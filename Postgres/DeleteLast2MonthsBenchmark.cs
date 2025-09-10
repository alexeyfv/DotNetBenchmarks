using BenchmarkDotNet.Attributes;
using Npgsql;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: Iterations)]
public class DeleteLast2MonthsBenchmark : BenchmarkBase
{
    [Params(100_000)]
    public override int ResourceCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        OneYearData = GenerateData(Start, End, ResourceCount);
    }

    [IterationSetup(Target = nameof(DeleteLast2Months))]
    public void SetupDeleteTable()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        create table billing_data (
            resource_id     int not null,
            billing_date    date not null,
            cost            decimal not null);
        """);

        BulkCopy(conn, "billing_data", OneYearData);
    }

    [IterationSetup(Target = nameof(DropLast2MonthPartitions))]
    public void SetupPartitionedTable()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        drop table if exists billing_data_partitioned cascade;
        create table billing_data_partitioned (
            resource_id     int not null,
            billing_date    date not null,
            cost            decimal not null
        ) partition by range (billing_date);
        """);

        for (var d = Start; d < End; d = d.AddMonths(1))
        {
            var partitionName = $"billing_data_partitioned_{d:yyyy_MM}";
            var nextMonth = d.AddMonths(1);
            ExecuteCommand(conn,
            $"""
            create table {partitionName}
                partition of billing_data_partitioned
                for values from ('{d:yyyy-MM-dd}') to ('{nextMonth:yyyy-MM-dd}');
            """);
        }

        BulkCopy(conn, "billing_data_partitioned", OneYearData);
    }

    [Benchmark(Baseline = true)]
    public void DeleteLast2Months()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        delete from billing_data
        where billing_date >= '2025-11-01' and billing_date < '2026-01-01';
        """);
    }

    [Benchmark]
    public void DropLast2MonthPartitions()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        drop table if exists billing_data_partitioned_2025_11;
        drop table if exists billing_data_partitioned_2025_12;
        """);
    }
}

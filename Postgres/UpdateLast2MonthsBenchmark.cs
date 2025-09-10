using BenchmarkDotNet.Attributes;
using Npgsql;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: Iterations)]
public class UpdateLast2MonthsBenchmark : BenchmarkBase
{
    [Params(100_000)]
    public override int ResourceCount { get; set; }

    protected Data[] Last2MonthsData = [];
    
    [GlobalSetup]
    public void Setup()
    {
        OneYearData = GenerateData(Start, End, ResourceCount);
        Last2MonthsData = GenerateData(End.AddMonths(-2), End, ResourceCount);
    }

    [IterationSetup(Targets = [nameof(IndexRecreation), nameof(Default)])]
    public void SetupBulkCopy()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        drop index if exists idx_billing_data_billing_date_resource_id;

        create table billing_data (
            resource_id     int not null,
            billing_date    date not null,
            cost            decimal not null);

        create index idx_billing_data_billing_date_resource_id
        on billing_data(billing_date, resource_id);
        """);

        BulkCopy(conn, "billing_data", OneYearData);
    }

    [IterationSetup(Targets = [nameof(Partitioned)])]
    public void SetupBulkCopyPartitioned()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        drop table if exists billing_data_partitioned cascade;
        drop index if exists idx_billing_data_partitioned_billing_date_resource_id;

        create table billing_data_partitioned (
            resource_id     int not null,
            billing_date    date not null,
            cost            decimal not null
        ) partition by range (billing_date);
        
        create index idx_billing_data_partitioned_billing_date_resource_id
        on billing_data_partitioned(billing_date, resource_id);
        """
        );

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

    [Benchmark]
    public int IndexRecreation()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        // Drop last 2 month of data and index
        ExecuteCommand(conn,
        """
        delete from billing_data
        where billing_date >= '2025-11-01' and billing_date < '2026-01-01';
        drop index if exists idx_billing_data_billing_date_resource_id;
        """);

        BulkCopy(conn, "billing_data", Last2MonthsData);

        // Recreate index
        return ExecuteCommand(conn,
        """
        create index idx_billing_data_billing_date_resource_id
        on billing_data(billing_date, resource_id);
        """);
    }

    [Benchmark(Baseline = true)]
    public void Default()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        // Drop last 2 month of data
        ExecuteCommand(conn,
        """
        delete from billing_data
        where billing_date >= '2025-11-01' and billing_date < '2026-01-01';
        """);

        BulkCopy(conn, "billing_data", Last2MonthsData);
    }

    [Benchmark]
    public void Partitioned()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        // Recreate partitions for last 2 months
        ExecuteCommand(conn,
        """
        drop table if exists billing_data_partitioned_2025_11;
        drop table if exists billing_data_partitioned_2025_12;
        create table billing_data_partitioned_2025_11
            partition of billing_data_partitioned
            for values from ('2025-11-01') to ('2025-12-01');
        create table billing_data_partitioned_2025_12
            partition of billing_data_partitioned
            for values from ('2025-12-01') to ('2026-01-01');
        """);

        // Bulk copy last 2 months data
        BulkCopy(conn, "billing_data_partitioned", Last2MonthsData);
    }
}

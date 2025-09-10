using BenchmarkDotNet.Attributes;
using Npgsql;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: Iterations)]
public class IndexMaintainanceBenchmark : BenchmarkBase
{
    [Params(100_000)]
    public override int ResourceCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        OneYearData = GenerateData(Start, End, ResourceCount);
    }

    [IterationSetup(Target = nameof(DropIndex))]
    public void SetupTableWithIndex()
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

    [IterationSetup(Target = nameof(CreateIndex))]
    public void SetupTableWithoutIndex()
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
        """);
        BulkCopy(conn, "billing_data", OneYearData);
    }

    [Benchmark]
    public void DropIndex()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        drop index if exists idx_billing_data_billing_date_resource_id;
        """);
    }

    [Benchmark]
    public void CreateIndex()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        create index idx_billing_data_billing_date_resource_id
        on billing_data(billing_date, resource_id);
        """);
    }
}

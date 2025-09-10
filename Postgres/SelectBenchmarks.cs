using BenchmarkDotNet.Attributes;
using Npgsql;

namespace Benchmark;

public class SelectBenchmarks : BenchmarkBase
{
    [Params(100_000)]
    public override int ResourceCount { get; set; }

    [GlobalSetup(Target = nameof(SelectGroupByNoIndex))]
    public void SetupQueryNoIndex()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        drop table if exists billing_data_no_index;

        create table billing_data_no_index (
            resource_id     int not null,
            billing_date    date not null,
            cost            decimal not null);
        """);

        BulkCopy(conn, "billing_data_no_index", OneYearData);
    }

    [GlobalSetup(Target = nameof(SelectGroupByWithCompositeIndex))]
    public void SetupQueryWithCompositeIndex()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        drop index if exists idx_billing_data_partitioned_date;

        create table billing_data (
            resource_id     int not null,
            billing_date    date not null,
            cost            decimal not null);

        create index idx_billing_data_partitioned_date
        on billing_data(billing_date, resource_id);
        """);

        BulkCopy(conn, "billing_data", OneYearData);
    }

    [GlobalSetup(Target = nameof(SelectGroupByWithIndexInclude))]
    public void SetupQueryWithIndexInclude()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();
        
        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        drop index if exists idx_billing_data_partitioned_date;

        create table billing_data (
            resource_id     int not null,
            billing_date    date not null,
            cost            decimal not null);

        create index idx_billing_data_partitioned_date
        on billing_data(billing_date) include (resource_id, cost);
        """);

        BulkCopy(conn, "billing_data", OneYearData);
    }

    [Benchmark]
    public (DateTime, int, decimal) SelectGroupByNoIndex()
    {
        var sql =
        """
        select billing_date, resource_id, sum(cost) 
        from billing_data_no_index 
        group by billing_date, resource_id;
        """;

        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        return Select(conn, sql);
    }

    [Benchmark(Baseline = true)]
    public (DateTime, int, decimal) SelectGroupByWithCompositeIndex()
    {
        var sql =
        """
        select billing_date, resource_id, sum(cost) 
        from billing_data 
        group by billing_date, resource_id;
        """;

        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        return Select(conn, sql);
    }

    [Benchmark]
    public (DateTime, int, decimal) SelectGroupByWithCompositeIndexDiffOrder()
    {
        var sql =
        """
        select billing_date, resource_id, sum(cost) 
        from billing_data 
        group by resource_id, billing_date;
        """;

        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        return Select(conn, sql);
    }

    [Benchmark]
    public (DateTime, int, decimal) SelectGroupByWithIndexInclude()
    {
        var sql =
        """
        select billing_date, resource_id, sum(cost) 
        from billing_data 
        group by billing_date, resource_id;
        """;

        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        return Select(conn, sql);
    }
}

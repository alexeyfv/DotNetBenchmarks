using BenchmarkDotNet.Attributes;
using Npgsql;

namespace Benchmark;

[SimpleJob(iterationCount: Iterations)]
public class SelectWithoutIndexBenchmarks : BenchmarkBase
{
    [Params("temp", "unlogged", "regular")]
    public string CreateTable { get; set; } = string.Empty;

    [ParamsSource(nameof(GetSize))]
    public override int BatchSize { get; set; }

    public string Sql { get; set; } = string.Empty;

    private NpgsqlConnection conn = null!;

    [IterationSetup]
    public void Setup()
    {
        DataRows = GenerateDataRows();

        var createTable = CreateTable switch
        {
            "temp" => "create temp table",
            "unlogged" => "create unlogged table",
            _ => "create table"
        };

        Sql =
        $"""
        drop table if exists billing_data;
        drop index if exists idx_billing_data;
        
        {createTable} billing_data (
            resource         text not null,
            billing_date     date not null,
            cost             int not null);
        """;

        conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn, Sql);

        BulkCopy(conn);
    }

    [IterationCleanup]
    public void Cleanup()
    {
        conn.Close();
        conn.Dispose();
    }

    [Benchmark]
    public int Select()
    {
        var sql =
        """
        select resource, billing_date, sum(cost)
        from billing_data
        group by resource, billing_date
        """;

        return Select(conn, sql);
    }

    public static IEnumerable<int> GetSize()
    {
        for (int i = 10_000; i < 100_000; i += 3_600) yield return i;
        for (int i = 100_000; i <= 1_000_000; i += 36_000) yield return i;
    }    
}

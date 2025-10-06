using BenchmarkDotNet.Attributes;
using Npgsql;

namespace Benchmark;

[SimpleJob(iterationCount: Iterations)]
public class TempBufferInfluence : BenchmarkBase
{
    public override int BatchSize { get; set; } = 1_000_000;

    [Params("temp", "unlogged", "regular")]
    public string CreateTable { get; set; } = string.Empty;

    [Params(1024, 1024 * 2, 1024 * 4, 1024 * 8, 1024 * 16, 1024 * 32, 1024 * 64)]
    public int TempBufferSize { get; set; }

    public string Sql { get; set; } = string.Empty;

    [GlobalSetup]
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
        
        set temp_buffers = {TempBufferSize};
        
        {createTable} billing_data (
            resource         text not null,
            billing_date     date not null,
            cost             int not null);

        create index idx_billing_data on billing_data(resource, billing_date) include(cost);
        """;
    }

    [Benchmark]
    public ulong BulkCopy()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        // We have to create the table within the benchmark 
        // because temp tables are automatically dropped at the end of the session
        // But this is relatively fast compared to bulk copy
        ExecuteCommand(conn, Sql);

        return BulkCopy(conn);
    }
}

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 25)]
public class BulkCopyPerTableCreation : BenchmarkBase
{
    [ParamsSource(nameof(GetBatchSize))]
    public override int BatchSize { get; set; }

    [Params("temp", "unlogged", "regular")]
    public string CreateTable { get; set; } = string.Empty;

    [Params("with index", "no index")]
    public string CreateIndex { get; set; } = string.Empty;

    public string Sql { get; set; } = string.Empty;

    [GlobalSetup]
    public void Setup()
    {
        DataRows = GenerateDataRows();

        var createTable = CreateTable switch
        {
            "temp" => "create temp table",
            "unlogged" => "create unlogged table",
            _ => "create table"
        };

        var createIndex = CreateIndex switch
        {
            "with index" => "create index idx_billing_data on billing_data(resource, billing_date) include(cost);",
            _ => string.Empty
        };

        Sql =
        $"""
        drop table if exists billing_data;
        drop index if exists idx_billing_data;
        
        {createTable} billing_data (
            resource         text not null,
            billing_date     date not null,
            cost             int not null);

        {createIndex}
        """;
    }

    [Benchmark]
    public ulong BulkCopy()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        // We have to create the table within the benchmark 
        // because temp tables are automatically dropped at the end of the session
        // But this is relatively fast compared to bulk copy
        ExecuteCommand(conn, Sql);

        return BulkCopy(conn);
    }
}
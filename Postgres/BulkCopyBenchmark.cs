using System.Data;
using System.Diagnostics;
using System.Text;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.ReportColumns;

using Npgsql;

using NpgsqlTypes;

namespace Benchmark;

[MemoryDiagnoser]
[IterationCount(25)]
public partial class BulkCopyBenchmark
{
    [ReportColumn(Aggregation = Aggregation.Median)]
    public long CreateTableTime { get; set; }

    [ReportColumn(Aggregation = Aggregation.Median)]
    public long CreateIndexTime { get; set; }

    [ReportColumn(Aggregation = Aggregation.Median)]
    public long BulkCopyTime { get; set; }

    [ReportColumn(Aggregation = Aggregation.Median)]
    public long AnalyzeTime { get; set; }

    [ReportColumn(Aggregation = Aggregation.Median)]
    public long SelectTime { get; set; }

    [ReportColumn]
    public string ExecutionPlan { get; set; } = string.Empty;

    private const string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=sa;Password=qweQWE123!";

    private Stopwatch Stopwatch { get; set; } = new();

    private DataRow[] Data { get; set; } = [];

    [IterationSetup]
    public void IterationSetup()
    {
        var rnd = new Random(987654321);
        var data = new List<DataRow>();

        // 100 unique resources
        var resources = Enumerable.Range(0, 100).Select(_ => Guid.NewGuid().ToString()).ToArray();

        var date = new DateTime(2026, 2, 1);
        var days = DateTime.DaysInMonth(2026, 2);

        foreach (var _ in Enumerable.Range(0, 1_000_000))
        {
            // Randomly distribute data across resources and dates
            var resource = resources[rnd.Next(resources.Length)];
            var billingDate = date.AddDays(rnd.Next(days));
            var cost = rnd.Next(0, 1001);

            data.Add(new DataRow(resource, billingDate, cost));
        }

        Data = [.. data];
    }

    [Benchmark]
    // Temporary table
    [Arguments("temp", true, true, "2", "64", "1024", "1000", "0.1", "on")]
    [Arguments("temp", true, true, "2", "64", "1024", "1000", "0.1", "off")]
    [Arguments("temp", true, true, "4", "0", "0", "0", "0", "on")]
    [Arguments("temp", true, true, "4", "0", "0", "0", "0", "off")]
    [Arguments("temp", true, true, "8", "0", "0", "0", "0", "on")]
    [Arguments("temp", true, true, "8", "0", "0", "0", "0", "off")]
    [Arguments("temp", true, false, "2", "64", "1024", "1000", "0.1", "on")]
    [Arguments("temp", true, false, "2", "64", "1024", "1000", "0.1", "off")]
    [Arguments("temp", true, false, "4", "0", "0", "0", "0", "on")]
    [Arguments("temp", true, false, "4", "0", "0", "0", "0", "off")]
    [Arguments("temp", true, false, "8", "0", "0", "0", "0", "on")]
    [Arguments("temp", true, false, "8", "0", "0", "0", "0", "off")]
    [Arguments("temp", false, false, "2", "64", "1024", "1000", "0.1", "on")]
    [Arguments("temp", false, false, "2", "64", "1024", "1000", "0.1", "off")]
    [Arguments("temp", false, false, "4", "0", "0", "0", "0", "on")]
    [Arguments("temp", false, false, "4", "0", "0", "0", "0", "off")]
    [Arguments("temp", false, false, "8", "0", "0", "0", "0", "on")]
    [Arguments("temp", false, false, "8", "0", "0", "0", "0", "off")]
    // Unlogged table
    [Arguments("unlogged", true, true, "2", "64", "1024", "1000", "0.1", "on")]
    [Arguments("unlogged", true, true, "2", "64", "1024", "1000", "0.1", "off")]
    [Arguments("unlogged", true, true, "4", "0", "0", "0", "0", "on")]
    [Arguments("unlogged", true, true, "4", "0", "0", "0", "0", "off")]
    [Arguments("unlogged", true, true, "8", "0", "0", "0", "0", "on")]
    [Arguments("unlogged", true, true, "8", "0", "0", "0", "0", "off")]
    [Arguments("unlogged", true, false, "2", "64", "1024", "1000", "0.1", "on")]
    [Arguments("unlogged", true, false, "2", "64", "1024", "1000", "0.1", "off")]
    [Arguments("unlogged", true, false, "4", "0", "0", "0", "0", "on")]
    [Arguments("unlogged", true, false, "4", "0", "0", "0", "0", "off")]
    [Arguments("unlogged", true, false, "8", "0", "0", "0", "0", "on")]
    [Arguments("unlogged", true, false, "8", "0", "0", "0", "0", "off")]
    [Arguments("unlogged", false, false, "2", "64", "1024", "1000", "0.1", "on")]
    [Arguments("unlogged", false, false, "2", "64", "1024", "1000", "0.1", "off")]
    [Arguments("unlogged", false, false, "4", "0", "0", "0", "0", "on")]
    [Arguments("unlogged", false, false, "4", "0", "0", "0", "0", "off")]
    [Arguments("unlogged", false, false, "8", "0", "0", "0", "0", "on")]
    [Arguments("unlogged", false, false, "8", "0", "0", "0", "0", "off")]
    // Regular table (with WAL)
    [Arguments("", true, true, "2", "64", "1024", "1000", "0.1", "on")]
    [Arguments("", true, true, "2", "64", "1024", "1000", "0.1", "off")]
    [Arguments("", true, true, "4", "0", "0", "0", "0", "on")]
    [Arguments("", true, true, "4", "0", "0", "0", "0", "off")]
    [Arguments("", true, true, "8", "0", "0", "0", "0", "on")]
    [Arguments("", true, true, "8", "0", "0", "0", "0", "off")]
    [Arguments("", true, false, "2", "64", "1024", "1000", "0.1", "on")]
    [Arguments("", true, false, "2", "64", "1024", "1000", "0.1", "off")]
    [Arguments("", true, false, "4", "0", "0", "0", "0", "on")]
    [Arguments("", true, false, "4", "0", "0", "0", "0", "off")]
    [Arguments("", true, false, "8", "0", "0", "0", "0", "on")]
    [Arguments("", true, false, "8", "0", "0", "0", "0", "off")]
    [Arguments("", false, false, "2", "64", "1024", "1000", "0.1", "on")]
    [Arguments("", false, false, "2", "64", "1024", "1000", "0.1", "off")]
    [Arguments("", false, false, "4", "0", "0", "0", "0", "on")]
    [Arguments("", false, false, "4", "0", "0", "0", "0", "off")]
    [Arguments("", false, false, "8", "0", "0", "0", "0", "on")]
    [Arguments("", false, false, "8", "0", "0", "0", "0", "off")]
    public void Run(
        string tableType,
        bool createIndex,
        bool analyzeData,
        string workers,
        string minIndexScanSize,
        string minTableScanSize,
        string setupCost,
        string tupleCost,
        string hashAgg)
    {
        var settingsSql =
            $"""
            set local max_parallel_workers_per_gather =   {workers};
            set local min_parallel_index_scan_size =      {minIndexScanSize};
            set local min_parallel_table_scan_size =      {minTableScanSize};
            set local parallel_setup_cost =               {setupCost};
            set local parallel_tuple_cost =               {tupleCost};
            set local enable_hashagg =                    {hashAgg};
            """;

        var recreateTableSql =
            $"""
            drop table if exists billing_data;
            create {tableType} table billing_data (
                resource         text not null,
                billing_date     date not null,
                cost             int not null);
            """;

        // Setup
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        using var tx = conn.BeginTransaction();

        ExecuteCommand(conn, settingsSql);

        Stopwatch.Restart();

        // Recreate table
        ExecuteCommand(conn, recreateTableSql);

        CreateTableTime = Stopwatch.ElapsedMilliseconds;

        // Create index
        if (createIndex)
        {
            ExecuteCommand(conn,
            """
            create index idx_billing_data 
            on billing_data(resource, billing_date)
            include (cost);
            """);
        }

        CreateIndexTime = Stopwatch.ElapsedMilliseconds;

        // Bulk copy
        BulkCopy(Data, conn);

        BulkCopyTime = Stopwatch.ElapsedMilliseconds;

        // Analyze
        if (analyzeData)
        {
            ExecuteCommand(conn, "analyze billing_data;");
        }

        AnalyzeTime = Stopwatch.ElapsedMilliseconds;

        // Execute query
        using (var selectCommand = conn.CreateCommand())
        {
            selectCommand.CommandText =
            """
            select resource, billing_date, sum(cost)
            from billing_data
            group by resource, billing_date
            """;

            using var reader = selectCommand.ExecuteReader();
            var count = 0;
            while (reader.Read()) count++;
        }

        SelectTime = Stopwatch.ElapsedMilliseconds;

        // Get execution plan
        ExecutionPlan = GetExecutionPlan(conn);
    }

    public static string GetExecutionPlan(NpgsqlConnection conn)
    {
        var hashAggregate = false;
        var groupAggregate = false;
        var seqScan = false;
        var indexScan = false;
        var indexOnlyScan = false;
        var parallel = false;

        using var explainCommand = conn.CreateCommand();

        explainCommand.CommandText =
        """
        explain
        select resource, billing_date, sum(cost)
        from billing_data
        group by resource, billing_date
        """;

        using var reader = explainCommand.ExecuteReader();
        while (reader.Read())
        {
            var line = reader.GetString(0);
            if (line.Contains("HashAggregate")) hashAggregate = true;
            if (line.Contains("GroupAggregate")) groupAggregate = true;
            if (line.Contains("Seq Scan")) seqScan = true;
            if (line.Contains("Index Scan")) indexScan = true;
            if (line.Contains("Index Only Scan")) indexOnlyScan = true;
            if (line.Contains("Workers Planned") || line.Contains("Workers Launched")) parallel = true;
        }

        var sb = new StringBuilder();

        if (parallel) sb.Append("Parallel ");
        if (hashAggregate) sb.Append("HashAggregate ");
        if (groupAggregate) sb.Append("GroupAggregate ");
        if (seqScan) sb.Append("Seq Scan ");
        if (indexScan) sb.Append("Index Scan ");
        if (indexOnlyScan) sb.Append("Index Only Scan ");

        return sb.ToString().Trim();
    }

    private static int ExecuteCommand(NpgsqlConnection conn, string sql)
    {
        using var command = conn.CreateCommand();
        command.CommandText = sql;
        return command.ExecuteNonQuery();
    }

    private static void BulkCopy(DataRow[] data, NpgsqlConnection conn)
    {
        var sql =
        """
        copy billing_data
        (resource, billing_date, cost)
        from stdin (format binary)
        """;

        using var importer = conn.BeginBinaryImport(sql);

        foreach (var d in data)
        {
            importer.StartRow();
            importer.Write(d.Resource, NpgsqlDbType.Text);
            importer.Write(d.BillingDate, NpgsqlDbType.Date);
            importer.Write(d.Cost, NpgsqlDbType.Integer);
        }

        importer.Complete();
    }

    private record DataRow(string Resource, DateTime BillingDate, int Cost);
}

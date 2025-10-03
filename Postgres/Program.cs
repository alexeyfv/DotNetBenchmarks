using System.Diagnostics;
using System.Text;
using Benchmark;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Npgsql;
using NpgsqlTypes;

// var summaryStyle = SummaryStyle
//     .Default
//     .WithRatioStyle(RatioStyle.Percentage);

// var config = ManualConfig
//     .Create(DefaultConfig.Instance)
//     .WithSummaryStyle(summaryStyle);

// BenchmarkSwitcher
//     .FromAssembly(typeof(Program).Assembly)
//     .Run(args, config);

Param[] tableParams =
[
    new Param("temp", "create temp table"),
    new Param("unlogged", "create unlogged table"),
    new Param("regular", "create table")
];
SettingParam[] settingsParam =
[
    new SettingParam("default", 2, 64, 1024, 1000, 0.1, "on"),
    new SettingParam("default_hashagg_off", 2, 64, 1024, 1000, 0.1, "off"),
    new SettingParam("4_workers", 4, 0, 0, 1000, 0.1, "on"),
    new SettingParam("4_workers_hashagg_off", 4, 0, 0, 1000, 0.1, "off"),
    new SettingParam("8_workers", 8, 0, 0, 1000, 0.1, "on"),
    new SettingParam("8_workers_hashagg_off", 8, 0, 0, 1000, 0.1, "off")
];
Param[] createIndexParams =
[
    new Param("with_index", "create index idx_billing_data on billing_data(resource, billing_date) include (cost);"),
    new Param("no_index", "-- no index")
];
Param[] analyzeParams =
[
    new Param("analyze", "analyze billing_data;"),
    new Param("no_analyze", "-- no analyze")
];

var rnd = new Random(987654321);
var data = new List<DataRow>();

var resources = Enumerable.Range(0, 100).Select(_ => Guid.NewGuid().ToString()).ToArray();

var date = new DateTime(2025, 9, 1);
var days = DateTime.DaysInMonth(2025, 9);

foreach (var _ in Enumerable.Range(0, 1_000_000))
{
    var resource = resources[rnd.Next(resources.Length)];
    var billingDate = date.AddDays(rnd.Next(days));
    var cost = rnd.Next(0, 1001);

    data.Add(new DataRow(resource, billingDate, cost));
}

foreach (var t in tableParams)
{
    foreach (var setting in settingsParam)
    {
        foreach (var createIndex in createIndexParams)
        {
            foreach (var analyze in analyzeParams)
            {
                Run(data, t, setting, createIndex, analyze);
            }
        }
    }
}

const int WarmupIterations = 5;
const int WorkloadIterations = 25;

static void Run(List<DataRow> data, Param createTable, SettingParam setting, Param createIndex, Param analyze)
{
    var measurements = new List<BenchmarkMeasure>();

    Console.WriteLine(
        """
        Table:

        {0}

        Settings: 
        
        set max_parallel_workers_per_gather =   {1};
        set min_parallel_index_scan_size =      {2};
        set min_parallel_table_scan_size =      {3};
        set parallel_setup_cost =               {4};
        set parallel_tuple_cost =               {5};
        set enable_hashagg =                    {6};

        Create index: 
        
        {7}

        Analyze: 
        
        {8}

        Warmup: {9} iterations
        Running {10} iterations...
        """,
        createTable.Value,
        setting.Workers,
        setting.MinIndexScanSize,
        setting.MinTableScanSize,
        setting.SetupCost,
        setting.TupleCost,
        setting.HashAgg,
        createIndex.Value,
        analyze.Value,
        WarmupIterations,
        WorkloadIterations
    );

    Console.WriteLine("Iteration, Elapsed, HashAggregate, GroupAggregate, SeqScan, IndexScan, IndexOnlyScan, Parallel");

    for (var i = 0; i < WorkloadIterations; i++)
    {
        // Setup
        using var conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=postgres;Username=sa;Password=qweQWE123!");
        conn.Open();

        using var tx = conn.BeginTransaction();

        ExecuteCommand(conn,
        $"""
        set max_parallel_workers_per_gather	=   {setting.Workers};
        set min_parallel_index_scan_size =      {setting.MinIndexScanSize};
        set min_parallel_table_scan_size =      {setting.MinTableScanSize};
        set parallel_setup_cost =               {setting.SetupCost};
        set parallel_tuple_cost =               {setting.TupleCost};
        set enable_hashagg =                    {setting.HashAgg};

        drop table if exists billing_data;
        {createTable.Value} billing_data (
            resource         text not null,
            billing_date     date not null,
            cost             int not null);

        {createIndex.Value}
        """);

        var sql =
        """
        copy billing_data
        (resource, billing_date, cost)
        from stdin (format binary)
        """;

        using (var importer = conn.BeginBinaryImport(sql))
        {
            foreach (var d in data)
            {
                importer.StartRow();
                importer.Write(d.Resource, NpgsqlDbType.Text);
                importer.Write(d.BillingDate, NpgsqlDbType.Date);
                importer.Write(d.Cost, NpgsqlDbType.Integer);
            }

            importer.Complete();
        }

        // Analyze
        ExecuteCommand(conn, analyze.Value);

        // Warmup
        for (var w = 0; w < WarmupIterations; w++)
        {
            using var select = conn.CreateCommand();
            select.CommandText =
            """
            select resource, billing_date, sum(cost)
            from billing_data
            group by resource, billing_date
            """;

            using (var reader = select.ExecuteReader())
            {
                var count = 0;
                while (reader.Read()) count++;
            }
        }

        // Benchmark
        var elapsedMilliseconds = 0L;
        var hashAggregate = false;
        var groupAggregate = false;
        var seqScan = false;
        var indexScan = false;
        var indexOnlyScan = false;
        var parallel = false;

        // Execute query
        using (var select = conn.CreateCommand())
        {
            select.CommandText =
            """
            select resource, billing_date, sum(cost)
            from billing_data
            group by resource, billing_date
            """;

            var sw = Stopwatch.StartNew();
            using (var reader = select.ExecuteReader())
            {
                var count = 0;
                while (reader.Read()) count++;
            }
            elapsedMilliseconds = sw.ElapsedMilliseconds;
        }

        // Get execution plan info
        using (var explain = conn.CreateCommand())
        {
            explain.CommandText =
            """
            explain
            select resource, billing_date, sum(cost)
            from billing_data
            group by resource, billing_date
            """;

            using (var reader = explain.ExecuteReader())
            {
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
            }
        }

        var result = new BenchmarkMeasure
        {
            CreateTable = createTable.Value,
            ElapsedMilliseconds = elapsedMilliseconds,
            Workers = setting.Workers,
            MinIndexScanSize = setting.MinIndexScanSize,
            MinTableScanSize = setting.MinTableScanSize,
            SetupCost = setting.SetupCost,
            TupleCost = setting.TupleCost,
            HashAgg = setting.HashAgg,
            CreateIndex = createIndex.Value,
            Analyze = analyze.Value,
            HashAggregate = hashAggregate,
            GroupAggregate = groupAggregate,
            SeqScan = seqScan,
            IndexScan = indexScan,
            IndexOnlyScan = indexOnlyScan,
            Parallel = parallel
        };

        Console.WriteLine("{0,9}, {1,7}, {2,13}, {3,14}, {4,7}, {5,9}, {6,13}, {7,7}",
            i + 1,
            result.ElapsedMilliseconds,
            result.HashAggregate,
            result.GroupAggregate,
            result.SeqScan,
            result.IndexScan,
            result.IndexOnlyScan,
            result.Parallel
        );

        measurements.Add(result);

        tx.Rollback();
    }

    Console.WriteLine(
        """
        ✨ Completed ✨ 
        Min: {0} ms, 
        Max: {1} ms, 
        Avg: {2} ms, 
        Median: {3} ms
        """,
        measurements.Min(m => m.ElapsedMilliseconds),
        measurements.Max(m => m.ElapsedMilliseconds),
        measurements.Average(m => m.ElapsedMilliseconds),
        measurements.OrderBy(m => m.ElapsedMilliseconds).ElementAt(measurements.Count / 2).ElapsedMilliseconds);

    // Save to csv
    var sb = new StringBuilder();
    sb.AppendLine("ElapsedMilliseconds,CreateTable,CreateIndex,Analyze,Workers,MinIndexScanSize,MinTableScanSize,SetupCost,TupleCost,HashAgg,HashAggregate,GroupAggregate,SeqScan,IndexScan,IndexOnlyScan,Parallel");
    foreach (var m in measurements)
    {
        sb.AppendFormat(@"{0},", m.ElapsedMilliseconds);
        sb.AppendFormat(@"""{0}"",", m.CreateTable);
        sb.AppendFormat(@"""{0}"",", m.CreateIndex);
        sb.AppendFormat(@"""{0}"",", m.Analyze);
        sb.AppendFormat(@"{0},", m.Workers);
        sb.AppendFormat(@"{0},", m.MinIndexScanSize);
        sb.AppendFormat(@"{0},", m.MinTableScanSize);
        sb.AppendFormat(@"{0},", m.SetupCost);
        sb.AppendFormat(@"{0},", m.TupleCost);
        sb.AppendFormat(@"{0},", m.HashAgg);
        sb.AppendFormat(@"{0},", m.HashAggregate);
        sb.AppendFormat(@"{0},", m.GroupAggregate);
        sb.AppendFormat(@"{0},", m.SeqScan);
        sb.AppendFormat(@"{0},", m.IndexScan);
        sb.AppendFormat(@"{0},", m.IndexOnlyScan);
        sb.AppendFormat(@"{0}", m.Parallel);
        sb.AppendLine();
    }

    var filename = new StringBuilder();
    filename.Append("postgres_");
    filename.Append(createTable.Name);
    filename.Append(createIndex.Name);
    filename.Append(analyze.Name);
    filename.Append("_workers_").Append(setting.Workers);
    filename.Append("_minidx_").Append(setting.MinIndexScanSize);
    filename.Append("_mintbl_").Append(setting.MinTableScanSize);
    filename.Append("_setup_").Append(setting.SetupCost);
    filename.Append("_tuple_").Append(setting.TupleCost);
    filename.Append("_hashagg_").Append(setting.HashAgg);
    filename.Append(".csv");
    File.WriteAllText(filename.ToString(), sb.ToString());
}

static int ExecuteCommand(NpgsqlConnection conn, string sql)
{
    using var command = conn.CreateCommand();
    command.CommandText = sql;
    return command.ExecuteNonQuery();
}

record SettingParam(string Name, int Workers, int MinIndexScanSize, int MinTableScanSize, int SetupCost, double TupleCost, string HashAgg);
record Param (string Name, string Value);
record DataRow(string Resource, DateTime BillingDate, int Cost);

record BenchmarkMeasure
{
    public required long ElapsedMilliseconds { get; init; }

    // Parameters
    public required string CreateTable { get; init; }
    public required string CreateIndex { get; init; }
    public required int Workers { get; init; }
    public required int MinIndexScanSize { get; init; }
    public required int MinTableScanSize { get; init; }
    public required int SetupCost { get; init; }
    public required double TupleCost { get; init; }
    public required string HashAgg { get; init; }
    public required string Analyze { get; init; }

    // Execution plan details
    public required bool HashAggregate { get; init; }
    public required bool GroupAggregate { get; init; }
    public required bool SeqScan { get; init; }
    public required bool IndexScan { get; init; }
    public required bool IndexOnlyScan { get; init; }
    public required bool Parallel { get; init; }
}
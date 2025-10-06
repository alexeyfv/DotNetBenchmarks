using System.Diagnostics;
using System.Text;
using Npgsql;
using NpgsqlTypes;

namespace Benchmark;

public static class AllInOneBenchmark
{
    public static void Run()
    {
        Param[] tableParams =
        [
            new Param("temp", "create temp table"),
            new Param("unlogged", "create unlogged table"),
            new Param("regular", "create table")
        ];

        SettingParam[] settingsParam =
        [
            new SettingParam("default", "2", "64", "1024", "1000", "0.1", "on"),
            new SettingParam("default_hashagg_off", "2", "64", "1024", "1000", "0.1", "off"),
            new SettingParam("4_workers", "4", "0", "0", "0", "0", "on"),
            new SettingParam("4_workers_hashagg_off", "4", "0", "0", "0", "0", "off"),
            new SettingParam("8_workers", "8", "0", "0", "0", "0", "on"),
            new SettingParam("8_workers_hashagg_off", "8", "0", "0", "0", "0", "off")
        ];

        Param[] createIndexParams =
        [
            new Param("with_index", "create index idx_billing_data on billing_data(resource, billing_date) include (cost);"),
            new Param("no_index", "")
        ];
        
        Param[] analyzeParams =
        [
            new Param("analyze", "analyze billing_data;"),
            new Param("no_analyze", "")
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

        const string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=sa;Password=qweQWE123!";
        const int WorkloadIterations = 25;

        static void Run(List<DataRow> data, Param createTable, SettingParam setting, Param createIndex, Param analyze)
        {
            var measurements = new List<BenchmarkMeasure>();

            Console.WriteLine(
                """
                Table: {0}
                Create index: {7}
                Analyze: {8}

                Settings: 
                
                set max_parallel_workers_per_gather =   {1};
                set min_parallel_index_scan_size =      {2};
                set min_parallel_table_scan_size =      {3};
                set parallel_setup_cost =               {4};
                set parallel_tuple_cost =               {5};
                set enable_hashagg =                    {6};

                Running {9} iterations...
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
                WorkloadIterations
            );

            Console.Write("{0, -15}, ", "Iteration");
            Console.Write("{0, -15}, ", "CreateTable");
            Console.Write("{0, -15}, ", "CreateIndex");
            Console.Write("{0, -15}, ", "BulkCopy");
            Console.Write("{0, -15}, ", "Analyze");
            Console.Write("{0, -15}, ", "Select");
            Console.Write("{0, -15}, ", "Total Time");
            Console.Write("{0, -15}", "Execution plan");
            Console.WriteLine();

            for (var i = 0; i < WorkloadIterations; i++)
            {
                // Setup
                using var conn = new NpgsqlConnection(ConnectionString);
                conn.Open();
                using var tx = conn.BeginTransaction();

                Setup(conn, setting);

                // Recreate table
                var sw = Stopwatch.StartNew();
                ExecuteCommand(conn,
                $"""
                drop table if exists billing_data;
                {createTable.Value} billing_data (
                    resource         text not null,
                    billing_date     date not null,
                    cost             int not null);
                """);
                var createTableTime = sw.ElapsedMilliseconds;

                // Create index
                if (!string.IsNullOrEmpty(createIndex.Value))
                {
                    ExecuteCommand(conn, createIndex.Value);
                }
                var createIndexTime = sw.ElapsedMilliseconds;

                // Bulk copy
                BulkCopy(data, conn);
                var bulkCopy = sw.ElapsedMilliseconds;

                // Analyze
                if (!string.IsNullOrEmpty(analyze.Value))
                {
                    ExecuteCommand(conn, analyze.Value);
                }
                var analyzeTime = sw.ElapsedMilliseconds;

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
                var select = sw.ElapsedMilliseconds;

                // Get execution plan info
                var hashAggregate = false;
                var groupAggregate = false;
                var seqScan = false;
                var indexScan = false;
                var indexOnlyScan = false;
                var parallel = false;
                using (var explainCommand = conn.CreateCommand())
                {
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
                }

                var result = new BenchmarkMeasure
                {
                    // Parameters
                    CreateTable = createTable.Name,
                    CreateIndex = createIndex.Name,
                    Analyze = analyze.Name,
                    Workers = setting.Workers,
                    MinIndexScanSize = setting.MinIndexScanSize,
                    MinTableScanSize = setting.MinTableScanSize,
                    SetupCost = setting.SetupCost,
                    TupleCost = setting.TupleCost,
                    HashAgg = setting.HashAgg,

                    // Measurements
                    CreateTableTime = createTableTime,
                    CreateIndexTime = createIndexTime - createTableTime,
                    BulkCopyTime = bulkCopy - createIndexTime,
                    AnalyzeTime = analyzeTime - bulkCopy,
                    SelectTime = select - analyzeTime,

                    // Execution plan details
                    HashAggregate = hashAggregate,
                    GroupAggregate = groupAggregate,
                    SeqScan = seqScan,
                    IndexScan = indexScan,
                    IndexOnlyScan = indexOnlyScan,
                    Parallel = parallel
                };

                Console.Write("{0, -15}, ", i + 1);
                Console.Write("{0, -15}, ", result.CreateTableTime);
                Console.Write("{0, -15}, ", result.CreateIndexTime);
                Console.Write("{0, -15}, ", result.BulkCopyTime);
                Console.Write("{0, -15}, ", result.AnalyzeTime);
                Console.Write("{0, -15}, ", result.SelectTime);
                Console.Write("{0, -15}, ", select); // Total
                Console.Write("{0, -15}", result.ExecutionPlan);
                Console.WriteLine();

                measurements.Add(result);

                tx.Rollback();
            }

            Console.WriteLine();
            Console.WriteLine("✨ Completed ✨");
            Console.WriteLine();

            // Save to csv
            var sb = new StringBuilder();

            // Measurements
            sb.Append("CreateTableTime,");
            sb.Append("CreateIndexTime,");
            sb.Append("BulkCopyTime,");
            sb.Append("AnalyzeTime,");
            sb.Append("SelectTime,");

            // Parameters
            sb.Append("CreateTable,");
            sb.Append("CreateIndex,");
            sb.Append("Analyze,");
            sb.Append("Workers,");
            sb.Append("MinIndexScanSize,");
            sb.Append("MinTableScanSize,");
            sb.Append("SetupCost,");
            sb.Append("TupleCost,");
            sb.Append("HashAgg,");

            // Execution plan
            sb.Append("ExecutionPlan,");
            sb.AppendLine();

            foreach (var m in measurements)
            {
                // Measurements
                sb.AppendFormat(@"{0,15},", m.CreateTableTime);
                sb.AppendFormat(@"{0,15},", m.CreateIndexTime);
                sb.AppendFormat(@"{0,12},", m.BulkCopyTime);
                sb.AppendFormat(@"{0,11},", m.AnalyzeTime);
                sb.AppendFormat(@"{0,10},", m.SelectTime);

                // Parameters
                sb.AppendFormat(@"{0,11},", m.CreateTable);
                sb.AppendFormat(@"{0,11},", m.CreateIndex);
                sb.AppendFormat(@"{0,7},", m.Analyze);
                sb.AppendFormat(@"{0,7},", m.Workers);
                sb.AppendFormat(@"{0,16},", m.MinIndexScanSize);
                sb.AppendFormat(@"{0,16},", m.MinTableScanSize);
                sb.AppendFormat(@"{0,9},", m.SetupCost);
                sb.AppendFormat(@"{0,9},", m.TupleCost);
                sb.AppendFormat(@"{0,7},", m.HashAgg);

                // Execution plan
                sb.AppendFormat(@"""{0,13}""", m.ExecutionPlan);
                sb.AppendLine();
            }

            var filename = new StringBuilder();
            filename.Append("postgres_");
            filename.Append(createTable.Name).Append("_");
            filename.Append(createIndex.Name).Append("_");
            filename.Append(analyze.Name).Append("_");
            filename.Append("workers_").Append(setting.Workers).Append("_");
            filename.Append("minidx_").Append(setting.MinIndexScanSize).Append("_");
            filename.Append("mintbl_").Append(setting.MinTableScanSize).Append("_");
            filename.Append("setup_").Append(setting.SetupCost).Append("_");
            filename.Append("tuple_").Append(setting.TupleCost).Append("_");
            filename.Append("hashagg_").Append(setting.HashAgg);
            filename.Append(".csv");
            File.WriteAllText(filename.ToString(), sb.ToString());
        }
    }

    static int ExecuteCommand(NpgsqlConnection conn, string sql)
    {
        using var command = conn.CreateCommand();
        command.CommandText = sql;
        return command.ExecuteNonQuery();
    }

    static void BulkCopy(List<DataRow> data, NpgsqlConnection conn)
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

    static int Setup(NpgsqlConnection conn, SettingParam setting)
    {
        return ExecuteCommand(conn,
        $"""
        set local max_parallel_workers_per_gather =   {setting.Workers};
        set local min_parallel_index_scan_size =      {setting.MinIndexScanSize};
        set local min_parallel_table_scan_size =      {setting.MinTableScanSize};
        set local parallel_setup_cost =               {setting.SetupCost};
        set local parallel_tuple_cost =               {setting.TupleCost};
        set local enable_hashagg =                    {setting.HashAgg};
        """);
    }

    record SettingParam(string Name, string Workers, string MinIndexScanSize, string MinTableScanSize, string SetupCost, string TupleCost, string HashAgg);
    record Param(string Name, string Value);
    record DataRow(string Resource, DateTime BillingDate, int Cost);

    record BenchmarkMeasure
    {
        // Measurements
        public required long CreateTableTime { get; init; }
        public required long CreateIndexTime { get; init; }
        public required long BulkCopyTime { get; init; }
        public required long AnalyzeTime { get; init; }
        public required long SelectTime { get; init; }

        // Parameters
        public required string CreateTable { get; init; }
        public required string CreateIndex { get; init; }
        public required string Analyze { get; init; }
        public required string Workers { get; init; }
        public required string MinIndexScanSize { get; init; }
        public required string MinTableScanSize { get; init; }
        public required string SetupCost { get; init; }
        public required string TupleCost { get; init; }
        public required string HashAgg { get; init; }

        // Execution plan details
        public required bool HashAggregate { get; init; }
        public required bool GroupAggregate { get; init; }
        public required bool SeqScan { get; init; }
        public required bool IndexScan { get; init; }
        public required bool IndexOnlyScan { get; init; }
        public required bool Parallel { get; init; }

        public string ExecutionPlan
        {
            get
            {
                var sb = new StringBuilder();
                if (Parallel) sb.Append("Parallel ");
                if (HashAggregate) sb.Append("HashAggregate ");
                if (GroupAggregate) sb.Append("GroupAggregate ");
                if (SeqScan) sb.Append("Seq Scan ");
                if (IndexScan) sb.Append("Index Scan ");
                if (IndexOnlyScan) sb.Append("Index Only Scan ");
                return sb.ToString().Trim();
            }
        }
    }
}
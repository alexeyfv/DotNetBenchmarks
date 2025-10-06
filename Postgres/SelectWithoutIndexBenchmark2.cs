using System.Diagnostics;
using System.Text;
using Npgsql;
using NpgsqlTypes;

namespace Benchmark;

public static class SelectWithoutIndexBenchmark2
{
    private const string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=sa;Password=qweQWE123!";
    private const int WorkloadIterations = 50;

    private static IEnumerable<int> GetSize()
    {
        for (int i = 10_000; i < 100_000; i += 3_600) yield return i;
        for (int i = 100_000; i <= 1_000_000; i += 36_000) yield return i;
    }

    public static void Run()
    {
        Param[] tableParams =
        [
            new Param("regular", "create table"),
            new Param("unlogged", "create unlogged table"),
            new Param("temp", "create temp table"),
        ];

        var rnd = new Random(987654321);
        var resources = Enumerable.Range(0, 100).Select(_ => Guid.NewGuid().ToString()).ToArray();

        var sb = new StringBuilder();

        // Iteration
        var iteration = 1;
        sb.Append("Iteration,");

        // Parameters
        sb.Append("BatchSize,");
        sb.Append("CreateTable,");

        // Measurements
        sb.Append("CreateTableTime,");
        sb.Append("BulkCopyTime,");
        sb.Append("SelectTime,");


        // Execution plan
        sb.Append("ExecutionPlan,");
        sb.AppendLine();

        foreach (var size in GetSize())
        {
            var data = new List<DataRow>();
            var date = new DateTime(2025, 9, 1);
            var days = DateTime.DaysInMonth(2025, 9);

            for (var i = 0; i < size; i++)
            {
                var resource = resources[rnd.Next(resources.Length)];
                var billingDate = date.AddDays(rnd.Next(days));
                var cost = rnd.Next(0, 1001);

                data.Add(new DataRow(resource, billingDate, cost));
            }

            foreach (var t in tableParams)
            {
                Console.WriteLine($"Running benchmark: Size={size}, TableType={t.Name}");
                
                Console.WriteLine("{0, -15}, {1, -15}, {2, -15}, {3, -15}, {4, -15}, {5, -15}, {6, -15}",
                    "CreateTableTime",
                    "BulkCopyTime",
                    "SelectTime",
                    "TotalTime",
                    "CreateTable",
                    "BatchSize",
                    "ExecutionPlan");

                foreach (var m in Run(data, t, size, sb))
                {
                    // Iteration
                    sb.AppendFormat(@"{0,10},", iteration++);

                    // Measurements
                    sb.AppendFormat(@"{0,15},", m.CreateTableTime);
                    sb.AppendFormat(@"{0,12},", m.BulkCopyTime);
                    sb.AppendFormat(@"{0,10},", m.SelectTime);

                    // Parameters
                    sb.AppendFormat(@"{0,11},", m.CreateTable);
                    sb.AppendFormat(@"{0,9},", m.BatchSize);

                    // Execution plan
                    sb.AppendFormat(@"""{0,13}""", m.ExecutionPlan);
                    sb.AppendLine();

                    Console.WriteLine("{0, -15}, {1, -15}, {2, -15}, {3, -15}, {4, -15}, {5, -15}, {6, -15}",
                        m.CreateTableTime,
                        m.BulkCopyTime,
                        m.SelectTime,
                        m.TotalTime,
                        m.CreateTable,
                        m.BatchSize,
                        m.ExecutionPlan);
                }
                
                Console.WriteLine($"Completed benchmark: Size={size}, TableType={t.Name}");
            }
        }

        File.WriteAllText("select_results.csv", sb.ToString());
    }


    static IEnumerable<BenchmarkMeasure> Run(List<DataRow> data, Param createTable, int batchSize, StringBuilder sb)
    {
        for (var i = 0; i < WorkloadIterations; i++)
        {
            // Setup
            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();

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

            // Bulk copy
            sw.Restart();
            BulkCopy(data, conn);
            var bulkCopy = sw.ElapsedMilliseconds;

            // Execute query
            sw.Restart();
            var (resource, billingDate, cost, x) = (string.Empty, DateTime.MinValue, 0, 0);
            using (var selectCommand = conn.CreateCommand())
            {
                selectCommand.CommandText =
                """
                    select resource, billing_date, sum(cost)
                    from billing_data
                    group by resource, billing_date
                    """;

                using var reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    resource = reader.GetString(0);
                    billingDate = reader.GetDateTime(1);
                    cost = reader.GetInt32(2);
                }
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
                BatchSize = batchSize,

                // Measurements
                CreateTableTime = createTableTime,
                BulkCopyTime = bulkCopy,
                SelectTime = select,

                // Execution plan details
                HashAggregate = hashAggregate,
                GroupAggregate = groupAggregate,
                SeqScan = seqScan,
                IndexScan = indexScan,
                IndexOnlyScan = indexOnlyScan,
                Parallel = parallel
            };

            yield return result;

            tx.Rollback();
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

    record Param(string Name, string Value);
    record DataRow(string Resource, DateTime BillingDate, int Cost);

    record BenchmarkMeasure
    {
        // Measurements
        public required long CreateTableTime { get; init; }
        public required long BulkCopyTime { get; init; }
        public required long SelectTime { get; init; }

        public long TotalTime => CreateTableTime + BulkCopyTime + SelectTime;

        // Parameters
        public required string CreateTable { get; init; }
        public required int BatchSize { get; init; }

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
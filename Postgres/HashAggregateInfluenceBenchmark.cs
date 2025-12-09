using System.Diagnostics;
using System.Text;
using Npgsql;
using NpgsqlTypes;


namespace Benchmark;

public static class HashAggregateInfluenceBenchmark
{
    private const string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=sa;Password=qweQWE123!";
    private const int WorkloadIterations = 50;

    private static IEnumerable<int> GetBatchSize()
    {
        for (int i = 10_000; i < 100_000; i += 3_600) yield return i;
        for (int i = 100_000; i <= 1_000_000; i += 36_000) yield return i;
    }

    public static void Run()
    {
        Param[] hashagg =
        [
            new Param("on", "on"),
            new Param("off", "off"),
        ];

        var rnd = new Random(987654321);
        var resources = Enumerable.Range(0, 100).Select(_ => Guid.NewGuid().ToString()).ToArray();

        var sb = new StringBuilder();

        // Iteration
        var iteration = 1;

        // Write CSV header (use same simple approach as in CardinalityInfluenceBenchmark)
        File.AppendAllText(
            "hashagg_influence_results.csv",
            "Iteration,SelectTime,HashAgg,BatchSize,ExecutionPlan\n");

        foreach (var size in GetBatchSize())
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

            foreach (var i in hashagg)
            {
                Console.WriteLine($"Running benchmark: HashAgg={i.Name}, BatchSize={size}...");

                // Print a simple CSV header to console similar to file header
                Console.WriteLine("Iteration,SelectTime,HashAgg,BatchSize,ExecutionPlan");

                foreach (var m in Run(data, i, size))
                {
                    // Build CSV line and persist, then print same line to console
                    var s = sb.Clear()
                        .AppendFormat(@"{0,9},", iteration++)
                        .AppendFormat(@"{0,10},", m.SelectTime)
                        .AppendFormat(@"{0,11},", m.HashAgg)
                        .AppendFormat(@"{0,9},", m.BatchSize)
                        .AppendFormat(@"""{0,13}""", m.ExecutionPlan)
                        .AppendLine()
                        .ToString();

                    File.AppendAllText("hashagg_influence_results.csv", s);
                    Console.Write(s);
                }

                Console.WriteLine($"Completed benchmark: Size={size}, HashAgg={i.Name}");
            }
        }
    }

    static IEnumerable<BenchmarkMeasure> Run(List<DataRow> data, Param hashagg, int batchSize)
    {
        for (var i = 0; i < WorkloadIterations; i++)
        {
            // Setup
            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();

            // Recreate table
            ExecuteCommand(conn,
            $"""
            drop table if exists billing_data;
            drop index if exists idx_billing_data;

            create table billing_data (
                resource         text not null,
                billing_date     date not null,
                cost             int not null);
            
            create index idx_billing_data
            on billing_data (resource, billing_date) 
            include (cost);

            set enable_hashagg = {hashagg.Value};
            """);

            // Bulk copy
            BulkCopy(data, conn);

            // Execute query
            var sw = Stopwatch.StartNew();
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
                HashAgg = hashagg.Name,
                BatchSize = batchSize,

                // Measurements
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
        public required long SelectTime { get; init; }

        // Parameters
        public required string HashAgg { get; init; }
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

using System.Diagnostics;
using System.Text;
using Npgsql;
using NpgsqlTypes;


namespace Benchmark;

public static class CardinalityInfluenceBenchmark
{
    private const string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=sa;Password=qweQWE123!";
    private const int WorkloadIterations = 50;

    private static IEnumerable<int> GetUniqueResources()
    {
        for (int i = 10; i < 1_000; i += 36) yield return i;
        for (int i = 1000; i < 10_000; i += 360) yield return i;
        for (int i = 10_000; i < 100_000; i += 3_600) yield return i;
        for (int i = 100_000; i <= 1_000_000; i += 36_000) yield return i;
    }

    public static void Run()
    {
        var rnd = new Random(987654321);
        var sb = new StringBuilder();
        var batchSize = 1_000_000;
        var iteration = 1;

        // Index parameters (same style as IndexInfluenceBenchmark)
        Param[] index =
        [
            new Param("no_index", ""),
            new Param("resource_billing-date",
            """
            create index idx_billing_data
            on billing_data (resource, billing_date);
            """),
            new Param("resource_billing-date_cost",
            """
            create index idx_billing_data
            on billing_data (resource, billing_date) 
            include (cost);
            """),
        ];

        File.AppendAllText(
            "cardinality_influence_results.csv",
            "Iteration,SelectTime,BatchSize,Index,ResourcesCount,ExecutionPlan\n");

        foreach (var resourceCount in GetUniqueResources())
        {
            var resources = Enumerable
                .Range(0, resourceCount)
                .Select(_ => Guid.NewGuid().ToString())
                .ToArray();

            var data = new List<DataRow>();
            var date = new DateTime(2025, 9, 1);
            var days = DateTime.DaysInMonth(2025, 9);

            for (var i = 0; i < batchSize; i++)
            {
                var resource = resources[i % resourceCount];
                var billingDate = date.AddDays(rnd.Next(days));
                var cost = rnd.Next(0, 1001);

                data.Add(new DataRow(resource, billingDate, cost));
            }


            // iterate over index options
            foreach (var idx in index)
            {
                Console.WriteLine($"Running benchmark: Index={idx.Name}, ResourcesCount={resourceCount}...");

                Console.WriteLine("Iteration,SelectTime,BatchSize,Index,ResourcesCount,ExecutionPlan");
                
                foreach (var m in Run(data, idx, resourceCount))
                {
                    var s = sb.Clear()
                        .AppendFormat(@"{0,9},", iteration++)
                        .AppendFormat(@"{0,10},", m.SelectTime)
                        .AppendFormat(@"{0,9},", batchSize)
                        .AppendFormat(@"{0,11},", m.Index)
                        .AppendFormat(@"{0,14},", m.ResourcesCount)
                        .AppendFormat(@"""{0,13}""", m.ExecutionPlan)
                        .AppendLine()
                        .ToString();

                    // Persist the CSV after each iteration
                    File.AppendAllText("cardinality_influence_results.csv", s);
                    Console.Write(s);
                }

                Console.WriteLine($"Completed benchmark group: Index={idx.Name}, ResourcesCount={resourceCount}.");
            }
        }
    }

    static IEnumerable<BenchmarkMeasure> Run(List<DataRow> data, Param index, int resourcesCount)
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

            create table billing_data (
                resource         text not null,
                billing_date     date not null,
                cost             int not null);
            
            {index.Value} -- create index (may be empty)
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
                Index = index.Name,
                ResourcesCount = resourcesCount,

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
        public required string Index { get; init; }
        public required int ResourcesCount { get; init; }

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

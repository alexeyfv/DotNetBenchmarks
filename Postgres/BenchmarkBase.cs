using Npgsql;

namespace Benchmark;

public abstract class BenchmarkBase
{
    public const int Iterations = 50;

    public abstract int BatchSize { get; set; }

    protected readonly string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=sa;Password=qweQWE123!";

    protected DataRow[] DataRows = [];

    protected record DataRow(string Resource, DateTime BillingDate, int Cost);

    public static IEnumerable<int> GetBatchSize()
    {
        // for (int i = 10_000; i <= 100_000; i += 3_600) yield return i;
        for (int i = 100_000; i <= 1_000_000; i += 36_000) yield return i;
    }

    protected DataRow[] GenerateDataRows()
    {
        var data = new List<DataRow>();
        var rnd = new Random();

        var resources = Enumerable.Range(0, 100)
            .Select(_ => Guid.NewGuid().ToString())
            .ToArray();

        var date = new DateTime(2025, 9, 1);
        var days = DateTime.DaysInMonth(2025, 9);

        for (var i = 0; i < BatchSize; i++)
        {
            var resource = resources[rnd.Next(resources.Length)];
            var billingDate = date.AddDays(rnd.Next(days));
            var cost = rnd.Next(0, 1001);

            data.Add(new DataRow(resource, billingDate, cost));
        }

        return [.. data];
    }

    protected static int Select(NpgsqlConnection conn, string sql)
    {
        using var command = conn.CreateCommand();
        command.CommandText = sql;

        using var reader = command.ExecuteReader();

        var (resource, billing_date, costs) = (string.Empty, DateTime.MinValue, 0L);

        var val = 0;
        while (reader.Read())
        {
            resource = reader.GetString(0);
            billing_date = reader.GetDateTime(1);
            costs = reader.GetInt64(2);
            val = resource.Length + billing_date.Day + (int)costs;
        }

        return val;
    }

    protected ulong BulkCopy(NpgsqlConnection conn)
    {
        var sql = $"""
        copy billing_data
        (resource, billing_date, cost)
        from stdin (format binary)
        """;

        using var importer = conn.BeginBinaryImport(sql);

        foreach (var d in DataRows)
        {
            importer.StartRow();
            importer.Write(d.Resource, NpgsqlTypes.NpgsqlDbType.Text);
            importer.Write(d.BillingDate, NpgsqlTypes.NpgsqlDbType.Date);
            importer.Write(d.Cost, NpgsqlTypes.NpgsqlDbType.Integer);
        }

        return importer.Complete();
    }

    protected static int ExecuteCommand(NpgsqlConnection conn, string sql)
    {
        using var command = conn.CreateCommand();
        command.CommandText = sql;
        return command.ExecuteNonQuery();
    }

    protected static void RecreateTable(NpgsqlConnection conn)
    {
        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        drop index if exists idx_billing_data;
        
        create table billing_data (
            resource         text not null,
            billing_date     date not null,
            cost             int not null);
        """);
    }
}

using Npgsql;

namespace Benchmark;

public abstract class BenchmarkBase
{
    public const int Iterations = 25;

    public abstract int ResourceCount { get; set; }

    protected readonly string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=sa;Password=qweQWE123!";
    protected readonly DateTime Start = new(2025, 1, 1);
    protected readonly DateTime End = new(2026, 1, 1);

    protected Data[] OneYearData = [];

    protected record Data(int ResourceId, DateTime BillingDate, decimal Cost);

    protected static (DateTime, int, decimal) Select(NpgsqlConnection conn, string sql)
    {
        using var command = conn.CreateCommand();
        command.CommandText = sql;
        using var reader = command.ExecuteReader();
        var (billing_date, resource_id, costs) = (DateTime.MinValue, 0, 0m);
        while (reader.Read())
        {
            billing_date = reader.GetDateTime(0);
            resource_id = reader.GetInt32(1);
            costs = reader.GetDecimal(2);
        }
        return (billing_date, resource_id, costs);
    }

    protected static ulong BulkCopy(NpgsqlConnection conn, string table, Data[] data)
    {
        var sql = $"""
        copy {table}
        (resource_id, billing_date, cost) 
        from stdin (format binary)
        """;
        using var importer = conn.BeginBinaryImport(sql);
        foreach (var d in data)
        {
            importer.StartRow();
            importer.Write(d.ResourceId, NpgsqlTypes.NpgsqlDbType.Integer);
            importer.Write(d.BillingDate, NpgsqlTypes.NpgsqlDbType.Date);
            importer.Write(d.Cost, NpgsqlTypes.NpgsqlDbType.Numeric);
        }
        return importer.Complete();
    }

    protected static int ExecuteCommand(NpgsqlConnection conn, string sql)
    {
        using var command = conn.CreateCommand();
        command.CommandText = sql;
        return command.ExecuteNonQuery();
    }

    protected static Data[] GenerateData(DateTime start, DateTime end, int resourceCount)
    {
        var data = new List<Data>();

        for (var d = start; d < end; d = d.AddMonths(1))
        {
            for (var res = 1; res <= resourceCount; res++)
            {
                data.Add(new Data(res, d, res * 10m));
            }
        }

        return [.. data];
    }
}

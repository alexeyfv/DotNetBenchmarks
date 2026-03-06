using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

using Npgsql;

using NpgsqlTypes;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class Benchmark
{
    [ParamsSource(nameof(ResourceCounts))]
    public int ResourcesCount { get; set; }

    public static IEnumerable<int> ResourceCounts()
    {
        for (var i = 10; i < 100; i += 10) yield return i;
        for (var i = 100; i < 1000; i += 100) yield return i;
        for (var i = 1000; i < 10_000; i += 1000) yield return i;
        for (var i = 10_000; i < 100_000; i += 10_000) yield return i;
        for (var i = 100_000; i < 1_000_000; i += 100_000) yield return i;
        yield return 1_000_000;
    }

    private const int RowCount = 1_000_000;

    private const string PostgresDefaultConnString = "Host=localhost;Port=1111;Database=pg_default;Username=sa;Password=qweQWE123!!";

    private const string PostgresAnalyticsConnString = "Host=localhost;Port=2222;Database=pg_analytics;Username=sa;Password=qweQWE123!!";

    private int _sampleResourceId;

    private const string CreateTable =
    """
    DROP TABLE IF EXISTS billing_data;
    CREATE TABLE billing_data (
        billed_cost numeric(25,15),
        charge_date timestamptz,
        resource_id int4);
    """;

    private const string CreateHypertable =
    """
    DROP TABLE IF EXISTS billing_data;
    CREATE TABLE billing_data (
        billed_cost numeric(25,15),
        charge_date timestamptz,
        resource_id int4)
    WITH (
        timescaledb.hypertable = true,
        timescaledb.chunk_interval='1 day',
        timescaledb.segmentby='resource_id'
    );
    """;

    private const string CreateColumnstore =
    """
    DROP TABLE IF EXISTS billing_data;
    CREATE TABLE billing_data (
        billed_cost numeric(25,15),
        charge_date timestamptz,
        resource_id int4)
    WITH (
        timescaledb.hypertable = true,
        timescaledb.chunk_interval='1 day',
        timescaledb.segmentby='resource_id'
    );
    """;

    private const string CreateIndex_Default =
    """
    CREATE INDEX ON billing_data (charge_date DESC, resource_id)
    INCLUDE (billed_cost);
    """;

    private const string CreateIndex_Columnstore =
    """
    CREATE INDEX ON billing_data (charge_date DESC, resource_id)
    INCLUDE (billed_cost);
        
    DO $$
    DECLARE
    ch regclass;
    BEGIN
    FOR ch IN
        SELECT show_chunks('billing_data')
    LOOP
        CALL convert_to_columnstore(ch);
    END LOOP;
    END$$;
    """;

    private const string DailyCloudCostRollupPostgresSql =
    """
    SELECT
        date_trunc('day', charge_date) AS day,
        resource_id,
        SUM(billed_cost) AS total_cost
    FROM billing_data
    WHERE charge_date >= now() - interval '30 days'
    GROUP BY 1,2;
    """;

    private const string DailyCloudCostRollupTimescaleSql =
    """
    SELECT
        time_bucket(INTERVAL '1 day', charge_date) AS day,
        resource_id,
        SUM(billed_cost) AS total_cost
    FROM billing_data
    WHERE charge_date >= now() - interval '30 days'
    GROUP BY 1,2;
    """;

    private const string SingleResourceDailyRollupPostgresSql =
    """
    SELECT
        date_trunc('day', charge_date) AS day,
        SUM(billed_cost) AS total_cost
    FROM billing_data
    WHERE charge_date >= now() - interval '30 days'
        AND resource_id = @resourceId
    GROUP BY 1
    ORDER BY 1;
    """;

    private const string SingleResourceDailyRollupTimescaleSql =
    """
    SELECT
        time_bucket(INTERVAL '1 day', charge_date) AS day,
        SUM(billed_cost) AS total_cost
    FROM billing_data
    WHERE charge_date >= now() - interval '30 days'
        AND resource_id = @resourceId
    GROUP BY 1
    ORDER BY 1;
    """;

    [GlobalSetup(Targets = [nameof(AllResources_Default), nameof(SingleResource_Default)])]
    public void SetupPostgres_Default()
    {
        _sampleResourceId = ResourcesCount / 2;
        Setup(PostgresDefaultConnString, CreateTable, CreateIndex_Default);
    }

    [GlobalSetup(Targets = [nameof(AllResources_Hypertable)])]
    public void SetupPostgres_Hypertable()
    {
        _sampleResourceId = ResourcesCount / 2;
        Setup(PostgresAnalyticsConnString, CreateHypertable, CreateIndex_Default);
    }

    [GlobalSetup(Targets = [nameof(SingleResource_Hypertable_Columnstore)])]
    public void SetupPostgres_ColumnstoreTest()
    {
        _sampleResourceId = ResourcesCount / 2;
        Setup(PostgresAnalyticsConnString, CreateColumnstore, CreateIndex_Columnstore);
    }

    private void Setup(string connString, string createTableSql, string createIndexSql)
    {
        var anchor = DateTimeOffset.UtcNow;

        using var conn = new NpgsqlConnection(connString);
        conn.Open();

        ExecuteNonQuery(conn, createTableSql);

        var copySql =
        """
        COPY billing_data (billed_cost, charge_date, resource_id) 
        FROM STDIN (FORMAT BINARY);
        """;

        using (var importer = conn.BeginBinaryImport(copySql))
        {
            var start = anchor - TimeSpan.FromSeconds(RowCount);
            for (var i = 1; i <= RowCount; i++)
            {
                var ts = start.AddSeconds(i);
                var billedCost = i * 13 % 100000 / 10000m;
                var resourceId = (i % ResourcesCount) + 1;

                importer.StartRow();
                importer.Write(billedCost, NpgsqlDbType.Numeric);
                importer.Write(ts, NpgsqlDbType.TimestampTz);
                importer.Write(resourceId, NpgsqlDbType.Integer);
            }

            importer.Complete();
        }

        ExecuteNonQuery(conn, createIndexSql);
        ExecuteNonQuery(conn, "ANALYZE billing_data;");
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("all_resources")]
    public long AllResources_Default() =>
        ExecuteBenchmark(PostgresDefaultConnString, DailyCloudCostRollupPostgresSql);

    [Benchmark]
    [BenchmarkCategory("all_resources")]
    public long AllResources_Hypertable() =>
        ExecuteBenchmark(PostgresAnalyticsConnString, DailyCloudCostRollupTimescaleSql);

    // [Benchmark(Baseline = true)]
    // [BenchmarkCategory("single_resource")]
    public long SingleResource_Default() =>
        ExecuteBenchmarkWithResourceId(PostgresDefaultConnString, SingleResourceDailyRollupPostgresSql);

    // [Benchmark]
    // [BenchmarkCategory("single_resource")]
    public long SingleResource_Hypertable_Columnstore() =>
        ExecuteBenchmarkWithResourceId(PostgresAnalyticsConnString, SingleResourceDailyRollupTimescaleSql);

    private static long ExecuteBenchmark(string connString, string sql)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();

        using var cmd = new NpgsqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        var checksum = 17L;
        while (reader.Read())
        {
            checksum = HashCode.Combine(checksum, reader.GetValue(0));
        }

        return checksum;
    }

    private long ExecuteBenchmarkWithResourceId(string connString, string sql)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();

        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.Add(new NpgsqlParameter("resourceId", NpgsqlDbType.Integer)
        {
            Value = _sampleResourceId
        });

        using var reader = cmd.ExecuteReader();

        var checksum = 17L;
        while (reader.Read())
        {
            checksum = HashCode.Combine(checksum, reader.GetValue(0));
        }

        return checksum;
    }

    private static void ExecuteNonQuery(NpgsqlConnection conn, string sql)
    {
        using var cmd = new NpgsqlCommand(sql, conn) { CommandTimeout = 1200 };
        cmd.ExecuteNonQuery();
    }
}

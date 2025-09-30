using BenchmarkDotNet.Attributes;
using Npgsql;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: Iterations)]
public class SelectBenchmarks : BenchmarkBase
{
    [ParamsSource(nameof(GetBatchSize))]
    public override int BatchSize { get; set; }

    [Params(
        IndexCreationStrategy.None,
        // IndexCreationStrategy.Res,
        // IndexCreationStrategy.Res_BillDate,
        IndexCreationStrategy.Res_BillDate_Cst
        // IndexCreationStrategy.Res_BillDate_Inc_Cst
        )]
    public IndexCreationStrategy IndexCreation { get; set; }

    private string IndexCreationSql => IndexCreation switch
    {
        IndexCreationStrategy.Res => "create index idx_billing_data on billing_data(resource);",
        IndexCreationStrategy.Res_BillDate => "create index idx_billing_data on billing_data(resource, billing_date);",
        IndexCreationStrategy.Res_BillDate_Cst => "create index idx_billing_data on billing_data(resource, billing_date, cost);",
        IndexCreationStrategy.Res_BillDate_Inc_Cst => "create index idx_billing_data on billing_data(resource, billing_date) include (cost);",
        _ => throw new NotImplementedException()
    };

    [GlobalSetup(Target = nameof(Select_HashAggregate))]
    public void Setup_HashAggregate()
    {
        DataRows = GenerateDataRows();

        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        RecreateTable(conn);

        ExecuteCommand(conn, "SET enable_hashagg = on;");

        BulkCopy(conn);

        if (IndexCreation != IndexCreationStrategy.None)
        {
            ExecuteCommand(conn, IndexCreationSql);
        }
    }

    [GlobalSetup(Target = nameof(Select_GroupAggregate))]
    public void Setup_GroupAggregate()
    {
        DataRows = GenerateDataRows();

        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        RecreateTable(conn);

        ExecuteCommand(conn, "SET enable_hashagg = off;");

        BulkCopy(conn);

        if (IndexCreation != IndexCreationStrategy.None)
        {
            ExecuteCommand(conn, IndexCreationSql);
        }
    }

    [Benchmark]
    public int Select_HashAggregate()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        var sql =
        """
        select resource, billing_date, sum(cost)
        from billing_data
        group by resource, billing_date
        """;

        return Select(conn, sql);
    }

    [Benchmark]
    public int Select_GroupAggregate()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        var sql =
        """
        select resource, billing_date, sum(cost)
        from billing_data
        group by resource, billing_date
        """;

        return Select(conn, sql);
    }

    public enum IndexCreationStrategy
    {
        None,
        Res,
        Res_BillDate,
        Res_BillDate_Cst,
        Res_BillDate_Inc_Cst
    }
}

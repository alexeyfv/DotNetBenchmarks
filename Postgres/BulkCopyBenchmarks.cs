using BenchmarkDotNet.Attributes;
using Npgsql;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: Iterations)]
public class BulkCopyBenchmarks : BenchmarkBase
{
    [ParamsSource(nameof(GetBatchSize))]
    public override int BatchSize { get; set; }

    [Params(IndexCreationStrategy.None, IndexCreationStrategy.Res, IndexCreationStrategy.Res_BillDate, IndexCreationStrategy.Res_BillDate_Cst, IndexCreationStrategy.Res_BillDate_Inc_Cst, IndexCreationStrategy.After)]
    public IndexCreationStrategy IndexCreation { get; set; }

    private string IndexCreationSql => IndexCreation switch
    {
        IndexCreationStrategy.Res => "create index idx_billing_data on billing_data(resource);",
        IndexCreationStrategy.Res_BillDate => "create index idx_billing_data on billing_data(resource, billing_date);",
        IndexCreationStrategy.Res_BillDate_Cst => "create index idx_billing_data on billing_data(resource, billing_date, cost);",
        IndexCreationStrategy.Res_BillDate_Inc_Cst => "create index idx_billing_data on billing_data(resource, billing_date) include (cost);",
        _ => throw new NotImplementedException()
    };

    [IterationSetup]
    public void Setup()
    {
        DataRows = GenerateDataRows();

        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        RecreateTable(conn);

        if (IndexCreation != IndexCreationStrategy.After && IndexCreation != IndexCreationStrategy.None)
        {
            ExecuteCommand(conn, IndexCreationSql);
        }
    }

    [Benchmark]
    public ulong BulkCopy()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        var rows = BulkCopy(conn);

        if (IndexCreation == IndexCreationStrategy.After)
        {
            ExecuteCommand(conn,
            """
            create index idx_billing_data on billing_data(resource, billing_date) include (cost);
            """);
        }

        return rows;
    }

    public enum IndexCreationStrategy
    {
        None,
        Res,
        Res_BillDate,
        Res_BillDate_Cst,
        Res_BillDate_Inc_Cst,
        After
    }
}

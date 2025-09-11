using BenchmarkDotNet.Attributes;
using Npgsql;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: Iterations)]
public class BulkCopyBenchmarks : BenchmarkBase
{
    [Params(10, 100, 1_000, 10_000, 100_000)]
    public override int ResourceCount { get; set; }

    private DataRow[] DataRows = [];

    private record DataRow(
        string CloudProvider,
        string CloudAccount,
        string Resource,
        DateTime BillingDate,
        int Cost);

    private static ulong BulkCopy(NpgsqlConnection conn, string table, DataRow[] data)
    {
        var sql = $"""
        copy {table}
        (cloud_provider, cloud_account, resource, billing_date, cost)
        from stdin (format binary)
        """;
        using var importer = conn.BeginBinaryImport(sql);
        foreach (var d in data)
        {
            importer.StartRow();
            importer.Write(d.CloudProvider, NpgsqlTypes.NpgsqlDbType.Text);
            importer.Write(d.CloudAccount, NpgsqlTypes.NpgsqlDbType.Text);
            importer.Write(d.Resource, NpgsqlTypes.NpgsqlDbType.Text);
            importer.Write(d.BillingDate, NpgsqlTypes.NpgsqlDbType.Date);
            importer.Write(d.Cost, NpgsqlTypes.NpgsqlDbType.Integer);
        }
        return importer.Complete();
    }

    private static DataRow[] GenerateDataRows(int resourceCount)
    {
        var data = new List<DataRow>();
        var rnd = new Random();
        var providers = new[] { "azure", "aws", "gcp" };
        var accounts = Enumerable.Range(0, 10).Select(_ => Guid.NewGuid().ToString()).ToArray();
        var sept2025 = new DateTime(2025, 9, 1);
        var daysInSept = DateTime.DaysInMonth(2025, 9);

        for (var i = 0; i < resourceCount; i++)
        {
            var provider = providers[rnd.Next(providers.Length)];
            var account = accounts[rnd.Next(accounts.Length)];
            var resource = Guid.NewGuid().ToString();
            var billingDate = sept2025.AddDays(rnd.Next(daysInSept));
            var cost = rnd.Next(0, 1001);
            data.Add(new DataRow(provider, account, resource, billingDate, cost));
        }

        return [.. data];
    }

    [GlobalSetup]
    public void Setup()
    {
        DataRows = GenerateDataRows(ResourceCount);
    }

    [IterationSetup(Targets = [nameof(BulkCopyNoIndex), nameof(BulkCopyThenCreateIndexes)])]
    public void SetupBulkCopyNoIndex()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        drop index if exists idx_billing_data_cloud_provider;
        drop index if exists idx_billing_data_cloud_account;
        drop index if exists idx_billing_data_resource;
        drop index if exists idx_billing_data_billing_date;
        
        create table billing_data (
            cloud_provider   text not null,
            cloud_account    text not null,
            resource         text not null,
            billing_date     date not null,
            cost             int not null);
        """);
    }

    [IterationSetup(Target = nameof(BulkCopyCloudProviderIndex))]
    public void SetupCloudProviderIndex()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();
        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        drop index if exists idx_billing_data_cloud_provider;
        drop index if exists idx_billing_data_cloud_account;
        drop index if exists idx_billing_data_resource;
        drop index if exists idx_billing_data_billing_date;

        create table billing_data (
            cloud_provider   text not null,
            cloud_account    text not null,
            resource         text not null,
            billing_date     date not null,
            cost             int not null);

        create index idx_billing_data_cloud_provider on billing_data(cloud_provider);
        """);
    }

    [IterationSetup(Target = nameof(BulkCopyCloudProviderAccountIndex))]
    public void SetupCloudProviderAccountIndex()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();
        
        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        drop index if exists idx_billing_data_cloud_provider;
        drop index if exists idx_billing_data_cloud_account;
        drop index if exists idx_billing_data_resource;
        drop index if exists idx_billing_data_billing_date;

        create table billing_data (
            cloud_provider   text not null,
            cloud_account    text not null,
            resource         text not null,
            billing_date     date not null,
            cost             int not null);

        create index idx_billing_data_cloud_provider on billing_data(cloud_provider);
        create index idx_billing_data_cloud_account on billing_data(cloud_account);
        """);
    }

    [IterationSetup(Target = nameof(BulkCopyCloudProviderAccountResourceIndex))]
    public void SetupCloudProviderAccountResourceIndex()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();
        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        drop index if exists idx_billing_data_cloud_provider;
        drop index if exists idx_billing_data_cloud_account;
        drop index if exists idx_billing_data_resource;
        drop index if exists idx_billing_data_billing_date;

        create table billing_data (
            cloud_provider   text not null,
            cloud_account    text not null,
            resource         text not null,
            billing_date     date not null,
            cost             int not null);

        create index idx_billing_data_cloud_provider on billing_data(cloud_provider);
        create index idx_billing_data_cloud_account on billing_data(cloud_account);
        create index idx_billing_data_resource on billing_data(resource);
        """);
    }

    [IterationSetup(Target = nameof(BulkCopyCloudProviderAccountResourceDateIndex))]
    public void SetupCloudProviderAccountResourceDateIndex()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();
        ExecuteCommand(conn,
        """
        drop table if exists billing_data;
        drop index if exists idx_billing_data_cloud_provider;
        drop index if exists idx_billing_data_cloud_account;
        drop index if exists idx_billing_data_resource;
        drop index if exists idx_billing_data_billing_date;
        
        create table billing_data (
            cloud_provider   text not null,
            cloud_account    text not null,
            resource         text not null,
            billing_date     date not null,
            cost             int not null);
        
        create index idx_billing_data_cloud_provider on billing_data(cloud_provider);
        create index idx_billing_data_cloud_account on billing_data(cloud_account);
        create index idx_billing_data_resource on billing_data(resource);
        create index idx_billing_data_billing_date on billing_data(billing_date);
        """);
    }
    
    private ulong BulkCopy()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        return BulkCopy(conn, "billing_data", DataRows);
    }


    [Benchmark(Baseline = true)]
    public ulong BulkCopyNoIndex() => BulkCopy();

    [Benchmark]
    public ulong BulkCopyCloudProviderIndex() => BulkCopy();

    [Benchmark]
    public ulong BulkCopyCloudProviderAccountIndex() => BulkCopy();

    [Benchmark]
    public ulong BulkCopyCloudProviderAccountResourceIndex() => BulkCopy();

    [Benchmark]
    public ulong BulkCopyCloudProviderAccountResourceDateIndex() => BulkCopy();

    [Benchmark]
    public ulong BulkCopyThenCreateIndexes()
    {
        using var conn = new NpgsqlConnection(ConnectionString);
        conn.Open();

        var rows = BulkCopy(conn, "billing_data", DataRows);

        ExecuteCommand(conn,
        """
        create index idx_billing_data_cloud_provider on billing_data(cloud_provider);
        create index idx_billing_data_cloud_account on billing_data(cloud_account);
        create index idx_billing_data_resource on billing_data(resource);
        create index idx_billing_data_billing_date on billing_data(billing_date);
        """);
        
        return rows;
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

/// <summary>
/// HybridCache with L1 (in-memory) + L2 (PostgreSQL distributed cache). Should execute exactly once.
/// </summary>
[MemoryDiagnoser]
[SimpleJob]
public class HybridCacheBenchmark : CacheStampedeBenchmarkBase
{
    [Params(1, 2)]
    public int ReplicasCount { get; set; }

    [Params(HybridCacheMode.L1Only, HybridCacheMode.L1L2)]
    public HybridCacheMode Mode { get; set; }

    private readonly List<HybridCache> _replicas = [];
    private const string ConnectionString = "Host=localhost;Database=postgres;Username=sa;Password=qweQWE123!";

    protected override void ConfigureServices(IServiceCollection services)
    {
        for (int i = 0; i < ReplicasCount; i++)
        {
            services.AddKeyedHybridCache($"Replica{i}");
        }

        if (Mode == HybridCacheMode.L1Only)
        {
            return;
        }

        services.AddDistributedPostgresCache(o =>
        {
            o.ConnectionString = ConnectionString;
            o.SchemaName = "public";
            o.TableName = "cache";
            o.CreateIfNotExists = true;
        });
    }

    public override void GlobalSetup()
    {
        base.GlobalSetup();

        for (int i = 0; i < ReplicasCount; i++)
        {
            _replicas.Add(ServiceProvider.GetRequiredKeyedService<HybridCache>($"Replica{i}"));
        }
    }

    public override void IterationSetup()
    {
        base.IterationSetup();
    }

    protected override List<Task> CreateTasks()
    {
        var tasks = new List<Task>();

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            var replica = _replicas[i % _replicas.Count];

            var task = Task.Run(async () =>
            {
                await Semaphore.WaitAsync();

                return await replica.GetOrCreateAsync(CacheKey, async (cancellationToken) =>
                {
                    Interlocked.Increment(ref OpCount);
                    return await ExecuteOperation(Operation, cancellationToken);
                });
            });

            tasks.Add(task);
        }

        return tasks;
    }

    protected override void ClearCache()
    {
        foreach (var replica in _replicas)
        {
            // We have to Wait here because BDN does not support async in cleanup
            replica.RemoveAsync(CacheKey).AsTask().Wait();
        }
    }

    public enum HybridCacheMode
    {
        L1Only,
        L1L2
    }
}

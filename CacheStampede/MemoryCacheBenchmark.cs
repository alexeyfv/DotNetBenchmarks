using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

/// <summary>
/// IMemoryCache without stampede protection. Should execute ~ConcurrentRequests times.
/// </summary>
[MemoryDiagnoser]
[SimpleJob]
public class MemoryCacheBenchmark : CacheStampedeBenchmarkBase
{
    private IMemoryCache _memoryCache = null!;

    protected override void ConfigureServices(IServiceCollection services)
    {
        services.AddMemoryCache();
    }

    public override void GlobalSetup()
    {
        base.GlobalSetup();
        _memoryCache = ServiceProvider.GetRequiredService<IMemoryCache>();
    }

    protected override List<Task> CreateTasks()
    {
        var tasks = new List<Task>();

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            var task = Task.Run(async () =>
            {
                await Semaphore.WaitAsync();

                return await _memoryCache.GetOrCreateAsync(CacheKey, async entry =>
                {
                    Interlocked.Increment(ref OpCount);
                    return await ExecuteOperation(Operation, CancellationToken.None);
                })!;
            });

            tasks.Add(task);
        }

        return tasks;
    }

    protected override void ClearCache()
    {
        _memoryCache.Remove(CacheKey);
    }
}

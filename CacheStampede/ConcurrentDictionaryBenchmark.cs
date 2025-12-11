using System.Collections.Concurrent;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

/// <summary>
/// ConcurrentDictionary without stampede protection. Should execute ~ConcurrentRequests times.
/// </summary>
[MemoryDiagnoser]
[SimpleJob(iterationCount: 25)]
public class ConcurrentDictionaryBenchmark : CacheStampedeBenchmarkBase
{
    private readonly ConcurrentDictionary<string, int> _dictionary = [];

    protected override void ConfigureServices(IServiceCollection services)
    {
        // No services needed
    }

    protected override List<Task> CreateTasks()
    {
        var tasks = new List<Task>();

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            var task = Task.Run(async () =>
            {
                await Semaphore.WaitAsync();

                if (!_dictionary.TryGetValue(CacheKey, out var existing))
                {
                    Interlocked.Increment(ref OpCount);

                    var value = await ExecuteOperation(Operation, CancellationToken.None);

                    _dictionary.TryAdd(CacheKey, value);

                    return value;
                }
                return existing;
            });

            tasks.Add(task);
        }

        return tasks;
    }

    protected override void ClearCache()
    {
        _dictionary.Clear();
    }
}

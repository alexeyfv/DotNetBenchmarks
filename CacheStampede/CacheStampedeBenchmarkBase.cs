using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

/// <summary>
/// Base class for cache stampede benchmarks.
/// Benchmarks cache stampede protection by measuring how many times an expensive operation executes
/// when multiple concurrent requests ask for the same uncached key simultaneously.
/// </summary>
public abstract class CacheStampedeBenchmarkBase
{
    protected ServiceProvider ServiceProvider { get; set; } = null!;
    protected string CacheKey { get; set; } = string.Empty;
    protected SemaphoreSlim Semaphore { get; set; } = null!;
    protected List<Task> Tasks { get; set; } = null!;
    protected int OpCount;

    [ParamsSource(nameof(GetConcurrentRequests))]
    public int ConcurrentRequests { get; set; }

    public static IEnumerable<int> GetConcurrentRequests() => Enumerable.Range(1, Environment.ProcessorCount * 2);

    [Params(OperationType.CPUBound, OperationType.IOBound)]
    public OperationType Operation { get; set; }

    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        ServiceProvider?.DisposeAsync().AsTask().Wait();
    }

    [IterationSetup]
    public virtual void IterationSetup()
    {
        OpCount = 0;
        CacheKey = Guid.NewGuid().ToString();
        var totalTasks = GetTotalTaskCount();
        Semaphore = new SemaphoreSlim(0, totalTasks); // 0 initial count to block all tasks
        Tasks = CreateTasks();
    }

    /// <summary>
    /// Gets the total number of tasks that will be created.
    /// </summary>
    protected virtual int GetTotalTaskCount() => ConcurrentRequests;

    [IterationCleanup]
    public virtual void IterationCleanup()
    {
        BenchmarkMetadata.Instance.AddMetadata("OpCount", OpCount);
        BenchmarkMetadata.Instance.Save(GetBenchmarkName());

        ClearCache();
    }

    /// <summary>
    /// Gets the unique benchmark name used for metadata storage.
    /// Override in derived classes to include additional parameters.
    /// </summary>
    protected virtual string GetBenchmarkName() => $"{ConcurrentRequests}_{Operation}";

    [Benchmark]
    public async Task Run()
    {
        var totalTasks = GetTotalTaskCount();
        Semaphore.Release(totalTasks); // Release all tasks to start simultaneously
        await Task.WhenAll(Tasks);
    }

    protected abstract void ConfigureServices(IServiceCollection services);
    protected abstract List<Task> CreateTasks();
    protected abstract void ClearCache();

    protected static Task<int> ExecuteOperation(OperationType op, CancellationToken ct) => op switch
    {
        OperationType.IOBound => IOBoundOperation(ct),
        OperationType.CPUBound => CPUBoundOperation(ct),
        _ => throw new NotSupportedException()
    };

    /// <summary>
    /// Simulates I/O-bound operation (e.g. database call)
    /// </summary>
    protected static async Task<int> IOBoundOperation(CancellationToken ct)
    {
        await Task.Delay(200, ct);

        var result = new byte[1024].Length; // Simulate some memory allocation

        return result;
    }

    /// <summary>
    /// Simulates CPU-bound operation (e.g. complex calculation)
    /// </summary>
    protected static Task<int> CPUBoundOperation(CancellationToken _)
    {
        var result = 0;

        for (int i = 0; i < 200_000_000; i++)
        {
            result += i % 7;
        }

        return Task.FromResult(result);
    }
}

public enum OperationType
{
    IOBound,
    CPUBound
}

using System.Collections.Concurrent;
using System.Globalization;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Benchmark;

/// <summary>
/// Benchmarks cache stampede protection by measuring how many times an expensive operation executes
/// when multiple concurrent requests ask for the same uncached key simultaneously.
/// <list type="bullet">
/// <item><description>HybridCache_SingleReplica: HybridCache with L1 (in-memory) + L2 (PostgreSQL distributed cache). Should execute ~1 time.</description></item>
/// <item><description>HybridCache_MultipleReplica: Two separate HybridCache instances sharing PostgreSQL L2. Tests cross-replica coordination.</description></item>
/// <item><description>HybridCache_L1Only: HybridCache with only L1 (in-memory) cache, no L2. Should execute ~1 time.</description></item>
/// <item><description>MemoryCache: IMemoryCache without stampede protection. Should execute ~ConcurrentRequests times.</description></item>
/// <item><description>ConcurrentDictionary: ConcurrentDictionary without stampede protection. Should execute ~ConcurrentRequests times.</description></item>
/// </list>
/// </summary>
[MemoryDiagnoser]
[SimpleJob]
public class HybridCacheBenchmark
{
    public string BenchmarkName = string.Empty;
    public int OpCount = 0;

    private SemaphoreSlim Semaphore { get; set; } = null!;
    private List<Task> Tasks { get; set; } = null!;
    private ServiceProvider ServiceProvider { get; set; } = null!;
    private string CacheKey { get; set; } = string.Empty;

    private HybridCache HybridCache_SingleReplica { get; set; } = null!;
    private HybridCache HybridCache_L1Only { get; set; } = null!;
    private HybridCache HybridCache_ReplicaA { get; set; } = null!;
    private HybridCache HybridCache_ReplicaB { get; set; } = null!;
    private IMemoryCache MemoryCache = null!;
    private ConcurrentDictionary<string, int> ConcurrentDictionary = [];
    private const string ConnectionString = "Host=localhost;Database=postgres;Username=sa;Password=qweQWE123!";

    [ParamsSource(nameof(GetConcurrentRequests))]
    public int ConcurrentRequests { get; set; }

    public static IEnumerable<int> GetConcurrentRequests() => Enumerable.Range(1, Environment.ProcessorCount * 2);

    [Params(OperationType.CPUBound, OperationType.IOBound)]
    public OperationType Operation { get; set; }

    [IterationSetup(Target = nameof(Run_HybridCache_SingleReplica))]
    public void IterationSetup_HybridCache_SingleReplica()
    {
        var services = new ServiceCollection();

        // Add PostgreSQL as distributed cache
        services.AddDistributedPostgresCache(o =>
        {
            o.ConnectionString = ConnectionString;
            o.SchemaName = "public";
            o.TableName = "single_replica_cache";
            o.CreateIfNotExists = true;
        });

        services.AddHybridCache();

        ServiceProvider = services.BuildServiceProvider();

        HybridCache_SingleReplica = ServiceProvider.GetRequiredService<HybridCache>();
        OpCount = 0;
        BenchmarkName = nameof(Run_HybridCache_SingleReplica);
        CacheKey = Guid.NewGuid().ToString();
        Semaphore = new SemaphoreSlim(0, ConcurrentRequests);
        Tasks = new List<Task>(ConcurrentRequests);

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            var task = Task.Run(async () =>
            {
                await Semaphore.WaitAsync();
                return await HybridCache_SingleReplica.GetOrCreateAsync(CacheKey, (ct) =>
                {
                    Interlocked.Increment(ref OpCount);
                    return ExecuteOperation(Operation, ct);
                });
            });

            Tasks.Add(task);
        }
    }

    [IterationSetup(Target = nameof(Run_HybridCache_MultipleReplica))]
    public void IterationSetup_HybridCache_MultipleReplica()
    {
        var services = new ServiceCollection();

        // Add PostgreSQL as distributed cache
        services.AddDistributedPostgresCache(o =>
        {
            o.ConnectionString = ConnectionString;
            o.SchemaName = "public";
            o.TableName = "multi_replica_cache";
            o.CreateIfNotExists = true;
        });

        services.AddKeyedHybridCache(nameof(HybridCache_ReplicaA));
        services.AddKeyedHybridCache(nameof(HybridCache_ReplicaB));

        ServiceProvider = services.BuildServiceProvider();

        HybridCache_ReplicaA = ServiceProvider.GetRequiredKeyedService<HybridCache>(nameof(HybridCache_ReplicaA));
        HybridCache_ReplicaB = ServiceProvider.GetRequiredKeyedService<HybridCache>(nameof(HybridCache_ReplicaB));

        OpCount = 0;
        BenchmarkName = nameof(Run_HybridCache_MultipleReplica);
        CacheKey = Guid.NewGuid().ToString();
        Semaphore = new SemaphoreSlim(0, ConcurrentRequests);
        Tasks = new List<Task>(ConcurrentRequests);

        for (int i = 0; i < ConcurrentRequests / 2; i++)
        {
            var taskA = Task.Run(async () =>
            {
                await Semaphore.WaitAsync();
                return await HybridCache_ReplicaA.GetOrCreateAsync(CacheKey, (ct) =>
                {
                    Interlocked.Increment(ref OpCount);
                    return ExecuteOperation(Operation, ct);
                });
            });

            var taskB = Task.Run(async () =>
            {
                await Semaphore.WaitAsync();
                return await HybridCache_ReplicaB.GetOrCreateAsync(CacheKey, (ct) =>
                {
                    Interlocked.Increment(ref OpCount);
                    return ExecuteOperation(Operation, ct);
                });
            });

            Tasks.Add(taskA);
            Tasks.Add(taskB);
        }
    }

    [IterationSetup(Target = nameof(Run_HybridCache_L1Only))]
    public void IterationSetup_HybridCache_L1Only()
    {
        var services = new ServiceCollection();
        services.AddHybridCache();
        ServiceProvider = services.BuildServiceProvider();
        HybridCache_L1Only = ServiceProvider.GetRequiredService<HybridCache>();

        OpCount = 0;
        BenchmarkName = nameof(Run_HybridCache_L1Only);
        CacheKey = Guid.NewGuid().ToString();
        Semaphore = new SemaphoreSlim(0, ConcurrentRequests);
        Tasks = new List<Task>(ConcurrentRequests);

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            var task = Task.Run(async () =>
            {
                await Semaphore.WaitAsync();
                return await HybridCache_L1Only.GetOrCreateAsync(CacheKey, (ct) =>
                {
                    Interlocked.Increment(ref OpCount);
                    return ExecuteOperation(Operation, ct);
                });
            });

            Tasks.Add(task);
        }
    }

    [IterationSetup(Target = nameof(Run_MemoryCache))]
    public void IterationSetup_MemoryCache()
    {
        var services = new ServiceCollection();
        services.AddMemoryCache();
        ServiceProvider = services.BuildServiceProvider();
        MemoryCache = ServiceProvider.GetRequiredService<IMemoryCache>();

        OpCount = 0;
        BenchmarkName = nameof(Run_MemoryCache);
        CacheKey = Guid.NewGuid().ToString();
        Semaphore = new SemaphoreSlim(0, ConcurrentRequests);
        Tasks = new List<Task>(ConcurrentRequests);

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            var task = Task.Run(async () =>
            {
                await Semaphore.WaitAsync();
                return await MemoryCache.GetOrCreateAsync(CacheKey, async entry =>
                {
                    Interlocked.Increment(ref OpCount);
                    return await ExecuteOperation(Operation, CancellationToken.None);
                });
            });

            Tasks.Add(task);
        }
    }

    [IterationSetup(Target = nameof(Run_ConcurrentDictionary))]
    public void IterationSetup_ConcurrentDictionary()
    {
        ConcurrentDictionary = [];
        OpCount = 0;

        BenchmarkName = nameof(Run_ConcurrentDictionary);
        CacheKey = Guid.NewGuid().ToString();
        Semaphore = new SemaphoreSlim(0, ConcurrentRequests);
        Tasks = new List<Task>(ConcurrentRequests);

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            var task = Task.Run(async () =>
            {
                await Semaphore.WaitAsync();
                if (!ConcurrentDictionary.TryGetValue(CacheKey, out var existing))
                {
                    Interlocked.Increment(ref OpCount);
                    var value = await ExecuteOperation(Operation, CancellationToken.None);
                    ConcurrentDictionary.TryAdd(CacheKey, value);
                    return value;
                }
                return existing;
            });

            Tasks.Add(task);
        }
    }

    [IterationCleanup]
    public void IterationCleanup()
    {
        BenchmarkMetadata.Instance.AddMetadata("OpCount", OpCount);
        BenchmarkMetadata.Instance.Save($"{BenchmarkName}_{ConcurrentRequests}_{Operation}");

        ServiceProvider?.Dispose();
    }

    [Benchmark]
    public async Task Run_HybridCache_SingleReplica()
    {
        Semaphore.Release(ConcurrentRequests);
        await Task.WhenAll(Tasks);
    }

    [Benchmark]
    public async Task Run_HybridCache_MultipleReplica()
    {
        Semaphore.Release(ConcurrentRequests);
        await Task.WhenAll(Tasks);
    }

    [Benchmark]
    public async Task Run_HybridCache_L1Only()
    {
        Semaphore.Release(ConcurrentRequests);
        await Task.WhenAll(Tasks);
    }

    [Benchmark]
    public async Task Run_MemoryCache()
    {
        Semaphore.Release(ConcurrentRequests);
        await Task.WhenAll(Tasks);
    }

    [Benchmark]
    public async Task Run_ConcurrentDictionary()
    {
        Semaphore.Release(ConcurrentRequests);
        await Task.WhenAll(Tasks);
    }

    public enum OperationType
    {
        IOBound,
        CPUBound
    }

    internal static async ValueTask<int> ExecuteOperation(OperationType op, CancellationToken ct) => op switch
    {
        OperationType.IOBound => await IOBoundOperation(ct),
        OperationType.CPUBound => await CPUBoundOperation(ct),
        _ => throw new NotSupportedException()
    };

    /// <summary>
    /// Simulates I/O-bound operation (e.g. database call)
    /// </summary>
    internal static async ValueTask<int> IOBoundOperation(CancellationToken ct)
    {
        await Task.Delay(200, ct);

        var result = new byte[1024].Length; // Simulate some memory allocation

        return result;
    }

    /// <summary>
    /// Simulates CPU-bound operation (e.g. complex calculation)
    /// </summary>
    internal static ValueTask<int> CPUBoundOperation(CancellationToken _)
    {
        var result = 0;

        for (int i = 0; i < 200_000_000; i++)
        {
            result += i % 7;
        }

        return ValueTask.FromResult(result);
    }
}

public class BenchmarkMetadata
{
    private readonly string _directory = Path.Combine(Path.GetTempPath(), "HybridCacheBenchmark");
    private Dictionary<string, SortedList<int, object>> _metadata = [];
    private int _index = 0;

    public static BenchmarkMetadata Instance { get; } = new();


    public void Load(string benchmarkName)
    {
        if (!Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory);
        }

        string fileName = Path.Combine(_directory, $"{benchmarkName}.json");

        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            _metadata = JsonSerializer.Deserialize<Dictionary<string, SortedList<int, object>>>(json) ?? [];
        }
        else
        {
            _metadata = [];
        }

        _index = 0; // Reset index for each benchmark
    }

    public void Save(string benchmarkName)
    {
        if (!Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory);
        }

        string fileName = Path.Combine(_directory, $"{benchmarkName}.json");
        string json = JsonSerializer.Serialize(_metadata);
        File.WriteAllText(fileName, json);
    }

    public void AddMetadata(string name, object value)
    {
        if (!_metadata.TryGetValue(name, out SortedList<int, object>? cached))
        {
            cached = [];
            _metadata[name] = cached;
        }

        cached.Add(_index++, value);
    }

    public SortedList<int, object>? GetMetadata(string name)
    {
        if (_metadata.TryGetValue(name, out var values))
        {
            return values;
        }

        return null;
    }
}

public class OpCounterColumn : IColumn
{
    public string Id => nameof(OpCounterColumn);
    public string ColumnName => "Op Count";
    public bool AlwaysShow => true;
    public ColumnCategory Category => ColumnCategory.Custom;
    public int PriorityInCategory => 0;
    public bool IsNumeric => true;
    public UnitType UnitType => UnitType.Dimensionless;
    public string Legend => "Number of times the expensive operation executed";

    public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
    {
        return GetValue(summary, benchmarkCase, SummaryStyle.Default);
    }

    public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
    {
        string benchmarkName = benchmarkCase.Descriptor.WorkloadMethod.Name;
        var concurrentRequests = benchmarkCase.Parameters["ConcurrentRequests"];
        var operationType = benchmarkCase.Parameters["Operation"];
        BenchmarkMetadata.Instance.Load($"{benchmarkName}_{concurrentRequests}_{operationType}");
        var metadata = BenchmarkMetadata.Instance.GetMetadata("OpCount");

        if (metadata != null && metadata.Count > 0)
        {
            var avg = metadata.Values.Cast<JsonElement>().Select(e => e.GetInt32()).Average();
            return string.Format(CultureInfo.InvariantCulture, "{0:F1}", avg);
        }
        return "N/A";
    }

    public bool IsAvailable(Summary summary) => true;

    public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
}

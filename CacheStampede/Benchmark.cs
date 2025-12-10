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

[MemoryDiagnoser]
[SimpleJob(iterationCount: 25)]
public class HybridCacheBenchmark
{
    public string BenchmarkName = string.Empty;
    public int OpCount = 0;

    private HybridCache HybridCache_SingleReplica { get; set; } = null!;
    private HybridCache HybridCache_L1Only { get; set; } = null!;
    private HybridCache HybridCache_ReplicaA { get; set; } = null!;
    private HybridCache HybridCache_ReplicaB { get; set; } = null!;
    private IMemoryCache MemoryCache = null!;
    private ConcurrentDictionary<string, int> ConcurrentDictionary = [];
    private const string CacheKey = "test-key";

    [ParamsSource(nameof(GetConcurrentRequests))]
    public int ConcurrentRequests { get; set; }
    
    public static IEnumerable<int> GetConcurrentRequests() => Enumerable.Range(1, Environment.ProcessorCount * 2);

    [Params(OperationType.CPUBound, OperationType.IOBound)]
    public OperationType Operation { get; set; }

    [IterationSetup]
    public void IterationSetup()
    {
        OpCount = 0;
    }
    
    [IterationSetup(Target = nameof(Run_HybridCache_SingleReplica))]
    public void IterationSetup_HybridCache_SingleReplica()
    {
        var services = new ServiceCollection();

        // Add PostgreSQL as distributed cache
        services.AddDistributedPostgresCache(o =>
        {
            o.ConnectionString = "Host=localhost;Database=postgres;Username=sa;Password=qweQWE123!!";
            o.SchemaName = "public";
            o.TableName = "single_replica_cache";
            o.CreateIfNotExists = true;
        });

        services.AddHybridCache();

        var provider = services.BuildServiceProvider();

        HybridCache_SingleReplica = provider.GetRequiredService<HybridCache>();
    }

    [IterationSetup(Target = nameof(Run_HybridCache_MultipleReplica))]
    public void IterationSetup_HybridCache_MultipleReplica()
    {
        var services = new ServiceCollection();

        // Add PostgreSQL as distributed cache
        services.AddDistributedPostgresCache(o =>
        {
            o.ConnectionString = "Host=localhost;Database=postgres;Username=sa;Password=qweQWE123!!";
            o.SchemaName = "public";
            o.TableName = "multi_replica_cache";
            o.CreateIfNotExists = true;
        });

        services.AddKeyedHybridCache(nameof(HybridCache_ReplicaA));
        services.AddKeyedHybridCache(nameof(HybridCache_ReplicaB));

        var provider = services.BuildServiceProvider();

        HybridCache_ReplicaA = provider.GetRequiredKeyedService<HybridCache>(nameof(HybridCache_ReplicaA));
        HybridCache_ReplicaB = provider.GetRequiredKeyedService<HybridCache>(nameof(HybridCache_ReplicaB));
    }

    [IterationSetup(Target = nameof(Run_HybridCache_L1Only))]
    public void IterationSetup_HybridCache_L1Only()
    {
        var services = new ServiceCollection();
        services.AddHybridCache();
        var provider = services.BuildServiceProvider();
        HybridCache_L1Only = provider.GetRequiredService<HybridCache>();
    }

    [IterationSetup(Target = nameof(Run_MemoryCache))]
    public void IterationSetup_MemoryCache()
    {
        var services = new ServiceCollection();
        services.AddMemoryCache();
        var provider = services.BuildServiceProvider();
        MemoryCache = provider.GetRequiredService<IMemoryCache>();
    }

    [IterationSetup(Target = nameof(Run_ConcurrentDictionary))]
    public void IterationSetup_ConcurrentDictionary()
    {
        ConcurrentDictionary = [];
    }

    [IterationCleanup]
    public void IterationCleanup()
    {
        BenchmarkMetadata.Instance.AddMetadata("OpCount", OpCount);
        BenchmarkMetadata.Instance.Save($"{BenchmarkName}_{ConcurrentRequests}_{Operation}");
    }

    [Benchmark]
    public async Task Run_HybridCache_SingleReplica()
    {
        BenchmarkName = nameof(Run_HybridCache_SingleReplica);

        var tasks = new List<Task>(ConcurrentRequests);

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            var replica = HybridCache_SingleReplica.GetOrCreateAsync(CacheKey, (ct) =>
            {
                Interlocked.Increment(ref OpCount);
                return ExecuteOperation(Operation, ct);
            });

            tasks.Add(replica.AsTask());
        }

        await Task.WhenAll(tasks);
    }

    [Benchmark]
    public async Task Run_HybridCache_MultipleReplica()
    {
        BenchmarkName = nameof(Run_HybridCache_MultipleReplica);

        var tasks = new List<Task>(ConcurrentRequests * 2);

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            var replicaA = HybridCache_ReplicaA.GetOrCreateAsync(CacheKey, (ct) =>
            {
                Interlocked.Increment(ref OpCount);
                return ExecuteOperation(Operation, ct);
            });

            var replicaB = HybridCache_ReplicaB.GetOrCreateAsync(CacheKey, (ct) =>
            {
                Interlocked.Increment(ref OpCount);
                return ExecuteOperation(Operation, ct);
            });

            tasks.Add(replicaA.AsTask());
            tasks.Add(replicaB.AsTask());
        }

        await Task.WhenAll(tasks);
    }

    [Benchmark]
    public async Task Run_HybridCache_L1Only()
    {
        BenchmarkName = nameof(Run_HybridCache_L1Only);

        var tasks = new List<Task>(ConcurrentRequests);

        for (int i = 0; i < tasks.Count; i++)
        {
            var task = HybridCache_L1Only.GetOrCreateAsync(CacheKey, async (ct) =>
            {
                Interlocked.Increment(ref OpCount);
                return await ExecuteOperation(Operation, ct);
            });

            tasks.Add(task.AsTask());
        }

        await Task.WhenAll(tasks);
    }

    [Benchmark]
    public async Task Run_MemoryCache()
    {
        BenchmarkName = nameof(Run_MemoryCache);

        var tasks = new List<Task>(ConcurrentRequests);

        for (int i = 0; i < tasks.Count; i++)
        {
            var task = MemoryCache.GetOrCreateAsync(CacheKey, async entry =>
            {
                Interlocked.Increment(ref OpCount);
                return await ExecuteOperation(Operation, CancellationToken.None);
            });

            tasks.Add(task);
        }

        await Task.WhenAll(tasks);
    }

    [Benchmark]
    public async Task Run_ConcurrentDictionary()
    {
        BenchmarkName = nameof(Run_ConcurrentDictionary);

        var tasks = new List<Task>(ConcurrentRequests);

        for (int i = 0; i < tasks.Count; i++)
        {
            var task = ConcurrentDictionary.GetOrCreateAsync(CacheKey, async () =>
            {
                Interlocked.Increment(ref OpCount);
                return await ExecuteOperation(Operation, CancellationToken.None);
            });
        }

        await Task.WhenAll(tasks);
    }

    public enum OperationType
    {
        IOBound,
        CPUBound
    }

    internal static ValueTask<int> ExecuteOperation(OperationType op, CancellationToken ct) => op switch
    {
        OperationType.IOBound => IOBoundOperation(ct),
        OperationType.CPUBound => CPUBoundOperation(ct),
        _ => throw new NotSupportedException()
    };

    /// <summary>
    /// Simulates I/O-bound operation (e.g. database call)
    /// </summary>
    internal static async ValueTask<int> IOBoundOperation(CancellationToken ct)
    {
        await Task.Delay(100, ct);

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

public static class ConcurrentDictionaryExtensions
{
    public static async ValueTask<TItem> GetOrCreateAsync<TItem>(this ConcurrentDictionary<string, TItem> dict, string key, Func<ValueTask<TItem>> factory)
    {
        if (dict.TryGetValue(key, out var existing))
        {
            return existing;
        }

        var newValue = await factory();

        var value = dict.GetOrAdd(key, newValue);

        return value;
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

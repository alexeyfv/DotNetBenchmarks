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

public enum OperationType
{
    IOBound,
    CPUBound
}

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public class Benchmark
{
    private const string CacheKey = "test-key";

    private static int OperationCounter;
    private string _benchmarkName = string.Empty;

    private HybridCache _hybridCache = null!;
    private IMemoryCache _memoryCache = null!;
    private readonly ConcurrentDictionary<string, int> _concurrentDict = [];

    [ParamsSource(nameof(ConcurrentRequestsSource))]
    public int ConcurrentRequests { get; set; }

    public static IEnumerable<int> ConcurrentRequestsSource() =>
        Enumerable
            .Range(1, Environment.ProcessorCount * 2)
            .Where(x => x == 1 || x % 2 == 0); // Even numbers up to 2x processor count

    [Params(OperationType.CPUBound)]
    public OperationType Operation { get; set; }


    [GlobalSetup]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddHybridCache();
        var provider = services.BuildServiceProvider();
        _hybridCache = provider.GetRequiredService<HybridCache>();
        _memoryCache = provider.GetRequiredService<IMemoryCache>();
    }

    [IterationSetup]
    public void IterationSetup()
    {
        _hybridCache.RemoveAsync(CacheKey).AsTask().Wait();
        _memoryCache.Remove(CacheKey);
        _concurrentDict.Clear();
        OperationCounter = 0;
    }

    [IterationCleanup]
    public void IterationCleanup()
    {
        if (!string.IsNullOrEmpty(_benchmarkName))
        {
            BenchmarkMetadata.Instance.AddMetadata("OpCount", OperationCounter);
            BenchmarkMetadata.Instance.Save($"{_benchmarkName}_{ConcurrentRequests}_{Operation}");
        }
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Stampede")]
    public async Task HybridCache_Stampede()
    {
        _benchmarkName = nameof(HybridCache_Stampede);
        var tasks = Enumerable
            .Range(0, ConcurrentRequests)
            .Select(_ => _hybridCache.GetOrCreateAsync(CacheKey, ct => ExecuteOperation(ct)).AsTask())
            .ToArray();

        await Task.WhenAll(tasks);
    }

    [Benchmark]
    [BenchmarkCategory("Stampede")]
    public async Task MemoryCache_Stampede()
    {
        _benchmarkName = nameof(MemoryCache_Stampede);
        var tasks = Enumerable
            .Range(0, ConcurrentRequests)
            .Select(_ => Task.Run(async () =>
            {
                if (_memoryCache.TryGetValue(CacheKey, out var value))
                {
                    return value;
                }

                value = await ExecuteOperation(CancellationToken.None);
                return _memoryCache.Set(CacheKey, value);

            }))
            .ToArray();

        await Task.WhenAll(tasks);
    }

    [Benchmark]
    [BenchmarkCategory("Stampede")]
    public async Task ConcurrentDictionary_Stampede()
    {
        _benchmarkName = nameof(ConcurrentDictionary_Stampede);
        var tasks = Enumerable
            .Range(0, ConcurrentRequests)
            .Select(_ => Task.Run(async () =>
            {
                if (_concurrentDict.TryGetValue(CacheKey, out var value))
                {
                    return value;
                }

                value = await ExecuteOperation(CancellationToken.None);
                return _concurrentDict.GetOrAdd(CacheKey, value);
            }))
            .ToArray();

        await Task.WhenAll(tasks);
    }

    private ValueTask<int> ExecuteOperation(CancellationToken ct)
    {
        return Operation switch
        {
            OperationType.IOBound => IOBoundOperation(ct),
            OperationType.CPUBound => CPUBoundOperation(ct),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static async ValueTask<int> IOBoundOperation(CancellationToken ct)
    {
        // Simulate IO-bound operation (e.g., database query)
        await Task.Delay(100, ct);
        Interlocked.Increment(ref OperationCounter);
        var result = new byte[1024].Length; // Allocate 1 KB to simulate some data
        return result;
    }

    private static ValueTask<int> CPUBoundOperation(CancellationToken ct)
    {
        // Simulate CPU-bound operation
        var result = 0;
        for (int i = 0; i < 500_000_000; i++)
        {
            result += i % 7;
        }
        Interlocked.Increment(ref OperationCounter);
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

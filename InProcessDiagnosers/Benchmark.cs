using System.Globalization;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace Benchmark;

public interface IMutationCountProvider
{
    int MutationCount { get; }
}

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public class CounterMutationBenchmark : IMutationCountProvider
{
    private int _value;
    private int _mutations;
    private readonly object _gate = new();

    [Params(2, 4, 8, 16)]
    public int ConcurrentRequests { get; set; }

    public int MutationCount => Volatile.Read(ref _mutations);

    [Benchmark(Baseline = true)]
    public async Task NoLocks()
    {
        Volatile.Write(ref _value, 0);
        Volatile.Write(ref _mutations, 0);

        var semaphore = new SemaphoreSlim(0, ConcurrentRequests);
        var tasks = new Task[ConcurrentRequests];

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            tasks[i] = Task.Run(async () =>
            {
                await semaphore.WaitAsync().ConfigureAwait(false);

                if (Volatile.Read(ref _value) == 0)
                {
                    // Widen the race window so we reliably see > 1.
                    Thread.SpinWait(20);

                    Interlocked.Increment(ref _mutations);
                    Volatile.Write(ref _value, 1);
                }
            });
        }

        semaphore.Release(ConcurrentRequests);
        await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    [Benchmark]
    public async Task WithLock()
    {
        Volatile.Write(ref _value, 0);
        Volatile.Write(ref _mutations, 0);

        var semaphore = new SemaphoreSlim(0, ConcurrentRequests);
        var tasks = new Task[ConcurrentRequests];

        for (int i = 0; i < ConcurrentRequests; i++)
        {
            tasks[i] = Task.Run(async () =>
            {
                await semaphore.WaitAsync().ConfigureAwait(false);

                lock (_gate)
                {
                    if (_value == 0)
                    {
                        _mutations++;
                        _value = 1;
                    }
                }
            });
        }

        semaphore.Release(ConcurrentRequests);
        await Task.WhenAll(tasks).ConfigureAwait(false);
    }
}

/// <summary>
/// Minimal example of an in-process diagnoser:
/// - Runs a handler in the benchmark process.
/// - Handler reads a value from the benchmark instance.
/// - Handler serializes results back to host.
/// - Host turns it into a Metric, which BDN prints as a column.
/// </summary>
public sealed class CounterMutationDiagnoser : IInProcessDiagnoser
{
    private readonly Dictionary<BenchmarkCase, List<int>> _resultsByCase = [];

    public IEnumerable<string> Ids => [nameof(CounterMutationDiagnoser)];

    public IEnumerable<IExporter> Exporters => [];

    public IEnumerable<IAnalyser> Analysers => [];

    public RunMode GetRunMode(BenchmarkCase benchmarkCase) => RunMode.NoOverhead;

    public void Handle(HostSignal signal, DiagnoserActionParameters parameters) { }

    public void DisplayResults(ILogger logger) { }

    public IEnumerable<ValidationError> Validate(ValidationParameters validationParameters) => [];

    public InProcessDiagnoserHandlerData GetHandlerData(BenchmarkCase benchmarkCase)
    {
        // The handler type is created INSIDE the benchmark process (it must have a public parameterless ctor).
        // It will receive the benchmark instance in Handle(...).
        return new InProcessDiagnoserHandlerData(typeof(CounterMutationDiagnoserHandler), serializedConfig: null);
    }

    public void DeserializeResults(BenchmarkCase benchmarkCase, string serializedResults)
    {
        if (!int.TryParse(serializedResults, NumberStyles.Integer, CultureInfo.InvariantCulture, out var value))
        {
            return;
        }

        if (!_resultsByCase.TryGetValue(benchmarkCase, out var list))
        {
            list = [];
            _resultsByCase.Add(benchmarkCase, list);
        }

        list.Add(value);
    }

    public IEnumerable<Metric> ProcessResults(DiagnoserResults results)
    {
        if (!_resultsByCase.TryGetValue(results.BenchmarkCase, out var values) || values.Count == 0)
        {
            return [];
        }

        // One value per process launch; we show the average.
        return [new Metric(MutationsMetricDescriptor.Instance, values.Average())];
    }

    private sealed class MutationsMetricDescriptor : IMetricDescriptor
    {
        public static readonly IMetricDescriptor Instance = new MutationsMetricDescriptor();

        public string Id => "Mutations";
        public string DisplayName => "Mutations";
        public string Legend => "How many times the shared counter was set (shows stampede / contention)";
        public string NumberFormat => "N1";
        public UnitType UnitType => UnitType.Dimensionless;
        public string Unit => "Count";
        public bool TheGreaterTheBetter => false;
        public int PriorityInCategory => 0;
        public bool GetIsAvailable(Metric metric) => true;
    }
}

public sealed class CounterMutationDiagnoserHandler : IInProcessDiagnoserHandler
{
    private int _mutationCount;

    public void Initialize(string? serializedConfig) { }

    public void Handle(BenchmarkSignal signal, InProcessDiagnoserActionArgs args)
    {
        // Run after the actual benchmark run, while the benchmark instance still exists.
        if (signal != BenchmarkSignal.AfterActualRun)
        {
            return;
        }

        if (args.BenchmarkInstance is IMutationCountProvider provider)
        {
            _mutationCount = provider.MutationCount;
        }
    }

    public string SerializeResults() => _mutationCount.ToString(CultureInfo.InvariantCulture);
}
using System.Security.Cryptography;
using System.Text;
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

public class CustomMetricsBenchmark
{
    private byte[] hash = [];

    // Custom result to be displayed by the column
    public string Result => Convert.ToBase64String(hash);

    [Params("Hello, World!", "Benchmarking is fun!")]
    public string Input { get; set; } = string.Empty;

    [GlobalSetup(Target = nameof(CalculateSHA256))]
    public void SHA256Setup() => hash = new byte[SHA256.HashSizeInBytes];

    [GlobalSetup(Target = nameof(CalculateMD5))]
    public void MD5Setup() => hash = new byte[MD5.HashSizeInBytes];

    [Benchmark]
    public int CalculateSHA256()
    {
        // Get bytes for the string
        var count = Encoding.UTF8.GetByteCount(Input);
        Span<byte> source = stackalloc byte[count];
        Encoding.UTF8.GetBytes(Input, source);

        // Compute SHA512 hash
        return SHA256.HashData(source, hash);
    }

    [Benchmark]
    public int CalculateMD5()
    {
        // Get bytes for the string
        var count = Encoding.UTF8.GetByteCount(Input);
        Span<byte> source = stackalloc byte[count];
        Encoding.UTF8.GetBytes(Input, source);

        // Compute MD5 hash
        return MD5.HashData(source, hash);
    }
}

// Custom column to display the hash result
public sealed class HashResultColumn : IColumn
{
    private static readonly Dictionary<BenchmarkCase, string> Results = [];

    public static void StoreResult(BenchmarkCase benchmarkCase, string result)
    {
        Results[benchmarkCase] = result;
    }

    public string Id => nameof(HashResultColumn);
    public string ColumnName => "Hash Result";
    public string Legend => "Base64 encoded hash result";
    public UnitType UnitType => UnitType.Dimensionless;
    public bool AlwaysShow => true;
    public ColumnCategory Category => ColumnCategory.Custom;
    public int PriorityInCategory => 0;
    public bool IsNumeric => false;
    public bool IsAvailable(Summary summary) => true;
    public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

    public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
    {
        return Results.TryGetValue(benchmarkCase, out var result) ? result : "N/A";
    }

    public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
    {
        return GetValue(summary, benchmarkCase);
    }
}

// Diagnoser to capture the hash result
public sealed class HashResultDiagnoser : IInProcessDiagnoser
{
    public IEnumerable<string> Ids => [nameof(HashResultDiagnoser)];

    public IEnumerable<IExporter> Exporters => [];
    
    public IEnumerable<IAnalyser> Analysers => [];

    public RunMode GetRunMode(BenchmarkCase benchmarkCase) => RunMode.NoOverhead;

    public void Handle(HostSignal signal, DiagnoserActionParameters parameters) { }

    public void DisplayResults(ILogger logger) { }

    public IEnumerable<ValidationError> Validate(ValidationParameters validationParameters) => [];

    public InProcessDiagnoserHandlerData GetHandlerData(BenchmarkCase benchmarkCase)
    {
        return new InProcessDiagnoserHandlerData(typeof(HashResultDiagnoserHandler), serializedConfig: null);
    }

    public void DeserializeResults(BenchmarkCase benchmarkCase, string serializedResults)
    {
        HashResultColumn.StoreResult(benchmarkCase, serializedResults);
    }

    public IEnumerable<Metric> ProcessResults(DiagnoserResults results) => [];
}

public sealed class HashResultDiagnoserHandler : IInProcessDiagnoserHandler
{
    private string _hashResult = string.Empty;

    public void Initialize(string? serializedConfig) { }

    public void Handle(BenchmarkSignal signal, InProcessDiagnoserActionArgs args)
    {
        if (signal != BenchmarkSignal.AfterActualRun)
        {
            return;
        }

        if (args.BenchmarkInstance is CustomMetricsBenchmark benchmark)
        {
            _hashResult = benchmark.Result;
        }
    }

    public string SerializeResults() => _hashResult;
}

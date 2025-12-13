using System.Globalization;
using System.Text.Json;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Benchmark;

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
        var benchmarkName = GetBenchmarkName(benchmarkCase);
        BenchmarkMetadata.Instance.Load(benchmarkName);
        var metadata = BenchmarkMetadata.Instance.GetMetadata("OpCount");

        if (metadata != null && metadata.Count > 0)
        {
            var avg = metadata.Values.Cast<JsonElement>().Average(e => e.GetInt32());
            return string.Format(CultureInfo.InvariantCulture, "{0:F1}", avg);
        }
        return "N/A";
    }

    public bool IsAvailable(Summary summary) => true;

    public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

    /// <summary>
    /// Builds the benchmark name from all available parameters.
    /// Must match the format used in the benchmark's GetBenchmarkName() method.
    /// </summary>
    private static string GetBenchmarkName(BenchmarkCase benchmarkCase)
    {
        var parameters = benchmarkCase.Parameters;
        var parts = new List<string>();

        // Add HybridCache-specific parameters if present
        if (parameters.Items.Any(p => p.Name == "ReplicasCount"))
            parts.Add(parameters["ReplicasCount"]?.ToString() ?? "");
        if (parameters.Items.Any(p => p.Name == "Mode"))
            parts.Add(parameters["Mode"]?.ToString() ?? "");

        // Add common parameters
        parts.Add(parameters["ConcurrentRequests"]?.ToString() ?? "");
        parts.Add(parameters["Operation"]?.ToString() ?? "");

        return string.Join("_", parts);
    }
}

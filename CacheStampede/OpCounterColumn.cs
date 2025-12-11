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
        var concurrentRequests = benchmarkCase.Parameters["ConcurrentRequests"];
        var operationType = benchmarkCase.Parameters["Operation"];
        BenchmarkMetadata.Instance.Load($"{concurrentRequests}_{operationType}");
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

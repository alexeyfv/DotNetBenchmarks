using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

/// <summary>
/// Prefer strongly-typed Append and Insert method overloads on StringBuilder
/// https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1830
/// </summary>
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 50)]
public class Ca1830
{
    [Params(1000)]
    public int Length { get; set; }

    private StringBuilder StringBuilder { get; set; } = new();

    [Benchmark]
    public int CallToString()
    {
        StringBuilder.Clear();
        for (int i = 0; i < 1000; i++) StringBuilder.Append(i.ToString());
        return StringBuilder.ToString().Length;
    }

    [Benchmark(Baseline = true)]
    public int OnlyAppend()
    {
        StringBuilder.Clear();
        for (int i = 0; i < 1000; i++) StringBuilder.Append(i);
        return StringBuilder.ToString().Length;
    }
}

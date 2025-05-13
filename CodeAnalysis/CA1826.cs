using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace Benchmark;

/// <summary>
/// Use property instead of Linq Enumerable method
/// https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1826
/// </summary>
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 50)]
public class Ca1826
{
    [ParamsSource(nameof(Generate_10_to_100000))]
    public int Length { get; set; }

    private IReadOnlyList<string> ReadOnlyList { get; set; } = null!;

    public static IEnumerable<int> Generate_10_to_100000()
    {
        for (int i = 10; i < 100; i += 9) yield return i;
        for (int i = 100; i < 1_000; i += 36) yield return i;
        for (int i = 1_000; i < 10_000; i += 360) yield return i;
        for (int i = 10_000; i <= 100_000; i += 3_600) yield return i;
    }

    [GlobalSetup]
    public void Setup()
    {
        ReadOnlyList = [.. Enumerable.Range(1, Length).Select(x => x.ToString())];
    }

    [Benchmark]
    [BenchmarkCategory("Linq")]
    public int FirstLinq()
    {
        var x = 0;
        for (int i = 0; i < 1000; i++) x += ReadOnlyList.First().Length;
        return x;
    }

    [Benchmark]
    [BenchmarkCategory("Prop")]
    public int FirstProp()
    {
        var x = 0;
        for (int i = 0; i < 1000; i++) x += ReadOnlyList[0].Length;
        return x;
    }

    [Benchmark]
    [BenchmarkCategory("Linq")]
    public int LastLinq()
    {
        var x = 0;
        for (int i = 0; i < 1000; i++) x += ReadOnlyList.Last().Length;
        return x;
    }

    [Benchmark]
    [BenchmarkCategory("Prop")]
    public int LastProp()
    {
        var x = 0;
        for (int i = 0; i < 1000; i++) x += ReadOnlyList[^1].Length;
        return x;
    }

    [Benchmark]
    [BenchmarkCategory("Linq")]
    public int CountLinq()
    {
        var x = 0;
        for (int i = 0; i < 1000; i++) x += ReadOnlyList.Count();
        return x;
    }

    [Benchmark]
    [BenchmarkCategory("Prop")]
    public int CountProp()
    {
        var x = 0;
        for (int i = 0; i < 1000; i++) x += ReadOnlyList.Count;
        return x;
    }
}

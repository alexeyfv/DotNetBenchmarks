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
[SimpleJob(iterationCount: 20)]
public class Ca1826
{
    [Params(1000)]
    public int Length { get; set; }

    private IReadOnlyList<string> ReadOnlyList { get; set; } = null!;

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

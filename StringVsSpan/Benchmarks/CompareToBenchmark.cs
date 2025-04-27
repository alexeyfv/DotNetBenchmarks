using BenchmarkDotNet.Attributes;

namespace Bnchmrk.Benchmarks;

public class CompareToBenchmark : BenchmarkBase
{
    [Params(
        StringComparison.Ordinal, StringComparison.OrdinalIgnoreCase, 
        StringComparison.InvariantCulture, StringComparison.InvariantCultureIgnoreCase,
        StringComparison.CurrentCulture, StringComparison.CurrentCultureIgnoreCase)]
    public StringComparison Comparison { get; set; }

    protected string randomString = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomString = strings[Random.Shared.Next(0, strings.Length)];
    }

    [Benchmark]
    public int StringCompareToInternal()
    {
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += string.Compare(strings[i], randomString, Comparison);
        }
        return res;
    }

    [Benchmark]
    public int SpanCompareToInternal()
    {
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += MemoryExtensions.CompareTo(strings[i], randomString, Comparison);
        }
        return res;
    }
}

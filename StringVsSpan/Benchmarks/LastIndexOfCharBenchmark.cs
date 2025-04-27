using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class LastIndexOfCharBenchmark : BenchmarkBase
{
    protected char randomChar = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomChar = Convert.ToChar($"{Random.Shared.Next(0, 9)}");
    }

    [Benchmark(Baseline = true, Description = "string.LastIndexOf(randomChars)")]
    public int StringContains()
    {
        int val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].LastIndexOf(randomChar);
        }
        return val;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.LastIndexOf(randomChars)")]
    public int SpanContains()
    {
        var val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].AsSpan().LastIndexOf(randomChar);
        }
        return val;
    }
}

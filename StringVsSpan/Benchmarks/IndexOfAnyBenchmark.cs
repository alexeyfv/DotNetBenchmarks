using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class IndexOfAnyBenchmark : BenchmarkBase
{
    protected char[] randomChars = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomChars = [
            Convert.ToChar($"{Random.Shared.Next(0, 9)}"), 
            Convert.ToChar($"{Random.Shared.Next(0, 9)}"),
            Convert.ToChar($"{Random.Shared.Next(0, 9)}")];
    }

    [Benchmark(Baseline = true, Description = "string.IndexOfAny(randomChars)")]
    public int StringContains()
    {
        int val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].IndexOfAny(randomChars);
        }
        return val;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.IndexOfAny(randomChars)")]
    public int SpanContains()
    {
        var val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].AsSpan().IndexOfAny(randomChars);
        }
        return val;
    }
}

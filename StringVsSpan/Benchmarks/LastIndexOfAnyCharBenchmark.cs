using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class LastIndexOfAnyCharBenchmark : BenchmarkBase
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

    [Benchmark(Baseline = true, Description = "string.LastIndexOfAny(randomChars)")]
    public int StringContains()
    {
        int val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].LastIndexOfAny(randomChars);
        }
        return val;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.LastIndexOfAny(randomChars)")]
    public int SpanContains()
    {
        var val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].AsSpan().LastIndexOfAny(randomChars);
        }
        return val;
    }
}

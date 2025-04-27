using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class SplitBenchmark : BenchmarkBase
{
    protected char randomChar = default!;

    [Params(StringSplitOptions.RemoveEmptyEntries, StringSplitOptions.TrimEntries, StringSplitOptions.None)]
    public StringSplitOptions Options { get; set; }

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomChar = Convert.ToChar($"{Random.Shared.Next(0, 9)}");
    }

    [Benchmark(Baseline = true)]
    public int String()
    {
        var sum = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            var substrings = strings[i].Split(randomChar, Options);
            sum += substrings.Length;
        }
        return sum;
    }

    [Benchmark]
    public int Span()
    {
        var sum = 0;
        Span<Range> ranges = stackalloc Range[strings[0].Length];
        for (int i = 0; i < strings.Length; i++)
        {
            strings[i].AsSpan().Split(ranges, randomChar, Options);
        }
        return sum;
    }
}

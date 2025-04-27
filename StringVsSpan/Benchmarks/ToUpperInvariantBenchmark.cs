using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class ToUpperInvariantBenchmark : BenchmarkBase
{
    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
    }

    [Benchmark]
    public int String()
    {
        var sum = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            sum += strings[i].ToUpperInvariant().Length;
        }
        return sum;
    }

    [Benchmark]
    public int Span()
    {
        var sum = 0;
        Span<char> destination = stackalloc char[strings[0].Length];
        for (int i = 0; i < strings.Length; i++)
        {
            sum += strings[i].AsSpan().ToUpperInvariant(destination);
        }
        return sum;
    }

    [Benchmark]
    public int SpanAlloc()
    {
        var sum = 0;
        Span<char> destination = stackalloc char[strings[0].Length];
        for (int i = 0; i < strings.Length; i++)
        {
            strings[i].AsSpan().ToUpperInvariant(destination);
            sum += destination.ToString().Length;
        }
        return sum;
    }
}

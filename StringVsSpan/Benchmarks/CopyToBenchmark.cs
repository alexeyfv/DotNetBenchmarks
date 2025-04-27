using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class CopyToBenchmark : BenchmarkBase
{
    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
    }

    [Benchmark(Baseline = true)]
    public int String()
    {
        Span<char> destination = stackalloc char[strings[0].Length];
        for (int i = 0; i < strings.Length; i++)
        {
            strings[i].CopyTo(destination);
        }
        return destination.Length;
    }

    [Benchmark]
    public int Span()
    {
        Span<char> destination = stackalloc char[strings[0].Length];
        for (int i = 0; i < strings.Length; i++)
        {
            strings[i].AsSpan().CopyTo(destination);
        }
        return destination.Length;
    }
}

using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class ReplaceBenchmark : BenchmarkBase
{
    protected char oldChar = default!;
    protected char newChar = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        oldChar = Convert.ToChar($"{Random.Shared.Next(0, 9)}");
        newChar = Convert.ToChar($"{Random.Shared.Next(0, 9)}");
    }

    [Benchmark(Baseline = true)]
    public int String()
    {
        var sum = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            sum += strings[i].Replace(oldChar, newChar).Length;
        }
        return sum;
    }

    [Benchmark]
    public int Span()
    {
        Span<char> destination = stackalloc char[strings[0].Length];
        for (int i = 0; i < strings.Length; i++)
        {
            strings[i].AsSpan().Replace(destination, oldChar, newChar);
        }
        return destination.Length;
    }

    [Benchmark]
    public int SpanAlloc()
    {
        var sum = 0;
        Span<char> destination = stackalloc char[strings[0].Length];
        for (int i = 0; i < strings.Length; i++)
        {
            strings[i].AsSpan().Replace(destination, oldChar, newChar);
            sum = destination.ToString().Length;
        }
        return sum;
    }
}

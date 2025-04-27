using System.Globalization;
using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class ToLowerBenchmark : BenchmarkBase
{
    [ParamsSource(nameof(GetCulture))]
    public CultureInfo Culture { get; set; } = default!;

    public static IEnumerable<CultureInfo> GetCulture()
    {
        yield return CultureInfo.InvariantCulture;
        yield return CultureInfo.GetCultureInfo("en-US");
    }

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
            sum += strings[i].ToLower(Culture).Length;
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
            sum += strings[i].AsSpan().ToLower(destination, Culture);
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
            strings[i].AsSpan().ToLower(destination, Culture);
            sum += destination.ToString().Length;
        }
        return sum;
    }
}

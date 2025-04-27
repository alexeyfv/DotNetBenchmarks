using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class ContainsStringBenchmark : BenchmarkBase
{
    protected string randomString = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomString = $"{Random.Shared.Next(0, 9)}{Random.Shared.Next(0, 9)}";
    }

    [Benchmark(Baseline = true, Description = "string.Contains(string)")]
    public bool StringContainsDefault() => StringContainsDefaultInternal();
    
    [Benchmark(Description = "string.Contains(string, StringComparison.Ordinal)")]
    public bool StringContainsOrdinal() => StringContainsComparison(StringComparison.Ordinal);

    [Benchmark(Description = "string.Contains(string, StringComparison.OrdinalIgnoreCase)")]
    public bool StringContainsOrdinalIgnoreCase() => StringContainsComparison(StringComparison.OrdinalIgnoreCase);

    [Benchmark(Description = "string.Contains(string, StringComparison.CurrentCulture)")]
    public bool StringContainsCurrentCulture() => StringContainsComparison(StringComparison.CurrentCulture);

    [Benchmark(Description = "string.Contains(string, StringComparison.CurrentCultureIgnoreCase)")]
    public bool StringContainsCurrentCultureIgnoreCase() => StringContainsComparison(StringComparison.CurrentCultureIgnoreCase);

    [Benchmark(Description = "string.Contains(string, StringComparison.InvariantCulture)")]
    public bool StringContainsInvariantCulture() => StringContainsComparison(StringComparison.InvariantCulture);

    [Benchmark(Description = "string.Contains(string, StringComparison.InvariantCultureIgnoreCase)")]
    public bool StringContainsInvariantCultureIgnoreCase() => StringContainsComparison(StringComparison.InvariantCultureIgnoreCase);

    [Benchmark(Description = "ReadOnlySpan<char>.Contains(string, StringComparison.Ordinal)")]
    public bool SpanContainsOrdinal() => SpanContainsComparison(StringComparison.Ordinal);

    [Benchmark(Description = "ReadOnlySpan<char>.Contains(string, StringComparison.OrdinalIgnoreCase)")]
    public bool SpanContainsOrdinalIgnoreCase() => SpanContainsComparison(StringComparison.OrdinalIgnoreCase);

    [Benchmark(Description = "ReadOnlySpan<char>.Contains(string, StringComparison.CurrentCulture)")]
    public bool SpanContainsCurrentCulture() => SpanContainsComparison(StringComparison.CurrentCulture);

    [Benchmark(Description = "ReadOnlySpan<char>.Contains(string, StringComparison.CurrentCultureIgnoreCase)")]
    public bool SpanContainsCurrentCultureIgnoreCase() => SpanContainsComparison(StringComparison.CurrentCultureIgnoreCase);

    [Benchmark(Description = "ReadOnlySpan<char>.Contains(string, StringComparison.InvariantCulture)")]
    public bool SpanContainsInvariantCulture() => SpanContainsComparison(StringComparison.InvariantCulture);

    [Benchmark(Description = "ReadOnlySpan<char>.Contains(string, StringComparison.InvariantCultureIgnoreCase)")]
    public bool SpanContainsInvariantCultureIgnoreCase() => SpanContainsComparison(StringComparison.InvariantCultureIgnoreCase);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool StringContainsDefaultInternal()
    {
        bool val = false;
        for (int i = 0; i < strings.Length; i++)
        {
            val ^= strings[i].Contains(randomString);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool StringContainsComparison(StringComparison comparison)
    {
        bool val = false;
        for (int i = 0; i < strings.Length; i++)
        {
            val ^= strings[i].Contains(randomString, comparison);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool SpanContainsComparison(StringComparison comparison)
    {
        var val = false;
        var span = randomString.AsSpan();
        for (int i = 0; i < strings.Length; i++)
        {
            val ^= strings[i].AsSpan().Contains(span, comparison);
        }
        return val;
    }
}

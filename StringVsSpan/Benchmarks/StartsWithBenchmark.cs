using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class StartsWithBenchmark : BenchmarkBase
{
    protected string randomString = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomString = $"{Random.Shared.Next(0, 9)}{Random.Shared.Next(0, 9)}";
    }

    [Benchmark(Description = "string.StartsWith(string)")]
    public bool StringDefault() => String();

    [Benchmark(Baseline = true, Description = "string.StartsWith(string, StringComparison.Ordinal)")]
    public bool StringOrdinal() => String(StringComparison.Ordinal);

    [Benchmark(Description = "string.StartsWith(string, StringComparison.OrdinalIgnoreCase)")]
    public bool StringOrdinalIgnoreCase() => String(StringComparison.OrdinalIgnoreCase);

    [Benchmark(Description = "string.StartsWith(string, StringComparison.CurrentCulture)")]
    public bool StringCurrentCulture() => String(StringComparison.CurrentCulture);

    [Benchmark(Description = "string.StartsWith(string, StringComparison.CurrentCultureIgnoreCase)")]
    public bool StringCurrentCultureIgnoreCase() => String(StringComparison.CurrentCultureIgnoreCase);

    [Benchmark(Description = "string.StartsWith(string, StringComparison.InvariantCulture)")]
    public bool StringInvariantCulture() => String(StringComparison.InvariantCulture);

    [Benchmark(Description = "string.StartsWith(string, StringComparison.InvariantCultureIgnoreCase)")]
    public bool StringInvariantCultureIgnoreCase() => String(StringComparison.InvariantCultureIgnoreCase);

    [Benchmark(Description = "ReadOnlySpan<char>.StartsWith(string, StringComparison.Ordinal)")]
    public bool SpanOrdinal() => Span(StringComparison.Ordinal);

    [Benchmark(Description = "ReadOnlySpan<char>.StartsWith(string, StringComparison.OrdinalIgnoreCase)")]
    public bool SpanOrdinalIgnoreCase() => Span(StringComparison.OrdinalIgnoreCase);

    [Benchmark(Description = "ReadOnlySpan<char>.StartsWith(string, StringComparison.CurrentCulture)")]
    public bool SpanCurrentCulture() => Span(StringComparison.CurrentCulture);

    [Benchmark(Description = "ReadOnlySpan<char>.StartsWith(string, StringComparison.CurrentCultureIgnoreCase)")]
    public bool SpanCurrentCultureIgnoreCase() => Span(StringComparison.CurrentCultureIgnoreCase);

    [Benchmark(Description = "ReadOnlySpan<char>.StartsWith(string, StringComparison.InvariantCulture)")]
    public bool SpanInvariantCulture() => Span(StringComparison.InvariantCulture);

    [Benchmark(Description = "ReadOnlySpan<char>.StartsWith(string, StringComparison.InvariantCultureIgnoreCase)")]
    public bool SpanInvariantCultureIgnoreCase() => Span(StringComparison.InvariantCultureIgnoreCase);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool String(StringComparison comparison)
    {
        var val = false;
        for (int i = 0; i < strings.Length; i++)
        {
            val ^= strings[i].StartsWith(randomString, comparison);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool String()
    {
        var val = false;
        for (int i = 0; i < strings.Length; i++)
        {
            val ^= strings[i].StartsWith(randomString);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool Span(StringComparison comparison)
    {
        var val = false;
        var span = randomString.AsSpan();
        for (int i = 0; i < strings.Length; i++)
        {
            val ^= strings[i].AsSpan().StartsWith(span, comparison);
        }
        return val;
    }
}

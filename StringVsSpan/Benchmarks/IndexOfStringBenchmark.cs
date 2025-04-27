using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class IndexOfStringBenchmark : BenchmarkBase
{
    protected string randomString = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomString = $"{Random.Shared.Next(0, 9)}{Random.Shared.Next(0, 9)}";
    }

    [Benchmark(Baseline = true, Description = "string.IndexOf(randomString)")]
    public int StringDefault() => String();
    
    [Benchmark(Description = "string.IndexOf(randomString, StringComparison.Ordinal)")]
    public int StringOrdinal() => String(StringComparison.Ordinal);

    [Benchmark(Description = "string.IndexOf(randomString, StringComparison.OrdinalIgnoreCase)")]
    public int StringOrdinalIgnoreCase() => String(StringComparison.OrdinalIgnoreCase);

    [Benchmark(Description = "string.IndexOf(randomString, StringComparison.CurrentCulture)")]
    public int StringCurrentCulture() => String(StringComparison.CurrentCulture);

    [Benchmark(Description = "string.IndexOf(randomString, StringComparison.CurrentCultureIgnoreCase)")]
    public int StringCurrentCultureIgnoreCase() => String(StringComparison.CurrentCultureIgnoreCase);

    [Benchmark(Description = "string.IndexOf(randomString, StringComparison.InvariantCulture)")]
    public int StringInvariantCulture() => String(StringComparison.InvariantCulture);

    [Benchmark(Description = "string.IndexOf(randomString, StringComparison.InvariantCultureIgnoreCase)")]
    public int StringInvariantCultureIgnoreCase() => String(StringComparison.InvariantCultureIgnoreCase);

    [Benchmark(Description = "ReadOnlySpan<char>.IndexOf(randomString)")]
    public int SpanDefault() => Span();

    [Benchmark(Description = "ReadOnlySpan<char>.IndexOf(randomString, StringComparison.Ordinal)")]
    public int SpanOrdinal() => Span(StringComparison.Ordinal);

    [Benchmark(Description = "ReadOnlySpan<char>.IndexOf(randomString, StringComparison.OrdinalIgnoreCase)")]
    public int SpanOrdinalIgnoreCase() => Span(StringComparison.OrdinalIgnoreCase);

    [Benchmark(Description = "ReadOnlySpan<char>.IndexOf(randomString, StringComparison.CurrentCulture)")]
    public int SpanCurrentCulture() => Span(StringComparison.CurrentCulture);

    [Benchmark(Description = "ReadOnlySpan<char>.IndexOf(randomString, StringComparison.CurrentCultureIgnoreCase)")]
    public int SpanCurrentCultureIgnoreCase() => Span(StringComparison.CurrentCultureIgnoreCase);

    [Benchmark(Description = "ReadOnlySpan<char>.IndexOf(randomString, StringComparison.InvariantCulture)")]
    public int SpanInvariantCulture() => Span(StringComparison.InvariantCulture);

    [Benchmark(Description = "ReadOnlySpan<char>.IndexOf(randomString, StringComparison.InvariantCultureIgnoreCase)")]
    public int SpanInvariantCultureIgnoreCase() => Span(StringComparison.InvariantCultureIgnoreCase);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int String()
    {
        var val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].IndexOf(randomString);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int Span()
    {
        var val = 0;
        var span = randomString.AsSpan();
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].AsSpan().IndexOf(span);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int String(StringComparison comparison)
    {
        var val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].IndexOf(randomString, comparison);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int Span(StringComparison comparison)
    {
        var val = 0;
        var span = randomString.AsSpan();
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].AsSpan().IndexOf(span, comparison);
        }
        return val;
    }
}

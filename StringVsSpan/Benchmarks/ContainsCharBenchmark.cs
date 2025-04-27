using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class ContainsCharBenchmark : BenchmarkBase
{
    protected char randomChar = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomChar = Convert.ToChar($"{Random.Shared.Next(0, 9)}");
    }

    [Benchmark(Baseline = true, Description = "string.Contains(randomChar)")]
    public bool StringContainsDefault() => StringContains();

    [Benchmark(Description = "ReadOnlySpan<char>.Contains(randomChar)")]
    public bool SpanContains() => SpanContainsInternal();

    [Benchmark(Description = "string.Contains(randomChar, StringComparison.Ordinal)")]
    public bool StringContainsOrdinal() => StringContains(StringComparison.Ordinal);

    [Benchmark(Description = "string.Contains(randomChar, StringComparison.OrdinalIgnoreCase)")]
    public bool StringContainsOrdinalIgnoreCase() => StringContains(StringComparison.OrdinalIgnoreCase);

    [Benchmark(Description = "string.Contains(randomChar, StringComparison.CurrentCulture)")]
    public bool StringContainsCurrentCulture() => StringContains(StringComparison.CurrentCulture);

    [Benchmark(Description = "string.Contains(randomChar, StringComparison.CurrentCultureIgnoreCase)")]
    public bool StringContainsCurrentCultureIgnoreCase() => StringContains(StringComparison.CurrentCultureIgnoreCase);

    [Benchmark(Description = "string.Contains(randomChar, StringComparison.InvariantCulture)")]
    public bool StringContainsInvariantCulture() => StringContains(StringComparison.InvariantCulture);

    [Benchmark(Description = "string.Contains(randomChar, StringComparison.InvariantCultureIgnoreCase)")]
    public bool StringContainsInvariantCultureIgnoreCase() => StringContains(StringComparison.InvariantCultureIgnoreCase);

    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool StringContains()
    {
        bool val = false;
        for (int i = 0; i < strings.Length; i++)
        {
            val ^= strings[i].Contains(randomChar);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool StringContains(StringComparison comparison)
    {
        bool val = false;
        for (int i = 0; i < strings.Length; i++)
        {
            val ^= strings[i].Contains(randomChar, comparison);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool SpanContainsInternal()
    {
        var val = false;
        for (int i = 0; i < strings.Length; i++)
        {
            val ^= strings[i].AsSpan().Contains(randomChar);
        }
        return val;
    }
}

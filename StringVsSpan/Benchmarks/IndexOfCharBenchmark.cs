using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using Bnchmrk.Benchmarks;

namespace Bnchmrk;

public class IndexOfCharBenchmark : BenchmarkBase
{
    protected char randomChar = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomChar = Convert.ToChar($"{Random.Shared.Next(0, 9)}");
    }

    [Benchmark(Baseline = true, Description = "string.IndexOf(randomChar)")]
    public int StringDefault() => String();
    
    [Benchmark(Description = "string.IndexOf(randomChar, StringComparison.Ordinal)")]
    public int StringOrdinal() => String(StringComparison.Ordinal);

    [Benchmark(Description = "string.IndexOf(randomChar, StringComparison.OrdinalIgnoreCase)")]
    public int StringOrdinalIgnoreCase() => String(StringComparison.OrdinalIgnoreCase);

    [Benchmark(Description = "string.IndexOf(randomChar, StringComparison.CurrentCulture)")]
    public int StringCurrentCulture() => String(StringComparison.CurrentCulture);

    [Benchmark(Description = "string.IndexOf(randomChar, StringComparison.CurrentCultureIgnoreCase)")]
    public int StringCurrentCultureIgnoreCase() => String(StringComparison.CurrentCultureIgnoreCase);

    [Benchmark(Description = "string.IndexOf(randomChar, StringComparison.InvariantCulture)")]
    public int StringInvariantCulture() => String(StringComparison.InvariantCulture);

    [Benchmark(Description = "string.IndexOf(randomChar, StringComparison.InvariantCultureIgnoreCase)")]
    public int StringInvariantCultureIgnoreCase() => String(StringComparison.InvariantCultureIgnoreCase);

    [Benchmark]
    public int SpanDefault() => Span();
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int String(StringComparison comparison)
    {
        int val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].IndexOf(randomChar, comparison);
        }
        return val;
    }
    
    [MethodImpl(MethodImplOptions.NoInlining)]
    public int String()
    {
        int val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].IndexOf(randomChar);
        }
        return val;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int Span()
    {
        var val = 0;
        for (int i = 0; i < strings.Length; i++)
        {
            val += strings[i].AsSpan().IndexOf(randomChar);
        }
        return val;
    }
}

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Bnchmrk.Benchmarks;

public class EqualsBenchmark : BenchmarkBase
{
    protected string randomString = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomString = strings[Random.Shared.Next(0, strings.Length)];
    }

    [Benchmark]
    public bool StringEqualsDefault() => StringEqualsDefaultInternal();

    [Benchmark]
    public bool StringEqualsOrdinal() => StringEqualsInternal(StringComparison.Ordinal);

    [Benchmark]
    public bool StringEqualsOrdinalIgnoreCase() => StringEqualsInternal(StringComparison.OrdinalIgnoreCase);

    [Benchmark]
    public bool StringEqualsInvariantCulture() => StringEqualsInternal(StringComparison.InvariantCulture);

    [Benchmark]
    public bool StringEqualsInvariantCultureIgnoreCase() => StringEqualsInternal(StringComparison.InvariantCultureIgnoreCase);

    [Benchmark]
    public bool StringEqualsCurrentCulture() => StringEqualsInternal(StringComparison.CurrentCulture);

    [Benchmark]
    public bool StringEqualsCurrentCultureIgnoreCase() => StringEqualsInternal(StringComparison.CurrentCultureIgnoreCase);

    [Benchmark]
    public bool SpanEqualsDefault() => SpanEqualsDefaultInternal();

    [Benchmark]
    public bool SpanEqualsOrdinal() => SpanEqualsInternal(StringComparison.Ordinal);

    [Benchmark]
    public bool SpanEqualsOrdinalIgnoreCase() => SpanEqualsInternal(StringComparison.OrdinalIgnoreCase);

    [Benchmark]
    public bool SpanEqualsInvariantCulture() => SpanEqualsInternal(StringComparison.InvariantCulture);

    [Benchmark]
    public bool SpanEqualsInvariantCultureIgnoreCase() => SpanEqualsInternal(StringComparison.InvariantCultureIgnoreCase);

    [Benchmark]
    public bool SpanEqualsCurrentCulture() => SpanEqualsInternal(StringComparison.CurrentCulture);

    [Benchmark]
    public bool SpanEqualsCurrentCultureIgnoreCase() => SpanEqualsInternal(StringComparison.CurrentCultureIgnoreCase);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool StringEqualsDefaultInternal()
    {
        var res = false;
        for (var i = 0; i < strings.Length; i++)
        {
            res ^= strings[i].Equals(randomString);
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool StringEqualsInternal(StringComparison comparison)
    {
        var res = false;
        for (var i = 0; i < strings.Length; i++)
        {
            res ^= strings[i].Equals(randomString, comparison);
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool SpanEqualsDefaultInternal()
    {
        var res = false;
        for (var i = 0; i < strings.Length; i++)
        {
            res ^= strings[i].AsSpan().Equals(randomString);
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool SpanEqualsInternal(StringComparison comparison)
    {
        var res = false;
        for (var i = 0; i < strings.Length; i++)
        {
            res ^= strings[i].AsSpan().Equals(randomString, comparison);
        }
        return res;
    }
}

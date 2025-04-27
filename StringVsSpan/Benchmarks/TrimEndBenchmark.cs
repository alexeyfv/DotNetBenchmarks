using BenchmarkDotNet.Attributes;

namespace Bnchmrk.Benchmarks;

public class TrimEndBenchmark : BenchmarkBase
{
    protected char randomChar = default!;
    protected char[] randomChars = default!;

    [GlobalSetup]
    public override void Setup()
    {
        base.Setup();
        randomChar = Convert.ToChar($"{Random.Shared.Next(0, 9)}");
        
        randomChars = [
            Convert.ToChar($"{Random.Shared.Next(0, 9)}"), 
            Convert.ToChar($"{Random.Shared.Next(0, 9)}"),
            Convert.ToChar($"{Random.Shared.Next(0, 9)}")];
    }   

    [Benchmark(Description = "string.TrimEnd()")]
    public int StringTrimEndWhitespace()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].TrimEnd().Length;
        }
        return res;
    }

    [Benchmark(Description = "string.TrimEnd(char trimChar)")]
    public int StringTrimEndRandomChar()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].TrimEnd(randomChar).Length;
        }
        return res;
    }

    [Benchmark(Description = "string.TrimEnd(char trimChars)")]
    public int StringTrimEndRandomChars()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].TrimEnd(randomChars).Length;
        }
        return res;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.TrimEnd()")]
    public int SpanTrimEndWhitespace()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].AsSpan().TrimEnd().Length;
        }
        return res;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.TrimEnd(char trimChar)")]
    public int SpanTrimEndRandomChar()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].AsSpan().TrimEnd(randomChar).Length;
        }
        return res;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.TrimEnd(char trimChars)")]
    public int SpanTrimEndRandomChars()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].AsSpan().TrimEnd(randomChars).Length;
        }
        return res;
    }
}

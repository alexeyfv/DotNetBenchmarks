using System.ComponentModel;
using BenchmarkDotNet.Attributes;

namespace Bnchmrk.Benchmarks;

public class TrimStartBenchmark : BenchmarkBase
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

    [Benchmark(Description = "string.TrimStart()")]
    public int StringTrimStartWhitespace()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].TrimStart().Length;
        }
        return res;
    }

    [Benchmark(Description = "string.TrimStart(char trimChar)")]
    public int StringTrimStartRandomChar()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].TrimStart(randomChar).Length;
        }
        return res;
    }

    [Benchmark(Description = "string.TrimStart(char trimChars)")]
    public int StringTrimStartRandomChars()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].TrimStart(randomChars).Length;
        }
        return res;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.TrimStart()")]
    public int SpanTrimStartWhitespace()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].AsSpan().TrimStart().Length;
        }
        return res;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.TrimStart(char trimChar)")]
    public int SpanTrimStartRandomChar()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].AsSpan().TrimStart(randomChar).Length;
        }
        return res;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.TrimStart(char trimChars)")]
    public int SpanTrimStartRandomChars()
    { 
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].AsSpan().TrimStart(randomChars).Length;
        }
        return res;
    }
}

using BenchmarkDotNet.Attributes;

namespace Bnchmrk.Benchmarks;

public class TrimBenchmark : BenchmarkBase
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

    [Benchmark(Description = "string.Trim()")]
    public int StringTrimWhitespace()
    {
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].Trim().Length;
        }
        return res;
    }

    [Benchmark(Description = "string.Trim(char trimChar)")]
    public int StringTrimRandomChar()
    {
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].Trim(randomChar).Length;
        }
        return res;
    }

    [Benchmark(Description = "string.Trim(char trimChars)")]
    public int StringTrimRandomChars()
    {
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].Trim(randomChars).Length;
        }
        return res;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.Trim()")]
    public int SpanTrimWhitespace()
    {
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].AsSpan().Trim().Length;
        }
        return res;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.Trim(char trimChar)")]
    public int SpanTrimRandomChar()
    {
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].AsSpan().Trim(randomChar).Length;
        }
        return res;
    }

    [Benchmark(Description = "ReadOnlySpan<char>.Trim(char trimChars)")]
    public int SpanTrimRandomChars()
    {
        var res = 0;
        for (var i = 0; i < strings.Length; i++)
        {
            res += strings[i].AsSpan().Trim(randomChars).Length;
        }
        return res;
    }
}
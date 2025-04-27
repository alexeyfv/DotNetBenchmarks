using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Diagnostics.dotTrace;
using Microsoft.Extensions.Logging;

namespace Benchmark;

[CategoriesColumn]
// [DotTraceDiagnoser]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public partial class Benchmark
{
    // [Params(100, 1000, 10_000, 100_000)]
    [Params(100_000)]
    public int Length { get; set; }

    private int[] Integers { get; set; } = [];

    private ILogger _logger = default!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        using var factory = LoggerFactory.Create(builder =>
        {
            builder.SetMinimumLevel(LogLevel.Information);
            builder.AddConsole();
        });
        _logger = factory.CreateLogger<Program>();
        Integers = Enumerable.Range(0, Length).ToArray();
    }

    [Benchmark(Baseline = true)]
    public int StructuredMessageTemplate()
    {
        var sum = 0;

        for (var i = 0; i < Length; i++)
        {
            _logger.LogDebug("Integers: {i1}, {i2}, {i3}, {i4}, {i5}, {i6}, {i7}", Integers[i], Integers[i], Integers[i], Integers[i], Integers[i], Integers[i], Integers[i]);
            sum += i;
        }

        return sum;
    }

    [Benchmark]
    public int StringInterpolation()
    {
        var sum = 0;

        for (var i = 0; i < Length; i++)
        {
            _logger.LogDebug($"Integers: {Integers[i]}, {Integers[i]}, {Integers[i]}, {Integers[i]}, {Integers[i]}, {Integers[i]}, {Integers[i]}");
            sum += i;
        }

        return sum;
    }

    [Benchmark]
    public int LoggerMessageAttribute()
    {
        var sum = 0;

        for (var i = 0; i < Length; i++)
        {
            LogIntegers(_logger, Integers[i], Integers[i], Integers[i], Integers[i], Integers[i], Integers[i], Integers[i]);
            sum += i;
        }

        return sum;
    }

    [LoggerMessage(Level = LogLevel.Debug, Message = "Integers: {i1}, {i2}, {i3}, {i4}, {i5}, {i6}, {i7}")]
    public static partial void LogIntegers(ILogger logger, int i1, int i2, int i3, int i4, int i5, int i6, int i7);

    [LoggerMessage(Level = LogLevel.Debug, Message = "Integers: {i1}, {i2}, {i3}, {i4}")]
    public static partial void LogIntegers(ILogger logger, int i1, int i2, int i3, int i4);

    [LoggerMessage(Level = LogLevel.Debug, Message = "Integers: {i1}, {i2}")]
    public static partial void LogIntegers(ILogger logger, int i1, int i2);
    
    [LoggerMessage(Level = LogLevel.Debug, Message = "Integers: {i1}")]
    public static partial void LogIntegers(ILogger logger, int i1);
}

namespace Benchmark;

public class BenchmarkBase
{
    public const int RepetitionsCount = 100;

    public const int IterationCount = 25;

    public static IEnumerable<int> Sizes()
    {
        for (var i = 10; i < 100; i += 10) yield return i;
        for (var i = 100; i < 1000; i += 100) yield return i;
        for (var i = 1000; i < 10_000; i += 1000) yield return i;
        for (var i = 10_000; i < 100_000; i += 10_000) yield return i;
        for (var i = 100_000; i < 1_000_000; i += 100_000) yield return i;
        yield return 1_000_000;
    }

    public static IEnumerable<int> ThreadCounts()
    {
        int logicalCores = Environment.ProcessorCount;
        yield return 1;
        yield return logicalCores / 4;
        yield return logicalCores / 2;
        yield return logicalCores;
        yield return logicalCores * 2;
        yield return logicalCores * 4;
    }
}

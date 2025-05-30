namespace Benchmark.Benchmarks;

public abstract class BenchmarkBase
{
    public static IEnumerable<int> GenerateSmall()
    {
        for (int i = 1; i <= 10; i++)
        {
            yield return i;
        }
    }

    public static IEnumerable<int> GenerateSmall1to4()
    {
        for (int i = 1; i <= 4; i++)
        {
            yield return i;
        }
    }

    public static IEnumerable<int> GenerateLarge()
    {
        yield return 998;
        yield return 999;
        // for (int i = 11; i < 100; i += 9) yield return i;
        // for (int i = 100; i < 1_000; i += 36) yield return i;
        // for (int i = 1_000; i < 10_000; i += 360) yield return i;
        // for (int i = 10_000; i < 100_000; i += 3_600) yield return i;
        // for (int i = 100_000; i <= 1_000_000; i += 36_000) yield return i;
    }

    public static IEnumerable<int> Generate_10_to_50000()
    {
        for (int i = 10; i < 100; i += 9) yield return i;
        for (int i = 100; i < 1_000; i += 60) yield return i;
        for (int i = 1_000; i < 10_000; i += 600) yield return i;
        for (int i = 10_000; i <= 50_000; i += 2_500) yield return i;
    }

    public static IEnumerable<int> Generate_10_to_100000()
    {
        for (int i = 10; i < 100; i += 9) yield return i;
        for (int i = 100; i < 1_000; i += 36) yield return i;
        for (int i = 1_000; i < 10_000; i += 360) yield return i;
        for (int i = 10_000; i <= 100_000; i += 3_600) yield return i;
    }
}

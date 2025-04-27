using System.Buffers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: IterationCount)]
public class TemporaryBuffersBenchmark : BenchmarkBase
{
    [ParamsSource(nameof(GetLengths))]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup() => InitCollections(Length);

    [Benchmark(Baseline = true)]
    public int Default()
    {
        var sum = 0;
        var arr = new int[Length];
        foreach (var n in arr) sum += n;
        return sum;
    }

    [Benchmark]
    public int ArrayPool()
    {
        var pool = ArrayPool<int>.Shared;
        var arr = pool.Rent(Length);
        var sum = 0;
        foreach (var n in arr) sum += n;
        pool.Return(arr);
        return sum;
    }

    [Benchmark]
    public int Stackalloc()
    {
        var sum = 0;
        Span<int> arr = stackalloc int[Length];
        foreach (var n in arr) sum += n;
        return sum;
    }
}

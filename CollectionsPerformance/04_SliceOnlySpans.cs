using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: IterationCount)]
public class SliceOnlySpans : BenchmarkBase
{
    private int _start;
    private int _end;

    [ParamsSource(nameof(GetLengths))]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup() 
    {
        _start = Length / 4;
        _end = Length * 3 / 4;
        InitCollections(Length);
    }

    [Benchmark(Baseline = true)]
    public int SliceArray()
    {
        var sum = 0;
        var sliced = _transactionsArray[_start.._end];
        foreach (var t in sliced) sum += t.Amount;
        return sum;
    }

    [Benchmark]
    public int SliceSpan()
    {
        var sum = 0;
        var sliced = _transactionsArray.AsSpan()[_start.._end];
        foreach (var t in sliced) sum += t.Amount;
        return sum;
    }
}

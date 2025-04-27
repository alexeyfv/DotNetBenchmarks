using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: IterationCount)]
public class AvoidLinq_Exists : BenchmarkBase
{
    [ParamsSource(nameof(GetLengths))]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup() => InitCollections(Length);

    [Benchmark]
    public bool ArrayExists()
    {
        return Array.Exists(_transactionsArray, x => x.Amount > 1_000_00);
    }

    [Benchmark]
    public bool ArrayLinqAny()
    {
        return _transactionsArray.Any(x => x.Amount > 1_000_00);
    }

    [Benchmark]
    public bool ListLinqAny()
    {
        return _transactionsList.Any(x => x.Amount > 1_000_00);
    }

    [Benchmark]
    public bool IEnumerableLinqAny()
    {
        return _transactionsList.Any(x => x.Amount > 1_000_00);
    }

    [Benchmark]
    public bool ImperativeExists()
    {
        for (int i = 0; i < _transactionsArray.Length; i++)
        {
            if (_transactionsArray[i].Amount > 1_000_000) return true;
        }
        return false;
    }
}

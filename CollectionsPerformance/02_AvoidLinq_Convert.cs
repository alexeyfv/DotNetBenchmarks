using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: IterationCount)]
public class AvoidLinq_Convert : BenchmarkBase
{
    [ParamsSource(nameof(GetLengths))]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup() => InitCollections(Length);

    [Benchmark]
    public string[] ArrayConvertAll()
    {
        return Array.ConvertAll(_transactionsArray, x => x.Description);
    }

    [Benchmark]
    public string[] ArrayLinqSelect()
    {
        return _transactionsArray.Select(x => x.Description).ToArray();
    }

    [Benchmark]
    public string[] ListLinqSelect()
    {
        return _transactionsList.Select(x => x.Description).ToArray();
    }

    [Benchmark]
    public string[] IEnumerableLinqSelect()
    {
        return _transactionsIEnumerable.Select(x => x.Description).ToArray();
    }

    [Benchmark]
    public string[] ImperativeConvert()
    {
        var array = new string[_transactionsArray.Length];
        for (int i = 0; i < _transactionsArray.Length; i++)
        {
            array[i] = _transactionsArray[i].Description;
        }
        return array;
    }
}

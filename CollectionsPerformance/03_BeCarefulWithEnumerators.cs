using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: IterationCount)]
public class BeCarefulWithEnumerators : BenchmarkBase
{
    [ParamsSource(nameof(GetLengths))]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup() => InitCollections(Length);

    [Benchmark]
    public int ArrayIndexer()
    {
        var sum = 0;
        for (var i = 0; i < 100; i++) sum += Indexer(_transactionsArray);
        return sum;
    }

    [Benchmark]
    public int ArrayAsICollectionEnumerator()
    {
        var sum = 0;
        for (var i = 0; i < 100; i++) sum += ICollectionEnumerator(_transactionsArray);
        return sum;
    }

    [Benchmark]
    public int ListIndexer()
    {
        var sum = 0;
        for (var i = 0; i < 100; i++) sum += Indexer(_transactionsList);
        return sum;
    }

    [Benchmark]
    public int ListEnumerator()
    {
        var sum = 0;
        for (var i = 0; i < 100; i++) sum += ListEnumerator(_transactionsList);
        return sum;
    }

    [Benchmark]
    public int ListAsICollectionEnumerator()
    {
        var sum = 0;
        for (var i = 0; i < 100; i++) sum += ICollectionEnumerator(_transactionsList);
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int Indexer(List<Transaction> collection)
    {
        var sum = 0;
        for (var i = 0; i < collection.Count; i++) sum += collection[i].Amount;
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int Indexer(Transaction[] array)
    {
        var sum = 0;
        for (var i = 0; i < array.Length; i++) sum += array[i].Amount;
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int ListEnumerator(List<Transaction> collection)
    {
        var sum = 0;
        foreach (var item in collection) sum += item.Amount;
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public int ICollectionEnumerator(ICollection<Transaction> collection)
    {
        var sum = 0;
        foreach (var item in collection) sum += item.Amount;
        return sum;
    }
}

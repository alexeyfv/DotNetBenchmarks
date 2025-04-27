using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: IterationCount)]
public class SetInitialCapacity : BenchmarkBase
{
    [ParamsSource(nameof(GetLengths))]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup() => InitCollections(Length);

    [Benchmark(Baseline = true)]
    public int DefaultInitialCapacity()
    {
        var list = new List<TransactionStruct>();
        for (var i = 0; i < Length; i++)
        {
            list.Add(new TransactionStruct()
            {
                Id = Guid.Empty,
                Amount = i,
                Description = string.Empty
            });
        }
        return list.Count;
    }

    [Benchmark]
    public int GivenInitialCapacity()
    {
        var list = new List<TransactionStruct>(Length);
        for (var i = 0; i < Length; i++)
        {
            list.Add(new TransactionStruct()
            {
                Id = Guid.Empty,
                Amount = i,
                Description = string.Empty
            });
        }
        return list.Count;
    }
}

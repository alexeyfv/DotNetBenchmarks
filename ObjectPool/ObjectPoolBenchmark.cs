using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.Extensions.ObjectPool;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: IterationCount)]
public class ObjectPoolBenchmark : BenchmarkBase
{
    private Task[] _tasks = default!;
    private ObjectPool<List<int>> pool = default!;

    [ParamsSource(nameof(Sizes))]
    public int Size { get; set; }

    [ParamsSource(nameof(ThreadCounts))]
    public int ThreadCount { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _tasks = new Task[ThreadCount];
        pool = Microsoft.Extensions.ObjectPool.ObjectPool.Create(new ListPolicy(Size));
    }

    [Benchmark]
    public void ObjectPool()
    {
        for (int i = 0; i < ThreadCount; i++)
        {
            _tasks[i] = Task.Run(() =>
            {
                var sum = 0;
                for (int i = 0; i < RepetitionsCount; i++)
                {
                    var list = pool.Get();
                    for (var j = 0; j < Size; j++) list.Add(j);
                    sum += list.Count;
                    pool.Return(list);
                }
                return sum;
            });
        }

        Task.WaitAll(_tasks);
    }

    [Benchmark(Baseline = true)]
    public void CreatNewList()
    {
        for (int i = 0; i < ThreadCount; i++)
        {
            _tasks[i] = Task.Run(() =>
            {
                var sum = 0;
                for (int i = 0; i < RepetitionsCount; i++)
                {
                    var list = new List<int>(Size);
                    for (var j = 0; j < Size; j++) list.Add(j);
                    sum += list.Count;
                }
                return sum;
            });
        }

        Task.WaitAll(_tasks);
    }

    public class ListPolicy(int size) : IPooledObjectPolicy<List<int>>
    {
        public List<int> Create() => new(size);

        public bool Return(List<int> obj)
        {
            obj.Clear();
            return true;
        }
    }
}

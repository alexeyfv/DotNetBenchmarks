using System.Buffers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: IterationCount)]
public class ArrayPoolBenchmark : BenchmarkBase
{
    private Task[] _tasks = default!;
    private ArrayPool<int> _sharedArrayPool = default!;
    private ArrayPool<int> _configurableArrayPool = default!;

    [ParamsSource(nameof(Sizes))]
    public int Size { get; set; }

    [ParamsSource(nameof(ThreadCounts))]
    public int ThreadCount { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        _tasks = new Task[ThreadCount];
        _sharedArrayPool = ArrayPool<int>.Shared;
        _configurableArrayPool = ArrayPool<int>.Create();
    }

    [Benchmark(Baseline = true)]
    public void CreatNewArray()
    {
        for (int i = 0; i < ThreadCount; i++)
        {
            _tasks[i] = Task.Run(() =>
            {
                var sum = 0;
                for (int i = 0; i < RepetitionsCount; i++)
                {
                    int[] array = new int[Size];
                    for (var j = 0; j < Size; j++) sum += array[j];
                }
                return sum;
            });
        }

        Task.WaitAll(_tasks);
    }

    [Benchmark]
    public void SharedArrayPool()
    {
        for (int i = 0; i < ThreadCount; i++)
        {
            _tasks[i] = Task.Run(() =>
            {
                var sum = 0;
                for (int i = 0; i < RepetitionsCount; i++)
                {
                    int[] array = _sharedArrayPool.Rent(Size);
                    for (var j = 0; j < Size; j++) sum += array[j];
                    _sharedArrayPool.Return(array, true);
                }
                return sum;
            });
        }

        Task.WaitAll(_tasks);
    }

    [Benchmark]
    public void ConfigurableArrayPool()
    {
        for (int i = 0; i < ThreadCount; i++)
        {
            _tasks[i] = Task.Run(() =>
            {
                var sum = 0;
                for (int i = 0; i < RepetitionsCount; i++)
                {
                    int[] array = _configurableArrayPool.Rent(Size);
                    for (var j = 0; j < Size; j++) sum += array[j];
                    _configurableArrayPool.Return(array, true);
                }
                return sum;
            });
        }

        Task.WaitAll(_tasks);
    }
}

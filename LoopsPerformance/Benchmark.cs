using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Diagnostics.dotTrace;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net90, iterationCount: 25)]
[SimpleJob(RuntimeMoniker.Net80, iterationCount: 25)]
[SimpleJob(RuntimeMoniker.Net60, iterationCount: 25)]
public class BadBenchmark
{
    [Params(100_000)]
    public int ItemCount { get; set; }

    public List<int> Items;

    [GlobalSetup]
    public void GlobalSetup()
    {
        Items = Enumerable.Range(0, ItemCount).ToList();
    }

    [Benchmark]
    public void For()
    {
        for (int i = 0; i < ItemCount; i++)
        {
            DoSomeThing(Items[i]);
        }
    }

    [Benchmark]
    public void ForEach()
    {
        foreach (var item in Items)
        {
            DoSomeThing(item);
        }
    }

    [Benchmark]
    public void ForEach_Linq()
    {
        Items.ForEach(DoSomeThing);
    }

    [Benchmark]
    public void ForEach_Parallel()
    {
        Parallel.ForEach(Items, DoSomeThing);
    }

    [Benchmark]
    public void ForEach_LinqParallel()
    {
        Items.AsParallel().ForAll(DoSomeThing);
    }

    [Benchmark]
    public void For_Span()
    {
        var span = CollectionsMarshal.AsSpan(Items);
        for (int i = 0; i < span.Length; i++)
        {
            DoSomeThing(span[i]);
        }
    }

    [Benchmark]
    public void ForEach_Span()
    {
        foreach (var item in CollectionsMarshal.AsSpan(Items))
        {
            DoSomeThing(item);
        }
    }

    private void DoSomeThing(int i)
    {
        _ = i;
    }
}

[MemoryDiagnoser]
[DisassemblyDiagnoser(printInstructionAddresses: true, printSource: true, exportCombinedDisassemblyReport: true)]
[SimpleJob(RuntimeMoniker.Net90, iterationCount: 25)]
[SimpleJob(RuntimeMoniker.Net80, iterationCount: 25)]
[SimpleJob(RuntimeMoniker.Net60, iterationCount: 25)]
public class BetterBenchmark
{
    [Params(100_000)]
    public int ItemCount { get; set; }
    private List<int> List = null!;
    private static int sum = 0;
    private readonly Action<int> _doSomeThing = x => sum += DoSomeThing(x);
    private readonly Action<int> _doSomeThingParallel = x => Interlocked.Add(ref sum, DoSomeThing(x));

    [GlobalSetup]
    public void GlobalSetup()
    {
        List = Enumerable.Range(0, ItemCount).ToList();
        
        if (For() != For_Span()) throw new Exception();
        if (For() != ForEach()) throw new Exception();
        if (For() != ForEach_Linq()) throw new Exception();
        if (For() != ForEach_LinqParallel()) throw new Exception();
        if (For() != ForEach_Parallel()) throw new Exception();
        if (For() != ForEach_Span()) throw new Exception();
    }

    [Benchmark]
    public int For()
    {
        sum = 0;
        for (int i = 0; i < List.Count; i++)
        {
            sum += DoSomeThing(List[i]);
        }
        return sum;
    }

    [Benchmark]
    public int ForEach()
    {
        sum = 0;
        foreach (var item in List)
        {
            sum += DoSomeThing(item);
        }
        return sum;
    }

    [Benchmark]
    public int ForEach_Linq()
    {
        sum = 0;
        List.ForEach(_doSomeThing);
        return sum;
    }

    [Benchmark]
    public int ForEach_Parallel()
    {
        sum = 0;
        Parallel.ForEach(List, _doSomeThingParallel);
        return sum;
    }

    [Benchmark]
    public int ForEach_LinqParallel()
    {
        sum = 0;
        List.AsParallel().ForAll(_doSomeThingParallel);
        return sum;
    }

    [Benchmark]
    public int For_Span()
    {
        sum = 0;
        var span = CollectionsMarshal.AsSpan(List);
        for (int i = 0; i < span.Length; i++)
        {
            sum += DoSomeThing(span[i]);
        }
        return sum;
    }

    [Benchmark]
    public int ForEach_Span()
    {
        sum = 0;
        foreach (var item in CollectionsMarshal.AsSpan(List))
        {
            sum += DoSomeThing(item);
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int DoSomeThing(int i) => i + i;
}
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

public record Transaction(int Amount, string Description);

[CsvMeasurementsExporter]
[CategoriesColumn]
[MemoryDiagnoser]
[HardwareCounters(HardwareCounter.CacheMisses)]
[SimpleJob(iterationCount: 50)]
public class Benchmark
{ 
    [Params(100_000)]
    public int Length { get; set; }
    public Transaction[] t1 = default!;
    public Transaction[] t2 = default!;
    public record Transaction(int Amount, string Description);

    [GlobalSetup(Target = nameof(Option1))]
    public void Setup1() {
        t1 = new Transaction[Length];
        t2 = new Transaction[Length];
        for (var i = 0; i < Length; i++) t1[i] = new(i, $"{i}");
        for (var i = 0; i < Length; i++) t2[i] = new(i, $"{i}");
    }

    [GlobalSetup(Target = nameof(Option2))]
    public void Setup2() {
        t1 = new Transaction[Length];
        t2 = new Transaction[Length];
        for (var i = 0; i < Length; i++) {
            t1[i] = new(i, $"{i}");
            t2[i] = new(i, $"{i}");
        }
    }

    [Benchmark(Baseline = true)]
    public int Option1() => Sum(t1) + Sum(t2);

    [Benchmark]
    public int Option2() => Sum(t1) + Sum(t2);

    [MethodImpl(MethodImplOptions.NoInlining)]
    private int Sum(Transaction[] t) {
        var sum = 0;
        for (var i = 0; i < Length; i++) sum += t[i].Amount;
        return sum;
    }
}

// Cover for the article
public class Article { 
    public const int Length = 10_000;

    public Transaction[] t1 = new Transaction[Length];
    public Transaction[] t2 = new Transaction[Length]!;
    
    public record Transaction(int Amount, string Description);

    public void Setup1() {
        for (var i = 0; i < Length; i++) t1[i] = new(i, $"{i}");
        for (var i = 0; i < Length; i++) t2[i] = new(i, $"{i}");
    }

    public void Setup2() {
        for (var i = 0; i < Length; i++) {
            t1[i] = new(i, $"{i}");
            t2[i] = new(i, $"{i}");
        }
    }

    public int Sum(Transaction[] t) {
        var sum = 0;
        for (var i = 0; i < Length; i++) sum += t[i].Amount;
        return sum;
    }
}
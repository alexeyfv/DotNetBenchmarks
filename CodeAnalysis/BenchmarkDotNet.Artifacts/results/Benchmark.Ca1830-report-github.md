```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.202
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2
  Job-ACKITE : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2

IterationCount=50  

```
| Method       | Length | Mean      | Error     | StdDev    | Ratio    | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------- |------- |----------:|----------:|----------:|---------:|--------:|--------:|----------:|------------:|
| CallToString | 1000   | 11.285 μs | 0.1813 μs | 0.3621 μs |     +66% |    3.4% | 13.4735 |  27.55 KB |       +386% |
| OnlyAppend   | 1000   |  6.788 μs | 0.0410 μs | 0.0759 μs | baseline |         |  2.7695 |   5.67 KB |             |

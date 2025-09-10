```

BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.413
  [Host]     : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2
  Job-VWLKHT : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2

InvocationCount=1  IterationCount=25  UnrollFactor=1  

```
| Method                   | ResourceCount | Mean       | Error      | StdDev     | Ratio    | RatioSD | Allocated | Alloc Ratio |
|------------------------- |-------------- |-----------:|-----------:|-----------:|---------:|--------:|----------:|------------:|
| DeleteLast2Months        | 100000        | 212.122 ms | 12.9770 ms | 17.3240 ms | baseline |         |   2.19 KB |             |
| DropLast2MonthPartitions | 100000        |   3.354 ms |  0.3788 ms |  0.4791 ms |     -98% |   16.0% |   2.59 KB |        +18% |

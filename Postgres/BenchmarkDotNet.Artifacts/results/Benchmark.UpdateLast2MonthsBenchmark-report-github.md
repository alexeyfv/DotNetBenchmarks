```

BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.413
  [Host]     : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2
  Job-QGAFTE : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2

InvocationCount=1  IterationCount=25  UnrollFactor=1  

```
| Method          | ResourceCount | Mean     | Error    | StdDev   | Ratio    | RatioSD | Gen0      | Gen1      | Allocated | Alloc Ratio |
|---------------- |-------------- |---------:|---------:|---------:|---------:|--------:|----------:|----------:|----------:|------------:|
| IndexRecreation | 100000        | 670.8 ms | 19.93 ms | 25.92 ms |     +26% |    5.9% | 4000.0000 | 1000.0000 |   9.16 MB |         +0% |
| Default         | 100000        | 533.1 ms | 19.37 ms | 25.19 ms | baseline |         | 4000.0000 | 1000.0000 |   9.16 MB |             |
| Partitioned     | 100000        | 363.7 ms | 14.20 ms | 18.95 ms |     -32% |    6.8% | 4000.0000 | 1000.0000 |   9.16 MB |         +0% |

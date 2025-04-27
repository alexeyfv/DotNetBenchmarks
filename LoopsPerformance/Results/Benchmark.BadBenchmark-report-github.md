```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
12th Gen Intel Core i7-12800H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100-rc.1.24452.12
  [Host]     : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  Job-WLUFCS : .NET 6.0.33 (6.0.3324.36610), X64 RyuJIT AVX2
  Job-ENYEEI : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX2
  Job-RDZBZW : .NET 9.0.0 (9.0.24.43107), X64 RyuJIT AVX2

IterationCount=25  

```
| Method               | Runtime  | ItemCount | Mean      | Error    | StdDev   | Gen0   | Allocated |
|--------------------- |--------- |---------- |----------:|---------:|---------:|-------:|----------:|
| For                  | .NET 6.0 | 100000    |  31.53 μs | 0.049 μs | 0.062 μs |      - |         - |
| ForEach              | .NET 6.0 | 100000    |  42.22 μs | 0.116 μs | 0.150 μs |      - |         - |
| ForEach_Linq         | .NET 6.0 | 100000    | 134.49 μs | 0.834 μs | 1.114 μs |      - |      64 B |
| ForEach_Parallel     | .NET 6.0 | 100000    |  61.85 μs | 1.851 μs | 2.273 μs | 0.4272 |    5624 B |
| ForEach_LinqParallel | .NET 6.0 | 100000    | 147.86 μs | 3.749 μs | 4.874 μs | 0.4883 |    7960 B |
| For_Span             | .NET 6.0 | 100000    |  29.25 μs | 0.054 μs | 0.067 μs |      - |         - |
| ForEach_Span         | .NET 6.0 | 100000    |  29.26 μs | 0.051 μs | 0.062 μs |      - |         - |
| For                  | .NET 8.0 | 100000    |  31.49 μs | 0.016 μs | 0.020 μs |      - |         - |
| ForEach              | .NET 8.0 | 100000    |  21.16 μs | 0.057 μs | 0.074 μs |      - |         - |
| ForEach_Linq         | .NET 8.0 | 100000    |  31.60 μs | 0.045 μs | 0.052 μs |      - |      64 B |
| ForEach_Parallel     | .NET 8.0 | 100000    |  41.03 μs | 0.766 μs | 0.968 μs | 0.4272 |    5783 B |
| ForEach_LinqParallel | .NET 8.0 | 100000    |  51.04 μs | 1.127 μs | 1.466 μs | 0.6104 |    7960 B |
| For_Span             | .NET 8.0 | 100000    |  21.39 μs | 0.134 μs | 0.179 μs |      - |         - |
| ForEach_Span         | .NET 8.0 | 100000    |  21.04 μs | 0.035 μs | 0.047 μs |      - |         - |
| For                  | .NET 9.0 | 100000    |  31.60 μs | 0.060 μs | 0.073 μs |      - |         - |
| ForEach              | .NET 9.0 | 100000    |  21.08 μs | 0.050 μs | 0.065 μs |      - |         - |
| ForEach_Linq         | .NET 9.0 | 100000    |  31.59 μs | 0.035 μs | 0.044 μs |      - |      64 B |
| ForEach_Parallel     | .NET 9.0 | 100000    |  40.85 μs | 0.351 μs | 0.444 μs | 0.4272 |    5783 B |
| ForEach_LinqParallel | .NET 9.0 | 100000    |  47.37 μs | 2.125 μs | 2.763 μs | 0.6104 |    7960 B |
| For_Span             | .NET 9.0 | 100000    |  21.07 μs | 0.030 μs | 0.037 μs |      - |         - |
| ForEach_Span         | .NET 9.0 | 100000    |  21.08 μs | 0.034 μs | 0.045 μs |      - |         - |

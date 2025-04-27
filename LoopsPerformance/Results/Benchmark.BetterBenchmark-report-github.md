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
| Method               | Runtime  | ItemCount | Mean        | Error     | StdDev    | Median      | Code Size | Allocated |
|--------------------- |--------- |---------- |------------:|----------:|----------:|------------:|----------:|----------:|
| For                  | .NET 6.0 | 100000    |   145.31 μs |  4.754 μs |  6.346 μs |   141.68 μs |     117 B |         - |
| ForEach              | .NET 6.0 | 100000    |   160.99 μs |  0.745 μs |  0.942 μs |   161.03 μs |     135 B |         - |
| ForEach_Linq         | .NET 6.0 | 100000    |   209.88 μs |  1.003 μs |  1.305 μs |   209.61 μs |     155 B |         - |
| ForEach_Parallel     | .NET 6.0 | 100000    | 1,838.16 μs |  6.614 μs |  7.873 μs | 1,837.78 μs |     573 B |    5450 B |
| ForEach_LinqParallel | .NET 6.0 | 100000    | 1,852.24 μs |  5.715 μs |  7.227 μs | 1,851.65 μs |     637 B |    7895 B |
| For_Span             | .NET 6.0 | 100000    |   135.56 μs |  0.553 μs |  0.679 μs |   135.63 μs |     134 B |         - |
| ForEach_Span         | .NET 6.0 | 100000    |   133.66 μs |  0.967 μs |  1.257 μs |   133.76 μs |        NA |         - |
| For                  | .NET 8.0 | 100000    |    95.76 μs |  0.588 μs |  0.764 μs |    95.77 μs |     112 B |         - |
| ForEach              | .NET 8.0 | 100000    |   116.71 μs |  0.567 μs |  0.757 μs |   117.00 μs |        NA |         - |
| ForEach_Linq         | .NET 8.0 | 100000    |   113.73 μs |  0.301 μs |  0.392 μs |   113.68 μs |     300 B |         - |
| ForEach_Parallel     | .NET 8.0 | 100000    | 1,656.11 μs | 17.840 μs | 22.562 μs | 1,649.92 μs |   1,532 B |    5583 B |
| ForEach_LinqParallel | .NET 8.0 | 100000    | 1,480.85 μs | 26.218 μs | 34.090 μs | 1,491.28 μs |     475 B |    7895 B |
| For_Span             | .NET 8.0 | 100000    |   113.97 μs |  0.589 μs |  0.787 μs |   114.02 μs |     125 B |         - |
| ForEach_Span         | .NET 8.0 | 100000    |   110.51 μs |  0.828 μs |  1.105 μs |   110.19 μs |        NA |         - |
| For                  | .NET 9.0 | 100000    |    92.48 μs |  0.309 μs |  0.412 μs |    92.39 μs |     110 B |         - |
| ForEach              | .NET 9.0 | 100000    |    92.13 μs |  0.211 μs |  0.275 μs |    92.20 μs |        NA |         - |
| ForEach_Linq         | .NET 9.0 | 100000    |   114.37 μs |  0.515 μs |  0.688 μs |   114.57 μs |     295 B |         - |
| ForEach_Parallel     | .NET 9.0 | 100000    | 1,506.33 μs |  5.382 μs |  6.807 μs | 1,504.69 μs |     522 B |    5725 B |
| ForEach_LinqParallel | .NET 9.0 | 100000    | 1,596.71 μs |  6.297 μs |  7.963 μs | 1,596.09 μs |   1,301 B |    7895 B |
| For_Span             | .NET 9.0 | 100000    |   114.19 μs |  0.556 μs |  0.742 μs |   114.10 μs |     108 B |         - |
| ForEach_Span         | .NET 9.0 | 100000    |    91.04 μs |  0.352 μs |  0.469 μs |    91.16 μs |        NA |         - |

```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                 | Mean       | Error    | StdDev   | Allocated |
|--------------------------------------- |-----------:|---------:|---------:|----------:|
| StringEqualsDefault                    |   792.7 μs |  9.48 μs |  8.87 μs |         - |
| StringEqualsOrdinal                    | 1,028.5 μs | 11.06 μs | 10.34 μs |       1 B |
| StringEqualsOrdinalIgnoreCase          |   896.2 μs |  2.75 μs |  2.44 μs |         - |
| StringEqualsInvariantCulture           | 4,104.6 μs | 66.68 μs | 59.11 μs |         - |
| StringEqualsInvariantCultureIgnoreCase | 4,015.8 μs | 43.28 μs | 38.37 μs |       3 B |
| StringEqualsCurrentCulture             | 4,529.6 μs | 54.23 μs | 48.07 μs |       3 B |
| StringEqualsCurrentCultureIgnoreCase   | 4,500.1 μs | 49.98 μs | 46.75 μs |       3 B |
| SpanEqualsDefault                      |         NA |       NA |       NA |        NA |
| SpanEqualsOrdinal                      | 1,081.8 μs | 13.36 μs | 11.16 μs |       1 B |
| SpanEqualsOrdinalIgnoreCase            | 1,122.8 μs | 10.25 μs |  9.09 μs |       1 B |
| SpanEqualsInvariantCulture             | 3,878.0 μs |  5.81 μs |  4.53 μs |       2 B |
| SpanEqualsInvariantCultureIgnoreCase   | 4,020.2 μs | 61.33 μs | 57.37 μs |       3 B |
| SpanEqualsCurrentCulture               | 4,249.9 μs | 26.57 μs | 22.18 μs |       3 B |
| SpanEqualsCurrentCultureIgnoreCase     | 4,264.4 μs | 31.06 μs | 25.94 μs |       3 B |

Benchmarks with issues:
  EqualsBenchmark.SpanEqualsDefault: DefaultJob

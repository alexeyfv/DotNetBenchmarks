```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method | Mean     | Error   | StdDev  | Ratio    | RatioSD | Allocated | Alloc Ratio |
|------- |---------:|--------:|--------:|---------:|--------:|----------:|------------:|
| String | 732.6 μs | 2.68 μs | 2.38 μs | baseline |         |         - |          NA |
| Span   | 709.1 μs | 2.37 μs | 1.98 μs |      -3% |    0.4% |         - |          NA |

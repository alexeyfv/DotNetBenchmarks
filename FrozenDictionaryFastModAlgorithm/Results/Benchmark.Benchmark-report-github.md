****```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4112/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method          | Mean      | Error     | StdDev    | Ratio    | RatioSD | Code Size | Allocated | Alloc Ratio |
|---------------- |----------:|----------:|----------:|---------:|--------:|----------:|----------:|------------:|
| DefaultMod      | 621.27 μs | 11.031 μs | 10.319 μs | baseline |         |      68 B |         - |          NA |
| DefaultModConst |  91.36 μs |  1.800 μs |  2.907 μs |     -85% |    3.0% |      88 B |         - |          NA |
| FastModDotNet   | 104.23 μs |  2.034 μs |  2.422 μs |     -83% |    3.1% |      82 B |         - |          NA |
| FastModLemier   | 125.10 μs |  2.437 μs |  3.722 μs |     -80% |    4.2% |     104 B |         - |          NA |

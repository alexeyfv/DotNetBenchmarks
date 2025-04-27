```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  Job-ABUHKM : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2

IterationCount=50  

```
| Method  | Length | Mean     | Error     | StdDev    | Ratio    | RatioSD | CacheMisses/Op | Allocated | Alloc Ratio |
|-------- |------- |---------:|----------:|----------:|---------:|--------:|---------------:|----------:|------------:|
| Option1 | 100000 | 1.236 ms | 0.0073 ms | 0.0147 ms | baseline |         |         37,489 |       1 B |             |
| Option2 | 100000 | 2.128 ms | 0.0132 ms | 0.0258 ms |     +72% |    1.7% |        167,389 |       2 B |       +100% |

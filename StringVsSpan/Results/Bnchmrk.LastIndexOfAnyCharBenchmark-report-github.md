```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4249/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                         | Mean     | Error     | StdDev    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------- |---------:|----------:|----------:|---------:|--------:|----------:|------------:|
| string.LastIndexOfAny(randomChars)             | 1.165 ms | 0.0099 ms | 0.0092 ms | baseline |         |       1 B |             |
| ReadOnlySpan&lt;char&gt;.LastIndexOfAny(randomChars) | 1.236 ms | 0.0037 ms | 0.0031 ms |      +6% |    0.8% |       1 B |         +0% |

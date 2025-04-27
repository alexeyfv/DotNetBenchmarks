```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method | Options            | Mean      | Error     | StdDev    | Median    | Ratio    | RatioSD | Gen0       | Allocated  | Alloc Ratio |
|------- |------------------- |----------:|----------:|----------:|----------:|---------:|--------:|-----------:|-----------:|------------:|
| **String** | **None**               | **11.468 ms** | **0.0417 ms** | **0.0370 ms** | **11.459 ms** | **baseline** |        **** |  **7984.3750** | **16720102 B** |            **** |
| Span   | None               |  6.167 ms | 0.0100 ms | 0.0089 ms |  6.166 ms |     -46% |    0.3% |          - |        3 B |     -100.0% |
|        |                    |           |           |           |           |          |         |            |            |             |
| **String** | **RemoveEmptyEntries** | **16.291 ms** | **0.9391 ms** | **2.7245 ms** | **14.463 ms** | **baseline** |        **** |  **9000.0000** | **18851550 B** |            **** |
| Span   | RemoveEmptyEntries |  6.328 ms | 0.0172 ms | 0.0161 ms |  6.328 ms |     -60% |   15.0% |          - |        3 B |     -100.0% |
|        |                    |           |           |           |           |          |         |            |            |             |
| **String** | **TrimEntries**        | **17.774 ms** | **0.0601 ms** | **0.0502 ms** | **17.755 ms** | **baseline** |        **** | **10093.7500** | **21163844 B** |            **** |
| Span   | TrimEntries        |  6.817 ms | 0.0167 ms | 0.0148 ms |  6.818 ms |     -62% |    0.3% |          - |        3 B |     -100.0% |

```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method    | Mean       | Error    | StdDev   | Ratio    | RatioSD | Gen0      | Allocated | Alloc Ratio |
|---------- |-----------:|---------:|---------:|---------:|--------:|----------:|----------:|------------:|
| String    | 3,793.9 μs | 11.47 μs | 10.17 μs | baseline |         | 3921.8750 | 8206562 B |             |
| Span      |   966.7 μs |  3.40 μs |  3.01 μs |     -75% |    0.4% |         - |       1 B |     -100.0% |
| SpanAlloc | 2,852.7 μs |  8.33 μs |  7.80 μs |     -25% |    0.4% | 4589.8438 | 9600002 B |      +17.0% |

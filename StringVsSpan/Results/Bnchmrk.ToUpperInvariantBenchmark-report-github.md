```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method    | Mean     | Error     | StdDev    | Gen0      | Allocated |
|---------- |---------:|----------:|----------:|----------:|----------:|
| String    | 3.113 ms | 0.0025 ms | 0.0021 ms | 2292.9688 | 4800002 B |
| Span      | 1.662 ms | 0.0018 ms | 0.0016 ms |         - |       1 B |
| SpanAlloc | 3.591 ms | 0.0086 ms | 0.0072 ms | 4585.9375 | 9600003 B |

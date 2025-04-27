```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method    | Culture | Mean     | Error     | StdDev    | Gen0      | Allocated |
|---------- |-------- |---------:|----------:|----------:|----------:|----------:|
| **String**    | ****        | **3.253 ms** | **0.0097 ms** | **0.0076 ms** | **2292.9688** | **4800002 B** |
| Span      |         | 1.774 ms | 0.0017 ms | 0.0014 ms |         - |       1 B |
| SpanAlloc |         | 3.630 ms | 0.0197 ms | 0.0185 ms | 4585.9375 | 9600003 B |
| **String**    | **en-US**   | **3.256 ms** | **0.0108 ms** | **0.0095 ms** | **2292.9688** | **4800002 B** |
| Span      | en-US   | 1.792 ms | 0.0338 ms | 0.0300 ms |         - |       1 B |
| SpanAlloc | en-US   | 3.663 ms | 0.0098 ms | 0.0087 ms | 4585.9375 | 9600003 B |

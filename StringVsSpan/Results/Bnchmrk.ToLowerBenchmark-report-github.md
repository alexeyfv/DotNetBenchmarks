```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method    | Culture | Mean     | Error     | StdDev    | Gen0      | Allocated |
|---------- |-------- |---------:|----------:|----------:|----------:|----------:|
| **String**    | ****        | **3.394 ms** | **0.0545 ms** | **0.0510 ms** | **2292.9688** | **4800002 B** |
| Span      |         | 1.894 ms | 0.0018 ms | 0.0016 ms |         - |       1 B |
| SpanAlloc |         | 3.938 ms | 0.0268 ms | 0.0251 ms | 4585.9375 | 9600003 B |
| **String**    | **en-US**   | **3.315 ms** | **0.0651 ms** | **0.0749 ms** | **2292.9688** | **4800002 B** |
| Span      | en-US   | 1.901 ms | 0.0033 ms | 0.0028 ms |         - |       2 B |
| SpanAlloc | en-US   | 3.904 ms | 0.0135 ms | 0.0106 ms | 4585.9375 | 9600003 B |

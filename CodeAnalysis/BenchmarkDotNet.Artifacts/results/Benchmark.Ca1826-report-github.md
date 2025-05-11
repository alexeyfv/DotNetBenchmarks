```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3915)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.202
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2
  Job-RLXAAW : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2

IterationCount=20  

```
| Method    | Categories | Length | Mean        | Error       | StdDev      | Allocated |
|---------- |----------- |------- |------------:|------------:|------------:|----------:|
| FirstLinq | Linq       | 1000   | 17,148.3 ns |   996.08 ns | 1,147.09 ns |         - |
| LastLinq  | Linq       | 1000   | 17,399.1 ns | 1,237.07 ns | 1,424.62 ns |         - |
| CountLinq | Linq       | 1000   |  7,087.6 ns |   578.08 ns |   665.72 ns |         - |
|           |            |        |             |             |             |           |
| FirstProp | Prop       | 1000   |  1,542.5 ns |    98.50 ns |   113.43 ns |         - |
| LastProp  | Prop       | 1000   |  1,530.3 ns |   103.36 ns |   119.03 ns |         - |
| CountProp | Prop       | 1000   |    694.8 ns |    51.30 ns |    59.07 ns |         - |

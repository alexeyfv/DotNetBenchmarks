```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3915)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.202
  [Host]     : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2
  Job-YSOJRN : .NET 8.0.14 (8.0.1425.11118), X64 RyuJIT AVX2

IterationCount=20  

```
| Method                    | Length | Mean            | Error         | StdDev        | Ratio    | RatioSD | Gen0      | Allocated  | Alloc Ratio |
|-------------------------- |------- |----------------:|--------------:|--------------:|---------:|--------:|----------:|-----------:|------------:|
| StructuredMessageTemplate | 100    |     10,007.1 ns |     265.20 ns |     294.77 ns | baseline |         |    8.7891 |    18400 B |             |
| StringInterpolation       | 100    |     12,189.8 ns |     281.33 ns |     323.98 ns |     +22% |    3.9% |    3.7842 |     7920 B |        -57% |
| LoggerMessageAttribute    | 100    |        384.0 ns |      12.33 ns |      14.19 ns |     -96% |    4.6% |         - |          - |       -100% |
|                           |        |                 |               |               |          |         |           |            |             |
| StructuredMessageTemplate | 1000   |     99,478.5 ns |   2,451.44 ns |   2,823.08 ns | baseline |         |   87.8906 |   184000 B |             |
| StringInterpolation       | 1000   |    125,079.7 ns |   4,727.94 ns |   5,444.70 ns |     +26% |    5.1% |   41.5039 |    87120 B |        -53% |
| LoggerMessageAttribute    | 1000   |      3,857.6 ns |     109.07 ns |     125.60 ns |     -96% |    4.2% |         - |          - |       -100% |
|                           |        |                 |               |               |          |         |           |            |             |
| StructuredMessageTemplate | 10000  |    972,244.4 ns |  27,948.33 ns |  32,185.34 ns | baseline |         |  879.8828 |  1840000 B |             |
| StringInterpolation       | 10000  |  1,315,899.0 ns |  43,767.54 ns |  50,402.76 ns |     +35% |    5.0% |  488.2813 |  1023121 B |        -44% |
| LoggerMessageAttribute    | 10000  |     37,365.9 ns |   1,230.14 ns |   1,416.64 ns |     -96% |    4.9% |         - |          - |       -100% |
|                           |        |                 |               |               |          |         |           |            |             |
| StructuredMessageTemplate | 100000 |  9,444,437.0 ns | 344,777.52 ns | 383,219.30 ns | baseline |         | 8796.8750 | 18400006 B |             |
| StringInterpolation       | 100000 | 13,541,648.2 ns | 444,353.39 ns | 511,718.03 ns |     +44% |    5.3% | 5296.8750 | 11103126 B |        -40% |
| LoggerMessageAttribute    | 100000 |    374,085.1 ns |  11,551.87 ns |  13,303.15 ns |     -96% |    5.2% |         - |          - |       -100% |

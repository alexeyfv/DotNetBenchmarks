```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4249/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                                                    | Mean         | Error       | StdDev      | Ratio    | RatioSD | Allocated | Alloc Ratio |
|-------------------------------------------------------------------------- |-------------:|------------:|------------:|---------:|--------:|----------:|------------:|
| string.IndexOf(randomChar)                                                |     846.4 μs |     7.09 μs |     5.53 μs | baseline |         |         - |          NA |
| &#39;string.IndexOf(randomChar, StringComparison.Ordinal)&#39;                    |   1,230.7 μs |    16.34 μs |    16.78 μs |     +45% |    1.5% |       1 B |          NA |
| &#39;string.IndexOf(randomChar, StringComparison.OrdinalIgnoreCase)&#39;          |   1,315.1 μs |    22.86 μs |    24.46 μs |     +55% |    1.9% |       1 B |          NA |
| &#39;string.IndexOf(randomChar, StringComparison.CurrentCulture)&#39;             | 263,672.3 μs | 2,649.59 μs | 2,068.63 μs | +31,052% |    1.0% |     200 B |          NA |
| &#39;string.IndexOf(randomChar, StringComparison.CurrentCultureIgnoreCase)&#39;   | 265,234.2 μs | 1,834.00 μs | 1,715.52 μs | +31,236% |    0.9% |     200 B |          NA |
| &#39;string.IndexOf(randomChar, StringComparison.InvariantCulture)&#39;           |   4,470.7 μs |    67.75 μs |    56.57 μs |    +428% |    1.4% |       3 B |          NA |
| &#39;string.IndexOf(randomChar, StringComparison.InvariantCultureIgnoreCase)&#39; |   9,214.2 μs |    21.42 μs |    16.72 μs |    +989% |    0.6% |       6 B |          NA |
| SpanDefault                                                               |   1,100.4 μs |     2.50 μs |     2.22 μs |     +30% |    0.7% |       1 B |          NA |

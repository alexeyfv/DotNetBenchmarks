```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4249/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                                                                             |        Mean |     Error |    StdDev |    Ratio | RatioSD | Allocated | Alloc Ratio |
| -------------------------------------------------------------------------------------------------- | ----------: | --------: | --------: | -------: | ------: | --------: | ----------: |
| string.StartsWith(string)                                                                          | 77,441.7 μs | 326.05 μs | 289.04 μs | +10,653% |    0.7% |      57 B |          NA |
| &#39;string.StartsWith(string, StringComparison.Ordinal)&#39;                                      |    720.2 μs |   4.47 μs |   4.18 μs | baseline |         |         - |          NA |
| &#39;string.StartsWith(string, StringComparison.OrdinalIgnoreCase)&#39;                            |    825.2 μs |   1.74 μs |   1.45 μs |     +15% |    0.6% |         - |          NA |
| &#39;string.StartsWith(string, StringComparison.CurrentCulture)&#39;                               | 77,838.3 μs | 437.72 μs | 409.44 μs | +10,708% |    0.8% |      57 B |          NA |
| &#39;string.StartsWith(string, StringComparison.CurrentCultureIgnoreCase)&#39;                     | 77,461.5 μs | 258.93 μs | 216.22 μs | +10,656% |    0.6% |      57 B |          NA |
| &#39;string.StartsWith(string, StringComparison.InvariantCulture)&#39;                             |  1,467.6 μs |   9.35 μs |   7.81 μs |    +104% |    0.8% |       1 B |          NA |
| &#39;string.StartsWith(string, StringComparison.InvariantCultureIgnoreCase)&#39;                   |  1,793.2 μs |   3.02 μs |   2.67 μs |    +149% |    0.6% |       1 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.StartsWith(string, StringComparison.Ordinal)&#39;                    |    949.3 μs |   6.50 μs |   6.08 μs |     +32% |    0.8% |         - |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.StartsWith(string, StringComparison.OrdinalIgnoreCase)&#39;          |    788.1 μs |   1.03 μs |   0.80 μs |      +9% |    0.6% |         - |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.StartsWith(string, StringComparison.CurrentCulture)&#39;             | 77,018.8 μs | 449.63 μs | 351.04 μs | +10,594% |    0.7% |      57 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.StartsWith(string, StringComparison.CurrentCultureIgnoreCase)&#39;   | 77,164.5 μs | 767.33 μs | 599.08 μs | +10,615% |    0.9% |      57 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.StartsWith(string, StringComparison.InvariantCulture)&#39;           |  1,286.1 μs |   3.89 μs |   3.45 μs |     +79% |    0.6% |       1 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.StartsWith(string, StringComparison.InvariantCultureIgnoreCase)&#39; |  1,623.7 μs |   2.25 μs |   1.99 μs |    +125% |    0.6% |       1 B |          NA |

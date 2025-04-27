```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4249/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                                                             | Mean         | Error        | StdDev       | Median       | Ratio    | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------------------------------------------- |-------------:|-------------:|-------------:|-------------:|---------:|--------:|----------:|------------:|
| string.EndsWith(string)                                                            | 129,804.4 μs |  1,570.25 μs |  1,468.81 μs | 129,922.5 μs | +14,104% |    1.1% |     100 B |          NA |
| &#39;string.EndsWith(string, StringComparison.Ordinal)&#39;                                |     913.9 μs |      1.96 μs |      1.83 μs |     913.9 μs | baseline |         |         - |          NA |
| &#39;string.EndsWith(string, StringComparison.OrdinalIgnoreCase)&#39;                      |     753.0 μs |      1.63 μs |      1.44 μs |     753.3 μs |     -18% |    0.3% |         - |          NA |
| &#39;string.EndsWith(string, StringComparison.CurrentCulture)&#39;                         | 121,636.9 μs |    731.13 μs |    648.13 μs | 121,539.0 μs | +13,210% |    0.6% |     100 B |          NA |
| &#39;string.EndsWith(string, StringComparison.CurrentCultureIgnoreCase)&#39;               | 311,476.5 μs | 12,693.91 μs | 35,385.55 μs | 317,966.5 μs | +33,984% |   11.3% |     100 B |          NA |
| &#39;string.EndsWith(string, StringComparison.InvariantCulture)&#39;                       |   1,224.2 μs |     11.73 μs |     12.55 μs |   1,220.6 μs |     +34% |    1.0% |       1 B |          NA |
| &#39;string.EndsWith(string, StringComparison.InvariantCultureIgnoreCase)&#39;             |   1,614.0 μs |      4.58 μs |      3.82 μs |   1,613.8 μs |     +77% |    0.3% |       1 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.EndsWith(string, StringComparison.Ordinal)&#39;                    |     923.1 μs |      1.92 μs |      1.79 μs |     923.5 μs |      +1% |    0.3% |       1 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.EndsWith(string, StringComparison.OrdinalIgnoreCase)&#39;          |     782.8 μs |     12.81 μs |     11.98 μs |     776.1 μs |     -14% |    1.5% |         - |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.EndsWith(string, StringComparison.CurrentCulture)&#39;             | 122,038.9 μs |    414.43 μs |    387.66 μs | 121,966.2 μs | +13,254% |    0.4% |     100 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.EndsWith(string, StringComparison.CurrentCultureIgnoreCase)&#39;   | 122,762.2 μs |    820.93 μs |    685.51 μs | 123,012.9 μs | +13,333% |    0.6% |     100 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.EndsWith(string, StringComparison.InvariantCulture)&#39;           |   1,275.4 μs |     25.41 μs |     37.24 μs |   1,255.9 μs |     +40% |    2.9% |       1 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.EndsWith(string, StringComparison.InvariantCultureIgnoreCase)&#39; |   1,634.5 μs |     22.23 μs |     18.56 μs |   1,627.6 μs |     +79% |    1.1% |       1 B |          NA |

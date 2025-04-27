```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4249/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                                                             | Mean       | Error     | StdDev    | Median     | Ratio    | RatioSD | Allocated | Alloc Ratio |
|----------------------------------------------------------------------------------- |-----------:|----------:|----------:|-----------:|---------:|--------:|----------:|------------:|
| string.Contains(string)                                                            |   1.282 ms | 0.0017 ms | 0.0014 ms |   1.282 ms | baseline |         |         - |          NA |
| &#39;string.Contains(string, StringComparison.Ordinal)&#39;                                |   1.693 ms | 0.0336 ms | 0.0730 ms |   1.648 ms |     +32% |    4.3% |       1 B |          NA |
| &#39;string.Contains(string, StringComparison.OrdinalIgnoreCase)&#39;                      |   1.942 ms | 0.0382 ms | 0.0718 ms |   1.900 ms |     +51% |    3.7% |       2 B |          NA |
| &#39;string.Contains(string, StringComparison.CurrentCulture)&#39;                         | 331.656 ms | 2.2906 ms | 2.0306 ms | 330.981 ms | +25,763% |    0.6% |     400 B |          NA |
| &#39;string.Contains(string, StringComparison.CurrentCultureIgnoreCase)&#39;               | 332.956 ms | 0.6539 ms | 0.5797 ms | 332.930 ms | +25,864% |    0.2% |     400 B |          NA |
| &#39;string.Contains(string, StringComparison.InvariantCulture)&#39;                       |   9.485 ms | 0.0384 ms | 0.0340 ms |   9.476 ms |    +640% |    0.4% |       6 B |          NA |
| &#39;string.Contains(string, StringComparison.InvariantCultureIgnoreCase)&#39;             |  19.000 ms | 0.0700 ms | 0.0547 ms |  18.980 ms |  +1,382% |    0.3% |      12 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.Contains(string, StringComparison.Ordinal)&#39;                    |   1.302 ms | 0.0040 ms | 0.0031 ms |   1.301 ms |      +2% |    0.3% |       1 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.Contains(string, StringComparison.OrdinalIgnoreCase)&#39;          |   1.610 ms | 0.0052 ms | 0.0044 ms |   1.611 ms |     +26% |    0.3% |       1 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.Contains(string, StringComparison.CurrentCulture)&#39;             | 329.954 ms | 2.2649 ms | 1.8913 ms | 329.380 ms | +25,630% |    0.6% |     400 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.Contains(string, StringComparison.CurrentCultureIgnoreCase)&#39;   | 333.366 ms | 1.0939 ms | 1.0233 ms | 333.568 ms | +25,896% |    0.3% |     400 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.Contains(string, StringComparison.InvariantCulture)&#39;           |   7.670 ms | 0.0140 ms | 0.0110 ms |   7.671 ms |    +498% |    0.2% |       6 B |          NA |
| &#39;ReadOnlySpan&lt;char&gt;.Contains(string, StringComparison.InvariantCultureIgnoreCase)&#39; |  17.465 ms | 0.0128 ms | 0.0107 ms |  17.462 ms |  +1,262% |    0.1% |      12 B |          NA |

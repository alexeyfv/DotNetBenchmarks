```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4249/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                                                                  | Mean       | Error     | StdDev    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|---------------------------------------------------------------------------------------- |-----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| string.IndexOf(randomString)                                                            | 333.837 ms | 5.2581 ms | 5.3997 ms | baseline |         |     400 B |             |
| &#39;string.IndexOf(randomString, StringComparison.Ordinal)&#39;                                |   1.615 ms | 0.0092 ms | 0.0077 ms |   -99.5% |    1.6% |       1 B |      -99.8% |
| &#39;string.IndexOf(randomString, StringComparison.OrdinalIgnoreCase)&#39;                      |   1.866 ms | 0.0017 ms | 0.0014 ms |   -99.4% |    1.5% |       1 B |      -99.8% |
| &#39;string.IndexOf(randomString, StringComparison.CurrentCulture)&#39;                         | 329.011 ms | 1.1783 ms | 0.9840 ms |    -1.4% |    1.6% |     200 B |      -50.0% |
| &#39;string.IndexOf(randomString, StringComparison.CurrentCultureIgnoreCase)&#39;               | 333.899 ms | 0.9951 ms | 0.9308 ms |    +0.0% |    1.6% |     400 B |       +0.0% |
| &#39;string.IndexOf(randomString, StringComparison.InvariantCulture)&#39;                       |   8.081 ms | 0.0179 ms | 0.0139 ms |   -97.6% |    1.5% |       6 B |      -98.5% |
| &#39;string.IndexOf(randomString, StringComparison.InvariantCultureIgnoreCase)&#39;             |  18.347 ms | 0.0459 ms | 0.0383 ms |   -94.5% |    1.5% |      12 B |      -97.0% |
| ReadOnlySpan&lt;char&gt;.IndexOf(randomString)                                                |   1.304 ms | 0.0123 ms | 0.0096 ms |   -99.6% |    1.7% |       1 B |      -99.8% |
| &#39;ReadOnlySpan&lt;char&gt;.IndexOf(randomString, StringComparison.Ordinal)&#39;                    |   1.395 ms | 0.0276 ms | 0.0491 ms |   -99.6% |    3.8% |       1 B |      -99.8% |
| &#39;ReadOnlySpan&lt;char&gt;.IndexOf(randomString, StringComparison.OrdinalIgnoreCase)&#39;          |   1.678 ms | 0.0193 ms | 0.0161 ms |   -99.5% |    1.8% |       1 B |      -99.8% |
| &#39;ReadOnlySpan&lt;char&gt;.IndexOf(randomString, StringComparison.CurrentCulture)&#39;             | 332.030 ms | 1.1093 ms | 0.9263 ms |    -0.5% |    1.6% |     200 B |      -50.0% |
| &#39;ReadOnlySpan&lt;char&gt;.IndexOf(randomString, StringComparison.CurrentCultureIgnoreCase)&#39;   | 335.258 ms | 2.5007 ms | 2.0882 ms |    +0.4% |    1.6% |     400 B |       +0.0% |
| &#39;ReadOnlySpan&lt;char&gt;.IndexOf(randomString, StringComparison.InvariantCulture)&#39;           |   7.646 ms | 0.0145 ms | 0.0128 ms |   -97.7% |    1.5% |       6 B |      -98.5% |
| &#39;ReadOnlySpan&lt;char&gt;.IndexOf(randomString, StringComparison.InvariantCultureIgnoreCase)&#39; |  17.404 ms | 0.0132 ms | 0.0110 ms |   -94.8% |    1.5% |      12 B |      -97.0% |

```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4249/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                                                                      | Mean       | Error     | StdDev    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|-------------------------------------------------------------------------------------------- |-----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| string.LastIndexOf(randomString)                                                            | 472.294 ms | 2.5169 ms | 2.3543 ms | baseline |         |     400 B |             |
| &#39;string.LastIndexOf(randomString, StringComparison.Ordinal)&#39;                                |   1.800 ms | 0.0030 ms | 0.0027 ms |   -99.6% |    0.5% |       2 B |      -99.5% |
| &#39;string.LastIndexOf(randomString, StringComparison.OrdinalIgnoreCase)&#39;                      |  11.967 ms | 0.0250 ms | 0.0221 ms |   -97.5% |    0.5% |       6 B |      -98.5% |
| &#39;string.LastIndexOf(randomString, StringComparison.CurrentCulture)&#39;                         | 469.670 ms | 1.5018 ms | 1.4048 ms |    -0.6% |    0.6% |     400 B |       +0.0% |
| &#39;string.LastIndexOf(randomString, StringComparison.CurrentCultureIgnoreCase)&#39;               | 473.584 ms | 1.6721 ms | 1.5641 ms |    +0.3% |    0.6% |     400 B |       +0.0% |
| &#39;string.LastIndexOf(randomString, StringComparison.InvariantCulture)&#39;                       |   8.486 ms | 0.0200 ms | 0.0156 ms |   -98.2% |    0.5% |       6 B |      -98.5% |
| &#39;string.LastIndexOf(randomString, StringComparison.InvariantCultureIgnoreCase)&#39;             |  19.482 ms | 0.0460 ms | 0.0431 ms |   -95.9% |    0.5% |      12 B |      -97.0% |
| ReadOnlySpan&lt;char&gt;.LastIndexOf(randomString)                                                |   1.284 ms | 0.0011 ms | 0.0010 ms |   -99.7% |    0.5% |       1 B |      -99.8% |
| &#39;ReadOnlySpan&lt;char&gt;.LastIndexOf(randomString, StringComparison.Ordinal)&#39;                    |   1.375 ms | 0.0188 ms | 0.0166 ms |   -99.7% |    1.3% |       1 B |      -99.8% |
| &#39;ReadOnlySpan&lt;char&gt;.LastIndexOf(randomString, StringComparison.OrdinalIgnoreCase)&#39;          |  11.159 ms | 0.2211 ms | 0.3376 ms |   -97.6% |    3.0% |       6 B |      -98.5% |
| &#39;ReadOnlySpan&lt;char&gt;.LastIndexOf(randomString, StringComparison.CurrentCulture)&#39;             | 472.562 ms | 1.3318 ms | 1.2458 ms |    +0.1% |    0.5% |     400 B |       +0.0% |
| &#39;ReadOnlySpan&lt;char&gt;.LastIndexOf(randomString, StringComparison.CurrentCultureIgnoreCase)&#39;   | 474.741 ms | 1.4583 ms | 1.2928 ms |    +0.5% |    0.5% |     400 B |       +0.0% |
| &#39;ReadOnlySpan&lt;char&gt;.LastIndexOf(randomString, StringComparison.InvariantCulture)&#39;           |   7.567 ms | 0.0111 ms | 0.0093 ms |   -98.4% |    0.5% |       6 B |      -98.5% |
| &#39;ReadOnlySpan&lt;char&gt;.LastIndexOf(randomString, StringComparison.InvariantCultureIgnoreCase)&#39; |  18.328 ms | 0.0148 ms | 0.0124 ms |   -96.1% |    0.5% |      12 B |      -97.0% |

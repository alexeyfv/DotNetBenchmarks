```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                    | Mean       | Error    | StdDev   | Gen0      | Allocated |
|------------------------------------------ |-----------:|---------:|---------:|----------:|----------:|
| string.Trim()                             |   579.0 μs |  1.90 μs |  1.68 μs |         - |         - |
| &#39;string.Trim(char trimChar)&#39;              |   964.1 μs |  7.20 μs |  6.74 μs |  546.8750 | 1143841 B |
| &#39;string.Trim(char trimChars)&#39;             | 1,808.0 μs | 14.93 μs | 13.97 μs | 1074.2188 | 2250177 B |
| ReadOnlySpan&lt;char&gt;.Trim()                 |   598.1 μs |  2.77 μs |  2.31 μs |         - |         - |
| &#39;ReadOnlySpan&lt;char&gt;.Trim(char trimChar)&#39;  |   645.7 μs |  7.18 μs |  6.36 μs |         - |         - |
| &#39;ReadOnlySpan&lt;char&gt;.Trim(char trimChars)&#39; | 1,049.1 μs |  5.70 μs |  5.06 μs |         - |       1 B |

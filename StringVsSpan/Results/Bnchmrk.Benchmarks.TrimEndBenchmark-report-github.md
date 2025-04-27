```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                       | Mean       | Error   | StdDev  | Gen0     | Allocated |
|--------------------------------------------- |-----------:|--------:|--------:|---------:|----------:|
| string.TrimEnd()                             |   566.6 μs | 0.96 μs | 0.85 μs |        - |         - |
| &#39;string.TrimEnd(char trimChar)&#39;              |   925.7 μs | 5.96 μs | 4.98 μs | 281.2500 |  588304 B |
| &#39;string.TrimEnd(char trimChars)&#39;             | 1,459.1 μs | 9.15 μs | 8.56 μs | 861.3281 | 1801281 B |
| ReadOnlySpan&lt;char&gt;.TrimEnd()                 |   586.5 μs | 2.42 μs | 2.26 μs |        - |         - |
| &#39;ReadOnlySpan&lt;char&gt;.TrimEnd(char trimChar)&#39;  |   565.1 μs | 5.16 μs | 4.82 μs |        - |         - |
| &#39;ReadOnlySpan&lt;char&gt;.TrimEnd(char trimChars)&#39; |   694.1 μs | 2.17 μs | 1.93 μs |        - |         - |

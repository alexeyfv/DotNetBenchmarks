```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4249/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                                                               | Mean       | Error     | StdDev    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------------------------------------- |-----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| string.Contains(char)                                                |   1.086 ms | 0.0131 ms | 0.0123 ms | baseline |         |       1 B |             |
| ReadOnlySpan&lt;char&gt;.Contains(char)                                    |   1.057 ms | 0.0206 ms | 0.0172 ms |      -3% |    1.9% |       1 B |         +0% |
| &#39;string.Contains(char, StringComparison.Ordinal)&#39;                    |   1.237 ms | 0.0039 ms | 0.0031 ms |     +14% |    1.1% |       1 B |         +0% |
| &#39;string.Contains(char, StringComparison.OrdinalIgnoreCase)&#39;          |   1.312 ms | 0.0020 ms | 0.0019 ms |     +21% |    1.1% |       1 B |         +0% |
| &#39;string.Contains(char, StringComparison.CurrentCulture)&#39;             | 249.081 ms | 1.4479 ms | 1.2091 ms | +22,828% |    1.2% |     200 B |    +19,900% |
| &#39;string.Contains(char, StringComparison.CurrentCultureIgnoreCase)&#39;   | 261.706 ms | 0.7530 ms | 0.6675 ms | +23,990% |    1.1% |     200 B |    +19,900% |
| &#39;string.Contains(char, StringComparison.InvariantCulture)&#39;           |   4.560 ms | 0.0118 ms | 0.0116 ms |    +320% |    1.1% |       3 B |       +200% |
| &#39;string.Contains(char, StringComparison.InvariantCultureIgnoreCase)&#39; |   9.353 ms | 0.0147 ms | 0.0123 ms |    +761% |    1.1% |       6 B |       +500% |

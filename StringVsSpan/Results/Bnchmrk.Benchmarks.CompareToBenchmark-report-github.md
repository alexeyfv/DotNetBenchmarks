```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method                  | Comparison           | Mean       | Error    | StdDev    | Median     | Allocated |
|------------------------ |--------------------- |-----------:|---------:|----------:|-----------:|----------:|
| **StringCompareToInternal** | **CurrentCulture**       | **4,627.1 μs** | **11.40 μs** |  **10.66 μs** | **4,623.4 μs** |       **3 B** |
| SpanCompareToInternal   | CurrentCulture       | 4,638.7 μs | 90.83 μs | 161.46 μs | 4,556.0 μs |       3 B |
| **StringCompareToInternal** | **Curre(...)eCase [24]** | **4,462.2 μs** | **43.74 μs** |  **36.52 μs** | **4,448.4 μs** |       **3 B** |
| SpanCompareToInternal   | Curre(...)eCase [24] | 4,697.0 μs | 93.10 μs | 174.86 μs | 4,625.7 μs |       3 B |
| **StringCompareToInternal** | **InvariantCulture**     | **3,911.5 μs** | **76.53 μs** | **123.58 μs** | **3,892.6 μs** |       **2 B** |
| SpanCompareToInternal   | InvariantCulture     | 4,203.2 μs | 83.73 μs | 194.06 μs | 4,129.3 μs |       3 B |
| **StringCompareToInternal** | **Invar(...)eCase [26]** | **3,936.3 μs** | **77.93 μs** | **171.05 μs** | **3,852.3 μs** |       **3 B** |
| SpanCompareToInternal   | Invar(...)eCase [26] | 4,323.9 μs | 86.13 μs | 159.65 μs | 4,318.3 μs |       3 B |
| **StringCompareToInternal** | **Ordinal**              |   **646.6 μs** |  **5.02 μs** |   **4.19 μs** |   **646.8 μs** |         **-** |
| SpanCompareToInternal   | Ordinal              | 1,220.2 μs |  6.53 μs |   5.45 μs | 1,219.9 μs |       1 B |
| **StringCompareToInternal** | **OrdinalIgnoreCase**    |   **844.9 μs** | **11.06 μs** |  **10.35 μs** |   **840.8 μs** |         **-** |
| SpanCompareToInternal   | OrdinalIgnoreCase    |   992.0 μs |  4.41 μs |   3.68 μs |   990.9 μs |       1 B |

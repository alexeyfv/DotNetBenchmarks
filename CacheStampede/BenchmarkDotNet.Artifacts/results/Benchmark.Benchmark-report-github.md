```

BenchmarkDotNet v0.15.8, Linux Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics 1.21GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  Job-DCZXCV : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3

InvocationCount=1  IterationCount=20  UnrollFactor=1  
Categories=Stampede  

```
| Method                        | Operation | ConcurrentRequests | Mean     | Error    | StdDev   | Median   | Ratio    | RatioSD | Op Count | Allocated | Alloc Ratio |
|------------------------------ |---------- |------------------- |---------:|---------:|---------:|---------:|---------:|--------:|---------:|----------:|------------:|
| **HybridCache_Stampede**          | **IOBound**   | **1**                  | **100.4 ms** |  **0.79 ms** |  **0.91 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **2960 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 1                  | 100.4 ms |  0.80 ms |  0.92 ms | 100.5 ms |      -0% |    1.3% |      1.0 |    2336 B |        -21% |
| ConcurrentDictionary_Stampede | IOBound   | 1                  | 100.4 ms |  0.79 ms |  0.91 ms | 100.6 ms |      -0% |    1.3% |      1.0 |    2192 B |        -26% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **2**                  | **100.6 ms** |  **0.14 ms** |  **0.16 ms** | **100.6 ms** | **baseline** |        **** |      **1.0** |    **3032 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 2                  | 100.6 ms |  0.13 ms |  0.15 ms | 100.6 ms |      +0% |    0.2% |      2.0 |    2048 B |        -32% |
| ConcurrentDictionary_Stampede | IOBound   | 2                  | 100.4 ms |  0.76 ms |  0.87 ms | 100.7 ms |      -0% |    0.9% |      2.0 |    1760 B |        -42% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **3**                  | **100.5 ms** |  **0.78 ms** |  **0.90 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **3120 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 3                  | 100.7 ms |  0.16 ms |  0.18 ms | 100.7 ms |      +0% |    0.9% |      3.0 |    2808 B |        -10% |
| ConcurrentDictionary_Stampede | IOBound   | 3                  | 100.7 ms |  0.11 ms |  0.13 ms | 100.7 ms |      +0% |    0.9% |      3.0 |    2384 B |        -24% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **4**                  | **100.6 ms** |  **0.14 ms** |  **0.16 ms** | **100.6 ms** | **baseline** |        **** |      **1.0** |    **3200 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 4                  | 100.6 ms |  0.13 ms |  0.14 ms | 100.6 ms |      +0% |    0.2% |      4.0 |    3568 B |        +12% |
| ConcurrentDictionary_Stampede | IOBound   | 4                  | 100.7 ms |  0.13 ms |  0.15 ms | 100.7 ms |      +0% |    0.2% |      4.0 |    3000 B |         -6% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **5**                  | **100.7 ms** |  **0.10 ms** |  **0.12 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **3376 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 5                  | 100.6 ms |  0.76 ms |  0.88 ms | 100.8 ms |      -0% |    0.9% |      5.0 |    4328 B |        +28% |
| ConcurrentDictionary_Stampede | IOBound   | 5                  | 100.7 ms |  0.12 ms |  0.14 ms | 100.7 ms |      -0% |    0.2% |      5.0 |    3624 B |         +7% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **6**                  | **100.6 ms** |  **0.14 ms** |  **0.16 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **3456 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 6                  | 100.7 ms |  0.17 ms |  0.19 ms | 100.7 ms |      +0% |    0.2% |      6.0 |    5088 B |        +47% |
| ConcurrentDictionary_Stampede | IOBound   | 6                  | 100.8 ms |  0.11 ms |  0.12 ms | 100.8 ms |      +0% |    0.2% |      6.0 |    4240 B |        +23% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **7**                  | **100.6 ms** |  **0.12 ms** |  **0.14 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **3544 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 7                  | 100.6 ms |  0.11 ms |  0.12 ms | 100.7 ms |      +0% |    0.2% |      7.0 |    5848 B |        +65% |
| ConcurrentDictionary_Stampede | IOBound   | 7                  | 100.7 ms |  0.16 ms |  0.18 ms | 100.7 ms |      +0% |    0.2% |      7.0 |    4864 B |        +37% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **8**                  | **100.4 ms** |  **0.83 ms** |  **0.95 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **3624 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 8                  | 100.6 ms |  0.11 ms |  0.12 ms | 100.6 ms |      +0% |    1.0% |      8.0 |    6608 B |        +82% |
| ConcurrentDictionary_Stampede | IOBound   | 8                  | 100.6 ms |  0.12 ms |  0.14 ms | 100.7 ms |      +0% |    1.0% |      8.0 |    5480 B |        +51% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **9**                  | **100.6 ms** |  **0.13 ms** |  **0.15 ms** | **100.6 ms** | **baseline** |        **** |      **1.0** |    **3864 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 9                  | 100.7 ms |  0.12 ms |  0.14 ms | 100.7 ms |      +0% |    0.2% |      9.0 |    7368 B |        +91% |
| ConcurrentDictionary_Stampede | IOBound   | 9                  | 100.7 ms |  0.14 ms |  0.16 ms | 100.7 ms |      +0% |    0.2% |      9.0 |    6104 B |        +58% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **10**                 | **100.7 ms** |  **0.11 ms** |  **0.13 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **3944 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 10                 | 100.7 ms |  0.10 ms |  0.11 ms | 100.7 ms |      +0% |    0.2% |     10.0 |    8128 B |       +106% |
| ConcurrentDictionary_Stampede | IOBound   | 10                 | 100.7 ms |  0.14 ms |  0.16 ms | 100.7 ms |      +0% |    0.2% |     10.0 |    6720 B |        +70% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **11**                 | **100.7 ms** |  **0.14 ms** |  **0.16 ms** | **100.8 ms** | **baseline** |        **** |      **1.0** |    **4032 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 11                 | 100.6 ms |  0.11 ms |  0.13 ms | 100.7 ms |      -0% |    0.2% |     11.0 |    8888 B |       +120% |
| ConcurrentDictionary_Stampede | IOBound   | 11                 | 100.6 ms |  0.12 ms |  0.13 ms | 100.6 ms |      -0% |    0.2% |     11.0 |    7344 B |        +82% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **12**                 | **100.6 ms** |  **0.13 ms** |  **0.14 ms** | **100.6 ms** | **baseline** |        **** |      **1.0** |    **4112 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 12                 | 100.7 ms |  0.13 ms |  0.15 ms | 100.7 ms |      +0% |    0.2% |     12.0 |    9648 B |       +135% |
| ConcurrentDictionary_Stampede | IOBound   | 12                 | 100.6 ms |  0.09 ms |  0.10 ms | 100.6 ms |      -0% |    0.2% |     12.0 |    7960 B |        +94% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **13**                 | **100.6 ms** |  **0.16 ms** |  **0.18 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **4200 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 13                 | 100.8 ms |  0.11 ms |  0.12 ms | 100.8 ms |      +0% |    0.2% |     13.0 |   10408 B |       +148% |
| ConcurrentDictionary_Stampede | IOBound   | 13                 | 100.7 ms |  0.15 ms |  0.17 ms | 100.7 ms |      +0% |    0.2% |     13.0 |    8584 B |       +104% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **14**                 | **100.6 ms** |  **0.12 ms** |  **0.13 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **4280 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 14                 | 100.7 ms |  0.10 ms |  0.12 ms | 100.7 ms |      +0% |    0.2% |     14.0 |   11168 B |       +161% |
| ConcurrentDictionary_Stampede | IOBound   | 14                 | 100.6 ms |  0.16 ms |  0.19 ms | 100.5 ms |      -0% |    0.2% |     14.0 |    9200 B |       +115% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **15**                 | **100.6 ms** |  **0.15 ms** |  **0.17 ms** | **100.6 ms** | **baseline** |        **** |      **1.0** |    **4368 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 15                 | 100.6 ms |  0.11 ms |  0.13 ms | 100.6 ms |      +0% |    0.2% |     15.0 |   11928 B |       +173% |
| ConcurrentDictionary_Stampede | IOBound   | 15                 | 100.6 ms |  0.13 ms |  0.14 ms | 100.5 ms |      -0% |    0.2% |     15.0 |    9824 B |       +125% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **16**                 | **100.3 ms** |  **1.09 ms** |  **1.25 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **4448 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 16                 | 100.7 ms |  0.12 ms |  0.14 ms | 100.7 ms |      +0% |    1.3% |     16.0 |   12688 B |       +185% |
| ConcurrentDictionary_Stampede | IOBound   | 16                 | 100.8 ms |  0.14 ms |  0.16 ms | 100.8 ms |      +1% |    1.3% |     16.0 |   10440 B |       +135% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **17**                 | **100.7 ms** |  **0.14 ms** |  **0.17 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **4816 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 17                 | 100.8 ms |  0.13 ms |  0.15 ms | 100.8 ms |      +0% |    0.2% |     17.0 |   13448 B |       +179% |
| ConcurrentDictionary_Stampede | IOBound   | 17                 | 100.7 ms |  0.13 ms |  0.15 ms | 100.7 ms |      +0% |    0.2% |     17.0 |   11064 B |       +130% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **18**                 | **100.6 ms** |  **0.12 ms** |  **0.14 ms** | **100.6 ms** | **baseline** |        **** |      **1.0** |    **4896 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 18                 | 100.7 ms |  0.12 ms |  0.14 ms | 100.7 ms |      +0% |    0.2% |     18.0 |   14208 B |       +190% |
| ConcurrentDictionary_Stampede | IOBound   | 18                 | 100.6 ms |  0.13 ms |  0.15 ms | 100.6 ms |      +0% |    0.2% |     18.0 |   11680 B |       +139% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **19**                 | **100.6 ms** |  **0.15 ms** |  **0.17 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **4984 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 19                 | 100.7 ms |  0.13 ms |  0.15 ms | 100.7 ms |      +0% |    0.2% |     19.0 |   14968 B |       +200% |
| ConcurrentDictionary_Stampede | IOBound   | 19                 | 100.7 ms |  0.14 ms |  0.16 ms | 100.7 ms |      +0% |    0.2% |     19.0 |   12304 B |       +147% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **20**                 | **100.5 ms** |  **0.76 ms** |  **0.87 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **5064 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 20                 | 100.7 ms |  0.16 ms |  0.18 ms | 100.7 ms |      +0% |    0.9% |     20.0 |   15728 B |       +211% |
| ConcurrentDictionary_Stampede | IOBound   | 20                 | 100.7 ms |  0.11 ms |  0.13 ms | 100.7 ms |      +0% |    0.9% |     20.0 |   12920 B |       +155% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **21**                 | **100.7 ms** |  **0.09 ms** |  **0.11 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **5152 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 21                 | 100.7 ms |  0.14 ms |  0.16 ms | 100.7 ms |      +0% |    0.2% |     21.0 |   16488 B |       +220% |
| ConcurrentDictionary_Stampede | IOBound   | 21                 | 100.8 ms |  0.12 ms |  0.14 ms | 100.8 ms |      +0% |    0.2% |     21.0 |   13544 B |       +163% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **22**                 | **100.6 ms** |  **0.13 ms** |  **0.15 ms** | **100.6 ms** | **baseline** |        **** |      **1.0** |    **5232 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 22                 | 100.8 ms |  0.13 ms |  0.15 ms | 100.8 ms |      +0% |    0.2% |     22.0 |   17248 B |       +230% |
| ConcurrentDictionary_Stampede | IOBound   | 22                 | 100.7 ms |  0.14 ms |  0.16 ms | 100.7 ms |      +0% |    0.2% |     22.0 |   14160 B |       +171% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **23**                 | **100.6 ms** |  **0.14 ms** |  **0.16 ms** | **100.6 ms** | **baseline** |        **** |      **1.0** |    **5320 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 23                 | 100.6 ms |  0.13 ms |  0.15 ms | 100.7 ms |      +0% |    0.2% |     23.0 |   18008 B |       +238% |
| ConcurrentDictionary_Stampede | IOBound   | 23                 | 100.6 ms |  0.14 ms |  0.16 ms | 100.7 ms |      +0% |    0.2% |     23.0 |   14784 B |       +178% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **IOBound**   | **24**                 | **100.7 ms** |  **0.12 ms** |  **0.13 ms** | **100.7 ms** | **baseline** |        **** |      **1.0** |    **5400 B** |            **** |
| MemoryCache_Stampede          | IOBound   | 24                 | 100.8 ms |  0.12 ms |  0.14 ms | 100.7 ms |      +0% |    0.2% |     24.0 |   18768 B |       +248% |
| ConcurrentDictionary_Stampede | IOBound   | 24                 | 100.5 ms |  0.75 ms |  0.86 ms | 100.7 ms |      -0% |    0.8% |     24.0 |   15400 B |       +185% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **1**                  | **198.1 ms** |  **0.41 ms** |  **0.42 ms** | **198.0 ms** | **baseline** |        **** |      **1.0** |    **1168 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 1                  | 198.9 ms |  0.25 ms |  0.28 ms | 198.9 ms |      +0% |    0.2% |      1.0 |     968 B |        -17% |
| ConcurrentDictionary_Stampede | CPUBound  | 1                  | 198.8 ms |  0.37 ms |  0.43 ms | 198.8 ms |      +0% |    0.3% |      1.0 |     824 B |        -29% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **2**                  | **197.6 ms** |  **0.12 ms** |  **0.12 ms** | **197.6 ms** | **baseline** |        **** |      **1.0** |    **1224 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 2                  | 199.6 ms |  0.42 ms |  0.46 ms | 199.6 ms |      +1% |    0.2% |      2.0 |    1408 B |        +15% |
| ConcurrentDictionary_Stampede | CPUBound  | 2                  | 199.5 ms |  0.49 ms |  0.52 ms | 199.5 ms |      +1% |    0.3% |      2.0 |    1120 B |         -8% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **3**                  | **197.9 ms** |  **0.19 ms** |  **0.20 ms** | **197.9 ms** | **baseline** |        **** |      **1.0** |    **1384 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 3                  | 198.1 ms |  1.34 ms |  1.49 ms | 197.4 ms |      +0% |    0.7% |      3.0 |    1848 B |        +34% |
| ConcurrentDictionary_Stampede | CPUBound  | 3                  | 199.1 ms |  0.92 ms |  0.95 ms | 199.2 ms |      +1% |    0.5% |      3.0 |    1424 B |         +3% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **4**                  | **197.6 ms** |  **0.09 ms** |  **0.09 ms** | **197.5 ms** | **baseline** |        **** |      **1.0** |    **1536 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 4                  | 201.7 ms |  1.62 ms |  1.80 ms | 201.6 ms |      +2% |    0.9% |      4.0 |    2288 B |        +49% |
| ConcurrentDictionary_Stampede | CPUBound  | 4                  | 201.8 ms |  2.71 ms |  2.90 ms | 202.2 ms |      +2% |    1.4% |      4.0 |    1720 B |        +12% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **5**                  | **198.0 ms** |  **0.27 ms** |  **0.29 ms** | **197.9 ms** | **baseline** |        **** |      **1.0** |    **1696 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 5                  | 217.4 ms | 11.41 ms | 12.68 ms | 211.2 ms |     +10% |    5.7% |      5.0 |    2728 B |        +61% |
| ConcurrentDictionary_Stampede | CPUBound  | 5                  | 207.0 ms |  3.36 ms |  3.30 ms | 206.9 ms |      +5% |    1.6% |      5.0 |    2056 B |        +21% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **6**                  | **197.7 ms** |  **0.12 ms** |  **0.14 ms** | **197.7 ms** | **baseline** |        **** |      **1.0** |    **1848 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 6                  | 220.6 ms | 11.96 ms | 13.30 ms | 212.3 ms |     +12% |    5.9% |      6.0 |    3168 B |        +71% |
| ConcurrentDictionary_Stampede | CPUBound  | 6                  | 216.7 ms |  3.16 ms |  3.63 ms | 215.6 ms |     +10% |    1.6% |      6.0 |    2320 B |        +26% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **7**                  | **198.0 ms** |  **0.25 ms** |  **0.27 ms** | **198.0 ms** | **baseline** |        **** |      **1.0** |    **2008 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 7                  | 324.0 ms |  3.03 ms |  3.37 ms | 323.0 ms |     +64% |    1.0% |      7.0 |    3608 B |        +80% |
| ConcurrentDictionary_Stampede | CPUBound  | 7                  | 326.8 ms |  3.02 ms |  3.47 ms | 326.7 ms |     +65% |    1.0% |      7.0 |    2624 B |        +31% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **8**                  | **197.6 ms** |  **0.05 ms** |  **0.05 ms** | **197.6 ms** | **baseline** |        **** |      **1.0** |    **2160 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 8                  | 328.4 ms |  2.40 ms |  2.66 ms | 328.2 ms |     +66% |    0.8% |      8.0 |    4080 B |        +89% |
| ConcurrentDictionary_Stampede | CPUBound  | 8                  | 333.0 ms |  3.72 ms |  4.13 ms | 333.9 ms |     +69% |    1.2% |      8.0 |    2920 B |        +35% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **9**                  | **198.2 ms** |  **0.19 ms** |  **0.21 ms** | **198.2 ms** | **baseline** |        **** |      **1.0** |    **2320 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 9                  | 369.1 ms | 11.51 ms | 13.25 ms | 368.4 ms |     +86% |    3.5% |      9.0 |    4488 B |        +93% |
| ConcurrentDictionary_Stampede | CPUBound  | 9                  | 375.5 ms |  9.83 ms | 11.32 ms | 371.6 ms |     +89% |    2.9% |      9.0 |    3256 B |        +40% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **10**                 | **197.8 ms** |  **0.37 ms** |  **0.43 ms** | **197.7 ms** | **baseline** |        **** |      **1.0** |    **2472 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 10                 | 413.2 ms |  7.28 ms |  7.79 ms | 413.7 ms |    +109% |    1.8% |     10.0 |    4960 B |       +101% |
| ConcurrentDictionary_Stampede | CPUBound  | 10                 | 409.3 ms |  6.21 ms |  7.15 ms | 407.6 ms |    +107% |    1.7% |     10.0 |    3520 B |        +42% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **11**                 | **197.8 ms** |  **0.09 ms** |  **0.09 ms** | **197.8 ms** | **baseline** |        **** |      **1.0** |    **2632 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 11                 | 439.5 ms |  3.08 ms |  3.55 ms | 438.6 ms |    +122% |    0.8% |     11.0 |    5368 B |       +104% |
| ConcurrentDictionary_Stampede | CPUBound  | 11                 | 437.8 ms |  2.86 ms |  3.29 ms | 438.2 ms |    +121% |    0.7% |     11.0 |    3856 B |        +47% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **12**                 | **197.7 ms** |  **0.16 ms** |  **0.18 ms** | **197.7 ms** | **baseline** |        **** |      **1.0** |    **2784 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 12                 | 445.2 ms |  4.90 ms |  5.45 ms | 442.5 ms |    +125% |    1.2% |     12.0 |    5808 B |       +109% |
| ConcurrentDictionary_Stampede | CPUBound  | 12                 | 452.2 ms |  3.85 ms |  4.12 ms | 450.8 ms |    +129% |    0.9% |     12.0 |    4152 B |        +49% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **13**                 | **197.6 ms** |  **0.08 ms** |  **0.08 ms** | **197.6 ms** | **baseline** |        **** |      **1.0** |    **2944 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 13                 | 486.3 ms | 36.39 ms | 41.90 ms | 498.7 ms |    +146% |    8.4% |     12.4 |    6152 B |       +109% |
| ConcurrentDictionary_Stampede | CPUBound  | 13                 | 492.5 ms | 35.97 ms | 41.43 ms | 488.5 ms |    +149% |    8.2% |     12.4 |    4456 B |        +51% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **14**                 | **198.1 ms** |  **0.30 ms** |  **0.34 ms** | **198.2 ms** | **baseline** |        **** |      **1.0** |    **3096 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 14                 | 480.7 ms | 36.30 ms | 41.81 ms | 447.5 ms |    +143% |    8.5% |     12.5 |    6592 B |       +113% |
| ConcurrentDictionary_Stampede | CPUBound  | 14                 | 492.2 ms | 35.37 ms | 40.73 ms | 509.7 ms |    +148% |    8.1% |     12.4 |    4752 B |        +53% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **15**                 | **198.0 ms** |  **0.27 ms** |  **0.30 ms** | **198.0 ms** | **baseline** |        **** |      **1.0** |    **3256 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 15                 | 484.8 ms | 37.69 ms | 43.41 ms | 478.6 ms |    +145% |    8.7% |     12.4 |    6872 B |       +111% |
| ConcurrentDictionary_Stampede | CPUBound  | 15                 | 491.8 ms | 36.26 ms | 41.76 ms | 521.0 ms |    +148% |    8.3% |     12.5 |    5024 B |        +54% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **16**                 | **197.3 ms** |  **0.95 ms** |  **1.05 ms** | **197.6 ms** | **baseline** |        **** |      **1.0** |    **3408 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 16                 | 482.5 ms | 35.91 ms | 41.36 ms | 449.9 ms |    +145% |    8.4% |     12.4 |    7216 B |       +112% |
| ConcurrentDictionary_Stampede | CPUBound  | 16                 | 493.3 ms | 36.57 ms | 42.11 ms | 492.6 ms |    +150% |    8.3% |     12.5 |    5320 B |        +56% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **17**                 | **197.4 ms** |  **1.01 ms** |  **1.04 ms** | **197.7 ms** | **baseline** |        **** |      **1.0** |    **3568 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 17                 | 484.6 ms | 36.46 ms | 41.98 ms | 476.9 ms |    +146% |    8.5% |     12.5 |    7528 B |       +111% |
| ConcurrentDictionary_Stampede | CPUBound  | 17                 | 496.4 ms | 34.88 ms | 40.17 ms | 516.9 ms |    +152% |    7.9% |     12.5 |    5656 B |        +59% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **18**                 | **198.6 ms** |  **0.45 ms** |  **0.49 ms** | **198.5 ms** | **baseline** |        **** |      **1.0** |    **3720 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 18                 | 493.9 ms | 35.10 ms | 40.42 ms | 498.6 ms |    +149% |    8.0% |     12.5 |    7680 B |       +106% |
| ConcurrentDictionary_Stampede | CPUBound  | 18                 | 494.4 ms | 33.75 ms | 38.86 ms | 512.9 ms |    +149% |    7.7% |     12.5 |    5952 B |        +60% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **19**                 | **198.4 ms** |  **0.32 ms** |  **0.37 ms** | **198.4 ms** | **baseline** |        **** |      **1.0** |    **3880 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 19                 | 479.1 ms | 32.97 ms | 37.97 ms | 457.7 ms |    +141% |    7.7% |     12.5 |    7992 B |       +106% |
| ConcurrentDictionary_Stampede | CPUBound  | 19                 | 497.6 ms | 36.38 ms | 41.90 ms | 521.5 ms |    +151% |    8.2% |     12.5 |    6256 B |        +61% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **20**                 | **198.0 ms** |  **0.13 ms** |  **0.14 ms** | **198.1 ms** | **baseline** |        **** |      **1.0** |    **4032 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 20                 | 491.5 ms | 36.00 ms | 41.45 ms | 511.9 ms |    +148% |    8.2% |     12.6 |    8464 B |       +110% |
| ConcurrentDictionary_Stampede | CPUBound  | 20                 | 480.1 ms | 33.79 ms | 38.91 ms | 458.3 ms |    +142% |    7.9% |     12.5 |    6520 B |        +62% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **21**                 | **198.2 ms** |  **0.15 ms** |  **0.16 ms** | **198.2 ms** | **baseline** |        **** |      **1.0** |    **4192 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 21                 | 486.8 ms | 37.33 ms | 42.99 ms | 483.9 ms |    +146% |    8.6% |     12.5 |    8648 B |       +106% |
| ConcurrentDictionary_Stampede | CPUBound  | 21                 | 480.6 ms | 33.01 ms | 38.01 ms | 458.1 ms |    +142% |    7.7% |     12.5 |    6824 B |        +63% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **22**                 | **198.5 ms** |  **0.36 ms** |  **0.40 ms** | **198.4 ms** | **baseline** |        **** |      **1.0** |    **4344 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 22                 | 487.4 ms | 41.11 ms | 47.34 ms | 455.6 ms |    +146% |    9.5% |     12.5 |    8928 B |       +106% |
| ConcurrentDictionary_Stampede | CPUBound  | 22                 | 480.7 ms | 35.65 ms | 41.05 ms | 458.0 ms |    +142% |    8.3% |     12.5 |    7120 B |        +64% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **23**                 | **198.0 ms** |  **0.16 ms** |  **0.18 ms** | **198.0 ms** | **baseline** |        **** |      **1.0** |    **4504 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 23                 | 489.0 ms | 38.68 ms | 44.54 ms | 483.2 ms |    +147% |    8.9% |     12.5 |    9240 B |       +105% |
| ConcurrentDictionary_Stampede | CPUBound  | 23                 | 489.9 ms | 38.69 ms | 44.55 ms | 486.4 ms |    +147% |    8.9% |     12.5 |    7456 B |        +66% |
|                               |           |                    |          |          |          |          |          |         |          |           |             |
| **HybridCache_Stampede**          | **CPUBound**  | **24**                 | **198.4 ms** |  **0.39 ms** |  **0.43 ms** | **198.4 ms** | **baseline** |        **** |      **1.0** |    **4656 B** |            **** |
| MemoryCache_Stampede          | CPUBound  | 24                 | 483.8 ms | 34.61 ms | 39.86 ms | 478.5 ms |    +144% |    8.0% |     12.5 |    9584 B |       +106% |
| ConcurrentDictionary_Stampede | CPUBound  | 24                 | 475.6 ms | 33.09 ms | 38.11 ms | 452.3 ms |    +140% |    7.8% |     12.5 |    7720 B |        +66% |

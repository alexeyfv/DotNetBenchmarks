```

BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.414
  [Host]     : .NET 8.0.20 (8.0.2025.41914), X64 RyuJIT AVX2
  Job-AJSQNW : .NET 8.0.20 (8.0.2025.41914), X64 RyuJIT AVX2

IterationCount=50  

```
| Method                | IndexCreation    | BatchSize | Mean      | Error     | StdDev    | StdErr   | Median    | Min       | Q1        | Q3        | Max       | Op/s   | Gen0     | Allocated |
|---------------------- |----------------- |---------- |----------:|----------:|----------:|---------:|----------:|----------:|----------:|----------:|----------:|-------:|---------:|----------:|
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **100000**    |  **23.10 ms** |  **0.148 ms** |  **0.298 ms** | **0.042 ms** |  **23.10 ms** |  **22.46 ms** |  **22.91 ms** |  **23.34 ms** |  **23.61 ms** | **43.290** | **125.0000** | **282.45 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 100000    |  23.50 ms |  0.249 ms |  0.502 ms | 0.071 ms |  23.62 ms |  22.57 ms |  23.08 ms |  23.93 ms |  24.33 ms | 42.556 | 125.0000 | 282.32 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **136000**    |  **31.04 ms** |  **0.493 ms** |  **0.995 ms** | **0.141 ms** |  **30.56 ms** |  **29.76 ms** |  **30.23 ms** |  **32.01 ms** |  **32.74 ms** | **32.212** | **125.0000** | **282.36 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 136000    |  31.92 ms |  0.095 ms |  0.188 ms | 0.027 ms |  31.91 ms |  31.54 ms |  31.80 ms |  32.03 ms |  32.37 ms | 31.331 | 125.0000 | 282.32 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **172000**    |  **37.90 ms** |  **0.162 ms** |  **0.324 ms** | **0.046 ms** |  **37.97 ms** |  **36.91 ms** |  **37.77 ms** |  **38.16 ms** |  **38.38 ms** | **26.385** |  **71.4286** | **282.38 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 172000    |  39.49 ms |  0.116 ms |  0.235 ms | 0.033 ms |  39.49 ms |  38.93 ms |  39.37 ms |  39.62 ms |  39.98 ms | 25.321 |  76.9231 | 282.38 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **208000**    |  **46.72 ms** |  **1.699 ms** |  **3.432 ms** | **0.485 ms** |  **47.87 ms** |  **33.90 ms** |  **46.03 ms** |  **48.82 ms** |  **50.58 ms** | **21.405** |  **90.9091** | **282.54 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 208000    |  45.43 ms |  0.229 ms |  0.462 ms | 0.065 ms |  45.59 ms |  44.29 ms |  45.03 ms |  45.76 ms |  46.58 ms | 22.012 |  90.9091 | 283.03 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **244000**    |  **42.96 ms** |  **3.909 ms** |  **7.896 ms** | **1.117 ms** |  **38.26 ms** |  **34.31 ms** |  **36.82 ms** |  **52.10 ms** |  **58.22 ms** | **23.276** | **100.0000** | **282.54 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 244000    |  54.31 ms |  0.876 ms |  1.770 ms | 0.250 ms |  53.82 ms |  51.77 ms |  52.88 ms |  56.26 ms |  58.19 ms | 18.412 | 111.1111 | 282.43 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **280000**    |  **42.22 ms** |  **1.771 ms** |  **3.238 ms** | **0.500 ms** |  **42.14 ms** |  **36.34 ms** |  **40.06 ms** |  **44.63 ms** |  **49.57 ms** | **23.685** | **125.0000** | **282.59 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 280000    |  60.20 ms |  0.484 ms |  0.943 ms | 0.138 ms |  59.81 ms |  58.99 ms |  59.57 ms |  60.68 ms |  63.01 ms | 16.612 | 111.1111 | 282.43 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **316000**    |  **47.06 ms** |  **1.306 ms** |  **2.638 ms** | **0.373 ms** |  **46.81 ms** |  **40.35 ms** |  **45.56 ms** |  **49.07 ms** |  **52.12 ms** | **21.251** | **125.0000** | **282.89 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 316000    |  65.92 ms |  2.878 ms |  5.681 ms | 0.820 ms |  67.01 ms |  46.00 ms |  66.72 ms |  68.06 ms |  70.53 ms | 15.170 | 125.0000 | 282.61 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **352000**    |  **74.48 ms** |  **0.150 ms** |  **0.300 ms** | **0.043 ms** |  **74.52 ms** |  **74.01 ms** |  **74.20 ms** |  **74.69 ms** |  **75.26 ms** | **13.426** |        **-** | **283.22 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 352000    |  55.91 ms |  7.999 ms | 16.159 ms | 2.285 ms |  45.49 ms |  34.43 ms |  43.35 ms |  74.22 ms |  75.25 ms | 17.886 |        - | 282.77 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **388000**    |  **81.83 ms** |  **0.189 ms** |  **0.377 ms** | **0.054 ms** |  **81.79 ms** |  **81.08 ms** |  **81.63 ms** |  **82.13 ms** |  **82.59 ms** | **12.221** |        **-** | **282.47 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 388000    |  45.15 ms |  1.681 ms |  3.395 ms | 0.480 ms |  45.07 ms |  38.61 ms |  42.42 ms |  48.42 ms |  51.50 ms | 22.149 |        - | 282.66 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **424000**    |  **88.99 ms** |  **0.218 ms** |  **0.441 ms** | **0.062 ms** |  **88.99 ms** |  **88.18 ms** |  **88.68 ms** |  **89.27 ms** |  **90.05 ms** | **11.237** |        **-** |  **282.5 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 424000    |  47.17 ms |  1.048 ms |  2.117 ms | 0.299 ms |  46.90 ms |  42.74 ms |  45.81 ms |  48.38 ms |  52.22 ms | 21.201 |  90.9091 | 282.59 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **460000**    |  **75.03 ms** | **12.239 ms** | **24.724 ms** | **3.496 ms** |  **95.96 ms** |  **44.00 ms** |  **47.17 ms** |  **96.61 ms** |  **98.56 ms** | **13.328** |        **-** | **282.73 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 460000    |  96.28 ms |  0.168 ms |  0.332 ms | 0.048 ms |  96.32 ms |  95.53 ms |  96.05 ms |  96.47 ms |  96.95 ms | 10.386 |        - |  282.5 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **496000**    |  **50.56 ms** |  **1.566 ms** |  **3.127 ms** | **0.447 ms** |  **50.37 ms** |  **45.46 ms** |  **48.48 ms** |  **52.26 ms** |  **58.00 ms** | **19.780** |        **-** | **282.85 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 496000    | 103.74 ms |  0.171 ms |  0.329 ms | 0.048 ms | 103.68 ms | 103.11 ms | 103.55 ms | 103.98 ms | 104.61 ms |  9.640 |        - | 282.55 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **532000**    |  **51.78 ms** |  **1.427 ms** |  **2.851 ms** | **0.407 ms** |  **51.51 ms** |  **46.97 ms** |  **49.85 ms** |  **53.84 ms** |  **58.41 ms** | **19.312** |        **-** | **282.81 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 532000    | 111.43 ms |  0.260 ms |  0.507 ms | 0.074 ms | 111.31 ms | 110.31 ms | 111.10 ms | 111.75 ms | 112.76 ms |  8.974 |        - | 282.62 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **568000**    | **118.35 ms** |  **0.220 ms** |  **0.418 ms** | **0.062 ms** | **118.36 ms** | **117.53 ms** | **118.16 ms** | **118.57 ms** | **119.23 ms** |  **8.449** |        **-** | **282.55 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 568000    |  57.69 ms |  1.931 ms |  3.532 ms | 0.545 ms |  57.42 ms |  52.24 ms |  55.05 ms |  60.09 ms |  65.81 ms | 17.333 |        - | 282.73 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **604000**    | **126.18 ms** |  **0.436 ms** |  **0.850 ms** | **0.124 ms** | **125.87 ms** | **124.82 ms** | **125.63 ms** | **126.66 ms** | **128.60 ms** |  **7.925** |        **-** | **282.61 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 604000    |  57.86 ms |  1.555 ms |  3.141 ms | 0.444 ms |  57.28 ms |  52.40 ms |  55.10 ms |  60.11 ms |  64.64 ms | 17.282 |        - |  282.8 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **640000**    | **133.80 ms** |  **0.733 ms** |  **1.464 ms** | **0.209 ms** | **133.26 ms** | **132.18 ms** | **132.71 ms** | **134.71 ms** | **137.69 ms** |  **7.474** |        **-** | **282.61 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 640000    | 134.10 ms |  0.809 ms |  1.635 ms | 0.231 ms | 133.43 ms | 132.25 ms | 132.84 ms | 135.58 ms | 137.99 ms |  7.457 |        - | 282.61 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **676000**    |  **93.96 ms** | **18.868 ms** | **38.115 ms** | **5.390 ms** |  **66.94 ms** |  **59.74 ms** |  **63.59 ms** | **142.15 ms** | **146.92 ms** | **10.643** |        **-** |  **282.8 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 676000    | 141.49 ms |  0.785 ms |  1.550 ms | 0.224 ms | 140.86 ms | 139.68 ms | 140.42 ms | 142.34 ms | 145.80 ms |  7.068 |        - | 282.61 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **712000**    |  **68.84 ms** |  **1.277 ms** |  **2.580 ms** | **0.365 ms** |  **69.12 ms** |  **63.42 ms** |  **66.71 ms** |  **70.51 ms** |  **74.56 ms** | **14.527** |        **-** | **282.99 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 712000    | 135.21 ms | 14.724 ms | 29.743 ms | 4.206 ms | 148.17 ms |  67.00 ms | 147.24 ms | 149.52 ms | 152.23 ms |  7.396 |        - | 283.13 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **748000**    | **160.23 ms** |  **1.396 ms** |  **2.820 ms** | **0.399 ms** | **159.51 ms** | **155.72 ms** | **157.73 ms** | **162.96 ms** | **165.23 ms** |  **6.241** |        **-** | **282.72 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 748000    | 103.14 ms | 19.824 ms | 40.046 ms | 5.663 ms |  77.98 ms |  73.46 ms |  75.38 ms | 160.28 ms | 166.60 ms |  9.695 |        - | 282.91 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **784000**    | **174.80 ms** |  **0.490 ms** |  **0.991 ms** | **0.140 ms** | **174.77 ms** | **173.06 ms** | **174.00 ms** | **175.53 ms** | **177.20 ms** |  **5.721** |        **-** | **282.72 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 784000    |  82.31 ms |  1.278 ms |  2.523 ms | 0.364 ms |  82.76 ms |  75.94 ms |  81.20 ms |  83.88 ms |  87.35 ms | 12.150 |        - | 282.91 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **820000**    | **185.68 ms** |  **1.893 ms** |  **3.780 ms** | **0.540 ms** | **186.54 ms** | **177.00 ms** | **183.35 ms** | **188.54 ms** | **191.78 ms** |  **5.386** |        **-** |  **283.1 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 820000    | 190.80 ms |  3.047 ms |  6.154 ms | 0.870 ms | 192.07 ms | 180.71 ms | 183.88 ms | 195.93 ms | 198.72 ms |  5.241 |        - | 283.04 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **856000**    |  **88.30 ms** |  **1.778 ms** |  **3.339 ms** | **0.503 ms** |  **87.99 ms** |  **81.49 ms** |  **85.98 ms** |  **90.60 ms** |  **94.16 ms** | **11.325** |        **-** | **282.91 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 856000    | 183.29 ms |  2.359 ms |  4.766 ms | 0.674 ms | 181.44 ms | 174.69 ms | 179.92 ms | 187.05 ms | 197.26 ms |  5.456 |        - | 282.85 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **892000**    | **197.28 ms** |  **1.673 ms** |  **3.380 ms** | **0.478 ms** | **197.83 ms** | **190.17 ms** | **195.00 ms** | **199.61 ms** | **205.92 ms** |  **5.069** |        **-** | **282.72 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 892000    |  85.36 ms |  2.769 ms |  5.593 ms | 0.791 ms |  84.60 ms |  73.77 ms |  80.73 ms |  90.73 ms |  95.75 ms | 11.715 |        - | 283.04 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **928000**    | **181.93 ms** | **18.855 ms** | **38.088 ms** | **5.386 ms** | **196.81 ms** |  **82.23 ms** | **195.30 ms** | **198.70 ms** | **200.35 ms** |  **5.497** |        **-** | **282.97 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 928000    | 205.55 ms |  3.504 ms |  6.833 ms | 0.997 ms | 203.84 ms | 196.15 ms | 200.31 ms | 209.16 ms | 222.86 ms |  4.865 |        - | 284.35 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **964000**    |  **89.40 ms** |  **2.192 ms** |  **4.118 ms** | **0.621 ms** |  **89.42 ms** |  **80.75 ms** |  **86.48 ms** |  **92.48 ms** |  **99.03 ms** | **11.185** |        **-** | **283.22 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 964000    | 187.53 ms | 24.880 ms | 47.934 ms | 7.068 ms | 207.18 ms |  81.91 ms | 204.22 ms | 210.43 ms | 223.18 ms |  5.332 |        - | 283.22 KB |
| **Select_HashAggregate**  | **Res_BillDate_Cst** | **1000000**   | **213.39 ms** |  **1.331 ms** |  **2.659 ms** | **0.380 ms** | **213.24 ms** | **209.22 ms** | **211.35 ms** | **215.40 ms** | **218.83 ms** |  **4.686** |        **-** | **282.72 KB** |
| Select_GroupAggregate | Res_BillDate_Cst | 1000000   |  89.32 ms |  1.396 ms |  2.820 ms | 0.399 ms |  89.39 ms |  83.81 ms |  87.37 ms |  91.32 ms |  95.75 ms | 11.195 |        - | 282.91 KB |

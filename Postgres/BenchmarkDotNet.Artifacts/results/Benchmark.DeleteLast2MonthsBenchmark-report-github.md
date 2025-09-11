```

BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.413
  [Host]     : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2
  Job-BEIATO : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2

InvocationCount=1  IterationCount=25  UnrollFactor=1  

```
| Method                   | ResourceCount | Mean       | Error     | StdDev     | Median     | Ratio    | RatioSD | Allocated | Alloc Ratio |
|------------------------- |-------------- |-----------:|----------:|-----------:|-----------:|---------:|--------:|----------:|------------:|
| **DeleteLast2Months**        | **10**            |   **1.108 ms** | **0.2332 ms** |  **0.3032 ms** |   **1.041 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 10            |   1.893 ms | 0.2062 ms |  0.2681 ms |   1.821 ms |     +83% |   29.2% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **19**            |   **1.077 ms** | **0.1169 ms** |  **0.1436 ms** |   **1.103 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 19            |   1.955 ms | 0.2111 ms |  0.2592 ms |   1.971 ms |     +85% |   19.2% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **28**            |   **1.095 ms** | **0.1197 ms** |  **0.1513 ms** |   **1.043 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 28            |   2.444 ms | 0.5204 ms |  0.6947 ms |   2.056 ms |    +127% |   30.8% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **37**            |   **1.215 ms** | **0.2060 ms** |  **0.2678 ms** |   **1.167 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 37            |   2.036 ms | 0.2381 ms |  0.2924 ms |   1.952 ms |     +75% |   23.8% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **46**            |   **1.385 ms** | **0.2502 ms** |  **0.3254 ms** |   **1.459 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 46            |   2.342 ms | 0.4175 ms |  0.5573 ms |   2.162 ms |     +79% |   33.9% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **55**            |   **1.392 ms** | **0.2642 ms** |  **0.3436 ms** |   **1.248 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 55            |   1.987 ms | 0.1654 ms |  0.2150 ms |   2.012 ms |     +50% |   23.4% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **64**            |   **1.431 ms** | **0.2159 ms** |  **0.2807 ms** |   **1.437 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 64            |   2.218 ms | 0.3501 ms |  0.4552 ms |   2.104 ms |     +61% |   28.5% |   3.76 KB |        +34% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **73**            |   **1.233 ms** | **0.1950 ms** |  **0.2603 ms** |   **1.111 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 73            |   2.355 ms | 0.3941 ms |  0.5261 ms |   2.180 ms |     +98% |   28.6% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **82**            |   **1.312 ms** | **0.1645 ms** |  **0.2139 ms** |   **1.324 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 82            |   2.487 ms | 0.3766 ms |  0.5028 ms |   2.371 ms |     +94% |   25.5% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **91**            |   **1.334 ms** | **0.2359 ms** |  **0.2897 ms** |   **1.281 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 91            |   2.166 ms | 0.3108 ms |  0.3931 ms |   2.086 ms |     +69% |   26.7% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **100**           |   **1.277 ms** | **0.1942 ms** |  **0.2384 ms** |   **1.250 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 100           |   2.249 ms | 0.2478 ms |  0.3222 ms |   2.207 ms |     +81% |   21.9% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **136**           |   **1.916 ms** | **0.2608 ms** |  **0.3482 ms** |   **1.939 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 136           |   2.201 ms | 0.4106 ms |  0.5481 ms |   1.938 ms |     +19% |   32.0% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **172**           |   **1.823 ms** | **0.3714 ms** |  **0.4959 ms** |   **1.724 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 172           |   2.476 ms | 0.4113 ms |  0.5490 ms |   2.343 ms |     +46% |   35.5% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **208**           |   **1.628 ms** | **0.3190 ms** |  **0.4148 ms** |   **1.453 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 208           |   2.631 ms | 0.3604 ms |  0.4686 ms |   2.608 ms |     +70% |   27.8% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **244**           |   **1.528 ms** | **0.1789 ms** |  **0.2327 ms** |   **1.435 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 244           |   2.647 ms | 0.3314 ms |  0.4425 ms |   2.677 ms |     +77% |   21.5% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **280**           |   **2.076 ms** | **0.3347 ms** |  **0.4468 ms** |   **2.166 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 280           |   2.523 ms | 0.3202 ms |  0.4275 ms |   2.407 ms |     +27% |   28.2% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **316**           |   **2.550 ms** | **0.2657 ms** |  **0.3548 ms** |   **2.542 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 316           |   2.882 ms | 0.2762 ms |  0.3687 ms |   2.848 ms |     +15% |   19.5% |   3.01 KB |         +8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **352**           |   **2.693 ms** | **0.6320 ms** |  **0.8437 ms** |   **2.935 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 352           |   2.960 ms | 0.3025 ms |  0.4038 ms |   2.949 ms |     +23% |   39.1% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **388**           |   **2.915 ms** | **0.2988 ms** |  **0.3988 ms** |   **2.975 ms** | **baseline** |        **** |   **2.52 KB** |            **** |
| DropLast2MonthPartitions | 388           |   2.493 ms | 0.2161 ms |  0.2654 ms |   2.522 ms |     -13% |   18.7% |    3.2 KB |        +27% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **424**           |   **2.164 ms** | **0.2788 ms** |  **0.3722 ms** |   **2.205 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 424           |   2.532 ms | 0.2182 ms |  0.2837 ms |   2.580 ms |     +20% |   19.5% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **460**           |   **2.746 ms** | **0.4389 ms** |  **0.5707 ms** |   **2.964 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 460           |   2.589 ms | 0.2802 ms |  0.3741 ms |   2.435 ms |      -1% |   27.9% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **496**           |   **2.515 ms** | **0.4300 ms** |  **0.5740 ms** |   **2.474 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 496           |   3.040 ms | 0.2581 ms |  0.3446 ms |   3.114 ms |     +27% |   24.5% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **532**           |   **2.012 ms** | **0.2434 ms** |  **0.3165 ms** |   **1.894 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 532           |   2.408 ms | 0.2845 ms |  0.3797 ms |   2.351 ms |     +22% |   21.0% |   3.34 KB |        +19% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **568**           |   **2.512 ms** | **0.3592 ms** |  **0.4796 ms** |   **2.483 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 568           |   2.715 ms | 0.4055 ms |  0.5414 ms |   2.594 ms |     +12% |   26.9% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **604**           |   **2.766 ms** | **0.5381 ms** |  **0.6806 ms** |   **2.516 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 604           |   2.480 ms | 0.3286 ms |  0.4386 ms |   2.453 ms |      -6% |   26.1% |   3.15 KB |        +13% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **640**           |   **2.703 ms** | **0.5771 ms** |  **0.7504 ms** |   **2.304 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 640           |   2.432 ms | 0.2755 ms |  0.3679 ms |   2.412 ms |      -4% |   27.9% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **676**           |   **3.426 ms** | **0.6463 ms** |  **0.8628 ms** |   **3.612 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 676           |   2.469 ms | 0.2030 ms |  0.2709 ms |   2.509 ms |     -23% |   29.7% |   2.68 KB |         -4% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **712**           |   **2.650 ms** | **0.2615 ms** |  **0.3491 ms** |   **2.614 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 712           |   2.525 ms | 0.3289 ms |  0.4160 ms |   2.418 ms |      -3% |   20.5% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **748**           |   **2.656 ms** | **0.1582 ms** |  **0.2057 ms** |   **2.638 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 748           |   2.812 ms | 0.3123 ms |  0.4169 ms |   2.730 ms |      +7% |   16.6% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **784**           |   **2.732 ms** | **0.2673 ms** |  **0.3475 ms** |   **2.666 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 784           |   2.535 ms | 0.2301 ms |  0.3072 ms |   2.525 ms |      -6% |   16.9% |   3.15 KB |        +13% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **820**           |   **4.555 ms** | **0.5965 ms** |  **0.7964 ms** |   **4.826 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 820           |   2.830 ms | 0.3229 ms |  0.4311 ms |   2.864 ms |     -35% |   26.9% |    3.2 KB |        +14% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **856**           |   **3.535 ms** | **0.7257 ms** |  **0.9687 ms** |   **2.971 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 856           |   2.828 ms | 0.2749 ms |  0.3670 ms |   2.804 ms |     -15% |   26.4% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **892**           |   **2.953 ms** | **0.3398 ms** |  **0.4536 ms** |   **2.877 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 892           |   2.399 ms | 0.1867 ms |  0.2293 ms |   2.372 ms |     -17% |   17.9% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **928**           |   **3.624 ms** | **0.5437 ms** |  **0.7258 ms** |   **3.614 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 928           |   2.520 ms | 0.2511 ms |  0.3352 ms |   2.461 ms |     -28% |   23.7% |   3.01 KB |         +8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **964**           |   **3.899 ms** | **0.5797 ms** |  **0.7332 ms** |   **3.830 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 964           |   2.404 ms | 0.2340 ms |  0.3123 ms |   2.309 ms |     -36% |   21.4% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **1000**          |   **3.203 ms** | **0.3923 ms** |  **0.5237 ms** |   **3.037 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 1000          |   3.082 ms | 0.2127 ms |  0.2839 ms |   3.111 ms |      -2% |   16.9% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **1360**          |   **3.881 ms** | **0.2204 ms** |  **0.2865 ms** |   **3.836 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 1360          |   2.799 ms | 0.2982 ms |  0.3981 ms |   2.836 ms |     -28% |   15.6% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **1720**          |   **4.604 ms** | **0.3625 ms** |  **0.4175 ms** |   **4.599 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 1720          |   2.856 ms | 0.1537 ms |  0.2051 ms |   2.878 ms |     -37% |   11.2% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **2080**          |   **4.994 ms** | **0.3639 ms** |  **0.4191 ms** |   **4.945 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 2080          |   2.934 ms | 0.1810 ms |  0.2416 ms |   3.005 ms |     -41% |   11.6% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **2440**          |   **6.041 ms** | **0.2745 ms** |  **0.3372 ms** |   **6.082 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 2440          |   2.674 ms | 0.2888 ms |  0.3856 ms |   2.597 ms |     -56% |   15.3% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **2800**          |   **6.749 ms** | **0.4934 ms** |  **0.6239 ms** |   **6.721 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 2800          |   2.865 ms | 0.2820 ms |  0.3764 ms |   2.902 ms |     -57% |   15.5% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **3160**          |   **7.502 ms** | **0.3245 ms** |  **0.3985 ms** |   **7.520 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 3160          |   2.843 ms | 0.2579 ms |  0.3443 ms |   2.782 ms |     -62% |   13.1% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **3520**          |   **7.930 ms** | **0.3691 ms** |  **0.4668 ms** |   **8.052 ms** | **baseline** |        **** |    **2.8 KB** |            **** |
| DropLast2MonthPartitions | 3520          |   2.810 ms | 0.2326 ms |  0.3105 ms |   2.874 ms |     -64% |   12.4% |   2.59 KB |         -8% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **3880**          |   **9.373 ms** | **1.4770 ms** |  **1.8680 ms** |   **8.593 ms** | **baseline** |        **** |   **2.42 KB** |            **** |
| DropLast2MonthPartitions | 3880          |   2.962 ms | 0.1701 ms |  0.2271 ms |   3.008 ms |     -67% |   18.9% |   2.59 KB |         +7% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **4240**          |   **9.392 ms** | **0.4798 ms** |  **0.6068 ms** |   **9.204 ms** | **baseline** |        **** |   **2.42 KB** |            **** |
| DropLast2MonthPartitions | 4240          |   2.701 ms | 0.2617 ms |  0.3493 ms |   2.765 ms |     -71% |   14.3% |   2.59 KB |         +7% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **4600**          |  **10.619 ms** | **0.4735 ms** |  **0.5989 ms** |  **10.612 ms** | **baseline** |        **** |   **2.42 KB** |            **** |
| DropLast2MonthPartitions | 4600          |   2.807 ms | 0.1786 ms |  0.2384 ms |   2.784 ms |     -73% |   10.1% |   2.59 KB |         +7% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **4960**          |  **10.613 ms** | **0.3668 ms** |  **0.4505 ms** |  **10.717 ms** | **baseline** |        **** |   **2.42 KB** |            **** |
| DropLast2MonthPartitions | 4960          |   3.020 ms | 0.2167 ms |  0.2893 ms |   3.100 ms |     -71% |   10.3% |   2.59 KB |         +7% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **5320**          |  **10.987 ms** | **0.3793 ms** |  **0.4932 ms** |  **11.023 ms** | **baseline** |        **** |   **2.42 KB** |            **** |
| DropLast2MonthPartitions | 5320          |   2.737 ms | 0.2394 ms |  0.3196 ms |   2.676 ms |     -75% |   12.3% |   2.59 KB |         +7% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **5680**          |  **12.296 ms** | **0.5427 ms** |  **0.7245 ms** |  **12.359 ms** | **baseline** |        **** |   **2.42 KB** |            **** |
| DropLast2MonthPartitions | 5680          |   2.746 ms | 0.1734 ms |  0.2315 ms |   2.757 ms |     -78% |   10.2% |   2.59 KB |         +7% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **6040**          |  **12.156 ms** | **0.4126 ms** |  **0.5218 ms** |  **12.212 ms** | **baseline** |        **** |   **2.42 KB** |            **** |
| DropLast2MonthPartitions | 6040          |   2.897 ms | 0.2859 ms |  0.3817 ms |   2.902 ms |     -76% |   13.6% |   2.59 KB |         +7% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **6400**          |  **13.283 ms** | **0.4995 ms** |  **0.6318 ms** |  **13.240 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 6400          |   2.749 ms | 0.2649 ms |  0.3537 ms |   2.757 ms |     -79% |   13.4% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **6760**          |  **14.076 ms** | **0.5949 ms** |  **0.7306 ms** |  **13.983 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 6760          |   2.858 ms | 0.2153 ms |  0.2874 ms |   2.902 ms |     -80% |   11.1% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **7120**          |  **14.561 ms** | **0.6030 ms** |  **0.7841 ms** |  **14.741 ms** | **baseline** |        **** |   **2.23 KB** |            **** |
| DropLast2MonthPartitions | 7120          |   2.908 ms | 0.2104 ms |  0.2809 ms |   2.972 ms |     -80% |   10.9% |   2.59 KB |        +16% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **7480**          |  **15.206 ms** | **0.5166 ms** |  **0.6717 ms** |  **15.136 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 7480          |   2.718 ms | 0.1749 ms |  0.2335 ms |   2.728 ms |     -82% |    9.4% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **7840**          |  **16.505 ms** | **0.5652 ms** |  **0.7349 ms** |  **16.606 ms** | **baseline** |        **** |   **2.23 KB** |            **** |
| DropLast2MonthPartitions | 7840          |   2.866 ms | 0.2396 ms |  0.3116 ms |   2.793 ms |     -83% |   11.5% |   2.59 KB |        +16% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **8200**          |  **16.905 ms** | **0.8550 ms** |  **1.1117 ms** |  **17.344 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 8200          |   2.850 ms | 0.3373 ms |  0.4266 ms |   2.907 ms |     -83% |   16.1% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **8560**          |  **16.941 ms** | **0.4823 ms** |  **0.6099 ms** |  **17.088 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 8560          |   3.024 ms | 0.2337 ms |  0.3039 ms |   3.132 ms |     -82% |   10.5% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **8920**          |  **17.335 ms** | **0.5681 ms** |  **0.7185 ms** |  **17.492 ms** | **baseline** |        **** |   **2.75 KB** |            **** |
| DropLast2MonthPartitions | 8920          |   2.838 ms | 0.2084 ms |  0.2782 ms |   2.839 ms |     -84% |   10.5% |   2.59 KB |         -6% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **9280**          |  **18.679 ms** | **1.0516 ms** |  **1.3674 ms** |  **18.521 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 9280          |   2.935 ms | 0.2415 ms |  0.3054 ms |   2.941 ms |     -84% |   12.4% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **9640**          |  **19.077 ms** | **0.8922 ms** |  **1.0621 ms** |  **18.892 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 9640          |   2.940 ms | 0.2241 ms |  0.2992 ms |   2.959 ms |     -85% |   11.3% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **10000**         |  **19.653 ms** | **0.6500 ms** |  **0.7738 ms** |  **19.989 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 10000         |   2.777 ms | 0.1865 ms |  0.2425 ms |   2.825 ms |     -86% |    9.4% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **13600**         |  **25.181 ms** | **0.9259 ms** |  **1.1371 ms** |  **24.841 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 13600         |   2.741 ms | 0.2036 ms |  0.2718 ms |   2.751 ms |     -89% |   10.6% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **17200**         |  **31.729 ms** | **0.6870 ms** |  **0.8933 ms** |  **31.859 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 17200         |   2.677 ms | 0.2475 ms |  0.3218 ms |   2.597 ms |     -92% |   12.1% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **20800**         |  **37.341 ms** | **1.6281 ms** |  **2.0590 ms** |  **37.003 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 20800         |   2.982 ms | 0.2526 ms |  0.3195 ms |   3.051 ms |     -92% |   11.7% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **24400**         |  **45.206 ms** | **0.7670 ms** |  **0.9419 ms** |  **45.032 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 24400         |   3.102 ms | 0.1649 ms |  0.2201 ms |   3.079 ms |     -93% |    7.3% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **28000**         |  **50.594 ms** | **1.5399 ms** |  **1.9475 ms** |  **51.097 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 28000         |   2.512 ms | 0.1556 ms |  0.1967 ms |   2.466 ms |     -95% |    8.6% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **31600**         |  **59.417 ms** | **1.2191 ms** |  **1.5417 ms** |  **59.625 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 31600         |   3.038 ms | 0.2391 ms |  0.3192 ms |   3.112 ms |     -95% |   10.6% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **35200**         |  **66.865 ms** | **1.4833 ms** |  **1.8759 ms** |  **67.178 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 35200         |   2.777 ms | 0.2120 ms |  0.2831 ms |   2.803 ms |     -96% |   10.4% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **38800**         |  **74.165 ms** | **1.5765 ms** |  **2.0499 ms** |  **74.305 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 38800         |   2.902 ms | 0.2736 ms |  0.3653 ms |   3.003 ms |     -96% |   12.6% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **42400**         |  **80.401 ms** | **1.4081 ms** |  **1.8309 ms** |  **80.785 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 42400         |   3.098 ms | 0.2473 ms |  0.3302 ms |   3.020 ms |     -96% |   10.7% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **46000**         |  **92.387 ms** | **5.2277 ms** |  **6.7975 ms** |  **90.409 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 46000         |   3.091 ms | 0.2148 ms |  0.2868 ms |   3.148 ms |     -97% |   11.6% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **49600**         | **102.999 ms** | **9.4571 ms** | **12.6250 ms** |  **98.298 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 49600         |   3.040 ms | 0.1944 ms |  0.2458 ms |   3.116 ms |     -97% |   13.8% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **53200**         | **107.563 ms** | **7.1406 ms** |  **9.5326 ms** | **106.057 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 53200         |   2.985 ms | 0.2118 ms |  0.2754 ms |   3.047 ms |     -97% |   12.5% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **56800**         | **116.152 ms** | **4.7608 ms** |  **6.3555 ms** | **113.222 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 56800         |   3.009 ms | 0.3330 ms |  0.4445 ms |   3.003 ms |     -97% |   15.4% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **60400**         | **115.677 ms** | **6.4224 ms** |  **8.5737 ms** | **115.606 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 60400         |   3.249 ms | 0.2334 ms |  0.3035 ms |   3.235 ms |     -97% |   11.7% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **64000**         | **130.370 ms** | **6.0233 ms** |  **7.6175 ms** | **129.009 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 64000         |   3.294 ms | 0.2850 ms |  0.3805 ms |   3.348 ms |     -97% |   12.8% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **67600**         | **147.596 ms** | **3.9322 ms** |  **5.2494 ms** | **147.691 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 67600         |   3.100 ms | 0.1886 ms |  0.2518 ms |   3.145 ms |     -98% |    8.7% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **71200**         | **146.168 ms** | **6.3041 ms** |  **8.4157 ms** | **146.867 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 71200         |   3.373 ms | 0.2989 ms |  0.3990 ms |   3.324 ms |     -98% |   13.0% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **74800**         | **162.155 ms** | **4.5553 ms** |  **6.0812 ms** | **162.186 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 74800         |   3.413 ms | 0.2966 ms |  0.3960 ms |   3.408 ms |     -98% |   12.0% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **78400**         | **167.629 ms** | **4.5866 ms** |  **5.9639 ms** | **166.367 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 78400         |   3.484 ms | 0.3065 ms |  0.3986 ms |   3.465 ms |     -98% |   11.7% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **82000**         | **171.286 ms** | **7.5309 ms** |  **9.7923 ms** | **173.163 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 82000         |   3.165 ms | 0.1995 ms |  0.2663 ms |   3.211 ms |     -98% |   10.1% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **85600**         | **183.132 ms** | **4.2384 ms** |  **5.3602 ms** | **183.206 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 85600         |   3.483 ms | 0.3785 ms |  0.5053 ms |   3.462 ms |     -98% |   14.5% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **89200**         | **179.306 ms** | **8.4311 ms** | **10.9628 ms** | **180.756 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 89200         |   3.185 ms | 0.3194 ms |  0.4264 ms |   3.178 ms |     -98% |   14.5% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **92800**         | **191.931 ms** | **6.0655 ms** |  **7.6709 ms** | **192.642 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 92800         |   3.310 ms | 0.3071 ms |  0.4100 ms |   3.319 ms |     -98% |   12.8% |   2.72 KB |        +24% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **96400**         | **204.241 ms** | **8.1432 ms** | **10.8709 ms** | **207.835 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 96400         |   3.479 ms | 0.4614 ms |  0.5999 ms |   3.483 ms |     -98% |   17.8% |   2.59 KB |        +18% |
|                          |               |            |           |            |            |          |         |           |             |
| **DeleteLast2Months**        | **100000**        | **207.731 ms** | **9.0836 ms** | **12.1264 ms** | **203.617 ms** | **baseline** |        **** |   **2.19 KB** |            **** |
| DropLast2MonthPartitions | 100000        |   3.450 ms | 0.3479 ms |  0.4644 ms |   3.470 ms |     -98% |   14.4% |   2.59 KB |        +18% |

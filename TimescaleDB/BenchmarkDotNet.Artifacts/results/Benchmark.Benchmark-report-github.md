```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.22631.6649/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12800H 2.40GHz, 1 CPU, 20 logical and 14 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  Job-VNIRUV : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3

IterationCount=20  Categories=all_resources  

```
| Method                  | ResourcesCount | Mean       | Error     | StdDev    | Ratio    | RatioSD | Gen0      | Allocated   | Alloc Ratio |
|------------------------ |--------------- |-----------:|----------:|----------:|---------:|--------:|----------:|------------:|------------:|
| AllResources_Default    | 10             |   252.2 ms |   3.07 ms |   3.54 ms | baseline |         |         - |     4.12 KB |             |
| AllResources_Hypertable | 10             |   182.4 ms |  14.89 ms |  17.14 ms |     -28% |    9.3% |         - |     4.14 KB |         +1% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 20             |   258.9 ms |   3.20 ms |   3.56 ms | baseline |         |         - |     7.16 KB |             |
| AllResources_Hypertable | 20             |   191.2 ms |  16.87 ms |  19.43 ms |     -26% |   10.0% |         - |     7.19 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 30             |   261.1 ms |   3.81 ms |   4.07 ms | baseline |         |         - |    10.21 KB |             |
| AllResources_Hypertable | 30             |   197.6 ms |   7.11 ms |   8.19 ms |     -24% |    4.3% |         - |    10.55 KB |         +3% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 40             |   266.8 ms |  11.01 ms |  12.68 ms | baseline |         |         - |    13.26 KB |             |
| AllResources_Hypertable | 40             |   199.6 ms |   5.49 ms |   6.32 ms |     -25% |    5.5% |         - |    13.28 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 50             |   267.0 ms |   5.74 ms |   5.90 ms | baseline |         |         - |     16.3 KB |             |
| AllResources_Hypertable | 50             |   204.2 ms |   6.87 ms |   7.91 ms |     -24% |    4.3% |         - |    16.33 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 60             |   262.6 ms |   7.27 ms |   7.78 ms | baseline |         |         - |    19.35 KB |             |
| AllResources_Hypertable | 60             |   200.6 ms |   4.89 ms |   5.63 ms |     -24% |    3.9% |         - |    19.38 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 70             |   265.2 ms |   9.98 ms |  11.50 ms | baseline |         |         - |     22.4 KB |             |
| AllResources_Hypertable | 70             |   159.2 ms |   8.10 ms |   9.32 ms |     -40% |    7.1% |         - |    22.42 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 80             |   262.3 ms |   4.74 ms |   5.46 ms | baseline |         |         - |    25.56 KB |             |
| AllResources_Hypertable | 80             |   197.6 ms |   9.01 ms |  10.37 ms |     -25% |    5.5% |         - |    25.47 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 90             |   262.7 ms |   3.21 ms |   3.70 ms | baseline |         |         - |    28.73 KB |             |
| AllResources_Hypertable | 90             |   224.7 ms |  51.83 ms |  50.91 ms |     -14% |   22.0% |         - |    28.52 KB |         -1% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 100            |   258.8 ms |   3.70 ms |   3.96 ms | baseline |         |         - |    31.77 KB |             |
| AllResources_Hypertable | 100            |   194.5 ms |  20.68 ms |  23.81 ms |     -25% |   12.0% |         - |    31.56 KB |         -1% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 200            |   273.1 ms |   4.30 ms |   4.96 ms | baseline |         |         - |    62.01 KB |             |
| AllResources_Hypertable | 200            |   206.3 ms |  11.16 ms |  12.86 ms |     -24% |    6.3% |         - |    62.03 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 300            |   264.0 ms |   3.40 ms |   3.34 ms | baseline |         |         - |    92.48 KB |             |
| AllResources_Hypertable | 300            |   196.8 ms |  28.46 ms |  32.78 ms |     -25% |   16.3% |         - |     92.5 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 400            |   264.3 ms |   3.95 ms |   4.55 ms | baseline |         |         - |   123.18 KB |             |
| AllResources_Hypertable | 400            |   197.2 ms |   8.86 ms |  10.20 ms |     -25% |    5.3% |         - |   122.97 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 500            |   265.1 ms |   2.89 ms |   3.33 ms | baseline |         |         - |   153.53 KB |             |
| AllResources_Hypertable | 500            |   203.8 ms |   9.24 ms |  10.64 ms |     -23% |    5.2% |         - |   153.44 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 600            |   266.6 ms |   3.65 ms |   4.20 ms | baseline |         |         - |   183.88 KB |             |
| AllResources_Hypertable | 600            |   157.9 ms |   4.37 ms |   4.09 ms |     -41% |    2.9% |         - |   183.91 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 700            |   272.3 ms |   8.94 ms |   9.56 ms | baseline |         |         - |   214.35 KB |             |
| AllResources_Hypertable | 700            |   215.9 ms |   8.09 ms |   9.32 ms |     -21% |    5.4% |         - |   214.59 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 800            |   291.4 ms |   5.47 ms |   6.08 ms | baseline |         |         - |   244.82 KB |             |
| AllResources_Hypertable | 800            |   200.9 ms |  17.73 ms |  20.42 ms |     -31% |   10.1% |         - |   244.84 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 900            |   283.6 ms |   3.37 ms |   3.31 ms | baseline |         |         - |   275.29 KB |             |
| AllResources_Hypertable | 900            |   193.4 ms |  12.31 ms |  14.17 ms |     -32% |    7.2% |         - |   275.31 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 1000           |   299.9 ms |   4.64 ms |   4.97 ms | baseline |         |         - |   305.88 KB |             |
| AllResources_Hypertable | 1000           |   237.2 ms |  11.73 ms |  13.50 ms |     -21% |    5.8% |         - |   305.78 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 2000           |   351.8 ms |   3.65 ms |   4.20 ms | baseline |         |         - |   610.77 KB |             |
| AllResources_Hypertable | 2000           |   270.8 ms |  12.94 ms |  14.90 ms |     -23% |    5.5% |         - |    610.7 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 3000           |   693.7 ms | 252.93 ms | 291.27 ms | baseline |         |         - |   893.55 KB |             |
| AllResources_Hypertable | 3000           |   276.8 ms |  20.09 ms |  23.13 ms |     -52% |   40.6% |         - |   892.77 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 4000           |   399.8 ms |   6.69 ms |   7.44 ms | baseline |         |         - |   1173.7 KB |             |
| AllResources_Hypertable | 4000           |   364.5 ms |  10.64 ms |  10.45 ms |      -9% |    3.3% |         - |  1173.41 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 5000           |   433.5 ms |   9.13 ms |  10.51 ms | baseline |         |         - |   1454.2 KB |             |
| AllResources_Hypertable | 5000           |   400.1 ms |   9.00 ms |  10.36 ms |      -8% |    3.4% |         - |  1453.87 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 6000           |   460.3 ms |  11.31 ms |  13.03 ms | baseline |         |         - |  1734.74 KB |             |
| AllResources_Hypertable | 6000           |   416.4 ms |   8.00 ms |   9.21 ms |      -9% |    3.5% |         - |  1734.39 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 7000           |   477.3 ms |   7.34 ms |   8.45 ms | baseline |         |         - |  2015.24 KB |             |
| AllResources_Hypertable | 7000           |   462.6 ms |   7.49 ms |   8.63 ms |      -3% |    2.5% |         - |  2014.91 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 8000           |   468.8 ms |   7.91 ms |   9.11 ms | baseline |         |         - |  2295.65 KB |             |
| AllResources_Hypertable | 8000           |   492.9 ms |  12.36 ms |  14.24 ms |      +5% |    3.4% |         - |  2295.34 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 9000           |   483.1 ms |   7.97 ms |   9.18 ms | baseline |         |         - |  2576.17 KB |             |
| AllResources_Hypertable | 9000           |   490.5 ms |  13.13 ms |  15.12 ms |      +2% |    3.5% |         - |  2575.73 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 10000          |   459.9 ms |   4.63 ms |   5.33 ms | baseline |         |         - |  2856.58 KB |             |
| AllResources_Hypertable | 10000          |   543.1 ms |  12.85 ms |  14.28 ms |     +18% |    2.8% |         - |  2856.27 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 20000          |   546.9 ms |   7.73 ms |   8.59 ms | baseline |         |         - |   5668.3 KB |             |
| AllResources_Hypertable | 20000          |   897.5 ms |  19.31 ms |  21.46 ms |     +64% |    2.8% |         - |  5667.91 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 30000          |   635.8 ms |   8.64 ms |   9.60 ms | baseline |         |         - |  8479.68 KB |             |
| AllResources_Hypertable | 30000          | 1,309.3 ms |  27.92 ms |  32.15 ms |    +106% |    2.8% |         - |  8479.23 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 40000          |   714.6 ms |  14.53 ms |  16.73 ms | baseline |         |         - | 11290.63 KB |             |
| AllResources_Hypertable | 40000          | 1,613.8 ms |  20.55 ms |  23.67 ms |    +126% |    2.7% |         - | 11291.05 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 50000          |   716.8 ms |  11.90 ms |  12.22 ms | baseline |         | 1000.0000 | 14054.43 KB |             |
| AllResources_Hypertable | 50000          | 2,061.2 ms |  55.53 ms |  63.95 ms |    +188% |    3.4% | 1000.0000 | 14055.39 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 60000          |   850.2 ms |  10.38 ms |  11.53 ms | baseline |         | 1000.0000 | 16633.49 KB |             |
| AllResources_Hypertable | 60000          | 2,208.0 ms |  25.36 ms |  26.04 ms |    +160% |    1.7% | 1000.0000 | 16632.67 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 70000          |   841.0 ms |  11.70 ms |  11.49 ms | baseline |         | 1000.0000 | 19210.77 KB |             |
| AllResources_Hypertable | 70000          | 2,557.8 ms |  19.07 ms |  19.58 ms |    +204% |    1.5% | 1000.0000 |  19210.8 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 80000          |   956.4 ms |  23.59 ms |  27.17 ms | baseline |         | 1000.0000 |  21788.8 KB |             |
| AllResources_Hypertable | 80000          | 2,813.7 ms |  40.97 ms |  43.84 ms |    +194% |    3.1% | 1000.0000 | 21788.92 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 90000          |   939.6 ms |  20.52 ms |  19.19 ms | baseline |         | 1000.0000 |  23438.8 KB |             |
| AllResources_Hypertable | 90000          | 3,103.5 ms |  24.80 ms |  28.56 ms |    +230% |    2.1% | 1000.0000 | 23438.83 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 100000         |   961.6 ms |  42.26 ms |  41.50 ms | baseline |         | 1000.0000 |  23438.9 KB |             |
| AllResources_Hypertable | 100000         | 3,082.0 ms |  66.03 ms |  73.39 ms |    +221% |    4.4% | 1000.0000 | 23438.83 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 200000         |   954.9 ms |  19.73 ms |  21.11 ms | baseline |         | 1000.0000 |  23438.8 KB |             |
| AllResources_Hypertable | 200000         | 3,158.4 ms |  57.07 ms |  53.38 ms |    +231% |    2.7% | 1000.0000 | 23438.92 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 300000         |   899.1 ms |  10.56 ms |  11.30 ms | baseline |         | 1000.0000 |  23438.8 KB |             |
| AllResources_Hypertable | 300000         | 3,118.2 ms |  36.17 ms |  40.20 ms |    +247% |    1.8% | 1000.0000 | 23438.83 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 400000         |   960.6 ms |  23.38 ms |  25.99 ms | baseline |         | 1000.0000 |  23438.9 KB |             |
| AllResources_Hypertable | 400000         | 3,150.3 ms |  33.69 ms |  36.05 ms |    +228% |    2.8% | 1000.0000 | 23438.92 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 500000         |   976.3 ms |  15.64 ms |  18.01 ms | baseline |         | 1000.0000 |  23438.9 KB |             |
| AllResources_Hypertable | 500000         | 3,043.5 ms |  21.30 ms |  24.53 ms |    +212% |    2.0% | 1000.0000 | 23438.83 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 600000         |   971.8 ms |  24.12 ms |  26.81 ms | baseline |         | 1000.0000 |  23438.8 KB |             |
| AllResources_Hypertable | 600000         | 3,591.5 ms | 254.10 ms | 282.43 ms |    +270% |    8.1% | 1000.0000 | 23438.83 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 700000         |   910.7 ms |  20.56 ms |  22.86 ms | baseline |         | 1000.0000 |  23438.8 KB |             |
| AllResources_Hypertable | 700000         | 3,044.8 ms | 135.77 ms | 127.00 ms |    +235% |    4.7% | 1000.0000 | 23438.83 KB |         +0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 800000         |   916.2 ms |  15.80 ms |  18.19 ms | baseline |         | 1000.0000 |  23438.9 KB |             |
| AllResources_Hypertable | 800000         | 3,126.6 ms |  60.16 ms |  64.38 ms |    +241% |    2.8% | 1000.0000 | 23438.83 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 900000         |   931.4 ms |  13.23 ms |  15.23 ms | baseline |         | 1000.0000 |  23438.9 KB |             |
| AllResources_Hypertable | 900000         | 3,066.2 ms |  31.74 ms |  32.60 ms |    +229% |    1.9% | 1000.0000 | 23438.83 KB |         -0% |
|                         |                |            |           |           |          |         |           |             |             |
| AllResources_Default    | 1000000        |   935.0 ms |  12.70 ms |  13.05 ms | baseline |         | 1000.0000 |  23438.9 KB |             |
| AllResources_Hypertable | 1000000        | 3,127.1 ms |  32.41 ms |  36.02 ms |    +235% |    1.8% | 1000.0000 | 23438.92 KB |         +0% |

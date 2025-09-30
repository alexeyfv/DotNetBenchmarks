```

BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.414
  [Host]     : .NET 8.0.20 (8.0.2025.41914), X64 RyuJIT AVX2
  Job-PBVRJP : .NET 8.0.20 (8.0.2025.41914), X64 RyuJIT AVX2

IterationCount=50  

```
| Method                | IndexCreation    | BatchSize | Mean      | Error     | StdDev    | Median    | Gen0     | Allocated |
|---------------------- |----------------- |---------- |----------:|----------:|----------:|----------:|---------:|----------:|
| Select_HashAggregate  | None             | 100000    |  25.12 ms |  0.141 ms |  0.285 ms |  25.02 ms | 125.0000 | 282.32 KB |
| Select_GroupAggregate | None             | 100000    |  25.15 ms |  0.099 ms |  0.194 ms |  25.19 ms | 125.0000 | 282.34 KB |
| Select_HashAggregate  | None             | 136000    |  34.00 ms |  0.136 ms |  0.274 ms |  34.04 ms | 133.3333 | 282.37 KB |
| Select_GroupAggregate | None             | 136000    |  33.59 ms |  0.177 ms |  0.357 ms |  33.50 ms | 125.0000 | 282.36 KB |
| Select_HashAggregate  | None             | 172000    |  41.58 ms |  0.122 ms |  0.236 ms |  41.52 ms |  83.3333 |  282.8 KB |
| Select_GroupAggregate | None             | 172000    |  41.62 ms |  0.142 ms |  0.284 ms |  41.65 ms |  83.3333 | 282.53 KB |
| Select_HashAggregate  | None             | 208000    |  50.64 ms |  0.237 ms |  0.479 ms |  50.60 ms | 100.0000 | 282.41 KB |
| Select_GroupAggregate | None             | 208000    |  39.57 ms |  2.939 ms |  5.937 ms |  38.46 ms | 100.0000 | 282.96 KB |
| Select_HashAggregate  | None             | 244000    |  58.30 ms |  0.176 ms |  0.355 ms |  58.26 ms | 111.1111 | 282.43 KB |
| Select_GroupAggregate | None             | 244000    |  42.51 ms |  1.324 ms |  2.674 ms |  42.36 ms | 111.1111 |  282.6 KB |
| Select_HashAggregate  | None             | 280000    |  66.76 ms |  0.213 ms |  0.420 ms |  66.65 ms | 125.0000 | 282.45 KB |
| Select_GroupAggregate | None             | 280000    |  66.76 ms |  0.225 ms |  0.450 ms |  66.76 ms | 125.0000 | 283.08 KB |
| Select_HashAggregate  | None             | 316000    |  62.38 ms |  6.599 ms | 13.331 ms |  74.10 ms |        - | 282.66 KB |
| Select_GroupAggregate | None             | 316000    |  74.44 ms |  0.162 ms |  0.324 ms |  74.46 ms |        - | 283.41 KB |
| Select_HashAggregate  | None             | 352000    |  42.58 ms |  1.826 ms |  3.293 ms |  42.53 ms |        - | 283.09 KB |
| Select_GroupAggregate | None             | 352000    |  83.22 ms |  0.273 ms |  0.545 ms |  83.21 ms |        - |  282.5 KB |
| Select_HashAggregate  | None             | 388000    |  45.47 ms |  1.553 ms |  2.954 ms |  45.33 ms |        - | 283.36 KB |
| Select_GroupAggregate | None             | 388000    |  91.01 ms |  0.319 ms |  0.645 ms |  90.81 ms |        - | 282.35 KB |
| Select_HashAggregate  | None             | 424000    |  47.35 ms |  0.974 ms |  1.945 ms |  47.39 ms |        - | 282.82 KB |
| Select_GroupAggregate | None             | 424000    |  99.09 ms |  0.247 ms |  0.481 ms |  99.02 ms |        - | 283.22 KB |
| Select_HashAggregate  | None             | 460000    |  50.67 ms |  1.046 ms |  2.113 ms |  50.55 ms |        - | 282.85 KB |
| Select_GroupAggregate | None             | 460000    | 107.17 ms |  0.165 ms |  0.318 ms | 107.12 ms |        - | 282.55 KB |
| Select_HashAggregate  | None             | 496000    | 116.00 ms |  0.344 ms |  0.686 ms | 115.87 ms |        - | 282.55 KB |
| Select_GroupAggregate | None             | 496000    |  53.60 ms |  1.040 ms |  1.848 ms |  53.27 ms |        - | 282.88 KB |
| Select_HashAggregate  | None             | 532000    | 124.35 ms |  0.373 ms |  0.719 ms | 124.26 ms |        - | 282.71 KB |
| Select_GroupAggregate | None             | 532000    |  55.29 ms |  1.225 ms |  2.331 ms |  55.26 ms |        - | 283.04 KB |
| Select_HashAggregate  | None             | 568000    | 132.29 ms |  0.447 ms |  0.871 ms | 131.98 ms |        - | 282.85 KB |
| Select_GroupAggregate | None             | 568000    |  58.83 ms |  1.064 ms |  2.100 ms |  58.44 ms |        - | 283.13 KB |
| Select_HashAggregate  | None             | 604000    | 141.08 ms |  0.421 ms |  0.811 ms | 141.14 ms |        - | 282.61 KB |
| Select_GroupAggregate | None             | 604000    |  61.90 ms |  1.409 ms |  2.846 ms |  61.11 ms |        - | 282.89 KB |
| Select_HashAggregate  | None             | 640000    | 147.91 ms |  6.119 ms | 12.079 ms | 149.04 ms |        - |  282.8 KB |
| Select_GroupAggregate | None             | 640000    | 148.48 ms |  0.445 ms |  0.847 ms | 148.31 ms |        - | 282.61 KB |
| Select_HashAggregate  | None             | 676000    |  69.10 ms |  1.554 ms |  2.994 ms |  69.02 ms |        - | 283.08 KB |
| Select_GroupAggregate | None             | 676000    | 157.07 ms |  0.821 ms |  1.620 ms | 156.47 ms |        - |  282.8 KB |
| Select_HashAggregate  | None             | 712000    | 166.92 ms |  0.809 ms |  1.596 ms | 166.81 ms |        - | 282.72 KB |
| Select_GroupAggregate | None             | 712000    | 125.11 ms | 23.497 ms | 47.465 ms | 166.21 ms |        - | 283.41 KB |
| Select_HashAggregate  | None             | 748000    | 174.59 ms |  0.811 ms |  1.543 ms | 174.42 ms |        - |  283.1 KB |
| Select_GroupAggregate | None             | 748000    |  75.66 ms |  1.546 ms |  2.788 ms |  76.15 ms |        - | 282.91 KB |
| Select_HashAggregate  | None             | 784000    | 184.65 ms |  1.057 ms |  2.037 ms | 184.66 ms |        - | 282.72 KB |
| Select_GroupAggregate | None             | 784000    |  79.12 ms |  1.492 ms |  3.014 ms |  79.60 ms |        - | 282.91 KB |
| Select_HashAggregate  | None             | 820000    | 191.43 ms |  5.736 ms | 11.455 ms | 192.37 ms |        - | 283.35 KB |
| Select_GroupAggregate | None             | 820000    | 193.17 ms |  1.205 ms |  2.435 ms | 192.94 ms |        - | 282.72 KB |
| Select_HashAggregate  | None             | 856000    |  83.58 ms |  1.888 ms |  3.257 ms |  83.32 ms |        - | 282.97 KB |
| Select_GroupAggregate | None             | 856000    | 201.45 ms |  0.924 ms |  1.758 ms | 201.44 ms |        - | 283.16 KB |
| Select_HashAggregate  | None             | 892000    |  90.07 ms |  0.886 ms |  1.789 ms |  90.13 ms |        - | 282.82 KB |
| Select_GroupAggregate | None             | 892000    |  89.05 ms |  1.339 ms |  2.674 ms |  88.66 ms |        - | 282.69 KB |
| Select_HashAggregate  | None             | 928000    |  93.23 ms |  0.904 ms |  1.784 ms |  93.41 ms |        - | 282.97 KB |
| Select_GroupAggregate | None             | 928000    |  95.49 ms |  0.929 ms |  1.835 ms |  95.34 ms |        - | 283.22 KB |
| Select_HashAggregate  | None             | 964000    |  95.22 ms |  1.181 ms |  2.359 ms |  95.22 ms |        - | 282.97 KB |
| Select_GroupAggregate | None             | 964000    |  97.15 ms |  1.179 ms |  2.271 ms |  97.11 ms |        - | 282.73 KB |
| Select_HashAggregate  | None             | 1000000   | 102.17 ms |  1.305 ms |  2.636 ms | 101.87 ms |        - | 282.81 KB |
| Select_GroupAggregate | None             | 1000000   |  98.17 ms |  1.264 ms |  2.523 ms |  98.37 ms |        - | 283.11 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 100000    |  25.18 ms |  0.170 ms |  0.344 ms |  25.14 ms | 125.0000 | 283.15 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 100000    |  25.05 ms |  0.108 ms |  0.208 ms |  25.05 ms | 125.0000 | 282.95 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 136000    |  33.17 ms |  0.125 ms |  0.247 ms |  33.21 ms | 125.0000 |  282.6 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 136000    |  33.08 ms |  0.113 ms |  0.204 ms |  33.05 ms | 133.3333 | 282.37 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 172000    |  41.77 ms |  0.177 ms |  0.357 ms |  41.69 ms |  83.3333 | 282.39 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 172000    |  42.05 ms |  0.194 ms |  0.393 ms |  42.01 ms |  83.3333 | 282.39 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 208000    |  43.28 ms |  3.318 ms |  6.702 ms |  44.31 ms |  90.9091 | 282.59 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 208000    |  49.66 ms |  0.148 ms |  0.291 ms |  49.67 ms | 100.0000 | 282.41 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 244000    |  41.81 ms |  1.526 ms |  2.829 ms |  42.75 ms | 111.1111 | 282.74 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 244000    |  58.05 ms |  0.128 ms |  0.252 ms |  58.05 ms | 111.1111 | 282.43 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 280000    |  45.45 ms |  1.351 ms |  2.729 ms |  45.54 ms | 125.0000 | 282.63 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 280000    |  64.73 ms |  2.549 ms |  5.149 ms |  66.19 ms | 125.0000 | 282.61 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 316000    |  74.33 ms |  0.117 ms |  0.231 ms |  74.32 ms |        - | 282.71 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 316000    |  63.15 ms |  6.153 ms | 12.429 ms |  74.16 ms |        - | 282.79 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 352000    |  82.99 ms |  0.239 ms |  0.483 ms |  82.93 ms |        - |  282.5 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 352000    |  54.87 ms |  8.529 ms | 17.229 ms |  45.86 ms |        - | 283.25 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 388000    |  90.88 ms |  0.277 ms |  0.548 ms |  90.80 ms |        - | 282.91 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 388000    |  45.81 ms |  1.349 ms |  2.632 ms |  45.87 ms |        - | 283.28 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 424000    |  98.99 ms |  0.141 ms |  0.271 ms |  98.96 ms |        - |  282.5 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 424000    |  47.14 ms |  0.691 ms |  1.397 ms |  47.26 ms |  90.9091 | 282.66 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 460000    |  77.34 ms | 14.483 ms | 29.256 ms |  52.50 ms |        - | 282.73 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 460000    | 107.08 ms |  0.175 ms |  0.338 ms | 107.02 ms |        - | 282.55 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 496000    |  54.74 ms |  1.013 ms |  1.927 ms |  54.64 ms |        - | 283.33 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 496000    | 115.87 ms |  0.364 ms |  0.727 ms | 115.65 ms |        - | 282.55 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 532000    |  57.39 ms |  1.358 ms |  2.712 ms |  57.26 ms |        - | 283.08 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 532000    | 124.52 ms |  0.338 ms |  0.674 ms | 124.46 ms |        - | 282.61 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 568000    |  60.34 ms |  1.321 ms |  2.607 ms |  59.78 ms |        - |  282.8 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 568000    | 132.86 ms |  0.834 ms |  1.666 ms | 132.02 ms |        - | 282.75 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 604000    |  64.01 ms |  1.519 ms |  3.068 ms |  63.75 ms |        - | 282.89 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 604000    | 140.72 ms |  0.809 ms |  1.616 ms | 140.28 ms |        - |  282.8 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 640000    | 148.25 ms |  0.306 ms |  0.591 ms | 148.19 ms |        - | 282.61 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 640000    |  67.03 ms |  1.831 ms |  3.528 ms |  66.65 ms |        - | 283.04 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 676000    | 151.57 ms | 11.258 ms | 22.483 ms | 158.19 ms |        - | 282.89 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 676000    | 158.58 ms |  1.016 ms |  2.052 ms | 158.16 ms |        - | 282.72 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 712000    | 117.92 ms | 24.282 ms | 49.052 ms |  76.79 ms |        - |  283.1 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 712000    | 166.74 ms |  0.772 ms |  1.524 ms | 166.50 ms |        - | 282.72 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 748000    |  72.77 ms |  1.163 ms |  2.212 ms |  72.67 ms |        - | 283.47 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 748000    | 174.79 ms |  0.841 ms |  1.640 ms | 174.80 ms |        - | 282.72 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 784000    |  78.72 ms |  1.367 ms |  2.761 ms |  79.16 ms |        - | 283.54 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 784000    | 183.92 ms |  1.156 ms |  2.309 ms | 183.66 ms |        - |  283.1 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 820000    | 192.07 ms |  1.109 ms |  2.214 ms | 192.23 ms |        - | 282.72 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 820000    |  79.87 ms |  1.766 ms |  3.093 ms |  79.56 ms |        - | 283.41 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 856000    | 201.02 ms |  1.177 ms |  2.351 ms | 200.72 ms |        - | 282.72 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 856000    | 200.28 ms |  0.760 ms |  1.481 ms | 200.09 ms |        - | 282.72 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 892000    |  88.27 ms |  1.303 ms |  2.447 ms |  88.64 ms |        - |  283.6 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 892000    | 195.85 ms | 19.798 ms | 38.614 ms | 208.83 ms |        - | 282.91 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 928000    | 217.51 ms |  0.830 ms |  1.658 ms | 217.46 ms |        - | 283.41 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 928000    |  91.08 ms |  1.705 ms |  3.444 ms |  91.37 ms |        - | 282.91 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 964000    | 186.99 ms | 30.041 ms | 60.685 ms | 226.36 ms |        - | 282.97 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 964000    | 227.26 ms |  1.464 ms |  2.958 ms | 226.37 ms |        - | 282.72 KB |
| Select_HashAggregate  | Res_BillDate_Cst | 1000000   | 235.12 ms |  0.878 ms |  1.775 ms | 235.64 ms |        - | 283.41 KB |
| Select_GroupAggregate | Res_BillDate_Cst | 1000000   |  97.09 ms |  1.352 ms |  2.731 ms |  96.87 ms |        - | 283.04 KB |

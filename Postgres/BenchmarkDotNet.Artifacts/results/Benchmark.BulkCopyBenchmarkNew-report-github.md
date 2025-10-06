```

BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.414
  [Host]     : .NET 8.0.20 (8.0.2025.41914), X64 RyuJIT AVX2
  Job-OYUXIE : .NET 8.0.20 (8.0.2025.41914), X64 RyuJIT AVX2

IterationCount=25  

```
| Method   | CreateTable          | BatchSize | Mean        | Error     | StdDev    | Allocated |
|--------- |--------------------- |---------- |------------:|----------:|----------:|----------:|
| **BulkCopy** | **create table**         | **10000**     |    **31.86 ms** |  **0.519 ms** |  **0.674 ms** |   **7.84 KB** |
| **BulkCopy** | **create table**         | **13600**     |    **43.75 ms** |  **2.484 ms** |  **3.317 ms** |    **9.1 KB** |
| **BulkCopy** | **create table**         | **17200**     |    **56.00 ms** |  **0.928 ms** |  **1.139 ms** |  **10.29 KB** |
| **BulkCopy** | **create table**         | **20800**     |    **68.15 ms** |  **1.051 ms** |  **1.251 ms** |  **11.54 KB** |
| **BulkCopy** | **create table**         | **24400**     |    **78.17 ms** |  **1.727 ms** |  **2.245 ms** |  **12.78 KB** |
| **BulkCopy** | **create table**         | **28000**     |    **91.02 ms** |  **0.997 ms** |  **1.297 ms** |  **13.97 KB** |
| **BulkCopy** | **create table**         | **31600**     |   **102.12 ms** |  **2.422 ms** |  **3.063 ms** |  **15.22 KB** |
| **BulkCopy** | **create table**         | **35200**     |   **104.06 ms** |  **1.218 ms** |  **1.541 ms** |  **16.58 KB** |
| **BulkCopy** | **create table**         | **38800**     |   **128.16 ms** |  **8.053 ms** | **10.751 ms** |  **17.75 KB** |
| **BulkCopy** | **create table**         | **42400**     |   **130.28 ms** |  **2.909 ms** |  **3.573 ms** |  **18.84 KB** |
| **BulkCopy** | **create table**         | **46000**     |   **143.26 ms** |  **4.057 ms** |  **5.416 ms** |  **20.05 KB** |
| **BulkCopy** | **create table**         | **49600**     |   **155.47 ms** |  **3.988 ms** |  **5.044 ms** |  **21.31 KB** |
| **BulkCopy** | **create table**         | **53200**     |   **167.80 ms** |  **4.378 ms** |  **5.845 ms** |  **22.53 KB** |
| **BulkCopy** | **create table**         | **56800**     |   **174.45 ms** |  **2.074 ms** |  **2.469 ms** |   **23.7 KB** |
| **BulkCopy** | **create table**         | **60400**     |   **188.69 ms** |  **3.286 ms** |  **4.273 ms** |  **24.92 KB** |
| **BulkCopy** | **create table**         | **64000**     |   **198.91 ms** |  **4.378 ms** |  **5.693 ms** |  **26.09 KB** |
| **BulkCopy** | **create table**         | **67600**     |   **212.77 ms** |  **4.779 ms** |  **6.379 ms** |  **27.31 KB** |
| **BulkCopy** | **create table**         | **71200**     |   **223.31 ms** |  **4.854 ms** |  **6.139 ms** |  **28.65 KB** |
| **BulkCopy** | **create table**         | **74800**     |   **234.97 ms** |  **4.491 ms** |  **5.516 ms** |   **29.7 KB** |
| **BulkCopy** | **create table**         | **78400**     |   **247.37 ms** |  **6.377 ms** |  **8.065 ms** |  **31.09 KB** |
| **BulkCopy** | **create table**         | **82000**     |   **259.67 ms** |  **3.932 ms** |  **4.972 ms** |  **32.26 KB** |
| **BulkCopy** | **create table**         | **85600**     |   **273.65 ms** |  **9.271 ms** | **11.725 ms** |  **33.48 KB** |
| **BulkCopy** | **create table**         | **89200**     |   **286.26 ms** |  **6.082 ms** |  **7.908 ms** |  **34.65 KB** |
| **BulkCopy** | **create table**         | **92800**     |   **296.80 ms** |  **4.203 ms** |  **5.466 ms** |  **35.87 KB** |
| **BulkCopy** | **create table**         | **96400**     |   **305.01 ms** |  **2.988 ms** |  **3.885 ms** |  **37.04 KB** |
| **BulkCopy** | **create table**         | **100000**    |   **329.18 ms** |  **8.783 ms** | **11.725 ms** |  **38.76 KB** |
| BulkCopy | create table         | 100000    |   329.98 ms | 10.749 ms | 14.350 ms |  38.76 KB |
| **BulkCopy** | **create table**         | **136000**    |   **462.26 ms** | **15.605 ms** | **20.833 ms** |  **50.71 KB** |
| **BulkCopy** | **create table**         | **172000**    |   **582.52 ms** |  **8.759 ms** | **11.389 ms** |  **62.66 KB** |
| **BulkCopy** | **create table**         | **208000**    |   **725.83 ms** | **11.510 ms** | **14.966 ms** |  **75.02 KB** |
| **BulkCopy** | **create table**         | **244000**    |   **861.52 ms** | **11.591 ms** | **14.659 ms** |  **86.98 KB** |
| **BulkCopy** | **create table**         | **280000**    |   **978.60 ms** |  **9.628 ms** | **12.519 ms** |  **98.93 KB** |
| **BulkCopy** | **create table**         | **316000**    | **1,098.40 ms** | **10.889 ms** | **14.158 ms** | **111.29 KB** |
| **BulkCopy** | **create table**         | **352000**    | **1,238.80 ms** | **13.290 ms** | **17.742 ms** | **123.42 KB** |
| **BulkCopy** | **create table**         | **388000**    | **1,391.44 ms** | **16.841 ms** | **21.898 ms** | **135.38 KB** |
| **BulkCopy** | **create table**         | **424000**    | **1,552.66 ms** | **28.473 ms** | **38.011 ms** | **147.55 KB** |
| **BulkCopy** | **create table**         | **460000**    | **1,676.75 ms** | **14.213 ms** | **18.481 ms** | **159.69 KB** |
| **BulkCopy** | **create table**         | **496000**    | **1,805.87 ms** | **23.714 ms** | **29.991 ms** | **172.14 KB** |
| **BulkCopy** | **create table**         | **532000**    | **1,917.13 ms** | **13.903 ms** | **16.551 ms** |    **184 KB** |
| **BulkCopy** | **create table**         | **568000**    | **2,040.09 ms** | **27.943 ms** | **36.334 ms** | **196.67 KB** |
| **BulkCopy** | **create table**         | **604000**    | **2,156.15 ms** | **16.113 ms** | **20.378 ms** | **208.63 KB** |
| **BulkCopy** | **create table**         | **640000**    | **2,280.52 ms** | **31.371 ms** | **39.674 ms** | **220.98 KB** |
| **BulkCopy** | **create table**         | **676000**    | **2,405.86 ms** | **23.615 ms** | **29.866 ms** | **232.76 KB** |
| **BulkCopy** | **create table**         | **712000**    | **2,529.70 ms** | **22.438 ms** | **29.176 ms** | **245.43 KB** |
| **BulkCopy** | **create table**         | **748000**    | **2,675.38 ms** | **21.974 ms** | **27.791 ms** | **257.38 KB** |
| **BulkCopy** | **create table**         | **784000**    | **2,825.33 ms** | **32.306 ms** | **40.856 ms** |  **269.2 KB** |
| **BulkCopy** | **create table**         | **820000**    | **2,976.19 ms** | **20.839 ms** | **25.592 ms** |  **281.7 KB** |
| **BulkCopy** | **create table**         | **856000**    | **3,109.17 ms** | **32.541 ms** | **41.153 ms** | **294.01 KB** |
| **BulkCopy** | **create table**         | **892000**    | **3,251.17 ms** | **31.462 ms** | **40.910 ms** | **305.82 KB** |
| **BulkCopy** | **create table**         | **928000**    | **3,363.81 ms** | **30.808 ms** | **40.059 ms** | **317.78 KB** |
| **BulkCopy** | **create table**         | **964000**    | **3,502.80 ms** | **35.603 ms** | **45.027 ms** | **330.84 KB** |
| **BulkCopy** | **create table**         | **1000000**   | **3,603.96 ms** | **25.140 ms** | **30.874 ms** |  **342.9 KB** |
| **BulkCopy** | **create temp table**    | **10000**     |    **24.58 ms** |  **0.187 ms** |  **0.250 ms** |   **8.35 KB** |
| **BulkCopy** | **create temp table**    | **13600**     |    **31.69 ms** |  **0.289 ms** |  **0.386 ms** |   **9.58 KB** |
| **BulkCopy** | **create temp table**    | **17200**     |    **39.43 ms** |  **0.295 ms** |  **0.384 ms** |  **10.77 KB** |
| **BulkCopy** | **create temp table**    | **20800**     |    **47.27 ms** |  **0.245 ms** |  **0.310 ms** |  **12.01 KB** |
| **BulkCopy** | **create temp table**    | **24400**     |    **56.14 ms** |  **0.487 ms** |  **0.650 ms** |  **13.24 KB** |
| **BulkCopy** | **create temp table**    | **28000**     |    **63.89 ms** |  **0.448 ms** |  **0.599 ms** |  **14.45 KB** |
| **BulkCopy** | **create temp table**    | **31600**     |    **71.95 ms** |  **0.201 ms** |  **0.246 ms** |  **15.66 KB** |
| **BulkCopy** | **create temp table**    | **35200**     |    **79.79 ms** |  **0.234 ms** |  **0.304 ms** |  **16.83 KB** |
| **BulkCopy** | **create temp table**    | **38800**     |    **89.94 ms** |  **0.668 ms** |  **0.892 ms** |  **18.07 KB** |
| **BulkCopy** | **create temp table**    | **42400**     |    **97.36 ms** |  **0.514 ms** |  **0.650 ms** |  **19.28 KB** |
| **BulkCopy** | **create temp table**    | **46000**     |   **107.99 ms** |  **0.768 ms** |  **0.971 ms** |   **20.5 KB** |
| **BulkCopy** | **create temp table**    | **49600**     |   **116.09 ms** |  **0.679 ms** |  **0.859 ms** |  **21.67 KB** |
| **BulkCopy** | **create temp table**    | **53200**     |   **125.46 ms** |  **0.512 ms** |  **0.628 ms** |  **22.94 KB** |
| **BulkCopy** | **create temp table**    | **56800**     |   **137.11 ms** |  **2.287 ms** |  **3.053 ms** |  **24.11 KB** |
| **BulkCopy** | **create temp table**    | **60400**     |   **144.26 ms** |  **0.556 ms** |  **0.723 ms** |  **25.33 KB** |
| **BulkCopy** | **create temp table**    | **64000**     |   **153.95 ms** |  **0.831 ms** |  **1.080 ms** |   **26.5 KB** |
| **BulkCopy** | **create temp table**    | **67600**     |   **163.98 ms** |  **0.391 ms** |  **0.494 ms** |  **27.86 KB** |
| **BulkCopy** | **create temp table**    | **71200**     |   **175.81 ms** |  **1.879 ms** |  **2.377 ms** |  **28.97 KB** |
| **BulkCopy** | **create temp table**    | **74800**     |   **184.84 ms** |  **1.642 ms** |  **2.077 ms** |  **30.19 KB** |
| **BulkCopy** | **create temp table**    | **78400**     |   **197.72 ms** |  **1.869 ms** |  **2.430 ms** |  **31.41 KB** |
| **BulkCopy** | **create temp table**    | **82000**     |   **204.43 ms** |  **0.813 ms** |  **1.057 ms** |  **32.58 KB** |
| **BulkCopy** | **create temp table**    | **85600**     |   **220.07 ms** |  **2.902 ms** |  **3.874 ms** |   **33.8 KB** |
| **BulkCopy** | **create temp table**    | **89200**     |   **228.57 ms** |  **2.004 ms** |  **2.676 ms** |  **34.97 KB** |
| **BulkCopy** | **create temp table**    | **92800**     |   **239.63 ms** |  **1.932 ms** |  **2.513 ms** |  **36.36 KB** |
| **BulkCopy** | **create temp table**    | **96400**     |   **250.71 ms** |  **1.902 ms** |  **2.405 ms** |  **37.53 KB** |
| **BulkCopy** | **create temp table**    | **100000**    |   **261.57 ms** |  **3.634 ms** |  **4.852 ms** |  **38.75 KB** |
| BulkCopy | create temp table    | 100000    |   264.57 ms |  3.579 ms |  4.526 ms |  38.75 KB |
| **BulkCopy** | **create temp table**    | **136000**    |   **418.32 ms** |  **4.191 ms** |  **5.301 ms** |   **51.2 KB** |
| **BulkCopy** | **create temp table**    | **172000**    |   **611.33 ms** |  **4.648 ms** |  **6.205 ms** |  **63.16 KB** |
| **BulkCopy** | **create temp table**    | **208000**    |   **842.13 ms** |  **6.448 ms** |  **8.155 ms** |  **75.34 KB** |
| **BulkCopy** | **create temp table**    | **244000**    | **1,103.88 ms** |  **9.714 ms** | **12.968 ms** |  **87.29 KB** |
| **BulkCopy** | **create temp table**    | **280000**    | **1,355.56 ms** | **11.005 ms** | **14.691 ms** | **100.02 KB** |
| **BulkCopy** | **create temp table**    | **316000**    | **1,597.40 ms** |  **8.333 ms** | **11.124 ms** |  **111.6 KB** |
| **BulkCopy** | **create temp table**    | **352000**    | **1,853.17 ms** |  **9.075 ms** | **12.115 ms** | **123.91 KB** |
| **BulkCopy** | **create temp table**    | **388000**    | **2,148.74 ms** | **11.290 ms** | **15.072 ms** | **136.77 KB** |
| **BulkCopy** | **create temp table**    | **424000**    | **2,444.57 ms** |  **9.196 ms** | **12.276 ms** | **148.83 KB** |
| **BulkCopy** | **create temp table**    | **460000**    | **2,733.53 ms** | **12.384 ms** | **16.532 ms** | **160.97 KB** |
| **BulkCopy** | **create temp table**    | **496000**    | **2,973.12 ms** | **11.647 ms** | **15.548 ms** | **172.49 KB** |
| **BulkCopy** | **create temp table**    | **532000**    | **3,231.78 ms** | **13.096 ms** | **17.482 ms** | **184.85 KB** |
| **BulkCopy** | **create temp table**    | **568000**    | **3,494.88 ms** | **11.441 ms** | **15.273 ms** | **197.73 KB** |
| **BulkCopy** | **create temp table**    | **604000**    | **3,746.03 ms** | **12.018 ms** | **16.044 ms** | **209.12 KB** |
| **BulkCopy** | **create temp table**    | **640000**    | **3,992.62 ms** | **11.931 ms** | **15.927 ms** | **221.84 KB** |
| **BulkCopy** | **create temp table**    | **676000**    | **4,244.08 ms** | **12.335 ms** | **16.467 ms** | **233.43 KB** |
| **BulkCopy** | **create temp table**    | **712000**    | **4,513.89 ms** | **11.494 ms** | **15.345 ms** | **245.92 KB** |
| **BulkCopy** | **create temp table**    | **748000**    | **4,771.74 ms** | **10.815 ms** | **13.282 ms** | **258.05 KB** |
| **BulkCopy** | **create temp table**    | **784000**    | **5,065.99 ms** |  **8.692 ms** | **10.993 ms** | **270.05 KB** |
| **BulkCopy** | **create temp table**    | **820000**    | **5,371.30 ms** |  **8.464 ms** | **11.006 ms** | **282.37 KB** |
| **BulkCopy** | **create temp table**    | **856000**    | **5,655.34 ms** | **13.965 ms** | **18.643 ms** | **294.32 KB** |
| **BulkCopy** | **create temp table**    | **892000**    | **5,927.23 ms** | **13.813 ms** | **18.440 ms** | **307.29 KB** |
| **BulkCopy** | **create temp table**    | **928000**    | **6,179.37 ms** | **15.373 ms** | **20.522 ms** | **319.17 KB** |
| **BulkCopy** | **create temp table**    | **964000**    | **6,436.72 ms** | **26.800 ms** | **35.777 ms** | **332.66 KB** |
| **BulkCopy** | **create temp table**    | **1000000**   | **6,691.84 ms** | **14.511 ms** | **19.372 ms** |  **343.3 KB** |
| **BulkCopy** | **creat(...)table [21]** | **10000**     |    **25.84 ms** |  **0.121 ms** |  **0.157 ms** |   **7.87 KB** |
| **BulkCopy** | **creat(...)table [21]** | **13600**     |    **33.60 ms** |  **0.104 ms** |  **0.131 ms** |   **9.12 KB** |
| **BulkCopy** | **creat(...)table [21]** | **17200**     |    **42.46 ms** |  **0.733 ms** |  **0.979 ms** |  **10.31 KB** |
| **BulkCopy** | **creat(...)table [21]** | **20800**     |    **50.70 ms** |  **0.241 ms** |  **0.287 ms** |  **11.54 KB** |
| **BulkCopy** | **creat(...)table [21]** | **24400**     |    **59.64 ms** |  **0.467 ms** |  **0.623 ms** |  **12.78 KB** |
| **BulkCopy** | **creat(...)table [21]** | **28000**     |    **68.30 ms** |  **0.830 ms** |  **1.108 ms** |  **13.96 KB** |
| **BulkCopy** | **creat(...)table [21]** | **31600**     |    **78.37 ms** |  **1.856 ms** |  **2.477 ms** |   **15.2 KB** |
| **BulkCopy** | **creat(...)table [21]** | **35200**     |    **85.59 ms** |  **0.245 ms** |  **0.327 ms** |  **16.39 KB** |
| **BulkCopy** | **creat(...)table [21]** | **38800**     |    **95.58 ms** |  **0.320 ms** |  **0.405 ms** |  **17.61 KB** |
| **BulkCopy** | **creat(...)table [21]** | **42400**     |   **104.30 ms** |  **0.575 ms** |  **0.748 ms** |  **18.82 KB** |
| **BulkCopy** | **creat(...)table [21]** | **46000**     |   **113.68 ms** |  **0.261 ms** |  **0.339 ms** |  **20.04 KB** |
| **BulkCopy** | **creat(...)table [21]** | **49600**     |   **123.09 ms** |  **0.675 ms** |  **0.829 ms** |  **21.21 KB** |
| **BulkCopy** | **creat(...)table [21]** | **53200**     |   **132.55 ms** |  **0.303 ms** |  **0.372 ms** |  **22.48 KB** |
| **BulkCopy** | **creat(...)table [21]** | **56800**     |   **142.36 ms** |  **0.989 ms** |  **1.177 ms** |  **23.65 KB** |
| **BulkCopy** | **creat(...)table [21]** | **60400**     |   **151.79 ms** |  **1.371 ms** |  **1.782 ms** |  **24.95 KB** |
| **BulkCopy** | **creat(...)table [21]** | **64000**     |   **162.14 ms** |  **0.641 ms** |  **0.763 ms** |  **26.12 KB** |
| **BulkCopy** | **creat(...)table [21]** | **67600**     |   **170.87 ms** |  **0.678 ms** |  **0.833 ms** |  **27.34 KB** |
| **BulkCopy** | **creat(...)table [21]** | **71200**     |   **184.24 ms** |  **1.767 ms** |  **2.297 ms** |  **28.51 KB** |
| **BulkCopy** | **creat(...)table [21]** | **74800**     |   **192.89 ms** |  **1.744 ms** |  **2.268 ms** |  **29.73 KB** |
| **BulkCopy** | **creat(...)table [21]** | **78400**     |   **201.92 ms** |  **0.549 ms** |  **0.675 ms** |  **30.95 KB** |
| **BulkCopy** | **creat(...)table [21]** | **82000**     |   **214.59 ms** |  **2.453 ms** |  **3.275 ms** |  **32.12 KB** |
| **BulkCopy** | **creat(...)table [21]** | **85600**     |   **225.08 ms** |  **1.424 ms** |  **1.801 ms** |  **33.51 KB** |
| **BulkCopy** | **creat(...)table [21]** | **89200**     |   **235.21 ms** |  **2.026 ms** |  **2.634 ms** |  **34.68 KB** |
| **BulkCopy** | **creat(...)table [21]** | **92800**     |   **247.59 ms** |  **2.329 ms** |  **2.945 ms** |   **35.9 KB** |
| **BulkCopy** | **creat(...)table [21]** | **96400**     |   **257.87 ms** |  **4.352 ms** |  **5.809 ms** |  **37.07 KB** |
| **BulkCopy** | **creat(...)table [21]** | **100000**    |   **266.63 ms** |  **2.519 ms** |  **3.276 ms** |  **38.29 KB** |
| BulkCopy | creat(...)table [21] | 100000    |   264.71 ms |  1.852 ms |  2.409 ms |  38.29 KB |
| **BulkCopy** | **creat(...)table [21]** | **136000**    |   **378.54 ms** |  **6.300 ms** |  **8.192 ms** |  **50.74 KB** |
| **BulkCopy** | **creat(...)table [21]** | **172000**    |   **480.99 ms** |  **3.441 ms** |  **4.226 ms** |   **62.7 KB** |
| **BulkCopy** | **creat(...)table [21]** | **208000**    |   **601.22 ms** |  **6.826 ms** |  **8.383 ms** |  **74.88 KB** |
| **BulkCopy** | **creat(...)table [21]** | **244000**    |   **722.92 ms** |  **8.967 ms** | **11.971 ms** |  **87.01 KB** |
| **BulkCopy** | **creat(...)table [21]** | **280000**    |   **827.69 ms** | **10.974 ms** | **14.650 ms** |  **99.14 KB** |
| **BulkCopy** | **creat(...)table [21]** | **316000**    |   **929.11 ms** | **10.583 ms** | **14.128 ms** |  **111.5 KB** |
| **BulkCopy** | **creat(...)table [21]** | **352000**    | **1,038.39 ms** |  **9.579 ms** | **12.787 ms** | **123.45 KB** |
| **BulkCopy** | **creat(...)table [21]** | **388000**    | **1,160.76 ms** |  **8.946 ms** | **11.942 ms** | **135.41 KB** |
| **BulkCopy** | **creat(...)table [21]** | **424000**    | **1,299.21 ms** |  **8.691 ms** | **11.602 ms** | **147.59 KB** |
| **BulkCopy** | **creat(...)table [21]** | **460000**    | **1,417.95 ms** |  **8.709 ms** | **11.626 ms** |  **159.9 KB** |
| **BulkCopy** | **creat(...)table [21]** | **496000**    | **1,524.09 ms** |  **8.916 ms** | **11.902 ms** | **171.85 KB** |
| **BulkCopy** | **creat(...)table [21]** | **532000**    | **1,625.75 ms** | **10.108 ms** | **13.494 ms** | **183.85 KB** |
| **BulkCopy** | **creat(...)table [21]** | **568000**    | **1,734.98 ms** |  **9.521 ms** | **12.710 ms** | **196.34 KB** |
| **BulkCopy** | **creat(...)table [21]** | **604000**    | **1,825.32 ms** | **12.001 ms** | **15.605 ms** | **208.48 KB** |
| **BulkCopy** | **creat(...)table [21]** | **640000**    | **1,930.62 ms** | **12.315 ms** | **16.440 ms** | **220.66 KB** |
| **BulkCopy** | **creat(...)table [21]** | **676000**    | **2,029.52 ms** | **13.296 ms** | **17.750 ms** | **232.79 KB** |
| **BulkCopy** | **creat(...)table [21]** | **712000**    | **2,144.27 ms** |  **9.459 ms** | **12.627 ms** | **244.74 KB** |
| **BulkCopy** | **creat(...)table [21]** | **748000**    | **2,268.79 ms** |  **8.690 ms** | **11.299 ms** | **257.05 KB** |
| **BulkCopy** | **creat(...)table [21]** | **784000**    | **2,392.70 ms** | **11.945 ms** | **15.532 ms** |  **268.7 KB** |
| **BulkCopy** | **creat(...)table [21]** | **820000**    | **2,523.82 ms** | **14.792 ms** | **19.747 ms** | **281.37 KB** |
| **BulkCopy** | **creat(...)table [21]** | **856000**    | **2,636.88 ms** |  **6.465 ms** |  **8.630 ms** | **293.14 KB** |
| **BulkCopy** | **creat(...)table [21]** | **892000**    | **2,740.43 ms** | **12.003 ms** | **15.179 ms** |  **305.5 KB** |
| **BulkCopy** | **creat(...)table [21]** | **928000**    | **2,847.37 ms** |  **8.734 ms** | **11.660 ms** | **317.81 KB** |
| **BulkCopy** | **creat(...)table [21]** | **964000**    | **2,948.17 ms** | **11.348 ms** | **15.149 ms** | **329.91 KB** |
| **BulkCopy** | **creat(...)table [21]** | **1000000**   | **3,056.89 ms** |  **9.091 ms** | **11.497 ms** | **341.95 KB** |

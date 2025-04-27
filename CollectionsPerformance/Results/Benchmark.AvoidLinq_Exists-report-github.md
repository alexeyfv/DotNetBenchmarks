```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4391/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  Job-CPAQVT : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2

IterationCount=25  

```
| Method             | Length  | Mean              | Error           | StdDev          | Gen0   | Allocated |
|------------------- |-------- |------------------:|----------------:|----------------:|-------:|----------:|
| **ArrayExists**        | **10**      |         **12.999 ns** |       **0.0966 ns** |       **0.1257 ns** |      **-** |         **-** |
| ArrayLinqAny       | 10      |         59.859 ns |       0.4100 ns |       0.5474 ns | 0.0153 |      32 B |
| ListLinqAny        | 10      |        103.551 ns |       0.9304 ns |       1.1767 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 10      |        101.996 ns |       1.0467 ns |       1.3238 ns | 0.0191 |      40 B |
| ImperativeExists   | 10      |          8.556 ns |       0.0416 ns |       0.0556 ns |      - |         - |
| **ArrayExists**        | **20**      |         **26.373 ns** |       **0.3653 ns** |       **0.4877 ns** |      **-** |         **-** |
| ArrayLinqAny       | 20      |         97.394 ns |       0.7734 ns |       0.9781 ns | 0.0153 |      32 B |
| ListLinqAny        | 20      |        178.539 ns |       2.0501 ns |       2.6657 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 20      |        177.978 ns |       1.6457 ns |       2.0210 ns | 0.0191 |      40 B |
| ImperativeExists   | 20      |         14.722 ns |       0.0796 ns |       0.1035 ns |      - |         - |
| **ArrayExists**        | **30**      |         **37.898 ns** |       **0.2281 ns** |       **0.2885 ns** |      **-** |         **-** |
| ArrayLinqAny       | 30      |        133.371 ns |       0.9562 ns |       1.2433 ns | 0.0153 |      32 B |
| ListLinqAny        | 30      |        255.393 ns |       1.7068 ns |       2.2193 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 30      |        240.621 ns |       2.3287 ns |       3.0280 ns | 0.0191 |      40 B |
| ImperativeExists   | 30      |         32.240 ns |       0.4286 ns |       0.5721 ns |      - |         - |
| **ArrayExists**        | **40**      |         **49.319 ns** |       **0.6537 ns** |       **0.8501 ns** |      **-** |         **-** |
| ArrayLinqAny       | 40      |        169.235 ns |       1.1335 ns |       1.4335 ns | 0.0153 |      32 B |
| ListLinqAny        | 40      |        334.104 ns |       4.3384 ns |       5.3279 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 40      |        309.321 ns |       2.8737 ns |       3.8363 ns | 0.0191 |      40 B |
| ImperativeExists   | 40      |         34.282 ns |       0.2261 ns |       0.2940 ns |      - |         - |
| **ArrayExists**        | **50**      |         **57.581 ns** |       **0.4800 ns** |       **0.6241 ns** |      **-** |         **-** |
| ArrayLinqAny       | 50      |        205.750 ns |       2.0891 ns |       2.7889 ns | 0.0153 |      32 B |
| ListLinqAny        | 50      |        406.586 ns |       4.2535 ns |       5.5307 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 50      |        409.072 ns |       4.8562 ns |       6.3144 ns | 0.0191 |      40 B |
| ImperativeExists   | 50      |         44.957 ns |       0.7974 ns |       1.0646 ns |      - |         - |
| **ArrayExists**        | **60**      |         **67.273 ns** |       **0.3425 ns** |       **0.4332 ns** |      **-** |         **-** |
| ArrayLinqAny       | 60      |        243.897 ns |       1.3965 ns |       1.8158 ns | 0.0153 |      32 B |
| ListLinqAny        | 60      |        487.426 ns |       4.2744 ns |       5.7062 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 60      |        484.114 ns |       3.8790 ns |       5.0438 ns | 0.0191 |      40 B |
| ImperativeExists   | 60      |         53.475 ns |       0.8419 ns |       1.1239 ns |      - |         - |
| **ArrayExists**        | **70**      |         **75.745 ns** |       **0.5238 ns** |       **0.6432 ns** |      **-** |         **-** |
| ArrayLinqAny       | 70      |        277.030 ns |       1.3659 ns |       1.7274 ns | 0.0153 |      32 B |
| ListLinqAny        | 70      |        518.446 ns |       4.5300 ns |       5.7290 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 70      |        558.952 ns |       4.5092 ns |       6.0196 ns | 0.0191 |      40 B |
| ImperativeExists   | 70      |         59.809 ns |       0.4473 ns |       0.5657 ns |      - |         - |
| **ArrayExists**        | **80**      |         **83.925 ns** |       **0.4933 ns** |       **0.6058 ns** |      **-** |         **-** |
| ArrayLinqAny       | 80      |        314.527 ns |       2.0054 ns |       2.5361 ns | 0.0153 |      32 B |
| ListLinqAny        | 80      |        638.566 ns |       6.1081 ns |       7.7248 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 80      |        592.545 ns |       6.0841 ns |       7.9110 ns | 0.0191 |      40 B |
| ImperativeExists   | 80      |         65.921 ns |       0.4055 ns |       0.5414 ns |      - |         - |
| **ArrayExists**        | **90**      |         **95.607 ns** |       **1.2633 ns** |       **1.6427 ns** |      **-** |         **-** |
| ArrayLinqAny       | 90      |        355.061 ns |       6.5907 ns |       8.7984 ns | 0.0153 |      32 B |
| ListLinqAny        | 90      |        716.407 ns |       6.6456 ns |       8.1613 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 90      |        681.545 ns |      15.6342 ns |      20.8712 ns | 0.0191 |      40 B |
| ImperativeExists   | 90      |         72.284 ns |       0.8932 ns |       1.1296 ns |      - |         - |
| **ArrayExists**        | **100**     |        **103.940 ns** |       **1.7207 ns** |       **2.2970 ns** |      **-** |         **-** |
| ArrayLinqAny       | 100     |        393.723 ns |       6.2481 ns |       8.3411 ns | 0.0153 |      32 B |
| ListLinqAny        | 100     |        787.281 ns |      10.8731 ns |      14.1382 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 100     |        803.704 ns |      14.4957 ns |      19.3513 ns | 0.0191 |      40 B |
| ImperativeExists   | 100     |         78.062 ns |       0.5929 ns |       0.6590 ns |      - |         - |
| **ArrayExists**        | **200**     |        **194.318 ns** |       **3.0530 ns** |       **3.9698 ns** |      **-** |         **-** |
| ArrayLinqAny       | 200     |        702.415 ns |      14.6550 ns |      19.5639 ns | 0.0153 |      32 B |
| ListLinqAny        | 200     |      1,571.752 ns |      23.8523 ns |      31.8422 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 200     |      1,461.407 ns |      24.1169 ns |      31.3588 ns | 0.0191 |      40 B |
| ImperativeExists   | 200     |        140.387 ns |       0.7260 ns |       0.9182 ns |      - |         - |
| **ArrayExists**        | **300**     |        **282.230 ns** |       **2.1102 ns** |       **2.6687 ns** |      **-** |         **-** |
| ArrayLinqAny       | 300     |      1,113.107 ns |       6.7471 ns |       9.0072 ns | 0.0153 |      32 B |
| ListLinqAny        | 300     |      2,310.940 ns |      16.8834 ns |      21.9532 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 300     |      2,316.099 ns |      21.9161 ns |      29.2573 ns | 0.0191 |      40 B |
| ImperativeExists   | 300     |        204.539 ns |       2.1049 ns |       2.8100 ns |      - |         - |
| **ArrayExists**        | **400**     |        **381.179 ns** |       **7.0921 ns** |       **9.4677 ns** |      **-** |         **-** |
| ArrayLinqAny       | 400     |      1,494.797 ns |      20.6239 ns |      26.0826 ns | 0.0153 |      32 B |
| ListLinqAny        | 400     |      3,148.567 ns |      68.3604 ns |      91.2592 ns | 0.0191 |      40 B |
| IEnumerableLinqAny | 400     |      3,109.847 ns |      56.9808 ns |      76.0677 ns | 0.0191 |      40 B |
| ImperativeExists   | 400     |        273.260 ns |       1.7730 ns |       2.1774 ns |      - |         - |
| **ArrayExists**        | **500**     |        **479.728 ns** |       **6.5727 ns** |       **8.5463 ns** |      **-** |         **-** |
| ArrayLinqAny       | 500     |      1,709.551 ns |      30.7383 ns |      41.0347 ns | 0.0153 |      32 B |
| ListLinqAny        | 500     |      3,852.426 ns |      42.3967 ns |      52.0669 ns | 0.0153 |      40 B |
| IEnumerableLinqAny | 500     |      3,825.146 ns |      28.6875 ns |      38.2970 ns | 0.0153 |      40 B |
| ImperativeExists   | 500     |        400.752 ns |       5.1441 ns |       6.8673 ns |      - |         - |
| **ArrayExists**        | **600**     |        **571.965 ns** |       **5.9560 ns** |       **7.5324 ns** |      **-** |         **-** |
| ArrayLinqAny       | 600     |      2,214.930 ns |      14.0017 ns |      18.2061 ns | 0.0153 |      32 B |
| ListLinqAny        | 600     |      4,602.644 ns |      53.4057 ns |      69.4425 ns | 0.0153 |      40 B |
| IEnumerableLinqAny | 600     |      4,590.982 ns |      29.4986 ns |      39.3798 ns | 0.0153 |      40 B |
| ImperativeExists   | 600     |        485.803 ns |       3.3787 ns |       4.5105 ns |      - |         - |
| **ArrayExists**        | **700**     |        **666.438 ns** |       **9.4144 ns** |      **11.5617 ns** |      **-** |         **-** |
| ArrayLinqAny       | 700     |      2,375.738 ns |      17.9145 ns |      22.0006 ns | 0.0153 |      32 B |
| ListLinqAny        | 700     |      5,436.736 ns |      98.3416 ns |     124.3707 ns | 0.0153 |      40 B |
| IEnumerableLinqAny | 700     |      5,467.524 ns |      89.5867 ns |     119.5957 ns | 0.0153 |      40 B |
| ImperativeExists   | 700     |        564.020 ns |       2.9057 ns |       3.8790 ns |      - |         - |
| **ArrayExists**        | **800**     |        **757.543 ns** |      **11.0185 ns** |      **14.7094 ns** |      **-** |         **-** |
| ArrayLinqAny       | 800     |      2,972.826 ns |      45.1124 ns |      58.6589 ns | 0.0153 |      32 B |
| ListLinqAny        | 800     |      6,162.698 ns |      79.9734 ns |     101.1408 ns | 0.0153 |      40 B |
| IEnumerableLinqAny | 800     |      6,191.850 ns |      99.7144 ns |     133.1159 ns | 0.0153 |      40 B |
| ImperativeExists   | 800     |        646.133 ns |       8.3126 ns |      10.8087 ns |      - |         - |
| **ArrayExists**        | **900**     |        **855.878 ns** |      **11.9350 ns** |      **15.9329 ns** |      **-** |         **-** |
| ArrayLinqAny       | 900     |      3,073.168 ns |      47.7227 ns |      63.7085 ns | 0.0153 |      32 B |
| ListLinqAny        | 900     |      6,918.615 ns |     109.9279 ns |     146.7506 ns | 0.0153 |      40 B |
| IEnumerableLinqAny | 900     |      6,882.451 ns |      73.3206 ns |      95.3375 ns | 0.0153 |      40 B |
| ImperativeExists   | 900     |        722.041 ns |       9.5034 ns |      12.3571 ns |      - |         - |
| **ArrayExists**        | **1000**    |        **945.433 ns** |      **13.7171 ns** |      **17.3478 ns** |      **-** |         **-** |
| ArrayLinqAny       | 1000    |      3,704.784 ns |      48.7881 ns |      65.1308 ns | 0.0153 |      32 B |
| ListLinqAny        | 1000    |      7,721.023 ns |     128.3792 ns |     171.3826 ns | 0.0153 |      40 B |
| IEnumerableLinqAny | 1000    |      7,718.495 ns |     136.8400 ns |     177.9307 ns | 0.0153 |      40 B |
| ImperativeExists   | 1000    |        796.365 ns |      13.8084 ns |      18.4338 ns |      - |         - |
| **ArrayExists**        | **2000**    |      **1,881.778 ns** |      **14.7891 ns** |      **19.7430 ns** |      **-** |         **-** |
| ArrayLinqAny       | 2000    |      6,825.851 ns |     115.6862 ns |     154.4378 ns | 0.0153 |      32 B |
| ListLinqAny        | 2000    |     15,361.927 ns |     222.3198 ns |     296.7906 ns |      - |      40 B |
| IEnumerableLinqAny | 2000    |     15,324.264 ns |     162.8458 ns |     211.7456 ns |      - |      40 B |
| ImperativeExists   | 2000    |      1,635.009 ns |      29.7695 ns |      39.7414 ns |      - |         - |
| **ArrayExists**        | **3000**    |      **2,785.859 ns** |      **30.1558 ns** |      **39.2111 ns** |      **-** |         **-** |
| ArrayLinqAny       | 3000    |     10,174.938 ns |      86.6228 ns |     109.5501 ns | 0.0153 |      32 B |
| ListLinqAny        | 3000    |     23,326.227 ns |     384.0414 ns |     512.6843 ns |      - |      40 B |
| IEnumerableLinqAny | 3000    |     20,453.632 ns |     246.8480 ns |     284.2705 ns |      - |      40 B |
| ImperativeExists   | 3000    |      2,428.966 ns |      17.4524 ns |      22.6930 ns |      - |         - |
| **ArrayExists**        | **4000**    |      **3,739.524 ns** |      **34.5032 ns** |      **41.0736 ns** |      **-** |         **-** |
| ArrayLinqAny       | 4000    |     13,553.135 ns |     183.6693 ns |     245.1932 ns | 0.0153 |      32 B |
| ListLinqAny        | 4000    |     27,518.566 ns |     548.9634 ns |     732.8504 ns |      - |      40 B |
| IEnumerableLinqAny | 4000    |     27,696.098 ns |     448.0764 ns |     582.6259 ns |      - |      40 B |
| ImperativeExists   | 4000    |      3,272.060 ns |      33.1961 ns |      38.2287 ns |      - |         - |
| **ArrayExists**        | **5000**    |      **5,544.676 ns** |      **35.4250 ns** |      **43.5051 ns** |      **-** |         **-** |
| ArrayLinqAny       | 5000    |     16,905.548 ns |     115.0325 ns |     145.4793 ns |      - |      32 B |
| ListLinqAny        | 5000    |     38,462.584 ns |     314.6738 ns |     409.1649 ns |      - |      40 B |
| IEnumerableLinqAny | 5000    |     35,448.059 ns |     486.5926 ns |     649.5873 ns |      - |      40 B |
| ImperativeExists   | 5000    |      4,382.148 ns |      43.7162 ns |      58.3599 ns |      - |         - |
| **ArrayExists**        | **6000**    |      **8,063.755 ns** |      **58.2570 ns** |      **73.6764 ns** |      **-** |         **-** |
| ArrayLinqAny       | 6000    |     20,725.910 ns |     126.2836 ns |     164.2044 ns |      - |      32 B |
| ListLinqAny        | 6000    |     47,026.114 ns |     885.3307 ns |   1,181.8911 ns |      - |      40 B |
| IEnumerableLinqAny | 6000    |     41,252.355 ns |     342.6077 ns |     457.3715 ns |      - |      40 B |
| ImperativeExists   | 6000    |      6,434.286 ns |      95.6425 ns |     127.6800 ns |      - |         - |
| **ArrayExists**        | **7000**    |     **11,073.576 ns** |     **435.2931 ns** |     **581.1038 ns** |      **-** |         **-** |
| ArrayLinqAny       | 7000    |     25,814.032 ns |     157.6257 ns |     181.5220 ns |      - |      32 B |
| ListLinqAny        | 7000    |     54,752.040 ns |     561.8010 ns |     730.5001 ns |      - |      40 B |
| IEnumerableLinqAny | 7000    |     50,826.749 ns |     340.5005 ns |     418.1652 ns |      - |      40 B |
| ImperativeExists   | 7000    |     10,254.982 ns |      92.4220 ns |     123.3807 ns |      - |         - |
| **ArrayExists**        | **8000**    |     **13,547.230 ns** |     **103.7187 ns** |     **138.4614 ns** |      **-** |         **-** |
| ArrayLinqAny       | 8000    |     30,490.084 ns |     323.8361 ns |     421.0785 ns |      - |      32 B |
| ListLinqAny        | 8000    |     57,461.392 ns |     542.2971 ns |     705.1395 ns |      - |      40 B |
| IEnumerableLinqAny | 8000    |     57,182.192 ns |     434.9184 ns |     550.0326 ns |      - |      40 B |
| ImperativeExists   | 8000    |     12,652.369 ns |      95.8349 ns |     117.6939 ns |      - |         - |
| **ArrayExists**        | **9000**    |     **15,748.736 ns** |     **205.4023 ns** |     **274.2062 ns** |      **-** |         **-** |
| ArrayLinqAny       | 9000    |     34,168.213 ns |     342.2459 ns |     432.8316 ns |      - |      32 B |
| ListLinqAny        | 9000    |     64,478.830 ns |     600.7618 ns |     781.1601 ns |      - |      40 B |
| IEnumerableLinqAny | 9000    |     74,081.841 ns |     821.6384 ns |   1,096.8638 ns |      - |      40 B |
| ImperativeExists   | 9000    |     14,446.023 ns |      81.0499 ns |     108.1993 ns |      - |         - |
| **ArrayExists**        | **10000**   |     **17,385.665 ns** |     **106.1865 ns** |     **138.0724 ns** |      **-** |         **-** |
| ArrayLinqAny       | 10000   |     38,078.654 ns |     302.0341 ns |     370.9250 ns |      - |      32 B |
| ListLinqAny        | 10000   |     71,818.655 ns |     690.0031 ns |     921.1344 ns |      - |      40 B |
| IEnumerableLinqAny | 10000   |     79,776.835 ns |     686.2488 ns |     892.3174 ns |      - |      40 B |
| ImperativeExists   | 10000   |     16,321.839 ns |     124.9446 ns |     162.4633 ns |      - |         - |
| **ArrayExists**        | **20000**   |     **35,531.606 ns** |     **378.0471 ns** |     **504.6821 ns** |      **-** |         **-** |
| ArrayLinqAny       | 20000   |     77,813.913 ns |     442.9274 ns |     560.1614 ns |      - |      32 B |
| ListLinqAny        | 20000   |    149,218.659 ns |   1,745.7232 ns |   2,207.7811 ns |      - |      40 B |
| IEnumerableLinqAny | 20000   |    148,306.156 ns |   3,548.2524 ns |   4,223.9424 ns |      - |      40 B |
| ImperativeExists   | 20000   |     33,109.106 ns |     356.2919 ns |     424.1402 ns |      - |         - |
| **ArrayExists**        | **30000**   |    **112,630.240 ns** |     **852.7386 ns** |     **982.0150 ns** |      **-** |         **-** |
| ArrayLinqAny       | 30000   |    211,975.798 ns |   1,708.0857 ns |   2,160.1817 ns |      - |      32 B |
| ListLinqAny        | 30000   |    280,529.703 ns |   2,357.1591 ns |   2,894.8033 ns |      - |      40 B |
| IEnumerableLinqAny | 30000   |    284,439.101 ns |   1,919.2005 ns |   2,495.5029 ns |      - |      40 B |
| ImperativeExists   | 30000   |     78,723.954 ns |     740.8580 ns |     936.9483 ns |      - |         - |
| **ArrayExists**        | **40000**   |    **212,053.716 ns** |   **1,442.0525 ns** |   **1,823.7348 ns** |      **-** |         **-** |
| ArrayLinqAny       | 40000   |    340,548.060 ns |   1,729.4741 ns |   2,187.2312 ns |      - |      32 B |
| ListLinqAny        | 40000   |    426,546.289 ns |   2,641.6028 ns |   3,042.0737 ns |      - |      40 B |
| IEnumerableLinqAny | 40000   |    425,674.974 ns |   2,862.7933 ns |   3,821.7471 ns |      - |      40 B |
| ImperativeExists   | 40000   |    176,158.232 ns |   1,480.1680 ns |   1,817.7794 ns |      - |         - |
| **ArrayExists**        | **50000**   |    **285,137.290 ns** |   **1,022.6739 ns** |   **1,329.7650 ns** |      **-** |         **-** |
| ArrayLinqAny       | 50000   |    448,509.654 ns |   2,191.3654 ns |   2,849.3943 ns |      - |      32 B |
| ListLinqAny        | 50000   |    605,056.037 ns |   4,240.0699 ns |   5,660.3721 ns |      - |      40 B |
| IEnumerableLinqAny | 50000   |    567,229.097 ns |   2,392.6676 ns |   2,755.3996 ns |      - |      40 B |
| ImperativeExists   | 50000   |    244,490.867 ns |   1,074.3771 ns |   1,434.2627 ns |      - |         - |
| **ArrayExists**        | **60000**   |    **347,843.503 ns** |   **1,433.5926 ns** |   **1,913.8051 ns** |      **-** |         **-** |
| ArrayLinqAny       | 60000   |    556,397.694 ns |   2,085.2236 ns |   2,637.1405 ns |      - |      32 B |
| ListLinqAny        | 60000   |    711,607.890 ns |   2,282.8235 ns |   2,968.3156 ns |      - |      40 B |
| IEnumerableLinqAny | 60000   |    709,858.501 ns |   2,017.8918 ns |   2,478.1525 ns |      - |      40 B |
| ImperativeExists   | 60000   |    311,100.203 ns |   1,522.6022 ns |   1,979.8132 ns |      - |         - |
| **ArrayExists**        | **70000**   |    **405,874.814 ns** |   **3,219.6892 ns** |   **3,954.0678 ns** |      **-** |         **-** |
| ArrayLinqAny       | 70000   |    676,017.619 ns |   3,467.8542 ns |   4,509.1904 ns |      - |      32 B |
| ListLinqAny        | 70000   |    833,912.132 ns |   2,650.5657 ns |   3,255.1330 ns |      - |      40 B |
| IEnumerableLinqAny | 70000   |    860,005.278 ns |   5,570.9885 ns |   6,841.6748 ns |      - |      40 B |
| ImperativeExists   | 70000   |    387,052.695 ns |   2,058.4010 ns |   2,603.2184 ns |      - |         - |
| **ArrayExists**        | **80000**   |    **468,415.709 ns** |   **3,550.2384 ns** |   **4,360.0120 ns** |      **-** |         **-** |
| ArrayLinqAny       | 80000   |    754,102.565 ns |   2,185.5859 ns |   2,764.0665 ns |      - |      32 B |
| ListLinqAny        | 80000   |    965,782.773 ns |   4,140.9518 ns |   5,085.4611 ns |      - |      40 B |
| IEnumerableLinqAny | 80000   |    987,055.380 ns |   3,155.1401 ns |   3,755.9702 ns |      - |      41 B |
| ImperativeExists   | 80000   |    450,430.454 ns |   2,410.7762 ns |   2,869.8578 ns |      - |         - |
| **ArrayExists**        | **90000**   |    **540,550.176 ns** |   **5,522.5754 ns** |   **6,359.8061 ns** |      **-** |         **-** |
| ArrayLinqAny       | 90000   |    869,222.945 ns |  10,413.4988 ns |  12,788.7129 ns |      - |      32 B |
| ListLinqAny        | 90000   |  1,079,244.214 ns |   4,582.2272 ns |   5,958.1901 ns |      - |      41 B |
| IEnumerableLinqAny | 90000   |  1,082,869.150 ns |   7,252.3519 ns |   8,906.5402 ns |      - |      41 B |
| ImperativeExists   | 90000   |    510,636.148 ns |   1,664.2130 ns |   2,104.6968 ns |      - |         - |
| **ArrayExists**        | **100000**  |    **587,511.886 ns** |   **5,512.3305 ns** |   **7,167.5874 ns** |      **-** |         **-** |
| ArrayLinqAny       | 100000  |    947,443.336 ns |   3,843.1928 ns |   4,860.4088 ns |      - |      32 B |
| ListLinqAny        | 100000  |  1,212,336.320 ns |   5,576.8186 ns |   7,052.8905 ns |      - |      41 B |
| IEnumerableLinqAny | 100000  |  1,256,984.598 ns |  28,429.1096 ns |  33,842.8357 ns |      - |      41 B |
| ImperativeExists   | 100000  |    574,601.632 ns |   2,191.1525 ns |   2,849.1174 ns |      - |         - |
| **ArrayExists**        | **200000**  |  **1,192,128.198 ns** |   **6,318.1024 ns** |   **8,215.3185 ns** |      **-** |       **1 B** |
| ArrayLinqAny       | 200000  |  1,873,680.651 ns |  10,035.6927 ns |  12,691.9391 ns |      - |      33 B |
| ListLinqAny        | 200000  |  2,435,523.344 ns |  13,405.0666 ns |  16,953.1186 ns |      - |      42 B |
| IEnumerableLinqAny | 200000  |  2,430,221.211 ns |  19,623.1524 ns |  26,196.3470 ns |      - |      42 B |
| ImperativeExists   | 200000  |  1,140,730.227 ns |   4,458.5068 ns |   5,638.5840 ns |      - |       1 B |
| **ArrayExists**        | **300000**  |  **1,762,518.801 ns** |   **6,240.1186 ns** |   **8,330.3798 ns** |      **-** |       **1 B** |
| ArrayLinqAny       | 300000  |  2,803,009.812 ns |  15,641.9575 ns |  18,620.6394 ns |      - |      34 B |
| ListLinqAny        | 300000  |  3,579,109.863 ns |  20,288.0275 ns |  26,380.1687 ns |      - |      42 B |
| IEnumerableLinqAny | 300000  |  3,694,812.891 ns |  68,914.9237 ns |  84,633.7226 ns |      - |      42 B |
| ImperativeExists   | 300000  |  1,703,884.073 ns |  17,332.4551 ns |  21,285.8132 ns |      - |       1 B |
| **ArrayExists**        | **400000**  |  **2,375,532.422 ns** |   **8,281.9428 ns** |  **10,768.8660 ns** |      **-** |       **2 B** |
| ArrayLinqAny       | 400000  |  3,717,089.793 ns |  27,480.7094 ns |  34,754.3014 ns |      - |      34 B |
| ListLinqAny        | 400000  |  5,062,537.760 ns |  43,114.1053 ns |  56,060.5199 ns |      - |      52 B |
| IEnumerableLinqAny | 400000  |  5,150,314.347 ns |  37,942.3209 ns |  46,596.5815 ns |      - |      52 B |
| ImperativeExists   | 400000  |  2,264,891.559 ns |  17,173.7598 ns |  21,719.3092 ns |      - |       2 B |
| **ArrayExists**        | **500000**  |  **2,989,685.921 ns** |  **13,470.4956 ns** |  **17,515.4508 ns** |      **-** |       **2 B** |
| ArrayLinqAny       | 500000  |  4,780,551.265 ns |  18,269.4403 ns |  21,748.4710 ns |      - |      44 B |
| ListLinqAny        | 500000  |  6,064,101.136 ns |  27,897.9604 ns |  34,261.2038 ns |      - |      52 B |
| IEnumerableLinqAny | 500000  |  6,446,081.688 ns |  32,997.9496 ns |  44,051.3186 ns |      - |      42 B |
| ImperativeExists   | 500000  |  2,825,324.432 ns |  17,585.8618 ns |  21,597.0195 ns |      - |       2 B |
| **ArrayExists**        | **600000**  |  **3,567,592.932 ns** |  **18,308.4772 ns** |  **21,794.9417 ns** |      **-** |       **3 B** |
| ArrayLinqAny       | 600000  |  5,840,745.182 ns |  58,096.9957 ns |  75,542.5112 ns |      - |      44 B |
| ListLinqAny        | 600000  |  7,013,023.438 ns |  40,553.1004 ns |  51,286.6919 ns |      - |      44 B |
| IEnumerableLinqAny | 600000  |  7,062,702.995 ns |  75,914.2734 ns |  98,710.0069 ns |      - |      52 B |
| ImperativeExists   | 600000  |  3,395,421.892 ns |  16,919.6123 ns |  21,397.8939 ns |      - |       2 B |
| **ArrayExists**        | **700000**  |  **4,143,103.244 ns** |  **26,113.5848 ns** |  **33,025.3264 ns** |      **-** |       **3 B** |
| ArrayLinqAny       | 700000  |  6,675,790.217 ns |  16,139.4240 ns |  20,411.2055 ns |      - |      44 B |
| ListLinqAny        | 700000  |  8,199,938.920 ns |  43,604.1286 ns |  53,549.7905 ns |      - |      52 B |
| IEnumerableLinqAny | 700000  |  8,235,292.448 ns |  75,658.2417 ns |  98,377.0934 ns |      - |      52 B |
| ImperativeExists   | 700000  |  3,930,254.925 ns |  11,140.8250 ns |  14,089.5777 ns |      - |       3 B |
| **ArrayExists**        | **800000**  |  **4,791,753.551 ns** |  **13,290.8824 ns** |  **16,322.3986 ns** |      **-** |      **12 B** |
| ArrayLinqAny       | 800000  |  7,643,976.250 ns |  54,567.2864 ns |  62,839.7682 ns |      - |      44 B |
| ListLinqAny        | 800000  |  9,235,024.062 ns |  37,438.1811 ns |  43,113.8651 ns |      - |      52 B |
| IEnumerableLinqAny | 800000  |  9,234,668.466 ns |  53,978.2710 ns |  66,290.1702 ns |      - |      52 B |
| ImperativeExists   | 800000  |  4,511,869.837 ns |  22,354.1180 ns |  28,270.8042 ns |      - |       3 B |
| **ArrayExists**        | **900000**  |  **5,263,619.973 ns** |  **19,663.4042 ns** |  **24,867.9125 ns** |      **-** |      **12 B** |
| ArrayLinqAny       | 900000  |  8,579,065.439 ns |  42,411.5301 ns |  50,487.9141 ns |      - |      38 B |
| ListLinqAny        | 900000  | 10,568,712.305 ns | 108,532.7781 ns | 141,123.2802 ns |      - |      46 B |
| IEnumerableLinqAny | 900000  | 10,547,560.714 ns |  96,394.8207 ns | 114,751.1872 ns |      - |      65 B |
| ImperativeExists   | 900000  |  5,064,015.270 ns |  14,614.2963 ns |  17,947.6699 ns |      - |       3 B |
| **ArrayExists**        | **1000000** |  **5,913,091.168 ns** |  **44,874.6074 ns** |  **56,752.0151 ns** |      **-** |      **12 B** |
| ArrayLinqAny       | 1000000 |  9,432,913.859 ns |  41,047.4851 ns |  51,911.9302 ns |      - |      57 B |
| ListLinqAny        | 1000000 | 11,600,962.000 ns |  60,749.6165 ns |  81,099.0000 ns |      - |      65 B |
| IEnumerableLinqAny | 1000000 | 11,542,039.844 ns |  59,988.7998 ns |  78,002.3911 ns |      - |      65 B |
| ImperativeExists   | 1000000 |  5,629,011.347 ns |  27,125.3680 ns |  32,290.8239 ns |      - |       3 B |

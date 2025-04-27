```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4391/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  Job-CPAQVT : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2

IterationCount=25  

```
| Method                       | Length  | Mean             | Error           | StdDev           | Median           | Gen0   | Allocated |
|----------------------------- |-------- |-----------------:|----------------:|-----------------:|-----------------:|-------:|----------:|
| **ArrayIndexer**                 | **10**      |         **576.0 ns** |         **3.07 ns** |          **4.00 ns** |         **576.3 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 10      |       3,400.4 ns |        22.37 ns |         28.29 ns |       3,400.1 ns | 1.5297 |    3200 B |
| ListIndexer                  | 10      |         823.4 ns |        12.57 ns |         16.78 ns |         820.9 ns |      - |         - |
| ListEnumerator               | 10      |         934.0 ns |        11.76 ns |         15.70 ns |         934.4 ns |      - |         - |
| ListAsICollectionEnumerator  | 10      |       6,383.3 ns |        57.43 ns |         74.67 ns |       6,369.5 ns | 1.9073 |    4000 B |
| **ArrayIndexer**                 | **20**      |         **877.9 ns** |        **11.22 ns** |         **14.98 ns** |         **876.2 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 20      |       5,891.8 ns |        44.45 ns |         57.80 ns |       5,886.5 ns | 1.5259 |    3200 B |
| ListIndexer                  | 20      |       1,517.6 ns |        27.60 ns |         35.88 ns |       1,498.6 ns |      - |         - |
| ListEnumerator               | 20      |       1,740.1 ns |        23.85 ns |         31.84 ns |       1,727.4 ns |      - |         - |
| ListAsICollectionEnumerator  | 20      |       8,684.2 ns |        98.31 ns |        124.33 ns |       8,683.5 ns | 1.9073 |    4000 B |
| **ArrayIndexer**                 | **30**      |       **1,294.6 ns** |         **5.70 ns** |          **7.00 ns** |       **1,294.9 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 30      |       8,487.8 ns |        47.51 ns |         63.43 ns |       8,500.5 ns | 1.5259 |    3200 B |
| ListIndexer                  | 30      |       3,106.4 ns |       119.44 ns |        159.45 ns |       3,077.2 ns |      - |         - |
| ListEnumerator               | 30      |       2,515.0 ns |        33.39 ns |         39.74 ns |       2,508.8 ns |      - |         - |
| ListAsICollectionEnumerator  | 30      |      11,860.4 ns |       192.72 ns |        257.28 ns |      11,727.8 ns | 1.9073 |    4000 B |
| **ArrayIndexer**                 | **40**      |       **2,397.2 ns** |        **16.75 ns** |         **20.57 ns** |       **2,397.3 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 40      |      12,944.0 ns |       105.57 ns |        137.27 ns |      12,987.7 ns | 1.5259 |    3200 B |
| ListIndexer                  | 40      |       3,615.6 ns |        59.06 ns |         74.70 ns |       3,585.5 ns |      - |         - |
| ListEnumerator               | 40      |       4,464.0 ns |        60.70 ns |         81.03 ns |       4,481.8 ns |      - |         - |
| ListAsICollectionEnumerator  | 40      |      14,997.4 ns |       234.19 ns |        312.64 ns |      14,891.4 ns | 1.9073 |    4000 B |
| **ArrayIndexer**                 | **50**      |       **2,821.1 ns** |        **30.19 ns** |         **37.08 ns** |       **2,818.6 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 50      |      15,684.6 ns |        87.62 ns |        113.94 ns |      15,692.7 ns | 1.5259 |    3200 B |
| ListIndexer                  | 50      |       4,483.4 ns |        28.48 ns |         37.04 ns |       4,482.6 ns |      - |         - |
| ListEnumerator               | 50      |       5,186.5 ns |        67.52 ns |         90.13 ns |       5,178.7 ns |      - |         - |
| ListAsICollectionEnumerator  | 50      |      18,131.4 ns |       198.32 ns |        257.87 ns |      18,061.2 ns | 1.8921 |    4000 B |
| **ArrayIndexer**                 | **60**      |       **3,369.4 ns** |        **42.65 ns** |         **56.94 ns** |       **3,368.2 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 60      |      18,172.0 ns |        84.99 ns |        113.47 ns |      18,179.4 ns | 1.5259 |    3200 B |
| ListIndexer                  | 60      |       5,385.3 ns |        51.87 ns |         61.75 ns |       5,386.6 ns |      - |         - |
| ListEnumerator               | 60      |       6,106.9 ns |       112.36 ns |        146.10 ns |       6,072.5 ns |      - |         - |
| ListAsICollectionEnumerator  | 60      |      21,082.3 ns |       178.37 ns |        225.58 ns |      21,095.8 ns | 1.8921 |    4000 B |
| **ArrayIndexer**                 | **70**      |       **4,076.2 ns** |        **24.17 ns** |         **30.57 ns** |       **4,074.9 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 70      |      20,694.4 ns |        96.11 ns |        121.55 ns |      20,735.2 ns | 1.5259 |    3200 B |
| ListIndexer                  | 70      |       6,209.3 ns |       107.58 ns |        143.61 ns |       6,134.6 ns |      - |         - |
| ListEnumerator               | 70      |       6,976.6 ns |       138.49 ns |        184.88 ns |       6,919.7 ns |      - |         - |
| ListAsICollectionEnumerator  | 70      |      28,041.6 ns |       295.27 ns |        383.93 ns |      28,077.9 ns | 1.8921 |    4000 B |
| **ArrayIndexer**                 | **80**      |       **4,522.7 ns** |        **34.64 ns** |         **42.54 ns** |       **4,509.6 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 80      |      23,272.3 ns |       182.47 ns |        243.59 ns |      23,329.5 ns | 1.5259 |    3200 B |
| ListIndexer                  | 80      |       6,848.9 ns |        85.52 ns |        114.17 ns |       6,839.3 ns |      - |         - |
| ListEnumerator               | 80      |       7,756.0 ns |       138.46 ns |        184.85 ns |       7,771.6 ns |      - |         - |
| ListAsICollectionEnumerator  | 80      |      27,903.2 ns |       419.64 ns |        545.65 ns |      27,902.3 ns | 1.8921 |    4000 B |
| **ArrayIndexer**                 | **90**      |       **4,898.9 ns** |        **37.47 ns** |         **47.38 ns** |       **4,891.2 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 90      |      25,851.6 ns |       195.31 ns |        247.01 ns |      25,843.2 ns | 1.5259 |    3200 B |
| ListIndexer                  | 90      |       7,565.2 ns |        96.54 ns |        128.88 ns |       7,579.0 ns |      - |         - |
| ListEnumerator               | 90      |       8,380.3 ns |       105.86 ns |        141.32 ns |       8,383.0 ns |      - |         - |
| ListAsICollectionEnumerator  | 90      |      30,656.5 ns |       443.80 ns |        592.46 ns |      30,592.9 ns | 1.8921 |    4000 B |
| **ArrayIndexer**                 | **100**     |       **5,244.3 ns** |        **35.42 ns** |         **47.28 ns** |       **5,259.8 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 100     |      28,299.8 ns |       209.80 ns |        280.08 ns |      28,290.7 ns | 1.5259 |    3200 B |
| ListIndexer                  | 100     |       8,153.8 ns |        52.79 ns |         70.48 ns |       8,151.1 ns |      - |         - |
| ListEnumerator               | 100     |       9,250.4 ns |       160.69 ns |        208.94 ns |       9,279.1 ns |      - |         - |
| ListAsICollectionEnumerator  | 100     |      33,987.0 ns |       633.43 ns |        801.09 ns |      33,933.8 ns | 1.8921 |    4000 B |
| **ArrayIndexer**                 | **200**     |       **9,389.9 ns** |        **72.55 ns** |         **94.33 ns** |       **9,392.0 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 200     |      54,367.3 ns |       726.03 ns |        891.64 ns |      54,057.1 ns | 1.5259 |    3200 B |
| ListIndexer                  | 200     |      15,110.4 ns |       178.31 ns |        238.04 ns |      15,102.6 ns |      - |         - |
| ListEnumerator               | 200     |      16,664.8 ns |        87.40 ns |        110.53 ns |      16,635.9 ns |      - |         - |
| ListAsICollectionEnumerator  | 200     |      65,362.3 ns |     1,392.16 ns |      1,760.64 ns |      64,974.6 ns | 1.8311 |    4000 B |
| **ArrayIndexer**                 | **300**     |      **13,608.2 ns** |       **209.83 ns** |        **280.12 ns** |      **13,559.8 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 300     |      80,014.4 ns |       613.60 ns |        819.14 ns |      79,819.6 ns | 1.4648 |    3200 B |
| ListIndexer                  | 300     |      22,032.6 ns |       385.84 ns |        515.08 ns |      21,808.5 ns |      - |         - |
| ListEnumerator               | 300     |      24,739.3 ns |       394.34 ns |        526.43 ns |      24,551.5 ns |      - |         - |
| ListAsICollectionEnumerator  | 300     |     111,161.5 ns |     1,785.04 ns |      2,321.05 ns |     110,495.7 ns | 1.8311 |    4000 B |
| **ArrayIndexer**                 | **400**     |      **17,728.2 ns** |       **140.56 ns** |        **172.63 ns** |      **17,717.9 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 400     |     105,688.0 ns |       820.13 ns |      1,037.20 ns |     105,806.9 ns | 1.4648 |    3200 B |
| ListIndexer                  | 400     |      29,046.8 ns |       337.12 ns |        450.04 ns |      29,088.7 ns |      - |         - |
| ListEnumerator               | 400     |      32,326.1 ns |       252.71 ns |        337.36 ns |      32,295.5 ns |      - |         - |
| ListAsICollectionEnumerator  | 400     |     145,810.3 ns |     2,485.07 ns |      3,317.50 ns |     144,952.4 ns | 1.7090 |    4000 B |
| **ArrayIndexer**                 | **500**     |      **29,633.7 ns** |       **423.00 ns** |        **564.69 ns** |      **29,644.0 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 500     |     134,375.0 ns |       738.81 ns |        986.29 ns |     134,322.6 ns | 1.4648 |    3200 B |
| ListIndexer                  | 500     |      39,992.9 ns |       529.88 ns |        688.99 ns |      39,798.6 ns |      - |         - |
| ListEnumerator               | 500     |      46,325.5 ns |       517.18 ns |        672.48 ns |      46,247.5 ns |      - |         - |
| ListAsICollectionEnumerator  | 500     |     172,175.8 ns |     3,375.25 ns |      4,505.86 ns |     171,288.7 ns | 1.7090 |    4000 B |
| **ArrayIndexer**                 | **600**     |      **42,289.6 ns** |       **525.75 ns** |        **645.66 ns** |      **42,096.7 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 600     |     159,491.1 ns |     1,054.00 ns |      1,370.50 ns |     159,363.7 ns | 1.4648 |    3200 B |
| ListIndexer                  | 600     |      47,905.8 ns |       588.80 ns |        765.61 ns |      47,736.9 ns |      - |         - |
| ListEnumerator               | 600     |      57,031.9 ns |       819.86 ns |      1,066.05 ns |      57,134.4 ns |      - |         - |
| ListAsICollectionEnumerator  | 600     |     189,703.9 ns |     2,738.90 ns |      3,363.61 ns |     189,714.3 ns | 1.7090 |    4000 B |
| **ArrayIndexer**                 | **700**     |      **50,147.2 ns** |       **665.63 ns** |        **888.60 ns** |      **50,111.2 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 700     |     185,382.0 ns |     1,130.45 ns |      1,509.12 ns |     185,353.8 ns | 1.4648 |    3200 B |
| ListIndexer                  | 700     |      55,661.2 ns |       599.60 ns |        736.36 ns |      55,633.3 ns |      - |         - |
| ListEnumerator               | 700     |      65,609.4 ns |       297.76 ns |        365.68 ns |      65,702.5 ns |      - |         - |
| ListAsICollectionEnumerator  | 700     |     244,149.6 ns |     5,694.75 ns |      7,602.33 ns |     245,333.6 ns | 1.4648 |    4000 B |
| **ArrayIndexer**                 | **800**     |      **59,776.9 ns** |     **1,358.45 ns** |      **1,813.49 ns** |      **59,856.5 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 800     |     210,780.2 ns |     1,746.13 ns |      2,208.30 ns |     210,901.1 ns | 1.4648 |    3200 B |
| ListIndexer                  | 800     |      63,700.5 ns |       569.13 ns |        719.76 ns |      63,636.5 ns |      - |         - |
| ListEnumerator               | 800     |      75,218.9 ns |       380.94 ns |        467.83 ns |      75,266.9 ns |      - |         - |
| ListAsICollectionEnumerator  | 800     |     270,330.2 ns |     5,530.08 ns |      7,190.66 ns |     269,918.8 ns | 1.4648 |    4000 B |
| **ArrayIndexer**                 | **900**     |      **63,378.2 ns** |       **546.41 ns** |        **729.44 ns** |      **63,190.9 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 900     |     238,679.5 ns |     2,639.50 ns |      3,523.66 ns |     238,810.9 ns | 1.4648 |    3200 B |
| ListIndexer                  | 900     |      71,197.1 ns |       365.94 ns |        449.41 ns |      71,246.1 ns |      - |         - |
| ListEnumerator               | 900     |      84,278.2 ns |       821.05 ns |        977.40 ns |      84,144.5 ns |      - |         - |
| ListAsICollectionEnumerator  | 900     |     306,208.6 ns |     7,827.44 ns |     10,449.41 ns |     306,967.8 ns | 1.4648 |    4000 B |
| **ArrayIndexer**                 | **1000**    |      **70,070.5 ns** |       **421.88 ns** |        **563.20 ns** |      **70,088.0 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 1000    |     265,482.8 ns |     1,623.71 ns |      2,167.61 ns |     265,345.1 ns | 1.4648 |    3200 B |
| ListIndexer                  | 1000    |      79,305.3 ns |       770.08 ns |      1,001.32 ns |      79,284.2 ns |      - |         - |
| ListEnumerator               | 1000    |      95,031.4 ns |     1,584.73 ns |      2,115.57 ns |      94,457.1 ns |      - |         - |
| ListAsICollectionEnumerator  | 1000    |     310,972.2 ns |     4,512.63 ns |      5,867.69 ns |     308,878.6 ns | 1.4648 |    4000 B |
| **ArrayIndexer**                 | **2000**    |     **141,279.0 ns** |       **883.46 ns** |      **1,117.29 ns** |     **141,197.3 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 2000    |     525,603.1 ns |     2,973.61 ns |      3,866.53 ns |     525,717.7 ns | 0.9766 |    3200 B |
| ListIndexer                  | 2000    |     162,659.6 ns |     2,206.56 ns |      2,869.15 ns |     162,220.8 ns |      - |         - |
| ListEnumerator               | 2000    |     193,169.8 ns |     2,697.21 ns |      3,600.70 ns |     192,209.2 ns |      - |         - |
| ListAsICollectionEnumerator  | 2000    |     619,116.7 ns |     9,452.20 ns |     12,290.54 ns |     618,303.1 ns | 0.9766 |    4000 B |
| **ArrayIndexer**                 | **3000**    |     **216,984.9 ns** |     **3,220.39 ns** |      **4,299.13 ns** |     **216,459.7 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 3000    |     784,020.8 ns |     8,861.76 ns |     11,207.28 ns |     783,166.7 ns | 0.9766 |    3200 B |
| ListIndexer                  | 3000    |     241,834.8 ns |     1,203.96 ns |      1,607.25 ns |     241,593.4 ns |      - |         - |
| ListEnumerator               | 3000    |     286,220.2 ns |     2,366.01 ns |      3,076.48 ns |     286,771.9 ns |      - |         - |
| ListAsICollectionEnumerator  | 3000    |     967,380.8 ns |    17,455.08 ns |     23,302.03 ns |     963,011.4 ns | 0.9766 |    4000 B |
| **ArrayIndexer**                 | **4000**    |     **287,596.8 ns** |     **1,658.04 ns** |      **2,096.89 ns** |     **287,335.2 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 4000    |   1,048,101.1 ns |     6,524.31 ns |      8,709.77 ns |   1,049,897.9 ns |      - |    3201 B |
| ListIndexer                  | 4000    |     327,719.1 ns |     3,022.87 ns |      3,930.59 ns |     327,632.1 ns |      - |         - |
| ListEnumerator               | 4000    |     388,639.7 ns |     5,772.65 ns |      7,706.32 ns |     384,569.3 ns |      - |         - |
| ListAsICollectionEnumerator  | 4000    |   1,246,521.3 ns |    19,638.98 ns |     26,217.48 ns |   1,243,196.4 ns |      - |    4001 B |
| **ArrayIndexer**                 | **5000**    |     **380,857.8 ns** |     **2,283.40 ns** |      **2,804.22 ns** |     **381,156.1 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 5000    |   1,309,494.0 ns |     9,592.40 ns |     11,046.62 ns |   1,310,928.6 ns |      - |    3200 B |
| ListIndexer                  | 5000    |     471,496.0 ns |     4,348.03 ns |      5,653.67 ns |     472,321.7 ns |      - |         - |
| ListEnumerator               | 5000    |     542,392.6 ns |     3,626.94 ns |      4,716.04 ns |     543,019.6 ns |      - |         - |
| ListAsICollectionEnumerator  | 5000    |   1,547,510.4 ns |    28,921.61 ns |     38,609.53 ns |   1,540,071.7 ns |      - |    4000 B |
| **ArrayIndexer**                 | **6000**    |     **522,715.3 ns** |     **3,467.73 ns** |      **4,629.32 ns** |     **521,983.5 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 6000    |   1,606,307.8 ns |    23,399.45 ns |     30,425.89 ns |   1,596,945.9 ns |      - |    3201 B |
| ListIndexer                  | 6000    |     706,787.9 ns |     8,800.73 ns |     11,443.44 ns |     703,627.3 ns |      - |         - |
| ListEnumerator               | 6000    |     862,324.5 ns |    10,105.41 ns |     13,139.89 ns |     856,947.1 ns |      - |         - |
| ListAsICollectionEnumerator  | 6000    |   2,020,205.8 ns |    13,072.71 ns |     16,998.22 ns |   2,019,750.6 ns |      - |    4002 B |
| **ArrayIndexer**                 | **7000**    |     **791,213.4 ns** |    **12,373.54 ns** |     **15,195.82 ns** |     **786,585.5 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 7000    |   1,979,610.4 ns |    22,003.83 ns |     28,611.19 ns |   1,979,877.0 ns |      - |    3202 B |
| ListIndexer                  | 7000    |   1,061,778.5 ns |     6,848.05 ns |      9,141.95 ns |   1,061,214.3 ns |      - |       1 B |
| ListEnumerator               | 7000    |   1,088,649.9 ns |    10,261.45 ns |     13,698.75 ns |   1,087,572.2 ns |      - |       1 B |
| ListAsICollectionEnumerator  | 7000    |   2,430,289.4 ns |    20,970.29 ns |     26,520.71 ns |   2,427,117.8 ns |      - |    4002 B |
| **ArrayIndexer**                 | **8000**    |   **1,002,308.5 ns** |    **10,728.68 ns** |     **14,322.48 ns** |   **1,002,070.5 ns** |      **-** |         **-** |
| ArrayAsICollectionEnumerator | 8000    |   2,280,463.8 ns |    16,523.82 ns |     20,292.74 ns |   2,275,147.3 ns |      - |    3200 B |
| ListIndexer                  | 8000    |   1,294,768.0 ns |    12,066.29 ns |     16,108.15 ns |   1,292,198.0 ns |      - |       1 B |
| ListEnumerator               | 8000    |   1,285,877.6 ns |     8,876.49 ns |     11,849.86 ns |   1,285,861.0 ns |      - |       1 B |
| ListAsICollectionEnumerator  | 8000    |   2,752,769.0 ns |    30,052.17 ns |     39,076.31 ns |   2,752,197.7 ns |      - |    4002 B |
| **ArrayIndexer**                 | **9000**    |   **1,174,039.9 ns** |    **11,052.11 ns** |     **14,754.25 ns** |   **1,175,054.1 ns** |      **-** |       **1 B** |
| ArrayAsICollectionEnumerator | 9000    |   2,576,938.9 ns |    21,487.54 ns |     27,174.86 ns |   2,578,614.5 ns |      - |    3202 B |
| ListIndexer                  | 9000    |   1,493,799.0 ns |    11,364.73 ns |     14,372.75 ns |   1,489,102.1 ns |      - |       1 B |
| ListEnumerator               | 9000    |   1,468,312.2 ns |    13,521.03 ns |     18,050.19 ns |   1,465,792.1 ns |      - |       1 B |
| ListAsICollectionEnumerator  | 9000    |   3,145,465.6 ns |    24,443.41 ns |     30,018.71 ns |   3,153,948.2 ns |      - |    4002 B |
| **ArrayIndexer**                 | **10000**   |   **1,304,945.7 ns** |     **8,231.46 ns** |     **10,988.77 ns** |   **1,300,630.0 ns** |      **-** |       **1 B** |
| ArrayAsICollectionEnumerator | 10000   |   2,863,117.5 ns |    25,859.85 ns |     34,522.15 ns |   2,865,275.4 ns |      - |    3202 B |
| ListIndexer                  | 10000   |   1,656,538.2 ns |     7,967.00 ns |     10,075.70 ns |   1,654,436.1 ns |      - |       1 B |
| ListEnumerator               | 10000   |   1,656,845.9 ns |    19,788.42 ns |     25,026.01 ns |   1,649,443.5 ns |      - |       1 B |
| ListAsICollectionEnumerator  | 10000   |   3,748,149.0 ns |    74,043.46 ns |     90,932.02 ns |   3,727,004.3 ns |      - |    4000 B |
| **ArrayIndexer**                 | **20000**   |   **2,683,589.7 ns** |    **16,053.45 ns** |     **20,874.02 ns** |   **2,677,574.0 ns** |      **-** |       **2 B** |
| ArrayAsICollectionEnumerator | 20000   |   5,911,806.4 ns |    36,393.47 ns |     48,584.24 ns |   5,902,718.0 ns |      - |    3203 B |
| ListIndexer                  | 20000   |   3,351,571.1 ns |    14,334.80 ns |     17,064.56 ns |   3,351,829.3 ns |      - |       2 B |
| ListEnumerator               | 20000   |   3,367,646.5 ns |    31,854.26 ns |     39,119.90 ns |   3,358,329.5 ns |      - |       2 B |
| ListAsICollectionEnumerator  | 20000   |   8,147,562.8 ns |   127,632.23 ns |    161,413.92 ns |   8,127,809.4 ns |      - |    4006 B |
| **ArrayIndexer**                 | **30000**   |   **4,965,536.9 ns** |    **22,566.81 ns** |     **27,714.07 ns** |   **4,965,355.9 ns** |      **-** |       **3 B** |
| ArrayAsICollectionEnumerator | 30000   |  17,550,152.5 ns |   104,575.24 ns |    135,977.37 ns |  17,524,043.8 ns |      - |    3212 B |
| ListIndexer                  | 30000   |   8,763,540.2 ns |    54,254.82 ns |     62,479.93 ns |   8,766,454.7 ns |      - |       6 B |
| ListEnumerator               | 30000   |   9,619,747.4 ns |    82,068.53 ns |    106,712.28 ns |   9,599,672.7 ns |      - |       6 B |
| ListAsICollectionEnumerator  | 30000   |  19,972,106.8 ns |   164,999.96 ns |    208,672.13 ns |  20,004,003.1 ns |      - |    4012 B |
| **ArrayIndexer**                 | **40000**   |  **12,183,159.5 ns** |   **105,214.99 ns** |    **133,063.28 ns** |  **12,185,002.3 ns** |      **-** |       **6 B** |
| ArrayAsICollectionEnumerator | 40000   |  27,172,861.8 ns |   143,384.89 ns |    170,689.53 ns |  27,143,162.5 ns |      - |    3212 B |
| ListIndexer                  | 40000   |  18,858,845.2 ns |   110,502.02 ns |    147,517.03 ns |  18,820,162.5 ns |      - |      12 B |
| ListEnumerator               | 40000   |  21,974,811.4 ns |   131,797.45 ns |    175,945.83 ns |  21,910,254.7 ns |      - |      12 B |
| ListAsICollectionEnumerator  | 40000   |  34,739,400.0 ns |   374,302.07 ns |    459,676.59 ns |  34,548,166.7 ns |      - |    4027 B |
| **ArrayIndexer**                 | **50000**   |  **18,741,040.9 ns** |   **178,126.24 ns** |    **205,130.44 ns** |  **18,678,996.9 ns** |      **-** |      **12 B** |
| ArrayAsICollectionEnumerator | 50000   |  36,460,005.1 ns |   486,881.52 ns |    649,972.90 ns |  36,252,685.7 ns |      - |    3229 B |
| ListIndexer                  | 50000   |  25,750,662.8 ns |   198,003.00 ns |    264,328.33 ns |  25,772,362.5 ns |      - |      12 B |
| ListEnumerator               | 50000   |  30,438,974.6 ns |   131,313.35 ns |    156,319.22 ns |  30,416,612.5 ns |      - |      12 B |
| ListAsICollectionEnumerator  | 50000   |  46,980,201.4 ns |   120,833.31 ns |    139,151.82 ns |  46,967,354.5 ns |      - |    4036 B |
| **ArrayIndexer**                 | **60000**   |  **25,513,445.8 ns** |   **160,922.77 ns** |    **209,245.07 ns** |  **25,477,795.3 ns** |      **-** |      **12 B** |
| ArrayAsICollectionEnumerator | 60000   |  45,764,873.1 ns |   228,428.84 ns |    297,022.04 ns |  45,686,309.1 ns |      - |    3206 B |
| ListIndexer                  | 60000   |  32,483,111.7 ns |   139,834.62 ns |    181,824.52 ns |  32,493,400.0 ns |      - |      25 B |
| ListEnumerator               | 60000   |  37,938,928.9 ns |   194,884.23 ns |    253,404.57 ns |  37,864,203.6 ns |      - |      29 B |
| ListAsICollectionEnumerator  | 60000   |  59,467,173.5 ns |   217,293.22 ns |    258,672.15 ns |  59,375,755.6 ns |      - |    4044 B |
| **ArrayIndexer**                 | **70000**   |  **33,510,595.5 ns** |   **295,062.52 ns** |    **362,363.30 ns** |  **33,363,787.5 ns** |      **-** |      **25 B** |
| ArrayAsICollectionEnumerator | 70000   |  54,874,945.2 ns |   676,879.67 ns |    805,777.16 ns |  54,777,040.0 ns |      - |    3240 B |
| ListIndexer                  | 70000   |  38,566,581.1 ns |   160,332.48 ns |    202,769.27 ns |  38,506,235.7 ns |      - |      29 B |
| ListEnumerator               | 70000   |  44,873,512.6 ns |   163,951.47 ns |    207,346.13 ns |  44,815,327.3 ns |      - |      36 B |
| ListAsICollectionEnumerator  | 70000   |  70,543,980.2 ns |   305,262.58 ns |    396,927.62 ns |  70,439,600.0 ns |      - |    4050 B |
| **ArrayIndexer**                 | **80000**   |  **39,217,452.1 ns** |   **192,304.79 ns** |    **236,167.57 ns** |  **39,197,934.6 ns** |      **-** |      **31 B** |
| ArrayAsICollectionEnumerator | 80000   |  62,133,600.0 ns |   313,350.71 ns |    396,288.35 ns |  62,000,500.0 ns |      - |    3244 B |
| ListIndexer                  | 80000   |  44,778,104.2 ns |   440,597.22 ns |    572,900.89 ns |  44,451,987.5 ns |      - |      33 B |
| ListEnumerator               | 80000   |  51,681,081.7 ns |   476,487.10 ns |    602,603.67 ns |  51,400,130.0 ns |      - |      40 B |
| ListAsICollectionEnumerator  | 80000   |  80,038,000.0 ns |   436,887.47 ns |    536,537.09 ns |  79,915,942.9 ns |      - |    4057 B |
| **ArrayIndexer**                 | **90000**   |  **43,904,448.6 ns** |   **171,836.10 ns** |    **217,317.67 ns** |  **43,861,608.3 ns** |      **-** |      **33 B** |
| ArrayAsICollectionEnumerator | 90000   |  71,884,120.0 ns | 2,888,801.14 ns |  3,856,466.87 ns |  69,576,425.0 ns |      - |    3250 B |
| ListIndexer                  | 90000   |  49,879,745.5 ns |   154,902.50 ns |    195,902.09 ns |  49,791,518.2 ns |      - |       6 B |
| ListEnumerator               | 90000   |  58,054,399.0 ns |   362,436.20 ns |    458,365.79 ns |  57,944,155.6 ns |      - |      44 B |
| ListAsICollectionEnumerator  | 90000   |  92,033,124.6 ns |   975,278.63 ns |  1,233,415.30 ns |  91,893,500.0 ns |      - |    4067 B |
| **ArrayIndexer**                 | **100000**  |  **49,519,736.8 ns** |   **110,895.35 ns** |    **140,247.12 ns** |  **49,477,872.7 ns** |      **-** |      **36 B** |
| ArrayAsICollectionEnumerator | 100000  |  77,820,506.2 ns |   796,530.26 ns |  1,007,355.83 ns |  77,295,100.0 ns |      - |    3257 B |
| ListIndexer                  | 100000  |  56,027,434.2 ns |   258,089.68 ns |    326,400.83 ns |  55,978,600.0 ns |      - |      50 B |
| ListEnumerator               | 100000  |  64,784,626.7 ns |   228,087.50 ns |    280,111.96 ns |  64,718,312.5 ns |      - |      50 B |
| ListAsICollectionEnumerator  | 100000  | 101,740,088.7 ns |   588,122.32 ns |    743,786.49 ns | 101,577,960.0 ns |      - |    4080 B |
| **ArrayIndexer**                 | **200000**  |  **97,436,728.8 ns** |   **398,229.23 ns** |    **489,061.30 ns** |  **97,293,033.3 ns** |      **-** |      **67 B** |
| ArrayAsICollectionEnumerator | 200000  | 151,348,141.7 ns | 1,022,819.99 ns |  1,329,955.01 ns | 150,865,912.5 ns |      - |    3300 B |
| ListIndexer                  | 200000  | 111,092,156.5 ns |   697,182.94 ns |    881,713.26 ns | 110,817,680.0 ns |      - |      80 B |
| ListEnumerator               | 200000  | 128,222,560.0 ns |   730,753.51 ns |    975,535.03 ns | 127,926,900.0 ns |      - |     100 B |
| ListAsICollectionEnumerator  | 200000  | 203,192,547.8 ns | 1,873,554.76 ns |  2,369,447.09 ns | 202,895,433.3 ns |      - |    4133 B |
| **ArrayIndexer**                 | **300000**  | **145,715,953.0 ns** |   **675,742.32 ns** |    **902,096.66 ns** | **145,264,125.0 ns** |      **-** |     **100 B** |
| ArrayAsICollectionEnumerator | 300000  | 229,447,013.9 ns | 2,601,984.99 ns |  3,383,315.74 ns | 227,926,350.0 ns |      - |    3333 B |
| ListIndexer                  | 300000  | 168,020,567.9 ns | 2,195,088.73 ns |  2,613,097.21 ns | 167,260,375.0 ns |      - |     100 B |
| ListEnumerator               | 300000  | 191,410,262.5 ns |   891,551.19 ns |  1,159,268.48 ns | 190,987,783.3 ns |      - |     133 B |
| ListAsICollectionEnumerator  | 300000  | 299,104,830.0 ns | 2,776,988.30 ns |  3,707,199.93 ns | 297,737,500.0 ns |      - |    4200 B |
| **ArrayIndexer**                 | **400000**  | **195,979,494.2 ns** | **1,819,381.36 ns** |  **2,300,935.07 ns** | **194,976,966.7 ns** |      **-** |     **133 B** |
| ArrayAsICollectionEnumerator | 400000  | 302,822,618.0 ns | 1,926,513.43 ns |  2,571,840.31 ns | 302,663,750.0 ns |      - |    3400 B |
| ListIndexer                  | 400000  | 223,414,292.8 ns | 1,140,871.96 ns |  1,442,837.86 ns | 222,894,833.3 ns |      - |     133 B |
| ListEnumerator               | 400000  | 255,701,493.5 ns |   667,313.89 ns |    843,938.48 ns | 255,597,050.0 ns |      - |     200 B |
| ListAsICollectionEnumerator  | 400000  | 424,820,240.9 ns | 2,996,480.29 ns |  3,679,947.22 ns | 423,762,600.0 ns |      - |    4400 B |
| **ArrayIndexer**                 | **500000**  | **242,569,650.0 ns** | **1,055,155.55 ns** |  **1,256,087.74 ns** | **242,204,300.0 ns** |      **-** |     **200 B** |
| ArrayAsICollectionEnumerator | 500000  | 379,806,924.0 ns | 2,877,694.16 ns |  3,841,639.38 ns | 379,240,900.0 ns |      - |    3600 B |
| ListIndexer                  | 500000  | 288,019,893.2 ns | 1,284,877.95 ns |  1,577,945.65 ns | 287,534,525.0 ns |      - |     200 B |
| ListEnumerator               | 500000  | 320,488,334.8 ns | 1,915,885.29 ns |  2,422,981.66 ns | 319,869,500.0 ns |      - |     200 B |
| ListAsICollectionEnumerator  | 500000  | 541,314,108.7 ns | 2,503,707.12 ns |  3,166,388.13 ns | 540,026,400.0 ns |      - |    4400 B |
| **ArrayIndexer**                 | **600000**  | **290,618,045.7 ns** | **1,090,277.98 ns** |  **1,378,852.67 ns** | **290,016,050.0 ns** |      **-** |     **200 B** |
| ArrayAsICollectionEnumerator | 600000  | 464,705,154.5 ns | 1,709,847.68 ns |  2,099,846.69 ns | 463,938,400.0 ns |      - |    3600 B |
| ListIndexer                  | 600000  | 331,881,232.0 ns | 3,118,794.26 ns |  4,163,501.10 ns | 330,769,600.0 ns |      - |     200 B |
| ListEnumerator               | 600000  | 381,463,959.1 ns | 2,623,526.73 ns |  3,221,926.71 ns | 380,183,250.0 ns |      - |     400 B |
| ListAsICollectionEnumerator  | 600000  | 592,218,495.8 ns | 2,835,190.68 ns |  3,686,549.04 ns | 591,621,500.0 ns |      - |    4400 B |
| **ArrayIndexer**                 | **700000**  | **340,166,930.4 ns** | **1,437,871.82 ns** |  **1,818,447.62 ns** | **340,309,600.0 ns** |      **-** |     **400 B** |
| ArrayAsICollectionEnumerator | 700000  | 538,991,552.0 ns | 3,314,904.84 ns |  4,425,303.13 ns | 537,864,900.0 ns |      - |    3600 B |
| ListIndexer                  | 700000  | 385,194,141.7 ns | 1,660,209.70 ns |  2,158,741.75 ns | 384,424,450.0 ns |      - |     400 B |
| ListEnumerator               | 700000  | 445,186,040.9 ns | 4,238,281.62 ns |  5,204,990.91 ns | 443,414,100.0 ns |      - |     400 B |
| ListAsICollectionEnumerator  | 700000  | 698,206,462.5 ns | 7,018,988.76 ns |  9,126,668.79 ns | 697,020,350.0 ns |      - |    4400 B |
| **ArrayIndexer**                 | **800000**  | **389,705,982.6 ns** | **3,338,376.15 ns** |  **4,221,977.29 ns** | **387,980,100.0 ns** |      **-** |      **64 B** |
| ArrayAsICollectionEnumerator | 800000  | 614,363,739.1 ns | 2,972,163.85 ns |  3,758,835.95 ns | 613,659,100.0 ns |      - |    3600 B |
| ListIndexer                  | 800000  | 439,618,813.6 ns | 1,902,849.25 ns |  2,336,869.97 ns | 438,959,550.0 ns |      - |     400 B |
| ListEnumerator               | 800000  | 505,201,769.6 ns | 1,341,791.06 ns |  1,696,936.21 ns | 504,818,400.0 ns |      - |     400 B |
| ListAsICollectionEnumerator  | 800000  | 793,081,504.2 ns | 3,804,107.48 ns |  4,946,414.67 ns | 792,665,950.0 ns |      - |    4400 B |
| **ArrayIndexer**                 | **900000**  | **441,259,823.8 ns** | **1,123,743.93 ns** |  **1,337,737.33 ns** | **440,947,200.0 ns** |      **-** |     **400 B** |
| ArrayAsICollectionEnumerator | 900000  | 698,102,913.0 ns | 4,133,514.63 ns |  5,227,572.97 ns | 695,947,000.0 ns |      - |    3600 B |
| ListIndexer                  | 900000  | 494,266,573.9 ns | 3,044,792.69 ns |  3,850,688.19 ns | 492,721,600.0 ns |      - |     400 B |
| ListEnumerator               | 900000  | 570,671,739.1 ns | 5,358,600.70 ns |  6,776,914.72 ns | 567,568,900.0 ns |      - |     400 B |
| ListAsICollectionEnumerator  | 900000  | 887,816,745.8 ns | 6,307,279.19 ns |  8,201,245.23 ns | 883,874,250.0 ns |      - |    4400 B |
| **ArrayIndexer**                 | **1000000** | **485,931,452.2 ns** | **3,930,340.50 ns** |  **4,970,622.71 ns** | **483,384,800.0 ns** |      **-** |     **400 B** |
| ArrayAsICollectionEnumerator | 1000000 | 767,454,440.0 ns | 5,285,209.80 ns |  7,055,603.87 ns | 766,946,400.0 ns |      - |    3600 B |
| ListIndexer                  | 1000000 | 550,726,078.3 ns | 2,791,833.43 ns |  3,530,775.69 ns | 551,232,900.0 ns |      - |     400 B |
| ListEnumerator               | 1000000 | 631,996,466.7 ns | 2,697,994.97 ns |  3,508,155.85 ns | 631,333,300.0 ns |      - |     400 B |
| ListAsICollectionEnumerator  | 1000000 | 989,276,972.0 ns | 7,922,491.04 ns | 10,576,298.88 ns | 984,054,200.0 ns |      - |    4400 B |

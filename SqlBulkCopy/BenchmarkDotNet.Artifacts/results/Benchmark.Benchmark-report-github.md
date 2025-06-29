```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4351)
Unknown processor
.NET SDK 8.0.411
  [Host]     : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2
  Job-IMRJCE : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2

IterationCount=20  

```
| Method                 | N    |        Mean |      Error |     StdDev |    Ratio | RatioSD |     Gen0 |  Allocated | Alloc Ratio |
| ---------------------- | ---- | ----------: | ---------: | ---------: | -------: | ------: | -------: | ---------: | ----------: |
| InsertRowByRow         | 100  |   575.12 ms |   7.780 ms |   7.989 ms | baseline |         |        - |  179.53 KB |             |
| BulkCopyWithDataTable  | 100  |    12.64 ms |   0.199 ms |   0.196 ms |     -98% |    2.0% |  15.6250 |   60.74 KB |        -66% |
| BulkCopyWithDataReader | 100  |    12.60 ms |   0.476 ms |   0.529 ms |     -98% |    4.3% |        - |   15.22 KB |        -92% |
|                        |      |             |            |            |          |         |          |            |             |
| InsertRowByRow         | 200  | 1,167.78 ms |  42.934 ms |  47.721 ms | baseline |         |        - |  357.94 KB |             |
| BulkCopyWithDataTable  | 200  |    13.84 ms |   0.245 ms |   0.262 ms |     -99% |    4.3% |  31.2500 |  116.03 KB |        -68% |
| BulkCopyWithDataReader | 200  |    13.41 ms |   0.244 ms |   0.251 ms |     -99% |    4.3% |        - |   22.25 KB |        -94% |
|                        |      |             |            |            |          |         |          |            |             |
| InsertRowByRow         | 300  | 1,713.49 ms |  44.474 ms |  51.216 ms | baseline |         |        - |  536.06 KB |             |
| BulkCopyWithDataTable  | 300  |    27.62 ms |   1.561 ms |   1.798 ms |   -98.4% |    7.0% |  62.5000 |  166.45 KB |        -69% |
| BulkCopyWithDataReader | 300  |    14.06 ms |   0.473 ms |   0.486 ms |   -99.2% |    4.4% |        - |   29.28 KB |        -95% |
|                        |      |             |            |            |          |         |          |            |             |
| InsertRowByRow         | 400  | 2,280.06 ms |  62.087 ms |  63.759 ms | baseline |         |        - |  713.91 KB |             |
| BulkCopyWithDataTable  | 400  |    27.09 ms |   0.427 ms |   0.420 ms |   -98.8% |    3.1% |  93.7500 |  219.18 KB |        -69% |
| BulkCopyWithDataReader | 400  |    14.80 ms |   0.471 ms |   0.504 ms |   -99.4% |    4.3% |  15.6250 |   36.34 KB |        -95% |
|                        |      |             |            |            |          |         |          |            |             |
| InsertRowByRow         | 500  | 2,854.93 ms |  50.728 ms |  56.384 ms | baseline |         |        - |  892.31 KB |             |
| BulkCopyWithDataTable  | 500  |    28.00 ms |   0.763 ms |   0.816 ms |   -99.0% |    3.4% | 125.0000 |  259.06 KB |        -71% |
| BulkCopyWithDataReader | 500  |    16.37 ms |   1.078 ms |   1.242 ms |   -99.4% |    7.7% |        - |   43.37 KB |        -95% |
|                        |      |             |            |            |          |         |          |            |             |
| InsertRowByRow         | 600  | 3,414.65 ms |  71.096 ms |  79.023 ms | baseline |         |        - | 1070.44 KB |             |
| BulkCopyWithDataTable  | 600  |    41.07 ms |   0.808 ms |   0.864 ms |   -98.8% |    3.0% |  83.3333 |  312.21 KB |        -71% |
| BulkCopyWithDataReader | 600  |    16.03 ms |   0.282 ms |   0.289 ms |   -99.5% |    2.8% |        - |   50.41 KB |        -95% |
|                        |      |             |            |            |          |         |          |            |             |
| InsertRowByRow         | 700  | 3,985.33 ms |  83.986 ms |  96.719 ms | baseline |         |        - | 1248.56 KB |             |
| BulkCopyWithDataTable  | 700  |    41.01 ms |   0.657 ms |   0.675 ms |   -99.0% |    2.8% | 166.6667 |  362.32 KB |        -71% |
| BulkCopyWithDataReader | 700  |    17.89 ms |   1.550 ms |   1.784 ms |   -99.6% |   10.0% |        - |   57.43 KB |        -95% |
|                        |      |             |            |            |          |         |          |            |             |
| InsertRowByRow         | 800  | 4,567.05 ms | 125.906 ms | 139.944 ms | baseline |         |        - | 1426.41 KB |             |
| BulkCopyWithDataTable  | 800  |    53.92 ms |   0.936 ms |   0.961 ms |   -98.8% |    3.4% | 111.1111 |  412.63 KB |        -71% |
| BulkCopyWithDataReader | 800  |    17.05 ms |   0.220 ms |   0.226 ms |   -99.6% |    3.2% |  31.2500 |   64.47 KB |        -95% |
|                        |      |             |            |            |          |         |          |            |             |
| InsertRowByRow         | 1000 | 5,631.53 ms | 105.242 ms | 112.608 ms | baseline |         |        - | 1782.94 KB |             |
| BulkCopyWithDataTable  | 1000 |    55.98 ms |   1.191 ms |   1.275 ms |   -99.0% |    3.0% | 222.2222 |  505.37 KB |        -72% |
| BulkCopyWithDataReader | 1000 |    19.39 ms |   1.228 ms |   1.365 ms |   -99.7% |    7.1% |  31.2500 |   78.59 KB |        -96% |

```

BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.413
  [Host]     : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2
  Job-TJELOH : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2

InvocationCount=1  IterationCount=25  UnrollFactor=1  

```
| Method                                        | ResourceCount | Mean      | Error     | StdDev    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|---------------------------------------------- |-------------- |----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| BulkCopyNoIndex                               | 100000        |  99.13 ms |  8.758 ms |  11.69 ms | baseline |         |  93.47 KB |             |
| BulkCopyCloudProviderIndex                    | 100000        | 215.01 ms |  8.334 ms |  10.84 ms |    +120% |   12.3% |  96.23 KB |         +3% |
| BulkCopyCloudProviderAccountIndex             | 100000        | 418.57 ms | 55.765 ms |  74.45 ms |    +328% |   20.9% |   94.7 KB |         +1% |
| BulkCopyCloudProviderAccountResourceIndex     | 100000        | 723.97 ms | 16.913 ms |  21.99 ms |    +640% |   11.7% |  93.51 KB |         +0% |
| BulkCopyCloudProviderAccountResourceDateIndex | 100000        | 927.97 ms | 81.086 ms | 108.25 ms |    +848% |   16.1% |  93.45 KB |         -0% |
| BulkCopyThenCreateIndexes                     | 100000        | 436.25 ms | 18.649 ms |  24.90 ms |    +346% |   12.6% |   94.8 KB |         +1% |

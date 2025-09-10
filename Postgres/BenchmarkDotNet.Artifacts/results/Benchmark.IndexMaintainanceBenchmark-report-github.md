```

BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.413
  [Host]     : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2
  Job-POAUGD : .NET 8.0.19 (8.0.1925.36514), X64 RyuJIT AVX2

InvocationCount=1  IterationCount=25  UnrollFactor=1  

```
| Method      | ResourceCount | Mean      | Error    | StdDev    | Median    | Allocated |
|------------ |-------------- |----------:|---------:|----------:|----------:|----------:|
| DropIndex   | 100000        |  14.47 ms | 2.426 ms |  3.238 ms |  16.47 ms |   2.06 KB |
| CreateIndex | 100000        | 437.58 ms | 8.529 ms | 11.386 ms | 439.33 ms |   2.13 KB |

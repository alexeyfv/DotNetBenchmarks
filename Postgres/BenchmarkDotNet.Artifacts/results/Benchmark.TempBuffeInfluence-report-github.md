```

BenchmarkDotNet v0.14.0, Debian GNU/Linux 12 (bookworm)
AMD Ryzen 5 PRO 4650U with Radeon Graphics, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.414
  [Host]     : .NET 8.0.20 (8.0.2025.41914), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.20 (8.0.2025.41914), X64 RyuJIT AVX2


```
| Method   | CreateTable | TempBufferSize | Mean    | Error    | StdDev   |
|--------- |------------ |--------------- |--------:|---------:|---------:|
| **BulkCopy** | **regular**     | **1024**           | **3.689 s** | **0.0578 s** | **0.0513 s** |
| **BulkCopy** | **regular**     | **2048**           | **3.649 s** | **0.0517 s** | **0.0432 s** |
| **BulkCopy** | **regular**     | **4096**           | **3.679 s** | **0.0716 s** | **0.0670 s** |
| **BulkCopy** | **regular**     | **8192**           | **3.609 s** | **0.0222 s** | **0.0197 s** |
| **BulkCopy** | **regular**     | **16384**          | **3.625 s** | **0.0514 s** | **0.0481 s** |
| **BulkCopy** | **regular**     | **32768**          | **3.601 s** | **0.0337 s** | **0.0299 s** |
| **BulkCopy** | **regular**     | **65536**          | **3.613 s** | **0.0413 s** | **0.0386 s** |
| **BulkCopy** | **temp**        | **1024**           | **6.611 s** | **0.0207 s** | **0.0193 s** |
| **BulkCopy** | **temp**        | **2048**           | **4.864 s** | **0.0386 s** | **0.0361 s** |
| **BulkCopy** | **temp**        | **4096**           | **2.914 s** | **0.0163 s** | **0.0153 s** |
| **BulkCopy** | **temp**        | **8192**           | **2.909 s** | **0.0178 s** | **0.0158 s** |
| **BulkCopy** | **temp**        | **16384**          | **2.870 s** | **0.0132 s** | **0.0124 s** |
| **BulkCopy** | **temp**        | **32768**          | **2.855 s** | **0.0242 s** | **0.0227 s** |
| **BulkCopy** | **temp**        | **65536**          | **2.851 s** | **0.0188 s** | **0.0157 s** |
| **BulkCopy** | **unlogged**    | **1024**           | **3.064 s** | **0.0167 s** | **0.0139 s** |
| **BulkCopy** | **unlogged**    | **2048**           | **3.073 s** | **0.0138 s** | **0.0129 s** |
| **BulkCopy** | **unlogged**    | **4096**           | **3.052 s** | **0.0113 s** | **0.0105 s** |
| **BulkCopy** | **unlogged**    | **8192**           | **3.051 s** | **0.0117 s** | **0.0110 s** |
| **BulkCopy** | **unlogged**    | **16384**          | **3.065 s** | **0.0187 s** | **0.0174 s** |
| **BulkCopy** | **unlogged**    | **32768**          | **3.062 s** | **0.0180 s** | **0.0168 s** |
| **BulkCopy** | **unlogged**    | **65536**          | **3.064 s** | **0.0144 s** | **0.0135 s** |

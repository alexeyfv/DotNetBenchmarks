using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public partial class ExtractDataBenchmark
{
    public const int Length = 100_000;

    /* the benchmark body is generated from CodeGen project */
}

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public partial class CreateDictionaryBenchmark
{
    public const int Length = 100_000;

    /* the benchmark body is generated from CodeGen project */
}

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public partial class InitDictionaryBenchmark
{
    public const int Length = 100_000;

    /* the benchmark body is generated from CodeGen project */
}

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public partial class MutateBenchmark
{
    public const int Length = 100_000;

    /* the benchmark body is generated from CodeGen project */
}

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public partial class TotalBenchmark
{
    [Params(1, 25, 50, 75, 100)]
    public int Repeats { get; set; }
    public const int Length = 100_000;

    /* the benchmark body is generated from CodeGen project */
}

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public partial class TotalDictionaryOnlyBenchmark
{
    [Params(1, 25, 50, 75, 100)]
    public int Repeats { get; set; }
    public const int Length = 100_000;

    /* the benchmark body is generated from CodeGen project */
}
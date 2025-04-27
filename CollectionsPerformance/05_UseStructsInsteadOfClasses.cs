using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: IterationCount)]
public class UseStructsInsteadOfClasses : BenchmarkBase
{
    [ParamsSource(nameof(GetLengths))]
    public int Length { get; set; }

    [GlobalSetup]
    public void Setup() => InitCollections(Length);

    // Array of Structs
    private EntityStruct8[] entityStruct8 = [];
    private EntityStruct16[] entityStruct16 = [];
    private EntityStruct24[] entityStruct24 = [];
    private EntityStruct32[] entityStruct32 = [];
    private EntityStruct40[] entityStruct40 = [];
    private EntityStruct48[] entityStruct48 = [];
    private EntityStruct56[] entityStruct56 = [];
    private EntityStruct64[] entityStruct64 = [];
    private EntityStruct72[] entityStruct72 = [];
    private EntityStruct80[] entityStruct80 = [];

    // Array of Classes
    private EntityClass8[] entityClass8 = [];
    private EntityClass16[] entityClass16 = [];
    private EntityClass24[] entityClass24 = [];
    private EntityClass32[] entityClass32 = [];
    private EntityClass40[] entityClass40 = [];
    private EntityClass48[] entityClass48 = [];
    private EntityClass56[] entityClass56 = [];
    private EntityClass64[] entityClass64 = [];
    private EntityClass72[] entityClass72 = [];
    private EntityClass80[] entityClass80 = [];

    // Struct of Arrays
    private StructOfArrays8 structOfArrays8 = default!;
    private StructOfArrays16 structOfArrays16 = default!;
    private StructOfArrays24 structOfArrays24 = default!;
    private StructOfArrays32 structOfArrays32 = default!;
    private StructOfArrays40 structOfArrays40 = default!;
    private StructOfArrays48 structOfArrays48 = default!;
    private StructOfArrays56 structOfArrays56 = default!;
    private StructOfArrays64 structOfArrays64 = default!;
    private StructOfArrays72 structOfArrays72 = default!;
    private StructOfArrays80 structOfArrays80 = default!;

    [GlobalSetup(Targets =
    [
        nameof(InitializeEntityClass8),
        nameof(InitializeEntityClass16),
        nameof(InitializeEntityClass24),
        nameof(InitializeEntityClass32),
        nameof(InitializeEntityClass40),
        nameof(InitializeEntityClass48),
        nameof(InitializeEntityClass56),
        nameof(InitializeEntityClass64),
        nameof(InitializeEntityClass72),
        nameof(InitializeEntityClass80),
        nameof(InitializeEntityStruct8),
        nameof(InitializeEntityStruct16),
        nameof(InitializeEntityStruct24),
        nameof(InitializeEntityStruct32),
        nameof(InitializeEntityStruct40),
        nameof(InitializeEntityStruct48),
        nameof(InitializeEntityStruct56),
        nameof(InitializeEntityStruct64),
        nameof(InitializeEntityStruct72),
        nameof(InitializeEntityStruct80),
        nameof(InitializeStructOfArrays8),
        nameof(InitializeStructOfArrays16),
        nameof(InitializeStructOfArrays24),
        nameof(InitializeStructOfArrays32),
        nameof(InitializeStructOfArrays40),
        nameof(InitializeStructOfArrays48),
        nameof(InitializeStructOfArrays56),
        nameof(InitializeStructOfArrays64),
        nameof(InitializeStructOfArrays72),
        nameof(InitializeStructOfArrays80),
    ])]

    [BenchmarkCategory("Initialize", "8"), Benchmark(Baseline = true)]
    public int InitializeEntityClass8()
    {
        var arr = new EntityClass8[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass8(i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "16"), Benchmark(Baseline = true)]
    public int InitializeEntityClass16()
    {
        var arr = new EntityClass16[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass16(i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "24"), Benchmark(Baseline = true)]
    public int InitializeEntityClass24()
    {
        var arr = new EntityClass24[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass24(i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "32"), Benchmark(Baseline = true)]
    public int InitializeEntityClass32()
    {
        var arr = new EntityClass32[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass32(i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "40"), Benchmark(Baseline = true)]
    public int InitializeEntityClass40()
    {
        var arr = new EntityClass40[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass40(i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "48"), Benchmark(Baseline = true)]
    public int InitializeEntityClass48()
    {
        var arr = new EntityClass48[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass48(i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "56"), Benchmark(Baseline = true)]
    public int InitializeEntityClass56()
    {
        var arr = new EntityClass56[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass56(i, i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "64"), Benchmark(Baseline = true)]
    public int InitializeEntityClass64()
    {
        var arr = new EntityClass64[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass64(i, i, i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "72"), Benchmark(Baseline = true)]
    public int InitializeEntityClass72()
    {
        var arr = new EntityClass72[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass72(i, i, i, i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "80"), Benchmark(Baseline = true)]
    public int InitializeEntityClass80()
    {
        var arr = new EntityClass80[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityClass80(i, i, i, i, i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "8"), Benchmark]
    public int InitializeEntityStruct8()
    {
        var arr = new EntityStruct8[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct8(i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "16"), Benchmark]
    public int InitializeEntityStruct16()
    {
        var arr = new EntityStruct16[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct16(i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "24"), Benchmark]
    public int InitializeEntityStruct24()
    {
        var arr = new EntityStruct24[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct24(i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "32"), Benchmark]
    public int InitializeEntityStruct32()
    {
        var arr = new EntityStruct32[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct32(i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "40"), Benchmark]
    public int InitializeEntityStruct40()
    {
        var arr = new EntityStruct40[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct40(i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "48"), Benchmark]
    public int InitializeEntityStruct48()
    {
        var arr = new EntityStruct48[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct48(i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "56"), Benchmark]
    public int InitializeEntityStruct56()
    {
        var arr = new EntityStruct56[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct56(i, i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "64"), Benchmark]
    public int InitializeEntityStruct64()
    {
        var arr = new EntityStruct64[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct64(i, i, i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "72"), Benchmark]
    public int InitializeEntityStruct72()
    {
        var arr = new EntityStruct72[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct72(i, i, i, i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "80"), Benchmark]
    public int InitializeEntityStruct80()
    {
        var arr = new EntityStruct80[Length];
        for (var i = 0; i < arr.Length; i++) arr[i] = new EntityStruct80(i, i, i, i, i, i, i, i, i, i);
        return arr.Length;
    }

    [BenchmarkCategory("Initialize", "8"), Benchmark]
    public int InitializeStructOfArrays8()
    {
        var arr = new StructOfArrays8(new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        return arr.Value1.Length;
    }

    [BenchmarkCategory("Initialize", "16"), Benchmark]
    public int InitializeStructOfArrays16()
    {
        var arr = new StructOfArrays16(new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        for (var i = 0; i < Length; i++) arr.Value2[i] = i;
        return arr.Value1.Length;
    }

    [BenchmarkCategory("Initialize", "24"), Benchmark]
    public int InitializeStructOfArrays24()
    {
        var arr = new StructOfArrays24(new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        for (var i = 0; i < Length; i++) arr.Value2[i] = i;
        for (var i = 0; i < Length; i++) arr.Value3[i] = i;
        return arr.Value1.Length;
    }

    [BenchmarkCategory("Initialize", "32"), Benchmark]
    public int InitializeStructOfArrays32()
    {
        var arr = new StructOfArrays32(new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        for (var i = 0; i < Length; i++) arr.Value2[i] = i;
        for (var i = 0; i < Length; i++) arr.Value3[i] = i;
        for (var i = 0; i < Length; i++) arr.Value4[i] = i;
        return arr.Value1.Length;
    }

    [BenchmarkCategory("Initialize", "40"), Benchmark]
    public int InitializeStructOfArrays40()
    {
        var arr = new StructOfArrays40(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        for (var i = 0; i < Length; i++) arr.Value2[i] = i;
        for (var i = 0; i < Length; i++) arr.Value3[i] = i;
        for (var i = 0; i < Length; i++) arr.Value4[i] = i;
        for (var i = 0; i < Length; i++) arr.Value5[i] = i;
        return arr.Value1.Length;
    }

    [BenchmarkCategory("Initialize", "48"), Benchmark]
    public int InitializeStructOfArrays48()
    {
        var arr = new StructOfArrays48(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        for (var i = 0; i < Length; i++) arr.Value2[i] = i;
        for (var i = 0; i < Length; i++) arr.Value3[i] = i;
        for (var i = 0; i < Length; i++) arr.Value4[i] = i;
        for (var i = 0; i < Length; i++) arr.Value5[i] = i;
        for (var i = 0; i < Length; i++) arr.Value6[i] = i;
        return arr.Value1.Length;
    }

    [BenchmarkCategory("Initialize", "56"), Benchmark]
    public int InitializeStructOfArrays56()
    {
        var arr = new StructOfArrays56(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        for (var i = 0; i < Length; i++) arr.Value2[i] = i;
        for (var i = 0; i < Length; i++) arr.Value3[i] = i;
        for (var i = 0; i < Length; i++) arr.Value4[i] = i;
        for (var i = 0; i < Length; i++) arr.Value5[i] = i;
        for (var i = 0; i < Length; i++) arr.Value6[i] = i;
        for (var i = 0; i < Length; i++) arr.Value7[i] = i;
        return arr.Value1.Length;
    }

    [BenchmarkCategory("Initialize", "64"), Benchmark]
    public int InitializeStructOfArrays64()
    {
        var arr = new StructOfArrays64(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        for (var i = 0; i < Length; i++) arr.Value2[i] = i;
        for (var i = 0; i < Length; i++) arr.Value3[i] = i;
        for (var i = 0; i < Length; i++) arr.Value4[i] = i;
        for (var i = 0; i < Length; i++) arr.Value5[i] = i;
        for (var i = 0; i < Length; i++) arr.Value6[i] = i;
        for (var i = 0; i < Length; i++) arr.Value7[i] = i;
        for (var i = 0; i < Length; i++) arr.Value8[i] = i;
        return arr.Value1.Length;
    }

    [BenchmarkCategory("Initialize", "72"), Benchmark]
    public int InitializeStructOfArrays72()
    {
        var arr = new StructOfArrays72(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        for (var i = 0; i < Length; i++) arr.Value2[i] = i;
        for (var i = 0; i < Length; i++) arr.Value3[i] = i;
        for (var i = 0; i < Length; i++) arr.Value4[i] = i;
        for (var i = 0; i < Length; i++) arr.Value5[i] = i;
        for (var i = 0; i < Length; i++) arr.Value6[i] = i;
        for (var i = 0; i < Length; i++) arr.Value7[i] = i;
        for (var i = 0; i < Length; i++) arr.Value8[i] = i;
        for (var i = 0; i < Length; i++) arr.Value9[i] = i;
        return arr.Value1.Length;
    }

    [BenchmarkCategory("Initialize", "80"), Benchmark]
    public int InitializeStructOfArrays80()
    {
        var arr = new StructOfArrays80(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) arr.Value1[i] = i;
        for (var i = 0; i < Length; i++) arr.Value2[i] = i;
        for (var i = 0; i < Length; i++) arr.Value3[i] = i;
        for (var i = 0; i < Length; i++) arr.Value4[i] = i;
        for (var i = 0; i < Length; i++) arr.Value5[i] = i;
        for (var i = 0; i < Length; i++) arr.Value6[i] = i;
        for (var i = 0; i < Length; i++) arr.Value7[i] = i;
        for (var i = 0; i < Length; i++) arr.Value8[i] = i;
        for (var i = 0; i < Length; i++) arr.Value9[i] = i;
        for (var i = 0; i < Length; i++) arr.Value10[i] = i;
        return arr.Value1.Length;
    }

    [GlobalSetup(Targets =
    [
        nameof(EnumerateEntityClass8),
        nameof(EnumerateEntityClass16),
        nameof(EnumerateEntityClass24),
        nameof(EnumerateEntityClass32),
        nameof(EnumerateEntityClass40),
        nameof(EnumerateEntityClass48),
        nameof(EnumerateEntityClass56),
        nameof(EnumerateEntityClass64),
        nameof(EnumerateEntityClass72),
        nameof(EnumerateEntityClass80),
        nameof(EnumerateEntityStruct8),
        nameof(EnumerateEntityStruct16),
        nameof(EnumerateEntityStruct24),
        nameof(EnumerateEntityStruct32),
        nameof(EnumerateEntityStruct40),
        nameof(EnumerateEntityStruct48),
        nameof(EnumerateEntityStruct56),
        nameof(EnumerateEntityStruct64),
        nameof(EnumerateEntityStruct72),
        nameof(EnumerateEntityStruct80),
        nameof(EnumerateStructOfArrays8),
        nameof(EnumerateStructOfArrays16),
        nameof(EnumerateStructOfArrays24),
        nameof(EnumerateStructOfArrays32),
        nameof(EnumerateStructOfArrays40),
        nameof(EnumerateStructOfArrays48),
        nameof(EnumerateStructOfArrays56),
        nameof(EnumerateStructOfArrays64),
        nameof(EnumerateStructOfArrays72),
        nameof(EnumerateStructOfArrays80),
    ])
    ]
    public void SetupEnumerate()
    {
        entityStruct8 = new EntityStruct8[Length];
        for (var i = 0; i < Length; i++) entityStruct8[i] = new(i);

        entityStruct16 = new EntityStruct16[Length];
        for (var i = 0; i < Length; i++) entityStruct16[i] = new(i, i);

        entityStruct24 = new EntityStruct24[Length];
        for (var i = 0; i < Length; i++) entityStruct24[i] = new(i, i, i);

        entityStruct32 = new EntityStruct32[Length];
        for (var i = 0; i < Length; i++) entityStruct32[i] = new(i, i, i, i);

        entityStruct40 = new EntityStruct40[Length];
        for (var i = 0; i < Length; i++) entityStruct40[i] = new(i, i, i, i, i);

        entityStruct48 = new EntityStruct48[Length];
        for (var i = 0; i < Length; i++) entityStruct48[i] = new(i, i, i, i, i, i);

        entityStruct56 = new EntityStruct56[Length];
        for (var i = 0; i < Length; i++) entityStruct56[i] = new(i, i, i, i, i, i, i);

        entityStruct64 = new EntityStruct64[Length];
        for (var i = 0; i < Length; i++) entityStruct64[i] = new(i, i, i, i, i, i, i, i);

        entityStruct72 = new EntityStruct72[Length];
        for (var i = 0; i < Length; i++) entityStruct72[i] = new(i, i, i, i, i, i, i, i, i);

        entityStruct80 = new EntityStruct80[Length];
        for (var i = 0; i < Length; i++) entityStruct80[i] = new(i, i, i, i, i, i, i, i, i, i);

        entityClass8 = new EntityClass8[Length];
        for (var i = 0; i < Length; i++) entityClass8[i] = new(i);

        entityClass16 = new EntityClass16[Length];
        for (var i = 0; i < Length; i++) entityClass16[i] = new(i, i);

        entityClass24 = new EntityClass24[Length];
        for (var i = 0; i < Length; i++) entityClass24[i] = new(i, i, i);

        entityClass32 = new EntityClass32[Length];
        for (var i = 0; i < Length; i++) entityClass32[i] = new(i, i, i, i);

        entityClass40 = new EntityClass40[Length];
        for (var i = 0; i < Length; i++) entityClass40[i] = new(i, i, i, i, i);

        entityClass48 = new EntityClass48[Length];
        for (var i = 0; i < Length; i++) entityClass48[i] = new(i, i, i, i, i, i);

        entityClass56 = new EntityClass56[Length];
        for (var i = 0; i < Length; i++) entityClass56[i] = new(i, i, i, i, i, i, i);

        entityClass64 = new EntityClass64[Length];
        for (var i = 0; i < Length; i++) entityClass64[i] = new(i, i, i, i, i, i, i, i);

        entityClass72 = new EntityClass72[Length];
        for (var i = 0; i < Length; i++) entityClass72[i] = new(i, i, i, i, i, i, i, i, i);

        entityClass80 = new EntityClass80[Length];
        for (var i = 0; i < Length; i++) entityClass80[i] = new(i, i, i, i, i, i, i, i, i, i);

        structOfArrays8 = new StructOfArrays8(new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays8.Value1[i] = i;

        structOfArrays16 = new StructOfArrays16(new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays16.Value1[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays16.Value2[i] = i;

        structOfArrays24 = new StructOfArrays24(new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays24.Value1[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays24.Value2[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays24.Value3[i] = i;

        structOfArrays32 = new StructOfArrays32(new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays32.Value1[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays32.Value2[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays32.Value3[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays32.Value4[i] = i;

        structOfArrays40 = new StructOfArrays40(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays40.Value1[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays40.Value2[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays40.Value3[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays40.Value4[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays40.Value5[i] = i;

        structOfArrays48 = new StructOfArrays48(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays48.Value1[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays48.Value2[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays48.Value3[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays48.Value4[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays48.Value5[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays48.Value6[i] = i;

        structOfArrays56 = new StructOfArrays56(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays56.Value1[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays56.Value2[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays56.Value3[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays56.Value4[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays56.Value5[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays56.Value6[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays56.Value7[i] = i;

        structOfArrays64 = new StructOfArrays64(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays64.Value1[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays64.Value2[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays64.Value3[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays64.Value4[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays64.Value5[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays64.Value6[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays64.Value7[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays64.Value8[i] = i;

        structOfArrays72 = new StructOfArrays72(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays72.Value1[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays72.Value2[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays72.Value3[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays72.Value4[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays72.Value5[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays72.Value6[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays72.Value7[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays72.Value8[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays72.Value9[i] = i;

        structOfArrays80 = new StructOfArrays80(new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length], new long[Length]);
        for (var i = 0; i < Length; i++) structOfArrays80.Value1[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays80.Value2[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays80.Value3[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays80.Value4[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays80.Value5[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays80.Value6[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays80.Value7[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays80.Value8[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays80.Value9[i] = i;
        for (var i = 0; i < Length; i++) structOfArrays80.Value10[i] = i;
    }

    [BenchmarkCategory("Enumerate", "8"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass8()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass8.Length; i++) sum += entityClass8[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "16"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass16()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass16.Length; i++) sum += entityClass16[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "24"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass24()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass24.Length; i++) sum += entityClass24[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "32"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass32()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass32.Length; i++) sum += entityClass32[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "40"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass40()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass40.Length; i++) sum += entityClass40[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "48"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass48()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass48.Length; i++) sum += entityClass48[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "56"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass56()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass56.Length; i++) sum += entityClass56[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "64"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass64()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass64.Length; i++) sum += entityClass64[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "72"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass72()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass72.Length; i++) sum += entityClass72[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "80"), Benchmark(Baseline = true)]
    public long EnumerateEntityClass80()
    {
        var sum = 0L;
        for (var i = 0; i < entityClass80.Length; i++) sum += entityClass80[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "8"), Benchmark]
    public long EnumerateEntityStruct8()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct8.Length; i++) sum += entityStruct8[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "16"), Benchmark]
    public long EnumerateEntityStruct16()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct16.Length; i++) sum += entityStruct16[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "24"), Benchmark]
    public long EnumerateEntityStruct24()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct24.Length; i++) sum += entityStruct24[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "32"), Benchmark]
    public long EnumerateEntityStruct32()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct32.Length; i++) sum += entityStruct32[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "40"), Benchmark]
    public long EnumerateEntityStruct40()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct40.Length; i++) sum += entityStruct40[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "48"), Benchmark]
    public long EnumerateEntityStruct48()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct48.Length; i++) sum += entityStruct48[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "56"), Benchmark]
    public long EnumerateEntityStruct56()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct56.Length; i++) sum += entityStruct56[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "64"), Benchmark]
    public long EnumerateEntityStruct64()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct64.Length; i++) sum += entityStruct64[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "72"), Benchmark]
    public long EnumerateEntityStruct72()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct72.Length; i++) sum += entityStruct72[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "80"), Benchmark]
    public long EnumerateEntityStruct80()
    {
        var sum = 0L;
        for (var i = 0; i < entityStruct80.Length; i++) sum += entityStruct80[i].Value1;
        return sum;
    }

    [BenchmarkCategory("Enumerate", "8"), Benchmark]
    public long EnumerateStructOfArrays8()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays8.Value1.Length; i++) sum += structOfArrays8.Value1[i];
        return sum;
    }

    [BenchmarkCategory("Enumerate", "16"), Benchmark]
    public long EnumerateStructOfArrays16()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays16.Value1.Length; i++) sum += structOfArrays16.Value1[i];
        return sum;
    }

    [BenchmarkCategory("Enumerate", "24"), Benchmark]
    public long EnumerateStructOfArrays24()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays24.Value1.Length; i++) sum += structOfArrays24.Value1[i];
        return sum;
    }

    [BenchmarkCategory("Enumerate", "32"), Benchmark]
    public long EnumerateStructOfArrays32()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays32.Value1.Length; i++) sum += structOfArrays32.Value1[i];
        return sum;
    }

    [BenchmarkCategory("Enumerate", "40"), Benchmark]
    public long EnumerateStructOfArrays40()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays40.Value1.Length; i++) sum += structOfArrays40.Value1[i];
        return sum;
    }

    [BenchmarkCategory("Enumerate", "48"), Benchmark]
    public long EnumerateStructOfArrays48()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays48.Value1.Length; i++) sum += structOfArrays48.Value1[i];
        return sum;
    }

    [BenchmarkCategory("Enumerate", "56"), Benchmark]
    public long EnumerateStructOfArrays56()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays56.Value1.Length; i++) sum += structOfArrays56.Value1[i];
        return sum;
    }

    [BenchmarkCategory("Enumerate", "64"), Benchmark]
    public long EnumerateStructOfArrays64()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays64.Value1.Length; i++) sum += structOfArrays64.Value1[i];
        return sum;
    }

    [BenchmarkCategory("Enumerate", "72"), Benchmark]
    public long EnumerateStructOfArrays72()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays72.Value1.Length; i++) sum += structOfArrays72.Value1[i];
        return sum;
    }

    [BenchmarkCategory("Enumerate", "80"), Benchmark]
    public long EnumerateStructOfArrays80()
    {
        var sum = 0L;
        for (var i = 0; i < structOfArrays80.Value1.Length; i++) sum += structOfArrays80.Value1[i];
        return sum;
    }

    public record struct EntityStruct8(long Value1);
    public record struct EntityStruct16(long Value1, long Value2);
    public record struct EntityStruct24(long Value1, long Value2, long Value3);
    public record struct EntityStruct32(long Value1, long Value2, long Value3, long Value4);
    public record struct EntityStruct40(long Value1, long Value2, long Value3, long Value4, long Value5);
    public record struct EntityStruct48(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6);
    public record struct EntityStruct56(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6, long Value7);
    public record struct EntityStruct64(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6, long Value7, long Value8);
    public record struct EntityStruct72(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6, long Value7, long Value8, long Value9);
    public record struct EntityStruct80(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6, long Value7, long Value8, long Value9, long Value10);

    public record class EntityClass8(long Value1);
    public record class EntityClass16(long Value1, long Value2);
    public record class EntityClass24(long Value1, long Value2, long Value3);
    public record class EntityClass32(long Value1, long Value2, long Value3, long Value4);
    public record class EntityClass40(long Value1, long Value2, long Value3, long Value4, long Value5);
    public record class EntityClass48(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6);
    public record class EntityClass56(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6, long Value7);
    public record class EntityClass64(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6, long Value7, long Value8);
    public record class EntityClass72(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6, long Value7, long Value8, long Value9);
    public record class EntityClass80(long Value1, long Value2, long Value3, long Value4, long Value5, long Value6, long Value7, long Value8, long Value9, long Value10);

    public record class StructOfArrays8(long[] Value1);
    public record class StructOfArrays16(long[] Value1, long[] Value2);
    public record class StructOfArrays24(long[] Value1, long[] Value2, long[] Value3);
    public record class StructOfArrays32(long[] Value1, long[] Value2, long[] Value3, long[] Value4);
    public record class StructOfArrays40(long[] Value1, long[] Value2, long[] Value3, long[] Value4, long[] Value5);
    public record class StructOfArrays48(long[] Value1, long[] Value2, long[] Value3, long[] Value4, long[] Value5, long[] Value6);
    public record class StructOfArrays56(long[] Value1, long[] Value2, long[] Value3, long[] Value4, long[] Value5, long[] Value6, long[] Value7);
    public record class StructOfArrays64(long[] Value1, long[] Value2, long[] Value3, long[] Value4, long[] Value5, long[] Value6, long[] Value7, long[] Value8);
    public record class StructOfArrays72(long[] Value1, long[] Value2, long[] Value3, long[] Value4, long[] Value5, long[] Value6, long[] Value7, long[] Value8, long[] Value9);
    public record class StructOfArrays80(long[] Value1, long[] Value2, long[] Value3, long[] Value4, long[] Value5, long[] Value6, long[] Value7, long[] Value8, long[] Value9, long[] Value10);
}

using System.Text;
using Microsoft.CodeAnalysis;

namespace CodeGen
{
    [Generator]
    public class SourceGenerator : ISourceGenerator
    {
        private readonly int _count = 32; // number of properties

        public void Execute(GeneratorExecutionContext context)
        {
            GenerateEntities(context);
            GenerateExtractDataBenchmark(context);
            GenerateCreateDictionaryBenchmark(context);
            GenerateInitDictionaryBenchmark(context);
            GenerateMutateDataBenchmark(context);
            GenerateTotalBenchmark(context);
            GenerateTotalDictionaryOnlyBenchmark(context);
        }

        private void GenerateEntities(GeneratorExecutionContext context)
        {
            var sb = new StringBuilder();
            var sbProps = new StringBuilder();
            var sbCtor = new StringBuilder();
            var sbDoWork = new StringBuilder();

            sb.AppendLine(_headerTemplate);

            for (var i = 1; i < _count + 1; i++)
            {
                for (var j = 1; j < i + 1; j++)
                {
                    // props
                    sbProps.AppendFormat("    public int Prop{0} {{ get; set; }}", j).AppendLine();
                    // ctor
                    sbCtor.AppendFormat("        Prop{0} = i + {0};", j).AppendLine();
                    // do wordk
                    sbDoWork.AppendFormat("        Prop{0} += i + {0};", j).AppendLine();
                }

                sb.AppendFormat(_entityTempltate, "class", "Class", i, sbProps, sbCtor, sbDoWork);
                sb.AppendFormat(_entityTempltate, "struct", "Struct", i, sbProps, sbCtor, sbDoWork);
                sbProps.Clear();
                sbCtor.Clear();
                sbDoWork.Clear();
            }

            context.AddSource($"Entities.g.cs", sb.ToString());
        }

        private void GenerateExtractDataBenchmark(GeneratorExecutionContext context)
        {
            var sbBenchmarks = new StringBuilder();

            for (int i = 1; i < _count + 1; i++)
            {
                sbBenchmarks.AppendFormat(_extractDataBenchmarkTemplate, "Class", i).AppendLine();
                sbBenchmarks.AppendFormat(_extractDataBenchmarkTemplate, "Struct", i).AppendLine();
            }

            context.AddSource($"ExtractDataBenchmark.g.cs",
                string.Format(
                    _benchmarkClassTemplate,
                    "ExtractData",
                    string.Empty,
                    sbBenchmarks));
        }

        private void GenerateCreateDictionaryBenchmark(GeneratorExecutionContext context)
        {
            var sbBenchmarks = new StringBuilder();

            for (int i = 1; i < _count + 1; i++)
            {
                sbBenchmarks.AppendFormat(_createDictionaryBenchmarkTemplate, "Class", i).AppendLine();
                sbBenchmarks.AppendFormat(_createDictionaryBenchmarkTemplate, "Struct", i).AppendLine();
            }

            context.AddSource($"CreateDictionaryBenchmark.g.cs",
                string.Format(
                    _benchmarkClassTemplate,
                    "CreateDictionary",
                    string.Empty,
                    sbBenchmarks));
        }

        private void GenerateInitDictionaryBenchmark(GeneratorExecutionContext context)
        {
            var sbGlobalSetup = new StringBuilder();
            var sbBenchmarks = new StringBuilder();

            for (int i = 1; i < _count + 1; i++)
            {
                sbGlobalSetup.AppendFormat("        for (var i = 0; i < Length; i++) _arrayClass{0}[i] = new(i);", i).AppendLine();
                sbGlobalSetup.AppendFormat("        for (var i = 0; i < Length; i++) _arrayStruct{0}[i] = new(i);", i).AppendLine();
                sbBenchmarks.AppendFormat(_initDictionaryBenchmarkTemplate, "Class", i).AppendLine();
                sbBenchmarks.AppendFormat(_initDictionaryBenchmarkTemplate, "Struct", i).AppendLine();
            }

            context.AddSource($"InitDictionaryBenchmark.g.cs",
                string.Format(
                    _benchmarkClassTemplate,
                    "InitDictionary",
                    sbGlobalSetup,
                    sbBenchmarks));
        }

        private void GenerateMutateDataBenchmark(GeneratorExecutionContext context)
        {
            var sbGlobalSetup = new StringBuilder();
            var sbBenchmarks = new StringBuilder();

            for (var i = 1; i < _count + 1; i++)
            {
                sbGlobalSetup.AppendFormat("        for (var i = 0; i < Length; i++) _dictClass{0}.Add(i, new(i));", i).AppendLine();
                sbGlobalSetup.AppendFormat("        for (var i = 0; i < Length; i++) _dictStruct{0}.Add(i, new(i));", i).AppendLine();
            }

            for (int i = 1; i < _count + 1; i++)
            {
                sbBenchmarks.AppendFormat(_mutateBenchmarkTemplate, i).AppendLine();
            }

            context.AddSource($"MutateBenchmark.g.cs",
                string.Format(
                    _benchmarkClassTemplate,
                    "Mutate",
                    sbGlobalSetup,
                    sbBenchmarks));

        }

        private void GenerateTotalBenchmark(GeneratorExecutionContext context)
        {
            var sbBenchmarks = new StringBuilder();

            for (int i = 1; i < _count + 1; i++)
            {
                sbBenchmarks.AppendFormat(_totalBenchmarkTemplate, i).AppendLine();
            }

            context.AddSource($"TotalBenchmark.g.cs",
                string.Format(
                    _benchmarkClassTemplate,
                    "Total",
                    string.Empty,
                    sbBenchmarks));
        }

        private void GenerateTotalDictionaryOnlyBenchmark(GeneratorExecutionContext context)
        {
            var sbBenchmarks = new StringBuilder();
            var sbGlobalSetup = new StringBuilder();

            for (int i = 1; i < _count + 1; i++)
            {
                sbBenchmarks.AppendFormat(_totalDictionaryOnlyBenchmarkTemplate, i).AppendLine();
                sbGlobalSetup.AppendFormat("        for (var i = 0; i < Length; i++) _arrayClass{0}[i] = new(i);", i).AppendLine();
                sbGlobalSetup.AppendFormat("        for (var i = 0; i < Length; i++) _arrayStruct{0}[i] = new(i);", i).AppendLine();
            }

            context.AddSource($"TotalDictionaryOnlyBenchmark.g.cs",
                string.Format(
                    _benchmarkClassTemplate,
                    "TotalDictionaryOnly",
                    sbGlobalSetup,
                    sbBenchmarks));
        }

        public void Initialize(GeneratorInitializationContext context) { }

        private readonly string _headerTemplate =
@"// <auto-generated/>
using System.Runtime.CompilerServices;

namespace Benchmark;";

        private readonly string _entityTempltate =
@"
public {0} {1}{2}
{{
{3}

    public {1}{2}(int i)
    {{
{4}
    }}

    public void DoWork(int i)
    {{
{5}
    }}

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void DoWorkNoInlining(int i)
    {{
{5}
    }}
}}";


        private readonly string _benchmarkClassTemplate =
@"// <auto-generated/>
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

public partial class {0}Benchmark
{{
    [GlobalSetup]
    public void Setup()
    {{
{1}
    }}

{2}
}}";

        private readonly string _extractDataBenchmarkTemplate =
@"
    [Benchmark]
    [BenchmarkCategory(""{1}"")]
    public {0}{1}[] {0}{1}ExtractData()
    {{
        return Enumerable
            .Range(0, Length)
            .Select(i => new {0}{1}(i))
            .ToArray();
    }}";

        private readonly string _createDictionaryBenchmarkTemplate =
@"    Dictionary<int, {0}{1}> _dict{0}{1} = new(Length);
    {0}{1}[] _array{0}{1} = new {0}{1}[Length];

    [Benchmark]
    [BenchmarkCategory(""{1}"")]
    public Dictionary<int, {0}{1}> {0}{1}DictCreate()
    {{
        _dict{0}{1} = new(Length);
        return _dict{0}{1};
    }}";

        private readonly string _initDictionaryBenchmarkTemplate =
@"    Dictionary<int, {0}{1}> _dict{0}{1} = new(Length);
    {0}{1}[] _array{0}{1} = new {0}{1}[Length];

    [Benchmark]
    [BenchmarkCategory(""{1}"")]
    public Dictionary<int, {0}{1}> {0}{1}DictInit()
    {{
        // Simulate initializing the dictionary
        _dict{0}{1}.Clear();
        for (var i = 0; i < Length; i++)
        {{
            var obj = _array{0}{1}[i];
            _dict{0}{1}.Add(i, obj);
        }}

        return _dict{0}{1};
    }}";

        private readonly string _mutateBenchmarkTemplate =
@"    
    Dictionary<int, Class{0}> _dictClass{0} = new(Length);
    Class{0}[] _arrayClass{0} = new Class{0}[Length];

    [Benchmark]
    [BenchmarkCategory(""{0}"")]
    public Dictionary<int, Class{0}> MutateClass{0}()
    {{
        for (int i = 0; i < Length; i++)
        {{
            _dictClass{0}[i].DoWork(i);
        }}

        return _dictClass{0};
    }}

    Dictionary<int, Struct{0}> _dictStruct{0} = new(Length);
    Struct{0}[] _arrayStruct{0} = new Struct{0}[Length];

    [Benchmark]
    [BenchmarkCategory(""{0}"")]
    public Dictionary<int, Struct{0}> MutateStruct{0}()
    {{
        for (int i = 0; i < Length; i++)
        {{
            var obj = _dictStruct{0}[i];
            obj.DoWork(i);
            _dictStruct{0}[i] = obj;
        }}

        return _dictStruct{0};
    }}

    [Benchmark]
    [BenchmarkCategory(""{0}"")]
    public Dictionary<int, Struct{0}> MutateStruct{0}CollectionsMarshal()
    {{
        for (int i = 0; i < Length; i++)
        {{
            ref Struct{0} obj = ref CollectionsMarshal.GetValueRefOrNullRef(_dictStruct{0}, i);
            obj.DoWork(i);
        }}

        return _dictStruct{0};
    }}";

        private readonly string _totalBenchmarkTemplate =
@"
    [Benchmark]
    [BenchmarkCategory(""{0}"")]
    public Dictionary<int, Class{0}> TotalClass{0}()
    {{
        var data = Enumerable
            .Range(0, Length)
            .Select(i => (i, new Class{0}(i)));

        // Array creation
        var dict = new Dictionary<int, Class{0}>(Length);
        
        // Populate the data
        foreach (var (i, obj) in data)
        {{
            dict.Add(i, obj);
        }}

        // Mutate the data
        for (var j = 0; j < Repeats; j++)
        {{
            for (int i = 0; i < Length; i++)
            {{
                dict[i].DoWork(i);
            }}
        }}

        return dict;
    }}

    Dictionary<int, Struct{0}> _dictStruct{0} = new(Length);
    Struct{0}[] _arrayStruct{0} = new Struct{0}[Length];

    [Benchmark]
    [BenchmarkCategory(""{0}"")]
    public Dictionary<int, Struct{0}> TotalStruct{0}()
    {{
        var data = Enumerable
            .Range(0, Length)
            .Select(i => (i, new Struct{0}(i)));

        // Array creation
        var dict = new Dictionary<int, Struct{0}>(Length);
        
        // Populate the data
        foreach (var (i, obj) in data)
        {{
            dict.Add(i, obj);
        }}

        // Mutate the data
        for (var j = 0; j < Repeats; j++)
        {{
            for (int i = 0; i < Length; i++)
            {{
                var obj = dict[i];
                obj.DoWork(i);
                dict[i] = obj;
            }}
        }}

        return dict;
    }}

    [Benchmark]
    [BenchmarkCategory(""{0}"")]
    public Dictionary<int, Struct{0}> TotalStruct{0}CollectionsMarshal()
    {{
        var data = Enumerable
            .Range(0, Length)
            .Select(i => (i, new Struct{0}(i)));
            
        // Array creation
        var dict = new Dictionary<int, Struct{0}>(Length);
        
        // Populate the data
        foreach (var (i, obj) in data)
        {{
            dict.Add(i, obj);
        }}

        // Mutate the data        
        for (var j = 0; j < Repeats; j++)
        {{
            for (int i = 0; i < Length; i++)
            {{
                ref Struct{0} obj = ref CollectionsMarshal.GetValueRefOrNullRef(dict, i);
                obj.DoWork(i);
            }}
        }}

        return dict;
    }}";

        private readonly string _totalDictionaryOnlyBenchmarkTemplate =
@"
    Class{0}[] _arrayClass{0} = new Class{0}[Length];

    [Benchmark]
    [BenchmarkCategory(""{0}"")]
    public Dictionary<int, Class{0}> TotalClass{0}()
    {{
        // Array creation
        var dict = new Dictionary<int, Class{0}>(Length);
        
        // Populate the data
        for (var i = 0; i < Length; i++)
        {{
            var obj = _arrayClass{0}[i];
            dict.Add(i, obj);
        }}

        // Mutate the data
        for (var j = 0; j < Repeats; j++)
        {{
            for (int i = 0; i < Length; i++)
            {{
                dict[i].DoWork(i);
            }}
        }}

        return dict;
    }}

    Struct{0}[] _arrayStruct{0} = new Struct{0}[Length];

    [Benchmark]
    [BenchmarkCategory(""{0}"")]
    public Dictionary<int, Struct{0}> TotalStruct{0}()
    {{
        // Array creation
        var dict = new Dictionary<int, Struct{0}>(Length);
        
        // Populate the data
        for (var i = 0; i < Length; i++)
        {{
            var obj = _arrayStruct{0}[i];
            dict.Add(i, obj);
        }}

        // Mutate the data
        for (var j = 0; j < Repeats; j++)
        {{
            for (int i = 0; i < Length; i++)
            {{
                var obj = dict[i];
                obj.DoWork(i);
                dict[i] = obj;
            }}
        }}

        return dict;
    }}

    [Benchmark]
    [BenchmarkCategory(""{0}"")]
    public Dictionary<int, Struct{0}> TotalStruct{0}CollectionsMarshal()
    {{
        // Array creation
        var dict = new Dictionary<int, Struct{0}>(Length);
        
        // Populate the data
        for (var i = 0; i < Length; i++)
        {{
            var obj = _arrayStruct{0}[i];
            dict.Add(i, obj);
        }}

        // Mutate the data        
        for (var j = 0; j < Repeats; j++)
        {{
            for (int i = 0; i < Length; i++)
            {{
                ref Struct{0} obj = ref CollectionsMarshal.GetValueRefOrNullRef(dict, i);
                obj.DoWork(i);
            }}
        }}

        return dict;
    }}";

    }
}
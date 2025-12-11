using System.Text.Json;

namespace Benchmark;

public class BenchmarkMetadata
{
    private readonly string _directory = Path.Combine(Path.GetTempPath(), "HybridCacheBenchmark");
    private Dictionary<string, SortedList<int, object>> _metadata = [];
    private int _index = 0;

    public static BenchmarkMetadata Instance { get; } = new();


    public void Load(string benchmarkName)
    {
        if (!Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory);
        }

        string fileName = Path.Combine(_directory, $"{benchmarkName}.json");

        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            _metadata = JsonSerializer.Deserialize<Dictionary<string, SortedList<int, object>>>(json) ?? [];
        }
        else
        {
            _metadata = [];
        }

        _index = 0; // Reset index for each benchmark
    }

    public void Save(string benchmarkName)
    {
        if (!Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory);
        }

        string fileName = Path.Combine(_directory, $"{benchmarkName}.json");
        string json = JsonSerializer.Serialize(_metadata);
        File.WriteAllText(fileName, json);
    }

    public void AddMetadata(string name, object value)
    {
        if (!_metadata.TryGetValue(name, out SortedList<int, object>? cached))
        {
            cached = [];
            _metadata[name] = cached;
        }

        cached.Add(_index++, value);
    }

    public SortedList<int, object>? GetMetadata(string name)
    {
        if (_metadata.TryGetValue(name, out var values))
        {
            return values;
        }

        return null;
    }
}

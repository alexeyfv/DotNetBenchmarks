using System.Data;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.Data.SqlClient;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public class Benchmark
{
    [Params(100, 200, 300, 400, 500, 600, 700, 800, 1000)]
    public int N = 100;

    private const string ConnectionString = "Server=localhost,1433;Database=master;User Id=sa;Password=qweQWE123!;TrustServerCertificate=True;";
    private Row[] _arr = [];

    [GlobalSetup]
    public void GlobalSetup()
    {
        // Initialize array
        _arr = new Row[N];

        for (int i = 0; i < N; i++)
        {
            _arr[i] = new Row(i, i * 2, i * 3);
        }

        // Create table
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();
        cmd.CommandText =
        """
        DROP TABLE IF EXISTS BenchmarkRows;
        CREATE TABLE BenchmarkRows (
            a INT NOT NULL,
            b INT NOT NULL,
            c INT NOT NULL
        );
        """;
        cmd.ExecuteNonQuery();
    }

    [Benchmark(Baseline = true)]
    public void InsertRowByRow()
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        foreach (var row in _arr)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO BenchmarkRows (a, b, c) VALUES (@a, @b, @c);";
            cmd.Parameters.AddWithValue("@a", row.A);
            cmd.Parameters.AddWithValue("@b", row.B);
            cmd.Parameters.AddWithValue("@c", row.C);
            cmd.ExecuteNonQuery();
        }
    }

    [Benchmark]
    public void BulkCopyWithDataTable()
    {
        const int batchSize = 250;
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var table = new DataTable();
        table.Columns.Add("a", typeof(int));
        table.Columns.Add("b", typeof(int));
        table.Columns.Add("c", typeof(int));

        for (int i = 0; i < _arr.Length; i += batchSize)
        {
            table.Clear();

            int count = Math.Min(batchSize, _arr.Length - i);

            for (int j = 0; j < count; j++)
            {
                var row = _arr[i + j];
                table.Rows.Add(row.A, row.B, row.C);
            }

            using var bulk = new SqlBulkCopy(connection)
            {
                DestinationTableName = "BenchmarkRows",
                BatchSize = batchSize
            };

            bulk.WriteToServer(table);
        }
    }

    [Benchmark]
    public void BulkCopyWithDataReader()
    {
        using var reader = new RowDataReader(_arr);
        using var connection = new SqlConnection(ConnectionString);

        connection.Open();

        using var bulk = new SqlBulkCopy(connection)
        {
            DestinationTableName = "BenchmarkRows",
            EnableStreaming = true
        };

        bulk.WriteToServer(reader);
    }
}

public record struct Row(int A, int B, int C);

public sealed class RowDataReader : IDataReader
{
    private readonly Row[] _data;

    private int _index = -1;

    public RowDataReader(Row[] data) => _data = data;

    public bool Read() => ++_index < _data.Length;

    public int FieldCount => 3;

    public object GetValue(int i) => i switch
    {
        0 => _data[_index].A,
        1 => _data[_index].B,
        2 => _data[_index].C,
        _ => throw new IndexOutOfRangeException()
    };

    public string GetName(int i) => i switch
    {
        0 => "a",
        1 => "b",
        2 => "c",
        _ => throw new IndexOutOfRangeException()
    };

    public Type GetFieldType(int i) => typeof(int);

    public int GetOrdinal(string name) => name switch
    {
        "a" => 0,
        "b" => 1,
        "c" => 2,
        _ => throw new IndexOutOfRangeException()
    };

    public bool IsDBNull(int i) => false;

    public int GetInt32(int i) => (int)GetValue(i);

    public int GetValues(object[] values)
    {
        values[0] = _data[_index].A;
        values[1] = _data[_index].B;
        values[2] = _data[_index].C;
        return 3;
    }
    public void Dispose() { }

    public string GetDataTypeName(int i) => "int";

    public object this[int i] => GetValue(i);

    public object this[string name] => GetValue(GetOrdinal(name));

    public bool NextResult() => false;

    public int Depth => 0;

    public bool IsClosed => false;

    public int RecordsAffected => -1;

    public void Close() { }

    #region Not Required for Benchmark

    public DataTable GetSchemaTable() => throw new NotSupportedException();
    public bool GetBoolean(int i) => throw new NotSupportedException();
    public byte GetByte(int i) => throw new NotSupportedException();
    public long GetBytes(int i, long fieldOffset, byte[]? buffer, int bufferoffset, int length) => throw new NotSupportedException();
    public char GetChar(int i) => throw new NotSupportedException();
    public long GetChars(int i, long fieldoffset, char[]? buffer, int bufferoffset, int length) => throw new NotSupportedException();
    public Guid GetGuid(int i) => throw new NotSupportedException();
    public short GetInt16(int i) => throw new NotSupportedException();
    public long GetInt64(int i) => throw new NotSupportedException();
    public float GetFloat(int i) => throw new NotSupportedException();
    public double GetDouble(int i) => throw new NotSupportedException();
    public string GetString(int i) => throw new NotSupportedException();
    public decimal GetDecimal(int i) => throw new NotSupportedException();
    public DateTime GetDateTime(int i) => throw new NotSupportedException();
    public IDataReader GetData(int i) => throw new NotSupportedException();

    #endregion
}
using System.IO.Hashing;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 25)]
public class HashAlgorithms
{
    [Params(102_400)]
    public int N { get; set; }

    private byte[] data = [];

    [GlobalSetup]
    public void GlobalSetup()
    {
        data = new byte[N];
        Random.Shared.NextBytes(data);
    }

    [Benchmark]
    public int GxHashHash32() => GxHash.Hash32(data, 0);

    [Benchmark]
    public uint GxHashHashU32() => GxHash.HashU32(data, 0);

    [Benchmark]
    public long GxHashHash64() => GxHash.Hash64(data, 0);

    [Benchmark]
    public ulong GxHashHashU64() => GxHash.HashU64(data, 0);

    [Benchmark]
    public UInt128 GxHashHash128() => GxHash.Hash128(data, 0);

    [Benchmark]
    public ulong XXHash3() => XxHash3.HashToUInt64(data);

    [Benchmark]
    public ulong XXHash64() => XxHash64.HashToUInt64(data);

    [Benchmark]
    public uint XXHash32() => XxHash32.HashToUInt32(data);

    [Benchmark]
    public UInt128 XXHash128() => XxHash128.HashToUInt128(data);

    [Benchmark]
    public byte[] Sha1() => SHA1.HashData(data);

    [Benchmark]
    public byte[] Sha2_256() => SHA256.HashData(data);

    [Benchmark]
    public byte[] Sha2_384() => SHA384.HashData(data);

    [Benchmark]
    public byte[] Sha2_512() => SHA512.HashData(data);

    [Benchmark]
    public byte[] Sha3_256() => SHA3_256.HashData(data);

    [Benchmark]
    public byte[] Sha3_384() => SHA3_384.HashData(data);

    [Benchmark]
    public byte[] Sha3_512() => SHA3_512.HashData(data);

    [Benchmark]
    public byte[] Md5() => MD5.HashData(data);
}


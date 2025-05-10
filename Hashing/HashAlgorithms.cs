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
    public byte[] XXHash3() => XxHash3.Hash(data);

    [Benchmark]
    public byte[] XXHash64() => XxHash64.Hash(data);

    [Benchmark]
    public byte[] XXHash32() => XxHash32.Hash(data);

    [Benchmark]
    public byte[] XXHash128() => XxHash128.Hash(data);

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

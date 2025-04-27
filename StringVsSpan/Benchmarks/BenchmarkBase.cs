namespace Bnchmrk.Benchmarks;

public abstract class BenchmarkBase
{
    protected string[] strings = default!;

    public virtual void Setup()
    {
        strings = Enumerable
            .Range(1, 100_000)
            .Select((i, x) => i % 2 == 0 ?
                $"{Guid.NewGuid()}".ToLower() :
                $"{Guid.NewGuid()}".ToUpper())
            .ToArray();
    }
}

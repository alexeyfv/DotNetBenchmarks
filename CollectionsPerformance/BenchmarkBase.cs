namespace Benchmark;

public abstract class BenchmarkBase
{
    public const int IterationCount = 25;

    protected Transaction[] _transactionsArray = default!;
    protected List<Transaction> _transactionsList = default!;
    protected IEnumerable<Transaction> _transactionsIEnumerable = default!;

    protected void InitCollections(int length)
    {
        _transactionsArray = InitializeTransaction(length).ToArray();
        _transactionsList = InitializeTransaction(length).ToList();
        _transactionsIEnumerable = InitializeTransaction(length);
    }

    public static IEnumerable<Transaction> InitializeTransaction(int length) =>
        Enumerable
            .Range(0, length)
            .Select(x => new Transaction(
                Guid.NewGuid(),
                Random.Shared.Next(0, 100),
                $"{Guid.NewGuid()}"));

    public static IEnumerable<int> GetLengths()
    {
        for (var i = 10; i < 100; i += 10) yield return i;
        for (var i = 100; i < 1000; i += 100) yield return i;
        for (var i = 1000; i < 10_000; i += 1000) yield return i;
        for (var i = 10_000; i < 100_000; i += 10_000) yield return i;
        for (var i = 100_000; i < 1_000_000; i += 100_000) yield return i;
        yield return 1_000_000;
    }

    public record class Transaction(Guid Id, int Amount, string Description);
    public struct TransactionStruct
    {
        public required Guid Id { get; set; }
        public required int Amount { get; set; }
        public required string Description{ get; set; }        
    }
}

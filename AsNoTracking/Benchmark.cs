using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Microsoft.EntityFrameworkCore;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 30)]
public class Benchmark
{
    [ParamsSource(nameof(Generate_10_to_100000))]
    public int WorkersCount { get; set; }

    public static IEnumerable<int> Generate_10_to_100000()
    {
        for (int i = 10; i < 100; i += 9) yield return i;
        for (int i = 100; i < 1_000; i += 36) yield return i;
        for (int i = 1_000; i < 10_000; i += 360) yield return i;
        for (int i = 10_000; i <= 100_000; i += 3_600) yield return i;
    }

    [GlobalSetup]
    public void Setup()
    {
        using var context = new AppDbContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Employers.AddRange(
            Enumerable
                .Range(0, 100)
                .Select(i => new Employer
                {
                    Id = i + 1,
                    Name = $"Employer {i + 1}",
                    EstablishedDate = DateTime.Now.AddYears(-10).AddDays(i)
                }));

        context.Workers.AddRange(
            Enumerable
                .Range(0, WorkersCount)
                .Select(i => new Worker
                {
                    Id = i + 1,
                    Name = $"Worker {i + 1}",
                    BirthDate = DateTime.Now.AddYears(-30).AddDays(i),
                    EmployerId = (i % 100) + 1 // Assigning to one of the 100 employers
                }));

        context.SaveChanges();
    }

    [Benchmark]
    public int EfQueryAsNoTracking()
    {
        using var context = new AppDbContext();
        return context.Workers.AsNoTracking().ToList().Count;
    }

    [Benchmark(Baseline = true)]
    public int EfQuery()
    {
        using var context = new AppDbContext();
        return context.Workers.ToList().Count;
    }
}

public class AppDbContext : DbContext
{
    public DbSet<Worker> Workers { get; set; } = null!;
    public DbSet<Employer> Employers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=benchmark.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Worker>().HasOne<Employer>()
            .WithMany()
            .HasForeignKey(w => w.EmployerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public record Worker
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required DateTime BirthDate { get; init; }
    public required int EmployerId { get; init; }
}

public record Employer
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required DateTime EstablishedDate { get; init; }
}

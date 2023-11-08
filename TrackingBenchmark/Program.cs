
using BenchmarkDotNet.Running;
using TrackingBenchmark;
using TrackingBenchmark.Db;

class Program
{
    static void Main(string[] args)
    {
        SetDb(100000);
        BenchmarkRunner.Run<Benchmark>();
    }

    static void SetDb(int size)
    {
        using var dbContext = new AppDbContext();
        dbContext.ApplyMigrations();
        dbContext.SeedData(size); //set db size
    }
}
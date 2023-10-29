
using BenchmarkDotNet.Running;
using TrackingBenchmark;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchmark>();
    }
}
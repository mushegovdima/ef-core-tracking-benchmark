namespace TrackingBenchmark.Db;

public class Product : IProduct
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public double Price { get; set; }
}



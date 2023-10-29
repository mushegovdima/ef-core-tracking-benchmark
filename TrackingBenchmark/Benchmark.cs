using System;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using TrackingBenchmark.Db;

namespace TrackingBenchmark;

public class Benchmark
{
    private AppDbContext dbContext;

    [GlobalSetup]
    public void Setup()
    {
        dbContext = new AppDbContext();
        dbContext.ApplyMigrations();
        dbContext.SeedData(1000000); //set db size
    }

    [Benchmark]
    public int WithTracking()
    {
        var products = dbContext.Product.ToList();
        return products.Count;
    }
    [Benchmark]
    public int WithoutTracking()
    {
        var products = dbContext.Product.AsNoTracking().ToList();
        return products.Count;
    }

    [Benchmark]
    public int WithTrackingAndOrder()
    {
        var products = dbContext.Product.OrderBy(x => x.Name).ToList();
        return products.Count;
    }


    [Benchmark]
    public int WithoutTrackingAndOrder()
    {
        var products = dbContext.Product.AsNoTracking().OrderBy(x => x.Name).ToList();
        return products.Count;
    }
}



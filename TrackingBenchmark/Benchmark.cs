using System;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using TrackingBenchmark.Db;

namespace TrackingBenchmark;

public class Benchmark
{

    [Benchmark]
    public async Task<int> WithTracking()
    {
        using var dbContext = new AppDbContext();
        var products = await dbContext.Product.AsTracking().ToListAsync();
        return products.Count;
    }
    [Benchmark]
    public async Task<int> WithoutTracking()
    {
        using var dbContext = new AppDbContext();
        var products = await dbContext.Product.AsNoTracking().ToListAsync();
        return products.Count;
    }

    [Benchmark]
    public async Task<int> WithTrackingAndOrder()
    {
        using var dbContext = new AppDbContext();
        var products = await dbContext.Product.AsTracking().OrderBy(x => x.Name).ToListAsync();
        return products.Count;
    }


    [Benchmark]
    public async Task<int> WithoutTrackingAndOrder()
    {
        using var dbContext = new AppDbContext();
        var products = await dbContext.Product.AsNoTracking().OrderBy(x => x.Name).ToListAsync();
        return products.Count;
    }
}



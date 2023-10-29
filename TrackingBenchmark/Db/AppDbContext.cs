using Microsoft.EntityFrameworkCore;

namespace TrackingBenchmark.Db;

public class AppDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("your connection string");
    }

    internal void ApplyMigrations()
    {
        var migrations = Database.GetPendingMigrations();
        if (migrations.Any())
        {
            Database.Migrate();
        }
    }

    internal void SeedData(int size)
    {
        if (Product.Count() != size)
        {
            RemoveRange(Product);
            SaveChanges();
        }

        if (!Product.Any())
        {
            Product.AddRange(Enumerable.Range(1, size).Select(i => new Product { Name = $"Product {i}", Price = i * 10.01 }));
            SaveChanges();
        }
    }
}

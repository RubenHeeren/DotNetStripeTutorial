using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /// <summary>
    /// Uses Lorem Picsum for example images. Website: https://picsum.photos/.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        const int amountOfProductsToSeed = 20;

        var productsToSeed = new Product[amountOfProductsToSeed];

        for (int i = 1; i <= amountOfProductsToSeed; i++)
        {
            productsToSeed[i - 1] = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Title = $"Product {i}",
                Description = $"Product {i} description. This is an amazing product with a price-quality balance you won't find anywhere ele.",
                ImageUrl = $"https://picsum.photos/id/{i}/500",
                Price = 1000 * i,
            };
        }

        modelBuilder.Entity<Product>().HasData(productsToSeed);
    }
}
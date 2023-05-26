using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence;

public class FlowerShopDbContext : DbContext
{
    public FlowerShopDbContext(DbContextOptions<FlowerShopDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Administrator> Administrators { get; set; } = null!;
    public DbSet<Flower> Flowers { get; set; } = null!;
    public DbSet<FlowerArrangement> FlowerArrangements { get; set; } = null!;
    public DbSet<FlowerArrangementCategory> FlowerArrangementCategories { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlowerShopDbContext).Assembly);
    }
}

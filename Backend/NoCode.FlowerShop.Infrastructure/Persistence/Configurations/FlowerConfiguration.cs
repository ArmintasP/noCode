using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Configurations;

public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
{
    public void Configure(EntityTypeBuilder<Flower> builder)
    {
        ConfigureCustomersTable(builder);
    }

    private static void ConfigureCustomersTable(EntityTypeBuilder<Flower> builder)
    {
        builder.ToTable("Flowers");
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedOnAdd();

        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(f => f.ImageUrl)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasIndex(f => f.Name)
            .IsUnique();
    }
}

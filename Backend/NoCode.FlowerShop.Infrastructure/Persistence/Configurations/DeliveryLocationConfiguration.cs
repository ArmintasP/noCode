using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Configurations;

public class DeliveryLocationConfiguration : IEntityTypeConfiguration<DeliveryLocation>
{
    public void Configure(EntityTypeBuilder<DeliveryLocation> builder)
    {
        ConfigureDeliveryLocationsTable(builder);
    }

    private static void ConfigureDeliveryLocationsTable(EntityTypeBuilder<DeliveryLocation> builder)
    {
        builder.ToTable("DeliveryLocations");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedOnAdd();

        builder.Property(d => d.Country)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(d => d.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.Address)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(d => d.ZipCode)
            .IsRequired()
            .HasMaxLength(16);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Configurations;

public class FlowerArrangementConfiguration : IEntityTypeConfiguration<FlowerArrangement>
{
    public void Configure(EntityTypeBuilder<FlowerArrangement> builder)
    {
        ConfigureFlowerArrangementsTable(builder);
    }

    private static void ConfigureFlowerArrangementsTable(EntityTypeBuilder<FlowerArrangement> builder)
    {
        builder.ToTable("FlowersArrangements");
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedOnAdd();

        builder.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(f => f.Price)
            .IsRequired();

        builder.Property(f => f.StorageQuantity)
            .IsRequired();
        
        builder.Property(f => f.ImageUrl)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(f => f.Description)
            .IsRequired()
            .HasMaxLength(256);

        builder.OwnsMany(f => f.Flowers, fb =>
        {
            fb.ToTable("FlowersArrangementsFlowers");
            fb.WithOwner().HasForeignKey("FlowerArrangementId");

            fb.HasKey("FlowerArrangementId", "FlowerId");

            fb.Property<int>("Quantity")
                .IsRequired();
        });

        builder.HasIndex(f => f.Name)
            .IsUnique();
    }
}

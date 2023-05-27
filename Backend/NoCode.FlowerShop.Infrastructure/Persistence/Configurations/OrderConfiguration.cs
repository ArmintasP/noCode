using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ConfigureOrdersTable(builder);
    }

    private static void ConfigureOrdersTable(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedOnAdd();

        builder.Property(o => o.Name)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.Property(o => o.Surname)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(o => o.PhoneNumber)
            .IsRequired()
            .HasMaxLength(16);

        builder.OwnsMany(c => c.FlowerArrangements, fb =>
        {
            fb.ToTable("OrderFlowerArrangements");
            fb.WithOwner().HasForeignKey("OrderId");

            fb.HasKey("OrderId", "FlowerArrangementId");

            fb.Property(f => f.Quantity)
                .IsRequired()
                .HasConversion<int>();
        });
    }
}

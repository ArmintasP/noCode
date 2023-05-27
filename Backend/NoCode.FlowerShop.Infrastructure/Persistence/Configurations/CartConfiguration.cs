using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        ConfigureCartsTable(builder);
    }

    private static void ConfigureCartsTable(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedOnAdd();

        builder.OwnsMany(c => c.FlowerArrangements, fb =>
        {
            fb.ToTable("CartFlowerArrangements");
            fb.WithOwner().HasForeignKey("CartId");

            fb.HasKey("CartId", "FlowerArrangementId");

            fb.Property(f => f.Quantity)
                .IsRequired()
                .HasConversion<int>();
        });
    }
}

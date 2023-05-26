using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Configurations;

public class FlowerArrangementCategoryConfiguration : IEntityTypeConfiguration<FlowerArrangementCategory>
{
    public void Configure(EntityTypeBuilder<FlowerArrangementCategory> builder)
    {
        ConfigureCustomersTable(builder);
    }

    private static void ConfigureCustomersTable(EntityTypeBuilder<FlowerArrangementCategory> builder)
    {
        builder.ToTable("FlowersArrangementCategories");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasIndex(c => c.Name)
            .IsUnique();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        ConfigureCustomersTable(builder);
    }

    public void ConfigureCustomersTable(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(customer => customer.Id);
        builder.Property(customer => customer.Id).ValueGeneratedOnAdd();
        builder.Property(customer => customer.Email).IsRequired().HasMaxLength(80);
        builder.Property(customer => customer.Password).IsRequired().HasMaxLength(50);
        builder.Property(customer => customer.Salt).HasConversion<byte[]>().IsRequired().HasMaxLength(64);
        builder.HasIndex(customer => customer.Email).IsUnique();
    }
}

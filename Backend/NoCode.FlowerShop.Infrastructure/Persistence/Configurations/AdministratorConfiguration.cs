using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Configurations;

public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        ConfigureAdministratorsTable(builder);
    }

    private static void ConfigureAdministratorsTable(EntityTypeBuilder<Administrator> builder)
    {
        builder.ToTable("Administrators");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.Email).IsRequired().HasMaxLength(80);
        builder.Property(a => a.Password).IsRequired().HasMaxLength(50);
        builder.Property(a => a.Salt).HasConversion<byte[]>().IsRequired().HasMaxLength(64);
        builder.HasIndex(a => a.Email).IsUnique();
    }
}

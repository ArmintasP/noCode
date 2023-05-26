using NoCode.FlowerShop.Domain.Common.Models;

namespace NoCode.FlowerShop.Domain;

public sealed class FlowerArrangementCategory : Entity<Guid>
{
    public string Name { get; private set; }

    public FlowerArrangementCategory(string name)
    {
        Name = name;
    }

#pragma warning disable CS8618
    private FlowerArrangementCategory() { }
#pragma warning restore CS8618
}

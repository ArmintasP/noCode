using NoCode.FlowerShop.Domain.Common.Models;

namespace NoCode.FlowerShop.Domain;

public sealed class Flower : Entity<Guid>
{
    public string Name { get; private set; }
    public string ImageUrl { get; private set; }

    public Flower(string name, string imageUrl)
    {
        Name = name;
        ImageUrl = imageUrl;
    }

    public void UpdateImageUrl(string imageUrl)
    {
        ImageUrl = imageUrl;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

#pragma warning disable CS8618
    private Flower() { }
#pragma warning restore CS8618
}

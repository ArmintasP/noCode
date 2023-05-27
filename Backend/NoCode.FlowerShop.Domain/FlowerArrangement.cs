using NoCode.FlowerShop.Domain.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace NoCode.FlowerShop.Domain;

public sealed class FlowerArrangement : Entity<Guid>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
    public decimal Price { get; private set; }
    public int StorageQuantity { get; private set; }
    public FlowerArrangementCategory FlowerArrangementCategory { get; private set; }
    public List<Flowers> Flowers { get; private set; }
    
    [Timestamp]
    public byte[]? Version { get; private set; }
    
    public FlowerArrangement(
        string name,
        string description,
        string imageUrl,
        decimal price,
        int storageQuantity,
        FlowerArrangementCategory flowerArrangementCategory,
        List<Flowers> flowers)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Price = price;
        StorageQuantity = storageQuantity;
        FlowerArrangementCategory = flowerArrangementCategory;
        Flowers = flowers;
    }

#pragma warning disable CS8618
    private FlowerArrangement() { }

#pragma warning restore CS8618
}

public class Flowers
{
    public Flower Flower { get; private set; }
    public int Quantity { get; private set; }

    public Flowers(Flower flower, int quantity)
    {
        Flower = flower;
        Quantity = quantity;
    }

#pragma warning disable CS8618
    private Flowers() { }
#pragma warning restore CS8618
}
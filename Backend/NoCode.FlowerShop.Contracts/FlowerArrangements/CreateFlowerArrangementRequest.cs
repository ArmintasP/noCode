namespace NoCode.FlowerShop.Contracts.FlowerArrangements;

public sealed record CreateFlowerArrangementRequest(string Name,
    string Description,
    string ImageUrl,
    decimal Price,
    int StorageQuantity,
    Flowers[] Flowers,
    Guid CategoryId);

public sealed record Flowers(Guid Id, int Quantity);
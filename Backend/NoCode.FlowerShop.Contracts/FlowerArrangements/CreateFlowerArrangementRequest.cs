namespace NoCode.FlowerShop.Contracts.FlowerArrangements;

public sealed record CreateFlowerArrangementRequest(string Name,
    string Description,
    string ImageUrl,
    decimal Price,
    int StorageQuantity,
    FlowersDto[] Flowers);

public sealed record FlowersDto(Guid Id, int Quantity);
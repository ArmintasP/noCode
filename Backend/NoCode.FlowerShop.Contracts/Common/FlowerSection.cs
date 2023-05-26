namespace NoCode.FlowerShop.Contracts.Common;

public sealed record FlowerSection(
    Guid Id,
    string Name,
    string ImageUrl,
    uint? Quantity);
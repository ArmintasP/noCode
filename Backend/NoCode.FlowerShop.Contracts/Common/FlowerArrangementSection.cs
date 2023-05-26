namespace NoCode.FlowerShop.Contracts.Common;
public sealed record FlowerArrangementSection(
    Guid Id,
    string Name,
    string Description,
    string ImageUrl,
    decimal Price,
    string CategoryName,
    List<FlowerSection> Flowers);
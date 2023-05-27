namespace NoCode.FlowerShop.Contracts.Common;

public sealed record CartSection(
    Guid Id,
    Guid CustomerId,
    List<FlowerArrangementSection> FlowerArrangements);

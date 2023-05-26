using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Customers.FlowerArrangements.GetAvailableFlowerArragementsList;

public sealed record AvailableFlowerArrangementsResult(
    List<FlowerArrangement> FlowerArrangements);
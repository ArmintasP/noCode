using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.FlowerArrangements.GetAvailableFlowerArragementsList;

public sealed record AvailableFlowerArrangementsResult(
    List<FlowerArrangement> FlowerArrangements);
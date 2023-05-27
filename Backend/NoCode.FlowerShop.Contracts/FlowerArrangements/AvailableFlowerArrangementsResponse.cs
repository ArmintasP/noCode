using NoCode.FlowerShop.Contracts.Common;

namespace NoCode.FlowerShop.Contracts.FlowerArrangements;

public record AvailableFlowerArrangementsResponse(
    List<FlowerArrangementSection> FlowerArrangements);
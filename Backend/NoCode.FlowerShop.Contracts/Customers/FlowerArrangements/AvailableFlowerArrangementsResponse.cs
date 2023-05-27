using NoCode.FlowerShop.Contracts.Common;

namespace NoCode.FlowerShop.Contracts.Customers.FlowerArrangements;

public record AvailableFlowerArrangementsResponse(
    List<FlowerArrangementSection> FlowerArrangements);
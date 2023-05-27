using NoCode.FlowerShop.Contracts.Common;

namespace NoCode.FlowerShop.Contracts.Flowers;

public sealed record GetAllFlowersResponse(List<FlowerSection> Flowers);
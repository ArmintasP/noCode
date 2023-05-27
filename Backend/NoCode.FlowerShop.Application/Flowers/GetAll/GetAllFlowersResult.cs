using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Flowers.Delete;

public sealed record GetAllFlowersResult(List<Flower> Flowers);
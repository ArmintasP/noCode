using Mapster;
using NoCode.FlowerShop.Application.Customers.FlowerArrangements.GetAvailableFlowerArragementsList;
using NoCode.FlowerShop.Application.Customers.FlowerArrangements.GetFlowerArrangementById;
using NoCode.FlowerShop.Contracts.Common;
using NoCode.FlowerShop.Contracts.Customers.FlowerArrangements;
using NoCode.FlowerShop.Domain;
using NoCode.FlowerShop.Domain.Common;

namespace NoCode.FlowerShop.Api.Mappings;

public sealed class FlowerArrangementsMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AvailableFlowerArrangementsResult, AvailableFlowerArrangementsResponse>()
            .Map(dest => dest, src => src.FlowerArrangements);

        config.NewConfig<FlowerArrangement, FlowerArrangementSection>()
            .Map(dest => dest.CategoryName, src => src.FlowerArrangementCategory.Name);

        config.NewConfig<Flowers, FlowerSection>()
            .Map(dest => dest, src => src.Flower);

        config.NewConfig<GetFlowerArrangementByIdResult, GetFlowerArrangementByIdResponse>()
            .Map(dest => dest, src => src.FlowerArrangement);

        config.NewConfig<FlowerArrangementPair, FlowerArrangementSection>()
            .Map(dest => dest, src => src.FlowerArrangement);
    }
}
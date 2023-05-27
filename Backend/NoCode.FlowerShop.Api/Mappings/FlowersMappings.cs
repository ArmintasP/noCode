using Mapster;
using NoCode.FlowerShop.Application.Flowers.Create;
using NoCode.FlowerShop.Contracts.Flowers;

namespace NoCode.FlowerShop.Api.Mappings;

public class FlowersMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateFlowerResult, CreateFlowerResponse>()
            .Map(dest => dest.Id, src => src.Flower.Id);
    }
}
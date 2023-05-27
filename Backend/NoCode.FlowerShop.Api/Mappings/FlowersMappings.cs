using Mapster;
using NoCode.FlowerShop.Application.Flowers.Create;
using NoCode.FlowerShop.Application.Flowers.Delete;
using NoCode.FlowerShop.Application.Flowers.Update;
using NoCode.FlowerShop.Contracts.Flowers;

namespace NoCode.FlowerShop.Api.Mappings;

public class FlowersMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateFlowerResult, CreateFlowerResponse>()
            .Map(dest => dest.Id, src => src.Flower.Id);

        config.NewConfig<DeleteFlowerResult, DeleteFlowerResponse>();
        config.NewConfig<GetAllFlowersResult, GetAllFlowersResponse>();

        config.NewConfig<(UpdateFlowerRequest request, Guid id), UpdateFlowerCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest, src => src.request);
    }
}
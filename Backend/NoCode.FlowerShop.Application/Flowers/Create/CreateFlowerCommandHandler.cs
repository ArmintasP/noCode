using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Flowers.Create;

public sealed class CreateFlowerCommandHandler 
    : IRequestHandler<CreateFlowerCommand, ErrorOr<CreateFlowerResult>>
{
    private readonly IFlowerRepository _flowerRepository;

    public CreateFlowerCommandHandler(IFlowerRepository flowerRepository)
    {
        _flowerRepository = flowerRepository;
    }

    public async Task<ErrorOr<CreateFlowerResult>> Handle(CreateFlowerCommand request, CancellationToken cancellationToken)
    {
        List<Error> errors = new();

        if (errors.Count > 0) return errors;

        Flower flowerToCreate = new(
            name: request.Name, 
            imageUrl: request.ImageUrl);

        var createdFlower = await _flowerRepository
            .AddAsync(flowerToCreate, CancellationToken.None);

        return new CreateFlowerResult(createdFlower);
    }
}
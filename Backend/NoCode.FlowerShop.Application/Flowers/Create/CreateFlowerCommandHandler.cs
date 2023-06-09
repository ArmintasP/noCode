using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

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
        var isUniqueName = await IsUniqueName(request.Name);
        if (!isUniqueName)
            return Errors.Flowers.DuplicateName;

        var flowerToCreate = new Flower(request.Name, request.ImageUrl);

        var createdFlower = await _flowerRepository.AddAsync(flowerToCreate, cancellationToken);

        return new CreateFlowerResult(createdFlower);
    }

    private async Task<bool> IsUniqueName(string name)
    {
        var flower = await _flowerRepository.GetByNameAsync(name);
        return flower is null;
    }
}
using MediatR;
using ErrorOr;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.Flowers.Update;

public class UpdateFlowerCommandHandler : IRequestHandler<UpdateFlowerCommand, ErrorOr<UpdateFlowerResult>>
{
    private readonly IFlowerRepository _flowerRepository;

    public UpdateFlowerCommandHandler(IFlowerRepository flowerRepository)
    {
        _flowerRepository = flowerRepository;
    }

    public async Task<ErrorOr<UpdateFlowerResult>> Handle(UpdateFlowerCommand request, CancellationToken cancellationToken)
    {
        var flower = await _flowerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (flower is null)
            return Errors.Flowers.NotFound;

        var isUniqueName = await IsUniqueName(flower.Name, request.Name);
        if (!isUniqueName)
            return Errors.Flowers.DuplicateName;
        
        flower.UpdateImageUrl(request.ImageUrl ?? flower.ImageUrl);
        flower.UpdateName(request.Name ?? flower.Name);
        
        await _flowerRepository.UpdateAsync(flower, cancellationToken);

        return new UpdateFlowerResult();
    }

    private async Task<bool> IsUniqueName(string currentName, string? newName)
    {
        if (currentName == newName)
            return true;
        
        if (newName is null)
            return true;
        
        var flower = await _flowerRepository.GetByNameAsync(newName);
        return flower is null;
    }
}
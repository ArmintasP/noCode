using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.FlowerArrangements.Create;
internal class CreateFlowerArrangementHandler :
    IRequestHandler<CreateFlowerArrangementCommand, ErrorOr<CreateFlowerArrangementResult>>
{
    private readonly IFlowerArrangementRepository _flowerArrangementRepository;

    private readonly IFlowerArrangementCategoryRepository _flowerArrangementCategoryRepository;

    private readonly IFlowerRepository _flowerRepository;

    public CreateFlowerArrangementHandler(
        IFlowerArrangementRepository flowerArrangementRepository, 
        IFlowerArrangementCategoryRepository flowerArrangementCategoryRepository, 
        IFlowerRepository flowerRepository)
    {
        _flowerArrangementRepository=flowerArrangementRepository;
        _flowerArrangementCategoryRepository=flowerArrangementCategoryRepository;
        _flowerRepository=flowerRepository;
    }

    public async Task<ErrorOr<CreateFlowerArrangementResult>> Handle(CreateFlowerArrangementCommand request, CancellationToken cancellationToken)
    {
        var flowerArrangement = await _flowerArrangementRepository.GetByNameAsync(request.Name, cancellationToken);
        if (flowerArrangement is not null)
            return Errors.FlowerArrangement.DuplicateName;

        var category = await _flowerArrangementCategoryRepository.GetById(request.CategoryId, cancellationToken);
        if (category is null)
            return Errors.FlowerArrangement.CategoryNotFound;

        var flowersIds = request.Flowers.Select(x => x.Id).ToList();
        var flowers = _flowerRepository
            .GetAll()
            .Where(x => flowersIds.Contains(x.Id))
            .ToList();

        var hasExistingFlowersIds = flowers.Count == flowersIds.Count;

        if (flowers == null || !hasExistingFlowersIds)
            return Errors.FlowerArrangement.FlowerNotFound;

        var flowerArrangementFlowers = new List<Domain.Flowers>();
        foreach(var flower in flowers)
        {
            var quantity = request.Flowers
                .Where(x => x.Id == flower.Id)
                .First()
                .Quantity;

            flowerArrangementFlowers.Add(new(flower, quantity));
        }

        var flowerArrangementToCreate = new FlowerArrangement(
            request.Name, 
            request.Description, 
            request.ImageUrl, 
            request.Price, 
            request.StorageQuantity, 
            category, 
            flowerArrangementFlowers);

        var createdFlowerArrangement = await _flowerArrangementRepository.AddAsync(flowerArrangementToCreate, cancellationToken);

        return new CreateFlowerArrangementResult(createdFlowerArrangement);
    }
}

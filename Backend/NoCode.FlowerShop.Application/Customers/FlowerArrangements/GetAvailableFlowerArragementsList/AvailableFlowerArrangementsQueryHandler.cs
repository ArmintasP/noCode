using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

namespace NoCode.FlowerShop.Application.Customers.FlowerArrangements.GetAvailableFlowerArragementsList;

public sealed class AvailableFlowerArrangementsQueryHandler :
    IRequestHandler<AvailableFlowerArrangementsQuery, ErrorOr<AvailableFlowerArrangementsResult>>
{
    private readonly IFlowerArrangementRepository _flowerArrangementRepository;

    public AvailableFlowerArrangementsQueryHandler(IFlowerArrangementRepository flowerArrangementRepository)
    {
        _flowerArrangementRepository = flowerArrangementRepository;
    }

    public async Task<ErrorOr<AvailableFlowerArrangementsResult>> Handle(AvailableFlowerArrangementsQuery request, CancellationToken cancellationToken)
    {
        var flowerArrangements = _flowerArrangementRepository.GetAll();

        var availableFlowerArrangements = flowerArrangements
            .Where(fa => fa.StorageQuantity > 0)
            .ToList();

        return new AvailableFlowerArrangementsResult(availableFlowerArrangements);
    }
}
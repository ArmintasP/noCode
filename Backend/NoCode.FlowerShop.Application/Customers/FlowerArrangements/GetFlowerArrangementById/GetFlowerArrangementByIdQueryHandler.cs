using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.Customers.FlowerArrangements.GetFlowerArrangementById;
public sealed class GetFlowerArrangementByIdQueryHandler :
    IRequestHandler<GetFlowerArrangementByIdQuery, ErrorOr<GetFlowerArrangementByIdResult>>
{
    private readonly IFlowerArrangementRepository _flowerArrangementRepository;

    public GetFlowerArrangementByIdQueryHandler(IFlowerArrangementRepository flowerArrangementRepository)
    {
        _flowerArrangementRepository = flowerArrangementRepository;
    }

    public async Task<ErrorOr<GetFlowerArrangementByIdResult>> Handle(GetFlowerArrangementByIdQuery request, CancellationToken cancellationToken)
    {
        var flowerArrangement = await _flowerArrangementRepository.GetByIdAsync(request.id);

        if (flowerArrangement is null)
            return Errors.FlowerArrangement.NotFound;

        return new GetFlowerArrangementByIdResult(flowerArrangement);
    }
}

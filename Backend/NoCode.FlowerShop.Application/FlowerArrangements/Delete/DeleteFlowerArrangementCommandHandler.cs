using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.FlowerArrangements.Delete;
public sealed class DeleteFlowerArrangementCommandHandler :
    IRequestHandler<DeleteFlowerArrangementCommand, ErrorOr<DeleteFlowerArrangementResult>>
{
    private readonly IFlowerArrangementRepository _flowerArrangementRepository;

    public DeleteFlowerArrangementCommandHandler(IFlowerArrangementRepository flowerArrangementRepository)
    {
        _flowerArrangementRepository = flowerArrangementRepository;
    }

    public async Task<ErrorOr<DeleteFlowerArrangementResult>> Handle(DeleteFlowerArrangementCommand request, CancellationToken cancellationToken)
    {
        var flowerArrangement = await _flowerArrangementRepository.GetByIdAsync(request.Id, cancellationToken);

        if (flowerArrangement is null)
            return Errors.FlowerArrangement.NotFound;

        await _flowerArrangementRepository.DeleteAsync(flowerArrangement, cancellationToken);
        return new DeleteFlowerArrangementResult();
    }
}

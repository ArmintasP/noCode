using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.Flowers.Delete;

public class DeleteFlowerCommandHandler : IRequestHandler<DeleteFlowerCommand, ErrorOr<DeleteFlowerResult>>
{
    private readonly IFlowerRepository _flowerRepository;

    public DeleteFlowerCommandHandler(IFlowerRepository flowerRepository)
    {
        _flowerRepository = flowerRepository;
    }

    public async Task<ErrorOr<DeleteFlowerResult>> Handle(DeleteFlowerCommand request, CancellationToken cancellationToken)
    {
        var flowerToDelete = await _flowerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (flowerToDelete is null)
            return Errors.Flowers.NotFound;
        
        await _flowerRepository.DeleteByIdAsync(flowerToDelete, cancellationToken);
        
        return new DeleteFlowerResult();
    }
}
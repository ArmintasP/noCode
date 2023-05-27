using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.Carts.Delete;

public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, ErrorOr<DeleteCartResult>>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ErrorOr<DeleteCartResult>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var cartToDelete = await _cartRepository.GetByCustomerId(request.CustomerId, cancellationToken);

        if (cartToDelete is null)
            return Errors.Cart.NotFound;

        await _cartRepository.DeleteByCustomerIdAsync(cartToDelete, cancellationToken);

        return new DeleteCartResult();
    }
}
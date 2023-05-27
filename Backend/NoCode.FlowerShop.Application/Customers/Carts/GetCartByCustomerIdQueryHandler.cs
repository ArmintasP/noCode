using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.Customers.Carts;

public sealed class GetCartByCustomerIdQueryHandler :
    IRequestHandler<GetCartByCustomerIdQuery, ErrorOr<GetCartByCustomerIdResult>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartByCustomerIdQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ErrorOr<GetCartByCustomerIdResult>> Handle(GetCartByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByCustomerId(request.customerId, cancellationToken);

        if (cart is null)
            return Errors.Cart.NotFound;

        return new GetCartByCustomerIdResult(cart);
    }
}
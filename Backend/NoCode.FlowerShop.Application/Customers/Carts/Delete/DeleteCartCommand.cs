using ErrorOr;
using MediatR;

namespace NoCode.FlowerShop.Application.Carts.Delete;

public sealed record DeleteCartCommand(Guid CustomerId)
    : IRequest<ErrorOr<DeleteCartResult>>;

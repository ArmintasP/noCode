using ErrorOr;
using FluentValidation;
using MediatR;

namespace NoCode.FlowerShop.Application.Customers.Carts;
public sealed record GetCartByCustomerIdQuery(Guid customerId) : IRequest<ErrorOr<GetCartByCustomerIdResult>>;

public sealed class GetCartByCustomerIdValidator : AbstractValidator<GetCartByCustomerIdQuery> { }

using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Customers.Authentication.Common;

namespace NoCode.FlowerShop.Application.Customers.Authentication.Login;

public sealed record CustomerLoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<CustomerAuthenticationResult>>;

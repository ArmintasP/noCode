using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Customers.Authentication.Common;

namespace NoCode.FlowerShop.Application.Customers.Authentication.Register;

public sealed record CustomerRegisterCommand(
    string Email,
    string Password) : IRequest<ErrorOr<CustomerAuthenticationResult>>;

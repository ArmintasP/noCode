using ErrorOr;
using MediatR;

namespace NoCode.FlowerShop.Application.Administrators.Authentication.Login;

public sealed record AdministratorLoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AdministratorAuthenticationResult>>;
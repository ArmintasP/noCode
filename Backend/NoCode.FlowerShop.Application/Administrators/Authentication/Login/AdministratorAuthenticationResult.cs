using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Administrators.Authentication.Login;

public sealed record AdministratorAuthenticationResult(
    Administrator Administrator,
    string Token);
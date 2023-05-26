using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Customers.Authentication.Common;

public record CustomerAuthenticationResult(
    Customer Customer,
    string Token);

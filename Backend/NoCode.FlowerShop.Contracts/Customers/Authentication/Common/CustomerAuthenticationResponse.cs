namespace NoCode.FlowerShop.Contracts.Customers.Authentication.Common;

public record CustomerAuthenticationResponse(
    int Id,
    string Email,
    string Token);

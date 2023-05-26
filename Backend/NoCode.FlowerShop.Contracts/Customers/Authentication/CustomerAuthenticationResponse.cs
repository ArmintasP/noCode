namespace NoCode.FlowerShop.Contracts.Customers.Authentication;

public record CustomerAuthenticationResponse(
    Guid Id,
    string Email,
    string Token);

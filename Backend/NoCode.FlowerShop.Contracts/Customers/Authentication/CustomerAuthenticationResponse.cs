namespace NoCode.FlowerShop.Contracts.Customers.Authentication;

public record CustomerAuthenticationResponse(
    int Id,
    string Email,
    string Token);

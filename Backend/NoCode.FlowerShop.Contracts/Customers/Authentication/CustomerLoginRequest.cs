namespace NoCode.FlowerShop.Contracts.Customers.Authentication;

public record CustomerLoginRequest(
    string Email,
    string Password);

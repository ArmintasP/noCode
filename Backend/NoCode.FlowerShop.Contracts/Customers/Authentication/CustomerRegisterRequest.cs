namespace NoCode.FlowerShop.Contracts.Customers.Authentication;

public record CustomerRegisterRequest(
    string Email,
    string Password);
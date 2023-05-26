namespace NoCode.FlowerShop.Contracts.Employees.Authentication;

public record AdministratorAuthenticationResponse(
    Guid Id,
    string Email,
    string Token);
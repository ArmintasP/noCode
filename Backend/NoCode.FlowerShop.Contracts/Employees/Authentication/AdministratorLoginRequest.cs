namespace NoCode.FlowerShop.Contracts.Employees.Authentication;

public record AdministratorLoginRequest(
    string Email,
    string Password);
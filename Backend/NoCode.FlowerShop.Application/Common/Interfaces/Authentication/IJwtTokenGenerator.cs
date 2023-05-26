using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Customer customer);
    string GenerateToken(Administrator administrator);
}

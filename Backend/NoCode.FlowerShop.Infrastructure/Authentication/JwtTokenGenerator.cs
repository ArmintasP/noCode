using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;
using NoCode.FlowerShop.Application.Common.Interfaces.Clock;
using NoCode.FlowerShop.Domain;
using NoCode.FlowerShop.Domain.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NoCode.FlowerShop.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IClock _clock;
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IClock clock, IOptions<JwtSettings> jwtSettings)
    {
        _clock = clock;
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateToken(Customer customer)
    {
        var claims = GetMainClaims(
            customer.Id.ToString(),
            customer.Email,
            UserRole.Customer);

        var token = GenerateToken(claims);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateToken(Administrator administrator)
    {
        var claims = GetMainClaims(
            administrator.Id.ToString(),
            administrator.Email,
            UserRole.Administrator);

        var token = GenerateToken(claims);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GenerateToken(List<Claim> claims)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _clock.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
            claims: claims,
            signingCredentials: signingCredentials);
        return token;
    }

    private static List<Claim> GetMainClaims(string entityId, string email, UserRole userRole)
    {
        return new()
        {
            new Claim(JwtRegisteredClaimNames.Sub, entityId),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, userRole.ToString())
        };
    }
}

using Microsoft.Extensions.Options;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;
using System.Security.Cryptography;

namespace NoCode.FlowerShop.Infrastructure.Authentication;

public sealed class PasswordProvider : IPasswordProvider
{
    private readonly PasswordProviderSettings _settings;

    public PasswordProvider(IOptions<PasswordProviderSettings> settings)
    {
        _settings = settings.Value;
    }

    public string GenerateRandomPassword()
    {
        return Guid.NewGuid()
            .ToString()
            .Substring(0, 8);
    }

    public (string hashedPassword, byte[] salt) HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(_settings.KeySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            _settings.Iterations,
            _settings.Algorithm,
            _settings.KeySize);

        return (Convert.ToHexString(hash), salt);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            _settings.Iterations,
             _settings.Algorithm,
            _settings.KeySize);

        return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
    }
}

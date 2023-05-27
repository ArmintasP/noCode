using Microsoft.Extensions.Options;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;
using System.Security.Cryptography;

namespace NoCode.FlowerShop.Infrastructure.Authentication;

public sealed class PasswordProvider : IPasswordProvider
{
    private readonly PasswordProviderSettings _settings;
    private readonly IHashingStrategy _hashingStrategy;

    public PasswordProvider(IOptions<PasswordProviderSettings> settings, IHashingStrategy hashingStrategy)
    {
        _hashingStrategy = hashingStrategy;
        _settings = settings.Value;
    }

    public string GenerateRandomPassword()
    {
        return Guid.NewGuid()
            .ToString()
            .Substring(0, 8);
    }

    public (string hashedPassword, byte[] salt) HashPassword(string password) 
        => _hashingStrategy.HashPassword(password, _settings.KeySize, _settings.Iterations, _settings.Algorithm);

    public bool VerifyPassword(string password, string hash, byte[] salt) 
        => _hashingStrategy.VerifyPassword(password, hash, salt, _settings.KeySize, _settings.Iterations, _settings.Algorithm);
}

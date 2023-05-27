using System.Security.Cryptography;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;

namespace NoCode.FlowerShop.Infrastructure.Authentication.HashingStrategies;

public class Pbkdf2HashingStrategy : IHashingStrategy
{
    public (string hashedPassword, byte[] salt) HashPassword(string password, int keySize, int iterations, HashAlgorithmName algorithm)
    {
        var salt = RandomNumberGenerator.GetBytes(keySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations,
            algorithm,
            keySize);

        return (Convert.ToHexString(hash), salt);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt, int keySize, int iterations, HashAlgorithmName algorithm)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            iterations,
            algorithm,
            keySize);

        return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
    }
}
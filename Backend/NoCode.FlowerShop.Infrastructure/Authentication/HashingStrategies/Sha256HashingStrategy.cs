using System.Security.Cryptography;
using System.Text;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;

namespace NoCode.FlowerShop.Infrastructure.Authentication.HashingStrategies;

public class Sha256HashingStrategy : IHashingStrategy
{
    public (string hashedPassword, byte[] salt) HashPassword(string password, int keySize, int iterations, HashAlgorithmName algorithm)
    {
        var salt = RandomNumberGenerator.GetBytes(keySize);
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + Convert.ToHexString(salt)));

        return (Convert.ToHexString(hash), salt);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt, int keySize, int iterations, HashAlgorithmName algorithm)
    {
        using var sha256 = SHA256.Create();
        var hashToCompare = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + Convert.ToHexString(salt)));

        return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
    }
}

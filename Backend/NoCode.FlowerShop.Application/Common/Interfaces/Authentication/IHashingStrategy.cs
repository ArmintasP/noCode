using System.Security.Cryptography;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Authentication;

public interface IHashingStrategy
{
    (string hashedPassword, byte[] salt) HashPassword(string password, int keySize, int iterations, HashAlgorithmName algorithm);

    bool VerifyPassword(string password, string hash, byte[] salt, int keySize, int iterations, HashAlgorithmName algorithm);
}
using NoCode.FlowerShop.Domain.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace NoCode.FlowerShop.Domain;

public sealed class Customer : Entity<Guid>
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public byte[] Salt { get; }

    [Timestamp]
    public byte[]? Version { get; private set; }
    public Customer(string email, string password, byte[] salt)
    {
        Email = email;
        Password = password;
        Salt = salt;
    }

#pragma warning disable CS8618
    private Customer() { }
#pragma warning restore CS8618
}

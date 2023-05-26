using NoCode.FlowerShop.Domain.Common.Models;

namespace NoCode.FlowerShop.Domain;

public sealed class Administrator : Entity<Guid>
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public byte[] Salt { get; private set; }

    public Administrator(Guid id, string email, string password, byte[] salt)
        : base(id)
    {
        Email = email;
        Password = password;
        Salt = salt;
    }

#pragma warning disable CS8618
    private Administrator() { }
#pragma warning restore CS8618
}

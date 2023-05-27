using NoCode.FlowerShop.Domain.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace NoCode.FlowerShop.Domain;

public sealed class DeliveryLocation : Entity<Guid>
{
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Address { get; private set; }
    public string ZipCode { get; private set; }

    [Timestamp]
    public byte[]? Version { get; private set; }

    public DeliveryLocation(string country, string city, string address, string zipCode)
    {
        Country = country;
        City = city;
        Address = address;
        ZipCode = zipCode;
    }
#pragma warning disable CS8618
    private DeliveryLocation() { }
#pragma warning restore CS8618
}

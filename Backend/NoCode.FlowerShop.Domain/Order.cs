using NoCode.FlowerShop.Domain.Common;
using NoCode.FlowerShop.Domain.Common.Models;

namespace NoCode.FlowerShop.Domain;

public sealed class Order : Entity<Guid>
{
    public DeliveryOption DeliveryOption { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    public DateTime DateTime { get; private set; }
    public string Name{ get; private set; }
    public string Surname{ get; private set; }
    public string PhoneNumber{ get; private set; }
    public List<FlowerArrangementPair> FlowerArrangements { get; private set; }
    public Customer Customer { get; private set; }
    public DeliveryLocation DeliveryLocation { get; private set; }

    public Order(
        DeliveryOption deliveryOption,
        OrderStatus orderStatus,
        string name,
        string surname,
        string phoneNumber,
        List<FlowerArrangementPair> flowerArrangements,
        Customer customer,
        DeliveryLocation deliveryLocation)
    {
        DeliveryOption = deliveryOption;
        OrderStatus = orderStatus;
        Name = name;
        Surname = surname;
        PhoneNumber = phoneNumber;
        FlowerArrangements = flowerArrangements;
        Customer = customer;
        DeliveryLocation = deliveryLocation;
    }
    
#pragma warning disable CS8618
    private Order() { }
#pragma warning restore CS8618
}


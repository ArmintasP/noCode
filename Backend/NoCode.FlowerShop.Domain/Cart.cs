using NoCode.FlowerShop.Domain.Common;
using NoCode.FlowerShop.Domain.Common.Models;

namespace NoCode.FlowerShop.Domain;

public sealed class Cart : Entity<Guid>
{
    public Customer Customer { get; private set; }
    public List<FlowerArrangementPair> FlowerArrangements { get; private set; }

    public Cart(Customer customer, List<FlowerArrangementPair> flowerArrangements)
        : base(Guid.NewGuid())
    {
        Customer = customer;
        FlowerArrangements = flowerArrangements;
    }

    public void AdjustFlowerArrangementQuantity(FlowerArrangement flowerArrangement, uint quantity)
    {
        var flowerArrangementPair = FlowerArrangements.SingleOrDefault(x => x.FlowerArrangement == flowerArrangement);

        if (quantity is 0 && flowerArrangementPair is not null)
        {
            FlowerArrangements.Remove(flowerArrangementPair);
            return;
        }

        flowerArrangementPair ??= new FlowerArrangementPair(flowerArrangement, quantity);
        flowerArrangementPair.Quantity = quantity;
    }

#pragma warning disable CS8618
    private Cart() { }
#pragma warning restore CS8618
}

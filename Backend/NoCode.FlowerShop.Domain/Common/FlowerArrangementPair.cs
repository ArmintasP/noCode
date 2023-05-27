namespace NoCode.FlowerShop.Domain.Common;

public class FlowerArrangementPair
{
    public FlowerArrangement FlowerArrangement { get; private set; }
    public uint Quantity { get; set; }

    public FlowerArrangementPair(FlowerArrangement flowerArrangement, uint quantity)
    {
        FlowerArrangement = flowerArrangement;
        Quantity = quantity;
    }

#pragma warning disable CS8618
    private FlowerArrangementPair() { }
#pragma warning restore CS8618
}

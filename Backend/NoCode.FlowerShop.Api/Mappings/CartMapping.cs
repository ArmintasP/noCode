using Mapster;
using NoCode.FlowerShop.Application.Carts.Delete;
using NoCode.FlowerShop.Application.Customers.Carts;
using NoCode.FlowerShop.Contracts.Cart;
using NoCode.FlowerShop.Contracts.Common;
using NoCode.FlowerShop.Contracts.Customers.Cart;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Api.Mappings;

public sealed class CartMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetCartByCustomerIdResult, GetCartByCustomerIdResponse>();

        config.NewConfig<Cart, CartSection>()
            .Map(dest => dest.CustomerId, src => src.Customer.Id);

        config.NewConfig<DeleteCartResult, DeleteCartResponse>();
    }
}
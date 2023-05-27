using NoCode.FlowerShop.Contracts.Common;

namespace NoCode.FlowerShop.Contracts.Customers.Cart;

public record GetCartByCustomerIdResponse(
    CartSection Cart);
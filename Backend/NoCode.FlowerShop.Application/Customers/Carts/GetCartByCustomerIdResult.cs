using NoCode.FlowerShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCode.FlowerShop.Application.Customers.Carts;
public sealed record GetCartByCustomerIdResult(
    Cart Cart);

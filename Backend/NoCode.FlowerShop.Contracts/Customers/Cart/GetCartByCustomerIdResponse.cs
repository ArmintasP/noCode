﻿using NoCode.FlowerShop.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoCode.FlowerShop.Contracts.Customers.Cart;

public record GetCartByCustomerIdResponse(
    CartSection Cart);
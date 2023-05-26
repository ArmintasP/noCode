using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;


namespace NoCode.FlowerShop.Domain.Common.ErrorsCollection;

public static partial class Errors
{
    public static class Cart
    {
        public static Error NotFound => Error.Conflict(
            code: "Cart.NotFound",
            description: "Cart does not exist.");
    }
}

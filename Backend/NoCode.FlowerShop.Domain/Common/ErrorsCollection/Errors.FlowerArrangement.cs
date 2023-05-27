using ErrorOr;

namespace NoCode.FlowerShop.Domain.Common.ErrorsCollection;
public static partial class Errors
{
    public static class FlowerArrangement
    {
        public static Error NotFound => Error.Conflict(
            code: "FlowerArrangement.NotFound",
            description: "Flower arrangement does not exist.");
    }
}

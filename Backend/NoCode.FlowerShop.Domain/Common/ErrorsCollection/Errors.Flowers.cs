using ErrorOr;

namespace NoCode.FlowerShop.Domain.Common.ErrorsCollection;

public static partial class Errors
{
    public static class Flowers
    {
        public static Error DuplicateName => Error.Conflict(
            code: "Flower.DuplicateName",
            description: "The name is already in use by another flower.");
    }
}
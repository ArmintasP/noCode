using ErrorOr;

namespace NoCode.FlowerShop.Domain.Common.ErrorsCollection;

public static partial class Errors
{
    public static class Flowers
    {
        public static Error DuplicateName => Error.Conflict(
            code: "Flower.DuplicateName",
            description: "The name is already in use by another flower.");

        public static Error NotFound => Error.NotFound(
            code: "Flower.NotFound",
            description: "Can't find flower with matching properties.");
        
        public static Error OutdatedVersion => Error.Failure(
            code: "Flower.Failure",
            description: "Outdated flower information was given. Retry your action.");
    }
}
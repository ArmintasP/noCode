using ErrorOr;

namespace NoCode.FlowerShop.Domain.Common.ErrorsCollection;
public static partial class Errors
{
    public static class FlowerArrangement
    {
        public static Error NotFound=> Error.NotFound(
            code: "FlowerArrangement.NotFound",
            description: "Flower arrangement does not exist.");

        public static Error DuplicateName => Error.Conflict(
            code: "FlowerArrangement.DuplicateName",
            description: "Flower arrangement with given name already exists.");

        public static Error CategoryNotFound => Error.NotFound(
            code: "FlowerArrangement.CategoryNotFound",
            description: "Category with the given id not found.");

        public static Error FlowerNotFound => Error.NotFound(
            code: "FlowerArrangement.FlowerNotFound",
            description: "Flower with the given id not found.");
    }
}

using ErrorOr;

namespace NoCode.FlowerShop.Domain.Common.ErrorsCollection;

public static partial class Errors
{
    public static class Customer
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "Customer.DuplicateEmail",
            description: "The email is already in use by another customer.");

        public static Error InvalidCredentials => Error.Conflict(
            code: "Authentication.InvalidCredentials",
            description: "Invalid email or password.");

        public static Error Unauthorized => Error.Conflict(
            code: "Customer.Unauthorized",
            description: "Unauthorized access.");
    }
}

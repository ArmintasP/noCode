using ErrorOr;

namespace NoCode.FlowerShop.Domain.Common.ErrorsCollection;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict(
            code: "Authentication.InvalidCredentials",
            description: "Invalid username or password.");
    }
}

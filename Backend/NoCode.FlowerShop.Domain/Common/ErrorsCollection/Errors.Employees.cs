using ErrorOr;

namespace NoCode.FlowerShop.Domain.Common.ErrorsCollection;

public static partial class Errors
{
    public static class Administrator
    {
        public static Error InvalidCredentials => Error.Conflict(
            code: "Authentication.InvalidCredentials",
            description: "Invalid email or password.");
    }
}

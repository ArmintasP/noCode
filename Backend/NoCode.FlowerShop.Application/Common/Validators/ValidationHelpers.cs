using System.Text.RegularExpressions;

namespace NoCode.FlowerShop.Application.Common.Validators;

public static class ValidationHelpers
{
    public static bool BeValidUrl(string url)
    {
        // This regular expression is used to validate URLs
        const string pattern 
            = @"^[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)$";

        var regex = new Regex(pattern);
        return regex.IsMatch(url);
    }
}
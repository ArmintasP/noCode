﻿using System.Text.RegularExpressions;
using FluentValidation;

namespace NoCode.FlowerShop.Application.Common.Behaviors;

public static class ValidationExtensions
{
    public static IRuleBuilderOptionsConditions<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minLength = 8, int maxLength = 32)
    {
        return ruleBuilder.Custom((password, context) =>
        {
            if (string.IsNullOrWhiteSpace(password))
                context.AddFailure("Password cannot be empty");
            if (password.Length < minLength)
                context.AddFailure($"Password must be at least {minLength} characters long");
            if (password.Length > maxLength)
                context.AddFailure($"Password must be at most {maxLength} characters long");
            if (!password.Any(char.IsUpper))
                context.AddFailure("Password must contain at least one uppercase letter");
            if (!password.Any(char.IsLower))
                context.AddFailure("Password must contain at least one lowercase letter");
            if (!password.Any(char.IsDigit))
                context.AddFailure("Password must contain at least one digit");
        });
    }
    
    public static IRuleBuilderOptionsConditions<T, string> ValidUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Custom((url, context) =>
        {
            const string pattern 
                = @"^[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)$";

            var regex = new Regex(pattern);

            if (!regex.IsMatch(url))
            {
                context.AddFailure("The URL is not valid.");
            }
        });
    }
}

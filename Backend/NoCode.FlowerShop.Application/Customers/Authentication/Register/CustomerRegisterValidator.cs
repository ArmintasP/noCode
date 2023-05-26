using FluentValidation;
using NoCode.FlowerShop.Application.Common.Behaviors;

namespace NoCode.FlowerShop.Application.Customers.Authentication.Register;

public sealed class CustomerRegisterValidator : AbstractValidator<CustomerRegisterCommand>
{
    private const int MaxEmailLength = 80;

    public CustomerRegisterValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(MaxEmailLength);

        RuleFor(x => x.Password).Password();
    }
}

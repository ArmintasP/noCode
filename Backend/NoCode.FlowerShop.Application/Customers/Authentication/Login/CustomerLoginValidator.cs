using FluentValidation;

namespace NoCode.FlowerShop.Application.Customers.Authentication.Login;

public sealed class CustomerLoginValidator : AbstractValidator<CustomerLoginQuery>
{
    public CustomerLoginValidator()
    {
        RuleFor(x => x.Email).EmailAddress();

        RuleFor(x => x.Password).NotEmpty();
    }
}

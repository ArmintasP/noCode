using FluentValidation;

namespace NoCode.FlowerShop.Application.Administrators.Authentication.Login;

public sealed class AdministratorLoginValidator : AbstractValidator<AdministratorLoginQuery>
{
    public AdministratorLoginValidator()
    {
        RuleFor(x => x.Email).EmailAddress();

        RuleFor(x => x.Password).NotEmpty();
    }
}

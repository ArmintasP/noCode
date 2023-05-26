using FluentValidation;
using NoCode.FlowerShop.Application.Common.Behaviors;

namespace NoCode.FlowerShop.Application.Flowers.Create;

public class CreateFlowerValidator : AbstractValidator<CreateFlowerCommand>
{
    public CreateFlowerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.ImageUrl)
            .ValidUrl();
    }
}
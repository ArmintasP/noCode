using FluentValidation;
using NoCode.FlowerShop.Application.Common.Behaviors;

namespace NoCode.FlowerShop.Application.Flowers.Update;

public class UpdateFlowerCommandValidator : AbstractValidator<UpdateFlowerCommand>
{
    public UpdateFlowerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .When(x => x.Name != null);

        RuleFor(x => x.ImageUrl)
            .Must(ValidationExtensions.IsValidUrl)
            .WithMessage("ImageUrl is not a valid URL")
            .When(x => !string.IsNullOrWhiteSpace(x.ImageUrl));
    }
}
using FluentValidation;
using NoCode.FlowerShop.Application.Common.Behaviors;

namespace NoCode.FlowerShop.Application.FlowerArrangements.Create;

public sealed class CreateFlowerArrangementValidator : AbstractValidator<CreateFlowerArrangementCommand>
{
    public CreateFlowerArrangementValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty()
           .MaximumLength(64);

        RuleFor(x => x.Description)
           .NotEmpty()
           .MaximumLength(256);

        RuleFor(x => x.ImageUrl)
           .MaximumLength(256)
           .ValidUrl();
           
        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.StorageQuantity)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Flowers)
            .NotEmpty();

        RuleForEach(x => x.Flowers).ChildRules(child =>
            child.RuleFor(flower => flower.Quantity)
                .GreaterThan(0)
        );
    }
}

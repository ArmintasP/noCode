using FluentValidation;

namespace NoCode.FlowerShop.Application.FlowerArrangements.GetFlowerArrangementById;

public sealed class GetFlowerArrangementByIdValidator : AbstractValidator<GetFlowerArrangementByIdQuery>
{
    public GetFlowerArrangementByIdValidator()
    {
        RuleFor(x => x.id).NotEmpty();
    }
}
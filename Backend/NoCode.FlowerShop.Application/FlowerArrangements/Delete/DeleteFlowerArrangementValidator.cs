using FluentValidation;

namespace NoCode.FlowerShop.Application.FlowerArrangements.Delete;
public sealed class DeleteFlowerArrangementValidator : AbstractValidator<DeleteFlowerArrangementCommand>
{
    public DeleteFlowerArrangementValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
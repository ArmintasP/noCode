using MediatR;
using ErrorOr;

namespace NoCode.FlowerShop.Application.Flowers.Update;

public sealed record UpdateFlowerCommand(Guid Id, string? Name, string? ImageUrl)
    : IRequest<ErrorOr<UpdateFlowerResult>>;
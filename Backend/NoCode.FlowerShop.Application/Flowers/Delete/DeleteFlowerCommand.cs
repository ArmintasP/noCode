using MediatR;
using ErrorOr;

namespace NoCode.FlowerShop.Application.Flowers.Delete;

public sealed record DeleteFlowerCommand(Guid Id)
    : IRequest<ErrorOr<DeleteFlowerResult>>;
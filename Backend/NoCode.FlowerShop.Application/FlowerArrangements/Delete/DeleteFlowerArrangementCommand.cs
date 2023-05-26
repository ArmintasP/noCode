using ErrorOr;
using MediatR;

namespace NoCode.FlowerShop.Application.FlowerArrangements.Delete;
public sealed record DeleteFlowerArrangementCommand(Guid Id) : IRequest<ErrorOr<DeleteFlowerArrangementResult>>;

public sealed record DeleteFlowerArrangementResult();
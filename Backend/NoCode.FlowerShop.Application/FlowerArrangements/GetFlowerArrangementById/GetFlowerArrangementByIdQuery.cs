using ErrorOr;
using MediatR;

namespace NoCode.FlowerShop.Application.FlowerArrangements.GetFlowerArrangementById;

public sealed record GetFlowerArrangementByIdQuery(Guid id) : IRequest<ErrorOr<GetFlowerArrangementByIdResult>>;

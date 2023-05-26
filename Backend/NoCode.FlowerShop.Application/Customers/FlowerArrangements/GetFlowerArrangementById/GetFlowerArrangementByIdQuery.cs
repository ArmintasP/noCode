using ErrorOr;
using MediatR;

namespace NoCode.FlowerShop.Application.Customers.FlowerArrangements.GetFlowerArrangementById;

public sealed record GetFlowerArrangementByIdQuery(Guid id) : IRequest<ErrorOr<GetFlowerArrangementByIdResult>>;

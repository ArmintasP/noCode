using ErrorOr;
using MediatR;

namespace NoCode.FlowerShop.Application.Flowers.Delete;

public sealed record GetAllFlowersQuery()
    : IRequest<ErrorOr<GetAllFlowersResult>>;
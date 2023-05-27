using ErrorOr;
using MediatR;

namespace NoCode.FlowerShop.Application.FlowerArrangements.Create;

public sealed record CreateFlowerArrangementCommand(
    string Name,
    string Description,
    string ImageUrl,
    decimal Price,
    int StorageQuantity,
    Flowers[] Flowers,
    Guid CategoryId)
    : IRequest<ErrorOr<CreateFlowerArrangementResult>>;

public sealed record Flowers(Guid Id, int Quantity);
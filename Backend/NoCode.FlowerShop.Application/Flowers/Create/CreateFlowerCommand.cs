using ErrorOr;
using MediatR;

namespace NoCode.FlowerShop.Application.Flowers.Create;

public record CreateFlowerCommand(string Name, string ImageUrl) 
    : IRequest<ErrorOr<CreateFlowerResult>>;
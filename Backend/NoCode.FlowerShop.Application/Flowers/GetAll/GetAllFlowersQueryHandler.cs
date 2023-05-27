using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

namespace NoCode.FlowerShop.Application.Flowers.Delete;

public class GetAllFlowersQueryHandler : IRequestHandler<GetAllFlowersQuery, ErrorOr<GetAllFlowersResult>>
{
    private readonly IFlowerRepository _flowerRepository;

    public GetAllFlowersQueryHandler(IFlowerRepository flowerRepository)
    {
        _flowerRepository = flowerRepository;
    }

    public async Task<ErrorOr<GetAllFlowersResult>> Handle(GetAllFlowersQuery request, CancellationToken cancellationToken)
    {
        var flowers = _flowerRepository.GetAll().ToList();
        return new GetAllFlowersResult(flowers);
    }
}
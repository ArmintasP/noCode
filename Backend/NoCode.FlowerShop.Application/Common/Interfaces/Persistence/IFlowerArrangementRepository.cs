using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface IFlowerArrangementRepository
{
    Task AddAsync(FlowerArrangement flowerArrangement, CancellationToken token = default);
    Task<List<FlowerArrangement>> GetAllAsync(CancellationToken token = default);
    Task<FlowerArrangement?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task UpdateAsync(FlowerArrangement flowerArrangement, CancellationToken token = default);
}

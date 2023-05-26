using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface IFlowerRepository
{
    Task AddAsync(Flower flower, CancellationToken token = default);
    Task<Flower?> GetByNameAsync(string name, CancellationToken token = default);
    Task<List<Flower>> GetAllAsync(CancellationToken token = default);
    Task<Flower?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task UpdateAsync(Flower flower, CancellationToken token = default);
}

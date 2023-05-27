using ErrorOr;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface IFlowerRepository
{
    Task<Flower> AddAsync(Flower flower, CancellationToken token = default);
    Task<Flower?> GetByNameAsync(string name, CancellationToken token = default);
    IQueryable<Flower> GetAll();
    Task<Flower?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task<ErrorOr<Flower>> UpdateAsync(Flower flower, CancellationToken token = default);
    Task DeleteByIdAsync(Flower flower, CancellationToken token = default);
}

using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface IFlowerArrangementCategoryRepository
{
    Task AddAsync(FlowerArrangementCategory flowerArrangementCategory, CancellationToken token = default);
    Task<FlowerArrangementCategory?> GetById(Guid id, CancellationToken token = default);
    IQueryable<FlowerArrangementCategory> GetAll();
    Task UpdateAsync(FlowerArrangementCategory flowerArrangementCategory, CancellationToken token = default);
}

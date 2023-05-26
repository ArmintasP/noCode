using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Repositories;

public sealed class FlowerArrangementCategoryRepository : IFlowerArrangementCategoryRepository
{
    private readonly FlowerShopDbContext _dbContext;

    public FlowerArrangementCategoryRepository(FlowerShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(FlowerArrangementCategory flowerArrangementCategory, CancellationToken token = default)
    {
        await _dbContext.AddAsync(flowerArrangementCategory, token);
        await _dbContext.SaveChangesAsync(token);
    }

    public IQueryable<FlowerArrangementCategory> GetAll()
    {
        return _dbContext.FlowerArrangementCategories;
    }

    public Task<FlowerArrangementCategory?> GetById(Guid id, CancellationToken token = default)
    {
        return _dbContext.FlowerArrangementCategories.SingleOrDefaultAsync(f => f.Id == id, token);
    }

    public Task UpdateAsync(FlowerArrangementCategory flowerArrangementCategory, CancellationToken token = default)
    {
        _dbContext.Update(flowerArrangementCategory);
        return _dbContext.SaveChangesAsync(token);
    }
}

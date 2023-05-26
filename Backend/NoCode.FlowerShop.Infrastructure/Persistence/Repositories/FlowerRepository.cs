using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Repositories;

public sealed class FlowerRepository : IFlowerRepository
{
    private readonly FlowerShopDbContext _dbContext;

    public FlowerRepository(FlowerShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Flower> AddAsync(Flower flower, CancellationToken token = default)
    {
        var createdFlower = await _dbContext.AddAsync(flower, token);
        await _dbContext.SaveChangesAsync(token);

        return createdFlower.Entity;
    }

    public IQueryable<Flower> GetAll()
    {
        return _dbContext.Flowers;
    }

    public Task<Flower?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _dbContext.Flowers.SingleOrDefaultAsync(f => f.Id == id, token);
    }

    public Task<Flower?> GetByNameAsync(string name, CancellationToken token = default)
    {
        return _dbContext.Flowers.SingleOrDefaultAsync(f => f.Name == name, token);
    }

    public Task UpdateAsync(Flower flower, CancellationToken token = default)
    {
        _dbContext.Update(flower);
        return _dbContext.SaveChangesAsync(token);
    }
}

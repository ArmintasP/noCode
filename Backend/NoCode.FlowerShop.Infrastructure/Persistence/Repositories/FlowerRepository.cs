using ErrorOr;
using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

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

    public async Task<ErrorOr<Flower>> UpdateAsync(Flower flower, CancellationToken token = default)
    {
        var updatedFlower = _dbContext.Update(flower);

        try
        {
            await _dbContext.SaveChangesAsync(token);
            return updatedFlower.Entity;
        }
        catch (DbUpdateConcurrencyException _)
        {
            return Errors.Flowers.OutdatedVersion;
        }
    }

    public async Task DeleteByIdAsync(Flower flower, CancellationToken token = default)
    {
        _dbContext.Remove(flower);
        await _dbContext.SaveChangesAsync(token);
    }
}

﻿using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Repositories;
public sealed class FlowerArrangementRepository : IFlowerArrangementRepository
{
    private readonly FlowerShopDbContext _dbContext;

    public FlowerArrangementRepository(FlowerShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(FlowerArrangement flowerArrangement, CancellationToken token = default)
    {
        await _dbContext.AddAsync(flowerArrangement, token);
        await _dbContext.SaveChangesAsync(token);
    }

    public Task DeleteAsync(FlowerArrangement flowerArrangement, CancellationToken token = default)
    {
        _dbContext.Remove(flowerArrangement);
        return _dbContext.SaveChangesAsync(token);
    }

    public IQueryable<FlowerArrangement> GetAll()
    {
        return _dbContext.FlowerArrangements
            .Include(f => f.FlowerArrangementCategory)
            .Include(f => f.Flowers)
            .ThenInclude(f => f.Flower);
    }
    
    public Task<FlowerArrangement?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _dbContext.FlowerArrangements
            .Include(f => f.FlowerArrangementCategory)
            .Include(f => f.Flowers)
            .ThenInclude(f => f.Flower)
            .SingleOrDefaultAsync(f => f.Id == id, token);
    }

    public Task UpdateAsync(FlowerArrangement flowerArrangement, CancellationToken token = default)
    {
        _dbContext.Update(flowerArrangement);
        return _dbContext.SaveChangesAsync(token);
    }
}

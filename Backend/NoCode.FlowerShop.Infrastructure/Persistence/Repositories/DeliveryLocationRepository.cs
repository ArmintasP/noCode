using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Repositories;

public sealed class DeliveryLocationRepository : IDeliveryLocationRepository
{
    private readonly FlowerShopDbContext _dbContext;

    public DeliveryLocationRepository(FlowerShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(DeliveryLocation deliveryLocation, CancellationToken token = default)
    {
        await _dbContext.AddAsync(deliveryLocation, token);
        await _dbContext.SaveChangesAsync(token);
    }

    public Task<DeliveryLocation?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _dbContext.DeliveryLocations.SingleOrDefaultAsync(d => d.Id == id, token);
    }

    public Task UpdateAsync(DeliveryLocation deliveryLocation, CancellationToken token = default)
    {
        _dbContext.Update(deliveryLocation);
        return _dbContext.SaveChangesAsync(token);
    }
}

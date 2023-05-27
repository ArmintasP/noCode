using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Repositories;

public class CartRepository : ICartRepository
{
    private readonly FlowerShopDbContext _dbContext;

    public CartRepository(FlowerShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Cart cart, CancellationToken token = default)
    {
        await _dbContext.AddAsync(cart, token);
        await _dbContext.SaveChangesAsync(token);
    }

    public Task<Cart?> GetByCustomerId(Guid customerId, CancellationToken token = default)
    {
        return _dbContext.Carts
            .Include(c => c.Customer)
            .Include(c => c.FlowerArrangements)
            .ThenInclude(fa => fa.FlowerArrangement)
            .SingleOrDefaultAsync(c => c.Customer.Id == customerId, token);
    }

    public Task UpdateAsync(Cart cart, CancellationToken token = default)
    {
        _dbContext.Update(cart);
        return _dbContext.SaveChangesAsync(token);
    }

    public async Task DeleteByCustomerIdAsync(Cart cart, CancellationToken token = default)
    {
        _dbContext.Remove(cart);
        await _dbContext.SaveChangesAsync(token);
    }
}

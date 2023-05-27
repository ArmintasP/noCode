using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Repositories;

public sealed class OrderRepository : IOrderRepository
{
    private readonly FlowerShopDbContext _dbContext;

    public OrderRepository(FlowerShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Order order, CancellationToken token = default)
    {
        await _dbContext.AddAsync(order, token);
        await _dbContext.SaveChangesAsync(token);
    }

    public IQueryable<Order> GetAll()
    {
        return _dbContext.Orders;
    }

    public IQueryable<Order> GetAllByCustomerId(Guid customerId, CancellationToken token = default)
    {
        return _dbContext.Orders.Where(o => o.Customer.Id == customerId);
    }

    public Task<Order?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return _dbContext.Orders.SingleOrDefaultAsync(o => o.Id == id, token);
    }

    public Task UpdateAsync(Order order, CancellationToken token = default)
    {
        _dbContext.Update(order);
        return _dbContext.SaveChangesAsync(token);
    }
}

using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Repositories;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly FlowerShopDbContext _dbContext;

    public CustomerRepository(FlowerShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(Customer customer, CancellationToken token = default)
    {
        await _dbContext.AddAsync(customer, token);
        await _dbContext.SaveChangesAsync(token);
    }
    
    public Task<Customer?> GetCustomerByEmailAsync(string email, CancellationToken token = default)
    {
        return _dbContext.Customers.SingleOrDefaultAsync(c => c.Email == email, token);
    }

    public Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken token = default)
    {
        return _dbContext.Customers.SingleOrDefaultAsync(c => c.Id == id, token);
    }

    public Task UpdateAsync(Customer customer, CancellationToken token = default)
    {
        _dbContext.Update(customer);
        return _dbContext.SaveChangesAsync(token);
    }
}

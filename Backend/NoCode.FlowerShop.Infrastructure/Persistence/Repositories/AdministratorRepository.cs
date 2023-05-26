using Microsoft.EntityFrameworkCore;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence.Repositories;

public sealed class AdministratorRepository : IAdministratorRepository
{
    private readonly FlowerShopDbContext _dbContext;

    public AdministratorRepository(FlowerShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Administrator administrator, CancellationToken token = default)
    {
        await _dbContext.AddAsync(administrator, token);
        await _dbContext.SaveChangesAsync(token);
    }

    public Task<Administrator?> GetAdministratorByEmailAsync(string email, CancellationToken token = default)
    {
        return _dbContext.Administrators.SingleOrDefaultAsync(a => a.Email == email, token);
    }

    public Task<Administrator?> GetAdministratorByIdAsync(Guid id, CancellationToken token = default)
    {
        return _dbContext.Administrators.SingleOrDefaultAsync(a => a.Id == id, token);
    }

    public Task UpdateAsync(Administrator administrator, CancellationToken token = default)
    {
        _dbContext.Update(administrator);
        return _dbContext.SaveChangesAsync(token);
    }
}

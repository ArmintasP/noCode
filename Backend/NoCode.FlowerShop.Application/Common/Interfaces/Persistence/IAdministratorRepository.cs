using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface IAdministratorRepository
{
    Task AddAsync(Administrator administrator, CancellationToken token = default);
    Task<Administrator?> GetAdministratorByEmailAsync(string email, CancellationToken token = default);
    Task<Administrator?> GetAdministratorByIdAsync(Guid id, CancellationToken token = default);
    Task UpdateAsync(Administrator administrator, CancellationToken token = default);
}

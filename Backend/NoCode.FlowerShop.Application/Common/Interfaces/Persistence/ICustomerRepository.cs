using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer, CancellationToken token = default);
    Task<Customer?> GetCustomerByEmailAsync(string email, CancellationToken token = default);
    Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken token = default);
    Task UpdateAsync(Customer customer, CancellationToken token = default);
}

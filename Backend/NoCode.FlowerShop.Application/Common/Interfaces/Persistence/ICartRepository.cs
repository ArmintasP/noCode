using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface ICartRepository
{
    Task AddAsync(Cart cart, CancellationToken token = default);
    Task<Cart?> GetByCustomerId(Guid customerId, CancellationToken token = default);
    Task UpdateAsync(Cart cart, CancellationToken token = default);
    Task DeleteByCustomerIdAsync(Cart cart, CancellationToken token = default);
}

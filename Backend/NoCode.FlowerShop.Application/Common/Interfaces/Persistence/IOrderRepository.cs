using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken token = default);
    IQueryable<Order> GetAll();
    IQueryable<Order> GetAllByCustomerId(Guid customerId, CancellationToken token = default);
    Task<Order?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task UpdateAsync(Order order, CancellationToken token = default);
}

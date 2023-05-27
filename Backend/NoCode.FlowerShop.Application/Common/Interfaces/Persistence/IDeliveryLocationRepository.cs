using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface IDeliveryLocationRepository
{
    Task AddAsync(DeliveryLocation deliveryLocation, CancellationToken token = default);
    Task<DeliveryLocation?> GetByIdAsync(Guid id, CancellationToken token = default);
    Task UpdateAsync(DeliveryLocation deliveryLocation, CancellationToken token = default);
}

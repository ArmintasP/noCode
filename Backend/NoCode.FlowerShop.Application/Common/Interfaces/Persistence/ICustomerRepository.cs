using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Application.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    Guid NextIdentity();
    Task<Customer?> GetCustomerByEmail(string email);
    Task<Customer?> GetCustomerById(Guid id);
    Task Add(Customer customer);
    Task Update(Customer customer);
}

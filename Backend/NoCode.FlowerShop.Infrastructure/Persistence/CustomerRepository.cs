using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;

namespace NoCode.FlowerShop.Infrastructure.Persistence;

public sealed class CustomerRepository : ICustomerRepository
{
    private static readonly List<Customer> _customers = new();

    // If it was a db, we would get generated id from there.
    // Ideally, it would be better to have keys as GUID instead of ints (as it is required by the documentation).

    public Guid NextIdentity()
    {
        return Guid.NewGuid();
    }

    public Task Add(Customer customer)
    {
        _customers.Add(customer);
        return Task.CompletedTask;
    }

    public Task<Customer?> GetCustomerByEmail(string email)
    {
        var customer = _customers.SingleOrDefault(c =>c.Email == email);
        return Task.FromResult(customer);
    }

    public Task<Customer?> GetCustomerById(Guid id)
    {
        var customer = _customers.SingleOrDefault(c => c.Id == id);
        return Task.FromResult(customer);
    }

    public Task Update(Customer customer)
    {
        var index = _customers.FindIndex(c => c.Id == customer.Id);
        _customers[index] = customer;
        return Task.CompletedTask;
    }
}

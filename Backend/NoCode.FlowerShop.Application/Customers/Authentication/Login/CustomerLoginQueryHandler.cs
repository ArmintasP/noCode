using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Application.Customers.Authentication.Common;
using NoCode.FlowerShop.Domain;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.Customers.Authentication.Login;

public sealed class CustomerLoginQueryHandler :
    IRequestHandler<CustomerLoginQuery, ErrorOr<CustomerAuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ICustomerRepository _customerRepository;
    private readonly IPasswordProvider _passwordProvider;

    public CustomerLoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        ICustomerRepository customerRepository,
        IPasswordProvider passwordProvider)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _customerRepository = customerRepository;
        _passwordProvider = passwordProvider;
    }

    public async Task<ErrorOr<CustomerAuthenticationResult>> Handle(
        CustomerLoginQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerByEmailAsync(request.Email);
        if (customer is null)
            return Errors.Customer.InvalidCredentials;

        if (IsCorrectPassword(request, customer))
            return Errors.Customer.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(customer);
        return new CustomerAuthenticationResult(customer, token);
    }

    private bool IsCorrectPassword(CustomerLoginQuery request, Customer customer)
    {
        return !_passwordProvider.VerifyPassword(request.Password, customer.Password, customer.Salt);
    }
}

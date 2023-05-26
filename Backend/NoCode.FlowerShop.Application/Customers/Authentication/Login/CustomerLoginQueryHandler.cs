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
    private readonly IPasswordProvider _passwordHasher;

    public CustomerLoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        ICustomerRepository customerRepository,
        IPasswordProvider passwordHasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _customerRepository = customerRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<CustomerAuthenticationResult>> Handle(
        CustomerLoginQuery request,
        CancellationToken cancellationToken)
    {
        if (await _customerRepository.GetCustomerByEmail(request.Email) is not Customer customer)
            return Errors.Customer.InvalidCredentials;

        if (!_passwordHasher.VerifyPassword(request.Password, customer.Password, customer.Salt))
            return Errors.Customer.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(customer);
        return new CustomerAuthenticationResult(customer, token);
    }
}

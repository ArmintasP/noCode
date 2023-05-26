using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Application.Customers.Authentication.Common;
using NoCode.FlowerShop.Domain;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.Customers.Authentication.Register;

public sealed class CustomerRegisterCommandHandler :
    IRequestHandler<CustomerRegisterCommand, ErrorOr<CustomerAuthenticationResult>>

{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ICustomerRepository _customerRepository;
    private readonly IPasswordProvider _passwordHasher;

    public CustomerRegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        ICustomerRepository customerRepository,
        IPasswordProvider passwordHasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _customerRepository = customerRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<ErrorOr<CustomerAuthenticationResult>> Handle(
        CustomerRegisterCommand request,
        CancellationToken cancellationToken)
    {
        if (await _customerRepository.GetCustomerByEmail(request.Email) is not null)
            return Errors.Customer.DuplicateEmail;

        var (hashedPassword, salt) = _passwordHasher.HashPassword(request.Password);

        var customer = new Customer(
            _customerRepository.NextIdentity(),
            request.Email,
            hashedPassword,
            salt);
        await _customerRepository.Add(customer);

        var token = _jwtTokenGenerator.GenerateToken(customer);
        return new CustomerAuthenticationResult(customer, token);
    }
}

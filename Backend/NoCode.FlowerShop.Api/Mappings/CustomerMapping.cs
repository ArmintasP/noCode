using Mapster;
using NoCode.FlowerShop.Application.Customers.Authentication.Common;
using NoCode.FlowerShop.Application.Customers.Authentication.Login;
using NoCode.FlowerShop.Application.Customers.Authentication.Register;
using NoCode.FlowerShop.Contracts.Customers.Authentication;

namespace NoCode.FlowerShop.Api.Mappings;

public sealed class CustomerMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CustomerAuthenticationResult, CustomerAuthenticationResponse>();
        config.NewConfig<CustomerRegisterRequest, CustomerRegisterCommand>();
        config.NewConfig<CustomerLoginRequest, CustomerLoginQuery>();
    }
}

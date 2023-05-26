using Mapster;
using NoCode.FlowerShop.Application.Administrators.Authentication.Login;
using NoCode.FlowerShop.Contracts.Employees.Authentication;

namespace NoCode.FlowerShop.Api.Mappings;

public sealed class AdministratorsMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AdministratorLoginRequest, AdministratorLoginQuery>();
        config.NewConfig<AdministratorAuthenticationResult, AdministratorAuthenticationResponse>()
            .Map(dest => dest, src => src.Administrator);
    }
}


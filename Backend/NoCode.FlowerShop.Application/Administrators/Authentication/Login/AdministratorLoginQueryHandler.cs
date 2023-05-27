using ErrorOr;
using MediatR;
using NoCode.FlowerShop.Application.Common.Interfaces.Authentication;
using NoCode.FlowerShop.Application.Common.Interfaces.Persistence;
using NoCode.FlowerShop.Domain;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;

namespace NoCode.FlowerShop.Application.Administrators.Authentication.Login;

public sealed class AdministratorLoginQueryHandler : IRequestHandler<AdministratorLoginQuery, ErrorOr<AdministratorAuthenticationResult>>
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IPasswordProvider _passwordProvider;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AdministratorLoginQueryHandler(
        IAdministratorRepository administratorRepository, 
        IJwtTokenGenerator jwtTokenGenerator, 
        IPasswordProvider passwordProvider)
    {
        _administratorRepository = administratorRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordProvider = passwordProvider;
    }

    public async Task<ErrorOr<AdministratorAuthenticationResult>> Handle(AdministratorLoginQuery request, CancellationToken cancellationToken)
    {
        var administrator = await _administratorRepository.GetAdministratorByEmailAsync(request.Email);

        if (administrator is null)
            return Errors.Administrator.InvalidCredentials;
        
        if(IsCorrectPassword(request, administrator))
            return Errors.Administrator.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(administrator);
        return new AdministratorAuthenticationResult(administrator, token);
    }

    private bool IsCorrectPassword(AdministratorLoginQuery request, Administrator administrator)
    {
        return _passwordProvider.VerifyPassword(request.Password, administrator.Password, administrator.Salt);
    }
}

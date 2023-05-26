using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoCode.FlowerShop.Application.Administrators.Authentication.Login;
using NoCode.FlowerShop.Contracts.Employees.Authentication;

namespace NoCode.FlowerShop.Api.Controllers;

[Route("administrators")]
public class AdministratorsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public AdministratorsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(AdministratorLoginRequest request)
    {
        var query = _mapper.Map<AdministratorLoginQuery>(request);
        var result = await _mediator.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<AdministratorAuthenticationResponse>(result)),
            errors => Problem(errors));
    }
}


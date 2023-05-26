using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoCode.FlowerShop.Application.Customers.Authentication.Login;
using NoCode.FlowerShop.Application.Customers.Authentication.Register;
using NoCode.FlowerShop.Contracts.Customers.Authentication;

namespace NoCode.FlowerShop.Api.Controllers;

[Route("customers")]
public class CustomersController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public CustomersController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(CustomerRegisterRequest request)
    {
        var command = _mapper.Map<CustomerRegisterCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<CustomerAuthenticationResponse>(result)),
            errors => Problem(errors));
    }
    
    [HttpGet("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(CustomerLoginRequest request)
    {
        var query = _mapper.Map<CustomerLoginQuery>(request);
        var result = await _mediator.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<CustomerAuthenticationResponse>(result)),
            errors => Problem(errors));
    }
}

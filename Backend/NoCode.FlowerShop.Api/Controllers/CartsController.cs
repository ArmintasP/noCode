using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoCode.FlowerShop.Api.Attributes;
using NoCode.FlowerShop.Application.Carts.Delete;
using NoCode.FlowerShop.Application.Customers.Carts;
using NoCode.FlowerShop.Application.Customers.Carts.Create;
using NoCode.FlowerShop.Contracts.Cart;
using NoCode.FlowerShop.Contracts.Customers.Cart;
using NoCode.FlowerShop.Domain.Common;
using NoCode.FlowerShop.Domain.Common.ErrorsCollection;
using System.Security.Claims;

namespace NoCode.FlowerShop.Api.Controllers;

[Route("cart")]
public class CartsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public CartsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{customerId}")]
    [AuthorizeRoles(UserRole.Customer)]
    public async Task<IActionResult> GetCartByCustomerId(Guid customerId)
    {
        var subjectIdString = GetClaimValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(subjectIdString, out var subjectId))
            return Problem(new() { Errors.Customer.Unauthorized });

        if (subjectId != customerId)
            return Problem(new() { Errors.Customer.Unauthorized });

        var query = new GetCartByCustomerIdQuery(customerId);
        var result = await _mediator.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<GetCartByCustomerIdResponse>(result)),
            errors => Problem(errors));
    }
    /*
    [HttpPost("")]
    [AuthorizeRoles(UserRole.Customer)]
    public async Task<IActionResult> Create(CreateCartRequest request)
    {
        var query = _mapper.Map<CreateCartCommand>(request);
        var result = await _mediator.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<CreateCartResponse>(result)),
            errors => Problem(errors));
    }*/

    [HttpDelete("{customerId}")]
    [AuthorizeRoles(UserRole.Customer)]
    public async Task<IActionResult> Delete(Guid customerId)
    {
        var subjectIdString = GetClaimValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(subjectIdString, out var subjectId))
            return Problem(new() { Errors.Customer.Unauthorized });

        if (subjectId != customerId)
            return Problem(new() { Errors.Customer.Unauthorized });

        var command = new DeleteCartCommand(customerId);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<DeleteCartResponse>(result)),
            errors => Problem(errors));
    }
}

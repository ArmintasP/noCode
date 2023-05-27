using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoCode.FlowerShop.Api.Attributes;
using NoCode.FlowerShop.Application.Customers.Carts;
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
}

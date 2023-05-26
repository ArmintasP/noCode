using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoCode.FlowerShop.Application.Customers.FlowerArrangements.GetAvailableFlowerArragementsList;
using NoCode.FlowerShop.Contracts.Customers.FlowerArrangements;

namespace NoCode.FlowerShop.Api.Controllers;

[Route("flower-arrangements")]
public class FlowerArrangementsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public FlowerArrangementsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("available")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAvailableFlowerArrangementsList()
    {
        var query = new AvailableFlowerArrangementsQuery();
        var result = await _mediator.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<AvailableFlowerArrangementsResponse>(result)),
            errors => Problem(errors));
    }

}


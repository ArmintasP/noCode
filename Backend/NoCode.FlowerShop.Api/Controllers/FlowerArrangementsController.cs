using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoCode.FlowerShop.Api.Attributes;
using NoCode.FlowerShop.Application.FlowerArrangements.Delete;
using NoCode.FlowerShop.Application.FlowerArrangements.GetAvailableFlowerArragementsList;
using NoCode.FlowerShop.Application.FlowerArrangements.GetFlowerArrangementById;
using NoCode.FlowerShop.Contracts.FlowerArrangements;
using NoCode.FlowerShop.Domain.Common;

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

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFlowerArrangementById(Guid id)
    {
        var query = new GetFlowerArrangementByIdQuery(id);
        var result = await _mediator.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<GetFlowerArrangementByIdResponse>(result)),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    [AuthorizeRoles(UserRole.Administrator)]
    public async Task<IActionResult> DeleteFlowerArrangement(Guid id)
    {
        var command = new DeleteFlowerArrangementCommand(id);
        var result = await _mediator.Send(command);

        return result.Match(
            result => NoContent(),
            errors => Problem(errors));
    }
}
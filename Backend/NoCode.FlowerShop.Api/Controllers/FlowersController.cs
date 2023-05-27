using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoCode.FlowerShop.Api.Attributes;
using NoCode.FlowerShop.Application.Flowers.Create;
using NoCode.FlowerShop.Application.Flowers.Delete;
using NoCode.FlowerShop.Application.Flowers.Update;
using NoCode.FlowerShop.Contracts.Flowers;
using NoCode.FlowerShop.Domain.Common;

namespace NoCode.FlowerShop.Api.Controllers;

[Route("flowers")]
public class FlowersController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public FlowersController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("")]
    [AuthorizeRoles(UserRole.Administrator)]
    public async Task<IActionResult> Create(CreateFlowerRequest request)
    {
        var command = _mapper.Map<CreateFlowerCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<CreateFlowerResponse>(result)),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    [AuthorizeRoles(UserRole.Administrator)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteFlowerCommand(id);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<DeleteFlowerResponse>(result)),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    [AuthorizeRoles(UserRole.Administrator)]
    public async Task<IActionResult> Update(Guid id, UpdateFlowerRequest request)
    {
        var command = _mapper.Map<UpdateFlowerCommand>((request, id));
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(new UpdateFlowerResponse()),
            errors => Problem(errors));
    }
}
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoCode.FlowerShop.Api.Attributes;
using NoCode.FlowerShop.Application.Flowers.Create;
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
        var query = _mapper.Map<CreateFlowerCommand>(request);
        var result = await _mediator.Send(query);
        return result.Match(Ok, Problem);
    }
}
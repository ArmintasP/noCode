using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
}
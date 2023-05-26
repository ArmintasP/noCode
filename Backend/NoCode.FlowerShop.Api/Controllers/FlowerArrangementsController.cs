using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

}


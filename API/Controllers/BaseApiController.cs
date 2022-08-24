using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController: ControllerBase
{
    private IMediator _mediator;
    //If _mediator is null, then we're going to assign to this property whatever is to the right side
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
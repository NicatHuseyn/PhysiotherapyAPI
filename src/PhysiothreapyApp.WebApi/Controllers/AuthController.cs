using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Commands;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Queries;

namespace PhysiothreapyApp.WebApi.Controllers;

public class AuthController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody]RegisterUserCommand command)
    {
        var result = await mediator.Send(command);
        return CreateActionResult(result);
    }

    [HttpGet("get-user")]
    public async Task<IActionResult> GetUser([FromQuery]GetUserQuery getUserQuery)
    {
        var result = await mediator.Send(getUserQuery);
        return CreateActionResult(result);
    }
}

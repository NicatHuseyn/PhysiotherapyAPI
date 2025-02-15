using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhysiothreapyApp.Application.Features.AuthFeatures.Register.Commands;

namespace PhysiothreapyApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUserCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}

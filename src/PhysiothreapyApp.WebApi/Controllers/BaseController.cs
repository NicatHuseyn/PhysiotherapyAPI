using Microsoft.AspNetCore.Mvc;
using PhysiothreapyApp.Application.Wrappers;

namespace PhysiothreapyApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(Result<T> result, string? urlAsCreated = null)
        {
            if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return NoContent();
            }

            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return Created(urlAsCreated, result.Data);
            }

            return new ObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() };
        }
    }
}



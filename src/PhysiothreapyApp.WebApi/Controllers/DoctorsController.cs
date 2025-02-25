using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Commands;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Queries;

namespace PhysiothreapyApp.WebApi.Controllers;

public class DoctorsController(IMediator mediator) : BaseController
{

    [HttpPost]
    public async Task<IActionResult> Create(CreateDoctorCommand command)
    {
        var result = await mediator.Send(command);
        return CreateActionResult(result);
    }

    [HttpGet("get-all-doctors")]
    public async Task<IActionResult> GetAll([FromQuery]GetAllDoctorQuery getAllDoctorQuery)
    {
        var result = await mediator.Send(getAllDoctorQuery);
        return CreateActionResult(result);
    }
}

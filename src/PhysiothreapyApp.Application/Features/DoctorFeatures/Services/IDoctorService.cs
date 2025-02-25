using System.Net;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Commands;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Queries;
using PhysiothreapyApp.Application.Wrappers;

namespace PhysiothreapyApp.Application.Features.DoctorFeatures.Services;

public interface IDoctorService
{
    Task<Result<HttpStatusCode>> CreateDoctorAsync(CreateDoctorCommand createDoctor);
    Task<Result<List<GetAllDoctorQueryResponse>>> GetAllDoctorsAsync(GetAllDoctorQuery getAllDoctorQuery);
}

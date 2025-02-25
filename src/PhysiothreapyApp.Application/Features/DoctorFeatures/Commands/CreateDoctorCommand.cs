using System.Net;
using MediatR;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Services;
using PhysiothreapyApp.Application.Wrappers;

namespace PhysiothreapyApp.Application.Features.DoctorFeatures.Commands;

public record CreateDoctorCommand
    (
    string Name, 
    string Surname, 
    string LicenseNumber,
    string Specialization,
    string Qualifications,
    string Biography,
    string ProfilePicture,
    bool IsAvailable,
    string WorkingHours,
    decimal ConsultationFees
    ):IRequest<Result<HttpStatusCode>>;


public class CreateDoctorCommandHandler(IDoctorService doctorService) : IRequestHandler<CreateDoctorCommand, Result<HttpStatusCode>>
{
    public async Task<Result<HttpStatusCode>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var result = await doctorService.CreateDoctorAsync(request);
        return result;
    }
}
using MediatR;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Services;
using PhysiothreapyApp.Application.Wrappers;

namespace PhysiothreapyApp.Application.Features.DoctorFeatures.Queries;

public record GetAllDoctorQuery:IRequest<Result<List<GetAllDoctorQueryResponse>>>
{
}

public record GetAllDoctorQueryResponse
    (
        Guid Id,
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
    );


public class GetAllDoctorQueryHandler(IDoctorService service) : IRequestHandler<GetAllDoctorQuery, Result<List<GetAllDoctorQueryResponse>>>
{
    public async Task<Result<List<GetAllDoctorQueryResponse>>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
    {
        var result = await service.GetAllDoctorsAsync(request);
        return result;
    }
}

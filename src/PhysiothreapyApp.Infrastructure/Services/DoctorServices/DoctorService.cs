using System.Net;
using Mapster;
using Microsoft.EntityFrameworkCore;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Commands;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Queries;
using PhysiothreapyApp.Application.Features.DoctorFeatures.Services;
using PhysiothreapyApp.Application.UnitOfWork;
using PhysiothreapyApp.Application.Wrappers;
using PhysiothreapyApp.Domain.Interfaces;
using PhysiothreapyApp.Domain.Models;

namespace PhysiothreapyApp.Infrastructure.Services.DoctorServices;

public class DoctorService(IDoctorRepository repository, IUnitOfWork unitOfWork) : IDoctorService
{
    public async Task<Result<HttpStatusCode>> CreateDoctorAsync(CreateDoctorCommand createDoctor)
    {
        var modelAsEntity = createDoctor.Adapt<Doctor>();
        repository.Add(modelAsEntity);
        await unitOfWork.CommitAsync();

        return Result<HttpStatusCode>.Succeed(HttpStatusCode.Created);
    }

    public async Task<Result<List<GetAllDoctorQueryResponse>>> GetAllDoctorsAsync(GetAllDoctorQuery getAllDoctorQuery)
    {
        var doctors = await repository.GetAll().ToListAsync();

        var modelsAsDoctors = doctors.Adapt<List<GetAllDoctorQueryResponse>>();

        return Result<List<GetAllDoctorQueryResponse>>.Succeed(modelsAsDoctors);
    }
}

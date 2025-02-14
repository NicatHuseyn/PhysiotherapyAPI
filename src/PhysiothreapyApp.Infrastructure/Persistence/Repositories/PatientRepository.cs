using PhysiothreapyApp.Domain.Interfaces;
using PhysiothreapyApp.Domain.Models;
using PhysiothreapyApp.Infrastructure.Persistence.Contexts;

namespace PhysiothreapyApp.Infrastructure.Persistence.Repositories;

public class PatientRepository(PhysiothreapyAppDbContext context) : GenericRepository<Patient, PhysiothreapyAppDbContext>(context), IPatientRepository
{
}

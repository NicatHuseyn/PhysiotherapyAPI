using PhysiothreapyApp.Domain.Interfaces;
using PhysiothreapyApp.Domain.Models;
using PhysiothreapyApp.Infrastructure.Persistence.Contexts;

namespace PhysiothreapyApp.Infrastructure.Persistence.Repositories;

public class DoctorRepository(PhysiothreapyAppDbContext context) : GenericRepository<Doctor, PhysiothreapyAppDbContext>(context), IDoctorRepository
{
}

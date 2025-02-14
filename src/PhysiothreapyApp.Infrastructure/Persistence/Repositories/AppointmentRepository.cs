using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysiothreapyApp.Domain.Interfaces;
using PhysiothreapyApp.Domain.Models;
using PhysiothreapyApp.Infrastructure.Persistence.Contexts;

namespace PhysiothreapyApp.Infrastructure.Persistence.Repositories;

public class AppointmentRepository(PhysiothreapyAppDbContext context) : GenericRepository<Appointment, PhysiothreapyAppDbContext>(context), IAppointmentRepository
{
}

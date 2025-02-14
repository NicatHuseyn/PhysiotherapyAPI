using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysiothreapyApp.Domain.Interfaces;
using PhysiothreapyApp.Domain.Models;
using PhysiothreapyApp.Infrastructure.Persistence.Contexts;

namespace PhysiothreapyApp.Infrastructure.Persistence.Repositories;

public class MedicalHistoryRepository(PhysiothreapyAppDbContext context) : GenericRepository<MedicalHistory, PhysiothreapyAppDbContext>(context), IMedicalHistoryRepository
{
}

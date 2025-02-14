using PhysiothreapyApp.Domain.Interfaces;
using PhysiothreapyApp.Domain.Models;
using PhysiothreapyApp.Infrastructure.Persistence.Contexts;

namespace PhysiothreapyApp.Infrastructure.Persistence.Repositories;

public class DocumentRepository(PhysiothreapyAppDbContext context) : GenericRepository<Document, PhysiothreapyAppDbContext>(context), IDocumentRepository
{
}

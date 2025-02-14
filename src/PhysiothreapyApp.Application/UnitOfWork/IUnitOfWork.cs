using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysiothreapyApp.Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync(bool state = true);
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
}
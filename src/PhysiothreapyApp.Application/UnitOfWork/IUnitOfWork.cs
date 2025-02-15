namespace PhysiothreapyApp.Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    Task<bool> CommitAsync(bool state = true);
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
}
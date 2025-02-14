using Microsoft.EntityFrameworkCore.Storage;
using PhysiothreapyApp.Application.UnitOfWork;
using PhysiothreapyApp.Infrastructure.Persistence.Contexts;

namespace PhysiothreapyApp.Infrastructure.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly PhysiothreapyAppDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(PhysiothreapyAppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Starts a new transaction asynchronously.
    /// </summary>
    public async Task BeginTransactionAsync()
    {
        if (_transaction != null)
            throw new InvalidOperationException("A transaction is already in progress.");

        _transaction = await _context.Database.BeginTransactionAsync();
    }

    /// <summary>
    /// Commits the transaction and saves changes to the database.
    /// Rolls back the transaction in case of an error.
    /// </summary>
    /// <param name="state">Whether to commit the transaction or not.</param>
    /// <returns>True if commit was successful, otherwise false.</returns>
    public async Task<bool> CommitAsync(bool state = true)
    {
        try
        {
            var changes = await SaveChangesAsync();
            if (state && _transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
            return changes > 0;
        }
        catch
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
            throw;
        }
    }

    /// <summary>
    /// Saves changes to the database asynchronously.
    /// </summary>
    /// <returns>The number of affected rows.</returns>
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context?.Dispose();
        _transaction?.Dispose();
    }
}

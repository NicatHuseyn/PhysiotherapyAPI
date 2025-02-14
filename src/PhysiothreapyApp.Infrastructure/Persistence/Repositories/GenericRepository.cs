using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhysiothreapyApp.Domain.Abstractions;
using PhysiothreapyApp.Domain.Interfaces;

namespace PhysiothreapyApp.Infrastructure.Persistence.Repositories;

public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    private readonly TContext _context;
    private DbSet<TEntity> Entity;

    public GenericRepository(TContext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        Entity.Add(entity);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken);
    }

    public void AddRange(ICollection<TEntity> entities)
    {
        Entity.AddRange(entities);
    }

    public async Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Entity.AddRangeAsync(entities, cancellationToken);
    }

    public bool Any(Expression<Func<TEntity, bool>> expression)
    {
        return Entity.Any(expression);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await Entity.AnyAsync(expression, cancellationToken);
    }

    public void Delete(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public async Task<bool> DeleteByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        TEntity? entity = await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        EntityEntry<TEntity> entityEntry = Entity.Remove(entity!);

        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        TEntity? entity = await Entity.FindAsync(id);
        EntityEntry<TEntity> entityEntry = Entity.Remove(entity!);

        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true, CancellationToken cancellationToken = default)
    {
        return (!isTrackingActive) ? (await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken)) : (await Entity.Where(expression).FirstOrDefaultAsync(cancellationToken));
    }

    public IQueryable<TEntity> GetAll()
    {
        return Entity.AsNoTracking().AsQueryable();
    }


    public IQueryable<TEntity> GetAllWithTracking()
    {
        return Entity.AsQueryable();
    }

    public async Task<TEntity?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, bool isTrackingActive = true, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = Entity.AsQueryable();
        if (!isTrackingActive)
            query.AsNoTracking();

        return await query.FirstOrDefaultAsync(x=>x.Id == id);
    }

    public IQueryable<TEntity> GetWithIncludes(
      Expression<Func<TEntity, bool>>? filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
      bool isTrackingActive = true,
      params Expression<Func<TEntity, object>>[] includes)
    {
        var query = Entity.AsQueryable();

        if (!isTrackingActive)
            query = query.AsNoTracking();

        if (filter != null)
            query = query.Where(filter);

        foreach (var include in includes)
            query = query.Include(include);

        if (orderBy != null)
            query = orderBy(query);

        return query;
    }


    public void Update(TEntity entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(ICollection<TEntity> entities)
    {
        Entity.UpdateRange(entities);
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true)
    {
        var query = Entity.AsNoTracking().AsQueryable();

        return query.Where(expression);
    }

    public IQueryable<KeyValuePair<bool, int>> CountBy(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return Entity.CountBy(expression);
    }

    public TEntity First(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true)
    {
        if (isTrackingActive)
        {
            return Entity.First(expression);
        }

        return Entity.AsNoTracking().First(expression);
    }

    public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default, bool isTrackingActive = true)
    {
        if (isTrackingActive)
        {
            return await Entity.FirstAsync(expression, cancellationToken);
        }

        return await Entity.AsNoTracking().FirstAsync(expression, cancellationToken);
    }
}

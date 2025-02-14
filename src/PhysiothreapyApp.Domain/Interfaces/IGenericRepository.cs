using System.Linq.Expressions;
using PhysiothreapyApp.Domain.Abstractions;

namespace PhysiothreapyApp.Domain.Interfaces;

public interface IGenericRepository<TEntity>
    where TEntity : Entity
{
    IQueryable<TEntity> GetAll(bool isTrackingActive = true);

    IQueryable<TEntity> Where(Expression<Func<TEntity,bool>> expression);

    IQueryable<TEntity> WhereWithTracking(Expression<Func<TEntity,bool>> expression);

    TEntity First(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true);

    Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken), bool isTrackingActive = true);

    Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    bool Any(Expression<Func<TEntity, bool>> expression);

    Task<TEntity> GetByIdAsync(Guid Id, bool isTrackingActive = true, params Expression<Func<TEntity, object>>[] includes);

    IQueryable<TEntity> Get(Guid Id, bool isTrackingActive = true, params Expression<Func<TEntity, object>>[] includes);

    IQueryable<TEntity> GetFunctional(
        Expression<Func<TEntity, bool>>? filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, 
        params Expression<Func<TEntity, object>>[] includes);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

    void Add(TEntity entity);

    Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

    void AddRange(ICollection<TEntity> entities);

    void Update(TEntity entity);

    void UpdateRange(ICollection<TEntity> entities);

    Task DeleteByIdAsync(string id);

    Task DeleteByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default(CancellationToken));

    void Delete(TEntity entity);

    void DeleteRange(ICollection<TEntity> entities);

}

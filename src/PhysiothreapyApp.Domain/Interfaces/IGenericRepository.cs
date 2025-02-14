using System.Linq.Expressions;
using PhysiothreapyApp.Domain.Abstractions;

namespace PhysiothreapyApp.Domain.Interfaces;

/// <summary>
/// Generic repository interface that provides common data access operations.
/// </summary>
/// <typeparam name="TEntity">The entity type that extends from the base Entity class.</typeparam>
public interface IGenericRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Retrieves all entities from the database.
    /// </summary>
    /// <param name="isTrackingActive">Specifies whether tracking is enabled.</param>
    /// <returns>An IQueryable of TEntity.</returns>
    IQueryable<TEntity> GetAll();

    IQueryable<TEntity> GetAllWithTracking();

    /// <summary>
    /// Retrieves entities that match the specified filter expression.
    /// </summary>
    /// <param name="expression">The filter condition.</param>
    /// <param name="isTrackingActive">Specifies whether tracking is enabled.</param>
    /// <returns>An IQueryable of TEntity.</returns>
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true);

    /// <summary>
    /// Retrieves the first entity that matches the specified condition or returns null if not found.
    /// </summary>
    /// <param name="expression">The condition to filter entities.</param>
    /// <param name="isTrackingActive">Specifies whether tracking is enabled.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The first matching entity or null.</returns>
    Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an entity based on the given condition.
    /// </summary>
    /// <param name="expression">The filter condition.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The matching entity or null.</returns>
    Task<TEntity?> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks whether any entity matches the given condition asynchronously.
    /// </summary>
    /// <param name="expression">The condition to check.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if any entity matches; otherwise, false.</returns>
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks whether any entity matches the given condition synchronously.
    /// </summary>
    /// <param name="expression">The condition to check.</param>
    /// <returns>True if any entity matches; otherwise, false.</returns>
    bool Any(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The entity's unique identifier.</param>
    /// <param name="isTrackingActive">Specifies whether tracking is enabled.</param>
    /// <param name="includes">Related entities to include.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    Task<TEntity?> GetByIdAsync(Guid id, bool isTrackingActive = true, params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Retrieves entities with optional filtering, ordering, and includes.
    /// </summary>
    /// <param name="filter">Optional filter condition.</param>
    /// <param name="orderBy">Optional ordering function.</param>
    /// <param name="isTrackingActive">Specifies whether tracking is enabled.</param>
    /// <param name="includes">Related entities to include.</param>
    /// <returns>An IQueryable of TEntity.</returns>
    IQueryable<TEntity> GetWithIncludes(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        bool isTrackingActive = true,
        params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new entity synchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Add(TEntity entity);

    /// <summary>
    /// Adds multiple entities asynchronously.
    /// </summary>
    /// <param name="entities">The collection of entities to add.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds multiple entities synchronously.
    /// </summary>
    /// <param name="entities">The collection of entities to add.</param>
    void AddRange(ICollection<TEntity> entities);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(TEntity entity);

    /// <summary>
    /// Updates multiple existing entities.
    /// </summary>
    /// <param name="entities">The collection of entities to update.</param>
    void UpdateRange(ICollection<TEntity> entities);

    /// <summary>
    /// Deletes an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The entity's unique identifier.</param>
    /// <returns>True if deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteByIdAsync(Guid id);

    /// <summary>
    /// Deletes entities that match the specified condition asynchronously.
    /// </summary>
    /// <param name="expression">The condition to filter entities.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if at least one entity was deleted; otherwise, false.</returns>
    Task<bool> DeleteByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a specific entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Deletes multiple entities.
    /// </summary>
    /// <param
    /// 


    /// <summary>
    /// Counts the number of entities that satisfy the given condition.
    /// Returns a key-value pair where the key indicates whether any entity exists 
    /// and the value represents the count of matching entities.
    /// </summary>
    /// <param name="expression">The filter condition to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
    /// <returns>An IQueryable containing a key-value pair (bool, int), 
    /// where the bool indicates existence and int is the count.</returns>
    IQueryable<KeyValuePair<bool, int>> CountBy(
        Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the first entity that matches the specified condition.
    /// </summary>
    /// <param name="expression">The condition to filter entities.</param>
    /// <param name="isTrackingActive">Determines whether change tracking is enabled.</param>
    /// <returns>The first entity that matches the condition.</returns>
    TEntity First(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true);

    /// <summary>
    /// Asynchronously retrieves the first entity that matches the specified condition.
    /// </summary>
    /// <param name="expression">The condition to filter entities.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation if needed.</param>
    /// <param name="isTrackingActive">Determines whether change tracking is enabled.</param>
    /// <returns>A task representing the asynchronous operation, returning the first entity that matches the condition.</returns>
    Task<TEntity> FirstAsync(
        Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default,
        bool isTrackingActive = true);

}
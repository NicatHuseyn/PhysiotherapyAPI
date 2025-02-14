using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PhysiothreapyApp.Domain.Abstractions;

namespace PhysiothreapyApp.Infrastructure.Persistence.Interceptors;

public class DbSaveChangesInterceptor:SaveChangesInterceptor
{
    private readonly static Dictionary<EntityState, Action<DbContext, IEntityTimeStamps>> _behaviors = new()
    {
        {EntityState.Added, AddDataBehavior },
        {EntityState.Modified, UpdateDataBehavior },
        {EntityState.Deleted, DeleteDataBehavior },
    };

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var entityEntries = eventData.Context!.ChangeTracker.Entries<Entity>();

        foreach (var entityEntry in entityEntries)
        {
            if (entityEntry.Entity is not IEntityTimeStamps entityTimeStamps)
            {
                continue;
            }

            if (_behaviors.ContainsKey(entityEntry.State))
            {
                _behaviors[entityEntry.State](eventData.Context, entityTimeStamps);
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void AddDataBehavior(DbContext context, IEntityTimeStamps entityTimeStamps)
    {
        entityTimeStamps.CreatedDate = DateOnly.FromDateTime(DateTime.UtcNow);
        context.Entry(entityTimeStamps).Property(e=>e.UpdateddDate).IsModified = false;
    }

    private static void UpdateDataBehavior(DbContext context, IEntityTimeStamps entityTimeStamps)
    {
        entityTimeStamps.UpdateddDate = DateOnly.FromDateTime(DateTime.UtcNow);
        context.Entry(entityTimeStamps).Property(e => e.DeletedDate).IsModified = false;
    }

    private static void DeleteDataBehavior(DbContext context, IEntityTimeStamps entityTimeStamps)
    {
        entityTimeStamps.DeletedDate = DateOnly.FromDateTime(DateTime.UtcNow);
        context.Entry(entityTimeStamps).Property(e => e.UpdateddDate).IsModified = false;

        // for soft delete
        context.Entry(entityTimeStamps).State = EntityState.Modified;
    }
}

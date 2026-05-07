using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Repositories;

/// <summary>
/// Declare a partial class
/// </summary>
/// <typeparam name="T"></typeparam>
public partial interface IRepository<T> where T : class
{
    // Command operations    
    void Update(T entity);    
}

public partial class Repository<T> : IRepository<T> where T : class
{
    public virtual void Update(T entity)
    {
        // ✅ Check if an entity with the same key is already tracked.
        // This happens when AsNoTracking() entities are mixed with tracked ones
        // (e.g. FindAsync, DeleteAsync, or a previous Update in the same DbContext lifetime).
        var entry = _context.ChangeTracker.Entries<T>()
                            .FirstOrDefault(e => e.State != EntityState.Detached &&
                                                 e.Entity == entity);

        if (entry != null)
        {
            // Same instance already tracked — just mark it Modified
            entry.State = EntityState.Modified;
        }
        else
        {
            // Check by key value — different instance, same PK
            var keyValues = _context.Model.FindEntityType(typeof(T))!
                                    .FindPrimaryKey()!.Properties
                                    .Select(p => p.PropertyInfo!.GetValue(entity))
                                    .ToArray();

            var trackedEntry = _context.ChangeTracker.Entries<T>()
                                       .FirstOrDefault(e =>
                                       {
                                           var trackedKeys = _context.Model.FindEntityType(typeof(T))!
                                                                     .FindPrimaryKey()!.Properties
                                                                     .Select(p => p.PropertyInfo!.GetValue(e.Entity))
                                                                     .ToArray();
                                           return trackedKeys.SequenceEqual(keyValues);
                                       });

            if (trackedEntry != null)
            {
                // ✅ Different instance, same PK — copy values into the tracked instance
                // instead of trying to attach a duplicate
                trackedEntry.CurrentValues.SetValues(entity);
                trackedEntry.State = EntityState.Modified;
            }
            else
            {
                // No conflict — attach normally
                _dbSet.Update(entity);
            }
        }
    }
      
}

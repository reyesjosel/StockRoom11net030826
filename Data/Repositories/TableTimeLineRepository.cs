using Microsoft.EntityFrameworkCore;
using StockRoom11net.Data.Entities;

namespace StockRoom11net.Data.Repositories;


/// <summary>
/// ✅ REPOSITORY — only data access, no logic
/// Repository interface for TableTimeLine operations
/// </summary>
public interface ITableTimeLineRepository : IRepository<Table_TimeLine>
{
    // Basic CRUD operations
    Task<Table_TimeLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Table_TimeLine> AddAsync(Table_TimeLine entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the existing entity in the table Table_TimeLine, save the changes to the database.
    /// It first checks if the entity exists in the database by its primary key (ID). If it doesn't exist, it throws a KeyNotFoundException.
    /// No need call SaveChangesAsync() after this method, it will be called in the service layer after all operations are done.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    Task UpdateAsync(Table_TimeLine entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        
    // Query operations
    Task<IEnumerable<Table_TimeLine>> FindByItemTextAsync(string itemText, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine>> FindByAltTextAsync(string altText, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine>> SearchByHeadLineAsync(string headLine, CancellationToken cancellationToken = default);

    // Batch operations
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}


/// <summary>
/// ✅ REPOSITORY — only data access, no logic
/// Repository implementation for TableTimeLine entity
/// </summary>
public class TableTimeLineRepository : Repository<Table_TimeLine>, ITableTimeLineRepository
{
    public TableTimeLineRepository(ProductionInventoryContext context) : base(context)
    {
    }

    #region Basic CRUD Operations

    public async Task<Table_TimeLine?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Table_TimeLines
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Table_TimeLines
            .AsNoTracking()
            .OrderBy(x => x.ID)
            .ToListAsync(cancellationToken);
    }

    public async Task<Table_TimeLine> AddAsync(Table_TimeLine entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _context.Table_TimeLines.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
        
    public async Task UpdateAsync(Table_TimeLine entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        // Find the existing tracked entity by PK first to avoid a
        // DbUpdateConcurrencyException when the entity is untracked (AsNoTracking).
        var existing = await _context.Table_TimeLines.FindAsync(new object[] { entity.ID }, cancellationToken);

        if (existing == null)
            throw new KeyNotFoundException($"Row with ID={entity.ID} not found. It may have been deleted.");

        // Copy new values onto the tracked entity and save.
        _context.Entry(existing).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Table_TimeLines.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _context.Table_TimeLines.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    #endregion
    
    #region Query Operations

    public async Task<IEnumerable<Table_TimeLine>> FindByItemTextAsync(string itemText, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(itemText))
            return Enumerable.Empty<Table_TimeLine>();

        return await _context.Table_TimeLines
            .AsNoTracking()
            .Where(x => x.ItemText == itemText)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine>> FindByAltTextAsync(string altText, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(altText))
            return Enumerable.Empty<Table_TimeLine>();

        return await _context.Table_TimeLines
            .AsNoTracking()
            .Where(x => x.AltText == altText)
            .OrderBy(x => x.ID)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine>> SearchByHeadLineAsync(string headLine, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(headLine))
            return Enumerable.Empty<Table_TimeLine>();

        var term = headLine.ToLower();
        return await _context.Table_TimeLines
            .AsNoTracking()
            .Where(x => (x.HeadLine != null && x.HeadLine.ToLower().Contains(term)))// ||
                    //   (x.Code != null && x.Code.ToLower().Contains(term)) ||
                    //   (x.StringFilter != null && x.StringFilter.ToLower().Contains(term)))
            .OrderBy(x => x.ID)
            .ToListAsync(cancellationToken);
    }

    #endregion

    #region Batch Operations

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    #endregion
}
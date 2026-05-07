using Microsoft.EntityFrameworkCore;
using StockRoom11net.Data.Entities;

namespace StockRoom11net.Data.Repositories;


/// <summary>
/// Repository interface for TableTimeLineTreeView operations
/// </summary>
public interface ITableTimeLineTreeViewRepository : IRepository<Table_TimeLine_TreeView>
{
    // Basic CRUD operations
    Task<Table_TimeLine_TreeView?> GetByIDAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine_TreeView>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Table_TimeLine_TreeView> AddAsync(Table_TimeLine_TreeView entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Table_TimeLine_TreeView entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    // Tree-specific operations
    Task<IEnumerable<Table_TimeLine_TreeView>> GetRootNodesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine_TreeView>> GetChildrenAsync(int parentId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine_TreeView>> GetTreeHierarchyAsync(int? rootId = null, CancellationToken cancellationToken = default);

    // Query operations
    Task<IEnumerable<Table_TimeLine_TreeView>> FindByCodeAsync(string code, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine_TreeView>> FindByStatusAsync(string status, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine_TreeView>> SearchByTextAsync(string searchTerm, CancellationToken cancellationToken = default);

    // Batch operations
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}


/// <summary>
/// Repository implementation for TableTimeLineTreeView entity
/// </summary>
public class TableTimeLineTreeViewRepository : Repository<Table_TimeLine_TreeView>, ITableTimeLineTreeViewRepository
{
    public TableTimeLineTreeViewRepository(ProductionInventoryContext context) : base(context)
    {}

    #region Basic CRUD Operations

    public async Task<Table_TimeLine_TreeView?> GetByIDAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Table_TimeLine_TreeViews
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Table_TimeLine_TreeViews
            .AsNoTracking()
            .OrderBy(x => x.Index)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Add the new entity to the table Table_TimeLine_TreeView, save the changes to the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<Table_TimeLine_TreeView> AddAsync(Table_TimeLine_TreeView entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _context.Table_TimeLine_TreeViews.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(Table_TimeLine_TreeView entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _context.Table_TimeLine_TreeViews.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Table_TimeLine_TreeViews.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _context.Table_TimeLine_TreeViews.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    #endregion

    #region Tree-Specific Operations

    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetRootNodesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Table_TimeLine_TreeViews
            .AsNoTracking()
            .Where(x => x.Parent_ID == null || x.Parent_ID == 0)
            .OrderBy(x => x.Index)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetChildrenAsync(int parentId, CancellationToken cancellationToken = default)
    {
        return await _context.Table_TimeLine_TreeViews .AsNoTracking()
            .AsNoTracking()
            .Where(x => x.Parent_ID == parentId)
            .OrderBy(x => x.Index)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetTreeHierarchyAsync(int? rootId = null, CancellationToken cancellationToken = default)
    {
        if (rootId.HasValue)
        {
            // Get specific subtree
            return await _context.Table_TimeLine_TreeViews
                .AsNoTracking()
                .Where(x => x.ID == rootId.Value || x.Parent_ID == rootId.Value)
                .OrderBy(x => x.Index)
                .ToListAsync(cancellationToken);
        }

        // Get entire tree
        return await _context.Table_TimeLine_TreeViews
            .AsNoTracking()
            .OrderBy(x => x.Index)
            .ToListAsync(cancellationToken);
    }

    #endregion

    #region Query Operations

    public async Task<IEnumerable<Table_TimeLine_TreeView>> FindByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(code))
            return Enumerable.Empty<Table_TimeLine_TreeView>();

        return await _context.Table_TimeLine_TreeViews
            .AsNoTracking()
            .Where(x => x.Code == code)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine_TreeView>> FindByStatusAsync(string status, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(status))
            return Enumerable.Empty<Table_TimeLine_TreeView>();

        return await _context.Table_TimeLine_TreeViews
            .AsNoTracking()
            .Where(x => x.Status == status)
            .OrderBy(x => x.Index)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine_TreeView>> SearchByTextAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return Enumerable.Empty<Table_TimeLine_TreeView>();

        var term = searchTerm.ToLower();
        return await _context.Table_TimeLine_TreeViews
            .AsNoTracking()
            .Where(x => (x.Text_Name != null && x.Text_Name.ToLower().Contains(term)) ||
                       (x.Code != null && x.Code.ToLower().Contains(term)) ||
                       (x.String_Filter != null && x.String_Filter.ToLower().Contains(term)))
            .OrderBy(x => x.Index)
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
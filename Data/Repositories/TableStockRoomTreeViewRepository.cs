using Microsoft.EntityFrameworkCore;
using StockRoom11net.Data.Entities;

namespace StockRoom11net.Data.Repositories;

/// <summary>
/// ✅ REPOSITORY — only data access, no logic
/// Repository interface for TableStockRoomTreeView operations
/// </summary>
public interface ITableStockRoomTreeViewRepository : IRepository<Table_StockRoom_TreeView>
{
    // Basic CRUD operations
    Task<Table_StockRoom_TreeView?> GetByIDAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_StockRoom_TreeView>> GetAllAsync(CancellationToken cancellationToken = default, int? count = null);
    Task<Table_StockRoom_TreeView> AddAsync(Table_StockRoom_TreeView entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the existing entity in the table Table_StockRoom_TreeView, save the changes to the database.
    /// It first checks if the entity exists in the database by its primary key (Index). If it doesn't exist, it throws a KeyNotFoundException.
    /// No need call SaveChangesAsync() after this method, it will be called in the service layer after all operations are done.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    Task UpdateAsync(Table_StockRoom_TreeView entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the entity with the specified index from the table Table_StockRoom_TreeView, save the changes to the database.
    /// It first checks if the entity exists in the database by its primary key (Index). If it doesn't exist, it does nothing.
    /// No need call SaveChangesAsync() after this method, it will be called in the service layer after all operations are done.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(int index, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes all entities with the specified index values in a single SQL statement.
    /// No need to call SaveChangesAsync() — ExecuteDeleteAsync commits immediately.
    /// </summary>
    Task DeleteRangeAsync(IEnumerable<int> indexes, CancellationToken cancellationToken = default);

    // Tree-specific operations
    Task<IEnumerable<Table_StockRoom_TreeView>> GetRootNodesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_StockRoom_TreeView>> GetChildrenAsync(int parentId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_StockRoom_TreeView>> GetTreeHierarchyAsync(int? rootId = null, CancellationToken cancellationToken = default);

    // Query operations
    Task<IEnumerable<Table_StockRoom_TreeView>> FindByCodeAsync(string code, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_StockRoom_TreeView>> FindByStatusAsync(string status, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_StockRoom_TreeView>> SearchByTextAsync(string searchTerm, CancellationToken cancellationToken = default);

    // Batch operations
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    // Diagnostic: reads raw column values via ADO.NET, bypassing the EF materializer.
    // Returns one dictionary per row; NULL columns are stored as null (not DBNull).
    Task<List<Dictionary<string, object?>>> GetRawRowsAsync(int offsetZeroBased, int rowCount, CancellationToken cancellationToken = default);

    Task<List<(int RowPosition, long IndexVal, long IdVal, List<string> NullColumns)>>
    FindIntegerNullsAsync(CancellationToken cancellationToken = default);
}


/// <summary>
/// ✅ REPOSITORY — only data access, no logic
/// Repository implementation for TableStockRoomTreeView entity
/// </summary>
public class TableStockRoomTreeViewRepository : Repository<Table_StockRoom_TreeView>, ITableStockRoomTreeViewRepository
{
    public TableStockRoomTreeViewRepository(ProductionInventoryContext context) : base(context)
    {}

    #region Basic CRUD Operations

    public async Task<Table_StockRoom_TreeView?> GetByIDAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Table_StockRoom_TreeViews
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);
    }

    public async Task<IEnumerable<Table_StockRoom_TreeView>> GetAllAsync(CancellationToken cancellationToken = default, int? count = null)
    {
        var query = _context.Table_StockRoom_TreeViews
            .AsNoTracking()
            .OrderBy(x => x.Index);

        return await (count.HasValue ? query.Take(count.Value) : query)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Add the new entity to the table Table_StockRoom_TreeView, save the changes to the database.
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<Table_StockRoom_TreeView> AddAsync(Table_StockRoom_TreeView entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _context.Table_StockRoom_TreeViews.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
        
    public async Task UpdateAsync(Table_StockRoom_TreeView entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        // Find the existing tracked entity by PK first to avoid a
        // DbUpdateConcurrencyException when the entity is untracked (AsNoTracking).
        var existing = await _context.Table_StockRoom_TreeViews.FindAsync(new object[] { entity.Index }, cancellationToken);

        if (existing == null)
            throw new KeyNotFoundException($"Row with Index={entity.Index} not found. It may have been deleted.");

        // Copy new values onto the tracked entity and save.
        _context.Entry(existing).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
        
    public async Task DeleteAsync(int index, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Table_StockRoom_TreeViews.FindAsync(new object[] { index }, cancellationToken);
        if (entity != null)
        {
            _context.Table_StockRoom_TreeViews.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task DeleteRangeAsync(IEnumerable<int> indexes, CancellationToken cancellationToken = default)
    {
        var indexList = indexes.ToList();
        if (indexList.Count == 0)
            return;

        // ✅ Single SQL: DELETE FROM Table_StockRoom_TreeView WHERE Index IN (...)
        // No FindAsync, no per-row SaveChangesAsync — one round-trip for all rows.
        await _context.Table_StockRoom_TreeViews
            .Where(x => indexList.Contains(x.Index))
            .ExecuteDeleteAsync(cancellationToken);
    }

    #endregion

    #region Tree-Specific Operations

    public async Task<IEnumerable<Table_StockRoom_TreeView>> GetRootNodesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Table_StockRoom_TreeViews
            .AsNoTracking()
            .Where(x => x.Parent_ID == null || x.Parent_ID == 0)
            .OrderBy(x => x.Index)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_StockRoom_TreeView>> GetChildrenAsync(int parentId, CancellationToken cancellationToken = default)
    {
        return await _context.Table_StockRoom_TreeViews
            .AsNoTracking()
            .Where(x => x.Parent_ID == parentId)
            .OrderBy(x => x.Index)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_StockRoom_TreeView>> GetTreeHierarchyAsync(int? rootId = null, CancellationToken cancellationToken = default)
    {
        // Load the full table once — avoids N+1 recursive DB calls.
        var all = await _context.Table_StockRoom_TreeViews
            .AsNoTracking()
            .OrderBy(x => x.Index)
            .ToListAsync(cancellationToken);

        if (rootId.HasValue)
        {
            // ✅ BFS: collects root + ALL descendants, not just direct children.
            return CollectSubtree(all, rootId.Value);
        }

        return all;
    }

    /// <summary>
    /// Iterative BFS that returns the root node and every descendant below it.
    /// </summary>
    private static List<Table_StockRoom_TreeView> CollectSubtree(List<Table_StockRoom_TreeView> all, int rootId)
    {
        var result = new List<Table_StockRoom_TreeView>();
        var queue = new Queue<int>();
        queue.Enqueue(rootId);

        while (queue.Count > 0)
        {
            int currentId = queue.Dequeue();

            var node = all.FirstOrDefault(x => x.ID == currentId);
            if (node is not null)
                result.Add(node);

            foreach (var child in all.Where(x => x.Parent_ID == currentId))
                queue.Enqueue(child.ID);
        }

        return result;
    }

    #endregion

    #region Query Operations

    public async Task<IEnumerable<Table_StockRoom_TreeView>> FindByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(code))
            return Enumerable.Empty<Table_StockRoom_TreeView>();

        return await _context.Table_StockRoom_TreeViews
            .AsNoTracking()
            .Where(x => x.Code == code)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_StockRoom_TreeView>> FindByStatusAsync(string status, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(status))
            return Enumerable.Empty<Table_StockRoom_TreeView>();

        return await _context.Table_StockRoom_TreeViews
            .AsNoTracking()
            .Where(x => x.Status == status)
            .OrderBy(x => x.Index)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_StockRoom_TreeView>> SearchByTextAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return Enumerable.Empty<Table_StockRoom_TreeView>();

        var term = searchTerm.ToLower();
        return await _context.Table_StockRoom_TreeViews
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

    public async Task<List<Dictionary<string, object?>>> GetRawRowsAsync(int offsetZeroBased, int rowCount, CancellationToken cancellationToken = default)
    {
        var results = new List<Dictionary<string, object?>>();
        var conn = _context.Database.GetDbConnection();
        bool wasOpen = conn.State == System.Data.ConnectionState.Open;

        try
        {
            if (!wasOpen)
                await conn.OpenAsync(cancellationToken);

            using var cmd = conn.CreateCommand();
            // Parameterised LIMIT/OFFSET — safe because both values are ints from C#
            cmd.CommandText = $"""
            SELECT * FROM "Table_StockRoom_TreeView"
            ORDER BY "Index"
            LIMIT {rowCount} OFFSET {offsetZeroBased}
            """;

            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            int rowNum = offsetZeroBased + 1;   // 1-based for display

            while (await reader.ReadAsync(cancellationToken))
            {
                var row = new Dictionary<string, object?> { ["__Row#__"] = rowNum++ };
                for (int i = 0; i < reader.FieldCount; i++)
                    row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                results.Add(row);
            }
        }
        finally
        {
            if (!wasOpen && conn.State != System.Data.ConnectionState.Closed)
                await conn.CloseAsync();
        }

        return results;
    }

    public async Task<List<(int RowPosition, long IndexVal, long IdVal, List<string> NullColumns)>> FindIntegerNullsAsync(CancellationToken cancellationToken = default)
    {
        var hits = new List<(int, long, long, List<string>)>();
        var conn = _context.Database.GetDbConnection();
        bool wasOpen = conn.State == System.Data.ConnectionState.Open;

        try
        {
            if (!wasOpen) await conn.OpenAsync(cancellationToken);

            using var cmd = conn.CreateCommand();
            // Only reads the 3 integer columns that can crash EF Core if NULL.
            // Row position is counted in C# — no SQLite window function needed.
            cmd.CommandText = """
            SELECT "Index", "ID", "Parent_ID", "ItemCount", "ItemOpen"
            FROM   "Table_StockRoom_TreeView"
            ORDER  BY "Index"
            """;

            using var reader = await cmd.ExecuteReaderAsync(cancellationToken);
            int pos = 0;
            while (await reader.ReadAsync(cancellationToken))
            {
                pos++;
                var nullCols = new List<string>();
                // ordinals: 0=Index  1=ID  2=Parent_ID  3=ItemCount  4=ItemOpen
                for (int i = 2; i <= 4; i++)
                    if (reader.IsDBNull(i)) nullCols.Add(reader.GetName(i));

                if (nullCols.Count > 0)
                    hits.Add((pos,
                              reader.IsDBNull(0) ? -1 : reader.GetInt64(0),
                              reader.IsDBNull(1) ? -1 : reader.GetInt64(1),
                              nullCols));
            }
        }
        finally
        {
            if (!wasOpen && conn.State != System.Data.ConnectionState.Closed)
                await conn.CloseAsync();
        }

        return hits;
    }

}
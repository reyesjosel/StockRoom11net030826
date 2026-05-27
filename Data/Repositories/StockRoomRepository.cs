using Microsoft.EntityFrameworkCore;
using StockRoom11net.Data.Entities;

namespace StockRoom11net.Data.Repositories;

/// <summary>
/// ✅ REPOSITORY — only data access, no logic
/// StockRoom-specific repository with custom queries
/// Replaces TableAdapter queries with LINQ and async operations
/// </summary>
public interface IStockRoomRepository : IRepository<Table_StockRoom>
{
    Task<IEnumerable<Table_StockRoom>> GetByPartNumberAsync(string partNumber);
    Task<IEnumerable<Table_StockRoom>> GetByLocationAsync(string location);
    Task<IEnumerable<Table_StockRoom>> SearchByDescriptionAsync(string searchTerm);
    Task<IEnumerable<Table_StockRoom>> GetLowInventoryAsync(int threshold);
    Task<int> GetTotalQuantityAsync();
    Task<decimal> GetTotalValueAsync();

    Task<IEnumerable<Table_StockRoom>> FilterByStringFilterAsync(string stringFilter);
}


// ✅ REPOSITORY — only data access, no logic
public class StockRoomRepository : Repository<Table_StockRoom>, IStockRoomRepository
{
    public StockRoomRepository(ProductionInventoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Table_StockRoom>> GetByPartNumberAsync(string partNumber)
    {
        return await _dbSet
            .Where(s => s.PartNumber == partNumber)
            .OrderBy(s => s.Location)
            .ToListAsync();
    }

    public async Task<IEnumerable<Table_StockRoom>> GetByLocationAsync(string location)
    {
        return await _dbSet
            .Where(s => s.Location == location)
            .OrderBy(s => s.PartNumber)
            .ToListAsync();
    }

    public async Task<IEnumerable<Table_StockRoom>> SearchByDescriptionAsync(string searchTerm)
    {
        return await _dbSet
            .Where(s => s.Description != null && s.Description.Contains(searchTerm))
            .OrderBy(s => s.PartNumber)
            .ToListAsync();
    }

    public async Task<IEnumerable<Table_StockRoom>> GetLowInventoryAsync(int threshold)
    {
        return await _dbSet
            .Where(s => s.OnHand <= threshold)
            .OrderBy(s => s.OnHand)
            .ThenBy(s => s.PartNumber)
            .ToListAsync();
    }

    public async Task<int> GetTotalQuantityAsync()
    {
        return (int)await _dbSet.SumAsync(s => s.OnHand);
    }

    public async Task<decimal> GetTotalValueAsync()
    {
        return (decimal)await _dbSet.SumAsync(s => s.OnHand * s.SalePrice);
    }

    /// <summary>
    /// Filters StockRoom records using the StringFilter from the TreeView node.
    /// StringFilter format: "PartNumber LIKE '060-*' AND Description NOT LIKE '*Obsolete,*'"
    /// Translates to EF LINQ queries.
    /// </summary>
    public async Task<IEnumerable<Table_StockRoom>> FilterByStringFilterAsync(string stringFilter)
    {
        if (string.IsNullOrWhiteSpace(stringFilter))
            return await _dbSet.AsNoTracking().ToListAsync();

        // Parse "PartNumber LIKE '060-*'" → EF Contains/StartsWith
        // Simple prefix match: "060-*" → StartsWith("060-")
        var query = _dbSet.AsNoTracking().AsQueryable();

        // Extract LIKE patterns via simple parse
        var parts = stringFilter.Split(new[] { " AND " }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var part in parts)
        {
            if (part.Contains("LIKE") && !part.Contains("NOT LIKE"))
            {
                var col = part.Split("LIKE")[0].Trim();
                var pattern = part.Split("LIKE")[1].Trim().Trim('\'').Replace("*", "");

                if (col == "PartNumber")
                    query = query.Where(s => s.PartNumber != null && s.PartNumber.StartsWith(pattern));
                else if (col == "Description")
                    query = query.Where(s => s.Description != null && s.Description.Contains(pattern));
            }
            else if (part.Contains("NOT LIKE"))
            {
                var col = part.Split("NOT LIKE")[0].Trim();
                var pattern = part.Split("NOT LIKE")[1].Trim().Trim('\'').Replace("*", "");

                if (col == "Description")
                    query = query.Where(s => s.Description == null || !s.Description.Contains(pattern));
            }
        }

        return await query.OrderBy(s => s.PartNumber).ToListAsync();
    }
}

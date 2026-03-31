using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Repositories;

/// <summary>
/// StockRoom-specific repository with custom queries
/// Replaces TableAdapter queries with LINQ and async operations
/// </summary>
public interface IStockRoomRepository : IRepository<StockRoom>
{
    Task<IEnumerable<StockRoom>> GetByPartNumberAsync(string partNumber);
    Task<IEnumerable<StockRoom>> GetByLocationAsync(string location);
    Task<IEnumerable<StockRoom>> SearchByDescriptionAsync(string searchTerm);
    Task<IEnumerable<StockRoom>> GetLowInventoryAsync(int threshold);
    Task<int> GetTotalQuantityAsync();
    Task<decimal> GetTotalValueAsync();
}

public class StockRoomRepository : Repository<StockRoom>, IStockRoomRepository
{
    public StockRoomRepository(ProductionInventoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<StockRoom>> GetByPartNumberAsync(string partNumber)
    {
        return await _dbSet
            .Where(s => s.PartNumber == partNumber)
            .OrderBy(s => s.Location)
            .ToListAsync();
    }

    public async Task<IEnumerable<StockRoom>> GetByLocationAsync(string location)
    {
        return await _dbSet
            .Where(s => s.Location == location)
            .OrderBy(s => s.PartNumber)
            .ToListAsync();
    }

    public async Task<IEnumerable<StockRoom>> SearchByDescriptionAsync(string searchTerm)
    {
        return await _dbSet
            .Where(s => s.Description != null && s.Description.Contains(searchTerm))
            .OrderBy(s => s.PartNumber)
            .ToListAsync();
    }

    public async Task<IEnumerable<StockRoom>> GetLowInventoryAsync(int threshold)
    {
        return await _dbSet
            .Where(s => s.Quantity <= threshold)
            .OrderBy(s => s.Quantity)
            .ThenBy(s => s.PartNumber)
            .ToListAsync();
    }

    public async Task<int> GetTotalQuantityAsync()
    {
        return await _dbSet.SumAsync(s => s.Quantity);
    }

    public async Task<decimal> GetTotalValueAsync()
    {
        return await _dbSet.SumAsync(s => s.Quantity * s.UnitPrice);
    }
}

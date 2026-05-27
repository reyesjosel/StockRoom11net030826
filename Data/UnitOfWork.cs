using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Repositories;
using StockRoom11net.Data.Services;

namespace StockRoom11net.Data;

/// <summary>
/// Unit of Work pattern - coordinates multiple repositories and ensures transactional consistency
/// Best practice for managing multiple entity types
/// </summary>
public interface IUnitOfWork : IDisposable
{
    // Repository properties
    IStockRoomRepository StockRooms { get; }
    ITableStockRoomTreeViewRepository TableStockRoomTreeViews { get; }

    ITableTimeLineRepository TableTimeLines { get; }
    ITableTimeLineTreeViewRepository TableTimeLineTreeViews { get; }

    ITableEmployeeRepository TableEmployees { get; }
    ITableEmployeeTreeViewRepository TableEmployeeTreeViews { get; }

    // Save changes methods
    Task<int> CompleteAsync();
    Task<int> SaveChangesAsync(); // ✅ Add this alias
    
    // Transaction support
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductionInventoryContext _context;
    private IStockRoomRepository? _stockRooms;
    private ITableStockRoomTreeViewRepository? _tableStockRoomTreeViews;

    private ITableTimeLineRepository? _tableTimeLines;
    private ITableTimeLineTreeViewRepository? _tableTimeLineTreeViews;

    private ITableEmployeeRepository? _tableEmployees;
    private ITableEmployeeTreeViewRepository? _tableEmployeeTreeViews;

    private IDbContextTransaction? _currentTransaction;

    public UnitOfWork(ProductionInventoryContext context)
    {
        _context = context;
    }

    public IStockRoomRepository StockRooms
    {
        get { return _stockRooms ??= new StockRoomRepository(_context); }
    }

    public ITableStockRoomTreeViewRepository TableStockRoomTreeViews
    {
        get { return _tableStockRoomTreeViews ??= new TableStockRoomTreeViewRepository(_context); }
    }

    public ITableTimeLineRepository TableTimeLines
    {
        get { return _tableTimeLines ??= new TableTimeLineRepository(_context); }
    }

    public ITableTimeLineTreeViewRepository TableTimeLineTreeViews
    {
        get { return _tableTimeLineTreeViews ??= new TableTimeLineTreeViewRepository(_context); }
    }
    
    public ITableEmployeeRepository TableEmployees
    {
        get { return _tableEmployees ??= new TableEmployeeRepository(_context); }
    }

    public ITableEmployeeTreeViewRepository TableEmployeeTreeViews
    {
        get { return _tableEmployeeTreeViews ??= new TableEmployeeTreeViewRepository(_context); }
    }

    public IDbContextTransaction? CurrentTransaction => _currentTransaction;

    /// <summary>
    /// Saves all changes made in this unit of work to the database
    /// </summary>
    /// <returns>The number of state entries written to the database</returns>
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Alias for CompleteAsync() - saves all changes to the database
    /// Provided for naming convention preference
    /// </summary>
    /// <returns>The number of state entries written to the database</returns>
    public async Task<int> SaveChangesAsync()
    {
        return await CompleteAsync();
    }

    #region "Transaction Management"

    /// <summary>
    /// Begins a new database transaction
    /// </summary>
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            throw new InvalidOperationException("A transaction is already in progress.");
        }

        _currentTransaction = await _context.Database.BeginTransactionAsync();
        return _currentTransaction;
    }

    /// <summary>
    /// Commits the current transaction
    /// </summary>
    public async Task CommitTransactionAsync()
    {
        if (_currentTransaction == null)
        {
            throw new InvalidOperationException("No active transaction to commit.");
        }

        try
        {
            await _context.SaveChangesAsync();
            await _currentTransaction.CommitAsync();
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    /// <summary>
    /// Rolls back the current transaction
    /// </summary>
    public async Task RollbackTransactionAsync()
    {
        if (_currentTransaction == null)
        {
            throw new InvalidOperationException("No active transaction to rollback.");
        }

        try
        {
            await _currentTransaction.RollbackAsync();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    #endregion

    public void Dispose()
    {
        _currentTransaction?.Dispose();
        _context.Dispose();
    }
}

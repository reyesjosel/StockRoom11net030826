namespace StockRoom11net.Data;

/// <summary>
/// Unit of Work pattern - coordinates multiple repositories and ensures transactional consistency
/// Best practice for managing multiple entity types
/// </summary>
public interface IUnitOfWork : IDisposable
{
    IStockRoomRepository StockRooms { get; }
    IRepository<Project> Projects { get; }
    IRepository<Employee> Employees { get; }
    IRepository<Location> Locations { get; }
    IRepository<Marshall> Marshalls { get; }
    IRepository<Timeline> Timelines { get; }

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductionInventoryContext _context;
    private Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction? _transaction;

    // Lazy-loaded repositories
    private IStockRoomRepository? _stockRooms;
    private IRepository<Project>? _projects;
    private IRepository<Employee>? _employees;
    private IRepository<Location>? _locations;
    private IRepository<Marshall>? _marshalls;
    private IRepository<Timeline>? _timelines;

    public UnitOfWork(ProductionInventoryContext context)
    {
        _context = context;
    }

    public IStockRoomRepository StockRooms => 
        _stockRooms ??= new StockRoomRepository(_context);

    public IRepository<Project> Projects => 
        _projects ??= new Repository<Project>(_context);

    public IRepository<Employee> Employees => 
        _employees ??= new Repository<Employee>(_context);

    public IRepository<Location> Locations => 
        _locations ??= new Repository<Location>(_context);

    public IRepository<Marshall> Marshalls => 
        _marshalls ??= new Repository<Marshall>(_context);

    public IRepository<Timeline> Timelines => 
        _timelines ??= new Repository<Timeline>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}

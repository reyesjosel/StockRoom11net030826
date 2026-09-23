using Microsoft.EntityFrameworkCore;
using StockRoom11net.Data.Entities;

namespace StockRoom11net.Data.Repositories;


/// <summary>
/// ✅ REPOSITORY — only data access, no logic
/// Repository interface for TableEmployee operations
/// </summary>
public interface ITableEmployeeRepository : IRepository<Table_Employee>
{
    // Basic CRUD operations
    Task<Table_Employee?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_Employee>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_Employee>> GetAllDepartmentsAsync(CancellationToken cancellationToken = default);
    Task<Table_Employee> AddAsync(Table_Employee entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing entity in the Table_Employees table.
    /// It first checks if the entity exists in the database by its primary key (Index).
    /// If it doesn't exist, it throws a KeyNotFoundException. If it exists, it updates
    /// the tracked entity with the new values and saves the changes to the database.
    /// No need call SaveChangesAsync() after this method, it will be called in the service layer after all operations are done.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    Task UpdateAsync(Table_Employee entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an entity from the Table_Employees table by its ID. If the entity is found,
    /// it is removed and changes are saved to the database. If the entity is not found, no action is taken.
    /// No need call SaveChangesAsync() after this method, it will be called in the service layer after all operations are done.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
        
    // Query operations
    Task<IEnumerable<Table_Employee>> FindByLastNameAsync(string lastName, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_Employee>> FindByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_Employee>> SearchByLast6DigitAsync(int last6Digit, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_Employee>> FindByDepartmentAsync(string departmentName, CancellationToken cancellationToken = default);

    // Batch operations
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    string StatusInfoDefault { get; }

    string AccessLevelDefault { get; }

    Task<int> GetMaxIdAsync(CancellationToken cancellationToken = default);

    Task<int> GetNextIdAsync(CancellationToken cancellationToken = default);
}


/// <summary>
/// ✅ REPOSITORY — only data access, no logic
/// Repository implementation for TableEmployee entity
/// </summary>
public class TableEmployeeRepository : Repository<Table_Employee>, ITableEmployeeRepository
{
    static readonly string _statusInfoDefault = "Locked␟True␞Selected␟False␞Unerasable␟True␞Color␟-36865␞Note␟Null␞HeaderInf␟Null␞";

    public string StatusInfoDefault
    {
        get
        {
            return _statusInfoDefault;
        }
    }

    static readonly string _accessLevelDefault = "AccessLevel:3;AutoSizeColumnsMode:1;EditMode:3;EnableTreeViewSetting:1";

    public string AccessLevelDefault
    {
        get
        {
            return _accessLevelDefault;
        }
    }

    public async Task<int> GetMaxIdAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(cancellationToken)?
               await _dbSet.MaxAsync(e => e.ID, cancellationToken)
              : 0;
    }

    public async Task<int> GetNextIdAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(cancellationToken)?
               await _dbSet.MaxAsync(e => e.ID, cancellationToken) + 1
               : 1;
    }

    public TableEmployeeRepository(ProductionInventoryContext context) : base(context)
    {
    }

    #region Basic CRUD Operations

    public async Task<Table_Employee?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Table_Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == id, cancellationToken);
    }

    public async Task<IEnumerable<Table_Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Table_Employees
            .AsNoTracking()
            .OrderBy(x => x.ID)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_Employee>> GetAllDepartmentsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Table_Employees
            .AsNoTracking()
            .Where(x => x.Department == "Department")
            .OrderBy(x => x.ID)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Adds a new entity to the Table_Employees table and saves changes to the database.
    /// No need call SaveChangesAsync() after this method, it will be called in the service layer after all operations are done.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The added entity.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<Table_Employee> AddAsync(Table_Employee entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _context.Table_Employees.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    /// <summary>
    /// Updates an existing entity in the Table_Employees table.
    /// It first checks if the entity exists in the database by its primary key (Index).
    /// If it doesn't exist, it throws a KeyNotFoundException. If it exists, it updates
    /// the tracked entity with the new values and saves the changes to the database.
    /// No need call SaveChangesAsync() after this method, it will be called in the service layer after all operations are done.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task UpdateAsync(Table_Employee entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        // Find the existing tracked entity by PK first to avoid a
        // DbUpdateConcurrencyException when the entity is untracked (AsNoTracking).
        var existing = await _context.Table_Employees.FindAsync(new object[] { entity.Index }, cancellationToken);

        if (existing == null)
            throw new KeyNotFoundException($"Row with Index={entity.Index} not found. It may have been deleted.");

        // Copy new values onto the tracked entity and save.
        _context.Entry(existing).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Deletes an entity from the Table_Employees table by its Index. If the entity is found,
    /// it is removed and changes are saved to the database. If the entity is not found, no action is taken.
    /// No need call SaveChangesAsync() after this method, it will be called in the service layer after all operations are done.
    /// </summary>
    /// <param name="index">The Index of the entity to delete.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task DeleteByIdAsync(int index, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Table_Employees.FindAsync(new object[] { index }, cancellationToken);
        if (entity != null)
        {
            _context.Table_Employees.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    #endregion
    
    #region Query Operations

    public async Task<IEnumerable<Table_Employee>> FindByLastNameAsync(string lastName, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            return Enumerable.Empty<Table_Employee>();

        return await _context.Table_Employees
            .AsNoTracking()
            .Where(x => x.LastName == lastName)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_Employee>> FindByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Enumerable.Empty<Table_Employee>();

        return await _context.Table_Employees
            .AsNoTracking()
            .Where(x => x.Name == name)
            .OrderBy(x => x.ID)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_Employee>> SearchByLast6DigitAsync(int last6Digit, CancellationToken cancellationToken = default)
    {
        if (last6Digit <= 0)
            return Enumerable.Empty<Table_Employee>();
                
        return await _context.Table_Employees
            .AsNoTracking()
            .Where(x => (x.Last6Digit == last6Digit))
            .OrderBy(x => x.ID)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_Employee>> FindByDepartmentAsync(string departmentName, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(departmentName))
            return Enumerable.Empty<Table_Employee>();

        return await _context.Table_Employees
            .AsNoTracking()
            .Where(x => x.Department == departmentName)
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
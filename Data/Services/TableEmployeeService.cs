using StockRoom11net.Data.Entities;
using System.ComponentModel;

namespace StockRoom11net.Data.Services;

/// <summary>
/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
/// Service layer for EmployeeInformation business logic using scaffolded entities
/// </summary>
public partial interface ITableEmployeeService
{    
    IUnitOfWork UnitOfWork { get; }
    Task<BindingList<Table_Employee>> LoadEmployeeAsync();
    Task<BindingList<Table_Employee>> SearchEmployeeAsync(string searchTerm);
    Task<Table_Employee?> GetEmployeeByIdAsync(int id);
    Task<Table_Employee> CreateEmployeeAsync(Table_Employee employee);
    Task UpdateEmployeeAsync(Table_Employee employee);
    Task DeleteEmployeeAsync(int id);
    Task<BindingList<Table_Employee>> GetEmployeesByFilterAsync(string filter);
}

/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
public partial class TableEmployeeService : ITableEmployeeService
{
    public readonly IUnitOfWork _unitOfWork;
          
    public async Task<BindingList<Table_Employee>> LoadEmployeeAsync()
    {
        var items = await _unitOfWork.TableEmployees.GetAllAsync();
        return new BindingList<Table_Employee>(items.ToList());
    }

    public async Task<BindingList<Table_Employee>> SearchEmployeeAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await LoadEmployeeAsync();

        var items = await _unitOfWork.TableEmployees.FindAsync(t => 
        (t.Last6Digit != null && t.Last6Digit.ToString().Contains(searchTerm)) ||
             (t.LastName != null && t.LastName.Contains(searchTerm)) ||
             (t.Name != null && t.Name.Contains(searchTerm)));

        return new BindingList<Table_Employee>(items.ToList());
    }

    public async Task<BindingList<Table_Employee>> GetEmployeesByFilterAsync(string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
            return await LoadEmployeeAsync();

        var items = await _unitOfWork.TableEmployees.FindAsync(t => 
                (t.Last6Digit != null && t.Last6Digit.ToString().Contains(filter)) ||
                (t.LastName != null && t.LastName.Contains(filter)) ||
                (t.Name != null && t.Name.Contains(filter)));
        
        return new BindingList<Table_Employee>(items.ToList());
    }

    public async Task<Table_Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _unitOfWork.TableEmployees.GetByIdAsync(id);
    }

    public async Task<Table_Employee> CreateEmployeeAsync(Table_Employee employee)
    {
        // Ensure required fields are set
        if (employee.Dob == default)
            employee.Dob = DateTime.Now;

        if (string.IsNullOrEmpty(employee.Status))
            employee.Status = "Active";

        var created = await _unitOfWork.TableEmployees.AddAsync(employee);
        await _unitOfWork.SaveChangesAsync();
        return created;
    }

    public async Task UpdateEmployeeAsync(Table_Employee employee)
    {
        _unitOfWork.TableEmployees.Update(employee);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _unitOfWork.TableEmployees.GetByIdAsync(id);
        if (employee != null)
        {
            _unitOfWork.TableEmployees.Remove(employee);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
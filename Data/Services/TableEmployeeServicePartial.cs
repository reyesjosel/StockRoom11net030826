using StockRoom11net.Controls;
using StockRoom11net.Controls.DocumentationBehavior;
using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Data.Entities;
using StockRoom11net.Properties;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace StockRoom11net.Data.Services;

/// <summary>
/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
/// Service layer for EmployeeInformation business logic using scaffolded entities
/// </summary>
public partial interface ITableEmployeeService
{
    public int NoUserLogIn { get; set; }

    public int MasterPassword { get; set; }

    /// <summary>
    /// Gets the currently logged-in employee entity.
    /// </summary>
    Table_Employee CurrentEmployeeEntity { get; }

    /// <summary>
    /// Currently logged-in employee.
    /// </summary>
    EmployeeInformation CurrentEmployeeLogIn { get; set; }

    /// <summary>
    /// Raised when the logged-in employee changes.
    /// </summary>
    event EventHandler<EmployeeInformation>? CurrentEmployeeLogInChanged;
        
    public Task<bool> InitializeEmployeeAsync(int last6Digit);
        
    string GetTableName();


    public Task InitializeDefaultDepartmentAsync(string departmentName);
    public DepartmentInformation CurrentDepartmentLogIn { get; set; }
    public List<DepartmentInformation> DepartmentsInformationList { get; set; }
    public List<string> DepartmentsList { get; set; }

    public event EventHandler<DepartmentInformation>? CurrentDepartmentLogInChanged;

}


/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
public partial class TableEmployeeService : ITableEmployeeService
{
    public IUnitOfWork UnitOfWork
    {
        get { return _unitOfWork; }
    }

    public TableEmployeeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeDepartmentList();
        _ = InitializeEmployeeAsync(NoUserLogIn);
        _ = InitializeDefaultDepartmentAsync(NoSetToAnyDepartmentYet);

        // 🔔 Fire the event to notify all subscribers
        CurrentEmployeeLogInChanged?.Invoke(this, _currentEmployeeLogIn!);
    }

    /// <summary>
    /// Gets or sets the debug message position.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string MessageDebugPosition { get; set; } = string.Empty;
    public static string SpliterCharacter
    {
        get
        {
            return "&";
        }
    }
    public int NoUserLogIn { get; set; } = 0;
    public string NoSetToAnyDepartmentYet { get; } = "No set to any department yet";
    public int MasterPassword { get; set; } = 811266;

    public string GetTableName()
    {
        return "Table_Employee";
    }

    #region "Employee Initializacion"

    private Table_Employee _currentEmployeeEntity;

    public Table_Employee CurrentEmployeeEntity
    { 
        get => _currentEmployeeEntity;
        private set => _currentEmployeeEntity = value;
    }

    private EmployeeInformation _currentEmployeeLogIn;       

    public EmployeeInformation CurrentEmployeeLogIn
    {
        get => _currentEmployeeLogIn;
        set
        {
            if (_currentEmployeeLogIn == value)
                return;

            _currentEmployeeLogIn = value;

            // 🔔 Fire the event to notify all subscribers
            CurrentEmployeeLogInChanged?.Invoke(this, _currentEmployeeLogIn!);
        }
    }

    public event EventHandler<EmployeeInformation>? CurrentEmployeeLogInChanged;
    
    public async Task<bool> InitializeEmployeeAsync(int last6Digit)
    {
        var UserLogInEntity = await _unitOfWork.TableEmployeeRepository.FirstOrDefaultAsync(e => e.Last6Digit == last6Digit);

        if(UserLogInEntity == null)
        {
            var defaultemployee = new EmployeeInformation();

            if (CurrentEmployeeLogIn != defaultemployee)
            {
                CurrentEmployeeEntity = new Table_Employee();
                CurrentEmployeeLogIn = defaultemployee;
                CurrentEmployeeLogIn.EmployeesService = this;
            }
        }
        else
        {
            var loggedEmployee = new EmployeeInformation(UserLogInEntity);

            if (CurrentEmployeeLogIn != loggedEmployee)
            {
                CurrentEmployeeEntity = UserLogInEntity;
                CurrentEmployeeLogIn = loggedEmployee;
                CurrentEmployeeLogIn.EmployeesService = this;
            }
        }

        return UserLogInEntity != null;
    }

    #endregion "Employee Initializacion"

    #region"Department Initializacion"

    /// <summary>
    /// List of department available in the system, use this list to setup the
    /// computer department name.
    /// </summary>
    public List<DepartmentInformation> DepartmentsInformationList { get; set; } = new List<DepartmentInformation>();
    public List<string> DepartmentsList { get; set; } = new List<string>();

    private void InitializeDepartmentList()
    {
        IEnumerable<Table_Employee> departments = _unitOfWork.TableEmployeeRepository.GetAllDepartmentsAsync().Result;

        foreach (Table_Employee department in departments)
        {
            DepartmentsList.Add(department.Name ?? "No Department Name");
            DepartmentsInformationList.Add(new DepartmentInformation(department));
        }
    }

    private DepartmentInformation _currentDepartmentLogIn;

    public DepartmentInformation CurrentDepartmentLogIn
    {
        get => _currentDepartmentLogIn;
        set
        {
            if (_currentDepartmentLogIn == value)
                return;

            _currentDepartmentLogIn = value;

            // 🔔 Fire the event to notify all subscribers
            CurrentDepartmentLogInChanged?.Invoke(this, _currentDepartmentLogIn!);
        }
    }

    public event EventHandler<DepartmentInformation>? CurrentDepartmentLogInChanged;

    public async Task InitializeDefaultDepartmentAsync(string departmentName)
    {
        try
        {
            var DepartmentLogIn = DepartmentsInformationList.FirstOrDefault(d => d.DepartmentName == departmentName);

            if (DepartmentLogIn == null)
            {
                CurrentDepartmentLogIn = new DepartmentInformation();
            }
            else
            {
                CurrentDepartmentLogIn = DepartmentLogIn;
            }
        }
        catch (Exception error)
        {
            MessageBox.Show(new Form() { TopMost = true }, "The InitializeDefaultDepartmentAsync method has found an error " +
                error.Message, "EmployeesInformation Class error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
        
    #endregion"Department Initializacion"

}


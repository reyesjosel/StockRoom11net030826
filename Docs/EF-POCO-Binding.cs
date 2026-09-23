using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using System.ComponentModel;


namespace StockRoom11net.Docs
{
    internal class EF_POCO_Binding
    {
        // Injected EF Core services
        private readonly IAppService _iappService;
        private readonly IUnitOfWork _unitOfWork;
        private ITableEmployeeTreeViewService _tableEmployeesTreeViewService;

        private ITableEmployeeService _employeesService;

        private PropertyDescriptorCollection _employeeColumnsCollection;
        /// <summary>
        /// EF Core migration: POCO/BindingList equivalent of DataColumnCollection.
        /// Keeps a record of all "columns" (properties) existent in the Table_Employee entity,
        /// obtained from _employeesService's data instead of a DataTable.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PropertyDescriptorCollection ColumnsCollectionEmployee
        {
            get
            {
                return _employeeColumnsCollection;
            }
            set
            {
                _employeeColumnsCollection = value;
                _iappService.ColumnsCollection = value;
            }
        }

        List<string> _positionList;
        /// <summary>
        /// EF Core migration: loads a distinct list of employee positions from the Table_Employee entity.
        /// </summary>
        /// <returns></returns>
        async Task PositionList()
        {
            _positionList = (await _employeesService.LoadEmployeeAsync())
                                                    .Where(emp => !string.IsNullOrEmpty(emp.Position))
                                                    .Select(emp => emp.Position.Trim())
                                                    .Distinct()
                                                    .ToList();
        }

        async Task LoadEmployeeDataAsync()
        {
            // EF Core migration: load entities directly from the service instead of
            // pulling a DataTable out of a DataSet-backed BindingSource.
            BindingList<Table_Employee> employees = await _employeesService.LoadEmployeeAsync();

            // Wrap the list in a BindingSource for compatibility with existing UI code that expects a BindingSource.
            // This aproach loses the ability to filter and sort, but it allows us to use the typed Table_Employee objects directly.
            BindingSource _bindingSource_Employees = new BindingSource();
            _bindingSource_Employees.DataSource = employees;

            // POCO equivalent of DataColumnCollection: exposes the "columns" (properties)
            // of Table_Employee for UI code that previously enumerated table.Columns.
            ColumnsCollectionEmployee = TypeDescriptor.GetProperties(typeof(Table_Employee));            
        }
    }
}

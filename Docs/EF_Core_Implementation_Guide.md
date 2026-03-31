# Entity Framework Core Implementation Guide

## 📋 Overview
This implementation replaces the legacy DataSet/TableAdapter pattern with modern Entity Framework Core for .NET 11.

## 🎯 Key Benefits

### 1. **Performance**
- Async/await for non-blocking database operations
- LINQ query optimization
- Connection pooling by default
- Lazy loading and eager loading support

### 2. **Type Safety**
- Strongly-typed entities (no more DataRowView)
- Compile-time error checking
- IntelliSense support
- Refactoring-friendly

### 3. **Maintainability**
- Repository pattern for clean separation
- Unit of Work for transaction management
- Dependency Injection for testability
- Clear data access layer

### 4. **Modern Patterns**
- INotifyPropertyChanged for data binding
- BindingList<T> for DataGridView compatibility
- Async operations throughout
- Service layer for business logic

## 🚀 Usage Examples

### Basic CRUD Operations

#### Reading Data (Replace DataAdapter.Fill)
```csharp
// OLD WAY (DataSet/TableAdapter)
var adapter = new Table_StockRoomTableAdapter();
var dataTable = new Production_InventoryDataSet.Table_StockRoomDataTable();
adapter.Fill(dataTable);
dataGridView.DataSource = dataTable;

// NEW WAY (EF Core)
using var scope = DependencyInjection.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<IStockRoomService>();
var items = await service.GetAllStockRoomsAsync();
dataGridView.DataSource = items; // BindingList<StockRoom>
```

#### Creating New Records
```csharp
// NEW WAY
using var scope = DependencyInjection.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<IStockRoomService>();

var newItem = new StockRoom
{
    PartNumber = "ABC-123",
    Description = "Test Component",
    Quantity = 100,
    UnitPrice = 12.50m,
    Location = "A1-B2"
};

await service.CreateStockRoomAsync(newItem);
// Automatically saved to database
```

#### Updating Records
```csharp
// NEW WAY
using var scope = DependencyInjection.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<IStockRoomService>();

var item = await service.GetStockRoomByIdAsync(1);
if (item != null)
{
    item.Quantity += 50;
    item.Location = "New Location";
    await service.UpdateStockRoomAsync(item);
}
```

#### Deleting Records
```csharp
// NEW WAY
using var scope = DependencyInjection.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<IStockRoomService>();

await service.DeleteStockRoomAsync(1);
```

### Advanced Queries

#### Filtering with LINQ
```csharp
using var scope = DependencyInjection.CreateScope();
var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

// Find all items in a specific location
var items = await unitOfWork.StockRooms.FindAsync(s => s.Location == "A1-B2");

// Find low inventory items
var lowStock = await unitOfWork.StockRooms.GetLowInventoryAsync(10);

// Complex query
var result = await unitOfWork.StockRooms.FindAsync(s => 
    s.Quantity < 50 && 
    s.UnitPrice > 10 && 
    s.Description!.Contains("Component"));
```

#### Searching
```csharp
using var scope = DependencyInjection.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<IStockRoomService>();

var searchResults = await service.SearchStockRoomsAsync("resistor");
dataGridView.DataSource = searchResults;
```

### Using in Forms

#### Form with Service Injection
```csharp
public partial class StockRoomInventoryForm : Form
{
    private readonly IStockRoomService _stockRoomService;
    private BindingList<StockRoom> _items;

    // Constructor injection (best practice)
    public StockRoomInventoryForm(IStockRoomService stockRoomService)
    {
        InitializeComponent();
        _stockRoomService = stockRoomService;
    }

    private async void Form_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            // Show loading indicator
            Cursor = Cursors.WaitCursor;

            _items = await _stockRoomService.GetAllStockRoomsAsync();
            dataGridView.DataSource = _items;

            // Data binding works automatically with INotifyPropertyChanged
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (var item in _items)
            {
                await _stockRoomService.UpdateStockRoomAsync(item);
            }
            MessageBox.Show("Changes saved successfully!");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving: {ex.Message}");
        }
    }
}
```

#### Manual Service Resolution (if not using DI in form)
```csharp
private async void btnLoad_Click(object sender, EventArgs e)
{
    using var scope = DependencyInjection.CreateScope();
    var service = scope.ServiceProvider.GetRequiredService<IStockRoomService>();

    var items = await service.GetAllStockRoomsAsync();
    dataGridView.DataSource = items;
}
```

### Transactions (Unit of Work)

#### Multiple Operations in Transaction
```csharp
using var scope = DependencyInjection.CreateScope();
var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

try
{
    await unitOfWork.BeginTransactionAsync();

    // Add new stock
    var newItem = new StockRoom { PartNumber = "XYZ", Quantity = 100 };
    await unitOfWork.StockRooms.AddAsync(newItem);

    // Update project
    var project = await unitOfWork.Projects.GetByIdAsync(1);
    if (project != null)
    {
        project.Status = "Active";
        unitOfWork.Projects.Update(project);
    }

    // Save all changes in transaction
    await unitOfWork.SaveChangesAsync();
    await unitOfWork.CommitTransactionAsync();
}
catch
{
    await unitOfWork.RollbackTransactionAsync();
    throw;
}
```

## 🔧 Migration from DataSet/TableAdapter

### Step-by-Step Migration

1. **Identify Current Usage**
   - Find all `TableAdapter.Fill()` calls
   - Find all `DataRow` manipulations
   - Find all `BindingSource` configurations

2. **Replace with Services**
   ```csharp
   // Before
   _adapter.Fill(_dataTable);
   bindingSource.DataSource = _dataTable;

   // After
   var items = await _service.GetAllStockRoomsAsync();
   bindingSource.DataSource = items;
   ```

3. **Update Data Binding**
   - Entities already implement INotifyPropertyChanged
   - Use BindingList<T> for two-way binding
   - DataGridView works seamlessly

4. **Handle Async Operations**
   - Use async/await throughout
   - Show loading indicators
   - Handle exceptions properly

## ⚡ Performance Tips

1. **Use AsNoTracking for Read-Only Queries**
   ```csharp
   var items = await _context.StockRooms
       .AsNoTracking()
       .Where(s => s.Location == "A1")
       .ToListAsync();
   ```

2. **Eager Loading for Related Data**
   ```csharp
   var projects = await _context.Projects
       .Include(p => p.Items) // Load related items
       .ToListAsync();
   ```

3. **Batch Operations**
   ```csharp
   await unitOfWork.StockRooms.AddRangeAsync(manyItems);
   await unitOfWork.SaveChangesAsync(); // Single database call
   ```

## 🐛 Troubleshooting

### Issue: "Service provider not initialized"
**Solution:** Ensure `services.AddDataServices()` is called in Program.cs

### Issue: "Entity tracking error"
**Solution:** Use separate DbContext instances or detach entities

### Issue: "Connection string not found"
**Solution:** Verify App.config has connection string in correct format

## 📚 Additional Resources

- [EF Core Documentation](https://docs.microsoft.com/ef/core/)
- [Repository Pattern](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
- [Async Programming](https://docs.microsoft.com/en-us/dotnet/csharp/async)

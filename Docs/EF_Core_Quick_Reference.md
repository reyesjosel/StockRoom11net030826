# 🚀 EF Core Quick Reference - .NET 11 WinForms

## 📦 Packages Installed
```
✅ Microsoft.EntityFrameworkCore.Sqlite (10.0.5)
✅ Microsoft.EntityFrameworkCore.Design (10.0.5)
✅ Microsoft.Data.Sqlite.Core (10.0.5)
```

## 🏗️ Architecture Overview

```
┌─────────────────────────────────────────────────┐
│              WinForms (UI Layer)                 │
│  ├─ DataGridView binds to BindingList<T>       │
│  └─ Forms inject services via DI                │
└─────────────────────────────────────────────────┘
                      ↓
┌─────────────────────────────────────────────────┐
│           Service Layer (Business Logic)         │
│  ├─ StockRoomService                            │
│  └─ Returns BindingList<T> for WinForms         │
└─────────────────────────────────────────────────┘
                      ↓
┌─────────────────────────────────────────────────┐
│        Repository + Unit of Work Pattern         │
│  ├─ IRepository<T> - Generic CRUD               │
│  ├─ StockRoomRepository - Custom queries        │
│  └─ UnitOfWork - Transaction management         │
└─────────────────────────────────────────────────┘
                      ↓
┌─────────────────────────────────────────────────┐
│           DbContext (EF Core)                    │
│  └─ ProductionInventoryContext                  │
└─────────────────────────────────────────────────┘
                      ↓
┌─────────────────────────────────────────────────┐
│          SQLite Database                         │
│  Production_InventoryConnectionString           │
└─────────────────────────────────────────────────┘
```

## 💡 Quick Start - Replace Old Code

### 1️⃣ Load Data into DataGridView

**❌ OLD (DataSet/TableAdapter)**
```csharp
var adapter = new Table_StockRoomTableAdapter();
var dataTable = new DataTable();
adapter.Fill(dataTable);
dataGridView.DataSource = dataTable;
```

**✅ NEW (EF Core)**
```csharp
var service = DependencyInjection.GetService<IStockRoomService>();
var items = await service.GetAllStockRoomsAsync();
dataGridView.DataSource = items; // BindingList<StockRoom>
```

### 2️⃣ Filter/Search Data

**❌ OLD**
```csharp
bindingSource.Filter = "Description LIKE '%search%'";
```

**✅ NEW**
```csharp
var service = DependencyInjection.GetService<IStockRoomService>();
var results = await service.SearchStockRoomsAsync("search");
dataGridView.DataSource = results;
```

### 3️⃣ Add New Record

**❌ OLD**
```csharp
adapter.Insert(partNo, desc, qty, loc, price, DateTime.Now);
```

**✅ NEW**
```csharp
var service = DependencyInjection.GetService<IStockRoomService>();
var newItem = new StockRoom 
{ 
    PartNumber = "ABC-123",
    Description = "Part",
    Quantity = 100 
};
await service.CreateStockRoomAsync(newItem);
```

### 4️⃣ Update Record

**❌ OLD**
```csharp
adapter.Update(partNo, desc, qty, loc, price, DateTime.Now, id);
```

**✅ NEW**
```csharp
var service = DependencyInjection.GetService<IStockRoomService>();
item.Quantity = 150; // Modify entity
await service.UpdateStockRoomAsync(item);
```

### 5️⃣ Delete Record

**❌ OLD**
```csharp
adapter.Delete(id);
```

**✅ NEW**
```csharp
var service = DependencyInjection.GetService<IStockRoomService>();
await service.DeleteStockRoomAsync(id);
```

## 🎯 Common Patterns

### Pattern 1: Form with Dependency Injection
```csharp
public class MyForm : Form
{
    private readonly IStockRoomService _service;

    // Constructor injection (recommended)
    public MyForm(IStockRoomService service)
    {
        InitializeComponent();
        _service = service;
    }

    private async void Form_Load(object sender, EventArgs e)
    {
        var data = await _service.GetAllStockRoomsAsync();
        dataGridView.DataSource = data;
    }
}
```

### Pattern 2: Manual Service Resolution
```csharp
private async void btnLoad_Click(object sender, EventArgs e)
{
    using var scope = DependencyInjection.CreateScope();
    var service = scope.ServiceProvider.GetRequiredService<IStockRoomService>();

    var data = await service.GetAllStockRoomsAsync();
    dataGridView.DataSource = data;
}
```

### Pattern 3: Direct Repository Access
```csharp
using var scope = DependencyInjection.CreateScope();
var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

// Complex LINQ query
var results = await unitOfWork.StockRooms.FindAsync(s => 
    s.Quantity < 50 && 
    s.UnitPrice > 10m);
```

### Pattern 4: Transactions
```csharp
using var scope = DependencyInjection.CreateScope();
var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

await unitOfWork.BeginTransactionAsync();
try
{
    await unitOfWork.StockRooms.AddAsync(newItem);
    await unitOfWork.Projects.UpdateAsync(project);
    await unitOfWork.SaveChangesAsync();
    await unitOfWork.CommitTransactionAsync();
}
catch
{
    await unitOfWork.RollbackTransactionAsync();
    throw;
}
```

## 🔍 LINQ Query Examples

```csharp
// Get all
var all = await unitOfWork.StockRooms.GetAllAsync();

// Find by condition
var filtered = await unitOfWork.StockRooms.FindAsync(s => s.Quantity > 100);

// Find single
var item = await unitOfWork.StockRooms.FirstOrDefaultAsync(s => s.PartNumber == "ABC");

// Complex query
var complex = await unitOfWork.StockRooms.FindAsync(s =>
    s.Quantity < threshold &&
    s.Location != null &&
    s.Location.StartsWith("A") &&
    s.Description!.Contains("Component"));

// Sorting
var sorted = (await unitOfWork.StockRooms.GetAllAsync())
    .OrderBy(s => s.PartNumber)
    .ThenByDescending(s => s.Quantity);

// Grouping
var grouped = (await unitOfWork.StockRooms.GetAllAsync())
    .GroupBy(s => s.Location)
    .Select(g => new { Location = g.Key, Count = g.Count() });
```

## ⚡ Performance Tips

### ✅ DO
```csharp
// Use async/await
await service.GetAllAsync();

// Batch operations
await unitOfWork.StockRooms.AddRangeAsync(manyItems);

// Project only needed columns
var names = await context.StockRooms
    .Select(s => s.PartNumber)
    .ToListAsync();
```

### ❌ DON'T
```csharp
// Don't block async calls
var data = service.GetAllAsync().Result; // ❌

// Don't query in loops
foreach (var id in ids)
{
    var item = await service.GetByIdAsync(id); // ❌
}

// Don't load unnecessary data
var all = await service.GetAllAsync(); // ❌ if you only need few
```

## 🐛 Common Errors & Solutions

### Error: "Service provider not initialized"
```csharp
// ✅ Solution: Add to Program.cs
services.AddDataServices();
```

### Error: "The instance cannot be tracked"
```csharp
// ✅ Solution: Use separate context or detach
context.Entry(entity).State = EntityState.Detached;
```

### Error: "Async method lacks await"
```csharp
// ❌ Wrong
private async void Method() { }

// ✅ Correct
private async Task Method() { }
```

## 📂 File Structure Created

```
StockRoom11net/
├── Data/
│   ├── ProductionInventoryContext.cs     # DbContext
│   ├── DependencyInjection.cs             # DI setup
│   ├── UnitOfWork.cs                      # Transaction mgmt
│   ├── Entities/
│   │   ├── StockRoom.cs                   # Entity model
│   │   └── OtherEntities.cs               # Other models
│   └── Repositories/
│       ├── Repository.cs                   # Generic repo
│       └── StockRoomRepository.cs          # Specific repo
├── Services/
│   └── StockRoomService.cs                 # Business logic
├── Examples/
│   └── StockRoomFormExample.cs             # Usage examples
└── Docs/
    └── EF_Core_Implementation_Guide.md     # Full guide
```

## 🎓 Next Steps

1. **Verify Build**: Build solution to ensure no errors
2. **Update Connection String**: Check App.config connection string
3. **Create Database**: Run migrations if needed
4. **Test Service**: Create test form to verify data loading
5. **Migrate Forms**: Gradually replace DataSet/TableAdapter in forms
6. **Add Validation**: Implement FluentValidation for entity validation
7. **Add Logging**: Use ILogger for debugging
8. **Unit Tests**: Add tests for services and repositories

## 📞 Support Resources

- **Full Guide**: See `Docs/EF_Core_Implementation_Guide.md`
- **Examples**: See `Examples/StockRoomFormExample.cs`
- **EF Core Docs**: https://learn.microsoft.com/ef/core/
- **SQLite Provider**: https://learn.microsoft.com/ef/core/providers/sqlite/

---

**✨ You now have a modern, maintainable, high-performance data access layer!**

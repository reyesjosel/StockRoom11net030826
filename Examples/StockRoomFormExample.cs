using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace StockRoom11net.Examples;

/// <summary>
/// Example: Migrating from DataSet/TableAdapter to EF Core
/// Shows side-by-side comparison
/// </summary>
public partial class StockRoomFormExample : Form
{
    private readonly IStockRoomService _stockRoomService;
    private BindingList<StockRoom> _bindingList;

    #region Constructor with Dependency Injection

    // Modern approach: Constructor injection
    public StockRoomFormExample(IStockRoomService stockRoomService)
    {
        InitializeComponent();
        _stockRoomService = stockRoomService;
        _bindingList = new BindingList<StockRoom>();
    }

    // Alternative: Manual service resolution (if form not created via DI)
    public StockRoomFormExample()
    {
        InitializeComponent();

        // Get service manually
        using var scope = DependencyInjection.CreateScope();
        _stockRoomService = scope.ServiceProvider.GetRequiredService<IStockRoomService>();
        _bindingList = new BindingList<StockRoom>();
    }

    #endregion

    #region OLD WAY vs NEW WAY Examples

    // ============================================================================
    // EXAMPLE 1: Loading Data
    // ============================================================================

    /* OLD WAY (DataSet/TableAdapter)
    private void LoadData_OldWay()
    {
        var adapter = new Table_StockRoomTableAdapter();
        var dataTable = new Production_InventoryDataSet.Table_StockRoomDataTable();

        adapter.Fill(dataTable);

        var bindingSource = new BindingSource();
        bindingSource.DataSource = dataTable;
        dataGridView.DataSource = bindingSource;
    }
    */

    // NEW WAY (EF Core with async)
    private async Task LoadData_NewWay()
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            statusLabel.Text = "Loading data...";

            // Load data asynchronously
            _bindingList = await _stockRoomService.GetAllStockRoomsAsync();

            // Bind to DataGridView (supports automatic updates via INotifyPropertyChanged)
            dataGridView.DataSource = _bindingList;

            statusLabel.Text = $"Loaded {_bindingList.Count} items";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            statusLabel.Text = "Error loading data";
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    // ============================================================================
    // EXAMPLE 2: Searching/Filtering
    // ============================================================================

    /* OLD WAY
    private void Search_OldWay(string searchTerm)
    {
        var bindingSource = (BindingSource)dataGridView.DataSource;
        bindingSource.Filter = $"Description LIKE '%{searchTerm}%'";
    }
    */

    // NEW WAY (Type-safe LINQ)
    private async Task Search_NewWay(string searchTerm)
    {
        try
        {
            Cursor = Cursors.WaitCursor;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Load all
                _bindingList = await _stockRoomService.GetAllStockRoomsAsync();
            }
            else
            {
                // Search with service
                _bindingList = await _stockRoomService.SearchStockRoomsAsync(searchTerm);
            }

            dataGridView.DataSource = _bindingList;
            statusLabel.Text = $"Found {_bindingList.Count} items";
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    // ============================================================================
    // EXAMPLE 3: Adding New Record
    // ============================================================================

    /* OLD WAY
    private void AddRecord_OldWay()
    {
        var adapter = new Table_StockRoomTableAdapter();
        adapter.Insert("ABC-123", "Test Part", 100, "A1", 12.50m, DateTime.Now);
        LoadData_OldWay(); // Refresh grid
    }
    */

    // NEW WAY (Strongly typed with validation)
    private async Task AddRecord_NewWay()
    {
        try
        {
            var newItem = new StockRoom
            {
                PartNumber = txtPartNumber.Text,
                Description = txtDescription.Text,
                Quantity = (int)numQuantity.Value,
                Location = txtLocation.Text,
                UnitPrice = numUnitPrice.Value,
                LastUpdated = DateTime.Now
            };

            // Validate
            if (string.IsNullOrWhiteSpace(newItem.PartNumber))
            {
                MessageBox.Show("Part Number is required");
                return;
            }

            // Save to database
            await _stockRoomService.CreateStockRoomAsync(newItem);

            // Add to binding list (automatic UI update)
            _bindingList.Add(newItem);

            MessageBox.Show("Record added successfully!");
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding record: {ex.Message}");
        }
    }

    // ============================================================================
    // EXAMPLE 4: Updating Record
    // ============================================================================

    /* OLD WAY
    private void UpdateRecord_OldWay(int id)
    {
        var adapter = new Table_StockRoomTableAdapter();
        adapter.Update("ABC-123", "Updated Desc", 150, "B2", 15.00m, DateTime.Now, id);
        LoadData_OldWay();
    }
    */

    // NEW WAY (Entity tracking, automatic change detection)
    private async Task UpdateRecord_NewWay()
    {
        try
        {
            if (dataGridView.CurrentRow?.DataBoundItem is StockRoom selectedItem)
            {
                // Entity already has changes from UI binding
                // Just save it
                await _stockRoomService.UpdateStockRoomAsync(selectedItem);

                MessageBox.Show("Record updated successfully!");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating record: {ex.Message}");
        }
    }

    // ============================================================================
    // EXAMPLE 5: Deleting Record
    // ============================================================================

    /* OLD WAY
    private void DeleteRecord_OldWay(int id)
    {
        var adapter = new Table_StockRoomTableAdapter();
        adapter.Delete(id);
        LoadData_OldWay();
    }
    */

    // NEW WAY
    private async Task DeleteRecord_NewWay()
    {
        try
        {
            if (dataGridView.CurrentRow?.DataBoundItem is StockRoom selectedItem)
            {
                var result = MessageBox.Show(
                    $"Delete {selectedItem.PartNumber}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _stockRoomService.DeleteStockRoomAsync(selectedItem.Id);
                    _bindingList.Remove(selectedItem); // Automatic UI update

                    MessageBox.Show("Record deleted successfully!");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting record: {ex.Message}");
        }
    }

    // ============================================================================
    // EXAMPLE 6: Complex Query with Multiple Conditions
    // ============================================================================

    // NEW WAY (Type-safe LINQ with IntelliSense)
    private async Task ComplexQuery_NewWay()
    {
        using var scope = DependencyInjection.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        // Find items: quantity < 50, price > $10, in locations starting with 'A'
        var results = await unitOfWork.StockRooms.FindAsync(s =>
            s.Quantity < 50 &&
            s.UnitPrice > 10m &&
            s.Location != null &&
            s.Location.StartsWith("A"));

        _bindingList = new BindingList<StockRoom>(results.ToList());
        dataGridView.DataSource = _bindingList;
    }

    // ============================================================================
    // EXAMPLE 7: Batch Operations (Performance)
    // ============================================================================

    // NEW WAY (Efficient bulk operations)
    private async Task BatchUpdate_NewWay(List<StockRoom> itemsToUpdate)
    {
        using var scope = DependencyInjection.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        try
        {
            await unitOfWork.BeginTransactionAsync();

            foreach (var item in itemsToUpdate)
            {
                item.LastUpdated = DateTime.Now;
                unitOfWork.StockRooms.Update(item);
            }

            // Single database call for all updates
            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();

            MessageBox.Show($"{itemsToUpdate.Count} records updated successfully!");
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackTransactionAsync();
            MessageBox.Show($"Error in batch update: {ex.Message}");
        }
    }

    #endregion

    #region Event Handlers

    private async void StockRoomFormExample_Load(object sender, EventArgs e)
    {
        await LoadData_NewWay();
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        await Search_NewWay(txtSearch.Text);
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        await AddRecord_NewWay();
    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
        await UpdateRecord_NewWay();
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        await DeleteRecord_NewWay();
    }

    private async void btnLowInventory_Click(object sender, EventArgs e)
    {
        try
        {
            var lowStock = await _stockRoomService.GetLowInventoryItemsAsync(10);
            dataGridView.DataSource = lowStock;
            statusLabel.Text = $"Found {lowStock.Count} low inventory items";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
    }

    #endregion

    #region Helper Methods

    private void ClearForm()
    {
        txtPartNumber.Clear();
        txtDescription.Clear();
        txtLocation.Clear();
        numQuantity.Value = 0;
        numUnitPrice.Value = 0;
    }

    #endregion

    #region Designer Code (Stub - would be generated)

    private void InitializeComponent()
    {
        // This would be auto-generated by the designer
        // Including controls: dataGridView, txtSearch, btnSearch, etc.
    }

    // Control declarations
    private DataGridView dataGridView = null!;
    private TextBox txtSearch = null!;
    private TextBox txtPartNumber = null!;
    private TextBox txtDescription = null!;
    private TextBox txtLocation = null!;
    private NumericUpDown numQuantity = null!;
    private NumericUpDown numUnitPrice = null!;
    private Button btnSearch = null!;
    private Button btnAdd = null!;
    private Button btnUpdate = null!;
    private Button btnDelete = null!;
    private Button btnLowInventory = null!;
    private StatusStrip statusStrip = null!;
    private ToolStripStatusLabel statusLabel = null!;

    #endregion
}

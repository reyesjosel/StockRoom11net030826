using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockRoom11net.BlazorWebAssembly;
using StockRoom11net.BlazorWebAssembly.Components.Pages;
using StockRoom11net.BlazorWebAssembly.Data;
using StockRoom11net.Controls;
using StockRoom11net.Controls.BindingSourceExt;
using StockRoom11net.Controls.ComponentInformations;
using StockRoom11net.Controls.DataGridViewExtend;
using StockRoom11net.Controls.DirectoryFileOperations;
using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Controls.RawInput;
using StockRoom11net.Controls.ShellBasics;
using StockRoom11net.Controls.SMTcontrol;
using StockRoom11net.Controls.ZPL2_ZebraPrint;
using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using StockRoom11net.Properties;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using static StockRoom11net.Controls.Custom_Events_Args;
using static StockRoom11net.Controls.Utilities;
using CurrentRowMouseEnterEventArgs = StockRoom11net.Controls.Custom_Events_Args.RowsMouseEnterEventArgs;

namespace StockRoom11net
{
    public partial class StockRoom_Inventory : BaseTemple
    {
        #region "Properties"

        // Injected EF Core services
        private readonly IUnitOfWork _unitOfWork;        
        private readonly IStockRoomService _stockRoomService;
        private readonly ITableStockRoomTreeViewService _tableStockRoomTreeViewService;
        
        // ✅ Updated to use scaffolded entity
      //  private BindingList<Table_StockRoom> _stockRoomBindingList;
        private BindingList<Table_StockRoom_TreeView> _stockRoomTreeViewBindingList;

        // Declare as extended type
        public BindingSourceValidating<Table_StockRoom> _bindingSourceStockRoomVal;
        public BindingSourceValidating<Table_Base_TreeView> _bindingSourceStockRoomTreeViewVal;
                
        DataColumnCollection _stockroomColumns;

        readonly AppState _appState = new();
        readonly AppService _appService = new();
                
        bool _settingMode = false;
        /// <summary>
        /// Indicates whether the setting mode is enabled.
        /// If we are editing the dataTreeView table, the columns have different names.
        /// </summary>
        bool SettingMode
        {
            get
            {
                return _settingMode;
            }
            set
            {
                _settingMode = value;
                if (_settingMode)
                {
                    dataTreeViewToAdd_Cancel_Delete.SettingMode = true;
                }
                else
                {
                    dataTreeViewToAdd_Cancel_Delete.SettingMode = false;

                    if (dataGridViewExtended.DataSource == _bindingSourceStockRoomTreeViewVal)
                        dataGridViewExtended.DataSource = _bindingSourceStockRoomVal;
                }
            }
        }

        #endregion"Properties"

        #region"On_ScannedData"

        string returnToTabPage = "tabPage_Pictures";
        public void OnBarcodeScanned_EventHandler(object? sender, RawInputEventArg e)
        {
            if (e == null)
                return;

            // If the application is not visible, do not processes the barcode event. 
            if (!Visible)
                return;

            #region"EmployeeID Scanned"

            if (e.BarcodeData.Length == 6)
            {
                return;
            }

            #endregion"EmployeeID Scanned"

            #region"Set Location field"

            if (_employeesService.CurrentEmployeeLogIn.IsManager && dataGridViewExtendedBase.IsColumnVisible("Location"))
            {
                if (_currentColumnActive != null && _currentColumnActive.ColumnName.Contains("Location"))
                {
           //         CurrentRowViewActive.Row[_currentColumnActive.ColumnName] = e.BarcodeData;
                    TabControl_Inventory.SelectTab("tabPage_Location");
                    return;
                }
            }

            #endregion"Set Location field"

            #region"Scanned Location label"

            if (e.BarcodeData.Contains("LOCATION-7869"))
            {
                if (dataGridViewExtendedBase.CustomFilter != null &&
                    dataGridViewExtendedBase.CustomFilter.Contains("Location LIKE '" + e.BarcodeData + "'"))
                {
                    TabControl_Inventory.SelectTab(returnToTabPage);
                    //   if (_currentFocusedNodeproperties != null)
                    //       dataGridViewExtendedBase.CustomFilter = _currentFocusedNodeproperties.StringFilter;
                    //   else
                    dataGridViewExtendedBase.CustomFilter = "";
                    return;
                }

                dataGridViewExtendedBase.CustomFilter = "Location LIKE '" + e.BarcodeData + "'";

                if (TabControl_Inventory.SelectedTab.Name.Contains("tabPage_Location"))
                {
                    return;
                }
                else
                {
                    returnToTabPage = TabControl_Inventory.SelectedTab.Name;
                    TabControl_Inventory.SelectTab("tabPage_Location");
                    return;
                }
            }

            #endregion"Scanned Location label"

            #region"Scanned PartNumber label"

            if (e.BarcodeData.Length == 15)
            {
                string partNumber = e.BarcodeData.Substring(0, 7);
                partNumber = partNumber.Insert(3, "-");

                if (dataGridViewExtendedBase.CustomFilter != null &&
                    dataGridViewExtendedBase.CustomFilter.Contains("PartNumber LIKE '*" + partNumber + "*'"))
                {
                    TabControl_Inventory.SelectTab(returnToTabPage);
                    //   if (_currentFocusedNodeproperties != null)
                    //       dataGridViewExtendedBase.CustomFilter = _currentFocusedNodeproperties.StringFilter;
                    //   else
                    dataGridViewExtendedBase.CustomFilter = "";
                    return;
                }

                dataGridViewExtendedBase.CustomFilter = "PartNumber LIKE '*" + partNumber + "*'";
                if (TabControl_Inventory.SelectedTab.Name.Contains("tabPage_Picturess"))
                {
                    return;
                }
                else
                {
                    returnToTabPage = TabControl_Inventory.SelectedTab.Name;
                    TabControl_Inventory.SelectTabPage("tabPage_Picturess");
                    return;
                }
            }
            #endregion"Scanned PartNumber label"

            var filterDataGridView = "PartNumber LIKE '" + e.BarcodeData + "'";

            if (dataGridViewExtended.CustomFilter != null && dataGridViewExtended.CustomFilter.Contains(filterDataGridView))
                dataGridViewExtended.CustomFilter = "";
            else
                dataGridViewExtended.CustomFilter = filterDataGridView;
        }

        #endregion

        #region"CurrentUserBroadcast"

        private ITableEmployeeService _employeesService;
        EmployeeInformation _currentEmployeeLogIn;

        /// <summary>
        /// The user setting name, we save userSettingName = DataTreeViewName + "_" + TableName;
        /// It is update at public object DataSource{ set }
        /// We saved the datasource name because in some cases,
        /// the same dataTreeView manipulates different dataSources.
        /// </summary>                  //DGVExt_StockRoom_Table_StockRoom -> from the setting itselft
        private string userSettingName = "DGVExt_StockRoom_Table_StockRoom";

        // Properties and fields used in LogIn employees.
        string _employeeName = "Not user login.";
        string _employeeLastName = "";
        AccessLevel _employeeAccessLevel = AccessLevel.User;
        EditMode _employeeEditMode = EditMode.View;
        EnableSetting EmployeeEnableTreeViewSetting = EnableSetting.False;

        /// <summary>
        /// We pass the EmployeeService to this control, to be able to process the current employee information
        /// at initialization time, the control need to know the current employee information to apply the correct
        /// setting for this employee, and also to be able to update the control setting when the employee log in change.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ITableEmployeeService EmployeesService
        {
            set
            {
                if (value == null)
                    return;

                _employeesService = value;
                CurrentEmployeeLogIn = _employeesService.CurrentEmployeeLogIn;
                _employeesService.CurrentEmployeeLogInChanged += EmployeesService_CurrentEmployeeLogInChanged;
            }
        }

        void EmployeesService_CurrentEmployeeLogInChanged(object? sender, EmployeeInformation e)
        {
            CurrentEmployeeLogIn = e;
        }

        /// <summary>
        /// Process current employee information.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private EmployeeInformation CurrentEmployeeLogIn
        {
            get
            {
                return _currentEmployeeLogIn;
            }
            set
            {
                if (value == null)
                    return;

                _currentEmployeeLogIn = value;

                _employeeName = _currentEmployeeLogIn.Name;
                _employeeLastName = _currentEmployeeLogIn.LastName;
                _employeeEditMode = _currentEmployeeLogIn.EmployeeEditMode;
                _employeeAccessLevel = _currentEmployeeLogIn.EmployeeAccessLevel;
                EmployeeEnableTreeViewSetting = _currentEmployeeLogIn.EmployeeEnableTreeViewSetting;

                UserSetting userSetting = _currentEmployeeLogIn.UserSettingEntity(userSettingName);

                internalResizeEvent = true;
                splitContainerVertical.SplitterDistance = userSetting.SplitterVertical;
                splitContainerHorizontal.SplitterDistance = userSetting.SplitterHorizontal;
            }
        }

        #endregion"CurrentUserBroadcast"

        /// <summary>
        /// This flag is used to avoid the execution of SplitterMoved event during the initialization of the form, because
        /// at initialization we set the SplitterDistance according to the user setting, and we do not want to save the user
        /// setting at this moment, because it is not a user action, it is just the application of the user setting.
        /// </summary>
        bool internalResizeEvent = false;

        readonly DataTable _dataTableStockRoom;
        readonly DataTable _dataTableTreeListView;

        // ⚠️ To catch missing registrations early, you can also mark the parameterless
        // constructor with[Obsolete] so it shows a compiler warning whenever it's accidentally used:
        [Browsable(false)]
        [Obsolete("Use DI constructor. Missing service registration may be causing this call.")]
        public StockRoom_Inventory()
        {
            InitializeComponent();
        }

        public StockRoom_Inventory(ITableEmployeeService employeesService,
                                    IStockRoomService stockRoomService,
                                    ITableStockRoomTreeViewService tableStockRoomTreeViewService,
                                    IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.Dpi;
            DockAreas = WinFormsUI.Docking.DockAreas.Document | WinFormsUI.Docking.DockAreas.Float;

            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            EmployeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService));
       //   _employeesService.CurrentEmployeeLogInChanged += (s, e) =>  { };
            _stockRoomService = stockRoomService ?? throw new ArgumentNullException(nameof(stockRoomService));
            _tableStockRoomTreeViewService = tableStockRoomTreeViewService ?? throw new ArgumentNullException(nameof(tableStockRoomTreeViewService));
            
            Name = "StockRoom_Inventory";
            dataGridViewExtended.Name = "DGVExt_StockRoom";
            // We need pass employeeService, at initialization we call currentEmployeeLogIn
            dataGridViewExtended.EmployeesService = _employeesService;
            dataTreeViewToAdd_Cancel_Delete.EmployeesService = _employeesService;

            // ✅ Pass unitOfWork to the EXISTING designer instance, don't replace it
            dataTreeViewToAdd_Cancel_Delete.SetUnitOfWork(_unitOfWork);

            InitializeBlazorWebView();            
        }

        void InitializeBlazorWebView()
        {
            #region"BlazorWebView"

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWindowsFormsBlazorWebView();
            serviceCollection.AddSingleton<AppState>(_appState);
            serviceCollection.AddSingleton<AppService>(_appService);
            serviceCollection.AddSingleton<WeatherForecastService>();
            serviceCollection.AddLogging(builder =>             // Add logging services and configure them
            {
                builder.SetMinimumLevel(LogLevel.Information);  // Set a minimum log level
                builder.AddConsole();                           // Add the Console logging provider
                builder.AddDebug();                             // Add the Debug logging provider
            });

            // Build the service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Get an ILogger instance
            var logger = serviceProvider.GetRequiredService<ILogger<StockRoom_Inventory>>();
            // Log a message
            logger.LogInformation("Application started.");

            blazorWebView1.HostPage = "wwwroot\\index.html";
            // blazorWebView1.HostPage = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "wwwroot\\index.html");
            blazorWebView1.Services = serviceProvider;
            blazorWebView1.RootComponents.Add<Counter>("#app");

            blazorWebView2.HostPage = "wwwroot\\index.html";
            blazorWebView2.Services = serviceProvider;
            blazorWebView2.RootComponents.Add<App>("#app");

            AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
            {
#if DEBUG
                MessageBox.Show(text: error.ExceptionObject.ToString(), caption: "Error");
#else
                        MessageBox.Show(text: "An error has occurred.", caption: "Error");
#endif
            };

            #endregion"BlazorWebView"                
        }

        /// <summary>
        /// Since we are using EF Core, we will load data in the LoadDataEF() method.
        /// </summary>
        async void LoadDataEF()
        {
            // ✅ Load data using EF Core
            await LoadTimeLineDataAsync();
        }

        /// <summary>
        /// Load TimeLine data using EF Core service
        /// </summary>
        async Task LoadTimeLineDataAsync()
        {
            try
            {
                MessageDebugPosition = "Starting LoadTimeLineDataAsync()";
                
                // ✅ Load DataTable from database → DataView → BindingSource (supports .Filter)
                var dataTable = await _stockRoomService.LoadStockRoomsDataTableAsync();
                var dataView = new DataView(dataTable);

                _bindingSourceStockRoomVal = new BindingSourceValidating<Table_StockRoom>
                {
                    DataSource = dataView,
                    TableName = "Table_StockRoom",
                    Position = 0
                };

                MessageDebugPosition = "Assigning BindingSource to DataGridView";
                dataGridViewExtended.DataSource = _bindingSourceStockRoomVal;


                MessageDebugPosition = "Loading TreeView data";

                // ✅ Load typed list from database → BindingList<Table_Base_TreeView> → BindingSource.
                // A DataView-backed BindingSource exposes DataRowView items through .List, which cannot
                // be cast to Table_Base_TreeView in the BindingSourceTreeView setter (InvalidCastException).
                var treeViewList = await _tableStockRoomTreeViewService.LoadStockRoomsTreeViewAsync();

                // Loading all rows works, but we want to investigate the crash at row 60, so we will load only 60 rows
                // to see if the crash still happens, if it does not happen, we will know that the problem is related
                // to the data in the rows after 60, and we can investigate further.
                //_bindingSourceStockRoomTreeViewVal = await _tableStockRoomTreeViewService.LoadStockRoomsTreeViewAsync(count: 60);

                MessageDebugPosition = "Create BindingSource for TreeView";
                _bindingSourceStockRoomTreeViewVal = new BindingSourceValidating<Table_Base_TreeView>
                {
                    DataSource = new BindingList<Table_Base_TreeView>(treeViewList.Cast<Table_Base_TreeView>().ToList()),
                    TableName = "Table_StockRoom_TreeView",
                    Position = 0
                };

               // DiagnoseRow60();
                //DiagnoseRow60NullInIntegerColumns();

                MessageDebugPosition = "Assign BindingSource to TreeView";
                dataTreeViewToAdd_Cancel_Delete.BindingSourceTreeView = _bindingSourceStockRoomTreeViewVal;

                StatusBarMessage(new StatusBarMessage_EventArgs($"Loaded {_bindingSourceStockRoomVal.Count} StockRoom records"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading StockRoom data: {ex.Message}",
                    "Data Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                
            }
        }

        string nodeID = string.Empty;
        bool HasCircularReference(IEnumerable<Table_Base_TreeView> nodes)
        {
            var lookup = nodes.ToDictionary(n => n.ID);

            foreach (var node in nodes)
            {
                var visited = new HashSet<int>();
                int current = node.Parent_ID ?? 0;

                while (current != 0)
                {
                    if (!lookup.TryGetValue(current, out var parent)) break;
                    if (!visited.Add(current))
                    {
                        nodeID = node.ID.ToString();
                        return true; // ← circular!
                    }
                    current = parent.Parent_ID ?? 0;
                }
            }
            return false;
        }

        /// <summary>
        /// This method is a diagnostic tool to compare the rows around the problematic row 60, to see if there are any differences
        /// in the data that could explain the crash. It retrieves rows 57 to 60 (inclusive) and compares their columns side by side,
        /// highlighting any differences and null values. The output is saved to a text file and opened in Notepad for easy analysis.
        /// Use raw ADO.NET directly against the DbConnection — this completely bypasses the EF Core materializer, so it reads every
        /// column's raw value (including NULLs that would crash EF) without risk.
        /// </summary>
        private async void DiagnoseRow60()
        {
            var rows = await _unitOfWork.TableStockRoomTreeViewRepository
                                        .GetRawRowsAsync(offsetZeroBased: 57, rowCount: 4);

            const int colW = 28;
            var sep = new string('─', 72);
            var sb = new System.Text.StringBuilder();

            // ── SECTION 1: side-by-side diff (most useful) ───────────────────────
            sb.AppendLine("══════════════════════════════════════════════════════════════════════");
            sb.AppendLine(" SECTION 1 — COLUMNS THAT DIFFER  (consecutive rows)");
            sb.AppendLine("══════════════════════════════════════════════════════════════════════");

            for (int i = 0; i < rows.Count - 1; i++)
            {
                var r1 = rows[i];
                var r2 = rows[i + 1];
                var diffs = r1.Keys
                    .Where(k => k != "__Row#__" && !Equals(r1.GetValueOrDefault(k),
                                                            r2.GetValueOrDefault(k)))
                    .ToList();

                sb.AppendLine($"\n  Row {r1["__Row#__"],3} → Row {r2["__Row#__"],3}" +
                              (diffs.Count == 0 ? "   (identical)" : $"   {diffs.Count} column(s) differ"));

                if (diffs.Count > 0)
                {
                    sb.AppendLine(sep);
                    sb.AppendLine($"  {"Column",-colW}  {"Row " + r1["__Row#__"],-20}  {"Row " + r2["__Row#__"]}");
                    sb.AppendLine(sep);
                    foreach (var key in diffs)
                    {
                        string v1 = r1.GetValueOrDefault(key) is null ? "⚠ NULL" : $"{r1[key]}";
                        string v2 = r2.GetValueOrDefault(key) is null ? "⚠ NULL" : $"{r2[key]}";
                        sb.AppendLine($"  {key,-colW}  {v1,-20}  {v2}");
                    }
                }
            }

            // ── SECTION 2: full side-by-side grid (all columns, all 4 rows) ──────
            sb.AppendLine();
            sb.AppendLine("══════════════════════════════════════════════════════════════════════");
            sb.AppendLine(" SECTION 2 — FULL COLUMN DUMP  (⚠ = NULL in at least one row)");
            sb.AppendLine("══════════════════════════════════════════════════════════════════════");

            var cols = rows[0].Keys.Where(k => k != "__Row#__").ToList();

            // header
            sb.Append($"\n  {"Column",-colW}");
            foreach (var row in rows) sb.Append($"  {"Row " + row["__Row#__"],-15}");
            sb.AppendLine();
            sb.AppendLine(sep);

            // one line per column
            foreach (var col in cols)
            {
                bool nullExists = rows.Any(r => r.GetValueOrDefault(col) is null);
                sb.Append($"  {col,-colW}");
                foreach (var row in rows)
                {
                    string val = row.GetValueOrDefault(col) is null ? "⚠ NULL" : $"{row[col]}";
                    sb.Append($"  {val,-15}");
                }
                if (nullExists) sb.Append("  ◄ NULL");
                sb.AppendLine();
            }

            // ── write to %TEMP% and open in Notepad ──────────────────────────────
            string path = System.IO.Path.Combine(
                System.IO.Path.GetTempPath(),
                $"TreeView_Row60_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

            await System.IO.File.WriteAllTextAsync(path, sb.ToString());
            System.Diagnostics.Process.Start("notepad.exe", path);        
        }

        /// <summary>
        /// The right approach is a single purpose query — instead of comparing rows, ask the database directly:
        /// "which rows have NULL in any integer column?" That's the only question that matters.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DiagnoseRow60NullInIntegerColumns()
        {
            var hits = await _unitOfWork.TableStockRoomTreeViewRepository
                                        .FindIntegerNullsAsync();

            var sb = new System.Text.StringBuilder();

            if (hits.Count == 0)
            {
                sb.AppendLine("✅ No NULL values found in Parent_ID, ItemCount, or ItemOpen.");
                sb.AppendLine("   The crash may have a different cause.");
            }
            else
            {
                sb.AppendLine($"⚠  Found {hits.Count} row(s) with NULL in an integer column:\n");
                sb.AppendLine($"  {"Pos",5}  {"Index",8}  {"ID",8}  NULL columns");
                sb.AppendLine(new string('─', 55));
                foreach (var (pos, idx, id, cols) in hits)
                    sb.AppendLine($"  {pos,5}  {idx,8}  {id,8}  {string.Join(", ", cols)}");

                sb.AppendLine();
                sb.AppendLine("'Pos' = row number when the whole table is sorted by Index.");
                sb.AppendLine("Row 60 crashing means look for Pos = 60 in this list.");
            }

            // ── write to %TEMP% and open in Notepad ──────────────────────────────
            string path = System.IO.Path.Combine(
                System.IO.Path.GetTempPath(),
                $"IntNulls_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                           
            await System.IO.File.WriteAllTextAsync(path, sb.ToString());
            System.Diagnostics.Process.Start("notepad.exe", path);
        }

        #region "StockRoomInventory Load, Shown, FormClosing"

        void StockRoomInventoryLoad(object? sender, EventArgs e)
        {
            MessageDebugPosition = "Starting Try/Catch procedure.";
            try
            {
                MessageDebugPosition = "InitializeProperties()";
                InitializeProperties();

                MessageDebugPosition = "InitializeDataTreeView()";
                InitializeDataTreeView();

                MessageDebugPosition = "Initialize_DataGridView()";
                Initialize_DataGridView();

                MessageDebugPosition = "InitializeSaveUserSettingTimer()";
                InitializeSaveUserSettingTimer(); // Initialize before wiring SplitterMoved in InitTabControlExtend.

                MessageDebugPosition = "InitTabControlExtend()";
                InitTabControlExtend();

                MessageDebugPosition = "InitializeThumbsViewerPicture()";
                InitializeThumbsViewerPicture();

                MessageDebugPosition = "InitializeThumbsViewerLocation()";
                InitializeThumbsViewerLocation();

                MessageDebugPosition = "InitializeTabPage_UpDateModifCompValue()";
                InitializeTabPage_UpDateModifCompValue();

                MessageDebugPosition = "Initialize_NodeSetting";
                //InitializeNodeSettingTabPage();
                
                MessageDebugPosition = "Initialize_OK";
                // If we are here, the initialization is OK, we can load data aster the form is shown,
                // to avoid freeze of the form during loading and loose of events related to data processing,
                // like filtering with the treeView.               
                LoadDataEF();
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Found an error at " + MessageDebugPosition + @" " + error.Message,
                                          @"StockRoom Inventory load has generated an error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        System.Windows.Forms.Timer _initialDelay;
        async void StockRoomInventoryShown(object? sender, EventArgs e)
        {
            try
            {
                MessageDebugPosition = "InitializeTab_AddNewItem";
                InitializeTab_AddNewItem();
                
                splitContainerHorizontal.SplitterDistance = (int)(Height * 0.65);                
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message,
                                          @"StockRoom Inventory show has generated an error at " + MessageDebugPosition,
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
               
        void InitializeProperties()
        {
            try
            {
                RenameDistFileName = Settings.Default.RenameDistFileName;
                DeleteOriginalFile = Settings.Default.DeleteOriginalFile;

                editorTinyMce = @"\Resources\HTML pages\tinymce\examples\full.html";
                editorPageLocation = Settings.Default.DataBaseAddress;
                editorPageLocation += editorTinyMce;

            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message,
                                          @"InitializeProperties() has generated an error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion "StockRoomInventory Load, Shown, FormClosing"
        
        #region"DataTreeListView"

        void InitializeDataTreeView()
        {
            dataTreeViewToAdd_Cancel_Delete.Load += DataTreeViewToAdd_Cancel_Delete_Load;
            dataTreeViewToAdd_Cancel_Delete.Save_Requested += DataTreeViewToAdd_Cancel_Delete_Save_Requested;
            dataTreeViewToAdd_Cancel_Delete.Switch_DataTable += DataTreeViewToAdd_Cancel_Delete_Switch_DataTable;            
            dataTreeViewToAdd_Cancel_Delete.SelectedIndexChanged += DataTreeViewToAdd_Cancel_Delete_SelectedIndexChangedAsync;
            dataTreeViewToAdd_Cancel_Delete.StatusBarMessage += DataTreeViewToAdd_Cancel_Delete_StatusBarMessage;
        }

        void DataTreeViewToAdd_Cancel_Delete_StatusBarMessage(object? sender, StatusBarMessage_EventArgs e)
        {
            StatusBarMessage(e);
        }

        void DataTreeViewToAdd_Cancel_Delete_Load(object? sender, EventArgs e)
        {
            
        }

        async void DataTreeViewToAdd_Cancel_Delete_SelectedIndexChangedAsync(object? sender, TreeViewSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (e.CurrentNode == null)
                    return;

                if (dataGridViewExtended.DataSource == _bindingSourceStockRoomVal)
                {
                    // ✅ Filter now works because DataSource is a DataView
                    dataGridViewExtended.CustomFilter = e.CurrentNode.String_Filter;
                }

                #region"tabPage_DataTreeViewSetting"

                if (_nodeSettingIsDone & TabControl_Inventory.SelectedTab.Name == "tabPage_TreeViewSetting")
                {
                    _nodeSetting.CurrentNode = e.CurrentNode;
                }

                #endregion"tabPage_DataTreeViewSetting"

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filter error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DataTreeViewToAdd_Cancel_Delete_Save_Requested(object? sender, Save_Requested_EventArgs e)
        {
            e.Message = "DataTreeViewToAdd_Cancel_Delete_Save_Requested, BaseTemple.On_Save_Requested(e).";
            On_Save_Requested(e);
        }

        void DataTreeViewToAdd_Cancel_Delete_Switch_DataTable(object? sender, Switch_DataTable_EventArgs e)
        {
            if(dataGridViewExtended.DataSource == _bindingSourceStockRoomVal)
                dataGridViewExtended.DataSource = _bindingSourceStockRoomTreeViewVal;
            else
                dataGridViewExtended.DataSource = _bindingSourceStockRoomVal;

            SettingMode = true;            
        }

        #endregion"DataTreeListView"

        #region"DataGridViewExtended"

        /// <summary>
        /// If DataGridView.Columns collection do not contains PartNumber column.
        /// </summary>
        bool FaultColumnPartNumber;

        void Initialize_DataGridView()
        {
            InitializeDataGridViewBase(dataGridViewExtended);

            dataGridViewExtended.SuspendLayout();            

            dataGridViewExtended.CellBegingEditEvent    += DataGridViewExtendedInventoryCellBeggingEditEvent;
            dataGridViewExtended.CellEndEditEvent       += DataGridViewExtendedInventoryCellEndEditEvent;
            dataGridViewExtended.CellClickEvent         += DataGridViewExtended_StockRoom_CellClick_Event;
            dataGridViewExtended.CellDoubleClickEvent   += DataGridViewExtended_StockRoom_CellDoubleClick_Event;

            dataGridViewExtended.CellMouseEnter         += DataGridViewExtended_CellMouseEnter;

            dataGridViewExtended.RowsRemoved            += DataGridViewExtendedInventoryRowsRemoved;
            dataGridViewExtended.RowsMouseEnter         += DataGridViewExtended_RowsMouseEnter;
            dataGridViewExtended.UserDeletingRow        += DataGridViewExtended_UserDeletingRow;
            dataGridViewExtended.UserDeletedRow         += DataGridViewExtendedInventoryUserDeletedRow;
            dataGridViewExtended.CurrentRowActivesEvent += DataGridViewExtendedInventoryCurrentRowActive;
            dataGridViewExtended.SaveRequested          += DataGridViewExtended_SaveRequested;

            dataGridViewExtended.FindRemplace           += DataGridViewExtended_Inventory_Find_Replace;

            dataGridViewExtended.RefreshRequested       += DataGridViewExtendedInventoryRefreshRequested;

            dataGridViewExtended.DataGridViewMouseEnterEvent += DataGridViewExtendedInventoryMouseEnterEvent;
            dataGridViewExtended.DataGridViewSort       += DataGridViewExtendedInventoryDataGridViewSort;
            dataGridViewExtended.BindingNavigatorAddNewItemEvent += DataGridViewExtended_AddNewItemEvent;

            dataGridViewExtended.AddNoteEvent           += DataGridViewExtended_AddNoteEvent;
            dataGridViewExtended.EditNoteEvent          += DataGridViewExtended_EditNoteEvent;

            dataGridViewExtended.LogFileMessage         += DataGridViewExtendedInventoryLogFileMessage;

            dataGridViewExtended.ContextMenuStripItemClicked += DataGridViewExtended_ContextMenuStripItemClicked;
            dataGridViewExtended.ContextMenuStripPrintCompLabel += DataGridViewExtended_PrintCompLabel;
            
            dataGridViewExtended.ResumeLayout();
        }

        async void DataGridViewExtended_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow? ert = e.Row;
            if(ert == null)
                return;

            if (dataGridViewExtended.DataSource == _bindingSourceStockRoomTreeViewVal)
            {
                Table_StockRoom_TreeView? item = (Table_StockRoom_TreeView)ert.DataBoundItem;
                if(item == null)
                    return;

                MessageDebugPosition = $"Attempting to get childrens of '{item.Text_Name}'";
                IEnumerable<Table_StockRoom_TreeView> children = await _unitOfWork.TableStockRoomTreeViewRepository.GetChildrenAsync(item.ID);

                if (children.Any())
                {
                    DialogResult dialogResult =
                    MessageBox.Show("Do you want to delete all the children as well?", "Cannot Delete Node with " + children.Count() + " Childrens ",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No || dialogResult == DialogResult.Cancel)
                        return;

                    MessageDebugPosition = $"Deleting {children.Count()} children of '{item.Text_Name}'";
                    if (dialogResult == DialogResult.Yes)
                    {
                        _bindingSourceStockRoomTreeViewVal.SuspendBinding();

                        foreach (Table_StockRoom_TreeView itemEF in children)
                        {
                            // ✅ Use DeleteAsync — it fetches the tracked entity by PK (Index)
                            // then removes it. Avoids attaching detached entities with Index = 0.
                            await _unitOfWork.TableStockRoomTreeViewRepository.DeleteAsync(itemEF.Index);

                            RemoveFromBindingSourceByIndex(itemEF.Index);
                        }

                        _bindingSourceStockRoomTreeViewVal.ResumeBinding();
                    }
                }

                await _unitOfWork.TableStockRoomTreeViewRepository.DeleteAsync(item.Index, CancellationToken.None);
                RemoveFromBindingSourceByIndex(item.Index);
            }

            if (dataGridViewExtended.DataSource == _bindingSourceStockRoomVal)
            {
                Table_StockRoom? rowEntity = (Table_StockRoom)ert.DataBoundItem;
                if(rowEntity == null)
                    return;

                await _unitOfWork.TableStockRoomRepository.DeleteAsync(rowEntity.PartNumber, CancellationToken.None);
                _bindingSourceStockRoomVal.RemoveCurrent();
            }
        }

        /// <summary>
        /// Removes an itemEFtableTreeView from the BindingSource by matching its ID property.
        /// 
        /// BindingSource.Remove()    → fails: uses reference equality, AsNoTracking = different instances
        /// BindingSource.RemoveAt(i) → fails: sorted-view index ≠ underlying-list index
        /// BindingSource.DataSource as BindingList → fails: DataSource may be BindingSourceValidating<T>
        ///
        /// ✅ BindingSource.List always returns the actual managed IList regardless of nesting or sorting.
        ///    Index operations on it are always valid.
        /// </summary>
        void RemoveFromBindingSourceByIndex(int index)
        {
            try
            {
                // ✅ .List resolves any nested BindingSource and returns the real underlying IList.
                // Iterating and removing from it directly is safe regardless of sort/filter state.
                IList list = _bindingSourceStockRoomTreeViewVal.List;
                MessageDebugPosition = $"Removing itemEFtableTreeView with index {index} from BindingSource list with {list.Count} items";
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i] is Table_Base_TreeView node && node.Index == index)
                    {
                        MessageDebugPosition = $"Found itemEFtableTreeView with index {index} at list index {i}, removing it from BindingSource";
                        list.RemoveAt(i);
                        return;
                    }
                }

                // Item not found — already removed or index mismatch
                MessageDebugPosition = $"RemoveFromBindingSourceByIndex: index {index} not found in list.";
            }
            catch (Exception error)
            {
                MessageDebugPosition = $"Error removing itemEFtableTreeView from BindingSource: {error.Message}";
            }
        }

        async void DataGridViewExtended_SaveRequested(object? sender, Save_Requested_EventArgs e)
        {
            if (dataGridViewExtended.DataSource == _bindingSourceStockRoomTreeViewVal)
            {
                if (e.DirtyDataGridViewIndexes.Count == 0)
                {
                    dataGridViewExtended.SavedRequestedDone();
                    return;
                }

                // Force-commit any cell still in edit mode before reading values.
                _bindingSourceStockRoomTreeViewVal.EndEdit();

                // Collect only the rows that were actually changed.
                var dirtyItems = _bindingSourceStockRoomTreeViewVal
                    .GetAllItems()
                    .OfType<Table_StockRoom_TreeView>()
                    .Where(item => e.DirtyDataGridViewIndexes.Contains(item.Index))
                    .ToList();

                try
                {
                    foreach (var item in dirtyItems)
                        await _unitOfWork.TableStockRoomTreeViewRepository.UpdateAsync(item, CancellationToken.None);

                    dataGridViewExtended.SavedRequestedDone();
                    _bindingSourceStockRoomTreeViewVal.ResetDirtyFlag();
                }
                catch (Exception ex)
                {
                    MessageDebugPosition = $"SaveRequested (TreeView) error: {ex.Message}";
                    // dataGridViewExtended.DirtyDataGridViewIndexes intentionally NOT cleared — retry is still possible.
                    throw;
                }
            }

            if (dataGridViewExtended.DataSource == _bindingSourceStockRoomVal)
            {
                if (e.DirtyDataGridViewIndexes.Count == 0)
                {
                    dataGridViewExtended.SavedRequestedDone();
                    return;
                }

                // Force-commit any cell still in edit mode before reading values.
                _bindingSourceStockRoomVal.EndEdit();

                // Collect only the rows that were actually changed.
                var dirtyItems = _bindingSourceStockRoomVal
                    .GetAllItems()
                    .OfType<Table_StockRoom>()
                    .Where(item => e.DirtyDataGridViewPartNumbers.Contains(item.PartNumber))
                    .ToList();

                try
                {
                    foreach (var item in dirtyItems)
                        await _unitOfWork.TableStockRoomRepository.UpdateAsync(item, CancellationToken.None);

                    dataGridViewExtended.SavedRequestedDone();
                    _bindingSourceStockRoomVal.ResetDirtyFlag();
                }
                catch (Exception ex)
                {
                    MessageDebugPosition = $"SaveRequested (StockRoom) error: {ex.Message}";
                    // dataGridViewExtended.DirtyDataGridViewPartNumbers intentionally NOT cleared — retry is still possible.
                    throw;
                }
            }
        }

        public System.Collections.IList Rows;
        public IDictionary<object, BindingSourceGroups.GroupRow> GroupsDict;
               

        #region"Add Column method"

        void AddColumn(string headerText, int width, int displayIndex)
        {
            using (var newColumn = new DataGridViewColumn())
            {
                using (DataGridViewCell newcell = new DataGridViewTextBoxCell())
                {
                    newColumn.CellTemplate = newcell;
                    newColumn.HeaderText = headerText;
                    newColumn.ValueType = typeof(int);
                    newColumn.Name = headerText;
                    newColumn.Visible = true;
                    newColumn.Width = width;
                    newColumn.SortMode = DataGridViewColumnSortMode.Automatic;

                    dataGridViewExtended.AddColumn(newColumn, displayIndex);
                }
            }
        }

        void AddColumnCompForProduction()
        {
            int displayedIndex = dataGridViewExtended._dataGridView.DisplayedColumns.Last().DisplayIndex;

            AddColumn("Comp_for_Production", 60, (displayedIndex + 1));
            AddColumn("QtyNeeded", 60, (displayedIndex + 2));
        }

        #endregion"Add Column method"
              
        string editorPageLocation;
        string editorTinyMce;
        //NoteEvent: DataGridViewExtended_EditNoteEvent.
        void DataGridViewExtended_EditNoteEvent(object? sender, EventArgs e)
        {
            TabControl_Inventory.ShowTab(nameof(tabPage_NoteEditor));
            TabControl_Inventory.SelectTab(nameof(tabPage_NoteEditor));
            TabControl_Inventory.SelectedTab.Focus();


            var noteToEdit = CurrentRowStatus.Note;
            //    actionDoWhenBrowserWasLoaded = new Action(() => chromeBrowser.ExecuteScriptAsync("SetContent", noteToEdit));

        }

        /// <summary>
        /// Initialize the timer to update the browser in EditNote process.
        /// </summary>
        int count_ChromeWebBrowserDelayTick;

        //NoteEvent: DataGridViewExtended_AddNoteEvent.
        void DataGridViewExtended_AddNoteEvent(object? sender, EventArgs e)
        {
            TabControl_Inventory.ShowTab(nameof(tabPage_NoteEditor));
            TabControl_Inventory.SelectTab(nameof(tabPage_NoteEditor));
        }

        void DataGridViewExtended_AddNewItemEvent(object? sender, EventArgs e)
        {
            var tempFilter = _bindingSource_StockRoom.Filter;
            _bindingSource_StockRoom.Filter = null;

            /*
            using (var addNewComponent = new StockRoom_AddNewComp(_bindingSource_StockRoom, _currentFocusedNodeproperties, _bindingSource_CodeTreeView, DepartList))
            {
                addNewComponent.SaveTreeView_Requested += AddNewItemSaveTreeViewRequest;
                addNewComponent.StatusBarMessage += OnStatusBarMessage;

                addNewComponent.ShowInTaskbar = false;
                addNewComponent.StartPosition = FormStartPosition.CenterScreen;
                addNewComponent.ShowDialog();                
            }
            */

            dataGridViewExtended.BindingNavigatorAddNewItemEnable = false;
            dataGridViewExtended.BindingNavigatorDeleteItemEnable = false;
            TabControl_Inventory.ShowTab(tabPage_AddNewItem);

            InitializeTab_AddNewItem();
        }

        void AddNewItemSaveTreeViewRequest(object? sender, Save_Requested_EventArgs saveRequestedEventArgs)
        {
            try
            {
                On_AddNewItemSaveTreeViewRequested(new Save_Requested_EventArgs(Utilities.NotificationEvents.DataBaseUpDated));
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message,
                                          @"AddNewItemSaveTreeViewRequested() has generated an error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void DataGridViewExtendedInventoryCellEndEditEvent(object? sender, DataGridViewCellEventArgs e)
        {
            NeedSaveData = true;
            if (CurrentRowViewActive["LastAccessTime"] != null)
            {
                CurrentRowViewActive["LastAccessTime"] = DateTime.Now;
                CurrentRowViewActive["ModifiedBy"] = Table_Employee.FullName;
            }

            #region"OnHand column, update OnHold and Onavailable"
            if (CurrentRowViewActive["OnHand"] != null)
            {
                int OnHold = Utilities.IntParseFast(CurrentRowViewActive["OnHold"].ToString());
                if (OnHold < 0)
                    OnHold = 0;

                int OnHand = Utilities.IntParseFast(CurrentRowViewActive["OnHand"].ToString());

                int OnAvailable = OnHand - OnHold;

                if (OnAvailable < 0)
                    OnAvailable = 0;

                CurrentRowViewActive["OnAvailable"] = OnAvailable;

           //     On_Save_Requested(new Save_Requested_EventArgs(Utilities.NotificationEvents.RowInformationChange, CurrentRowViewActive));
            }
            #endregion"OnHand column, update OnHold and Onavailable"
        }

        async void DataGridViewExtendedInventoryCellBeggingEditEvent(object? sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                MessageDebugPosition = "CellBeggingEditEvent";
                if (_employeesService.CurrentEmployeeLogIn.IsUser)
                {
                    MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                     @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                bool isKeyField = await _unitOfWork.IsKeyColumn(dataGridViewExtended.CurrentCell, typeof(Table_StockRoom_TreeView));
                if (isKeyField)
                {
                    MessageBox.Show("Sorry, this column is a key field, cannot be edited.",
                                    "Key field. Call a system manager to access this column",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                var description = "The information of " + CurrentRowViewActive["PartNumber"]?.ToString() + " is being edited." + Environment.NewLine;

                On_NotificationsToSends(new Notification(
                                                         "Row information is being edited.",                //notification.Text
                                                         "Warning, Row information is being edited.",       //notification.Title
                                                         description,                                        //notification.Description
                                                         (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                         (int)Utilities.NotificationEvents.Warning,             //notifycation.NotifycationEvents
                                                         Settings.Default.DepartmentName,                   //notification.DepartmentName
                                                         DateTime.Now,                                       //notification.DateCreated
                                                         Table_Employee.FullName,                     //notification.Created_by
                                                         "Properties",                                       //notification.Properties
                                                         "Status"                                            //notification.Status
                                                        ));
            }
            catch (Exception ex)
            {
                using (var form = new Form() { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + ex.Message +
                    @", Break code at position " + MessageDebugPosition,
                    @"DataGridViewExtended has generated an error.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        void DataGridViewExtendedInventoryLogFileMessage(object? sender, LogFileMessageEventArgs e)
        {
            On_LogFileMessage(e);
        }

        void DataGridViewExtendedInventoryDataGridViewSort(object? sender, DataGridViewSort_EventArgs e)
        {
            //  if (chart_Components.Visible)
            // Start_EasyProgressBar_GraphicChart();
        }

        void DataGridViewExtended_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        { }

        void DataGridViewExtended_RowsMouseEnter(object? sender, CurrentRowMouseEnterEventArgs e)
        {
            WhoUsesThisProcess(e);
        }

        void DataGridViewExtendedInventoryCurrentRowActive(object? sender, CurrentRowActive_EventArgs e)
        {
            try
            {
                MessageDebugPosition = "DataGridViewExtendedInventoryCurrentRowActive try...";
                if (e.CurrentRowActive.Index == -1)
                {
                    On_ActiveDataSheet(null);
                    thumbViewer_Pictures.PathFromPartNumber = "No_Picture_Found";
                    GetLocationProcess("No_Location_Found");
                    CurrentPartNumber = "";
                    return;
                }

                MessageDebugPosition = "TabControl_Inventory.SelectedTab.Name";
                if (TabControl_Inventory.SelectedTab.Name.Contains("tabPage_NoteEditor"))
                {
                    TabControl_Inventory.SelectTab(nameof(tabPage_Pictures));
                    TabControl_Inventory.HideTab(nameof(tabPage_NoteEditor));
                }

                MessageDebugPosition = "Check if CurrentRowActive.DataBoundItem is Table_StockRoom";
                if (e.CurrentRowActive.DataBoundItem.GetType() == typeof(Table_StockRoom))
                {
                    CurrentRowViewActive = (DataRowView)e.CurrentRowActive.DataBoundItem;
                }

                if (e.CurrentRowActive.DataBoundItem.GetType() == typeof(DataRowView))
                {
                    CurrentRowViewActive = (DataRowView)e.CurrentRowActive.DataBoundItem;
                }

                if (CurrentRowViewActive != null)
                {
                    CurrentRowStatus = new CurrentStatus(CurrentRowViewActive);
                    CurrentPartNumber = CurrentRowViewActive["PartNumber"]?.ToString();
                }

                thumbViewer_Pictures.PathFromPartNumber = CurrentPartNumber;

                MessageDebugPosition = "DataSheetProcess()";
                DataSheetProcess();

                if (CurrentRowViewActive["Location"] != null)
                    GetLocationProcess(CurrentRowViewActive["Location"]?.ToString());
                else
                    GetLocationProcess("NoLocationDef");

                MessageDebugPosition = "FocusTabPage_UpDateModifCompValue().";
                FocusTabPage_UpDateModifCompValue();

            }
            catch (Exception error)
            {
                using var form = new Form() { TopMost = true };
                MessageBox.Show(form, @"Message related to this error is " + error.Message +
                @", Break code at position " + MessageDebugPosition,
                @"DataGridViewExtended has generated an error.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        void DataGridViewExtended_StockRoom_CellClick_Event(object? sender, CellClick_EventArgs e)
        {
          //  _currentColumnActive = CurrentDataColumnActive(e.ColumnIndex);
        }

        void DataGridViewExtended_StockRoom_CellDoubleClick_Event(object? sender, CellDoubleClick_EventArgs e)
        {
            if (_employeesService.CurrentEmployeeLogIn.IsUser)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentRowViewActive == null)
                return;

            #region"DataSheet Input"

            var listFileNames = "";

            if (e.ColumnName.Contains("DataSheet_File"))
            {
                using (var directoryFile = new DirectoryFile())
                {
                    var selectedFileNames = directoryFile.ProcessDataSheetFiles(CurrentRowViewActive["PartNumber"]?.ToString(), false, false);

                    foreach (string strFileName in selectedFileNames)
                    {
                        var diskFileName = Path.GetFileName(strFileName);

                        if (diskFileName == "")
                        {
                            dataGridViewExtended._dataGridView.EndEdit();
                            return;
                        }

                        listFileNames += diskFileName + ";";
                    }

                    CurrentRowViewActive["DataSheet_File"] = listFileNames;
                   
                    dataGridViewExtended._dataGridView.EndEdit();
                    DataSheetProcess();
                    return;
                }
            }

            #endregion"DataSheet Input"

            On_CellDoubleClick_Event(e);
        }

        void DataGridViewExtended_Inventory_Find_Replace(object? sender, DataGridViewExtended.FindRemplaceEventArgs e)
        {

        }

        void DataGridViewExtendedInventoryRefreshRequested(object? sender, Refresh_Requested_EventArgs e)
        {
            if (CurrentRowViewActive == null)
                On_Refresh_Requested(new Refresh_Requested_EventArgs("PartNumber Like 'Is Not Null'"));
            else
            {
                //  if (_currentFocusedNodeproperties == null)
                //      On_Refresh_Requested(new Refresh_Requested_EventArgs("PartNumber Like 'Is Not Null'"));
                //   else
                //       On_Refresh_Requested(new Refresh_Requested_EventArgs(_currentFocusedNodeproperties.StringFilter));
            }
        }

        void DataGridViewExtendedInventoryUserDeletedRow(object? sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells[0].Value == null)
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Error in row information."));
                return;
            }

            if (!e.Row.Cells[0].Value.ToString().Contains("-"))
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Error in row information."));
                return;
            }

            var filePath = Settings.Default.DataBaseAddress + "\\Pictures\\" + e.Row.Cells[0].Value.ToString() + ".JPG";

            if (!File.Exists(filePath))
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("No Picture file was found."));
                return;
            }

            var source = new string[1];
            source[0] = filePath;

            var fo = new ShellFileOperation
            {
                Operation = ShellFileOperation.FileOperations.FO_DELETE,
                OwnerWindow = Handle,
                SourceFiles = source
            };

            if (fo.DoOperation())
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Picture file was found and deleted."));
            else
                MessageBox.Show("Picture file was found, but unable to be deleted.");

            //*****************************************************************************************************************

            var description = "The component " + e.Row.Cells[0].Value.ToString() + " has been deleted.";

            On_NotificationsToSends(new Notification(
                                                     "DataBase has been change.",                            //notification.Text
                                                     "Warning, DataBase change.",                        //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)Utilities.NotificationEvents.RowRemoved,          //notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName + ";",   //notification.String_Filter
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     Table_Employee.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        void DataGridViewExtendedInventoryRowsRemoved(object? sender, DataGridViewRowsRemovedEventArgs e)
        {
            //*****************************************************************************************************************

            var description = "The component " + "" + " has been removed.";

            On_NotificationsToSends(new Notification(
                                                     "DataBase has been change.",                        //notification.Text
                                                     "Warning, DataBase change.",                        //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)Utilities.NotificationEvents.RowRemoved,          //notification.NotificationEvents
                                                     Settings.Default.DepartmentName + ";",              //notification.String_Filter
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     Table_Employee.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        void DataGridViewExtendedInventoryMouseEnterEvent(object? sender, DataGridViewMouseEnterEventArgs e)
        {
            dataGridViewExtended._dataGridView.Focus();

            if (FaultColumnPartNumber)
                return;

            if (e.CurrentRowActive == null)
                return;

            if (e.CurrentRowActive.Index == -1)
                return;

            if (!dataGridViewExtended.ColumnsCollection.Contains("PartNumber"))
                return;

            if (e.CurrentRowActive.Cells["PartNumber"].Value == null)
                return;

            CurrentRowViewActive = (DataRowView)e.CurrentRowActive.DataBoundItem;
            CurrentRowStatus = new CurrentStatus(CurrentRowViewActive);
            CurrentPartNumber = CurrentRowViewActive["PartNumber"]?.ToString();

            Update_Description(CurrentRowViewActive);
            thumbViewer_Pictures.PathFromPartNumber = CurrentPartNumber;
        }

        void DataGridViewExtended_ContextMenuStripItemClicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void DataGridViewExtended_PrintCompLabel(object? sender, EventArgs e)
        {
            string partNumber = CurrentRowViewActive["PartNumber"]?.ToString();
            string description = CurrentRowViewActive["Description"]?.ToString();

            Zebra_Prints_CompPartNumbers printCompLabel = new Zebra_Prints_CompPartNumbers(partNumber, description, 1);
            printCompLabel.ShowDialog();
        }

        void DataSheetProcess()
        {
            MessageDebugPosition = "DataSheetProcess()";
            string dataSheetInfo = CurrentRowViewActive["DataSheet_File"]?.ToString();

            if (dataSheetInfo == null || string.IsNullOrEmpty(dataSheetInfo) || string.IsNullOrWhiteSpace(dataSheetInfo))
                dataSheetInfo = "";

            MessageDebugPosition = "DataSheetProcess() -> DocumentationBehavior";
            On_ActiveDataSheet(new ActiveDataSheet_EventArgs(CurrentPartNumber, Settings.Default.DataBaseAddress + "\\DataSheets\\", dataSheetInfo));
        }

        void WhoUsesThisProcess(CurrentRowMouseEnterEventArgs e)
        {
            if (dataGridViewExtended.IsCurrentCellInEditMode)
                return;

            if (!dataGridViewExtended.ColumnsCollection.Contains("Who_uses_this"))
                return;

            if (e.CurrentRowActive.Cells["Who_uses_this"].Value == null)
                return;

            string whoUsesThis = e.CurrentRowActive.Cells["Who_uses_this"].Value?.ToString();

            string tip = Utilities.DescriptionExpand(whoUsesThis, Font, CreateGraphics());

            if (tip != null && tip.Contains("Error Information"))
            {
                e.CurrentRowMouseEnterStatus.Select(CurrentStatusReference.ErrorSelectedColor);

                if (e.CurrentDataRowviewMouseEnter != null)
                {
                    e.CurrentDataRowviewMouseEnter.Row.RowError = @"Column Who_uses_this have a error information." + Environment.NewLine + tip;
                    e.CurrentDataRowviewMouseEnter.EndEdit();
                }
            }
        }

        void Update_Description(DataRowView currentRowView)
        {
            if (currentRowView == null)
                return;

            if (currentRowView["PartNumber"] == null)
                return;

            if (_bindingSource_table_StockroomTreeView.Count == 0)
                return;

            #region"Description Short"

            string description_short;
            description_short = "<font color='Blue'><b>" + currentRowView["PartNumber"]?.ToString() + "</b></font>    ->";

            if (currentRowView["Description"]?.ToString() == "")
                description_short += "  This component has not any Description.";
            else
            {
                string tempDescription = currentRowView["Description"]?.ToString();
                if (tempDescription.Contains("&"))
                    tempDescription = tempDescription.Replace("&", "&amp;");

                description_short += "<i>" + tempDescription + "</i>";
            }

            #endregion"Description Short"

            #region"Description Expand"

            if (currentRowView["OnAvailable"] == null)
                currentRowView["OnAvailable"] = 0;

            string description_expand = Utilities.DescriptionExpand(currentRowView["Who_uses_this"]?.ToString(), Font, CreateGraphics());

            #endregion"Description Expand"

        }

        #endregion"DataGridViewExtended"

        #region"TabControlExtende"

        Plexiglass ShowPlexiglassRectangle;
        void InitTabControlExtend()
        {
            splitContainerHorizontal.SplitterWidth = 3;
            splitContainerVertical.SplitterWidth = 3;
            splitContainerHorizontal.MouseDown += SplitContainerHorizontal_MouseDown;
            splitContainerVertical.MouseDown += SplitContainerVertical_MouseDown;
            splitContainerHorizontal.SplitterMoved += SplitContainerHorizontal_SplitterMoved;
            splitContainerVertical.SplitterMoved += SplitContainerVertical_SplitterMoved;

            TabControl_Inventory.Alignment = TabAlignment.Bottom;

            // TabControl_Inventory.HideTab("tabPage_TreeViewSetting");

            TabControl_Inventory.MouseDownResizeGripEvent += TabControl_Inventory_MouseDownResizeGripEvent;
            TabControl_Inventory.MouseUpResizeGripEvent += TabControl_Inventory_MouseUpResizeGripEventAsync;
            TabControl_Inventory.ResizeGripEvent += TabControl_Inventory_ResizeGripEvent;
            TabControl_Inventory.SelectedIndexChanged += TabControl_Inventory_SelectedIndexChanged;

            //  TabControl_Inventory.HideTab(tabPage_NoteEditor);
            //  TabControl_Inventory.HideTab(tabPage_TreeViewSetting);
            TabControl_Inventory.HideTab(tabPage_AddNewItem);
            TabControl_Inventory.ShowTab(tabPage_Pictures);

            /// Default tabPage_xx selected. Hide panel2 of splitContainer_DataTreeView
            /// where is the dataTreeViewToAdd_Cancel_Delete control.
          //  splitContainer_DataTreeView.Panel2Collapsed = true;
        }

        void SplitContainerVertical_MouseDown(object? sender, MouseEventArgs e)
        {
            internalResizeEvent = false;
        }

        void SplitContainerHorizontal_MouseDown(object? sender, MouseEventArgs e)
        {
            internalResizeEvent = false;
        }

        void SplitContainerVertical_SplitterMoved(object? sender, SplitterEventArgs e)
        {
            if(internalResizeEvent)
                return;

            SaveUserSetting();
        }

        void SplitContainerHorizontal_SplitterMoved(object? sender, SplitterEventArgs e)
        {
            if (internalResizeEvent)
                return;

            SaveUserSetting();
        }

        void TabControl_Inventory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (TabControl_Inventory.SelectedTab.Name == "tabPage_TreeViewSetting")
            {
                InitializeNodeSettingTabPage();
                SettingMode = true;
                return;
            }
            else
            {
                if (SettingMode)
                    SettingMode = false;
            }

        }

        void TabControl_Inventory_MouseUpResizeGripEventAsync(object? sender, MouseEventArgs e)
        {
            ShowPlexiglassRectangle.Close();

            splitContainerVertical.SplitterDistance   = ShowPlexiglassRectangle.Location.X;
            splitContainerHorizontal.SplitterDistance = ShowPlexiglassRectangle.Height;

            TabControl_Inventory.Visible = true;
            
            SaveUserSetting();
        }

        void TabControl_Inventory_MouseDownResizeGripEvent(object? sender, MouseEventArgs e)
        {
            internalResizeEvent = false;

            // Show a Plexiglass rectangle to simulate the resizing of the splitContainer, this is for better
            // user experience, because the real resizing of the splitContainer is too slow and we set
            // the SplitterDistance only when the mouse up event is triggered, so the user can see the
            // resizing process with the Plexiglass rectangle, and when the mouse up event is triggered,
            // the real resizing of the splitContainer is done and the Plexiglass rectangle is closed.
            Point location = splitContainerVertical.SplitterRectangle.Location;
            Size sizeCon = splitContainerVertical.Panel2.ClientSize;
            var rectangleImage = (Bitmap)ScreenImage.GetScreenshot(Handle, location, sizeCon);

            ShowPlexiglassRectangle = new Plexiglass(this)
            {
                ClientSize = sizeCon,
                RectImage = rectangleImage,
                Location = PointToScreen(location)
            };

            TabControl_Inventory.Visible = false;
        }

        void TabControl_Inventory_ResizeGripEvent(object? sender, Custom_Events_Args.ResizeGrip_EventArgs e)
        {
            ShowPlexiglassRectangle.Location = new Point(ShowPlexiglassRectangle.Location.X + e.X, ShowPlexiglassRectangle.Location.Y);
            ShowPlexiglassRectangle.ClientSize = new Size(ShowPlexiglassRectangle.ClientSize.Width - e.X, ShowPlexiglassRectangle.ClientSize.Height + e.Y);
        }

        #endregion"TabControlExtende"

        #region"Tab_ThumbsViewer_Pictures"

        readonly Font _informationStatusTrue = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
        readonly Font _informationStatusFalse = new Font(FontFamily.GenericSansSerif, 6, FontStyle.Italic);

        void InitializeThumbsViewerPicture()
        {
            InitializeThumbViewerPicturesBase(thumbViewer_Pictures);

            thumbViewer_Pictures.SplitterDistance = 88;
            thumbViewer_Pictures.DefaultAddress = Path.Combine(Settings.Default.DataBaseAddress, "Pictures");

            thumbViewer_Pictures.InformationStatus += ThumbViewer_Pictures_InformationStatus; ;
        }

        private void ThumbViewer_Pictures_InformationStatus(object? sender, InformationStatus_EventArgs e)
        {
            if (e.InformationStatus == true)
            {
                tabPage_Pictures.Font = _informationStatusTrue;
            }
            else
            {
                tabPage_Pictures.Font = _informationStatusFalse;
            }

            tabPage_Pictures.Text = " Pictures " + e.Qty;
            tabPage_Pictures.Invalidate();
        }

        #endregion"Tab_ThumbsViewer_Pictures"

        #region"Tab_ThumbsViewer_Location"

        void InitializeThumbsViewerLocation()
        {
            InitializeThumbViewerLocationBase(thumbViewer_Location);

            thumbViewer_Location.SplitterDistance = 72;
            thumbViewer_Location.DefaultAddress = Path.Combine(Settings.Default.DataBaseAddress, "Pictures", "Location");

            thumbViewer_Location.InformationStatus += ThumbViewer_Location_InformationStatus;
        }

        void ThumbViewer_Location_InformationStatus(object? sender, Custom_Events_Args.InformationStatus_EventArgs e)
        {
            if (e.InformationStatus == true)
            {
                tabPage_Location.Font = _informationStatusTrue;
            }
            else
            {
                tabPage_Location.Font = _informationStatusFalse;
            }

            tabPage_Location.Text = " Location " + e.Qty; ;
            tabPage_Location.Invalidate();
        }


        /// <summary>
        /// Test if the file exist, filePathString contain only the filename out ext,
        /// this routine add ext ".JPG", need modification....
        /// </summary>
        /// <param name="filePathString"></param>
        void GetLocationProcess(string fileNameOutExtString)
        {
            if (fileNameOutExtString == null)
                return;

            thumbViewer_Location.PathFromPartNumber = fileNameOutExtString;
        }


        #endregion"Tab_ThumbsViewer_Location"

        #region "Tab_AddNewItem"               

        void InitializeTab_AddNewItem()
        {
            InitializeComboBoxPartNumberDescription();

            InitializeButtons();

            if (TabControl_Inventory.TabPages.Contains(tabPage_AddNewItem))
                TabControl_Inventory.SelectTab(tabPage_AddNewItem);
        }

        void InitializeComboBoxPartNumberDescription()
        {
            comboBoxExtended_PartNumber.LabelText = "PartNumber";
            comboBoxExtended_PartNumber.Text = "Select a new PartNumber...";
            comboBoxExtended_Description.LabelText = "Description";
            comboBoxExtended_Description.Text = "PartNumber's Description...";
        }


        #region"Button events"

        int addedCompIndex;
        SortedList<int, DataRowView> addedComp = new SortedList<int, DataRowView>();

        void InitializeButtons()
        {
            button_AddNew.Enabled = false;
            button_Save.Enabled = false;

            button_Delete.Enabled = false;
        }

        void Button_AddNew_Click(object? sender, EventArgs e)
        {
            button_AddNew.Enabled = false;
            button_Save.Enabled = true;
            button_Delete.Enabled = true;

            CurrentStatusReference.SelectedColor = ColorTranslator.FromHtml("#FFA456B8");
            CurrentStatusReference.Selected = true;

            object newObject = _bindingSource_StockRoom.AddNew();
            DataRowView newDataRowView = newObject as DataRowView;

            newDataRowView["PartNumber"] = comboBoxExtended_PartNumber.Text;
            newDataRowView["Description"] = comboBoxExtended_Description.Text;
            newDataRowView["Status"] = CurrentStatusReference.ToString();

            addedCompIndex++;
            addedComp.Add(addedCompIndex, newDataRowView);

            InitializeComboBoxPartNumberDescription();

            On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("A new partNumber been added to the database " +
                                                                                    newDataRowView["PartNumber"].ToString()));
        }

        void Button_Save_Click(object? sender, EventArgs e)
        {
            button_Save.Enabled = false;

            On_Save_Requested(new Save_Requested_EventArgs(Utilities.NotificationEvents.DataBaseUpDated));
        }

        void Button_Delete_Click(object? sender, EventArgs e)
        {
            string partNumberDataGridView = dataGridViewExtended.CurrentRowActive.Cells["PartNumber"].Value.ToString();

            string partNumberDelete = "";
            DataRowView addedRowToDelete;

            foreach (KeyValuePair<int, DataRowView> ddd in addedComp)
            {
                if (ddd.Value["PartNumber"].ToString().Contains(partNumberDataGridView))
                {
                    partNumberDelete = ddd.Value["PartNumber"].ToString();
                    addedRowToDelete = ddd.Value;

                    dataGridViewExtended._dataGridView.Rows.Remove(dataGridViewExtended.CurrentRowActive);

                    if (_bindingSource_StockRoom.Contains(addedRowToDelete))
                    {
                        _bindingSource_StockRoom.Remove(addedRowToDelete);
                        _bindingSource_StockRoom.ResetBindings(false);
                    }

                    addedComp.Remove(ddd.Key);

                    if (addedComp.Count == 0)
                        button_Delete.Enabled = false;

                    button_Save.Enabled = true;

                    On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("An partNumber to been removed from the database " + partNumberDelete));

                    return;
                }
            }

            MessageBox.Show(new Form() { TopMost = true }, @"The delete option only applies to components added on this occasion, " +
                                                           @"it is not possible to remove old components using this tool.",
                                                           @"You try to delete a component that has not been generated this time.",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion"Button events"

        #endregion "Tab_AddNewItem"

        #region"Tab_NodeSetting"

        NodeSetting _nodeSetting;
        bool _nodeSettingIsDone = false;
        /// <summary>
        /// RenameDistFileName, true to rename with new fileName, false keep original fileName.
        /// </summary>
        bool RenameDistFileName;

        /// <summary>
        /// DeleteOriginalFile, true to delete the source file, false keep source file.
        /// </summary>
        bool DeleteOriginalFile;

        void InitializeNodeSettingTabPage()
        {
            if (_nodeSettingIsDone)
                return;

            _nodeSettingIsDone = true;

            RenameDistFileName = Settings.Default.RenameDistFileName;

            DeleteOriginalFile = Settings.Default.DeleteOriginalFile;


            _nodeSetting = new NodeSetting(_bindingSourceStockRoomTreeViewVal, ColumnsCollection, _employeesService)
            {
                DebugMode = false,
                AutoScroll = true,
                Dock = DockStyle.Fill,
                AutoScrollMinSize = new Size(730, 475),
                Location = new Point(0, 0),
                Name = "nodeSetting",
                NeedSaveData = false,
                Size = new Size(731, 501),
                TabIndex = 0
            };

            _nodeSetting.CurrentNode = new Table_Base_TreeView();
            _nodeSetting.SaveRequested += NodeSetting_Save_Requested;
            _nodeSetting.StatusBarMessage += NodeSetting_StatusBarMessage;
            _nodeSetting.NodeImageChange += NodeSetting_NodeImageChange;

           // CurrentDeptUserBroadcast_Requested += _nodeSetting.CurrentUserBroadcast_EventHandler;

            tabPage_TreeViewSetting.Controls.Add(_nodeSetting);
        }

        void NodeSetting_NodeImageChange(object? sender, NodeSetting.NodeImageChange_EventArgs e)
        {
            _ = dataTreeViewToAdd_Cancel_Delete.InitializeImageListAsync();
        }

        void NodeSetting_StatusBarMessage(object? sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        async void NodeSetting_Save_Requested(object? sender, Save_Requested_EventArgs e)
        {
            if (_bindingSourceStockRoomTreeViewVal.TableName.Contains("Table_StockRoom_TreeView"))
            {
                await _unitOfWork.TableStockRoomTreeViewRepository.UpdateAsync((Table_StockRoom_TreeView)e.Item, CancellationToken.None);
            }
        }

        #endregion"Tab_NodeSetting"

        #region"Tab_UpDateModifCompValue"

        BaseComponent currentComp;
        ComponentInformation currentCompInformation;

        void InitializeTabPage_UpDateModifCompValue()
        {
            currentComp = new Resistor();
            customPanel_ContainerComp.Controls.Clear();
            customPanel_ContainerComp.Controls.Add(currentComp);
            currentCompInformation = new("NewComp-xxxx");
        }

        void FocusTabPage_UpDateModifCompValue()
        {
            if(TabControl_Inventory.SelectedTab != tabPage_UpDateModifCompValue)
                return;

            if(CurrentRowViewActive == null)
                return;

            textBoxUpDateModifPartNumber.Text = CurrentPartNumber;


        //    currentCompInformation.ProcessNewCompInformation(CurrentRowViewActive, customPanel_ContainerComp);

            //currentCompInformation = new ComponentInformation(CurrentRowViewActive, customPanel_ContainerComp);
                                                
            //customPanel_ContainerComp.Controls.Clear();
            //customPanel_ContainerComp.Controls.Add(currentCompInformation.SeletedComponent);



        }


        #endregion"Tab_ThumbsViewer_Pictures"

        #region"Timer SaveUserSetting if it's modifying the user interface."

        /// <summary>
        /// Initialize the SaveUserSettingTimer to 10 seconds to save
        /// user setting if this is modifying the user interface.
        /// </summary>
        void InitializeSaveUserSettingTimer()
        {
            SaveUserSettingTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            SaveUserSettingTimer.Tick += async (sender, e) => await SaveUserSettingTickAsync(sender, e);
        }

        int _sec = 10;
        /// <summary>
        /// An interval of 10 seconds to save user setting if this is modifying the user interface.
        /// </summary>
        System.Windows.Forms.Timer SaveUserSettingTimer;

        /// <summary>
        /// Start the SaveUserSettingTimer to save user setting if this is modifying the user interface,
        /// wait for others changes, if there is no more modification, save user setting after 10 seconds.
        /// </summary>
        void SaveUserSetting()
        {
            // Guard: timer not yet initialized during early layout events.
            if (SaveUserSettingTimer == null)
                return;

            SaveUserSettingTimer.Start();
            _sec = 10;

            On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  10 sec less to save StockRoom setting."));
        }

        async Task SaveUserSettingTickAsync(object? sender, EventArgs e)
        {
            _sec--;

            if (_sec > 0)
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  " + _sec + " sec less to save StockRoom setting."));
                return;
            }

            SaveUserSettingTimer.Stop();
            On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  "));//Clear the StatusBar.

            await _currentEmployeeLogIn.UpDateSave_Splitter_UserSetting(userSettingName, splitContainerVertical.SplitterDistance,
                                                                        splitContainerHorizontal.SplitterDistance);
        }

        #endregion"Timer SaveUserSetting if it's modifying the user interface."   

        async void TimeLineToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            string dataObject = @"{""title"": {
            ""media"": {
                ""url"": ""//www.flickr.com/photos/tm_10001/2310475988/"",
        ""caption"": ""Whitney Houston performing on her My Love is Your Love Tour in Hamburg."",
        ""credit"": ""flickr/<a href='http://www.flickr.com/photos/tm_10001/'>tm_10001</a>""
            },
    ""text"": {
                ""headline"": ""Whitney Houston<br/> 1963 - 2012"",
        ""text"": ""<p>Houston's voice caught the imagination of the world propelling her to superstardom at an early age becoming one of the most awarded performers of our time. This is a look into the amazing heights she achieved and her personal struggles with substance abuse and a tumultuous marriage.</p>""
    }
        },
    ""events"": [
    {
            ""media"": {
                ""url"": ""//twitter.com/Blavity/status/851872780949889024"",
                ""caption"": ""Houston, performing on Good Morning America in 2009."",
                ""credit"": ""<a href='http://commons.wikimedia.org/wiki/File%3AFlickr_Whitney_Houston_performing_on_GMA_2009_4.jpg'>Asterio Tecson</a> via Wikimedia""
            },
            ""start_date"": {
                ""month"": ""2"",
                ""day"": ""11"",
                ""year"": ""2012""
            },
            ""text"": {
                ""headline"": ""Whitney Houston<br/> 1963-2012"",
                ""text"": ""<p>Houston, 48, was discovered dead at the Beverly Hilton Hotel on  on Feb. 11, 2012. She is survived by her daughter, Bobbi Kristina Brown, and mother, Cissy Houston.</p>""
            }
        }
    ]
}";

            _appService.UpDateTimeLine(dataObject);
        }

        
    }
}

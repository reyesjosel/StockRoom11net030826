using Microsoft.AspNetCore.Components.WebView.WindowsForms;
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
using StockRoom11net.Controls.RawInput;
using StockRoom11net.Controls.ShellBasics;
using StockRoom11net.Controls.SMTcontrol;
using StockRoom11net.Controls.ZPL2_ZebraPrint;
using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using StockRoom11net.Properties;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using static StockRoom11net.Controls.Custom_Events_Args;
using CurrentRowMouseEnterEventArgs = StockRoom11net.Controls.Custom_Events_Args.RowsMouseEnterEventArgs;

namespace StockRoom11net
{
    public partial class StockRoom_Inventory : BaseTemple
    {
        #region "Properties"

        // Injected EF Core services
        private readonly IUnitOfWork _unitOfWork;
        private ITableEmployeeService _employeesService;
        private readonly IStockRoomService _stockRoomService;
        private readonly ITableStockRoomTreeViewService _tableStockRoomTreeViewService;
        
        // ✅ Updated to use scaffolded entity
        private BindingList<Table_StockRoom> _stockRoomBindingList;
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

                    if (dataGridViewExtended.DataSource == _bindingSource_table_StockroomTreeView)
                        dataGridViewExtended.DataSource = _bindingSource_StockRoom;
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

        readonly DataTable _dataTableStockRoom;
        readonly DataTable _dataTableTreeListView;

        // To catch missing registrations early, you can also mark the parameterless
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
            _employeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService));
            _employeesService.CurrentEmployeeLogInChanged += (s, e) =>
            {                
                dataTreeViewToAdd_Cancel_Delete.CurrentDepartmentLogIn = _employeesService.CurrentDepartmentLogIn.DepartmentName;
            };
            _stockRoomService = stockRoomService ?? throw new ArgumentNullException(nameof(stockRoomService));
            _tableStockRoomTreeViewService = tableStockRoomTreeViewService ?? throw new ArgumentNullException(nameof(tableStockRoomTreeViewService));
            
            Name = "StockRoom_Inventory";

            // We need pass employeeService, at initialization we call currentEmployeeLogIn
            dataGridViewExtended.EmployeesService = _employeesService;

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
        /// If we were not using EF Core, we would load data from a file or other source here.
        /// But since we are using EF Core, we will load data in the LoadDataEF() method.
        /// </summary>
        async void LoadDataEF()
        {
            // ✅ Load data using EF Core
            await LoadTimeLineDataAsync();
        }

        /// <summary>
        /// Load TimeLine data using EF Core service
        /// </summary>
        private async Task LoadTimeLineDataAsync()
        {
            try
            {
                MessageDebugPosition = "Starting LoadTimeLineDataAsync()";

                // ✅ Load data from database
                _stockRoomBindingList = await _stockRoomService.LoadStockRoomsAsync();

                // ✅ Convert to DataTable → DataView → BindingSource (supports .Filter)
                var dataTable = _stockRoomBindingList.ToDataTable();
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
                _stockRoomTreeViewBindingList = await _tableStockRoomTreeViewService.LoadStockRoomsTreeViewAsync();

                // ✅ Remove nodes with duplicate or zero IDs before binding
                var validNodes = _stockRoomTreeViewBindingList
                    .Where(n => n.ID > 0)
                    .GroupBy(n => n.ID)
                    .Select(g => g.First())  // keep first in case of duplicates
                    .ToList();

                var duplicates = _stockRoomTreeViewBindingList
                    .GroupBy(n => n.ID)
                    .Where(g => g.Count() > 1 || g.Key == 0)
                    .Select(g => g.Key)
                    .ToList();

                if (duplicates.Count != 0)
                    Debug.WriteLine($"⚠️ Duplicate/zero IDs found: {string.Join(", ", duplicates)}");

                if (HasCircularReference(validNodes))
                {
                    MessageBox.Show($"Error loading data: Circular reference detected in node ID: {nodeID}.",
                    "Data Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                MessageDebugPosition = "Diagnose data before assigning to OLV";
                var items = _stockRoomTreeViewBindingList.ToList().Cast<Table_Base_TreeView>().ToList();
                var roots = items.Where(n => n.Parent_ID == 0).ToList();
                var dupIDs = items.GroupBy(n => n.ID).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                var orphans = items.Where(n => n.Parent_ID != 0 && !items.Any(p => p.ID == n.Parent_ID)).ToList();

                Debug.WriteLine($"Total: {items.Count} | Roots (Parent_ID==0): {roots.Count} | DupIDs: {string.Join(",", dupIDs)} | Orphans: {orphans.Count}");

                if (roots.Count == 0 || dupIDs.Any())
                {
                    MessageBox.Show($"Tree data invalid!\nRoots: {roots.Count}\nDuplicate IDs: {string.Join(",", dupIDs)}\nOrphans: {orphans.Count}",
                        "DataSource Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // ← prevents the freeze
                }

                MessageDebugPosition = "Create BindingSource for TreeView";
                _bindingSourceStockRoomTreeViewVal = new BindingSourceValidating<Table_Base_TreeView>
                {
                    // DataSource = new BindingList<Table_Base_TreeView>(validNodes.Cast<Table_Base_TreeView>().ToList()),
                    DataSource = _stockRoomTreeViewBindingList,
                    TableName = "Table_StockRoom_TreeView",
                    Position = 0
                };

                MessageDebugPosition = "Assign BindingSource to TreeView";
                dataTreeViewToAdd_Cancel_Delete.BindingSourceTreeView = _bindingSourceStockRoomTreeViewVal;

                StatusBarMessage(new StatusBarMessage_EventArgs($"Loaded {_stockRoomBindingList.Count} StockRoom records"));
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
                int current = node.Parent_ID  ;

                while (current != 0)
                {
                    if (!lookup.TryGetValue(current, out var parent)) break;
                    if (!visited.Add(current))
                    {
                        nodeID = node.ID.ToString();
                        return true; // ← circular!
                    }
                    current = parent.Parent_ID;
                }
            }
            return false;
        }

        bool _isNotInitiating = false;
        void BindingSource_Table_StockroomTreeView_ListChanged(object? sender, ListChangedEventArgs e)
        {
            /// We assign the bindingsource only when it contains some element, only once.
            if (BindingSourceTreeViewBase.Count > 0 & _isNotInitiating == false)
            {
                _isNotInitiating = true;

                var action = new Action(() =>
                {
                    dataTreeViewToAdd_Cancel_Delete.BindingSourceTreeView = 
                    new BindingSourceValidating<Table_Base_TreeView> { DataSource = BindingSourceTreeViewBase };
                });

                ThreadSafeInvoke(action);
            }

            if(_isNotInitiating)
            {
                if (BindingSourceTreeViewBase.Count > 0)
                    dataTreeViewToAdd_Cancel_Delete.EnsureVisibledNode(0);
            }
        }
        
        #region "StockRoomInventory Load, Shown, FormClosing"

        void StockRoomInventoryLoad(object? sender, EventArgs e)
        {
            MessageDebugPosition = "Starting Try/Catch procedure.";
            try
            {
                LoadDataEF();

                MessageDebugPosition = "Initialize_DataGridView()";
                Initialize_DataGridView();

                MessageDebugPosition = "InitTabControlExtend()";
                InitTabControlExtend();

                MessageDebugPosition = "InitializeThumbsViewerPicture()";
                InitializeThumbsViewerPicture();

                MessageDebugPosition = "InitializeThumbsViewerLocation()";
                InitializeThumbsViewerLocation();

                MessageDebugPosition = "InitializeTabPage_UpDateModifCompValue()";
                InitializeTabPage_UpDateModifCompValue();

                MessageDebugPosition = "InitEasyProgressBar()";
                //   InitEasyProgressBar();

                MessageDebugPosition = "InitEasyProgressBar_GraphicChart()";
                //   InitEasyProgressBar_GraphicChart();

                MessageDebugPosition = "Initialize_ToolTip";
                //   InitializeToolTip();

                MessageDebugPosition = "Initialize_NodeSetting";
                InitializeNodeSettingTabPage();

                MessageDebugPosition = "Initialize_OK";
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
                dataTreeViewToAdd_Cancel_Delete.CurrentDepartmentLogIn = _employeesService.CurrentDepartmentLogIn.DepartmentName;
                MessageDebugPosition = "ListChangedType.Reset";

                // ✅ Use Reset instead of ItemMoved — Reset does not require a valid index
                // and correctly signals "re-evaluate the whole list" for initialization.
                BindingSource_Table_StockroomTreeView_ListChanged(sender, new ListChangedEventArgs(ListChangedType.Reset, -1));

                MessageDebugPosition = "InitializeTab_AddNewItem";
                InitializeTab_AddNewItem();

                MessageDebugPosition = "_initialDelay";
                _initialDelay = new System.Windows.Forms.Timer
                {
                    Interval = 1000
                };
                _initialDelay.Tick += InitialDelay_Tick;
                _initialDelay.Start();
                
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

        int count_InitialDelayTick;
        void InitialDelay_Tick(object? sender, EventArgs e)
        {
            _initialDelay.Stop();
            count_InitialDelayTick++;

            try
            {
                //Call those only one time.
                if (count_InitialDelayTick == 1)
                {
                    //InitializeProcessUserHasLogIn();
                    if(_isNotInitiating == false)
                        BindingSource_Table_StockroomTreeView_ListChanged(sender, new ListChangedEventArgs(ListChangedType.Reset, -1));
                }

                FaultColumnPartNumber = !dataGridViewExtended._dataGridView.Columns.Contains("PartNumber");
                
             //   SortColumnPartNumber();
             //   AddColumnSortDoc_PDF_Doc_Docx();               
             //   ProcessBOMrows();
            }
            catch (Exception)
            { }
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

        void DataTreeViewToAdd_Cancel_Delete_Load(object? sender, EventArgs e)
        {
            
        }

        async void DataTreeViewToAdd_Cancel_Delete_SelectedIndexChangedAsync(object? sender, TreeViewSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (dataGridViewExtended.DataSource == _bindingSourceStockRoomVal)
                {
                    //string filter = e.SelectedNodeProperties.StringFilter;
                    //var filtered = await _stockRoomService.FilterByStringFilterAsync(filter);
                    //_bindingSourceStockRoomVal.DataSource = filtered;
                    //_bindingSourceStockRoomVal.ResetBindings(false);

                    // ✅ Filter now works because DataSource is a DataView
                    dataGridViewExtended.CustomFilter = e.SelectedNodeProperties.StringFilter;
                }

                #region"tabPage_DataTreeViewSetting"

                if (_nodeSettingIsDone & TabControl_Inventory.SelectedTab.Name == "tabPage_TreeViewSetting")
                {
                    _nodeSetting.FocusedNodeProperties = e.SelectedNodeProperties;
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

            dataGridViewExtended.Name = "StockRoom Inventory";

            dataGridViewExtended.CellBegingEditEvent    += DataGridViewExtendedInventoryCellBeggingEditEvent;
            dataGridViewExtended.CellEndEditEvent       += DataGridViewExtendedInventoryCellEndEditEvent;
            dataGridViewExtended.CellClickEvent         += DataGridViewExtended_StockRoom_CellClick_Event;
            dataGridViewExtended.CellDoubleClickEvent   += DataGridViewExtended_StockRoom_CellDoubleClick_Event;

            dataGridViewExtended.CellMouseEnter         += DataGridViewExtended_CellMouseEnter;

            dataGridViewExtended.RowsRemoved            += DataGridViewExtendedInventoryRowsRemoved;
            dataGridViewExtended.RowsMouseEnter         += DataGridViewExtended_RowsMouseEnter;
            dataGridViewExtended.UserDeletedRow         += DataGridViewExtendedInventoryUserDeletedRow;
            dataGridViewExtended.CurrentRowActivesEvent += DataGridViewExtendedInventoryCurrentRowActive;

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

        void DataGridViewExtendedInventoryCellBeggingEditEvent(object? sender, DataGridViewCellCancelEventArgs e)
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

        Plexiglass ShowResizeRectangle;
        void InitTabControlExtend()
        {
            splitContainerHorizontal.SplitterWidth = 3;
            splitContainerVertical.SplitterWidth = 3;

            TabControl_Inventory.Alignment = TabAlignment.Bottom;

            // TabControl_Inventory.HideTab("tabPage_TreeViewSetting");

            TabControl_Inventory.MouseDownResizeGripEvent += TabControl_Inventory_MouseDownResizeGripEvent;
            TabControl_Inventory.MouseUpResizeGripEvent += TabControl_Inventory_MouseUpResizeGripEvent;
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

        void TabControl_Inventory_MouseUpResizeGripEvent(object? sender, MouseEventArgs e)
        {
            ShowResizeRectangle.Close();

            splitContainerVertical.SplitterDistance = ShowResizeRectangle.Location.X;
            splitContainerHorizontal.SplitterDistance = ShowResizeRectangle.Height;

            TabControl_Inventory.Visible = true;

            //  StockRoomSetting.SplitterX = splitContainerVertical.SplitterDistance;
            //  StockRoomSetting.SplitterY = splitContainerHorizontal.SplitterDistance;

            //  SaveUserSetting();
        }

        void TabControl_Inventory_MouseDownResizeGripEvent(object? sender, MouseEventArgs e)
        {
            Point location = splitContainerVertical.SplitterRectangle.Location;
            Size sizeCon = splitContainerVertical.Panel2.ClientSize;
            var rectangleImage = (Bitmap)ScreenImage.GetScreenshot(Handle, location, sizeCon);

            ShowResizeRectangle = new Plexiglass(this)
            {
                ClientSize = sizeCon,
                RectImage = rectangleImage,
                Location = PointToScreen(location)
            };

            TabControl_Inventory.Visible = false;
        }

        void TabControl_Inventory_ResizeGripEvent(object? sender, Custom_Events_Args.ResizeGrip_EventArgs e)
        {
            ShowResizeRectangle.Location = new Point(ShowResizeRectangle.Location.X + e.X, ShowResizeRectangle.Location.Y);
            ShowResizeRectangle.ClientSize = new Size(ShowResizeRectangle.ClientSize.Width - e.X, ShowResizeRectangle.ClientSize.Height + e.Y);
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

            _nodeSetting = new NodeSetting(BindingSourceTreeViewBase, ColumnsCollection, _employeesService);

            _nodeSetting.SaveRequested += NodeSetting_Save_Requested;
            _nodeSetting.StatusBarMessage += NodeSetting_StatusBarMessage;
            _nodeSetting.NodeImageChange += NodeSetting_NodeImageChange;
            _nodeSetting.AutoScroll = true;
            _nodeSetting.AutoScrollMinSize = new Size(730, 475);
            _nodeSetting.Dock = DockStyle.Fill;
       //     _nodeSetting.FocusedNodeProperties = new NodeProperties();
            _nodeSetting.Location = new Point(0, 0);
            _nodeSetting.Name = "nodeSetting";
            _nodeSetting.NeedSaveData = false;
            _nodeSetting.Size = new Size(731, 501);
            _nodeSetting.TabIndex = 0;

            CurrentDeptUserBroadcast_Requested += _nodeSetting.CurrentUserBroadcast_EventHandler;

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

        void NodeSetting_Save_Requested(object? sender, Save_Requested_EventArgs e)
        {
            On_Save_Requested(e);
        }

        #endregion"Tab_NodeSetting"

        #region"Tab_GraphicChart"

        //  EasyProgressBar.EasyProgressBar easyProgressBar_GraphicChart;
        bool isProgressStarted_GraphicChart;
        Thread progressThread_GraphicChart;
        int Prod_Projected = 1000;

        void Chart_up_date()
        {
            #region "Set Chart Area position, Set the plotting area position."

            /*

            chart_Components.ChartAreas["Default"].Area3DStyle.Enable3D = false;

            // Set Chart Area position,es el area donde se ponen los label y el grafico
            chart_Components.ChartAreas["Default"].Position.Auto = false;
            chart_Components.ChartAreas["Default"].Position.X = 0;
            chart_Components.ChartAreas["Default"].Position.Y = 3;
            chart_Components.ChartAreas["Default"].Position.Width = 95;
            chart_Components.ChartAreas["Default"].Position.Height = 95;

            // Set the plotting area position. Coordinates of a plotting 
            // area are relative to a chart area position.
            chart_Components.ChartAreas["Default"].InnerPlotPosition.Auto = false;
            chart_Components.ChartAreas["Default"].InnerPlotPosition.X = 10;
            chart_Components.ChartAreas["Default"].InnerPlotPosition.Y = 5;
            chart_Components.ChartAreas["Default"].InnerPlotPosition.Width = 90;
            chart_Components.ChartAreas["Default"].InnerPlotPosition.Height = 80;

            */

            #endregion


            /*
            #region "Scale Breaks"

            // Enable scale breaks
            chart_Components.ChartAreas["Default"].AxisY.ScaleBreakStyle.Enabled = true;

            // Set the scale break type
          //  chart_Components.ChartAreas["Default"].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Ragged;

            // Set the spacing gap between the lines of the scale break (as a percentage of y-axis)
            chart_Components.ChartAreas["Default"].AxisY.ScaleBreakStyle.Spacing = 2;

            // Set the line width of the scale break
            chart_Components.ChartAreas["Default"].AxisY.ScaleBreakStyle.LineWidth = 2;

            // Set the color of the scale break
            chart_Components.ChartAreas["Default"].AxisY.ScaleBreakStyle.LineColor = Color.MediumTurquoise;

            // Show scale break if more than 25% of the chart is empty space
            chart_Components.ChartAreas["Default"].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 10;

            // If all data points are significantly far from zero, 
            // the Chart will calculate the scale minimum value
          //  chart_Components.ChartAreas["Default"].AxisY.ScaleBreakStyle.StartFromZero = StartFromZero.Auto;

            #endregion "Scale Breaks End"

            #region "AxisX labels"

            // Disable axis labels auto fitting of text
            chart_Components.ChartAreas["Default"].AxisX.IsLabelAutoFit = false;

            // Set axis labels font
            chart_Components.ChartAreas["Default"].AxisX.LabelStyle.Font = new Font("Arial", 7, FontStyle.Bold);

            // Set axis labels angle
            chart_Components.ChartAreas["Default"].AxisX.LabelStyle.Angle = 30;

            // Disable offset labels style
            chart_Components.ChartAreas["Default"].AxisX.LabelStyle.IsStaggered = false;

            // Enable X axis labels
            chart_Components.ChartAreas["Default"].AxisX.LabelStyle.Enabled = true;

            // Enable AntiAliasing for either Text and Graphics or just Graphics
        //    chart_Components.AntiAliasing = AntiAliasingStyles.All; // AntiAliasingStyles.Graphics and AntiAliasing.Text

            // Set interval of X axis to zero, which represents an "Auto" value.
            chart_Components.ChartAreas["Default"].AxisX.Interval = 1;

            // Use variable count algorithm to generate labels.
         //   chart_Components.ChartAreas["Default"].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chart_Components.ChartAreas["Default"].AxisX.MajorTickMark.Interval = 1;

            chart_Components.ChartAreas["Default"].AxisX.IsMarginVisible = false;

            #endregion

            #region"Add the second legend"

         //   chart_Components.Legends.Add(new Legend("Second"));

            // Associate the last three series to the new legend
            chart_Components.Series["Comp_On_Hand"].Legend = "Second";
            chart_Components.Series["Comp_for_Prod"].Legend = "Second";

            #endregion"Add the second legend"

            #region"Create cursor object"

      //      System.Windows.Forms.DataVisualization.Charting.Cursor cursor = null;

            // Set cursor object
      //      cursor = chart_Components.ChartAreas["Default"].CursorY;

            // Set cursor properties 
     //       cursor.LineWidth = 1;
      //      cursor.LineDashStyle = ChartDashStyle.Solid;
      //      cursor.LineColor = Color.Red;
      //      cursor.SelectionColor = Color.Yellow;

            // Set cursor selection color of X axis cursor
            chart_Components.ChartAreas["Default"].CursorX.SelectionColor = Color.Yellow;

            chart_Components.ChartAreas["Default"].CursorX.IsUserEnabled = true;
            chart_Components.ChartAreas["Default"].CursorY.IsUserEnabled = true;


            #endregion"Create cursor object"

            */

            /*

            #region"Set Titles in Chart"
            chart_Components.Titles.Add("");

            // Set chart title
            chart_Components.Titles[0].Text = "Graphics Chart.";

            // Set chart title font
            chart_Components.Titles[0].Font = new Font("Times New Roman", 12, FontStyle.Bold);

            // Set chart title color
            chart_Components.Titles[0].ForeColor = Color.Black;

            // Set border title color
            chart_Components.Titles[0].BorderColor = Color.Transparent;

            // Set background title color
            chart_Components.Titles[0].BackColor = Color.Transparent;

            // Set Title Alignment
            chart_Components.Titles[0].Alignment = System.Drawing.ContentAlignment.MiddleCenter;

            // Set Title ToolTip
            chart_Components.Titles[0].ToolTip = "Estimated Quantity = " + Prod_Projected;

            #endregion"Set Titles in Chart"

            */

            //   chart_Components.CursorPositionChanging += Chart_Components_CursorPositionChanging;

        }

        void Chart_Components_CursorPositionChanging(object? sender)
        {
            /*
            if (double.IsNaN(e.NewPosition))
                return;

            if ((int)e.NewPosition >= chart_Components.Series["Comp_On_Hand"].Points.Count)
                return;

            if (e.Axis.AxisName == AxisName.X)
            {
                string _label = chart_Components.Series["Comp_On_Hand"].Points[(int)e.NewPosition].AxisLabel;

                if (_label == "")
                    return;

                //     int index = _bindingSource_tableStockRoom.Find("PartNumber", _label);

                //     if (index == -1)
                //         return;

                //     DataRowView row = (DataRowView)_bindingSource_tableStockRoom[index];

                dataGridViewExtended.FirstDisplayedRow = "PartNumber/" + _label;

            }
            */
        }

        #region"InitEasyProgressBar_Updating Graphic Chart"
        /*
            void InitEasyProgressBar_GraphicChart()
            {
                easyProgressBar_GraphicChart = new EasyProgressBar.EasyProgressBar
                {
                    AlphaMaker = floatWindowAlphaMaker1,
                    BackColor = System.Drawing.SystemColors.Window
                };
                easyProgressBar_GraphicChart.BackgroundGradient.ColorStart = System.Drawing.Color.White;
                easyProgressBar_GraphicChart.BackgroundGradient.IsBlendedForBackground = true;
                easyProgressBar_GraphicChart.BorderColor = System.Drawing.Color.Gray;
                easyProgressBar_GraphicChart.DigitBoxGradient.BorderColor = System.Drawing.Color.Silver;
                easyProgressBar_GraphicChart.DigitBoxGradient.ColorEnd = System.Drawing.Color.AntiqueWhite;
                easyProgressBar_GraphicChart.DigitBoxGradient.ColorStart = System.Drawing.Color.White;
                easyProgressBar_GraphicChart.DigitBoxGradient.IsBlendedForBackground = true;
                easyProgressBar_GraphicChart.DisplayFormat = "";
                easyProgressBar_GraphicChart.Font = new Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                easyProgressBar_GraphicChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                easyProgressBar_GraphicChart.IsDigitDrawEnabled = false;
                easyProgressBar_GraphicChart.Location = new Point(((ClientSize.Width / 2) - 300), ((ClientSize.Height / 2) + 30));
                easyProgressBar_GraphicChart.Name = "easyProgressBar_GraphicChart";
                easyProgressBar_GraphicChart.ProgressColorizer.Alpha = ((byte)(113));
                easyProgressBar_GraphicChart.ProgressColorizer.Blue = ((byte)(140));
                easyProgressBar_GraphicChart.ProgressColorizer.Green = ((byte)(200));
                easyProgressBar_GraphicChart.ProgressColorizer.Red = ((byte)(230));
                easyProgressBar_GraphicChart.ProgressGradient.ColorEnd = System.Drawing.Color.Wheat;
                easyProgressBar_GraphicChart.ProgressGradient.ColorStart = System.Drawing.Color.WhiteSmoke;
                easyProgressBar_GraphicChart.ProgressGradient.IsBlendedForProgress = true;
                easyProgressBar_GraphicChart.Size = new Size(600, 65);
                easyProgressBar_GraphicChart.TabIndex = 0;
                easyProgressBar_GraphicChart.Text = "40% ";
                easyProgressBar_GraphicChart.Value = 40;
                easyProgressBar_GraphicChart.DockUndockProgressBar = false;
                easyProgressBar_GraphicChart.Visible = false;
                easyProgressBar_GraphicChart.EasyProgressBarClosing += EasyProgressBar_GraphicChart_EasyProgressBarClosing;
                easyProgressBar_GraphicChart.MouseEnter += EasyProgressBar_GraphicChart_MouseEnter;
                easyProgressBar_GraphicChart.MouseLeave += EasyProgressBar_GraphicChart_MouseLeave;

                chart_Components.Series["Comp_for_Prod"].Points.Clear();
                chart_Components.Series["Comp_On_Hand"].Points.Clear();
                chart_Components.Annotations.Clear();

                chart_Components.Series["Comp_On_Hand"].LabelAngle = 30;
            }

            // Starts or stops the current progressThread.
            void Start_EasyProgressBar_GraphicChart()
            {
                //  if (chart_Components.Visible == false)
                //      return;

                if (_bindingSource_StockRoom.Count == 0)
                    return;

                if (!isProgressStarted_GraphicChart)
                {
                    easyProgressBar_GraphicChart.TextMessage = "Updating Graphic Chart.";
                    easyProgressBar_GraphicChart.Visible = true;
                    easyProgressBar_GraphicChart.Focus();
                    easyProgressBar_GraphicChart.Value = easyProgressBar_GraphicChart.Minimum;
                    easyProgressBar_GraphicChart.Maximum = _bindingSource_StockRoom.Count;

                    easyProgressBar_GraphicChart.ValueChanged += (thrower, ea) =>
                    {
                        if (easyProgressBar_GraphicChart.Value == easyProgressBar_GraphicChart.Maximum)
                            isProgressStarted_GraphicChart = false;
                    };

                    progressThread_GraphicChart = new Thread(new ParameterizedThreadStart(ProgressChannel_GraphicChart))
                    {
                        Name = "ProgressBar thread",
                        IsBackground = true
                    };

                    //      ParameterizedThreadClass pThread = new ParameterizedThreadClass(dataSet_SMT_Project.Tables["Table_Components"]);
                    ParameterizedThreadClassGraphic pThread = new ParameterizedThreadClassGraphic(_bindingSource_StockRoom);
                    progressThread_GraphicChart.Start(pThread);

                    // Set new value.
                    isProgressStarted_GraphicChart = true;

                    // Write log message.
                    //      status.Text = String.Format("Channel Started !!!, The {0} is started at {1:F}", progressThread.Name, DateTime.Now);

                    // Update button text.
                    //      button1.Text = "Stop";
                }
                else
                {
                    if (progressThread_GraphicChart.IsAlive)
                    {
                        easyProgressBar_GraphicChart.Visible = false;
                        _textMessage = "";

                        // Tell the progressThread to abort itself immediately, raises a ThreadAbortException in the progressThread after calling the Thread.Join() method.
                        progressThread_GraphicChart.Abort();

                        // Wait for the progressThread to finish.
                        progressThread_GraphicChart.Join();



                        // Update button text.
                        //     button1.Text = "Resume Progress";
                    }
                    isProgressStarted_GraphicChart = false;
                }
            }

            void EasyProgressBar_GraphicChart_MouseEnter(object sender, EventArgs e)
            {
                if (easyProgressBar_GraphicChart.AlphaMaker != null
                    && !easyProgressBar_GraphicChart.DockUndockProgressBar)
                {
                    easyProgressBar_GraphicChart.AlphaMaker.IFloatWindowControl = easyProgressBar_GraphicChart;
                    easyProgressBar_GraphicChart.AlphaMaker.SeekToOpacity(255);
                }

            }

            void EasyProgressBar_GraphicChart_MouseLeave(object sender, EventArgs e)
            {
                if (easyProgressBar_GraphicChart.AlphaMaker != null
                    && !easyProgressBar_GraphicChart.DockUndockProgressBar)
                {
                    if (!easyProgressBar_GraphicChart.ClientRectangle.Contains(easyProgressBar_GraphicChart.PointToClient(System.Windows.Forms.Cursor.Position)))
                    {
                        easyProgressBar_GraphicChart.AlphaMaker.IFloatWindowControl = easyProgressBar_GraphicChart;
                        easyProgressBar_GraphicChart.AlphaMaker.SeekToOpacity(180);
                    }
                    else
                    {
                        easyProgressBar_GraphicChart.AlphaMaker.IFloatWindowControl = easyProgressBar_GraphicChart;
                        easyProgressBar_GraphicChart.AlphaMaker.UpdateOpacity(255, true);
                    }
                }
            }

            void EasyProgressBar_GraphicChart_EasyProgressBarClosing(object sender, out bool cancel)
            {
                if (MessageBox.Show("Do you want to close the control window?", Application.ProductName,
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    cancel = true;
                else
                    cancel = false;
            }

            void ProgressChannel_GraphicChart(object instance)
            {
                if (instance is ParameterizedThreadClassGraphic pThread)
                {
                    try
                    {
                        Invoke(new EventHandler(delegate (object o, EventArgs e)
                     {
                         chart_Components.Series["Comp_for_Prod"].Points.Clear();
                         chart_Components.Series["Comp_On_Hand"].Points.Clear();
                         chart_Components.Annotations.Clear();

                         CurrentStatus currentStatus;

                         int _onAvailable = 0;
                         int _minQty = 0;

                         if (_rootNodeActive.Contains("Stock Room"))
                         {
                             #region"Stock Room"

                             for (int i = 0; i <= (pThread.RowCount - 1); i++)
                             {
                                 DataRowView rowsItems = (DataRowView)pThread.BindingComp[i];
                                 currentStatus = new CurrentStatus(rowsItems);

                                 try
                                 {
                                     _onAvailable = (int)rowsItems["OnAvailable"];

                                     _minQty = (int)rowsItems["MinQty"];
                                 }
                                 catch (Exception)
                                 {
                                     currentStatus.Selected = true;
                                     _onAvailable = 2;
                                     _minQty = 1;
                                     MessageBox.Show("Error in database information, Null, empty or wrong value has been found.", "Wrong value.",
                                                                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 }

                                 SortedDictionary<string, int> dict = MyCode.GetDict(rowsItems["Who_uses_this"].ToString());

                                 if (_onAvailable <= _minQty)
                                     currentStatus.Selected = true;

                                 chart_Components.Series["Comp_On_Hand"].Points.Add(new DataPoint(i, _onAvailable));
                                 chart_Components.Series["Comp_for_Prod"].Points.Add(new DataPoint(i, _minQty));

                                 chart_Components.Series["Comp_On_Hand"].Points[i].AxisLabel = rowsItems["PartNumber"].ToString();

                                 UpdateProgressBar_GraphicChart(i);
                             }

                             #endregion"Stock Room"
                         }
                         else
                         {
                             #region"By Products...."

                             string Active_Filter = pThread.BindingComp.Filter;

                             if (Active_Filter == null)
                                 return;

                             int _starIndex = Active_Filter.IndexOf('\'') + 1;
                             int _lengt = Active_Filter.LastIndexOf('\'') - _starIndex;

                             if (_lengt != -1)
                             {
                                 Active_Filter = Active_Filter.Substring(_starIndex, _lengt);
                             }

                             Active_Filter = Active_Filter.Replace("*", "");

                             for (int i = 0; i <= (pThread.RowCount - 1); i++)
                             {
                                 DataRowView rowsItems = (DataRowView)pThread.BindingComp[i];
                                 currentStatus = new CurrentStatus(rowsItems);

                                 //Set to false, no selected. If Qty to product change.
                                 currentStatus.UnSelect();

                                 string Who_uses_this = rowsItems["Who_uses_this"].ToString();
                                 if (string.IsNullOrEmpty(Who_uses_this))
                                 {
                                     UpdateProgressBar_GraphicChart(pThread.RowCount);
                                     break;
                                 }

                                 int OnAvailable = (int)rowsItems["OnAvailable"];
                                 int Comp_for_prod = 0;
                                 int pointValue = 0;
                                 int value = 0;

                                 SortedDictionary<string, int> dictWhoUsesThis = MyCode.GetDict(Who_uses_this);
                                 foreach (KeyValuePair<string, int> inf in dictWhoUsesThis)
                                 {
                                     if (!inf.Key.Contains(Active_Filter))
                                         continue;

                                     value += inf.Value;
                                 }

                                 Comp_for_prod = value * Prod_Projected;
                                 pointValue = Comp_for_prod + 1000;

                                 if (OnAvailable <= pointValue)
                                     pointValue = OnAvailable;

                                 int QtyNeeded = 0;
                                 if (OnAvailable <= Comp_for_prod)
                                 {
                                     currentStatus.Select();
                                     QtyNeeded = Comp_for_prod - OnAvailable;
                                 }

                                 chart_Components.Series["Comp_for_Prod"].Points.Add(new DataPoint(i, Comp_for_prod));
                                 chart_Components.Series["Comp_On_Hand"].Points.Add(new DataPoint(i, pointValue));

                                 chart_Components.Series["Comp_On_Hand"].Points[i].AxisLabel = rowsItems["PartNumber"].ToString();

                                 dataGridViewExtended.SetValueAt = "PartNumber/" + rowsItems["PartNumber"].ToString() + "/" + Comp_for_prod + "/" + QtyNeeded;

                                 rowsItems.EndEdit();
                                 UpdateProgressBar_GraphicChart(i);
                             }

                             #endregion"By Products...."
                         }

                         pThread.BindingComp.EndEdit();
                         UpdateProgressBar_GraphicChart(pThread.RowCount);
                     }));
                    }
                    catch (ThreadAbortException error)
                    {
                        // Write log message.
                        UpdateStatusBar_GraphicChart(string.Format("Channel Aborted !!!, The {0} is destroyed and stopped at {1:F}", Thread.CurrentThread.Name, DateTime.Now));

                        MessageBox.Show(new Form() { TopMost = true }, "Message related to this error is " + error.Message,
                                   "StockRoom Inventory progress channel has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            void UpdateStatusBar_GraphicChart(string statusText)
            {
                _ = statusText;
            }

            void UpdateProgressBar_GraphicChart(int currentValue)
            {
                if (currentValue == (easyProgressBar_GraphicChart.Maximum - 1))
                {
                    Invoke(new EventHandler(EasyProgressBar_GraphicChart_Hide));
                    return;
                }

                if (easyProgressBar_GraphicChart.InvokeRequired)
                    easyProgressBar_GraphicChart.Invoke(new SetProgressValue(UpdateProgressBar_GraphicChart), new object[] { currentValue });
                else
                {
                    easyProgressBar_GraphicChart.Value = currentValue;
                }
            }

            void EasyProgressBar_GraphicChart_Hide(object sender, EventArgs e)
            {
                isProgressStarted_GraphicChart = false;
                easyProgressBar_GraphicChart.Hide();
                _textMessage = "";

                dataGridViewExtended.Refresh();

                //  UpdateGraphicsChart();
            }

            #region"Class ParameterizedThreadClass"

            class ParameterizedThreadClassGraphic
            {
                readonly DataTable _tableComp;
                readonly BindingSource _bindingsource;
                readonly int minimum;
                readonly int maximum;
                readonly int progressValue;

                public ParameterizedThreadClassGraphic(DataTable tableComp)
                {
                    _tableComp = tableComp;
                }

                public ParameterizedThreadClassGraphic(BindingSource bindingsource)
                {
                    _bindingsource = bindingsource;
                }           

                public ParameterizedThreadClassGraphic(int minimum1, int maximum1, int progressValue1)
                {
                    minimum = minimum1;
                    maximum = maximum1;
                    progressValue = progressValue1;
                }

                public int Minimum
                {
                    get { return minimum; }
                }

                public int Maximum
                {
                    get { return maximum; }
                }

                public int ProgressValue
                {
                    get { return progressValue; }
                }

                public DataTable TableComp
                {
                    get { return _tableComp; }
                }

                public BindingSource BindingComp
                {
                    get { return _bindingsource; }
                }

                public int RowCount
                {
                    get
                    {
                        if (_tableComp != null)
                            return _tableComp.Rows.Count;

                        return _bindingsource.Count;
                    }
                }
            }

            #endregion"Class ParameterizedThreadClass"

            #endregion"InitEasyProgressBar_Updating Graphic Chart"

            #endregion"Tab_GraphicChart"

            #region"InitEasyProgressBar"

            EasyProgressBar.EasyProgressBar _easyProgressBar1;
            bool _isProgressStarted;
            Thread _progressThread;

            void InitEasyProgressBar()
            {
                _easyProgressBar1 = new EasyProgressBar.EasyProgressBar
                {
                    AlphaMaker = floatWindowAlphaMaker1
                };
                _easyProgressBar1.BackColor = System.Drawing.SystemColors.Window;
                _easyProgressBar1.BackgroundGradient.ColorStart = System.Drawing.Color.White;
                _easyProgressBar1.BackgroundGradient.IsBlendedForBackground = true;
                _easyProgressBar1.BorderColor = System.Drawing.Color.Gray;
                _easyProgressBar1.DigitBoxGradient.BorderColor = System.Drawing.Color.Silver;
                _easyProgressBar1.DigitBoxGradient.ColorEnd = System.Drawing.Color.AntiqueWhite;
                _easyProgressBar1.DigitBoxGradient.ColorStart = System.Drawing.Color.White;
                _easyProgressBar1.DigitBoxGradient.IsBlendedForBackground = true;
                _easyProgressBar1.DisplayFormat = "";
                _easyProgressBar1.Font = new Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                _easyProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                _easyProgressBar1.IsDigitDrawEnabled = false;
                _easyProgressBar1.Location = new Point(((ClientSize.Width / 2) - 300), ((ClientSize.Height / 2) + 30));
                _easyProgressBar1.Name = "easyProgressBar1";
                _easyProgressBar1.ProgressColorizer.Alpha = ((byte)(113));
                _easyProgressBar1.ProgressColorizer.Blue = ((byte)(140));
                _easyProgressBar1.ProgressColorizer.Green = ((byte)(200));
                _easyProgressBar1.ProgressColorizer.Red = ((byte)(230));
                _easyProgressBar1.ProgressGradient.ColorEnd = System.Drawing.Color.Wheat;
                _easyProgressBar1.ProgressGradient.ColorStart = System.Drawing.Color.WhiteSmoke;
                _easyProgressBar1.ProgressGradient.IsBlendedForProgress = true;
                _easyProgressBar1.Size = new Size(600, 65);
                _easyProgressBar1.TabIndex = 0;
                _easyProgressBar1.Text = "40% ";
                _easyProgressBar1.Value = 40;
                _easyProgressBar1.DockUndockProgressBar = false;
                _easyProgressBar1.Visible = false;
                _easyProgressBar1.EasyProgressBarClosed += new EventHandler(EasyProgressBar1_EasyProgressBarClosed);
                _easyProgressBar1.EasyProgressBarClosing += new EasyProgressBar.EasyProgressBar.EasyProgressBarClosingEventHandler(EasyProgressBar1_EasyProgressBarClosing);
                _easyProgressBar1.MouseEnter += new EventHandler(EasyProgressBar1MouseEnter);
                _easyProgressBar1.MouseLeave += new EventHandler(EasyProgressBar1MouseLeave);
                _easyProgressBar1.LostFocus += new EventHandler(EasyProgressBar1LostFocus);


            }

            void EasyProgressBar1LostFocus(object sender, EventArgs e)
            {
                _easyProgressBar1.Focus();
            }

            // Starts or stops the current progressThread.
            void Start_EasyProgressBar(object sender, EventArgs e)
            {
                if (!_isProgressStarted)
                {
                    _easyProgressBar1.TextMessage = _textMessage;
                    _easyProgressBar1.Visible = true;
                    _easyProgressBar1.Focus();
                    _easyProgressBar1.Value = _easyProgressBar1.Minimum;

                    _easyProgressBar1.ValueChanged += (thrower, ea) =>
                    {
                        if (_easyProgressBar1.Value == _easyProgressBar1.Maximum)
                        {
                            _isProgressStarted = false;

                            //                 status.Text = "Progress execution is completed";
                            //                 button1.Text = "Start New Progress";
                        }
                    };

                    _progressThread = new Thread(ProgressChannel)
                    {
                        Name = "ProgressBar thread",
                        IsBackground = true
                    };

                    var pThread = new ParameterizedThreadClass(_easyProgressBar1.Minimum, _easyProgressBar1.Maximum, _easyProgressBar1.Value);
                    _progressThread.Start(pThread);

                    // Set new value.
                    _isProgressStarted = true;

                    // Write log message.
                    //      status.Text = String.Format("Channel Started !!!, The {0} is started at {1:F}", progressThread.Name, DateTime.Now);

                    // Update button text.
                    //      button1.Text = "Stop";
                }
                else
                {
                    if (_progressThread.IsAlive)
                    {
                        _easyProgressBar1.Visible = false;
                        _textMessage = "";

                        // Tell the progressThread to abort itself immediately, raises a ThreadAbortException in the progressThread after calling the Thread.Join() method.
                        _progressThread.Abort();

                        // Wait for the progressThread to finish.
                        _progressThread.Join();

                        _isProgressStarted = false;

                        // Update button text.
                        //     button1.Text = "Resume Progress";
                    }
                }
            }

            void EasyProgressBar1MouseEnter(object sender, EventArgs e)
            {
                if (_easyProgressBar1.AlphaMaker != null
                    && !_easyProgressBar1.DockUndockProgressBar)
                {
                    _easyProgressBar1.AlphaMaker.IFloatWindowControl = _easyProgressBar1;
                    _easyProgressBar1.AlphaMaker.SeekToOpacity(255);
                }

            }

            void EasyProgressBar1MouseLeave(object sender, EventArgs e)
            {
                if (_easyProgressBar1.AlphaMaker != null
                    && !_easyProgressBar1.DockUndockProgressBar)
                {
                    if (!_easyProgressBar1.ClientRectangle.Contains(_easyProgressBar1.PointToClient(System.Windows.Forms.Cursor.Position)))
                    {
                        _easyProgressBar1.AlphaMaker.IFloatWindowControl = _easyProgressBar1;
                        _easyProgressBar1.AlphaMaker.SeekToOpacity(180);
                    }
                    else
                    {
                        _easyProgressBar1.AlphaMaker.IFloatWindowControl = _easyProgressBar1;
                        _easyProgressBar1.AlphaMaker.UpdateOpacity(255, true);
                    }
                }
            }

            void EasyProgressBar1_EasyProgressBarClosing(object sender, out bool cancel)
            {
                if (MessageBox.Show(@"Do you want to close the control window?", Application.ProductName,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    cancel = true;
                else
                    cancel = false;
            }

            void EasyProgressBar1_EasyProgressBarClosed(object sender, EventArgs e)
            {
                //  ToolStripItem item = menuStrip1.Items["OPEN"];
                //  if (item == null)
                //  {
                //      item = new ToolStripButton("OPEN: EasyProgressBar");
                //      item.Name = "OPEN";
                //      item.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
                //      item.ForeColor = Color.Maroon;

                //     item.Click += (thrower, ea) =>
                //     {
                //          easyProgressBar1.DockUndockProgressBar = true;
                //          item.Enabled = false;
                //      };

                //      menuStrip1.Items.Add(item);
                //  }
                //  else
                //      item.Enabled = true;
            }

            void ProgressChannel(object instance)
            {
                if (instance is ParameterizedThreadClass)
                {
                    var pThread = instance as ParameterizedThreadClass;

                    try
                    {
                        var startingValue = pThread.ProgressValue == pThread.Maximum ? pThread.Minimum : pThread.ProgressValue;
                        for (var i = startingValue + 1; i <= pThread.Maximum; i++)
                        {
                            UpdateProgressBar(i);
                            Thread.Sleep(100);
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        // Write log message.
                        UpdateStatusBar(string.Format("Channel Aborted !!!, The {0} is destroyed and stopped at {1:F}", Thread.CurrentThread.Name, DateTime.Now));
                    }
                }
            }

            void UpdateStatusBar(string statusText)
            {
                _= statusText;
            }

            void UpdateProgressBar(int currentValue)
            {
                if (currentValue == 100)
                    Invoke(new EventHandler(EasyProgressBar_Hide));

                if (_easyProgressBar1.InvokeRequired)
                    _easyProgressBar1.Invoke(new SetProgressValue(UpdateProgressBar), new object[] { currentValue });
                else
                {
                    _easyProgressBar1.Value = currentValue;

                }
            }

            void EasyProgressBar_Hide(object sender, EventArgs e)
            {
                _easyProgressBar1.Hide();
                _textMessage = "";
            }
        */
        #region "ParameterizedThreadClass"

        class ParameterizedThreadClass(int minimum1, int maximum1, int progressValue1)
        {
            #region Instance Members

            readonly int minimum = minimum1;
            readonly int maximum = maximum1;
            readonly int progressValue = progressValue1;

            #endregion
            #region Constructor

            #endregion

            #region Property

            public int Minimum
            {
                get { return minimum; }
            }

            public int Maximum
            {
                get { return maximum; }
            }

            public int ProgressValue
            {
                get { return progressValue; }
            }

            #endregion
        }

        #endregion "ParameterizedThreadClass"


        #endregion"InitEasyProgressBar"

        /*

       #region"Initialize ToolTip"

       readonly ToolTip toolTip = new ToolTip();
       void InitializeToolTip()
       {
           toolTip.IsBalloon = true;
           toolTip.AutomaticDelay = 0;
           toolTip.OwnerDraw = true;
           toolTip.ShowAlways = true;
           toolTip.UseAnimation = false;
           toolTip.UseFading = false;
           toolTip.Draw += ToolTipDraw;
       }

       // if toolTip.IsBalloon = true, toolTip_Draw never is called.
       void ToolTipDraw(object sender, System.Windows.Forms.DrawToolTipEventArgs e)
       {
           e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
           e.Graphics.DrawRectangle(Pens.Chocolate, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));
           e.Graphics.DrawString(toolTip.ToolTipTitle + e.ToolTipText, e.Font, Brushes.Red, e.Bounds);
       }

       #endregion"Initialize ToolTip"

       #region"ProcessCurrentEmployeesHasLogIn & CurrentEmployeesLogIn SaveUserSetting"

       UserSetting StockRoomSetting;
       void InitializeProcessUserHasLogIn()
       {
           StockRoomSetting = new UserSetting(splitContainerVertical.SplitterDistance, splitContainerHorizontal.SplitterDistance);
           ProcessCurrentEmployeesLogIn = new Action(ProcessUserSetting);
           InitializeSaveUserSettingTimer();
       }

       void ProcessUserSetting()
       {
           if (CurrentEmployeesLogIn.ContainsUserSetting("StockRoomSetting"))
           {
               StockRoomSetting = CurrentEmployeesLogIn.UserSettingList("StockRoomSetting");

               splitContainerVertical.SplitterDistance = StockRoomSetting.SplitterX;
               splitContainerHorizontal.SplitterDistance = StockRoomSetting.SplitterY;
           }
           else
           {
               StockRoomSetting = new UserSetting(splitContainerVertical.SplitterDistance, splitContainerHorizontal.SplitterDistance);
               CurrentEmployeesLogIn.SaveUserSetting("StockRoomSetting", StockRoomSetting);
           }
       }

       int _sec = 10;
       /// <summary>
       /// An interval of 10 seconds to save user setting if this is modifying the user interface.
       /// </summary>
       System.Windows.Forms.Timer SaveUserSettingTimer;

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
           SaveUserSettingTimer.Tick += new EventHandler(SaveUserSettingTick);
       }

       void SaveUserSetting()
       {
           SaveUserSettingTimer.Start();
           NeedSaveData = false;
           _sec = 10;

           On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  10 sec less to save dataGridViewSetting."));
       }

       void SaveUserSettingTick(object sender, EventArgs e)
       {
           _sec--;

           if (_sec > 0)
           {
               On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  " + _sec + " sec less to save dataGridViewSetting."));
               return;
           }

           SaveUserSettingTimer.Stop();

           if (CurrentEmployeesLogIn != null)
               CurrentEmployeesLogIn.SaveUserSetting(nameof(StockRoomSetting), StockRoomSetting);
           else
               On_SaveSetting(new SaveSettingEventArgs(nameof(StockRoomSetting), StockRoomSetting));

           On_StatusBarMessage(new StatusBarMessage_EventArgs("", ""));
       }
   */
        #endregion"ProcessCurrentEmployeesHasLogIn & CurrentEmployeesLogIn SaveUserSetting"        

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

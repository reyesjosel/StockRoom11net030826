using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Microsoft.Web.WebView2.Core;
using StockRoom11net.BlazorWebAssembly.Components.Pages;
using StockRoom11net.BlazorWebAssembly.Data;
using StockRoom11net.Controls;
using StockRoom11net.Controls.BindingSourceExt;
using StockRoom11net.Controls.DataGridViewExtend;
using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Controls.VisTimeLine;
using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using StockRoom11net.Properties;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using WinFormsUI.Docking;
using static StockRoom11net.Controls.Custom_Events_Args;
using static StockRoom11net.Controls.Utilities;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CellClick_EventArgs = StockRoom11net.Controls.Custom_Events_Args.CellClick_EventArgs;
using CellDoubleClick_EventArgs = StockRoom11net.Controls.Custom_Events_Args.CellDoubleClick_EventArgs;
using CurrentRowActive_EventArgs = StockRoom11net.Controls.Custom_Events_Args.CurrentRowActive_EventArgs;
using DataGridViewMouseEnterEventArgs = StockRoom11net.Controls.Custom_Events_Args.DataGridViewMouseEnterEventArgs;
using DataGridViewSort_EventArgs = StockRoom11net.Controls.Custom_Events_Args.DataGridViewSort_EventArgs;
using Refresh_Requested_EventArgs = StockRoom11net.Controls.Custom_Events_Args.Refresh_Requested_EventArgs;
using Save_Requested_EventArgs = StockRoom11net.Controls.Custom_Events_Args.Save_Requested_EventArgs;
using StatusBarMessage_EventArgs = StockRoom11net.Controls.Custom_Events_Args.StatusBarMessage_EventArgs;

namespace StockRoom11net
{
    public partial class TimeLineEditor : DockContent
    {
        #region "Properties"

        // Injected EF Core services
        private readonly IAppService _iappService;
        private readonly ITimeLineService _itimeLineService;
        private readonly ITableTimeLineService _itableTimeLineService;
        private readonly ITableTimeLineTreeViewService _itableTimeLineTreeViewService;
        private readonly IUnitOfWork _unitOfWork;
        
        // ✅ Updated to use scaffolded entity
        private BindingList<Table_TimeLine_TreeView> _timeLineTreeViewBindingList;

        // Declare as extended type
        public BindingSourceValidating<Table_TimeLine> _bindingSourceTimeLineVal;
        public BindingSourceValidating<Table_Base_TreeView> _bindingSourceTimeLineTreeViewVal;

        /// <summary>
        /// Gets or sets the debug message position.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MessageDebugPosition { get; set; } = string.Empty;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get
            {
                return Text;
            }
            set
            {
                Text = $"{value}";
            }
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
            get
            {
                return _employeesService;
            }
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
             //   splitContainerVertical.SplitterDistance = userSetting.SplitterVertical;
             //   splitContainerHorizontal.SplitterDistance = userSetting.SplitterHorizontal;
            }
        }

        #endregion"CurrentUserBroadcast"

        /// <summary>
        /// This flag is used to avoid the execution of SplitterMoved event during the initialization of the form, because
        /// at initialization we set the SplitterDistance according to the user setting, and we do not want to save the user
        /// setting at this moment, it is not a user action, it is just the application of the user setting.
        /// </summary>
        bool internalResizeEvent = false;
                
        // Parameterless constructor for designer
        [Obsolete("Use constructor with dependency injection")]
        public TimeLineEditor()
        {
            InitializeComponent();
        }

        // ✅ Constructor with DI
        public TimeLineEditor(ITableEmployeeService employeesService,
                              IAppService iappService,
                              ITimeLineService timeLineService,
                              ITableTimeLineService itableTimeLineService,
                              ITableTimeLineTreeViewService timeLineTreeViewService,
                              IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.Dpi;
            DockAreas = WinFormsUI.Docking.DockAreas.Document | WinFormsUI.Docking.DockAreas.Float;
            Title = "TimeLine Editor";

            _iappService = iappService ?? throw new ArgumentNullException(nameof(iappService));
            _itimeLineService = timeLineService ?? throw new ArgumentNullException(nameof(timeLineService));
            _itableTimeLineService = itableTimeLineService ?? throw new ArgumentNullException(nameof(itableTimeLineService));
            _itableTimeLineTreeViewService = timeLineTreeViewService ?? throw new ArgumentNullException(nameof(timeLineTreeViewService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            EmployeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService));            

            // Do NOT call InitializeTimeLineItems on Shown — the BlazorWebView has not rendered yet.
            // Instead, subscribe to TimelineReadyEvent which fires after timelineInterop.create() completes.
            _itimeLineService.TimelineReadyEvent += async () => await InitializeTimeLineItems();

            Name = "TimeLineEditor";
            dataGridViewExtended.Name = "DGVExt_TimeLine";
            // We need pass employeeService, at initialization we call currentEmployeeLogIn
            dataGridViewExtended.EmployeesService = EmployeesService;
            dataTreeViewToAdd_Cancel_Delete.EmployeesService = EmployeesService;

            // ✅ Pass unitOfWork to the EXISTING designer instance, don't replace it
            dataTreeViewToAdd_Cancel_Delete.SetUnitOfWork(_unitOfWork);

            InitializeBlazorWebView();
        }
                
        void InitializeBlazorWebView()
        {
            try
            {
                if (blazorWebView_TimeLine == null)
                {
                    MessageBox.Show(@"The BlazorWebView component is Null", @"Error on initialization",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                #region"BlazorWebView"

                var serviceCollection = new ServiceCollection();
                serviceCollection.AddWindowsFormsBlazorWebView();
                serviceCollection.AddSingleton<ITimeLineService>(_itimeLineService);
                serviceCollection.AddLogging(builder =>             // Add logging services and configure them
                {
                    builder.SetMinimumLevel(LogLevel.Information);  // Set a minimum log level
                    builder.AddConsole();                           // Add the Console logging provider
                    builder.AddDebug();                             // Add the Debug logging provider
                });

                // Build the service provider
                var serviceProvider = serviceCollection.BuildServiceProvider();

                // Get an ILogger instance
                var logger = serviceProvider.GetRequiredService<ILogger<TimeLineEditor>>();
                // Log a message
                logger.LogInformation("Application started.");

                // In constructor or TimeLineEditor_Load — NO async needed
                var userDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                                "StockRoom11net", "WebView2UserData");

                // Delete stale cache synchronously
                if (Directory.Exists(userDataFolder))
                {
                    try { Directory.Delete(userDataFolder, recursive: true); }
                    catch { /* non-fatal */ }
                }

                // Point the BlazorWebView's internal WebView2 at the fresh folder
                // MUST be set BEFORE the control is shown/rendered
                blazorWebView_TimeLine.WebView.CreationProperties =
                    new Microsoft.Web.WebView2.WinForms.CoreWebView2CreationProperties
                    {
                        UserDataFolder = userDataFolder
                    };

                blazorWebView_TimeLine.HostPage = "wwwroot\\index.html";
                blazorWebView_TimeLine.Services = serviceProvider;
                blazorWebView_TimeLine.RootComponents.Add<TimeLinePage>("#app");

                _itimeLineService.OpenDevToolsEvent += () =>
                {
                    blazorWebView_TimeLine.WebView.CoreWebView2.OpenDevToolsWindow();
                };
                
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error on initialization", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        async void TimeLineEditor_Load(object? sender, EventArgs e)
        {
            try
            {
                MessageDebugPosition = "InitializeProperties()";
                //InitializeProperties();
                                
                InitTabControlExtend();
                InitDataTreeViewTo();
                Initialize_DataGridView();

                // If we are here, the initialization is OK, we can load data aster the form is shown,
                // to avoid freeze of the form during loading and loose of events related to data processing,
                // like filtering with the treeView.               
                LoadDataEF();

                InitializeItimeLineServiceCallBackEvents();                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, @"Error on initialization", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
               
        void InitializeItimeLineServiceCallBackEvents()
        {
            _itimeLineService.OnSelectEvent = EventCallback.Factory.Create<string>(this, OnSelectedItem);
            _itimeLineService.OnMovedEvent = EventCallback.Factory.Create<TimeLineItem>(this, OnMoveItem);
        }

        void OnSelectedItem(string e)
        {
            foreach(DataRowView row in _bindingSourceTimeLineVal.List)
            {
                string id = row["ID"] is int idValue ? idValue.ToString() : row["ID"].ToString();
                if (id == e)
                {
                    _bindingSourceTimeLineVal.Position = _bindingSourceTimeLineVal.IndexOf(row);
                    break;
                }
            }
        }

        void OnMoveItem(TimeLineItem e)
        {
            var rowView = _bindingSourceTimeLineVal.List.OfType<DataRowView>()
                .FirstOrDefault(r => (r["ID"] is int id ? id.ToString() : r["ID"].ToString()) == e.Id);
            if (rowView != null)
            {
                rowView.BeginEdit();
                rowView["StartDate"] = e.Start.ToString("yyyy-MM-dd");
                rowView["EndDate"] = e.End?.ToString("yyyy-MM-dd");
                rowView.EndEdit();
            }
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
        async Task LoadTimeLineDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs("Loading TimeLine data..."));

                // ✅ Load DataTable convert to → DataView → BindingSource (supports .Filter)
                var dataTable = await _itableTimeLineService.LoadTimeLinesDataTableAsync();
                var dataView = new DataView(dataTable);

                // Create BindingSource
                _bindingSourceTimeLineVal = new BindingSourceValidating<Table_TimeLine>
                {
                    DataSource = dataView,
                    TableName = "Table_TimeLine",
                    Position = 0
                };

                // Bind to DataGridView
                dataGridViewExtended.DataSource = _bindingSourceTimeLineVal;


                _timeLineTreeViewBindingList = await _itableTimeLineTreeViewService.LoadTimelinesTreeViewAsync();

                if (HasCircularReference(_timeLineTreeViewBindingList))
                {
                    MessageBox.Show($"Error loading data: Circular reference detected in node ID: {nodeID}.",
                    "Data Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                // Create BindingSource for TreeView
                _bindingSourceTimeLineTreeViewVal = new BindingSourceValidating<Table_Base_TreeView>
                {
                    DataSource = _timeLineTreeViewBindingList,
                    TableName = "Table_TimeLine_TreeView",
                    Position = 0
                };
                dataTreeViewToAdd_Cancel_Delete.BindingSourceTreeView = _bindingSourceTimeLineTreeViewVal;

                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs($"Loaded {_timeLineTreeViewBindingList.Count} TimeLine records"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading TimeLine data: {ex.Message}", 
                    "Data Load Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
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
        
        #region"CustomTabControl"

        Plexiglass ShowResizeRectangle;
        void InitTabControlExtend()
        {
           
            splitContainer_Horizontal.SplitterWidth = 3;
            splitContainer_Vertical.SplitterWidth = 3;

            customTabControl_TimeLine.Alignment = TabAlignment.Bottom;

            customTabControl_TimeLine.MouseDownResizeGripEvent += CustomTabControl_TimeLine_MouseDownResizeGripEvent;
            customTabControl_TimeLine.MouseUpResizeGripEvent += customTabControl_TimeLine_MouseUpResizeGripEvent;
            customTabControl_TimeLine.ResizeGripEvent += customTabControl_TimeLine_ResizeGripEvent;            
        }

        void customTabControl_TimeLine_ResizeGripEvent(object sender, ResizeGrip_EventArgs e)
        {            
            ShowResizeRectangle.Location = new Point(ShowResizeRectangle.Location.X + e.X, ShowResizeRectangle.Location.Y);
            ShowResizeRectangle.ClientSize = new Size(ShowResizeRectangle.ClientSize.Width - e.X, ShowResizeRectangle.ClientSize.Height + e.Y);
        }

        void customTabControl_TimeLine_MouseUpResizeGripEvent(object sender, MouseEventArgs e)
        {
            ShowResizeRectangle.Close();

            splitContainer_Vertical.SplitterDistance = ShowResizeRectangle.Location.X;
            splitContainer_Horizontal.SplitterDistance = ShowResizeRectangle.Height;

            customTabControl_TimeLine.Visible = true;

            //  StockRoomSetting.SplitterVertical = splitContainerVertical.SplitterDistance;
            //  StockRoomSetting.SplitterHorizontal = splitContainerHorizontal.SplitterDistance;

            //  SaveUserSetting();
        }

        void CustomTabControl_TimeLine_MouseDownResizeGripEvent(object sender, MouseEventArgs e)
        {
            Point location = splitContainer_Vertical.SplitterRectangle.Location;
            Size sizeCon = splitContainer_Vertical.Panel2.ClientSize;
            var rectangleImage = (Bitmap)ScreenImage.GetScreenshot(Handle, location, sizeCon);

            ShowResizeRectangle = new Plexiglass(this)
            {
                ClientSize = sizeCon,
                RectImage = rectangleImage,
                Location = PointToScreen(location)
            };

            customTabControl_TimeLine.Visible = false;
        }

        void CustomTabControl_TimeLine_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (customTabControl_TimeLine.SelectedTab.Name == "tabPage_TimeLine")
            {
                action = new Action(() =>
                {
                    dataTreeViewToAdd_Cancel_Delete.ClosePanelSetting(false);
                });

                ThreadSafeInvoke(action);

                if(dataGridViewExtended.DataSource == _bindingSourceTimeLineTreeViewVal)
                    dataGridViewExtended.DataSource = _bindingSourceTimeLineVal;

                return;
            }

            if (customTabControl_TimeLine.SelectedTab.Name == "tabPage_DataTreeViewSetting")
            {
                InitializeNodeSettingTabPage();
                
                action = new Action(() =>
                {
                    dataTreeViewToAdd_Cancel_Delete.ClosePanelSetting(true);
                });

                ThreadSafeInvoke(action);

              //  dataTreeViewToAdd_Cancel_Delete.OlvDataTreeMaster_SelectedIndexChanged(sender, e);

              //  dataGridViewExtendedBase.CustomEdit = EditMode.Delete;
             //   dataGridViewExtended_TimeLineEditor.DataSource = _bindingSourceTimeLineTreeViewVal;
                return;
            }
        }

        #endregion"CustomTabControl"

        #region"NodeSettingTabPage"

        NodeSetting _nodeSetting;
        bool _nodeSettingIsDone = false;
        void InitializeNodeSettingTabPage()
        {
            if (_nodeSettingIsDone)
                return;

            _nodeSettingIsDone = true;

            _nodeSetting = new NodeSetting(_bindingSourceTimeLineTreeViewVal, _iappService.ColumnsCollection, _employeesService)
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
            
            tabPage_DataTreeViewSetting.Controls.Add(_nodeSetting);
        }

        void NodeSetting_NodeImageChange(object? sender, NodeSetting.NodeImageChange_EventArgs e)
        {
            _ = dataTreeViewToAdd_Cancel_Delete.InitializeImageListAsync();
        }

        void NodeSetting_StatusBarMessage(object? sender, StatusBarMessage_EventArgs e)
        {
            _iappService.On_StatusBarMessage(e);
        }

        async void NodeSetting_Save_Requested(object? sender, Save_Requested_EventArgs e)
        {
            if (_bindingSourceTimeLineTreeViewVal.TableName.Contains("Table_TimeLine_TreeView"))
            {
                await _unitOfWork.TableTimeLineTreeViewRepository.UpdateAsync((Table_TimeLine_TreeView)e.Item, CancellationToken.None);
            }
        }

        #endregion"NodeSettingTabPage"       

        #region"DataGridViewExtended"

        Table_TimeLine _currentRowViewActive;
        private void Initialize_DataGridView()
        {            
            dataGridViewExtended.SuspendLayout();
            
            dataGridViewExtended.CellBegingEditEvent    += DataGridViewExtendedInventoryCellBeggingEditEvent;
            dataGridViewExtended.CellEndEditEvent       += DataGridViewExtendedInventoryCellEndEditEvent;
            dataGridViewExtended.CellClickEvent         += DataGridViewExtended_TimeLine_CellClick_Event;
            dataGridViewExtended.CellDoubleClickEvent   += DataGridViewExtended_TimeLine_CellDoubleClick_Event;
            dataGridViewExtended.CurrentRowActivesEvent += DataGridViewExtendedInventoryCurrentRowActiveAsync;
            dataGridViewExtended.FindRemplace           += DataGridViewExtended_Inventory_Find_Replace;
            dataGridViewExtended.SaveRequested          += DataGridViewExtended_SaveRequested;
            dataGridViewExtended.RefreshRequested       += DataGridViewExtendedInventoryRefreshRequested;
            dataGridViewExtended.UserDeletingRow        += DataGridViewExtended_UserDeletingRow;
            dataGridViewExtended.UserDeletedRow         += DataGridViewExtendedInventoryUserDeletedRow;
            dataGridViewExtended.RowsRemoved            += DataGridViewExtendedInventoryRowsRemoved;
            dataGridViewExtended.DataGridViewMouseEnterEvent += DataGridViewExtendedInventoryMouseEnterEvent;
            dataGridViewExtended.DataGridViewSort       += DataGridViewExtendedInventoryDataGridViewSort;
            dataGridViewExtended.BindingNavigatorAddNewItemEvent += DataGridViewExtended_Inventory_AddNewItemEvent;

            dataGridViewExtended.StatusBarMessageEvent       += DataGridViewExtendedInventoryStatusBarMessage;
            dataGridViewExtended.LogFileMessage         += DataGridViewExtendedInventoryLogFileMessage;

            dataGridViewExtended.DataSource = _bindingSourceTimeLineVal;

            dataGridViewExtended._dataGridView.ReadOnly = false;
            dataGridViewExtended.CustomEdit = EditMode.Delete;

            dataGridViewExtended.ResumeLayout();
        }

        async void DataGridViewExtended_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow? ert = e.Row;
            if (ert == null)
                return;

            if (dataGridViewExtended.DataSource == _bindingSourceTimeLineVal)
            {

                Table_TimeLine? rowEntity = ert.DataBoundItem is DataRowView row
                    ? new Table_TimeLine
                    {
                        ID             = row["ID"] is int id ? id : Convert.ToInt32(row["ID"]),
                        StartDate      = row["StartDate"]?.ToString(),
                        StartTime      = row["StartTime"]?.ToString(),
                        EndDate        = row["EndDate"]?.ToString(),
                        EndTime        = row["EndTime"]?.ToString(),
                        DisplayDate    = row["DisplayDate"]?.ToString(),
                        HeadLine       = row["HeadLine"]?.ToString(),
                        ItemText       = row["ItemText"]?.ToString(),
                        Media          = row["Media"]?.ToString(),
                        MediaCredit    = row["MediaCredit"]?.ToString(),
                        MediaCaption   = row["MediaCaption"]?.ToString(),
                        MediaThumbnail = row["MediaThumbnail"]?.ToString(),
                        AltText        = row["AltText"]?.ToString(),
                        Type           = row["Type"]?.ToString(),
                        Group          = row["Group"]?.ToString(),
                        Background     = row["Background"]?.ToString()
                    }
                    : ert.DataBoundItem as Table_TimeLine;
                if (rowEntity == null)
                    return;

                await _unitOfWork.TableTimeLineRepository.DeleteAsync(rowEntity.ID, CancellationToken.None);
                _bindingSourceTimeLineVal.RemoveCurrent();
            }

            if (dataGridViewExtended.DataSource == _bindingSourceTimeLineTreeViewVal)
            {
                Table_TimeLine_TreeView? rowEntity = (Table_TimeLine_TreeView)ert.DataBoundItem;
                if (rowEntity == null)
                    return;

                await _unitOfWork.TableTimeLineTreeViewRepository.DeleteAsync(rowEntity.Index, CancellationToken.None);
                _bindingSourceTimeLineTreeViewVal.RemoveCurrent();
            }
        }

        /// <summary>
        /// Add new TimeLine itemEFtableTreeView
        /// </summary>
        async void DataGridViewExtended_Inventory_AddNewItemEvent(object? sender, EventArgs e)
        {
            try
            {
                _bindingSourceTimeLineVal.SuspendBinding();

                // ✅ Create new scaffolded entity
                var newTimeLine = new Table_TimeLine
                {
                  //  Index = await GetNextIndexAsync(),
                   // TextName = "NewNode",
                   // ParentId = null,
                  //  NodePdf = string.Empty,
                  //  NodePicture = string.Empty,
                  //  DescriptionShort = string.Empty,
                  //  DescriptionExpand = string.Empty,
                  //  Image = string.Empty,
                 //   StringFilter = string.Empty,
                 //   ItemCount = 0,
                 //   ItemOpen = false,
                  //  DateCreated = DateTime.Now,
                  //  CreatedBy = CurrentEmployeesLogIn.FullName,
                 //   Properties = string.Empty,
                //    MessageString = string.Empty,
                //    Status = "Active"
                };

                // Save to database
                var savedTimeLine = await _itableTimeLineService.CreateTimeLineAsync(newTimeLine);

                // Add to binding list
                _bindingSourceTimeLineVal.Add(savedTimeLine);

                _bindingSourceTimeLineVal.ResumeBinding();
                _bindingSourceTimeLineVal.ResetBindings(false);

                // ✅ Navigate to new itemEFtableTreeView
                int newItemIndex = _bindingSourceTimeLineVal.IndexOf(savedTimeLine);
                _bindingSourceTimeLineVal.Position = newItemIndex;

                // Focus the DataGridView
                if (dataGridViewExtended._dataGridView.Rows.Count > 0)
                {
                    var row = dataGridViewExtended._dataGridView.Rows[newItemIndex];
                    row.Selected = true;
                    dataGridViewExtended._dataGridView.CurrentCell = row.Cells[0];
                }

                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs(
                    $"New TimeLine itemEFtableTreeView created: {savedTimeLine.ItemText}"));
            }
            catch (Exception ex)
            {
                _bindingSourceTimeLineVal.ResumeBinding();
                MessageBox.Show($"Error adding new itemEFtableTreeView: {ex.Message}",
                    "Add Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        async void DataGridViewExtendedInventoryCellEndEditEvent(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Flush any pending cell edit to the DataView before reading values.
                // _currentRowViewActive is a snapshot taken at row-selection time and is stale here;
                // read the live DataRowView from the BindingSource instead.
                _bindingSourceTimeLineVal.EndEdit();

                if (_bindingSourceTimeLineVal.Current is not DataRowView row)
                    return;

                if (!DateTime.TryParse(row["StartDate"]?.ToString(), out DateTime start))
                    return;

                TimeLineItem itemToUpDate = new TimeLineItem
                {
                    Id      = row["ID"]?.ToString() ?? string.Empty,
                    Content = row["HeadLine"]?.ToString() ?? row["ItemText"]?.ToString() ?? string.Empty,
                    Start   = start,
                    End     = DateTime.TryParse(row["EndDate"]?.ToString(), out DateTime end) ? end : (DateTime?)null,
                    Title   = row["ItemText"]?.ToString()
                };

                _itimeLineService.UpDateItem(itemToUpDate);

            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase. StockRoom Inventory.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewExtendedInventoryCellBeggingEditEvent(object? sender, DataGridViewCellCancelEventArgs e)
        {
          
        }

        private void DataGridViewExtendedInventoryLogFileMessage(object? sender, LogFileMessageEventArgs e)
        {
            _iappService.On_LogFileMessage(e);
        }

        private void DataGridViewExtendedInventoryDataGridViewSort(object? sender, DataGridViewSort_EventArgs e)
        {
            //   if (chart_Components.Visible)
            //       Start_EasyProgressBar_GraphicChart();
        }

        private void DataGridViewExtendedInventoryStatusBarMessage(object? sender, StatusBarMessage_EventArgs e)
        {
             _iappService.On_StatusBarMessage(e);
        }

        private void DataGridViewExtended_TimeLine_CellClick_Event(object? sender, CellClick_EventArgs e)
        {
          //  _currentColumnActive = _currentRowViewActive.DataView.Table.Columns[e.ColumnIndex];
        }

        private void DataGridViewExtended_TimeLine_CellDoubleClick_Event(object? sender, CellDoubleClick_EventArgs e)
        {
            /*
            if (CurrentEmployeesLogIn.IsUser)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/

          //  if (_currentRowViewActive == null)
          //      return;

            //On_CellDoubleClick_Event(e);
        }

        void DataGridViewExtendedInventoryCurrentRowActiveAsync(object? sender, CurrentRowActive_EventArgs e)
        {
            try
            {
                if(!dataGridViewExtended.ClientRectangle.Contains(dataGridViewExtended.PointToClient(Cursor.Position)))
                    return;

                if (_bindingSourceTimeLineVal.Current is not DataRowView row)
                    return;

                if (!DateTime.TryParse(row["StartDate"]?.ToString(), out DateTime start))
                    return;

                TimeLineItem itemToUpDate = new TimeLineItem
                {
                    Id = row["ID"]?.ToString() ?? string.Empty,
                    Content = row["HeadLine"]?.ToString() ?? row["ItemText"]?.ToString() ?? string.Empty,
                    Start = start,
                    End = DateTime.TryParse(row["EndDate"]?.ToString(), out DateTime end) ? end : (DateTime?)null,
                    Title = row["ItemText"]?.ToString()
                };

                _itimeLineService.SelectItem(JsonSerializer.Serialize(itemToUpDate));

            }
            catch (Exception ex)
            {
                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs(@"Error al tratar de salvar la DataBase" + ex.Message));
            }
        }

        private void DataGridViewExtended_Inventory_Find_Replace(object? sender, DataGridViewExtended.FindRemplaceEventArgs e)
        {

        }

        async void DataGridViewExtended_SaveRequested(object? sender, Save_Requested_EventArgs e)
        {
            if (dataGridViewExtended.DataSource == _bindingSourceTimeLineTreeViewVal)
            {
                if (e.DirtyDataGridViewIndexes.Count == 0)
                {
                    dataGridViewExtended.SavedRequestedDone();
                    return;
                }

                // Force-commit any cell still in edit mode before reading values.
                _bindingSourceTimeLineTreeViewVal.EndEdit();

                // Collect only the rows that were actually changed.
                var dirtyItems = _bindingSourceTimeLineTreeViewVal
                    .GetAllItems()
                    .OfType<Table_TimeLine_TreeView>()
                    .Where(item => e.DirtyDataGridViewIndexes.Contains(item.Index))
                    .ToList();

                try
                {
                    foreach (var item in dirtyItems)
                        await _unitOfWork.TableTimeLineTreeViewRepository.UpdateAsync(item, CancellationToken.None);

                    dataGridViewExtended.SavedRequestedDone();
                    _bindingSourceTimeLineTreeViewVal.ResetDirtyFlag();
                }
                catch (Exception ex)
                {
                    MessageDebugPosition = $"SaveRequested (TimeLineTreeView) error: {ex.Message}";
                    // dataGridViewExtended.DirtyDataGridViewIndexes intentionally NOT cleared — retry is still possible.
                    throw;
                }
            }

            if (dataGridViewExtended.DataSource == _bindingSourceTimeLineVal)
            {
                if (e.DirtyDataGridViewIndexes.Count == 0)
                {
                    dataGridViewExtended.SavedRequestedDone();
                    return;
                }

                // Force-commit any cell still in edit mode before reading values.
                _bindingSourceTimeLineVal.EndEdit();

                // Collect only the rows that were actually changed.
                var dirtyItems = _bindingSourceTimeLineVal
                    .GetItems()
                    .OfType<Table_TimeLine>()
                    .Where(item => e.DirtyDataGridViewIndexes.Contains(item.ID))
                    .ToList();

                try
                {
                    foreach (var item in dirtyItems)
                        await _unitOfWork.TableTimeLineRepository.UpdateAsync(item, CancellationToken.None);

                    dataGridViewExtended.SavedRequestedDone();
                    _bindingSourceTimeLineVal.ResetDirtyFlag();
                }
                catch (Exception ex)
                {
                    MessageDebugPosition = $"SaveRequested (TimeLine) error: {ex.Message}";
                    // dataGridViewExtended.DirtyDataGridViewIndexes intentionally NOT cleared — retry is still possible.
                    throw;
                }
            }
        }

        private void DataGridViewExtendedInventoryRefreshRequested(object? sender, Refresh_Requested_EventArgs e)
        {
         //   if (_currentRowViewActive == null)
         //       On_Refresh_Requested(new Refresh_Requested_EventArgs("ID Like 'Is Not Null'"));
         //   else
         //   {
                //   if (_currentFocusedNodeproperties == null)
                //       On_Refresh_Requested(new Refresh_Requested_EventArgs("ID Like 'Is Not Null'"));
                //   else
                //       On_Refresh_Requested(new Refresh_Requested_EventArgs(_currentFocusedNodeproperties.StringFilter));
          //  }
        }

        private void DataGridViewExtendedInventoryUserDeletedRow(object? sender, DataGridViewRowEventArgs e)
        {
            if(e.Row.Cells[0].Value == null)
            {
                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs("Error in row information."));
                return;
            }

            if (!e.Row.Cells[0].Value.ToString().Contains('-'))
            {
                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs("Error in row information."));
                return;
            }

            string filePath = Settings.Default.DataBaseAddress + "\\Pictures\\" + e.Row.Cells[0].Value.ToString() + ".JPG";

            if (!File.Exists(filePath))
            {
                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs("No Pictures file was found."));
                return;
            }

            string[] source = new string[1];
            source[0] = filePath;

             Controls.ShellBasics.ShellFileOperation fo = new Controls.ShellBasics.ShellFileOperation();

            fo.Operation = StockRoom11net.Controls.ShellBasics.ShellFileOperation.FileOperations.FO_DELETE;
            fo.OwnerWindow = this.Handle;
            fo.SourceFiles = source;

            if (fo.DoOperation())
                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs("Pictures file was found and deleted."));
            else
                MessageBox.Show("Pictures file was found, but unable to be deleted.");

            //*****************************************************************************************************************

            string description = "The component " + e.Row.Cells[0].Value.ToString() + " has been deleted.";

            _iappService.On_NotificationsToSends(new Notification(
                                                     "DataBase hass change.",                            //notification.Text
                                                     "Warning, DataBase change.",                        //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)NotificationEvents.RowRemoved,          //notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName + ";",   //notification.String_Filter
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     Table_Employee.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        private void DataGridViewExtendedInventoryRowsRemoved(object? sender, DataGridViewRowsRemovedEventArgs e)
        {
            //*****************************************************************************************************************

            string description = "The component " + "" + " has been removed.";

            _iappService.On_NotificationsToSends(new Notification(
                                                     "DataBase has been change.",                        //notification.Text
                                                     "Warning, DataBase change.",                        //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)NotificationEvents.RowRemoved,          //notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName + ";",   //notification.String_Filter
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     Table_Employee.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        private void DataGridViewExtendedInventoryMouseEnterEvent(object? sender, DataGridViewMouseEnterEventArgs e)
        {
            dataGridViewExtended._dataGridView.Focus();

            if (e.CurrentRowActive == null)
                return;

            if (e.CurrentRowActive.Index == -1)
                return;

            if (e.CurrentRowActive.Cells["ID"].Value == null)
                return;

          //  _currentRowViewActive = (DataRowView)e.CurrentRowActive.DataBoundItem;

        }

        #endregion"DataGridViewExtended"

        #region"DataTreeViewToAdd_Cancel_Delete"

        void InitDataTreeViewTo()
        {
            dataTreeViewToAdd_Cancel_Delete.Switch_DataTable += DataTreeViewToAdd_Cancel_Delete_Switch_DataTable; ;
        }

        void DataTreeViewToAdd_Cancel_Delete_Load(object sender, EventArgs e)
        {
         //   dataTreeViewToAdd_Cancel_Delete.BindingSourceTreeView = BindingSourceTimeLineTreeView;
        }

        void DataTreeViewToAdd_Cancel_Delete_SelectedIndexChanged(object sender, TreeViewSelectedIndexChangedEventArgs e)
        {
            #region"tabPage_DataTreeViewSetting"

            if (_nodeSettingIsDone & customTabControl_TimeLine.SelectedTab.Name == "tabPage_DataTreeViewSetting")
            {
                _nodeSetting.CurrentNode = e.CurrentNode;
            }

            #endregion"tabPage_DataTreeViewSetting"
        }

        void DataTreeViewToAdd_Cancel_Delete_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            try
            {
                //On_Save_Requested(e);

                _iappService.On_NotificationsToSends(new Notification(
                                                     "DataBase has been updated.",                       // 0 notification.Text
                                                     "Warning, DataBase updated.",                       // 1 notification.Title
                                                     "The database has been updated by an user.",        // 2 notification.Description
                                                     (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                                     (int)NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName,         // 5 notification.String_Filter
                                                     DateTime.Now,                                       // 6 notification.DateCreated
                                                     Table_Employee.FullName,                     // 7 notification.Created_by
                                                     "properties",                                       // 8 notification.Properties
                                                     "Status"                                            // 9 notification.Status
                                                    ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase. StockRoom Inventory.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        async void DataTreeViewToAdd_Cancel_Delete_ToolStripMenuItemClick(object sender, ToolStripMenuItemClickEventArgs e)
        {
            try
            {
                if (e.ItemClicked.Name == "toolStripMenuItem_TimeLine")
                {
                    //await BuiltTimeLineItems();
                    await InitializeTimeLineItems();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error updating timeline", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Callback method from TimeLineComp.razor, OnAfterRenderAsync(bool firstRender) indicates that the JS interop is ready,
        /// so we can now initialize the timeline items.
        /// </summary>
        /// <returns></returns>
        async Task InitializeTimeLineItems()
        {
            try
            {
                // Build vis-timeline items from the already-loaded DataView.
                // Table_TimeLine.StartDate / EndDate are stored as strings, so parse them.
                var dataView = _bindingSourceTimeLineVal?.DataSource as DataView;
                if (dataView == null) return;

                int _id = GetNextId(dataView);

                List<TimeLineItem> visItems = new List<TimeLineItem>();
                foreach (DataRowView row in dataView)
                {
                    if (!DateTime.TryParse(row["StartDate"]?.ToString(), out DateTime start))
                        continue;

                    visItems.Add(new TimeLineItem
                    {
                        Id = row["ID"]?.ToString() ?? ID.ToString(),
                        Content = row["HeadLine"]?.ToString() ?? row["ItemText"]?.ToString() ?? string.Empty,
                        Start = start,
                        End = DateTime.TryParse(row["EndDate"]?.ToString(), out DateTime end) ? end : null,
                        Title = row["ItemText"]?.ToString(),
                        Editable = new TimeLineItemEditableOptions
                        {
                            UpdateTime = true,
                            UpdateGroup = true,
                            Remove = true
                        },
                        Type = Enum.TryParse<TimeLineTypeEnum>(row["Type"]?.ToString()?.ToLower(), out var type) ? type.ToString() : TimeLineTypeEnum.box.ToString()
                    });
                }

                // InitialDataJson = JsonSerializer.Serialize(visItems);

                // OnItemsClassName(visItems);       // Construct timeline items with class names and serialize to JSON
                OnHTMLContents(visItems);           // Construct HTML content for timeline items and serialize to JSON

                // TODO: Consider using a more robust mechanism to ensure that the JS interop is ready before calling InitializeData.
                await Task.Delay(300);              // Wait for the JS interop to be ready before calling InitializeData
                                                    // 155ms is the minimun delay where the JS interop is ready, but 300ms
                                                    // is a safe delay to ensure the JS interop is ready, but you can adjust
                                                    // this value based on your application's performance and responsiveness.
                                                    
                await _itimeLineService.InitializeData(InitialDataJson);
            }
            catch (JSException ex)
            {
                // JS interop error — swallow safely, items were already pushed to the DataSet
                Debug.WriteLine($"[InitializeTimeLineItems] JSException: {ex.Message}");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error updating timeline", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async Task BuiltTimeLineItems()
        {
            try
            {
                // Build vis-timeline items from the already-loaded DataView.
                // Table_TimeLine.StartDate / EndDate are stored as strings, so parse them.
                var dataView = _bindingSourceTimeLineVal?.DataSource as DataView;
                if (dataView == null) return;

                int _id = GetNextId(dataView);

                List<TimeLineItem> visItems = new List<TimeLineItem>();
                foreach (DataRowView row in dataView)
                {
                    if (!DateTime.TryParse(row["StartDate"]?.ToString(), out DateTime start))
                        continue;

                    visItems.Add(new TimeLineItem
                    {
                        Id = row["ID"]?.ToString() ?? ID.ToString(),
                        Content = row["HeadLine"]?.ToString() ?? row["ItemText"]?.ToString() ?? string.Empty,
                        Start = start,
                        End = DateTime.TryParse(row["EndDate"]?.ToString(), out DateTime end) ? end : null,
                        Title = row["ItemText"]?.ToString(),
                        Editable = new TimeLineItemEditableOptions
                        {
                            UpdateTime = true,
                            UpdateGroup = true,
                            Remove = true
                        },
                        Type = Enum.TryParse<TimeLineTypeEnum>(row["Type"]?.ToString()?.ToLower(), out var type) ? type.ToString() : TimeLineTypeEnum.box.ToString()
                    });
                }

                //InitialDataJson = JsonSerializer.Serialize(visItems);

                //OnItemsClassName(visItems);       // Construct timeline items with class names and serialize to JSON
                OnHTMLContents(visItems);           // Construct HTML content for timeline items and serialize to JSON
                _itimeLineService.UpDateTimeLine(InitialDataJson);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error updating timeline", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int _nextId = 100; // Initialize the next ID for timeline items
        int ID
        {
            get {
                    _nextId++;
                return _nextId;
                }
            set { _nextId = value; }
        }

        int GetNextId(DataView dataView)
        {
            // We ask per the lastID just before used.
            if (dataView.Count > 0)
                _nextId = (int)(dataView?.Table?.Compute("MAX(ID)", "ID is Not null") ?? 100);
           
            return _nextId;
        }

        /// <summary>
        /// Gets the initial data in JSON format for the timeline items.
        /// This property holds the JSON string for the frontend.
        /// </summary>
        public string InitialDataJson { get; private set; } = "[]";

        /// <summary>
        /// Constructs a list of timeline items with class names and serializes it to JSON for use in the frontend.
        /// Each timeline item is associated with a different CSS class for styling.
        /// Seven timeline items are created, each with a different class name.
        /// </summary>
        void OnItemsClassName(List<TimeLineItem>? items)
        {
            // Item class names
            // Example: C# data for a vis.js Timeline or Network
            List<TimeLineItem> myItems = new List<TimeLineItem>
            {
                new TimeLineItem { Id = ID.ToString(), Content = "Task A", ClassName = ""    , Start = DateTime.Parse("2026-06-27") },
                new TimeLineItem { Id = ID.ToString(), Content = "Task B", ClassName = ""    , Start = DateTime.Parse("2026-06-28") },
                new TimeLineItem { Id = ID.ToString(), Content = "Task C", ClassName = ""    , Start = DateTime.Parse("2026-06-29") },
                new TimeLineItem { Id = ID.ToString(), Content = "green", ClassName = "green", Start = DateTime.Parse("2026-06-30") },
                new TimeLineItem { Id = ID.ToString(), Content = "red", ClassName = "red"    , Start = DateTime.Parse("2026-07-01") },
                new TimeLineItem { Id = ID.ToString(), Content = "orange", ClassName = "orange", Start = DateTime.Parse("2026-07-02") },
                new TimeLineItem { Id = ID.ToString(), Content = "magenta", ClassName = "magenta", Start = DateTime.Parse("2026-07-03") }
            };

            if (items != null)
            {
                items.AddRange(myItems);
            }
            else
            {
                items = myItems;
            }

            // Serialize to JSON
            InitialDataJson = JsonSerializer.Serialize(items);

        }

        /// <summary>
        /// Constructs HTML content for timeline items and serializes it to JSON for use in the frontend.
        /// Seven timeline items are created, each with different HTML content, including text, images,
        /// classNames and links.
        /// </summary>
        void OnHTMLContents(List<TimeLineItem>? items)
        {
            // ✅ Build the HTML content as a C# string instead
            string item1 = "<div>Your content here</div>";

            // ✅ More complex example matching your timeline use case """<div>item2<br>
            string item2 = """<div>item2<img src="/Resources/img/Flag_Red.png" width="22"/></div>""";

            // ✅ Then assign it to the TimeLineItem
            TimeLineItem itemToUpDate = new TimeLineItem
            {
                //Id = row["ID"] is int id ? id : Convert.ToInt32(row["ID"]),
                Content = item1,   // ← HTML string rendered directly by vis.js
             };

            // ✅ Option 2 — C# 11 raw string literal (no escaping needed)
            string item6 = """item6<br><img src="/Resources/img/Flag_Blue.png" width="22"/>""";

            string item7 = """item7<br><a href="https://visjs.org" target="_blank">click here</a>""";
                        
            List<TimeLineItem> myItems = new List<TimeLineItem>
            {
                new TimeLineItem { Id = ID.ToString(), Content = item1, ClassName = ""    , Start = DateTime.Parse("2026-06-27") },
                new TimeLineItem { Id = ID.ToString(), Content = item2, ClassName = ""    , Start = DateTime.Parse("2026-06-28") },
                new TimeLineItem { Id = ID.ToString(), Content = item6, ClassName = ""    , Start = DateTime.Parse("2026-06-29") },
                new TimeLineItem { Id = ID.ToString(), Content = "green", ClassName = "green", Start = DateTime.Parse("2026-06-30") },
                new TimeLineItem { Id = ID.ToString(), Content = "red", ClassName = "red"    , Start = DateTime.Parse("2026-07-01") },
                new TimeLineItem { Id = ID.ToString(), Content = "orange", ClassName = "orange", Start = DateTime.Parse("2026-07-02") },
                new TimeLineItem {
                Id = ID.ToString(), // "font-size: 18px;" maximum font size for the label, but can be adjusted down.
                Content = """
                            <div style="font-size:14px; font-weight:bold;">
                            <img src="/Resources/img/Flag_Green.png" width="12"/> My Label</div>
                          """,
                ClassName = "magenta",
                Start = DateTime.Parse("2026-07-03"),
                End = DateTime.Parse("2026-07-05"),
                Style = "height: 20px;" +
                         "line-height: 5px;",    // = height → vertically centered
                Type = TimeLineTypeEnum.range.ToString()
                }
            };

            if (items != null)
            {
                items.AddRange(myItems);
            }
            else
            {
                items = myItems;
            }

            // Serialize to JSON
            InitialDataJson = JsonSerializer.Serialize(items);
        }


        private void DataTreeViewToAdd_Cancel_Delete_Switch_DataTable(object sender, Switch_DataTable_EventArgs e)
        {
            if (dataGridViewExtended.DataSource == _bindingSourceTimeLineVal)
                dataGridViewExtended.DataSource = _bindingSourceTimeLineTreeViewVal;
            else
                dataGridViewExtended.DataSource = _bindingSourceTimeLineVal;

            // SettingMode = true;
        }

        #endregion"DataTreeViewToAdd_Cancel_Delete"    

        /// <summary>
        /// The action to execute.<br/>
        /// <code>
        /// var action = new Action(() => <br/>
        /// { <br/>
        ///     Call some method here, or execute some code, for example: <br/>
        ///     SettingMode = !_settingMode; <br/>
        /// }); <br/>
        /// </code>
        /// </summary>
        public Action action;

        /// <summary>
        /// Executes the specified action on the appropriate thread, marshaling to the UI thread if necessary.
        /// </summary>
        /// <remarks>Ensures thread-safe execution by automatically marshaling the call to the UI thread
        /// when invoked from a worker thread.</remarks>
        /// <param name="action">The action to execute.</param>
        public void ThreadSafeInvoke(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action?.Invoke();
            }
        }
    }
}

using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StockRoom11net.BlazorWebAssembly.Components.Pages;
using StockRoom11net.BlazorWebAssembly.Data;
using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using StockRoom11net.Controls;
using System.ComponentModel;
using System.Data;
using static StockRoom11net.Controls.Utilities;
using CellClick_EventArgs = StockRoom11net.Controls.Custom_Events_Args.CellClick_EventArgs;
using CellDoubleClick_EventArgs = StockRoom11net.Controls.Custom_Events_Args.CellDoubleClick_EventArgs;
using CurrentRowActive_EventArgs = StockRoom11net.Controls.Custom_Events_Args.CurrentRowActive_EventArgs;
using DataGridViewMouseEnterEventArgs = StockRoom11net.Controls.Custom_Events_Args.DataGridViewMouseEnterEventArgs;
using DataGridViewSort_EventArgs = StockRoom11net.Controls.Custom_Events_Args.DataGridViewSort_EventArgs;
using Refresh_Requested_EventArgs = StockRoom11net.Controls.Custom_Events_Args.Refresh_Requested_EventArgs;
using Save_Requested_EventArgs = StockRoom11net.Controls.Custom_Events_Args.Save_Requested_EventArgs;
using StatusBarMessage_EventArgs = StockRoom11net.Controls.Custom_Events_Args.StatusBarMessage_EventArgs;
using static StockRoom11net.Controls.Custom_Events_Args;
using StockRoom11net.Controls.DataGridViewExtend;
using StockRoom11net.Controls.BindingSourceExt;
using StockRoom11net.Properties;

namespace StockRoom11net
{
    public partial class TimeLineEditor : BaseTemple
    {
        #region "Properties"

        // Injected EF Core services
        private readonly ITableTimeLineService _timeLineService;
        private readonly ITableTimeLineTreeViewService _timeLineTreeViewService;
        private readonly IUnitOfWork _unitOfWork;
        
        // ✅ Updated to use scaffolded entity
        private BindingList<Table_TimeLine> _timeLineBindingList;
        private BindingList<Table_TimeLine_TreeView> _timeLineTreeViewBindingList;

        // Declare as extended type
        public BindingSourceValidating<Table_TimeLine> _bindingSourceTimeLineVal;
        public BindingSourceValidating<Table_Base_TreeView> _bindingSourceTimeLineTreeViewVal;

        BindingSource _bindingSourceTimeLine;
        BindingSource _bindingSourceTimeLineTreeView;

        DataColumnCollection _stockroomColumns;

        readonly AppState _appState = new();
        readonly AppService _appService = new();

        #endregion

        // Parameterless constructor for designer
        [Obsolete("Use constructor with dependency injection")]
        public TimeLineEditor()
        {
            InitializeComponent();
        }

        // ✅ Constructor with DI
        public TimeLineEditor(ITableTimeLineService timeLineService,
                              ITableTimeLineTreeViewService timeLineTreeViewService,
                              IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _timeLineService = timeLineService ?? throw new ArgumentNullException(nameof(timeLineService));
            _timeLineTreeViewService = timeLineTreeViewService ?? throw new ArgumentNullException(nameof(timeLineTreeViewService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            
            Name = "TimeLineEditor";

            // ✅ Pass unitOfWork to the EXISTING designer instance, don't replace it
            dataTreeViewToAdd_Cancel_Delete.SetUnitOfWork(_unitOfWork);

            InitializeBlazorWebView();

            LoadDataEF();
        }

        private void InitializeBlazorWebView()
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

                blazorWebView_TimeLine.HostPage = "wwwroot\\index.html";
                //  blazorWebView_TimeLine.HostPage = Path.Combine(Path.GetDirectoryName(Environment.ProcessPath), "wwwroot\\index.html");
                blazorWebView_TimeLine.Services = serviceProvider;
                blazorWebView_TimeLine.RootComponents.Add<TimeLinePage>("#app");

                AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
                {
                    //#if DEBUG
                    MessageBox.Show(text: error.ExceptionObject.ToString(), caption: "Error");
                    //#else
                    //    MessageBox.Show(text: "An error has occurred.", caption: "Error");
                    //#endif
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
                InitializeProperties();
                                
                InitTabControlExtend();
                InitDataTreeViewTo();
                Initialize_DataGridView();                                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, @"Error on initialization", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private async Task LoadTimeLineDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                StatusBarMessage(new StatusBarMessage_EventArgs("Loading TimeLine data..."));

                // ✅ Load data from database
                _timeLineBindingList = await _timeLineService.LoadTimelinesAsync();

                // ✅ Convert to DataTable → DataView → BindingSource (supports .Filter)
                var dataTable = _timeLineBindingList.ToDataTable();
                var dataView = new DataView(dataTable);

                // Create BindingSource
                _bindingSourceTimeLine = new BindingSourceValidating<Table_TimeLine>
                {
                    DataSource = dataView,
                    TableName = "Table_TimeLine",
                    Position = 0
                };

                // Bind to DataGridView
                dataGridViewExtended_TimeLineEditor.DataSource = _bindingSourceTimeLine;


                _timeLineTreeViewBindingList = await _timeLineTreeViewService.LoadTimelinesTreeViewAsync();

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
                //dataTreeViewToAdd_Cancel_Delete.SetDataSource(_timeLineTreeViewBindingList);

                StatusBarMessage(new StatusBarMessage_EventArgs(
                    $"Loaded {_timeLineBindingList.Count} TimeLine records"));
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



        /// <summary>
        /// Get next available index
        /// </summary>
        private async Task<int> GetNextIndexAsync()
        {
            try
            {
                if (_timeLineBindingList.Count == 0)
                    return 1;

                int maxId = _timeLineBindingList.Max(t => t.ID);
                return maxId + 1;
            }
            catch
            {
                return _timeLineBindingList.Count + 1;
            }
        }

        /// <summary>
        /// Save changes to database
        /// </summary>
        private async Task SaveTimeLineAsync(Table_TimeLine timeLine)
        {
            try
            {
                if (timeLine.ID == 0) // New item
                {
                    await _timeLineService.CreateTimeLineAsync(timeLine);
                }
                else // Update existing
                {
                    await _timeLineService.UpdateTimeLineAsync(timeLine);
                }

                StatusBarMessage(new StatusBarMessage_EventArgs("Saved successfully"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving: {ex.Message}", 
                    "Save Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete TimeLine item
        /// </summary>
        private async Task DeleteTimeLineAsync(int id)
        {
            try
            {
                var result = MessageBox.Show(
                    "Are you sure you want to delete this TimeLine item?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _timeLineService.DeleteTimeLineAsync(id);
                    
                    // Remove from binding list
                    var itemToRemove = _timeLineBindingList.FirstOrDefault(t => t.ID == id);
                    if (itemToRemove != null)
                    {
                        _timeLineBindingList.Remove(itemToRemove);
                        _bindingSourceTimeLine.ResetBindings(false);
                    }

                    StatusBarMessage(new StatusBarMessage_EventArgs("TimeLine deleted successfully"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting: {ex.Message}", 
                    "Delete Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
        }

        void InitializeProperties()
        {
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

            //  StockRoomSetting.SplitterX = splitContainerVertical.SplitterDistance;
            //  StockRoomSetting.SplitterY = splitContainerHorizontal.SplitterDistance;

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

                if(dataGridViewExtended_TimeLineEditor.DataSource == _bindingSourceTimeLineTreeView)
                    dataGridViewExtended_TimeLineEditor.DataSource = _bindingSourceTimeLine;

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

              //  dataTreeViewToAdd_Cancel_Delete.OlvDataTree_SelectedIndexChanged(sender, e);

              //  dataGridViewExtendedBase.CustomEdit = EditMode.Delete;
             //   dataGridViewExtended_TimeLineEditor.DataSource = _bindingSourceTimeLineTreeView;
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

            //_nodeSetting = new NodeSetting(_bindingSourceTimeLineTreeView, CurrentEmployeesLogIn);
            _nodeSetting = new NodeSetting
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
             _nodeSetting.FocusedNodeProperties = new NodeProperties();
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
            On_StatusBarMessage(e);
        }

        void NodeSetting_Save_Requested(object? sender, Save_Requested_EventArgs e)
        {
            Save_Requested_EventArgs save_Requested_EventArgs = new Save_Requested_EventArgs()
            {
                SaveEvent = NotificationEvents.DataBaseUpDated,
                DataTableName = "Table_TimeLine_TreeView"
            };

            On_Save_Requested(save_Requested_EventArgs);
        }

        #endregion"NodeSettingTabPage"       

        #region"DataGridViewExtended"

        Table_TimeLine_TreeView _currentRowViewActive;
        private void Initialize_DataGridView()
        {
            InitializeDataGridViewBase(dataGridViewExtended_TimeLineEditor);

            dataGridViewExtended_TimeLineEditor.SuspendLayout();

            dataGridViewExtended_TimeLineEditor.Name = Name;

            dataGridViewExtended_TimeLineEditor.CellBegingEditEvent += DataGridViewExtendedInventoryCellBeggingEditEvent;
            dataGridViewExtended_TimeLineEditor.CellEndEditEvent += DataGridViewExtendedInventoryCellEndEditEvent;
            dataGridViewExtended_TimeLineEditor.CellClickEvent += DataGridViewExtended_StockRoom_CellClick_Event;
            dataGridViewExtended_TimeLineEditor.CellDoubleClickEvent += DataGridViewExtended_StockRoom_CellDoubleClick_Event;
            dataGridViewExtended_TimeLineEditor.CurrentRowActivesEvent += DataGridViewExtendedInventoryCurrentRowActive;
            dataGridViewExtended_TimeLineEditor.FindRemplace += DataGridViewExtended_Inventory_Find_Replace;
            dataGridViewExtended_TimeLineEditor.SaveRequested += DataGridViewExtendedInventorySaveRequested;
            dataGridViewExtended_TimeLineEditor.RefreshRequested += DataGridViewExtendedInventoryRefreshRequested;
            dataGridViewExtended_TimeLineEditor.UserDeletedRow += DataGridViewExtendedInventoryUserDeletedRow;
            dataGridViewExtended_TimeLineEditor.RowsRemoved += DataGridViewExtendedInventoryRowsRemoved;
            dataGridViewExtended_TimeLineEditor.DataGridViewMouseEnterEvent += DataGridViewExtendedInventoryMouseEnterEvent;
            dataGridViewExtended_TimeLineEditor.DataGridViewSort += DataGridViewExtendedInventoryDataGridViewSort;
            dataGridViewExtended_TimeLineEditor.BindingNavigatorAddNewItemEvent += DataGridViewExtended_Inventory_AddNewItemEvent;

            dataGridViewExtended_TimeLineEditor.StatusBarMessage += DataGridViewExtendedInventoryStatusBarMessage;
            dataGridViewExtended_TimeLineEditor.LogFileMessage += DataGridViewExtendedInventoryLogFileMessage;

            dataGridViewExtended_TimeLineEditor.DataSource = _bindingSourceTimeLine;

            dataGridViewExtended_TimeLineEditor._dataGridView.ReadOnly = false;
            dataGridViewExtended_TimeLineEditor.CustomEdit = Utilities.EditMode.Delete;

            dataGridViewExtended_TimeLineEditor.ResumeLayout();
        }

        /// <summary>
        /// Add new TimeLine item
        /// </summary>
        private async void DataGridViewExtended_Inventory_AddNewItemEvent(object? sender, EventArgs e)
        {
            try
            {
                _bindingSourceTimeLine.SuspendBinding();

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
                var savedTimeLine = await _timeLineService.CreateTimeLineAsync(newTimeLine);

                // Add to binding list
                _timeLineBindingList.Add(savedTimeLine);

                _bindingSourceTimeLine.ResumeBinding();
                _bindingSourceTimeLine.ResetBindings(false);

                // ✅ Navigate to new item
                int newItemIndex = _bindingSourceTimeLine.IndexOf(savedTimeLine);
                _bindingSourceTimeLine.Position = newItemIndex;

                // Focus the DataGridView
                if (dataGridViewExtended_TimeLineEditor._dataGridView.Rows.Count > 0)
                {
                    var row = dataGridViewExtended_TimeLineEditor._dataGridView.Rows[newItemIndex];
                    row.Selected = true;
                    dataGridViewExtended_TimeLineEditor._dataGridView.CurrentCell = row.Cells[0];
                }

                StatusBarMessage(new StatusBarMessage_EventArgs(
                    $"New TimeLine item created: {savedTimeLine.ItemText}"));
            }
            catch (Exception ex)
            {
                _bindingSourceTimeLine.ResumeBinding();
                MessageBox.Show($"Error adding new item: {ex.Message}",
                    "Add Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        async void DataGridViewExtendedInventoryCellEndEditEvent(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _unitOfWork.TableTimeLineTreeViews.Update(_currentRowViewActive);

                await _unitOfWork.SaveChangesAsync();

                _bindingSourceTimeLineTreeView.ResetBindings(false);
                
                On_NotificationsToSends(new Notification(
                                                     "DataBase has been updated.",                       // 0 notification.Text
                                                     "Warning, DataBase updated.",                       // 1 notification.Title
                                                     "The database has been updated by an user.",        // 2 notification.Description
                                                     (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                                     (int)NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName,                    // 5 notification.String_Filter
                                                     DateTime.Now,                                       // 6 notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     // 7 notification.Created_by
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

        private void DataGridViewExtendedInventoryCellBeggingEditEvent(object? sender, DataGridViewCellCancelEventArgs e)
        {
          
        }

        private void DataGridViewExtendedInventoryLogFileMessage(object? sender, LogFileMessageEventArgs e)
        {
            On_LogFileMessage(e);
        }

        private void DataGridViewExtendedInventoryDataGridViewSort(object? sender, DataGridViewSort_EventArgs e)
        {
            //   if (chart_Components.Visible)
            //       Start_EasyProgressBar_GraphicChart();
        }

        private void DataGridViewExtendedInventoryStatusBarMessage(object? sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        private void DataGridViewExtended_StockRoom_CellClick_Event(object? sender, CellClick_EventArgs e)
        {
          //  _currentColumnActive = _currentRowViewActive.DataView.Table.Columns[e.ColumnIndex];
        }

        private void DataGridViewExtended_StockRoom_CellDoubleClick_Event(object? sender, CellDoubleClick_EventArgs e)
        {

            if (CurrentEmployeesLogIn.IsUser)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          //  if (_currentRowViewActive == null)
          //      return;

            //On_CellDoubleClick_Event(e);
        }

        private void DataGridViewExtendedInventoryCurrentRowActive(object? sender, CurrentRowActive_EventArgs e)
        {
            if (e.CurrentRowActive.Index == -1)
            {
                //   GetPicturesProccess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Pictures_Found.jpg");
                //   GetLocationProccess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Location_Found.jpg");
                return;
            }

            if (e.CurrentRowActive.DataBoundItem.GetType() == typeof(Table_TimeLine_TreeView))
            {
                _currentRowViewActive = (Table_TimeLine_TreeView)e.CurrentRowActive.DataBoundItem;
            }

            //   if (!dataGridViewExtended_Inventory.Bounds.Contains(dataGridViewExtended_Inventory.PointToClient(MousePosition)))
            //       return;
        }

        private void DataGridViewExtended_Inventory_Find_Replace(object? sender, DataGridViewExtended.FindRemplaceEventArgs e)
        {

        }

        private void DataGridViewExtendedInventorySaveRequested(object? sender, Save_Requested_EventArgs e)
        {
            //If you extend Base Temple class you do not need to implement this event,
            //Base Temple method DataGridViewExtendedBase_SaveRequested() already implements it.

            //SaveRequested(e);
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
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Error in row information."));
                return;
            }

            if (!e.Row.Cells[0].Value.ToString().Contains('-'))
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Error in row information."));
                return;
            }

            string filePath = Settings.Default.DataBaseAddress + "\\Pictures\\" + e.Row.Cells[0].Value.ToString() + ".JPG";

            if (!File.Exists(filePath))
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("No Pictures file was found."));
                return;
            }

            string[] source = new string[1];
            source[0] = filePath;

             Controls.ShellBasics.ShellFileOperation fo = new Controls.ShellBasics.ShellFileOperation();

            fo.Operation = StockRoom11net.Controls.ShellBasics.ShellFileOperation.FileOperations.FO_DELETE;
            fo.OwnerWindow = this.Handle;
            fo.SourceFiles = source;

            if (fo.DoOperation())
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Pictures file was found and deleted."));
            else
                MessageBox.Show("Pictures file was found, but unable to be deleted.");

            //*****************************************************************************************************************

            string description = "The component " + e.Row.Cells[0].Value.ToString() + " has been deleted.";

            On_NotificationsToSends(new Notification(
                                                     "DataBase hass change.",                            //notification.Text
                                                     "Warning, DataBase change.",                        //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)NotificationEvents.RowRemoved,          //notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName + ";",   //notification.String_Filter
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        private void DataGridViewExtendedInventoryRowsRemoved(object? sender, DataGridViewRowsRemovedEventArgs e)
        {
            //*****************************************************************************************************************

            string description = "The component " + "" + " has been removed.";

            On_NotificationsToSends(new Notification(
                                                     "DataBase has been change.",                        //notification.Text
                                                     "Warning, DataBase change.",                        //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)NotificationEvents.RowRemoved,          //notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName + ";",   //notification.String_Filter
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        private void DataGridViewExtendedInventoryMouseEnterEvent(object? sender, DataGridViewMouseEnterEventArgs e)
        {
            dataGridViewExtended_TimeLineEditor._dataGridView.Focus();

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
                _nodeSetting.FocusedNodeProperties = e.SelectedNodeProperties;
            }

            #endregion"tabPage_DataTreeViewSetting"

        }

        void DataTreeViewToAdd_Cancel_Delete_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            try
            {
                On_Save_Requested(e);

                On_NotificationsToSends(new Notification(
                                                     "DataBase has been updated.",                       // 0 notification.Text
                                                     "Warning, DataBase updated.",                       // 1 notification.Title
                                                     "The database has been updated by an user.",        // 2 notification.Description
                                                     (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                                     (int)NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName,         // 5 notification.String_Filter
                                                     DateTime.Now,                                       // 6 notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     // 7 notification.Created_by
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
                    string dataObject = @"{
                        ""title"": {
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
                        ""events"": [{
                                    ""media"": {
                                                ""url"": ""//www.flickr.com/photos/tm_10001/2310475988/"",
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
                                                ""text"": ""<div><p> Houston, 48, was discovered dead at the Beverly Hilton Hotel on  on Feb. 11, 2012. She is survived by her daughter, Bobbi Kristina Brown, and mother, Cissy Houston.</p></div>""
                                              }
                                        }]
                            }";

                    _appService.UpDateTimeLine(dataObject);
                }
            }
            catch(Exception error)
            {
                string aert = error.Message;
            }
        }

        private void DataTreeViewToAdd_Cancel_Delete_Switch_DataTable(object sender, Switch_DataTable_EventArgs e)
        {
            if (dataGridViewExtended_TimeLineEditor.DataSource == _bindingSourceTimeLine)
                dataGridViewExtended_TimeLineEditor.DataSource = _bindingSourceTimeLineTreeViewVal;
            else
                dataGridViewExtended_TimeLineEditor.DataSource = _bindingSourceTimeLine;

            // SettingMode = true;
        }

        #endregion"DataTreeViewToAdd_Cancel_Delete"    
    }
}

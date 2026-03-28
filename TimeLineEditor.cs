using BrightIdeasSoftware;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyStuff11net;
using MyStuff11net.DataGridViewExtend;
using MyStuff11net.Properties;
using StockRoom11net.BlazorWebAssembly.Components.Pages;
using StockRoom11net.BlazorWebAssembly.Data;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using static MyStuff11net.Custom_Events_Args;
using static MyStuff11net.MyCode;
using CellClick_EventArgs = MyStuff11net.Custom_Events_Args.CellClick_EventArgs;
using CellDoubleClick_EventArgs = MyStuff11net.Custom_Events_Args.CellDoubleClick_EventArgs;
using CurrentRowActive_EventArgs = MyStuff11net.Custom_Events_Args.CurrentRowActive_EventArgs;
using DataGridViewMouseEnterEventArgs = MyStuff11net.Custom_Events_Args.DataGridViewMouseEnterEventArgs;
using DataGridViewSort_EventArgs = MyStuff11net.Custom_Events_Args.DataGridViewSort_EventArgs;
using Refresh_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Refresh_Requested_EventArgs;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;

namespace StockRoom11net
{
    public partial class TimeLineEditor : BaseTemple
    {
        #region"Properties"

        DataColumnCollection _stockroomColumns;
        /// <summary>
        /// Keep a record of all columns existent in StockRoom datatable.
        /// </summary>
        private DataColumnCollection StockRoomColumns
        {
            get
            {
                return _stockroomColumns;
            }
            set
            {
                _stockroomColumns = value;
            }
        }

        /// <summary>
        /// RenameDistFileName, true to rename with new fileName, false keep original fileName.
        /// </summary>
        bool RenameDistFileName;

        /// <summary>
        /// DeleteOriginalFile, true to delete the source file, false keep source file.
        /// </summary>
        bool DeleteOriginalFile;

        /// <summary>
        /// Reference to data table were is saved all information.
        /// </summary>
        private DataTable table;

        private BindingSource _bindingSourceTimeLine;
        private BindingSource _bindingSourceTimeLineTreeView;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingSource BindingSourceTimeLineTreeView
        {
            get { return _bindingSourceTimeLineTreeView; }
            set
            {
                BindingSourceTreeViewBase = value;
                _bindingSourceTimeLineTreeView = BindingSourceTreeViewBase;

                if (_bindingSourceTimeLineTreeView != null & _bindingSourceTimeLineTreeView.DataSource != null)
                {
                    MessagePositionString = "tempDataTable";
                    _dataTableTreeView = (_bindingSourceTimeLineTreeView.DataSource as DataSet).Tables[_bindingSourceTimeLineTreeView.DataMember];

                    MessagePositionString = "columnsCollection";
                    ColumnsCollection = _dataTableTreeView.Columns;
                }
            }
        }

        int _lastID;
        // If we are using a bindingSource, used this in Load procedure.
        //    table = ((DataSet)_bindingSource.DataSource).Tables[_bindingSource.DataMember];
        // We ask per the lastID just before used.
        //            if (table.Rows.Count > 0)
        //                LastID = (int)table.Compute("MAX(ID)", "ID is Not null");
        //            else
        //                LastID = 0;
        /// <summary>
        /// Top value for ID field, option filter to select a group of row.
        /// table.Compute("MAX(ID)", "filter condition"), itself inc.
        /// </summary>
        private int LastID
        {
            get
            {
                ++_lastID;
                return _lastID;
            }
            set
            {
                _lastID = value;
            }
        }

        /// <summary>
        /// Current rowView active in the dataGridViewExtended_Inventory,
        /// update on CurrentRowActive and MouseEnterEvent event.
        /// </summary>
        DataRowView _currentRowViewActive;

        readonly DataTable _dataTableTimeLine;
        DataTable _dataTableTreeView;
        readonly AppState _appState = new();
        readonly AppService _appService = new();

        #endregion"Properties"

        public TimeLineEditor()
        {
            InitializeComponent();
        }

        public TimeLineEditor(BindingSource bindingSourceTimeLine)
        {
            InitializeComponent();

            Name = "TimeLineEditor";

            InitializeBlazorWebView();

            #region"_bindingSourceTimeLine, ColumnsCollection"

            _bindingSourceTimeLineTreeView = [];

            MessagePositionString = "_bindingSourceTimeLine == null";
            _bindingSourceTimeLine = [];
            _bindingSourceTimeLine = bindingSourceTimeLine;
            _dataTableTimeLine = new DataTable();
            if (_bindingSourceTimeLine == null)
            {
                MessageBox.Show(@"The input TimeLine bindingSource is Null", @"Error on initialization",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessagePositionString = "tempDataTable";
                _dataTableTimeLine = (_bindingSourceTimeLine.DataSource as DataSet).Tables[_bindingSourceTimeLine.DataMember];

                MessagePositionString = "columnsCollection";
                ColumnsCollection = _dataTableTimeLine?.Columns;
            }

            #endregion"_bindingSource_StockRoom, ColumnsCollection"    
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

        async Task BlazorWebView2ReadyAsync()
        {
            // Ensure CoreWebView2 is initialized before proceeding
            await blazorWebView_TimeLine.WebView.EnsureCoreWebView2Async();
            // After the CoreWebView2 has been initialized (e.g., in the Form_Load or after EnsureCoreWebView2Async)
            blazorWebView_TimeLine.WebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = true;
            blazorWebView_TimeLine.WebView.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = true;
            blazorWebView_TimeLine.WebView.CoreWebView2.Settings.AreDevToolsEnabled = true; // Prevents F12/Ctrl+Shift+I

            // blazorWebView_TimeLine.WebView.CoreWebView2.OpenDevToolsWindow();
        }

        void TimeLineEditor_Load(object? sender, EventArgs e)
        {
            try
            {
                MessagePositionString = "InitializeProperties()";
                InitializeProperties();

                InitTabControlExtend();
                Initialize_DataGridView();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, @"Error on initialization", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        async void TimeLineEditor_Shown(object? sender, EventArgs e)
        {
            try
            {
                dataTreeViewToAdd_Cancel_Delete.DebugMode = false;

                await BlazorWebView2ReadyAsync();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, @"Error on initialization", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void InitializeProperties()
        {
            RenameDistFileName = Settings.Default.RenameDistFileName;

            DeleteOriginalFile = Settings.Default.DeleteOriginalFile;
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
                dataTreeViewToAdd_Cancel_Delete.SettingMode = false;

                dataGridViewExtended_TimeLineEditor.DataSource = _bindingSourceTimeLine;

                return;
            }

            if (customTabControl_TimeLine.SelectedTab.Name == "tabPage_DataTreeViewSetting")
            {
                InitializeNodeSettingTabPage();
                dataTreeViewToAdd_Cancel_Delete.SettingMode = true;
                dataTreeViewToAdd_Cancel_Delete.OlvDataTree_SelectedIndexChanged(sender, e);

                dataGridViewExtendedBase.CustomEdit = EditMode.Delete;
                dataGridViewExtended_TimeLineEditor.DataSource = _bindingSourceTimeLineTreeView;
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

            RenameDistFileName = Settings.Default.RenameDistFileName;

            DeleteOriginalFile = Settings.Default.DeleteOriginalFile;

            _nodeSetting = new NodeSetting(_bindingSourceTimeLineTreeView, ColumnsCollection, CurrentEmployeesLogIn);

            _nodeSetting.DebugMode = false;
            _nodeSetting.SaveRequested += NodeSetting_Save_Requested;
            _nodeSetting.StatusBarMessage += NodeSetting_StatusBarMessage;
            _nodeSetting.NodeImageChange += NodeSetting_NodeImageChange;
            _nodeSetting.AutoScroll = true;
            _nodeSetting.AutoScrollMinSize = new Size(730, 475);
            _nodeSetting.Dock = DockStyle.Fill;
            _nodeSetting.FocusedNodeProperties = new NodeProperties();
            _nodeSetting.Location = new Point(0, 0);
            _nodeSetting.Name = "nodeSetting";
            _nodeSetting.NeedSaveData = false;
            _nodeSetting.Size = new Size(731, 501);
            _nodeSetting.TabIndex = 0;

            tabPage_DataTreeViewSetting.Controls.Add(_nodeSetting);
        }

        void NodeSetting_NodeImageChange(object? sender, NodeSetting.NodeImageChange_EventArgs e)
        {
            dataTreeViewToAdd_Cancel_Delete.InitializeImageList();
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
            dataGridViewExtended_TimeLineEditor.CustomEdit = MyCode.EditMode.Delete;

            dataGridViewExtended_TimeLineEditor.ResumeLayout();
        }

        private void DataGridViewExtended_Inventory_AddNewItemEvent(object? sender, EventArgs e)
        {
            BindingSource bindingSource = (BindingSource)dataGridViewExtended_TimeLineEditor.DataSource;

            table = (bindingSource.DataSource as DataSet).Tables[bindingSource.DataMember];

            if (table.Rows.Count > 0)
                LastID = (int)table.Compute("MAX(ID)", "ID is Not null");
            else
                LastID = 0;

            bindingSource.SuspendBinding();
            bindingSource.RaiseListChangedEvents = false;

            object? newObject = bindingSource.AddNew();
            DataRowView? newRow = newObject as DataRowView;

            if (newRow == null)
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Error in row information."));
                return;
            }

            int newRowID = LastID;

            newRow.BeginEdit();
            newRow["ID"] = newRowID;
            newRow["Index"] = newRowID;
            newRow["Text_Name"] = "NewNode";
            newRow["Parent_ID"] = DBNull.Value;
            newRow["Node_PDF"] = "";
            newRow["Node_Picture"] = "";
            newRow["Description_Short"] = "";
            newRow["Description_Expand"] = "";
            newRow["Image"] = "";
            newRow["String_Filter"] = "";
            newRow["ItemCount"] = 0;
            newRow["ItemOpen"] = "false";
            newRow["DateCreated"] = DateTime.Now;
            newRow["Created_by"] = CurrentEmployeesLogIn.Name + " " + CurrentEmployeesLogIn.LastName;
            newRow["Properties"] = "";
            newRow["Message_String"] = "";
            newRow["Status"] = "";

            newRow.EndEdit();

            bindingSource.EndEdit();
            bindingSource.RaiseListChangedEvents = true;
            bindingSource.ResumeBinding();
            bindingSource.ResetBindings(false);
            bindingSource.Sort = "ID ASC";
            bindingSource.Position = bindingSource.Count - 1;
        }

        private void DataGridViewExtendedInventoryCellEndEditEvent(object? sender, DataGridViewCellEventArgs e)
        {
            Save_Requested_EventArgs save_Requested_EventArgs = new Save_Requested_EventArgs()
            {
                SaveEvent = NotificationEvents.DataBaseUpDated,
                DataTableName = dataGridViewExtended_TimeLineEditor._dataTable.TableName,
                Message = "TimeLineEditor DataGridViewExtended: CellEndEditEvent, BaseTemple.On_Save_Requested(e).",

            };

            try
            {
                On_Save_Requested(save_Requested_EventArgs);

                On_NotificationsToSends(new Notification(
                                                     "DataBase has been updated.",                       // 0 notification.Text
                                                     "Warning, DataBase updated.",                       // 1 notification.Title
                                                     "The database has been updated by an user.",        // 2 notification.Description
                                                     (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                                     (int)MyCode.NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
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

        private void DataGridViewExtendedInventoryCellBeggingEditEvent(object? sender, DataGridViewCellCancelEventArgs e)
        {
            _currentColumnActive = _currentRowViewActive.DataView.Table.Columns[e.ColumnIndex];

            string description = "The information of " + _currentRowViewActive["ID"].ToString() + " is being edited.\r\n" +
                                 _currentColumnActive.ColumnName + " " + _currentRowViewActive[_currentColumnActive.ColumnName].ToString();

            On_NotificationsToSends(new Notification(
                                                     "Row information is being edited.",                //notification.Text
                                                     "Warning, Row information is being edited.",       //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)MyCode.NotificationEvents.Warning,             //notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName,         //notification.DepartmentName
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        private void DataGridViewExtendedInventoryLogFileMessage(object? sender, Custom_Events_Args.LogFileMessageEventArgs e)
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
            _currentColumnActive = _currentRowViewActive.DataView.Table.Columns[e.ColumnIndex];
        }

        private void DataGridViewExtended_StockRoom_CellDoubleClick_Event(object? sender, CellDoubleClick_EventArgs e)
        {

            if (CurrentEmployeesLogIn.IsUser)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentRowViewActive == null)
                return;

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

            _currentRowViewActive = (DataRowView)e.CurrentRowActive.DataBoundItem;

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
            if (_currentRowViewActive == null)
                On_Refresh_Requested(new Refresh_Requested_EventArgs("ID Like 'Is Not Null'"));
            else
            {
                //   if (_currentFocusedNodeproperties == null)
                //       On_Refresh_Requested(new Refresh_Requested_EventArgs("ID Like 'Is Not Null'"));
                //   else
                //       On_Refresh_Requested(new Refresh_Requested_EventArgs(_currentFocusedNodeproperties.StringFilter));
            }
        }

        private void DataGridViewExtendedInventoryUserDeletedRow(object? sender, DataGridViewRowEventArgs e)
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

            string filePath = Settings.Default.DataBaseAddress + "\\Pictures\\" + e.Row.Cells[0].Value.ToString() + ".JPG";

            if (!File.Exists(filePath))
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("No Pictures file was found."));
                return;
            }

            string[] source = new string[1];
            source[0] = filePath;

            ShellFileOperation fo = new ShellFileOperation();

            fo.Operation = ShellFileOperation.FileOperations.FO_DELETE;
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
                                                     (int)MyCode.NotificationEvents.RowRemoved,          //notifycation.NotifycationEvents
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
                                                     (int)MyCode.NotificationEvents.RowRemoved,          //notifycation.NotifycationEvents
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

            _currentRowViewActive = (DataRowView)e.CurrentRowActive.DataBoundItem;

        }

        #endregion"DataGridViewExtended"

        
        void DataTreeViewToAdd_Cancel_Delete_Load(object sender, EventArgs e)
        {
            dataTreeViewToAdd_Cancel_Delete.BindingSourceTreeView = BindingSourceTimeLineTreeView;
        }

        void DataTreeViewToAdd_Cancel_Delete_SelectedIndexChanged(object sender, Custom_Events_Args.TreeViewSelectedIndexChangedEventArgs e)
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
                                                     (int)MyCode.NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
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
    }
}

using BrightIdeasSoftware;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using OpenTelemetry.Resources;
using StockRoom11net.Controls;
using StockRoom11net.Controls.BindingSourceExt;
using StockRoom11net.Controls.DataGridViewExtend;
using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Controls.OpenFileDialogExt;
using StockRoom11net.Controls.ResourcesCache;
using StockRoom11net.Controls.ShellBasics;
using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using StockRoom11net.Properties;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using static StockRoom11net.Controls.Custom_Events_Args;
using static StockRoom11net.Controls.NodeSetting;
using static StockRoom11net.Controls.Utilities;

namespace StockRoom11net
{
    public partial class Employees_Management : BaseTemple
    {
        // Injected EF Core services
        private readonly IAppService _iappService;
        private readonly IUnitOfWork _unitOfWork;
        private ITableEmployeeService _employeesService;
        private ITableEmployeeTreeViewService _tableEmployeesTreeViewService;

        // Declare as extended type
        public BindingSourceValidating<Table_Employee> _bindingSourceEmployeeVal;
        public BindingSourceValidating<Table_Base_TreeView> _bindingSourceEmployeeTreeViewVal;

        #region"CurrentUserBroadcast"

        /// <summary>
        /// The user setting name, we save userSettingName = DataTreeViewName + "_" + TableName;
        /// It is update at public object DataSource{ set }
        /// We saved the datasource name because in some cases,
        /// the same dataTreeView manipulates different dataSources.
        /// </summary>                  //DGVExt_Employee_Table_Employees -> from the setting itselft
        private string userSettingName = "DGVExt_Employee_Table_Employees";

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
            get { return _employeesService; }
            set
            {
                if (value == null)
                    return;

                _employeesService = value;
                CurrentEmployeeLogIn = _employeesService.CurrentEmployeeLogIn;
                _employeesService.CurrentEmployeeLogInChanged += EmployeesService_CurrentEmployeeLogInChanged;
                dataGridViewExtended.EmployeesService = _employeesService;
                dataTreeViewToAdd_Cancel_Delete.EmployeesService = _employeesService;
            }
        }

        void EmployeesService_CurrentEmployeeLogInChanged(object? sender, EmployeeInformation e)
        {
            CurrentEmployeeLogIn = e;
            dataGridViewExtended.EmployeesService = EmployeesService;
            dataTreeViewToAdd_Cancel_Delete.EmployeesService = EmployeesService;
        }

        /// <summary>
        /// The current employee information, we use this information to apply the correct setting for this employee,
        /// this is internal field, we do not want to expose it to the designer.
        /// </summary>
        EmployeeInformation _currentEmployeeLogIn;

        /// <summary>
        /// The current employee information, we use this information to apply the correct setting for this employee,
        /// this is internal field, we do not want to expose it to the designer.
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
                _employeeEditMode = _currentEmployeeLogIn.EditMode;
                _employeeAccessLevel = _currentEmployeeLogIn.AccessLevel;
                EmployeeEnableTreeViewSetting = _currentEmployeeLogIn.EnableTreeViewSetting;

                UserSetting userSetting = _currentEmployeeLogIn.UserSettingEntity(userSettingName);

                internalResizeEvent = true;
                splitContainer_Vertical.SplitterDistance = userSetting.SplitterVertical;
                splitContainer_Horizontal.SplitterDistance = userSetting.SplitterHorizontal;
            }
        }

        #endregion"CurrentUserBroadcast"

        #region"Properties"

        /// <summary>
        /// Reference to datatable were is saved all information.
        /// </summary>
        private DataTable dataTableEmployees;

        private DataColumnCollection _columnsCollection_Inventory;
        /// <summary>
        /// Keep a record of all columns existent in StockRoomInventory datatable.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Keep a record of all columns existent in StockRoomInventory datatable.
        /// </summary>
        public DataColumnCollection ColumnsCollection_Inventory
        {
            get
            {
                return _columnsCollection_Inventory;
            }
            set
            {
                _columnsCollection_Inventory = value;
            }
        }

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

                    if (dataGridViewExtended.DataSource == _bindingSourceEmployeeTreeViewVal)
                        dataGridViewExtended.DataSource = _bindingSourceEmployeeVal;
                }
            }
        }

        #endregion"Properties"

        private EmployeeInformation EmployeesSelected = new EmployeeInformation();
        private DepartmentInformation DepartmentSelected;

        private List<string> PositionList = new List<string>();

        // ⚠️ To catch missing registrations early, you can also mark the parameterless
        // constructor with[Obsolete] so it shows a compiler warning whenever it's accidentally used:
        [Browsable(false)]
        [Obsolete("Use DI constructor. Missing service registration may be causing this call.")]
        public Employees_Management()
        {
            InitializeComponent();

#if DEBUG
            System.Diagnostics.Debug.WriteLine(
                "[DI WARNING] Employees_Management parameterless constructor was called. " +
                "This usually means a required service (ITableEmployeeService, ITableEmployeeTreeViewService, or IAppService) " +
                "is missing from the DI container. Register the missing service in Data/DependencyInjection.cs.");

            MessageBox.Show(
                "Employees_Management was created using its parameterless constructor.\n\n" +
                "This means DI could not resolve one or more required services:\n" +
                "  - ITableEmployeeService\n" +
                "  - ITableEmployeeTreeViewService\n" +
                "  - IAppService\n\n" +
                "Register the missing service in Data/DependencyInjection.cs.",
                "DI Registration Missing",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
#endif
        }

        public Employees_Management(ITableEmployeeService employeesService,
                                    ITableEmployeeTreeViewService employeesTreeViewService,
                                    IAppService iappService,
                                    IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            EmployeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService));
            _tableEmployeesTreeViewService = employeesTreeViewService ?? throw new ArgumentNullException(nameof(employeesTreeViewService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _iappService = iappService ?? throw new ArgumentNullException(nameof(iappService));

            // ✅ Pass unitOfWork to the EXISTING designer instance, don't replace it
            dataTreeViewToAdd_Cancel_Delete.SetUnitOfWork(_unitOfWork);

            Name = "Employees Management";
            dataGridViewExtended.Name = "DGVExt_Employee";
            // We need pass employeeService, at initialization we call currentEmployeeLogIn
            //dataGridViewExtended.EmployeesService = EmployeesService;
            //dataTreeViewToAdd_Cancel_Delete.EmployeesService = EmployeesService;

            Load += Employees_Management_Load;
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
                MessageDebugPosition = "Starting LoadEmployeesDataAsync()";

                // ✅ Load DataTable from database → DataView → BindingSource (supports .Filter)
                // DataTable is used here to demonstrate that EF Core can load data into a DataTable,
                // which is then wrapped in a DataView for filtering and sorting. The BindingSourceValidating
                // class is a custom BindingSource that adds validation capabilities.
                dataTableEmployees = await _employeesService.LoadEmployeeDataTableAsync();
                var dataView = new DataView(dataTableEmployees);

                _bindingSourceEmployeeVal = new BindingSourceValidating<Table_Employee>
                {
                    DataSource = dataView,
                    TableName = "Table_Employees",
                    Position = 0
                };

                MessageDebugPosition = "Assigning BindingSource to DataGridView";
                dataGridViewExtended.DataSource = _bindingSourceEmployeeVal;


                MessageDebugPosition = "Loading TreeView data";
                // ✅ Load typed list from database → BindingList<Table_Base_TreeView> → BindingSource.
                // A DataView-backed BindingSource exposes DataRowView items through .List, which cannot
                // be cast to Table_Base_TreeView in the BindingSourceTreeView setter (InvalidCastException).
                // We lose the ability to filtering and sorting, but we gain the ability to use the
                // typed Table_Base_TreeView objects in the TreeView.
                var treeViewList = await _tableEmployeesTreeViewService.LoadEmployeeTreeViewAsync();

                // Loading all rows works, but we want to investigate the crash at row 60, so we will load only 60 rows
                // to see if the crash still happens, if it does not happen, we will know that the problem is related
                // to the data in the rows after 60, and we can investigate further.
                //_bindingSourceStockRoomTreeViewVal = await _tableStockRoomTreeViewService.LoadStockRoomsTreeViewAsync(count: 60);

                MessageDebugPosition = "Create BindingSource for TreeView";
                _bindingSourceEmployeeTreeViewVal = new BindingSourceValidating<Table_Base_TreeView>
                {
                    DataSource = new BindingList<Table_Base_TreeView>(treeViewList.Cast<Table_Base_TreeView>().ToList()),
                    TableName = "Table_Employees_TreeView",
                    Position = 0
                };

                // DiagnoseRow60();
                //DiagnoseRow60NullInIntegerColumns();

                MessageDebugPosition = "Assign BindingSource to TreeView";
                dataTreeViewToAdd_Cancel_Delete.BindingSourceTreeView = _bindingSourceEmployeeTreeViewVal;

                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs($"Loaded {_bindingSourceEmployeeVal.Count} Employee records"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Employee data: {ex.Message}",
                    "Data Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Employees_Management_Load(object? sender, EventArgs e)
        {
            // EF Core migration: load entities directly from the service instead of
            // pulling a DataTable out of a DataSet-backed BindingSource.
            //BindingList<Table_Employee> employees = await _employeesService.LoadEmployeeAsync();

            // POCO equivalent of DataColumnCollection: exposes the "columns" (properties)
            // of Table_Employee for UI code that previously enumerated table.Columns.
            ColumnsCollectionEmployee = TypeDescriptor.GetProperties(typeof(Table_Employee));

            PositionList.Clear();
            PositionList = (await _employeesService.LoadEmployeeAsync())
                                                    .Where(emp => !string.IsNullOrEmpty(emp.Position))
                                                    .Select(emp => emp.Position.Trim())
                                                    .Distinct()
                                                    .ToList();

            _cache = new ResourcesCache();

            MessageDebugPosition = "InitializeSaveUserSettingTimer()";
            InitializeSaveUserSettingTimer();

            MessageDebugPosition = "InitializeDataTreeView()";
            InitializeDataTreeView();

            MessageDebugPosition = "InitTabControlExtend()";
            InitTabControlExtend();

            DataGridViewExtended_EmployeeInitialize();

            SettingUI_Department();
            SettingUI_Employee();
            InitializeProfile();

            LoadDataEF();
        }

        #region"DataTreeListView"

        void InitializeDataTreeView()
        {
            dataTreeViewToAdd_Cancel_Delete.Switch_DataTable += DataTreeViewToAdd_Cancel_Delete_Switch_DataTable;
            dataTreeViewToAdd_Cancel_Delete.SelectedIndexChanged += DataTreeViewToAdd_Cancel_Delete_SelectedIndexChangedAsync;
            dataTreeViewToAdd_Cancel_Delete.StatusBarMessage += DataTreeViewToAdd_Cancel_Delete_StatusBarMessage;
        }

        void DataTreeViewToAdd_Cancel_Delete_StatusBarMessage(object? sender, StatusBarMessage_EventArgs e)
        {
            _iappService.On_StatusBarMessage(e);
        }

        async void DataTreeViewToAdd_Cancel_Delete_SelectedIndexChangedAsync(object? sender, TreeViewSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (e.CurrentNode == null)
                    return;

                if (dataGridViewExtended.DataSource == _bindingSourceEmployeeVal)
                {
                    // ✅ Filter now works because DataSource is a DataView
                    dataGridViewExtended.CustomFilter = e.CurrentNode.String_Filter;
                }

                #region"tabPage_DataTreeViewSetting"

                if (_nodeSettingIsDone && customTabControl.SelectedTab?.Name == "tabPage_TreeViewSetting")
                {
                    _nodeSetting.CurrentItem = e.CurrentNode;
                }

                #endregion"tabPage_DataTreeViewSetting"

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filter error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void DataTreeViewToAdd_Cancel_Delete_Switch_DataTable(object? sender, Switch_DataTable_EventArgs e)
        {
            if (dataGridViewExtended.DataSource == _bindingSourceEmployeeVal)
                dataGridViewExtended.DataSource = _bindingSourceEmployeeTreeViewVal;
            else
                dataGridViewExtended.DataSource = _bindingSourceEmployeeVal;

            SettingMode = true;
        }

        #endregion"DataTreeListView"

        #region"TabControlExtende"

        /// <summary>
        /// This flag is used to avoid the execution of SplitterMoved event during the initialization of the form, because
        /// at initialization we set the SplitterDistance according to the user setting, and we do not want to save the user
        /// setting at this moment, because it is not a user action, it is just the application of the user setting.
        /// </summary>
        bool internalResizeEvent = false;

        Plexiglass ShowPlexiglassRectangle;
        void InitTabControlExtend()
        {
            splitContainer_Horizontal.MouseDown += SplitContainerHorizontal_MouseDown;
            splitContainer_Vertical.MouseDown += SplitContainerVertical_MouseDown;
            splitContainer_Horizontal.SplitterMoved += SplitContainerHorizontal_SplitterMoved;
            splitContainer_Vertical.SplitterMoved += SplitContainerVertical_SplitterMoved;

            customTabControl.Alignment = TabAlignment.Bottom;
                        
            customTabControl.MouseDownResizeGripEvent += TabControl_Inventory_MouseDownResizeGripEvent;
            customTabControl.MouseUpResizeGripEvent += TabControl_Inventory_MouseUpResizeGripEventAsync;
            customTabControl.ResizeGripEvent += TabControl_Inventory_ResizeGripEvent;
            customTabControl.SelectedIndexChanged += TabControl_Inventory_SelectedIndexChanged;
                        
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
            if (internalResizeEvent)
                return;

            settingModified = "Splitter";
            SaveUserSetting();
        }

        void SplitContainerHorizontal_SplitterMoved(object? sender, SplitterEventArgs e)
        {
            if (internalResizeEvent)
                return;

            settingModified = "Splitter";
            SaveUserSetting();
        }

        void TabControl_Inventory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            if (customTabControl.SelectedTab != null & customTabControl.SelectedTab.Name.Contains("tabPage_Employee"))
            {
                //    dataTreeViewToAdd_Cancel_Delete.SelectedIndex = 0;
                customTabControl.ShowTab("tabPage_ProFile");
            }

            if (customTabControl.SelectedTab != null & customTabControl.SelectedTab.Name.Contains("tabPage_Department"))
            {
                //        dataTreeViewToAdd_Cancel_Delete.SelectedIndex = 1;
                customTabControl.HideTab("tabPage_ProFile");
            }

            if (customTabControl.SelectedTab.Name == "tabPage_TreeViewSetting")
            {
                InitializeNodeSettingTabPage();
                SettingMode = true;
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

            splitContainer_Vertical.SplitterDistance = ShowPlexiglassRectangle.Location.X;
            splitContainer_Horizontal.SplitterDistance = ShowPlexiglassRectangle.Height;

            customTabControl.Visible = true;

            settingModified = "Splitter";
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
            Point location = splitContainer_Vertical.SplitterRectangle.Location;
            Size sizeCon = splitContainer_Vertical.Panel2.ClientSize;
            var rectangleImage = (Bitmap)ScreenImage.GetScreenshot(Handle, location, sizeCon);

            ShowPlexiglassRectangle = new Plexiglass(this)
            {
                ClientSize = sizeCon,
                RectImage = rectangleImage,
                Location = PointToScreen(location)
            };

            customTabControl.Visible = false;
        }

        void TabControl_Inventory_ResizeGripEvent(object? sender, ResizeGrip_EventArgs e)
        {
            ShowPlexiglassRectangle.Location = new Point(ShowPlexiglassRectangle.Location.X + e.X, ShowPlexiglassRectangle.Location.Y);
            ShowPlexiglassRectangle.ClientSize = new Size(ShowPlexiglassRectangle.ClientSize.Width - e.X, ShowPlexiglassRectangle.ClientSize.Height + e.Y);
        }

        #endregion"TabControlExtende"

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

            _nodeSetting = new NodeSetting(_bindingSourceEmployeeTreeViewVal, ColumnsCollectionEmployee, _employeesService)
            {
                DebugMode = false,
                AutoScroll = true,
                Dock = DockStyle.Fill,
                AutoScrollMinSize = new Size(730, 475),
                Location = new Point(0, 0),
                Name = "nodeSetting",
                NeedSaveData = false,
                Size = new Size(731, 501),
                TabIndex = 0,
                CurrentItem = new Table_Base_TreeView()
            };

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
            _iappService.On_StatusBarMessage(e);
        }

        async void NodeSetting_Save_Requested(object? sender, Save_Requested_EventArgs e)
        {
            if (_bindingSourceEmployeeTreeViewVal.TableName.Contains("Table_Employees_TreeView"))
            {
                await _unitOfWork.TableEmployeesTreeViewRepository.UpdateAsync((Table_Employees_TreeView)e.Item, CancellationToken.None);
            }
        }

        #endregion"Tab_NodeSetting"

        #region"DataGridViewExtended"
        private void DataGridViewExtended_EmployeeInitialize()
        {
            dataGridViewExtended.CurrentRowActivesEvent += DataGridViewExtended_Employees_CurrentRowActive;
            dataGridViewExtended.UserDeletingRow += DataGridViewExtended_UserDeletingRow;
            dataGridViewExtended.SaveRequested += DataGridViewExtended_SaveRequested;
            dataGridViewExtended.RefreshRequested += DataGridViewExtended_Employees_Management_Refresh_Requested;

            dataGridViewExtended.StatusBarMessageEvent += (s, e) => _iappService.On_StatusBarMessage(e);
            dataGridViewExtended.ContextMenuStripOpening += DataGridViewExtended_Employee_ContextMenuStripOpening;

            dataGridViewExtended._dataGridView.ReadOnly = false;
            dataGridViewExtended.CustomEdit = StockRoom11net.Controls.Utilities.EditMode.Delete;
        }

        async void DataGridViewExtended_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow? ert = e.Row;
            if (ert == null)
                return;

            if (dataGridViewExtended.DataSource == _bindingSourceEmployeeTreeViewVal)
            {
                Table_Employees_TreeView? item = (Table_Employees_TreeView)ert.DataBoundItem;
                if (item == null)
                    return;

                MessageDebugPosition = $"Attempting to get childrens of '{item.Text_Name}'";
                IEnumerable<Table_Employees_TreeView> children = await _unitOfWork.TableEmployeesTreeViewRepository.GetChildrenAsync(item.ID);

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
                        _bindingSourceEmployeeTreeViewVal.SuspendBinding();

                        foreach (Table_Employees_TreeView itemEF in children)
                        {
                            // ✅ Use DeleteAsync — it fetches the tracked entity by PK (Index)
                            // then removes it. Avoids attaching detached entities with Index = 0.
                            await _unitOfWork.TableEmployeesTreeViewRepository.DeleteAsync(itemEF.Index);

                            RemoveFromBindingSourceTreeViewByIndex(itemEF.Index);
                        }

                        _bindingSourceEmployeeTreeViewVal.ResumeBinding();
                    }
                }

                await _unitOfWork.TableEmployeesTreeViewRepository.DeleteAsync(item.Index, CancellationToken.None);
                RemoveFromBindingSourceTreeViewByIndex(item.Index);
            }

            if (dataGridViewExtended.DataSource == _bindingSourceEmployeeVal)
            {
                Table_Employee? rowEntity = (Table_Employee)ert.DataBoundItem;
                if (rowEntity == null)
                    return;

                await _unitOfWork.TableEmployeesRepository.DeleteByIdAsync(rowEntity.ID, CancellationToken.None);
                _bindingSourceEmployeeVal.RemoveCurrent();
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
        void RemoveFromBindingSourceTreeViewByIndex(int index)
        {
            try
            {
                // ✅ .List resolves any nested BindingSource and returns the real underlying IList.
                // Iterating and removing from it directly is safe regardless of sort/filter state.
                IList list = _bindingSourceEmployeeTreeViewVal.List;
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
            if (dataGridViewExtended.DataSource == _bindingSourceEmployeeTreeViewVal)
            {
                if (e.DirtyDataGridViewIndexes.Count == 0)
                {
                    dataGridViewExtended.SavedRequestedDone();
                    return;
                }

                // Force-commit any cell still in edit mode before reading values.
                _bindingSourceEmployeeTreeViewVal.EndEdit();

                // Collect only the rows that were actually changed.
                var dirtyItems = _bindingSourceEmployeeTreeViewVal
                    .GetAllItems()
                    .OfType<Table_Employees_TreeView>()
                    .Where(item => e.DirtyDataGridViewIndexes.Contains(item.Index))
                    .ToList();

                try
                {
                    foreach (var item in dirtyItems)
                        await _unitOfWork.TableEmployeesTreeViewRepository.UpdateAsync(item, CancellationToken.None);

                    dataGridViewExtended.SavedRequestedDone();
                    _bindingSourceEmployeeTreeViewVal.ResetDirtyFlag();
                }
                catch (Exception ex)
                {
                    MessageDebugPosition = $"SaveRequested (TreeView) error: {ex.Message}";
                    // dataGridViewExtended.DirtyDataGridViewIndexes intentionally NOT cleared — retry is still possible.
                    throw;
                }
            }

            if (dataGridViewExtended.DataSource == _bindingSourceEmployeeVal)
            {
                try
                {
                    // Force-commit any cell still in edit mode before reading values.
                    _bindingSourceEmployeeVal.EndEdit();

                    BindingList<Table_Employee> employeesList = await _employeesService.LoadEmployeeAsync();

                    foreach (var item in employeesList)
                    {
                        if (e.DirtyDataGridViewIndexes.Contains(item.Index))
                        {
                            DataRowView? originalItem = _bindingSourceEmployeeVal.Cast<DataRowView>()
                                                        .FirstOrDefault(r => (int)r.Row["Index"] == item.Index);

                            foreach (PropertyDescriptor property in ColumnsCollectionEmployee)
                            {
                                var propertyName = property.Name;
                                var newValue = item.GetType().GetProperty(propertyName)?.GetValue(item);
                                var originalValue = originalItem?.Row[propertyName];
                                if (originalValue is DBNull)
                                {
                                    originalValue = null;
                                }
                                if (!Equals(newValue, originalValue))
                                {
                                    item.GetType().GetProperty(propertyName)?.SetValue(item, originalValue);
                                }

                                string statusInfo = _unitOfWork.TableEmployeesRepository.StatusInfoDefault;

                                if (propertyName == "Status")
                                {
                                    item.GetType().GetProperty(propertyName)?.SetValue(item, statusInfo);
                                    originalItem?.Row[propertyName] = statusInfo;
                                    _bindingSourceEmployeeVal.ResetItem(_bindingSourceEmployeeVal.IndexOf(originalItem));
                                }
                            }

                            await _unitOfWork.TableEmployeesRepository.UpdateAsync(item, CancellationToken.None);
                        }
                    }

                    dataGridViewExtended.SavedRequestedDone();
                    _bindingSourceEmployeeVal.ResetDirtyFlag();
                }
                catch (Exception ex)
                {
                    MessageDebugPosition = $"SaveRequested (Employee) error: {ex.Message}";
                    // dataGridViewExtended.DirtyDataGridViewIndexes intentionally NOT cleared — retry is still possible.
                    throw;
                }
            }
        }

        private void DataGridViewExtended_Employee_ContextMenuStripOpening(object? sender, ContextMenuStrip e)
        {
            e.Items.Remove(e.Items["toolStripMenuItem_SortByPDF"]);
            e.Items.Remove(e.Items["toolStripMenuItem_PrintCompLabel"]);
            e.Items.Remove(e.Items["ToolStripMenuItem_GroupByThisColumn"]);
            e.Items.Remove(e.Items["ToolStripMenuItem_RemoveGroup"]);
            e.Items.Remove(e.Items["ToolStripMenuItem_CollaseAll"]);
            e.Items.Remove(e.Items["ToolStripMenuItem_ExpandAll"]);
            e.Items.Remove(e.Items["toolStripSeparator1"]);

            e.Items.Remove(e.Items["toolStripMenuItem_editByColumn"]);
            e.Items.Remove(e.Items["ToolStripMenuItem_RemovethisFilter"]);
        }

        private void DataGridViewExtended_Employees_Management_Refresh_Requested(object? sender, Refresh_Requested_EventArgs e)
        {
            try
            {
                // On_Refresh_Requested(new Refresh_Requested_EventArgs(_bindingSource_Employees.Filter));
                NeedSaveData = false;
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// The currently selected employee or department.
        /// EF Core entities are tracked by the DbContext,
        /// so we store the entity reference here to avoid
        /// re-querying the database for the same record.
        /// </summary>
        Table_Employee? employeeDepartementSelected;

        /// <summary>
        /// The filename of the employee's image, constructed from their name and last name.
        /// EmployeesSelected.Name + EmployeesSelected.LastName + ".png"
        /// </summary>
        string employeeImageFileName = "";

        /// <summary>
        /// The full path to the employee's image file, constructed from the database address and the employee's image filename.
        /// Path.Combine(Settings.Default.DataBaseAddress, "Resources", "Photos", employeeImageFileName);
        /// </summary>
        string EmployeeImagePath = "";

        async void DataGridViewExtended_Employees_CurrentRowActive(object? sender, CurrentRowActive_EventArgs e)
        {
            try
            {
                // If the SaveUserSettingTimer is enabled, we want to save the user settings immediately
                // before processing the current row change. This ensures that any pending changes
                // are saved before we potentially switch to a different employee or department.
                if (SaveUserSettingTimer.Enabled)
                {
                    SecondsRemainingToSave = 0;
                    await SaveUserSettingTickAsync(sender, e);
                }
                    

                if (e.CurrentRowActive == null || e.CurrentRowActive.Index == -1)
                    return;

                if (dataGridViewExtended.DataSource == _bindingSourceEmployeeVal)
                {
                    var currentRow = dataGridViewExtended.CurrentRowActive;
                    if (currentRow.IsNewRow || currentRow.DataGridView == null || currentRow.DataBoundItem == null)
                        return;

                    object? data = currentRow.Cells["ID"].Value;
                    if (data == null || data == DBNull.Value)
                    {
                        // MessageBox.Show(@"The current row does not have a valid ID value.",
                        //             @"Error, invalid data.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int _ID = Convert.ToInt32(data);
                    employeeDepartementSelected = await _employeesService.GetEmployeeByIdAsync(_ID);

                    if (employeeDepartementSelected == null)
                    {
                        MessageBox.Show($"Employee with ID {_ID} not found.",
                                    @"Error, invalid data.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // If the user is already on the TreeViewSetting tab, we don't want to switch to another
                    // tab when selecting a row in the DataGridView. In this case, the user is likely editing
                    // the TreeView settings and doesn't want to be interrupted by switching tabs.
                    if (customTabControl.SelectedTab == tabPage_TreeViewSetting)
                        return;

                    if (employeeDepartementSelected?.Department?.Contains("Department") == true)
                    {
                        DepartmentSelected = new DepartmentInformation(employeeDepartementSelected);

                        InitializeUI_Department(DepartmentSelected);
                        customTabControl.ShowTab("tabPage_Department");
                        customTabControl.SelectedTab = tabPage_Department;
                        customTabControl.HideTab("tabPage_ProFile");
                        customTabControl.HideTab("tabPage_Employee");

                        if (employeeDepartementSelected.Name.Contains("No set to any department yet."))
                        {
                            tabPage_Department.Enabled = false;
                            return;
                        }
                        else
                        {
                            tabPage_Department.Enabled = true;
                            return;
                        }
                    }

                    // If the selected row is an employee (not a department),
                    // we want to show the Employee tab and hide the Department tab.
                    if (employeeDepartementSelected?.Department?.Contains("Department") == false)
                    {
                        EmployeesSelected = new EmployeeInformation(employeeDepartementSelected);

                        employeeImageFileName = EmployeesSelected.Name + EmployeesSelected.LastName + ".png";
                        EmployeeImagePath = Path.Combine(Settings.Default.DataBaseAddress, "Resources", "Photos", employeeImageFileName);

                        InitializeUI_Employee(EmployeesSelected);
                        customTabControl.ShowTab("tabPage_Employee");
                        customTabControl.SelectedTab = tabPage_Employee;
                        customTabControl.HideTab("tabPage_ProFile");
                        customTabControl.HideTab("tabPage_Department");

                        if (employeeDepartementSelected.Name.Contains("No User Log On") ||
                            employeeDepartementSelected.Last6Digit == 811266)
                        {
                            tabPage_Employee.Enabled = false;
                            return;
                        }
                        else
                        {
                            tabPage_Employee.Enabled = true;
                            return;
                        }
                    }
                }

                if (dataGridViewExtended.DataSource == _bindingSourceEmployeeTreeViewVal)
                {
                    // Send the current node to the NodeSetting control if the mouse is over the DataGridViewExtended.
                    // It was a user action, so we want to update the NodeSetting.CurrentItem to reflect the user's selection.
                    if (dataGridViewExtended.Bounds.Contains(dataGridViewExtended.PointToClient(MousePosition)))
                    {
                        _nodeSetting.CurrentItem = dataTreeViewToAdd_Cancel_Delete.CurrentNodeItem;
                    }
                }
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(@"Message related to this error is " + error.Message +
                                    @", Break code at position " + MessageDebugPosition,
                                    @"StockRoom Inventory has generated an error.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion"DataGridViewExtended"

        #region"Process Employees"

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Utilities.AccessLevel AccessLevel { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Utilities.EditMode EditMode { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Utilities.EnableSetting EnableTreeViewSetting{ get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode{ get; set; }

        void SettingUI_Employee()
        {
            textBox_Employee_Last6Digit.TextChanged += TextBox_Employee_Last6Digit_TextChanged;
            textBox_Employee_Name.TextChanged += TextBox_Employee_Name_TextChanged;
            textBox_Employee_LastName.TextChanged += TextBox_Employee_LastName_TextChanged;
            textBox_Employee_Address.TextChanged += TextBox_Employee_Address_TextChanged;
            textBox_Employee_Telephone.TextChanged += TextBox_Employee_Telephone_TextChanged;
            dateTimePicker_Employee_Hire_Date.ValueChanged += DateTimePicker_Employee_Hire_Date_ValueChanged;
            textBox_Employee_Size.TextChanged += TextBox_Employee_Size_TextChanged;

            comboBox_Employee_Position.SelectedValueChanged += ComboBox_Employee_Position_SelectedValueChanged;
            comboBox_Employee_Position.TextChanged += ComboBox_Employee_Position_TextChanged;
            comboBox_Employee_Position.DataSource = PositionList;

            comboBox_Employee_Department.SelectedValueChanged += ComboBox_Employee_Department_SelectedValueChanged;
            comboBox_Employee_Department.TextChanged += ComboBox_Employee_Department_TextChanged;

            // Guard against an empty DepartmentsList: ComboBox.DataSource internally tries to
            // set SelectedIndex = 0 when a non-null DataSource is assigned, which throws
            // ArgumentOutOfRangeException if the collection has no items.
            if (_employeesService.DepartmentsList != null && _employeesService.DepartmentsList.Count > 0)
                comboBox_Employee_Department.DataSource = _employeesService.DepartmentsList;
            else
                comboBox_Employee_Department.DataSource = null;

            comboBox_Employee_AccessLevel.SelectedValueChanged += ComboBox_Employee_AccessLevel_SelectedValueChanged;
            comboBox_Employee_AccessLevel.TextChanged += ComboBox_Employee_AccessLevel_TextChanged;
            comboBox_Employee_AccessLevel.DataSource = Enum.GetValues<AccessLevel>();

            comboBox_Employee_EditMode.SelectedValueChanged += ComboBox_Employee_EditMode_SelectedValueChanged;
            comboBox_Employee_EditMode.TextChanged += ComboBox_Employee_EditMode_TextChanged;
            comboBox_Employee_EditMode.DataSource = Enum.GetValues<Utilities.EditMode>();

            comboBox_Employee_EnableSetting.SelectedValueChanged += ComboBox_Employee_EnableSetting_SelectedValueChanged;
            comboBox_Employee_EnableSetting.TextChanged += ComboBox_Employee_EnableSetting_TextChanged;
            comboBox_Employee_EnableSetting.DataSource = Enum.GetValues<Utilities.EnableSetting>();

            PicturesBox_EmployeeImage.MouseDoubleClick += PicturesBox_EmployeeImage_MouseDoubleClick;

            button_AddNewEmployee.Enabled = true;
            button_SaveEmployee.Text = "Save";
            button_SaveEmployee.Enabled = false;
            button_DeleteEmployee.Enabled = true;

            EditMode = Utilities.EditMode.Delete;
            AccessLevel = Utilities.AccessLevel.Manager;
            EnableTreeViewSetting = Utilities.EnableSetting.False;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void ComboBox_Employee_EnableSetting_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            EnableTreeViewSetting = Enum.Parse<EnableSetting>(comboBox_Employee_EnableSetting.Text);

            string accessLevelString = $"AccessLevel:{(int)AccessLevel};EditMode:{(int)EditMode};EnableTreeViewSetting:{(int)EnableTreeViewSetting}";

            if (employeeDepartementSelected != null)
                employeeDepartementSelected.AccessLevel = accessLevelString;

            dataGridViewExtended.CurrentRowActive.Cells["AccessLevel"].Value = accessLevelString;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void ComboBox_Employee_EnableSetting_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            EnableTreeViewSetting = Enum.Parse<EnableSetting>(comboBox_Employee_EnableSetting.Text);

            string accessLevelString = $"AccessLevel:{(int)AccessLevel};EditMode:{(int)EditMode};EnableTreeViewSetting:{(int)EnableTreeViewSetting}";

            if (employeeDepartementSelected != null)
                employeeDepartementSelected.AccessLevel = accessLevelString;

            dataGridViewExtended.CurrentRowActive.Cells["AccessLevel"].Value = accessLevelString;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void ComboBox_Employee_EditMode_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            EditMode = Enum.Parse<EditMode>(comboBox_Employee_EditMode.Text);

            string accessLevelString = $"AccessLevel:{(int)AccessLevel};EditMode:{(int)EditMode};EnableTreeViewSetting:{(int)EnableTreeViewSetting}";

            if (employeeDepartementSelected != null)
                employeeDepartementSelected.AccessLevel = accessLevelString;

            dataGridViewExtended.CurrentRowActive.Cells["AccessLevel"].Value = accessLevelString;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void ComboBox_Employee_EditMode_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            EditMode = Enum.Parse<EditMode>(comboBox_Employee_EditMode.Text);
            string accessLevelString = $"AccessLevel:{(int)AccessLevel};EditMode:{(int)EditMode};EnableTreeViewSetting:{(int)EnableTreeViewSetting}";

            if (employeeDepartementSelected != null)
                employeeDepartementSelected.AccessLevel = accessLevelString;

            dataGridViewExtended.CurrentRowActive.Cells["AccessLevel"].Value = accessLevelString;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void ComboBox_Employee_AccessLevel_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            AccessLevel = Enum.Parse<AccessLevel>(comboBox_Employee_AccessLevel.Text);

            string accessLevelString = $"AccessLevel:{(int)AccessLevel};EditMode:{(int)EditMode};EnableTreeViewSetting:{(int)EnableTreeViewSetting}";

            if (employeeDepartementSelected != null)
                employeeDepartementSelected.AccessLevel = accessLevelString;

            dataGridViewExtended.CurrentRowActive.Cells["AccessLevel"].Value = accessLevelString;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void ComboBox_Employee_AccessLevel_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            AccessLevel = Enum.Parse<AccessLevel>(comboBox_Employee_AccessLevel.Text);

            string accessLevelString = $"AccessLevel:{(int)AccessLevel};EditMode:{(int)EditMode};EnableTreeViewSetting:{(int)EnableTreeViewSetting}";

            if (employeeDepartementSelected != null)
                employeeDepartementSelected.AccessLevel = accessLevelString;

            dataGridViewExtended.CurrentRowActive.Cells["AccessLevel"].Value = accessLevelString;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void ComboBox_Employee_Department_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            employeeDepartementSelected.Department = comboBox_Employee_Department.Text;
            dataGridViewExtended.CurrentRowActive.Cells["Department"].Value = comboBox_Employee_Department.Text;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void ComboBox_Employee_Department_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            employeeDepartementSelected.Department = comboBox_Employee_Department.Text;
            dataGridViewExtended.CurrentRowActive.Cells["Department"].Value = comboBox_Employee_Department.Text;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void ComboBox_Employee_Position_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            employeeDepartementSelected.Position = comboBox_Employee_Position.Text;
            dataGridViewExtended.CurrentRowActive.Cells["Position"].Value = comboBox_Employee_Position.Text;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void ComboBox_Employee_Position_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            employeeDepartementSelected.Position = comboBox_Employee_Position.Text;
            dataGridViewExtended.CurrentRowActive.Cells["Position"].Value = comboBox_Employee_Position.Text;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void TextBox_Employee_Size_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            employeeDepartementSelected.Size = textBox_Employee_Size.Text;
            dataGridViewExtended.CurrentRowActive.Cells["Size"].Value = textBox_Employee_Size.Text;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void DateTimePicker_Employee_Hire_Date_ValueChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            employeeDepartementSelected.HireDate = dateTimePicker_Employee_Hire_Date.Value.ToString("yyyy-MM-dd HH:mm:ss");
            dataGridViewExtended.CurrentRowActive.Cells["HireDate"].Value = dateTimePicker_Employee_Hire_Date.Value.ToString("yyyy-MM-dd HH:mm:ss");

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void TextBox_Employee_Telephone_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            employeeDepartementSelected.Telephone = textBox_Employee_Telephone.Text;
            dataGridViewExtended.CurrentRowActive.Cells["Telephone"].Value = textBox_Employee_Telephone.Text;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void TextBox_Employee_Address_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            employeeDepartementSelected.Address = textBox_Employee_Address.Text;
            dataGridViewExtended.CurrentRowActive.Cells["Address"].Value = textBox_Employee_Address.Text;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void TextBox_Employee_LastName_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            employeeDepartementSelected.LastName = textBox_Employee_LastName.Text;
            dataGridViewExtended.CurrentRowActive.Cells["LastName"].Value = textBox_Employee_LastName.Text;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void TextBox_Employee_Name_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;

            employeeDepartementSelected.Name = textBox_Employee_Name.Text;
            dataGridViewExtended.CurrentRowActive.Cells["Name"].Value = textBox_Employee_Name.Text;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        private void TextBox_Employee_Last6Digit_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            NeedSaveData = true;
            if (int.TryParse(textBox_Employee_Last6Digit.Text, out int last6Digit))
            {
                employeeDepartementSelected.Last6Digit = last6Digit;
                dataGridViewExtended.CurrentRowActive.Cells["Last6Digit"].Value = last6Digit;
            }

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();

            settingModified = "Employee";
            SaveUserSetting();
        }

        string initialDirectory = Settings.Default.DataBaseAddress;

        void PicturesBox_EmployeeImage_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            using (var openFileDialogExt = new OpenFileDialogExt
            {
                Title = @"Please select any Image",
                FileName = "",
                Filter = @"*.png|*.png|*.gif|*.gif|*.jpg|*.jpg",
                DefaultExt = "(*.png)|*.png",
                InitialDirectory = Path.Combine(initialDirectory, "\\Resources\\Photos\\"),
            })
            {
                if (openFileDialogExt.ShowDialog(this) == DialogResult.Cancel)
                    return;

                try
                {
                    PicturesBox_EmployeeImage.Image = Image.FromFile(openFileDialogExt.FileName);

                    if (!(openFileDialogExt.FileName.Contains(Settings.Default.DataBaseAddress + "\\Resources\\")))
                    {
                        #region"Copy the file front source directory to destinity directory"

                        var fo = new ShellFileOperation();

                        var source = new string[1];
                        var dest = new string[1];

                        source[0] = openFileDialogExt.FileName;

                        dest[0] = EmployeeImagePath;

                        fo.Operation = ShellFileOperation.FileOperations.FO_COPY;
                        fo.OwnerWindow = Handle;
                        fo.SourceFiles = source;
                        fo.DestFiles = dest;

                        fo.DoOperation();

                        #endregion"Copy the file front source directory to destinity directory"
                    }
                    else
                    {
                        ProcessEmployeeImage(openFileDialogExt.FileName);

                        var fo = new ShellFileOperation();
                        fo.Operation = ShellFileOperation.FileOperations.FO_DELETE;
                        fo.OwnerWindow = Handle;
                        fo.SourceFiles = new[] { EmployeeImagePath };
                        fo.DestFiles = new[] { EmployeeImagePath };

                        fo.DoOperation();

                        fo.Operation = ShellFileOperation.FileOperations.FO_COPY;
                        fo.OwnerWindow = Handle;
                        fo.SourceFiles = new[] { openFileDialogExt.FileName };
                        fo.DestFiles = new[] { EmployeeImagePath };

                        fo.DoOperation();
                    }
                }
                catch (Exception excp)
                {
                    PicturesBox_EmployeeImage.Image = null;
                    MessageBox.Show(@"Image Error ; " + excp.Message);
                }
            }
        }

        void InitializeUI_Employee(EmployeeInformation employeesSelected)
        {
            if (_employeesService.DepartmentsList.Contains("Department"))
                _employeesService.DepartmentsList.Remove("Department");

            UpdateUI_Employee(employeesSelected);

            //   GeneratedDataGridViedProfile(EmployeesSelected);

            NeedSaveData = false;
            button_AddNewEmployee.Enabled = true;
            button_SaveEmployee.Enabled = false;
            button_SaveEmployee.Text = "Save";
        }

        void UpdateUI_Employee(EmployeeInformation employeesSelected)
        {
            textBox_Employee_Name.Text = employeesSelected.Name;
            textBox_Employee_LastName.Text = employeesSelected.LastName;
            textBox_Employee_Address.Text = employeesSelected.Address;
            textBox_Employee_Last6Digit.Text = employeesSelected.Last6Digit + "";
            textBox_Employee_Telephone.Text = employeesSelected.Telephone;
            dateTimePicker_Employee_Hire_Date.Value = DateTime.Parse(employeesSelected.HireDate);
            textBox_Employee_Size.Text = employeesSelected.Size;

            comboBox_Employee_Position.SelectedItem = employeesSelected.Position;
            comboBox_Employee_Department.SelectedItem = employeesSelected.Department;

            AutoSizeColumnsMode = employeesSelected.AutoSizeColumnsMode;
            comboBox_Employee_AccessLevel.SelectedItem = employeesSelected.AccessLevel;
            AccessLevel = employeesSelected.AccessLevel;
            comboBox_Employee_EditMode.SelectedItem = employeesSelected.EditMode;
            EditMode = employeesSelected.EditMode;
            comboBox_Employee_EnableSetting.SelectedItem = employeesSelected.EnableTreeViewSetting;
            EnableTreeViewSetting = employeesSelected.EnableTreeViewSetting;

            ProcessEmployeeImage(EmployeeImagePath);
        }

        void ProcessEmployeeImage(string employeeImagePath)
        {
            string[] noimageColl = { "NoImage1.png", "NoImage2.png", "NoImage3.png", "NoImage4.png", "NoImage5.png" };
            string noimageFile = noimageColl[new Random().Next(0, noimageColl.Length)];

            if (File.Exists(employeeImagePath))
                PicturesBox_EmployeeImage.Image = LoadImageNoLock(employeeImagePath);
            else
                if (File.Exists(Path.Combine(Settings.Default.DataBaseAddress, "Resources", "Photos", noimageFile)))
                    PicturesBox_EmployeeImage.Image = LoadImageNoLock(Path.Combine(Settings.Default.DataBaseAddress, "Resources", "Photos", noimageFile));
                else
                    PicturesBox_EmployeeImage.Image = null;
        }

        static Image LoadImageNoLock(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            using var ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        async Task<bool> Last6Digit_Valid()
        {
            if (textBox_Employee_Last6Digit.Text.Length != 6)
            {
                MessageBox.Show(@"The Last6Digit most be 6 digit length. Last6Digit_Valid().",
                                   @"Wrongt lengt in value Last6Digit. Employees Management.",
                                         MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }

            int NewLast6Digit = Utilities.CastAsInt(textBox_Employee_Last6Digit.Text);

            bool valit6Digit = (await _employeesService.LoadEmployeeAsync()).Any(emp => emp.Last6Digit == NewLast6Digit);

            // If the Last6Digit already exists in the database, show an error message and return false.
            if (valit6Digit)
            {
                MessageBox.Show("Errors in the information, the employee Last6Digit number ( " + textBox_Employee_Last6Digit.Text + " ) already exist.",
                                                                        "Duplicate staff number.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        async Task<Table_Employee> AddNewEmployee()
        {
            var nextId = await _employeesService.GetNextIdAsync();

            var newAddEmployee = new Table_Employee
            {
                Index = nextId,
                ID = nextId,
                Last6Digit = 0,
                LastName = "",
                Name = "",
                Address = "",
                Telephone = "",
                Dob = DateTime.Now.ToShortDateString(),
                HireDate = DateTime.Now.ToShortDateString(),
                UserSetting = "",
                DataGridViewSetting = "",
                Position = "",
                Department = "",
                AccessLevel = _unitOfWork.TableEmployeesRepository.AccessLevelDefault,
                Size = "",
                Status = _unitOfWork.TableEmployeesRepository.StatusInfoDefault
            };

            _bindingSourceEmployeeVal.SuspendBinding();
            // AddNew() on a DataView/DataTable-backed BindingSource returns a DataRowView, not the entity type.
            DataRowView newRowView = (DataRowView)_bindingSourceEmployeeVal.AddNew();

            // Copy the values into the DataRowView backing the grid/UI.
            newRowView["Index"] = newAddEmployee.Index;
            newRowView["ID"] = newAddEmployee.ID;
            newRowView["Last6Digit"] = newAddEmployee.Last6Digit;
            newRowView["LastName"] = newAddEmployee.LastName;
            newRowView["Name"] = newAddEmployee.Name;
            newRowView["Address"] = newAddEmployee.Address;
            newRowView["Telephone"] = newAddEmployee.Telephone;
            newRowView["Dob"] = newAddEmployee.Dob;
            newRowView["HireDate"] = newAddEmployee.HireDate;
            newRowView["UserSetting"] = newAddEmployee.UserSetting;
            newRowView["DataGridViewSetting"] = newAddEmployee.DataGridViewSetting;
            newRowView["Position"] = newAddEmployee.Position;
            newRowView["Department"] = newAddEmployee.Department;
            newRowView["AccessLevel"] = newAddEmployee.AccessLevel;
            newRowView["Size"] = newAddEmployee.Size;
            newRowView["Status"] = newAddEmployee.Status;

            _bindingSourceEmployeeVal.EndEdit();
            _bindingSourceEmployeeVal.ResumeBinding();

            // Find the row's actual position in the (possibly sorted/filtered) view
            // and make it the current item, so the grid selection follows it.
            int newRowIndex = _bindingSourceEmployeeVal.List.IndexOf(newRowView);
            if (newRowIndex >= 0)
                _bindingSourceEmployeeVal.Position = newRowIndex;

            _bindingSourceEmployeeVal.ResetCurrentItem();

            if (dataGridViewExtended._dataGridView.Rows.Count > newRowIndex)
                dataGridViewExtended._dataGridView.CurrentCell = dataGridViewExtended._dataGridView.Rows[newRowIndex].Cells[0];

            var result = await _unitOfWork.TableEmployeesRepository.AddAsync(newAddEmployee);

            return result;
        }

        bool isNewEmployee;
        async void Button_AddEmployee_Click(object sender, EventArgs e)
        {
            button_AddNewEmployee.Enabled = false;
            button_SaveEmployee.Text = "Save EmployeeInformation";
            button_SaveEmployee.Enabled = true;

            try
            {
                var newEmployee = await AddNewEmployee();

                employeeDepartementSelected = newEmployee;                 // <-- repoint the stale pointer
                EmployeesSelected = new EmployeeInformation(newEmployee);  // keep this in sync too

                UpdateUI_Employee(EmployeesSelected);

                isNewEmployee = true;

                textBox_Employee_Last6Digit.Clear();
                textBox_Employee_Last6Digit.Focus();

            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Button_Add_Click() found an error " + error.Message,
                                 @"Employees Management has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void Button_SaveEmployee_Click(object sender, EventArgs e)
        {
            #region"Test if the Last6Digit number exist"

            if (!await Last6Digit_Valid())
            {
                textBox_Employee_Last6Digit.Focus();
                return;
            }

            #endregion"Test if the Last6Digit number exist"

            settingModified = "Employee";
            SaveUserSetting();
        }

        async void Button_DeleteEmployee_Click(object sender, EventArgs e)
        {
            // Guard against deleting the default user, which are not meant to be removed.
            // The default user is used for system operations and should not be deleted.
            if (employeeDepartementSelected.Name.Contains("No User Log On"))
            {
                MessageBox.Show(@"This employee is the default user and cannot be deleted.",
                                @"Delete EmployeeInformation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(@"Are you sure you want to delete this employee? This action cannot be undone.",
                            @"Delete EmployeeInformation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            DeleteEmployeeDepartmentSelected();
        }

        async void DeleteEmployeeDepartmentSelected()
        {
            // Guard against deleting the default department, which is not meant to be removed.
            // The default department is used for system operations and should not be deleted.
            if (employeeDepartementSelected.Name.Contains("No set to any department yet."))
            {
                MessageBox.Show(@"This department is the default department and cannot be deleted.",
                                @"Delete Department Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            button_SaveEmployee.Text = "Save Changes";
            button_SaveEmployee.Enabled = true;

            _bindingSourceEmployeeVal.SuspendBinding();

            if (_bindingSourceEmployeeVal.TableName.Contains("Table_Employees"))
            {
                await _unitOfWork.TableEmployeesRepository.DeleteByIdAsync(employeeDepartementSelected.Index);
                RemoveFromBindingSourceByIndex(employeeDepartementSelected.Index);
            }

            _bindingSourceEmployeeVal.ResumeBinding();
            _bindingSourceEmployeeVal.ResetBindings(false);
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
        async void RemoveFromBindingSourceByIndex(int index)
        {
            try
            {
                // ✅ .List resolves any nested BindingSource and returns the real underlying IList.
                // Iterating and removing from it directly is safe regardless of sort/filter state.
                IList list = _bindingSourceEmployeeVal.List;
                MessageDebugPosition = $"Removing itemEFtableTreeView with index {index} from BindingSource list with {list.Count} items";
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i] is DataRowView employee && employee.Row.Field<int>("Index") == index)
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

        void AnySetting_TextChanged(object? sender, EventArgs e)
        {
            if (!customTabControl.Bounds.Contains(customTabControl.PointToClient(MousePosition)))
                return;

            button_AddNewEmployee.Enabled = false;
            button_SaveEmployee.Enabled = true;
            NeedSaveData = true;

            if (_bindingSourceEmployeeVal.Position >= 0)
                _bindingSourceEmployeeVal.ResetCurrentItem();
        }

        #endregion"Process Employees"

        #region"Process Department"

        void SettingUI_Department()
        {
            textBox_Department_Name.TextChanged += AnySetting_TextChanged;
            textBox_Department_Coments.TextChanged += AnySetting_TextChanged;
            textBox_Department_ID.TextChanged += AnySetting_TextChanged;
            textBox_Department_Telephone.TextChanged += AnySetting_TextChanged;

            button_AddNewDept.Click += Button_AddNewDept_Click;
            button_DeleteDept.Click += Button_DeleteDept_Click;
            button_SaveDept.Click += Button_SaveDept_Click;
        }

        void InitializeUI_Department(DepartmentInformation departmentInformation)
        {
            _employeesService.DepartmentsList.Clear();
            _employeesService.DepartmentsList.Add("Department");

            textBox_Department_Name.Text = departmentInformation.DepartmentName;
            textBox_Department_Coments.Text = departmentInformation.DepartmentComments;
            textBox_Department_ID.Text = departmentInformation.ID + "";
            textBox_Department_Telephone.Text = departmentInformation.DepartmentTelephone;
        }

        void UpDateDepartmentSelected()
        {
            DepartmentSelected.ID = Utilities.CastAsInt(textBox_Department_ID.Text);
            DepartmentSelected.DepartmentName = textBox_Department_Name.Text;
            DepartmentSelected.DepartmentComments = textBox_Department_Coments.Text;
            DepartmentSelected.DepartmentTelephone = textBox_Department_Telephone.Text;
            DepartmentSelected.DeptAccessLevel = (Utilities.AccessLevel)comboBox_Employee_AccessLevel.SelectedItem;
            DepartmentSelected.DeptEditMode = (Utilities.EditMode)comboBox_Employee_EditMode.SelectedItem;

            foreach (Control dataControl in panel_dataGridViewProfile.Controls)
            {
                DataGridViewSetting dataGridViewSetting = (DataGridViewSetting)dataControl;

                DepartmentSelected.DataGridViewSettingDict.Clear();
                //     DepartmentSelected.DataGridViewSettingDict.Add(dataGridViewSetting.SettingName.Key,
                //                                                    dataGridViewSetting.SettingName.Value);
            }

            DepartmentSelected.SaveSetting();

            dataGridViewExtended.FirstDisplayedRow = "ID/" + DepartmentSelected.ID;

            // Do not call it here, EmployeeInformation will call automatically on event Save_Requested.
            //dataGridViewExtended_Employees_Management_Save_Requested(new object(), new EventArgs());
        }

        void Button_AddNewDept_Click(object? sender, EventArgs e)
        {
            try
            {
                button_AddNewDept.Enabled = false;

                isNewEmployee = true;

                Utilities.MouseUtility.MousePointerPosition(textBox_Department_Name, 2, 2);
                Utilities.MouseUtility.DoMouseClick(MouseButtons.Left);

                //   DataGridViewExtended_Employees_CurrentRowActive(sender, new CurrentRowActive_EventArgs((int)_newRow["ID"],
                //                                                                            dataGridViewExtended.CurrentRowActive));
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Button_AddDept_Click() found an error " + error.Message,
                                 @"Department Management has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Button_SaveDept_Click(object? sender, EventArgs e)
        {
            try
            {
                NeedSaveData = false;
                UpDateDepartmentSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase. Employees Management.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        void Button_DeleteDept_Click(object? sender, EventArgs e)
        {
            DeleteEmployeeDepartmentSelected();
        }

        #endregion"Process Department"

        #region"Profile"

        private void InitializeProfile()
        {
            button_DeleteProfile.Enabled = false;
        }

        private void GeneratedDataGridViedProfile(Table_Employee activeEmployee)
        {/*
            panel_dataGridViewProfile.Controls.Clear();

            foreach (KeyValuePair<string, List<ColumnSetting>> SettingName in activeEmployee.DataGridViewSettingDict)
            {
                DataGridViewSetting dataGridViewSetting = new DataGridViewSetting(SettingName);

                dataGridViewSetting.Dock = DockStyle.Top;
                dataGridViewSetting.Click += new EventHandler(DataGridViewSetting_Click);
                panel_dataGridViewProfile.Controls.Add(dataGridViewSetting);
            }*/
        }

        private void Panel_SettingControls_Click(object sender, EventArgs e)
        {
            activeDataGridviewSetting.BackgroundColor = controlBackgroundColor;
            activeDataGridviewSetting = new DataGridViewSetting();

            button_AddNewProfile.Enabled = false;
            button_DeleteProfile.Enabled = false;
        }

        private void Button_Profile_AddNew_Click(object sender, EventArgs e)
        {

        }

        private void Button_Profile_Save_Click(object sender, EventArgs e)
        {
            EmployeesSelected.DataGridViewSettingDict.Clear();

            foreach (Control dataControl in panel_dataGridViewProfile.Controls)
            {
                DataGridViewSetting dataGridViewSetting = (DataGridViewSetting)dataControl;

                //    EmployeesSelected.DataGridViewSettingDict.Add(dataGridViewSetting.SettingName.Key,
                //                                                                        dataGridViewSetting.SettingName.Value);
            }

            //TODO: We need to update the EmployeeInformation class, to save the AccessLevel, EditMode and EnableTreeViewSetting
            // EmployeesSelected.SaveSetting();
        }

        private void Button_Profile_Cancel_Click(object sender, EventArgs e)
        {
            //   GeneratedDataGridViedProfile(EmployeesSelected);
        }

        private void Button_Profile_Delete_Click(object sender, EventArgs e)
        {
            panel_dataGridViewProfile.Controls.Remove(activeDataGridviewSetting);
        }

        private Color controlBackgroundColor = new Color();
        private DataGridViewSetting activeDataGridviewSetting = new DataGridViewSetting();
        private void DataGridViewSetting_Click(object sender, EventArgs e)
        {
            DataGridViewSetting dataGridViewSetting = (DataGridViewSetting)sender;

            if (dataGridViewSetting == activeDataGridviewSetting)
                return;

            activeDataGridviewSetting.BackgroundColor = controlBackgroundColor;
            activeDataGridviewSetting = dataGridViewSetting;
            controlBackgroundColor = dataGridViewSetting.BackgroundColor;
            dataGridViewSetting.BackgroundColor = Color.Cornsilk;

            button_SaveProfile.Enabled = true;
            button_DeleteProfile.Enabled = true;
        }

        #endregion"Profile"

        #region"Timer SaveUserSetting if it's modifying the user interface."

        /// <summary>
        /// A string to keep track of which setting has been modified,
        /// used to determine what to save when the timer ticks.
        /// Two possible values: "Splitter" or "Employee", or both if both have been modified.
        /// </summary>
        string settingModified = "";

        /// <summary>
        /// Initialize the SaveUserSettingTimer to 10 seconds to save
        /// user setting if this is modifying the user interface.
        /// </summary>
        void InitializeSaveUserSettingTimer()
        {
            if (DesignMode)
                return;  // Do not run timers in the Visual Studio Designer

            SaveUserSettingTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            SaveUserSettingTimer.Tick += async (sender, e) => await SaveUserSettingTickAsync(sender, e);
        }

        /// <summary>
        /// A counter to keep track of the remaining seconds before saving user setting,
        /// If we need save inmediately, we can set this to 0 and call the SaveUserSettingTickAsync() method directly.
        /// </summary>
        int SecondsRemainingToSave = 10;
        /// <summary>
        /// An interval of 10 seconds to save user setting if this is modifying the user interface.
        /// </summary>
        System.Windows.Forms.Timer SaveUserSettingTimer;

        /// <summary>
        /// Start the SaveUserSettingTimer to save user setting if this is modifying the user interface,
        /// wait for others changes, if there is no more modification, save user setting after 10 seconds.
        /// Remember to set the settingModified string to "Splitter" or "Employee" when a setting is modified,
        /// so that the timer knows what to save, or both if both have been modified.
        /// </summary>
        void SaveUserSetting()
        {
            // Guard: timer not yet initialized during early layout events.
            if (SaveUserSettingTimer == null)
                return;

            SaveUserSettingTimer.Start();
            SecondsRemainingToSave = 10;

            _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  10 sec less to save setting."));
        }

        async Task SaveUserSettingTickAsync(object? sender, EventArgs e)
        {
            if (DesignMode || _employeesService == null || _currentEmployeeLogIn == null)
                return;

            // DesignMode is not reliable in a UserControl constructor — it only works
            // correctly after the control has been sited (i.e., added to a parent).
            // If you call InitializeSaveUserSettingTimer from the constructor, use 
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            if (_employeesService == null || string.IsNullOrEmpty(userSettingName))
                return;

            SecondsRemainingToSave--;

            if (SecondsRemainingToSave > 0)
            {
                _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  " + SecondsRemainingToSave + " sec less to save setting."));
                return;
            }

            SaveUserSettingTimer.Stop();
            _iappService.On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  "));//Clear the StatusBar.

            if (settingModified.Contains("Splitter"))
            {
                settingModified = "";
                await _currentEmployeeLogIn.UpDateSave_Splitter_UserSetting(userSettingName, splitContainer_Vertical.SplitterDistance,
                                                                        splitContainer_Horizontal.SplitterDistance);
            }

            if (settingModified.Contains("Employee"))
            {
                settingModified = "";
                await _unitOfWork.TableEmployeesRepository.UpdateAsync(employeeDepartementSelected);
            }

        }

        #endregion"Timer SaveUserSetting if it's modifying the user interface."   


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Unsubscribe TextChanged/SelectedValueChanged handlers that reach into
                // customTabControl (via PointToClient) so they can't fire against a
                // disposed control while messages are still pending (e.g. during
                // ComboBox teardown), which previously caused an ObjectDisposedException.
                comboBox_Employee_Department.SelectedValueChanged -= ComboBox_Employee_Department_SelectedValueChanged;
                comboBox_Employee_Department.TextChanged -= ComboBox_Employee_Department_TextChanged;
                comboBox_Employee_Position.SelectedValueChanged -= ComboBox_Employee_Position_SelectedValueChanged;
                comboBox_Employee_Position.TextChanged -= ComboBox_Employee_Position_TextChanged;
                comboBox_Employee_AccessLevel.SelectedValueChanged -= ComboBox_Employee_AccessLevel_SelectedValueChanged;
                comboBox_Employee_AccessLevel.TextChanged -= ComboBox_Employee_AccessLevel_TextChanged;
                comboBox_Employee_EditMode.SelectedValueChanged -= ComboBox_Employee_EditMode_SelectedValueChanged;
                comboBox_Employee_EditMode.TextChanged -= ComboBox_Employee_EditMode_TextChanged;
                comboBox_Employee_EnableSetting.SelectedValueChanged -= ComboBox_Employee_EnableSetting_SelectedValueChanged;
                comboBox_Employee_EnableSetting.TextChanged -= ComboBox_Employee_EnableSetting_TextChanged;

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }

}

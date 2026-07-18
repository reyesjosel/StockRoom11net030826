using BrightIdeasSoftware;
using StockRoom11net.Controls.BindingSourceExt;
using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using StockRoom11net.Properties;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Xml;
using static StockRoom11net.Controls.Custom_Events_Args;
using static StockRoom11net.Controls.Utilities;

namespace StockRoom11net.Controls
{
    public partial class DataTreeViewToAddCancelDelete : UserControl
    {
        #region"Events, Custom Controls Events with custom Args.*********************"

        #region"Show_DataTable"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Show_DataTable action")]
        public event Switch_DataTable_EventHandler? Switch_DataTable;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Switch_DataTable(Switch_DataTable_EventArgs e)
        {
            // Notify Subscribers
            Switch_DataTable?.Invoke(this, e);
        }

        #endregion

        #region"Save_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Save_Requested_EventHandler? Save_Requested;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Save_Requested(Save_Requested_EventArgs e)
        {
            // Notify Subscribers
            Save_Requested?.Invoke(this, e);
        }

        #endregion

        #region"SelectedIndexChanged"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The Selected Index Changed")]
        public event TreeViewSelectedIndexChangedEventHandler? SelectedIndexChanged;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_SelectedIndexChanged(TreeViewSelectedIndexChangedEventArgs e)
        {
            // Notify Subscribers
            SelectedIndexChanged?.Invoke(this, e);
        }

        #endregion

        #region"ContextMenuStripTreeViewOpening"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The Selected Index Changed")]
        public event ContextMenuStripTreeViewOpeningEventHandler? ContextMenuStripTreeViewOpening;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ContextMenuStripTreeViewOpeningEventHandler(object sender, CancelEventArgs e);

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_ContextMenuStripTreeViewOpening(CancelEventArgs e)
        {
            // Notify Subscribers
            ContextMenuStripTreeViewOpening?.Invoke(this, e);
        }

        #endregion

        #region"ToolStripMenuItemClick"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("A ToolStripMenuItem event Click")]
        public event ToolStripMenuItemClickEventHandler? ToolStripMenuItemClick;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_ToolStripMenuItemClick(ToolStripMenuItemClickEventArgs e)
        {
            // Notify Subscribers
            ToolStripMenuItemClick?.Invoke(this, e);
        }

        #endregion

        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event StatusBarMessageEventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessageEventHandler(object? sender, StatusBarMessage_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            StatusBarMessage?.Invoke(this, e);
        }

        #endregion"StatusBarMessage"

        #endregion"Events, Custom Controls Events with custom Args.*********************"

        #region"CurrentUserBroadcast"

        ITableEmployeeService _employeesService;
        EmployeeInformation.EmployeeInformation _currentEmployeeLogIn;

        /// <summary>
        /// The user setting name, we save userSettingName = DataTreeViewName + "_" + TableName;
        /// It is update at public object DataSource{ set }
        /// We saved the datasource name because in some cases,
        /// the same dataTreeView manipulates different dataSources.
        /// </summary>
        private string userSettingName = "";

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

        void EmployeesService_CurrentEmployeeLogInChanged(object? sender, EmployeeInformation.EmployeeInformation e)
        {
            CurrentEmployeeLogIn = e;
        }

        /// <summary>
        /// Process current employee information.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private EmployeeInformation.EmployeeInformation CurrentEmployeeLogIn
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
                olvDataTreeMaster.Font = userSetting.DataTreeViewFont;
                olvDataTreeMaster.Columns[0].Width = userSetting.DataTreeViewColumnTextNameWidth;
            }
        }

        #endregion"CurrentUserBroadcast"

        DataTable _dataTableTreeView;
        int _lastID = 99;
        // If we are using a bindingSource, used this in Load procedure.
        //    table = ((DataSet)_bindingSource.DataSource).Tables[_bindingSource.DataMember];
        // We ask per the lastID just before used.
        //            if (table.Rows.Count > 0)
        //                LastID = (int)table.Compute("MAX(ID)", "ID is Not null");
        //            else
        //                LastID = 0;
        /// <summary>
        /// Top value for ID field, option filter to select a group of row.
        /// table.Compute("MAX(ID)", "filter condition").
        /// LastID autoIncrement itself on each access
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

        void InitializedLastID()
        {
            if (_bindingSourceTreeView?.DataSource == null)
            {
                LastID = 100;
                return;
            }

            try
            {
                // Work with BindingList instead of DataSet
                var maxId = 100;

                if (_bindingSourceTreeView.Count > 0 && _bindingSourceTreeView.List[0] is Table_Base_TreeView)
                {
                    foreach (Table_Base_TreeView item in _bindingSourceTreeView)
                    {
                        var idValue = item.ID;
                        if (idValue is int id)
                        {
                            maxId = Math.Max(maxId, id);
                        }
                    }
                }

                LastID = maxId;
            }
            catch
            {
                LastID = 100;
            }
        }

        int CounterEvents = 0;
        /// <summary>
        /// Gets or sets a value indicating whether the application is running in debug mode.
        /// This property can be used to enable or disable debug-specific features or logging.
        /// Will send StatusBarMessage_EventArgs events.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DebugMode { get; set; }

        /// <summary>
        /// A message used to mark a position in the code for debugging purposes.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MessageDebugPosition { get; set; } = string.Empty;

        /// <summary>
        /// Represents the name of the database table associated with the current context.
        /// </summary>
        /// <remarks>This field is intended to store the name of a table as a string.  It is recommended
        /// to use a meaningful and valid table name that aligns with the database schema.</remarks>
        public string TableName = "";

        /// <summary>
        /// A list of items representing the nodes in the tree view.
        /// </summary>
        List<Table_Base_TreeView> ItemsList;
        /// <summary>
        /// A list of orphan nodes in the tree view, which are nodes that have a Parent_ID that does not correspond to any existing node's ID.
        /// These nodes are moved to a "DeletedTreeView" root to prevent them from being lost and to make them visible for correction.
        /// </summary>
        List<Table_Base_TreeView> OrphansNodes;
        BindingSourceValidating<Table_Base_TreeView> _bindingSourceTreeView;

        /// <summary>
        /// Gets or sets the <see cref="BindingSource"/> used as the data source for the tree view controls.
        /// </summary>
        /// <remarks>When a new <see cref="BindingSource"/> is assigned, the data source for the following
        /// tree view controls is updated: <list type="bullet">
        /// <itemEFtableTreeView><description><c>olvDataTreeMaster</c></description></itemEFtableTreeView>
        /// <itemEFtableTreeView><description><c>olvDataTree_toAdd</c></description></itemEFtableTreeView>
        /// <itemEFtableTreeView><description><c>olvDataTree_toCancel</c></description></itemEFtableTreeView>
        /// <itemEFtableTreeView><description><c>olvDataTree_toDelete</c></description></itemEFtableTreeView> </list> Additionally, the image list for
        /// the tree views is re-initialized.</remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingSourceValidating<Table_Base_TreeView> BindingSourceTreeView
        {
            get
            {
                return _bindingSourceTreeView;
            }

            set
            {
                try
                {
                    _bindingSourceTreeView = value;

                    TableName = _bindingSourceTreeView.TableName;

                    if (_bindingSourceTreeView.Count == 0)
                        return;

                    // ⚠️ Warning: The ObjectListView (OLV) control can enter an infinite recursion state if
                    // the data source contains circular references or invalid parent-child relationships.
                    // ✅ Data validation and integrity checks before assigning to OLV
                    // This is crucial to prevent issues like infinite recursion in OLV when rendering the tree.
                    // We check for: - presence of root nodes (Parent_ID == 0),
                    // - duplicate IDs, which can cause rendering issues,
                    // - orphan nodes (nodes with Parent_ID that doesn't match any existing ID), which can cause them to be lost in the tree.
                    // We also perform cycle detection to identify any circular parent-child relationships that could lead to infinite recursion
                    // in OLV. Any nodes that fail these checks are moved to a "Deleted" root node to ensure they remain visible for correction
                    // rather than being silently lost or causing application instability.
                    // Remenber, rootKeyValueToMaster ( 0) is reserved for the actual root nodes, so any node with Parent_ID == 0 is considered a root.
                    //           rootKeyValueToAdd    (25) can be used as an "Add" bucket if needed for similar purposes.
                    //           rootKeyValueToCancel (50) can be used as a "Cancel" bucket if needed for similar purposes. 
                    //           rootKeyValueToDelete (75) as a "Deleted" bucket to re-home any problematic nodes.
                    // So we most be careful to exclude these reserved values from the valid ID set when checking for orphan nodes,
                    // and to use the "Deleted" bucket for any nodes that fail validation or cycle detection.

                    // The best aproach is to delete any record with ID == 0, because 0 is reserved for "Master" root nodes, and any
                    // record with ID == 25, 50 or 75, because these values are reserved for the "Add", "Cancel" and "Deleted" buckets.
                    List<Table_Base_TreeView> itemsReservedID = _bindingSourceTreeView.List.Cast<Table_Base_TreeView>()
                                                                .Where(n => n.ID == 0 || n.ID == 25 || n.ID == 50 || n.ID == 75)
                                                                .ToList();

                    if(itemsReservedID.Count > 0)
                    {
                       RemoveRowReservedIDsAsync(itemsReservedID);
                    }

                    // ✅ Diagnose data before assigning to OLV
                    ItemsList = _bindingSourceTreeView.List.Cast<Table_Base_TreeView>().ToList();
                    List<(int ID, int? Parent_ID)> id_Parent_ID = ItemsList.Where(n => n.ID >= 0)
                                                                           .Select(n => (n.ID, n.Parent_ID))
                                                                           .ToList();

                    id_Parent_ID.Sort((a, b) => a.ID.CompareTo(b.ID));
                    id_Parent_ID.Sort((a, b) => a.Parent_ID.GetValueOrDefault().CompareTo(b.Parent_ID.GetValueOrDefault()));
                    id_Parent_ID.Sort();

                    List<Table_Base_TreeView> roots = ItemsList.Where(n => n.Parent_ID == 0)
                                                               .ToList();

                    List<int> dupIDs = ItemsList.GroupBy(n => n.ID).Where(g => g.Count() > 1)
                                                .Select(g => g.Key)
                                                .ToList();

                    HashSet<int> validIDs = new HashSet<int>(ItemsList.Select(n => n.ID))
                                                {
                                                 // rootKeyValueToMaster, //  0 is already excluded by n.Parent_ID != 0
                                                    rootKeyValueToAdd,    // 25
                                                    rootKeyValueToCancel, // 50
                                                    rootKeyValueToDelete  // 75                                                    
                                                };

                    OrphansNodes = ItemsList.Where(n => n.Parent_ID == null   // ← null = unattached node, no parent reference at all
                                                     || n.Parent_ID is > 0
                                                    && !validIDs.Contains(n.Parent_ID.Value)).ToList();

                    // ── 0. Self-loop fix ─────────────────────────────────────────────────────
                    // Must run BEFORE the orphan pass so a self-looping delete-bucket root
                    // cannot poison every orphan that gets re-homed to it.
                    foreach (var node in ItemsList.Where(n => n.Parent_ID.HasValue && n.Parent_ID == n.ID))
                    {
                        // If this node IS the delete-bucket (ID == rootKeyValueToDelete),
                        // we cannot send it back to itself — fall back to the master root (0).
                        node.Parent_ID = (node.ID == rootKeyValueToDelete) ? rootKeyValueToMaster   // 0
                                                                           : rootKeyValueToDelete;  // 75

                        Debug.WriteLine($"Self-loop fix: node ID={node.ID} ('{node.Text_Name}') " +
                                        $"pointed to itself. Moved to Parent_ID={node.Parent_ID}.");
                    }

                    if (OrphansNodes.Count > 0)
                    {
                        foreach (var item in OrphansNodes)
                        {
                            item.Parent_ID = rootKeyValueToDelete; // Move OrphansNodes to a "Deleted" root to prevent them
                                                                   // from being lost and to make them visible for correction

                            Debug.WriteLine($"Orphan fix: node ID={item.ID} ('{item.Text_Name}') " +
                                            $"was orphaned. Moved to Parent_ID={item.Parent_ID}.");
                        }
                    }

                    // ── Cycle detection ───────────────────────────────────────────────────────
                    // Rebuild idLookup AFTER the self-loop pass so corrected Parent_IDs are seen.
                    var idLookup = ItemsList.Where(n => n.ID > 0).ToDictionary(n => n.ID);
                    var cycleNodes = ItemsList
                        .Where(n => n.Parent_ID.HasValue && n.Parent_ID.Value > 0)
                        .Where(n =>
                        {
                            var visited = new HashSet<int> { n.ID };
                            int? current = n.Parent_ID;
                            while (current.HasValue && current.Value > 0)
                            {
                                if (!visited.Add(current.Value))
                                    return true; // cycle detected
                                if (!idLookup.TryGetValue(current.Value, out var parentNode))
                                    break;
                                current = parentNode.Parent_ID;
                            }
                            return false;
                        }).ToList();

                    if (cycleNodes.Count != 0)
                    {
                        foreach (var node in cycleNodes)
                        {
                            // Guard: never move a node to its own ID (avoids re-creating a self-loop).
                            node.Parent_ID = (node.ID == rootKeyValueToDelete)
                                             ? rootKeyValueToMaster   // 0
                                             : rootKeyValueToDelete;  // 75
                            Debug.WriteLine($"Cycle fix: node ID={node.ID} ('{node.Text_Name}') " +
                                            $"was in a circular parent chain. Moved to Parent_ID={node.Parent_ID}.");
                        }
                    }
                    // ─────────────────────────────────────────────────────────────────────────

                    Debug.WriteLine($"Total: {ItemsList.Count} | Roots (Parent_ID==0): {roots.Count} | DupIDs: {string.Join(",", dupIDs)} | Orphans: {OrphansNodes.Count} | CycleNodes: {cycleNodes.Count}");

                    if (roots.Count == 0 || dupIDs.Count != 0 || cycleNodes.Count != 0)  // ← added cycleNodes check
                    {
                        MessageBox.Show($"Tree data invalid!\nRoots: {roots.Count}\nDuplicate IDs: {string.Join(",", dupIDs)}\nOrphans: {OrphansNodes.Count}\nCycle nodes: {cycleNodes.Count}",
                            "DataSource Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    /*

                    OrphansNodes = ItemsList.Where(n => n.Parent_ID == null   // ← null = unattached node, no parent reference at all
                                                 || n.Parent_ID is > 0 
                                                 && !validIDs.Contains(n.Parent_ID.Value)).ToList();

                    if(OrphansNodes.Count > 0)
                    {
                        foreach( var item in OrphansNodes)
                        {
                            item.Parent_ID = rootKeyValueToDelete; // Move OrphansNodes to a "Deleted" root to prevent them
                                                                   // from being lost and to make them visible for correction
                        }
                                               
                    }

                    // ── Cycle detection ──────────────────────────────────────────────────────
                    // A circular parent chain (e.g. A→B→A, or A→A) causes
                    // Branch.Visible.get in ObjectListView to recurse infinitely when the
                    // tree is expanded, resulting in a StackOverflowException.
                    // Walk every node's ancestor chain; if an ID is visited twice the chain
                    // contains a cycle. Re-home the offending node to the delete bucket so
                    // the data remains visible for correction rather than being silently lost.
                    var idLookup = ItemsList.Where(n => n.ID > 0).ToDictionary(n => n.ID);
                    var cycleNodes = ItemsList
                        .Where(n => n.Parent_ID.HasValue && n.Parent_ID.Value > 0)
                        .Where(n =>
                        {
                            var visited = new HashSet<int> { n.ID };
                            int? current = n.Parent_ID;
                            while (current.HasValue && current.Value > 0)
                            {
                                if (!visited.Add(current.Value))
                                    return true; // cycle detected
                                if (!idLookup.TryGetValue(current.Value, out var parentNode))
                                    break;
                                current = parentNode.Parent_ID;
                            }
                            return false;
                        }).ToList();

                    if (cycleNodes.Count != 0)
                    {
                        foreach (var node in cycleNodes)
                        {
                            node.Parent_ID = rootKeyValueToDelete;
                            Debug.WriteLine($"Cycle fix: node ID={node.ID} ('{node.Text_Name}') " +
                                            $"was in a circular parent chain. Moved to delete bucket.");
                        }
                    }
                    // ─────────────────────────────────────────────────────────────────────────

                    Debug.WriteLine($"Total: {ItemsList.Count} | Roots (Parent_ID==0): {roots.Count} | DupIDs: {string.Join(",", dupIDs)} | Orphans: {OrphansNodes.Count}");

                    if (roots.Count == 0 || dupIDs.Count != 0)
                    {
                        MessageBox.Show($"Tree data invalid!\nRoots: {roots.Count}\nDuplicate IDs: {string.Join(",", dupIDs)}\nOrphans: {OrphansNodes.Count}",
                            "DataSource Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //return; // ← prevents the freeze
                    }
                    */

                    if (InvokeRequired)
                    {
                        Invoke(() => olvDataTreeMaster.DataSource = _bindingSourceTreeView);
                    }
                    else
                    {
                        olvDataTreeMaster.DataSource = _bindingSourceTreeView;
                    }

                    olvDataTree_ToAdd.DataSource = _bindingSourceTreeView;
                    olvDataTree_ToCancel.DataSource = _bindingSourceTreeView;
                    olvDataTree_ToDelete.DataSource = _bindingSourceTreeView;

                    InitializedLastID();
                    InitializeImageList();
                    _ = SetupRowsToAddAsync();

                    // Select the itemEFtableTreeView whose data object matches
                    var myModelObject = _bindingSourceTreeView.List.Cast<Table_Base_TreeView>().FirstOrDefault(n => n.Parent_ID == 2);
                    olvDataTreeMaster.SelectedObject = myModelObject;
                    //   olvDataTreeMaster.EnsureModelVisible(myModelObject);
                    //   olvDataTreeMaster.Focus();

                    // ✅ Minimal trigger to force OLV to render rows after DataSource assignment
                    var firstRoot = _bindingSourceTreeView.List.Cast<Table_Base_TreeView>().FirstOrDefault(n => n.Parent_ID == 0);
                    if (firstRoot != null)
                        olvDataTreeMaster.Expand(firstRoot);         // expand first root node to trigger render

                    if (_bindingSourceTreeView.Count > 1)
                        _bindingSourceTreeView.Position = 1;         // move position to trigger PositionChanged → repaint

                    if (olvDataTreeMaster.GetItemCount() > 0)
                        olvDataTreeMaster.EnsureVisible(0);          // scroll back to top
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error setting data source: {ex.Message}", "Data Source Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
            }
        }

        async void RemoveRowReservedIDsAsync(List<Table_Base_TreeView> itemsReserved)
        {
            if (TableName.Contains("Table_StockRoom_TreeView"))
            {
                foreach (var item in itemsReserved)
                {
                    await _unitOfWork.TableStockRoomTreeViewRepository.DeleteAsync(item.Index);
                    RemoveFromBindingSourceByIndex(item.Index);
                }
            }
            else if (TableName.Contains("Table_TimeLine_TreeView"))
            {
                foreach (var item in itemsReserved)
                {
                    await _unitOfWork.TableTimeLineTreeViewRepository.DeleteAsync(item.Index);
                    RemoveFromBindingSourceByIndex(item.Index);
                }   
            }
        }

        /// <summary>
        /// This shows or hides the panel where ToAdd, ToCancel and ToDelete.
        /// True if the DataTreeView is in setting mode, false otherwise.
        /// </summary>
        bool _settingMode = false;
        /// <summary>
        /// This shows or hides the panel where ToAdd, ToCancel and ToDelete.
        /// True if the DataTreeView is in setting mode, false otherwise.
        /// </summary>        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SettingMode
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
                    splitContainer_DataTreeView.Panel2Collapsed = false;
                    splitContainer_DataTreeView.SplitterDistance = Settings.Default.SplitterDistance_DataTreeViewToAdd_Cancel_Delete;

                    On_SelectedIndexChanged(new TreeViewSelectedIndexChangedEventArgs()
                    {
                        CurrentNode = _currentNodeItem
                    });

                    OlvDataTreeMaster_SelectedIndexChanged(new CustomTabControl(), new EventArgs());
                }
                else
                {
                    splitContainer_DataTreeView.Panel2Collapsed = true;
                }
            }
        }

        /// <summary>
        /// Shows or hides the panel where ToAdd, ToCancel and ToDelete.
        /// True if the DataTreeView is in setting mode, false otherwise.
        /// </summary>
        /// <param name="state"></param>
        public void ClosePanelSetting(bool state)
        {
            SettingMode = state;
        }


       // [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
       // public string CurrentDepartmentLogIn { get; set; }

        private IUnitOfWork _unitOfWork;

        public DataTreeViewToAddCancelDelete(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            InitializeComponent();
        }

        public DataTreeViewToAddCancelDelete()
        {
            InitializeComponent();
        }

        public DataTreeViewToAddCancelDelete(BindingSource bindingSourceDataTreeView)
        {
            InitializeComponent();
            BindingSourceTreeView = new BindingSourceValidating<Table_Base_TreeView> { DataSource = bindingSourceDataTreeView };
        }

        /// <summary>
        /// Injects the unit of work after the control has been created by the designer.
        /// </summary>
        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        void DataTreeViewToAdd_Cancel_Delete_Load(object sender, EventArgs e)
        {
            SettingMode = false; // Set to false to hide the panel with ToAdd, ToCancel and ToDelete when the control loads.

            InitializeSaveUserSettingTimer();

            Initialize_olvDataTreeMaster();
            Initialize_olvDataTree_toAdd();
            Initialize_olvDataTree_toCancel();
            Initialize_olvDataTree_toDelete();

            DataTreeListView_Shown();
        }

        void DataTreeListView_Shown()
        {
            // The whole point of a DataTreeListView is to write no code.
            // So there is very little code here.

            // Put some images against each row
            olvColumn_TextName.ImageGetter = delegate (object? row) { return "user"; };

            // This does a better job of auto sizing the columns
            olvDataTreeMaster.AutoResizeColumns();
            olvColumn_TextName.Width = 200;                       
        }

        void DataTreeView_Save_Requested(object? sender, Save_Requested_EventArgs e)
        {
            Save_Requested_EventArgs save_Requested_EventArgs = new Save_Requested_EventArgs()
            {
                SaveEvent = NotificationEvents.DataBaseUpDated,
                DataTableName = TableName,
                Message = "DataTreeViewToAddCancelDelete, Save_Requested()"
            };

            On_Save_Requested(save_Requested_EventArgs);
        }

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

            // Add the timer to the components container to ensure it is disposed properly when the control is disposed.
            // otherswise, the timer would continue to run and could cause memory leaks or unexpected behavior after the control is disposed.
            components.Add(SaveUserSettingTimer);
        }

        int _sec = 10;
        /// <summary>
        /// An interval of 10 seconds to save user setting if this is modifying the user interface.
        /// </summary>
        System.Windows.Forms.Timer SaveUserSettingTimer;

        void SaveUserSetting()
        {           
            SaveUserSettingTimer.Start();
            _sec = 10;

            On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  10 sec less to save dataTreeView."));
        }

        async Task SaveUserSettingTickAsync(object? sender, EventArgs e)
        {
            _sec--;

            if (_sec > 0)
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  " + _sec + " sec less to save dataTreeView."));
                return;
            }

            SaveUserSettingTimer.Stop();
            On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  "));//Clear the StatusBar.
                        
            await _currentEmployeeLogIn.UpDateSave_DataTreeView_UserSetting(olvDataTreeMaster.Font, olvDataTreeMaster.Columns[0].Width);
        }

        #endregion"Timer SaveUserSetting if it's modifying the user interface."   
        
        #region"DataTreeListViewMaster"

        HotItemStyle hotItemStyle = new();
        RowBorderDecoration rowBorderDec = new();
        Color foreColor = Color.White;
        Color backColor = Color.White;
        bool keyPressDataTreeList = false;
        /// <summary>
        /// An empty node item used as a placeholder when there are no matching tasks to display in the tree view.
        /// </summary>
        Table_Base_TreeView _emptyNodeItem = new Table_Base_TreeView()
        {
            Index = 100000,
                    ID = 100000,
                    Parent_ID = 100000,
                    Code = "",
                    Text_Name = "",
                    Node_PDF = "",
                    Node_Picture = "",
                    Description_Short = "",
                    Description_Expand = "",
                    Image = "",
                    String_Filter = "",
                    ItemCount = 0,
                    ItemOpen = 0,
                    DateCreated = "",
                    Created_by = "",
                    AvailableDepartments = "",
                    Properties = "",
                    Message_String = ""
                };

        /// <summary>
        /// Image list for displaying task icons in the tree view.
        /// </summary>
        ImageList imageListTasks = new();

        /// <summary>
        /// The key value (0) that maps to the master treeView.
        /// </summary>
        readonly int rootKeyValueToMaster = 0;
        /// <summary>
        /// The value (25) to add to the root key.
        /// </summary>
        readonly int rootKeyValueToAdd = 25;
        /// <summary>
        /// The root key value (50) to add to cancellation.
        /// </summary>
        readonly int rootKeyValueToCancel = 50;
        /// <summary>
        /// The root key value (75) to be deleted.
        /// </summary>
        readonly int rootKeyValueToDelete = 75;

        /// <summary>
        /// This domy ImageList is used to change the hight of the HotItem, ensure that expanded descriptions
        /// are displayed correctly.
        /// </summary>
        /// <remarks>This image list is intended for UI customization, particularly to support visual
        /// features such as hot itemEFtableTreeView highlighting and description expanded.</remarks>
        private readonly ImageList imageListHotItem = new();

        void Initialize_olvDataTreeMaster()
        {
            olvDataTreeMaster.Name = "DataTreeListViewMaster";
            olvDataTreeMaster.AccessibleName = "DataTreeListViewMaster";
            olvDataTreeMaster.KeyAspectName = "ID";
            olvDataTreeMaster.ParentKeyAspectName = "Parent_ID";
            // The DataTreeListView needs to know the key that identifies root level objects.
            // DataTreeListView can handle that key being any data type, but the Designer only deals in strings.
            // Since we want a non-string value to identify keys, we have to set it explicitly here.

            // If Parent_ID is int? (nullable int), set RootKeyValue explicitly as int
            //olvDataTreeMaster.RootKeyValue = (int?)0;  // match the nullable type
            olvDataTreeMaster.RootKeyValue = rootKeyValueToMaster;
            olvDataTreeMaster.AllowDrop = true;
            olvDataTreeMaster.FullRowSelect = true;
            olvDataTreeMaster.ShowKeyColumns = false;
            olvDataTreeMaster.AutoGenerateColumns = false;

            olvDataTreeMaster.OwnerDraw = true;

            olvDataTreeMaster.GotFocus   += OlvDataTreeMaster_GotFocus;
            olvDataTreeMaster.Resize     += OlvDataTreeMaster_Resize;
            olvDataTreeMaster.ItemDrag   += OlvDataTreeMaster_ItemDrag;
            olvDataTreeMaster.KeyDown    += OlvDataTreeMaster_KeyDown;
            olvDataTreeMaster.Expanding  += OlvDataTreeMaster_Expanding;
            olvDataTreeMaster.Expanded   += olvDataTreeMaster_Expanded;
            olvDataTreeMaster.MouseDown  += OlvDataTreeMaster_MouseDown;
            olvDataTreeMaster.MouseClick += OlvDataTreeMaster_MouseClick;
            olvDataTreeMaster.MouseWheel += olvDataTreeMaster_MouseWheel;
            olvDataTreeMaster.ColumnWidthChanged    += OlvDataTreeMaster_ColumnWidthChanged;
            olvDataTreeMaster.SelectedIndexChanged  += OlvDataTreeMaster_SelectedIndexChanged;

            imageListTasks = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(32, 32),
                TransparentColor = Color.Transparent
            };

            // 2. Set the desired image size.
            imageListHotItem.ImageSize = new Size(32, 42);
            // You can add images from project resources or files.
            imageListHotItem.Images.Add(Resources.close);
            imageListHotItem.Images.Add(Resources.dial);
            // 4. Assign the ImageList to the ObjectListView.
            // ✅ Keep imageListTasks for row icons — don't overwrite it
            olvDataTreeMaster.SmallImageList = imageListTasks;

            // How much space do we want to give each row? Obviously, this should be at least
            // the height of the images used by the renderer
            //olvDataTreeMaster.RowHeight = 16;
            olvDataTreeMaster.EmptyListMsg = "No tasks match the filter";
            olvDataTreeMaster.UseAlternatingBackColors = false;
            olvDataTreeMaster.UseHotItem = true;

            toolStripMenuItem_FullRowSelect.Checked = true;

            SetupColumns();
            SetupDragAndDrop();
            SetupDescriptionColumn();
            InitializeContextMenuStripTreeView();

            // ✅ Load images AFTER SmallImageList is assigned
            InitializeImageList();
        }

        void OlvDataTreeMaster_GotFocus(object? sender, EventArgs e)
        {
            
        }
        
        /// <summary>
        /// Initializes the ImageList by loading images from disk.
        /// This is a synchronous wrapper that calls the async version.
        /// </summary>
        public void InitializeImageList()
        {
            // Fire and forget - don't block the UI thread
            _ = InitializeImageListAsync();
        }

        /// <summary>
        /// Initializes the ImageList by loading images from disk based on the
        /// Image field of all Table_TimeLine_TreeView records retrieved via EF.
        /// </summary>
        public async Task InitializeImageListAsync(CancellationToken cancellationToken = default)
        {
            if (_bindingSourceTreeView is null) return;

            foreach (var node in _bindingSourceTreeView)
            {
                string? imageName = ((Table_Base_TreeView)node).Image;

                if (string.IsNullOrEmpty(imageName) || imageName.Contains("Undefined"))
                    continue;

                // Avoid duplicates in the ImageList
                if (imageListTasks.Images.ContainsKey(imageName))
                    continue;

                string filePath = Path.Join(Settings.Default.DataBaseAddress, imageName);

                try
                {
                    Image image = Image.FromFile(filePath);
                    if(image == null)
                        using (var form = new Form() { TopMost = true })
                        {
                            MessageBox.Show(form, @"The image path was not found, " + filePath,
                                                    @"System error, The application will continue without an image.",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    imageListTasks.Images.Add(imageName, image);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading image '{imageName}': {ex.Message}");
                }
            }
        }

        void OlvDataTreeMaster_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down || e.KeyData == Keys.Up ||
               e.KeyData == Keys.Left || e.KeyData == Keys.Right)
                keyPressDataTreeList = true;
        }

        void SetupColumns()
        {
            // ✅ Column 0 must have an AspectName to display data
            olvDataTreeMaster.GetColumn(0).AspectName = "Text_Name"; // or "Code" — whatever holds the node label

            olvDataTreeMaster.GetColumn(1).ImageGetter = delegate (object x)
            {
                if (x is Table_Base_TreeView node && !string.IsNullOrEmpty(node.Image))
                    return node.Image;// ✅ matches the key added in InitializeImageListAsync
                return null;
            };
           
           // olvDataTreeMaster.GetColumn(1).Renderer = new MultiImageRenderer(Resources.star16, 5, 0, 40);
        }

        void SetupDragAndDrop()
        {
            // The RearrangingDropSink overwrites IsSimpleDropSink = true.
            //olvDataTreeMaster.IsSimpleDropSink = true;
            olvDataTreeMaster.IsSimpleDragSource = false;
            olvDataTreeMaster.CanDrop += OlvDataTree_CanDrop;
            olvDataTreeMaster.Dropped += OlvDataTree_Dropped;
            olvDataTreeMaster.ModelDropped += OlvDataTree_ModelDropped;
            ((SimpleDropSink)olvDataTreeMaster.DropSink).CanDropBetween = true;
            ((SimpleDropSink)olvDataTreeMaster.DropSink).ModelCanDrop += OlvDataTree_ModelCanDrop;

            // Make listView capable of dragging rows out
            SimpleDragSource simpleDragSourceMaster = new SimpleDragSource(true);

            olvDataTreeMaster.DragSource = simpleDragSourceMaster;

            // Make listView capable of accepting drops.
            // More than that, make it so it's items can be rearranged
            RearrangingDropSink rearrangingDropSinkToMaster = new RearrangingDropSink(true)
            {
                Billboard = new BillboardOverlay
                {
                    BackColor = Color.LightGoldenrodYellow,
                    Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold),
                    CornerRounding = 5,
                    BorderColor = Color.Black,
                    BorderWidth = 1
                }
            };

            olvDataTreeMaster.DropSink = rearrangingDropSinkToMaster;
        }

        void SetupDescriptionColumn()
        {
            // Setup a described task renderer, which draws a large icon
            // with a title, and a description under the title.
            // Almost all of this configuration could be done through the Designer
            // but I've done it through code that make it clear what's going on.

            // Create and install an appropriately configured renderer 
            olvColumn_Description.Renderer = CreateDescribedTaskRenderer();

            // Now let's setup the couple of other bits that the column needs

            // Tell the column which property should be used to get the title
            // In OLV 2.9.1.0 the column's AspectName drives the title (top bold line)
            olvColumn_Description.AspectName = "Description_Short";
            
            // Tell the column which property holds the identifier for the image for row.
            // We could also have installed an ImageGetter
            olvColumn_Description.ImageAspectName = "Image";

            // Put a little bit of space around the task and its description
            olvColumn_Description.CellPadding = new Rectangle(4, 2, 4, 2);
            olvColumn_Description.Name = "olvColumn_Description";

            // ✅ OLV-native proportional sizing — no Resize handler required
            // but the user can not resize columns when FillsFreeSpace is true, so we set it only on the description column
            olvColumn_TextName.FillsFreeSpace = false;
            //olvColumn_TextName.FreeSpaceProportion = 3;   // 60%  (3 out of 5)

            olvColumn_Description.FillsFreeSpace = true;
            //olvColumn_Description.FreeSpaceProportion = 2;  // 40%  (2 out of 5)

            ((OLVColumn)olvDataTreeMaster.Columns["olvColumn_Description"]).FillsFreeSpace = true;
        }

        DescribedTaskRenderer CreateDescribedTaskRenderer()
        {
            // Let's create an appropriately configured renderer.
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();

            // Give the renderer its own collection of images.
            // If this isn't set, the renderer will use the SmallImageList from the ObjectListView.
            // (this is standard Renderer behavior, not specific to DescribedTaskRenderer).
            renderer.ImageList = imageListTasks;

            // Description: smaller bottom line
            // Tell the renderer which property holds the text to be used as a description
            renderer.DescriptionAspectName = "Description_Expand";

            // Change the formatting slightly
            renderer.TitleFont = new Font("Tahoma", 10, FontStyle.Bold);
            renderer.DescriptionFont = new Font("Tahoma", 8);
            renderer.ImageTextSpace = 8;
            renderer.TitleDescriptionSpace = -3;

            // Use older Gdi rendering, since most people think the text looks clearer
            renderer.UseGdiTextRendering = true;

            // If you like colors other than black and grey, you could uncomment these
            //            renderer.TitleColor = Color.DarkBlue;
            //            renderer.DescriptionColor = Color.CornflowerBlue;

            return renderer;
        }

        void SendStatusBarMessage(string info)
        {
            if (DebugMode == false)
                return;

            CounterEvents++;
            //   On_StatusBarMessage(new StatusBarMessage_EventArgs(info + " " + CounterEvents));
        }

        #region"Drag & Drop"

        void OlvDataTree_ModelCanDrop(object? sender, ModelDropEventArgs e)
        {
            int targeId = e.TargetModel as Table_Base_TreeView != null ?
                              ((Table_Base_TreeView)e.TargetModel).ID : 0;

            int sourceModel_ID = e.SourceModels[0] as Table_Base_TreeView != null ?
                      ((Table_Base_TreeView)e.SourceModels[0]).ID : 0;

            if (targeId == sourceModel_ID)
            {
                e.Handled = true;
                e.InfoMessage = "   Can't drop on myself";
                e.Effect = DragDropEffects.None;
                e.DropSink.Billboard.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
                e.DropSink.Billboard.BackColor = Color.Yellow;
                e.DropSink.Billboard.CornerRounding = 5;
                e.DropSink.Billboard.BorderColor = Color.Black;
                e.DropSink.Billboard.BorderWidth = 1;
                e.DropSink.FeedbackColor = Color.Black;
                return;
            }

            e.Handled = true;
            e.Effect = DragDropEffects.Move;
            e.DropSink.Billboard.BackColor = Color.Yellow;
            e.DropSink.FeedbackColor = Color.Black;
            if (e.DropTargetItem != null)
                e.InfoMessage = "   " + e.DropTargetLocation.ToString().Replace("Item", " Item ") +
                                        e.DropTargetItem.Text;
            else
                e.InfoMessage = "   To root";
        }

        async void OlvDataTree_ModelDropped(object? sender, ModelDropEventArgs e)
        {
            e.Handled = true;
            e.Effect = DragDropEffects.Move;
            await RearrangeModels(e);
        }

        void OlvDataTree_CanDrop(object? sender, OlvDropEventArgs e)
        {
            try
            {
                int sourceModel_ID = ((OLVDataObject)e.DataObject).ModelObjects[0] as Table_Base_TreeView != null ?
                                     ((Table_Base_TreeView)((OLVDataObject)e.DataObject).ModelObjects[0]).ID : 0;

                int targeId = 0;

                if (e.DropTargetItem != null)
                    targeId = e.DropTargetItem.RowObject as Table_Base_TreeView != null ?
                                    ((Table_Base_TreeView)e.DropTargetItem.RowObject).ID : 0;

                if (targeId == sourceModel_ID)
                {
                    e.Handled = true;
                    e.InfoMessage = "   Can't drop on myself";
                    e.Effect = DragDropEffects.None;
                    e.DropSink.Billboard.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
                    e.DropSink.Billboard.BackColor = Color.Yellow;
                    e.DropSink.Billboard.CornerRounding = 5;
                    e.DropSink.Billboard.BorderColor = Color.Black;
                    e.DropSink.Billboard.BorderWidth = 1;
                    e.DropSink.FeedbackColor = Color.Black;
                    return;
                }

                e.Handled = true;
                e.Effect = DragDropEffects.Move;
                e.DropSink.Billboard.BackColor = Color.Yellow;
                e.DropSink.FeedbackColor = Color.Black;
                if (e.DropTargetItem != null)
                    e.InfoMessage = "   " + e.DropTargetLocation.ToString().Replace("Item", " Item ") +
                                            e.DropTargetItem.Text;
                else
                    e.InfoMessage = "   To root";
            }
            catch (Exception error)
            {
                string _ = error.Message;
            }
        }

        void OlvDataTree_Dropped(object? sender, OlvDropEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            e.Handled = true;
        }

        void OlvDataTreeMaster_ItemDrag(object? sender, ItemDragEventArgs e)
        {
            Table_Base_TreeView _itemDragged = e.Item as Table_Base_TreeView;
        }

        /// <summary>
        /// Do the work of processing the dropped items
        /// </summary>
        /// <param name="args"></param>
        async Task RearrangeModels(ModelDropEventArgs args)
        {
            try
            {
                int targeId = ((Table_Base_TreeView)args.TargetModel)?.ID ?? 0;

                int modelId = ((Table_Base_TreeView)args.SourceModels[0])?.ID ?? 0;

                if (targeId == modelId)
                    return;

                switch (args.DropTargetLocation)
                {
                    case DropTargetLocation.AboveItem:
                        {
                            await AddObjectAboveItem(args);
                            break;
                        }
                    case DropTargetLocation.LeftOfItem:
                        olvDataTreeMaster.MoveObjects(args.DropTargetIndex, args.SourceModels);
                        break;
                    case DropTargetLocation.BelowItem:
                        {
                            await AddObjectBelowItemToAddAsync(args);
                            break;
                        }
                    case DropTargetLocation.RightOfItem:
                        olvDataTreeMaster.MoveObjects(args.DropTargetIndex + 1, args.SourceModels);
                        break;
                    case DropTargetLocation.Background:
                        {
                            await AddObjectToRootToAddAsync(args);
                            break;
                        }
                    case DropTargetLocation.Item:
                        break;
                    case DropTargetLocation.None:
                        {
                            await AddObjectToRootToAddAsync(args);
                            break;
                        }
                    default:
                        return;
                }

                olvDataTreeMaster.RebuildAll(true);   // master tree also reflects the deletion
                olvDataTreeMaster.ClearHotItem();
            }
            catch (Exception error)
            {
                string message = error.Message;
            }
        }

        async Task AddObjectAboveItem(ModelDropEventArgs args)
        {
            try
            {
                if (args.DropTargetItem == null)
                    return;
                                    
                foreach (Table_Base_TreeView model in args.SourceModels.OfType<Table_Base_TreeView>())
                {
                    await CreatedAddObjectToEFAsync(model, args);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving new itemEFtableTreeView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async Task AddObjectBelowItemToAddAsync(ModelDropEventArgs args)
        {
            try
            {
                if (args.DropTargetItem == null)
                    return;
                
                foreach (Table_Base_TreeView model in args.SourceModels.OfType<Table_Base_TreeView>())
                {
                    model.ID = 100000; // temporary ID to avoid EF tracking issues, will be updated in
                                       // CreatedAddObjectToEFAsync() with the actual ID generated.
                    await CreatedAddObjectToEFAsync(model, args);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving new itemEFtableTreeView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async Task AddObjectToRootToAddAsync(ModelDropEventArgs args)
        {
            try
            {
                if (args.DropTargetItem != null)
                    return;
                foreach (Table_Base_TreeView model in args.SourceModels.OfType<Table_Base_TreeView>())
                {
                    model.ID = 100000; // temporary ID to avoid EF tracking issues, will be updated in
                                       // CreatedAddObjectToEFAsync() with the actual ID generated.
                    await CreatedAddObjectToEFAsync(model, args);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving new itemEFtableTreeView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async Task CreatedAddObjectToEFAsync(Table_Base_TreeView model, ModelDropEventArgs args)
        {            
            string typeName = _bindingSourceTreeView.TableName;

            if (typeName == nameof(Table_StockRoom_TreeView))
            {
                Table_StockRoom_TreeView? itemEF = await _unitOfWork.TableStockRoomTreeViewRepository.GetByIdAsync(model.ID);
                if (itemEF != null)
                {
                    model.Parent_ID  = ((Table_Base_TreeView)args.TargetModel).ID;
                    itemEF.Parent_ID = model.Parent_ID;
                    await _unitOfWork.TableStockRoomTreeViewRepository.UpdateAsync(itemEF, CancellationToken.None);
                    int positionIndex = FindPositionById(model.ID);
                    if (positionIndex >= 0)
                        BindingSourceTreeView.Position = positionIndex;

                    BindingSourceTreeView.ResetBindings(false);
                    olvDataTree_ToDelete.RebuildAll(true);
                    olvDataTree_ToDelete.ClearHotItem();
                    return;
                }

                var typedItem = new Table_StockRoom_TreeView
                {
                    Index = LastID,  // Incrementing the index for each new node to ensure uniqueness
                    ID    = _lastID, // Use the same ID as Index for simplicity, but in a real application
                                     // you might want to use a different strategy for generating unique IDs
                    Parent_ID = ((Table_Base_TreeView)args.TargetModel)?.ID ?? rootKeyValueToMaster,
                    Text_Name = model.Text_Name,
                    Description_Short = model.Description_Short,
                    Description_Expand = model.Description_Expand,
                    Image = model.Image
                };
                await _unitOfWork.TableStockRoomTreeViewRepository.AddAsync(typedItem, CancellationToken.None);
                BindingSourceTreeView.Add(typedItem);

                int position = FindPositionById(typedItem.ID);
                if (position >= 0)
                    BindingSourceTreeView.Position = position;
            }
            else if (typeName == nameof(Table_TimeLine_TreeView))
            {
                Table_TimeLine_TreeView? itemEF = await _unitOfWork.TableTimeLineTreeViewRepository.GetByIdAsync(model.ID);
                if (itemEF != null)
                {                    
                    model.Parent_ID = ((Table_Base_TreeView)args.TargetModel)?.ID ?? rootKeyValueToMaster; ;
                    itemEF.Parent_ID = model.Parent_ID;
                    await _unitOfWork.TableTimeLineTreeViewRepository.UpdateAsync(itemEF, CancellationToken.None);
                    int positionIndex = FindPositionById(model.ID);
                    if (positionIndex >= 0)
                        BindingSourceTreeView.Position = positionIndex;

                    BindingSourceTreeView.ResetBindings(false);
                    olvDataTree_ToDelete.RebuildAll(true);
                    olvDataTree_ToDelete.ClearHotItem();
                    return;
                }

                var typedItem = new Table_TimeLine_TreeView
                {
                    Index = LastID,  // Incrementing the index for each new node to ensure uniqueness
                    ID    = _lastID, // Use the same ID as Index for simplicity, but in a real application
                                     // you might want to use a different strategy for generating unique IDs
                    Parent_ID = ((Table_Base_TreeView)args.TargetModel)?.ID ?? rootKeyValueToMaster,
                    Text_Name = model.Text_Name,
                    Description_Short = model.Description_Short,
                    Description_Expand = model.Description_Expand,
                    Image = model.Image
                };
                await _unitOfWork.TableTimeLineTreeViewRepository.AddAsync(typedItem, CancellationToken.None);
                BindingSourceTreeView.Add(typedItem);
                int position = FindPositionById(typedItem.ID);
                if (position >= 0)
                    BindingSourceTreeView.Position = position;
            }
        }

        /// <summary>
        /// Finds the BindingSource position of the itemEFtableTreeView with the given ID.
        /// BindingList&lt;T&gt; does not support BindingSource.Find() — this is the correct alternative.
        /// Returns -1 if not found.
        /// </summary>
        private int FindPositionById(int id)
        {
            for (int i = 0; i < BindingSourceTreeView.Count; i++)
            {
                var item = BindingSourceTreeView[i];
                if (item is Table_Base_TreeView node && node.ID == id)
                    return i;
            }
            return -1;
        }

        #endregion"Drag & Drop"

        /// <summary>
        /// This flag is used to avoid the execution of SplitterMoved event during the initialization of the form, because
        /// at initialization we set the SplitterDistance according to the user setting, and we do not want to save the user
        /// setting at this moment, because it is not a user action, it is just the application of the user setting.
        /// </summary>        
        bool internalResizeEvent = false;
        void OlvDataTreeMaster_ColumnWidthChanged(object? sender, ColumnWidthChangedEventArgs e)
        {
            // Only save user setting if the first column (Text_Name) is resized, not the description column,
            // which fills free space and can be resized by the user but we don't want to save that width as it is not meaningful.
            if (e.ColumnIndex != olvDataTreeMaster.Columns[0].Index)
                return;

            if (internalResizeEvent)
                return;
           
            if (e.ColumnIndex == olvDataTreeMaster.Columns[0].Index)
            {
                // Update the user setting for the column width
                SaveUserSetting();                
            }
        }

        void OlvDataTreeMaster_Resize(object? sender, EventArgs e)
        {
            internalResizeEvent = true;
            olvDataTreeMaster.Columns[0].Width = (int)(olvDataTreeMaster.Width * 0.60);
         // olvColumn_Description (Columns[1]) fills the remaining 40% via FillsFreeSpace = true
        }

        int expandingRootNode_ID = 0;
        Table_TimeLine_TreeView expandingNode;
        void OlvDataTreeMaster_Expanding(object? sender, TreeBranchExpandingEventArgs e)
        {
            return;
            if (olvDataTreeMaster.ExpandedObjects == null)
                return;

            if (e.Item == null)
                return;

            int? expanding_parentID;
            var type = e.Item.GetType();
           // expandingNode = (Table_TimeLine_TreeView)e.Item.RowObject;

            // if (expandingNode.Row.RowState == DataRowState.Detached)
            //     return;

            var expanding_Object = expandingNode.Parent_ID;

            if (expanding_Object == null)
                expanding_parentID = null;
            else
                expanding_parentID = expandingNode.Parent_ID;

            if (expanding_parentID != null)
                return;

            //    expandingRootNode_ID = (int)expandingNode.ID;

            //   foreach (var itemEFtableTreeView in olvDataTreeMaster.ExpandedObjects)
            //   {
            // olvDataTreeMaster.Collapse(itemEFtableTreeView);
            //   }

            //    int objectsCount = olvDataTreeMaster.Roots.Cast<object>().Count();
            //    if (expandingRootNode_ID > objectsCount)
            //        expandingRootNode_ID = objectsCount - 1;

            // olvDataTreeMaster.EnsureVisible(expandingRootNode_ID);
        }

        TreeBranchExpandedEventArgs treeBranchExpandedEventArgs;
        void olvDataTreeMaster_Expanded(object? sender, TreeBranchExpandedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (treeBranchExpandedEventArgs != null)
            {
                olvDataTreeMaster.Collapse(treeBranchExpandedEventArgs.Item);
            }

            treeBranchExpandedEventArgs = e;

            // olvDataTreeMaster.EnsureVisible(e.Item.Index);
        }
        
        Type DataBoundObject;
        string DataBoundObject_Name;
        DataRowView? CurrentDataRowViewActive = null;
        Table_Base_TreeView? _currentNodeItem = null;

        /// <summary>
        /// Handles the event triggered when the selected index of the ObjectListView data tree changes.
        /// </summary>
        /// <remarks>This method updates the current data-bound object and its associated properties when
        /// the selection changes. It ensures that the selected itemEFtableTreeView is valid and processes the selection only if
        /// certain conditions are met, such as the mouse position being within the bounds of the control or a key press
        /// triggering the event.</remarks>
        /// <param name="sender">The source of the event, typically the ObjectListView control.</param>
        /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
        public void OlvDataTreeMaster_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {                
                Type type = sender.GetType();

                // Check if the mouse is outside the bounds of the control and no key press triggered the event
                // If so, exit the method early, unless the sender is a CustomTabControl
                //   if (!(olvDataTreeMaster.Bounds.Contains(PointToClient(MousePosition))) & !keyPressDataTreeList)
                //       if (!type.Name.Contains("CustomTabControl"))
                //           return;

                keyPressDataTreeList = false;

                if (olvDataTreeMaster.SelectedItem == null)
                    return;

                DataBoundObject = olvDataTreeMaster.SelectedItem.RowObject.GetType();
                DataBoundObject_Name = DataBoundObject.Name;

                if (DataBoundObject_Name.Contains("TreeView"))
                {
                    Table_Base_TreeView? _currentNodeTBT = olvDataTreeMaster.SelectedItem.RowObject as Table_Base_TreeView;
                    if (_currentNodeTBT != null)
                    {

                        _currentNodeItem = _currentNodeTBT;

                        // Change the image list based on the length of Description_Expand
                        // If exist some text in Description_Expand, use imageListHotItem size 32x42;
                        // otherwise, use imageListTasks size 32x32
                        if (_currentNodeTBT.Description_Expand != null &&  _currentNodeTBT.Description_Expand.Length > 2)
                            olvDataTreeMaster.SmallImageList = imageListHotItem;
                        else
                            olvDataTreeMaster.SmallImageList = imageListTasks;

                        UpDateCurrentSelectedIndex();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         
        public void UpDateCurrentSelectedIndex()
        {
            On_SelectedIndexChanged(new TreeViewSelectedIndexChangedEventArgs()
            {
                CurrentNode = _currentNodeItem
            });
        }

        void OlvDataTreeMaster_MouseClick(object? sender, MouseEventArgs e)
        {
            if (olvDataTreeMaster.SelectedItem == null)
            {
                _currentNodeItem = _emptyNodeItem;
                _bindingSourceTreeView.Position = -1;
                UpDateCurrentSelectedIndex();
            }
        }

        void OlvDataTreeMaster_MouseDown(object? sender, MouseEventArgs e)
        {
            internalResizeEvent = false;

            if (olvDataTreeMaster.HotCellHitLocation == HitTestLocation.Nothing)
            {
                if (_bindingSourceTreeView.Position == -1)
                    return;
                olvDataTreeMaster.FocusedItem = null;
                _currentNodeItem = _emptyNodeItem;
                _bindingSourceTreeView.Position = -1;
                UpDateCurrentSelectedIndex();
            }
        }

        void olvDataTreeMaster_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                if (true)
                {
                    float currentSize = olvDataTreeMaster.Font?.Size ?? Font.Size;
                    float newSize = e.Delta > 0 ? currentSize + 0.5f : currentSize - 0.5f;
                    newSize = Math.Clamp(newSize, 10f, 34f);

                    Font newFont = new Font(olvDataTreeMaster.Font!.FontFamily, newSize, olvDataTreeMaster.Font.Style);

                    olvDataTreeMaster.Font = newFont;
                    olvDataTreeMaster.Invalidate();
                }                               

                ((HandledMouseEventArgs)e).Handled = true;
                
                SaveUserSetting();
            }
        }

        #region"ContextMenuStripTreeView"

        void InitializeContextMenuStripTreeView()
        {
            ContextMenuStripTreeView.Opening += ContextMenuStripTreeView_Opening;
            toolStripMenuItem_SingleExpandedNode.Click += ToolStripMenuItem_singleExpandedNode_Click;
            toolStripMenuItem_Refresh.Click += ToolStripMenuItem_Refresh_Click;
        }

        void ContextMenuStripTreeView_Opening(object? sender, CancelEventArgs e)
        {            
            ContextMenuStripTreeView.Items.Clear();
            ContextMenuStripTreeView.Items.Add(toolStripMenuItem_HotItem);
            ContextMenuStripTreeView.Items.Add(new ToolStripSeparator());
            ContextMenuStripTreeView.Items.Add(toolStripMenuItem_Refresh);
            ContextMenuStripTreeView.Items.Add(new ToolStripSeparator());
            ContextMenuStripTreeView.Items.Add(toolStripMenuItem_TimeLine);
            if (SettingMode)
            {
                ContextMenuStripTreeView.Items.Add(new ToolStripSeparator());
                ContextMenuStripTreeView.Items.Add(toolStripMenuItem_SwitchDataTable);
            }

            On_ContextMenuStripTreeViewOpening(e);
        }

        void ToolStripMenuItem_HotItem_DropDownItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            olvDataTreeMaster.UseTranslucentHotItem = false;
            olvDataTreeMaster.UseHotItem = true;
            olvDataTreeMaster.UseExplorerTheme = false;

            switch (e.ClickedItem.Text)
            {
                case "None":
                    {
                        olvDataTreeMaster.UseHotItem = false;
                        break;
                    }
                case "Text Color":
                    {
                        if (toolStripMenuItem_TextColor.Checked)
                        {
                            hotItemStyle.ForeColor = foreColor;
                            hotItemStyle.BackColor = backColor;
                            olvDataTreeMaster.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_TextColor.Checked = false;
                            break;
                        }
                        else
                        {
                            foreColor = hotItemStyle.ForeColor;
                            backColor = hotItemStyle.BackColor;

                            hotItemStyle.ForeColor = Color.AliceBlue;
                            hotItemStyle.BackColor = Color.FromArgb(255, 64, 64, 64);
                            olvDataTreeMaster.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_TextColor.Checked = true;
                            break;
                        }
                    }
                case "Border":
                    {
                        if (toolStripMenuItem_Border.Checked)
                        {
                            rowBorderDec.BorderPen = null;
                            rowBorderDec.CornerRounding = 0;

                            hotItemStyle.Decoration = rowBorderDec;
                            olvDataTreeMaster.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Border.Checked = false;
                            break;
                        }
                        else
                        {
                            rowBorderDec.BorderPen = new Pen(Color.SeaGreen, 2);
                            rowBorderDec.CornerRounding = 4.0f;

                            hotItemStyle.Decoration = rowBorderDec;
                            olvDataTreeMaster.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Border.Checked = true;
                            break;
                        }
                    }
                case "Translucent":
                    {
                        if (toolStripMenuItem_Translucent.Checked)
                        {
                            rowBorderDec.FillBrush = null;
                            rowBorderDec.CornerRounding = 0;

                            hotItemStyle.Decoration = rowBorderDec;
                            olvDataTreeMaster.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Translucent.Checked = false;
                            break;
                        }
                        else
                        {
                            rowBorderDec.FillBrush = new SolidBrush(Color.FromArgb(64, Color.Blue));
                            rowBorderDec.CornerRounding = 4.0f;

                            hotItemStyle.Decoration = rowBorderDec;
                            olvDataTreeMaster.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Translucent.Checked = true;
                            break;
                        }
                    }
                case "Lightbox":
                    {
                        if (toolStripMenuItem_Lightbox.Checked)
                        {
                            hotItemStyle.Decoration = null;
                            olvDataTreeMaster.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Lightbox.Checked = false;
                            break;
                        }
                        else
                        {
                            hotItemStyle.Decoration = new LightBoxDecoration();
                            olvDataTreeMaster.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Lightbox.Checked = true;
                            break;
                        }
                    }
                case "FullRowSelect":
                    {
                        if (toolStripMenuItem_FullRowSelect.Checked)
                        {
                            olvDataTreeMaster.FullRowSelect = false;
                            olvDataTreeMaster.UseHotItem = true;
                            //olvDataTreeMaster.UseExplorerTheme = true;

                            toolStripMenuItem_FullRowSelect.Checked = false;
                        }
                        else
                        {
                            olvDataTreeMaster.FullRowSelect = true;
                            //olvDataTreeMaster.UseHotItem = false;
                            //olvDataTreeMaster.UseExplorerTheme = true;

                            toolStripMenuItem_FullRowSelect.Checked = true;
                        }
                        break;
                    }
            }

            olvDataTreeMaster.Invalidate();
        }

        void ToolStripMenuItem_Refresh_Click(object? sender, EventArgs e)
        {
            if (BindingSourceTreeView == null)
                return;

            string? sortOrder = BindingSourceTreeView.Sort;

            if (sortOrder != null && BindingSourceTreeView.Sort.Contains("DESC"))
                BindingSourceTreeView.Sort = "Parent_ID ASC";
            else
                BindingSourceTreeView.Sort = "Parent_ID DESC";

            olvDataTreeMaster.ClearHotItem();
            olvDataTreeMaster.Invalidate();
        }

        void ToolStripMenuItem_singleExpandedNode_Click(object? sender, EventArgs e)
        {

        }

        public void ToolStripMenuItem_TimeLine_Click(object sender, EventArgs e)
        {
            On_ToolStripMenuItemClick(new ToolStripMenuItemClickEventArgs(toolStripMenuItem_TimeLine));

            action = new Action(() =>
            {
               // SettingMode = !_settingMode;
            });

            ThreadSafeInvoke(action);
        }

        void SwitchDataTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            On_Switch_DataTable(new Switch_DataTable_EventArgs()
            {
                DataTableName = _bindingSourceTreeView != null ? BindingSourceTreeView.TableName : "No DataTable",
            });
        }

        #endregion"ContextMenuStripTreeView"

        #endregion"DataTreeListViewMaster"

        #region"olvDataTree_toAdd"

        bool mouseLeave = false;
        readonly List<string> _newNodeNames = new List<string>()
        {
            "I'm ready, pick me",
            "Look no further, drag me",
            "Choose me..."
        };
                
        async Task SetupRowsToAddAsync()
        {
            if (_unitOfWork is null)
                return; // Sanity check, though this should never happen since the constructor
                        // requires a non-null IUnitOfWork, but the other constructors do not,
                        // until we refactor those to also require an IUnitOfWork,
                        // we need this check to avoid null reference exceptions.

            try
            {
                MessageDebugPosition = "SetupRowsToAddAsync() - Start";
                _bindingSourceTreeView.RaiseListChangedEvents = false;
                _bindingSourceTreeView.SuspendBinding();
                _bindingSourceTreeView.AllowNew = true;

                string typeName = _bindingSourceTreeView.TableName;

                if (typeName.Contains("Table_StockRoom_TreeView"))
                {
                    MessageDebugPosition = "SetupRowsToAddAsync() - Adding new nodes";
                    foreach (string nodeName in _newNodeNames)
                    {
                        MessageDebugPosition = $"SetupRowsToAddAsync() - Checking if node exists: {nodeName}";
                        Table_StockRoom_TreeView? node = await _unitOfWork.TableStockRoomTreeViewRepository.FirstOrDefaultAsync(n => n.Text_Name == nodeName);

                        MessageDebugPosition = $"Node check complete for: {nodeName}, node found: {(node != null)}";
                        if (node != null)
                            continue;

                        var newEntity = new Table_StockRoom_TreeView
                        {
                            Index = LastID,  // Incrementing the index for each new node to ensure uniqueness
                            ID    = _lastID, // Use the same ID as Index for simplicity, but in a real application
                                             // you might want to use a different strategy for generating unique IDs
                            Parent_ID = rootKeyValueToAdd,
                            Text_Name = nodeName,
                            Node_PDF = "",
                            Node_Picture = "",
                            Image = "",
                            String_Filter = "",
                            ItemCount = 0,
                            DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            Created_by = "",
                            AvailableDepartments = $"AvalaibleDepart LIKE '*{_employeesService.CurrentDepartmentLogIn}*'",
                            Properties = "",
                            Message_String = "",
                            Description_Short = "",
                            Description_Expand = "",
                        };

                        await _unitOfWork.TableStockRoomTreeViewRepository.AddAsync(newEntity, CancellationToken.None);
                        BindingSourceTreeView.Add(newEntity);
                    }
                }
                else if (typeName.Contains("Table_TimeLine_TreeView"))
                {
                    MessageDebugPosition = "SetupRowsToAddAsync() - Adding new nodes";
                    foreach (string nodeName in _newNodeNames)
                    {
                        MessageDebugPosition = $"SetupRowsToAddAsync() - Checking if node exists: {nodeName}";
                        Table_TimeLine_TreeView? node = await _unitOfWork.TableTimeLineTreeViewRepository.FirstOrDefaultAsync(n => n.Text_Name == nodeName);

                        MessageDebugPosition = $"Node check complete for: {nodeName}, node found: {(node != null)}";
                        if (node != null)
                            continue;

                        var newEntity = new Table_TimeLine_TreeView
                        {
                            Index = LastID,  // Incrementing the index for each new node to ensure uniqueness
                            ID    = _lastID, // Use the same ID as Index for simplicity, but in a real application
                                             // you might want to use a different strategy for generating unique IDs
                            Parent_ID = rootKeyValueToAdd,
                            Text_Name = nodeName,
                            Node_PDF = "",
                            Node_Picture = "",
                            Image = "",
                            String_Filter = "",
                            ItemCount = 0,
                            DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            Created_by = "",
                            AvailableDepartments = $"AvalaibleDepart LIKE '*{_employeesService.CurrentDepartmentLogIn}*'",
                            Properties = "",
                            Message_String = "",
                            Description_Short = "",
                            Description_Expand = "",
                        };

                        await _unitOfWork.TableTimeLineTreeViewRepository.AddAsync(newEntity, CancellationToken.None);
                        BindingSourceTreeView.Add(newEntity);
                    }
                }

                MessageDebugPosition = "SetupRowsToAddAsync() - Finished adding nodes, resuming binding";
                _bindingSourceTreeView.RaiseListChangedEvents = true;
                _bindingSourceTreeView.ResumeBinding();
                _bindingSourceTreeView.AllowNew = false;
            }
            catch (Exception error)
            {
                MessageDebugPosition = $"SetupRowsToAddAsync() - Error: {error.Message}";
            }
        }
             
        void Initialize_olvDataTree_toAdd()
        {
            olvDataTree_ToAdd.Name = "DataTreeListViewtoAdd";
            olvDataTree_ToAdd.KeyAspectName = "ID";
            olvDataTree_ToAdd.ParentKeyAspectName = "Parent_ID";
            olvDataTree_ToAdd.RootKeyValue = rootKeyValueToAdd;
            olvDataTree_ToAdd.AllowDrop = true;
            olvDataTree_ToAdd.FullRowSelect = true;
            olvDataTree_ToAdd.ShowKeyColumns = false;
            olvDataTree_ToAdd.AutoGenerateColumns = false;
            ((OLVColumn)olvDataTree_ToAdd.Columns[0]).FillsFreeSpace = true;
            olvDataTree_ToAdd.SelectedIndexChanged += olvDataTree_ToAdd_SelectedIndexChanged;

            SetupDragAndDrop_toAdd();
        }

        public void olvDataTree_ToAdd_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                Type type = sender.GetType();

                // Check if the mouse is outside the bounds of the control and no key press triggered the event
                // If so, exit the method early, unless the sender is a CustomTabControl
                //   if (!(olvDataTreeMaster.Bounds.Contains(PointToClient(MousePosition))) & !keyPressDataTreeList)
                //       if (!type.Name.Contains("CustomTabControl"))
                //           return;

                keyPressDataTreeList = false;

                if (olvDataTree_ToAdd.SelectedItem == null)
                    return;

                DataBoundObject = olvDataTree_ToAdd.SelectedItem.RowObject.GetType();
                DataBoundObject_Name = DataBoundObject.Name;

                if (DataBoundObject_Name.Contains("TreeView"))
                {
                    var _currentNodeToAddTBT = olvDataTree_ToAdd.SelectedItem.RowObject as Table_Base_TreeView;
                    
                    if (_currentNodeToAddTBT != null)
                        if (_currentNodeItem != null && _currentNodeItem.ID == _currentNodeToAddTBT.ID)
                            return;

                    _currentNodeItem = _currentNodeToAddTBT;

                    UpDateCurrentSelectedIndex();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SetupDragAndDrop_toAdd()
        {
            olvDataTree_ToAdd.IsSimpleDropSink = true;
            olvDataTree_ToAdd.IsSimpleDragSource = false;
            olvDataTree_ToAdd.CanDrop += OlvDataTreeToAdd_CanDrop;
            olvDataTree_ToAdd.Dropped += OlvDataTreeToAdd_Dropped;
            olvDataTree_ToAdd.ModelDropped += OlvDataTreeToAdd_ModelDropped;
            ((SimpleDropSink)olvDataTree_ToAdd.DropSink).CanDropBetween = true;
            ((SimpleDropSink)olvDataTree_ToAdd.DropSink).ModelCanDrop += OlvDataTreeToAdd_ModelCanDrop;

            olvDataTree_ToAdd.ItemDrag += (sender, e) => { mouseLeave = false; };
            olvDataTree_ToAdd.DragLeave += (sender, e) => { mouseLeave = true; };

            // Make listView capable of dragging rows out
            SimpleDragSource simpleDragSourceToAdd = new SimpleDragSource(true);

            olvDataTree_ToAdd.DragSource = simpleDragSourceToAdd;

            // Make listView capable of accepting drops.
            // More than that, make it so it's items can be rearranged
            RearrangingDropSink rearrangingDropSinkToAdd = new RearrangingDropSink(true)
            {
                Billboard = new BillboardOverlay
                {
                    BackColor = Color.LightGoldenrodYellow,
                    Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold),
                    CornerRounding = 5,
                    BorderColor = Color.Black,
                    BorderWidth = 1
                }
            };
            olvDataTree_ToAdd.DropSink = rearrangingDropSinkToAdd;
        }

        void OlvDataTreeToAdd_CanDrop(object? sender, OlvDropEventArgs e)
        {
            try
            {
                var draggedObject = ((DataTreeListView)((OLVDataObject)e.DataObject).ListView);
                if (draggedObject.Name == "DataTreeListViewMaster")
                {
                    e.Handled = true;
                    e.InfoMessage = "   You can't drop those items here.";
                    e.Effect = DragDropEffects.None;
                    e.DropSink.Billboard.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
                    e.DropSink.Billboard.BackColor = Color.Red;
                    e.DropSink.Billboard.CornerRounding = 5;
                    e.DropSink.Billboard.BorderColor = Color.Black;
                    e.DropSink.Billboard.BorderWidth = 1;
                    e.DropSink.FeedbackColor = Color.Black;
                    return;
                }

                if (mouseLeave && draggedObject.Name == "DataTreeListViewtoAdd")
                {
                    e.Handled = true;
                    e.InfoMessage = "   You can't drop new items here.";
                    e.Effect = DragDropEffects.None;
                    e.DropSink.Billboard.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
                    e.DropSink.Billboard.BackColor = Color.Red;
                    e.DropSink.Billboard.CornerRounding = 5;
                    e.DropSink.Billboard.BorderColor = Color.Black;
                    e.DropSink.Billboard.BorderWidth = 1;
                    e.DropSink.FeedbackColor = Color.Black;
                    return;
                }

                int sourceModel_ID = 0;
                sourceModel_ID = ((OLVDataObject)e.DataObject).ModelObjects[0] as Table_Base_TreeView != null ?
                                    ((Table_Base_TreeView)((OLVDataObject)e.DataObject).ModelObjects[0]).ID : 0;

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = e.DropTargetItem.RowObject as Table_Base_TreeView != null ?
                                    ((Table_Base_TreeView)e.DropTargetItem.RowObject).ID : 0;

                if (targeId == sourceModel_ID)
                {
                    e.Handled = true;
                    e.InfoMessage = "   Can't drop on myself";
                    e.Effect = DragDropEffects.None;
                    e.DropSink.Billboard.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
                    e.DropSink.Billboard.BackColor = Color.Yellow;
                    e.DropSink.Billboard.CornerRounding = 5;
                    e.DropSink.Billboard.BorderColor = Color.Black;
                    e.DropSink.Billboard.BorderWidth = 1;
                    e.DropSink.FeedbackColor = Color.Black;
                    return;
                }

                e.Handled = true;
                e.Effect = DragDropEffects.Move;
                e.DropSink.Billboard.BackColor = Color.Yellow;
                e.DropSink.FeedbackColor = Color.Black;
                if (e.DropTargetItem != null)
                    e.InfoMessage = "   " + e.DropTargetLocation.ToString().Replace("Item", " Item ") +
                                            e.DropTargetItem.Text;
                else
                    e.InfoMessage = "   To root";
            }
            catch (Exception error)
            {
                string _ = error.Message;
            }
        }

        void OlvDataTreeToAdd_Dropped(object? sender, OlvDropEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            e.Handled = true;
        }

        void OlvDataTreeToAdd_ModelCanDrop(object? sender, ModelDropEventArgs e)
        {
            e.DropSink.Billboard.BackColor = Color.GreenYellow;
            e.DropSink.FeedbackColor = Color.GreenYellow;
            e.InfoMessage = "Hey there";
            e.Handled = true;
            e.Effect = DragDropEffects.Move;
        }

        void OlvDataTreeToAdd_ModelDropped(object? sender, ModelDropEventArgs e)
        {
            if (((DataTreeListView)e.SourceListView).Name == "DataTreeListViewtoAdd")
            {
                e.Effect = DragDropEffects.None;
                e.Handled = true;

                MessageBox.Show("You can't drop new items here, drop them in the master TreeView section.",
                                "Invalid Drop Target",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            e.Handled = true;
            e.Effect = DragDropEffects.Move;
            RearrangeModelsToAdd(e);
        }

        void RearrangeModelsToAdd(ModelDropEventArgs args)
        {
            switch (args.DropTargetLocation)
            {
                case DropTargetLocation.AboveItem:
                    olvDataTree_ToAdd.MoveObjects(args.DropTargetIndex, args.SourceModels);
                    break;
                case DropTargetLocation.LeftOfItem:
                    olvDataTree_ToAdd.MoveObjects(args.DropTargetIndex, args.SourceModels);
                    break;
                case DropTargetLocation.BelowItem:
                    AddObjectBelowItemToAdd(args);
                    break;
                case DropTargetLocation.RightOfItem:
                    olvDataTree_ToAdd.MoveObjects(args.DropTargetIndex + 1, args.SourceModels);
                    break;
                case DropTargetLocation.Background:
                    AddObjectToRootToAdd(args);
                    break;
                case DropTargetLocation.Item:
                    break;
                case DropTargetLocation.None:
                    AddObjectToRootToAdd(args);
                    break;

                default:
                    return;
            }

        }

        void AddObjectBelowItemToAdd(ModelDropEventArgs args)
        {
            if (args.DropTargetItem != null)
            {
                // If the target is a leaf node, we need to add the objects as children of that node
                foreach (Table_Base_TreeView model in args.SourceModels)
                {
                    if (BindingSourceTreeView.Current is Table_StockRoom_TreeView)
                    {
                        var typedItem = new Table_StockRoom_TreeView
                        {
                            ID = LastID,
                            Parent_ID = ((Table_Base_TreeView)args.TargetModel).ID,
                            Text_Name = model.Text_Name,
                            Description_Short = model.Description_Short,
                            Description_Expand = model.Description_Expand,
                            Image = model.Image
                        };
                        _ = _unitOfWork.TableStockRoomTreeViewRepository.AddAsync(typedItem, CancellationToken.None);
                        // Add to binding list (automatic UI update)
                        BindingSourceTreeView.Add(typedItem);
                        // ✅ BindingList<T> does not support Find() — use manual index search
                        int position = FindPositionById(typedItem.ID);
                        BindingSourceTreeView.Position = position;
                    }
                    else if (BindingSourceTreeView.Current is Table_TimeLine_TreeView)
                    {
                        var typedItem = new Table_TimeLine_TreeView
                        {
                            ID = LastID,
                            Parent_ID = ((Table_Base_TreeView)args.TargetModel).ID,
                            Text_Name = model.Text_Name,
                            Description_Short = model.Description_Short,
                            Description_Expand = model.Description_Expand,
                            Image = model.Image
                        };
                        _ = _unitOfWork.TableTimeLineTreeViewRepository.AddAsync(typedItem, CancellationToken.None);
                        // Add to binding list (automatic UI update)
                        BindingSourceTreeView.Add(typedItem);
                        // ✅ BindingList<T> does not support Find() — use manual index search
                        int position = FindPositionById(typedItem.ID);
                        BindingSourceTreeView.Position = position;
                    }
                }
            }
        }

        void AddObjectToRootToAdd(ModelDropEventArgs args)
        {
            if (args.DropTargetItem == null)
            {
                foreach (Table_Base_TreeView model in args.SourceModels)
                {
                    model.Parent_ID = rootKeyValueToAdd;
                }
            }
        }

        #endregion"olvDataTree_toAdd"

        #region"olvDataTree_toCancel"

        void Initialize_olvDataTree_toCancel()
        {
            olvDataTree_ToCancel.KeyAspectName = "ID";
            olvDataTree_ToCancel.ParentKeyAspectName = "Parent_ID";
            olvDataTree_ToCancel.RootKeyValue = rootKeyValueToCancel;
            olvDataTree_ToCancel.AllowDrop = true;
            olvDataTree_ToCancel.FullRowSelect = true;
            olvDataTree_ToCancel.ShowKeyColumns = false;
            olvDataTree_ToCancel.AutoGenerateColumns = false;
            ((OLVColumn)olvDataTree_ToCancel.Columns[0]).FillsFreeSpace = true;

            SetupDragAndDrop_toCancel();
        }

        void SetupDragAndDrop_toCancel()
        {
            olvDataTree_ToCancel.IsSimpleDropSink = true;
            olvDataTree_ToCancel.IsSimpleDragSource = false;
            olvDataTree_ToCancel.CanDrop += OlvDataTreeToCancel_CanDrop;
            olvDataTree_ToCancel.Dropped += OlvDataTreeToCancel_Dropped;
            olvDataTree_ToCancel.ModelDropped += OlvDataTreeToCancel_ModelDropped;
            ((SimpleDropSink)olvDataTree_ToCancel.DropSink).CanDropBetween = true;
            ((SimpleDropSink)olvDataTree_ToCancel.DropSink).ModelCanDrop += OlvDataTreeToCancel_ModelCanDrop;

            // Make listView capable of dragging rows out
            SimpleDragSource simpleDragSourceToCancel = new SimpleDragSource(true);

            olvDataTree_ToCancel.DragSource = simpleDragSourceToCancel;

            // Make listView capable of accepting drops.
            // More than that, make it so it's items can be rearranged
            RearrangingDropSink rearrangingDropSinkToCancel = new RearrangingDropSink(true)
            {
                Billboard = new BillboardOverlay
                {
                    BackColor = Color.LightGoldenrodYellow,
                    Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold),
                    CornerRounding = 5,
                    BorderColor = Color.Black,
                    BorderWidth = 1
                }
            };

            olvDataTree_ToCancel.DropSink = rearrangingDropSinkToCancel;
        }

        void OlvDataTreeToCancel_ModelCanDrop(object? sender, ModelDropEventArgs e)
        {
            e.Handled = true;
            e.Effect = DragDropEffects.None;
            e.DropSink.Billboard.BackColor = Color.Yellow;
            e.DropSink.FeedbackColor = Color.Black;
            if (e.DropTargetItem != null)
                e.InfoMessage = "   " + e.DropTargetLocation.ToString().Replace("Item", " Item ") +
                                        "Drop it here to cancel any drag action.";
            else
                e.InfoMessage = "   Drop it here to cancel any drag action.";
        }

        void OlvDataTreeToCancel_ModelDropped(object? sender, ModelDropEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            e.Handled = true;
        }

        void OlvDataTreeToCancel_CanDrop(object? sender, OlvDropEventArgs e)
        {
            try
            {


                int sourceModel_ID = ((OLVDataObject)e.DataObject).ModelObjects[0] as Table_Base_TreeView != null ?
                                      ((Table_Base_TreeView)((OLVDataObject)e.DataObject).ModelObjects[0]).ID : 0;

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = e.DropTargetItem.RowObject as Table_Base_TreeView != null ?
                                    ((Table_Base_TreeView)e.DropTargetItem.RowObject).ID : 0;

                if (targeId == sourceModel_ID)
                {
                    e.Handled = true;
                    e.InfoMessage = "   Can't drop on myself";
                    e.Effect = DragDropEffects.None;
                    e.DropSink.Billboard.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
                    e.DropSink.Billboard.BackColor = Color.Yellow;
                    e.DropSink.Billboard.CornerRounding = 5;
                    e.DropSink.Billboard.BorderColor = Color.Black;
                    e.DropSink.Billboard.BorderWidth = 1;
                    e.DropSink.FeedbackColor = Color.Black;
                    return;
                }

                e.Handled = true;
                e.Effect = DragDropEffects.None;
                e.DropSink.Billboard.BackColor = Color.Yellow;
                e.DropSink.FeedbackColor = Color.Black;
                if (e.DropTargetItem != null)
                    e.InfoMessage = "   " + e.DropTargetLocation.ToString().Replace("Item", " Item ") +
                                            "Drop it here to cancel any drag action.";
                else
                    e.InfoMessage = "   Drop it here to cancel any drag action.";
            }
            catch (Exception error)
            {
                string _ = error.Message;
            }
        }

        void OlvDataTreeToCancel_Dropped(object? sender, OlvDropEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            e.Handled = true;
        }

        #endregion"olvDataTree_toCancel"

        #region"olvDataTree_toDelete"

        void Initialize_olvDataTree_toDelete()
        {
            olvDataTree_ToDelete.KeyAspectName = "ID";
            olvDataTree_ToDelete.ParentKeyAspectName = "Parent_ID";
            olvDataTree_ToDelete.RootKeyValue = rootKeyValueToDelete;
            olvDataTree_ToDelete.AllowDrop = true;
            olvDataTree_ToDelete.FullRowSelect = true;
            olvDataTree_ToDelete.ShowKeyColumns = false;
            olvDataTree_ToDelete.AutoGenerateColumns = false;
            ((OLVColumn)olvDataTree_ToDelete.Columns[0]).FillsFreeSpace = true;
            olvDataTree_ToDelete.SelectedIndexChanged += olvDataTree_ToDelete_SelectedIndexChanged;

            SetupDragAndDrop_toDelete();
            InitializeContextMenuStrip_DeletedThisNode();
        }

        public void olvDataTree_ToDelete_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                Type type = sender.GetType();

                // Check if the mouse is outside the bounds of the control and no key press triggered the event
                // If so, exit the method early, unless the sender is a CustomTabControl
                //   if (!(olvDataTreeMaster.Bounds.Contains(PointToClient(MousePosition))) & !keyPressDataTreeList)
                //       if (!type.Name.Contains("CustomTabControl"))
                //           return;

                keyPressDataTreeList = false;

                if (olvDataTree_ToDelete.SelectedItem == null)
                    return;

                DataBoundObject = olvDataTree_ToDelete.SelectedItem.RowObject.GetType();
                DataBoundObject_Name = DataBoundObject.Name;

                if (DataBoundObject_Name.Contains("TreeView"))
                {
                    var _currentNodeToDeleteTBT = olvDataTree_ToDelete.SelectedItem.RowObject as Table_Base_TreeView;

                    if (_currentNodeToDeleteTBT != null)
                        if (_currentNodeItem == null || _currentNodeItem.ID == _currentNodeToDeleteTBT.ID)
                            return;

                    _currentNodeItem = _currentNodeToDeleteTBT;

                    UpDateCurrentSelectedIndex();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SetupDragAndDrop_toDelete()
        {
            olvDataTree_ToDelete.IsSimpleDropSink = true;
            olvDataTree_ToDelete.IsSimpleDragSource = false;
            olvDataTree_ToDelete.CanDrop += OlvDataTreeToDelete_CanDrop;
            olvDataTree_ToDelete.Dropped += OlvDataTreeToDelete_Dropped;
            olvDataTree_ToDelete.ModelDropped += OlvDataTreeToDelete_ModelDropped;
            ((SimpleDropSink)olvDataTree_ToDelete.DropSink).CanDropBetween = true;
            ((SimpleDropSink)olvDataTree_ToDelete.DropSink).ModelCanDrop += OlvDataTreeToDelete_ModelCanDrop;

            // Make listView capable of dragging rows out
            SimpleDragSource simpleDragSourceToDelete = new SimpleDragSource(true);

            olvDataTree_ToDelete.DragSource = simpleDragSourceToDelete;

            // Make listView capable of accepting drops.
            // More than that, make it so it's items can be rearranged
            RearrangingDropSink rearrangingDropSinkToDelete = new RearrangingDropSink(true)
            {
                Billboard = new BillboardOverlay
                {
                    BackColor = Color.LightGoldenrodYellow,
                    Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold),
                    CornerRounding = 5,
                    BorderColor = Color.Black,
                    BorderWidth = 1
                }
            };

            olvDataTree_ToDelete.DropSink = rearrangingDropSinkToDelete;
        }

        void OlvDataTreeToDelete_CanDrop(object? sender, OlvDropEventArgs e)
        {
            try
            {
                var draggedObject = ((DataTreeListView)((OLVDataObject)e.DataObject).ListView);
                if (draggedObject.Name == "DataTreeListViewtoAdd")
                {
                    e.Handled = true;
                    e.InfoMessage = "   You can't drop new items here.";
                    e.Effect = DragDropEffects.None;
                    e.DropSink.Billboard.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
                    e.DropSink.Billboard.BackColor = Color.Red;
                    e.DropSink.Billboard.CornerRounding = 5;
                    e.DropSink.Billboard.BorderColor = Color.Black;
                    e.DropSink.Billboard.BorderWidth = 1;
                    e.DropSink.FeedbackColor = Color.Black;
                    return;
                }

                int sourceModel_ID = 0;
                sourceModel_ID = (((OLVDataObject)e.DataObject).ModelObjects[0] as Table_Base_TreeView != null ?
                                    ((Table_Base_TreeView)((OLVDataObject)e.DataObject).ModelObjects[0]).ID : 0);

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = (e.DropTargetItem.RowObject as Table_Base_TreeView != null ?
                                    ((Table_Base_TreeView)e.DropTargetItem.RowObject).ID : 0);

                if (targeId == sourceModel_ID)
                {
                    e.Handled = true;
                    e.InfoMessage = "   Can't drop on myself";
                    e.Effect = DragDropEffects.None;
                    e.DropSink.Billboard.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
                    e.DropSink.Billboard.BackColor = Color.Yellow;
                    e.DropSink.Billboard.CornerRounding = 5;
                    e.DropSink.Billboard.BorderColor = Color.Black;
                    e.DropSink.Billboard.BorderWidth = 1;
                    e.DropSink.FeedbackColor = Color.Black;
                    return;
                }


                e.Handled = true;
                e.Effect = DragDropEffects.Move;
                e.DropSink.Billboard.BackColor = Color.Yellow;
                e.DropSink.FeedbackColor = Color.Black;
                if (e.DropTargetItem != null)
                    e.InfoMessage = "   " + e.DropTargetLocation.ToString().Replace("Item", " Item ") +
                                            e.DropTargetItem.Text +
                                            " Drop it here to be deleted.";
                else
                    e.InfoMessage = "   Drop it here to be deleted.";
            }
            catch (Exception error)
            {
                string _ = error.Message;
            }
        }

        void OlvDataTreeToDelete_Dropped(object? sender, OlvDropEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            e.Handled = true;
        }

        void OlvDataTreeToDelete_ModelCanDrop(object? sender, ModelDropEventArgs e)
        {
            if (e.SourceListView.AccessibilityObject.Name == "To add new Items...")
            {
                e.Handled = true;
                e.InfoMessage = "   You can't drop new items here.";
                e.Effect = DragDropEffects.None;
                e.DropSink.Billboard.Font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
                e.DropSink.Billboard.BackColor = Color.Red;
                e.DropSink.Billboard.CornerRounding = 5;
                e.DropSink.Billboard.BorderColor = Color.Black;
                e.DropSink.Billboard.BorderWidth = 1;
                e.DropSink.FeedbackColor = Color.Black;
                return;
            }

            e.DropSink.Billboard.BackColor = Color.GreenYellow;
            e.DropSink.FeedbackColor = Color.GreenYellow;
            e.InfoMessage = "Hey there";
            e.Handled = true;
            e.Effect = DragDropEffects.Move;
        }

        async void OlvDataTreeToDelete_ModelDropped(object? sender, ModelDropEventArgs e)
        {
            e.Handled = true;
            e.Effect = DragDropEffects.Move;
            await RearrangeModelsToDelete(e);   // ✅ must be awaited
        }

        async Task RearrangeModelsToDelete(ModelDropEventArgs args)
        {
            switch (args.DropTargetLocation)
            {
                case DropTargetLocation.AboveItem:
                    await AddObjectBelowItemToDelete(args);
                    break;
                case DropTargetLocation.LeftOfItem:
                    await AddObjectBelowItemToDelete(args);
                    break;
                case DropTargetLocation.BelowItem:
                    {
                        await AddObjectBelowItemToDelete(args);
                        break;
                    }
                case DropTargetLocation.RightOfItem:
                    await AddObjectBelowItemToDelete(args);
                    break;
                case DropTargetLocation.Background:
                    {
                        await AddObjectToRootToDelete(args);
                        break;
                    }
                case DropTargetLocation.Item:
                    break;
                case DropTargetLocation.None:
                    await AddObjectToRootToDelete(args);
                    break;

                default:
                    return;
            }
        }

        async Task AddObjectBelowItemToDelete(ModelDropEventArgs args)
        {
            if (args.SourceListView.AccessibilityObject.Name == "To add new Items...")
            {
                MessageBox.Show("You can't drop new items here, drop them in the master TreeView section.",
                                "Invalid Drop Target",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (args.DropTargetItem == null)
                return;

            // The new parent is the drop-target node's ID (not rootKeyValueToDelete).
            int newParentId = args.TargetModel is Table_Base_TreeView target ? target.ID : rootKeyValueToDelete;

            foreach (Table_Base_TreeView model in args.SourceModels)
            {
                model.Parent_ID = newParentId;   // ✅ update in memory

                // ✅ Persist to DB — same pattern as UpdateObjectToEFAsync
                if (TableName.Contains("Table_StockRoom_TreeView"))
                    await _unitOfWork.TableStockRoomTreeViewRepository.UpdateAsync((Table_StockRoom_TreeView)model, CancellationToken.None);
                else if (TableName.Contains("Table_TimeLine_TreeView"))
                    await _unitOfWork.TableTimeLineTreeViewRepository.UpdateAsync((Table_TimeLine_TreeView)model, CancellationToken.None);
            }

            BindingSourceTreeView.ResetBindings(false);
            olvDataTree_ToDelete.RebuildAll(false);
            olvDataTree_ToDelete.ClearHotItem();
        }

        async Task AddObjectToRootToDelete(ModelDropEventArgs args)
        {
            if (args.SourceListView.AccessibilityObject.Name == "To add new Items...")
            {
                MessageBox.Show("You can't drop new items here, drop them in the master TreeView section.",
                                "Invalid Drop Target",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If the target is a leaf node, we need to add the objects as children of that node
            if (args.DropTargetItem == null)
            {
                foreach (Table_Base_TreeView model in args.SourceModels)
                {
                    await UpdateObjectToEFAsync(model, args);
                }
            }
        }

        async Task UpdateObjectToEFAsync(Table_Base_TreeView model, ModelDropEventArgs args)
        {
            if (TableName.Contains("Table_StockRoom_TreeView"))
            {                
                Table_StockRoom_TreeView item = (Table_StockRoom_TreeView)model;
                item.Parent_ID  = rootKeyValueToDelete;
                model.Parent_ID = rootKeyValueToDelete;
                OrphansNodes.Add(model); // Add to orphans list

                await _unitOfWork.TableStockRoomTreeViewRepository.UpdateAsync(item, CancellationToken.None);
               
                BindingSourceTreeView.ResetBindings(false);
                olvDataTree_ToDelete.RebuildAll(false);
                olvDataTree_ToDelete.ClearHotItem();

                int positionIndex = FindPositionById(model.ID);
                if (positionIndex >= 0)
                    BindingSourceTreeView.Position = positionIndex;
            }
            else if (TableName.Contains("Table_TimeLine_TreeView"))
            {                
                Table_TimeLine_TreeView itemTL = (Table_TimeLine_TreeView)model;
                itemTL.Parent_ID = rootKeyValueToDelete;
                model.Parent_ID = rootKeyValueToDelete;
                OrphansNodes.Add(model); // Add to orphans list

                await _unitOfWork.TableTimeLineTreeViewRepository.UpdateAsync(itemTL, CancellationToken.None);
               
                BindingSourceTreeView.ResetBindings(false);

                olvDataTree_ToDelete.RebuildAll(false);
                olvDataTree_ToDelete.ClearHotItem();

                int positionIndex = FindPositionById(model.ID);
                if (positionIndex >= 0)
                    BindingSourceTreeView.Position = positionIndex;
            }
        }

        #region"ContextMenuStrip_ToDelete"

        void InitializeContextMenuStrip_DeletedThisNode()
        {
            contextMenuStrip_ToDelete.Opening += ContextMenuStrip_To_Delete_Opening;
            toolStripMenuItem_DeletedThisNode.Click += ToolStripMenuItem_DeletedThisNode_Click;
            toolStripMenuItem_DeleteAllNodes.Click += ToolStripMenuItem_DeletedAllNodes_Click;
        }

        void ContextMenuStrip_To_Delete_Opening(object? sender, CancelEventArgs e)
        {
            if (olvDataTree_ToDelete.SelectedItem == null)
            {
                e.Cancel = true;
                return;
            }

            contextMenuStrip_ToDelete.Items.Clear();
                        
            if (OrphansNodes.Count <= 5)
            {
                contextMenuStrip_ToDelete.Items.Add(toolStripMenuItem_DeletedThisNode);
            }
            if (OrphansNodes.Count > 5)
            {
                contextMenuStrip_ToDelete.Items.Add(toolStripMenuItem_DeletedThisNode);
                contextMenuStrip_ToDelete.Items.Add(toolStripMenuItem_RemoveAllNodes);
            }
        }

        async void ToolStripMenuItem_DeletedThisNode_Click(object? sender, EventArgs e)
        {
            try
            {
                if (olvDataTree_ToDelete.SelectedItem == null)
                    return;
                
                if (TableName.Contains("Table_StockRoom_TreeView"))
                {
                    if (olvDataTree_ToDelete.SelectedItem.RowObject is not Table_StockRoom_TreeView selectedItem)
                        return;

                    IEnumerable<Table_Base_TreeView> children = OrphansNodes.Where(x => x.Parent_ID == selectedItem.ID).ToList();

                    if (children.Any())
                    {
                        DialogResult dialogResult =
                        MessageBox.Show("Do you want to delete all the children as well?", "Cannot Delete Node with Childrens",
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.No || dialogResult == DialogResult.Cancel)
                            return;

                        if (dialogResult == DialogResult.Yes)
                        {
                            foreach (Table_Base_TreeView itemEF in children)
                            {
                                // ✅ Use DeleteAsync — it fetches the tracked entity by PK (Index)
                                // then removes it. Avoids attaching detached entities with Index = 0.
                                await _unitOfWork.TableStockRoomTreeViewRepository.DeleteAsync(itemEF.Index);

                                RemoveFromBindingSourceByIndex(itemEF.Index);
                            }

                            
                        }
                    }

                    await _unitOfWork.TableStockRoomTreeViewRepository.DeleteAsync(selectedItem.Index);
                    RemoveFromBindingSourceByIndex(selectedItem.Index);
                }
                else if (TableName.Contains("Table_TimeLine_TreeView"))
                {
                    if (olvDataTree_ToDelete.SelectedItem.RowObject is not Table_TimeLine_TreeView selectedItem)
                        return;

                    IEnumerable<Table_Base_TreeView> children = OrphansNodes.Where(x => x.Parent_ID == selectedItem.ID).ToList();

                    if (children.Any())
                    {
                        DialogResult dialogResult =
                        MessageBox.Show("Do you want to delete all the children as well?", "Cannot Delete Node with Childrens",
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.No || dialogResult == DialogResult.Cancel)
                            return;

                        if (dialogResult == DialogResult.Yes)
                        {
                            foreach (Table_TimeLine_TreeView itemEF in children)
                            {
                                // ✅ Use DeleteAsync — it fetches the tracked entity by PK (Index)
                                // then removes it. Avoids attaching detached entities with Index = 0.
                                await _unitOfWork.TableTimeLineTreeViewRepository.DeleteAsync(itemEF.Index);

                                RemoveFromBindingSourceByIndex(itemEF.Index);
                            }
                        }
                    }

                    await _unitOfWork.TableTimeLineTreeViewRepository.DeleteAsync(selectedItem.Index);
                    RemoveFromBindingSourceByIndex(selectedItem.Index);
                }

                BindingSourceTreeView.ResetBindings(false);
                olvDataTree_ToDelete.RebuildAll(false);
            }
            catch (Exception error)
            {
                MessageDebugPosition = $"Error deleting node: {error.Message}";
            }
        }

        async void ToolStripMenuItem_DeletedAllNodes_Click(object? sender, EventArgs e)
        {
            try
            {
                if (olvDataTree_ToDelete.SelectedItem == null)
                    return;

                List<int> indexesToDelete = ItemsList.Where(n => n.Parent_ID == 75).Select(n => n.Index).ToList();

                DialogResult dialogResult =
                MessageBox.Show("This action will delete all ( " + indexesToDelete.Count + " ) nodes and children.\r\n " +
                                "You will not be able to recover them once deleted.\r\n" +
                                "Do you want to continue?",
                                "Warning:This action will delete all nodes and children.",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No || dialogResult == DialogResult.Cancel)
                    return;

                if (dialogResult == DialogResult.Yes)
                {
                    BindingSourceTreeView.Position = 0;
                    BindingSourceTreeView.SuspendBinding();
                    
                    if (TableName.Contains("Table_StockRoom_TreeView"))
                        await _unitOfWork.TableStockRoomTreeViewRepository.DeleteRangeAsync(indexesToDelete);
                    else if (TableName.Contains("Table_TimeLine_TreeView"))
                        await _unitOfWork.TableTimeLineTreeViewRepository.DeleteRangeAsync(indexesToDelete);

                    olvDataTreeMaster.SelectedIndexChanged -= OlvDataTreeMaster_SelectedIndexChanged;
                    olvDataTree_ToAdd.SelectedIndexChanged -= olvDataTree_ToAdd_SelectedIndexChanged;
                    olvDataTree_ToDelete.SelectedIndexChanged -= olvDataTree_ToDelete_SelectedIndexChanged;

                    // Remove from BindingSource in memory (no DB calls)
                    var underlyingList = (BindingList<Table_Base_TreeView>)_bindingSourceTreeView.DataSource;
                    var itemsToRemove = underlyingList.Where(n => indexesToDelete.Contains(n.Index)).ToList();
                    foreach (var item in itemsToRemove)
                        _bindingSourceTreeView.Remove(item);

                    olvDataTreeMaster.SelectedIndexChanged += OlvDataTreeMaster_SelectedIndexChanged;
                    olvDataTree_ToAdd.SelectedIndexChanged += olvDataTree_ToAdd_SelectedIndexChanged;
                    olvDataTree_ToDelete.SelectedIndexChanged += olvDataTree_ToDelete_SelectedIndexChanged;

                    BindingSourceTreeView.ResumeBinding();
                }

                BindingSourceTreeView.ResetBindings(false);
                olvDataTree_ToDelete.RebuildAll(false);
                olvDataTree_ToDelete.ClearHotItem();
            }
            catch (Exception error)
            {
                MessageDebugPosition = $"Error deleting node: {error.Message}";
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
                IList list = BindingSourceTreeView.List;
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

        #endregion"ContextMenuStrip_ToDelete"

        #endregion"olvDataTree_ToDelete"

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
        Action action;

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

        void SplitContainer_DataTreeView_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Settings.Default.SplitterDistance_DataTreeViewToAdd_Cancel_Delete = splitContainer_DataTreeView.SplitterDistance;
            Settings.Default.Save();
        }
    }
}

using StockRoom11net.Controls.BindingSourceExt;
using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using StockRoom11net.Properties;
using System.ComponentModel;
using System.Data;
using static StockRoom11net.Controls.Custom_Events_Args;
using HeightChange_EventArgs = StockRoom11net.Controls.Custom_Events_Args.HeightChange_EventArgs;
using Save_Requested_EventArgs = StockRoom11net.Controls.Custom_Events_Args.Save_Requested_EventArgs;
using StatusBarMessage_EventArgs = StockRoom11net.Controls.Custom_Events_Args.StatusBarMessage_EventArgs;
using StringFilterControl_EventArgs = StockRoom11net.Controls.Custom_Events_Args.StringFilterControl_EventArgs;


namespace StockRoom11net.Controls
{
    public partial class NodeSetting : UserControl
    {
        private ITableEmployeeService _employeesService;

        int CounterEvents = 0;

        bool _debugMode = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DebugMode
        {
            get
            {
                return _debugMode;
            }
            set
            {
                _debugMode = value;
                queryBuilder.DebugMode = true;
            }
        }

        /// <summary>
        /// Keep a record of all columns existent in the dataTable.
        /// </summary>
        DataColumnCollection ColumnsCollectionStockRoom { get; set; }

        OpenFileDialog _openFile = new OpenFileDialog();

        ResourcesCache.ResourcesCache _cache;

        string _tableName = "Not DataTable defined.";

        string initialDirectory = Settings.Default.DataBaseAddress;// + "\\Resources\\PNG\\48\\";

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

        #region"Timer SaveUserSetting if it's modifying the user interface."

        int _sec = 10;

        /// <summary>
        /// An interval of 10 seconds to save user setting if this is modifying the user interface.
        /// </summary>
        System.Windows.Forms.Timer SaveUserSettingTimer;

        void SaveUserSetting()
        {
            if (itemBindingTableTreeView.ID == 100000)
                return;

            SaveUserSettingTimer.Start();
            NeedSaveData = false;
            _sec = 10;

            On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  10 sec less to save data changed."));
        }

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

        void SaveUserSettingTick(object? sender, EventArgs e)
        {
            _sec--;

            if (_sec > 0)
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  " + _sec + " sec less to save data changed."));
                return;
            }

            SaveUserSettingTimer.Stop();
            On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  "));//Clear the StatusBar.

            OnSaveRequested(new Save_Requested_EventArgs(itemBindingTableTreeView){ });
        }

        #endregion"Timer SaveUserSetting if it's modifying the user interface."   

        #region"Events, Custom Controls Events with custom Args.*********************"

        #region"Save_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Save_Requested_EventHandler SaveRequested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void OnSaveRequested(Save_Requested_EventArgs e)
        {
            SaveRequested?.Invoke(this, e);
        }

        #endregion

        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event StatusBarMessage_EventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessage_EventHandler(object? sender, StatusBarMessage_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (StatusBarMessage != null)
            {
                // Notify Subscribers
                StatusBarMessage(this, e);
            }
        }

        #endregion"StatusBarMessage"

        #region"HeightChange"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Control height has been changed.")]
        public event HeightChange_EventHandler HeightChange;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void HeightChange_EventHandler(object? sender, HeightChange_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_HeightChange(HeightChange_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (HeightChange != null)
            {
                // Notify Subscribers
                HeightChange(this, e);
            }
        }

        #endregion"StatusBarMessage"

        #region"NodeImageChange"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User change the image property")]
        public event NodeImageChange_EventHandler NodeImageChange;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void NodeImageChange_EventHandler(object? sender, NodeImageChange_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class NodeImageChange_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public NodeImageChange_EventArgs()
            {

            }
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void OnNodeImageChange(NodeImageChange_EventArgs e)
        {
            NodeImageChange?.Invoke(this, e);
        }

        #endregion"NodeImageChange"

        #region"CurrentUserBroadcast"

        /// <summary>
        /// Department active in this machine.
        /// </summary>
        DepartmentInformation _currentDepartmentLogIn = new DepartmentInformation();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DepartmentInformation CurrentDepartmentLogIn
        {
            get
            {
                return _currentDepartmentLogIn;
            }
            set
            {
                if (value == null)
                    return;

                _currentDepartmentLogIn = value;
            }
        }

        void CurrentDepartmentLogIn_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            //On_Save_Requested(e);
        }

        public Action? ProcessCurrentEmployeesLogIn;
        Table_Employee? _currentEmployeesLogIn = new Table_Employee();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Table_Employee CurrentEmployeesLogIn
        {
            get
            {
                _currentEmployeesLogIn ??= new Table_Employee();

                return _currentEmployeesLogIn;
            }
            set
            {
                _currentEmployeesLogIn = value;

                ProcessCurrentEmployeesLogIn?.Invoke();
            }
        }

        public void CurrentUserBroadcast_EventHandler(object sender, CurrentDeptUserBroadcast_EventArgs e)
        {
            if (e == null)
                return;

            CurrentEmployeesLogIn = e.Employee;
            CurrentDepartmentLogIn = e.Deptment;
        }

        #endregion"CurrentUserBroadcast"

        #endregion "Events, Custom Controls Events with custom Args.*********************"

        #region"Properties"

        bool _isMouseDrivenEvent = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Keep a flag if the user is modifying the user interface
        /// or the interface is modifying by code.
        public bool IsMouseDrivenEvent
        {
            get
            {
                return _isMouseDrivenEvent;
            }
            set
            {
                _isMouseDrivenEvent = value;
            }
        }

        public DataRowView nextNewNode;
                
        Table_Base_TreeView itemBindingTableTreeView;
        /// <summary>
        /// Set the current focused node,
        /// Input property to update the user interface with the properties of this recent selected node.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Table_Base_TreeView CurrentNode
        {
            set
            {
                _needSaveData = false;

                if(SaveUserSettingTimer.Enabled)
                {
                    _sec = 0;

                    SaveUserSettingTick(null, EventArgs.Empty);

                    /*   MessageBox.Show(new Form() { TopMost = true },
                                       $"The autosave process is active, indicating there is data to be saved.{Environment.NewLine}" +
                                       $"Press YES to save it immediately.{Environment.NewLine}" +
                                       $"Press NO to cancel the changes.",
                                        "The autosave process is active.",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);
                                       */
                }

                if (value == null)
                {
                    textBox_Node_Name.Text = "";
                    pictureBox_Image.Image = null;

                    return;
                }

                itemBindingTableTreeView = value;

                if (itemBindingTableTreeView.ID == 100000)
                {
                    // This is the empty node, we don't need to process the string filter because this node
                    // is just a placeholder when there are no matching tasks to display in the tree view.
                    textBox_Node_Name.Text = "";
                    pictureBox_Image.Image = null;
                    textBox_Title.Text = "";
                    textBox_Description.Text = "";
                    textBox_Node_PDF_Information.Text = "";
                    textBox_Node_Picture.Text = "";

                    this.Enabled = false;

                }
                else
                {
                    this.Enabled = true;

                    queryBuilder.Process_StringFilter(itemBindingTableTreeView.String_Filter);

                    UpdateUi();
                    UpdateAvailableDepartment();
                }
            }
        }

        /// <summary>
        /// Reference to dataTable were is saved all information.
        /// </summary>
        DataTable table_treeView;

        BindingSourceValidating<Table_Base_TreeView> _bindingSource_TreeView;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingSourceValidating<Table_Base_TreeView> BindingSourceTreeView
        {
            get
            {
                return _bindingSource_TreeView;
            }
            set
            {
                _bindingSource_TreeView = value;
            }
        }

        DataColumnCollection _columnsCollection;
        /// <summary>
        /// Keep a record of all columns existent in StockRoom dataTable.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataColumnCollection ColumnsCollection
        {
            get
            {
                return _columnsCollection;
            }
            set
            {
                if (value == null)
                    return;

                _columnsCollection = value;
                queryBuilder.ColumnsCollection = _columnsCollection;
            }
        }

        List<string> _departList;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<string> DepartList
        {
            get
            {
                return _departList;
            }
            set
            {
                if (value == null)
                    return;

                _departList = value;

                flowLayoutPanel_AvailableDepartments.Controls.Clear();

                foreach (string depart in _departList)
                {
                    var checkBoxDepart = new CheckBox
                    {
                        Name = "checkBox_" + depart,
                        Text = depart,
                        AutoSize = true,
                        Checked = false
                    };

                    checkBoxDepart.MouseClick += CheckBoxDepart_MouseClick;

                    flowLayoutPanel_AvailableDepartments.Controls.Add(checkBoxDepart);
                }
            }
        }

        int _lastID;
        /// <summary>
        /// Top value for ID field, option filter to select a group of row.
        /// table.Compute("MAX(ID)", "filter condition"), itself inc.
        /// </summary>
        int LastID
        {
            get
            {
                return _lastID;
            }
            set
            {
                _lastID = value;

            }
        }

        /// <summary>
        /// Gets the next unique identifier in a sequential order.
        /// Increment LastID by 1. 
        /// </summary>
        int NextID
        {
            get
            {
                ++_lastID;
                return _lastID;
            }
        }

        bool _needSaveData;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NeedSaveData
        {
            get
            {
                return _needSaveData;
            }
            set
            {
                if (!(Bounds.Contains(PointToClient(MousePosition))))
                    return;

                _needSaveData = value;
            }
        }

        public bool UpdateParentID(int? parentID)
        {
            //    _focusedNodeProperties.UpdateParentID(parentID);

            return true;
        }

        void FocusedNodeProperties_Save_Requested(object? sender, Save_Requested_EventArgs e)
        {
            OnSaveRequested(e);
        }

        #endregion"Properties"

        public NodeSetting()
        {
            InitializeComponent();

            NodeSettingInitialize();
        }

        /// <summary>
        /// If the nodeSetting dialog will bee used in Node setting used this constructor.
        /// </summary>
        /// <param name="treeView_datasource"></param>
        /// <param name="stockroomcollection"></param>
        /// <param name="currentEmployeesLogIn"></param>
        /// <param name="flexibleTreeView"></param>
        public NodeSetting(BindingSourceValidating<Table_Base_TreeView> treeView_datasource, DataColumnCollection columnCollection,
                                ITableEmployeeService employeesService)
        {
            try
            {
                InitializeComponent();

                BindingSourceTreeView = treeView_datasource;

                ColumnsCollection = columnCollection;

                _employeesService = employeesService;                

                NodeSettingInitialize();
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                @"NodeSetting InitializeComponent has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void NodeSettingInitialize()
        {
            SendStatusBarMessage("NodeSettingInitialize");

            InitializeSaveUserSettingTimer();

            customTabControl.Alignment = TabAlignment.Right;

            _cache = new ResourcesCache.ResourcesCache();

            queryBuilder.Resize += QueryBuilder_Resize;
            queryBuilder.StringFilter += QueryBuilderStringFilter;
            queryBuilder.StatusBarMessage += QueryBuilder_StatusBarMessage;

            textBox_Title.TextChanged += textBox_Title_TextChanged;
            textBox_Description.TextChanged += textBox_Description_TextChanged;
            textBox_Node_Name.TextChanged += TextBoxNodeNameTextChanged;
            textBox_Node_Name.MouseDoubleClick += TextBoxNodeNameMouseDoubleClick;

            textBox_Node_PDF_Information.TextChanged += TextBoxNodePdfInformationTextChanged;
            textBox_Node_PDF_Information.DoubleClick += TextBoxNodePdfInformationDoubleClick;

            textBox_Node_Picture.TextChanged += TextBoxNodePictureTextChanged;
            pictureBox_Image.DoubleClick += pictureBox_Image_DoubleClick;

            if (BindingSourceTreeView == null)
                return;

            label_FilterStatus.Text = "Department filter applied.";
            label_FilterString.Text = BindingSourceTreeView.Filter;

            if (table_treeView == null)
                return;

            // We ask per the lastID just before used.
            if (table_treeView.Rows.Count > 0)
                LastID = (int)table_treeView.Compute("MAX(ID)", "ID is Not null");
            else
                LastID = 10;
        }

        void QueryBuilder_StatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        #region"AvailableDepartments"

        void UpdateAvailableDepartment()
        {

            if (itemBindingTableTreeView == null)
                return;

            if (itemBindingTableTreeView.AvailableDepartmentList.Count == 0)
                return;

            /// Reset or uncheck all AvailableDepartments checkBox
            for (int i = 0; i <= (flowLayoutPanel_AvailableDepartments.Controls.Count - 1); i++)
                ((CheckBox)flowLayoutPanel_AvailableDepartments.Controls[i]).Checked = false;

            /// Set or check those departments where the menu is available.
            foreach (string depart in itemBindingTableTreeView.AvailableDepartmentList)
            {
                string Name = "checkBox_" + depart;

                if (((CheckBox)flowLayoutPanel_AvailableDepartments.Controls[Name]) == null)
                    return;

                ((CheckBox)flowLayoutPanel_AvailableDepartments.Controls[Name]).Checked = true;
            }
        }

        void CheckBoxDepart_MouseClick(object? sender, MouseEventArgs e)
        {
            /*
            string listDepart = "AvailableDepart:";
            CheckBox checkBoxDepartClicked = (CheckBox)sender;

            foreach (Control checkControl in flowLayoutPanel_AvailableDepartments.Controls)
            {
                CheckBox checkBox = (CheckBox)checkControl;
                if (checkBox.Checked)
                    listDepart += checkBox.Text + ",";
            }

            listDepart = listDepart.TrimEnd(',');

            _focusedNodeProperties.AvalaibleDepartments = listDepart;
          //  UpdateChildrenOf(_focusedNodeProperties);

            _focusedNodeProperties.SaveProperties();
            IsMouseDrivenEvent = true;
            SaveUserSetting();

            */
        }

        /*
        void UpdateChildrenOf(NodeProperties parentNode)
        {
            itemsToProcess.Clear();
            SelectItemsToProcess(parentNode.ID);

            foreach (int childID in itemsToProcess)
            {
                var index = _bindingSource_TreeView.Find("ID", childID);
                if (index == -1)
                    continue;

                //   table_treeView.Rows.Find(childID).ItemArray[19] = parentNode.AvalaibleDepartments;

                if (_bindingSource_TreeView[index] is DataRowView rowView)
                {              //AvailableDepartments
                    rowView.Row["AvalaibleDepartments"] = parentNode.AvalaibleDepartments;
                }
            }
        }
        */

        #endregion"AvailableDepartments"

        int queryBuilderHeight = 115;
        void QueryBuilder_Resize(object? sender, EventArgs e)
        {
            int differentHeight = queryBuilder.Size.Height - queryBuilderHeight;
            On_HeightChange(new HeightChange_EventArgs(differentHeight));
        }

        void QueryBuilderStringFilter(object? sender, StringFilterControl_EventArgs e)
        {
            /*
            if (_focusedNodeProperties == null)
                return;

            _focusedNodeProperties.StringFilter = e.StringFilterSql;
            _focusedNodeProperties.SaveProperties();

            IsMouseDrivenEvent = true;
            SaveUserSetting();
            */
        }

        void UpdateUi()
        {
            SendStatusBarMessage("UpdateUi");

            if (itemBindingTableTreeView == null)
                return;

            textBox_Node_Name.Text = itemBindingTableTreeView.Text_Name;

            textBox_Node_PDF_Information.Text = !string.IsNullOrEmpty(itemBindingTableTreeView.Node_PDF) ?
                                                                      itemBindingTableTreeView.Node_PDF : @"Double click to select a PDF file.";

            textBox_Node_Picture.Text = !string.IsNullOrEmpty(itemBindingTableTreeView.Node_Picture) ?
                                                              itemBindingTableTreeView.Node_Picture : @"Double click to select a picture.";

            if (itemBindingTableTreeView.Image == null || itemBindingTableTreeView.Image.Contains("Undefined") || itemBindingTableTreeView.Image == "")
            {
                pictureBox_Image.Image = null;
            }
            else
            {
                var imageResourcePathName = Path.Join(initialDirectory, itemBindingTableTreeView.Image);

                if (File.Exists(imageResourcePathName))
                {
                    pictureBox_Image.Image = _cache.GetBitmap(imageResourcePathName);
                }
                else
                    using (var form = new Form { TopMost = true })
                    {
                        MessageBox.Show(form, @"Message related to this error is Not file found at " + imageResourcePathName,
                                              @"NodeSetting has generated an error at UpdateUi()",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

            }

            textBox_Title.Text = itemBindingTableTreeView.Description_Short;
            textBox_Description.Text = itemBindingTableTreeView.Description_Expand;
        }

        void SendStatusBarMessage(string info)
        {
            if (DebugMode == false)
                return;

            CounterEvents++;
            On_StatusBarMessage(new StatusBarMessage_EventArgs(info + " " + CounterEvents));
        }

        string AddNewNode(DataRowView rowNode)
        {
            string path = "";
            try
            {
                //  var newNodeProperties = new NodeProperties(rowNode);

                //  node.Text = newNodeProperties.Text_Name;
                //   node.Tag = newNodeProperties;

                //   if (newNodeProperties.Parent_ID != null)
                //    {
                //         Node parentNode = _flexibleTreeView.Root.FindChildNodeById<BindableNode, object>(newNodeProperties.Parent_ID);
                //         node.AttachTo(parentNode);
                //     }
                //     else
                //        node.AttachTo(_flexibleTreeView);

                //    path = node.Path.ToString();

                //     _flexibleTreeView.Refresh();
            }
            catch (Exception error)
            {
                MessageBox.Show(@"Add new Node error, " + error.Message, @"Add new Node.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return path;
        }

        /*
        DataRowView AddNewRow(NodeProperties nodeProperties)
        {
            _bindingSource_TreeView.SuspendBinding();
            _bindingSource_TreeView.RaiseListChangedEvents = false;

            object? newObject = _bindingSource_TreeView.AddNew();
            DataRowView? newRow = newObject as DataRowView;

            try
            {
                newRow["Index"] = nodeProperties.ID;
                newRow["ID"] = nodeProperties.ID;
                if (nodeProperties.Parent_ID == 0)
                    newRow["Parent_ID"] = DBNull.Value;
                else
                    newRow["Parent_ID"] = nodeProperties.Parent_ID;
                newRow["Text_Name"] = nodeProperties.Text_Name;
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

                _bindingSource_TreeView.EndEdit();
                _bindingSource_TreeView.RaiseListChangedEvents = true;
                _bindingSource_TreeView.ResumeBinding();
                _bindingSource_TreeView.ResetBindings(false);
                _bindingSource_TreeView.Sort = "ID ASC";
                _bindingSource_TreeView.Position = _bindingSource_TreeView.Count - 1;
            }
            catch (Exception error)
            {
                MessageBox.Show(@"DataBase conflict, at Button_add_click " + error.Message, @"DataBase conflict.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newRow;
        }
        */

        /// <summary>
        /// Return the path as string of the next possible node to select front the current focused node.
        /// </summary>
        /// <returns></returns>
        string GetNextSelectableNode()
        {
            string pathNodeToSelect = null;


            return pathNodeToSelect;
        }

        /// <summary>
        /// Detach the node with this ID and all children
        /// Remove all dataRow front the bindingsource.
        /// </summary>
        /// <param name="id"></param>
        void RemoveItNodeAndChildren(int id)
        {
            itemsToProcess.Clear();
            itemsToProcess.Add(id);
            SelectItemsToProcess(id);

            foreach (int childID in itemsToProcess)
            {
                int index = _bindingSource_TreeView.Find("ID", childID);
                if (index == -1)
                    continue;

                _bindingSource_TreeView.RemoveAt(index);
            }
        }

        /// <summary>
        /// List of items to be processed
        /// </summary>
        List<int> itemsToProcess = new List<int>();

        /// <summary>
        /// Select all children of this parentID ( Rood node ) in the bindingSource,
        /// add it's to itemsToProcess List to be process. Do a recursive call in each
        /// node until reached the end.
        /// </summary>
        /// <param name="id"></param>
        void SelectItemsToProcess(int id)
        {
            string filterSub = "Parent_ID = " + id;
            DataView selectedChildren = new DataView(table_treeView, filterSub, "Parent_ID DESC", DataViewRowState.CurrentRows);

            foreach (DataRowView item in selectedChildren)
            {
                if (selectedChildren.Count != 0)
                    SelectItemsToProcess((int)item.Row["ID"]);

                itemsToProcess.Add((int)item.Row["ID"]);
            }
        }

        string FixedHtml(string value)
        {
            string description = null;
            if (value != "<P>&nbsp;</P>")
            {
                if (value.Contains("&nbsp;"))
                    description = Fixed_nbsp(value);

                if (value.Contains("<STRONG>"))
                    description = FixedStrong(value);

                if (value.Contains("<EM>"))
                    description = FixedEM(description ?? value);

                if (description == null)
                    description = value;
            }
            else
            {
                description = "";
            }

            return description;
        }

        string FixedStrong(string value)
        {
            var tofixed = value;

            tofixed = tofixed.Replace("<STRONG>", "<b>");
            tofixed = tofixed.Replace("</STRONG>", "</b>");

            return tofixed;
        }

        string FixedEM(string value)
        {
            var tofixed = value;

            tofixed = tofixed.Replace("<EM>", "<i>");
            tofixed = tofixed.Replace("</EM>", "</i>");

            return tofixed;
        }

        string Fixed_nbsp(string value)
        {
            var tofixed = value;

            tofixed = tofixed.Replace("&nbsp;", " ");

            return tofixed;
        }

        void StatusBarMessageHandler(object? sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        void TextBoxNodeNameKeyUp(object? sender, KeyEventArgs e)
        {
            //Used only to detect  enter keys, enter keys do not fire the TextChanged event.
            if (e.KeyData != Keys.Enter)
            {
                return;
            }
        }

        void TextBoxNodeNameTextChanged(object? sender, EventArgs e)
        {
            if (!(Bounds.Contains(PointToClient(MousePosition))))
                return;

            itemBindingTableTreeView.Text_Name = textBox_Node_Name.Text;
            BindingSourceTreeView.ResetCurrentItem();
            
            SaveUserSetting();
        }

        void TextBoxNodeNameMouseDoubleClick(object? sender, MouseEventArgs e)
        {
            textBox_Node_Name.SelectAll();
        }

        void TextBoxNodePdfInformationTextChanged(object? sender, EventArgs e)
        {
            if (!(Bounds.Contains(PointToClient(MousePosition))))
                return;

            itemBindingTableTreeView.Node_PDF = textBox_Node_PDF_Information.Text;
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSetting();
        }

        void TextBoxNodePictureTextChanged(object? sender, EventArgs e)
        {
            if (!(Bounds.Contains(PointToClient(MousePosition))))
                return;

            itemBindingTableTreeView.Node_Picture = textBox_Node_Picture.Text;
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSetting();
        }

        void TextBoxNodePdfInformationDoubleClick(object? sender, EventArgs e)
        {
            using (_openFile = new OpenFileDialog
            {
                Title = @"Please found Node PDF Information file......",
                FileName = "",
                Multiselect = false,
                Filter = @"(*.PDF)|*.PDF",
                DefaultExt = "(*.PDF)|*.PDF",
                InitialDirectory = Settings.Default.DataBaseAddress + "\\PDF Information\\"
            }
                 )
            {
                if (_openFile.ShowDialog(this) == DialogResult.Cancel)
                    return;

                if (!Path.GetExtension(_openFile.FileName).ToUpper().Contains("PDF"))
                {
                    MessageBox.Show(@"The file extension most be PDF type. Only PDF information is allowed.",
                                    @"Wrong file format.",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                textBox_Node_PDF_Information.Text = Path.GetFileName(_openFile.FileName);

                itemBindingTableTreeView.Node_PDF = textBox_Node_PDF_Information.Text;
                BindingSourceTreeView.ResetCurrentItem();

                SaveUserSetting();
            }
        }

        void TextBoxNodePictureDoubleClick(object? sender, EventArgs e)
        {
            using (var openFileDialogExt = new OpenFileDialogExt.OpenFileDialogExt
            {
                Title = @"Please select any Image",
                FileName = "",
                Filter = @"*.jpg|*.jpg|*.png|*.png|*.gif|*.gif",
                DefaultExt = "(*.jpg)|*.jpg",
                InitialDirectory = Settings.Default.DataBaseAddress + "\\Picture\\",
            }
                   )
            {
                if (openFileDialogExt.ShowDialog(this) == DialogResult.Cancel)
                    return;

                try
                {
                    textBox_Node_Picture.Text = Path.GetFileNameWithoutExtension(openFileDialogExt.FileName);

                    //                  _focusedNodeProperties.Node_Picture = openFileDialogExt.FileName.Replace(Settings.Default.DataBaseAddress, "");
                    //                  _focusedNodeProperties.SaveProperties();

                    IsMouseDrivenEvent = true;
                    SaveUserSetting();

                    if (!(openFileDialogExt.FileName.Contains(Settings.Default.DataBaseAddress + "\\Pictures\\")))
                    {
                        #region"Copy the file front source directory to destine directory"

                        var fo = new ShellBasics.ShellFileOperation();

                        var source = new string[1];
                        var dest = new string[1];

                        source[0] = openFileDialogExt.FileName;

                        dest[0] = Settings.Default.DataBaseAddress + "\\Pictures\\" + Path.GetFileName(openFileDialogExt.FileName);

                        fo.Operation = ShellBasics.ShellFileOperation.FileOperations.FO_COPY;
                        fo.OwnerWindow = Handle;
                        fo.SourceFiles = source;
                        fo.DestFiles = dest;

                        if (fo.DoOperation())
                        {
                            //                          _focusedNodeProperties.Node_Picture = "\\Pictures\\" + Path.GetFileName(openFileDialogExt.FileName);
                            //                          _focusedNodeProperties.SaveProperties();

                            IsMouseDrivenEvent = true;
                            SaveUserSetting();
                        }
                        else
                            MessageBox.Show(@"Copy Complete with errors!");

                        #endregion"Copy the file front source directory to destine directory"
                    }
                }
                catch (Exception excp)
                {
                    //                  _focusedNodeProperties.Node_Picture = null;
                    MessageBox.Show(@"Image Error ; " + excp.Message);
                }
            }
        }

        void ToolStripMenuItemNoneClick(object? sender, EventArgs e)
        {
            pictureBox_Image.Image = null;

            itemBindingTableTreeView.Node_Picture = "";
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSetting();
        }

        void tabPage_Properties_Click(object sender, EventArgs e)
        {

        }

        void pictureBox_Image_DoubleClick(object sender, EventArgs e)
        {
            using (var openFileDialogExt = new OpenFileDialogExt.OpenFileDialogExt
            {
                Title = @"Please select any Image",
                FileName = "",
                Filter = @"*.png|*.png|*.gif|*.gif|*.jpg|*.jpg",
                DefaultExt = "(*.png)|*.png",
                InitialDirectory = Path.Combine(initialDirectory, "\\Resources\\PNG\\48\\"),
            }
               )
            {
                if (openFileDialogExt.ShowDialog(this) == DialogResult.Cancel)
                    return;

                try
                {
                    pictureBox_Image.Image = Image.FromFile(openFileDialogExt.FileName);

                    itemBindingTableTreeView.Image = openFileDialogExt.FileName.Replace(initialDirectory, "");


                    OnNodeImageChange(new NodeImageChange_EventArgs());

                    if (!(openFileDialogExt.FileName.Contains(Settings.Default.DataBaseAddress + "\\Resources\\")))
                    {
                        #region"Copy the file front source directory to destinity directory"

                        var fo = new ShellBasics.ShellFileOperation();

                        var source = new string[1];
                        var dest = new string[1];

                        source[0] = openFileDialogExt.FileName;

                        dest[0] = Settings.Default.DataBaseAddress + "\\Resources\\Imported\\" + Path.GetFileName(openFileDialogExt.FileName);
                        itemBindingTableTreeView.Image = "\\Resources\\Imported\\" + Path.GetFileName(openFileDialogExt.FileName);

                        fo.Operation = ShellBasics.ShellFileOperation.FileOperations.FO_COPY;
                        fo.OwnerWindow = Handle;
                        fo.SourceFiles = source;
                        fo.DestFiles = dest;

                        if (fo.DoOperation())
                            MessageBox.Show(@"Copy Complete!");
                        else
                            MessageBox.Show(@"Copy Complete with errors!");

                        #endregion"Copy the file front source directory to destinity directory"
                    }

                    BindingSourceTreeView.ResetCurrentItem();

                    SaveUserSetting();
                }
                catch (Exception excp)
                {
                    itemBindingTableTreeView.Image = "";
                    MessageBox.Show(@"Image Error ; " + excp.Message);
                }
            }

            NeedSaveData = true;
        }

        void textBox_Title_TextChanged(object sender, EventArgs e)
        {
            if (!(Bounds.Contains(PointToClient(MousePosition))))
                return;

            itemBindingTableTreeView.Description_Short = textBox_Title.Text;
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSetting();
        }

        void textBox_Description_TextChanged(object sender, EventArgs e)
        {
            if (!(Bounds.Contains(PointToClient(MousePosition))))
                return;

            itemBindingTableTreeView.Description_Expand = textBox_Description.Text;
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSetting();
        }

        void buttonFilter_Click(object sender, EventArgs e)
        {
            if (buttonFilter.Text == "Show Filter")
            {
                buttonFilter.Text = "Hide Filter";
                BindingSourceTreeView.Filter = " AvalaibleDepartments LIKE '*" + _employeesService.CurrentDepartmentLogIn.DepartmentName + "*'";
                label_FilterStatus.Text = "Department filter applied.";
                label_FilterString.Text = BindingSourceTreeView.Filter;
            }
            else
            {
                buttonFilter.Text = "Show Filter";
                BindingSourceTreeView.RemoveFilter();
                label_FilterStatus.Text = "No Department filter applied.";
                label_FilterString.Text = "";
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

        void ContextMenuStripNodeSetting_Opening(object sender, CancelEventArgs e)
        {

        }

        void ToolStripMenuItem_RemoveImage_Click(object sender, EventArgs e)
        {
            pictureBox_Image.Image = null;
            itemBindingTableTreeView.Image = "";
            BindingSourceTreeView.ResetCurrentItem();
            SaveUserSetting();
        }
    }
}

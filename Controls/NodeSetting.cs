using StockRoom11net.Controls.BindingSourceExt;
using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using StockRoom11net.Properties;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
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
        /// Keep a record of all columns existent in the dataTableEmployees.
        /// </summary>
        DataColumnCollection ColumnsCollectionStockRoom { get; set; }

        OpenFileDialog _openFile = new OpenFileDialog();

        ResourcesCache.ResourcesCache _cache;

        // We will use the initial directory to store the resources files, like images and PDF files.
        // It is initialized with the value of the DataBaseAddress setting, which is the root directory of the application.
        readonly string defaultDirectory = Settings.Default.DataBaseAddress;

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

        void SaveUserSettings()
        {
            if (_currentItem.ID == 100000)
                return;

            // If the user is modifying the user interface, we will start a timer to save the user setting after 10 seconds.
            // otherwise, if the user is modifying the user interface by code, we will not start the timer to save the user setting.
            if (!_KeyPressEvent)
                return;

            _KeyPressEvent = false;

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

            OnSaveRequested(new Save_Requested_EventArgs(_currentItem){ });
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

        public DataRowView nextNewNode;

        /// <summary>
        /// Keep a reference to the current focused item, this is the item selected in the tree view.
        /// </summary>
        Table_Base_TreeView _currentItem;
        
        /// <summary>
        /// Set the current focused item,
        /// Input property to update the user interface with the properties of this recent selected item.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Table_Base_TreeView CurrentItem
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

                _currentItem = value;

                if (_currentItem.ID == 100000)
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

                    queryBuilder.Process_StringFilter(SanitizeFilter(_currentItem.String_Filter));

                    UpdateUi();
                    UpdateAvailableDepartment();
                }
            }
        }

        /// <summary>
        /// Reference to dataTableEmployees were is saved all information.
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

        PropertyDescriptorCollection _columnsCollection;
        /// <summary>
        /// Keep a record of all columns existent in StockRoom dataTableEmployees.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PropertyDescriptorCollection ColumnsCollection
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
        public NodeSetting(BindingSourceValidating<Table_Base_TreeView> treeView_datasource, PropertyDescriptorCollection columnCollection,
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
            InitializeSaveUserSettingTimer();
             
            _cache = new ResourcesCache.ResourcesCache();

            queryBuilder.StringFilter += QueryBuilderStringFilter;
            queryBuilder.StatusBarMessage += QueryBuilder_StatusBarMessage;

            textBox_Title.TextChanged += TextBox_Title_TextChanged;
            textBox_Title.KeyPress += NodeSetting_KeyPress;

            textBox_Description.TextChanged += TextBox_Description_TextChanged;
            textBox_Description.KeyPress += NodeSetting_KeyPress;

            textBox_Node_Name.TextChanged += TextBoxNodeNameTextChanged;
            textBox_Node_Name.KeyPress += NodeSetting_KeyPress;
            textBox_Node_Name.MouseDoubleClick += TextBoxNodeNameMouseDoubleClick;

            textBox_Node_PDF_Information.TextChanged += TextBoxNodePdfInformationTextChanged;
            textBox_Node_PDF_Information.KeyPress += NodeSetting_KeyPress;
            textBox_Node_PDF_Information.DoubleClick += TextBoxNodePdfInformationDoubleClick;

            textBox_Node_Picture.TextChanged += TextBoxNodePictureTextChanged;
            textBox_Node_Picture.KeyPress += NodeSetting_KeyPress;
            pictureBox_Image.DoubleClick += PictureBox_Image_DoubleClick;

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
                LastID = 200;
        }

        /// <summary>
        /// Keep a flag if the user is modifying the user interface or the interface is modifying by code.
        /// True if the user is modifying the user interface by keyboard, mouse or touch screen.
        /// False if the interface is modifying by code, no user interaction is involved.
        /// </summary>
        bool _KeyPressEvent = false;
        void NodeSetting_KeyPress(object? sender, KeyPressEventArgs e)
        {
            _KeyPressEvent = true;
        }

        void QueryBuilder_StatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        #region"AvailableDepartments"

        void UpdateAvailableDepartment()
        {

            if (_currentItem == null)
                return;

            if (_currentItem.AvailableDepartmentList.Count == 0)
                return;

            /// Reset or uncheck all AvailableDepartments checkBox
            for (int i = 0; i <= (flowLayoutPanel_AvailableDepartments.Controls.Count - 1); i++)
                ((CheckBox)flowLayoutPanel_AvailableDepartments.Controls[i]).Checked = false;

            /// Set or check those departments where the menu is available.
            foreach (string depart in _currentItem.AvailableDepartmentList)
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
            SaveUserSettings();

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

        void QueryBuilderStringFilter(object? sender, StringFilterControl_EventArgs e)
        {            
            if (_currentItem == null)
                return;

            // Update the current item with the new string filter generated by the query builder.
            _currentItem.String_Filter = SanitizeFilter(e.StringFilterSql);

            // Update the current item in the binding source to reflect the changes in the user interface.
            // We set the fiels _KeyPressEvent to true to indicate that intencionally we will save the changes after 10 seconds.
            _KeyPressEvent = true;
            SaveUserSettings();
            
        }

        /// <summary>
        /// Sanitize the filter string by removing any leading or trailing "AND" or "OR" operators.
        /// </summary>
        /// <param name="filter">The filter string to sanitize.</param>
        /// <returns>The sanitized filter string.</returns>
        static string SanitizeFilter(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return string.Empty;

            filter = filter.Trim();
            filter = Regex.Replace(filter, @"(?i)\s+(AND|OR)\s*$", "").Trim();
            filter = Regex.Replace(filter, @"(?i)^\s*(AND|OR)\s+", "").Trim();
            return filter;
        }

        void UpdateUi()
        {
            textBox_Node_Name.Text = _currentItem.Text_Name;

            textBox_Node_PDF_Information.Text = !string.IsNullOrEmpty(_currentItem.Node_PDF) ?
                                                                      _currentItem.Node_PDF : @"Double click to select a PDF file.";

            textBox_Node_Picture.Text = !string.IsNullOrEmpty(_currentItem.Node_Picture) ?
                                                              _currentItem.Node_Picture : @"Double click to select a picture.";

            if (_currentItem.Image == null || _currentItem.Image.Contains("Undefined") || _currentItem.Image == "")
            {
                pictureBox_Image.Image = null;
            }
            else
            {
                var imageResourcePathName = Path.Join(defaultDirectory, _currentItem.Image);

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

            textBox_Title.Text = _currentItem.Description_Short;
            textBox_Description.Text = _currentItem.Description_Expand;
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

        void TextBoxNodeNameTextChanged(object? sender, EventArgs e)
        {
            _currentItem.Text_Name = textBox_Node_Name.Text;
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSettings();
        }

        void TextBoxNodeNameMouseDoubleClick(object? sender, MouseEventArgs e)
        {
            textBox_Node_Name.SelectAll();
        }

        void TextBoxNodePdfInformationTextChanged(object? sender, EventArgs e)
        {
            if (!(textBox_Node_PDF_Information.Bounds.Contains(PointToClient(MousePosition))))
                return;

            _currentItem.Node_PDF = textBox_Node_PDF_Information.Text;
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSettings();
        }

        void TextBoxNodePictureTextChanged(object? sender, EventArgs e)
        {
            if (!(textBox_Node_Picture.Bounds.Contains(PointToClient(MousePosition))))
                return;

            _currentItem.Node_Picture = textBox_Node_Picture.Text;
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSettings();
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

                _currentItem.Node_PDF = textBox_Node_PDF_Information.Text;
                BindingSourceTreeView.ResetCurrentItem();

                SaveUserSettings();
            }
        }
               
        void TabPage_Properties_Click(object? sender, EventArgs e)
        {

        }

        void PictureBox_Image_DoubleClick(object? sender, EventArgs e)
        {
            using (var openFileDialogExt = new OpenFileDialogExt.OpenFileDialogExt
            {
                Title = @"Please select any Image",
                FileName = "",
                Filter = @"*.png|*.png|*.gif|*.gif|*.jpg|*.jpg",
                DefaultExt = "(*.png)|*.png",
                InitialDirectory = Path.Combine(defaultDirectory, "Resources", "PNG", "48"),
            }
               )
            {
                if (openFileDialogExt.ShowDialog(this) == DialogResult.Cancel)
                    return;

                try
                {
                    pictureBox_Image.Image = Image.FromFile(openFileDialogExt.FileName);

                    _currentItem.Image = openFileDialogExt.FileName.Replace(defaultDirectory, "");


                    OnNodeImageChange(new NodeImageChange_EventArgs());

                    if (!(openFileDialogExt.FileName.Contains(defaultDirectory + "\\Resources\\")))
                    {
                        #region"Copy the file front source directory to destinity directory"

                        var fo = new ShellBasics.ShellFileOperation();

                        var source = new string[1];
                        var dest = new string[1];

                        source[0] = openFileDialogExt.FileName;

                        dest[0] = Path.Combine(defaultDirectory, "Resources", "PNG", "48", Path.GetFileName(openFileDialogExt.FileName));
                        _currentItem.Image = Path.Combine("Resources", "PNG", "48", Path.GetFileName(openFileDialogExt.FileName));

                        fo.Operation = ShellBasics.ShellFileOperation.FileOperations.FO_COPY;
                        fo.OwnerWindow = Handle;
                        fo.SourceFiles = source;
                        fo.DestFiles = dest;

                        if (fo.DoOperation())
                            On_StatusBarMessage(new StatusBarMessage_EventArgs("", "Copy Complete!"));
                        //MessageBox.Show(@"Copy Complete!");
                        //else
                        // MessageBox.Show(@"Copy Complete with errors!");

                        #endregion"Copy the file front source directory to destinity directory"
                    }

                    BindingSourceTreeView.ResetCurrentItem();

                    SaveUserSettings();
                }
                catch (Exception excp)
                {
                    _currentItem.Image = "";
                    MessageBox.Show(@"Image Error ; " + excp.Message);
                }
            }

            NeedSaveData = true;
        }

        void TextBox_Title_TextChanged(object? sender, EventArgs e)
        {
            if (!(Bounds.Contains(PointToClient(MousePosition))))
                return;

            _currentItem.Description_Short = textBox_Title.Text;
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSettings();
        }

        void TextBox_Description_TextChanged(object? sender, EventArgs e)
        {
            if (!(Bounds.Contains(PointToClient(MousePosition))))
                return;

            _currentItem.Description_Expand = textBox_Description.Text;
            BindingSourceTreeView.ResetCurrentItem();

            SaveUserSettings();
        }

        void ButtonFilter_Click(object? sender, EventArgs e)
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

        void ContextMenuStripNodeSetting_Opening(object? sender, CancelEventArgs e)
        {

        }

        void ToolStripMenuItem_RemoveImage_Click(object? sender, EventArgs e)
        {
            pictureBox_Image.Image = null;
            _currentItem.Image = "";
            BindingSourceTreeView.ResetCurrentItem();
            SaveUserSettings();
        }
    }
}

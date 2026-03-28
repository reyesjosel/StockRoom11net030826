using System.Data;
using System.ComponentModel;
using System.Collections.Specialized;

using MyStuff11net;
using BrightIdeasSoftware;

using static MyStuff11net.Custom_Events_Args;

namespace StockRoom11net
{
    public partial class Employees_Management : BaseTemple
    {

        #region"Properties"

        /// <summary>
        /// Reference to datatable were is saved all information.
        /// </summary>
        private DataTable table;

        private int _lastID;
        // If we are using a bindingsource, used this in Load procedure.
        //    table = ((DataSet)_bindingSource.DataSource).Tables[_bindingSource.DataMember];
        // We ask per the lastID just before used.
        //            if (table.Rows.Count > 0)
        //                LastID = (int)table.Compute("MAX(ID)", "ID is Not null");
        //            else
        //                LastID = 0;
        /// <summary>
        /// Top value for ID fiel, option filter to select a group of row.
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

        #endregion"Properties"

        private BindingSource _bindingSource_EmployeesTreeView = new BindingSource();
        private DataTable _dataTableSetting = new DataTable("Setting");

        private Employee EmployeesSelected;
        private DepartmentInformation DepartmentSelected;

        public string PdfFile = "";

        private StringCollection PositionList = [];
        private StringCollection DepartmentList = [];

        public Employees_Management()
        {
            InitializeComponent();
        }

        public Employees_Management(BindingSource employees, BindingSource employeesTreeview, List<string> departList)
        {
            InitializeComponent();

            AutoScaleMode = AutoScaleMode.Dpi;
            DockAreas = WinFormsUI.Docking.DockAreas.Document | WinFormsUI.Docking.DockAreas.Float;

            if (employees == null)
            {
                MessageBox.Show("The input employees bindingSource is Null", "Error on initialization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DepartList = departList;
            _bindingSource_Employees = employees;
            _bindingSource_EmployeesTreeView = employeesTreeview;
            BindingSourceTreeViewBase = _bindingSource_EmployeesTreeView;

            foreach (object row in _bindingSource_Employees)
            {
                var Row = (DataRowView)row;

                var position = Row["Position"].ToString().Trim();
                if (!(PositionList.Contains(position)))
                    if (!(string.IsNullOrEmpty(position)) || !(string.IsNullOrWhiteSpace(position)))
                        PositionList.Add(position);

                var department = Row["Department"].ToString().Trim();
                if (!(DepartmentList.Contains(department)))
                    if (!(string.IsNullOrEmpty(department)) || !(string.IsNullOrWhiteSpace(department)))
                        DepartmentList.Add(department);
            }

            Load += Employees_Management_Load;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Employees_Management_Load(object? sender, EventArgs e)
        {
            // If we are using a binding source, used this in Load procedure.
            table = ((DataSet)_bindingSource_Employees.DataSource).Tables[_bindingSource_Employees.DataMember];
            ColumnsCollection = table.Columns;

            //   button_Adjustment.Enabled = false;
            splitContainer1.Panel1MinSize = 420;
            splitContainer2.Panel2MinSize = 665;

            splitContainer1.SplitterDistance = 475;
            splitContainer2.SplitterDistance = 665;

            _cache = new ResourcesCache();

            MessagePositionString = "Initialize_DataTreeListView";
            Initialize_DataTreeListView();
            DataTreeListView_Shown();

            InitializeCustomTabControl_Employee();

            DataGridViewExtended_EmployeeInitialize();

            SettingUI_Department();
            SettingUI_Employee();


            InitializeProfile();
        }

        #region"DataTreeListView"

        private HotItemStyle hotItemStyle = new HotItemStyle();
        private RowBorderDecoration rowBorderDec = new RowBorderDecoration();
        private Color foreColor = Color.White;
        private Color backColor = Color.White;

        private void Initialize_DataTreeListView()
        {
            olvDataTree.KeyAspectName = "ID";
            olvDataTree.ParentKeyAspectName = "Parent_ID"; olvDataTree.RootKeyValue = DBNull.Value;
            olvDataTree.FullRowSelect = true;
            olvDataTree.ShowKeyColumns = false;
            olvDataTree.AutoGenerateColumns = false;
            olvDataTree.Resize += OlvDataTree_Resize;
            olvDataTree.GotFocus += OlvDataTree_GotFocus;

            // How much space do we want to give each row? Obviously, this should be at least
            // the height of the images used by the renderer
            //olvDataTree.RowHeight = 32;

            toolStripMenuItem_FullRowSelect.Checked = true;

            SetupDescriptionColumn();
        }

        private void OlvDataTree_GotFocus(object? sender, EventArgs e)
        {
            OlvDataTree_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void OlvDataTree_Resize(object? sender, EventArgs e)
        {
            olvColumn_Description.Width = (olvDataTree.Width - olvColumn_TextName.Width) - 25;
        }

        private DataRowView expandedNode;
        private void OlvDataTree_Expanding(object? sender, TreeBranchExpandingEventArgs e)
        {
            if (olvDataTree.ExpandedObjects == null)
                return;

            expandedNode = (DataRowView)e.Item.RowObject;
            int espanding_parentID = (int)expandedNode["Parent_ID"];

            foreach (var item in olvDataTree.ExpandedObjects)
            {
                expandedNode = (DataRowView)item;
                string name = expandedNode["Text_Name"].ToString();
                int nodeID = (int)expandedNode["ID"];

                if (name != null && name.Contains("Stock Room"))
                    continue;

                if (nodeID == espanding_parentID)
                    continue;

                // olvDataTree.Collapse(expandedNode);
            }

        }

        private void DataTreeListView_Shown()
        {
            // The whole point of a DataTreeListView is to write no code.
            // So there is very little code here.

            // Put some images against each row
            olvColumn_TextName.ImageGetter = delegate (object row) { return "user"; };

            // Finally load the data into the UI
            olvDataTree.DataSource = BindingSourceTreeViewBase;

            // This does a better job of auto sizing the columns
            olvDataTree.AutoResizeColumns();
            olvColumn_TextName.Width = 300;
            olvColumn_Description.Width = (olvDataTree.Width - olvColumn_TextName.Width) - 25;
        }

        private Type DataBoundObject;
        private string DataBoundObject_Name;
        private DataRowView CurrentDataRowViewActive;
        private void OlvDataTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (olvDataTree.SelectedItem != null)
            {
                DataBoundObject = olvDataTree.SelectedItem.RowObject.GetType();
                DataBoundObject_Name = DataBoundObject.Name;
                if (DataBoundObject_Name.Contains("DataRowView"))
                {
                    CurrentDataRowViewActive = (DataRowView)olvDataTree.SelectedItem.RowObject;

                    _currentFocusedNodeproperties = new NodeProperties(CurrentDataRowViewActive);
                    if (_currentFocusedNodeproperties == null)
                        return;

                    _dataGridViewExtended_Employee.CustomFilter = _currentFocusedNodeproperties.StringFilter;

                    if (!olvDataTree.Bounds.Contains(olvDataTree.PointToClient(MousePosition)))
                        return;

                    #region"tabPage_Employee"

                    if (_currentFocusedNodeproperties.IsEmployee)
                    {
                        customTabControl_Employee.SelectedTab = customTabControl_Employee.TabPages["tabPage_Employee"];
                        customTabControl_Employee.ShowTab("tabPage_ProFile");
                        return;
                    }
                    #endregion"tabPage_Employee"

                    #region"TabControl_Inventory.ActiveTab.Name == "tabPage_TimeLine", show the TimeLine.

                    if (_currentFocusedNodeproperties.IsDepartment)
                    {
                        customTabControl_Employee.SelectedTab = customTabControl_Employee.TabPages["tabPage_Department"];
                        customTabControl_Employee.HideTab("tabPage_ProFile");
                    }
                    #endregion"If Selected Node is active, show the Pictures"
                }
            }
        }
        private void OlvDataTree_MouseClick(object sender, MouseEventArgs e)
        {
            if (olvDataTree.SelectedItem == null)
                _dataGridViewExtended_Employee.CustomFilter = "";
        }

        private void ToolStripMenuItem_HotItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            olvDataTree.UseTranslucentHotItem = false;
            olvDataTree.UseHotItem = true;
            olvDataTree.UseExplorerTheme = false;

            switch (e.ClickedItem.Text)
            {
                case "None":
                    {
                        olvDataTree.UseHotItem = false;
                        break;
                    }
                case "Text Color":
                    {
                        if (toolStripMenuItem_TextColor.Checked)
                        {
                            hotItemStyle.ForeColor = foreColor;
                            hotItemStyle.BackColor = backColor;
                            olvDataTree.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_TextColor.Checked = false;
                            break;
                        }
                        else
                        {
                            foreColor = hotItemStyle.ForeColor;
                            backColor = hotItemStyle.BackColor;

                            hotItemStyle.ForeColor = Color.AliceBlue;
                            hotItemStyle.BackColor = Color.FromArgb(255, 64, 64, 64);
                            olvDataTree.HotItemStyle = hotItemStyle;

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
                            olvDataTree.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Border.Checked = false;
                            break;
                        }
                        else
                        {
                            rowBorderDec.BorderPen = new Pen(Color.SeaGreen, 2);
                            rowBorderDec.CornerRounding = 4.0f;

                            hotItemStyle.Decoration = rowBorderDec;
                            olvDataTree.HotItemStyle = hotItemStyle;

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
                            olvDataTree.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Translucent.Checked = false;
                            break;
                        }
                        else
                        {
                            rowBorderDec.FillBrush = new SolidBrush(Color.FromArgb(64, Color.Blue));
                            rowBorderDec.CornerRounding = 4.0f;

                            hotItemStyle.Decoration = rowBorderDec;
                            olvDataTree.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Translucent.Checked = true;
                            break;
                        }
                    }
                case "Lightbox":
                    {
                        if (toolStripMenuItem_Lightbox.Checked)
                        {
                            hotItemStyle.Decoration = null;
                            olvDataTree.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Lightbox.Checked = false;
                            break;
                        }
                        else
                        {
                            hotItemStyle.Decoration = new LightBoxDecoration();
                            olvDataTree.HotItemStyle = hotItemStyle;

                            toolStripMenuItem_Lightbox.Checked = true;
                            break;
                        }
                    }
                case "FullRowSelect":
                    {
                        if (toolStripMenuItem_FullRowSelect.Checked)
                        {
                            olvDataTree.FullRowSelect = false;
                            olvDataTree.UseHotItem = true;
                            //olvDataTree.UseExplorerTheme = true;

                            toolStripMenuItem_FullRowSelect.Checked = false;
                        }
                        else
                        {
                            olvDataTree.FullRowSelect = true;
                            //olvDataTree.UseHotItem = false;
                            //olvDataTree.UseExplorerTheme = true;

                            toolStripMenuItem_FullRowSelect.Checked = true;
                        }
                        break;
                    }
            }

            olvDataTree.Invalidate();
        }

        private void ToolStripMenuItem_singleExpandedNode_Click(object sender, EventArgs e)
        {
            //olvDataTree.Exp
        }

        private void SetupDescriptionColumn()
        {
            // Setup a described task renderer, which draws a large icon
            // with a title, and a description under the title.
            // Almost all of this configuration could be done through the Designer
            // but I've done it through code that make it clear what's going on.

            // Create and install an appropriately configured renderer 
            olvColumn_Description.Renderer = CreateDescribedTaskRenderer();

            // Now let's setup the couple of other bits that the column needs

            // Tell the column which property should be used to get the title
            olvColumn_Description.AspectName = "Description_Expand";

            // Tell the column which property holds the identifier for the image for row.
            // We could also have installed an ImageGetter
            //   olvColumn_Description.ImageAspectName = "Node_Picture";

            // Put a little bit of space around the task and its description
            olvColumn_Description.CellPadding = new Rectangle(4, 2, 4, 2);
        }

        private DescribedTaskRenderer CreateDescribedTaskRenderer()
        {
            // Let's create an appropriately configured renderer.
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();

            // Give the renderer its own collection of images.
            // If this isn't set, the renderer will use the SmallImageList from the ObjectListView.
            // (this is standard Renderer behaviour, not specific to DescribedTaskRenderer).
            //       renderer.ImageList = this.imageListTasks;

            // Tell the renderer which property holds the text to be used as a description
            renderer.DescriptionAspectName = "Description_Expand";

            // Change the formatting slightly
            renderer.TitleFont = new Font("Tahoma", 11, FontStyle.Bold);
            renderer.DescriptionFont = new Font("Tahoma", 9);
            renderer.ImageTextSpace = 8;
            renderer.TitleDescriptionSpace = 1;

            // Use older Gdi rendering, since most people think the text looks clearer
            renderer.UseGdiTextRendering = true;

            // If you like colors other than black and grey, you could uncomment these
            //            renderer.TitleColor = Color.DarkBlue;
            //            renderer.DescriptionColor = Color.CornflowerBlue;

            return renderer;
        }

        #endregion"DataTreeListView"

        #region"CustomTabControl_Employee"

        private void InitializeCustomTabControl_Employee()
        {
            customTabControl_Employee.Alignment = TabAlignment.Bottom;
            customTabControl_Employee.SelectedIndexChanged += CustomTabControl_Employee_SelectedIndexChanged;
        }

        private void CustomTabControl_Employee_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!customTabControl_Employee.Bounds.Contains(
                    customTabControl_Employee.PointToClient(MousePosition)))
                return;

            if (customTabControl_Employee.SelectedTab != null &
                customTabControl_Employee.SelectedTab.Name.Contains("tabPage_Employee"))
            {
                olvDataTree.SelectedIndex = 0;
                customTabControl_Employee.ShowTab("tabPage_ProFile");
                return;
            }

            if (customTabControl_Employee.SelectedTab != null &
                customTabControl_Employee.SelectedTab.Name.Contains("tabPage_Department"))
            {
                olvDataTree.SelectedIndex = 1;
                customTabControl_Employee.HideTab("tabPage_ProFile");
                return;
            }
        }

        #endregion"CustomTabControl_Employee"

        #region"DataGridView"
        private void DataGridViewExtended_EmployeeInitialize()
        {
            InitializeDataGridViewBase(_dataGridViewExtended_Employee);
                        
            _dataGridViewExtended_Employee.Name = "EmployeesDepartment";

            //_dataGridViewExtended_Employee.CellBegingEditEvent += _dataGridViewExtended_EmployeeInventoryCellBegingEditEvent;
            //_dataGridViewExtended_Employee_Employees.CellEndEditEvent     += _dataGridViewExtended_EmployeeInventoryCellEndEditEvent;
            //_dataGridViewExtended_Employee_Employees.CellClickEvent       += _dataGridViewExtended_Employee_StockRoom_CellClick_Event;
            //_dataGridViewExtended_Employee_Employees.CellDoubleClickEvent += _dataGridViewExtended_Employee_StockRoom_CellDoubleClick_Event;
            _dataGridViewExtended_Employee.CurrentRowActivesEvent += DataGridViewExtended_Employees_CurrentRowActive;
            //_dataGridViewExtended_Employee_Employees.FindReplace         += _dataGridViewExtended_Employee_Inventory_Find_Replace;
            _dataGridViewExtended_Employee.RefreshRequested += DataGridViewExtended_Employees_Management_Refresh_Requested;
            //_dataGridViewExtended_Employee_Employees.UserDeletedRow       += _dataGridViewExtended_EmployeeInventoryUserDeletedRow;
            //_dataGridViewExtended_Employee_Employees.RowsRemoved          += _dataGridViewExtended_EmployeeInventoryRowsRemoved;
            //_dataGridViewExtended_Employee_Employees.MouseEnterEvent      += _dataGridViewExtended_EmployeeInventoryMouseEnterEvent;
            //_dataGridViewExtended_Employee_Employees.DataGridViewSort     += _dataGridViewExtended_EmployeeInventoryDataGridViewSort;

            //_dataGridViewExtended_Employee_Employees.LogFileMessage       += _dataGridViewExtended_Employee_EmployeesLogFileMessage;
            _dataGridViewExtended_Employee.ContextMenuStripOpening += DataGridViewExtended_Employee_ContextMenuStripOpening;

            _dataGridViewExtended_Employee.DataSource = _bindingSource_Employees;

            _dataGridViewExtended_Employee._dataGridView.ReadOnly = false;
            _dataGridViewExtended_Employee.CustomEdit = MyCode.EditMode.Delete;
        }

        private void DataGridViewExtended_Employee_ContextMenuStripOpening(object sender, ContextMenuStrip e)
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

        private void DataGridViewExtended_EmployeeInventoryCellBeginEditEvent(object sender, DataGridViewCellCancelEventArgs e)
        {
            // _currentColumnActive = CurrentDataColumnActive(e.ColumnIndex);

            if (CurrentEmployeesLogIn.IsUser)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            if (_currentColumnActive == null)
                return;
        }

        private void DataGridViewExtended_Employees_Management_Refresh_Requested(object sender, Refresh_Requested_EventArgs e)
        {
            try
            {
                On_Refresh_Requested(new Refresh_Requested_EventArgs(_bindingSource_Employees.Filter));
                NeedSaveData = false;
            }
            catch (Exception)
            {

            }
        }

        private void DataGridViewExtended_Employees_CurrentRowActive(object sender, CurrentRowActive_EventArgs e)
        {
            try
            {
                if (e.CurrentRowActive == null || e.CurrentRowActive.Index == -1)
                    return;
                MessagePositionString = "e.CurrentRowActive.Index";
                DataRowView currentRow = (DataRowView)_bindingSource_Employees[e.CurrentRowActive.Index];

                if (currentRow["Department"].ToString().Contains("Department"))
                {
                    DepartmentSelected = new DepartmentInformation(currentRow);
                    DepartmentSelected.Save_Requested -= EmployeesDepartmentSelected_SaveRequested;
                    DepartmentSelected.Save_Requested += EmployeesDepartmentSelected_SaveRequested;

                    InitializeUI_Department(DepartmentSelected);
                }
                else
                {
                    EmployeesSelected = new Employee(currentRow);
                    EmployeesSelected.Save_Requested -= EmployeesDepartmentSelected_SaveRequested;
                    EmployeesSelected.Save_Requested += EmployeesDepartmentSelected_SaveRequested;

                    InitializeUI_Employee(EmployeesSelected);
                }
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(@"Message related to this error is " + error.Message +
                                    @", Break code at position " + MessagePositionString,
                                    @"StockRoom Inventory has generated an error.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EmployeesDepartmentSelected_SaveRequested(object sender, Save_Requested_EventArgs e)
        {
            try
            {
                On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
                NeedSaveData = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase. Employees Management.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        #endregion"DataGridView"

        #region"Process Employees"

        private void SettingUI_Employee()
        {
            textBox_Last6Digit.TextChanged += AnySetting_TextChanged;
            textBox_Employee_Name.TextChanged += AnySetting_TextChanged;
            textBox_Employee_LastName.TextChanged += AnySetting_TextChanged;
            textBox_Address.TextChanged += AnySetting_TextChanged;
            textBox_Telephone.TextChanged += AnySetting_TextChanged;
            dateTimePicker_Hire_Date.ValueChanged += AnySetting_TextChanged;
            textBox_Size.TextChanged += AnySetting_TextChanged;

            comboBox_Position.SelectedValueChanged += AnySetting_TextChanged;
            comboBox_Position.TextChanged += AnySetting_TextChanged;
            comboBox_Position.DataSource = PositionList;

            comboBox_Department.SelectedValueChanged += AnySetting_TextChanged;
            comboBox_Department.TextChanged += AnySetting_TextChanged;
            comboBox_Department.DataSource = DepartmentList;

            comboBox_AccessLevel.SelectedValueChanged += AnySetting_TextChanged;
            comboBox_AccessLevel.TextChanged += AnySetting_TextChanged;
            comboBox_AccessLevel.DataSource = Enum.GetValues(typeof(MyCode.AccessLevel));

            comboBox_EditMode.SelectedValueChanged += AnySetting_TextChanged;
            comboBox_EditMode.TextChanged += AnySetting_TextChanged;
            comboBox_EditMode.DataSource = Enum.GetValues(typeof(MyCode.EditMode));

            comboBox_EnableSetting.SelectedValueChanged += AnySetting_TextChanged;
            comboBox_EnableSetting.TextChanged += AnySetting_TextChanged;
            comboBox_EnableSetting.DataSource = Enum.GetValues(typeof(MyCode.EnableSetting));

            button_AddNewEmployee.Enabled = true;
            button_SaveEmployee.Text = "Save";
            button_SaveEmployee.Enabled = false;
            button_DeleteEmployee.Enabled = true;
                        
            DataGridViewExtended_Employees_CurrentRowActive(new object(),
                new CurrentRowActive_EventArgs(_dataGridViewExtended_Employee.CurrentRowActive));
        }

        private void InitializeUI_Employee(Employee employeesSelected)
        {
            if (DepartmentList.Contains("Department"))
                DepartmentList.Remove("Department");

            UpdateUI_Employee(employeesSelected);

            GeneratedDataGridViedProfile(EmployeesSelected);

            NeedSaveData = false;
            button_AddNewEmployee.Enabled = true;
            button_SaveEmployee.Enabled = false;
            button_SaveEmployee.Text = "Save";
        }

        private void UpdateUI_Employee(Employee employeesSelected)
        {
            textBox_Employee_Name.Text = employeesSelected.Name;
            textBox_Employee_LastName.Text = employeesSelected.LastName;
            textBox_Address.Text = employeesSelected.Address;
            textBox_Last6Digit.Text = employeesSelected.Last6Digit + "";
            textBox_Telephone.Text = employeesSelected.Telephone;
            dateTimePicker_Hire_Date.Value = employeesSelected.HireDate;
            textBox_Size.Text = employeesSelected.Size;

            comboBox_Position.SelectedItem = employeesSelected.Position;
            comboBox_Department.SelectedItem = employeesSelected.Department;
            comboBox_AccessLevel.SelectedItem = employeesSelected.EmployeeAccessLevel;
            comboBox_EditMode.SelectedItem = employeesSelected.EmployeeEditMode;
            comboBox_EnableSetting.SelectedItem = employeesSelected.EmployeeEnableTreeViewSetting;
        }

        private void SaveEmployeeSelected()
        {
            button_SaveEmployee.Text = "Save";
            button_SaveEmployee.Enabled = false;

            EmployeesSelected.Last6Digit = MyCode.CastAsInt(textBox_Last6Digit.Text);
            EmployeesSelected.Name = textBox_Employee_Name.Text;
            EmployeesSelected.LastName = textBox_Employee_LastName.Text;
            EmployeesSelected.Address = textBox_Address.Text;
            EmployeesSelected.Telephone = textBox_Telephone.Text;
            EmployeesSelected.HireDate = dateTimePicker_Hire_Date.Value;
            EmployeesSelected.Size = textBox_Size.Text;
            EmployeesSelected.Position = comboBox_Position.Text;
            EmployeesSelected.Department = comboBox_Department.Text;

            EmployeesSelected.EmployeeAccessLevel = (MyCode.AccessLevel)comboBox_AccessLevel.SelectedItem;
            EmployeesSelected.EmployeeEditMode = (MyCode.EditMode)comboBox_EditMode.SelectedItem;
            EmployeesSelected.EmployeeEnableTreeViewSetting = (MyCode.EnableSetting)comboBox_EnableSetting.SelectedItem;

            EmployeesSelected.SaveSetting();

            _dataGridViewExtended_Employee.FirstDisplayedRow = "ID/" + EmployeesSelected.ID;

            // Do not call it here, EmployeeInformation will call automatically on event Save_Requested.
            //dataGridViewExtended_Employees_Management_Save_Requested(new object(), new EventArgs());
        }

        private bool Last6Digit_Valid()
        {
            if (textBox_Last6Digit.Text.Length != 6)
            {
                MessageBox.Show(@"The Last6Digit most be 6 digit length. Last6Digit_Valid().",
                                   @"Wrongt lengt in value Last6Digit. Employees Management.",
                                         MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }

            int NewLast6Digit = MyCode.CastAsInt(textBox_Last6Digit.Text);

            foreach (object row in _bindingSource_Employees)
            {
                DataRowView _row = row as DataRowView;
                int Last6Digit = MyCode.CastAsInt(_row["Last6Digit"]);

                if (Last6Digit == NewLast6Digit)
                {
                    MessageBox.Show("Errors in the information, the employee Last6Digit number ( " + textBox_Last6Digit.Text + " ) already exist.",
                                                                            "Duplicate staff number.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool isNewEmployee;
        private void Button_AddEmployee_Click(object sender, EventArgs e)
        {
            button_AddNewEmployee.Enabled = false;
            button_SaveEmployee.Text = "Save Employee";
            button_SaveEmployee.Enabled = true;

            try
            {
                // We ask per the lastID just before used.
                if (table.Rows.Count > 0)
                    LastID = (int)table.Compute("MAX(ID)", "ID is Not null");
                else
                    LastID = 0;

                DataRowView _newRow = (DataRowView)_bindingSource_Employees.AddNew();
                _newRow["Index"] = LastID;
                _newRow["ID"] = _newRow["Index"];
                _newRow["Last6Digit"] = 0;
                _newRow["LastName"] = "";
                _newRow["Name"] = "";
                _newRow["Address"] = "";
                _newRow["Telephone"] = "";
                _newRow["Dob"] = DateTime.Now.ToShortDateString();
                _newRow["HireDate"] = DateTime.Now.ToShortDateString();
                _newRow["UserSetting"] = "dataGridViewExtended_Inventory_UserSetting|1,0#dataGridViewExtended_CalendarViewer_UserSetting|1,0";
                _newRow["DataGridViewSetting"] = "dataGridViewExtended_Inventory_ColumnsSettingList|PartNumber,0,0,124,True,True,0;" +
                                    "Description,1,1,258,True,True,0;Manufacturer,2,2,190,True,True,0;ModelNumber,3,3,132,True,True,0;" +
                                    "Supplier,4,4,100,True,True,0;DataSheet_File,5,5,100,True,True,0;Who_uses_this,6,6,336,True,True,0;" +
                                    "OnHand,7,7,128,True,True,0;OnHold,8,8,100,True,True,0;OnHoldBy,9,9,100,False,True,0;OnAvailable,10,10,100,False,True,0;" +
                                    "Reel_Number,11,11,100,False,True,0;OnOrder,12,12,119,False,True,0;OnDemand,13,13,100,False,True,0;" +
                                    "ToOrder,14,14,100,False,True,32;MinQty,15,15,100,False,True,0;MaxQty,16,16,100,False,True,0;LTime,17,17,100,False,True,0;" +
                                    "PrevQty,18,18,100,False,True,0;SalePrice,19,19,100,False,True,0;Weight,20,20,100,False,True,0;" +
                                    "Replaced_by,21,21,100,False,True,0;Message_String,22,22,100,False,True,0;Status,23,23,100,False,True,0;" +
                                    "#StockRoom Inventory_ColumnsSettingList|PartNumber,0,0,100,True,True,0;Description,1,1,171,True,True,0;" +
                                    "Manufacturer,2,2,137,True,True,0;ModelNumber,3,3,149,True,True,0;Supplier,4,4,96,False,True,0;" +
                                    "DataSheet_File,5,5,100,False,True,0;Who_uses_this,6,6,210,True,True,0;OnHand,7,7,100,True,True,0;" +
                                    "OnHold,8,8,100,False,False,0;OnHoldBy,9,9,100,False,False,0;OnAvailable,10,10,100,False,False,0;" +
                                    "Reel_Number,11,11,100,False,False,0;OnOrder,12,12,100,False,False,0;OnDemand,13,13,100,False,False,0;" +
                                    "ToOrder,14,14,100,False,False,32;MinQty,15,15,100,False,False,0;MaxQty,16,16,100,False,False,0;" +
                                    "LTime,17,17,100,False,False,0;PrevQty,18,18,100,False,False,0;SalePrice,19,19,100,False,False,0;" +
                                    "Weight,20,20,100,False,False,0;Replaced_by,21,21,100,False,False,0;Properties,22,22,100,False,False,0;" +
                                    "Location,23,23,100,False,False,0;Message_String,24,24,100,False,False,0;Status,25,25,100,False,False,0";
                _newRow["Position"] = "";
                _newRow["Department"] = "";
                _newRow["AccessLevel"] = "AccessLevel:0;EditMode:0;EnableTreeViewSetting:0";
                _newRow["Size"] = "";
                _newRow["Status"] = "";
                _newRow.EndEdit();

                _bindingSource_Employees.EndEdit();
                //      _bindingSource_Employees.ResetCurrentItem();
                //      InitializeUI(new EmployeesInformation((DataRowView)_bindingSource_Employees.Current));

                isNewEmployee = true;

                textBox_Last6Digit.Clear();
                textBox_Last6Digit.Focus();

                MyCode.MouseUtility.MousePointerPosition(textBox_Last6Digit, 2, 2);
                MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);

                DataGridViewExtended_Employees_CurrentRowActive(sender, new CurrentRowActive_EventArgs(
                                    (int)_newRow["ID"], _dataGridViewExtended_Employee.CurrentRowActive));
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Button_Add_Click() found an error " + error.Message,
                                 @"Employees Management has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_SaveEmployee_Click(object sender, EventArgs e)
        {
            button_SaveEmployee.Text = "Save";
            button_SaveEmployee.Enabled = false;

            if (isNewEmployee)
            {
                #region"Test if the Last6Digit number exist"

                if (!Last6Digit_Valid())
                {
                    textBox_Last6Digit.Focus();
                    return;
                }

                #endregion"Test if the Last6Digit number exist"

                isNewEmployee = false;
                button_AddNewEmployee.Enabled = true;
            }

            try
            {
                NeedSaveData = false;
                SaveEmployeeSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase. Employees Management.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void Button_DeleteEmployee_Click(object sender, EventArgs e)
        {
            button_SaveEmployee.Text = "Save Changes";
            button_SaveEmployee.Enabled = true;

            if (isNewEmployee)
            {
                _bindingSource_Employees.RemoveCurrent();
                isNewEmployee = false;
                button_AddNewEmployee.Enabled = true;
                return;
            }

            _bindingSource_Employees.RemoveCurrent();

            if (EmployeesSelected == null)
                return;

            //UpdateUI_Employee(EmployeesSelected);

            NeedSaveData = false;
        }

        private void AnySetting_TextChanged(object sender, EventArgs e)
        {
            if (!customTabControl_Employee.Bounds.Contains(
                    customTabControl_Employee.PointToClient(MousePosition)))
                return;

            button_AddNewEmployee.Enabled = false;
            button_SaveEmployee.Enabled = true;
            NeedSaveData = true;
        }

        #endregion"Process Employees"

        #region"Process Department"

        private void SettingUI_Department()
        {
            textBox_DepartmentName.TextChanged += AnySetting_TextChanged;
            textBox_DepartmentComents.TextChanged += AnySetting_TextChanged;
            textBox_DepartmentID.TextChanged += AnySetting_TextChanged;
            textBox_DepartmentTelephone.TextChanged += AnySetting_TextChanged;

            button_AddNewDept.Click += new EventHandler(Button_AddNewDept_Click);
            button_AdjustmentDept.Click += new EventHandler(Button_AdjustmentDept_Click);
            button_SaveDept.Click += new EventHandler(Button_SaveDept_Click);
        }

        private void InitializeUI_Department(DepartmentInformation departmentInformation)
        {
            DepartmentList.Clear();
            DepartmentList.Add("Department");

            textBox_DepartmentName.Text = departmentInformation.DeptName;
            textBox_DepartmentComents.Text = departmentInformation.DeptComments;
            textBox_DepartmentID.Text = departmentInformation.DeptID + "";
            textBox_DepartmentTelephone.Text = departmentInformation.DeptTelephone;
        }

        private void UpDateDepartmentSelected()
        {
            DepartmentSelected.DeptID = MyCode.CastAsInt(textBox_DepartmentID.Text);
            DepartmentSelected.DeptName = textBox_DepartmentName.Text;
            //    DepartmentSelected.LastName = textBox_Employee_LastName.Text;
            DepartmentSelected.DeptComments = textBox_DepartmentComents.Text;
            DepartmentSelected.DeptTelephone = textBox_DepartmentTelephone.Text;
            //    DepartmentSelected.HireDate = dateTimePicker_Hire_Date.Value;
            //    DepartmentSelected.Size = textBox_Size.Text;
            //    DepartmentSelected.Position = comboBox_Position.Text;
            //    DepartmentSelected.Department; // ReadOnly

            DepartmentSelected.DeptAccessLevel = (MyCode.AccessLevel)comboBox_AccessLevel.SelectedItem;
            DepartmentSelected.DeptEditMode = (MyCode.EditMode)comboBox_EditMode.SelectedItem;

            foreach (Control dataControl in panel_dataGridViewProfile.Controls)
            {
                DataGridViewSetting dataGridViewSetting = (DataGridViewSetting)dataControl;

                DepartmentSelected.DataGridViewSettingDict.Clear();
                DepartmentSelected.DataGridViewSettingDict.Add(dataGridViewSetting.SettingName.Key,
                                                               dataGridViewSetting.SettingName.Value);
            }

            DepartmentSelected.SaveSetting();

            _dataGridViewExtended_Employee.FirstDisplayedRow = "ID/" + DepartmentSelected.ID;

            // Do not call it here, EmployeeInformation will call automatically on event Save_Requested.
            //dataGridViewExtended_Employees_Management_Save_Requested(new object(), new EventArgs());
        }


        private void Button_CancelDept_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_SaveDept_Click(object sender, EventArgs e)
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

        private void Button_AdjustmentDept_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_AddNewDept_Click(object sender, EventArgs e)
        {
            try
            {
                // We ask per the lastID just before used.
                if (table.Rows.Count > 0)
                    LastID = (int)table.Compute("MAX(ID)", "ID is Not null");
                else
                    LastID = 0;

                DataRowView _newRow = (DataRowView)_bindingSource_Employees.AddNew();
                _newRow["Index"] = LastID;
                _newRow["ID"] = _newRow["Index"];
                _newRow["Last6Digit"] = 0;
                _newRow["LastName"] = "";
                _newRow["Name"] = "";
                _newRow["Address"] = "";
                _newRow["Telephone"] = "";
                _newRow["Dob"] = DateTime.Now.ToShortDateString();
                _newRow["HireDate"] = DateTime.Now.ToShortDateString();
                _newRow["UserSetting"] = "dataGridViewExtended_Inventory_UserSetting|1,0#dataGridViewExtended_CalendarViewer_UserSetting|1,0";
                _newRow["DataGridViewSetting"] = "dataGridViewExtended_Inventory_ColumnsSettingList|PartNumber,0,0,124,True,True,0;" +
                                    "Description,1,1,258,True,True,0;Manufacturer,2,2,190,True,True,0;ModelNumber,3,3,132,True,True,0;" +
                                    "Supplier,4,4,100,True,True,0;DataSheet_File,5,5,100,True,True,0;Who_uses_this,6,6,336,True,True,0;" +
                                    "OnHand,7,7,128,True,True,0;OnHold,8,8,100,True,True,0;OnHoldBy,9,9,100,False,True,0;OnAvailable,10,10,100,False,True,0;" +
                                    "Reel_Number,11,11,100,False,True,0;OnOrder,12,12,119,False,True,0;OnDemand,13,13,100,False,True,0;" +
                                    "ToOrder,14,14,100,False,True,32;MinQty,15,15,100,False,True,0;MaxQty,16,16,100,False,True,0;LTime,17,17,100,False,True,0;" +
                                    "PrevQty,18,18,100,False,True,0;SalePrice,19,19,100,False,True,0;Weight,20,20,100,False,True,0;" +
                                    "Replaced_by,21,21,100,False,True,0;Message_String,22,22,100,False,True,0;Status,23,23,100,False,True,0;" +
                                    "#StockRoom Inventory_ColumnsSettingList|PartNumber,0,0,100,True,True,0;Description,1,1,171,True,True,0;" +
                                    "Manufacturer,2,2,137,True,True,0;ModelNumber,3,3,149,True,True,0;Supplier,4,4,96,False,True,0;" +
                                    "DataSheet_File,5,5,100,False,True,0;Who_uses_this,6,6,210,True,True,0;OnHand,7,7,100,True,True,0;" +
                                    "OnHold,8,8,100,False,False,0;OnHoldBy,9,9,100,False,False,0;OnAvailable,10,10,100,False,False,0;" +
                                    "Reel_Number,11,11,100,False,False,0;OnOrder,12,12,100,False,False,0;OnDemand,13,13,100,False,False,0;" +
                                    "ToOrder,14,14,100,False,False,32;MinQty,15,15,100,False,False,0;MaxQty,16,16,100,False,False,0;" +
                                    "LTime,17,17,100,False,False,0;PrevQty,18,18,100,False,False,0;SalePrice,19,19,100,False,False,0;" +
                                    "Weight,20,20,100,False,False,0;Replaced_by,21,21,100,False,False,0;Properties,22,22,100,False,False,0;" +
                                    "Location,23,23,100,False,False,0;Message_String,24,24,100,False,False,0;Status,25,25,100,False,False,0";
                _newRow["Position"] = "";
                _newRow["Department"] = "Department";
                _newRow["AccessLevel"] = "AccessLevel:0;EditMode:0;EnableTreeViewSetting:0";
                _newRow["Size"] = "";
                _newRow["Status"] = "";
                _newRow.EndEdit();

                _bindingSource_Employees.EndEdit();

                button_AddNewDept.Enabled = false;

                isNewEmployee = true;

                MyCode.MouseUtility.MousePointerPosition(textBox_DepartmentName, 2, 2);
                MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);

                DataGridViewExtended_Employees_CurrentRowActive(sender, new CurrentRowActive_EventArgs((int)_newRow["ID"],
                                                                                        _dataGridViewExtended_Employee.CurrentRowActive));
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Button_AddDept_Click() found an error " + error.Message,
                                 @"Department Management has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion"Process Department"

        #region"Profile"

        private void InitializeProfile()
        {
            button_DeleteProfile.Enabled = false;
        }

        private void GeneratedDataGridViedProfile(Employee activeEmployee)
        {
            panel_dataGridViewProfile.Controls.Clear();

            foreach (KeyValuePair<string, List<ColumnSetting>> SettingName in activeEmployee.DataGridViewSettingDict)
            {
                DataGridViewSetting dataGridViewSetting = new DataGridViewSetting(SettingName);

                dataGridViewSetting.Dock = DockStyle.Top;
                dataGridViewSetting.Click += new EventHandler(DataGridViewSetting_Click);
                panel_dataGridViewProfile.Controls.Add(dataGridViewSetting);
            }
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

                EmployeesSelected.DataGridViewSettingDict.Add(dataGridViewSetting.SettingName.Key,
                                                                                    dataGridViewSetting.SettingName.Value);
            }

            EmployeesSelected.SaveSetting();
        }

        private void Button_Profile_Cancel_Click(object sender, EventArgs e)
        {
            GeneratedDataGridViedProfile(EmployeesSelected);
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
                
    }


}

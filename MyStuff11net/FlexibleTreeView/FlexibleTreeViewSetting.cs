using MyStuff11net.Properties;
using System.ComponentModel;
using System.Data;
using CurrentRowActive_EventArgs = MyStuff11net.Custom_Events_Args.CurrentRowActive_EventArgs;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;

namespace MyStuff11net
{
    public partial class FlexibleTreeViewSetting : Form
    {
        readonly List<string> DepartList;
        readonly BindingSource _treeView_bindingSource;
        readonly NodeProperties _selectedNode;

        Resources _cache;

        #region"Events, Custom Controls Events with custom Args.*********************"

        #region"Save_Requested"

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Save_Requested_EventHandler Save_Requested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_Save_Requested(Save_Requested_EventArgs e)
        {
            Save_Requested?.Invoke(this, e);
        }
        #endregion

        #endregion "Events, Custom Controls Events with custom Args.*********************"

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

        int _lastID;
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

        private bool _needSaveData;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NeedSaveData
        {
            get
            {
                return _needSaveData;
            }
            set
            {
                _needSaveData = value;
            }
        }

        private Employee _currentEmployeesLogIn;
        /// <summary>
        /// Process current employee information.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Employee CurrentEmployeesLogIn
        {
            get
            {
                return _currentEmployeesLogIn;
            }
            set
            {
                _currentEmployeesLogIn = value;
                dataGridViewExtended_Setting.CurrentEmployeesLogIn = _currentEmployeesLogIn;
            }
        }

        readonly DepartmentInformation CurrentDepartmentLogIn;

        #endregion"Properties"

        /// <summary>
        /// Initialize new instance of FlexibleTreeView setting.
        /// </summary>
        /// <param name="bindingSource">TreeView data source.</param>
        /// <param name="stockroomcollection">Column collection used in filter string.</param>
        /// <param name="currentEmployeesLogIn">Employee Information.</param>
        /// <param name="selectedNode">Selected node at this moment.</param>
        public FlexibleTreeViewSetting(BindingSource treeviewbindingSource, DataColumnCollection stockroomcollection,
                                       Employee currentEmployeesLogIn, DepartmentInformation currentDepartmentLogIn,
                                       NodeProperties selectedNode, List<string> departList)
        {
            try
            {
                InitializeComponent();

                if (treeviewbindingSource != null)
                    _treeView_bindingSource = treeviewbindingSource;

                StockRoomColumns = stockroomcollection;

                _selectedNode = selectedNode;
                DepartList = departList;

                /*
                Type typeDataSource = _treeView_bindingSource.DataSource.GetType();
                                
                if (typeDataSource.BaseType == typeof(DataSet))
                    table = ((DataSet)_treeView_bindingSource.DataSource).Tables[_treeView_bindingSource.DataMember];

                if (typeDataSource.BaseType == typeof(DataTable))
                    table = _treeView_bindingSource.DataSource as DataTable;
                */

                CurrentEmployeesLogIn = currentEmployeesLogIn;
                CurrentDepartmentLogIn = currentDepartmentLogIn;

                if (_currentEmployeesLogIn.Last6Digit == 811266)
                    _treeView_bindingSource.Filter = null;
            }
            catch (Exception)
            {

            }
            finally
            {

            }
        }

        void Flexible_tree_view_setting_load(object sender, EventArgs e)
        {
            _cache = new Resources();

            InitializeNodeSetting();

            InitializeDataGridView();

            splitContainer_Vertical.SplitterDistance = 500;

            if (Settings.Default.ResizeHorizontal != 0)
                splitContainer_Horizontal.SplitterDistance = Settings.Default.ResizeHorizontal;

            if (Settings.Default.ResizeVertical != 0)
                splitContainer_Vertical.SplitterDistance = Settings.Default.ResizeVertical;
        }

        System.Windows.Forms.Timer timerDelay;
        void FlexibleTreeViewSetting_Shown(object sender, EventArgs e)
        {
            timerDelay = new System.Windows.Forms.Timer
            {
                Interval = 3000
            };
            timerDelay.Tick += new EventHandler(timerDelay_Tick);
            timerDelay.Start();
        }

        void timerDelay_Tick(object sender, EventArgs e)
        {
            timerDelay.Stop();

            dataGridViewExtended_Setting.CurrentEmployeesLogIn = _currentEmployeesLogIn;

            if (_selectedNode == null)
                return;

            nodeSetting.FocusedNodeProperties = _selectedNode;

        }

        void FlexibleTreeViewSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentDepartmentLogIn == null)
                return;

            _treeView_bindingSource.Filter = " AvalaibleDepartments LIKE '*" + CurrentDepartmentLogIn.DeptName + "*' OR  AvalaibleDepartments LIKE '*ToAll*'";

            NodeDelayDisable();
            NodeDelay.Dispose();

            mouseKeyEventProvider1.Enabled = false;

            if (NeedSaveData)
            {
                DialogResult savedialog = MessageBox.Show(new Form() { TopMost = true }, @"Calendar Control need save some items.",
                                                                            @"Calendar Control FormClosing",
                                                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (savedialog == DialogResult.Cancel)
                {
                    Text = @"Cancelling Item successful...";
                    e.Cancel = true;
                    mouseKeyEventProvider1.Enabled = true;
                    return;
                }

                if (savedialog == DialogResult.No)
                {
                    mouseKeyEventProvider1.Dispose();
                    return;
                }

                if (savedialog == DialogResult.Yes)
                {
                    mouseKeyEventProvider1.Dispose();
                    //Button_save_click(new object(), new EventArgs());
                }
            }
        }

        void Tool_strip_menu_item_expand_all_click(object sender, EventArgs e)
        {
            splitContainer_Vertical.SplitterDistance = Size.Height / 2;
        }

        void Tool_strip_menu_item_collase_all_click(object sender, EventArgs e)
        {
            splitContainer_Vertical.SplitterDistance = Size.Height;
        }

        void Split_container_horizontal_splitter_moved(object sender, SplitterEventArgs e)
        {
            Settings.Default.ResizeHorizontal = splitContainer_Horizontal.SplitterDistance;
            Settings.Default.Save();
        }

        void Split_container_vertical_splitter_moved(object sender, SplitterEventArgs e)
        {
            Settings.Default.ResizeVertical = splitContainer_Vertical.SplitterDistance;
            Settings.Default.Save();
        }

        void mouseKeyEventProvider1_MouseMove(object sender, MouseEventArgs e)
        {
            statusBar.Items["statusBarPanelMousePosition"].Text = " " + e.Location.ToString();
        }

        #region"NodeSetting"

        NodeSetting nodeSetting;

        void InitializeNodeSetting()
        {
            nodeSetting = new NodeSetting(_treeView_bindingSource, _stockroomColumns, CurrentEmployeesLogIn, DepartList, CurrentDepartmentLogIn);
            nodeSetting.SaveRequested += nodeSetting_Save_Requested;
            nodeSetting.StatusBarMessage += StatusBarMessage;
            nodeSetting.HeightChange += nodeSetting_HeightChange;

            nodeSetting.AutoScroll = true;
            nodeSetting.AutoScrollMinSize = new Size(730, 475);
            nodeSetting.Dock = DockStyle.Fill;
            nodeSetting.FocusedNodeProperties = new NodeProperties();
            nodeSetting.Location = new Point(0, 0);
            nodeSetting.Name = "nodeSetting";
            nodeSetting.NeedSaveData = false;
            nodeSetting.Size = new Size(731, 501);
            nodeSetting.TabIndex = 0;

            splitContainer_Horizontal.Panel2.Controls.Add(nodeSetting);
        }

        void nodeSetting_HeightChange(object sender, Custom_Events_Args.HeightChange_EventArgs e)
        {

        }

        void nodeSetting_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
        }

        #endregion"NodeSetting"

        #region"DataGridView"

        void InitializeDataGridView()
        {
            dataGridViewExtended_Setting.CurrentRowActivesEvent += dataGridViewExtended_Setting_CurrentRowActive;
            dataGridViewExtended_Setting.SaveRequested += dataGridViewExtended_Setting_Save_Requested;

            dataGridViewExtended_Setting.DataSource = _treeView_bindingSource;
        }

        void dataGridViewExtended_Setting_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            NeedSaveData = false;
            _treeView_bindingSource.EndEdit();
            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
        }

        void dataGridViewExtended_Setting_CurrentRowActive(object sender, CurrentRowActive_EventArgs e)
        {
            if (e.CurrentRowActive.IsNewRow)
                return;

            if (e.CurrentRowViewActive == null)
                return;

            Point mouseposition = PointToClient(MousePosition);

            //  if (dataGridViewExtended_Setting.ClientRectangle.Contains(dataGridViewExtended_Setting.PointToClient(MousePosition)))
            //     SelectNode(e.CurrentRowViewActive["Text_Name"].ToString());
        }

        #endregion"DataGridView"

        #region"FTV_setting_preview"

        MouseEventArgs MouseEvent_StockRoom = new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0);

        void FTV_setting_preview_MouseLeave(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

            }
            finally
            {

            }
        }

        readonly System.Windows.Forms.Timer NodeDelay = new System.Windows.Forms.Timer();

        void NodeDelay_Tick(object sender, EventArgs e)
        {
            NodeDelayDisable();

            //   if (FTV_setting_preview.FocusedNode == null)
            //       return;

            //   nodeSetting.FocusedNodeProperties = FTV_setting_preview.FocusedNode.Tag as NodeProperties;

            dataGridViewExtended_Setting.FirstDisplayedRow = "ID/" + nodeSetting.FocusedNodeProperties.ID;
        }

        /// <summary>
        /// Disable the timer when we close the application.
        /// </summary>
        void NodeDelayDisable()
        {
            NodeDelay.Tick -= new EventHandler(NodeDelay_Tick);
            NodeDelay.Stop();
        }

        void tvSampleContent_DragDrop(object sender, DragEventArgs e)
        {
            //   try
            //    {
            // If drag`s content is a DragDropContent type the there`s a drag & drop 
            // between Flexible TreeViews
            //     if (e.Data.GetData(typeof(DragDropContent)) is DragDropContent dragContent)
            //     {
            //nodeSetting2.FocusedNodeProperties = dragContent.Nodes[0].Tag as NodeProperties;
            //          NodeProperties testNode = dragContent.Nodes[0].Tag as NodeProperties;

            //          if (dragContent.Nodes[0].Parent != null)
            //              nodeSetting.UpdateParentID((dragContent.Nodes[0].Parent.Tag as NodeProperties).ID);
            //         else
            //             nodeSetting.UpdateParentID(null);
            //      }
            // Drag & drop from other control to a tree-view. 
            // Handle this operation manually.                
            //      else
            //     {
            if (!e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                MessageBox.Show(@"Drop text content only.");
                return;
            }

            var text = (string)e.Data.GetData(DataFormats.Text);
            //     var node = new Node(text);
            //     node.AttachTo(FTV_setting_preview.DragDropState.RealTargetNode);
            //      }
            //   }
            //   catch (Exception)
            //   {

            //  }
            //  finally
            //   {

            //   }
        }


        #endregion"FTV_setting_preview"

        #region"StatusBarMessage"

        public void StatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            if (e.StatusBarHelp != null)
                StatusBarHelp(e.StatusBarHelp);

            if (e.StatusBarMessage != null)
                StatusBarMessage(e.StatusBarMessage);
        }

        /// <summary>
        /// Write in the status bar, the help from any control.
        /// </summary>
        /// <param name="statusTex"></param>
        public void StatusBarHelp(string statusTex)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(delegate (object o, EventArgs e)
                {
                    //Do your work here.
                    statusBar.Items["statusBarPanelHelp"].Text = statusTex;
                }));
            }
            else
            {
                //Do your work here.
                statusBar.Items["statusBarPanelHelp"].Text = statusTex;
            }
        }

        /// <summary>
        /// Write in the status bar, the message from any control.
        /// </summary>
        /// <param name="statusTex"></param>
        public void StatusBarMessage(string statusTex)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(delegate (object o, EventArgs e)
                {
                    //Do your work here.
                    statusBar.Items["statusBarPanelMessage"].Text = statusTex;
                }));
            }
            else
            {
                //Do your work here.
                statusBar.Items["statusBarPanelMessage"].Text = statusTex;
            }
        }

        /// <summary>
        /// Write in the status bar, the mouse position.
        /// </summary>
        /// <param name="statusTex"></param>
        public void StatusBarMousePosition(string statusTex)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(delegate (object o, EventArgs e)
                {
                    //Do your work here.
                    statusBar.Items["statusBarPanelMousePosition"].Text = statusTex;
                }));
            }
            else
            {
                //Do your work here.
                statusBar.Items["statusBarPanelMousePosition"].Text = statusTex;
            }
        }

        #endregion"StatusBarMessage"    

    }

}
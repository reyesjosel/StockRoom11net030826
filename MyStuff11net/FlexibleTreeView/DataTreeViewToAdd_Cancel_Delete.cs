using BrightIdeasSoftware;
using MyStuff11net.Properties;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using static MyStuff11net.Custom_Events_Args;
using static MyStuff11net.MyCode;


namespace MyStuff11net.FlexibleTreeView
{
    public partial class DataTreeViewToAdd_Cancel_Delete : UserControl
    {
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

        DataTable _dataTableTreeView;
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

        int CounterEvents = 0;
        /// <summary>
        /// Gets or sets a value indicating whether the application is running in debug mode.
        /// This property can be used to enable or disable debug-specific features or logging.
        /// Will send StatusBarMessage_EventArgs events.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DebugMode { get; set; }

        /// <summary>
        /// Represents the name of the database table associated with the current context.
        /// </summary>
        /// <remarks>This field is intended to store the name of a table as a string.  It is recommended
        /// to use a meaningful and valid table name that aligns with the database schema.</remarks>
        string _tableName = "";

        /// <summary>
        /// Indicates whether the binding source for the TreeView has been set.
        /// </summary>
        bool _bindingSourceTreeViewSet = false;

        BindingSource _bindingSourceTreeView = new BindingSource();

        /// <summary>
        /// Gets or sets the <see cref="BindingSource"/> used as the data source for the tree view controls.
        /// </summary>
        /// <remarks>When a new <see cref="BindingSource"/> is assigned, the data source for the following
        /// tree view controls is updated: <list type="bullet">
        /// <item><description><c>olvDataTree</c></description></item>
        /// <item><description><c>olvDataTree_toAdd</c></description></item>
        /// <item><description><c>olvDataTree_toCancel</c></description></item>
        /// <item><description><c>olvDataTree_toDelete</c></description></item> </list> Additionally, the image list for
        /// the tree views is re-initialized.</remarks>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingSource BindingSourceTreeView
        {
            get
            {
                return _bindingSourceTreeView;
            }

            set
            {
                _bindingSourceTreeView = value;

                _bindingSourceTreeViewSet = true;

                InitializedLastID();
                olvDataTree.DataSource = _bindingSourceTreeView;

                InitializeImageList();
                SetupRowsToAdd();

                olvDataTree_ToAdd.DataSource = _bindingSourceTreeView;
                olvDataTree_ToCancel.DataSource = _bindingSourceTreeView;
                olvDataTree_ToDelete.DataSource = _bindingSourceTreeView;

                _tableName = _bindingSourceTreeView.DataMember;

                if (_bindingSourceTreeView.Count == 0)
                    return;

                //olvDataTree.EnsureVisible(0);
            }
        }

        public void EnsureVisibledNode(int index)
        {
            olvDataTree.EnsureVisible(index);
            // olvDataTree.CollapseAll();
        }

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
                    splitContainer_DataTreeView.SplitterDistance = Height - 150;

                    On_SelectedIndexChanged(new TreeViewSelectedIndexChangedEventArgs()
                    {
                        SelectedNodeProperties = _currentFocusedNodeProperties
                    });

                    OlvDataTree_SelectedIndexChanged(new CustomTabControl(), new EventArgs());
                }
                else
                {
                    splitContainer_DataTreeView.Panel2Collapsed = true;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrentDepartmentLogIn { get; set; }

        public DataTreeViewToAdd_Cancel_Delete()
        {
            InitializeComponent();
        }

        public DataTreeViewToAdd_Cancel_Delete(BindingSource bindingSourceDataTreeView)
        {
            InitializeComponent();
            BindingSourceTreeView = bindingSourceDataTreeView;
        }

        void DataTreeViewToAdd_Cancel_Delete_Load(object sender, EventArgs e)
        {
            Initialize_DataTreeListView(olvDataTree);
            Initialize_olvDataTree_toAdd();
            Initialize_olvDataTree_toCancel();
            Initialize_olvDataTree_toDelete();

            SettingMode = false;
            DataTreeListView_Shown();
        }

        void DataTreeView_Save_Requested(object? sender, Save_Requested_EventArgs e)
        {
            Save_Requested_EventArgs save_Requested_EventArgs = new Save_Requested_EventArgs()
            {
                SaveEvent = NotificationEvents.DataBaseUpDated,
                DataTableName = _tableName,
                Message = "DataTreeViewToAdd_Cancel_Delete, Save_Requested()"
            };

            On_Save_Requested(save_Requested_EventArgs);
        }

        void InitializedLastID()
        {
            if (_bindingSourceTreeView.DataSource == null)
                return;

            _dataTableTreeView = (_bindingSourceTreeView.DataSource as DataSet).Tables[_bindingSourceTreeView.DataMember];

            if (_dataTableTreeView.Rows.Count > 0)
                LastID = (int)_dataTableTreeView.Compute("MAX(ID)", "ID is Not null");
            else
                LastID = 0;
        }

        #region"DataTreeListView"

        #region"DataTreeListView"

        HotItemStyle hotItemStyle = new();
        RowBorderDecoration rowBorderDec = new();
        Color foreColor = Color.White;
        Color backColor = Color.White;
        bool keyPressDataTreeList = false;
        ImageList imageListTasks;

        /// <summary>
        /// This domy ImageList is used to change the hight of the HotItem, ensure that expanded descriptions
        /// are displayed correctly.
        /// </summary>
        /// <remarks>This image list is intended for UI customization, particularly to support visual
        /// features such as hot item highlighting and description expanded.</remarks>
        private readonly ImageList imageListHotItem = new();

        void Initialize_DataTreeListView(DataTreeListView thisTreeListView)
        {
            thisTreeListView.KeyAspectName = "ID";
            thisTreeListView.ParentKeyAspectName = "Parent_ID";
            // The DataTreeListView needs to know the key that identifies root level objects.
            // DataTreeListView can handle that key being any data type, but the Designer only deals in strings.
            // Since we want a non-string value to identify keys, we have to set it explicitly here.
            thisTreeListView.RootKeyValue = DBNull.Value;
            thisTreeListView.AllowDrop = true;
            thisTreeListView.FullRowSelect = true;
            thisTreeListView.ShowKeyColumns = false;
            thisTreeListView.AutoGenerateColumns = false;
            thisTreeListView.OwnerDraw = true;

            //olvDataTree.CanExpandGetter = delegate (object x) { return true; };
            //olvDataTree.ChildrenGetter = delegate (object x) { return ((ModelWithChildren)x).Children; };
            //olvDataTree.RowGetter = 

            thisTreeListView.SelectedIndexChanged += OlvDataTree_SelectedIndexChanged;
            thisTreeListView.MouseClick += OlvDataTree_MouseClick;
            thisTreeListView.Resize += OlvDataTree_Resize;
            thisTreeListView.ItemDrag += OlvDataTree_ItemDrag;
            thisTreeListView.KeyDown += DataTreeListView_KeyDown;
            thisTreeListView.Expanding += OlvDataTree_Expanding;
            thisTreeListView.Expanded += ThisTreeListView_Expanded;

            imageListTasks = new ImageList();
            imageListTasks.ColorDepth = ColorDepth.Depth32Bit;
            imageListTasks.ImageSize = new Size(32, 32);
            imageListTasks.TransparentColor = Color.Transparent;

            // 2. Set the desired image size.
            imageListHotItem.ImageSize = new Size(32, 42);
            // You can add images from project resources or files.
            imageListHotItem.Images.Add(Resources.close);
            imageListHotItem.Images.Add(Resources.dial);
            // 4. Assign the ImageList to the ObjectListView.
            //thisTreeListView.SmallImageList = imageListHotItem;

            // How much space do we want to give each row? Obviously, this should be at least
            // the height of the images used by the renderer
            //thisTreeListView.RowHeight = 16;
            thisTreeListView.SmallImageList = imageListTasks;
            thisTreeListView.EmptyListMsg = "No tasks match the filter";
            thisTreeListView.UseAlternatingBackColors = false;
            thisTreeListView.UseHotItem = true;

            toolStripMenuItem_FullRowSelect.Checked = true;

            SetupColumns();
            SetupDragAndDrop();

            SetupDescriptionColumn();
            InitializeContextMenuStripTreeView();
        }

        /// <summary>
        /// Initializes the image list by loading images from the specified directory and adding them to the image list
        /// if they are not already present.
        /// </summary>
        /// <remarks>This method iterates through the items in the binding source and attempts to load
        /// images specified in the "Image" column of each item. Images are loaded from the directory defined by the
        /// application settings and added to the image list if they are not already included. Any errors encountered
        /// while loading images are logged for debugging purposes.</remarks>
        public void InitializeImageList()
        {
            string initialDirectory = Settings.Default.DataBaseAddress;

            foreach (DataRowView item in BindingSourceTreeView)
            {
                if (item.Row.Table.Columns.Contains("Image"))
                {
                    if (item["Image"] != DBNull.Value)
                    {
                        string imageName = item["Image"].ToString();

                        if (string.IsNullOrEmpty(imageName) || imageName.Contains("Undefined"))
                            continue;

                        string filePath = Path.Join(initialDirectory, imageName);

                        // Check if the image is already in the ImageList to avoid duplicates
                        if (!imageListTasks.Images.ContainsKey(imageName))
                        {
                            try
                            {
                                Image image = Image.FromFile(filePath);
                                imageListTasks.Images.Add(imageName, image);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine($"Error loading image {imageName}: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }

        void DataTreeListView_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down || e.KeyData == Keys.Up ||
               e.KeyData == Keys.Left || e.KeyData == Keys.Right)
                keyPressDataTreeList = true;
        }

        void SetupColumns()
        {
            olvDataTree.GetColumn(0).ImageGetter = delegate (object x) { return "user"; };
            //olvDataTree.GetColumn(2).Renderer = new MultiImageRenderer(Resources.star16, 5, 0, 40);
        }

        void SetupDragAndDrop()
        {
            olvDataTree.IsSimpleDropSink = true;
            olvDataTree.IsSimpleDragSource = false;
            olvDataTree.CanDrop += OlvDataTree_CanDrop;
            olvDataTree.Dropped += OlvDataTree_Dropped;
            olvDataTree.ModelDropped += OlvDataTree_ModelDropped;
            ((SimpleDropSink)olvDataTree.DropSink).CanDropBetween = true;
            ((SimpleDropSink)olvDataTree.DropSink).ModelCanDrop += OlvDataTree_ModelCanDrop;

            // Make listView capable of dragging rows out
            SimpleDragSource simpleDragSourceMaster = new SimpleDragSource(true);

            olvDataTree.DragSource = simpleDragSourceMaster;

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

            olvDataTree.DropSink = rearrangingDropSinkToMaster;
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
            olvColumn_Description.AspectName = "Description_Short";

            // Tell the column which property holds the identifier for the image for row.
            // We could also have installed an ImageGetter
            olvColumn_Description.ImageAspectName = "Image";

            // Put a little bit of space around the task and its description
            olvColumn_Description.CellPadding = new Rectangle(4, 2, 4, 2);
        }

        void SendStatusBarMessage(string info)
        {
            if (DebugMode == false)
                return;

            CounterEvents++;
            On_StatusBarMessage(new StatusBarMessage_EventArgs(info + " " + CounterEvents));
        }

        #region"Drag & Drop"

        void OlvDataTree_ModelCanDrop(object? sender, ModelDropEventArgs e)
        {
            int targeId = (int)(e.TargetModel as DataRowView != null ?
                              ((DataRowView)e.TargetModel).Row["ID"] : 0);

            int sourceModel_ID = 0;
            sourceModel_ID = (int)(e.SourceModels[0] as DataRowView != null ?
                      ((DataRowView)e.SourceModels[0]).Row["ID"] : 0);

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

        void OlvDataTree_ModelDropped(object? sender, ModelDropEventArgs e)
        {
            e.Handled = true;
            e.Effect = DragDropEffects.Move;
            RearrangeModels(e);

            DataTreeView_Save_Requested(sender, new Save_Requested_EventArgs());
        }

        void OlvDataTree_CanDrop(object? sender, OlvDropEventArgs e)
        {
            try
            {
                int sourceModel_ID = 0;
                sourceModel_ID = (int)(((OLVDataObject)e.DataObject).ModelObjects[0] as DataRowView != null ?
                                    ((DataRowView)((OLVDataObject)e.DataObject).ModelObjects[0]).Row["ID"] : 0);

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = (int)(e.DropTargetItem.RowObject as DataRowView != null ?
                                    ((DataRowView)e.DropTargetItem.RowObject).Row["ID"] : 0);

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

        void OlvDataTree_ItemDrag(object? sender, ItemDragEventArgs e)
        {
            // as DataRowView
            DataRowView? draggedNode = e.Item as DataRowView;
        }

        /// <summary>
        /// Do the work of processing the dropped items
        /// </summary>
        /// <param name="args"></param>
        void RearrangeModels(ModelDropEventArgs args)
        {
            try
            {
                int targeId = (int)(args.TargetModel as DataRowView != null ?
                              ((DataRowView)args.TargetModel).Row["ID"] : 0);
                int modelId = (int)(args.SourceModels[0] as DataRowView != null ?
                          ((DataRowView)args.SourceModels[0]).Row["ID"] : 0);

                if (targeId == modelId)
                {
                    return;
                }

                switch (args.DropTargetLocation)
                {
                    case DropTargetLocation.AboveItem:
                        AddObjectAboveItem(args);
                        break;
                    case DropTargetLocation.LeftOfItem:
                        olvDataTree.MoveObjects(args.DropTargetIndex, args.SourceModels);
                        break;
                    case DropTargetLocation.BelowItem:
                        AddObjectBelowItem(args);
                        break;
                    case DropTargetLocation.RightOfItem:
                        olvDataTree.MoveObjects(args.DropTargetIndex + 1, args.SourceModels);
                        break;
                    case DropTargetLocation.Background:
                        AddObjectToRood(args);
                        break;
                    case DropTargetLocation.Item:
                        break;
                    case DropTargetLocation.None:
                        AddObjectToRood(args);
                        break;
                    default:
                        return;
                }

                args.RefreshObjects();
            }
            catch (Exception error)
            {
                string message = error.Message;
            }
        }

        void AddObjectAboveItem(ModelDropEventArgs args)
        {
            // If the target is a leaf node, we need to add the objects as children of that node
            foreach (DataRowView model in args.SourceModels)
            {
                var test = model.GetType();
                var cde = (DataRowView)olvDataTree.ChildrenGetter(args.DropTargetItem.RowObject);


                model.BeginEdit();
                model["Parent_ID"] = args.TargetModel as DataRowView != null ? ((DataRowView)args.TargetModel).Row["ID"] : DBNull.Value;
                model.EndEdit();
            }

        }

        void AddObjectBelowItem(ModelDropEventArgs args)
        {
            int position = 0;
            try
            {
                if (args.DropTargetItem != null)
                {
                    // If the target is a leaf node, we need to add the objects as children of that node
                    foreach (DataRowView model in args.SourceModels)
                    {
                        model.BeginEdit();
                        model["Parent_ID"] = args.TargetModel as DataRowView != null ? ((DataRowView)args.TargetModel).Row["ID"] : DBNull.Value;
                        model.EndEdit();

                        position = BindingSourceTreeView.Find("ID", model.Row["ID"]);
                    }

                    BindingSourceTreeView.Position = position;
                }
            }
            catch (Exception error)
            {
                string message = error.Message;
            }
        }

        void AddObjectToRood(ModelDropEventArgs args)
        {
            int position = 0;

            if (args.DropTargetItem == null)
            {
                foreach (DataRowView model in args.SourceModels)
                {
                    model.BeginEdit();
                    model["Parent_ID"] = DBNull.Value;
                    model.EndEdit();

                    position = BindingSourceTreeView.Find("ID", model.Row["ID"]);
                }

                BindingSourceTreeView.Position = position;
            }
        }

        #endregion"Drag & Drop"

        void OlvDataTree_Resize(object? sender, EventArgs e)
        {
            olvColumn_Description.Width = (olvDataTree.Width - olvColumn_TextName.Width) - 25;
        }

        int expandingRootNode_ID = 0;
        DataRowView expandingNode;
        void OlvDataTree_Expanding(object? sender, TreeBranchExpandingEventArgs e)
        {
            if (olvDataTree.ExpandedObjects == null)
                return;

            if (e.Item == null)
                return;

            int? expanding_parentID;
            var type = e.Item.GetType();
            expandingNode = (DataRowView)e.Item.RowObject;

            if (expandingNode.Row.RowState == DataRowState.Detached)
                return;

            var expanding_Object = expandingNode["Parent_ID"];

            if (expanding_Object == DBNull.Value)
                expanding_parentID = null;
            else
                expanding_parentID = (int)expandingNode["Parent_ID"];

            if (expanding_parentID != null)
                return;

            expandingRootNode_ID = (int)expandingNode["ID"];

            foreach (var item in olvDataTree.ExpandedObjects)
            {
                // olvDataTree.Collapse(item);
            }

            int objectsCount = olvDataTree.Roots.Cast<object>().Count();
            if (expandingRootNode_ID > objectsCount)
                expandingRootNode_ID = objectsCount - 1;

            olvDataTree.EnsureVisible(expandingRootNode_ID);
        }

        TreeBranchExpandedEventArgs treeBranchExpandedEventArgs;
        void ThisTreeListView_Expanded(object? sender, TreeBranchExpandedEventArgs e)
        {
            if (e.Item == null)
                return;

            if (treeBranchExpandedEventArgs != null)
            {
                olvDataTree.Collapse(treeBranchExpandedEventArgs.Item);
            }

            treeBranchExpandedEventArgs = e;

            //olvDataTree.EnsureVisible(e.Item.Index);
        }

        void DataTreeListView_Shown()
        {
            // The whole point of a DataTreeListView is to write no code.
            // So there is very little code here.

            // Put some images against each row
            olvColumn_TextName.ImageGetter = delegate (object? row) { return "user"; };

            // This does a better job of auto sizing the columns
            olvDataTree.AutoResizeColumns();
            olvColumn_TextName.Width = 200;
            olvColumn_Description.Width = (olvDataTree.Width - olvColumn_TextName.Width) - 25;

            if (_bindingSourceTreeViewSet)
            {
                int count = BindingSourceTreeView.Count;
                int itemsCount = olvDataTree.GetItemCount();
                if (itemsCount == 0 & count > 0)
                    olvDataTree.EmptyListMsg = "DataSource not set properly";
            }
            else
            {
                olvDataTree.EmptyListMsg = "DataSource not set";
            }
        }

        /// <summary>
        /// Read and return a DataSet from a given XML file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        DataSet LoadDatasetFromXml(string fileName)
        {
            var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(baseDirectoryPath, fileName);

            DataSet ds = new DataSet();
            FileStream fs = null;

            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using (StreamReader reader = new StreamReader(fs))
                {
                    ds.ReadXml(reader);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }

            return ds;
        }

        Type DataBoundObject;
        string DataBoundObject_Name;
        DataRowView? CurrentDataRowViewActive = null;
        NodeProperties _currentFocusedNodeProperties = new();
        NodeProperties? _currentNodeProperties = null;

        /// <summary>
        /// Handles the event triggered when the selected index of the ObjectListView data tree changes.
        /// </summary>
        /// <remarks>This method updates the current data-bound object and its associated properties when
        /// the selection changes. It ensures that the selected item is valid and processes the selection only if
        /// certain conditions are met, such as the mouse position being within the bounds of the control or a key press
        /// triggering the event.</remarks>
        /// <param name="sender">The source of the event, typically the ObjectListView control.</param>
        /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
        public void OlvDataTree_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                SendStatusBarMessage("OlvDataTree_SelectedIndexChanged");

                Type type = sender.GetType();

                // Check if the mouse is outside the bounds of the control and no key press triggered the event
                // If so, exit the method early, unless the sender is a CustomTabControl
                if (!(olvDataTree.Bounds.Contains(PointToClient(MousePosition))) & !keyPressDataTreeList)
                    if (!type.Name.Contains("CustomTabControl"))
                        return;

                keyPressDataTreeList = false;

                if (olvDataTree.SelectedItem != null)
                {
                    DataBoundObject = olvDataTree.SelectedItem.RowObject.GetType();
                    DataBoundObject_Name = DataBoundObject.Name;
                    if (DataBoundObject_Name.Contains("DataRowView"))
                    {
                        CurrentDataRowViewActive = (DataRowView)olvDataTree.SelectedItem.RowObject;
                        _currentNodeProperties = new NodeProperties(CurrentDataRowViewActive);

                        if (_currentNodeProperties != null)
                            if (_currentFocusedNodeProperties.ID == _currentNodeProperties.ID)
                                return;

                        _currentFocusedNodeProperties = _currentNodeProperties;

                        // Change the image list based on the length of Description_Expand
                        // If exist some text in Description_Expand, use imageListHotItem size 32x42;
                        // otherwise, use imageListTasks size 32x32
                        if (_currentFocusedNodeProperties.Description_Expand.Length > 2)
                            olvDataTree.SmallImageList = imageListHotItem;
                        else
                            olvDataTree.SmallImageList = imageListTasks;


                        UpDateCurrentSelectedIndex();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates the currently selected index in the tree view and triggers the  <see
        /// cref="On_SelectedIndexChanged(TreeViewSelectedIndexChangedEventArgs)"/> event.
        /// </summary>
        /// <remarks>This method raises the <see
        /// cref="On_SelectedIndexChanged(TreeViewSelectedIndexChangedEventArgs)"/>  event with the properties of the
        /// currently focused node. It is typically used to notify  listeners of changes to the selected node in the
        /// tree view.</remarks>
        public void UpDateCurrentSelectedIndex()
        {
            On_SelectedIndexChanged(new TreeViewSelectedIndexChangedEventArgs()
            {
                SelectedNodeProperties = _currentFocusedNodeProperties
            });
        }
                
        void OlvDataTree_MouseClick(object? sender, MouseEventArgs e)
        { 
            if (olvDataTree.SelectedItem == null)
            {
                _currentFocusedNodeProperties = new NodeProperties();
                UpDateCurrentSelectedIndex();
            }
        }

        DescribedTaskRenderer CreateDescribedTaskRenderer()
        {
            // Let's create an appropriately configured renderer.
            DescribedTaskRenderer renderer = new DescribedTaskRenderer();

            // Give the renderer its own collection of images.
            // If this isn't set, the renderer will use the SmallImageList from the ObjectListView.
            // (this is standard Renderer behavior, not specific to DescribedTaskRenderer).
            renderer.ImageList = imageListTasks;

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

        void InitializeContextMenuStripTreeView()
        {
            ContextMenuStripTreeView.Opening += ContextMenuStripTreeView_Opening;
            toolStripMenuItem_SingleExpandedNode.Click += ToolStripMenuItem_singleExpandedNode_Click;
            toolStripMenuItem_Refresh.Click += ToolStripMenuItem_Refresh_Click;
        }

        void ContextMenuStripTreeView_Opening(object sender, CancelEventArgs e)
        {
            var switchDataTableMenuItem = ContextMenuStripTreeView.Items["toolStripMenuItem_SwitchDataTable"];
            switchDataTableMenuItem?.Enabled = SettingMode;

            ContextMenuStripTreeView.Items.Clear();
            ContextMenuStripTreeView.Items.Add(toolStripMenuItem_HotItem);
            ContextMenuStripTreeView.Items.Add(new ToolStripSeparator());
            ContextMenuStripTreeView.Items.Add(toolStripMenuItem_Refresh);
            ContextMenuStripTreeView.Items.Add(new ToolStripSeparator());
            ContextMenuStripTreeView.Items.Add(toolStripMenuItem_TimeLine);
            ContextMenuStripTreeView.Items.Add(new ToolStripSeparator());
            ContextMenuStripTreeView.Items.Add(toolStripMenuItem_SwitchDataTable);

            On_ContextMenuStripTreeViewOpening(e);
        }

        void ToolStripMenuItem_HotItem_DropDownItemClicked(object? sender, ToolStripItemClickedEventArgs e)
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

        void ToolStripMenuItem_Refresh_Click(object? sender, EventArgs e)
        {
            if (BindingSourceTreeView == null)
                return;

            string? sortOrder = BindingSourceTreeView.Sort;

            if (sortOrder != null && BindingSourceTreeView.Sort.Contains("DESC"))
                BindingSourceTreeView.Sort = "Parent_ID ASC";
            else
                BindingSourceTreeView.Sort = "Parent_ID DESC";

            olvDataTree.ClearHotItem();
            olvDataTree.Invalidate();
        }

        void ToolStripMenuItem_singleExpandedNode_Click(object? sender, EventArgs e)
        {

        }

        void ToolStripMenuItem_TimeLine_Click(object sender, EventArgs e)
        {
            On_ToolStripMenuItemClick(new ToolStripMenuItemClickEventArgs(toolStripMenuItem_TimeLine));
        }

        void SwitchDataTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            On_Switch_DataTable(new Switch_DataTable_EventArgs()
            {
                DataTableName = _tableName
            });
        }


        #endregion"DataTreeListView"

        #region"olvDataTree_toAdd"

        readonly int rootKeyValueToAdd = 0;
        readonly List<string> _newNodeNames = new List<string>()
        {
            "I'm ready, pick me",
            "Look no further, drag me",
            "Choose me..."
        };

        void SetupRowsToAdd()
        {
            try
            {
                _bindingSourceTreeView.RaiseListChangedEvents = false;
                _bindingSourceTreeView.SuspendBinding();
                _bindingSourceTreeView.AllowNew = true;

                foreach (string nodeName in _newNodeNames)
                {
                    int index = _bindingSourceTreeView.Find("Text_Name", nodeName);
                    if (index >= 0)
                        continue;

                    AddNewRowToAdd(nodeName);
                }

                On_Save_Requested(new Save_Requested_EventArgs()
                {
                    NotificationEvent = NotificationEvents.DataBaseUpDated,
                    Message = "NodeProperties, SaveProperties(): SaveProperties has been called.",
                    DataTableName = _tableName
                });

                _bindingSourceTreeView.RaiseListChangedEvents = true;
                _bindingSourceTreeView.ResumeBinding();

            }
            catch (Exception error)
            {
                string _ = error.Message;
            }
        }

        void AddNewRowToAdd(string Text_Name)
        {
            try
            {
                object? newObject = _bindingSourceTreeView.AddNew();

                if (newObject is not DataRowView newRow)
                    return;

                newRow.BeginEdit();
                newRow["Index"] = newRow["ID"] = LastID;
                newRow["Parent_ID"] = rootKeyValueToAdd;
                newRow["Text_Name"] = Text_Name;
                newRow["Node_PDF"] = "";
                newRow["Node_Picture"] = "";
                newRow["Image"] = "";
                newRow["String_Filter"] = "";
                newRow["ItemCount"] = 0;
                newRow["DateCreated"] = DateTime.Now;
                newRow["Created_by"] = "";
                newRow["AvailableDepartments"] = "AvalaibleDepart LIKE '*" + CurrentDepartmentLogIn + "*'";
                newRow["Properties"] = "";
                newRow["Message_String"] = "";
                newRow["Description_Short"] = "";
                newRow["Description_Expand"] = "";

                newRow.EndEdit();
                _bindingSourceTreeView.EndEdit();
            }
            catch (Exception error)
            {
                string _ = error.Message;
            }
        }

        void Initialize_olvDataTree_toAdd()
        {
            olvDataTree_ToAdd.KeyAspectName = "ID";
            olvDataTree_ToAdd.ParentKeyAspectName = "Parent_ID";
            olvDataTree_ToAdd.RootKeyValue = rootKeyValueToAdd;
            olvDataTree_ToAdd.AllowDrop = true;
            olvDataTree_ToAdd.FullRowSelect = true;
            olvDataTree_ToAdd.ShowKeyColumns = false;
            olvDataTree_ToAdd.AutoGenerateColumns = false;

            SetupDragAndDrop_toAdd();
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
                int sourceModel_ID = 0;
                sourceModel_ID = (int)(((OLVDataObject)e.DataObject).ModelObjects[0] as DataRowView != null ?
                                    ((DataRowView)((OLVDataObject)e.DataObject).ModelObjects[0]).Row["ID"] : 0);

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = (int)(e.DropTargetItem.RowObject as DataRowView != null ?
                                    ((DataRowView)e.DropTargetItem.RowObject).Row["ID"] : 0);

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
            e.Effect = DragDropEffects.Move;
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
            e.Handled = true;
            e.Effect = DragDropEffects.Move;
            RearrangeModelsToAdd(e);

            DataTreeView_Save_Requested(sender, new Save_Requested_EventArgs());
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
                    AddObjectToRoodToAdd(args);
                    break;
                case DropTargetLocation.Item:
                    break;
                case DropTargetLocation.None:
                    AddObjectToRoodToAdd(args);
                    break;

                default:
                    return;
            }

            args.RefreshObjects();
        }

        void AddObjectBelowItemToAdd(ModelDropEventArgs args)
        {
            if (args.DropTargetItem != null)
            {
                // If the target is a leaf node, we need to add the objects as children of that node
                foreach (DataRowView model in args.SourceModels)
                {
                    model.BeginEdit();
                    model["Parent_ID"] = args.TargetModel as DataRowView != null ? ((DataRowView)args.TargetModel).Row["ID"] : DBNull.Value;
                    model.EndEdit();
                }
            }
        }

        void AddObjectToRoodToAdd(ModelDropEventArgs args)
        {
            // olvDataTree.MoveObjects(args.DropTargetIndex, args.SourceModels);

            // If the target is a leaf node, we need to add the objects as children of that node
            if (args.DropTargetItem == null)
            {
                foreach (DataRowView model in args.SourceModels)
                {
                    model.BeginEdit();
                    model["Parent_ID"] = rootKeyValueToAdd;
                    model.EndEdit();
                }
            }
        }

        #endregion"olvDataTree_toAdd"

        #region"olvDataTree_toCancel"

        void Initialize_olvDataTree_toCancel()
        {
            olvDataTree_ToCancel.KeyAspectName = "ID";
            olvDataTree_ToCancel.ParentKeyAspectName = "Parent_ID";
            olvDataTree_ToCancel.RootKeyValue = 25;
            olvDataTree_ToCancel.AllowDrop = true;
            olvDataTree_ToCancel.FullRowSelect = true;
            olvDataTree_ToCancel.ShowKeyColumns = false;
            olvDataTree_ToCancel.AutoGenerateColumns = false;

            SetupDragAndDrop_toCancel();
        }

        void SetupDragAndDrop_toCancel()
        {
            olvDataTree_ToCancel.IsSimpleDropSink = true;
            olvDataTree_ToCancel.IsSimpleDragSource = false;
            olvDataTree_ToCancel.CanDrop += OlvDataTreeToCancel_CanDrop;
            olvDataTree_ToCancel.Dropped += OlvDataTreeToCancel_Dropped;
            olvDataTree_ToCancel.ModelDropped += OlvDataTreeToDelete_ModelDropped;
            ((SimpleDropSink)olvDataTree_ToCancel.DropSink).CanDropBetween = true;
            ((SimpleDropSink)olvDataTree_ToCancel.DropSink).ModelCanDrop += OlvDataTreeToDelete_ModelCanDrop;

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

        void OlvDataTreeToCancel_CanDrop(object? sender, OlvDropEventArgs e)
        {
            try
            {
                int sourceModel_ID = 0;
                sourceModel_ID = (int)(((OLVDataObject)e.DataObject).ModelObjects[0] as DataRowView != null ?
                                    ((DataRowView)((OLVDataObject)e.DataObject).ModelObjects[0]).Row["ID"] : 0);

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = (int)(e.DropTargetItem.RowObject as DataRowView != null ?
                                    ((DataRowView)e.DropTargetItem.RowObject).Row["ID"] : 0);

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

        private readonly int rootKeyValueToDelete = 50;

        void Initialize_olvDataTree_toDelete()
        {
            olvDataTree_ToDelete.KeyAspectName = "ID";
            olvDataTree_ToDelete.ParentKeyAspectName = "Parent_ID";
            olvDataTree_ToDelete.RootKeyValue = rootKeyValueToDelete;
            olvDataTree_ToDelete.AllowDrop = true;
            olvDataTree_ToDelete.FullRowSelect = true;
            olvDataTree_ToDelete.ShowKeyColumns = false;
            olvDataTree_ToDelete.AutoGenerateColumns = false;

            SetupDragAndDrop_toDelete();
            InitializeContextMenuStrip_DeletedThisNode();
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
                int sourceModel_ID = 0;
                sourceModel_ID = (int)(((OLVDataObject)e.DataObject).ModelObjects[0] as DataRowView != null ?
                                    ((DataRowView)((OLVDataObject)e.DataObject).ModelObjects[0]).Row["ID"] : 0);

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = (int)(e.DropTargetItem.RowObject as DataRowView != null ?
                                    ((DataRowView)e.DropTargetItem.RowObject).Row["ID"] : 0);

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
            e.DropSink.Billboard.BackColor = Color.GreenYellow;
            e.DropSink.FeedbackColor = Color.GreenYellow;
            e.InfoMessage = "Hey there";
            e.Handled = true;
            e.Effect = DragDropEffects.Move;
        }

        void OlvDataTreeToDelete_ModelDropped(object? sender, ModelDropEventArgs e)
        {
            e.Handled = true;
            e.Effect = DragDropEffects.Move;
            RearrangeModelsToDelete(e);

            DataTreeView_Save_Requested(sender, new Save_Requested_EventArgs());
        }

        void RearrangeModelsToDelete(ModelDropEventArgs args)
        {
            switch (args.DropTargetLocation)
            {
                case DropTargetLocation.AboveItem:
                    olvDataTree_ToDelete.MoveObjects(args.DropTargetIndex, args.SourceModels);
                    break;
                case DropTargetLocation.LeftOfItem:
                    olvDataTree_ToDelete.MoveObjects(args.DropTargetIndex, args.SourceModels);
                    break;
                case DropTargetLocation.BelowItem:
                    AddObjectBelowItemToDelete(args);
                    break;
                case DropTargetLocation.RightOfItem:
                    olvDataTree_ToDelete.MoveObjects(args.DropTargetIndex + 1, args.SourceModels);
                    break;
                case DropTargetLocation.Background:
                    AddObjectToRoodToDelete(args);
                    break;
                case DropTargetLocation.Item:
                    break;
                case DropTargetLocation.None:
                    AddObjectToRoodToDelete(args);
                    break;

                default:
                    return;
            }

            args.RefreshObjects();
        }

        void AddObjectBelowItemToDelete(ModelDropEventArgs args)
        {
            if (args.DropTargetItem != null)
            {
                // If the target is a leaf node, we need to add the objects as children of that node
                foreach (DataRowView model in args.SourceModels)
                {
                    model.BeginEdit();
                    model["Parent_ID"] = args.TargetModel as DataRowView != null ? ((DataRowView)args.TargetModel).Row["ID"] : rootKeyValueToDelete;
                    model.EndEdit();
                }
            }
        }

        void AddObjectToRoodToDelete(ModelDropEventArgs args)
        {
            // If the target is a leaf node, we need to add the objects as children of that node
            if (args.DropTargetItem == null)
            {
                foreach (DataRowView model in args.SourceModels)
                {
                    model.BeginEdit();
                    model["Parent_ID"] = rootKeyValueToDelete;
                    model.EndEdit();
                }
            }
        }


        #region"ContextMenuStrip_ToDelete"

        void InitializeContextMenuStrip_DeletedThisNode()
        {
            contextMenuStrip_ToDelete.Opening += ContextMenuStrip_ToDelete_Opening;
            toolStripMenuItem_DeletedThisNode.Click += ToolStripMenuItem_DeletedThisNode_Click;
        }

        void ContextMenuStrip_ToDelete_Opening(object? sender, CancelEventArgs e)
        {
            if (olvDataTree_ToDelete.SelectedItem == null)
            {
                e.Cancel = true;
                return;
            }
        }

        void ToolStripMenuItem_DeletedThisNode_Click(object? sender, EventArgs e)
        {
            if (olvDataTree_ToDelete.SelectedItem == null)
                return;

            if (olvDataTree_ToDelete.SelectedItem.RowObject is not DataRowView selectedRow)
                return;

            selectedRow.Delete();
            DataTreeView_Save_Requested(sender, new Save_Requested_EventArgs());
            olvDataTree_ToDelete.ClearHotItem();
        }

        #endregion"ContextMenuStrip_ToDelete"

        #endregion"DataTreeListView"

        #endregion"DataTreeListView"
    }
}

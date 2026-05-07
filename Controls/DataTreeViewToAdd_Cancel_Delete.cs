using BrightIdeasSoftware;
using StockRoom11net.Controls.BindingSourceExt;
using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using StockRoom11net.Properties;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using static StockRoom11net.Controls.Custom_Events_Args;
using static StockRoom11net.Controls.Utilities;

namespace StockRoom11net.Controls
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
        /// A message used to mark a position in the code for debugging purposes.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MessageDebugPosition { get; set; } = string.Empty;

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

        BindingSourceValidating<Table_Base_TreeView> _bindingSourceTreeView;

        /// <summary>
        /// Gets or sets the <see cref="BindingSource"/> used as the data source for the tree view controls.
        /// </summary>
        /// <remarks>When a new <see cref="BindingSource"/> is assigned, the data source for the following
        /// tree view controls is updated: <list type="bullet">
        /// <item><description><c>olvDataTreeMaster</c></description></item>
        /// <item><description><c>olvDataTree_toAdd</c></description></item>
        /// <item><description><c>olvDataTree_toCancel</c></description></item>
        /// <item><description><c>olvDataTree_toDelete</c></description></item> </list> Additionally, the image list for
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

                    _bindingSourceTreeViewSet = true;
                    
                    if (_bindingSourceTreeView.Count == 0)
                        return;

                    // ✅ Diagnose data before assigning to OLV
                    var items = _bindingSourceTreeView.List.Cast<Table_Base_TreeView>().ToList();
                    var roots = items.Where(n => n.Parent_ID == 0).ToList();
                    var dupIDs = items.GroupBy(n => n.ID).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                    var orphans = items.Where(n => n.Parent_ID != 0 && !items.Any(p => p.ID == n.Parent_ID)).ToList();

                    Debug.WriteLine($"Total: {items.Count} | Roots (Parent_ID==0): {roots.Count} | DupIDs: {string.Join(",", dupIDs)} | Orphans: {orphans.Count}");

                    if (roots.Count == 0 || dupIDs.Any())
                    {
                        MessageBox.Show($"Tree data invalid!\nRoots: {roots.Count}\nDuplicate IDs: {string.Join(",", dupIDs)}\nOrphans: {orphans.Count}",
                            "DataSource Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // ← prevents the freeze
                    }

                    if (InvokeRequired)
                    {
                        Invoke(() => olvDataTreeMaster.DataSource = _bindingSourceTreeView);
                    }
                    else
                    {
                        olvDataTreeMaster.DataSource = _bindingSourceTreeView;
                    }

                    // olvDataTree_ToAdd.DataSource = _bindingSourceTreeView;
                    //olvDataTree_ToCancel.DataSource = _bindingSourceTreeView;
                    // olvDataTree_ToDelete.DataSource = _bindingSourceTreeView;

                    InitializedLastID();
                    InitializeImageList();
                    _ = SetupRowsToAddAsync();

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

        public void SetDataSource<T>(BindingList<T> dataList) where T : class
        {
            _bindingSourceTreeView = new BindingSourceValidating<Table_Base_TreeView> { DataSource = dataList };

            _bindingSourceTreeViewSet = true;

            olvDataTreeMaster.DataSource = _bindingSourceTreeView;
            olvDataTree_ToAdd.DataSource = _bindingSourceTreeView;
            olvDataTree_ToCancel.DataSource = _bindingSourceTreeView;
            olvDataTree_ToDelete.DataSource = _bindingSourceTreeView;

            InitializedLastID();
          //  InitializeImageList();
            SetupRowsToAddAsync();
        }

        public void EnsureVisibledNode(int index)
        {
            olvDataTreeMaster.EnsureVisible(index);
            olvDataTreeMaster.CollapseAll();
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
                    splitContainer_DataTreeView.SplitterDistance = Settings.Default.SplitterDistance_DataTreeViewToAdd_Cancel_Delete;

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

        public void ClosePanelSetting(bool state)
        {
            SettingMode = state;
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrentDepartmentLogIn { get; set; }

        private IUnitOfWork _unitOfWork;

        public DataTreeViewToAdd_Cancel_Delete(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            InitializeComponent();
        }

        public DataTreeViewToAdd_Cancel_Delete()
        {
            InitializeComponent();
        }

        public DataTreeViewToAdd_Cancel_Delete(BindingSource bindingSourceDataTreeView)
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

            Initialize_DataTreeListView(olvDataTreeMaster);
            Initialize_olvDataTree_toAdd();
            Initialize_olvDataTree_toCancel();
            Initialize_olvDataTree_toDelete();

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

        #region TODO: REMOVE - legacy code logic BindingList item using reflection
        /// <summary>
        /// Helper method to get property value from a BindingList item using reflection
        /// </summary>
        private object? GetPropertyValue(object item, string propertyName)
        {
            if (item == null) return null;

            var property = item.GetType().GetProperty(propertyName);
            return property?.GetValue(item);
        }

        /// <summary>
        /// Helper method to set property value on a BindingList item using reflection
        /// </summary>
        private void SetPropertyValue(object item, string propertyName, object value)
        {
            if (item == null) return;

            var property = item.GetType().GetProperty(propertyName);
            if (property != null && property.CanWrite)
            {
                property.SetValue(item, value);
            }
        }
        #endregion

        void InitializedLastID()
        {
            if (_bindingSourceTreeView?.DataSource == null)
            {
                LastID = 0;
                return;
            }

            try
            {
                // Work with BindingList instead of DataSet
                var maxId = 0;

                if (_bindingSourceTreeView.Current is Table_TimeLine_TreeView currentItem)
                {
                    // use 'currentItem' directly, already cast
                    Console.WriteLine(currentItem.ID);

                    foreach (Table_TimeLine_TreeView item in _bindingSourceTreeView)
                    {
                        var idValue = item.ID;
                        if (idValue is int id)
                        {
                            maxId = Math.Max(maxId, id);
                        }
                    }
                }
                else
                {
                    #region TODO: REMOVE - legacy code logic
                    // fallback if Current is not of expected type, still iterate through items
                    // but use reflection to get ID property value, since we don't know the type at compile time
                    // This is less efficient but provides a fallback mechanism, will be removed once we are sure
                    // of the data type in the BindingSource
                    foreach (var item in _bindingSourceTreeView)
                    {
                        if (item != null)
                        {
                            var idValue = GetPropertyValue(item, "ID");
                            if (idValue is int id)
                            {
                                maxId = Math.Max(maxId, id);
                            }
                        }
                    }
                    #endregion
                }

                LastID = maxId;
            }
            catch
            {
                LastID = 0;
            }
        }

        #region"DataTreeListView"

        #region"DataTreeListViewMaster"

        HotItemStyle hotItemStyle = new();
        RowBorderDecoration rowBorderDec = new();
        Color foreColor = Color.White;
        Color backColor = Color.White;
        bool keyPressDataTreeList = false;

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
        /// features such as hot item highlighting and description expanded.</remarks>
        private readonly ImageList imageListHotItem = new();

        void Initialize_DataTreeListView(DataTreeListView thisTreeListView)
        {
            thisTreeListView.Name = "DataTreeListViewMaster";
            thisTreeListView.AccessibleName = "DataTreeListViewMaster";
            thisTreeListView.KeyAspectName = "ID";
            thisTreeListView.ParentKeyAspectName = "Parent_ID";
            // The DataTreeListView needs to know the key that identifies root level objects.
            // DataTreeListView can handle that key being any data type, but the Designer only deals in strings.
            // Since we want a non-string value to identify keys, we have to set it explicitly here.

            // If Parent_ID is int? (nullable int), set RootKeyValue explicitly as int
            //thisTreeListView.RootKeyValue = (int?)0;  // match the nullable type
            thisTreeListView.RootKeyValue = rootKeyValueToMaster;
            thisTreeListView.AllowDrop = true;
            thisTreeListView.FullRowSelect = true;
            thisTreeListView.ShowKeyColumns = false;
            thisTreeListView.AutoGenerateColumns = false;

            thisTreeListView.OwnerDraw = true;

            thisTreeListView.SelectedIndexChanged += OlvDataTree_SelectedIndexChanged;
            thisTreeListView.MouseClick += OlvDataTree_MouseClick;
            thisTreeListView.Resize += OlvDataTree_Resize;
            thisTreeListView.ItemDrag += OlvDataTree_ItemDrag;
            thisTreeListView.KeyDown += DataTreeListView_KeyDown;
            thisTreeListView.Expanding += OlvDataTree_Expanding;
            thisTreeListView.Expanded += ThisTreeListView_Expanded;

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
            thisTreeListView.SmallImageList = imageListTasks;

            // How much space do we want to give each row? Obviously, this should be at least
            // the height of the images used by the renderer
            //thisTreeListView.RowHeight = 16;
            thisTreeListView.EmptyListMsg = "No tasks match the filter";
            thisTreeListView.UseAlternatingBackColors = false;
            thisTreeListView.UseHotItem = true;

            toolStripMenuItem_FullRowSelect.Checked = true;

            SetupColumns();
            SetupDragAndDrop();
            SetupDescriptionColumn();
            InitializeContextMenuStripTreeView();

            // ✅ Load images AFTER SmallImageList is assigned
            InitializeImageList();
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
            if (_unitOfWork is null) return;

            // Fetch only the Image column — no full entity load overhead
            IEnumerable<Table_Base_TreeView> nodes = await _unitOfWork.TableTimeLineTreeViews.GetAllAsync(cancellationToken);

            foreach (var node in nodes)
            {
                string? imageName = node.Image;

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

        void DataTreeListView_KeyDown(object? sender, KeyEventArgs e)
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
            olvColumn_Description.AspectName = "Description_Expand";

            // Tell the column which property holds the identifier for the image for row.
            // We could also have installed an ImageGetter
            olvColumn_Description.ImageAspectName = "Image";

            // Put a little bit of space around the task and its description
            olvColumn_Description.CellPadding = new Rectangle(4, 2, 4, 2);
            olvColumn_Description.Name = "olvColumn_Description";

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
            int targeId = e.TargetModel as Table_TimeLine_TreeView != null ?
                              ((Table_TimeLine_TreeView)e.TargetModel).ID : 0;

            int sourceModel_ID = e.SourceModels[0] as Table_TimeLine_TreeView != null ?
                      ((Table_TimeLine_TreeView)e.SourceModels[0]).ID : 0;

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

            // ✅ Entities were loaded with AsNoTracking — must explicitly tell EF
            // they have been modified before calling SaveChangesAsync()
            //    foreach (Table_TimeLine_TreeView model in e.SourceModels.OfType<Table_TimeLine_TreeView>())
            //    {
            //       _unitOfWork.TableTimeLineTreeViews.Update(model);
            //   }

            //   await _unitOfWork.SaveChangesAsync();
        }

        void OlvDataTree_CanDrop(object? sender, OlvDropEventArgs e)
        {
            try
            {
                int sourceModel_ID = ((OLVDataObject)e.DataObject).ModelObjects[0] as Table_TimeLine_TreeView != null ?
                                     ((Table_TimeLine_TreeView)((OLVDataObject)e.DataObject).ModelObjects[0]).ID : 0;

                int targeId = 0;

                if (e.DropTargetItem != null)
                    targeId = e.DropTargetItem.RowObject as Table_TimeLine_TreeView != null ?
                                    ((Table_TimeLine_TreeView)e.DropTargetItem.RowObject).ID : 0;

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
            Table_TimeLine_TreeView _itemDragged = e.Item as Table_TimeLine_TreeView;
        }

        /// <summary>
        /// Do the work of processing the dropped items
        /// </summary>
        /// <param name="args"></param>
        async Task RearrangeModels(ModelDropEventArgs args)
        {
            try
            {
                int targeId = ((Table_TimeLine_TreeView)args.TargetModel)?.ID ?? 0;

                int modelId = ((Table_TimeLine_TreeView)args.SourceModels[0])?.ID ?? 0;

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
                if (args.DropTargetItem == null) return;

                MessageDebugPosition = "AddObjectAboveItem() - before foreach loop";
                foreach (Table_TimeLine_TreeView model in args.SourceModels.OfType<Table_TimeLine_TreeView>())
                {
                    var newItem = new Table_TimeLine_TreeView
                    {
                        Index = LastID,
                        ID = LastID,
                        Parent_ID = ((Table_TimeLine_TreeView)args.TargetModel).ID,
                        Text_Name = model.Text_Name,
                        Description_Short = model.Description_Short,
                        Description_Expand = model.Description_Expand,
                        Image = model.Image
                    };

                    MessageDebugPosition = "AddObjectAboveItem() - before AddAsync()";
                    // ✅ Properly awaited — DB insert now actually executes
                    await _unitOfWork.TableTimeLineTreeViews.AddAsync(newItem, CancellationToken.None);

                    MessageDebugPosition = "AddObjectAboveItem() - after AddAsync(), before UI update";
                    // Update UI after confirmed save
                    BindingSourceTreeView.Add(newItem);

                    MessageDebugPosition = "AddObjectAboveItem() - after UI update, before finding position";
                    int position = FindPositionById(newItem.ID);
                    if (position >= 0)
                        BindingSourceTreeView.Position = position;
                }

                // args.RefreshObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving new item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async Task AddObjectBelowItemToAddAsync(ModelDropEventArgs args)
        {
            try
            {
                if (args.DropTargetItem == null) return;

                MessageDebugPosition = "AddObjectBelowItemToAddAsync() - before foreach loop";
                foreach (Table_TimeLine_TreeView model in args.SourceModels.OfType<Table_TimeLine_TreeView>())
                {
                    var newItem = new Table_TimeLine_TreeView
                    {
                        Index = LastID,
                        ID = LastID,
                        Parent_ID = ((Table_TimeLine_TreeView)args.TargetModel).ID,
                        Text_Name = model.Text_Name,
                        Description_Short = model.Description_Short,
                        Description_Expand = model.Description_Expand,
                        Image = model.Image
                    };

                    MessageDebugPosition = "AddObjectBelowItemToAddAsync() - before AddAsync()";
                    // ✅ Properly awaited — DB insert now actually executes
                    await _unitOfWork.TableTimeLineTreeViews.AddAsync(newItem, CancellationToken.None);

                    MessageDebugPosition = "AddObjectBelowItemToAddAsync() - after AddAsync(), before UI update";
                    // Update UI after confirmed save
                    BindingSourceTreeView.Add(newItem);

                    MessageDebugPosition = "AddObjectBelowItemToAddAsync() - after UI update, before finding position";
                    int position = FindPositionById(newItem.ID);
                    if (position >= 0)
                        BindingSourceTreeView.Position = position;
                }

                // args.RefreshObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving new item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async Task AddObjectToRootToAddAsync(ModelDropEventArgs args)
        {
            try
            {
                if (args.DropTargetItem != null) return;
                MessageDebugPosition = "AddObjectToRootToAddAsync() - before foreach loop";
                foreach (Table_TimeLine_TreeView model in args.SourceModels.OfType<Table_TimeLine_TreeView>())
                {
                    var newItem = new Table_TimeLine_TreeView
                    {
                        Index = LastID,
                        ID = LastID,
                        Parent_ID = rootKeyValueToMaster,
                        Text_Name = model.Text_Name,
                        Description_Short = model.Description_Short,
                        Description_Expand = model.Description_Expand,
                        Image = model.Image
                    };

                    MessageDebugPosition = "AddObjectToRootToAddAsync() - before AddAsync()";
                    // ✅ Properly awaited — DB insert now actually executes
                    await _unitOfWork.TableTimeLineTreeViews.AddAsync(newItem, CancellationToken.None);

                    MessageDebugPosition = "AddObjectToRootToAddAsync() - after AddAsync(), before UI update";
                    // Update UI after confirmed save
                    BindingSourceTreeView.Add(newItem);

                    MessageDebugPosition = "AddObjectToRootToAddAsync() - after UI update, before finding position";
                    int position = FindPositionById(newItem.ID);
                    if (position >= 0)
                        BindingSourceTreeView.Position = position;
                }

                // args.RefreshObjects();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving new item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Finds the BindingSource position of the item with the given ID.
        /// BindingList&lt;T&gt; does not support BindingSource.Find() — this is the correct alternative.
        /// Returns -1 if not found.
        /// </summary>
        private int FindPositionById(int id)
        {
            for (int i = 0; i < BindingSourceTreeView.Count; i++)
            {
                var item = BindingSourceTreeView[i];
                if (item is Table_TimeLine_TreeView node && node.ID == id)
                    return i;
            }
            return -1;
        }

        #endregion"Drag & Drop"

        void OlvDataTree_Resize(object? sender, EventArgs e)
        {
            olvColumn_Description.Width = (olvDataTreeMaster.Width - olvColumn_TextName.Width) - 25;
        }

        int expandingRootNode_ID = 0;
        Table_TimeLine_TreeView expandingNode;
        void OlvDataTree_Expanding(object? sender, TreeBranchExpandingEventArgs e)
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

            //   foreach (var item in olvDataTreeMaster.ExpandedObjects)
            //   {
            // olvDataTreeMaster.Collapse(item);
            //   }

            //    int objectsCount = olvDataTreeMaster.Roots.Cast<object>().Count();
            //    if (expandingRootNode_ID > objectsCount)
            //        expandingRootNode_ID = objectsCount - 1;

            // olvDataTreeMaster.EnsureVisible(expandingRootNode_ID);
        }

        TreeBranchExpandedEventArgs treeBranchExpandedEventArgs;
        void ThisTreeListView_Expanded(object? sender, TreeBranchExpandedEventArgs e)
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

        void DataTreeListView_Shown()
        {
            // The whole point of a DataTreeListView is to write no code.
            // So there is very little code here.

            // Put some images against each row
            olvColumn_TextName.ImageGetter = delegate (object? row) { return "user"; };

            // This does a better job of auto sizing the columns
            olvDataTreeMaster.AutoResizeColumns();
            olvColumn_TextName.Width = 200;
            olvColumn_Description.Width = (olvDataTreeMaster.Width - olvColumn_TextName.Width) - 25;

            if (_bindingSourceTreeViewSet)
            {
                int count = BindingSourceTreeView.Count;
                int itemsCount = olvDataTreeMaster.GetItemCount();
                if (itemsCount != count)
                    olvDataTreeMaster.EnsureVisible(0);
            }
            else
            {
                olvDataTreeMaster.EmptyListMsg = "DataSource not set";
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
                if (!(olvDataTreeMaster.Bounds.Contains(PointToClient(MousePosition))) & !keyPressDataTreeList)
                    if (!type.Name.Contains("CustomTabControl"))
                        return;

                keyPressDataTreeList = false;

                if (olvDataTreeMaster.SelectedItem == null)
                    return;

                DataBoundObject = olvDataTreeMaster.SelectedItem.RowObject.GetType();
                DataBoundObject_Name = DataBoundObject.Name;

                if (DataBoundObject_Name.Contains("DataRowView"))
                {
                    CurrentDataRowViewActive = (DataRowView)olvDataTreeMaster.SelectedItem.RowObject;
                    _currentNodeProperties = new NodeProperties(CurrentDataRowViewActive);

                    if (_currentNodeProperties != null)
                        if (_currentFocusedNodeProperties.ID == _currentNodeProperties.ID)
                            return;

                    _currentFocusedNodeProperties = _currentNodeProperties;

                    // Change the image list based on the length of Description_Expand
                    // If exist some text in Description_Expand, use imageListHotItem size 32x42;
                    // otherwise, use imageListTasks size 32x32
                    if (_currentFocusedNodeProperties.Description_Expand.Length > 2)
                        olvDataTreeMaster.SmallImageList = imageListHotItem;
                    else
                        olvDataTreeMaster.SmallImageList = imageListTasks;


                    UpDateCurrentSelectedIndex();
                }

                if (DataBoundObject_Name.Contains("TreeView"))
                {
                    var _CurrentDataRowViewActive = olvDataTreeMaster.SelectedItem.RowObject as Table_Base_TreeView;
                    _currentNodeProperties = new NodeProperties(_CurrentDataRowViewActive);

                    if (_currentNodeProperties != null)
                        if (_currentFocusedNodeProperties.ID == _currentNodeProperties.ID)
                            return;

                    _currentFocusedNodeProperties = _currentNodeProperties;

                    // Change the image list based on the length of Description_Expand
                    // If exist some text in Description_Expand, use imageListHotItem size 32x42;
                    // otherwise, use imageListTasks size 32x32
                    if (_currentFocusedNodeProperties.Description_Expand.Length > 2)
                        olvDataTreeMaster.SmallImageList = imageListHotItem;
                    else
                        olvDataTreeMaster.SmallImageList = imageListTasks;


                    UpDateCurrentSelectedIndex();
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
            if (olvDataTreeMaster.SelectedItem == null)
            {
                _currentFocusedNodeProperties = new NodeProperties();
                UpDateCurrentSelectedIndex();
            }
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
                SettingMode = !_settingMode;
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
            if (_unitOfWork is null) return; // Sanity check, though this should never happen since the constructor
                                             // requires a non-null IUnitOfWork, but the other constructors do not,
                                             // until we refactor those to also require an IUnitOfWork,
                                             // we need this check to avoid null reference exceptions.

            try
            {
                MessageDebugPosition = "SetupRowsToAddAsync() - Start";
                _bindingSourceTreeView.RaiseListChangedEvents = false;
                _bindingSourceTreeView.SuspendBinding();
                _bindingSourceTreeView.AllowNew = true;

                MessageDebugPosition = "SetupRowsToAddAsync() - Adding new nodes";
                foreach (string nodeName in _newNodeNames)
                {
                    MessageDebugPosition = $"SetupRowsToAddAsync() - Checking if node exists: {nodeName}";
                    Table_TimeLine_TreeView? node = await _unitOfWork.TableTimeLineTreeViews.FirstOrDefaultAsync(n => n.Text_Name == nodeName);

                    MessageDebugPosition = $"Node check complete for: {nodeName}, node found: {(node != null)}";
                    if (node != null)
                        continue;

                    MessageDebugPosition = $"SetupRowsToAddAsync() - Adding node: {nodeName}";
                    await AddNewTreeNodeAsync(nodeName, CancellationToken.None);
                }

                MessageDebugPosition = "SetupRowsToAddAsync() - Finished adding nodes, resuming binding";
                _bindingSourceTreeView.RaiseListChangedEvents = true;
                _bindingSourceTreeView.ResumeBinding();
            }
            catch (Exception error)
            {
                MessageDebugPosition = $"SetupRowsToAddAsync() - Error: {error.Message}";
            }
        }

        /// <summary>
        /// Adds a new tree node using Entity Framework via the repository/unit-of-work pattern.
        /// Call this instead of the BindingSource AddNew() block.
        /// </summary>
        private async Task AddNewTreeNodeAsync(string nodeName, CancellationToken cancellationToken = default)
        {
            var newEntity = new Table_TimeLine_TreeView
            {
                Index = LastID,
                ID = LastID,
                Parent_ID = rootKeyValueToAdd,
                Text_Name = nodeName,
                Node_PDF = "",
                Node_Picture = "",
                Image = "",
                String_Filter = "",
                ItemCount = 0,
                DateCreated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Created_by = "",
                AvailableDepartments = $"AvalaibleDepart LIKE '*{CurrentDepartmentLogIn}*'",
                Properties = "",
                Message_String = "",
                Description_Short = "",
                Description_Expand = "",
            };

            await _unitOfWork.TableTimeLineTreeViews.AddAsync(newEntity, cancellationToken);

            // After adding the new entity to the database, you can refresh the BindingSource
            // to reflect the changes in the UI, dont save changes to database here, just add
            // the new entity, and let the user decide when to save changes by clicking the save
            // button, which will call _unitOfWork.SaveChangesAsync() method.
            //   await _unitOfWork.SaveChangesAsync();
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
                sourceModel_ID = ((OLVDataObject)e.DataObject).ModelObjects[0] as Table_TimeLine_TreeView != null ?
                                    ((Table_TimeLine_TreeView)((OLVDataObject)e.DataObject).ModelObjects[0]).ID : 0;

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = e.DropTargetItem.RowObject as Table_TimeLine_TreeView != null ?
                                    ((Table_TimeLine_TreeView)e.DropTargetItem.RowObject).ID : 0;

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
                foreach (Table_TimeLine_TreeView model in args.SourceModels)
                {
                    var newItem = new Table_TimeLine_TreeView
                    {
                        ID = LastID,
                        Parent_ID = ((Table_TimeLine_TreeView)args.TargetModel).ID,
                        Text_Name = model.Text_Name,
                        Description_Short = model.Description_Short,
                        Description_Expand = model.Description_Expand,
                        Image = model.Image
                    };

                    _unitOfWork.TableTimeLineTreeViews.AddAsync(newItem, CancellationToken.None);
                    // Add to binding list (automatic UI update)
                    BindingSourceTreeView.Add(newItem);

                    // ✅ BindingList<T> does not support Find() — use manual index search
                    int position = FindPositionById(newItem.ID);
                    BindingSourceTreeView.Position = position;
                }
            }
        }

        void AddObjectToRootToAdd(ModelDropEventArgs args)
        {
            if (args.DropTargetItem == null)
            {
                foreach (Table_TimeLine_TreeView model in args.SourceModels)
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


                int sourceModel_ID = ((OLVDataObject)e.DataObject).ModelObjects[0] as Table_TimeLine_TreeView != null ?
                                      ((Table_TimeLine_TreeView)((OLVDataObject)e.DataObject).ModelObjects[0]).ID : 0;

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = e.DropTargetItem.RowObject as Table_TimeLine_TreeView != null ?
                                    ((Table_TimeLine_TreeView)e.DropTargetItem.RowObject).ID : 0;

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
                sourceModel_ID = (((OLVDataObject)e.DataObject).ModelObjects[0] as Table_TimeLine_TreeView != null ?
                                    ((Table_TimeLine_TreeView)((OLVDataObject)e.DataObject).ModelObjects[0]).ID : 0);

                int targeId = 0;
                if (e.DropTargetItem != null)
                    targeId = (e.DropTargetItem.RowObject as Table_TimeLine_TreeView != null ?
                                    ((Table_TimeLine_TreeView)e.DropTargetItem.RowObject).ID : 0);

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
                    olvDataTree_ToDelete.MoveObjects(args.DropTargetIndex, args.SourceModels);
                    break;
                case DropTargetLocation.LeftOfItem:
                    olvDataTree_ToDelete.MoveObjects(args.DropTargetIndex, args.SourceModels);
                    break;
                case DropTargetLocation.BelowItem:
                    {
                        await AddObjectBelowItemToDelete(args);
                        break;
                    }
                case DropTargetLocation.RightOfItem:
                    olvDataTree_ToDelete.MoveObjects(args.DropTargetIndex + 1, args.SourceModels);
                    break;
                case DropTargetLocation.Background:
                    {
                        await AddObjectToRootToDelete(args);
                        break;
                    }
                case DropTargetLocation.Item:
                    break;
                case DropTargetLocation.None:
                    AddObjectToRootToDelete(args);
                    break;

                default:
                    return;
            }

            // ✅ Entities were loaded with AsNoTracking — must explicitly tell EF
            // they have been modified before calling SaveChangesAsync()
            foreach (Table_TimeLine_TreeView model in args.SourceModels.OfType<Table_TimeLine_TreeView>())
            {
                _unitOfWork.TableTimeLineTreeViews.Update(model);
            }

            await _unitOfWork.SaveChangesAsync();

            _bindingSourceTreeView.ResetBindings(false);

            //olvDataTree_ToDelete.RebuildAll(true);// ✅ Rebuild tree structure — Refresh() is not enough
            //olvDataTreeMaster.RebuildAll(true);   // master tree also reflects the deletion

            olvDataTreeMaster.ClearHotItem();
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

            if (args.DropTargetItem != null)
            {
                // If the target is a leaf node, we need to add the objects as children of that node
                foreach (Table_TimeLine_TreeView model in args.SourceModels)
                {
                    model.Parent_ID = args.TargetModel as Table_TimeLine_TreeView != null ? ((Table_TimeLine_TreeView)args.TargetModel).ID : rootKeyValueToDelete;
                }
            }
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
                foreach (Table_TimeLine_TreeView model in args.SourceModels)
                {
                    model.Parent_ID = rootKeyValueToDelete;
                }
            }
        }

        #region"ContextMenuStrip_ToDelete"

        void InitializeContextMenuStrip_DeletedThisNode()
        {
            contextMenuStrip_ToDelete.Opening += ContextMenuStrip_To_Delete_Opening;
            toolStripMenuItem_DeletedThisNode.Click += ToolStripMenuItem_DeletedThisNode_Click;
        }

        void ContextMenuStrip_To_Delete_Opening(object? sender, CancelEventArgs e)
        {
            if (olvDataTree_ToDelete.SelectedItem == null)
            {
                e.Cancel = true;
                return;
            }
        }

        async void ToolStripMenuItem_DeletedThisNode_Click(object? sender, EventArgs e)
        {
            try
            {
                if (olvDataTree_ToDelete.SelectedItem == null)
                    return;

                if (olvDataTree_ToDelete.SelectedItem.RowObject is not Table_TimeLine_TreeView selectedNode)
                    return;

                MessageDebugPosition = $"Attempting to get childrens of '{selectedNode.Text_Name}'";
                IEnumerable<Table_TimeLine_TreeView> children = await _unitOfWork.TableTimeLineTreeViews.GetChildrenAsync(selectedNode.ID);

                if (children.Any())
                {
                    DialogResult dialogResult =
                    MessageBox.Show("Do you want to delete all the children as well?", "Cannot Delete Node with Childrens",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No || dialogResult == DialogResult.Cancel)
                        return;

                    MessageDebugPosition = $"Deleting {children.Count()} children of '{selectedNode.Text_Name}'";
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (Table_TimeLine_TreeView item in children)
                        {
                            //_unitOfWork.TableTimeLineTreeViews.Remove(item); Fails with "The entity cannot be deleted because
                            //it has related entities. Either delete the related entities or sever the relationship between them."
                            //because the child entities are not tracked by the context, since they were loaded with AsNoTracking()
                            //for performance reasons. Therefore, we must use DeleteAsync() which fetches the tracked entity by its
                            //primary key (Index) and then removes it, instead of trying to remove a detached entity.

                            // ✅ Use DeleteAsync — it fetches the tracked entity by PK (Index)
                            // then removes it. Avoids attaching detached entities with Index = 0.
                            await _unitOfWork.TableTimeLineTreeViews.DeleteAsync(item.Index);
                            // ✅ Find by ID — Remove() uses reference equality which fails
                            // for AsNoTracking entities (different object instances)
                            RemoveFromBindingSourceById(item.ID);
                        }
                    }
                }

                MessageDebugPosition = $"Deleting Parent node '{selectedNode.Text_Name}'";
                await _unitOfWork.TableTimeLineTreeViews.DeleteAsync(selectedNode.Index);
                // ✅ Find by ID — Remove() uses reference equality which fails
                // for AsNoTracking entities (different object instances)
                RemoveFromBindingSourceById(selectedNode.ID);
                await _unitOfWork.SaveChangesAsync();

                MessageDebugPosition = $"Rebuilding tree after deletion of '{selectedNode.Text_Name}'";
                olvDataTree_ToDelete.RebuildAll(true);// ✅ Rebuild tree structure — Refresh() is not enough
                olvDataTreeMaster.RebuildAll(true);   // master tree also reflects the deletion

                olvDataTree_ToDelete.ClearHotItem();
            }
            catch (Exception error)
            {
                MessageDebugPosition = $"Error deleting node: {error.Message}";
            }
        }

        /// <summary>
        /// Removes an item from the BindingSource by matching its ID property.
        /// 
        /// BindingSource.Remove()    → fails: uses reference equality, AsNoTracking = different instances
        /// BindingSource.RemoveAt(i) → fails: sorted-view index ≠ underlying-list index
        /// BindingSource.DataSource as BindingList → fails: DataSource may be BindingSourceValidating<T>
        ///
        /// ✅ BindingSource.List always returns the actual managed IList regardless of nesting or sorting.
        ///    Index operations on it are always valid.
        /// </summary>
        private void RemoveFromBindingSourceById(int id)
        {
            try
            {
                // ✅ .List resolves any nested BindingSource and returns the real underlying IList.
                // Iterating and removing from it directly is safe regardless of sort/filter state.
                IList list = BindingSourceTreeView.List;
                MessageDebugPosition = $"Removing item with ID {id} from BindingSource list with {list.Count} items";
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i] is Table_TimeLine_TreeView node && node.ID == id)
                    {
                        MessageDebugPosition = $"Found item with ID {id} at index {i}, removing it from BindingSource";
                        list.RemoveAt(i);
                        return;
                    }
                }

                // Item not found — already removed or ID mismatch
                MessageDebugPosition = $"RemoveFromBindingSourceById: ID {id} not found in list.";
            }
            catch (Exception error)
            {
                MessageDebugPosition = $"Error removing item from BindingSource: {error.Message}";
            }
        }

        #endregion"ContextMenuStrip_ToDelete"

        #endregion"DataTreeListView"

        #endregion"DataTreeListView"

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

namespace MyStuff11net.FlexibleTreeView
{
    partial class DataTreeViewToAdd_Cancel_Delete
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel_DataTreeViewSetting = new TableLayoutPanel();
            panel_toDelete = new Panel();
            olvDataTree_ToDelete = new BrightIdeasSoftware.DataTreeListView();
            olvColumn_TextName_toDelete = new BrightIdeasSoftware.OLVColumn();
            contextMenuStrip_ToDelete = new ContextMenuStrip(components);
            toolStripMenuItem_DeletedThisNode = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            label_toDelete = new Label();
            panel_toCancel = new Panel();
            olvDataTree_ToCancel = new BrightIdeasSoftware.DataTreeListView();
            olvColumn_TextName_toCancel = new BrightIdeasSoftware.OLVColumn();
            label_toCancel = new Label();
            panel_toAdd = new Panel();
            olvDataTree_ToAdd = new BrightIdeasSoftware.DataTreeListView();
            olvColumn_TextName_toAdd = new BrightIdeasSoftware.OLVColumn();
            label_AvailableInTheseDepartment = new Label();
            olvColumn_TextName = new BrightIdeasSoftware.OLVColumn();
            olvColumn_Description = new BrightIdeasSoftware.OLVColumn();
            splitContainer_DataTreeView = new SplitContainer();
            olvDataTree = new BrightIdeasSoftware.DataTreeListView();
            ContextMenuStripTreeView = new ContextMenuStrip(components);
            toolStripMenuItem_SingleExpandedNode = new ToolStripMenuItem();
            toolStripMenuItem_MultipleExpandedNodes = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripMenuItem_ExpandAllNodes = new ToolStripMenuItem();
            ToolStripMenuItem_CollapseAll = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripMenuItem_Refresh = new ToolStripMenuItem();
            toolStripMenuItem_HotItem = new ToolStripMenuItem();
            toolStripMenuItem_None = new ToolStripMenuItem();
            toolStripMenuItem_Border = new ToolStripMenuItem();
            toolStripMenuItem_Lightbox = new ToolStripMenuItem();
            toolStripMenuItem_TextColor = new ToolStripMenuItem();
            toolStripMenuItem_Translucent = new ToolStripMenuItem();
            toolStripMenuItem_FullRowSelect = new ToolStripMenuItem();
            toolStripMenuItem_TimeLine = new ToolStripMenuItem();
            toolStripMenuItem_SwitchDataTable = new ToolStripMenuItem();
            tableLayoutPanel_DataTreeViewSetting.SuspendLayout();
            panel_toDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)olvDataTree_ToDelete).BeginInit();
            contextMenuStrip_ToDelete.SuspendLayout();
            panel_toCancel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)olvDataTree_ToCancel).BeginInit();
            panel_toAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)olvDataTree_ToAdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer_DataTreeView).BeginInit();
            splitContainer_DataTreeView.Panel1.SuspendLayout();
            splitContainer_DataTreeView.Panel2.SuspendLayout();
            splitContainer_DataTreeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)olvDataTree).BeginInit();
            ContextMenuStripTreeView.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_DataTreeViewSetting
            // 
            tableLayoutPanel_DataTreeViewSetting.AutoSize = true;
            tableLayoutPanel_DataTreeViewSetting.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel_DataTreeViewSetting.ColumnCount = 3;
            tableLayoutPanel_DataTreeViewSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_DataTreeViewSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel_DataTreeViewSetting.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel_DataTreeViewSetting.Controls.Add(panel_toDelete, 2, 0);
            tableLayoutPanel_DataTreeViewSetting.Controls.Add(panel_toCancel, 1, 0);
            tableLayoutPanel_DataTreeViewSetting.Controls.Add(panel_toAdd, 0, 0);
            tableLayoutPanel_DataTreeViewSetting.Dock = DockStyle.Fill;
            tableLayoutPanel_DataTreeViewSetting.Location = new Point(0, 0);
            tableLayoutPanel_DataTreeViewSetting.Name = "tableLayoutPanel_DataTreeViewSetting";
            tableLayoutPanel_DataTreeViewSetting.RowCount = 1;
            tableLayoutPanel_DataTreeViewSetting.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_DataTreeViewSetting.Size = new Size(851, 161);
            tableLayoutPanel_DataTreeViewSetting.TabIndex = 0;
            // 
            // panel_toDelete
            // 
            panel_toDelete.Controls.Add(olvDataTree_ToDelete);
            panel_toDelete.Controls.Add(label_toDelete);
            panel_toDelete.Dock = DockStyle.Fill;
            panel_toDelete.Location = new Point(566, 0);
            panel_toDelete.Margin = new Padding(0);
            panel_toDelete.Name = "panel_toDelete";
            panel_toDelete.Size = new Size(285, 161);
            panel_toDelete.TabIndex = 25;
            // 
            // olvDataTree_ToDelete
            // 
            olvDataTree_ToDelete.AllColumns.Add(olvColumn_TextName_toDelete);
            olvDataTree_ToDelete.AllowDrop = true;
            olvDataTree_ToDelete.AlternateRowBackColor = Color.FromArgb(224, 224, 224);
            olvDataTree_ToDelete.AutoGenerateColumns = false;
            olvDataTree_ToDelete.Columns.AddRange(new ColumnHeader[] { olvColumn_TextName_toDelete });
            olvDataTree_ToDelete.ContextMenuStrip = contextMenuStrip_ToDelete;
            olvDataTree_ToDelete.DataSource = null;
            olvDataTree_ToDelete.Dock = DockStyle.Fill;
            olvDataTree_ToDelete.Font = new Font("Microsoft Sans Serif", 12F);
            olvDataTree_ToDelete.FullRowSelect = true;
            olvDataTree_ToDelete.IsSimpleDragSource = true;
            olvDataTree_ToDelete.IsSimpleDropSink = true;
            olvDataTree_ToDelete.KeyAspectName = "Id";
            olvDataTree_ToDelete.Location = new Point(0, 22);
            olvDataTree_ToDelete.Margin = new Padding(1);
            olvDataTree_ToDelete.Name = "olvDataTree_ToDelete";
            olvDataTree_ToDelete.ParentKeyAspectName = "ParentId";
            olvDataTree_ToDelete.RootKeyValueString = "";
            olvDataTree_ToDelete.SelectColumnsOnRightClick = false;
            olvDataTree_ToDelete.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            olvDataTree_ToDelete.ShowGroups = false;
            olvDataTree_ToDelete.ShowKeyColumns = false;
            olvDataTree_ToDelete.Size = new Size(285, 139);
            olvDataTree_ToDelete.TabIndex = 25;
            olvDataTree_ToDelete.UseCompatibleStateImageBehavior = false;
            olvDataTree_ToDelete.UseFilterIndicator = true;
            olvDataTree_ToDelete.UseFiltering = true;
            olvDataTree_ToDelete.UseHotItem = true;
            olvDataTree_ToDelete.UseTranslucentHotItem = true;
            olvDataTree_ToDelete.UseTranslucentSelection = true;
            olvDataTree_ToDelete.View = View.Details;
            olvDataTree_ToDelete.VirtualMode = true;
            // 
            // olvColumn_TextName_toDelete
            // 
            olvColumn_TextName_toDelete.AspectName = "Text_Name";
            olvColumn_TextName_toDelete.Text = "      Name";
            olvColumn_TextName_toDelete.Width = 250;
            // 
            // contextMenuStrip_ToDelete
            // 
            contextMenuStrip_ToDelete.BackColor = Color.LightGoldenrodYellow;
            contextMenuStrip_ToDelete.ImageScalingSize = new Size(20, 20);
            contextMenuStrip_ToDelete.ImeMode = ImeMode.On;
            contextMenuStrip_ToDelete.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_DeletedThisNode, toolStripSeparator2 });
            contextMenuStrip_ToDelete.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            contextMenuStrip_ToDelete.Name = "PreviewDataGridViewContextMenuStrip";
            contextMenuStrip_ToDelete.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip_ToDelete.ShowImageMargin = false;
            contextMenuStrip_ToDelete.Size = new Size(177, 36);
            // 
            // toolStripMenuItem_DeletedThisNode
            // 
            toolStripMenuItem_DeletedThisNode.Name = "toolStripMenuItem_DeletedThisNode";
            toolStripMenuItem_DeletedThisNode.Size = new Size(176, 26);
            toolStripMenuItem_DeletedThisNode.Text = "Deleted this node";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(173, 6);
            // 
            // label_toDelete
            // 
            label_toDelete.BackColor = SystemColors.Info;
            label_toDelete.BorderStyle = BorderStyle.FixedSingle;
            label_toDelete.Dock = DockStyle.Top;
            label_toDelete.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_toDelete.Location = new Point(0, 0);
            label_toDelete.Margin = new Padding(4, 0, 4, 0);
            label_toDelete.Name = "label_toDelete";
            label_toDelete.Size = new Size(285, 22);
            label_toDelete.TabIndex = 19;
            label_toDelete.Text = "To delete an Items...";
            label_toDelete.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_toCancel
            // 
            panel_toCancel.Controls.Add(olvDataTree_ToCancel);
            panel_toCancel.Controls.Add(label_toCancel);
            panel_toCancel.Dock = DockStyle.Fill;
            panel_toCancel.Location = new Point(283, 0);
            panel_toCancel.Margin = new Padding(0);
            panel_toCancel.Name = "panel_toCancel";
            panel_toCancel.Size = new Size(283, 161);
            panel_toCancel.TabIndex = 24;
            // 
            // olvDataTree_ToCancel
            // 
            olvDataTree_ToCancel.AllColumns.Add(olvColumn_TextName_toCancel);
            olvDataTree_ToCancel.AllowDrop = true;
            olvDataTree_ToCancel.AlternateRowBackColor = Color.FromArgb(224, 224, 224);
            olvDataTree_ToCancel.AutoGenerateColumns = false;
            olvDataTree_ToCancel.Columns.AddRange(new ColumnHeader[] { olvColumn_TextName_toCancel });
            olvDataTree_ToCancel.DataSource = null;
            olvDataTree_ToCancel.Dock = DockStyle.Fill;
            olvDataTree_ToCancel.Font = new Font("Microsoft Sans Serif", 12F);
            olvDataTree_ToCancel.FullRowSelect = true;
            olvDataTree_ToCancel.IsSimpleDragSource = true;
            olvDataTree_ToCancel.IsSimpleDropSink = true;
            olvDataTree_ToCancel.KeyAspectName = "Id";
            olvDataTree_ToCancel.Location = new Point(0, 22);
            olvDataTree_ToCancel.Margin = new Padding(1);
            olvDataTree_ToCancel.Name = "olvDataTree_ToCancel";
            olvDataTree_ToCancel.ParentKeyAspectName = "ParentId";
            olvDataTree_ToCancel.RootKeyValueString = "";
            olvDataTree_ToCancel.SelectColumnsOnRightClick = false;
            olvDataTree_ToCancel.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            olvDataTree_ToCancel.ShowGroups = false;
            olvDataTree_ToCancel.ShowKeyColumns = false;
            olvDataTree_ToCancel.Size = new Size(283, 139);
            olvDataTree_ToCancel.TabIndex = 2;
            olvDataTree_ToCancel.UseCompatibleStateImageBehavior = false;
            olvDataTree_ToCancel.UseFilterIndicator = true;
            olvDataTree_ToCancel.UseFiltering = true;
            olvDataTree_ToCancel.UseHotItem = true;
            olvDataTree_ToCancel.UseTranslucentHotItem = true;
            olvDataTree_ToCancel.UseTranslucentSelection = true;
            olvDataTree_ToCancel.View = View.Details;
            olvDataTree_ToCancel.VirtualMode = true;
            // 
            // olvColumn_TextName_toCancel
            // 
            olvColumn_TextName_toCancel.AspectName = "Text_Name";
            olvColumn_TextName_toCancel.Text = "      Name";
            olvColumn_TextName_toCancel.Width = 250;
            // 
            // label_toCancel
            // 
            label_toCancel.BackColor = SystemColors.Info;
            label_toCancel.BorderStyle = BorderStyle.FixedSingle;
            label_toCancel.Dock = DockStyle.Top;
            label_toCancel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_toCancel.Location = new Point(0, 0);
            label_toCancel.Margin = new Padding(4, 0, 4, 0);
            label_toCancel.Name = "label_toCancel";
            label_toCancel.Size = new Size(283, 22);
            label_toCancel.TabIndex = 19;
            label_toCancel.Text = "To cancel  any drag action...";
            label_toCancel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_toAdd
            // 
            panel_toAdd.Controls.Add(olvDataTree_ToAdd);
            panel_toAdd.Controls.Add(label_AvailableInTheseDepartment);
            panel_toAdd.Dock = DockStyle.Fill;
            panel_toAdd.Location = new Point(0, 0);
            panel_toAdd.Margin = new Padding(0);
            panel_toAdd.Name = "panel_toAdd";
            panel_toAdd.Size = new Size(283, 161);
            panel_toAdd.TabIndex = 23;
            // 
            // olvDataTree_ToAdd
            // 
            olvDataTree_ToAdd.AllColumns.Add(olvColumn_TextName_toAdd);
            olvDataTree_ToAdd.AllowDrop = true;
            olvDataTree_ToAdd.AlternateRowBackColor = Color.FromArgb(224, 224, 224);
            olvDataTree_ToAdd.AutoGenerateColumns = false;
            olvDataTree_ToAdd.Columns.AddRange(new ColumnHeader[] { olvColumn_TextName_toAdd });
            olvDataTree_ToAdd.DataSource = null;
            olvDataTree_ToAdd.Dock = DockStyle.Fill;
            olvDataTree_ToAdd.Font = new Font("Microsoft Sans Serif", 12F);
            olvDataTree_ToAdd.FullRowSelect = true;
            olvDataTree_ToAdd.IsSimpleDragSource = true;
            olvDataTree_ToAdd.IsSimpleDropSink = true;
            olvDataTree_ToAdd.KeyAspectName = "Id";
            olvDataTree_ToAdd.Location = new Point(0, 22);
            olvDataTree_ToAdd.Margin = new Padding(1);
            olvDataTree_ToAdd.Name = "olvDataTree_ToAdd";
            olvDataTree_ToAdd.ParentKeyAspectName = "ParentId";
            olvDataTree_ToAdd.RootKeyValueString = "";
            olvDataTree_ToAdd.SelectColumnsOnRightClick = false;
            olvDataTree_ToAdd.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            olvDataTree_ToAdd.ShowGroups = false;
            olvDataTree_ToAdd.ShowKeyColumns = false;
            olvDataTree_ToAdd.Size = new Size(283, 139);
            olvDataTree_ToAdd.TabIndex = 20;
            olvDataTree_ToAdd.UseCompatibleStateImageBehavior = false;
            olvDataTree_ToAdd.UseFilterIndicator = true;
            olvDataTree_ToAdd.UseFiltering = true;
            olvDataTree_ToAdd.UseHotItem = true;
            olvDataTree_ToAdd.UseTranslucentHotItem = true;
            olvDataTree_ToAdd.UseTranslucentSelection = true;
            olvDataTree_ToAdd.View = View.Details;
            olvDataTree_ToAdd.VirtualMode = true;
            // 
            // olvColumn_TextName_toAdd
            // 
            olvColumn_TextName_toAdd.AspectName = "Text_Name";
            olvColumn_TextName_toAdd.Text = "      Name";
            olvColumn_TextName_toAdd.Width = 250;
            // 
            // label_AvailableInTheseDepartment
            // 
            label_AvailableInTheseDepartment.BackColor = SystemColors.Info;
            label_AvailableInTheseDepartment.BorderStyle = BorderStyle.FixedSingle;
            label_AvailableInTheseDepartment.Dock = DockStyle.Top;
            label_AvailableInTheseDepartment.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_AvailableInTheseDepartment.Location = new Point(0, 0);
            label_AvailableInTheseDepartment.Margin = new Padding(4, 0, 4, 0);
            label_AvailableInTheseDepartment.Name = "label_AvailableInTheseDepartment";
            label_AvailableInTheseDepartment.Size = new Size(283, 22);
            label_AvailableInTheseDepartment.TabIndex = 19;
            label_AvailableInTheseDepartment.Text = "To add new Items...";
            label_AvailableInTheseDepartment.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // olvColumn_TextName
            // 
            olvColumn_TextName.AspectName = "Text_Name";
            olvColumn_TextName.Text = "      Name";
            olvColumn_TextName.Width = 250;
            // 
            // olvColumn_Description
            // 
            olvColumn_Description.AspectName = "Description_Expand";
            olvColumn_Description.Text = "Description";
            olvColumn_Description.Width = 350;
            // 
            // splitContainer_DataTreeView
            // 
            splitContainer_DataTreeView.BorderStyle = BorderStyle.Fixed3D;
            splitContainer_DataTreeView.Dock = DockStyle.Fill;
            splitContainer_DataTreeView.Location = new Point(0, 0);
            splitContainer_DataTreeView.Name = "splitContainer_DataTreeView";
            splitContainer_DataTreeView.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_DataTreeView.Panel1
            // 
            splitContainer_DataTreeView.Panel1.Controls.Add(olvDataTree);
            // 
            // splitContainer_DataTreeView.Panel2
            // 
            splitContainer_DataTreeView.Panel2.Controls.Add(tableLayoutPanel_DataTreeViewSetting);
            splitContainer_DataTreeView.Size = new Size(855, 542);
            splitContainer_DataTreeView.SplitterDistance = 373;
            splitContainer_DataTreeView.TabIndex = 1;
            // 
            // olvDataTree
            // 
            olvDataTree.AllColumns.Add(olvColumn_TextName);
            olvDataTree.AllowDrop = true;
            olvDataTree.AlternateRowBackColor = Color.FromArgb(224, 224, 224);
            olvDataTree.AutoGenerateColumns = false;
            olvDataTree.Columns.AddRange(new ColumnHeader[] { olvColumn_TextName, olvColumn_Description });
            olvDataTree.ContextMenuStrip = ContextMenuStripTreeView;
            olvDataTree.DataSource = null;
            olvDataTree.Dock = DockStyle.Fill;
            olvDataTree.Font = new Font("Microsoft Sans Serif", 12F);
            olvDataTree.FullRowSelect = true;
            olvDataTree.IsSimpleDragSource = true;
            olvDataTree.IsSimpleDropSink = true;
            olvDataTree.KeyAspectName = "Id";
            olvDataTree.Location = new Point(0, 0);
            olvDataTree.Margin = new Padding(1);
            olvDataTree.Name = "olvDataTree";
            olvDataTree.ParentKeyAspectName = "ParentId";
            olvDataTree.RootKeyValueString = "";
            olvDataTree.SelectColumnsOnRightClick = false;
            olvDataTree.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            olvDataTree.ShowGroups = false;
            olvDataTree.ShowKeyColumns = false;
            olvDataTree.Size = new Size(851, 369);
            olvDataTree.TabIndex = 2;
            olvDataTree.UseCompatibleStateImageBehavior = false;
            olvDataTree.UseFilterIndicator = true;
            olvDataTree.UseFiltering = true;
            olvDataTree.UseHotItem = true;
            olvDataTree.UseTranslucentHotItem = true;
            olvDataTree.UseTranslucentSelection = true;
            olvDataTree.View = View.Details;
            olvDataTree.VirtualMode = true;
            // 
            // ContextMenuStripTreeView
            // 
            ContextMenuStripTreeView.BackColor = Color.LightGoldenrodYellow;
            ContextMenuStripTreeView.ImageScalingSize = new Size(20, 20);
            ContextMenuStripTreeView.ImeMode = ImeMode.On;
            ContextMenuStripTreeView.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_SingleExpandedNode, toolStripMenuItem_MultipleExpandedNodes, toolStripSeparator5, toolStripMenuItem_ExpandAllNodes, ToolStripMenuItem_CollapseAll, toolStripSeparator7, toolStripMenuItem_Refresh, toolStripMenuItem_HotItem, toolStripMenuItem_TimeLine, toolStripMenuItem_SwitchDataTable });
            ContextMenuStripTreeView.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            ContextMenuStripTreeView.Name = "PreviewDataGridViewContextMenuStrip";
            ContextMenuStripTreeView.RenderMode = ToolStripRenderMode.Professional;
            ContextMenuStripTreeView.ShowImageMargin = false;
            ContextMenuStripTreeView.Size = new Size(230, 224);
            // 
            // toolStripMenuItem_SingleExpandedNode
            // 
            toolStripMenuItem_SingleExpandedNode.Name = "toolStripMenuItem_SingleExpandedNode";
            toolStripMenuItem_SingleExpandedNode.Size = new Size(229, 26);
            toolStripMenuItem_SingleExpandedNode.Text = "Single expanded node";
            // 
            // toolStripMenuItem_MultipleExpandedNodes
            // 
            toolStripMenuItem_MultipleExpandedNodes.Name = "toolStripMenuItem_MultipleExpandedNodes";
            toolStripMenuItem_MultipleExpandedNodes.Size = new Size(229, 26);
            toolStripMenuItem_MultipleExpandedNodes.Text = "Multiple expanded nodes";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(226, 6);
            // 
            // toolStripMenuItem_ExpandAllNodes
            // 
            toolStripMenuItem_ExpandAllNodes.Name = "toolStripMenuItem_ExpandAllNodes";
            toolStripMenuItem_ExpandAllNodes.Size = new Size(229, 26);
            toolStripMenuItem_ExpandAllNodes.Text = "Expand All Nodes";
            // 
            // ToolStripMenuItem_CollapseAll
            // 
            ToolStripMenuItem_CollapseAll.Name = "ToolStripMenuItem_CollapseAll";
            ToolStripMenuItem_CollapseAll.Size = new Size(229, 26);
            ToolStripMenuItem_CollapseAll.Text = "Collapse All Nodes";
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(226, 6);
            // 
            // toolStripMenuItem_Refresh
            // 
            toolStripMenuItem_Refresh.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem_Refresh.Name = "toolStripMenuItem_Refresh";
            toolStripMenuItem_Refresh.Size = new Size(229, 26);
            toolStripMenuItem_Refresh.Text = "Refresh";
            // 
            // toolStripMenuItem_HotItem
            // 
            toolStripMenuItem_HotItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripMenuItem_HotItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_None, toolStripMenuItem_Border, toolStripMenuItem_Lightbox, toolStripMenuItem_TextColor, toolStripMenuItem_Translucent, toolStripMenuItem_FullRowSelect });
            toolStripMenuItem_HotItem.Name = "toolStripMenuItem_HotItem";
            toolStripMenuItem_HotItem.Size = new Size(229, 26);
            toolStripMenuItem_HotItem.Text = "Hot Item";
            // 
            // toolStripMenuItem_None
            // 
            toolStripMenuItem_None.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_None.Name = "toolStripMenuItem_None";
            toolStripMenuItem_None.Size = new Size(177, 26);
            toolStripMenuItem_None.Text = "None";
            // 
            // toolStripMenuItem_Border
            // 
            toolStripMenuItem_Border.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_Border.Name = "toolStripMenuItem_Border";
            toolStripMenuItem_Border.Size = new Size(177, 26);
            toolStripMenuItem_Border.Text = "Border";
            // 
            // toolStripMenuItem_Lightbox
            // 
            toolStripMenuItem_Lightbox.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_Lightbox.Name = "toolStripMenuItem_Lightbox";
            toolStripMenuItem_Lightbox.Size = new Size(177, 26);
            toolStripMenuItem_Lightbox.Text = "Lightbox";
            // 
            // toolStripMenuItem_TextColor
            // 
            toolStripMenuItem_TextColor.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_TextColor.Name = "toolStripMenuItem_TextColor";
            toolStripMenuItem_TextColor.Size = new Size(177, 26);
            toolStripMenuItem_TextColor.Text = "Text Color";
            // 
            // toolStripMenuItem_Translucent
            // 
            toolStripMenuItem_Translucent.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_Translucent.Name = "toolStripMenuItem_Translucent";
            toolStripMenuItem_Translucent.Size = new Size(177, 26);
            toolStripMenuItem_Translucent.Text = "Translucent";
            // 
            // toolStripMenuItem_FullRowSelect
            // 
            toolStripMenuItem_FullRowSelect.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_FullRowSelect.Name = "toolStripMenuItem_FullRowSelect";
            toolStripMenuItem_FullRowSelect.Size = new Size(177, 26);
            toolStripMenuItem_FullRowSelect.Text = "FullRowSelect";
            // 
            // toolStripMenuItem_TimeLine
            // 
            toolStripMenuItem_TimeLine.Name = "toolStripMenuItem_TimeLine";
            toolStripMenuItem_TimeLine.Size = new Size(229, 26);
            toolStripMenuItem_TimeLine.Text = "TimeLine";
            toolStripMenuItem_TimeLine.Click += ToolStripMenuItem_TimeLine_Click;
            // 
            // toolStripMenuItem_SwitchDataTable
            // 
            toolStripMenuItem_SwitchDataTable.Name = "toolStripMenuItem_SwitchDataTable";
            toolStripMenuItem_SwitchDataTable.Size = new Size(229, 26);
            toolStripMenuItem_SwitchDataTable.Text = "Switch DataTable";
            toolStripMenuItem_SwitchDataTable.Click += SwitchDataTableToolStripMenuItem_Click;
            // 
            // DataTreeViewToAdd_Cancel_Delete
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer_DataTreeView);
            Name = "DataTreeViewToAdd_Cancel_Delete";
            Size = new Size(855, 542);
            Load += DataTreeViewToAdd_Cancel_Delete_Load;
            tableLayoutPanel_DataTreeViewSetting.ResumeLayout(false);
            panel_toDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)olvDataTree_ToDelete).EndInit();
            contextMenuStrip_ToDelete.ResumeLayout(false);
            panel_toCancel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)olvDataTree_ToCancel).EndInit();
            panel_toAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)olvDataTree_ToAdd).EndInit();
            splitContainer_DataTreeView.Panel1.ResumeLayout(false);
            splitContainer_DataTreeView.Panel2.ResumeLayout(false);
            splitContainer_DataTreeView.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_DataTreeView).EndInit();
            splitContainer_DataTreeView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)olvDataTree).EndInit();
            ContextMenuStripTreeView.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_DataTreeViewSetting;
        private Panel panel_toAdd;
        private Label label_AvailableInTheseDepartment;
        private BrightIdeasSoftware.DataTreeListView olvDataTree_ToAdd;
        private BrightIdeasSoftware.OLVColumn olvColumn_TextName_toAdd;
        private Panel panel_toCancel;
        private BrightIdeasSoftware.DataTreeListView olvDataTree_ToCancel;
        private BrightIdeasSoftware.OLVColumn olvColumn_TextName_toCancel;
        private Label label_toCancel;
        private Panel panel_toDelete;
        private BrightIdeasSoftware.DataTreeListView olvDataTree_ToDelete;
        private BrightIdeasSoftware.OLVColumn olvColumn_TextName_toDelete;
        private Label label_toDelete;
        private SplitContainer splitContainer_DataTreeView;
        private BrightIdeasSoftware.DataTreeListView olvDataTree;
        private BrightIdeasSoftware.OLVColumn olvColumn_TextName;
        private BrightIdeasSoftware.OLVColumn olvColumn_Description;
        private ContextMenuStrip ContextMenuStripTreeView;
        private ToolStripMenuItem toolStripMenuItem_SingleExpandedNode;
        private ToolStripMenuItem toolStripMenuItem_MultipleExpandedNodes;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem toolStripMenuItem_ExpandAllNodes;
        private ToolStripMenuItem ToolStripMenuItem_CollapseAll;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem toolStripMenuItem_Refresh;
        private ToolStripMenuItem toolStripMenuItem_HotItem;
        private ToolStripMenuItem toolStripMenuItem_None;
        private ToolStripMenuItem toolStripMenuItem_Border;
        private ToolStripMenuItem toolStripMenuItem_Lightbox;
        private ToolStripMenuItem toolStripMenuItem_TextColor;
        private ToolStripMenuItem toolStripMenuItem_Translucent;
        private ToolStripMenuItem toolStripMenuItem_FullRowSelect;
        private ToolStripMenuItem toolStripMenuItem_TimeLine;
        private ToolStripMenuItem toolStripMenuItem_SwitchDataTable;
        private ContextMenuStrip contextMenuStrip_ToDelete;
        private ToolStripMenuItem toolStripMenuItem_DeletedThisNode;
        private ToolStripSeparator toolStripSeparator2;
    }
}

using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using StockRoom11net.Controls;
using StockRoom11net.Controls.CustomPanelDoubleBuffered;
using StockRoom11net.Controls.DataGridViewExtend;
using StockRoom11net.Controls.ThumbViewer;
using StockRoom11net.Controls.ZPL2_ZebraPrint;

namespace StockRoom11net
{
    partial class StockRoom_Inventory
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _contextMenuStripTreeView = new ContextMenuStrip(components);
            ToolStripMenuItem_singleExpandedNode = new ToolStripMenuItem();
            ToolStripMenuItem_multipleExpandedNodes = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ToolStripMenuItem_ExpandAll = new ToolStripMenuItem();
            ToolStripMenuItem_CollapseAll = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ToolStripMenuItem_AddNewComponent = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            ToolStripMenuItem_refresh = new ToolStripMenuItem();
            ToolStripMenuItem_SetPictures = new ToolStripMenuItem();
            toolStripMenuItem_HotItem = new ToolStripMenuItem();
            toolStripMenuItem_None = new ToolStripMenuItem();
            toolStripMenuItem_Border = new ToolStripMenuItem();
            toolStripMenuItem_Lightbox = new ToolStripMenuItem();
            toolStripMenuItem_TextColor = new ToolStripMenuItem();
            toolStripMenuItem_Translucent = new ToolStripMenuItem();
            toolStripMenuItem_FullRowSelect = new ToolStripMenuItem();
            dataTreeViewToAdd_Cancel_Delete = new DataTreeViewToAddCancelDelete();
            contextMenuStripPicturesBox = new ContextMenuStrip(components);
            toolStripMenuItem_SetToNoPicturesFound = new ToolStripMenuItem();
            toolStripMenuItem_AddANewPictures = new ToolStripMenuItem();
            toolStripMenuItemCopyToANewFile = new ToolStripMenuItem();
            toolStripMenuItemCopyFileToTheClickBoard = new ToolStripMenuItem();
            toolStripMenuItemCopyImageToTheClipBoard = new ToolStripMenuItem();
            dataView_StockRoom = new System.Data.DataView();
            toolStripSeparator3 = new ToolStripSeparator();
            ToolStripMenuItem_showSettingDialog = new ToolStripMenuItem();
            _bindingSource_table_StockroomTreeView = new BindingSource(components);
            dataView_TreeView = new System.Data.DataView();
            _bindingSource_StockRoom = new BindingSource(components);
            splitContainerHorizontal = new SplitContainer();
            splitContainerVertical = new SplitContainer();
            dataGridViewExtended = new DataGridViewExtended();
            ToolStripMenuItem_PrintCompLabel = new ToolStripMenuItem();
            ToolStripMenuItem_GroupByThisColumn = new ToolStripMenuItem();
            tabPage_UpDateModifCompValue = new TabPage();
            grouper_ComponentProperties = new CodeVendor.Controls.Grouper();
            panel2 = new Panel();
            label_Received_Date = new Label();
            dateTimePicker = new DateTimePicker();
            panel_LabelsComponentsProperties = new Panel();
            label_PartNumber = new Label();
            textBoxUpDateModifPartNumber = new TextBox();
            panel3 = new Panel();
            panel4 = new Panel();
            label_Received_Quantity = new Label();
            comboBox1 = new ComboBox();
            panel5 = new Panel();
            label_NumberofReelsOrBoxes = new Label();
            comboBox2 = new ComboBox();
            flowLayoutPanel = new FlowLayoutPanel();
            button_Add_Other = new Button();
            button_Edit = new Button();
            button_Cancel = new Button();
            button1 = new Button();
            button_Adjustment = new Button();
            button_Add = new Button();
            panel_ComponentControl = new Panel();
            printingReferences = new PrintingReferences();
            panel_SpacerContainerComp = new Panel();
            customPanel_ContainerComp = new CustomPanelDoubleBuffered();
            panel6 = new Panel();
            grouper_ManufacturerProperties = new CodeVendor.Controls.Grouper();
            panel_LabelsManufacturerProperties = new Panel();
            panel7 = new Panel();
            comboBox_Manufacturer = new ComboBox();
            label_Model_Number = new Label();
            panel8 = new Panel();
            comboBox_Supplier = new ComboBox();
            label_Manufacturer = new Label();
            panel9 = new Panel();
            comboBox_Model_Number = new ComboBox();
            label_Supplier = new Label();
            panel1 = new Panel();
            tabPage_TreeViewSetting = new TabPage();
            tabPage_TimeLine = new TabPage();
            tabPage_Location = new TabPage();
            thumbViewer_Location = new ThumbViewer();
            tabPage_Pictures = new TabPage();
            thumbViewer_Pictures = new ThumbViewer();
            TabControl_Inventory = new CustomTabControl();
            tabPage_NoteEditor = new TabPage();
            blazorWebView1 = new BlazorWebView();
            tabPage_Test = new TabPage();
            grouper_ItemProperties = new CodeVendor.Controls.Grouper();
            flowLayoutPanel_ItemsProperties = new FlowLayoutPanel();
            comboBoxExtended_PartNumber = new StockRoom11net.Controls.ComboBoxExtended.ComboBoxExtended();
            comboBoxExtended1 = new StockRoom11net.Controls.ComboBoxExtended.ComboBoxExtended();
            comboBoxExtended_Status = new StockRoom11net.Controls.ComboBoxExtended.ComboBoxExtended();
            comboBoxExtended_Description = new StockRoom11net.Controls.ComboBoxExtended.ComboBoxExtended();
            grouper_NewItemButtons = new CodeVendor.Controls.Grouper();
            flowLayoutPanel_Buttons = new FlowLayoutPanel();
            button_Delete = new Button();
            button_Save = new Button();
            button_AddNew = new Button();
            tabPage_AddNewItem = new TabPage();
            blazorWebView_TimeLine = new BlazorWebView();
            ((System.ComponentModel.ISupportInitialize)BindingSourceTreeViewBase).BeginInit();
            _contextMenuStripTreeView.SuspendLayout();
            contextMenuStripPicturesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataView_StockRoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_bindingSource_table_StockroomTreeView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataView_TreeView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_bindingSource_StockRoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerHorizontal).BeginInit();
            splitContainerHorizontal.Panel1.SuspendLayout();
            splitContainerHorizontal.Panel2.SuspendLayout();
            splitContainerHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerVertical).BeginInit();
            splitContainerVertical.Panel1.SuspendLayout();
            splitContainerVertical.Panel2.SuspendLayout();
            splitContainerVertical.SuspendLayout();
            tabPage_UpDateModifCompValue.SuspendLayout();
            grouper_ComponentProperties.SuspendLayout();
            panel2.SuspendLayout();
            panel_LabelsComponentsProperties.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            panel_ComponentControl.SuspendLayout();
            customPanel_ContainerComp.SuspendLayout();
            grouper_ManufacturerProperties.SuspendLayout();
            panel_LabelsManufacturerProperties.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            tabPage_TimeLine.SuspendLayout();
            tabPage_Location.SuspendLayout();
            tabPage_Pictures.SuspendLayout();
            TabControl_Inventory.SuspendLayout();
            tabPage_NoteEditor.SuspendLayout();
            grouper_ItemProperties.SuspendLayout();
            flowLayoutPanel_ItemsProperties.SuspendLayout();
            grouper_NewItemButtons.SuspendLayout();
            flowLayoutPanel_Buttons.SuspendLayout();
            tabPage_AddNewItem.SuspendLayout();
            SuspendLayout();
            // 
            // _contextMenuStripTreeView
            // 
            _contextMenuStripTreeView.BackColor = Color.LightGoldenrodYellow;
            _contextMenuStripTreeView.ImageScalingSize = new Size(20, 20);
            _contextMenuStripTreeView.ImeMode = ImeMode.On;
            _contextMenuStripTreeView.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_singleExpandedNode, ToolStripMenuItem_multipleExpandedNodes, toolStripSeparator1, ToolStripMenuItem_ExpandAll, ToolStripMenuItem_CollapseAll, toolStripSeparator2, ToolStripMenuItem_AddNewComponent, toolStripSeparator4, ToolStripMenuItem_refresh, ToolStripMenuItem_SetPictures, toolStripMenuItem_HotItem });
            _contextMenuStripTreeView.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            _contextMenuStripTreeView.Name = "PreviewDataGridViewContextMenuStrip";
            _contextMenuStripTreeView.RenderMode = ToolStripRenderMode.Professional;
            _contextMenuStripTreeView.ShowImageMargin = false;
            _contextMenuStripTreeView.Size = new Size(230, 230);
            // 
            // ToolStripMenuItem_singleExpandedNode
            // 
            ToolStripMenuItem_singleExpandedNode.Name = "ToolStripMenuItem_singleExpandedNode";
            ToolStripMenuItem_singleExpandedNode.Size = new Size(229, 26);
            ToolStripMenuItem_singleExpandedNode.Text = "Single expanded node";
            // 
            // ToolStripMenuItem_multipleExpandedNodes
            // 
            ToolStripMenuItem_multipleExpandedNodes.Name = "ToolStripMenuItem_multipleExpandedNodes";
            ToolStripMenuItem_multipleExpandedNodes.Size = new Size(229, 26);
            ToolStripMenuItem_multipleExpandedNodes.Text = "Multiple expanded nodes";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(226, 6);
            // 
            // ToolStripMenuItem_ExpandAll
            // 
            ToolStripMenuItem_ExpandAll.Name = "ToolStripMenuItem_ExpandAll";
            ToolStripMenuItem_ExpandAll.Size = new Size(229, 26);
            ToolStripMenuItem_ExpandAll.Text = "Expand All Nodes";
            // 
            // ToolStripMenuItem_CollapseAll
            // 
            ToolStripMenuItem_CollapseAll.Name = "ToolStripMenuItem_CollapseAll";
            ToolStripMenuItem_CollapseAll.Size = new Size(229, 26);
            ToolStripMenuItem_CollapseAll.Text = "Collapse All Nodes";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(226, 6);
            // 
            // ToolStripMenuItem_AddNewComponent
            // 
            ToolStripMenuItem_AddNewComponent.Name = "ToolStripMenuItem_AddNewComponent";
            ToolStripMenuItem_AddNewComponent.Size = new Size(229, 26);
            ToolStripMenuItem_AddNewComponent.Text = "Add new Component";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(226, 6);
            // 
            // ToolStripMenuItem_refresh
            // 
            ToolStripMenuItem_refresh.Name = "ToolStripMenuItem_refresh";
            ToolStripMenuItem_refresh.Size = new Size(229, 26);
            ToolStripMenuItem_refresh.Text = "Refresh";
            // 
            // ToolStripMenuItem_SetPictures
            // 
            ToolStripMenuItem_SetPictures.Name = "ToolStripMenuItem_SetPictures";
            ToolStripMenuItem_SetPictures.Size = new Size(229, 26);
            ToolStripMenuItem_SetPictures.Text = "Set Pictures";
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
            // dataTreeViewToAdd_Cancel_Delete
            // 
            dataTreeViewToAdd_Cancel_Delete.Dock = DockStyle.Fill;
            dataTreeViewToAdd_Cancel_Delete.Location = new Point(0, 0);
            dataTreeViewToAdd_Cancel_Delete.Margin = new Padding(1);
            dataTreeViewToAdd_Cancel_Delete.Name = "dataTreeViewToAdd_Cancel_Delete";
            dataTreeViewToAdd_Cancel_Delete.Size = new Size(513, 510);
            dataTreeViewToAdd_Cancel_Delete.TabIndex = 0;
            // 
            // contextMenuStripPicturesBox
            // 
            contextMenuStripPicturesBox.BackColor = Color.LightGoldenrodYellow;
            contextMenuStripPicturesBox.ImageScalingSize = new Size(20, 20);
            contextMenuStripPicturesBox.ImeMode = ImeMode.On;
            contextMenuStripPicturesBox.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_SetToNoPicturesFound, toolStripMenuItem_AddANewPictures, toolStripMenuItemCopyToANewFile, toolStripMenuItemCopyFileToTheClickBoard, toolStripMenuItemCopyImageToTheClipBoard });
            contextMenuStripPicturesBox.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            contextMenuStripPicturesBox.Name = "PreviewDataGridViewContextMenuStrip";
            contextMenuStripPicturesBox.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStripPicturesBox.ShowImageMargin = false;
            contextMenuStripPicturesBox.Size = new Size(258, 134);
            // 
            // toolStripMenuItem_SetToNoPicturesFound
            // 
            toolStripMenuItem_SetToNoPicturesFound.Name = "toolStripMenuItem_SetToNoPicturesFound";
            toolStripMenuItem_SetToNoPicturesFound.Size = new Size(257, 26);
            toolStripMenuItem_SetToNoPicturesFound.Text = "Set to Pictures not found.";
            // 
            // toolStripMenuItem_AddANewPictures
            // 
            toolStripMenuItem_AddANewPictures.Name = "toolStripMenuItem_AddANewPictures";
            toolStripMenuItem_AddANewPictures.Size = new Size(257, 26);
            toolStripMenuItem_AddANewPictures.Text = "Add a new Pictures.";
            // 
            // toolStripMenuItemCopyToANewFile
            // 
            toolStripMenuItemCopyToANewFile.Name = "toolStripMenuItemCopyToANewFile";
            toolStripMenuItemCopyToANewFile.Size = new Size(257, 26);
            toolStripMenuItemCopyToANewFile.Text = "Copy to a new file.";
            // 
            // toolStripMenuItemCopyFileToTheClickBoard
            // 
            toolStripMenuItemCopyFileToTheClickBoard.Name = "toolStripMenuItemCopyFileToTheClickBoard";
            toolStripMenuItemCopyFileToTheClickBoard.Size = new Size(257, 26);
            toolStripMenuItemCopyFileToTheClickBoard.Text = "Copy file to the ClipBoard.";
            // 
            // toolStripMenuItemCopyImageToTheClipBoard
            // 
            toolStripMenuItemCopyImageToTheClipBoard.Name = "toolStripMenuItemCopyImageToTheClipBoard";
            toolStripMenuItemCopyImageToTheClipBoard.Size = new Size(257, 26);
            toolStripMenuItemCopyImageToTheClipBoard.Text = "Copy image to the ClipBoard.";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(219, 6);
            // 
            // ToolStripMenuItem_showSettingDialog
            // 
            ToolStripMenuItem_showSettingDialog.Name = "ToolStripMenuItem_showSettingDialog";
            ToolStripMenuItem_showSettingDialog.Size = new Size(32, 19);
            // 
            // _bindingSource_table_StockroomTreeView
            // 
            _bindingSource_table_StockroomTreeView.DataSource = dataView_TreeView;
            // 
            // _bindingSource_StockRoom
            // 
            _bindingSource_StockRoom.DataSource = dataView_StockRoom;
            // 
            // splitContainerHorizontal
            // 
            splitContainerHorizontal.BorderStyle = BorderStyle.Fixed3D;
            splitContainerHorizontal.Dock = DockStyle.Fill;
            splitContainerHorizontal.Location = new Point(0, 0);
            splitContainerHorizontal.Margin = new Padding(0);
            splitContainerHorizontal.Name = "splitContainerHorizontal";
            splitContainerHorizontal.Orientation = Orientation.Horizontal;
            // 
            // splitContainerHorizontal.Panel1
            // 
            splitContainerHorizontal.Panel1.Controls.Add(splitContainerVertical);
            // 
            // splitContainerHorizontal.Panel2
            // 
            splitContainerHorizontal.Panel2.Controls.Add(dataGridViewExtended);
            splitContainerHorizontal.Size = new Size(1678, 800);
            splitContainerHorizontal.SplitterDistance = 514;
            splitContainerHorizontal.SplitterWidth = 3;
            splitContainerHorizontal.TabIndex = 0;
            // 
            // splitContainerVertical
            // 
            splitContainerVertical.BorderStyle = BorderStyle.Fixed3D;
            splitContainerVertical.Dock = DockStyle.Fill;
            splitContainerVertical.Location = new Point(0, 0);
            splitContainerVertical.Margin = new Padding(0);
            splitContainerVertical.Name = "splitContainerVertical";
            // 
            // splitContainerVertical.Panel1
            // 
            splitContainerVertical.Panel1.Controls.Add(dataTreeViewToAdd_Cancel_Delete);
            // 
            // splitContainerVertical.Panel2
            // 
            splitContainerVertical.Panel2.Controls.Add(TabControl_Inventory);
            splitContainerVertical.Size = new Size(1678, 514);
            splitContainerVertical.SplitterDistance = 517;
            splitContainerVertical.SplitterIncrement = 10;
            splitContainerVertical.SplitterWidth = 1;
            splitContainerVertical.TabIndex = 0;
            // 
            // dataGridViewExtended
            // 
            dataGridViewExtended.BindingCompleted = false;
            dataGridViewExtended.ContextMenuStrip = _contextMenuStripTreeView;
            dataGridViewExtended.CurrentRowBackgroundColor = Color.DeepSkyBlue;
            dataGridViewExtended.CurrentRowBorderColor = Color.DarkBlue;
            dataGridViewExtended.CustomEdit = Utilities.EditMode.View;
            dataGridViewExtended.DividerColor = Color.Red;
            dataGridViewExtended.DividerHeight = 0;
            dataGridViewExtended.Dock = DockStyle.Fill;
            dataGridViewExtended.FirstDisplayedRow = null;
            dataGridViewExtended.Location = new Point(0, 0);
            dataGridViewExtended.Margin = new Padding(4, 5, 4, 5);
            dataGridViewExtended.Name = "dataGridViewExtended";
            dataGridViewExtended.NeedSaveData = false;
            dataGridViewExtended.SelectionBorderWidth = 3;
            dataGridViewExtended.SelectionColor = Color.DeepSkyBlue;
            dataGridViewExtended.SetValueAt = null;
            dataGridViewExtended.Size = new Size(1674, 279);
            dataGridViewExtended.TabIndex = 0;
            // 
            // ToolStripMenuItem_PrintCompLabel
            // 
            ToolStripMenuItem_PrintCompLabel.Name = "ToolStripMenuItem_PrintCompLabel";
            ToolStripMenuItem_PrintCompLabel.Size = new Size(205, 22);
            ToolStripMenuItem_PrintCompLabel.Text = "Print Comp Label";
            // 
            // ToolStripMenuItem_GroupByThisColumn
            // 
            ToolStripMenuItem_GroupByThisColumn.Name = "ToolStripMenuItem_GroupByThisColumn";
            ToolStripMenuItem_GroupByThisColumn.Size = new Size(205, 22);
            ToolStripMenuItem_GroupByThisColumn.Text = "Test Add itemEFtableTreeView";
            // 
            // tabPage_UpDateModifCompValue
            // 
            tabPage_UpDateModifCompValue.BackColor = SystemColors.Control;
            tabPage_UpDateModifCompValue.BorderStyle = BorderStyle.Fixed3D;
            tabPage_UpDateModifCompValue.Controls.Add(grouper_ManufacturerProperties);
            tabPage_UpDateModifCompValue.Controls.Add(panel_ComponentControl);
            tabPage_UpDateModifCompValue.Controls.Add(flowLayoutPanel);
            tabPage_UpDateModifCompValue.Controls.Add(grouper_ComponentProperties);
            tabPage_UpDateModifCompValue.Location = new Point(4, 4);
            tabPage_UpDateModifCompValue.Margin = new Padding(0);
            tabPage_UpDateModifCompValue.Name = "tabPage_UpDateModifCompValue";
            tabPage_UpDateModifCompValue.Size = new Size(1148, 478);
            tabPage_UpDateModifCompValue.TabIndex = 7;
            tabPage_UpDateModifCompValue.Tag = "";
            tabPage_UpDateModifCompValue.Text = "   UpDate/Modif";
            // 
            // grouper_ComponentProperties
            // 
            grouper_ComponentProperties.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_ComponentProperties.BackgroundColor = SystemColors.ButtonHighlight;
            grouper_ComponentProperties.BackgroundGradientColor = Color.LightGray;
            grouper_ComponentProperties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_ComponentProperties.BorderColor = Color.Black;
            grouper_ComponentProperties.BorderThickness = 1F;
            grouper_ComponentProperties.Controls.Add(panel3);
            grouper_ComponentProperties.Controls.Add(panel_LabelsComponentsProperties);
            grouper_ComponentProperties.Controls.Add(panel2);
            grouper_ComponentProperties.CustomGroupBoxColor = Color.White;
            grouper_ComponentProperties.Dock = DockStyle.Top;
            grouper_ComponentProperties.GroupImage = null;
            grouper_ComponentProperties.GroupTitle = "Component Properties";
            grouper_ComponentProperties.Location = new Point(0, 0);
            grouper_ComponentProperties.Margin = new Padding(0);
            grouper_ComponentProperties.MinimumSize = new Size(500, 100);
            grouper_ComponentProperties.Name = "grouper_ComponentProperties";
            grouper_ComponentProperties.Padding = new Padding(10, 25, 10, 10);
            grouper_ComponentProperties.PaintGroupBox = false;
            grouper_ComponentProperties.RoundCorners = 10;
            grouper_ComponentProperties.ShadowColor = Color.DarkGray;
            grouper_ComponentProperties.ShadowControl = false;
            grouper_ComponentProperties.ShadowThickness = 3;
            grouper_ComponentProperties.Size = new Size(1144, 100);
            grouper_ComponentProperties.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.Controls.Add(dateTimePicker);
            panel2.Controls.Add(label_Received_Date);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(838, 25);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(296, 65);
            panel2.TabIndex = 23;
            // 
            // label_Received_Date
            // 
            label_Received_Date.AutoSize = true;
            label_Received_Date.Dock = DockStyle.Top;
            label_Received_Date.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Received_Date.Location = new Point(5, 5);
            label_Received_Date.Margin = new Padding(0);
            label_Received_Date.Name = "label_Received_Date";
            label_Received_Date.Size = new Size(117, 20);
            label_Received_Date.TabIndex = 5;
            label_Received_Date.Text = "Recived Date";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Dock = DockStyle.Bottom;
            dateTimePicker.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker.Location = new Point(5, 34);
            dateTimePicker.Margin = new Padding(10);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(286, 26);
            dateTimePicker.TabIndex = 4;
            // 
            // panel_LabelsComponentsProperties
            // 
            panel_LabelsComponentsProperties.AutoSize = true;
            panel_LabelsComponentsProperties.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_LabelsComponentsProperties.Controls.Add(textBoxUpDateModifPartNumber);
            panel_LabelsComponentsProperties.Controls.Add(label_PartNumber);
            panel_LabelsComponentsProperties.Dock = DockStyle.Left;
            panel_LabelsComponentsProperties.Location = new Point(10, 25);
            panel_LabelsComponentsProperties.Margin = new Padding(0);
            panel_LabelsComponentsProperties.MinimumSize = new Size(250, 0);
            panel_LabelsComponentsProperties.Name = "panel_LabelsComponentsProperties";
            panel_LabelsComponentsProperties.Padding = new Padding(5);
            panel_LabelsComponentsProperties.Size = new Size(250, 65);
            panel_LabelsComponentsProperties.TabIndex = 6;
            // 
            // label_PartNumber
            // 
            label_PartNumber.AutoSize = true;
            label_PartNumber.Dock = DockStyle.Top;
            label_PartNumber.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_PartNumber.Location = new Point(5, 5);
            label_PartNumber.Margin = new Padding(48, 22, 48, 22);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Size = new Size(109, 20);
            label_PartNumber.TabIndex = 0;
            label_PartNumber.Text = "Part Number";
            // 
            // textBoxUpDateModifPartNumber
            // 
            textBoxUpDateModifPartNumber.Dock = DockStyle.Bottom;
            textBoxUpDateModifPartNumber.Location = new Point(5, 34);
            textBoxUpDateModifPartNumber.Margin = new Padding(5);
            textBoxUpDateModifPartNumber.Name = "textBoxUpDateModifPartNumber";
            textBoxUpDateModifPartNumber.Size = new Size(240, 26);
            textBoxUpDateModifPartNumber.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(260, 25);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(578, 65);
            panel3.TabIndex = 24;
            // 
            // panel4
            // 
            panel4.Controls.Add(comboBox1);
            panel4.Controls.Add(label_Received_Quantity);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5);
            panel4.Size = new Size(250, 65);
            panel4.TabIndex = 23;
            // 
            // label_Received_Quantity
            // 
            label_Received_Quantity.AutoSize = true;
            label_Received_Quantity.Dock = DockStyle.Top;
            label_Received_Quantity.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Received_Quantity.Location = new Point(5, 5);
            label_Received_Quantity.Margin = new Padding(48, 22, 48, 22);
            label_Received_Quantity.Name = "label_Received_Quantity";
            label_Received_Quantity.Size = new Size(159, 20);
            label_Received_Quantity.TabIndex = 2;
            label_Received_Quantity.Text = "Amounts Received";
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Bottom;
            comboBox1.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(5, 34);
            comboBox1.Margin = new Padding(10);
            comboBox1.MinimumSize = new Size(150, 0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(240, 26);
            comboBox1.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.Controls.Add(comboBox2);
            panel5.Controls.Add(label_NumberofReelsOrBoxes);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(250, 0);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5);
            panel5.Size = new Size(328, 65);
            panel5.TabIndex = 24;
            // 
            // label_NumberofReelsOrBoxes
            // 
            label_NumberofReelsOrBoxes.AutoSize = true;
            label_NumberofReelsOrBoxes.Dock = DockStyle.Top;
            label_NumberofReelsOrBoxes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_NumberofReelsOrBoxes.Location = new Point(5, 5);
            label_NumberofReelsOrBoxes.Margin = new Padding(48, 22, 48, 22);
            label_NumberofReelsOrBoxes.Name = "label_NumberofReelsOrBoxes";
            label_NumberofReelsOrBoxes.Size = new Size(221, 20);
            label_NumberofReelsOrBoxes.TabIndex = 2;
            label_NumberofReelsOrBoxes.Text = "Number of Reels Or Boxes";
            // 
            // comboBox2
            // 
            comboBox2.Dock = DockStyle.Bottom;
            comboBox2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(5, 34);
            comboBox2.Margin = new Padding(10);
            comboBox2.MinimumSize = new Size(200, 0);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(318, 26);
            comboBox2.TabIndex = 3;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.Controls.Add(button_Add);
            flowLayoutPanel.Controls.Add(button_Adjustment);
            flowLayoutPanel.Controls.Add(button1);
            flowLayoutPanel.Controls.Add(button_Cancel);
            flowLayoutPanel.Controls.Add(button_Edit);
            flowLayoutPanel.Controls.Add(button_Add_Other);
            flowLayoutPanel.Dock = DockStyle.Bottom;
            flowLayoutPanel.Location = new Point(0, 414);
            flowLayoutPanel.Margin = new Padding(0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(1144, 60);
            flowLayoutPanel.TabIndex = 12;
            // 
            // button_Add_Other
            // 
            button_Add_Other.Font = new Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Add_Other.Location = new Point(610, 10);
            button_Add_Other.Margin = new Padding(10);
            button_Add_Other.Name = "button_Add_Other";
            button_Add_Other.Size = new Size(106, 40);
            button_Add_Other.TabIndex = 8;
            button_Add_Other.Text = "Add Other";
            button_Add_Other.UseVisualStyleBackColor = true;
            // 
            // button_Edit
            // 
            button_Edit.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Edit.Location = new Point(490, 10);
            button_Edit.Margin = new Padding(10);
            button_Edit.Name = "button_Edit";
            button_Edit.Size = new Size(100, 40);
            button_Edit.TabIndex = 4;
            button_Edit.Text = "Edit";
            button_Edit.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            button_Cancel.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Cancel.Location = new Point(370, 10);
            button_Cancel.Margin = new Padding(10);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(100, 40);
            button_Cancel.TabIndex = 3;
            button_Cancel.Text = "Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(250, 10);
            button1.Margin = new Padding(10);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 2;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            // 
            // button_Adjustment
            // 
            button_Adjustment.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Adjustment.Location = new Point(130, 10);
            button_Adjustment.Margin = new Padding(10);
            button_Adjustment.Name = "button_Adjustment";
            button_Adjustment.Size = new Size(100, 40);
            button_Adjustment.TabIndex = 1;
            button_Adjustment.Text = "Adjustment";
            button_Adjustment.UseVisualStyleBackColor = true;
            // 
            // button_Add
            // 
            button_Add.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Add.Location = new Point(10, 10);
            button_Add.Margin = new Padding(10);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(100, 40);
            button_Add.TabIndex = 5;
            button_Add.Text = "Add New";
            button_Add.UseVisualStyleBackColor = true;
            // 
            // panel_ComponentControl
            // 
            panel_ComponentControl.Controls.Add(customPanel_ContainerComp);
            panel_ComponentControl.Controls.Add(panel_SpacerContainerComp);
            panel_ComponentControl.Controls.Add(printingReferences);
            panel_ComponentControl.Dock = DockStyle.Top;
            panel_ComponentControl.Location = new Point(0, 100);
            panel_ComponentControl.Margin = new Padding(0);
            panel_ComponentControl.Name = "panel_ComponentControl";
            panel_ComponentControl.Size = new Size(1144, 188);
            panel_ComponentControl.TabIndex = 21;
            // 
            // printingReferences
            // 
            printingReferences.Dock = DockStyle.Right;
            printingReferences.Location = new Point(605, 0);
            printingReferences.Margin = new Padding(0);
            printingReferences.MinimumSize = new Size(500, 167);
            printingReferences.Name = "printingReferences";
            printingReferences.Size = new Size(539, 188);
            printingReferences.TabIndex = 14;
            // 
            // panel_SpacerContainerComp
            // 
            panel_SpacerContainerComp.Dock = DockStyle.Right;
            panel_SpacerContainerComp.Location = new Point(600, 0);
            panel_SpacerContainerComp.Margin = new Padding(0);
            panel_SpacerContainerComp.Name = "panel_SpacerContainerComp";
            panel_SpacerContainerComp.Size = new Size(5, 188);
            panel_SpacerContainerComp.TabIndex = 23;
            // 
            // customPanel_ContainerComp
            // 
            customPanel_ContainerComp.Controls.Add(panel6);
            customPanel_ContainerComp.Dock = DockStyle.Fill;
            customPanel_ContainerComp.Location = new Point(0, 0);
            customPanel_ContainerComp.Name = "customPanel_ContainerComp";
            customPanel_ContainerComp.Size = new Size(600, 188);
            customPanel_ContainerComp.TabIndex = 24;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(255, 255, 192);
            panel6.Location = new Point(8, 8);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(2);
            panel6.Size = new Size(179, 66);
            panel6.TabIndex = 23;
            // 
            // grouper_ManufacturerProperties
            // 
            grouper_ManufacturerProperties.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_ManufacturerProperties.BackgroundColor = SystemColors.ButtonHighlight;
            grouper_ManufacturerProperties.BackgroundGradientColor = Color.LightGray;
            grouper_ManufacturerProperties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_ManufacturerProperties.BorderColor = Color.Black;
            grouper_ManufacturerProperties.BorderThickness = 1F;
            grouper_ManufacturerProperties.Controls.Add(panel_LabelsManufacturerProperties);
            grouper_ManufacturerProperties.CustomGroupBoxColor = Color.White;
            grouper_ManufacturerProperties.Dock = DockStyle.Top;
            grouper_ManufacturerProperties.GroupImage = null;
            grouper_ManufacturerProperties.GroupTitle = "Manufacturer Properties";
            grouper_ManufacturerProperties.Location = new Point(0, 288);
            grouper_ManufacturerProperties.Margin = new Padding(0);
            grouper_ManufacturerProperties.MinimumSize = new Size(0, 100);
            grouper_ManufacturerProperties.Name = "grouper_ManufacturerProperties";
            grouper_ManufacturerProperties.Padding = new Padding(10, 30, 10, 10);
            grouper_ManufacturerProperties.PaintGroupBox = false;
            grouper_ManufacturerProperties.RoundCorners = 10;
            grouper_ManufacturerProperties.ShadowColor = Color.DarkGray;
            grouper_ManufacturerProperties.ShadowControl = false;
            grouper_ManufacturerProperties.ShadowThickness = 3;
            grouper_ManufacturerProperties.Size = new Size(1144, 100);
            grouper_ManufacturerProperties.TabIndex = 20;
            // 
            // panel_LabelsManufacturerProperties
            // 
            panel_LabelsManufacturerProperties.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_LabelsManufacturerProperties.Controls.Add(panel1);
            panel_LabelsManufacturerProperties.Controls.Add(panel9);
            panel_LabelsManufacturerProperties.Controls.Add(panel8);
            panel_LabelsManufacturerProperties.Controls.Add(panel7);
            panel_LabelsManufacturerProperties.Dock = DockStyle.Top;
            panel_LabelsManufacturerProperties.Location = new Point(10, 30);
            panel_LabelsManufacturerProperties.Margin = new Padding(0);
            panel_LabelsManufacturerProperties.Name = "panel_LabelsManufacturerProperties";
            panel_LabelsManufacturerProperties.Size = new Size(1124, 56);
            panel_LabelsManufacturerProperties.TabIndex = 9;
            // 
            // panel7
            // 
            panel7.Controls.Add(label_Model_Number);
            panel7.Controls.Add(comboBox_Manufacturer);
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(0, 0);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(2);
            panel7.Size = new Size(263, 56);
            panel7.TabIndex = 23;
            // 
            // comboBox_Manufacturer
            // 
            comboBox_Manufacturer.Dock = DockStyle.Bottom;
            comboBox_Manufacturer.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Manufacturer.FormattingEnabled = true;
            comboBox_Manufacturer.Location = new Point(2, 28);
            comboBox_Manufacturer.Margin = new Padding(10);
            comboBox_Manufacturer.Name = "comboBox_Manufacturer";
            comboBox_Manufacturer.Size = new Size(259, 26);
            comboBox_Manufacturer.TabIndex = 3;
            // 
            // label_Model_Number
            // 
            label_Model_Number.AutoSize = true;
            label_Model_Number.Dock = DockStyle.Top;
            label_Model_Number.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Model_Number.Location = new Point(2, 2);
            label_Model_Number.Margin = new Padding(10);
            label_Model_Number.Name = "label_Model_Number";
            label_Model_Number.Size = new Size(124, 20);
            label_Model_Number.TabIndex = 4;
            label_Model_Number.Text = "Model Number";
            // 
            // panel8
            // 
            panel8.Controls.Add(label_Manufacturer);
            panel8.Controls.Add(comboBox_Supplier);
            panel8.Dock = DockStyle.Left;
            panel8.Location = new Point(263, 0);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(2);
            panel8.Size = new Size(263, 56);
            panel8.TabIndex = 24;
            // 
            // comboBox_Supplier
            // 
            comboBox_Supplier.Dock = DockStyle.Bottom;
            comboBox_Supplier.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Supplier.FormattingEnabled = true;
            comboBox_Supplier.Location = new Point(2, 28);
            comboBox_Supplier.Margin = new Padding(10);
            comboBox_Supplier.Name = "comboBox_Supplier";
            comboBox_Supplier.Size = new Size(259, 26);
            comboBox_Supplier.TabIndex = 7;
            // 
            // label_Manufacturer
            // 
            label_Manufacturer.AutoSize = true;
            label_Manufacturer.Dock = DockStyle.Top;
            label_Manufacturer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Manufacturer.Location = new Point(2, 2);
            label_Manufacturer.Margin = new Padding(10);
            label_Manufacturer.Name = "label_Manufacturer";
            label_Manufacturer.Size = new Size(116, 20);
            label_Manufacturer.TabIndex = 2;
            label_Manufacturer.Text = "Manufacturer";
            // 
            // panel9
            // 
            panel9.Controls.Add(label_Supplier);
            panel9.Controls.Add(comboBox_Model_Number);
            panel9.Dock = DockStyle.Left;
            panel9.Location = new Point(526, 0);
            panel9.Margin = new Padding(0);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(2);
            panel9.Size = new Size(314, 56);
            panel9.TabIndex = 23;
            // 
            // comboBox_Model_Number
            // 
            comboBox_Model_Number.Dock = DockStyle.Bottom;
            comboBox_Model_Number.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_Model_Number.FormattingEnabled = true;
            comboBox_Model_Number.Location = new Point(2, 28);
            comboBox_Model_Number.Margin = new Padding(10);
            comboBox_Model_Number.Name = "comboBox_Model_Number";
            comboBox_Model_Number.Size = new Size(310, 26);
            comboBox_Model_Number.TabIndex = 5;
            // 
            // label_Supplier
            // 
            label_Supplier.AutoSize = true;
            label_Supplier.Dock = DockStyle.Top;
            label_Supplier.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Supplier.Location = new Point(2, 2);
            label_Supplier.Margin = new Padding(10);
            label_Supplier.Name = "label_Supplier";
            label_Supplier.Size = new Size(75, 20);
            label_Supplier.TabIndex = 6;
            label_Supplier.Text = "Supplier";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(840, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(2);
            panel1.Size = new Size(284, 56);
            panel1.TabIndex = 22;
            // 
            // tabPage_TreeViewSetting
            // 
            tabPage_TreeViewSetting.Location = new Point(4, 4);
            tabPage_TreeViewSetting.Margin = new Padding(1);
            tabPage_TreeViewSetting.Name = "tabPage_TreeViewSetting";
            tabPage_TreeViewSetting.Padding = new Padding(0, 3, 0, 0);
            tabPage_TreeViewSetting.Size = new Size(1148, 478);
            tabPage_TreeViewSetting.TabIndex = 4;
            tabPage_TreeViewSetting.Text = "TreeViewSetting";
            tabPage_TreeViewSetting.UseVisualStyleBackColor = true;
            // 
            // tabPage_TimeLine
            // 
            tabPage_TimeLine.Controls.Add(blazorWebView_TimeLine);
            tabPage_TimeLine.Location = new Point(4, 4);
            tabPage_TimeLine.Margin = new Padding(1);
            tabPage_TimeLine.Name = "tabPage_TimeLine";
            tabPage_TimeLine.Padding = new Padding(1);
            tabPage_TimeLine.Size = new Size(1148, 478);
            tabPage_TimeLine.TabIndex = 1;
            tabPage_TimeLine.Text = "TimeLine";
            tabPage_TimeLine.UseVisualStyleBackColor = true;
            // 
            // tabPage_Location
            // 
            tabPage_Location.Controls.Add(thumbViewer_Location);
            tabPage_Location.Location = new Point(4, 4);
            tabPage_Location.Margin = new Padding(1);
            tabPage_Location.Name = "tabPage_Location";
            tabPage_Location.Padding = new Padding(1);
            tabPage_Location.Size = new Size(1148, 478);
            tabPage_Location.TabIndex = 2;
            tabPage_Location.Text = " Location";
            tabPage_Location.UseVisualStyleBackColor = true;
            // 
            // thumbViewer_Location
            // 
            thumbViewer_Location.DefaultAddress = "";
            thumbViewer_Location.Dock = DockStyle.Fill;
            thumbViewer_Location.Location = new Point(1, 1);
            thumbViewer_Location.Margin = new Padding(1);
            thumbViewer_Location.Name = "thumbViewer_Location";
            thumbViewer_Location.PathFromPartNumber = null;
            thumbViewer_Location.Size = new Size(1146, 476);
            thumbViewer_Location.SplitterDistance = 88;
            thumbViewer_Location.TabIndex = 1;
            thumbViewer_Location.ThumbNailHeight = 70;
            thumbViewer_Location.ThumbNailWidth = 92;
            // 
            // tabPage_Pictures
            // 
            tabPage_Pictures.Controls.Add(thumbViewer_Pictures);
            tabPage_Pictures.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage_Pictures.Location = new Point(4, 4);
            tabPage_Pictures.Margin = new Padding(1);
            tabPage_Pictures.Name = "tabPage_Pictures";
            tabPage_Pictures.Padding = new Padding(1);
            tabPage_Pictures.Size = new Size(1148, 478);
            tabPage_Pictures.TabIndex = 0;
            tabPage_Pictures.Text = " Pictures";
            tabPage_Pictures.UseVisualStyleBackColor = true;
            // 
            // thumbViewer_Pictures
            // 
            thumbViewer_Pictures.DefaultAddress = "";
            thumbViewer_Pictures.Dock = DockStyle.Fill;
            thumbViewer_Pictures.Location = new Point(1, 1);
            thumbViewer_Pictures.Margin = new Padding(1);
            thumbViewer_Pictures.Name = "thumbViewer_Pictures";
            thumbViewer_Pictures.PathFromPartNumber = null;
            thumbViewer_Pictures.Size = new Size(1146, 476);
            thumbViewer_Pictures.SplitterDistance = 88;
            thumbViewer_Pictures.TabIndex = 0;
            thumbViewer_Pictures.ThumbNailHeight = 70;
            thumbViewer_Pictures.ThumbNailWidth = 92;
            // 
            // TabControl_Inventory
            // 
            TabControl_Inventory.Controls.Add(tabPage_Pictures);
            TabControl_Inventory.Controls.Add(tabPage_Location);
            TabControl_Inventory.Controls.Add(tabPage_TimeLine);
            TabControl_Inventory.Controls.Add(tabPage_NoteEditor);
            TabControl_Inventory.Controls.Add(tabPage_TreeViewSetting);
            TabControl_Inventory.Controls.Add(tabPage_AddNewItem);
            TabControl_Inventory.Controls.Add(tabPage_Test);
            TabControl_Inventory.Controls.Add(tabPage_UpDateModifCompValue);
            TabControl_Inventory.DisplayStyle = TabStyle.VisualStudio;
            // 
            // 
            // 
            TabControl_Inventory.DisplayStyleProvider.BorderColor = SystemColors.ControlDark;
            TabControl_Inventory.DisplayStyleProvider.BorderColorHot = SystemColors.ControlDark;
            TabControl_Inventory.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(127, 157, 185);
            TabControl_Inventory.DisplayStyleProvider.CloserColor = Color.DarkGray;
            TabControl_Inventory.DisplayStyleProvider.TextColor = SystemColors.ControlText;
            TabControl_Inventory.DisplayStyleProvider.TextColorDisabled = SystemColors.ControlDark;
            TabControl_Inventory.DisplayStyleProvider.TextColorSelected = SystemColors.ControlText;
            TabControl_Inventory.Dock = DockStyle.Fill;
            TabControl_Inventory.Location = new Point(0, 0);
            TabControl_Inventory.Margin = new Padding(1);
            TabControl_Inventory.Name = "TabControl_Inventory";
            TabControl_Inventory.SelectedIndex = 0;
            TabControl_Inventory.Size = new Size(1156, 510);
            TabControl_Inventory.TabIndex = 0;
            // 
            // tabPage_NoteEditor
            // 
            tabPage_NoteEditor.Controls.Add(blazorWebView1);
            tabPage_NoteEditor.Location = new Point(4, 4);
            tabPage_NoteEditor.Margin = new Padding(1);
            tabPage_NoteEditor.Name = "tabPage_NoteEditor";
            tabPage_NoteEditor.Size = new Size(1148, 478);
            tabPage_NoteEditor.TabIndex = 3;
            tabPage_NoteEditor.Text = "Note Editor";
            // 
            // blazorWebView1
            // 
            blazorWebView1.Dock = DockStyle.Fill;
            blazorWebView1.Location = new Point(0, 0);
            blazorWebView1.Margin = new Padding(1);
            blazorWebView1.Name = "blazorWebView1";
            blazorWebView1.Size = new Size(1148, 478);
            blazorWebView1.TabIndex = 20;
            // 
            // tabPage_Test
            // 
            tabPage_Test.Location = new Point(4, 4);
            tabPage_Test.Margin = new Padding(1);
            tabPage_Test.Name = "tabPage_Test";
            tabPage_Test.Size = new Size(1148, 478);
            tabPage_Test.TabIndex = 6;
            tabPage_Test.Text = "tabPage_Test";
            tabPage_Test.UseVisualStyleBackColor = true;
            // 
            // grouper_ItemProperties
            // 
            grouper_ItemProperties.BackgroundColor = Color.LightGray;
            grouper_ItemProperties.BackgroundGradientColor = Color.DarkGray;
            grouper_ItemProperties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_ItemProperties.BackgroundImageLayout = ImageLayout.None;
            grouper_ItemProperties.BorderColor = Color.Black;
            grouper_ItemProperties.BorderThickness = 1F;
            grouper_ItemProperties.Controls.Add(flowLayoutPanel_ItemsProperties);
            grouper_ItemProperties.CustomGroupBoxColor = Color.White;
            grouper_ItemProperties.Dock = DockStyle.Top;
            grouper_ItemProperties.GroupImage = null;
            grouper_ItemProperties.GroupTitle = "";
            grouper_ItemProperties.Location = new Point(1, 1);
            grouper_ItemProperties.Margin = new Padding(0);
            grouper_ItemProperties.MinimumSize = new Size(1, 1);
            grouper_ItemProperties.Name = "grouper_ItemProperties";
            grouper_ItemProperties.Padding = new Padding(1);
            grouper_ItemProperties.PaintGroupBox = false;
            grouper_ItemProperties.RoundCorners = 10;
            grouper_ItemProperties.ShadowColor = Color.DarkGray;
            grouper_ItemProperties.ShadowControl = false;
            grouper_ItemProperties.ShadowThickness = 3;
            grouper_ItemProperties.Size = new Size(1146, 1);
            grouper_ItemProperties.TabIndex = 20;
            // 
            // flowLayoutPanel_ItemsProperties
            // 
            flowLayoutPanel_ItemsProperties.Controls.Add(comboBoxExtended_Description);
            flowLayoutPanel_ItemsProperties.Controls.Add(comboBoxExtended_Status);
            flowLayoutPanel_ItemsProperties.Controls.Add(comboBoxExtended1);
            flowLayoutPanel_ItemsProperties.Controls.Add(comboBoxExtended_PartNumber);
            flowLayoutPanel_ItemsProperties.Dock = DockStyle.Fill;
            flowLayoutPanel_ItemsProperties.Location = new Point(1, 1);
            flowLayoutPanel_ItemsProperties.Margin = new Padding(0);
            flowLayoutPanel_ItemsProperties.MinimumSize = new Size(4, 1);
            flowLayoutPanel_ItemsProperties.Name = "flowLayoutPanel_ItemsProperties";
            flowLayoutPanel_ItemsProperties.Padding = new Padding(1, 0, 0, 0);
            flowLayoutPanel_ItemsProperties.Size = new Size(1144, 1);
            flowLayoutPanel_ItemsProperties.TabIndex = 13;
            // 
            // comboBoxExtended_PartNumber
            // 
            comboBoxExtended_PartNumber.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboBoxExtended_PartNumber.Location = new Point(35, 5);
            comboBoxExtended_PartNumber.Margin = new Padding(4, 5, 4, 5);
            comboBoxExtended_PartNumber.MinimumSize = new Size(2, 1);
            comboBoxExtended_PartNumber.Name = "comboBoxExtended_PartNumber";
            comboBoxExtended_PartNumber.Size = new Size(2, 1);
            comboBoxExtended_PartNumber.TabIndex = 7;
            comboBoxExtended_PartNumber.Tag = "25";
            // 
            // comboBoxExtended1
            // 
            comboBoxExtended1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboBoxExtended1.Location = new Point(25, 5);
            comboBoxExtended1.Margin = new Padding(4, 5, 4, 5);
            comboBoxExtended1.MinimumSize = new Size(2, 1);
            comboBoxExtended1.Name = "comboBoxExtended1";
            comboBoxExtended1.Size = new Size(2, 1);
            comboBoxExtended1.TabIndex = 9;
            comboBoxExtended1.Tag = "15";
            // 
            // comboBoxExtended_Status
            // 
            comboBoxExtended_Status.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboBoxExtended_Status.Location = new Point(15, 5);
            comboBoxExtended_Status.Margin = new Padding(4, 5, 4, 5);
            comboBoxExtended_Status.MinimumSize = new Size(2, 1);
            comboBoxExtended_Status.Name = "comboBoxExtended_Status";
            comboBoxExtended_Status.Size = new Size(2, 1);
            comboBoxExtended_Status.TabIndex = 6;
            comboBoxExtended_Status.Tag = "20";
            // 
            // comboBoxExtended_Description
            // 
            comboBoxExtended_Description.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboBoxExtended_Description.Location = new Point(5, 5);
            comboBoxExtended_Description.Margin = new Padding(4, 5, 4, 5);
            comboBoxExtended_Description.MinimumSize = new Size(2, 1);
            comboBoxExtended_Description.Name = "comboBoxExtended_Description";
            comboBoxExtended_Description.Size = new Size(2, 1);
            comboBoxExtended_Description.TabIndex = 8;
            comboBoxExtended_Description.Tag = "40";
            // 
            // grouper_NewItemButtons
            // 
            grouper_NewItemButtons.BackgroundColor = Color.LightGray;
            grouper_NewItemButtons.BackgroundGradientColor = Color.DarkGray;
            grouper_NewItemButtons.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_NewItemButtons.BackgroundImageLayout = ImageLayout.None;
            grouper_NewItemButtons.BorderColor = Color.Black;
            grouper_NewItemButtons.BorderThickness = 1F;
            grouper_NewItemButtons.Controls.Add(flowLayoutPanel_Buttons);
            grouper_NewItemButtons.CustomGroupBoxColor = Color.White;
            grouper_NewItemButtons.Dock = DockStyle.Bottom;
            grouper_NewItemButtons.GroupImage = null;
            grouper_NewItemButtons.GroupTitle = "";
            grouper_NewItemButtons.Location = new Point(1, 476);
            grouper_NewItemButtons.Margin = new Padding(0);
            grouper_NewItemButtons.MinimumSize = new Size(4, 1);
            grouper_NewItemButtons.Name = "grouper_NewItemButtons";
            grouper_NewItemButtons.Padding = new Padding(1);
            grouper_NewItemButtons.PaintGroupBox = false;
            grouper_NewItemButtons.RoundCorners = 10;
            grouper_NewItemButtons.ShadowColor = Color.DarkGray;
            grouper_NewItemButtons.ShadowControl = false;
            grouper_NewItemButtons.ShadowThickness = 3;
            grouper_NewItemButtons.Size = new Size(1146, 1);
            grouper_NewItemButtons.TabIndex = 21;
            // 
            // flowLayoutPanel_Buttons
            // 
            flowLayoutPanel_Buttons.AutoSize = true;
            flowLayoutPanel_Buttons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_Buttons.BackgroundImageLayout = ImageLayout.None;
            flowLayoutPanel_Buttons.Controls.Add(button_AddNew);
            flowLayoutPanel_Buttons.Controls.Add(button_Save);
            flowLayoutPanel_Buttons.Controls.Add(button_Delete);
            flowLayoutPanel_Buttons.Dock = DockStyle.Fill;
            flowLayoutPanel_Buttons.Location = new Point(1, 1);
            flowLayoutPanel_Buttons.Margin = new Padding(0);
            flowLayoutPanel_Buttons.MinimumSize = new Size(0, 1);
            flowLayoutPanel_Buttons.Name = "flowLayoutPanel_Buttons";
            flowLayoutPanel_Buttons.Padding = new Padding(1);
            flowLayoutPanel_Buttons.Size = new Size(1144, 1);
            flowLayoutPanel_Buttons.TabIndex = 13;
            // 
            // button_Delete
            // 
            button_Delete.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Delete.Location = new Point(10, 2);
            button_Delete.Margin = new Padding(1);
            button_Delete.MinimumSize = new Size(2, 1);
            button_Delete.Name = "button_Delete";
            button_Delete.Size = new Size(2, 1);
            button_Delete.TabIndex = 3;
            button_Delete.Text = "Delete";
            button_Delete.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            button_Save.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Save.Location = new Point(6, 2);
            button_Save.Margin = new Padding(1);
            button_Save.MinimumSize = new Size(2, 1);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(2, 1);
            button_Save.TabIndex = 2;
            button_Save.Text = "Save";
            button_Save.UseVisualStyleBackColor = true;
            // 
            // button_AddNew
            // 
            button_AddNew.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_AddNew.Location = new Point(2, 2);
            button_AddNew.Margin = new Padding(1);
            button_AddNew.MinimumSize = new Size(2, 1);
            button_AddNew.Name = "button_AddNew";
            button_AddNew.Size = new Size(2, 1);
            button_AddNew.TabIndex = 5;
            button_AddNew.Text = "Add New";
            button_AddNew.UseVisualStyleBackColor = true;
            // 
            // tabPage_AddNewItem
            // 
            tabPage_AddNewItem.Controls.Add(grouper_NewItemButtons);
            tabPage_AddNewItem.Controls.Add(grouper_ItemProperties);
            tabPage_AddNewItem.Location = new Point(4, 4);
            tabPage_AddNewItem.Margin = new Padding(1);
            tabPage_AddNewItem.Name = "tabPage_AddNewItem";
            tabPage_AddNewItem.Padding = new Padding(1);
            tabPage_AddNewItem.Size = new Size(1148, 478);
            tabPage_AddNewItem.TabIndex = 5;
            tabPage_AddNewItem.Text = "Add New Item";
            tabPage_AddNewItem.UseVisualStyleBackColor = true;
            // 
            // blazorWebView_TimeLine
            // 
            blazorWebView_TimeLine.Dock = DockStyle.Fill;
            blazorWebView_TimeLine.Location = new Point(1, 1);
            blazorWebView_TimeLine.Margin = new Padding(1);
            blazorWebView_TimeLine.Name = "blazorWebView_TimeLine";
            blazorWebView_TimeLine.Size = new Size(1146, 476);
            blazorWebView_TimeLine.TabIndex = 21;
            // 
            // StockRoom_Inventory
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1678, 800);
            Controls.Add(splitContainerHorizontal);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 2, 3, 2);
            Name = "StockRoom_Inventory";
            Load += StockRoomInventoryLoad;
            Shown += StockRoomInventoryShown;
            ((System.ComponentModel.ISupportInitialize)BindingSourceTreeViewBase).EndInit();
            _contextMenuStripTreeView.ResumeLayout(false);
            contextMenuStripPicturesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataView_StockRoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)_bindingSource_table_StockroomTreeView).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataView_TreeView).EndInit();
            ((System.ComponentModel.ISupportInitialize)_bindingSource_StockRoom).EndInit();
            splitContainerHorizontal.Panel1.ResumeLayout(false);
            splitContainerHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerHorizontal).EndInit();
            splitContainerHorizontal.ResumeLayout(false);
            splitContainerVertical.Panel1.ResumeLayout(false);
            splitContainerVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerVertical).EndInit();
            splitContainerVertical.ResumeLayout(false);
            tabPage_UpDateModifCompValue.ResumeLayout(false);
            grouper_ComponentProperties.ResumeLayout(false);
            grouper_ComponentProperties.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel_LabelsComponentsProperties.ResumeLayout(false);
            panel_LabelsComponentsProperties.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            panel_ComponentControl.ResumeLayout(false);
            customPanel_ContainerComp.ResumeLayout(false);
            grouper_ManufacturerProperties.ResumeLayout(false);
            panel_LabelsManufacturerProperties.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tabPage_TimeLine.ResumeLayout(false);
            tabPage_Location.ResumeLayout(false);
            tabPage_Pictures.ResumeLayout(false);
            TabControl_Inventory.ResumeLayout(false);
            tabPage_NoteEditor.ResumeLayout(false);
            grouper_ItemProperties.ResumeLayout(false);
            flowLayoutPanel_ItemsProperties.ResumeLayout(false);
            grouper_NewItemButtons.ResumeLayout(false);
            grouper_NewItemButtons.PerformLayout();
            flowLayoutPanel_Buttons.ResumeLayout(false);
            tabPage_AddNewItem.ResumeLayout(false);
            ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.SplitContainer splitContainerHorizontal;
        private System.Windows.Forms.SplitContainer splitContainerVertical;
        private System.Data.DataView dataView_StockRoom;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStripTreeView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CollapseAll;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ExpandAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_singleExpandedNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_showSettingDialog;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_multipleExpandedNodes;
        private DataGridViewExtended dataGridViewExtended;
        private System.Windows.Forms.BindingSource _bindingSource_table_StockroomTreeView;
        private System.Data.DataView dataView_TreeView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_AddNewComponent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.BindingSource _bindingSource_StockRoom;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SetPictures;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_HotItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPicturesBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SetToNoPicturesFound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddANewPictures;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyFileToTheClickBoard;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyToANewFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyImageToTheClipBoard;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_GroupByThisColumn;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_PrintCompLabel;
        private DataTreeViewToAddCancelDelete dataTreeViewToAdd_Cancel_Delete;
        private ToolStripMenuItem toolStripMenuItem_Border;
        private ToolStripMenuItem toolStripMenuItem_Translucent;
        private ToolStripMenuItem toolStripMenuItem_TextColor;
        private ToolStripMenuItem toolStripMenuItem_Lightbox;
        private ToolStripMenuItem toolStripMenuItem_None;
        private ToolStripMenuItem toolStripMenuItem_FullRowSelect;
        private ToolStripMenuItem timeLineToolStripMenuItem;
        private CustomTabControl TabControl_Inventory;
        private TabPage tabPage_Pictures;
        private ThumbViewer thumbViewer_Pictures;
        private TabPage tabPage_Location;
        private ThumbViewer thumbViewer_Location;
        private TabPage tabPage_TimeLine;
        private TabPage tabPage_TreeViewSetting;
        private TabPage tabPage_UpDateModifCompValue;
        private CodeVendor.Controls.Grouper grouper_ManufacturerProperties;
        private Panel panel_LabelsManufacturerProperties;
        private Panel panel1;
        private Panel panel9;
        private Label label_Supplier;
        private ComboBox comboBox_Model_Number;
        private Panel panel8;
        private Label label_Manufacturer;
        private ComboBox comboBox_Supplier;
        private Panel panel7;
        private Label label_Model_Number;
        private ComboBox comboBox_Manufacturer;
        private Panel panel_ComponentControl;
        private CustomPanelDoubleBuffered customPanel_ContainerComp;
        private Panel panel6;
        private Panel panel_SpacerContainerComp;
        private PrintingReferences printingReferences;
        private FlowLayoutPanel flowLayoutPanel;
        private Button button_Add;
        private Button button_Adjustment;
        private Button button1;
        private Button button_Cancel;
        private Button button_Edit;
        private Button button_Add_Other;
        private CodeVendor.Controls.Grouper grouper_ComponentProperties;
        private Panel panel3;
        private Panel panel5;
        private ComboBox comboBox2;
        private Label label_NumberofReelsOrBoxes;
        private Panel panel4;
        private ComboBox comboBox1;
        private Label label_Received_Quantity;
        private Panel panel_LabelsComponentsProperties;
        private TextBox textBoxUpDateModifPartNumber;
        private Label label_PartNumber;
        private Panel panel2;
        private DateTimePicker dateTimePicker;
        private Label label_Received_Date;
        private TabPage tabPage_NoteEditor;
        private BlazorWebView blazorWebView1;
        private TabPage tabPage_AddNewItem;
        private CodeVendor.Controls.Grouper grouper_NewItemButtons;
        private FlowLayoutPanel flowLayoutPanel_Buttons;
        private Button button_AddNew;
        private Button button_Save;
        private Button button_Delete;
        private CodeVendor.Controls.Grouper grouper_ItemProperties;
        private FlowLayoutPanel flowLayoutPanel_ItemsProperties;
        private Controls.ComboBoxExtended.ComboBoxExtended comboBoxExtended_Description;
        private Controls.ComboBoxExtended.ComboBoxExtended comboBoxExtended_Status;
        private Controls.ComboBoxExtended.ComboBoxExtended comboBoxExtended1;
        private Controls.ComboBoxExtended.ComboBoxExtended comboBoxExtended_PartNumber;
        private TabPage tabPage_Test;
        private BlazorWebView blazorWebView_TimeLine;
    }
}
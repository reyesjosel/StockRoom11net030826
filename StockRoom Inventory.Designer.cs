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
            TabControl_Inventory = new CustomTabControl();
            tabPage_AddNewItem = new TabPage();
            grouper_NewItemButtons = new CodeVendor.Controls.Grouper();
            flowLayoutPanel_Buttons = new FlowLayoutPanel();
            button_AddNew = new Button();
            button_Save = new Button();
            button_Delete = new Button();
            grouper_ItemProperties = new CodeVendor.Controls.Grouper();
            flowLayoutPanel_ItemsProperties = new FlowLayoutPanel();
            comboBoxExtended_Status = new StockRoom11net.Controls.ComboBoxExtended.ComboBoxExtended();
            comboBoxExtended1 = new StockRoom11net.Controls.ComboBoxExtended.ComboBoxExtended();
            comboBoxExtended_Description = new StockRoom11net.Controls.ComboBoxExtended.ComboBoxExtended();
            comboBoxExtended_PartNumber = new StockRoom11net.Controls.ComboBoxExtended.ComboBoxExtended();
            tabPage_Pictures = new TabPage();
            thumbViewer_Pictures = new ThumbViewer();
            tabPage_Location = new TabPage();
            thumbViewer_Location = new ThumbViewer();
            tabPage_TimeLine = new TabPage();
            blazorWebView_TimeLine = new BlazorWebView();
            tabPage_NoteEditor = new TabPage();
            blazorWebView1 = new BlazorWebView();
            tabPage_TreeViewSetting = new TabPage();
            tabPage_Test = new TabPage();
            tabPage_UpDateModifCompValue = new TabPage();
            panel_ContainerUpDateModifValue = new Panel();
            grouper_PrintingLabels = new CodeVendor.Controls.Grouper();
            wrapperpanel_ComponentControl = new Panel();
            grouper_PrintingReferences = new CodeVendor.Controls.Grouper();
            panel_EnablePrints = new Panel();
            panel_Reels = new Panel();
            checkBox_printLabels = new CheckBox();
            panel_Description = new Panel();
            label_DescriptionToPrint = new Label();
            textBox_DescriptionToPrint = new TextBox();
            grouper_BarCodeRegion = new CodeVendor.Controls.Grouper();
            label_LabelInformation = new Label();
            grouper_LabelBarCode = new CodeVendor.Controls.Grouper();
            label_Description = new Label();
            label_HumanReadableInformation = new Label();
            pictureBox_BarCode_Image = new PictureBox();
            customPanelDoubleBuffered = new CustomPanelDoubleBuffered();
            grouper_ManufacturerProperties = new CodeVendor.Controls.Grouper();
            wrapperpanel_ManufacturerProperties = new Panel();
            panel1 = new Panel();
            textBox4 = new TextBox();
            panel_Supplier = new Panel();
            textBox_Supplier = new TextBox();
            label_Supplier = new Label();
            panel_Manufacturer = new Panel();
            textBox_Manufacturer = new TextBox();
            label_Manufacturer = new Label();
            panel_ModelNumber = new Panel();
            textBox_ModelNumber = new TextBox();
            label_ModelNumber = new Label();
            grouper_ComponentProperties = new CodeVendor.Controls.Grouper();
            wrapperpanel_ComponentProperties = new Panel();
            panel_NumberofReelsOrBoxes = new Panel();
            label_NumberofReelsOrBoxes = new Label();
            textBox_NumberofReelsOrBoxes = new TextBox();
            panel_ReceivedDate = new Panel();
            label_Received_Date = new Label();
            dateTimePicker_ReceivedDate = new DateTimePicker();
            panel4_ReceivedQuantity = new Panel();
            label_ReceivedQuantity = new Label();
            textBox_ReceivedQuantity = new TextBox();
            panel_PartNumber = new Panel();
            label_PartNumber = new Label();
            textBox_PartNumber = new TextBox();
            dataGridViewExtended = new DataGridViewExtended();
            ToolStripMenuItem_PrintCompLabel = new ToolStripMenuItem();
            ToolStripMenuItem_GroupByThisColumn = new ToolStripMenuItem();
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
            TabControl_Inventory.SuspendLayout();
            tabPage_AddNewItem.SuspendLayout();
            grouper_NewItemButtons.SuspendLayout();
            flowLayoutPanel_Buttons.SuspendLayout();
            grouper_ItemProperties.SuspendLayout();
            flowLayoutPanel_ItemsProperties.SuspendLayout();
            tabPage_Pictures.SuspendLayout();
            tabPage_Location.SuspendLayout();
            tabPage_TimeLine.SuspendLayout();
            tabPage_NoteEditor.SuspendLayout();
            tabPage_UpDateModifCompValue.SuspendLayout();
            panel_ContainerUpDateModifValue.SuspendLayout();
            grouper_PrintingLabels.SuspendLayout();
            wrapperpanel_ComponentControl.SuspendLayout();
            grouper_PrintingReferences.SuspendLayout();
            panel_EnablePrints.SuspendLayout();
            panel_Reels.SuspendLayout();
            panel_Description.SuspendLayout();
            grouper_BarCodeRegion.SuspendLayout();
            grouper_LabelBarCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_BarCode_Image).BeginInit();
            grouper_ManufacturerProperties.SuspendLayout();
            wrapperpanel_ManufacturerProperties.SuspendLayout();
            panel1.SuspendLayout();
            panel_Supplier.SuspendLayout();
            panel_Manufacturer.SuspendLayout();
            panel_ModelNumber.SuspendLayout();
            grouper_ComponentProperties.SuspendLayout();
            wrapperpanel_ComponentProperties.SuspendLayout();
            panel_NumberofReelsOrBoxes.SuspendLayout();
            panel_ReceivedDate.SuspendLayout();
            panel4_ReceivedQuantity.SuspendLayout();
            panel_PartNumber.SuspendLayout();
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
            // TabControl_Inventory
            // 
            TabControl_Inventory.Controls.Add(tabPage_AddNewItem);
            TabControl_Inventory.Controls.Add(tabPage_Pictures);
            TabControl_Inventory.Controls.Add(tabPage_Location);
            TabControl_Inventory.Controls.Add(tabPage_TimeLine);
            TabControl_Inventory.Controls.Add(tabPage_NoteEditor);
            TabControl_Inventory.Controls.Add(tabPage_TreeViewSetting);
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
            // grouper_NewItemButtons
            // 
            grouper_NewItemButtons.AutoSize = true;
            grouper_NewItemButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_NewItemButtons.BackgroundColor = Color.LightGray;
            grouper_NewItemButtons.BackgroundGradientColor = Color.DarkGray;
            grouper_NewItemButtons.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_NewItemButtons.BackgroundImageLayout = ImageLayout.None;
            grouper_NewItemButtons.BorderColor = Color.Black;
            grouper_NewItemButtons.BorderThickness = 1F;
            grouper_NewItemButtons.Controls.Add(flowLayoutPanel_Buttons);
            grouper_NewItemButtons.CustomGroupBoxColor = Color.White;
            grouper_NewItemButtons.Dock = DockStyle.Bottom;
            grouper_NewItemButtons.GroupTitle = "";
            grouper_NewItemButtons.Location = new Point(1, 352);
            grouper_NewItemButtons.Margin = new Padding(0);
            grouper_NewItemButtons.MinimumSize = new Size(3, 125);
            grouper_NewItemButtons.Name = "grouper_NewItemButtons";
            grouper_NewItemButtons.Padding = new Padding(25);
            grouper_NewItemButtons.PaintGroupBox = false;
            grouper_NewItemButtons.RoundCorners = 10;
            grouper_NewItemButtons.ShadowColor = Color.DarkGray;
            grouper_NewItemButtons.ShadowControl = false;
            grouper_NewItemButtons.ShadowThickness = 3;
            grouper_NewItemButtons.Size = new Size(1146, 125);
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
            flowLayoutPanel_Buttons.Dock = DockStyle.Top;
            flowLayoutPanel_Buttons.Location = new Point(25, 25);
            flowLayoutPanel_Buttons.Margin = new Padding(0);
            flowLayoutPanel_Buttons.MinimumSize = new Size(0, 7);
            flowLayoutPanel_Buttons.Name = "flowLayoutPanel_Buttons";
            flowLayoutPanel_Buttons.Size = new Size(1096, 28);
            flowLayoutPanel_Buttons.TabIndex = 13;
            // 
            // button_AddNew
            // 
            button_AddNew.AutoSize = true;
            button_AddNew.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_AddNew.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_AddNew.Location = new Point(1, 1);
            button_AddNew.Margin = new Padding(1);
            button_AddNew.MinimumSize = new Size(70, 26);
            button_AddNew.Name = "button_AddNew";
            button_AddNew.Size = new Size(78, 26);
            button_AddNew.TabIndex = 5;
            button_AddNew.Text = "Add New";
            button_AddNew.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            button_Save.AutoSize = true;
            button_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_Save.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Save.Location = new Point(81, 1);
            button_Save.Margin = new Padding(1);
            button_Save.MinimumSize = new Size(70, 26);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(70, 26);
            button_Save.TabIndex = 2;
            button_Save.Text = "Save";
            button_Save.UseVisualStyleBackColor = true;
            // 
            // button_Delete
            // 
            button_Delete.AutoSize = true;
            button_Delete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_Delete.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Delete.Location = new Point(153, 1);
            button_Delete.Margin = new Padding(1);
            button_Delete.MinimumSize = new Size(70, 26);
            button_Delete.Name = "button_Delete";
            button_Delete.Size = new Size(70, 26);
            button_Delete.TabIndex = 3;
            button_Delete.Text = "Delete";
            button_Delete.UseVisualStyleBackColor = true;
            // 
            // grouper_ItemProperties
            // 
            grouper_ItemProperties.AutoSize = true;
            grouper_ItemProperties.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_ItemProperties.BackgroundColor = Color.LightGray;
            grouper_ItemProperties.BackgroundGradientColor = Color.DarkGray;
            grouper_ItemProperties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_ItemProperties.BackgroundImageLayout = ImageLayout.None;
            grouper_ItemProperties.BorderColor = Color.Black;
            grouper_ItemProperties.BorderThickness = 1F;
            grouper_ItemProperties.Controls.Add(flowLayoutPanel_ItemsProperties);
            grouper_ItemProperties.CustomGroupBoxColor = Color.White;
            grouper_ItemProperties.Dock = DockStyle.Top;
            grouper_ItemProperties.GroupTitle = "";
            grouper_ItemProperties.Location = new Point(1, 1);
            grouper_ItemProperties.Margin = new Padding(0);
            grouper_ItemProperties.MinimumSize = new Size(1, 125);
            grouper_ItemProperties.Name = "grouper_ItemProperties";
            grouper_ItemProperties.Padding = new Padding(5, 25, 5, 5);
            grouper_ItemProperties.PaintGroupBox = false;
            grouper_ItemProperties.RoundCorners = 10;
            grouper_ItemProperties.ShadowColor = Color.DarkGray;
            grouper_ItemProperties.ShadowControl = false;
            grouper_ItemProperties.ShadowThickness = 3;
            grouper_ItemProperties.Size = new Size(1146, 130);
            grouper_ItemProperties.TabIndex = 20;
            // 
            // flowLayoutPanel_ItemsProperties
            // 
            flowLayoutPanel_ItemsProperties.AutoSize = true;
            flowLayoutPanel_ItemsProperties.Controls.Add(comboBoxExtended_Status);
            flowLayoutPanel_ItemsProperties.Controls.Add(comboBoxExtended1);
            flowLayoutPanel_ItemsProperties.Controls.Add(comboBoxExtended_Description);
            flowLayoutPanel_ItemsProperties.Controls.Add(comboBoxExtended_PartNumber);
            flowLayoutPanel_ItemsProperties.Dock = DockStyle.Top;
            flowLayoutPanel_ItemsProperties.Location = new Point(5, 25);
            flowLayoutPanel_ItemsProperties.Margin = new Padding(0);
            flowLayoutPanel_ItemsProperties.MinimumSize = new Size(0, 100);
            flowLayoutPanel_ItemsProperties.Name = "flowLayoutPanel_ItemsProperties";
            flowLayoutPanel_ItemsProperties.Padding = new Padding(1, 0, 0, 0);
            flowLayoutPanel_ItemsProperties.Size = new Size(1136, 100);
            flowLayoutPanel_ItemsProperties.TabIndex = 13;
            // 
            // comboBoxExtended_Status
            // 
            comboBoxExtended_Status.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboBoxExtended_Status.Dock = DockStyle.Top;
            comboBoxExtended_Status.Location = new Point(4, 2);
            comboBoxExtended_Status.Margin = new Padding(3, 2, 3, 2);
            comboBoxExtended_Status.MinimumSize = new Size(62, 41);
            comboBoxExtended_Status.Name = "comboBoxExtended_Status";
            comboBoxExtended_Status.Size = new Size(200, 60);
            comboBoxExtended_Status.TabIndex = 6;
            comboBoxExtended_Status.Tag = "20";
            // 
            // comboBoxExtended1
            // 
            comboBoxExtended1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboBoxExtended1.Dock = DockStyle.Top;
            comboBoxExtended1.Location = new Point(210, 2);
            comboBoxExtended1.Margin = new Padding(3, 2, 3, 2);
            comboBoxExtended1.MinimumSize = new Size(62, 41);
            comboBoxExtended1.Name = "comboBoxExtended1";
            comboBoxExtended1.Size = new Size(200, 60);
            comboBoxExtended1.TabIndex = 9;
            comboBoxExtended1.Tag = "15";
            // 
            // comboBoxExtended_Description
            // 
            comboBoxExtended_Description.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboBoxExtended_Description.Dock = DockStyle.Top;
            comboBoxExtended_Description.Location = new Point(416, 2);
            comboBoxExtended_Description.Margin = new Padding(3, 2, 3, 2);
            comboBoxExtended_Description.MinimumSize = new Size(62, 41);
            comboBoxExtended_Description.Name = "comboBoxExtended_Description";
            comboBoxExtended_Description.Size = new Size(200, 60);
            comboBoxExtended_Description.TabIndex = 8;
            comboBoxExtended_Description.Tag = "40";
            // 
            // comboBoxExtended_PartNumber
            // 
            comboBoxExtended_PartNumber.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            comboBoxExtended_PartNumber.Dock = DockStyle.Top;
            comboBoxExtended_PartNumber.Location = new Point(622, 2);
            comboBoxExtended_PartNumber.Margin = new Padding(3, 2, 3, 2);
            comboBoxExtended_PartNumber.MinimumSize = new Size(70, 50);
            comboBoxExtended_PartNumber.Name = "comboBoxExtended_PartNumber";
            comboBoxExtended_PartNumber.Size = new Size(200, 60);
            comboBoxExtended_PartNumber.TabIndex = 7;
            comboBoxExtended_PartNumber.Tag = "25";
            // 
            // tabPage_Pictures
            // 
            tabPage_Pictures.Controls.Add(thumbViewer_Pictures);
            tabPage_Pictures.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage_Pictures.Location = new Point(4, 4);
            tabPage_Pictures.Margin = new Padding(1);
            tabPage_Pictures.Name = "tabPage_Pictures";
            tabPage_Pictures.Padding = new Padding(1);
            tabPage_Pictures.Size = new Size(1148, 482);
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
            thumbViewer_Pictures.Size = new Size(1146, 480);
            thumbViewer_Pictures.SplitterDistance = 88;
            thumbViewer_Pictures.TabIndex = 0;
            thumbViewer_Pictures.ThumbNailHeight = 70;
            thumbViewer_Pictures.ThumbNailWidth = 92;
            // 
            // tabPage_Location
            // 
            tabPage_Location.Controls.Add(thumbViewer_Location);
            tabPage_Location.Location = new Point(4, 4);
            tabPage_Location.Margin = new Padding(1);
            tabPage_Location.Name = "tabPage_Location";
            tabPage_Location.Padding = new Padding(1);
            tabPage_Location.Size = new Size(1148, 482);
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
            thumbViewer_Location.Size = new Size(1146, 480);
            thumbViewer_Location.SplitterDistance = 88;
            thumbViewer_Location.TabIndex = 1;
            thumbViewer_Location.ThumbNailHeight = 70;
            thumbViewer_Location.ThumbNailWidth = 92;
            // 
            // tabPage_TimeLine
            // 
            tabPage_TimeLine.Controls.Add(blazorWebView_TimeLine);
            tabPage_TimeLine.Location = new Point(4, 4);
            tabPage_TimeLine.Margin = new Padding(1);
            tabPage_TimeLine.Name = "tabPage_TimeLine";
            tabPage_TimeLine.Padding = new Padding(1);
            tabPage_TimeLine.Size = new Size(1148, 482);
            tabPage_TimeLine.TabIndex = 1;
            tabPage_TimeLine.Text = "TimeLine";
            tabPage_TimeLine.UseVisualStyleBackColor = true;
            // 
            // blazorWebView_TimeLine
            // 
            blazorWebView_TimeLine.Dock = DockStyle.Fill;
            blazorWebView_TimeLine.Location = new Point(1, 1);
            blazorWebView_TimeLine.Margin = new Padding(1);
            blazorWebView_TimeLine.Name = "blazorWebView_TimeLine";
            blazorWebView_TimeLine.Size = new Size(1146, 480);
            blazorWebView_TimeLine.TabIndex = 21;
            // 
            // tabPage_NoteEditor
            // 
            tabPage_NoteEditor.Controls.Add(blazorWebView1);
            tabPage_NoteEditor.Location = new Point(4, 4);
            tabPage_NoteEditor.Margin = new Padding(1);
            tabPage_NoteEditor.Name = "tabPage_NoteEditor";
            tabPage_NoteEditor.Size = new Size(1148, 482);
            tabPage_NoteEditor.TabIndex = 3;
            tabPage_NoteEditor.Text = "Note Editor";
            // 
            // blazorWebView1
            // 
            blazorWebView1.Dock = DockStyle.Fill;
            blazorWebView1.Location = new Point(0, 0);
            blazorWebView1.Margin = new Padding(1);
            blazorWebView1.Name = "blazorWebView1";
            blazorWebView1.Size = new Size(1148, 482);
            blazorWebView1.TabIndex = 20;
            // 
            // tabPage_TreeViewSetting
            // 
            tabPage_TreeViewSetting.Location = new Point(4, 4);
            tabPage_TreeViewSetting.Margin = new Padding(1);
            tabPage_TreeViewSetting.Name = "tabPage_TreeViewSetting";
            tabPage_TreeViewSetting.Padding = new Padding(0, 2, 0, 0);
            tabPage_TreeViewSetting.Size = new Size(1148, 482);
            tabPage_TreeViewSetting.TabIndex = 4;
            tabPage_TreeViewSetting.Text = "TreeViewSetting";
            tabPage_TreeViewSetting.UseVisualStyleBackColor = true;
            // 
            // tabPage_Test
            // 
            tabPage_Test.Location = new Point(4, 4);
            tabPage_Test.Margin = new Padding(1);
            tabPage_Test.Name = "tabPage_Test";
            tabPage_Test.Size = new Size(1148, 482);
            tabPage_Test.TabIndex = 6;
            tabPage_Test.Text = "tabPage_Test";
            tabPage_Test.UseVisualStyleBackColor = true;
            // 
            // tabPage_UpDateModifCompValue
            // 
            tabPage_UpDateModifCompValue.BackColor = SystemColors.Control;
            tabPage_UpDateModifCompValue.BorderStyle = BorderStyle.Fixed3D;
            tabPage_UpDateModifCompValue.Controls.Add(panel_ContainerUpDateModifValue);
            tabPage_UpDateModifCompValue.Location = new Point(4, 4);
            tabPage_UpDateModifCompValue.Margin = new Padding(0);
            tabPage_UpDateModifCompValue.Name = "tabPage_UpDateModifCompValue";
            tabPage_UpDateModifCompValue.Padding = new Padding(11, 5, 11, 5);
            tabPage_UpDateModifCompValue.Size = new Size(1148, 478);
            tabPage_UpDateModifCompValue.TabIndex = 7;
            tabPage_UpDateModifCompValue.Tag = "";
            tabPage_UpDateModifCompValue.Text = "   UpDate/Modif";
            // 
            // panel_ContainerUpDateModifValue
            // 
            panel_ContainerUpDateModifValue.Controls.Add(grouper_PrintingLabels);
            panel_ContainerUpDateModifValue.Controls.Add(grouper_ManufacturerProperties);
            panel_ContainerUpDateModifValue.Controls.Add(grouper_ComponentProperties);
            panel_ContainerUpDateModifValue.Dock = DockStyle.Fill;
            panel_ContainerUpDateModifValue.Location = new Point(11, 5);
            panel_ContainerUpDateModifValue.Margin = new Padding(0);
            panel_ContainerUpDateModifValue.Name = "panel_ContainerUpDateModifValue";
            panel_ContainerUpDateModifValue.Padding = new Padding(4, 2, 4, 2);
            panel_ContainerUpDateModifValue.Size = new Size(1122, 464);
            panel_ContainerUpDateModifValue.TabIndex = 27;
            // 
            // grouper_PrintingLabels
            // 
            grouper_PrintingLabels.BackgroundColor = SystemColors.ButtonHighlight;
            grouper_PrintingLabels.BackgroundGradientColor = Color.LightGray;
            grouper_PrintingLabels.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_PrintingLabels.BackgroundImageLayout = ImageLayout.None;
            grouper_PrintingLabels.BorderColor = Color.Black;
            grouper_PrintingLabels.BorderThickness = 1F;
            grouper_PrintingLabels.Controls.Add(wrapperpanel_ComponentControl);
            grouper_PrintingLabels.CustomGroupBoxColor = Color.White;
            grouper_PrintingLabels.Dock = DockStyle.Top;
            grouper_PrintingLabels.GroupTitle = "";
            grouper_PrintingLabels.Location = new Point(4, 92);
            grouper_PrintingLabels.Margin = new Padding(0);
            grouper_PrintingLabels.MinimumSize = new Size(0, 180);
            grouper_PrintingLabels.Name = "grouper_PrintingLabels";
            grouper_PrintingLabels.Padding = new Padding(5, 25, 5, 5);
            grouper_PrintingLabels.PaintGroupBox = false;
            grouper_PrintingLabels.RoundCorners = 10;
            grouper_PrintingLabels.ShadowColor = Color.DarkGray;
            grouper_PrintingLabels.ShadowControl = false;
            grouper_PrintingLabels.ShadowThickness = 3;
            grouper_PrintingLabels.Size = new Size(1114, 180);
            grouper_PrintingLabels.TabIndex = 27;
            // 
            // wrapperpanel_ComponentControl
            // 
            wrapperpanel_ComponentControl.BackColor = Color.Transparent;
            wrapperpanel_ComponentControl.Controls.Add(grouper_PrintingReferences);
            wrapperpanel_ComponentControl.Controls.Add(customPanelDoubleBuffered);
            wrapperpanel_ComponentControl.Dock = DockStyle.Fill;
            wrapperpanel_ComponentControl.Location = new Point(5, 25);
            wrapperpanel_ComponentControl.Margin = new Padding(0);
            wrapperpanel_ComponentControl.Name = "wrapperpanel_ComponentControl";
            wrapperpanel_ComponentControl.Size = new Size(1104, 150);
            wrapperpanel_ComponentControl.TabIndex = 21;
            // 
            // grouper_PrintingReferences
            // 
            grouper_PrintingReferences.BackgroundColor = Color.WhiteSmoke;
            grouper_PrintingReferences.BackgroundGradientColor = SystemColors.Control;
            grouper_PrintingReferences.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_PrintingReferences.BorderColor = Color.Black;
            grouper_PrintingReferences.BorderThickness = 1F;
            grouper_PrintingReferences.Controls.Add(panel_EnablePrints);
            grouper_PrintingReferences.CustomGroupBoxColor = Color.White;
            grouper_PrintingReferences.Dock = DockStyle.Right;
            grouper_PrintingReferences.GroupTitle = "Printing References";
            grouper_PrintingReferences.Location = new Point(537, 0);
            grouper_PrintingReferences.Margin = new Padding(3, 2, 3, 2);
            grouper_PrintingReferences.MinimumSize = new Size(0, 114);
            grouper_PrintingReferences.Name = "grouper_PrintingReferences";
            grouper_PrintingReferences.Padding = new Padding(1, 0, 0, 1);
            grouper_PrintingReferences.PaintGroupBox = false;
            grouper_PrintingReferences.RoundCorners = 10;
            grouper_PrintingReferences.ShadowColor = Color.DarkGray;
            grouper_PrintingReferences.ShadowControl = false;
            grouper_PrintingReferences.ShadowThickness = 3;
            grouper_PrintingReferences.Size = new Size(567, 150);
            grouper_PrintingReferences.TabIndex = 25;
            // 
            // panel_EnablePrints
            // 
            panel_EnablePrints.Controls.Add(panel_Reels);
            panel_EnablePrints.Controls.Add(grouper_BarCodeRegion);
            panel_EnablePrints.Dock = DockStyle.Fill;
            panel_EnablePrints.Location = new Point(1, 0);
            panel_EnablePrints.Margin = new Padding(0);
            panel_EnablePrints.Name = "panel_EnablePrints";
            panel_EnablePrints.Size = new Size(566, 149);
            panel_EnablePrints.TabIndex = 58;
            // 
            // panel_Reels
            // 
            panel_Reels.Controls.Add(checkBox_printLabels);
            panel_Reels.Controls.Add(panel_Description);
            panel_Reels.Dock = DockStyle.Fill;
            panel_Reels.Location = new Point(0, 0);
            panel_Reels.Margin = new Padding(0);
            panel_Reels.Name = "panel_Reels";
            panel_Reels.Padding = new Padding(4);
            panel_Reels.Size = new Size(286, 149);
            panel_Reels.TabIndex = 57;
            // 
            // checkBox_printLabels
            // 
            checkBox_printLabels.AutoSize = true;
            checkBox_printLabels.Checked = true;
            checkBox_printLabels.CheckState = CheckState.Checked;
            checkBox_printLabels.Location = new Point(12, 36);
            checkBox_printLabels.Margin = new Padding(4);
            checkBox_printLabels.Name = "checkBox_printLabels";
            checkBox_printLabels.Size = new Size(124, 24);
            checkBox_printLabels.TabIndex = 51;
            checkBox_printLabels.Text = "Print Labels ?";
            checkBox_printLabels.UseVisualStyleBackColor = true;
            // 
            // panel_Description
            // 
            panel_Description.Controls.Add(label_DescriptionToPrint);
            panel_Description.Controls.Add(textBox_DescriptionToPrint);
            panel_Description.Dock = DockStyle.Bottom;
            panel_Description.Location = new Point(4, 79);
            panel_Description.Margin = new Padding(0);
            panel_Description.Name = "panel_Description";
            panel_Description.Padding = new Padding(9, 8, 9, 8);
            panel_Description.Size = new Size(278, 66);
            panel_Description.TabIndex = 55;
            // 
            // label_DescriptionToPrint
            // 
            label_DescriptionToPrint.AutoSize = true;
            label_DescriptionToPrint.Dock = DockStyle.Top;
            label_DescriptionToPrint.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DescriptionToPrint.Location = new Point(9, 8);
            label_DescriptionToPrint.Margin = new Padding(0);
            label_DescriptionToPrint.Name = "label_DescriptionToPrint";
            label_DescriptionToPrint.Size = new Size(139, 17);
            label_DescriptionToPrint.TabIndex = 53;
            label_DescriptionToPrint.Text = "Description to print...";
            // 
            // textBox_DescriptionToPrint
            // 
            textBox_DescriptionToPrint.Dock = DockStyle.Bottom;
            textBox_DescriptionToPrint.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_DescriptionToPrint.Location = new Point(9, 32);
            textBox_DescriptionToPrint.Margin = new Padding(4);
            textBox_DescriptionToPrint.Name = "textBox_DescriptionToPrint";
            textBox_DescriptionToPrint.Size = new Size(260, 26);
            textBox_DescriptionToPrint.TabIndex = 54;
            // 
            // grouper_BarCodeRegion
            // 
            grouper_BarCodeRegion.BackgroundColor = Color.WhiteSmoke;
            grouper_BarCodeRegion.BackgroundGradientColor = Color.LightGray;
            grouper_BarCodeRegion.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_BarCodeRegion.BorderColor = Color.Black;
            grouper_BarCodeRegion.BorderThickness = 1F;
            grouper_BarCodeRegion.Controls.Add(label_LabelInformation);
            grouper_BarCodeRegion.Controls.Add(grouper_LabelBarCode);
            grouper_BarCodeRegion.CustomGroupBoxColor = Color.White;
            grouper_BarCodeRegion.Dock = DockStyle.Right;
            grouper_BarCodeRegion.GroupTitle = "";
            grouper_BarCodeRegion.Location = new Point(286, 0);
            grouper_BarCodeRegion.Margin = new Padding(0);
            grouper_BarCodeRegion.MaximumSize = new Size(290, 0);
            grouper_BarCodeRegion.MinimumSize = new Size(280, 0);
            grouper_BarCodeRegion.Name = "grouper_BarCodeRegion";
            grouper_BarCodeRegion.Padding = new Padding(7, 6, 7, 6);
            grouper_BarCodeRegion.PaintGroupBox = false;
            grouper_BarCodeRegion.RoundCorners = 10;
            grouper_BarCodeRegion.ShadowColor = Color.DarkGray;
            grouper_BarCodeRegion.ShadowControl = false;
            grouper_BarCodeRegion.ShadowThickness = 3;
            grouper_BarCodeRegion.Size = new Size(280, 149);
            grouper_BarCodeRegion.TabIndex = 55;
            // 
            // label_LabelInformation
            // 
            label_LabelInformation.AutoSize = true;
            label_LabelInformation.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label_LabelInformation.Location = new Point(52, 123);
            label_LabelInformation.Margin = new Padding(4, 0, 4, 0);
            label_LabelInformation.Name = "label_LabelInformation";
            label_LabelInformation.Size = new Size(190, 15);
            label_LabelInformation.TabIndex = 21;
            label_LabelInformation.Text = "Label type: Brady, THT-37-483-10";
            // 
            // grouper_LabelBarCode
            // 
            grouper_LabelBarCode.BackgroundColor = Color.White;
            grouper_LabelBarCode.BackgroundGradientColor = Color.White;
            grouper_LabelBarCode.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_LabelBarCode.BorderColor = Color.Black;
            grouper_LabelBarCode.BorderThickness = 1F;
            grouper_LabelBarCode.Controls.Add(label_Description);
            grouper_LabelBarCode.Controls.Add(label_HumanReadableInformation);
            grouper_LabelBarCode.Controls.Add(pictureBox_BarCode_Image);
            grouper_LabelBarCode.CustomGroupBoxColor = Color.White;
            grouper_LabelBarCode.Dock = DockStyle.Top;
            grouper_LabelBarCode.GroupTitle = "";
            grouper_LabelBarCode.Location = new Point(7, 6);
            grouper_LabelBarCode.Margin = new Padding(4);
            grouper_LabelBarCode.Name = "grouper_LabelBarCode";
            grouper_LabelBarCode.Padding = new Padding(27, 24, 27, 24);
            grouper_LabelBarCode.PaintGroupBox = false;
            grouper_LabelBarCode.RoundCorners = 10;
            grouper_LabelBarCode.ShadowColor = Color.DarkGray;
            grouper_LabelBarCode.ShadowControl = false;
            grouper_LabelBarCode.ShadowThickness = 3;
            grouper_LabelBarCode.Size = new Size(266, 104);
            grouper_LabelBarCode.TabIndex = 19;
            // 
            // label_Description
            // 
            label_Description.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Description.Location = new Point(4, 74);
            label_Description.Margin = new Padding(0);
            label_Description.Name = "label_Description";
            label_Description.Size = new Size(270, 22);
            label_Description.TabIndex = 21;
            label_Description.Text = "Description field.";
            label_Description.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_HumanReadableInformation
            // 
            label_HumanReadableInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_HumanReadableInformation.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_HumanReadableInformation.Location = new Point(46, 76);
            label_HumanReadableInformation.Margin = new Padding(4, 0, 4, 0);
            label_HumanReadableInformation.Name = "label_HumanReadableInformation";
            label_HumanReadableInformation.Size = new Size(60, 18);
            label_HumanReadableInformation.TabIndex = 20;
            label_HumanReadableInformation.Text = "Human Readable Information.";
            label_HumanReadableInformation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox_BarCode_Image
            // 
            pictureBox_BarCode_Image.BackColor = Color.White;
            pictureBox_BarCode_Image.Location = new Point(4, 18);
            pictureBox_BarCode_Image.Margin = new Padding(4);
            pictureBox_BarCode_Image.Name = "pictureBox_BarCode_Image";
            pictureBox_BarCode_Image.Size = new Size(259, 52);
            pictureBox_BarCode_Image.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_BarCode_Image.TabIndex = 14;
            pictureBox_BarCode_Image.TabStop = false;
            // 
            // customPanelDoubleBuffered
            // 
            customPanelDoubleBuffered.Dock = DockStyle.Left;
            customPanelDoubleBuffered.Location = new Point(0, 0);
            customPanelDoubleBuffered.Margin = new Padding(3, 2, 3, 2);
            customPanelDoubleBuffered.Name = "customPanelDoubleBuffered";
            customPanelDoubleBuffered.Size = new Size(509, 150);
            customPanelDoubleBuffered.TabIndex = 24;
            // 
            // grouper_ManufacturerProperties
            // 
            grouper_ManufacturerProperties.AutoSize = true;
            grouper_ManufacturerProperties.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_ManufacturerProperties.BackgroundColor = SystemColors.ButtonHighlight;
            grouper_ManufacturerProperties.BackgroundGradientColor = Color.LightGray;
            grouper_ManufacturerProperties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_ManufacturerProperties.BorderColor = Color.Black;
            grouper_ManufacturerProperties.BorderThickness = 1F;
            grouper_ManufacturerProperties.Controls.Add(wrapperpanel_ManufacturerProperties);
            grouper_ManufacturerProperties.CustomGroupBoxColor = Color.White;
            grouper_ManufacturerProperties.Dock = DockStyle.Bottom;
            grouper_ManufacturerProperties.GroupTitle = "Manufacturer Properties";
            grouper_ManufacturerProperties.Location = new Point(4, 352);
            grouper_ManufacturerProperties.Margin = new Padding(0);
            grouper_ManufacturerProperties.MinimumSize = new Size(0, 110);
            grouper_ManufacturerProperties.Name = "grouper_ManufacturerProperties";
            grouper_ManufacturerProperties.Padding = new Padding(5, 25, 5, 5);
            grouper_ManufacturerProperties.PaintGroupBox = false;
            grouper_ManufacturerProperties.RoundCorners = 10;
            grouper_ManufacturerProperties.ShadowColor = Color.DarkGray;
            grouper_ManufacturerProperties.ShadowControl = false;
            grouper_ManufacturerProperties.ShadowThickness = 3;
            grouper_ManufacturerProperties.Size = new Size(1114, 110);
            grouper_ManufacturerProperties.TabIndex = 26;
            // 
            // wrapperpanel_ManufacturerProperties
            // 
            wrapperpanel_ManufacturerProperties.AutoSize = true;
            wrapperpanel_ManufacturerProperties.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            wrapperpanel_ManufacturerProperties.Controls.Add(panel1);
            wrapperpanel_ManufacturerProperties.Controls.Add(panel_Supplier);
            wrapperpanel_ManufacturerProperties.Controls.Add(panel_Manufacturer);
            wrapperpanel_ManufacturerProperties.Controls.Add(panel_ModelNumber);
            wrapperpanel_ManufacturerProperties.Dock = DockStyle.Fill;
            wrapperpanel_ManufacturerProperties.Location = new Point(5, 25);
            wrapperpanel_ManufacturerProperties.Margin = new Padding(0);
            wrapperpanel_ManufacturerProperties.MinimumSize = new Size(0, 18);
            wrapperpanel_ManufacturerProperties.Name = "wrapperpanel_ManufacturerProperties";
            wrapperpanel_ManufacturerProperties.Size = new Size(1104, 80);
            wrapperpanel_ManufacturerProperties.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(textBox4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(837, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5, 8, 5, 8);
            panel1.Size = new Size(267, 80);
            panel1.TabIndex = 22;
            // 
            // textBox4
            // 
            textBox4.Dock = DockStyle.Bottom;
            textBox4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox4.Location = new Point(5, 46);
            textBox4.Margin = new Padding(4, 5, 4, 5);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(257, 26);
            textBox4.TabIndex = 14;
            // 
            // panel_Supplier
            // 
            panel_Supplier.AutoSize = true;
            panel_Supplier.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Supplier.Controls.Add(textBox_Supplier);
            panel_Supplier.Controls.Add(label_Supplier);
            panel_Supplier.Dock = DockStyle.Left;
            panel_Supplier.Location = new Point(537, 0);
            panel_Supplier.Margin = new Padding(0);
            panel_Supplier.MinimumSize = new Size(300, 38);
            panel_Supplier.Name = "panel_Supplier";
            panel_Supplier.Padding = new Padding(5, 8, 5, 8);
            panel_Supplier.Size = new Size(300, 80);
            panel_Supplier.TabIndex = 23;
            // 
            // textBox_Supplier
            // 
            textBox_Supplier.Dock = DockStyle.Bottom;
            textBox_Supplier.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox_Supplier.Location = new Point(5, 46);
            textBox_Supplier.Margin = new Padding(4, 5, 4, 5);
            textBox_Supplier.Name = "textBox_Supplier";
            textBox_Supplier.Size = new Size(290, 26);
            textBox_Supplier.TabIndex = 14;
            // 
            // label_Supplier
            // 
            label_Supplier.AutoSize = true;
            label_Supplier.Dock = DockStyle.Top;
            label_Supplier.Font = new Font("Microsoft Sans Serif", 12F);
            label_Supplier.Location = new Point(5, 8);
            label_Supplier.Margin = new Padding(4, 2, 4, 2);
            label_Supplier.Name = "label_Supplier";
            label_Supplier.Size = new Size(67, 20);
            label_Supplier.TabIndex = 6;
            label_Supplier.Text = "Supplier";
            // 
            // panel_Manufacturer
            // 
            panel_Manufacturer.AutoSize = true;
            panel_Manufacturer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Manufacturer.Controls.Add(textBox_Manufacturer);
            panel_Manufacturer.Controls.Add(label_Manufacturer);
            panel_Manufacturer.Dock = DockStyle.Left;
            panel_Manufacturer.Location = new Point(237, 0);
            panel_Manufacturer.Margin = new Padding(0);
            panel_Manufacturer.MinimumSize = new Size(300, 38);
            panel_Manufacturer.Name = "panel_Manufacturer";
            panel_Manufacturer.Padding = new Padding(5, 8, 5, 8);
            panel_Manufacturer.Size = new Size(300, 80);
            panel_Manufacturer.TabIndex = 24;
            // 
            // textBox_Manufacturer
            // 
            textBox_Manufacturer.Dock = DockStyle.Bottom;
            textBox_Manufacturer.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox_Manufacturer.Location = new Point(5, 46);
            textBox_Manufacturer.Margin = new Padding(4, 5, 4, 5);
            textBox_Manufacturer.Name = "textBox_Manufacturer";
            textBox_Manufacturer.Size = new Size(290, 26);
            textBox_Manufacturer.TabIndex = 14;
            // 
            // label_Manufacturer
            // 
            label_Manufacturer.AutoSize = true;
            label_Manufacturer.Dock = DockStyle.Top;
            label_Manufacturer.Font = new Font("Microsoft Sans Serif", 12F);
            label_Manufacturer.Location = new Point(5, 8);
            label_Manufacturer.Margin = new Padding(4, 2, 4, 2);
            label_Manufacturer.Name = "label_Manufacturer";
            label_Manufacturer.Size = new Size(104, 20);
            label_Manufacturer.TabIndex = 2;
            label_Manufacturer.Text = "Manufacturer";
            // 
            // panel_ModelNumber
            // 
            panel_ModelNumber.AutoSize = true;
            panel_ModelNumber.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_ModelNumber.Controls.Add(textBox_ModelNumber);
            panel_ModelNumber.Controls.Add(label_ModelNumber);
            panel_ModelNumber.Dock = DockStyle.Left;
            panel_ModelNumber.Location = new Point(0, 0);
            panel_ModelNumber.Margin = new Padding(0);
            panel_ModelNumber.MinimumSize = new Size(237, 38);
            panel_ModelNumber.Name = "panel_ModelNumber";
            panel_ModelNumber.Padding = new Padding(5, 8, 5, 8);
            panel_ModelNumber.Size = new Size(237, 80);
            panel_ModelNumber.TabIndex = 23;
            // 
            // textBox_ModelNumber
            // 
            textBox_ModelNumber.Dock = DockStyle.Bottom;
            textBox_ModelNumber.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox_ModelNumber.Location = new Point(5, 46);
            textBox_ModelNumber.Margin = new Padding(4, 5, 4, 5);
            textBox_ModelNumber.Name = "textBox_ModelNumber";
            textBox_ModelNumber.Size = new Size(227, 26);
            textBox_ModelNumber.TabIndex = 14;
            // 
            // label_ModelNumber
            // 
            label_ModelNumber.AutoSize = true;
            label_ModelNumber.Dock = DockStyle.Top;
            label_ModelNumber.Font = new Font("Microsoft Sans Serif", 12F);
            label_ModelNumber.Location = new Point(5, 8);
            label_ModelNumber.Margin = new Padding(4, 2, 4, 2);
            label_ModelNumber.Name = "label_ModelNumber";
            label_ModelNumber.Size = new Size(112, 20);
            label_ModelNumber.TabIndex = 4;
            label_ModelNumber.Text = "Model Number";
            // 
            // grouper_ComponentProperties
            // 
            grouper_ComponentProperties.AutoSize = true;
            grouper_ComponentProperties.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_ComponentProperties.BackgroundColor = SystemColors.ButtonHighlight;
            grouper_ComponentProperties.BackgroundGradientColor = Color.LightGray;
            grouper_ComponentProperties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_ComponentProperties.BorderColor = Color.Black;
            grouper_ComponentProperties.BorderThickness = 1F;
            grouper_ComponentProperties.Controls.Add(wrapperpanel_ComponentProperties);
            grouper_ComponentProperties.CustomGroupBoxColor = Color.White;
            grouper_ComponentProperties.Dock = DockStyle.Top;
            grouper_ComponentProperties.GroupTitle = "Component Properties";
            grouper_ComponentProperties.Location = new Point(4, 2);
            grouper_ComponentProperties.Margin = new Padding(0);
            grouper_ComponentProperties.MinimumSize = new Size(139, 90);
            grouper_ComponentProperties.Name = "grouper_ComponentProperties";
            grouper_ComponentProperties.Padding = new Padding(5, 25, 5, 5);
            grouper_ComponentProperties.PaintGroupBox = false;
            grouper_ComponentProperties.RoundCorners = 10;
            grouper_ComponentProperties.ShadowColor = Color.DarkGray;
            grouper_ComponentProperties.ShadowControl = false;
            grouper_ComponentProperties.ShadowThickness = 3;
            grouper_ComponentProperties.Size = new Size(1114, 90);
            grouper_ComponentProperties.TabIndex = 20;
            // 
            // wrapperpanel_ComponentProperties
            // 
            wrapperpanel_ComponentProperties.Controls.Add(panel_NumberofReelsOrBoxes);
            wrapperpanel_ComponentProperties.Controls.Add(panel_ReceivedDate);
            wrapperpanel_ComponentProperties.Controls.Add(panel4_ReceivedQuantity);
            wrapperpanel_ComponentProperties.Controls.Add(panel_PartNumber);
            wrapperpanel_ComponentProperties.Dock = DockStyle.Fill;
            wrapperpanel_ComponentProperties.Location = new Point(5, 25);
            wrapperpanel_ComponentProperties.Margin = new Padding(0);
            wrapperpanel_ComponentProperties.Name = "wrapperpanel_ComponentProperties";
            wrapperpanel_ComponentProperties.Size = new Size(1104, 60);
            wrapperpanel_ComponentProperties.TabIndex = 24;
            // 
            // panel_NumberofReelsOrBoxes
            // 
            panel_NumberofReelsOrBoxes.Controls.Add(label_NumberofReelsOrBoxes);
            panel_NumberofReelsOrBoxes.Controls.Add(textBox_NumberofReelsOrBoxes);
            panel_NumberofReelsOrBoxes.Dock = DockStyle.Fill;
            panel_NumberofReelsOrBoxes.Location = new Point(442, 0);
            panel_NumberofReelsOrBoxes.Margin = new Padding(0);
            panel_NumberofReelsOrBoxes.Name = "panel_NumberofReelsOrBoxes";
            panel_NumberofReelsOrBoxes.Padding = new Padding(5);
            panel_NumberofReelsOrBoxes.Size = new Size(337, 60);
            panel_NumberofReelsOrBoxes.TabIndex = 24;
            // 
            // label_NumberofReelsOrBoxes
            // 
            label_NumberofReelsOrBoxes.AutoSize = true;
            label_NumberofReelsOrBoxes.Dock = DockStyle.Top;
            label_NumberofReelsOrBoxes.Font = new Font("Microsoft Sans Serif", 12F);
            label_NumberofReelsOrBoxes.Location = new Point(5, 5);
            label_NumberofReelsOrBoxes.Margin = new Padding(10, 2, 10, 2);
            label_NumberofReelsOrBoxes.Name = "label_NumberofReelsOrBoxes";
            label_NumberofReelsOrBoxes.Size = new Size(197, 20);
            label_NumberofReelsOrBoxes.TabIndex = 2;
            label_NumberofReelsOrBoxes.Text = "Number of Reels Or Boxes";
            // 
            // textBox_NumberofReelsOrBoxes
            // 
            textBox_NumberofReelsOrBoxes.Dock = DockStyle.Bottom;
            textBox_NumberofReelsOrBoxes.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox_NumberofReelsOrBoxes.Location = new Point(5, 29);
            textBox_NumberofReelsOrBoxes.Margin = new Padding(4, 5, 4, 5);
            textBox_NumberofReelsOrBoxes.Name = "textBox_NumberofReelsOrBoxes";
            textBox_NumberofReelsOrBoxes.Size = new Size(327, 26);
            textBox_NumberofReelsOrBoxes.TabIndex = 14;
            // 
            // panel_ReceivedDate
            // 
            panel_ReceivedDate.Controls.Add(label_Received_Date);
            panel_ReceivedDate.Controls.Add(dateTimePicker_ReceivedDate);
            panel_ReceivedDate.Dock = DockStyle.Right;
            panel_ReceivedDate.Location = new Point(779, 0);
            panel_ReceivedDate.Margin = new Padding(0);
            panel_ReceivedDate.Name = "panel_ReceivedDate";
            panel_ReceivedDate.Padding = new Padding(5);
            panel_ReceivedDate.Size = new Size(325, 60);
            panel_ReceivedDate.TabIndex = 23;
            // 
            // label_Received_Date
            // 
            label_Received_Date.AutoSize = true;
            label_Received_Date.Dock = DockStyle.Top;
            label_Received_Date.Font = new Font("Microsoft Sans Serif", 12F);
            label_Received_Date.Location = new Point(5, 5);
            label_Received_Date.Margin = new Padding(0);
            label_Received_Date.Name = "label_Received_Date";
            label_Received_Date.Size = new Size(105, 20);
            label_Received_Date.TabIndex = 5;
            label_Received_Date.Text = "Recived Date";
            // 
            // dateTimePicker_ReceivedDate
            // 
            dateTimePicker_ReceivedDate.Dock = DockStyle.Bottom;
            dateTimePicker_ReceivedDate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker_ReceivedDate.Location = new Point(5, 29);
            dateTimePicker_ReceivedDate.Margin = new Padding(4, 2, 4, 2);
            dateTimePicker_ReceivedDate.Name = "dateTimePicker_ReceivedDate";
            dateTimePicker_ReceivedDate.Size = new Size(315, 26);
            dateTimePicker_ReceivedDate.TabIndex = 4;
            // 
            // panel4_ReceivedQuantity
            // 
            panel4_ReceivedQuantity.Controls.Add(label_ReceivedQuantity);
            panel4_ReceivedQuantity.Controls.Add(textBox_ReceivedQuantity);
            panel4_ReceivedQuantity.Dock = DockStyle.Left;
            panel4_ReceivedQuantity.Location = new Point(213, 0);
            panel4_ReceivedQuantity.Margin = new Padding(0);
            panel4_ReceivedQuantity.MinimumSize = new Size(42, 0);
            panel4_ReceivedQuantity.Name = "panel4_ReceivedQuantity";
            panel4_ReceivedQuantity.Padding = new Padding(5);
            panel4_ReceivedQuantity.Size = new Size(229, 60);
            panel4_ReceivedQuantity.TabIndex = 23;
            // 
            // label_ReceivedQuantity
            // 
            label_ReceivedQuantity.AutoSize = true;
            label_ReceivedQuantity.Dock = DockStyle.Top;
            label_ReceivedQuantity.Font = new Font("Microsoft Sans Serif", 12F);
            label_ReceivedQuantity.Location = new Point(5, 5);
            label_ReceivedQuantity.Margin = new Padding(10, 2, 10, 2);
            label_ReceivedQuantity.Name = "label_ReceivedQuantity";
            label_ReceivedQuantity.Size = new Size(143, 20);
            label_ReceivedQuantity.TabIndex = 2;
            label_ReceivedQuantity.Text = "Amounts Received";
            // 
            // textBox_ReceivedQuantity
            // 
            textBox_ReceivedQuantity.Dock = DockStyle.Bottom;
            textBox_ReceivedQuantity.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox_ReceivedQuantity.Location = new Point(5, 29);
            textBox_ReceivedQuantity.Margin = new Padding(4, 5, 4, 5);
            textBox_ReceivedQuantity.Name = "textBox_ReceivedQuantity";
            textBox_ReceivedQuantity.Size = new Size(219, 26);
            textBox_ReceivedQuantity.TabIndex = 14;
            // 
            // panel_PartNumber
            // 
            panel_PartNumber.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_PartNumber.Controls.Add(label_PartNumber);
            panel_PartNumber.Controls.Add(textBox_PartNumber);
            panel_PartNumber.Dock = DockStyle.Left;
            panel_PartNumber.Location = new Point(0, 0);
            panel_PartNumber.Margin = new Padding(0);
            panel_PartNumber.MinimumSize = new Size(110, 0);
            panel_PartNumber.Name = "panel_PartNumber";
            panel_PartNumber.Padding = new Padding(5);
            panel_PartNumber.Size = new Size(213, 60);
            panel_PartNumber.TabIndex = 6;
            // 
            // label_PartNumber
            // 
            label_PartNumber.AutoSize = true;
            label_PartNumber.Dock = DockStyle.Top;
            label_PartNumber.Font = new Font("Microsoft Sans Serif", 12F);
            label_PartNumber.Location = new Point(5, 5);
            label_PartNumber.Margin = new Padding(10, 2, 10, 2);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Size = new Size(98, 20);
            label_PartNumber.TabIndex = 0;
            label_PartNumber.Text = "Part Number";
            // 
            // textBox_PartNumber
            // 
            textBox_PartNumber.Dock = DockStyle.Bottom;
            textBox_PartNumber.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox_PartNumber.Location = new Point(5, 29);
            textBox_PartNumber.Margin = new Padding(4, 5, 4, 5);
            textBox_PartNumber.Name = "textBox_PartNumber";
            textBox_PartNumber.Size = new Size(203, 26);
            textBox_PartNumber.TabIndex = 13;
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
            dataGridViewExtended.Margin = new Padding(4, 2, 4, 2);
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
            TabControl_Inventory.ResumeLayout(false);
            tabPage_AddNewItem.ResumeLayout(false);
            tabPage_AddNewItem.PerformLayout();
            grouper_NewItemButtons.ResumeLayout(false);
            grouper_NewItemButtons.PerformLayout();
            flowLayoutPanel_Buttons.ResumeLayout(false);
            flowLayoutPanel_Buttons.PerformLayout();
            grouper_ItemProperties.ResumeLayout(false);
            grouper_ItemProperties.PerformLayout();
            flowLayoutPanel_ItemsProperties.ResumeLayout(false);
            tabPage_Pictures.ResumeLayout(false);
            tabPage_Location.ResumeLayout(false);
            tabPage_TimeLine.ResumeLayout(false);
            tabPage_NoteEditor.ResumeLayout(false);
            tabPage_UpDateModifCompValue.ResumeLayout(false);
            panel_ContainerUpDateModifValue.ResumeLayout(false);
            panel_ContainerUpDateModifValue.PerformLayout();
            grouper_PrintingLabels.ResumeLayout(false);
            wrapperpanel_ComponentControl.ResumeLayout(false);
            grouper_PrintingReferences.ResumeLayout(false);
            panel_EnablePrints.ResumeLayout(false);
            panel_Reels.ResumeLayout(false);
            panel_Reels.PerformLayout();
            panel_Description.ResumeLayout(false);
            panel_Description.PerformLayout();
            grouper_BarCodeRegion.ResumeLayout(false);
            grouper_BarCodeRegion.PerformLayout();
            grouper_LabelBarCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_BarCode_Image).EndInit();
            grouper_ManufacturerProperties.ResumeLayout(false);
            grouper_ManufacturerProperties.PerformLayout();
            wrapperpanel_ManufacturerProperties.ResumeLayout(false);
            wrapperpanel_ManufacturerProperties.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel_Supplier.ResumeLayout(false);
            panel_Supplier.PerformLayout();
            panel_Manufacturer.ResumeLayout(false);
            panel_Manufacturer.PerformLayout();
            panel_ModelNumber.ResumeLayout(false);
            panel_ModelNumber.PerformLayout();
            grouper_ComponentProperties.ResumeLayout(false);
            wrapperpanel_ComponentProperties.ResumeLayout(false);
            panel_NumberofReelsOrBoxes.ResumeLayout(false);
            panel_NumberofReelsOrBoxes.PerformLayout();
            panel_ReceivedDate.ResumeLayout(false);
            panel_ReceivedDate.PerformLayout();
            panel4_ReceivedQuantity.ResumeLayout(false);
            panel4_ReceivedQuantity.PerformLayout();
            panel_PartNumber.ResumeLayout(false);
            panel_PartNumber.PerformLayout();
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
        private Panel panel_ContainerUpDateModifValue;
        private CodeVendor.Controls.Grouper grouper_ManufacturerProperties;
        private Panel wrapperpanel_ManufacturerProperties;
        private Panel panel1;
        private Panel panel_Supplier;
        private Label label_Supplier;
        private Panel panel_Manufacturer;
        private Label label_Manufacturer;
        private Panel panel_ModelNumber;
        private Label label_ModelNumber;
        private Panel wrapperpanel_ComponentControl;
        private CustomPanelDoubleBuffered customPanelDoubleBuffered;
        private CodeVendor.Controls.Grouper grouper_ComponentProperties;
        private Panel wrapperpanel_ComponentProperties;
        private Panel panel_NumberofReelsOrBoxes;
        private Label label_NumberofReelsOrBoxes;
        private Panel panel4_ReceivedQuantity;
        private Label label_ReceivedQuantity;
        private Panel panel_PartNumber;
        private Label label_PartNumber;
        private Panel panel_ReceivedDate;
        private Label label_Received_Date;
        private DateTimePicker dateTimePicker_ReceivedDate;
        private TextBox textBox_PartNumber;
        private TextBox textBox_NumberofReelsOrBoxes;
        private TextBox textBox_ReceivedQuantity;
        private TextBox textBox4;
        private TextBox textBox_Supplier;
        private TextBox textBox_Manufacturer;
        private TextBox textBox_ModelNumber;
        private CodeVendor.Controls.Grouper grouper_PrintingLabels;
        private CodeVendor.Controls.Grouper grouper_PrintingReferences;
        private Panel panel_EnablePrints;
        private Panel panel_Reels;
        protected CheckBox checkBox_printLabels;
        private Panel panel_Description;
        private Label label_DescriptionToPrint;
        private TextBox textBox_DescriptionToPrint;
        private CodeVendor.Controls.Grouper grouper_BarCodeRegion;
        private Label label_LabelInformation;
        private CodeVendor.Controls.Grouper grouper_LabelBarCode;
        private Label label_Description;
        private Label label_HumanReadableInformation;
        private PictureBox pictureBox_BarCode_Image;
    }
}
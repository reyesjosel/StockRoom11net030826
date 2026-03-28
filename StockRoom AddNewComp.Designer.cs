using MyStuff11net;
using System.Drawing;

namespace StockRoom11net
{
    partial class StockRoom_AddNewComp
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.customTabControl_AddNewComp = new System.Windows.Forms.CustomTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grouper_ItemProperties = new CodeVendor.Controls.Grouper();
            this.flowLayoutPanel_ItemsProperties = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxExtended_PartNumber = new MyStuff11net.ComboBoxExtended();
            this.comboBoxExtended_Description = new MyStuff11net.ComboBoxExtended();
            this.comboBoxExtended_Status = new MyStuff11net.ComboBoxExtended();
            this.comboBoxExtended1 = new MyStuff11net.ComboBoxExtended();
            this.grouper_NewItemButtons = new CodeVendor.Controls.Grouper();
            this.flowLayoutPanel_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.button_AddNew = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewExtended_AddNewComp = new MyStuff11net.DataGridViewExtend.DataGridViewExtended();
            this._contextMenuStripTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_singleExpandedNode = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_multipleExpandedNodes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_ExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_CollaseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_AddNewComponent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_showSettingDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SetPictures = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_estimatedFor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_QuantityEstimated = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTreeViewBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.customTabControl_AddNewComp.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grouper_ItemProperties.SuspendLayout();
            this.flowLayoutPanel_ItemsProperties.SuspendLayout();
            this.grouper_NewItemButtons.SuspendLayout();
            this.flowLayoutPanel_Buttons.SuspendLayout();
            this._contextMenuStripTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 300;
            this.splitContainer1.Size = new System.Drawing.Size(1437, 795);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.customTabControl_AddNewComp);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridViewExtended_AddNewComp);
            this.splitContainer2.Size = new System.Drawing.Size(1076, 795);
            this.splitContainer2.SplitterDistance = 406;
            this.splitContainer2.TabIndex = 0;
            // 
            // customTabControl_AddNewComp
            // 
            this.customTabControl_AddNewComp.Controls.Add(this.tabPage1);
            this.customTabControl_AddNewComp.Controls.Add(this.tabPage2);
            this.customTabControl_AddNewComp.DisplayStyle = System.Windows.Forms.TabStyle.Angled;
            // 
            // 
            // 
            this.customTabControl_AddNewComp.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.customTabControl_AddNewComp.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.customTabControl_AddNewComp.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.customTabControl_AddNewComp.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.customTabControl_AddNewComp.DisplayStyleProvider.FocusTrack = false;
            this.customTabControl_AddNewComp.DisplayStyleProvider.HotTrack = true;
            this.customTabControl_AddNewComp.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.customTabControl_AddNewComp.DisplayStyleProvider.Opacity = 1F;
            this.customTabControl_AddNewComp.DisplayStyleProvider.Overlap = 7;
            this.customTabControl_AddNewComp.DisplayStyleProvider.Padding = new Point(10, 3);
            this.customTabControl_AddNewComp.DisplayStyleProvider.Radius = 10;
            this.customTabControl_AddNewComp.DisplayStyleProvider.ShowTabCloser = false;
            this.customTabControl_AddNewComp.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.customTabControl_AddNewComp.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.customTabControl_AddNewComp.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.customTabControl_AddNewComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customTabControl_AddNewComp.HotTrack = true;
            this.customTabControl_AddNewComp.Location = new Point(0, 0);
            this.customTabControl_AddNewComp.Margin = new System.Windows.Forms.Padding(0);
            this.customTabControl_AddNewComp.Name = "customTabControl_AddNewComp";
            this.customTabControl_AddNewComp.SelectedIndex = 0;
            this.customTabControl_AddNewComp.Size = new System.Drawing.Size(1072, 402);
            this.customTabControl_AddNewComp.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grouper_ItemProperties);
            this.tabPage1.Controls.Add(this.grouper_NewItemButtons);
            this.tabPage1.Location = new Point(4, 23);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.tabPage1.Size = new System.Drawing.Size(1064, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate a new PartNumber.               ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grouper_ItemProperties
            // 
            this.grouper_ItemProperties.AutoSize = true;
            this.grouper_ItemProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grouper_ItemProperties.BackgroundColor = System.Drawing.Color.LightGray;
            this.grouper_ItemProperties.BackgroundGradientColor = System.Drawing.Color.DarkGray;
            this.grouper_ItemProperties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            this.grouper_ItemProperties.BorderColor = System.Drawing.Color.Black;
            this.grouper_ItemProperties.BorderThickness = 1F;
            this.grouper_ItemProperties.Controls.Add(this.flowLayoutPanel_ItemsProperties);
            this.grouper_ItemProperties.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper_ItemProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.grouper_ItemProperties.GroupImage = null;
            this.grouper_ItemProperties.GroupTitle = "";
            this.grouper_ItemProperties.Location = new Point(8, 0);
            this.grouper_ItemProperties.Margin = new System.Windows.Forms.Padding(2);
            this.grouper_ItemProperties.MinimumSize = new System.Drawing.Size(560, 70);
            this.grouper_ItemProperties.Name = "grouper_ItemProperties";
            this.grouper_ItemProperties.Padding = new System.Windows.Forms.Padding(2, 11, 2, 3);
            this.grouper_ItemProperties.PaintGroupBox = false;
            this.grouper_ItemProperties.RoundCorners = 10;
            this.grouper_ItemProperties.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper_ItemProperties.ShadowControl = false;
            this.grouper_ItemProperties.ShadowThickness = 3;
            this.grouper_ItemProperties.Size = new System.Drawing.Size(1048, 74);
            this.grouper_ItemProperties.TabIndex = 19;
            // 
            // flowLayoutPanel_ItemsProperties
            // 
            this.flowLayoutPanel_ItemsProperties.AutoSize = true;
            this.flowLayoutPanel_ItemsProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_ItemsProperties.Controls.Add(this.comboBoxExtended_PartNumber);
            this.flowLayoutPanel_ItemsProperties.Controls.Add(this.comboBoxExtended_Description);
            this.flowLayoutPanel_ItemsProperties.Controls.Add(this.comboBoxExtended_Status);
            this.flowLayoutPanel_ItemsProperties.Controls.Add(this.comboBoxExtended1);
            this.flowLayoutPanel_ItemsProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel_ItemsProperties.Location = new Point(2, 11);
            this.flowLayoutPanel_ItemsProperties.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel_ItemsProperties.MinimumSize = new System.Drawing.Size(560, 60);
            this.flowLayoutPanel_ItemsProperties.Name = "flowLayoutPanel_ItemsProperties";
            this.flowLayoutPanel_ItemsProperties.Size = new System.Drawing.Size(1044, 60);
            this.flowLayoutPanel_ItemsProperties.TabIndex = 13;
            // 
            // comboBoxExtended_PartNumber
            // 
            this.comboBoxExtended_PartNumber.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comboBoxExtended_PartNumber.DataSource = null;
            this.comboBoxExtended_PartNumber.Location = new Point(4, 4);
            this.comboBoxExtended_PartNumber.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxExtended_PartNumber.MinimumSize = new System.Drawing.Size(60, 50);
            this.comboBoxExtended_PartNumber.Name = "comboBoxExtended_PartNumber";
            this.comboBoxExtended_PartNumber.SelectedItem = null;
            this.comboBoxExtended_PartNumber.SelectionLength = 0;
            this.comboBoxExtended_PartNumber.Size = new System.Drawing.Size(85, 50);
            this.comboBoxExtended_PartNumber.TabIndex = 7;
            this.comboBoxExtended_PartNumber.Tag = "25";
            // 
            // comboBoxExtended_Description
            // 
            this.comboBoxExtended_Description.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comboBoxExtended_Description.DataSource = null;
            this.comboBoxExtended_Description.Location = new Point(97, 4);
            this.comboBoxExtended_Description.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxExtended_Description.MinimumSize = new System.Drawing.Size(60, 50);
            this.comboBoxExtended_Description.Name = "comboBoxExtended_Description";
            this.comboBoxExtended_Description.SelectedItem = null;
            this.comboBoxExtended_Description.SelectionLength = 0;
            this.comboBoxExtended_Description.Size = new System.Drawing.Size(380, 50);
            this.comboBoxExtended_Description.TabIndex = 8;
            this.comboBoxExtended_Description.Tag = "40";
            // 
            // comboBoxExtended_Status
            // 
            this.comboBoxExtended_Status.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comboBoxExtended_Status.DataSource = null;
            this.comboBoxExtended_Status.Location = new Point(485, 4);
            this.comboBoxExtended_Status.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxExtended_Status.MinimumSize = new System.Drawing.Size(60, 50);
            this.comboBoxExtended_Status.Name = "comboBoxExtended_Status";
            this.comboBoxExtended_Status.SelectedItem = null;
            this.comboBoxExtended_Status.SelectionLength = 0;
            this.comboBoxExtended_Status.Size = new System.Drawing.Size(60, 50);
            this.comboBoxExtended_Status.TabIndex = 6;
            this.comboBoxExtended_Status.Tag = "20";
            // 
            // comboBoxExtended1
            // 
            this.comboBoxExtended1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comboBoxExtended1.DataSource = null;
            this.comboBoxExtended1.Location = new Point(553, 4);
            this.comboBoxExtended1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxExtended1.MinimumSize = new System.Drawing.Size(60, 50);
            this.comboBoxExtended1.Name = "comboBoxExtended1";
            this.comboBoxExtended1.SelectedItem = null;
            this.comboBoxExtended1.SelectionLength = 0;
            this.comboBoxExtended1.Size = new System.Drawing.Size(60, 50);
            this.comboBoxExtended1.TabIndex = 9;
            this.comboBoxExtended1.Tag = "15";
            // 
            // grouper_NewItemButtons
            // 
            this.grouper_NewItemButtons.AutoSize = true;
            this.grouper_NewItemButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grouper_NewItemButtons.BackgroundColor = System.Drawing.Color.LightGray;
            this.grouper_NewItemButtons.BackgroundGradientColor = System.Drawing.Color.DarkGray;
            this.grouper_NewItemButtons.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            this.grouper_NewItemButtons.BorderColor = System.Drawing.Color.Black;
            this.grouper_NewItemButtons.BorderThickness = 1F;
            this.grouper_NewItemButtons.Controls.Add(this.flowLayoutPanel_Buttons);
            this.grouper_NewItemButtons.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper_NewItemButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grouper_NewItemButtons.GroupImage = null;
            this.grouper_NewItemButtons.GroupTitle = "";
            this.grouper_NewItemButtons.Location = new Point(8, 317);
            this.grouper_NewItemButtons.Margin = new System.Windows.Forms.Padding(2);
            this.grouper_NewItemButtons.MinimumSize = new System.Drawing.Size(300, 50);
            this.grouper_NewItemButtons.Name = "grouper_NewItemButtons";
            this.grouper_NewItemButtons.Padding = new System.Windows.Forms.Padding(2, 12, 2, 3);
            this.grouper_NewItemButtons.PaintGroupBox = false;
            this.grouper_NewItemButtons.RoundCorners = 10;
            this.grouper_NewItemButtons.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper_NewItemButtons.ShadowControl = false;
            this.grouper_NewItemButtons.ShadowThickness = 3;
            this.grouper_NewItemButtons.Size = new System.Drawing.Size(1048, 50);
            this.grouper_NewItemButtons.TabIndex = 18;
            // 
            // flowLayoutPanel_Buttons
            // 
            this.flowLayoutPanel_Buttons.AutoSize = true;
            this.flowLayoutPanel_Buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_Buttons.Controls.Add(this.button_AddNew);
            this.flowLayoutPanel_Buttons.Controls.Add(this.button_Save);
            this.flowLayoutPanel_Buttons.Controls.Add(this.button_Delete);
            this.flowLayoutPanel_Buttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel_Buttons.Location = new Point(2, 12);
            this.flowLayoutPanel_Buttons.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel_Buttons.MinimumSize = new System.Drawing.Size(0, 35);
            this.flowLayoutPanel_Buttons.Name = "flowLayoutPanel_Buttons";
            this.flowLayoutPanel_Buttons.Size = new System.Drawing.Size(1044, 35);
            this.flowLayoutPanel_Buttons.TabIndex = 13;
            // 
            // button_AddNew
            // 
            this.button_AddNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_AddNew.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddNew.Location = new Point(2, 2);
            this.button_AddNew.Margin = new System.Windows.Forms.Padding(2);
            this.button_AddNew.MinimumSize = new System.Drawing.Size(56, 30);
            this.button_AddNew.Name = "button_AddNew";
            this.button_AddNew.Size = new System.Drawing.Size(79, 30);
            this.button_AddNew.TabIndex = 5;
            this.button_AddNew.Text = "Add New";
            this.button_AddNew.UseVisualStyleBackColor = true;
            this.button_AddNew.Click += new System.EventHandler(this.Button_AddNew_Click);
            // 
            // button_Save
            // 
            this.button_Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_Save.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Location = new Point(85, 2);
            this.button_Save.Margin = new System.Windows.Forms.Padding(2);
            this.button_Save.MinimumSize = new System.Drawing.Size(56, 30);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(56, 30);
            this.button_Save.TabIndex = 2;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_Delete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Delete.Location = new Point(145, 2);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.button_Delete.MinimumSize = new System.Drawing.Size(56, 30);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(64, 30);
            this.button_Delete.TabIndex = 3;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(854, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " Generate a Group of new PartNumber.                  ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewExtended_AddNewComp
            // 
            this.dataGridViewExtended_AddNewComp.BindingCompleted = false;
            this.dataGridViewExtended_AddNewComp.CurrentColumnActive = null;
            this.dataGridViewExtended_AddNewComp.CurrentDataGridViewRowMouseOver = null;
            this.dataGridViewExtended_AddNewComp.CurrentDataRowViewMouseOver = null;
            this.dataGridViewExtended_AddNewComp.CurrentEmployeesLogIn = null;
            this.dataGridViewExtended_AddNewComp.CurrentRowBackgroundColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewExtended_AddNewComp.CurrentRowBorderColor = System.Drawing.Color.DarkBlue;
            this.dataGridViewExtended_AddNewComp.CurrentRowMouseOverStatus = null;
            this.dataGridViewExtended_AddNewComp.CustomEdit = MyCode.EditMode.View;
            this.dataGridViewExtended_AddNewComp.DataGridViewDrawDoubleBuffering = false;
            this.dataGridViewExtended_AddNewComp.DividerColor = System.Drawing.Color.Red;
            this.dataGridViewExtended_AddNewComp.DividerHeight = 0;
            this.dataGridViewExtended_AddNewComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExtended_AddNewComp.FirstDisplayedRow = null;
            this.dataGridViewExtended_AddNewComp.IsCurrentCellInEditMode = false;
            this.dataGridViewExtended_AddNewComp.IsMouseDrivenEvent = false;
            this.dataGridViewExtended_AddNewComp.Location = new Point(0, 0);
            this.dataGridViewExtended_AddNewComp.Name = "dataGridViewExtended_AddNewComp";
            this.dataGridViewExtended_AddNewComp.NeedSaveData = false;
            this.dataGridViewExtended_AddNewComp.SelectionBorderWidth = 3;
            this.dataGridViewExtended_AddNewComp.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridViewExtended_AddNewComp.SetValueAt = null;
            this.dataGridViewExtended_AddNewComp.Size = new System.Drawing.Size(1072, 381);
            this.dataGridViewExtended_AddNewComp.TabIndex = 0;
            // 
            // _contextMenuStripTreeView
            // 
            this._contextMenuStripTreeView.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this._contextMenuStripTreeView.ImeMode = System.Windows.Forms.ImeMode.On;
            this._contextMenuStripTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_singleExpandedNode,
            this.ToolStripMenuItem_multipleExpandedNodes,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_ExpandAll,
            this.ToolStripMenuItem_CollaseAll,
            this.toolStripSeparator2,
            this.ToolStripMenuItem_AddNewComponent,
            this.toolStripSeparator3,
            this.ToolStripMenuItem_showSettingDialog,
            this.toolStripSeparator4,
            this.ToolStripMenuItem_refresh,
            this.ToolStripMenuItem_SetPictures,
            this.toolStripMenuItem_estimatedFor});
            this._contextMenuStripTreeView.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this._contextMenuStripTreeView.Name = "PreviewDataGridViewContextMenuStrip";
            this._contextMenuStripTreeView.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._contextMenuStripTreeView.ShowImageMargin = false;
            this._contextMenuStripTreeView.Size = new System.Drawing.Size(184, 226);
            // 
            // ToolStripMenuItem_singleExpandedNode
            // 
            this.ToolStripMenuItem_singleExpandedNode.Name = "ToolStripMenuItem_singleExpandedNode";
            this.ToolStripMenuItem_singleExpandedNode.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem_singleExpandedNode.Text = "Single expanded node";
            // 
            // ToolStripMenuItem_multipleExpandedNodes
            // 
            this.ToolStripMenuItem_multipleExpandedNodes.Name = "ToolStripMenuItem_multipleExpandedNodes";
            this.ToolStripMenuItem_multipleExpandedNodes.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem_multipleExpandedNodes.Text = "Multiple expanded nodes";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // ToolStripMenuItem_ExpandAll
            // 
            this.ToolStripMenuItem_ExpandAll.Name = "ToolStripMenuItem_ExpandAll";
            this.ToolStripMenuItem_ExpandAll.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem_ExpandAll.Text = "Expand All Nodes";
            // 
            // ToolStripMenuItem_CollaseAll
            // 
            this.ToolStripMenuItem_CollaseAll.Name = "ToolStripMenuItem_CollaseAll";
            this.ToolStripMenuItem_CollaseAll.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem_CollaseAll.Text = "Collapse All Nodes";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // ToolStripMenuItem_AddNewComponent
            // 
            this.ToolStripMenuItem_AddNewComponent.Name = "ToolStripMenuItem_AddNewComponent";
            this.ToolStripMenuItem_AddNewComponent.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem_AddNewComponent.Text = "Add new Component";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(180, 6);
            // 
            // ToolStripMenuItem_showSettingDialog
            // 
            this.ToolStripMenuItem_showSettingDialog.Name = "ToolStripMenuItem_showSettingDialog";
            this.ToolStripMenuItem_showSettingDialog.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem_showSettingDialog.Text = "Show Setting Dialog";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(180, 6);
            // 
            // ToolStripMenuItem_refresh
            // 
            this.ToolStripMenuItem_refresh.Name = "ToolStripMenuItem_refresh";
            this.ToolStripMenuItem_refresh.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem_refresh.Text = "Refresh";
            // 
            // ToolStripMenuItem_SetPictures
            // 
            this.ToolStripMenuItem_SetPictures.Name = "ToolStripMenuItem_SetPictures";
            this.ToolStripMenuItem_SetPictures.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem_SetPictures.Text = "Set Pictures";
            // 
            // toolStripMenuItem_estimatedFor
            // 
            this.toolStripMenuItem_estimatedFor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem_estimatedFor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_QuantityEstimated});
            this.toolStripMenuItem_estimatedFor.Name = "toolStripMenuItem_estimatedFor";
            this.toolStripMenuItem_estimatedFor.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem_estimatedFor.Text = "Estimated for";
            // 
            // toolStripComboBox_QuantityEstimated
            // 
            this.toolStripComboBox_QuantityEstimated.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.toolStripComboBox_QuantityEstimated.Items.AddRange(new object[] {
            "100 pcs.",
            "250 pcs.",
            "300 pcs.",
            "500 pcs.",
            "750 pcs.",
            "1000 pcs.",
            "1250 pcs.",
            "1500 pcs.",
            "2000 pcs.",
            "2500 pcs.",
            "3000 pcs."});
            this.toolStripComboBox_QuantityEstimated.MaxDropDownItems = 15;
            this.toolStripComboBox_QuantityEstimated.Name = "toolStripComboBox_QuantityEstimated";
            this.toolStripComboBox_QuantityEstimated.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox_QuantityEstimated.Text = "500 pcs.";
            // 
            // StockRoom_AddNewComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 795);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "StockRoom_AddNewComp";
            this.Text = "Microsoft® Visual Studio® - Microsoft® Visual Studio® 2010 - Microsoft® Visual St" +
    "udio® 2010 - StockRoom Add New Component.";
            this.Title = "Microsoft® Visual Studio® - Microsoft® Visual Studio® 2010 - Microsoft® Visual St" +
    "udio® 2010 - StockRoom Add New Component.";
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceTreeViewBase)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.customTabControl_AddNewComp.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grouper_ItemProperties.ResumeLayout(false);
            this.grouper_ItemProperties.PerformLayout();
            this.flowLayoutPanel_ItemsProperties.ResumeLayout(false);
            this.grouper_NewItemButtons.ResumeLayout(false);
            this.grouper_NewItemButtons.PerformLayout();
            this.flowLayoutPanel_Buttons.ResumeLayout(false);
            this._contextMenuStripTreeView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CodeVendor.Controls.Grouper grouper_ItemProperties;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_ItemsProperties;
        private MyStuff11net.ComboBoxExtended comboBoxExtended_PartNumber;
        private MyStuff11net.ComboBoxExtended comboBoxExtended_Description;
        private MyStuff11net.ComboBoxExtended comboBoxExtended_Status;
        private CodeVendor.Controls.Grouper grouper_NewItemButtons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Buttons;
        private System.Windows.Forms.Button button_AddNew;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Delete;
        private MyStuff11net.ComboBoxExtended comboBoxExtended1;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStripTreeView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_singleExpandedNode;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_multipleExpandedNodes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ExpandAll;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CollaseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_AddNewComponent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_showSettingDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_refresh;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SetPictures;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_estimatedFor;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_QuantityEstimated;
        private System.Windows.Forms.CustomTabControl customTabControl_AddNewComp;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MyStuff11net.DataGridViewExtend.DataGridViewExtended dataGridViewExtended_AddNewComp;
    }
}
using System.Drawing;

namespace MyStuff11net
{
    partial class NodeSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeSetting));
            contextMenuStrip_AvailableDepartmentsSetting = new ContextMenuStrip(components);
            toolStripMenuItem_AvailableToAllDepartments = new ToolStripMenuItem();
            toolStripMenuItem_UnavailableToAllDepartements = new ToolStripMenuItem();
            customTabControl = new CustomTabControl();
            tabPage_Properties = new TabPage();
            panel3 = new Panel();
            queryBuilder = new QueryBuilder();
            panel1 = new Panel();
            grouper_Name = new CodeVendor.Controls.Grouper();
            panel9 = new Panel();
            panel11 = new Panel();
            textBox_Description = new TextBox();
            label_Description = new Label();
            panel10 = new Panel();
            textBox_Title = new TextBox();
            label1 = new Label();
            panel7 = new Panel();
            panel8 = new Panel();
            pictureBox_Image = new PictureBox();
            label_Node_Image = new Label();
            textBox_Node_Name = new TextBox();
            textBox_Node_PDF_Information = new TextBox();
            label_Node_PDF_Information = new Label();
            label_Node_Name = new Label();
            label_Node_Picture = new Label();
            textBox_Node_Picture = new TextBox();
            tabPage_CustomNodeResponse = new TabPage();
            grouperSetDepartmentFilter = new CodeVendor.Controls.Grouper();
            label_FilterString = new Label();
            label_FilterStatus = new Label();
            buttonFilter = new Button();
            panelSetDepartmentFilter = new Panel();
            labelSetDepartmentFilter = new Label();
            grouper_SettingAvailableMenuInTheseDepartments = new CodeVendor.Controls.Grouper();
            flowLayoutPanel_AvailableDepartments = new FlowLayoutPanel();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            panel_SeletaDepartmentWherethisMenuWillbeAvailable = new Panel();
            label_SeletDepartment = new Label();
            contextMenuStrip_AvailableDepartmentsSetting.SuspendLayout();
            customTabControl.SuspendLayout();
            tabPage_Properties.SuspendLayout();
            panel3.SuspendLayout();
            grouper_Name.SuspendLayout();
            panel9.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Image).BeginInit();
            tabPage_CustomNodeResponse.SuspendLayout();
            grouperSetDepartmentFilter.SuspendLayout();
            panelSetDepartmentFilter.SuspendLayout();
            grouper_SettingAvailableMenuInTheseDepartments.SuspendLayout();
            flowLayoutPanel_AvailableDepartments.SuspendLayout();
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip_AvailableDepartmentsSetting
            // 
            contextMenuStrip_AvailableDepartmentsSetting.BackColor = Color.LightGoldenrodYellow;
            contextMenuStrip_AvailableDepartmentsSetting.ImageScalingSize = new Size(20, 20);
            contextMenuStrip_AvailableDepartmentsSetting.ImeMode = ImeMode.On;
            contextMenuStrip_AvailableDepartmentsSetting.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_AvailableToAllDepartments, toolStripMenuItem_UnavailableToAllDepartements });
            contextMenuStrip_AvailableDepartmentsSetting.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            contextMenuStrip_AvailableDepartmentsSetting.Name = "PreviewDataGridViewContextMenuStrip";
            contextMenuStrip_AvailableDepartmentsSetting.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip_AvailableDepartmentsSetting.ShowImageMargin = false;
            contextMenuStrip_AvailableDepartmentsSetting.Size = new Size(275, 56);
            contextMenuStrip_AvailableDepartmentsSetting.Text = "Node Setting";
            // 
            // toolStripMenuItem_AvailableToAllDepartments
            // 
            toolStripMenuItem_AvailableToAllDepartments.Name = "toolStripMenuItem_AvailableToAllDepartments";
            toolStripMenuItem_AvailableToAllDepartments.Size = new Size(274, 26);
            toolStripMenuItem_AvailableToAllDepartments.Text = "Available to all departments";
            toolStripMenuItem_AvailableToAllDepartments.ToolTipText = "This is a global setting, select to make this menu available to all departments.";
            // 
            // toolStripMenuItem_UnavailableToAllDepartements
            // 
            toolStripMenuItem_UnavailableToAllDepartements.Name = "toolStripMenuItem_UnavailableToAllDepartements";
            toolStripMenuItem_UnavailableToAllDepartements.Size = new Size(274, 26);
            toolStripMenuItem_UnavailableToAllDepartements.Text = "Unavailable to all departements";
            toolStripMenuItem_UnavailableToAllDepartements.ToolTipText = "This is a global setting, select to make this menu unavailable to all departments.";
            // 
            // customTabControl
            // 
            customTabControl.Controls.Add(tabPage_Properties);
            customTabControl.Controls.Add(tabPage_CustomNodeResponse);
            customTabControl.DisplayStyle = TabStyle.Angled;
            // 
            // 
            // 
            customTabControl.DisplayStyleProvider.BorderColor = Color.DarkGray;
            customTabControl.DisplayStyleProvider.BorderColorHot = Color.DarkGray;
            customTabControl.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(127, 157, 185);
            customTabControl.DisplayStyleProvider.CloserColor = Color.DarkGray;
            customTabControl.DisplayStyleProvider.Radius = 10;
            customTabControl.DisplayStyleProvider.TextColor = Color.Black;
            customTabControl.DisplayStyleProvider.TextColorDisabled = Color.DarkGray;
            customTabControl.DisplayStyleProvider.TextColorSelected = Color.Black;
            customTabControl.Dock = DockStyle.Fill;
            customTabControl.Location = new Point(0, 0);
            customTabControl.Margin = new Padding(0);
            customTabControl.Name = "customTabControl";
            customTabControl.SelectedIndex = 0;
            customTabControl.Size = new Size(733, 560);
            customTabControl.TabIndex = 17;
            // 
            // tabPage_Properties
            // 
            tabPage_Properties.Controls.Add(panel3);
            tabPage_Properties.Location = new Point(4, 4);
            tabPage_Properties.Margin = new Padding(4, 5, 4, 5);
            tabPage_Properties.Name = "tabPage_Properties";
            tabPage_Properties.Size = new Size(725, 525);
            tabPage_Properties.TabIndex = 0;
            tabPage_Properties.Text = "Properties";
            tabPage_Properties.UseVisualStyleBackColor = true;
            tabPage_Properties.Click += tabPage_Properties_Click;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.AutoSize = true;
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.Controls.Add(queryBuilder);
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(grouper_Name);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8);
            panel3.Size = new Size(725, 525);
            panel3.TabIndex = 18;
            // 
            // queryBuilder
            // 
            queryBuilder.AutoSize = true;
            queryBuilder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            queryBuilder.Dock = DockStyle.Top;
            queryBuilder.Location = new Point(8, 218);
            queryBuilder.Margin = new Padding(8);
            queryBuilder.MinimumSize = new Size(200, 100);
            queryBuilder.Name = "queryBuilder";
            queryBuilder.Size = new Size(709, 203);
            queryBuilder.TabIndex = 15;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.Transparent;
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(8, 208);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.MaximumSize = new Size(0, 66);
            panel1.MinimumSize = new Size(0, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(709, 10);
            panel1.TabIndex = 17;
            // 
            // grouper_Name
            // 
            grouper_Name.AutoSize = true;
            grouper_Name.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_Name.BackgroundColor = Color.Silver;
            grouper_Name.BackgroundGradientColor = Color.DimGray;
            grouper_Name.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_Name.BorderColor = Color.Black;
            grouper_Name.BorderThickness = 1F;
            grouper_Name.Controls.Add(panel9);
            grouper_Name.Controls.Add(panel7);
            grouper_Name.CustomGroupBoxColor = SystemColors.Control;
            grouper_Name.Dock = DockStyle.Top;
            grouper_Name.GroupImage = null;
            grouper_Name.GroupTitle = "Name";
            grouper_Name.Location = new Point(8, 8);
            grouper_Name.Margin = new Padding(4, 5, 4, 8);
            grouper_Name.MinimumSize = new Size(200, 200);
            grouper_Name.Name = "grouper_Name";
            grouper_Name.Padding = new Padding(5, 25, 5, 5);
            grouper_Name.PaintGroupBox = true;
            grouper_Name.RoundCorners = 10;
            grouper_Name.ShadowColor = Color.DarkGray;
            grouper_Name.ShadowControl = false;
            grouper_Name.ShadowThickness = 3;
            grouper_Name.Size = new Size(709, 200);
            grouper_Name.TabIndex = 13;
            // 
            // panel9
            // 
            panel9.Controls.Add(panel11);
            panel9.Controls.Add(panel10);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(435, 25);
            panel9.Margin = new Padding(10, 3, 3, 3);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(0, 0, 0, 5);
            panel9.Size = new Size(269, 170);
            panel9.TabIndex = 17;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Transparent;
            panel11.Controls.Add(textBox_Description);
            panel11.Controls.Add(label_Description);
            panel11.Dock = DockStyle.Bottom;
            panel11.Location = new Point(0, 65);
            panel11.Margin = new Padding(4, 5, 4, 5);
            panel11.MinimumSize = new Size(0, 50);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(8);
            panel11.Size = new Size(269, 100);
            panel11.TabIndex = 19;
            // 
            // textBox_Description
            // 
            textBox_Description.Dock = DockStyle.Fill;
            textBox_Description.Font = new Font("Segoe UI", 10F);
            textBox_Description.Location = new Point(8, 25);
            textBox_Description.Margin = new Padding(5);
            textBox_Description.Multiline = true;
            textBox_Description.Name = "textBox_Description";
            textBox_Description.Size = new Size(253, 67);
            textBox_Description.TabIndex = 11;
            textBox_Description.TextChanged += textBox_Description_TextChanged;
            // 
            // label_Description
            // 
            label_Description.AutoSize = true;
            label_Description.Dock = DockStyle.Top;
            label_Description.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label_Description.Location = new Point(8, 8);
            label_Description.Margin = new Padding(5);
            label_Description.Name = "label_Description";
            label_Description.Size = new Size(95, 17);
            label_Description.TabIndex = 4;
            label_Description.Text = "Description.";
            // 
            // panel10
            // 
            panel10.BackColor = Color.Transparent;
            panel10.Controls.Add(textBox_Title);
            panel10.Controls.Add(label1);
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(0, 0);
            panel10.Margin = new Padding(4, 5, 4, 5);
            panel10.MinimumSize = new Size(0, 50);
            panel10.Name = "panel10";
            panel10.Padding = new Padding(8);
            panel10.Size = new Size(269, 60);
            panel10.TabIndex = 18;
            // 
            // textBox_Title
            // 
            textBox_Title.Dock = DockStyle.Top;
            textBox_Title.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBox_Title.Location = new Point(8, 25);
            textBox_Title.Margin = new Padding(5);
            textBox_Title.Name = "textBox_Title";
            textBox_Title.Size = new Size(253, 29);
            textBox_Title.TabIndex = 11;
            textBox_Title.TextChanged += textBox_Title_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label1.Location = new Point(8, 8);
            label1.Margin = new Padding(5);
            label1.Name = "label1";
            label1.Size = new Size(54, 17);
            label1.TabIndex = 4;
            label1.Text = "Titule.";
            // 
            // panel7
            // 
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(textBox_Node_Name);
            panel7.Controls.Add(textBox_Node_PDF_Information);
            panel7.Controls.Add(label_Node_PDF_Information);
            panel7.Controls.Add(label_Node_Name);
            panel7.Controls.Add(label_Node_Picture);
            panel7.Controls.Add(textBox_Node_Picture);
            panel7.Dock = DockStyle.Left;
            panel7.Location = new Point(5, 25);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(430, 170);
            panel7.TabIndex = 16;
            // 
            // panel8
            // 
            panel8.Controls.Add(pictureBox_Image);
            panel8.Controls.Add(label_Node_Image);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(290, 0);
            panel8.Margin = new Padding(3, 3, 10, 3);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(0, 5, 0, 0);
            panel8.Size = new Size(140, 170);
            panel8.TabIndex = 17;
            // 
            // pictureBox_Image
            // 
            pictureBox_Image.BorderStyle = BorderStyle.Fixed3D;
            pictureBox_Image.Dock = DockStyle.Top;
            pictureBox_Image.Location = new Point(0, 22);
            pictureBox_Image.Margin = new Padding(4, 5, 4, 5);
            pictureBox_Image.Name = "pictureBox_Image";
            pictureBox_Image.Size = new Size(140, 143);
            pictureBox_Image.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_Image.TabIndex = 3;
            pictureBox_Image.TabStop = false;
            pictureBox_Image.DoubleClick += pictureBox_Image_DoubleClick;
            // 
            // label_Node_Image
            // 
            label_Node_Image.AutoSize = true;
            label_Node_Image.Dock = DockStyle.Top;
            label_Node_Image.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label_Node_Image.Location = new Point(0, 5);
            label_Node_Image.Margin = new Padding(4, 0, 4, 0);
            label_Node_Image.Name = "label_Node_Image";
            label_Node_Image.Size = new Size(56, 17);
            label_Node_Image.TabIndex = 1;
            label_Node_Image.Text = "Image.";
            // 
            // textBox_Node_Name
            // 
            textBox_Node_Name.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Node_Name.Location = new Point(20, 25);
            textBox_Node_Name.Margin = new Padding(4, 5, 4, 5);
            textBox_Node_Name.Name = "textBox_Node_Name";
            textBox_Node_Name.Size = new Size(262, 29);
            textBox_Node_Name.TabIndex = 10;
            textBox_Node_Name.TextChanged += TextBoxNodeNameTextChanged;
            // 
            // textBox_Node_PDF_Information
            // 
            textBox_Node_PDF_Information.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Node_PDF_Information.Location = new Point(20, 80);
            textBox_Node_PDF_Information.Margin = new Padding(4, 5, 4, 5);
            textBox_Node_PDF_Information.Name = "textBox_Node_PDF_Information";
            textBox_Node_PDF_Information.Size = new Size(263, 29);
            textBox_Node_PDF_Information.TabIndex = 12;
            textBox_Node_PDF_Information.Text = "Node PDF Information file name.pdf";
            textBox_Node_PDF_Information.TextChanged += TextBoxNodePdfInformationTextChanged;
            textBox_Node_PDF_Information.DoubleClick += TextBoxNodePdfInformationDoubleClick;
            // 
            // label_Node_PDF_Information
            // 
            label_Node_PDF_Information.AutoSize = true;
            label_Node_PDF_Information.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label_Node_PDF_Information.Location = new Point(20, 60);
            label_Node_PDF_Information.Margin = new Padding(4, 0, 4, 0);
            label_Node_PDF_Information.Name = "label_Node_PDF_Information";
            label_Node_PDF_Information.Size = new Size(172, 17);
            label_Node_PDF_Information.TabIndex = 11;
            label_Node_PDF_Information.Text = "Node PDF Information.";
            // 
            // label_Node_Name
            // 
            label_Node_Name.AutoSize = true;
            label_Node_Name.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label_Node_Name.Location = new Point(20, 5);
            label_Node_Name.Margin = new Padding(4, 0, 4, 0);
            label_Node_Name.Name = "label_Node_Name";
            label_Node_Name.Size = new Size(97, 17);
            label_Node_Name.TabIndex = 13;
            label_Node_Name.Text = "Node Name.";
            // 
            // label_Node_Picture
            // 
            label_Node_Picture.AutoSize = true;
            label_Node_Picture.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            label_Node_Picture.Location = new Point(14, 115);
            label_Node_Picture.Margin = new Padding(4, 0, 4, 0);
            label_Node_Picture.Name = "label_Node_Picture";
            label_Node_Picture.Size = new Size(178, 17);
            label_Node_Picture.TabIndex = 14;
            label_Node_Picture.Text = "Node Picture file name.";
            // 
            // textBox_Node_Picture
            // 
            textBox_Node_Picture.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Node_Picture.Location = new Point(20, 135);
            textBox_Node_Picture.Margin = new Padding(4, 5, 4, 5);
            textBox_Node_Picture.Name = "textBox_Node_Picture";
            textBox_Node_Picture.Size = new Size(262, 29);
            textBox_Node_Picture.TabIndex = 15;
            textBox_Node_Picture.Text = "Double click to select a picture.";
            textBox_Node_Picture.TextChanged += TextBoxNodePictureTextChanged;
            // 
            // tabPage_CustomNodeResponse
            // 
            tabPage_CustomNodeResponse.ContextMenuStrip = contextMenuStrip_AvailableDepartmentsSetting;
            tabPage_CustomNodeResponse.Controls.Add(grouperSetDepartmentFilter);
            tabPage_CustomNodeResponse.Controls.Add(grouper_SettingAvailableMenuInTheseDepartments);
            tabPage_CustomNodeResponse.Location = new Point(4, 4);
            tabPage_CustomNodeResponse.Margin = new Padding(4, 5, 4, 5);
            tabPage_CustomNodeResponse.Name = "tabPage_CustomNodeResponse";
            tabPage_CustomNodeResponse.Padding = new Padding(4, 5, 4, 5);
            tabPage_CustomNodeResponse.Size = new Size(725, 525);
            tabPage_CustomNodeResponse.TabIndex = 1;
            tabPage_CustomNodeResponse.Text = "Custom Node Response";
            tabPage_CustomNodeResponse.UseVisualStyleBackColor = true;
            // 
            // grouperSetDepartmentFilter
            // 
            grouperSetDepartmentFilter.BackgroundColor = Color.WhiteSmoke;
            grouperSetDepartmentFilter.BackgroundGradientColor = Color.Gainsboro;
            grouperSetDepartmentFilter.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouperSetDepartmentFilter.BackgroundImageLayout = ImageLayout.None;
            grouperSetDepartmentFilter.BorderColor = Color.Black;
            grouperSetDepartmentFilter.BorderThickness = 1F;
            grouperSetDepartmentFilter.Controls.Add(label_FilterString);
            grouperSetDepartmentFilter.Controls.Add(label_FilterStatus);
            grouperSetDepartmentFilter.Controls.Add(buttonFilter);
            grouperSetDepartmentFilter.Controls.Add(panelSetDepartmentFilter);
            grouperSetDepartmentFilter.CustomGroupBoxColor = Color.Cornsilk;
            grouperSetDepartmentFilter.Dock = DockStyle.Top;
            grouperSetDepartmentFilter.Font = new Font("Segoe UI", 12F);
            grouperSetDepartmentFilter.GroupImage = null;
            grouperSetDepartmentFilter.GroupTitle = "";
            grouperSetDepartmentFilter.Location = new Point(4, 307);
            grouperSetDepartmentFilter.Margin = new Padding(4, 5, 4, 5);
            grouperSetDepartmentFilter.MinimumSize = new Size(600, 100);
            grouperSetDepartmentFilter.Name = "grouperSetDepartmentFilter";
            grouperSetDepartmentFilter.Padding = new Padding(15, 25, 15, 16);
            grouperSetDepartmentFilter.PaintGroupBox = true;
            grouperSetDepartmentFilter.RoundCorners = 10;
            grouperSetDepartmentFilter.ShadowColor = Color.DarkGray;
            grouperSetDepartmentFilter.ShadowControl = false;
            grouperSetDepartmentFilter.ShadowThickness = 3;
            grouperSetDepartmentFilter.Size = new Size(717, 208);
            grouperSetDepartmentFilter.TabIndex = 16;
            // 
            // label_FilterString
            // 
            label_FilterString.AutoEllipsis = true;
            label_FilterString.BorderStyle = BorderStyle.FixedSingle;
            label_FilterString.Location = new Point(15, 148);
            label_FilterString.Name = "label_FilterString";
            label_FilterString.Size = new Size(530, 44);
            label_FilterString.TabIndex = 27;
            label_FilterString.Text = "Filter";
            // 
            // label_FilterStatus
            // 
            label_FilterStatus.AutoEllipsis = true;
            label_FilterStatus.AutoSize = true;
            label_FilterStatus.BorderStyle = BorderStyle.FixedSingle;
            label_FilterStatus.Location = new Point(15, 121);
            label_FilterStatus.Name = "label_FilterStatus";
            label_FilterStatus.Size = new Size(47, 23);
            label_FilterStatus.TabIndex = 27;
            label_FilterStatus.Text = "Filter";
            // 
            // buttonFilter
            // 
            buttonFilter.AutoEllipsis = true;
            buttonFilter.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            buttonFilter.Location = new Point(566, 121);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(133, 71);
            buttonFilter.TabIndex = 26;
            buttonFilter.Text = "  Hide    Filter";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // panelSetDepartmentFilter
            // 
            panelSetDepartmentFilter.BackColor = Color.Ivory;
            panelSetDepartmentFilter.BorderStyle = BorderStyle.FixedSingle;
            panelSetDepartmentFilter.Controls.Add(labelSetDepartmentFilter);
            panelSetDepartmentFilter.Dock = DockStyle.Top;
            panelSetDepartmentFilter.Font = new Font("Segoe UI", 10F);
            panelSetDepartmentFilter.Location = new Point(15, 25);
            panelSetDepartmentFilter.Margin = new Padding(4, 5, 4, 5);
            panelSetDepartmentFilter.Name = "panelSetDepartmentFilter";
            panelSetDepartmentFilter.Padding = new Padding(8);
            panelSetDepartmentFilter.Size = new Size(687, 84);
            panelSetDepartmentFilter.TabIndex = 25;
            // 
            // labelSetDepartmentFilter
            // 
            labelSetDepartmentFilter.AutoEllipsis = true;
            labelSetDepartmentFilter.Dock = DockStyle.Fill;
            labelSetDepartmentFilter.Font = new Font("Segoe UI", 12F);
            labelSetDepartmentFilter.Location = new Point(8, 8);
            labelSetDepartmentFilter.Margin = new Padding(4, 0, 4, 4);
            labelSetDepartmentFilter.Name = "labelSetDepartmentFilter";
            labelSetDepartmentFilter.Size = new Size(669, 66);
            labelSetDepartmentFilter.TabIndex = 18;
            labelSetDepartmentFilter.Text = resources.GetString("labelSetDepartmentFilter.Text");
            // 
            // grouper_SettingAvailableMenuInTheseDepartments
            // 
            grouper_SettingAvailableMenuInTheseDepartments.BackgroundColor = Color.WhiteSmoke;
            grouper_SettingAvailableMenuInTheseDepartments.BackgroundGradientColor = Color.Gainsboro;
            grouper_SettingAvailableMenuInTheseDepartments.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_SettingAvailableMenuInTheseDepartments.BorderColor = Color.Black;
            grouper_SettingAvailableMenuInTheseDepartments.BorderThickness = 1F;
            grouper_SettingAvailableMenuInTheseDepartments.Controls.Add(flowLayoutPanel_AvailableDepartments);
            grouper_SettingAvailableMenuInTheseDepartments.Controls.Add(panel_SeletaDepartmentWherethisMenuWillbeAvailable);
            grouper_SettingAvailableMenuInTheseDepartments.CustomGroupBoxColor = Color.Cornsilk;
            grouper_SettingAvailableMenuInTheseDepartments.Dock = DockStyle.Top;
            grouper_SettingAvailableMenuInTheseDepartments.Font = new Font("Segoe UI", 12F);
            grouper_SettingAvailableMenuInTheseDepartments.GroupImage = null;
            grouper_SettingAvailableMenuInTheseDepartments.GroupTitle = "Setting available menu in these departments.";
            grouper_SettingAvailableMenuInTheseDepartments.Location = new Point(4, 5);
            grouper_SettingAvailableMenuInTheseDepartments.Margin = new Padding(4, 5, 4, 5);
            grouper_SettingAvailableMenuInTheseDepartments.MinimumSize = new Size(600, 226);
            grouper_SettingAvailableMenuInTheseDepartments.Name = "grouper_SettingAvailableMenuInTheseDepartments";
            grouper_SettingAvailableMenuInTheseDepartments.Padding = new Padding(15, 48, 15, 16);
            grouper_SettingAvailableMenuInTheseDepartments.PaintGroupBox = true;
            grouper_SettingAvailableMenuInTheseDepartments.RoundCorners = 10;
            grouper_SettingAvailableMenuInTheseDepartments.ShadowColor = Color.DarkGray;
            grouper_SettingAvailableMenuInTheseDepartments.ShadowControl = false;
            grouper_SettingAvailableMenuInTheseDepartments.ShadowThickness = 3;
            grouper_SettingAvailableMenuInTheseDepartments.Size = new Size(717, 302);
            grouper_SettingAvailableMenuInTheseDepartments.TabIndex = 15;
            // 
            // flowLayoutPanel_AvailableDepartments
            // 
            flowLayoutPanel_AvailableDepartments.Controls.Add(checkBox1);
            flowLayoutPanel_AvailableDepartments.Controls.Add(checkBox2);
            flowLayoutPanel_AvailableDepartments.Controls.Add(checkBox3);
            flowLayoutPanel_AvailableDepartments.Controls.Add(checkBox4);
            flowLayoutPanel_AvailableDepartments.Controls.Add(checkBox5);
            flowLayoutPanel_AvailableDepartments.Dock = DockStyle.Fill;
            flowLayoutPanel_AvailableDepartments.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel_AvailableDepartments.Location = new Point(15, 93);
            flowLayoutPanel_AvailableDepartments.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel_AvailableDepartments.Name = "flowLayoutPanel_AvailableDepartments";
            flowLayoutPanel_AvailableDepartments.Size = new Size(687, 193);
            flowLayoutPanel_AvailableDepartments.TabIndex = 16;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(4, 5);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(102, 25);
            checkBox1.TabIndex = 20;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(4, 40);
            checkBox2.Margin = new Padding(4, 5, 4, 5);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(102, 25);
            checkBox2.TabIndex = 21;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(4, 75);
            checkBox3.Margin = new Padding(4, 5, 4, 5);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(102, 25);
            checkBox3.TabIndex = 22;
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(4, 110);
            checkBox4.Margin = new Padding(4, 5, 4, 5);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(102, 25);
            checkBox4.TabIndex = 23;
            checkBox4.Text = "checkBox4";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(4, 145);
            checkBox5.Margin = new Padding(4, 5, 4, 5);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(102, 25);
            checkBox5.TabIndex = 24;
            checkBox5.Text = "checkBox5";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // panel_SeletaDepartmentWherethisMenuWillbeAvailable
            // 
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.BackColor = Color.Ivory;
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.BorderStyle = BorderStyle.FixedSingle;
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.Controls.Add(label_SeletDepartment);
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.Dock = DockStyle.Top;
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.Location = new Point(15, 48);
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.Margin = new Padding(4, 5, 4, 5);
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.Name = "panel_SeletaDepartmentWherethisMenuWillbeAvailable";
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.Padding = new Padding(8, 8, 8, 2);
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.Size = new Size(687, 45);
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.TabIndex = 25;
            // 
            // label_SeletDepartment
            // 
            label_SeletDepartment.AutoSize = true;
            label_SeletDepartment.Dock = DockStyle.Top;
            label_SeletDepartment.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label_SeletDepartment.Location = new Point(8, 8);
            label_SeletDepartment.Margin = new Padding(4, 0, 4, 0);
            label_SeletDepartment.Name = "label_SeletDepartment";
            label_SeletDepartment.Size = new Size(649, 25);
            label_SeletDepartment.TabIndex = 18;
            label_SeletDepartment.Text = "Check mark those departments where this treeView menu will be available.";
            // 
            // NodeSetting
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoScrollMinSize = new Size(730, 459);
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(customTabControl);
            Margin = new Padding(4, 5, 4, 5);
            Name = "NodeSetting";
            Size = new Size(733, 560);
            contextMenuStrip_AvailableDepartmentsSetting.ResumeLayout(false);
            customTabControl.ResumeLayout(false);
            tabPage_Properties.ResumeLayout(false);
            tabPage_Properties.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            grouper_Name.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Image).EndInit();
            tabPage_CustomNodeResponse.ResumeLayout(false);
            grouperSetDepartmentFilter.ResumeLayout(false);
            grouperSetDepartmentFilter.PerformLayout();
            panelSetDepartmentFilter.ResumeLayout(false);
            grouper_SettingAvailableMenuInTheseDepartments.ResumeLayout(false);
            flowLayoutPanel_AvailableDepartments.ResumeLayout(false);
            flowLayoutPanel_AvailableDepartments.PerformLayout();
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.ResumeLayout(false);
            panel_SeletaDepartmentWherethisMenuWillbeAvailable.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_AvailableDepartmentsSetting;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AvailableToAllDepartments;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_UnavailableToAllDepartements;
        private CustomTabControl customTabControl;
        private TabPage tabPage_Properties;
        private Panel panel3;
        private CodeVendor.Controls.Grouper grouper_Name;
        private TextBox textBox_Node_Picture;
        private Label label_Node_Picture;
        private Label label_Node_Name;
        private TextBox textBox_Node_PDF_Information;
        private Label label_Node_PDF_Information;
        private TextBox textBox_Node_Name;
        private Label label1;
        private Label label_Node_Image;
        private PictureBox pictureBox_Image;
        private Panel panel1;
        private TabPage tabPage_CustomNodeResponse;
        private CodeVendor.Controls.Grouper grouper_SettingAvailableMenuInTheseDepartments;
        private FlowLayoutPanel flowLayoutPanel_AvailableDepartments;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private Panel panel_SeletaDepartmentWherethisMenuWillbeAvailable;
        private Label label_SeletDepartment;
        private QueryBuilder queryBuilder;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panel10;
        private TextBox textBox_Title;
        private Panel panel11;
        private TextBox textBox_Description;
        private Label label_Description;
        private CodeVendor.Controls.Grouper grouperSetDepartmentFilter;
        private Panel panelSetDepartmentFilter;
        private Label labelSetDepartmentFilter;
        private Button buttonFilter;
        private Label label_FilterStatus;
        private Label label_FilterString;
    }
}

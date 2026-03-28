using MyStuff11net;
using MyStuff11net.DataGridViewExtend;
using System.Drawing;

namespace StockRoom11net
{
    partial class LabelsPrintsSMT
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
            customTabControl1 = new CustomTabControl();
            tabPage1 = new TabPage();
            splitContainer1 = new SplitContainer();
            grouper_PCB_PartNumber = new CodeVendor.Controls.Grouper();
            label_PreviousDescription = new Label();
            ListBox_PreviosUsedDescription = new ListBox();
            textBox_PartNumber_Data = new TextBox();
            label_Text_Description = new Label();
            textBox_Description = new TextBox();
            grouper_PrintSettings = new CodeVendor.Controls.Grouper();
            label2 = new Label();
            checkBox_print = new CheckBox();
            checkBox_EncodeCode = new CheckBox();
            label_DarknessValue = new Label();
            numericUpDown_DarknessValue = new NumericUpDown();
            grouper_PrintInformation = new CodeVendor.Controls.Grouper();
            button_Print = new Button();
            label_Counter_Start = new Label();
            numericUpDown_StartingValue = new NumericUpDown();
            numericUpDown_Quantity = new NumericUpDown();
            label_Quantity = new Label();
            panel1 = new Panel();
            grouper_BarCode2 = new CodeVendor.Controls.Grouper();
            label_Description_2 = new Label();
            label_HumanReadableInformation_2 = new Label();
            pictureBox_BarCode_Image_2 = new PictureBox();
            label_LabelInformation = new Label();
            grouper_BarCode = new CodeVendor.Controls.Grouper();
            label_HumanReadableInformation = new Label();
            label_Description = new Label();
            pictureBox_BarCode_Image = new PictureBox();
            tabPage2 = new TabPage();
            _dataGridViewLabelsSMT = new DataGridViewExtended();
            ((System.ComponentModel.ISupportInitialize)BindingSourceTreeViewBase).BeginInit();
            customTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grouper_PCB_PartNumber.SuspendLayout();
            grouper_PrintSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_DarknessValue).BeginInit();
            grouper_PrintInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_StartingValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Quantity).BeginInit();
            panel1.SuspendLayout();
            grouper_BarCode2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_BarCode_Image_2).BeginInit();
            grouper_BarCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_BarCode_Image).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tabPage1);
            customTabControl1.Controls.Add(tabPage2);
            customTabControl1.DisplayStyle = TabStyle.VisualStudio;
            // 
            // 
            // 
            customTabControl1.DisplayStyleProvider.BorderColor = SystemColors.ControlDark;
            customTabControl1.DisplayStyleProvider.BorderColorHot = SystemColors.ControlDark;
            customTabControl1.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(132, 130, 132);
            customTabControl1.DisplayStyleProvider.CloserColor = Color.DarkGray;
            customTabControl1.DisplayStyleProvider.FocusTrack = false;
            customTabControl1.DisplayStyleProvider.HotTrack = true;
            customTabControl1.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleRight;
            customTabControl1.DisplayStyleProvider.Opacity = 1F;
            customTabControl1.DisplayStyleProvider.Overlap = 7;
            customTabControl1.DisplayStyleProvider.Padding = new Point(14, 1);
            customTabControl1.DisplayStyleProvider.ShowTabCloser = false;
            customTabControl1.DisplayStyleProvider.TextColor = SystemColors.ControlText;
            customTabControl1.DisplayStyleProvider.TextColorDisabled = SystemColors.ControlDark;
            customTabControl1.DisplayStyleProvider.TextColorSelected = SystemColors.ControlText;
            customTabControl1.Dock = DockStyle.Fill;
            customTabControl1.HotTrack = true;
            customTabControl1.Location = new Point(0, 0);
            customTabControl1.Margin = new Padding(4);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new Size(1182, 553);
            customTabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Location = new Point(4, 21);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(1174, 528);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Project Labels        ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(4, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grouper_PCB_PartNumber);
            splitContainer1.Panel1.Controls.Add(grouper_PrintSettings);
            splitContainer1.Panel1.Controls.Add(grouper_PrintInformation);
            splitContainer1.Panel1.Padding = new Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2MinSize = 600;
            splitContainer1.Size = new Size(1166, 520);
            splitContainer1.SplitterDistance = 556;
            splitContainer1.TabIndex = 25;
            // 
            // grouper_PCB_PartNumber
            // 
            grouper_PCB_PartNumber.BackgroundColor = Color.Bisque;
            grouper_PCB_PartNumber.BackgroundGradientColor = Color.White;
            grouper_PCB_PartNumber.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_PCB_PartNumber.BorderColor = Color.Black;
            grouper_PCB_PartNumber.BorderThickness = 1F;
            grouper_PCB_PartNumber.Controls.Add(label_PreviousDescription);
            grouper_PCB_PartNumber.Controls.Add(ListBox_PreviosUsedDescription);
            grouper_PCB_PartNumber.Controls.Add(textBox_PartNumber_Data);
            grouper_PCB_PartNumber.Controls.Add(label_Text_Description);
            grouper_PCB_PartNumber.Controls.Add(textBox_Description);
            grouper_PCB_PartNumber.CustomGroupBoxColor = Color.White;
            grouper_PCB_PartNumber.Dock = DockStyle.Fill;
            grouper_PCB_PartNumber.GroupImage = null;
            grouper_PCB_PartNumber.GroupTitle = "PCB PartNumber here...";
            grouper_PCB_PartNumber.Location = new Point(10, 10);
            grouper_PCB_PartNumber.Margin = new Padding(4);
            grouper_PCB_PartNumber.Name = "grouper_PCB_PartNumber";
            grouper_PCB_PartNumber.Padding = new Padding(27, 25, 27, 25);
            grouper_PCB_PartNumber.PaintGroupBox = false;
            grouper_PCB_PartNumber.RoundCorners = 10;
            grouper_PCB_PartNumber.ShadowColor = Color.DarkGray;
            grouper_PCB_PartNumber.ShadowControl = false;
            grouper_PCB_PartNumber.ShadowThickness = 3;
            grouper_PCB_PartNumber.Size = new Size(532, 295);
            grouper_PCB_PartNumber.TabIndex = 23;
            // 
            // label_PreviousDescription
            // 
            label_PreviousDescription.AutoSize = true;
            label_PreviousDescription.ImeMode = ImeMode.NoControl;
            label_PreviousDescription.Location = new Point(31, 116);
            label_PreviousDescription.Margin = new Padding(4, 0, 4, 0);
            label_PreviousDescription.Name = "label_PreviousDescription";
            label_PreviousDescription.Size = new Size(191, 21);
            label_PreviousDescription.TabIndex = 26;
            label_PreviousDescription.Text = "Previous used description.";
            // 
            // ListBox_PreviosUsedDescription
            // 
            ListBox_PreviosUsedDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ListBox_PreviosUsedDescription.BackColor = Color.Linen;
            ListBox_PreviosUsedDescription.DataSource = BindingSourceTreeViewBase;
            ListBox_PreviosUsedDescription.DisplayMember = "Description";
            ListBox_PreviosUsedDescription.Enabled = false;
            ListBox_PreviosUsedDescription.FormattingEnabled = true;
            ListBox_PreviosUsedDescription.ItemHeight = 21;
            ListBox_PreviosUsedDescription.Location = new Point(31, 136);
            ListBox_PreviosUsedDescription.Name = "ListBox_PreviosUsedDescription";
            ListBox_PreviosUsedDescription.Size = new Size(469, 109);
            ListBox_PreviosUsedDescription.TabIndex = 25;
            ListBox_PreviosUsedDescription.ValueMember = "Description";
            ListBox_PreviosUsedDescription.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            ListBox_PreviosUsedDescription.Format += ListBox_PreviosUsedDescription_Format;
            // 
            // textBox_PartNumber_Data
            // 
            textBox_PartNumber_Data.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_PartNumber_Data.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_PartNumber_Data.Location = new Point(31, 30);
            textBox_PartNumber_Data.Margin = new Padding(4);
            textBox_PartNumber_Data.Name = "textBox_PartNumber_Data";
            textBox_PartNumber_Data.Size = new Size(469, 23);
            textBox_PartNumber_Data.TabIndex = 24;
            textBox_PartNumber_Data.TextChanged += TextBox_PartNumber_Data_TextChanged;
            // 
            // label_Text_Description
            // 
            label_Text_Description.AutoSize = true;
            label_Text_Description.ImeMode = ImeMode.NoControl;
            label_Text_Description.Location = new Point(31, 66);
            label_Text_Description.Margin = new Padding(4, 0, 4, 0);
            label_Text_Description.Name = "label_Text_Description";
            label_Text_Description.Size = new Size(178, 21);
            label_Text_Description.TabIndex = 13;
            label_Text_Description.Text = "Description Information.";
            // 
            // textBox_Description
            // 
            textBox_Description.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Description.BackColor = Color.Linen;
            textBox_Description.Enabled = false;
            textBox_Description.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_Description.Location = new Point(31, 85);
            textBox_Description.Margin = new Padding(4);
            textBox_Description.Name = "textBox_Description";
            textBox_Description.Size = new Size(469, 23);
            textBox_Description.TabIndex = 12;
            textBox_Description.TextChanged += TextBox_Description_TextChanged;
            // 
            // grouper_PrintSettings
            // 
            grouper_PrintSettings.BackgroundColor = Color.NavajoWhite;
            grouper_PrintSettings.BackgroundGradientColor = Color.White;
            grouper_PrintSettings.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_PrintSettings.BorderColor = Color.Black;
            grouper_PrintSettings.BorderThickness = 1F;
            grouper_PrintSettings.Controls.Add(label2);
            grouper_PrintSettings.Controls.Add(checkBox_print);
            grouper_PrintSettings.Controls.Add(checkBox_EncodeCode);
            grouper_PrintSettings.Controls.Add(label_DarknessValue);
            grouper_PrintSettings.Controls.Add(numericUpDown_DarknessValue);
            grouper_PrintSettings.CustomGroupBoxColor = Color.White;
            grouper_PrintSettings.Dock = DockStyle.Bottom;
            grouper_PrintSettings.GroupImage = null;
            grouper_PrintSettings.GroupTitle = "Print Settings";
            grouper_PrintSettings.Location = new Point(10, 305);
            grouper_PrintSettings.Margin = new Padding(4);
            grouper_PrintSettings.Name = "grouper_PrintSettings";
            grouper_PrintSettings.Padding = new Padding(27, 25, 27, 15);
            grouper_PrintSettings.PaintGroupBox = false;
            grouper_PrintSettings.RoundCorners = 10;
            grouper_PrintSettings.ShadowColor = Color.DarkGray;
            grouper_PrintSettings.ShadowControl = false;
            grouper_PrintSettings.ShadowThickness = 3;
            grouper_PrintSettings.Size = new Size(532, 101);
            grouper_PrintSettings.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(174, 28);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 21);
            label2.TabIndex = 17;
            label2.Text = "Print Date ?";
            // 
            // checkBox_print
            // 
            checkBox_print.AutoSize = true;
            checkBox_print.Checked = true;
            checkBox_print.CheckState = CheckState.Checked;
            checkBox_print.ImeMode = ImeMode.NoControl;
            checkBox_print.Location = new Point(177, 52);
            checkBox_print.Margin = new Padding(4);
            checkBox_print.Name = "checkBox_print";
            checkBox_print.Size = new Size(102, 17);
            checkBox_print.TabIndex = 16;
            checkBox_print.Text = "Yes, will be print";
            checkBox_print.UseVisualStyleBackColor = true;
            checkBox_print.CheckedChanged += CheckBox_print_CheckedChanged;
            // 
            // checkBox_EncodeCode
            // 
            checkBox_EncodeCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            checkBox_EncodeCode.AutoSize = true;
            checkBox_EncodeCode.Checked = true;
            checkBox_EncodeCode.CheckState = CheckState.Checked;
            checkBox_EncodeCode.ImeMode = ImeMode.NoControl;
            checkBox_EncodeCode.Location = new Point(331, 52);
            checkBox_EncodeCode.Margin = new Padding(4);
            checkBox_EncodeCode.Name = "checkBox_EncodeCode";
            checkBox_EncodeCode.Size = new Size(119, 17);
            checkBox_EncodeCode.TabIndex = 18;
            checkBox_EncodeCode.Text = "Yes, will be Encode";
            checkBox_EncodeCode.UseVisualStyleBackColor = true;
            // 
            // label_DarknessValue
            // 
            label_DarknessValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_DarknessValue.AutoSize = true;
            label_DarknessValue.ImeMode = ImeMode.NoControl;
            label_DarknessValue.Location = new Point(16, 28);
            label_DarknessValue.Margin = new Padding(4, 0, 4, 0);
            label_DarknessValue.Name = "label_DarknessValue";
            label_DarknessValue.Size = new Size(161, 21);
            label_DarknessValue.TabIndex = 10;
            label_DarknessValue.Text = "Darkness (1.0 to 30.0)";
            // 
            // numericUpDown_DarknessValue
            // 
            numericUpDown_DarknessValue.DecimalPlaces = 1;
            numericUpDown_DarknessValue.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            numericUpDown_DarknessValue.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDown_DarknessValue.Location = new Point(20, 51);
            numericUpDown_DarknessValue.Margin = new Padding(4);
            numericUpDown_DarknessValue.Maximum = new decimal(new int[] { 300, 0, 0, 65536 });
            numericUpDown_DarknessValue.Minimum = new decimal(new int[] { 10, 0, 0, 65536 });
            numericUpDown_DarknessValue.Name = "numericUpDown_DarknessValue";
            numericUpDown_DarknessValue.Size = new Size(75, 24);
            numericUpDown_DarknessValue.TabIndex = 11;
            numericUpDown_DarknessValue.Value = new decimal(new int[] { 145, 0, 0, 65536 });
            numericUpDown_DarknessValue.ValueChanged += NumericUpDown_DarknessValue_ValueChanged;
            // 
            // grouper_PrintInformation
            // 
            grouper_PrintInformation.BackgroundColor = Color.PeachPuff;
            grouper_PrintInformation.BackgroundGradientColor = Color.White;
            grouper_PrintInformation.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_PrintInformation.BorderColor = Color.Black;
            grouper_PrintInformation.BorderThickness = 1F;
            grouper_PrintInformation.Controls.Add(button_Print);
            grouper_PrintInformation.Controls.Add(label_Counter_Start);
            grouper_PrintInformation.Controls.Add(numericUpDown_StartingValue);
            grouper_PrintInformation.Controls.Add(numericUpDown_Quantity);
            grouper_PrintInformation.Controls.Add(label_Quantity);
            grouper_PrintInformation.CustomGroupBoxColor = Color.White;
            grouper_PrintInformation.Dock = DockStyle.Bottom;
            grouper_PrintInformation.GroupImage = null;
            grouper_PrintInformation.GroupTitle = "Print Informations.";
            grouper_PrintInformation.Location = new Point(10, 406);
            grouper_PrintInformation.Margin = new Padding(4);
            grouper_PrintInformation.Name = "grouper_PrintInformation";
            grouper_PrintInformation.Padding = new Padding(15, 25, 15, 15);
            grouper_PrintInformation.PaintGroupBox = false;
            grouper_PrintInformation.RoundCorners = 10;
            grouper_PrintInformation.ShadowColor = Color.DarkGray;
            grouper_PrintInformation.ShadowControl = false;
            grouper_PrintInformation.ShadowThickness = 3;
            grouper_PrintInformation.Size = new Size(532, 100);
            grouper_PrintInformation.TabIndex = 24;
            // 
            // button_Print
            // 
            button_Print.Dock = DockStyle.Right;
            button_Print.FlatAppearance.MouseDownBackColor = Color.Blue;
            button_Print.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            button_Print.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            button_Print.ImeMode = ImeMode.NoControl;
            button_Print.Location = new Point(392, 25);
            button_Print.Margin = new Padding(5);
            button_Print.Name = "button_Print";
            button_Print.Size = new Size(125, 60);
            button_Print.TabIndex = 0;
            button_Print.Text = "Print...";
            button_Print.UseVisualStyleBackColor = true;
            button_Print.Click += Button_Print_Click;
            // 
            // label_Counter_Start
            // 
            label_Counter_Start.AutoSize = true;
            label_Counter_Start.ImeMode = ImeMode.NoControl;
            label_Counter_Start.Location = new Point(28, 28);
            label_Counter_Start.Margin = new Padding(4, 0, 4, 0);
            label_Counter_Start.Name = "label_Counter_Start";
            label_Counter_Start.Size = new Size(108, 21);
            label_Counter_Start.TabIndex = 5;
            label_Counter_Start.Text = "Starting value.";
            // 
            // numericUpDown_StartingValue
            // 
            numericUpDown_StartingValue.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            numericUpDown_StartingValue.Location = new Point(30, 49);
            numericUpDown_StartingValue.Margin = new Padding(4);
            numericUpDown_StartingValue.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown_StartingValue.Name = "numericUpDown_StartingValue";
            numericUpDown_StartingValue.Size = new Size(80, 24);
            numericUpDown_StartingValue.TabIndex = 9;
            numericUpDown_StartingValue.ValueChanged += NumericUpDown_StartingValue_ValueChanged;
            // 
            // numericUpDown_Quantity
            // 
            numericUpDown_Quantity.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            numericUpDown_Quantity.Location = new Point(149, 50);
            numericUpDown_Quantity.Margin = new Padding(4);
            numericUpDown_Quantity.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown_Quantity.Name = "numericUpDown_Quantity";
            numericUpDown_Quantity.Size = new Size(80, 24);
            numericUpDown_Quantity.TabIndex = 8;
            numericUpDown_Quantity.Value = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDown_Quantity.ValueChanged += NumericUpDown_Quantity_ValueChanged;
            // 
            // label_Quantity
            // 
            label_Quantity.AutoSize = true;
            label_Quantity.ImeMode = ImeMode.NoControl;
            label_Quantity.Location = new Point(152, 28);
            label_Quantity.Margin = new Padding(4, 0, 4, 0);
            label_Quantity.Name = "label_Quantity";
            label_Quantity.Size = new Size(93, 21);
            label_Quantity.TabIndex = 7;
            label_Quantity.Text = "Qty to print.";
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(grouper_BarCode2);
            panel1.Controls.Add(label_LabelInformation);
            panel1.Controls.Add(grouper_BarCode);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(602, 516);
            panel1.TabIndex = 23;
            // 
            // grouper_BarCode2
            // 
            grouper_BarCode2.BackgroundColor = Color.White;
            grouper_BarCode2.BackgroundGradientColor = Color.White;
            grouper_BarCode2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_BarCode2.BorderColor = Color.Black;
            grouper_BarCode2.BorderThickness = 1F;
            grouper_BarCode2.Controls.Add(label_Description_2);
            grouper_BarCode2.Controls.Add(label_HumanReadableInformation_2);
            grouper_BarCode2.Controls.Add(pictureBox_BarCode_Image_2);
            grouper_BarCode2.CustomGroupBoxColor = Color.White;
            grouper_BarCode2.GroupImage = null;
            grouper_BarCode2.GroupTitle = "";
            grouper_BarCode2.Location = new Point(307, 4);
            grouper_BarCode2.Margin = new Padding(4);
            grouper_BarCode2.Name = "grouper_BarCode2";
            grouper_BarCode2.Padding = new Padding(15, 25, 15, 4);
            grouper_BarCode2.PaintGroupBox = false;
            grouper_BarCode2.RoundCorners = 10;
            grouper_BarCode2.ShadowColor = Color.DarkGray;
            grouper_BarCode2.ShadowControl = false;
            grouper_BarCode2.ShadowThickness = 3;
            grouper_BarCode2.Size = new Size(280, 100);
            grouper_BarCode2.TabIndex = 22;
            // 
            // label_Description_2
            // 
            label_Description_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_Description_2.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            label_Description_2.ImeMode = ImeMode.NoControl;
            label_Description_2.Location = new Point(4, 74);
            label_Description_2.Margin = new Padding(0);
            label_Description_2.Name = "label_Description_2";
            label_Description_2.Size = new Size(271, 24);
            label_Description_2.TabIndex = 21;
            label_Description_2.Text = "Description field.";
            label_Description_2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_HumanReadableInformation_2
            // 
            label_HumanReadableInformation_2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_HumanReadableInformation_2.Font = new Font("Microsoft Sans Serif", 9F);
            label_HumanReadableInformation_2.ImeMode = ImeMode.NoControl;
            label_HumanReadableInformation_2.Location = new Point(4, 53);
            label_HumanReadableInformation_2.Margin = new Padding(4, 0, 4, 0);
            label_HumanReadableInformation_2.Name = "label_HumanReadableInformation_2";
            label_HumanReadableInformation_2.Size = new Size(271, 18);
            label_HumanReadableInformation_2.TabIndex = 20;
            label_HumanReadableInformation_2.Text = "Human Readable Information.";
            label_HumanReadableInformation_2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox_BarCode_Image_2
            // 
            pictureBox_BarCode_Image_2.BackColor = Color.White;
            pictureBox_BarCode_Image_2.ImeMode = ImeMode.NoControl;
            pictureBox_BarCode_Image_2.Location = new Point(4, 17);
            pictureBox_BarCode_Image_2.Margin = new Padding(4);
            pictureBox_BarCode_Image_2.Name = "pictureBox_BarCode_Image_2";
            pictureBox_BarCode_Image_2.Size = new Size(271, 32);
            pictureBox_BarCode_Image_2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_BarCode_Image_2.TabIndex = 14;
            pictureBox_BarCode_Image_2.TabStop = false;
            // 
            // label_LabelInformation
            // 
            label_LabelInformation.AutoSize = true;
            label_LabelInformation.Dock = DockStyle.Bottom;
            label_LabelInformation.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Italic);
            label_LabelInformation.ImeMode = ImeMode.NoControl;
            label_LabelInformation.Location = new Point(0, 483);
            label_LabelInformation.Margin = new Padding(4, 0, 4, 0);
            label_LabelInformation.Name = "label_LabelInformation";
            label_LabelInformation.Padding = new Padding(10);
            label_LabelInformation.Size = new Size(576, 33);
            label_LabelInformation.TabIndex = 21;
            label_LabelInformation.Text = "                                                                                                                                   Label type: Brady, THT-37-483-10";
            // 
            // grouper_BarCode
            // 
            grouper_BarCode.BackgroundColor = Color.White;
            grouper_BarCode.BackgroundGradientColor = Color.White;
            grouper_BarCode.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_BarCode.BorderColor = Color.Black;
            grouper_BarCode.BorderThickness = 1F;
            grouper_BarCode.Controls.Add(label_HumanReadableInformation);
            grouper_BarCode.Controls.Add(label_Description);
            grouper_BarCode.Controls.Add(pictureBox_BarCode_Image);
            grouper_BarCode.CustomGroupBoxColor = Color.White;
            grouper_BarCode.GroupImage = null;
            grouper_BarCode.GroupTitle = "";
            grouper_BarCode.Location = new Point(17, 4);
            grouper_BarCode.Margin = new Padding(4);
            grouper_BarCode.Name = "grouper_BarCode";
            grouper_BarCode.Padding = new Padding(15, 25, 15, 4);
            grouper_BarCode.PaintGroupBox = false;
            grouper_BarCode.RoundCorners = 10;
            grouper_BarCode.ShadowColor = Color.DarkGray;
            grouper_BarCode.ShadowControl = false;
            grouper_BarCode.ShadowThickness = 3;
            grouper_BarCode.Size = new Size(280, 100);
            grouper_BarCode.TabIndex = 19;
            // 
            // label_HumanReadableInformation
            // 
            label_HumanReadableInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_HumanReadableInformation.Font = new Font("Microsoft Sans Serif", 9F);
            label_HumanReadableInformation.ImeMode = ImeMode.NoControl;
            label_HumanReadableInformation.Location = new Point(4, 53);
            label_HumanReadableInformation.Margin = new Padding(4, 0, 4, 0);
            label_HumanReadableInformation.Name = "label_HumanReadableInformation";
            label_HumanReadableInformation.Size = new Size(271, 18);
            label_HumanReadableInformation.TabIndex = 20;
            label_HumanReadableInformation.Text = "Human Readable Information.";
            label_HumanReadableInformation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Description
            // 
            label_Description.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_Description.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            label_Description.ImeMode = ImeMode.NoControl;
            label_Description.Location = new Point(4, 74);
            label_Description.Margin = new Padding(0);
            label_Description.Name = "label_Description";
            label_Description.Size = new Size(271, 24);
            label_Description.TabIndex = 21;
            label_Description.Text = "Description field.";
            label_Description.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox_BarCode_Image
            // 
            pictureBox_BarCode_Image.BackColor = Color.White;
            pictureBox_BarCode_Image.ImeMode = ImeMode.NoControl;
            pictureBox_BarCode_Image.Location = new Point(4, 17);
            pictureBox_BarCode_Image.Margin = new Padding(4);
            pictureBox_BarCode_Image.Name = "pictureBox_BarCode_Image";
            pictureBox_BarCode_Image.Size = new Size(271, 32);
            pictureBox_BarCode_Image.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_BarCode_Image.TabIndex = 14;
            pictureBox_BarCode_Image.TabStop = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(_dataGridViewLabelsSMT);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4);
            tabPage2.Size = new Size(1174, 525);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Labels Record SMT";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // _dataGridViewLabelsSMT
            // 
            _dataGridViewLabelsSMT.BindingCompleted = false;
            _dataGridViewLabelsSMT.BindingNavigatorAddNewItemEnable = true;
            _dataGridViewLabelsSMT.BindingNavigatorDeleteItemEnable = false;
            _dataGridViewLabelsSMT.CurrentColumnActive = null;
            _dataGridViewLabelsSMT.CurrentDataGridViewRowMouseOver = null;
            _dataGridViewLabelsSMT.CurrentDataRowViewMouseOver = null;
            _dataGridViewLabelsSMT.CurrentEmployeesLogIn = null;
            _dataGridViewLabelsSMT.CurrentRowBackgroundColor = Color.DeepSkyBlue;
            _dataGridViewLabelsSMT.CurrentRowBorderColor = Color.DarkBlue;
            _dataGridViewLabelsSMT.CurrentRowMouseOverStatus = null;
            _dataGridViewLabelsSMT.CustomEdit = MyCode.EditMode.Delete;
            _dataGridViewLabelsSMT.DataGridViewDrawDoubleBuffering = false;
            _dataGridViewLabelsSMT.DividerColor = Color.Red;
            _dataGridViewLabelsSMT.DividerHeight = 0;
            _dataGridViewLabelsSMT.Dock = DockStyle.Fill;
            _dataGridViewLabelsSMT.FirstDisplayedRow = null;
            _dataGridViewLabelsSMT.IsCurrentCellInEditMode = false;
            _dataGridViewLabelsSMT.IsMouseDrivenEvent = false;
            _dataGridViewLabelsSMT.Location = new Point(4, 4);
            _dataGridViewLabelsSMT.Margin = new Padding(7, 6, 7, 6);
            _dataGridViewLabelsSMT.Name = "_dataGridViewLabelsSMT";
            _dataGridViewLabelsSMT.NeedSaveData = false;
            _dataGridViewLabelsSMT.SelectionBorderWidth = 3;
            _dataGridViewLabelsSMT.SelectionColor = Color.DeepSkyBlue;
            _dataGridViewLabelsSMT.SetValueAt = null;
            _dataGridViewLabelsSMT.Size = new Size(1166, 517);
            _dataGridViewLabelsSMT.TabIndex = 2;
            // 
            // LabelsPrintsSMT
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 553);
            Controls.Add(customTabControl1);
            Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "LabelsPrintsSMT";
            Load += LabelsPrintsSMT_Load;
            ((System.ComponentModel.ISupportInitialize)BindingSourceTreeViewBase).EndInit();
            customTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grouper_PCB_PartNumber.ResumeLayout(false);
            grouper_PCB_PartNumber.PerformLayout();
            grouper_PrintSettings.ResumeLayout(false);
            grouper_PrintSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_DarknessValue).EndInit();
            grouper_PrintInformation.ResumeLayout(false);
            grouper_PrintInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_StartingValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_Quantity).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grouper_BarCode2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_BarCode_Image_2).EndInit();
            grouper_BarCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_BarCode_Image).EndInit();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown numericUpDown_DarknessValue;
        private CodeVendor.Controls.Grouper grouper_PrintInformation;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.Label label_Counter_Start;
        private System.Windows.Forms.NumericUpDown numericUpDown_StartingValue;
        private System.Windows.Forms.NumericUpDown numericUpDown_Quantity;
        private System.Windows.Forms.Label label_Quantity;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label_Text_Description;
        private System.Windows.Forms.Label label_DarknessValue;
        private System.Windows.Forms.Panel panel1;
        private CodeVendor.Controls.Grouper grouper_BarCode2;
        private System.Windows.Forms.Label label_Description_2;
        private System.Windows.Forms.Label label_HumanReadableInformation_2;
        private System.Windows.Forms.PictureBox pictureBox_BarCode_Image_2;
        private System.Windows.Forms.Label label_LabelInformation;
        private CodeVendor.Controls.Grouper grouper_BarCode;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Label label_HumanReadableInformation;
        private System.Windows.Forms.PictureBox pictureBox_BarCode_Image;
        private System.Windows.Forms.CheckBox checkBox_EncodeCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_print;
        private System.Windows.Forms.TabPage tabPage2;
        private MyStuff11net.DataGridViewExtend.DataGridViewExtended _dataGridViewLabelsSMT;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CodeVendor.Controls.Grouper grouper_PCB_PartNumber;
        private System.Windows.Forms.TextBox textBox_PartNumber_Data;
        private CodeVendor.Controls.Grouper grouper_PrintSettings;
        private System.Windows.Forms.ListBox ListBox_PreviosUsedDescription;
        private System.Windows.Forms.Label label_PreviousDescription;
    }
}
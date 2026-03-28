using System.Drawing;

namespace MyStuff11net.ZPL2ZebraPrint
{
    partial class ZebraPrintsPCBLabels
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZebraPrintsPCBLabels));
            customTabControl1 = new System.Windows.Forms.CustomTabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            numericUpDown_DarknessValue = new System.Windows.Forms.NumericUpDown();
            grouper2 = new CodeVendor.Controls.Grouper();
            button_Print = new System.Windows.Forms.Button();
            label_Counter_Start = new System.Windows.Forms.Label();
            numericUpDown_StartingValue = new System.Windows.Forms.NumericUpDown();
            numericUpDown_Quantity = new System.Windows.Forms.NumericUpDown();
            label_Quantity = new System.Windows.Forms.Label();
            textBox_Description = new System.Windows.Forms.TextBox();
            label_Text_Description = new System.Windows.Forms.Label();
            label_DarknessValue = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            grouper1 = new CodeVendor.Controls.Grouper();
            label_Description_2 = new System.Windows.Forms.Label();
            label_HumanReadableInformation_2 = new System.Windows.Forms.Label();
            pictureBox_BarCode_Image_2 = new System.Windows.Forms.PictureBox();
            label_LabelInformation = new System.Windows.Forms.Label();
            grouper_Label = new CodeVendor.Controls.Grouper();
            label_Description = new System.Windows.Forms.Label();
            label_HumanReadableInformation = new System.Windows.Forms.Label();
            pictureBox_BarCode_Image = new System.Windows.Forms.PictureBox();
            grouper_BarCode = new CodeVendor.Controls.Grouper();
            textBox_Suffix = new System.Windows.Forms.TextBox();
            label_Suffix = new System.Windows.Forms.Label();
            label_BarCode_Prefix = new System.Windows.Forms.Label();
            textBox_BarCode_Prefix = new System.Windows.Forms.TextBox();
            textBox_BarCode_Data = new System.Windows.Forms.TextBox();
            label_Text_Data = new System.Windows.Forms.Label();
            checkBox_EncodeCode = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            richTextBox_ZPL = new System.Windows.Forms.RichTextBox();
            checkBox_print = new System.Windows.Forms.CheckBox();
            tabPage2 = new System.Windows.Forms.TabPage();
            _dataGridViewLabelsSMT = new MyStuff11net.DataGridViewExtend.DataGridViewExtended();
            customTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_DarknessValue)).BeginInit();
            grouper2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_StartingValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_Quantity)).BeginInit();
            panel1.SuspendLayout();
            grouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_BarCode_Image_2)).BeginInit();
            grouper_Label.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_BarCode_Image)).BeginInit();
            grouper_BarCode.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tabPage1);
            customTabControl1.Controls.Add(tabPage2);
            customTabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            customTabControl1.DisplayStyle = System.Windows.Forms.TabStyle.Default;
            // 
            // 
            // 
            customTabControl1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            customTabControl1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            customTabControl1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(130)))), ((int)(((byte)(132)))));
            customTabControl1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            customTabControl1.DisplayStyleProvider.FocusTrack = false;
            customTabControl1.DisplayStyleProvider.HotTrack = true;
            customTabControl1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            customTabControl1.DisplayStyleProvider.Opacity = 1F;
            customTabControl1.DisplayStyleProvider.Overlap = 7;
            customTabControl1.DisplayStyleProvider.Padding = new Point(14, 1);
            customTabControl1.DisplayStyleProvider.ShowTabCloser = false;
            customTabControl1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            customTabControl1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            customTabControl1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(customTabControl1, "customTabControl1");
            customTabControl1.HotTrack = true;
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(numericUpDown_DarknessValue);
            tabPage1.Controls.Add(grouper2);
            tabPage1.Controls.Add(label_DarknessValue);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(grouper_BarCode);
            tabPage1.Controls.Add(checkBox_EncodeCode);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(richTextBox_ZPL);
            tabPage1.Controls.Add(checkBox_print);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_DarknessValue
            // 
            numericUpDown_DarknessValue.DecimalPlaces = 1;
            resources.ApplyResources(numericUpDown_DarknessValue, "numericUpDown_DarknessValue");
            numericUpDown_DarknessValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            numericUpDown_DarknessValue.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            65536});
            numericUpDown_DarknessValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            numericUpDown_DarknessValue.Name = "numericUpDown_DarknessValue";
            numericUpDown_DarknessValue.Value = new decimal(new int[] {
            145,
            0,
            0,
            65536});
            numericUpDown_DarknessValue.ValueChanged += new System.EventHandler(NumericUpDown_DarknessValue_ValueChanged);
            // 
            // grouper2
            // 
            grouper2.BackgroundColor = System.Drawing.Color.Cornsilk;
            grouper2.BackgroundGradientColor = System.Drawing.Color.White;
            grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper2.BorderColor = System.Drawing.Color.Black;
            grouper2.BorderThickness = 1F;
            grouper2.Controls.Add(button_Print);
            grouper2.Controls.Add(label_Counter_Start);
            grouper2.Controls.Add(numericUpDown_StartingValue);
            grouper2.Controls.Add(numericUpDown_Quantity);
            grouper2.Controls.Add(label_Quantity);
            grouper2.Controls.Add(textBox_Description);
            grouper2.Controls.Add(label_Text_Description);
            grouper2.CustomGroupBoxColor = System.Drawing.Color.White;
            resources.ApplyResources(grouper2, "grouper2");
            grouper2.GroupImage = null;
            grouper2.GroupTitle = "Print Informations.";
            grouper2.Name = "grouper2";
            grouper2.PaintGroupBox = false;
            grouper2.RoundCorners = 10;
            grouper2.ShadowColor = System.Drawing.Color.DarkGray;
            grouper2.ShadowControl = false;
            grouper2.ShadowThickness = 3;
            // 
            // button_Print
            // 
            resources.ApplyResources(button_Print, "button_Print");
            button_Print.Name = "button_Print";
            button_Print.UseVisualStyleBackColor = true;
            button_Print.Click += new System.EventHandler(Button1_Click);
            // 
            // label_Counter_Start
            // 
            resources.ApplyResources(label_Counter_Start, "label_Counter_Start");
            label_Counter_Start.Name = "label_Counter_Start";
            // 
            // numericUpDown_StartingValue
            // 
            resources.ApplyResources(numericUpDown_StartingValue, "numericUpDown_StartingValue");
            numericUpDown_StartingValue.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            numericUpDown_StartingValue.Name = "numericUpDown_StartingValue";
            numericUpDown_StartingValue.ValueChanged += new System.EventHandler(NumericUpDown_StartingValue_ValueChanged);
            // 
            // numericUpDown_Quantity
            // 
            resources.ApplyResources(numericUpDown_Quantity, "numericUpDown_Quantity");
            numericUpDown_Quantity.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            numericUpDown_Quantity.Name = "numericUpDown_Quantity";
            numericUpDown_Quantity.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            numericUpDown_Quantity.ValueChanged += new System.EventHandler(NumericUpDown_Quantity_ValueChanged);
            // 
            // label_Quantity
            // 
            resources.ApplyResources(label_Quantity, "label_Quantity");
            label_Quantity.Name = "label_Quantity";
            // 
            // textBox_Description
            // 
            resources.ApplyResources(textBox_Description, "textBox_Description");
            textBox_Description.Name = "textBox_Description";
            textBox_Description.TextChanged += new System.EventHandler(TextBox_Description_TextChanged);
            // 
            // label_Text_Description
            // 
            resources.ApplyResources(label_Text_Description, "label_Text_Description");
            label_Text_Description.Name = "label_Text_Description";
            // 
            // label_DarknessValue
            // 
            resources.ApplyResources(label_DarknessValue, "label_DarknessValue");
            label_DarknessValue.Name = "label_DarknessValue";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            panel1.Controls.Add(grouper1);
            panel1.Controls.Add(label_LabelInformation);
            panel1.Controls.Add(grouper_Label);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // grouper1
            // 
            grouper1.BackgroundColor = System.Drawing.Color.White;
            grouper1.BackgroundGradientColor = System.Drawing.Color.White;
            grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper1.BorderColor = System.Drawing.Color.Black;
            grouper1.BorderThickness = 1F;
            grouper1.Controls.Add(label_Description_2);
            grouper1.Controls.Add(label_HumanReadableInformation_2);
            grouper1.Controls.Add(pictureBox_BarCode_Image_2);
            grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper1.GroupImage = null;
            grouper1.GroupTitle = "";
            resources.ApplyResources(grouper1, "grouper1");
            grouper1.Name = "grouper1";
            grouper1.PaintGroupBox = false;
            grouper1.RoundCorners = 10;
            grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            grouper1.ShadowControl = false;
            grouper1.ShadowThickness = 3;
            // 
            // label_Description_2
            // 
            resources.ApplyResources(label_Description_2, "label_Description_2");
            label_Description_2.Name = "label_Description_2";
            // 
            // label_HumanReadableInformation_2
            // 
            resources.ApplyResources(label_HumanReadableInformation_2, "label_HumanReadableInformation_2");
            label_HumanReadableInformation_2.Name = "label_HumanReadableInformation_2";
            // 
            // pictureBox_BarCode_Image_2
            // 
            pictureBox_BarCode_Image_2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(pictureBox_BarCode_Image_2, "pictureBox_BarCode_Image_2");
            pictureBox_BarCode_Image_2.Name = "pictureBox_BarCode_Image_2";
            pictureBox_BarCode_Image_2.TabStop = false;
            // 
            // label_LabelInformation
            // 
            resources.ApplyResources(label_LabelInformation, "label_LabelInformation");
            label_LabelInformation.Name = "label_LabelInformation";
            // 
            // grouper_Label
            // 
            grouper_Label.BackgroundColor = System.Drawing.Color.White;
            grouper_Label.BackgroundGradientColor = System.Drawing.Color.White;
            grouper_Label.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_Label.BorderColor = System.Drawing.Color.Black;
            grouper_Label.BorderThickness = 1F;
            grouper_Label.Controls.Add(label_Description);
            grouper_Label.Controls.Add(label_HumanReadableInformation);
            grouper_Label.Controls.Add(pictureBox_BarCode_Image);
            grouper_Label.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper_Label.GroupImage = null;
            grouper_Label.GroupTitle = "";
            resources.ApplyResources(grouper_Label, "grouper_Label");
            grouper_Label.Name = "grouper_Label";
            grouper_Label.PaintGroupBox = false;
            grouper_Label.RoundCorners = 10;
            grouper_Label.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_Label.ShadowControl = false;
            grouper_Label.ShadowThickness = 3;
            // 
            // label_Description
            // 
            resources.ApplyResources(label_Description, "label_Description");
            label_Description.Name = "label_Description";
            // 
            // label_HumanReadableInformation
            // 
            resources.ApplyResources(label_HumanReadableInformation, "label_HumanReadableInformation");
            label_HumanReadableInformation.Name = "label_HumanReadableInformation";
            // 
            // pictureBox_BarCode_Image
            // 
            pictureBox_BarCode_Image.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(pictureBox_BarCode_Image, "pictureBox_BarCode_Image");
            pictureBox_BarCode_Image.Name = "pictureBox_BarCode_Image";
            pictureBox_BarCode_Image.TabStop = false;
            // 
            // grouper_BarCode
            // 
            grouper_BarCode.BackgroundColor = System.Drawing.Color.Silver;
            grouper_BarCode.BackgroundGradientColor = System.Drawing.Color.White;
            grouper_BarCode.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_BarCode.BorderColor = System.Drawing.Color.Black;
            grouper_BarCode.BorderThickness = 1F;
            grouper_BarCode.Controls.Add(textBox_Suffix);
            grouper_BarCode.Controls.Add(label_Suffix);
            grouper_BarCode.Controls.Add(label_BarCode_Prefix);
            grouper_BarCode.Controls.Add(textBox_BarCode_Prefix);
            grouper_BarCode.Controls.Add(textBox_BarCode_Data);
            grouper_BarCode.Controls.Add(label_Text_Data);
            grouper_BarCode.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper_BarCode.GroupImage = null;
            grouper_BarCode.GroupTitle = "BarCode Data.";
            resources.ApplyResources(grouper_BarCode, "grouper_BarCode");
            grouper_BarCode.Name = "grouper_BarCode";
            grouper_BarCode.PaintGroupBox = false;
            grouper_BarCode.RoundCorners = 10;
            grouper_BarCode.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_BarCode.ShadowControl = false;
            grouper_BarCode.ShadowThickness = 3;
            // 
            // textBox_Suffix
            // 
            resources.ApplyResources(textBox_Suffix, "textBox_Suffix");
            textBox_Suffix.Name = "textBox_Suffix";
            textBox_Suffix.TextChanged += new System.EventHandler(TextBox_Suffix_TextChanged);
            // 
            // label_Suffix
            // 
            resources.ApplyResources(label_Suffix, "label_Suffix");
            label_Suffix.Name = "label_Suffix";
            // 
            // label_BarCode_Prefix
            // 
            resources.ApplyResources(label_BarCode_Prefix, "label_BarCode_Prefix");
            label_BarCode_Prefix.Name = "label_BarCode_Prefix";
            // 
            // textBox_BarCode_Prefix
            // 
            resources.ApplyResources(textBox_BarCode_Prefix, "textBox_BarCode_Prefix");
            textBox_BarCode_Prefix.Name = "textBox_BarCode_Prefix";
            textBox_BarCode_Prefix.TextChanged += new System.EventHandler(TextBox_BarCode_Prefix_TextChanged);
            // 
            // textBox_BarCode_Data
            // 
            resources.ApplyResources(textBox_BarCode_Data, "textBox_BarCode_Data");
            textBox_BarCode_Data.Name = "textBox_BarCode_Data";
            textBox_BarCode_Data.TextChanged += new System.EventHandler(TextBox_BarCode_Data_TextChanged);
            // 
            // label_Text_Data
            // 
            resources.ApplyResources(label_Text_Data, "label_Text_Data");
            label_Text_Data.Name = "label_Text_Data";
            // 
            // checkBox_EncodeCode
            // 
            resources.ApplyResources(checkBox_EncodeCode, "checkBox_EncodeCode");
            checkBox_EncodeCode.Checked = true;
            checkBox_EncodeCode.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_EncodeCode.Name = "checkBox_EncodeCode";
            checkBox_EncodeCode.UseVisualStyleBackColor = true;
            checkBox_EncodeCode.CheckedChanged += new System.EventHandler(CheckBox_EncodeCode_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // richTextBox_ZPL
            // 
            resources.ApplyResources(richTextBox_ZPL, "richTextBox_ZPL");
            richTextBox_ZPL.Name = "richTextBox_ZPL";
            // 
            // checkBox_print
            // 
            resources.ApplyResources(checkBox_print, "checkBox_print");
            checkBox_print.Checked = true;
            checkBox_print.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_print.Name = "checkBox_print";
            checkBox_print.UseVisualStyleBackColor = true;
            checkBox_print.CheckedChanged += new System.EventHandler(CheckBox_print_CheckedChanged);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(_dataGridViewLabelsSMT);
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // _dataGridViewLabelsSMT
            // 
            _dataGridViewLabelsSMT.BindingCompleted = false;
            _dataGridViewLabelsSMT.CurrentColumnActive = null;
            _dataGridViewLabelsSMT.CurrentDataGridViewRowMouseOver = null;
            _dataGridViewLabelsSMT.CurrentDataRowViewMouseOver = null;
            _dataGridViewLabelsSMT.CurrentEmployeesLogIn = null;
            _dataGridViewLabelsSMT.CurrentRowBackgroundColor = System.Drawing.Color.DeepSkyBlue;
            _dataGridViewLabelsSMT.CurrentRowBorderColor = System.Drawing.Color.DarkBlue;
            _dataGridViewLabelsSMT.CurrentRowMouseOverStatus = null;
            _dataGridViewLabelsSMT.CustomEdit = MyCode.EditMode.Delete;
            _dataGridViewLabelsSMT.CustomFilter = null;
            _dataGridViewLabelsSMT.DataGridViewDrawDoubleBuffering = false;
            _dataGridViewLabelsSMT.DividerColor = System.Drawing.Color.Red;
            _dataGridViewLabelsSMT.DividerHeight = 0;
            resources.ApplyResources(_dataGridViewLabelsSMT, "_dataGridViewLabelsSMT");
            _dataGridViewLabelsSMT.FirstDisplayedRow = null;
            _dataGridViewLabelsSMT.IsMouseDrivenEvent = false;
            _dataGridViewLabelsSMT.Name = "_dataGridViewLabelsSMT";
            _dataGridViewLabelsSMT.NeedSaveData = false;
            _dataGridViewLabelsSMT.SelectionBorderWidth = 3;
            _dataGridViewLabelsSMT.SelectionColor = System.Drawing.Color.DeepSkyBlue;
            // 
            // ZebraPrintsPCBLabels
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(customTabControl1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ZebraPrintsPCBLabels";
            ShowIcon = false;
            ShowInTaskbar = false;
            TopMost = true;
            Load += new System.EventHandler(EPL2_Zebra_Prints_Load);
            customTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_DarknessValue)).EndInit();
            grouper2.ResumeLayout(false);
            grouper2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_StartingValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_Quantity)).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grouper1.ResumeLayout(false);
            grouper1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_BarCode_Image_2)).EndInit();
            grouper_Label.ResumeLayout(false);
            grouper_Label.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_BarCode_Image)).EndInit();
            grouper_BarCode.ResumeLayout(false);
            grouper_BarCode.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.RichTextBox richTextBox_ZPL;
        private System.Windows.Forms.TextBox textBox_BarCode_Prefix;
        private System.Windows.Forms.Label label_BarCode_Prefix;
        private System.Windows.Forms.Label label_Counter_Start;
        private System.Windows.Forms.Label label_Quantity;
        private System.Windows.Forms.NumericUpDown numericUpDown_Quantity;
        private System.Windows.Forms.NumericUpDown numericUpDown_StartingValue;
        private System.Windows.Forms.Label label_Suffix;
        private System.Windows.Forms.TextBox textBox_Suffix;
        private System.Windows.Forms.Label label_Text_Description;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.PictureBox pictureBox_BarCode_Image;
        private System.Windows.Forms.CustomTabControl customTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label_Text_Data;
        private System.Windows.Forms.TextBox textBox_BarCode_Data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_print;
        private System.Windows.Forms.CheckBox checkBox_EncodeCode;
        private CodeVendor.Controls.Grouper grouper_Label;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Label label_HumanReadableInformation;
        private CodeVendor.Controls.Grouper grouper_BarCode;
        private System.Windows.Forms.Panel panel1;
        private CodeVendor.Controls.Grouper grouper1;
        private System.Windows.Forms.Label label_Description_2;
        private System.Windows.Forms.Label label_HumanReadableInformation_2;
        private System.Windows.Forms.PictureBox pictureBox_BarCode_Image_2;
        private System.Windows.Forms.Label label_LabelInformation;
        private CodeVendor.Controls.Grouper grouper2;
        private System.Windows.Forms.NumericUpDown numericUpDown_DarknessValue;
        private System.Windows.Forms.Label label_DarknessValue;
        private DataGridViewExtend.DataGridViewExtended _dataGridViewLabelsSMT;
    }
}
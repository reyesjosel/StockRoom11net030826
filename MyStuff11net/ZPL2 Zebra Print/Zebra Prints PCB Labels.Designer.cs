namespace MyStuff11net.ZPL2_Zebra_Print
{
    partial class Zebra_Prints_PCBLabels
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
            customTabControl1 = new System.Windows.Forms.CustomTabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            grouper_BarCode = new CodeVendor.Controls.Grouper();
            textBox_Suffix = new System.Windows.Forms.TextBox();
            label_Suffix = new System.Windows.Forms.Label();
            label_BarCode_Prefix = new System.Windows.Forms.Label();
            textBox_BarCode_Prefix = new System.Windows.Forms.TextBox();
            textBox_BarCode_Data = new System.Windows.Forms.TextBox();
            label_Text_Data = new System.Windows.Forms.Label();
            grouper_Label = new CodeVendor.Controls.Grouper();
            label_Description = new System.Windows.Forms.Label();
            label_HumanReadableInformation = new System.Windows.Forms.Label();
            pictureBox_BarCode_Image = new System.Windows.Forms.PictureBox();
            checkBox_EncodeCode = new System.Windows.Forms.CheckBox();
            button_Print = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            richTextBox_ZPL = new System.Windows.Forms.RichTextBox();
            checkBox_print = new System.Windows.Forms.CheckBox();
            label_Text_Description = new System.Windows.Forms.Label();
            label_Counter_Start = new System.Windows.Forms.Label();
            textBox_Description = new System.Windows.Forms.TextBox();
            label_Quantity = new System.Windows.Forms.Label();
            numericUpDown_Quantity = new System.Windows.Forms.NumericUpDown();
            numericUpDown_Counter = new System.Windows.Forms.NumericUpDown();
            tabPage2 = new System.Windows.Forms.TabPage();
            label_LabelInformation = new System.Windows.Forms.Label();
            grouper1 = new CodeVendor.Controls.Grouper();
            label_Description_2 = new System.Windows.Forms.Label();
            label_HumanReadableInformation_2 = new System.Windows.Forms.Label();
            pictureBox_BarCode_Image_2 = new System.Windows.Forms.PictureBox();
            panel1 = new System.Windows.Forms.Panel();
            customTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            grouper_BarCode.SuspendLayout();
            grouper_Label.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_BarCode_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_Counter)).BeginInit();
            grouper1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_BarCode_Image_2)).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tabPage1);
            customTabControl1.Controls.Add(tabPage2);
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
            customTabControl1.DisplayStyleProvider.Padding = new System.Drawing.Point(14, 1);
            customTabControl1.DisplayStyleProvider.ShowTabCloser = false;
            customTabControl1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            customTabControl1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            customTabControl1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            customTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customTabControl1.HotTrack = true;
            customTabControl1.Location = new System.Drawing.Point(0, 0);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new System.Drawing.Size(522, 382);
            customTabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(grouper_BarCode);
            tabPage1.Controls.Add(checkBox_EncodeCode);
            tabPage1.Controls.Add(button_Print);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(richTextBox_ZPL);
            tabPage1.Controls.Add(checkBox_print);
            tabPage1.Controls.Add(label_Text_Description);
            tabPage1.Controls.Add(label_Counter_Start);
            tabPage1.Controls.Add(textBox_Description);
            tabPage1.Controls.Add(label_Quantity);
            tabPage1.Controls.Add(numericUpDown_Quantity);
            tabPage1.Controls.Add(numericUpDown_Counter);
            tabPage1.Location = new System.Drawing.Point(4, 21);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(514, 357);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Project Labels        ";
            tabPage1.UseVisualStyleBackColor = true;
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
            grouper_BarCode.Location = new System.Drawing.Point(9, 142);
            grouper_BarCode.Name = "grouper_BarCode";
            grouper_BarCode.Padding = new System.Windows.Forms.Padding(20);
            grouper_BarCode.PaintGroupBox = false;
            grouper_BarCode.RoundCorners = 10;
            grouper_BarCode.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_BarCode.ShadowControl = false;
            grouper_BarCode.ShadowThickness = 3;
            grouper_BarCode.Size = new System.Drawing.Size(275, 74);
            grouper_BarCode.TabIndex = 20;
            // 
            // textBox_Suffix
            // 
            textBox_Suffix.Location = new System.Drawing.Point(191, 46);
            textBox_Suffix.Name = "textBox_Suffix";
            textBox_Suffix.Size = new System.Drawing.Size(60, 20);
            textBox_Suffix.TabIndex = 10;
            textBox_Suffix.TextChanged += new System.EventHandler(textBox_Suffix_TextChanged);
            // 
            // label_Suffix
            // 
            label_Suffix.AutoSize = true;
            label_Suffix.Location = new System.Drawing.Point(193, 28);
            label_Suffix.Name = "label_Suffix";
            label_Suffix.Size = new System.Drawing.Size(60, 13);
            label_Suffix.TabIndex = 11;
            label_Suffix.Text = "Suffix data.";
            // 
            // label_BarCode_Prefix
            // 
            label_BarCode_Prefix.AutoSize = true;
            label_BarCode_Prefix.Location = new System.Drawing.Point(19, 28);
            label_BarCode_Prefix.Name = "label_BarCode_Prefix";
            label_BarCode_Prefix.Size = new System.Drawing.Size(60, 13);
            label_BarCode_Prefix.TabIndex = 3;
            label_BarCode_Prefix.Text = "Prefix data.";
            // 
            // textBox_BarCode_Prefix
            // 
            textBox_BarCode_Prefix.Location = new System.Drawing.Point(19, 46);
            textBox_BarCode_Prefix.Name = "textBox_BarCode_Prefix";
            textBox_BarCode_Prefix.Size = new System.Drawing.Size(60, 20);
            textBox_BarCode_Prefix.TabIndex = 2;
            textBox_BarCode_Prefix.TextChanged += new System.EventHandler(TextBox_BarCode_Prefix_TextChanged);
            // 
            // textBox_BarCode_Data
            // 
            textBox_BarCode_Data.Location = new System.Drawing.Point(85, 46);
            textBox_BarCode_Data.Name = "textBox_BarCode_Data";
            textBox_BarCode_Data.Size = new System.Drawing.Size(99, 20);
            textBox_BarCode_Data.TabIndex = 14;
            textBox_BarCode_Data.TextChanged += new System.EventHandler(textBox_BarCode_Data_TextChanged);
            // 
            // label_Text_Data
            // 
            label_Text_Data.AutoSize = true;
            label_Text_Data.Location = new System.Drawing.Point(114, 28);
            label_Text_Data.Name = "label_Text_Data";
            label_Text_Data.Size = new System.Drawing.Size(33, 13);
            label_Text_Data.TabIndex = 15;
            label_Text_Data.Text = "Data.";
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
            grouper_Label.GroupTitle = global::MyStuff11net.Properties.Settings.Default.DRIVERRESOURCE_NOTFOUND;
            grouper_Label.Location = new System.Drawing.Point(13, 3);
            grouper_Label.Name = "grouper_Label";
            grouper_Label.Padding = new System.Windows.Forms.Padding(20);
            grouper_Label.PaintGroupBox = false;
            grouper_Label.RoundCorners = 10;
            grouper_Label.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_Label.ShadowControl = false;
            grouper_Label.ShadowThickness = 3;
            grouper_Label.Size = new System.Drawing.Size(210, 81);
            grouper_Label.TabIndex = 19;
            // 
            // label_Description
            // 
            label_Description.AutoSize = true;
            label_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_Description.Location = new System.Drawing.Point(39, 60);
            label_Description.Margin = new System.Windows.Forms.Padding(0);
            label_Description.Name = "label_Description";
            label_Description.Size = new System.Drawing.Size(135, 18);
            label_Description.TabIndex = 21;
            label_Description.Text = "Description field.";
            // 
            // label_HumanReadableInformation
            // 
            label_HumanReadableInformation.AutoSize = true;
            label_HumanReadableInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_HumanReadableInformation.Location = new System.Drawing.Point(17, 43);
            label_HumanReadableInformation.Name = "label_HumanReadableInformation";
            label_HumanReadableInformation.Size = new System.Drawing.Size(173, 15);
            label_HumanReadableInformation.TabIndex = 20;
            label_HumanReadableInformation.Text = "Human Readable Information.";
            // 
            // pictureBox_BarCode_Image
            // 
            pictureBox_BarCode_Image.BackColor = System.Drawing.Color.White;
            pictureBox_BarCode_Image.Location = new System.Drawing.Point(3, 14);
            pictureBox_BarCode_Image.Name = "pictureBox_BarCode_Image";
            pictureBox_BarCode_Image.Size = new System.Drawing.Size(203, 26);
            pictureBox_BarCode_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox_BarCode_Image.TabIndex = 14;
            pictureBox_BarCode_Image.TabStop = false;
            // 
            // checkBox_EncodeCode
            // 
            checkBox_EncodeCode.AutoSize = true;
            checkBox_EncodeCode.Checked = true;
            checkBox_EncodeCode.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_EncodeCode.Location = new System.Drawing.Point(176, 273);
            checkBox_EncodeCode.Name = "checkBox_EncodeCode";
            checkBox_EncodeCode.Size = new System.Drawing.Size(119, 17);
            checkBox_EncodeCode.TabIndex = 18;
            checkBox_EncodeCode.Text = "Yes, will be Encode";
            checkBox_EncodeCode.UseVisualStyleBackColor = true;
            checkBox_EncodeCode.CheckedChanged += new System.EventHandler(checkBox_EncodeCode_CheckedChanged);
            // 
            // button_Print
            // 
            button_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button_Print.Location = new System.Drawing.Point(176, 302);
            button_Print.Name = "button_Print";
            button_Print.Size = new System.Drawing.Size(101, 40);
            button_Print.TabIndex = 0;
            button_Print.Text = "Print...";
            button_Print.UseVisualStyleBackColor = true;
            button_Print.Click += new System.EventHandler(Button1_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(180, 231);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(63, 13);
            label2.TabIndex = 17;
            label2.Text = "Print Date ?";
            // 
            // richTextBox_ZPL
            // 
            richTextBox_ZPL.Location = new System.Drawing.Point(296, 142);
            richTextBox_ZPL.Name = "richTextBox_ZPL";
            richTextBox_ZPL.Size = new System.Drawing.Size(210, 200);
            richTextBox_ZPL.TabIndex = 1;
            richTextBox_ZPL.Text = global::MyStuff11net.Properties.Settings.Default.DRIVERRESOURCE_NOTFOUND;
            // 
            // checkBox_print
            // 
            checkBox_print.AutoSize = true;
            checkBox_print.Checked = true;
            checkBox_print.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_print.Location = new System.Drawing.Point(176, 255);
            checkBox_print.Name = "checkBox_print";
            checkBox_print.Size = new System.Drawing.Size(102, 17);
            checkBox_print.TabIndex = 16;
            checkBox_print.Text = "Yes, will be print";
            checkBox_print.UseVisualStyleBackColor = true;
            checkBox_print.CheckedChanged += new System.EventHandler(CheckBox_print_CheckedChanged);
            // 
            // label_Text_Description
            // 
            label_Text_Description.AutoSize = true;
            label_Text_Description.Location = new System.Drawing.Point(9, 302);
            label_Text_Description.Name = "label_Text_Description";
            label_Text_Description.Size = new System.Drawing.Size(118, 13);
            label_Text_Description.TabIndex = 13;
            label_Text_Description.Text = "Description Information.";
            // 
            // label_Counter_Start
            // 
            label_Counter_Start.AutoSize = true;
            label_Counter_Start.Location = new System.Drawing.Point(9, 231);
            label_Counter_Start.Name = "label_Counter_Start";
            label_Counter_Start.Size = new System.Drawing.Size(75, 13);
            label_Counter_Start.TabIndex = 5;
            label_Counter_Start.Text = "Starting value.";
            // 
            // textBox_Description
            // 
            textBox_Description.Location = new System.Drawing.Point(9, 322);
            textBox_Description.Name = "textBox_Description";
            textBox_Description.Size = new System.Drawing.Size(149, 20);
            textBox_Description.TabIndex = 12;
            textBox_Description.TextChanged += new System.EventHandler(textBox_Description_TextChanged);
            // 
            // label_Quantity
            // 
            label_Quantity.AutoSize = true;
            label_Quantity.Location = new System.Drawing.Point(91, 231);
            label_Quantity.Name = "label_Quantity";
            label_Quantity.Size = new System.Drawing.Size(84, 13);
            label_Quantity.TabIndex = 7;
            label_Quantity.Text = "Quantity to print.";
            // 
            // numericUpDown_Quantity
            // 
            numericUpDown_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numericUpDown_Quantity.Location = new System.Drawing.Point(94, 255);
            numericUpDown_Quantity.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            numericUpDown_Quantity.Name = "numericUpDown_Quantity";
            numericUpDown_Quantity.Size = new System.Drawing.Size(64, 24);
            numericUpDown_Quantity.TabIndex = 8;
            numericUpDown_Quantity.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            numericUpDown_Quantity.ValueChanged += new System.EventHandler(numericUpDown_Quantity_ValueChanged);
            // 
            // numericUpDown_Counter
            // 
            numericUpDown_Counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numericUpDown_Counter.Location = new System.Drawing.Point(9, 255);
            numericUpDown_Counter.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            numericUpDown_Counter.Name = "numericUpDown_Counter";
            numericUpDown_Counter.Size = new System.Drawing.Size(70, 24);
            numericUpDown_Counter.TabIndex = 9;
            numericUpDown_Counter.ValueChanged += new System.EventHandler(numericUpDown_Counter_ValueChanged);
            // 
            // tabPage2
            // 
            tabPage2.Location = new System.Drawing.Point(4, 21);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(525, 292);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "IMEI and SN Module";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label_LabelInformation
            // 
            label_LabelInformation.AutoSize = true;
            label_LabelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_LabelInformation.Location = new System.Drawing.Point(281, 97);
            label_LabelInformation.Name = "label_LabelInformation";
            label_LabelInformation.Size = new System.Drawing.Size(163, 13);
            label_LabelInformation.TabIndex = 21;
            label_LabelInformation.Text = "Label type: Brady, THT-37-483-10";
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
            grouper1.GroupTitle = global::MyStuff11net.Properties.Settings.Default.DRIVERRESOURCE_NOTFOUND;
            grouper1.Location = new System.Drawing.Point(230, 3);
            grouper1.Name = "grouper1";
            grouper1.Padding = new System.Windows.Forms.Padding(20);
            grouper1.PaintGroupBox = false;
            grouper1.RoundCorners = 10;
            grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            grouper1.ShadowControl = false;
            grouper1.ShadowThickness = 3;
            grouper1.Size = new System.Drawing.Size(210, 81);
            grouper1.TabIndex = 22;
            // 
            // label_Description_2
            // 
            label_Description_2.AutoSize = true;
            label_Description_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_Description_2.Location = new System.Drawing.Point(39, 60);
            label_Description_2.Margin = new System.Windows.Forms.Padding(0);
            label_Description_2.Name = "label_Description_2";
            label_Description_2.Size = new System.Drawing.Size(135, 18);
            label_Description_2.TabIndex = 21;
            label_Description_2.Text = "Description field.";
            // 
            // label_HumanReadableInformation_2
            // 
            label_HumanReadableInformation_2.AutoSize = true;
            label_HumanReadableInformation_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_HumanReadableInformation_2.Location = new System.Drawing.Point(17, 43);
            label_HumanReadableInformation_2.Name = "label_HumanReadableInformation_2";
            label_HumanReadableInformation_2.Size = new System.Drawing.Size(173, 15);
            label_HumanReadableInformation_2.TabIndex = 20;
            label_HumanReadableInformation_2.Text = "Human Readable Information.";
            // 
            // pictureBox_BarCode_Image_2
            // 
            pictureBox_BarCode_Image_2.BackColor = System.Drawing.Color.White;
            pictureBox_BarCode_Image_2.Location = new System.Drawing.Point(3, 14);
            pictureBox_BarCode_Image_2.Name = "pictureBox_BarCode_Image_2";
            pictureBox_BarCode_Image_2.Size = new System.Drawing.Size(203, 26);
            pictureBox_BarCode_Image_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox_BarCode_Image_2.TabIndex = 14;
            pictureBox_BarCode_Image_2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            panel1.Controls.Add(grouper1);
            panel1.Controls.Add(label_LabelInformation);
            panel1.Controls.Add(grouper_Label);
            panel1.Location = new System.Drawing.Point(29, 10);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(454, 115);
            panel1.TabIndex = 23;
            // 
            // ZPL2_Zebra_Prints
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(522, 382);
            Controls.Add(customTabControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ZPL2_Zebra_Prints";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "EPL2_Zebra_Prints";
            TopMost = true;
            Load += new System.EventHandler(EPL2_Zebra_Prints_Load);
            customTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            grouper_BarCode.ResumeLayout(false);
            grouper_BarCode.PerformLayout();
            grouper_Label.ResumeLayout(false);
            grouper_Label.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_BarCode_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numericUpDown_Counter)).EndInit();
            grouper1.ResumeLayout(false);
            grouper1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_BarCode_Image_2)).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown numericUpDown_Counter;
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
    }
}
namespace MyStuff11net
{
    partial class DocumentsAddressEditor
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
            textBox_DescriptionReference = new System.Windows.Forms.TextBox();
            radioButton_Public = new System.Windows.Forms.RadioButton();
            radioButton_Private = new System.Windows.Forms.RadioButton();
            button_SaveDocumentsAddress = new System.Windows.Forms.Button();
            button_CancelDocumentsAddress = new System.Windows.Forms.Button();
            panel_ButtonSaveCancel = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            grouper_DocumentsAddressItem = new CodeVendor.Controls.Grouper();
            grouper1 = new CodeVendor.Controls.Grouper();
            textBox_DirectoryPathFolder = new System.Windows.Forms.TextBox();
            button_BrowserDirectoryPathFolder = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            grouper2 = new CodeVendor.Controls.Grouper();
            grouper_AllowedExt = new CodeVendor.Controls.Grouper();
            panel6 = new System.Windows.Forms.Panel();
            flowLayoutPanel_AllowedExt = new System.Windows.Forms.FlowLayoutPanel();
            checkBox1 = new System.Windows.Forms.CheckBox();
            checkBox2 = new System.Windows.Forms.CheckBox();
            checkBox3 = new System.Windows.Forms.CheckBox();
            checkBox4 = new System.Windows.Forms.CheckBox();
            checkBox5 = new System.Windows.Forms.CheckBox();
            checkBox6 = new System.Windows.Forms.CheckBox();
            checkBox7 = new System.Windows.Forms.CheckBox();
            panel4 = new System.Windows.Forms.Panel();
            panel5 = new System.Windows.Forms.Panel();
            panel_ButtonSaveCancel.SuspendLayout();
            panel1.SuspendLayout();
            grouper_DocumentsAddressItem.SuspendLayout();
            grouper1.SuspendLayout();
            grouper2.SuspendLayout();
            grouper_AllowedExt.SuspendLayout();
            panel6.SuspendLayout();
            flowLayoutPanel_AllowedExt.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_DescriptionReference
            // 
            textBox_DescriptionReference.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox_DescriptionReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox_DescriptionReference.Location = new System.Drawing.Point(10, 28);
            textBox_DescriptionReference.Name = "textBox_DescriptionReference";
            textBox_DescriptionReference.Size = new System.Drawing.Size(629, 23);
            textBox_DescriptionReference.TabIndex = 0;
            // 
            // radioButton_Public
            // 
            radioButton_Public.AutoSize = true;
            radioButton_Public.Location = new System.Drawing.Point(12, 11);
            radioButton_Public.Name = "radioButton_Public";
            radioButton_Public.Size = new System.Drawing.Size(233, 17);
            radioButton_Public.TabIndex = 5;
            radioButton_Public.Text = "Public  -> Make available to all departments.";
            radioButton_Public.UseVisualStyleBackColor = true;
            // 
            // radioButton_Private
            // 
            radioButton_Private.AutoSize = true;
            radioButton_Private.Checked = true;
            radioButton_Private.Location = new System.Drawing.Point(423, 11);
            radioButton_Private.Name = "radioButton_Private";
            radioButton_Private.Size = new System.Drawing.Size(203, 17);
            radioButton_Private.TabIndex = 6;
            radioButton_Private.TabStop = true;
            radioButton_Private.Text = "Private -> Use only in this department.";
            radioButton_Private.UseVisualStyleBackColor = true;
            // 
            // button_SaveDocumentsAddress
            // 
            button_SaveDocumentsAddress.Location = new System.Drawing.Point(200, 4);
            button_SaveDocumentsAddress.Name = "button_SaveDocumentsAddress";
            button_SaveDocumentsAddress.Size = new System.Drawing.Size(103, 34);
            button_SaveDocumentsAddress.TabIndex = 7;
            button_SaveDocumentsAddress.Text = "Save";
            button_SaveDocumentsAddress.UseVisualStyleBackColor = true;
            button_SaveDocumentsAddress.Click += new System.EventHandler(button_SaveDocumentsAddress_Click);
            // 
            // button_CancelDocumentsAddress
            // 
            button_CancelDocumentsAddress.Location = new System.Drawing.Point(309, 4);
            button_CancelDocumentsAddress.Name = "button_CancelDocumentsAddress";
            button_CancelDocumentsAddress.Size = new System.Drawing.Size(103, 34);
            button_CancelDocumentsAddress.TabIndex = 8;
            button_CancelDocumentsAddress.Text = "Cancel";
            button_CancelDocumentsAddress.UseVisualStyleBackColor = true;
            button_CancelDocumentsAddress.Click += new System.EventHandler(button_CancelDocumentsAddress_Click);
            // 
            // panel_ButtonSaveCancel
            // 
            panel_ButtonSaveCancel.Controls.Add(button_CancelDocumentsAddress);
            panel_ButtonSaveCancel.Controls.Add(button_SaveDocumentsAddress);
            panel_ButtonSaveCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel_ButtonSaveCancel.Location = new System.Drawing.Point(10, 345);
            panel_ButtonSaveCancel.Name = "panel_ButtonSaveCancel";
            panel_ButtonSaveCancel.Size = new System.Drawing.Size(649, 44);
            panel_ButtonSaveCancel.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton_Private);
            panel1.Controls.Add(radioButton_Public);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(10, 28);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(629, 35);
            panel1.TabIndex = 10;
            // 
            // grouper_DocumentsAddressItem
            // 
            grouper_DocumentsAddressItem.BackgroundColor = System.Drawing.Color.Gainsboro;
            grouper_DocumentsAddressItem.BackgroundGradientColor = System.Drawing.Color.GhostWhite;
            grouper_DocumentsAddressItem.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_DocumentsAddressItem.BorderColor = System.Drawing.Color.DimGray;
            grouper_DocumentsAddressItem.BorderThickness = 1F;
            grouper_DocumentsAddressItem.Controls.Add(textBox_DescriptionReference);
            grouper_DocumentsAddressItem.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper_DocumentsAddressItem.Dock = System.Windows.Forms.DockStyle.Top;
            grouper_DocumentsAddressItem.GroupImage = null;
            grouper_DocumentsAddressItem.GroupTitle = "Write a description about this, or a name as a reference for future reorganizatio" +
    "n";
            grouper_DocumentsAddressItem.Location = new System.Drawing.Point(10, 10);
            grouper_DocumentsAddressItem.Margin = new System.Windows.Forms.Padding(1, 4, 1, 10);
            grouper_DocumentsAddressItem.Name = "grouper_DocumentsAddressItem";
            grouper_DocumentsAddressItem.Padding = new System.Windows.Forms.Padding(10, 28, 10, 10);
            grouper_DocumentsAddressItem.PaintGroupBox = false;
            grouper_DocumentsAddressItem.RoundCorners = 10;
            grouper_DocumentsAddressItem.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_DocumentsAddressItem.ShadowControl = false;
            grouper_DocumentsAddressItem.ShadowThickness = 3;
            grouper_DocumentsAddressItem.Size = new System.Drawing.Size(649, 62);
            grouper_DocumentsAddressItem.TabIndex = 24;
            // 
            // grouper1
            // 
            grouper1.BackgroundColor = System.Drawing.Color.Gainsboro;
            grouper1.BackgroundGradientColor = System.Drawing.Color.GhostWhite;
            grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper1.BorderColor = System.Drawing.Color.DimGray;
            grouper1.BorderThickness = 1F;
            grouper1.Controls.Add(textBox_DirectoryPathFolder);
            grouper1.Controls.Add(button_BrowserDirectoryPathFolder);
            grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper1.Dock = System.Windows.Forms.DockStyle.Top;
            grouper1.GroupImage = null;
            grouper1.GroupTitle = "Directory or folder path to this documentation. Used Browser button to select";
            grouper1.Location = new System.Drawing.Point(10, 87);
            grouper1.Margin = new System.Windows.Forms.Padding(1, 10, 1, 1);
            grouper1.Name = "grouper1";
            grouper1.Padding = new System.Windows.Forms.Padding(10, 28, 10, 10);
            grouper1.PaintGroupBox = false;
            grouper1.RoundCorners = 10;
            grouper1.ShadowColor = System.Drawing.Color.DarkGray;
            grouper1.ShadowControl = false;
            grouper1.ShadowThickness = 3;
            grouper1.Size = new System.Drawing.Size(649, 62);
            grouper1.TabIndex = 25;
            // 
            // textBox_DirectoryPathFolder
            // 
            textBox_DirectoryPathFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox_DirectoryPathFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox_DirectoryPathFolder.Location = new System.Drawing.Point(10, 28);
            textBox_DirectoryPathFolder.Name = "textBox_DirectoryPathFolder";
            textBox_DirectoryPathFolder.Size = new System.Drawing.Size(538, 23);
            textBox_DirectoryPathFolder.TabIndex = 0;
            textBox_DirectoryPathFolder.Text = "D:\\My C# Example\\C# File Browser";
            // 
            // button_BrowserDirectoryPathFolder
            // 
            button_BrowserDirectoryPathFolder.Dock = System.Windows.Forms.DockStyle.Right;
            button_BrowserDirectoryPathFolder.Location = new System.Drawing.Point(548, 28);
            button_BrowserDirectoryPathFolder.Margin = new System.Windows.Forms.Padding(0);
            button_BrowserDirectoryPathFolder.Name = "button_BrowserDirectoryPathFolder";
            button_BrowserDirectoryPathFolder.Size = new System.Drawing.Size(91, 24);
            button_BrowserDirectoryPathFolder.TabIndex = 8;
            button_BrowserDirectoryPathFolder.Text = "Browser";
            button_BrowserDirectoryPathFolder.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(10, 72);
            panel2.MinimumSize = new System.Drawing.Size(0, 10);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(649, 15);
            panel2.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(10, 149);
            panel3.MinimumSize = new System.Drawing.Size(0, 10);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(649, 15);
            panel3.TabIndex = 27;
            // 
            // grouper2
            // 
            grouper2.BackgroundColor = System.Drawing.Color.Gainsboro;
            grouper2.BackgroundGradientColor = System.Drawing.Color.GhostWhite;
            grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper2.BorderColor = System.Drawing.Color.DimGray;
            grouper2.BorderThickness = 1F;
            grouper2.Controls.Add(panel1);
            grouper2.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper2.Dock = System.Windows.Forms.DockStyle.Bottom;
            grouper2.GroupImage = null;
            grouper2.GroupTitle = "Define whether this setup will be available to all departments or be restricted o" +
    "nly to this department";
            grouper2.Location = new System.Drawing.Point(10, 272);
            grouper2.Margin = new System.Windows.Forms.Padding(1, 10, 1, 1);
            grouper2.Name = "grouper2";
            grouper2.Padding = new System.Windows.Forms.Padding(10, 28, 10, 10);
            grouper2.PaintGroupBox = false;
            grouper2.RoundCorners = 10;
            grouper2.ShadowColor = System.Drawing.Color.DarkGray;
            grouper2.ShadowControl = false;
            grouper2.ShadowThickness = 3;
            grouper2.Size = new System.Drawing.Size(649, 73);
            grouper2.TabIndex = 28;
            // 
            // grouper_AllowedExt
            // 
            grouper_AllowedExt.BackgroundColor = System.Drawing.Color.Gainsboro;
            grouper_AllowedExt.BackgroundGradientColor = System.Drawing.Color.GhostWhite;
            grouper_AllowedExt.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_AllowedExt.BorderColor = System.Drawing.Color.DimGray;
            grouper_AllowedExt.BorderThickness = 1F;
            grouper_AllowedExt.Controls.Add(panel6);
            grouper_AllowedExt.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper_AllowedExt.Dock = System.Windows.Forms.DockStyle.Fill;
            grouper_AllowedExt.GroupImage = null;
            grouper_AllowedExt.GroupTitle = "Check mark the allowed extensions for viewing in the document explorer.";
            grouper_AllowedExt.Location = new System.Drawing.Point(10, 164);
            grouper_AllowedExt.Margin = new System.Windows.Forms.Padding(1, 10, 1, 1);
            grouper_AllowedExt.Name = "grouper_AllowedExt";
            grouper_AllowedExt.Padding = new System.Windows.Forms.Padding(10, 28, 10, 10);
            grouper_AllowedExt.PaintGroupBox = false;
            grouper_AllowedExt.RoundCorners = 10;
            grouper_AllowedExt.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_AllowedExt.ShadowControl = false;
            grouper_AllowedExt.ShadowThickness = 3;
            grouper_AllowedExt.Size = new System.Drawing.Size(649, 93);
            grouper_AllowedExt.TabIndex = 29;
            // 
            // panel6
            // 
            panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel6.Controls.Add(flowLayoutPanel_AllowedExt);
            panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(10, 28);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(629, 55);
            panel6.TabIndex = 0;
            // 
            // flowLayoutPanel_AllowedExt
            // 
            flowLayoutPanel_AllowedExt.AutoScroll = true;
            flowLayoutPanel_AllowedExt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_AllowedExt.Controls.Add(checkBox1);
            flowLayoutPanel_AllowedExt.Controls.Add(checkBox2);
            flowLayoutPanel_AllowedExt.Controls.Add(checkBox3);
            flowLayoutPanel_AllowedExt.Controls.Add(checkBox4);
            flowLayoutPanel_AllowedExt.Controls.Add(checkBox5);
            flowLayoutPanel_AllowedExt.Controls.Add(checkBox6);
            flowLayoutPanel_AllowedExt.Controls.Add(checkBox7);
            flowLayoutPanel_AllowedExt.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel_AllowedExt.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel_AllowedExt.MinimumSize = new System.Drawing.Size(0, 25);
            flowLayoutPanel_AllowedExt.Name = "flowLayoutPanel_AllowedExt";
            flowLayoutPanel_AllowedExt.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            flowLayoutPanel_AllowedExt.Size = new System.Drawing.Size(629, 55);
            flowLayoutPanel_AllowedExt.TabIndex = 1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(3, 8);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(80, 17);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new System.Drawing.Point(89, 8);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(80, 17);
            checkBox2.TabIndex = 4;
            checkBox2.Text = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(175, 8);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(80, 17);
            checkBox3.TabIndex = 5;
            checkBox3.Text = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new System.Drawing.Point(261, 8);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new System.Drawing.Size(80, 17);
            checkBox4.TabIndex = 8;
            checkBox4.Text = "checkBox4";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new System.Drawing.Point(347, 8);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new System.Drawing.Size(80, 17);
            checkBox5.TabIndex = 7;
            checkBox5.Text = "checkBox5";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new System.Drawing.Point(433, 8);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new System.Drawing.Size(80, 17);
            checkBox6.TabIndex = 6;
            checkBox6.Text = "checkBox6";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new System.Drawing.Point(519, 8);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new System.Drawing.Size(80, 17);
            checkBox7.TabIndex = 9;
            checkBox7.Text = "checkBox7";
            checkBox7.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel4.Location = new System.Drawing.Point(10, 257);
            panel4.MinimumSize = new System.Drawing.Size(0, 10);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(649, 15);
            panel4.TabIndex = 30;
            // 
            // panel5
            // 
            panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel5.Location = new System.Drawing.Point(10, 389);
            panel5.MinimumSize = new System.Drawing.Size(0, 10);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(649, 15);
            panel5.TabIndex = 31;
            // 
            // DocumentsAddressEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(669, 414);
            ControlBox = false;
            Controls.Add(grouper_AllowedExt);
            Controls.Add(panel3);
            Controls.Add(grouper1);
            Controls.Add(panel2);
            Controls.Add(grouper_DocumentsAddressItem);
            Controls.Add(panel4);
            Controls.Add(grouper2);
            Controls.Add(panel_ButtonSaveCancel);
            Controls.Add(panel5);
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(685, 430);
            Name = "DocumentsAddressEditor";
            Padding = new System.Windows.Forms.Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DocumentsAddressEditor";
            TopMost = true;
            panel_ButtonSaveCancel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grouper_DocumentsAddressItem.ResumeLayout(false);
            grouper_DocumentsAddressItem.PerformLayout();
            grouper1.ResumeLayout(false);
            grouper1.PerformLayout();
            grouper2.ResumeLayout(false);
            grouper_AllowedExt.ResumeLayout(false);
            panel6.ResumeLayout(false);
            flowLayoutPanel_AllowedExt.ResumeLayout(false);
            flowLayoutPanel_AllowedExt.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_DescriptionReference;
        private System.Windows.Forms.RadioButton radioButton_Public;
        private System.Windows.Forms.RadioButton radioButton_Private;
        private System.Windows.Forms.Button button_SaveDocumentsAddress;
        private System.Windows.Forms.Button button_CancelDocumentsAddress;
        private System.Windows.Forms.Panel panel_ButtonSaveCancel;
        private System.Windows.Forms.Panel panel1;
        private CodeVendor.Controls.Grouper grouper_DocumentsAddressItem;
        private CodeVendor.Controls.Grouper grouper1;
        private System.Windows.Forms.TextBox textBox_DirectoryPathFolder;
        private System.Windows.Forms.Button button_BrowserDirectoryPathFolder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CodeVendor.Controls.Grouper grouper2;
        private CodeVendor.Controls.Grouper grouper_AllowedExt;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_AllowedExt;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
    }
}
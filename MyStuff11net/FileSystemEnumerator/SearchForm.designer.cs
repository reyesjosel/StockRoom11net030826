namespace MyStuff11net
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            listboxResult = new System.Windows.Forms.ListBox();
            comboPath = new System.Windows.Forms.ComboBox();
            checkInclude = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            buttonBrowse = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // listboxResult
            // 
            listboxResult.BackColor = System.Drawing.SystemColors.Info;
            listboxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            listboxResult.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            listboxResult.FormattingEnabled = true;
            listboxResult.HorizontalScrollbar = true;
            listboxResult.ItemHeight = 17;
            listboxResult.Location = new System.Drawing.Point(0, 77);
            listboxResult.Margin = new System.Windows.Forms.Padding(4);
            listboxResult.Name = "listboxResult";
            listboxResult.Size = new System.Drawing.Size(664, 383);
            listboxResult.TabIndex = 5;
            listboxResult.SelectedValueChanged += new System.EventHandler(OnSelectionChanged);
            listboxResult.DoubleClick += new System.EventHandler(listboxResult_DoubleClick);
            listboxResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(listboxResult_MouseDoubleClick);
            // 
            // comboPath
            // 
            comboPath.FormattingEnabled = true;
            comboPath.Location = new System.Drawing.Point(9, 33);
            comboPath.Margin = new System.Windows.Forms.Padding(4);
            comboPath.Name = "comboPath";
            comboPath.Size = new System.Drawing.Size(533, 24);
            comboPath.TabIndex = 0;
            comboPath.DropDown += new System.EventHandler(OnPathDropDown);
            // 
            // checkInclude
            // 
            checkInclude.AutoSize = true;
            checkInclude.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            checkInclude.Checked = true;
            checkInclude.CheckState = System.Windows.Forms.CheckState.Checked;
            checkInclude.Location = new System.Drawing.Point(485, 9);
            checkInclude.Margin = new System.Windows.Forms.Padding(4);
            checkInclude.Name = "checkInclude";
            checkInclude.Size = new System.Drawing.Size(170, 21);
            checkInclude.TabIndex = 2;
            checkInclude.Text = "Include Subdirectories";
            checkInclude.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 9);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(103, 17);
            label2.TabIndex = 13;
            label2.Text = "In Directories...";
            // 
            // buttonBrowse
            // 
            buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonBrowse.Location = new System.Drawing.Point(550, 31);
            buttonBrowse.Margin = new System.Windows.Forms.Padding(4);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new System.Drawing.Size(105, 27);
            buttonBrowse.TabIndex = 1;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += new System.EventHandler(OnButtonBrowse);
            // 
            // panel1
            // 
            panel1.Controls.Add(comboPath);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(checkInclude);
            panel1.Controls.Add(buttonBrowse);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(664, 77);
            panel1.TabIndex = 14;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(664, 460);
            Controls.Add(listboxResult);
            Controls.Add(panel1);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
            Margin = new System.Windows.Forms.Padding(4);
            Name = "SearchForm";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Search for Thumbnail files";
            Load += new System.EventHandler(OnLoad);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listboxResult;
        private System.Windows.Forms.ComboBox comboPath;
        private System.Windows.Forms.CheckBox checkInclude;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}
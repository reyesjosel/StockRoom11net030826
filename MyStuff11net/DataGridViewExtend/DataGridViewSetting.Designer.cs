namespace MyStuff11net
{
    partial class DataGridViewSetting
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
            dataGridView = new System.Windows.Forms.DataGridView();
            grouper_DataGridViiewSetting = new CodeVendor.Controls.Grouper();
            ((System.ComponentModel.ISupportInitialize)(dataGridView)).BeginInit();
            grouper_DataGridViiewSetting.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView.Location = new System.Drawing.Point(5, 25);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new System.Drawing.Size(583, 106);
            dataGridView.TabIndex = 0;
            // 
            // grouper_DataGridViiewSetting
            // 
            grouper_DataGridViiewSetting.BackgroundColor = System.Drawing.SystemColors.Control;
            grouper_DataGridViiewSetting.BackgroundGradientColor = System.Drawing.Color.White;
            grouper_DataGridViiewSetting.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_DataGridViiewSetting.BorderColor = System.Drawing.Color.Black;
            grouper_DataGridViiewSetting.BorderThickness = 1F;
            grouper_DataGridViiewSetting.Controls.Add(dataGridView);
            grouper_DataGridViiewSetting.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper_DataGridViiewSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            grouper_DataGridViiewSetting.GroupImage = null;
            grouper_DataGridViiewSetting.GroupTitle = "The Grouper";
            grouper_DataGridViiewSetting.Location = new System.Drawing.Point(0, 0);
            grouper_DataGridViiewSetting.Name = "grouper_DataGridViiewSetting";
            grouper_DataGridViiewSetting.Padding = new System.Windows.Forms.Padding(5, 25, 5, 5);
            grouper_DataGridViiewSetting.PaintGroupBox = false;
            grouper_DataGridViiewSetting.RoundCorners = 10;
            grouper_DataGridViiewSetting.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_DataGridViiewSetting.ShadowControl = false;
            grouper_DataGridViiewSetting.ShadowThickness = 3;
            grouper_DataGridViiewSetting.Size = new System.Drawing.Size(593, 136);
            grouper_DataGridViiewSetting.TabIndex = 2;
            // 
            // DataGridViewSetting
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            Controls.Add(grouper_DataGridViiewSetting);
            MinimumSize = new System.Drawing.Size(450, 136);
            Name = "DataGridViewSetting";
            Size = new System.Drawing.Size(593, 136);
            ((System.ComponentModel.ISupportInitialize)(dataGridView)).EndInit();
            grouper_DataGridViiewSetting.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private CodeVendor.Controls.Grouper grouper_DataGridViiewSetting;

    }
}

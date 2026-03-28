namespace MyStuff11net
{
    partial class QueryBuilder
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
            grouperFilter = new CodeVendor.Controls.Grouper();
            labelStringFilter = new Label();
            comboBoxStringFilter = new ComboBox();
            panelFilterConditions = new Panel();
            filterCondition0 = new FilterCondition();
            grouperFilter.SuspendLayout();
            panelFilterConditions.SuspendLayout();
            SuspendLayout();
            // 
            // grouperFilter
            // 
            grouperFilter.AutoSize = true;
            grouperFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouperFilter.BackgroundColor = Color.Silver;
            grouperFilter.BackgroundGradientColor = Color.DimGray;
            grouperFilter.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouperFilter.BorderColor = Color.Black;
            grouperFilter.BorderThickness = 1F;
            grouperFilter.Controls.Add(labelStringFilter);
            grouperFilter.Controls.Add(comboBoxStringFilter);
            grouperFilter.Controls.Add(panelFilterConditions);
            grouperFilter.CustomGroupBoxColor = SystemColors.Control;
            grouperFilter.Dock = DockStyle.Fill;
            grouperFilter.GroupImage = null;
            grouperFilter.GroupTitle = "Filter";
            grouperFilter.Location = new Point(0, 0);
            grouperFilter.Margin = new Padding(4, 5, 4, 5);
            grouperFilter.MinimumSize = new Size(200, 150);
            grouperFilter.Name = "grouperFilter";
            grouperFilter.Padding = new Padding(15, 30, 15, 16);
            grouperFilter.PaintGroupBox = true;
            grouperFilter.RoundCorners = 10;
            grouperFilter.ShadowColor = Color.DarkGray;
            grouperFilter.ShadowControl = false;
            grouperFilter.ShadowThickness = 3;
            grouperFilter.Size = new Size(250, 203);
            grouperFilter.TabIndex = 13;
            // 
            // labelStringFilter
            // 
            labelStringFilter.AutoEllipsis = true;
            labelStringFilter.Dock = DockStyle.Bottom;
            labelStringFilter.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelStringFilter.Location = new Point(15, 106);
            labelStringFilter.Margin = new Padding(0);
            labelStringFilter.MinimumSize = new Size(700, 45);
            labelStringFilter.Name = "labelStringFilter";
            labelStringFilter.Size = new Size(700, 52);
            labelStringFilter.TabIndex = 5;
            labelStringFilter.Text = "String Filter. The helper will attempt to format it correctly. Almost all, following this syntax, \"Column name + Operator + Condition\"";
            labelStringFilter.TextAlign = ContentAlignment.MiddleLeft;
            labelStringFilter.DoubleClick += LabelStringFilterDoubleClick;
            // 
            // comboBoxStringFilter
            // 
            comboBoxStringFilter.Dock = DockStyle.Bottom;
            comboBoxStringFilter.FormattingEnabled = true;
            comboBoxStringFilter.Location = new Point(15, 158);
            comboBoxStringFilter.Margin = new Padding(0);
            comboBoxStringFilter.Name = "comboBoxStringFilter";
            comboBoxStringFilter.Size = new Size(220, 29);
            comboBoxStringFilter.TabIndex = 2;
            // 
            // panelFilterConditions
            // 
            panelFilterConditions.AutoSize = true;
            panelFilterConditions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelFilterConditions.BackColor = Color.Gainsboro;
            panelFilterConditions.Controls.Add(filterCondition0);
            panelFilterConditions.Dock = DockStyle.Top;
            panelFilterConditions.Location = new Point(15, 30);
            panelFilterConditions.Name = "panelFilterConditions";
            panelFilterConditions.Padding = new Padding(4);
            panelFilterConditions.Size = new Size(220, 76);
            panelFilterConditions.TabIndex = 6;
            // 
            // filterCondition0
            // 
            filterCondition0.AutoSize = true;
            filterCondition0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            filterCondition0.BackColor = Color.Transparent;
            filterCondition0.BorderStyle = BorderStyle.Fixed3D;
            filterCondition0.Dock = DockStyle.Top;
            filterCondition0.Location = new Point(4, 4);
            filterCondition0.Margin = new Padding(4, 5, 4, 5);
            filterCondition0.MinimumSize = new Size(200, 50);
            filterCondition0.Name = "filterCondition0";
            filterCondition0.Size = new Size(212, 68);
            filterCondition0.TabIndex = 0;
            // 
            // QueryBuilder
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(grouperFilter);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(250, 75);
            Name = "QueryBuilder";
            Size = new Size(250, 203);
            grouperFilter.ResumeLayout(false);
            grouperFilter.PerformLayout();
            panelFilterConditions.ResumeLayout(false);
            panelFilterConditions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private CodeVendor.Controls.Grouper grouperFilter;
       
        private System.Windows.Forms.Label labelStringFilter;
        private System.Windows.Forms.ComboBox comboBoxStringFilter;
        private Panel panelFilterConditions;
        private FilterCondition filterCondition0;
    }
}

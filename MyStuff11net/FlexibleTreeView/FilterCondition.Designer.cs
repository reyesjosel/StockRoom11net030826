namespace MyStuff11net
{
    partial class FilterCondition
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
            comboBoxCondition = new ComboBox();
            comboBoxOperator = new ComboBox();
            comboBoxSecondCondition = new ComboBox();
            comboBoxColumnName = new ComboBox();
            labelColumnName = new Label();
            labelOperator = new Label();
            labelCondition = new Label();
            labelSecondCondition = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel_Labels = new Panel();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel_Labels.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxCondition
            // 
            comboBoxCondition.Dock = DockStyle.Fill;
            comboBoxCondition.Enabled = false;
            comboBoxCondition.FormattingEnabled = true;
            comboBoxCondition.Location = new Point(103, 5);
            comboBoxCondition.Margin = new Padding(5);
            comboBoxCondition.MaxDropDownItems = 20;
            comboBoxCondition.Name = "comboBoxCondition";
            comboBoxCondition.Size = new Size(58, 29);
            comboBoxCondition.TabIndex = 13;
            comboBoxCondition.DrawItem += ComboBoxDrawItem;
            comboBoxCondition.TextChanged += ComboBoxConditionTextChanged;
            comboBoxCondition.MouseDown += comboBoxCondition_MouseDown;
            // 
            // comboBoxOperator
            // 
            comboBoxOperator.BackColor = SystemColors.Window;
            comboBoxOperator.Dock = DockStyle.Fill;
            comboBoxOperator.Enabled = false;
            comboBoxOperator.FormattingEnabled = true;
            comboBoxOperator.Location = new Point(53, 4);
            comboBoxOperator.Margin = new Padding(4);
            comboBoxOperator.MaxDropDownItems = 20;
            comboBoxOperator.Name = "comboBoxOperator";
            comboBoxOperator.Size = new Size(41, 29);
            comboBoxOperator.TabIndex = 9;
            comboBoxOperator.DrawItem += ComboBoxDrawItem;
            comboBoxOperator.SelectedIndexChanged += ComboBoxOperatorSelectedIndexChanged;
            comboBoxOperator.TextChanged += ComboBoxOperatorTextChanged;
            comboBoxOperator.MouseDown += comboBoxOperator_MouseDown;
            // 
            // comboBoxSecondCondition
            // 
            comboBoxSecondCondition.AutoCompleteCustomSource.AddRange(new string[] { "AND", "OR", "NONE" });
            comboBoxSecondCondition.Dock = DockStyle.Fill;
            comboBoxSecondCondition.Enabled = false;
            comboBoxSecondCondition.FormattingEnabled = true;
            comboBoxSecondCondition.Items.AddRange(new object[] { "AND", "OR", "None" });
            comboBoxSecondCondition.Location = new Point(171, 5);
            comboBoxSecondCondition.Margin = new Padding(5);
            comboBoxSecondCondition.Name = "comboBoxSecondCondition";
            comboBoxSecondCondition.Size = new Size(20, 29);
            comboBoxSecondCondition.TabIndex = 18;
            comboBoxSecondCondition.Text = "None";
            comboBoxSecondCondition.DrawItem += ComboBoxDrawItem;
            comboBoxSecondCondition.TextChanged += ComboBoxSecondConditionTextChanged;
            comboBoxSecondCondition.MouseDown += ComboBoxSecondConditionMouseDown;
            // 
            // comboBoxColumnName
            // 
            comboBoxColumnName.Dock = DockStyle.Fill;
            comboBoxColumnName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxColumnName.FormattingEnabled = true;
            comboBoxColumnName.Location = new Point(5, 5);
            comboBoxColumnName.Margin = new Padding(5);
            comboBoxColumnName.MaxDropDownItems = 20;
            comboBoxColumnName.Name = "comboBoxColumnName";
            comboBoxColumnName.Size = new Size(39, 29);
            comboBoxColumnName.TabIndex = 19;
            comboBoxColumnName.DrawItem += ComboBoxDrawItem;
            comboBoxColumnName.SelectedIndexChanged += ComboBoxColumnNameSelectedIndexChanged;
            comboBoxColumnName.TextChanged += ComboBoxColumnNameTextChanged;
            comboBoxColumnName.MouseDown += ComboBoxColumnName_MouseDown;
            // 
            // labelColumnName
            // 
            labelColumnName.AutoSize = true;
            labelColumnName.Dock = DockStyle.Left;
            labelColumnName.Location = new Point(4, 4);
            labelColumnName.Margin = new Padding(4, 0, 4, 0);
            labelColumnName.Name = "labelColumnName";
            labelColumnName.Size = new Size(122, 21);
            labelColumnName.TabIndex = 22;
            labelColumnName.Text = "  Column Name.";
            // 
            // labelOperator
            // 
            labelOperator.AutoSize = true;
            labelOperator.Location = new Point(227, 2);
            labelOperator.Margin = new Padding(4, 0, 4, 0);
            labelOperator.Name = "labelOperator";
            labelOperator.Size = new Size(76, 21);
            labelOperator.TabIndex = 23;
            labelOperator.Text = "Operator.";
            // 
            // labelCondition
            // 
            labelCondition.AutoSize = true;
            labelCondition.Location = new Point(447, 2);
            labelCondition.Margin = new Padding(0);
            labelCondition.Name = "labelCondition";
            labelCondition.Size = new Size(81, 21);
            labelCondition.TabIndex = 24;
            labelCondition.Text = "Condition.";
            // 
            // labelSecondCondition
            // 
            labelSecondCondition.AutoSize = true;
            labelSecondCondition.Dock = DockStyle.Right;
            labelSecondCondition.Location = new Point(71, 4);
            labelSecondCondition.Margin = new Padding(4, 0, 4, 0);
            labelSecondCondition.Name = "labelSecondCondition";
            labelSecondCondition.Size = new Size(121, 21);
            labelSecondCondition.TabIndex = 21;
            labelSecondCondition.Text = "Second Cond.    ";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.09411F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0941029F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.13174F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.68005F));
            tableLayoutPanel1.Controls.Add(comboBoxOperator, 1, 0);
            tableLayoutPanel1.Controls.Add(comboBoxCondition, 2, 0);
            tableLayoutPanel1.Controls.Add(comboBoxSecondCondition, 3, 0);
            tableLayoutPanel1.Controls.Add(comboBoxColumnName, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(196, 39);
            tableLayoutPanel1.TabIndex = 27;
            // 
            // panel_Labels
            // 
            panel_Labels.AutoSize = true;
            panel_Labels.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Labels.Controls.Add(labelColumnName);
            panel_Labels.Controls.Add(labelOperator);
            panel_Labels.Controls.Add(labelCondition);
            panel_Labels.Controls.Add(labelSecondCondition);
            panel_Labels.Dock = DockStyle.Top;
            panel_Labels.Location = new Point(0, 0);
            panel_Labels.Name = "panel_Labels";
            panel_Labels.Padding = new Padding(4);
            panel_Labels.Size = new Size(196, 27);
            panel_Labels.TabIndex = 28;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(panel_Labels);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(196, 66);
            panel1.TabIndex = 29;
            // 
            // FilterCondition
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Gainsboro;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(200, 40);
            Name = "FilterCondition";
            Size = new Size(196, 66);
            Load += Filter_Condition_Load;
            VisibleChanged += Filter_Condition_VisibleChanged;
            tableLayoutPanel1.ResumeLayout(false);
            panel_Labels.ResumeLayout(false);
            panel_Labels.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCondition;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private System.Windows.Forms.ComboBox comboBoxSecondCondition;
        private System.Windows.Forms.ComboBox comboBoxColumnName;
        private System.Windows.Forms.Label labelColumnName;
        private System.Windows.Forms.Label labelOperator;
        private System.Windows.Forms.Label labelCondition;
        private System.Windows.Forms.Label labelSecondCondition;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel_Labels;
        private Panel panel1;
    }
}

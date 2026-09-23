namespace StockRoom11net.Controls
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel_Next = new Panel();
            labelNext = new Label();
            panel_Operator = new Panel();
            panel_Condition = new Panel();
            panel_Name = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel_Next.SuspendLayout();
            panel_Operator.SuspendLayout();
            panel_Condition.SuspendLayout();
            panel_Name.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxCondition
            // 
            comboBoxCondition.Dock = DockStyle.Top;
            comboBoxCondition.Enabled = false;
            comboBoxCondition.FormattingEnabled = true;
            comboBoxCondition.Location = new Point(4, 24);
            comboBoxCondition.Margin = new Padding(5);
            comboBoxCondition.MaxDropDownItems = 20;
            comboBoxCondition.Name = "comboBoxCondition";
            comboBoxCondition.Size = new Size(233, 28);
            comboBoxCondition.TabIndex = 13;
            comboBoxCondition.DrawItem += ComboBoxDrawItem;
            comboBoxCondition.TextChanged += ComboBoxConditionTextChanged;
            comboBoxCondition.MouseDown += comboBoxCondition_MouseDown;
            // 
            // comboBoxOperator
            // 
            comboBoxOperator.BackColor = SystemColors.Window;
            comboBoxOperator.Dock = DockStyle.Top;
            comboBoxOperator.Enabled = false;
            comboBoxOperator.FormattingEnabled = true;
            comboBoxOperator.Location = new Point(4, 24);
            comboBoxOperator.Margin = new Padding(4);
            comboBoxOperator.MaxDropDownItems = 20;
            comboBoxOperator.Name = "comboBoxOperator";
            comboBoxOperator.Size = new Size(234, 28);
            comboBoxOperator.TabIndex = 9;
            comboBoxOperator.DrawItem += ComboBoxDrawItem;
            comboBoxOperator.SelectedIndexChanged += ComboBoxOperatorSelectedIndexChanged;
            comboBoxOperator.TextChanged += ComboBoxOperatorTextChanged;
            comboBoxOperator.MouseDown += comboBoxOperator_MouseDown;
            // 
            // comboBoxSecondCondition
            // 
            comboBoxSecondCondition.AutoCompleteCustomSource.AddRange(new string[] { "AND", "OR", "NONE" });
            comboBoxSecondCondition.Dock = DockStyle.Top;
            comboBoxSecondCondition.Enabled = false;
            comboBoxSecondCondition.FormattingEnabled = true;
            comboBoxSecondCondition.Items.AddRange(new object[] { "AND", "OR", "None" });
            comboBoxSecondCondition.Location = new Point(4, 24);
            comboBoxSecondCondition.Margin = new Padding(5);
            comboBoxSecondCondition.Name = "comboBoxSecondCondition";
            comboBoxSecondCondition.Size = new Size(135, 28);
            comboBoxSecondCondition.TabIndex = 18;
            comboBoxSecondCondition.Text = "None";
            comboBoxSecondCondition.DrawItem += ComboBoxDrawItem;
            comboBoxSecondCondition.TextChanged += ComboBoxSecondConditionTextChanged;
            comboBoxSecondCondition.MouseDown += ComboBoxSecondConditionMouseDown;
            // 
            // comboBoxColumnName
            // 
            comboBoxColumnName.Dock = DockStyle.Top;
            comboBoxColumnName.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxColumnName.FormattingEnabled = true;
            comboBoxColumnName.Location = new Point(4, 24);
            comboBoxColumnName.Margin = new Padding(5);
            comboBoxColumnName.MaxDropDownItems = 20;
            comboBoxColumnName.Name = "comboBoxColumnName";
            comboBoxColumnName.Size = new Size(234, 28);
            comboBoxColumnName.TabIndex = 19;
            comboBoxColumnName.DrawItem += ComboBoxDrawItem;
            comboBoxColumnName.SelectedIndexChanged += ComboBoxColumnNameSelectedIndexChanged;
            comboBoxColumnName.TextChanged += ComboBoxColumnNameTextChanged;
            comboBoxColumnName.MouseDown += ComboBoxColumnName_MouseDown;
            // 
            // labelColumnName
            // 
            labelColumnName.AutoSize = true;
            labelColumnName.Dock = DockStyle.Top;
            labelColumnName.Location = new Point(4, 4);
            labelColumnName.Margin = new Padding(4);
            labelColumnName.Name = "labelColumnName";
            labelColumnName.Size = new Size(113, 20);
            labelColumnName.TabIndex = 22;
            labelColumnName.Text = "Column Name.";
            // 
            // labelOperator
            // 
            labelOperator.AutoSize = true;
            labelOperator.Dock = DockStyle.Top;
            labelOperator.Location = new Point(4, 4);
            labelOperator.Margin = new Padding(4, 0, 4, 0);
            labelOperator.Name = "labelOperator";
            labelOperator.Size = new Size(76, 20);
            labelOperator.TabIndex = 23;
            labelOperator.Text = "Operator.";
            // 
            // labelCondition
            // 
            labelCondition.AutoSize = true;
            labelCondition.Dock = DockStyle.Top;
            labelCondition.Location = new Point(4, 4);
            labelCondition.Margin = new Padding(0);
            labelCondition.Name = "labelCondition";
            labelCondition.Size = new Size(80, 20);
            labelCondition.TabIndex = 24;
            labelCondition.Text = "Condition.";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Gainsboro;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.92322F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.92321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.8184986F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.33508F));
            tableLayoutPanel1.Controls.Add(panel_Next, 3, 0);
            tableLayoutPanel1.Controls.Add(panel_Operator, 1, 0);
            tableLayoutPanel1.Controls.Add(panel_Condition, 2, 0);
            tableLayoutPanel1.Controls.Add(panel_Name, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.MinimumSize = new Size(300, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(868, 56);
            tableLayoutPanel1.TabIndex = 27;
            // 
            // panel_Next
            // 
            panel_Next.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_Next.AutoSize = true;
            panel_Next.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Next.BackColor = Color.Transparent;
            panel_Next.Controls.Add(comboBoxSecondCondition);
            panel_Next.Controls.Add(labelNext);
            panel_Next.Location = new Point(725, 0);
            panel_Next.Margin = new Padding(0);
            panel_Next.Name = "panel_Next";
            panel_Next.Padding = new Padding(4);
            panel_Next.Size = new Size(143, 56);
            panel_Next.TabIndex = 32;
            // 
            // labelNext
            // 
            labelNext.AutoSize = true;
            labelNext.Dock = DockStyle.Top;
            labelNext.Location = new Point(4, 4);
            labelNext.Name = "labelNext";
            labelNext.Size = new Size(41, 20);
            labelNext.TabIndex = 19;
            labelNext.Text = "Next";
            // 
            // panel_Operator
            // 
            panel_Operator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_Operator.AutoSize = true;
            panel_Operator.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Operator.BackColor = Color.Transparent;
            panel_Operator.Controls.Add(comboBoxOperator);
            panel_Operator.Controls.Add(labelOperator);
            panel_Operator.Location = new Point(242, 0);
            panel_Operator.Margin = new Padding(0);
            panel_Operator.Name = "panel_Operator";
            panel_Operator.Padding = new Padding(4);
            panel_Operator.Size = new Size(242, 56);
            panel_Operator.TabIndex = 30;
            // 
            // panel_Condition
            // 
            panel_Condition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_Condition.AutoSize = true;
            panel_Condition.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Condition.BackColor = Color.Transparent;
            panel_Condition.Controls.Add(comboBoxCondition);
            panel_Condition.Controls.Add(labelCondition);
            panel_Condition.Location = new Point(484, 0);
            panel_Condition.Margin = new Padding(0);
            panel_Condition.Name = "panel_Condition";
            panel_Condition.Padding = new Padding(4);
            panel_Condition.Size = new Size(241, 56);
            panel_Condition.TabIndex = 31;
            // 
            // panel_Name
            // 
            panel_Name.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_Name.AutoSize = true;
            panel_Name.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Name.BackColor = Color.Transparent;
            panel_Name.Controls.Add(comboBoxColumnName);
            panel_Name.Controls.Add(labelColumnName);
            panel_Name.Location = new Point(0, 0);
            panel_Name.Margin = new Padding(0);
            panel_Name.Name = "panel_Name";
            panel_Name.Padding = new Padding(4);
            panel_Name.Size = new Size(242, 56);
            panel_Name.TabIndex = 29;
            // 
            // FilterCondition
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(300, 0);
            Name = "FilterCondition";
            Size = new Size(868, 59);
            Load += Filter_Condition_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel_Next.ResumeLayout(false);
            panel_Next.PerformLayout();
            panel_Operator.ResumeLayout(false);
            panel_Operator.PerformLayout();
            panel_Condition.ResumeLayout(false);
            panel_Condition.PerformLayout();
            panel_Name.ResumeLayout(false);
            panel_Name.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCondition;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private System.Windows.Forms.ComboBox comboBoxSecondCondition;
        private System.Windows.Forms.ComboBox comboBoxColumnName;
        private System.Windows.Forms.Label labelColumnName;
        private System.Windows.Forms.Label labelOperator;
        private System.Windows.Forms.Label labelCondition;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel_Name;
        private Panel panel_Operator;
        private Panel panel_Condition;
        private Panel panel_Next;
        private Label labelNext;
    }
}

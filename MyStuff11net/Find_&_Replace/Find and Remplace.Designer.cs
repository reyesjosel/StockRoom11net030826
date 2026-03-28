namespace MyStuff11net
{
    partial class Find_and_Remplace
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
            groupBox_Find = new GroupBox();
            label_SelectAnyColor = new Label();
            comboBox_Find_Look_In = new ComboBox();
            label_Look_In = new Label();
            comboBox_Find_Match = new ComboBox();
            label_Match = new Label();
            label_Find_Search = new Label();
            textBox_Find = new TextBox();
            grouper_Select_any_Color = new CodeVendor.Controls.Grouper();
            button_Find_Cancel = new Button();
            button_Find_Execute = new Button();
            groupBox_Replace = new GroupBox();
            comboBox_Replace_Look_In = new ComboBox();
            label_Replace_Look_In = new Label();
            comboBox_Replace_Macth = new ComboBox();
            label_Replace_Match = new Label();
            label2 = new Label();
            textBox_Replace = new TextBox();
            label_Replace = new Label();
            textBox_Replace_Replace = new TextBox();
            button_Replace_Cancel = new Button();
            button_Replace_Execute = new Button();
            groupBox_Fill = new GroupBox();
            comboBox_Fill_Look_In = new ComboBox();
            label_Fill_Look_In = new Label();
            label1 = new Label();
            textBox_Fill = new TextBox();
            button_Fill_Cancel = new Button();
            button_Fill_Execute = new Button();
            toolTip_Find_Replace_Tool = new ToolTip(components);
            splitContainer_Horizontal = new SplitContainer();
            splitContainer_Vertical = new SplitContainer();
            customTabControl_ProjectsViewer = new CustomTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dockPanelWebBrower = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            tabPage3 = new TabPage();
            dataGridViewExtended = new MyStuff11net.DataGridViewExtend.DataGridViewExtended();
            groupBox_Find.SuspendLayout();
            groupBox_Replace.SuspendLayout();
            groupBox_Fill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Horizontal).BeginInit();
            splitContainer_Horizontal.Panel1.SuspendLayout();
            splitContainer_Horizontal.Panel2.SuspendLayout();
            splitContainer_Horizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Vertical).BeginInit();
            splitContainer_Vertical.Panel2.SuspendLayout();
            splitContainer_Vertical.SuspendLayout();
            customTabControl_ProjectsViewer.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox_Find
            // 
            groupBox_Find.Controls.Add(label_SelectAnyColor);
            groupBox_Find.Controls.Add(comboBox_Find_Look_In);
            groupBox_Find.Controls.Add(label_Look_In);
            groupBox_Find.Controls.Add(comboBox_Find_Match);
            groupBox_Find.Controls.Add(label_Match);
            groupBox_Find.Controls.Add(label_Find_Search);
            groupBox_Find.Controls.Add(textBox_Find);
            groupBox_Find.Controls.Add(grouper_Select_any_Color);
            groupBox_Find.Location = new Point(30, 26);
            groupBox_Find.Name = "groupBox_Find";
            groupBox_Find.Size = new Size(230, 165);
            groupBox_Find.TabIndex = 4;
            groupBox_Find.TabStop = false;
            // 
            // label_SelectAnyColor
            // 
            label_SelectAnyColor.AutoSize = true;
            label_SelectAnyColor.Location = new Point(6, 56);
            label_SelectAnyColor.Name = "label_SelectAnyColor";
            label_SelectAnyColor.Size = new Size(129, 21);
            label_SelectAnyColor.TabIndex = 12;
            label_SelectAnyColor.Text = "Select any Color :";
            // 
            // comboBox_Find_Look_In
            // 
            comboBox_Find_Look_In.FormattingEnabled = true;
            comboBox_Find_Look_In.Items.AddRange(new object[] { "Current Column.", "Whole DataBase." });
            comboBox_Find_Look_In.Location = new Point(96, 130);
            comboBox_Find_Look_In.Name = "comboBox_Find_Look_In";
            comboBox_Find_Look_In.Size = new Size(116, 29);
            comboBox_Find_Look_In.TabIndex = 14;
            comboBox_Find_Look_In.Text = "Current Column.";
            // 
            // label_Look_In
            // 
            label_Look_In.AutoSize = true;
            label_Look_In.Location = new Point(10, 138);
            label_Look_In.Name = "label_Look_In";
            label_Look_In.Size = new Size(68, 21);
            label_Look_In.TabIndex = 13;
            label_Look_In.Text = "Look In :";
            // 
            // comboBox_Find_Match
            // 
            comboBox_Find_Match.FormattingEnabled = true;
            comboBox_Find_Match.Items.AddRange(new object[] { "Equals...", "Does Not Equals...", "Begin With...", "Does Not Begin With...", "Contains...", "Does Not Contains...", "Ends With...", "Does Not End With..." });
            comboBox_Find_Match.Location = new Point(96, 86);
            comboBox_Find_Match.Name = "comboBox_Find_Match";
            comboBox_Find_Match.Size = new Size(116, 29);
            comboBox_Find_Match.TabIndex = 12;
            comboBox_Find_Match.Text = "Equals...";
            comboBox_Find_Match.SelectionChangeCommitted += Combo_box_string_find_selection_change_committed;
            comboBox_Find_Match.TextUpdate += Combo_box_string_find_text_update;
            // 
            // label_Match
            // 
            label_Match.AutoSize = true;
            label_Match.Location = new Point(6, 94);
            label_Match.Name = "label_Match";
            label_Match.Size = new Size(60, 21);
            label_Match.TabIndex = 12;
            label_Match.Text = "Match :";
            // 
            // label_Find_Search
            // 
            label_Find_Search.AutoSize = true;
            label_Find_Search.Location = new Point(6, 22);
            label_Find_Search.Name = "label_Find_Search";
            label_Find_Search.Size = new Size(85, 21);
            label_Find_Search.TabIndex = 1;
            label_Find_Search.Text = "Search by :";
            // 
            // textBox_Find
            // 
            textBox_Find.Location = new Point(96, 14);
            textBox_Find.Name = "textBox_Find";
            textBox_Find.Size = new Size(116, 29);
            textBox_Find.TabIndex = 0;
            // 
            // grouper_Select_any_Color
            // 
            grouper_Select_any_Color.BackgroundColor = Color.FromArgb(255, 224, 192);
            grouper_Select_any_Color.BackgroundGradientColor = Color.White;
            grouper_Select_any_Color.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_Select_any_Color.BorderColor = Color.Black;
            grouper_Select_any_Color.BorderThickness = 1F;
            grouper_Select_any_Color.CustomGroupBoxColor = Color.White;
            grouper_Select_any_Color.GroupImage = null;
            grouper_Select_any_Color.GroupTitle = "";
            grouper_Select_any_Color.Location = new Point(138, 39);
            grouper_Select_any_Color.Name = "grouper_Select_any_Color";
            grouper_Select_any_Color.Padding = new Padding(20);
            grouper_Select_any_Color.PaintGroupBox = false;
            grouper_Select_any_Color.RoundCorners = 5;
            grouper_Select_any_Color.ShadowColor = Color.DarkGray;
            grouper_Select_any_Color.ShadowControl = false;
            grouper_Select_any_Color.ShadowThickness = 3;
            grouper_Select_any_Color.Size = new Size(74, 38);
            grouper_Select_any_Color.TabIndex = 14;
            toolTip_Find_Replace_Tool.SetToolTip(grouper_Select_any_Color, "Click over here to select diferent Color.");
            grouper_Select_any_Color.Click += Grouper_select_any_color_click;
            // 
            // button_Find_Cancel
            // 
            button_Find_Cancel.Location = new Point(142, 211);
            button_Find_Cancel.Name = "button_Find_Cancel";
            button_Find_Cancel.Size = new Size(80, 35);
            button_Find_Cancel.TabIndex = 11;
            button_Find_Cancel.Text = "Cancel";
            button_Find_Cancel.UseVisualStyleBackColor = true;
            button_Find_Cancel.Click += Button_find_cancel_click;
            // 
            // button_Find_Execute
            // 
            button_Find_Execute.Location = new Point(41, 211);
            button_Find_Execute.Name = "button_Find_Execute";
            button_Find_Execute.Size = new Size(80, 35);
            button_Find_Execute.TabIndex = 10;
            button_Find_Execute.Text = "Execute";
            button_Find_Execute.UseVisualStyleBackColor = true;
            button_Find_Execute.Click += Button_find_execute_click;
            // 
            // groupBox_Replace
            // 
            groupBox_Replace.AutoSize = true;
            groupBox_Replace.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox_Replace.Controls.Add(comboBox_Replace_Look_In);
            groupBox_Replace.Controls.Add(label_Replace_Look_In);
            groupBox_Replace.Controls.Add(comboBox_Replace_Macth);
            groupBox_Replace.Controls.Add(label_Replace_Match);
            groupBox_Replace.Controls.Add(label2);
            groupBox_Replace.Controls.Add(textBox_Replace);
            groupBox_Replace.Controls.Add(label_Replace);
            groupBox_Replace.Controls.Add(textBox_Replace_Replace);
            groupBox_Replace.Location = new Point(19, 14);
            groupBox_Replace.Name = "groupBox_Replace";
            groupBox_Replace.Size = new Size(232, 183);
            groupBox_Replace.TabIndex = 6;
            groupBox_Replace.TabStop = false;
            // 
            // comboBox_Replace_Look_In
            // 
            comboBox_Replace_Look_In.FormattingEnabled = true;
            comboBox_Replace_Look_In.Items.AddRange(new object[] { "Current Column.", "Whole DataBase." });
            comboBox_Replace_Look_In.Location = new Point(91, 126);
            comboBox_Replace_Look_In.Name = "comboBox_Replace_Look_In";
            comboBox_Replace_Look_In.Size = new Size(135, 29);
            comboBox_Replace_Look_In.TabIndex = 18;
            comboBox_Replace_Look_In.Text = "Current Column.";
            // 
            // label_Replace_Look_In
            // 
            label_Replace_Look_In.AutoSize = true;
            label_Replace_Look_In.Location = new Point(8, 129);
            label_Replace_Look_In.Name = "label_Replace_Look_In";
            label_Replace_Look_In.Size = new Size(68, 21);
            label_Replace_Look_In.TabIndex = 17;
            label_Replace_Look_In.Text = "Look In :";
            // 
            // comboBox_Replace_Macth
            // 
            comboBox_Replace_Macth.FormattingEnabled = true;
            comboBox_Replace_Macth.Items.AddRange(new object[] { "Equals...", "Does Not Equals...", "Begin With...", "Does Not Begin With...", "Contains...", "Does Not Contains...", "Ends With...", "Does Not End With..." });
            comboBox_Replace_Macth.Location = new Point(91, 86);
            comboBox_Replace_Macth.Name = "comboBox_Replace_Macth";
            comboBox_Replace_Macth.Size = new Size(135, 29);
            comboBox_Replace_Macth.TabIndex = 15;
            comboBox_Replace_Macth.Text = "Equals...";
            // 
            // label_Replace_Match
            // 
            label_Replace_Match.AutoSize = true;
            label_Replace_Match.Location = new Point(6, 94);
            label_Replace_Match.Name = "label_Replace_Match";
            label_Replace_Match.Size = new Size(60, 21);
            label_Replace_Match.TabIndex = 16;
            label_Replace_Match.Text = "Match :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 22);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 5;
            label2.Text = "Search by :";
            // 
            // textBox_Replace
            // 
            textBox_Replace.Location = new Point(105, 19);
            textBox_Replace.Name = "textBox_Replace";
            textBox_Replace.Size = new Size(121, 29);
            textBox_Replace.TabIndex = 4;
            // 
            // label_Replace
            // 
            label_Replace.AutoSize = true;
            label_Replace.Location = new Point(6, 51);
            label_Replace.Name = "label_Replace";
            label_Replace.Size = new Size(92, 21);
            label_Replace.TabIndex = 3;
            label_Replace.Text = "Replace by :";
            // 
            // textBox_Replace_Replace
            // 
            textBox_Replace_Replace.Location = new Point(108, 51);
            textBox_Replace_Replace.Name = "textBox_Replace_Replace";
            textBox_Replace_Replace.Size = new Size(118, 29);
            textBox_Replace_Replace.TabIndex = 2;
            textBox_Replace_Replace.TextChanged += Text_box_replace_replace_text_changed;
            // 
            // button_Replace_Cancel
            // 
            button_Replace_Cancel.Location = new Point(110, 203);
            button_Replace_Cancel.Name = "button_Replace_Cancel";
            button_Replace_Cancel.Size = new Size(80, 35);
            button_Replace_Cancel.TabIndex = 11;
            button_Replace_Cancel.Text = "Cancel";
            button_Replace_Cancel.UseVisualStyleBackColor = true;
            button_Replace_Cancel.Click += Button_replace_cancel_click;
            // 
            // button_Replace_Execute
            // 
            button_Replace_Execute.Location = new Point(19, 203);
            button_Replace_Execute.Name = "button_Replace_Execute";
            button_Replace_Execute.Size = new Size(80, 35);
            button_Replace_Execute.TabIndex = 10;
            button_Replace_Execute.Text = "Execute";
            button_Replace_Execute.UseVisualStyleBackColor = true;
            button_Replace_Execute.Click += Button_replace_execute_click;
            // 
            // groupBox_Fill
            // 
            groupBox_Fill.Controls.Add(comboBox_Fill_Look_In);
            groupBox_Fill.Controls.Add(label_Fill_Look_In);
            groupBox_Fill.Controls.Add(label1);
            groupBox_Fill.Controls.Add(textBox_Fill);
            groupBox_Fill.Location = new Point(19, 16);
            groupBox_Fill.Name = "groupBox_Fill";
            groupBox_Fill.Size = new Size(178, 140);
            groupBox_Fill.TabIndex = 7;
            groupBox_Fill.TabStop = false;
            // 
            // comboBox_Fill_Look_In
            // 
            comboBox_Fill_Look_In.FormattingEnabled = true;
            comboBox_Fill_Look_In.Items.AddRange(new object[] { "Current Column.", "Whole DataBase." });
            comboBox_Fill_Look_In.Location = new Point(56, 113);
            comboBox_Fill_Look_In.Name = "comboBox_Fill_Look_In";
            comboBox_Fill_Look_In.Size = new Size(116, 29);
            comboBox_Fill_Look_In.TabIndex = 18;
            comboBox_Fill_Look_In.Text = "Current Column.";
            // 
            // label_Fill_Look_In
            // 
            label_Fill_Look_In.AutoSize = true;
            label_Fill_Look_In.Location = new Point(6, 121);
            label_Fill_Look_In.Name = "label_Fill_Look_In";
            label_Fill_Look_In.Size = new Size(68, 21);
            label_Fill_Look_In.TabIndex = 17;
            label_Fill_Look_In.Text = "Look In :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 3;
            label1.Text = "Fill with :";
            // 
            // textBox_Fill
            // 
            textBox_Fill.Location = new Point(59, 19);
            textBox_Fill.Name = "textBox_Fill";
            textBox_Fill.Size = new Size(113, 29);
            textBox_Fill.TabIndex = 2;
            // 
            // button_Fill_Cancel
            // 
            button_Fill_Cancel.Location = new Point(111, 191);
            button_Fill_Cancel.Name = "button_Fill_Cancel";
            button_Fill_Cancel.Size = new Size(80, 35);
            button_Fill_Cancel.TabIndex = 9;
            button_Fill_Cancel.Text = "Cancel";
            button_Fill_Cancel.UseVisualStyleBackColor = true;
            button_Fill_Cancel.Click += Button_fill_cancel_click;
            // 
            // button_Fill_Execute
            // 
            button_Fill_Execute.Location = new Point(19, 191);
            button_Fill_Execute.Name = "button_Fill_Execute";
            button_Fill_Execute.Size = new Size(80, 35);
            button_Fill_Execute.TabIndex = 8;
            button_Fill_Execute.Text = "Execute";
            button_Fill_Execute.UseVisualStyleBackColor = true;
            button_Fill_Execute.Click += Button_fill_execute_click;
            // 
            // toolTip_Find_Replace_Tool
            // 
            toolTip_Find_Replace_Tool.AutoPopDelay = 5000;
            toolTip_Find_Replace_Tool.InitialDelay = 250;
            toolTip_Find_Replace_Tool.IsBalloon = true;
            toolTip_Find_Replace_Tool.ReshowDelay = 100;
            // 
            // splitContainer_Horizontal
            // 
            splitContainer_Horizontal.BorderStyle = BorderStyle.Fixed3D;
            splitContainer_Horizontal.Dock = DockStyle.Fill;
            splitContainer_Horizontal.Location = new Point(0, 0);
            splitContainer_Horizontal.Margin = new Padding(2);
            splitContainer_Horizontal.Name = "splitContainer_Horizontal";
            splitContainer_Horizontal.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_Horizontal.Panel1
            // 
            splitContainer_Horizontal.Panel1.Controls.Add(splitContainer_Vertical);
            // 
            // splitContainer_Horizontal.Panel2
            // 
            splitContainer_Horizontal.Panel2.Controls.Add(dataGridViewExtended);
            splitContainer_Horizontal.Size = new Size(1216, 753);
            splitContainer_Horizontal.SplitterDistance = 331;
            splitContainer_Horizontal.SplitterWidth = 2;
            splitContainer_Horizontal.TabIndex = 6;
            // 
            // splitContainer_Vertical
            // 
            splitContainer_Vertical.BorderStyle = BorderStyle.Fixed3D;
            splitContainer_Vertical.Dock = DockStyle.Fill;
            splitContainer_Vertical.Location = new Point(0, 0);
            splitContainer_Vertical.Margin = new Padding(2);
            splitContainer_Vertical.Name = "splitContainer_Vertical";
            // 
            // splitContainer_Vertical.Panel2
            // 
            splitContainer_Vertical.Panel2.Controls.Add(customTabControl_ProjectsViewer);
            splitContainer_Vertical.Size = new Size(1216, 331);
            splitContainer_Vertical.SplitterDistance = 565;
            splitContainer_Vertical.SplitterWidth = 2;
            splitContainer_Vertical.TabIndex = 0;
            // 
            // customTabControl_ProjectsViewer
            // 
            customTabControl_ProjectsViewer.Controls.Add(tabPage1);
            customTabControl_ProjectsViewer.Controls.Add(tabPage2);
            customTabControl_ProjectsViewer.Controls.Add(tabPage3);
            customTabControl_ProjectsViewer.DisplayStyle = TabStyle.VisualStudio;
            // 
            // 
            // 
            customTabControl_ProjectsViewer.DisplayStyleProvider.BorderColor = Color.DarkGray;
            customTabControl_ProjectsViewer.DisplayStyleProvider.BorderColorHot = Color.DarkGray;
            customTabControl_ProjectsViewer.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(127, 157, 185);
            customTabControl_ProjectsViewer.DisplayStyleProvider.CloserColor = Color.DarkGray;
            customTabControl_ProjectsViewer.DisplayStyleProvider.TextColor = Color.Black;
            customTabControl_ProjectsViewer.DisplayStyleProvider.TextColorDisabled = Color.DarkGray;
            customTabControl_ProjectsViewer.DisplayStyleProvider.TextColorSelected = Color.Black;
            customTabControl_ProjectsViewer.Dock = DockStyle.Fill;
            customTabControl_ProjectsViewer.ItemSize = new Size(90, 24);
            customTabControl_ProjectsViewer.Location = new Point(0, 0);
            customTabControl_ProjectsViewer.Margin = new Padding(2);
            customTabControl_ProjectsViewer.Name = "customTabControl_ProjectsViewer";
            customTabControl_ProjectsViewer.SelectedIndex = 0;
            customTabControl_ProjectsViewer.Size = new Size(645, 327);
            customTabControl_ProjectsViewer.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Window;
            tabPage1.Controls.Add(button_Find_Cancel);
            tabPage1.Controls.Add(groupBox_Find);
            tabPage1.Controls.Add(button_Find_Execute);
            tabPage1.Location = new Point(4, 4);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(637, 294);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "   tabPage1";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button_Replace_Cancel);
            tabPage2.Controls.Add(groupBox_Replace);
            tabPage2.Controls.Add(button_Replace_Execute);
            tabPage2.Controls.Add(dockPanelWebBrower);
            tabPage2.Location = new Point(4, 4);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(637, 294);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "   tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dockPanelWebBrower
            // 
            dockPanelWebBrower.Dock = DockStyle.Fill;
            dockPanelWebBrower.DocumentStyle = WinFormsUI.Docking.DocumentStyle.DockingSdi;
            dockPanelWebBrower.Location = new Point(2, 2);
            dockPanelWebBrower.Name = "dockPanelWebBrower";
            dockPanelWebBrower.Size = new Size(633, 290);
            dockPanelWebBrower.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button_Fill_Cancel);
            tabPage3.Controls.Add(groupBox_Fill);
            tabPage3.Controls.Add(button_Fill_Execute);
            tabPage3.Location = new Point(4, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(637, 294);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "   tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewExtended
            // 
            dataGridViewExtended.BindingCompleted = false;
            dataGridViewExtended.CurrentRowBackgroundColor = Color.DeepSkyBlue;
            dataGridViewExtended.CurrentRowBorderColor = Color.DarkBlue;
            dataGridViewExtended.CustomEdit = MyCode.EditMode.View;
            dataGridViewExtended.DividerColor = Color.Red;
            dataGridViewExtended.DividerHeight = 0;
            dataGridViewExtended.Dock = DockStyle.Fill;
            dataGridViewExtended.FirstDisplayedRow = null;
            dataGridViewExtended.Location = new Point(0, 0);
            dataGridViewExtended.Margin = new Padding(4, 5, 4, 5);
            dataGridViewExtended.Name = "dataGridViewExtended";
            dataGridViewExtended.NeedSaveData = false;
            dataGridViewExtended.SelectionBorderWidth = 3;
            dataGridViewExtended.SelectionColor = Color.DeepSkyBlue;
            dataGridViewExtended.SetValueAt = null;
            dataGridViewExtended.Size = new Size(1212, 416);
            dataGridViewExtended.TabIndex = 1;
            // 
            // Find_and_Remplace
            // 
            AccessibleRole = AccessibleRole.TitleBar;
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1216, 753);
            Controls.Add(splitContainer_Horizontal);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Find_and_Remplace";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            groupBox_Find.ResumeLayout(false);
            groupBox_Find.PerformLayout();
            groupBox_Replace.ResumeLayout(false);
            groupBox_Replace.PerformLayout();
            groupBox_Fill.ResumeLayout(false);
            groupBox_Fill.PerformLayout();
            splitContainer_Horizontal.Panel1.ResumeLayout(false);
            splitContainer_Horizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Horizontal).EndInit();
            splitContainer_Horizontal.ResumeLayout(false);
            splitContainer_Vertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Vertical).EndInit();
            splitContainer_Vertical.ResumeLayout(false);
            customTabControl_ProjectsViewer.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button button_Find_Cancel;
        private System.Windows.Forms.Button button_Find_Execute;
        private System.Windows.Forms.Button button_Replace_Cancel;
        private System.Windows.Forms.Button button_Replace_Execute;
        private System.Windows.Forms.GroupBox groupBox_Replace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Replace;
        private System.Windows.Forms.Label label_Replace;
        private System.Windows.Forms.TextBox textBox_Replace_Replace;
        private System.Windows.Forms.GroupBox groupBox_Fill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Fill;
        private System.Windows.Forms.Button button_Fill_Cancel;
        private System.Windows.Forms.Button button_Fill_Execute;
        private System.Windows.Forms.GroupBox groupBox_Find;
        private System.Windows.Forms.ComboBox comboBox_Find_Look_In;
        private System.Windows.Forms.Label label_Look_In;
        private System.Windows.Forms.ComboBox comboBox_Find_Match;
        private System.Windows.Forms.Label label_Match;
        private System.Windows.Forms.Label label_Find_Search;
        private System.Windows.Forms.TextBox textBox_Find;
        private System.Windows.Forms.ComboBox comboBox_Replace_Look_In;
        private System.Windows.Forms.Label label_Replace_Look_In;
        private System.Windows.Forms.ComboBox comboBox_Replace_Macth;
        private System.Windows.Forms.Label label_Replace_Match;
        private System.Windows.Forms.ComboBox comboBox_Fill_Look_In;
        private System.Windows.Forms.Label label_Fill_Look_In;
        private System.Windows.Forms.Label label_SelectAnyColor;
        private CodeVendor.Controls.Grouper grouper_Select_any_Color;
        private System.Windows.Forms.ToolTip toolTip_Find_Replace_Tool;
        private SplitContainer splitContainer_Horizontal;
        private SplitContainer splitContainer_Vertical;
        private CustomTabControl customTabControl_ProjectsViewer;
        private TabPage tabPage1;
        private TabPage tabPage2;
        public WeifenLuo.WinFormsUI.Docking.DockPanel dockPanelWebBrower;
        private TabPage tabPage3;
        private DataGridViewExtend.DataGridViewExtended dataGridViewExtended;
    }
}
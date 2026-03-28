using MyStuff11net.MouseKeyboardActivityMonitor.Controls;

namespace MyStuff11net
{
    partial class FlexibleTreeViewSetting
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
            _contextMenuStrip = new ContextMenuStrip(components);
            ToolStripMenuItem_ExpandAll = new ToolStripMenuItem();
            ToolStripMenuItem_CollaseAll = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            statusBar = new StatusStrip();
            statusBarPanelMessage = new ToolStripStatusLabel();
            statusBarPanelHelp = new ToolStripStatusLabel();
            statusBarPanelMousePosition = new ToolStripStatusLabel();
            mouseKeyEventProvider1 = new MyStuff11net.MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider();
            splitContainer_Vertical = new SplitContainer();
            splitContainer_Horizontal = new SplitContainer();
            dataGridViewExtended_Setting = new MyStuff11net.DataGridViewExtend.DataGridViewExtended();
            _contextMenuStrip.SuspendLayout();
            statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Vertical).BeginInit();
            splitContainer_Vertical.Panel1.SuspendLayout();
            splitContainer_Vertical.Panel2.SuspendLayout();
            splitContainer_Vertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Horizontal).BeginInit();
            splitContainer_Horizontal.SuspendLayout();
            SuspendLayout();
            // 
            // _contextMenuStrip
            // 
            _contextMenuStrip.BackColor = Color.LightGoldenrodYellow;
            _contextMenuStrip.ImageScalingSize = new Size(20, 20);
            _contextMenuStrip.ImeMode = ImeMode.On;
            _contextMenuStrip.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_ExpandAll, ToolStripMenuItem_CollaseAll, toolStripSeparator1 });
            _contextMenuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            _contextMenuStrip.Name = "PreviewDataGridViewContextMenuStrip";
            _contextMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            _contextMenuStrip.ShowImageMargin = false;
            _contextMenuStrip.Size = new Size(224, 62);
            // 
            // ToolStripMenuItem_ExpandAll
            // 
            ToolStripMenuItem_ExpandAll.Name = "ToolStripMenuItem_ExpandAll";
            ToolStripMenuItem_ExpandAll.Size = new Size(223, 26);
            ToolStripMenuItem_ExpandAll.Text = "Expand DataGridExpert";
            ToolStripMenuItem_ExpandAll.Click += Tool_strip_menu_item_expand_all_click;
            // 
            // ToolStripMenuItem_CollaseAll
            // 
            ToolStripMenuItem_CollaseAll.Name = "ToolStripMenuItem_CollaseAll";
            ToolStripMenuItem_CollaseAll.Size = new Size(223, 26);
            ToolStripMenuItem_CollaseAll.Text = "Collapse DataGridExpert";
            ToolStripMenuItem_CollaseAll.Click += Tool_strip_menu_item_collase_all_click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(220, 6);
            // 
            // statusBar
            // 
            statusBar.Items.AddRange(new ToolStripItem[] { statusBarPanelMessage, statusBarPanelHelp, statusBarPanelMousePosition });
            statusBar.Location = new Point(0, 719);
            statusBar.Margin = new Padding(4, 5, 4, 5);
            statusBar.Name = "statusBar";
            statusBar.Padding = new Padding(1, 0, 16, 0);
            statusBar.ShowItemToolTips = true;
            statusBar.Size = new Size(1758, 26);
            statusBar.SizingGrip = false;
            statusBar.TabIndex = 0;
            statusBar.Text = "statusBar_FlexibleTreeViewSetting";
            // 
            // statusBarPanelMessage
            // 
            statusBarPanelMessage.Name = "statusBarPanelMessage";
            statusBarPanelMessage.Size = new Size(812, 21);
            statusBarPanelMessage.Spring = true;
            statusBarPanelMessage.Text = "statusBarPanel StatusString";
            // 
            // statusBarPanelHelp
            // 
            statusBarPanelHelp.Name = "statusBarPanelHelp";
            statusBarPanelHelp.Size = new Size(812, 21);
            statusBarPanelHelp.Spring = true;
            statusBarPanelHelp.Text = "statusBarPanel Help";
            // 
            // statusBarPanelMousePosition
            // 
            statusBarPanelMousePosition.Name = "statusBarPanelMousePosition";
            statusBarPanelMousePosition.Size = new Size(116, 21);
            statusBarPanelMousePosition.Text = "Mouse Position";
            // 
            // mouseKeyEventProvider1
            // 
            mouseKeyEventProvider1.MouseMove += mouseKeyEventProvider1_MouseMove;
            // 
            // splitContainer_Vertical
            // 
            splitContainer_Vertical.AllowDrop = true;
            splitContainer_Vertical.BorderStyle = BorderStyle.Fixed3D;
            splitContainer_Vertical.Dock = DockStyle.Fill;
            splitContainer_Vertical.Location = new Point(0, 0);
            splitContainer_Vertical.Margin = new Padding(4, 5, 4, 5);
            splitContainer_Vertical.Name = "splitContainer_Vertical";
            splitContainer_Vertical.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_Vertical.Panel1
            // 
            splitContainer_Vertical.Panel1.Controls.Add(splitContainer_Horizontal);
            splitContainer_Vertical.Panel1MinSize = 300;
            // 
            // splitContainer_Vertical.Panel2
            // 
            splitContainer_Vertical.Panel2.AllowDrop = true;
            splitContainer_Vertical.Panel2.Controls.Add(dataGridViewExtended_Setting);
            splitContainer_Vertical.Panel2MinSize = 1;
            splitContainer_Vertical.Size = new Size(1758, 719);
            splitContainer_Vertical.SplitterDistance = 449;
            splitContainer_Vertical.SplitterWidth = 7;
            splitContainer_Vertical.TabIndex = 1;
            splitContainer_Vertical.SplitterMoved += Split_container_vertical_splitter_moved;
            // 
            // splitContainer_Horizontal
            // 
            splitContainer_Horizontal.AllowDrop = true;
            splitContainer_Horizontal.BorderStyle = BorderStyle.Fixed3D;
            splitContainer_Horizontal.Dock = DockStyle.Fill;
            splitContainer_Horizontal.Location = new Point(0, 0);
            splitContainer_Horizontal.Margin = new Padding(4, 5, 4, 5);
            splitContainer_Horizontal.Name = "splitContainer_Horizontal";
            // 
            // splitContainer_Horizontal.Panel1
            // 
            splitContainer_Horizontal.Panel1.AllowDrop = true;
            splitContainer_Horizontal.Size = new Size(1758, 449);
            splitContainer_Horizontal.SplitterDistance = 648;
            splitContainer_Horizontal.SplitterWidth = 6;
            splitContainer_Horizontal.TabIndex = 0;
            splitContainer_Horizontal.SplitterMoved += Split_container_horizontal_splitter_moved;
            // 
            // dataGridViewExtended_Setting
            // 
            dataGridViewExtended_Setting.BindingCompleted = false;
            dataGridViewExtended_Setting.CurrentRowBackgroundColor = Color.Blue;
            dataGridViewExtended_Setting.CurrentRowBorderColor = Color.DarkBlue;
            dataGridViewExtended_Setting.CustomEdit = MyCode.EditMode.View;
            dataGridViewExtended_Setting.DataMember = "Table_TreeView";
            dataGridViewExtended_Setting.DividerColor = Color.Red;
            dataGridViewExtended_Setting.DividerHeight = 0;
            dataGridViewExtended_Setting.Dock = DockStyle.Fill;
            dataGridViewExtended_Setting.FirstDisplayedRow = null;
            dataGridViewExtended_Setting.Location = new Point(0, 0);
            dataGridViewExtended_Setting.Margin = new Padding(6, 7, 6, 7);
            dataGridViewExtended_Setting.Name = "dataGridViewExtended_Setting";
            dataGridViewExtended_Setting.NeedSaveData = false;
            dataGridViewExtended_Setting.SelectionBorderWidth = 3;
            dataGridViewExtended_Setting.SelectionColor = Color.Blue;
            dataGridViewExtended_Setting.SetValueAt = null;
            dataGridViewExtended_Setting.Size = new Size(1754, 259);
            dataGridViewExtended_Setting.TabIndex = 0;
            // 
            // FlexibleTreeViewSetting
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1758, 745);
            Controls.Add(splitContainer_Vertical);
            Controls.Add(statusBar);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FlexibleTreeViewSetting";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FlexibleTreeViewSetting";
            WindowState = FormWindowState.Maximized;
            FormClosing += FlexibleTreeViewSetting_FormClosing;
            Load += Flexible_tree_view_setting_load;
            Shown += FlexibleTreeViewSetting_Shown;
            _contextMenuStrip.ResumeLayout(false);
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            splitContainer_Vertical.Panel1.ResumeLayout(false);
            splitContainer_Vertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Vertical).EndInit();
            splitContainer_Vertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Horizontal).EndInit();
            splitContainer_Horizontal.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_Horizontal;
        private System.Windows.Forms.SplitContainer splitContainer_Vertical;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ExpandAll;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CollaseAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private MyStuff11net.DataGridViewExtend.DataGridViewExtended dataGridViewExtended_Setting;  
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusBarPanelMousePosition;        
        private System.Windows.Forms.ToolStripStatusLabel statusBarPanelMessage;
        private System.Windows.Forms.ToolStripStatusLabel statusBarPanelHelp;
        private MouseKeyEventProvider mouseKeyEventProvider1;       
    }
}
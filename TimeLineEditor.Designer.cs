using MyStuff11net;
using MyStuff11net.FlexibleTreeView;

namespace StockRoom11net
{
    partial class TimeLineEditor
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
            splitContainer_Vertical = new SplitContainer();
            dataTreeViewToAdd_Cancel_Delete = new DataTreeViewToAdd_Cancel_Delete();
            customTabControl_TimeLine = new CustomTabControl();
            tabPage_TimeLine = new TabPage();
            blazorWebView_TimeLine = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
            tabPage_DataTreeViewSetting = new TabPage();
            tabPage1 = new TabPage();
            splitContainer_Horizontal = new SplitContainer();
            dataGridViewExtended_TimeLineEditor = new MyStuff11net.DataGridViewExtend.DataGridViewExtended();
            ((System.ComponentModel.ISupportInitialize)BindingSourceTreeViewBase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Vertical).BeginInit();
            splitContainer_Vertical.Panel1.SuspendLayout();
            splitContainer_Vertical.Panel2.SuspendLayout();
            splitContainer_Vertical.SuspendLayout();
            customTabControl_TimeLine.SuspendLayout();
            tabPage_TimeLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Horizontal).BeginInit();
            splitContainer_Horizontal.Panel1.SuspendLayout();
            splitContainer_Horizontal.Panel2.SuspendLayout();
            splitContainer_Horizontal.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer_Vertical
            // 
            splitContainer_Vertical.BorderStyle = BorderStyle.Fixed3D;
            splitContainer_Vertical.Dock = DockStyle.Fill;
            splitContainer_Vertical.Location = new Point(0, 0);
            splitContainer_Vertical.Name = "splitContainer_Vertical";
            // 
            // splitContainer_Vertical.Panel1
            // 
            splitContainer_Vertical.Panel1.Controls.Add(dataTreeViewToAdd_Cancel_Delete);
            // 
            // splitContainer_Vertical.Panel2
            // 
            splitContainer_Vertical.Panel2.Controls.Add(customTabControl_TimeLine);
            splitContainer_Vertical.Size = new Size(1567, 511);
            splitContainer_Vertical.SplitterDistance = 482;
            splitContainer_Vertical.TabIndex = 1;
            // 
            // dataTreeViewToAdd_Cancel_Delete
            // 
            dataTreeViewToAdd_Cancel_Delete.Dock = DockStyle.Fill;
            dataTreeViewToAdd_Cancel_Delete.Location = new Point(0, 0);
            dataTreeViewToAdd_Cancel_Delete.Name = "dataTreeViewToAdd_Cancel_Delete";
            dataTreeViewToAdd_Cancel_Delete.Size = new Size(478, 507);
            dataTreeViewToAdd_Cancel_Delete.TabIndex = 0;
            dataTreeViewToAdd_Cancel_Delete.Save_Requested += DataTreeViewToAdd_Cancel_Delete_Save_Requested;
            dataTreeViewToAdd_Cancel_Delete.SelectedIndexChanged += DataTreeViewToAdd_Cancel_Delete_SelectedIndexChanged;
            dataTreeViewToAdd_Cancel_Delete.ToolStripMenuItemClick += DataTreeViewToAdd_Cancel_Delete_ToolStripMenuItemClick;
            dataTreeViewToAdd_Cancel_Delete.Load += DataTreeViewToAdd_Cancel_Delete_Load;
            // 
            // customTabControl_TimeLine
            // 
            customTabControl_TimeLine.Controls.Add(tabPage_TimeLine);
            customTabControl_TimeLine.Controls.Add(tabPage_DataTreeViewSetting);
            customTabControl_TimeLine.Controls.Add(tabPage1);
            customTabControl_TimeLine.DisplayStyle = TabStyle.VisualStudio;
            // 
            // 
            // 
            customTabControl_TimeLine.DisplayStyleProvider.BorderColor = Color.DarkGray;
            customTabControl_TimeLine.DisplayStyleProvider.BorderColorHot = Color.DarkGray;
            customTabControl_TimeLine.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(127, 157, 185);
            customTabControl_TimeLine.DisplayStyleProvider.CloserColor = Color.DarkGray;
            customTabControl_TimeLine.DisplayStyleProvider.TextColor = Color.Black;
            customTabControl_TimeLine.DisplayStyleProvider.TextColorDisabled = Color.DarkGray;
            customTabControl_TimeLine.DisplayStyleProvider.TextColorSelected = Color.Black;
            customTabControl_TimeLine.Dock = DockStyle.Fill;
            customTabControl_TimeLine.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            customTabControl_TimeLine.Location = new Point(0, 0);
            customTabControl_TimeLine.Margin = new Padding(2);
            customTabControl_TimeLine.Name = "customTabControl_TimeLine";
            customTabControl_TimeLine.SelectedIndex = 0;
            customTabControl_TimeLine.Size = new Size(1077, 507);
            customTabControl_TimeLine.TabIndex = 1;
            customTabControl_TimeLine.SelectedIndexChanged += CustomTabControl_TimeLine_SelectedIndexChanged;
            // 
            // tabPage_TimeLine
            // 
            tabPage_TimeLine.BackColor = SystemColors.Window;
            tabPage_TimeLine.Controls.Add(blazorWebView_TimeLine);
            tabPage_TimeLine.Location = new Point(4, 4);
            tabPage_TimeLine.Margin = new Padding(0);
            tabPage_TimeLine.Name = "tabPage_TimeLine";
            tabPage_TimeLine.Size = new Size(1069, 479);
            tabPage_TimeLine.TabIndex = 0;
            tabPage_TimeLine.Text = "TimeLine";
            // 
            // blazorWebView_TimeLine
            // 
            blazorWebView_TimeLine.Dock = DockStyle.Fill;
            blazorWebView_TimeLine.Location = new Point(0, 0);
            blazorWebView_TimeLine.Margin = new Padding(1);
            blazorWebView_TimeLine.Name = "blazorWebView_TimeLine";
            blazorWebView_TimeLine.Size = new Size(1069, 479);
            blazorWebView_TimeLine.TabIndex = 21;
            // 
            // tabPage_DataTreeViewSetting
            // 
            tabPage_DataTreeViewSetting.Location = new Point(4, 4);
            tabPage_DataTreeViewSetting.Margin = new Padding(2);
            tabPage_DataTreeViewSetting.Name = "tabPage_DataTreeViewSetting";
            tabPage_DataTreeViewSetting.Padding = new Padding(2);
            tabPage_DataTreeViewSetting.Size = new Size(192, 72);
            tabPage_DataTreeViewSetting.TabIndex = 1;
            tabPage_DataTreeViewSetting.Text = "DataTreeView";
            tabPage_DataTreeViewSetting.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(192, 72);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer_Horizontal
            // 
            splitContainer_Horizontal.BorderStyle = BorderStyle.Fixed3D;
            splitContainer_Horizontal.Dock = DockStyle.Fill;
            splitContainer_Horizontal.Location = new Point(0, 0);
            splitContainer_Horizontal.Name = "splitContainer_Horizontal";
            splitContainer_Horizontal.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_Horizontal.Panel1
            // 
            splitContainer_Horizontal.Panel1.Controls.Add(splitContainer_Vertical);
            // 
            // splitContainer_Horizontal.Panel2
            // 
            splitContainer_Horizontal.Panel2.Controls.Add(dataGridViewExtended_TimeLineEditor);
            splitContainer_Horizontal.Size = new Size(1567, 799);
            splitContainer_Horizontal.SplitterDistance = 511;
            splitContainer_Horizontal.TabIndex = 2;
            // 
            // dataGridViewExtended_TimeLineEditor
            // 
            dataGridViewExtended_TimeLineEditor.BindingCompleted = false;
            dataGridViewExtended_TimeLineEditor.CurrentRowBackgroundColor = Color.Blue;
            dataGridViewExtended_TimeLineEditor.CurrentRowBorderColor = Color.DarkBlue;
            dataGridViewExtended_TimeLineEditor.CustomEdit = MyCode.EditMode.View;
            dataGridViewExtended_TimeLineEditor.DividerColor = Color.Red;
            dataGridViewExtended_TimeLineEditor.DividerHeight = 0;
            dataGridViewExtended_TimeLineEditor.Dock = DockStyle.Fill;
            dataGridViewExtended_TimeLineEditor.FirstDisplayedRow = null;
            dataGridViewExtended_TimeLineEditor.Location = new Point(0, 0);
            dataGridViewExtended_TimeLineEditor.Margin = new Padding(4, 5, 4, 5);
            dataGridViewExtended_TimeLineEditor.Name = "dataGridViewExtended_TimeLineEditor";
            dataGridViewExtended_TimeLineEditor.NeedSaveData = false;
            dataGridViewExtended_TimeLineEditor.SelectionBorderWidth = 3;
            dataGridViewExtended_TimeLineEditor.SelectionColor = Color.Blue;
            dataGridViewExtended_TimeLineEditor.SetValueAt = null;
            dataGridViewExtended_TimeLineEditor.Size = new Size(1563, 280);
            dataGridViewExtended_TimeLineEditor.TabIndex = 0;
            // 
            // TimeLineEditor
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1567, 799);
            Controls.Add(splitContainer_Horizontal);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "TimeLineEditor";
            Text = "TimeLineEditor.";
            Load += TimeLineEditor_Load;
            Shown += TimeLineEditor_Shown;
            ((System.ComponentModel.ISupportInitialize)BindingSourceTreeViewBase).EndInit();
            splitContainer_Vertical.Panel1.ResumeLayout(false);
            splitContainer_Vertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Vertical).EndInit();
            splitContainer_Vertical.ResumeLayout(false);
            customTabControl_TimeLine.ResumeLayout(false);
            tabPage_TimeLine.ResumeLayout(false);
            splitContainer_Horizontal.Panel1.ResumeLayout(false);
            splitContainer_Horizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Horizontal).EndInit();
            splitContainer_Horizontal.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer_Vertical;
        private MyStuff11net.DataGridViewExtend.DataGridViewExtended dataGridViewExtended_TimeLineEditor;
        private System.Windows.Forms.SplitContainer splitContainer_Horizontal;
        private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView blazorWebView_TimeLine;
        private CustomTabControl customTabControl_TimeLine;
        private TabPage tabPage_TimeLine;
        private TabPage tabPage_DataTreeViewSetting;
        private TabPage tabPage1;
        private DataTreeViewToAdd_Cancel_Delete dataTreeViewToAdd_Cancel_Delete;
    }
}
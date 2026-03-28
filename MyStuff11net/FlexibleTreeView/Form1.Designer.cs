namespace MyStuff11net.FlexibleTreeView
{
    partial class Form1
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
            dataTreeViewToAdd_Cancel_Delete = new DataTreeViewToAdd_Cancel_Delete();
            splitContainerVertical = new SplitContainer();
            customTabControl1 = new CustomTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)splitContainerVertical).BeginInit();
            splitContainerVertical.Panel1.SuspendLayout();
            splitContainerVertical.Panel2.SuspendLayout();
            splitContainerVertical.SuspendLayout();
            customTabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // dataTreeViewToAdd_Cancel_Delete
            // 
            dataTreeViewToAdd_Cancel_Delete.Dock = DockStyle.Fill;
            dataTreeViewToAdd_Cancel_Delete.Location = new Point(0, 0);
            dataTreeViewToAdd_Cancel_Delete.Name = "dataTreeViewToAdd_Cancel_Delete";
            dataTreeViewToAdd_Cancel_Delete.Size = new Size(582, 661);
            dataTreeViewToAdd_Cancel_Delete.TabIndex = 0;
            // 
            // splitContainerVertical
            // 
            splitContainerVertical.BorderStyle = BorderStyle.Fixed3D;
            splitContainerVertical.Dock = DockStyle.Fill;
            splitContainerVertical.Location = new Point(0, 0);
            splitContainerVertical.Name = "splitContainerVertical";
            // 
            // splitContainerVertical.Panel1
            // 
            splitContainerVertical.Panel1.Controls.Add(dataTreeViewToAdd_Cancel_Delete);
            // 
            // splitContainerVertical.Panel2
            // 
            splitContainerVertical.Panel2.Controls.Add(customTabControl1);
            splitContainerVertical.Size = new Size(1314, 665);
            splitContainerVertical.SplitterDistance = 586;
            splitContainerVertical.TabIndex = 1;
            // 
            // customTabControl1
            // 
            customTabControl1.Controls.Add(tabPage1);
            customTabControl1.Controls.Add(tabPage2);
            customTabControl1.DisplayStyle = TabStyle.VisualStudio;
            // 
            // 
            // 
            customTabControl1.DisplayStyleProvider.BorderColor = Color.DarkGray;
            customTabControl1.DisplayStyleProvider.BorderColorHot = Color.DarkGray;
            customTabControl1.DisplayStyleProvider.BorderColorSelected = Color.FromArgb(127, 157, 185);
            customTabControl1.DisplayStyleProvider.CloserColor = Color.DarkGray;
            customTabControl1.DisplayStyleProvider.TextColor = Color.Black;
            customTabControl1.DisplayStyleProvider.TextColorDisabled = Color.DarkGray;
            customTabControl1.DisplayStyleProvider.TextColorSelected = Color.Black;
            customTabControl1.Dock = DockStyle.Fill;
            customTabControl1.Location = new Point(0, 0);
            customTabControl1.Name = "customTabControl1";
            customTabControl1.SelectedIndex = 0;
            customTabControl1.Size = new Size(720, 661);
            customTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(712, 628);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "   tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(712, 628);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "   tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1314, 665);
            Controls.Add(splitContainerVertical);
            Name = "Form1";
            Text = "Form1";
            splitContainerVertical.Panel1.ResumeLayout(false);
            splitContainerVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerVertical).EndInit();
            splitContainerVertical.ResumeLayout(false);
            customTabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataTreeViewToAdd_Cancel_Delete dataTreeViewToAdd_Cancel_Delete;
        private SplitContainer splitContainerVertical;
        private CustomTabControl customTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
namespace StockRoom11net
{
    partial class H7H_Explorer
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStripHxH = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxFindNext = new System.Windows.Forms.ToolStripTextBox();
            this.goToPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxGotoHex = new System.Windows.Forms.ToolStripTextBox();
            this.gotoPositionDecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxGoToDec = new System.Windows.Forms.ToolStripTextBox();
            this.openAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripPicturesBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_SetToNoPicturesFound = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddANewPictures = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.hexBox = new Be.Windows.Forms.HexBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStripHxH.SuspendLayout();
            this.contextMenuStripPicturesBox.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(1023, 744);
            this.splitContainer1.SplitterDistance = 552;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // contextMenuStripHxH
            // 
            this.contextMenuStripHxH.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.contextMenuStripHxH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findNextToolStripMenuItem,
            this.goToPositionToolStripMenuItem,
            this.gotoPositionDecToolStripMenuItem,
            this.openAFileToolStripMenuItem});
            this.contextMenuStripHxH.Name = "contextMenuStripHxH";
            this.contextMenuStripHxH.Size = new System.Drawing.Size(172, 92);
            this.contextMenuStripHxH.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripHxH_Opening);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxFindNext});
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.findNextToolStripMenuItem.Text = "Find next";
            // 
            // toolStripTextBoxFindNext
            // 
            this.toolStripTextBoxFindNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxFindNext.Name = "toolStripTextBoxFindNext";
            this.toolStripTextBoxFindNext.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxFindNext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxFindNext_KeyUp);
            // 
            // goToPositionToolStripMenuItem
            // 
            this.goToPositionToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.goToPositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxGotoHex});
            this.goToPositionToolStripMenuItem.Name = "goToPositionToolStripMenuItem";
            this.goToPositionToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.goToPositionToolStripMenuItem.Text = "GoTo position Hex";
            // 
            // toolStripTextBoxGotoHex
            // 
            this.toolStripTextBoxGotoHex.AcceptsReturn = true;
            this.toolStripTextBoxGotoHex.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxGotoHex.MaxLength = 10;
            this.toolStripTextBoxGotoHex.Name = "toolStripTextBoxGotoHex";
            this.toolStripTextBoxGotoHex.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxGotoHex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxGoto_KeyUp);
            // 
            // gotoPositionDecToolStripMenuItem
            // 
            this.gotoPositionDecToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxGoToDec});
            this.gotoPositionDecToolStripMenuItem.Name = "gotoPositionDecToolStripMenuItem";
            this.gotoPositionDecToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gotoPositionDecToolStripMenuItem.Text = "Goto position Dec";
            // 
            // toolStripTextBoxGoToDec
            // 
            this.toolStripTextBoxGoToDec.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxGoToDec.MaxLength = 25;
            this.toolStripTextBoxGoToDec.Name = "toolStripTextBoxGoToDec";
            this.toolStripTextBoxGoToDec.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxGoToDec.KeyUp += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBoxDec_KeyUp);
            // 
            // openAFileToolStripMenuItem
            // 
            this.openAFileToolStripMenuItem.Name = "openAFileToolStripMenuItem";
            this.openAFileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.openAFileToolStripMenuItem.Text = "Open a file";
            this.openAFileToolStripMenuItem.Click += new System.EventHandler(this.openAFileToolStripMenuItem_Click);
            // 
            // contextMenuStripPicturesBox
            // 
            this.contextMenuStripPicturesBox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.contextMenuStripPicturesBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.contextMenuStripPicturesBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_SetToNoPicturesFound,
            this.toolStripMenuItem_AddANewPictures});
            this.contextMenuStripPicturesBox.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.contextMenuStripPicturesBox.Name = "PreviewDataGridViewContextMenuStrip";
            this.contextMenuStripPicturesBox.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStripPicturesBox.ShowImageMargin = false;
            this.contextMenuStripPicturesBox.Size = new System.Drawing.Size(184, 48);
            // 
            // toolStripMenuItem_SetToNoPicturesFound
            // 
            this.toolStripMenuItem_SetToNoPicturesFound.Name = "toolStripMenuItem_SetToNoPicturesFound";
            this.toolStripMenuItem_SetToNoPicturesFound.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem_SetToNoPicturesFound.Text = "Set to not Pictures found.";
            // 
            // toolStripMenuItem_AddANewPictures
            // 
            this.toolStripMenuItem_AddANewPictures.Name = "toolStripMenuItem_AddANewPictures";
            this.toolStripMenuItem_AddANewPictures.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem_AddANewPictures.Text = "Add a new Pictures.";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.hexBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(540, 715);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // hexBox
            // 
            this.hexBox.ContextMenuStrip = this.contextMenuStripHxH;
            this.hexBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hexBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         //   this.hexBox.LineInfoForeColor = System.Drawing.Color.Green;
            this.hexBox.LineInfoVisible = true;
            this.hexBox.Location = new System.Drawing.Point(2, 2);
            this.hexBox.Margin = new System.Windows.Forms.Padding(2);
            this.hexBox.Name = "hexBox";
            this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox.Size = new System.Drawing.Size(536, 711);
            this.hexBox.StringViewVisible = true;
            this.hexBox.TabIndex = 0;
            this.hexBox.UseFixedBytesPerLine = true;
            this.hexBox.VScrollBarVisible = true;
            this.hexBox.HorizontalByteCountChanged += new System.EventHandler(this.hexBox_HorizontalByteCountChanged);
            this.hexBox.CurrentLineChanged += new System.EventHandler(this.hexBox_CurrentLineChanged);
            this.hexBox.CurrentPositionInLineChanged += new System.EventHandler(this.hexBox_CurrentPositionInLineChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(540, 715);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(456, 715);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(452, 711);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(456, 715);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // H7H_Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 744);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "H7H_Explorer";
            this.Text = "HxH_Explorer";
            this.Load += new System.EventHandler(this.H7H_Explorer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStripHxH.ResumeLayout(false);
            this.contextMenuStripPicturesBox.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripHxH;
        private System.Windows.Forms.ToolStripMenuItem openAFileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPicturesBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SetToNoPicturesFound;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddANewPictures;
        private Be.Windows.Forms.HexBox hexBox;
        private System.Windows.Forms.ToolStripMenuItem goToPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxGotoHex;
        private System.Windows.Forms.ToolStripMenuItem gotoPositionDecToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxGoToDec;
        private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFindNext;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}
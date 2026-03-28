namespace MyStuff11net
{
    partial class ThumbViewer
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
            components = new System.ComponentModel.Container();
            splitContainer_ThumbViewer = new System.Windows.Forms.SplitContainer();
            pictureBox_Image = new System.Windows.Forms.PictureBox();
            contextMenuStripPictureBox = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItem_RemoveThisPicture = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem_AddANewPicture = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemCopyToANewFile = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemCopyFileToTheClickBoard = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemCopyImageToTheClipBoard = new System.Windows.Forms.ToolStripMenuItem();
            flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(splitContainer_ThumbViewer)).BeginInit();
            splitContainer_ThumbViewer.Panel1.SuspendLayout();
            splitContainer_ThumbViewer.Panel2.SuspendLayout();
            splitContainer_ThumbViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox_Image)).BeginInit();
            contextMenuStripPictureBox.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer_ThumbViewer
            // 
            splitContainer_ThumbViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            splitContainer_ThumbViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer_ThumbViewer.Location = new System.Drawing.Point(0, 0);
            splitContainer_ThumbViewer.Margin = new System.Windows.Forms.Padding(2);
            splitContainer_ThumbViewer.Name = "splitContainer_ThumbViewer";
            splitContainer_ThumbViewer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_ThumbViewer.Panel1
            // 
            splitContainer_ThumbViewer.Panel1.Controls.Add(pictureBox_Image);
            splitContainer_ThumbViewer.Panel1MinSize = 30;
            // 
            // splitContainer_ThumbViewer.Panel2
            // 
            splitContainer_ThumbViewer.Panel2.Controls.Add(flowLayoutPanel);
            splitContainer_ThumbViewer.Panel2MinSize = 30;
            splitContainer_ThumbViewer.Size = new System.Drawing.Size(512, 382);
            splitContainer_ThumbViewer.SplitterDistance = 302;
            splitContainer_ThumbViewer.SplitterWidth = 3;
            splitContainer_ThumbViewer.TabIndex = 2;
            splitContainer_ThumbViewer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(SplitContainer_ThumbViewer_SplitterMoved);
            // 
            // pictureBox_Image
            // 
            pictureBox_Image.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            pictureBox_Image.ContextMenuStrip = contextMenuStripPictureBox;
            pictureBox_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox_Image.Location = new System.Drawing.Point(0, 0);
            pictureBox_Image.Margin = new System.Windows.Forms.Padding(2);
            pictureBox_Image.Name = "pictureBox_Image";
            pictureBox_Image.Size = new System.Drawing.Size(508, 298);
            pictureBox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox_Image.TabIndex = 2;
            pictureBox_Image.TabStop = false;
            // 
            // contextMenuStripPictureBox
            // 
            contextMenuStripPictureBox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            contextMenuStripPictureBox.ImeMode = System.Windows.Forms.ImeMode.On;
            contextMenuStripPictureBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItem_RemoveThisPicture,
            toolStripMenuItem_AddANewPicture,
            toolStripMenuItemCopyToANewFile,
            toolStripMenuItemCopyFileToTheClickBoard,
            toolStripMenuItemCopyImageToTheClipBoard});
            contextMenuStripPictureBox.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            contextMenuStripPictureBox.Name = "PreviewDataGridViewContextMenuStrip";
            contextMenuStripPictureBox.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            contextMenuStripPictureBox.ShowImageMargin = false;
            contextMenuStripPictureBox.Size = new System.Drawing.Size(206, 114);
            // 
            // toolStripMenuItem_RemoveThisPicture
            // 
            toolStripMenuItem_RemoveThisPicture.Name = "toolStripMenuItem_RemoveThisPicture";
            toolStripMenuItem_RemoveThisPicture.Size = new System.Drawing.Size(205, 22);
            toolStripMenuItem_RemoveThisPicture.Text = "Remove this picture.";
            // 
            // toolStripMenuItem_AddANewPicture
            // 
            toolStripMenuItem_AddANewPicture.Name = "toolStripMenuItem_AddANewPicture";
            toolStripMenuItem_AddANewPicture.Size = new System.Drawing.Size(205, 22);
            toolStripMenuItem_AddANewPicture.Text = "Add a new picture.";
            // 
            // toolStripMenuItemCopyToANewFile
            // 
            toolStripMenuItemCopyToANewFile.Name = "toolStripMenuItemCopyToANewFile";
            toolStripMenuItemCopyToANewFile.Size = new System.Drawing.Size(205, 22);
            toolStripMenuItemCopyToANewFile.Text = "Copy to a new file.";
            // 
            // toolStripMenuItemCopyFileToTheClickBoard
            // 
            toolStripMenuItemCopyFileToTheClickBoard.Name = "toolStripMenuItemCopyFileToTheClickBoard";
            toolStripMenuItemCopyFileToTheClickBoard.Size = new System.Drawing.Size(205, 22);
            toolStripMenuItemCopyFileToTheClickBoard.Text = "Copy file to the ClipBoard.";
            // 
            // toolStripMenuItemCopyImageToTheClipBoard
            // 
            toolStripMenuItemCopyImageToTheClipBoard.Name = "toolStripMenuItemCopyImageToTheClipBoard";
            toolStripMenuItemCopyImageToTheClipBoard.Size = new System.Drawing.Size(205, 22);
            toolStripMenuItemCopyImageToTheClipBoard.Text = "Copy image to the ClipBoard.";
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new System.Drawing.Size(508, 73);
            flowLayoutPanel.TabIndex = 0;
            // 
            // ThumbViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(splitContainer_ThumbViewer);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "ThumbViewer";
            Size = new System.Drawing.Size(512, 382);
            splitContainer_ThumbViewer.Panel1.ResumeLayout(false);
            splitContainer_ThumbViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer_ThumbViewer)).EndInit();
            splitContainer_ThumbViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pictureBox_Image)).EndInit();
            contextMenuStripPictureBox.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion      

        private System.Windows.Forms.SplitContainer splitContainer_ThumbViewer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPictureBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RemoveThisPicture;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddANewPicture;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyToANewFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyFileToTheClickBoard;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyImageToTheClipBoard;


    }
}

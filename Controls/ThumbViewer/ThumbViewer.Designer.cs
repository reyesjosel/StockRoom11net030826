namespace StockRoom11net.Controls.ThumbViewer
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
            splitContainer_ThumbViewer = new SplitContainer();
            pictureBox_Image = new PictureBox();
            contextMenuStripPictureBox = new ContextMenuStrip(components);
            toolStripMenuItem_AddANewPicture = new ToolStripMenuItem();
            toolStripMenuItemCopyToANewFile = new ToolStripMenuItem();
            toolStripMenuItemCopyFileToTheClickBoard = new ToolStripMenuItem();
            toolStripMenuItemCopyImageToTheClipBoard = new ToolStripMenuItem();
            toolStripMenuItemPasteImageFromClipBoard = new ToolStripMenuItem();
            toolStripMenuItem_RemoveThisPicture = new ToolStripMenuItem();
            flowLayoutPanel_ThumbNails = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer_ThumbViewer).BeginInit();
            splitContainer_ThumbViewer.Panel1.SuspendLayout();
            splitContainer_ThumbViewer.Panel2.SuspendLayout();
            splitContainer_ThumbViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Image).BeginInit();
            contextMenuStripPictureBox.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer_ThumbViewer
            // 
            splitContainer_ThumbViewer.BorderStyle = BorderStyle.Fixed3D;
            splitContainer_ThumbViewer.Dock = DockStyle.Fill;
            splitContainer_ThumbViewer.Location = new Point(0, 0);
            splitContainer_ThumbViewer.Name = "splitContainer_ThumbViewer";
            splitContainer_ThumbViewer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_ThumbViewer.Panel1
            // 
            splitContainer_ThumbViewer.Panel1.Controls.Add(pictureBox_Image);
            splitContainer_ThumbViewer.Panel1MinSize = 30;
            // 
            // splitContainer_ThumbViewer.Panel2
            // 
            splitContainer_ThumbViewer.Panel2.Controls.Add(flowLayoutPanel_ThumbNails);
            splitContainer_ThumbViewer.Panel2MinSize = 30;
            splitContainer_ThumbViewer.Size = new Size(768, 588);
            splitContainer_ThumbViewer.SplitterDistance = 464;
            splitContainer_ThumbViewer.SplitterWidth = 5;
            splitContainer_ThumbViewer.TabIndex = 2;
            // 
            // pictureBox_Image
            // 
            pictureBox_Image.BackColor = Color.LightGoldenrodYellow;
            pictureBox_Image.ContextMenuStrip = contextMenuStripPictureBox;
            pictureBox_Image.Dock = DockStyle.Fill;
            pictureBox_Image.Location = new Point(0, 0);
            pictureBox_Image.Name = "pictureBox_Image";
            pictureBox_Image.Size = new Size(764, 460);
            pictureBox_Image.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Image.TabIndex = 2;
            pictureBox_Image.TabStop = false;
            // 
            // contextMenuStripPictureBox
            // 
            contextMenuStripPictureBox.BackColor = Color.LightGoldenrodYellow;
            contextMenuStripPictureBox.ImeMode = ImeMode.On;
            contextMenuStripPictureBox.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_AddANewPicture, toolStripMenuItemCopyToANewFile, toolStripMenuItemCopyFileToTheClickBoard, toolStripMenuItemCopyImageToTheClipBoard, toolStripMenuItemPasteImageFromClipBoard, toolStripMenuItem_RemoveThisPicture });
            contextMenuStripPictureBox.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            contextMenuStripPictureBox.Name = "PreviewDataGridViewContextMenuStrip";
            contextMenuStripPictureBox.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStripPictureBox.ShowImageMargin = false;
            contextMenuStripPictureBox.Size = new Size(258, 160);
            // 
            // toolStripMenuItem_AddANewPicture
            // 
            toolStripMenuItem_AddANewPicture.Name = "toolStripMenuItem_AddANewPicture";
            toolStripMenuItem_AddANewPicture.Size = new Size(257, 26);
            toolStripMenuItem_AddANewPicture.Text = "Add a new picture.";
            // 
            // toolStripMenuItemCopyToANewFile
            // 
            toolStripMenuItemCopyToANewFile.Name = "toolStripMenuItemCopyToANewFile";
            toolStripMenuItemCopyToANewFile.Size = new Size(257, 26);
            toolStripMenuItemCopyToANewFile.Text = "Copy to a new file.";
            // 
            // toolStripMenuItemCopyFileToTheClickBoard
            // 
            toolStripMenuItemCopyFileToTheClickBoard.Name = "toolStripMenuItemCopyFileToTheClickBoard";
            toolStripMenuItemCopyFileToTheClickBoard.Size = new Size(257, 26);
            toolStripMenuItemCopyFileToTheClickBoard.Text = "Copy file to the ClipBoard.";
            // 
            // toolStripMenuItemCopyImageToTheClipBoard
            // 
            toolStripMenuItemCopyImageToTheClipBoard.Name = "toolStripMenuItemCopyImageToTheClipBoard";
            toolStripMenuItemCopyImageToTheClipBoard.Size = new Size(257, 26);
            toolStripMenuItemCopyImageToTheClipBoard.Text = "Copy image to the ClipBoard.";
            // 
            // toolStripMenuItemPasteImageFromClipBoard
            // 
            toolStripMenuItemPasteImageFromClipBoard.Name = "toolStripMenuItemPasteImageFromClipBoard";
            toolStripMenuItemPasteImageFromClipBoard.Size = new Size(257, 26);
            toolStripMenuItemPasteImageFromClipBoard.Text = "Paste image from ClipBoard";
            // 
            // toolStripMenuItem_RemoveThisPicture
            // 
            toolStripMenuItem_RemoveThisPicture.Name = "toolStripMenuItem_RemoveThisPicture";
            toolStripMenuItem_RemoveThisPicture.Size = new Size(257, 26);
            toolStripMenuItem_RemoveThisPicture.Text = "Remove this picture.";
            // 
            // flowLayoutPanel_ThumbNails
            // 
            flowLayoutPanel_ThumbNails.AutoScroll = true;
            flowLayoutPanel_ThumbNails.BackColor = Color.WhiteSmoke;
            flowLayoutPanel_ThumbNails.Dock = DockStyle.Fill;
            flowLayoutPanel_ThumbNails.Location = new Point(0, 0);
            flowLayoutPanel_ThumbNails.Margin = new Padding(0);
            flowLayoutPanel_ThumbNails.Name = "flowLayoutPanel_ThumbNails";
            flowLayoutPanel_ThumbNails.Size = new Size(764, 115);
            flowLayoutPanel_ThumbNails.TabIndex = 0;
            // 
            // ThumbViewer
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer_ThumbViewer);
            Name = "ThumbViewer";
            Size = new Size(768, 588);
            splitContainer_ThumbViewer.Panel1.ResumeLayout(false);
            splitContainer_ThumbViewer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_ThumbViewer).EndInit();
            splitContainer_ThumbViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Image).EndInit();
            contextMenuStripPictureBox.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion      

        private System.Windows.Forms.SplitContainer splitContainer_ThumbViewer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_ThumbNails;
        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPictureBox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_RemoveThisPicture;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddANewPicture;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyToANewFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyFileToTheClickBoard;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopyImageToTheClipBoard;
        private ToolStripMenuItem toolStripMenuItemPasteImageFromClipBoard;
    }
}

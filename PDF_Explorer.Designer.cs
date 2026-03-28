namespace StockRoom11net
{
    partial class Pdf_explorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pdf_explorer));
            this.contextMenuStripPdfViewer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_OpenContainingFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTheUserHaveNotRight = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripPdfViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripPdfViewer
            // 
            this.contextMenuStripPdfViewer.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.contextMenuStripPdfViewer.ImeMode = System.Windows.Forms.ImeMode.On;
            this.contextMenuStripPdfViewer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_OpenContainingFolder,
            this.ToolStripMenuItemTheUserHaveNotRight});
            this.contextMenuStripPdfViewer.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.contextMenuStripPdfViewer.Name = "PreviewDataGridViewContextMenuStrip";
            this.contextMenuStripPdfViewer.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStripPdfViewer.ShowImageMargin = false;
            this.contextMenuStripPdfViewer.Size = new System.Drawing.Size(300, 48);
            // 
            // toolStripMenuItem_OpenContainingFolder
            // 
            this.toolStripMenuItem_OpenContainingFolder.Name = "toolStripMenuItem_OpenContainingFolder";
            this.toolStripMenuItem_OpenContainingFolder.Size = new System.Drawing.Size(299, 22);
            this.toolStripMenuItem_OpenContainingFolder.Text = "Open containing folder.";            
            // 
            // ToolStripMenuItemTheUserHaveNotRight
            // 
            this.ToolStripMenuItemTheUserHaveNotRight.Name = "ToolStripMenuItemTheUserHaveNotRight";
            this.ToolStripMenuItemTheUserHaveNotRight.Size = new System.Drawing.Size(299, 22);
            this.ToolStripMenuItemTheUserHaveNotRight.Text = "The User has no right to perform this operation.";
            // 
            // Pdf_explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 546);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Pdf_explorer";
            this.TabPageContextMenuStrip = this.contextMenuStripPdfViewer;
            this.Text = resources.GetString("$this.Text");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pdf_explorer_form_closing);
            this.Load += new System.EventHandler(this.Pdf_explorer_Load);
            this.Shown += new System.EventHandler(this.Pdf_explorer_shown);
            this.contextMenuStripPdfViewer.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
                
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPdfViewer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_OpenContainingFolder;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTheUserHaveNotRight;
    }
}


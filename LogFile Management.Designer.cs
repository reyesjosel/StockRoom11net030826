namespace StockRoom11net
{
    partial class LogFile_Management
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
            this.tinyMceEditor = new MyStuff11net.TinyMCE();
            this.SuspendLayout();
            // 
            // tinyMceEditor
            // 
            this.tinyMceEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tinyMceEditor.HtmlContent = null;
            this.tinyMceEditor.Location = new System.Drawing.Point(0, 0);
            this.tinyMceEditor.Name = "tinyMceEditor";
            this.tinyMceEditor.Size = new System.Drawing.Size(1073, 550);
            this.tinyMceEditor.TabIndex = 0;
            // 
            // LogFile_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 550);
            this.Controls.Add(this.tinyMceEditor);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LogFile_Management";
            this.Text = "LogFile_Management";
            this.ResumeLayout(false);

        }

        #endregion

        private MyStuff11net.TinyMCE tinyMceEditor;
    }
}
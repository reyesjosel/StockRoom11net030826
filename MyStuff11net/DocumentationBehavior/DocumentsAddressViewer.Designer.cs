namespace MyStuff11net.DocumentationBehavior
{
    partial class DocumentsAddressViewer
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
            documentsAddressGroup = new MyStuff11net.DocumentsAddressGroup();
            SuspendLayout();
            // 
            // documentsAddressGroup
            // 
            documentsAddressGroup.AutoSize = true;
            documentsAddressGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            documentsAddressGroup.Dock = System.Windows.Forms.DockStyle.Top;
            documentsAddressGroup.Location = new System.Drawing.Point(0, 0);
            documentsAddressGroup.MinimumSize = new System.Drawing.Size(450, 115);
            documentsAddressGroup.Name = "documentsAddressGroup";
            documentsAddressGroup.Size = new System.Drawing.Size(547, 115);
            documentsAddressGroup.TabIndex = 0;
            // 
            // DocumentsAddressViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            ClientSize = new System.Drawing.Size(547, 121);
            Controls.Add(documentsAddressGroup);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(563, 160);
            Name = "DocumentsAddressViewer";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "DocumentsAddressViewer";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DocumentsAddressGroup documentsAddressGroup;
    }
}
namespace MyStuff11net.HTML_Editor.Fabric
{
    partial class FabricViewer
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
            FabricBrowser = new System.Windows.Forms.WebBrowser();
            SuspendLayout();
            // 
            // FabricBrowser
            // 
            FabricBrowser.AllowWebBrowserDrop = false;
            FabricBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            FabricBrowser.IsWebBrowserContextMenuEnabled = false;
            FabricBrowser.Location = new System.Drawing.Point(0, 0);
            FabricBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            FabricBrowser.Name = "FabricBrowser";
            FabricBrowser.ScrollBarsEnabled = false;
            FabricBrowser.Size = new System.Drawing.Size(790, 476);
            FabricBrowser.TabIndex = 1;
            FabricBrowser.Url = new System.Uri(global::MyStuff11net.Properties.Settings.Default.DRIVERRESOURCE_NOTFOUND, System.UriKind.Relative);
            // 
            // FabricViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(FabricBrowser);
            Name = "FabricViewer";
            Size = new System.Drawing.Size(790, 476);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser FabricBrowser;
    }
}

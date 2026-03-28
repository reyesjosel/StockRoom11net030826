namespace MyStuff11net.FirstInstallationSetting
{
    partial class InstallationKey
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
            grouper_InstallationKey = new CodeVendor.Controls.Grouper();
            button_Browser = new System.Windows.Forms.Button();
            button_Cancel = new System.Windows.Forms.Button();
            button_Accept = new System.Windows.Forms.Button();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            grouper_InstallationKey.SuspendLayout();
            SuspendLayout();
            // 
            // grouper_InstallationKey
            // 
            grouper_InstallationKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            grouper_InstallationKey.BackgroundColor = System.Drawing.SystemColors.Control;
            grouper_InstallationKey.BackgroundGradientColor = System.Drawing.Color.White;
            grouper_InstallationKey.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_InstallationKey.BorderColor = System.Drawing.Color.Black;
            grouper_InstallationKey.BorderThickness = 1F;
            grouper_InstallationKey.Controls.Add(button_Browser);
            grouper_InstallationKey.Controls.Add(button_Cancel);
            grouper_InstallationKey.Controls.Add(button_Accept);
            grouper_InstallationKey.Controls.Add(richTextBox1);
            grouper_InstallationKey.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper_InstallationKey.GroupImage = null;
            grouper_InstallationKey.GroupTitle = "Enter the installation key file ...";
            grouper_InstallationKey.Location = new System.Drawing.Point(67, 75);
            grouper_InstallationKey.Margin = new System.Windows.Forms.Padding(1, 4, 1, 1);
            grouper_InstallationKey.Name = "grouper_InstallationKey";
            grouper_InstallationKey.Padding = new System.Windows.Forms.Padding(20, 32, 20, 20);
            grouper_InstallationKey.PaintGroupBox = false;
            grouper_InstallationKey.RoundCorners = 10;
            grouper_InstallationKey.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_InstallationKey.ShadowControl = false;
            grouper_InstallationKey.ShadowThickness = 3;
            grouper_InstallationKey.Size = new System.Drawing.Size(412, 198);
            grouper_InstallationKey.TabIndex = 15;
            // 
            // button_Browser
            // 
            button_Browser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button_Browser.Location = new System.Drawing.Point(272, 152);
            button_Browser.Name = "button_Browser";
            button_Browser.Size = new System.Drawing.Size(120, 35);
            button_Browser.TabIndex = 3;
            button_Browser.Text = "Browser";
            button_Browser.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button_Cancel.Location = new System.Drawing.Point(145, 152);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new System.Drawing.Size(120, 35);
            button_Cancel.TabIndex = 2;
            button_Cancel.Text = "CANCEL";
            button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_Accept
            // 
            button_Accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button_Accept.Location = new System.Drawing.Point(20, 152);
            button_Accept.Name = "button_Accept";
            button_Accept.Size = new System.Drawing.Size(120, 35);
            button_Accept.TabIndex = 1;
            button_Accept.Text = "ACCEPT";
            button_Accept.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            richTextBox1.Location = new System.Drawing.Point(20, 32);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new System.Drawing.Size(372, 107);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // InstallationKey
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            ClientSize = new System.Drawing.Size(566, 372);
            Controls.Add(grouper_InstallationKey);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "InstallationKey";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Installation Key Dialog";
            grouper_InstallationKey.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private CodeVendor.Controls.Grouper grouper_InstallationKey;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Accept;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_Browser;
    }
}
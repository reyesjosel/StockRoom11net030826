namespace MyStuff11net
{
    partial class Engineering_Change_Request
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Engineering_Change_Request));
            button_Save = new System.Windows.Forms.Button();
            button_Cancel = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            htmlwysiwyg_Title = new MyStuff11net.Htmlwysiwyg();
            label_Title = new System.Windows.Forms.Label();
            label_Description = new System.Windows.Forms.Label();
            htmlwysiwyg_Description = new MyStuff11net.Htmlwysiwyg();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            SuspendLayout();
            // 
            // button_Save
            // 
            button_Save.Location = new System.Drawing.Point(499, 235);
            button_Save.Name = "button_Save";
            button_Save.Size = new System.Drawing.Size(100, 25);
            button_Save.TabIndex = 0;
            button_Save.Text = "Save";
            button_Save.UseVisualStyleBackColor = true;
            button_Save.Click += new System.EventHandler(button_Save_Click);
            // 
            // button_Cancel
            // 
            button_Cancel.Location = new System.Drawing.Point(629, 235);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new System.Drawing.Size(100, 25);
            button_Cancel.TabIndex = 1;
            button_Cancel.Text = "Cancel";
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += new System.EventHandler(button_Cancel_Click);
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(485, 267);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // htmlwysiwyg_Title
            // 
            htmlwysiwyg_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            htmlwysiwyg_Title.Location = new System.Drawing.Point(490, 25);
            htmlwysiwyg_Title.Name = "htmlwysiwyg_Title";
            htmlwysiwyg_Title.ShowAlignCenterButton = true;
            htmlwysiwyg_Title.ShowAlignLeftButton = true;
            htmlwysiwyg_Title.ShowAlignRightButton = true;
            htmlwysiwyg_Title.ShowBackColorButton = true;
            htmlwysiwyg_Title.ShowBolButton = true;
            htmlwysiwyg_Title.ShowBulletButton = true;
            htmlwysiwyg_Title.ShowCopyButton = true;
            htmlwysiwyg_Title.ShowCutButton = true;
            htmlwysiwyg_Title.ShowFontFamilyButton = false;
            htmlwysiwyg_Title.ShowFontSizeButton = false;
            htmlwysiwyg_Title.ShowIndentButton = true;
            htmlwysiwyg_Title.ShowItalicButton = true;
            htmlwysiwyg_Title.ShowJustifyButton = true;
            htmlwysiwyg_Title.ShowLinkButton = false;
            htmlwysiwyg_Title.ShowNewButton = false;
            htmlwysiwyg_Title.ShowNewEngineeringChange = false;
            htmlwysiwyg_Title.ShowOrderedListButton = true;
            htmlwysiwyg_Title.ShowOutdentButton = true;
            htmlwysiwyg_Title.ShowPasteButton = true;
            htmlwysiwyg_Title.ShowPrintButton = false;
            htmlwysiwyg_Title.ShowSaveButton = false;
            htmlwysiwyg_Title.ShowScrollBars = false;
            htmlwysiwyg_Title.ShowTxtBGButton = true;
            htmlwysiwyg_Title.ShowTxtColorButton = true;
            htmlwysiwyg_Title.ShowUnderlineButton = true;
            htmlwysiwyg_Title.ShowUnlinkButton = false;
            htmlwysiwyg_Title.Size = new System.Drawing.Size(428, 65);
            htmlwysiwyg_Title.TabIndex = 3;
            // 
            // label_Title
            // 
            label_Title.AutoSize = true;
            label_Title.Location = new System.Drawing.Point(496, 6);
            label_Title.Name = "label_Title";
            label_Title.Size = new System.Drawing.Size(124, 13);
            label_Title.TabIndex = 4;
            label_Title.Text = "Engineering change title:";
            // 
            // label_Description
            // 
            label_Description.AutoSize = true;
            label_Description.Location = new System.Drawing.Point(497, 102);
            label_Description.Name = "label_Description";
            label_Description.Size = new System.Drawing.Size(159, 13);
            label_Description.TabIndex = 5;
            label_Description.Text = "Engineering change description:";
            // 
            // htmlwysiwyg_Description
            // 
            htmlwysiwyg_Description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            htmlwysiwyg_Description.Location = new System.Drawing.Point(490, 122);
            htmlwysiwyg_Description.Name = "htmlwysiwyg_Description";
            htmlwysiwyg_Description.ShowAlignCenterButton = true;
            htmlwysiwyg_Description.ShowAlignLeftButton = true;
            htmlwysiwyg_Description.ShowAlignRightButton = true;
            htmlwysiwyg_Description.ShowBackColorButton = true;
            htmlwysiwyg_Description.ShowBolButton = true;
            htmlwysiwyg_Description.ShowBulletButton = true;
            htmlwysiwyg_Description.ShowCopyButton = true;
            htmlwysiwyg_Description.ShowCutButton = true;
            htmlwysiwyg_Description.ShowFontFamilyButton = false;
            htmlwysiwyg_Description.ShowFontSizeButton = false;
            htmlwysiwyg_Description.ShowIndentButton = true;
            htmlwysiwyg_Description.ShowItalicButton = true;
            htmlwysiwyg_Description.ShowJustifyButton = true;
            htmlwysiwyg_Description.ShowLinkButton = false;
            htmlwysiwyg_Description.ShowNewButton = false;
            htmlwysiwyg_Description.ShowNewEngineeringChange = false;
            htmlwysiwyg_Description.ShowOrderedListButton = true;
            htmlwysiwyg_Description.ShowOutdentButton = true;
            htmlwysiwyg_Description.ShowPasteButton = true;
            htmlwysiwyg_Description.ShowPrintButton = false;
            htmlwysiwyg_Description.ShowSaveButton = false;
            htmlwysiwyg_Description.ShowScrollBars = false;
            htmlwysiwyg_Description.ShowTxtBGButton = true;
            htmlwysiwyg_Description.ShowTxtColorButton = true;
            htmlwysiwyg_Description.ShowUnderlineButton = true;
            htmlwysiwyg_Description.ShowUnlinkButton = false;
            htmlwysiwyg_Description.Size = new System.Drawing.Size(428, 103);
            htmlwysiwyg_Description.TabIndex = 6;
            // 
            // Engineering_Change_Request
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(926, 267);
            ControlBox = false;
            Controls.Add(htmlwysiwyg_Description);
            Controls.Add(label_Description);
            Controls.Add(label_Title);
            Controls.Add(htmlwysiwyg_Title);
            Controls.Add(pictureBox1);
            Controls.Add(button_Cancel);
            Controls.Add(button_Save);
            Name = "Engineering_Change_Request";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Engineering_Change_Request form.";
            TopMost = true;
            Load += new System.EventHandler(Engineering_Change_Request_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MyStuff11net.Htmlwysiwyg htmlwysiwyg_Title;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_Description;
        private MyStuff11net.Htmlwysiwyg htmlwysiwyg_Description;
    }
}
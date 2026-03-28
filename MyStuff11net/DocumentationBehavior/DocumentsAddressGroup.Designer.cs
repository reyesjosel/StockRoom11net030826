namespace MyStuff11net
{
    partial class DocumentsAddressGroup
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
            grouper_DocumentsAddressGroup = new CodeVendor.Controls.Grouper();
            panel_DocumentsAddressItems = new System.Windows.Forms.Panel();
            documentsAddressItemDefault = new MyStuff11net.DocumentsAddressItem();
            panel_DocumentsPDFGroupInf = new System.Windows.Forms.Panel();
            grouper_DocumentsPDFGroupInf = new CodeVendor.Controls.Grouper();
            richTextBox7 = new System.Windows.Forms.RichTextBox();
            panel_FlowLayoutButtons = new System.Windows.Forms.Panel();
            flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            ButtonAdd = new System.Windows.Forms.Button();
            ButtonEdit = new System.Windows.Forms.Button();
            ButtonDelete = new System.Windows.Forms.Button();
            ButtonCancel = new System.Windows.Forms.Button();
            grouper_DocumentsAddressGroup.SuspendLayout();
            panel_DocumentsAddressItems.SuspendLayout();
            panel_DocumentsPDFGroupInf.SuspendLayout();
            grouper_DocumentsPDFGroupInf.SuspendLayout();
            panel_FlowLayoutButtons.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // grouper_DocumentsAddressGroup
            // 
            grouper_DocumentsAddressGroup.AutoSize = true;
            grouper_DocumentsAddressGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            grouper_DocumentsAddressGroup.BackgroundColor = System.Drawing.SystemColors.Control;
            grouper_DocumentsAddressGroup.BackgroundGradientColor = System.Drawing.Color.Gainsboro;
            grouper_DocumentsAddressGroup.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_DocumentsAddressGroup.BorderColor = System.Drawing.Color.DimGray;
            grouper_DocumentsAddressGroup.BorderThickness = 1F;
            grouper_DocumentsAddressGroup.Controls.Add(panel_DocumentsAddressItems);
            grouper_DocumentsAddressGroup.Controls.Add(panel_FlowLayoutButtons);
            grouper_DocumentsAddressGroup.Controls.Add(panel_DocumentsPDFGroupInf);
            grouper_DocumentsAddressGroup.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper_DocumentsAddressGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            grouper_DocumentsAddressGroup.GroupImage = null;
            grouper_DocumentsAddressGroup.GroupTitle = "";
            grouper_DocumentsAddressGroup.Location = new System.Drawing.Point(0, 0);
            grouper_DocumentsAddressGroup.Margin = new System.Windows.Forms.Padding(0);
            grouper_DocumentsAddressGroup.MinimumSize = new System.Drawing.Size(400, 60);
            grouper_DocumentsAddressGroup.Name = "grouper_DocumentsAddressGroup";
            grouper_DocumentsAddressGroup.Padding = new System.Windows.Forms.Padding(5);
            grouper_DocumentsAddressGroup.PaintGroupBox = false;
            grouper_DocumentsAddressGroup.RoundCorners = 10;
            grouper_DocumentsAddressGroup.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_DocumentsAddressGroup.ShadowControl = false;
            grouper_DocumentsAddressGroup.ShadowThickness = 3;
            grouper_DocumentsAddressGroup.Size = new System.Drawing.Size(450, 230);
            grouper_DocumentsAddressGroup.TabIndex = 24;
            // 
            // panel_DocumentsAddressItems
            // 
            panel_DocumentsAddressItems.AutoSize = true;
            panel_DocumentsAddressItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel_DocumentsAddressItems.Controls.Add(documentsAddressItemDefault);
            panel_DocumentsAddressItems.Dock = System.Windows.Forms.DockStyle.Top;
            panel_DocumentsAddressItems.Location = new System.Drawing.Point(5, 95);
            panel_DocumentsAddressItems.Margin = new System.Windows.Forms.Padding(0);
            panel_DocumentsAddressItems.Name = "panel_DocumentsAddressItems";
            panel_DocumentsAddressItems.Size = new System.Drawing.Size(440, 60);
            panel_DocumentsAddressItems.TabIndex = 4;
            // 
            // documentsAddressItemDefault
            // 
            documentsAddressItemDefault.AccessLevel = "Public";
            documentsAddressItemDefault.AutoSize = true;
            documentsAddressItemDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            documentsAddressItemDefault.Dock = System.Windows.Forms.DockStyle.Top;
            documentsAddressItemDefault.DocumentsAddressNameDescription = "This setting fault, the system set to defaul";
            documentsAddressItemDefault.DocumentsAddressSet = "PdfDoc12345&Public&This setting fault, the system set to defaul&Default Documents" +
    " Location&*.doc,*.docx,*.pdf";
            documentsAddressItemDefault.DocumentsAddressValueDirectory = "Default Documents Location";
            documentsAddressItemDefault.DocumentsExtensionAcepted = "*.doc,*.docx,*.pdf";
            documentsAddressItemDefault.ID = 12345;
            documentsAddressItemDefault.IsMouseOver = false;
            documentsAddressItemDefault.IsSelected = false;
            documentsAddressItemDefault.Location = new System.Drawing.Point(0, 0);
            documentsAddressItemDefault.MinimumSize = new System.Drawing.Size(400, 60);
            documentsAddressItemDefault.Name = "documentsAddressItemDefault";
            documentsAddressItemDefault.Size = new System.Drawing.Size(440, 60);
            documentsAddressItemDefault.TabIndex = 0;
            // 
            // panel_DocumentsPDFGroupInf
            // 
            panel_DocumentsPDFGroupInf.Controls.Add(grouper_DocumentsPDFGroupInf);
            panel_DocumentsPDFGroupInf.Dock = System.Windows.Forms.DockStyle.Top;
            panel_DocumentsPDFGroupInf.Location = new System.Drawing.Point(5, 5);
            panel_DocumentsPDFGroupInf.Margin = new System.Windows.Forms.Padding(0);
            panel_DocumentsPDFGroupInf.Name = "panel_DocumentsPDFGroupInf";
            panel_DocumentsPDFGroupInf.Size = new System.Drawing.Size(440, 90);
            panel_DocumentsPDFGroupInf.TabIndex = 36;
            // 
            // grouper_DocumentsPDFGroupInf
            // 
            grouper_DocumentsPDFGroupInf.BackgroundColor = System.Drawing.SystemColors.Info;
            grouper_DocumentsPDFGroupInf.BackgroundGradientColor = System.Drawing.Color.DarkGray;
            grouper_DocumentsPDFGroupInf.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_DocumentsPDFGroupInf.BorderColor = System.Drawing.Color.Black;
            grouper_DocumentsPDFGroupInf.BorderThickness = 1F;
            grouper_DocumentsPDFGroupInf.Controls.Add(richTextBox7);
            grouper_DocumentsPDFGroupInf.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper_DocumentsPDFGroupInf.Dock = System.Windows.Forms.DockStyle.Fill;
            grouper_DocumentsPDFGroupInf.GroupImage = null;
            grouper_DocumentsPDFGroupInf.GroupTitle = "";
            grouper_DocumentsPDFGroupInf.Location = new System.Drawing.Point(0, 0);
            grouper_DocumentsPDFGroupInf.Margin = new System.Windows.Forms.Padding(0);
            grouper_DocumentsPDFGroupInf.Name = "grouper_DocumentsPDFGroupInf";
            grouper_DocumentsPDFGroupInf.Padding = new System.Windows.Forms.Padding(10, 28, 10, 10);
            grouper_DocumentsPDFGroupInf.PaintGroupBox = false;
            grouper_DocumentsPDFGroupInf.RoundCorners = 10;
            grouper_DocumentsPDFGroupInf.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_DocumentsPDFGroupInf.ShadowControl = false;
            grouper_DocumentsPDFGroupInf.ShadowThickness = 3;
            grouper_DocumentsPDFGroupInf.Size = new System.Drawing.Size(440, 90);
            grouper_DocumentsPDFGroupInf.TabIndex = 34;
            // 
            // richTextBox7
            // 
            richTextBox7.BackColor = System.Drawing.SystemColors.Info;
            richTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            richTextBox7.Location = new System.Drawing.Point(10, 28);
            richTextBox7.Name = "richTextBox7";
            richTextBox7.Size = new System.Drawing.Size(420, 52);
            richTextBox7.TabIndex = 29;
            richTextBox7.Text = "        There is no defined location or folder at this time, press Add button to " +
    "insert a new location or folder where the system scans for .pdf documents.";
            // 
            // panel_FlowLayoutButtons
            // 
            panel_FlowLayoutButtons.Controls.Add(flowLayoutPanelButtons);
            panel_FlowLayoutButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel_FlowLayoutButtons.Location = new System.Drawing.Point(5, 186);
            panel_FlowLayoutButtons.Name = "panel_FlowLayoutButtons";
            panel_FlowLayoutButtons.Size = new System.Drawing.Size(440, 39);
            panel_FlowLayoutButtons.TabIndex = 3;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanelButtons.Controls.Add(ButtonAdd);
            flowLayoutPanelButtons.Controls.Add(ButtonEdit);
            flowLayoutPanelButtons.Controls.Add(ButtonDelete);
            flowLayoutPanelButtons.Controls.Add(ButtonCancel);
            flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanelButtons.Location = new System.Drawing.Point(0, -1);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Size = new System.Drawing.Size(440, 40);
            flowLayoutPanelButtons.TabIndex = 12;
            // 
            // ButtonAdd
            // 
            ButtonAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            ButtonAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            ButtonAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            ButtonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ButtonAdd.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ButtonAdd.Location = new System.Drawing.Point(3, 3);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new System.Drawing.Size(104, 37);
            ButtonAdd.TabIndex = 5;
            ButtonAdd.Text = "Add";
            ButtonAdd.UseVisualStyleBackColor = false;
            // 
            // ButtonEdit
            // 
            ButtonEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            ButtonEdit.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            ButtonEdit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            ButtonEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ButtonEdit.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ButtonEdit.Location = new System.Drawing.Point(113, 3);
            ButtonEdit.Name = "ButtonEdit";
            ButtonEdit.Size = new System.Drawing.Size(104, 37);
            ButtonEdit.TabIndex = 2;
            ButtonEdit.Text = "Edit";
            ButtonEdit.UseVisualStyleBackColor = false;
            // 
            // ButtonDelete
            // 
            ButtonDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            ButtonDelete.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            ButtonDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            ButtonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ButtonDelete.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ButtonDelete.Location = new System.Drawing.Point(223, 3);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new System.Drawing.Size(104, 37);
            ButtonDelete.TabIndex = 4;
            ButtonDelete.Text = "Delete";
            ButtonDelete.UseVisualStyleBackColor = false;
            // 
            // ButtonCancel
            // 
            ButtonCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            ButtonCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            ButtonCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            ButtonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            ButtonCancel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ButtonCancel.Location = new System.Drawing.Point(333, 3);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new System.Drawing.Size(104, 37);
            ButtonCancel.TabIndex = 3;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = false;
            // 
            // DocumentsAddressGroup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(grouper_DocumentsAddressGroup);
            MinimumSize = new System.Drawing.Size(450, 230);
            Name = "DocumentsAddressGroup";
            Size = new System.Drawing.Size(450, 230);
            grouper_DocumentsAddressGroup.ResumeLayout(false);
            grouper_DocumentsAddressGroup.PerformLayout();
            panel_DocumentsAddressItems.ResumeLayout(false);
            panel_DocumentsAddressItems.PerformLayout();
            panel_DocumentsPDFGroupInf.ResumeLayout(false);
            grouper_DocumentsPDFGroupInf.ResumeLayout(false);
            panel_FlowLayoutButtons.ResumeLayout(false);
            flowLayoutPanelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private CodeVendor.Controls.Grouper grouper_DocumentsAddressGroup;
        private System.Windows.Forms.Panel panel_DocumentsAddressItems;
        private System.Windows.Forms.Panel panel_FlowLayoutButtons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonDelete;
        private DocumentsAddressItem documentsAddressItemDefault;
        private System.Windows.Forms.Panel panel_DocumentsPDFGroupInf;
        private CodeVendor.Controls.Grouper grouper_DocumentsPDFGroupInf;
        private System.Windows.Forms.RichTextBox richTextBox7;
    }
}

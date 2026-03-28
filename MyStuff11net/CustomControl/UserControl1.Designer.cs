namespace MyStuff11net.CustomControl
{
    partial class UserControl1
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
            panel_TreeViewSetting = new CustomPanelDoubleBuffered();
            grouper_TreeViewSetting = new CodeVendor.Controls.Grouper();
            panel1 = new CustomPanelDoubleBuffered();
            grouper_NewItemButtons = new CodeVendor.Controls.Grouper();
            flowLayoutPanel_Buttons = new FlowLayoutPanel();
            button_AddNew = new Button();
            button_Save = new Button();
            button_Delete = new Button();
            panel_TreeViewSetting.SuspendLayout();
            grouper_TreeViewSetting.SuspendLayout();
            grouper_NewItemButtons.SuspendLayout();
            flowLayoutPanel_Buttons.SuspendLayout();
            SuspendLayout();
            // 
            // panel_TreeViewSetting
            // 
            panel_TreeViewSetting.Controls.Add(grouper_TreeViewSetting);
            panel_TreeViewSetting.Controls.Add(grouper_NewItemButtons);
            panel_TreeViewSetting.Dock = DockStyle.Fill;
            panel_TreeViewSetting.Location = new Point(0, 0);
            panel_TreeViewSetting.Name = "panel_TreeViewSetting";
            panel_TreeViewSetting.Padding = new Padding(4);
            panel_TreeViewSetting.Size = new Size(1307, 660);
            panel_TreeViewSetting.TabIndex = 0;
            // 
            // grouper_TreeViewSetting
            // 
            grouper_TreeViewSetting.BackgroundColor = Color.LightGray;
            grouper_TreeViewSetting.BackgroundGradientColor = Color.DarkGray;
            grouper_TreeViewSetting.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_TreeViewSetting.BackgroundImageLayout = ImageLayout.None;
            grouper_TreeViewSetting.BorderColor = Color.Black;
            grouper_TreeViewSetting.BorderThickness = 1F;
            grouper_TreeViewSetting.Controls.Add(panel1);
            grouper_TreeViewSetting.CustomGroupBoxColor = Color.White;
            grouper_TreeViewSetting.Dock = DockStyle.Top;
            grouper_TreeViewSetting.GroupImage = null;
            grouper_TreeViewSetting.GroupTitle = "TreeView setting";
            grouper_TreeViewSetting.Location = new Point(4, 4);
            grouper_TreeViewSetting.Margin = new Padding(0);
            grouper_TreeViewSetting.MinimumSize = new Size(333, 65);
            grouper_TreeViewSetting.Name = "grouper_TreeViewSetting";
            grouper_TreeViewSetting.Padding = new Padding(5, 25, 5, 5);
            grouper_TreeViewSetting.PaintGroupBox = false;
            grouper_TreeViewSetting.RoundCorners = 10;
            grouper_TreeViewSetting.ShadowColor = Color.DarkGray;
            grouper_TreeViewSetting.ShadowControl = false;
            grouper_TreeViewSetting.ShadowThickness = 3;
            grouper_TreeViewSetting.Size = new Size(1299, 286);
            grouper_TreeViewSetting.TabIndex = 23;
            grouper_TreeViewSetting.Load += grouper_TreeViewSetting_Load;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(1289, 139);
            panel1.TabIndex = 0;
            // 
            // grouper_NewItemButtons
            // 
            grouper_NewItemButtons.BackgroundColor = Color.LightGray;
            grouper_NewItemButtons.BackgroundGradientColor = Color.DarkGray;
            grouper_NewItemButtons.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_NewItemButtons.BackgroundImageLayout = ImageLayout.None;
            grouper_NewItemButtons.BorderColor = Color.Black;
            grouper_NewItemButtons.BorderThickness = 1F;
            grouper_NewItemButtons.Controls.Add(flowLayoutPanel_Buttons);
            grouper_NewItemButtons.CustomGroupBoxColor = Color.White;
            grouper_NewItemButtons.Dock = DockStyle.Bottom;
            grouper_NewItemButtons.GroupImage = null;
            grouper_NewItemButtons.GroupTitle = "";
            grouper_NewItemButtons.Location = new Point(4, 568);
            grouper_NewItemButtons.Margin = new Padding(0);
            grouper_NewItemButtons.MinimumSize = new Size(333, 65);
            grouper_NewItemButtons.Name = "grouper_NewItemButtons";
            grouper_NewItemButtons.Padding = new Padding(3, 10, 3, 3);
            grouper_NewItemButtons.PaintGroupBox = false;
            grouper_NewItemButtons.RoundCorners = 10;
            grouper_NewItemButtons.ShadowColor = Color.DarkGray;
            grouper_NewItemButtons.ShadowControl = false;
            grouper_NewItemButtons.ShadowThickness = 3;
            grouper_NewItemButtons.Size = new Size(1299, 88);
            grouper_NewItemButtons.TabIndex = 22;
            // 
            // flowLayoutPanel_Buttons
            // 
            flowLayoutPanel_Buttons.AutoSize = true;
            flowLayoutPanel_Buttons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_Buttons.BackgroundImageLayout = ImageLayout.None;
            flowLayoutPanel_Buttons.Controls.Add(button_AddNew);
            flowLayoutPanel_Buttons.Controls.Add(button_Save);
            flowLayoutPanel_Buttons.Controls.Add(button_Delete);
            flowLayoutPanel_Buttons.Dock = DockStyle.Fill;
            flowLayoutPanel_Buttons.Location = new Point(3, 10);
            flowLayoutPanel_Buttons.Margin = new Padding(0);
            flowLayoutPanel_Buttons.MinimumSize = new Size(0, 1);
            flowLayoutPanel_Buttons.Name = "flowLayoutPanel_Buttons";
            flowLayoutPanel_Buttons.Padding = new Padding(1, 1, 0, 0);
            flowLayoutPanel_Buttons.Size = new Size(1293, 75);
            flowLayoutPanel_Buttons.TabIndex = 13;
            // 
            // button_AddNew
            // 
            button_AddNew.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_AddNew.Location = new Point(2, 2);
            button_AddNew.Margin = new Padding(1);
            button_AddNew.MinimumSize = new Size(67, 25);
            button_AddNew.Name = "button_AddNew";
            button_AddNew.Size = new Size(67, 25);
            button_AddNew.TabIndex = 5;
            button_AddNew.Text = "Add New";
            button_AddNew.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            button_Save.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Save.Location = new Point(71, 2);
            button_Save.Margin = new Padding(1);
            button_Save.MinimumSize = new Size(67, 25);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(67, 25);
            button_Save.TabIndex = 2;
            button_Save.Text = "Save";
            button_Save.UseVisualStyleBackColor = true;
            // 
            // button_Delete
            // 
            button_Delete.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_Delete.Location = new Point(140, 2);
            button_Delete.Margin = new Padding(1);
            button_Delete.MinimumSize = new Size(67, 25);
            button_Delete.Name = "button_Delete";
            button_Delete.Size = new Size(67, 25);
            button_Delete.TabIndex = 3;
            button_Delete.Text = "Delete";
            button_Delete.UseVisualStyleBackColor = true;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_TreeViewSetting);
            Name = "UserControl1";
            Size = new Size(1307, 660);
            panel_TreeViewSetting.ResumeLayout(false);
            grouper_TreeViewSetting.ResumeLayout(false);
            grouper_NewItemButtons.ResumeLayout(false);
            grouper_NewItemButtons.PerformLayout();
            flowLayoutPanel_Buttons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private CustomPanelDoubleBuffered panel_TreeViewSetting;
        private CodeVendor.Controls.Grouper grouper_NewItemButtons;
        private FlowLayoutPanel flowLayoutPanel_Buttons;
        private Button button_AddNew;
        private Button button_Save;
        private Button button_Delete;
        private CodeVendor.Controls.Grouper grouper_TreeViewSetting;
        private CustomPanelDoubleBuffered panel1;
    }
}

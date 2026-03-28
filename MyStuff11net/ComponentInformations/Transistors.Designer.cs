namespace MyStuff11net
{
    partial class Transistors
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
            flowLayoutPanel = new FlowLayoutPanel();
            panel_Value = new CustomPanelDoubleBuffered();
            Name_value = new TextBox();
            label_Name = new Label();
            panel_Unid = new CustomPanelDoubleBuffered();
            Type = new ComboBox();
            label_Type = new Label();
            panel_Tolerance = new CustomPanelDoubleBuffered();
            Vce = new ComboBox();
            label_Vce = new Label();
            panel_Size = new CustomPanelDoubleBuffered();
            Ice = new ComboBox();
            label_Ice = new Label();
            panel_Power = new CustomPanelDoubleBuffered();
            Package = new ComboBox();
            label_PackageCase = new Label();
            grouper_BaseComponent.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            panel_Value.SuspendLayout();
            panel_Unid.SuspendLayout();
            panel_Tolerance.SuspendLayout();
            panel_Size.SuspendLayout();
            panel_Power.SuspendLayout();
            SuspendLayout();
            // 
            // grouper_BaseComponent
            // 
            grouper_BaseComponent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_BaseComponent.Controls.Add(flowLayoutPanel);
            grouper_BaseComponent.Controls.SetChildIndex(label_DescriptionInformations, 0);
            grouper_BaseComponent.Controls.SetChildIndex(label_DescriptionLabel, 0);
            grouper_BaseComponent.Controls.SetChildIndex(flowLayoutPanel, 0);
            // 
            // label_DescriptionLabel
            // 
            label_DescriptionLabel.Location = new Point(25, 95);
            label_DescriptionLabel.Margin = new Padding(0);
            // 
            // label_DescriptionInformations
            // 
            label_DescriptionInformations.Location = new Point(25, 125);
            label_DescriptionInformations.Margin = new Padding(0);
            label_DescriptionInformations.Size = new Size(540, 35);
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.Controls.Add(panel_Value);
            flowLayoutPanel.Controls.Add(panel_Unid);
            flowLayoutPanel.Controls.Add(panel_Tolerance);
            flowLayoutPanel.Controls.Add(panel_Size);
            flowLayoutPanel.Controls.Add(panel_Power);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(25, 25);
            flowLayoutPanel.Margin = new Padding(0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(540, 70);
            flowLayoutPanel.TabIndex = 27;
            // 
            // panel_Value
            // 
            panel_Value.AutoSize = true;
            panel_Value.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Value.Controls.Add(Name_value);
            panel_Value.Controls.Add(label_Name);
            panel_Value.Location = new Point(0, 0);
            panel_Value.Margin = new Padding(0);
            panel_Value.MinimumSize = new Size(100, 60);
            panel_Value.Name = "panel_Value";
            panel_Value.Padding = new Padding(5);
            panel_Value.Size = new Size(100, 60);
            panel_Value.TabIndex = 30;
            // 
            // Name_value
            // 
            Name_value.BorderStyle = BorderStyle.FixedSingle;
            Name_value.Dock = DockStyle.Top;
            Name_value.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name_value.Location = new Point(5, 25);
            Name_value.Margin = new Padding(4, 5, 4, 5);
            Name_value.Name = "Name_value";
            Name_value.Size = new Size(90, 26);
            Name_value.TabIndex = 1;
            // 
            // label_Name
            // 
            label_Name.AutoSize = true;
            label_Name.Dock = DockStyle.Top;
            label_Name.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Name.Location = new Point(5, 5);
            label_Name.Margin = new Padding(4, 0, 4, 0);
            label_Name.Name = "label_Name";
            label_Name.Size = new Size(55, 20);
            label_Name.TabIndex = 6;
            label_Name.Text = "Name";
            // 
            // panel_Unid
            // 
            panel_Unid.AutoSize = true;
            panel_Unid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Unid.Controls.Add(Type);
            panel_Unid.Controls.Add(label_Type);
            panel_Unid.Location = new Point(100, 0);
            panel_Unid.Margin = new Padding(0);
            panel_Unid.MinimumSize = new Size(100, 60);
            panel_Unid.Name = "panel_Unid";
            panel_Unid.Padding = new Padding(5);
            panel_Unid.Size = new Size(100, 60);
            panel_Unid.TabIndex = 28;
            // 
            // Type
            // 
            Type.Dock = DockStyle.Top;
            Type.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Type.FormattingEnabled = true;
            Type.Location = new Point(5, 25);
            Type.Margin = new Padding(4, 5, 4, 5);
            Type.Name = "Type";
            Type.Size = new Size(90, 26);
            Type.TabIndex = 3;
            // 
            // label_Type
            // 
            label_Type.AutoSize = true;
            label_Type.Dock = DockStyle.Top;
            label_Type.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Type.Location = new Point(5, 5);
            label_Type.Margin = new Padding(4, 0, 4, 0);
            label_Type.Name = "label_Type";
            label_Type.Size = new Size(47, 20);
            label_Type.TabIndex = 7;
            label_Type.Text = "Type";
            // 
            // panel_Tolerance
            // 
            panel_Tolerance.AutoSize = true;
            panel_Tolerance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Tolerance.Controls.Add(Vce);
            panel_Tolerance.Controls.Add(label_Vce);
            panel_Tolerance.Location = new Point(200, 0);
            panel_Tolerance.Margin = new Padding(0);
            panel_Tolerance.MinimumSize = new Size(100, 60);
            panel_Tolerance.Name = "panel_Tolerance";
            panel_Tolerance.Padding = new Padding(5);
            panel_Tolerance.Size = new Size(100, 60);
            panel_Tolerance.TabIndex = 31;
            // 
            // Vce
            // 
            Vce.Dock = DockStyle.Top;
            Vce.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Vce.FormattingEnabled = true;
            Vce.Items.AddRange(new object[] { "0.1", "1", "5" });
            Vce.Location = new Point(5, 25);
            Vce.Margin = new Padding(4, 5, 4, 5);
            Vce.Name = "Vce";
            Vce.Size = new Size(90, 26);
            Vce.TabIndex = 2;
            Vce.Text = "1";
            // 
            // label_Vce
            // 
            label_Vce.AutoSize = true;
            label_Vce.Dock = DockStyle.Top;
            label_Vce.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Vce.Location = new Point(5, 5);
            label_Vce.Margin = new Padding(4, 0, 4, 0);
            label_Vce.Name = "label_Vce";
            label_Vce.Size = new Size(40, 20);
            label_Vce.TabIndex = 8;
            label_Vce.Text = "Vce";
            // 
            // panel_Size
            // 
            panel_Size.AutoSize = true;
            panel_Size.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Size.Controls.Add(Ice);
            panel_Size.Controls.Add(label_Ice);
            panel_Size.Location = new Point(300, 0);
            panel_Size.Margin = new Padding(0);
            panel_Size.MinimumSize = new Size(100, 60);
            panel_Size.Name = "panel_Size";
            panel_Size.Padding = new Padding(5);
            panel_Size.Size = new Size(100, 60);
            panel_Size.TabIndex = 29;
            // 
            // Ice
            // 
            Ice.Dock = DockStyle.Top;
            Ice.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Ice.FormattingEnabled = true;
            Ice.Items.AddRange(new object[] { "0402", "0603", "0805", "1008", "1206", "1210", "1411", "1612", "1806", "1812", "1913", "2010", "2225", "2412", "2416", "2512", "2916", "3119", "3312", "Through" });
            Ice.Location = new Point(5, 25);
            Ice.Margin = new Padding(4, 5, 4, 5);
            Ice.Name = "Ice";
            Ice.Size = new Size(90, 26);
            Ice.TabIndex = 4;
            Ice.Text = "0402";
            // 
            // label_Ice
            // 
            label_Ice.AutoSize = true;
            label_Ice.Dock = DockStyle.Top;
            label_Ice.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Ice.Location = new Point(5, 5);
            label_Ice.Margin = new Padding(4, 0, 4, 0);
            label_Ice.Name = "label_Ice";
            label_Ice.Size = new Size(34, 20);
            label_Ice.TabIndex = 9;
            label_Ice.Text = "Ice";
            // 
            // panel_Power
            // 
            panel_Power.AutoSize = true;
            panel_Power.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Power.Controls.Add(Package);
            panel_Power.Controls.Add(label_PackageCase);
            panel_Power.Location = new Point(400, 0);
            panel_Power.Margin = new Padding(0);
            panel_Power.MinimumSize = new Size(140, 60);
            panel_Power.Name = "panel_Power";
            panel_Power.Padding = new Padding(5);
            panel_Power.Size = new Size(140, 60);
            panel_Power.TabIndex = 32;
            // 
            // Package
            // 
            Package.Dock = DockStyle.Top;
            Package.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Package.FormattingEnabled = true;
            Package.Items.AddRange(new object[] { "1/8", "1/4", "1/2", "3/8", "1", "1.5", "2", "5", "10", "20" });
            Package.Location = new Point(5, 25);
            Package.Margin = new Padding(4, 5, 4, 5);
            Package.Name = "Package";
            Package.Size = new Size(130, 26);
            Package.TabIndex = 5;
            Package.Text = "1/8";
            // 
            // label_PackageCase
            // 
            label_PackageCase.AutoSize = true;
            label_PackageCase.Dock = DockStyle.Top;
            label_PackageCase.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_PackageCase.Location = new Point(5, 5);
            label_PackageCase.Margin = new Padding(4, 0, 4, 0);
            label_PackageCase.Name = "label_PackageCase";
            label_PackageCase.Size = new Size(124, 20);
            label_PackageCase.TabIndex = 10;
            label_PackageCase.Text = "Package/Case";
            // 
            // Transistors
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = false;
            Name = "Transistors";
            grouper_BaseComponent.ResumeLayout(false);
            grouper_BaseComponent.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            flowLayoutPanel.PerformLayout();
            panel_Value.ResumeLayout(false);
            panel_Value.PerformLayout();
            panel_Unid.ResumeLayout(false);
            panel_Unid.PerformLayout();
            panel_Tolerance.ResumeLayout(false);
            panel_Tolerance.PerformLayout();
            panel_Size.ResumeLayout(false);
            panel_Size.PerformLayout();
            panel_Power.ResumeLayout(false);
            panel_Power.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel;
        private CustomPanelDoubleBuffered panel_Value;
        private TextBox Name_value;
        private Label label_Name;
        private CustomPanelDoubleBuffered panel_Unid;
        private ComboBox Type;
        private Label label_Type;
        private CustomPanelDoubleBuffered panel_Tolerance;
        private ComboBox Vce;
        private Label label_Vce;
        private CustomPanelDoubleBuffered panel_Size;
        private ComboBox Ice;
        private Label label_Ice;
        private CustomPanelDoubleBuffered panel_Power;
        private ComboBox Package;
        private Label label_PackageCase;
    }
}

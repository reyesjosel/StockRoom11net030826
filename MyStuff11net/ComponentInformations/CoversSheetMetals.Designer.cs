namespace MyStuff11net
{
    partial class CoversSheetMetals
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
            Value = new TextBox();
            label_Value = new Label();
            panel_Unid = new CustomPanelDoubleBuffered();
            Unid = new ComboBox();
            label_Unid = new Label();
            panel_Tolerance = new CustomPanelDoubleBuffered();
            Tolerance = new ComboBox();
            label_Tolerance = new Label();
            panel_Size = new CustomPanelDoubleBuffered();
            Package = new ComboBox();
            label_Size = new Label();
            panel_Power = new CustomPanelDoubleBuffered();
            Power = new ComboBox();
            label_Power = new Label();
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
            grouper_BaseComponent.Controls.Add(flowLayoutPanel);
            grouper_BaseComponent.GroupTitle = "CoversSheetMetals";
            grouper_BaseComponent.Controls.SetChildIndex(label_DescriptionInformations, 0);
            grouper_BaseComponent.Controls.SetChildIndex(label_DescriptionLabel, 0);
            grouper_BaseComponent.Controls.SetChildIndex(flowLayoutPanel, 0);
            // 
            // label_DescriptionLabel
            // 
            label_DescriptionLabel.Location = new Point(25, 95);
            label_DescriptionLabel.Margin = new Padding(0);
            label_DescriptionLabel.Text = "Self-generated Description";
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
            panel_Value.Controls.Add(Value);
            panel_Value.Controls.Add(label_Value);
            panel_Value.Location = new Point(0, 0);
            panel_Value.Margin = new Padding(0);
            panel_Value.MinimumSize = new Size(125, 60);
            panel_Value.Name = "panel_Value";
            panel_Value.Padding = new Padding(5);
            panel_Value.Size = new Size(125, 60);
            panel_Value.TabIndex = 30;
            // 
            // Value
            // 
            Value.BorderStyle = BorderStyle.FixedSingle;
            Value.Dock = DockStyle.Top;
            Value.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Value.Location = new Point(5, 25);
            Value.Margin = new Padding(4, 5, 4, 5);
            Value.Name = "Value";
            Value.Size = new Size(115, 26);
            Value.TabIndex = 1;
            // 
            // label_Value
            // 
            label_Value.AutoSize = true;
            label_Value.Dock = DockStyle.Top;
            label_Value.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Value.Location = new Point(5, 5);
            label_Value.Margin = new Padding(4, 0, 4, 0);
            label_Value.Name = "label_Value";
            label_Value.Size = new Size(55, 20);
            label_Value.TabIndex = 6;
            label_Value.Text = "Value";
            // 
            // panel_Unid
            // 
            panel_Unid.Controls.Add(Unid);
            panel_Unid.Controls.Add(label_Unid);
            panel_Unid.Location = new Point(125, 0);
            panel_Unid.Margin = new Padding(0);
            panel_Unid.MinimumSize = new Size(125, 60);
            panel_Unid.Name = "panel_Unid";
            panel_Unid.Padding = new Padding(5);
            panel_Unid.Size = new Size(125, 60);
            panel_Unid.TabIndex = 28;
            // 
            // Unid
            // 
            Unid.Dock = DockStyle.Top;
            Unid.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Unid.FormattingEnabled = true;
            Unid.Location = new Point(5, 25);
            Unid.Margin = new Padding(4, 5, 4, 5);
            Unid.Name = "Unid";
            Unid.Size = new Size(115, 26);
            Unid.TabIndex = 3;
            // 
            // label_Unid
            // 
            label_Unid.AutoSize = true;
            label_Unid.Dock = DockStyle.Top;
            label_Unid.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Unid.Location = new Point(5, 5);
            label_Unid.Margin = new Padding(4, 0, 4, 0);
            label_Unid.Name = "label_Unid";
            label_Unid.Size = new Size(46, 20);
            label_Unid.TabIndex = 7;
            label_Unid.Text = "Unid";
            // 
            // panel_Tolerance
            // 
            panel_Tolerance.Controls.Add(Tolerance);
            panel_Tolerance.Controls.Add(label_Tolerance);
            panel_Tolerance.Location = new Point(250, 0);
            panel_Tolerance.Margin = new Padding(0);
            panel_Tolerance.MinimumSize = new Size(125, 60);
            panel_Tolerance.Name = "panel_Tolerance";
            panel_Tolerance.Padding = new Padding(5);
            panel_Tolerance.Size = new Size(125, 60);
            panel_Tolerance.TabIndex = 31;
            // 
            // Tolerance
            // 
            Tolerance.Dock = DockStyle.Top;
            Tolerance.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tolerance.FormattingEnabled = true;
            Tolerance.Items.AddRange(new object[] { "0.1", "1", "5" });
            Tolerance.Location = new Point(5, 25);
            Tolerance.Margin = new Padding(4, 5, 4, 5);
            Tolerance.Name = "Tolerance";
            Tolerance.Size = new Size(115, 26);
            Tolerance.TabIndex = 2;
            Tolerance.Text = "1";
            // 
            // label_Tolerance
            // 
            label_Tolerance.AutoSize = true;
            label_Tolerance.Dock = DockStyle.Top;
            label_Tolerance.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Tolerance.Location = new Point(5, 5);
            label_Tolerance.Margin = new Padding(4, 0, 4, 0);
            label_Tolerance.Name = "label_Tolerance";
            label_Tolerance.Size = new Size(88, 20);
            label_Tolerance.TabIndex = 8;
            label_Tolerance.Text = "Tolerance";
            // 
            // panel_Size
            // 
            panel_Size.Controls.Add(Package);
            panel_Size.Controls.Add(label_Size);
            panel_Size.Location = new Point(375, 0);
            panel_Size.Margin = new Padding(0);
            panel_Size.MinimumSize = new Size(80, 60);
            panel_Size.Name = "panel_Size";
            panel_Size.Padding = new Padding(5);
            panel_Size.Size = new Size(81, 60);
            panel_Size.TabIndex = 29;
            // 
            // Package
            // 
            Package.Dock = DockStyle.Top;
            Package.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Package.FormattingEnabled = true;
            Package.Items.AddRange(new object[] { "0402", "0603", "0805", "1008", "1206", "1210", "1411", "1612", "1806", "1812", "1913", "2010", "2225", "2412", "2416", "2512", "2916", "3119", "3312", "Through" });
            Package.Location = new Point(5, 25);
            Package.Margin = new Padding(4, 5, 4, 5);
            Package.Name = "Package";
            Package.Size = new Size(71, 26);
            Package.TabIndex = 4;
            Package.Text = "0402";
            // 
            // label_Size
            // 
            label_Size.AutoSize = true;
            label_Size.Dock = DockStyle.Top;
            label_Size.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Size.Location = new Point(5, 5);
            label_Size.Margin = new Padding(4, 0, 4, 0);
            label_Size.Name = "label_Size";
            label_Size.Size = new Size(44, 20);
            label_Size.TabIndex = 9;
            label_Size.Text = "Size";
            // 
            // panel_Power
            // 
            panel_Power.Controls.Add(Power);
            panel_Power.Controls.Add(label_Power);
            panel_Power.Location = new Point(456, 0);
            panel_Power.Margin = new Padding(0);
            panel_Power.MinimumSize = new Size(70, 60);
            panel_Power.Name = "panel_Power";
            panel_Power.Padding = new Padding(5);
            panel_Power.Size = new Size(71, 60);
            panel_Power.TabIndex = 32;
            // 
            // Power
            // 
            Power.Dock = DockStyle.Top;
            Power.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Power.FormattingEnabled = true;
            Power.Items.AddRange(new object[] { "1/8", "1/4", "1/2", "3/8", "1", "1.5", "2", "5", "10", "20" });
            Power.Location = new Point(5, 25);
            Power.Margin = new Padding(4, 5, 4, 5);
            Power.Name = "Power";
            Power.Size = new Size(61, 26);
            Power.TabIndex = 5;
            Power.Text = "1/8";
            // 
            // label_Power
            // 
            label_Power.AutoSize = true;
            label_Power.Dock = DockStyle.Top;
            label_Power.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Power.Location = new Point(5, 5);
            label_Power.Margin = new Padding(4, 0, 4, 0);
            label_Power.Name = "label_Power";
            label_Power.Size = new Size(58, 20);
            label_Power.TabIndex = 10;
            label_Power.Text = "Power";
            // 
            // CoversSheetMetals
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "CoversSheetMetals";
            grouper_BaseComponent.ResumeLayout(false);
            grouper_BaseComponent.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
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
        private TextBox Value;
        private Label label_Value;
        private CustomPanelDoubleBuffered panel_Unid;
        private ComboBox Unid;
        private Label label_Unid;
        private CustomPanelDoubleBuffered panel_Tolerance;
        private ComboBox Tolerance;
        private Label label_Tolerance;
        private CustomPanelDoubleBuffered panel_Size;
        private ComboBox Package;
        private Label label_Size;
        private CustomPanelDoubleBuffered panel_Power;
        private ComboBox Power;
        private Label label_Power;
    }
}

namespace MyStuff11net
{
    partial class Speakers
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
            Comment_about_it = new TextBox();
            label_Comment_about_it = new Label();
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
            grouper_BaseComponent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grouper_BaseComponent.Controls.Add(flowLayoutPanel);
            grouper_BaseComponent.Size = new Size(600, 175);
            grouper_BaseComponent.Controls.SetChildIndex(label_DescriptionInformations, 0);
            grouper_BaseComponent.Controls.SetChildIndex(label_DescriptionLabel, 0);
            grouper_BaseComponent.Controls.SetChildIndex(flowLayoutPanel, 0);
            // 
            // label_DescriptionLabel
            // 
            label_DescriptionLabel.Location = new Point(25, 95);
            label_DescriptionLabel.Margin = new Padding(0);
            label_DescriptionLabel.Size = new Size(550, 30);
            // 
            // label_DescriptionInformations
            // 
            label_DescriptionInformations.Location = new Point(25, 125);
            label_DescriptionInformations.Margin = new Padding(0);
            label_DescriptionInformations.Size = new Size(550, 35);
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
            flowLayoutPanel.Size = new Size(550, 70);
            flowLayoutPanel.TabIndex = 27;
            // 
            // panel_Value
            // 
            panel_Value.AutoSize = true;
            panel_Value.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Value.Controls.Add(Value);
            panel_Value.Controls.Add(label_Value);
            panel_Value.Location = new Point(0, 0);
            panel_Value.Margin = new Padding(0);
            panel_Value.MinimumSize = new Size(80, 60);
            panel_Value.Name = "panel_Value";
            panel_Value.Padding = new Padding(5);
            panel_Value.Size = new Size(80, 60);
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
            Value.Size = new Size(70, 26);
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
            panel_Unid.AutoSize = true;
            panel_Unid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Unid.Controls.Add(Unid);
            panel_Unid.Controls.Add(label_Unid);
            panel_Unid.Location = new Point(80, 0);
            panel_Unid.Margin = new Padding(0);
            panel_Unid.MinimumSize = new Size(80, 60);
            panel_Unid.Name = "panel_Unid";
            panel_Unid.Padding = new Padding(5);
            panel_Unid.Size = new Size(80, 60);
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
            Unid.Size = new Size(70, 26);
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
            panel_Tolerance.AutoSize = true;
            panel_Tolerance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Tolerance.Controls.Add(Comment_about_it);
            panel_Tolerance.Controls.Add(label_Comment_about_it);
            panel_Tolerance.Location = new Point(160, 0);
            panel_Tolerance.Margin = new Padding(0);
            panel_Tolerance.MinimumSize = new Size(240, 60);
            panel_Tolerance.Name = "panel_Tolerance";
            panel_Tolerance.Padding = new Padding(5);
            panel_Tolerance.Size = new Size(240, 60);
            panel_Tolerance.TabIndex = 31;
            // 
            // Comment_about_it
            // 
            Comment_about_it.BorderStyle = BorderStyle.FixedSingle;
            Comment_about_it.Dock = DockStyle.Top;
            Comment_about_it.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Comment_about_it.Location = new Point(5, 25);
            Comment_about_it.Margin = new Padding(4, 5, 4, 5);
            Comment_about_it.Name = "Comment_about_it";
            Comment_about_it.Size = new Size(230, 26);
            Comment_about_it.TabIndex = 9;
            // 
            // label_Comment_about_it
            // 
            label_Comment_about_it.AutoSize = true;
            label_Comment_about_it.Dock = DockStyle.Top;
            label_Comment_about_it.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Comment_about_it.Location = new Point(5, 5);
            label_Comment_about_it.Margin = new Padding(4, 0, 4, 0);
            label_Comment_about_it.Name = "label_Comment_about_it";
            label_Comment_about_it.Size = new Size(151, 20);
            label_Comment_about_it.TabIndex = 8;
            label_Comment_about_it.Text = "Comment about it";
            // 
            // panel_Size
            // 
            panel_Size.AutoSize = true;
            panel_Size.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Size.Controls.Add(Package);
            panel_Size.Controls.Add(label_Size);
            panel_Size.Location = new Point(400, 0);
            panel_Size.Margin = new Padding(0);
            panel_Size.MinimumSize = new Size(80, 60);
            panel_Size.Name = "panel_Size";
            panel_Size.Padding = new Padding(5);
            panel_Size.Size = new Size(80, 60);
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
            Package.Size = new Size(70, 26);
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
            panel_Power.AutoSize = true;
            panel_Power.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Power.Controls.Add(Power);
            panel_Power.Controls.Add(label_Power);
            panel_Power.Location = new Point(480, 0);
            panel_Power.Margin = new Padding(0);
            panel_Power.MinimumSize = new Size(70, 60);
            panel_Power.Name = "panel_Power";
            panel_Power.Padding = new Padding(5);
            panel_Power.Size = new Size(70, 60);
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
            Power.Size = new Size(60, 26);
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
            // Speakers
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "Speakers";
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
        private TextBox Value;
        private Label label_Value;
        private CustomPanelDoubleBuffered panel_Unid;
        private ComboBox Unid;
        private Label label_Unid;
        private CustomPanelDoubleBuffered panel_Tolerance;
        private Label label_Comment_about_it;
        private CustomPanelDoubleBuffered panel_Size;
        private ComboBox Package;
        private Label label_Size;
        private CustomPanelDoubleBuffered panel_Power;
        private ComboBox Power;
        private Label label_Power;
        private TextBox Comment_about_it;
    }
}

namespace MyStuff11net
{
    partial class Antennas
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
            panel3 = new CustomPanelDoubleBuffered();
            Value = new TextBox();
            label_Value = new Label();
            panel1 = new CustomPanelDoubleBuffered();
            Unid = new ComboBox();
            label_Unid = new Label();
            panel2 = new CustomPanelDoubleBuffered();
            Package = new ComboBox();
            label_Size = new Label();
            grouper_BaseComponent.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // grouper_BaseComponent
            // 
            grouper_BaseComponent.Controls.Add(flowLayoutPanel);
            grouper_BaseComponent.GroupTitle = "Antennas";
            grouper_BaseComponent.Controls.SetChildIndex(label_DescriptionInformations, 0);
            grouper_BaseComponent.Controls.SetChildIndex(label_DescriptionLabel, 0);
            grouper_BaseComponent.Controls.SetChildIndex(flowLayoutPanel, 0);
            // 
            // label_DescriptionLabel
            // 
            label_DescriptionLabel.Margin = new Padding(9, 10, 9, 10);
            label_DescriptionLabel.Text = "Self-generated Description";
            // 
            // label_DescriptionInformations
            // 
            label_DescriptionInformations.Margin = new Padding(6, 8, 6, 8);
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.Controls.Add(panel3);
            flowLayoutPanel.Controls.Add(panel1);
            flowLayoutPanel.Controls.Add(panel2);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Location = new Point(25, 25);
            flowLayoutPanel.Margin = new Padding(0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(540, 68);
            flowLayoutPanel.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.Controls.Add(Value);
            panel3.Controls.Add(label_Value);
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.MinimumSize = new Size(125, 60);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(5);
            panel3.Size = new Size(125, 60);
            panel3.TabIndex = 33;
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
            // panel1
            // 
            panel1.Controls.Add(Unid);
            panel1.Controls.Add(label_Unid);
            panel1.Location = new Point(125, 0);
            panel1.Margin = new Padding(0);
            panel1.MinimumSize = new Size(125, 60);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(125, 60);
            panel1.TabIndex = 31;
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
            // panel2
            // 
            panel2.Controls.Add(Package);
            panel2.Controls.Add(label_Size);
            panel2.Location = new Point(250, 0);
            panel2.Margin = new Padding(0);
            panel2.MinimumSize = new Size(80, 60);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5);
            panel2.Size = new Size(81, 60);
            panel2.TabIndex = 32;
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
            // Antennas
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "Antennas";
            grouper_BaseComponent.ResumeLayout(false);
            grouper_BaseComponent.PerformLayout();
            flowLayoutPanel.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private CustomPanelDoubleBuffered panel3;
        private TextBox Value;
        private Label label_Value;
        private CustomPanelDoubleBuffered panel1;
        private ComboBox Unid;
        private Label label_Unid;
        private CustomPanelDoubleBuffered panel2;
        private ComboBox Package;
        private Label label_Size;
    }
}

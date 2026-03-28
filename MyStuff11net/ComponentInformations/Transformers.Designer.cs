namespace MyStuff11net
{
    partial class Transformers
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
            Package = new ComboBox();
            label_Package = new Label();
            panel_Tolerance = new CustomPanelDoubleBuffered();
            Tolerance = new ComboBox();
            label_Tolerance = new Label();
            grouper_BaseComponent.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            panel_Value.SuspendLayout();
            panel_Unid.SuspendLayout();
            panel_Tolerance.SuspendLayout();
            SuspendLayout();
            // 
            // grouper_BaseComponent
            // 
            grouper_BaseComponent.Controls.Add(flowLayoutPanel);
            grouper_BaseComponent.MinimumSize = new Size(590, 175);
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
            panel_Unid.AutoSize = true;
            panel_Unid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Unid.Controls.Add(Package);
            panel_Unid.Controls.Add(label_Package);
            panel_Unid.Location = new Point(125, 0);
            panel_Unid.Margin = new Padding(0);
            panel_Unid.MinimumSize = new Size(125, 60);
            panel_Unid.Name = "panel_Unid";
            panel_Unid.Padding = new Padding(5);
            panel_Unid.Size = new Size(125, 60);
            panel_Unid.TabIndex = 28;
            // 
            // Package
            // 
            Package.Dock = DockStyle.Top;
            Package.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Package.FormattingEnabled = true;
            Package.Location = new Point(5, 25);
            Package.Margin = new Padding(4, 5, 4, 5);
            Package.Name = "Package";
            Package.Size = new Size(115, 26);
            Package.TabIndex = 3;
            // 
            // label_Package
            // 
            label_Package.AutoSize = true;
            label_Package.Dock = DockStyle.Top;
            label_Package.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Package.Location = new Point(5, 5);
            label_Package.Margin = new Padding(4, 0, 4, 0);
            label_Package.Name = "label_Package";
            label_Package.Size = new Size(78, 20);
            label_Package.TabIndex = 7;
            label_Package.Text = "Package";
            // 
            // panel_Tolerance
            // 
            panel_Tolerance.AutoSize = true;
            panel_Tolerance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Tolerance.Controls.Add(Tolerance);
            panel_Tolerance.Controls.Add(label_Tolerance);
            panel_Tolerance.Location = new Point(250, 0);
            panel_Tolerance.Margin = new Padding(0);
            panel_Tolerance.MinimumSize = new Size(250, 60);
            panel_Tolerance.Name = "panel_Tolerance";
            panel_Tolerance.Padding = new Padding(5);
            panel_Tolerance.Size = new Size(250, 60);
            panel_Tolerance.TabIndex = 31;
            // 
            // Tolerance
            // 
            Tolerance.Dock = DockStyle.Top;
            Tolerance.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tolerance.FormattingEnabled = true;
            Tolerance.Location = new Point(5, 25);
            Tolerance.Margin = new Padding(4, 5, 4, 5);
            Tolerance.Name = "Tolerance";
            Tolerance.Size = new Size(240, 26);
            Tolerance.TabIndex = 9;
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
            // Transformers
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "Transformers";
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
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private CustomPanelDoubleBuffered panel_Value;
        private TextBox Value;
        private Label label_Value;
        private CustomPanelDoubleBuffered panel_Unid;
        private ComboBox Package;
        private Label label_Package;
        private CustomPanelDoubleBuffered panel_Tolerance;
        private Label label_Tolerance;
        private ComboBox Tolerance;
    }
}

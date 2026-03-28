namespace MyStuff11net
{
    partial class Leds
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
            label_Name_LED = new Label();
            panel_Unid = new CustomPanelDoubleBuffered();
            label_Color_Leds = new Label();
            LedsColor = new ComboBox();
            panel_Tolerance = new CustomPanelDoubleBuffered();
            label_Vr_LED = new Label();
            Vr = new ComboBox();
            panel_Size = new CustomPanelDoubleBuffered();
            If = new ComboBox();
            label_If_LED = new Label();
            panel_Power = new CustomPanelDoubleBuffered();
            Power = new ComboBox();
            label21 = new Label();
            customPanelDoubleBuffered1 = new CustomPanelDoubleBuffered();
            Package = new ComboBox();
            label20 = new Label();
            grouper_BaseComponent.SuspendLayout();
            flowLayoutPanel.SuspendLayout();
            panel_Value.SuspendLayout();
            panel_Unid.SuspendLayout();
            panel_Tolerance.SuspendLayout();
            panel_Size.SuspendLayout();
            panel_Power.SuspendLayout();
            customPanelDoubleBuffered1.SuspendLayout();
            SuspendLayout();
            // 
            // grouper_BaseComponent
            // 
            grouper_BaseComponent.Controls.Add(flowLayoutPanel);
            grouper_BaseComponent.GroupTitle = "Leds";
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
            flowLayoutPanel.Controls.Add(customPanelDoubleBuffered1);
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
            panel_Value.Controls.Add(label_Name_LED);
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
            Name_value.BorderStyle = BorderStyle.None;
            Name_value.Dock = DockStyle.Bottom;
            Name_value.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name_value.Location = new Point(5, 32);
            Name_value.Margin = new Padding(4, 5, 4, 5);
            Name_value.Name = "Name_value";
            Name_value.Size = new Size(90, 23);
            Name_value.TabIndex = 17;
            // 
            // label_Name_LED
            // 
            label_Name_LED.AutoSize = true;
            label_Name_LED.Dock = DockStyle.Top;
            label_Name_LED.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Name_LED.Location = new Point(5, 5);
            label_Name_LED.Margin = new Padding(4, 0, 4, 0);
            label_Name_LED.Name = "label_Name_LED";
            label_Name_LED.Size = new Size(55, 20);
            label_Name_LED.TabIndex = 16;
            label_Name_LED.Text = "Name";
            // 
            // panel_Unid
            // 
            panel_Unid.AutoSize = true;
            panel_Unid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Unid.Controls.Add(label_Color_Leds);
            panel_Unid.Controls.Add(LedsColor);
            panel_Unid.Location = new Point(100, 0);
            panel_Unid.Margin = new Padding(0);
            panel_Unid.MinimumSize = new Size(100, 60);
            panel_Unid.Name = "panel_Unid";
            panel_Unid.Padding = new Padding(5);
            panel_Unid.Size = new Size(100, 60);
            panel_Unid.TabIndex = 28;
            // 
            // label_Color_Leds
            // 
            label_Color_Leds.AutoSize = true;
            label_Color_Leds.Dock = DockStyle.Top;
            label_Color_Leds.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Color_Leds.Location = new Point(5, 5);
            label_Color_Leds.Margin = new Padding(4, 0, 4, 0);
            label_Color_Leds.Name = "label_Color_Leds";
            label_Color_Leds.Size = new Size(51, 20);
            label_Color_Leds.TabIndex = 24;
            label_Color_Leds.Text = "Color";
            // 
            // LedsColor
            // 
            LedsColor.Dock = DockStyle.Bottom;
            LedsColor.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LedsColor.FormattingEnabled = true;
            LedsColor.Items.AddRange(new object[] { "Green", "Yellow", "Red", "Blue", "Amber", "Bicolor Red/Green", "Tricolor Red/Green/Blue" });
            LedsColor.Location = new Point(5, 29);
            LedsColor.Margin = new Padding(4, 5, 4, 5);
            LedsColor.Name = "LedsColor";
            LedsColor.Size = new Size(90, 26);
            LedsColor.TabIndex = 23;
            // 
            // panel_Tolerance
            // 
            panel_Tolerance.AutoSize = true;
            panel_Tolerance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Tolerance.Controls.Add(label_Vr_LED);
            panel_Tolerance.Controls.Add(Vr);
            panel_Tolerance.Location = new Point(200, 0);
            panel_Tolerance.Margin = new Padding(0);
            panel_Tolerance.MinimumSize = new Size(100, 60);
            panel_Tolerance.Name = "panel_Tolerance";
            panel_Tolerance.Padding = new Padding(5);
            panel_Tolerance.Size = new Size(100, 60);
            panel_Tolerance.TabIndex = 31;
            // 
            // label_Vr_LED
            // 
            label_Vr_LED.AutoSize = true;
            label_Vr_LED.Dock = DockStyle.Top;
            label_Vr_LED.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_Vr_LED.Location = new Point(5, 5);
            label_Vr_LED.Margin = new Padding(4, 0, 4, 0);
            label_Vr_LED.Name = "label_Vr_LED";
            label_Vr_LED.Size = new Size(27, 20);
            label_Vr_LED.TabIndex = 22;
            label_Vr_LED.Text = "Vr";
            // 
            // Vr
            // 
            Vr.Dock = DockStyle.Bottom;
            Vr.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Vr.FormattingEnabled = true;
            Vr.Items.AddRange(new object[] { "2", "3", "5", "7", "9", "12", "15", "17", "19" });
            Vr.Location = new Point(5, 29);
            Vr.Margin = new Padding(4, 5, 4, 5);
            Vr.Name = "Vr";
            Vr.Size = new Size(90, 26);
            Vr.TabIndex = 21;
            // 
            // panel_Size
            // 
            panel_Size.AutoSize = true;
            panel_Size.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Size.Controls.Add(If);
            panel_Size.Controls.Add(label_If_LED);
            panel_Size.Location = new Point(300, 0);
            panel_Size.Margin = new Padding(0);
            panel_Size.MinimumSize = new Size(80, 60);
            panel_Size.Name = "panel_Size";
            panel_Size.Padding = new Padding(5);
            panel_Size.Size = new Size(80, 60);
            panel_Size.TabIndex = 29;
            // 
            // If
            // 
            If.Dock = DockStyle.Bottom;
            If.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            If.FormattingEnabled = true;
            If.Items.AddRange(new object[] { "0.01", "0.02", "0.03", "0.04", "0.05", "0.06", "0.07", "0.08" });
            If.Location = new Point(5, 29);
            If.Margin = new Padding(4, 5, 4, 5);
            If.Name = "If";
            If.Size = new Size(70, 26);
            If.TabIndex = 18;
            // 
            // label_If_LED
            // 
            label_If_LED.AutoSize = true;
            label_If_LED.Dock = DockStyle.Top;
            label_If_LED.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label_If_LED.Location = new Point(5, 5);
            label_If_LED.Margin = new Padding(4, 0, 4, 0);
            label_If_LED.Name = "label_If_LED";
            label_If_LED.Size = new Size(21, 20);
            label_If_LED.TabIndex = 17;
            label_If_LED.Text = "If";
            // 
            // panel_Power
            // 
            panel_Power.AutoSize = true;
            panel_Power.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel_Power.Controls.Add(Power);
            panel_Power.Controls.Add(label21);
            panel_Power.Location = new Point(380, 0);
            panel_Power.Margin = new Padding(0);
            panel_Power.MinimumSize = new Size(70, 60);
            panel_Power.Name = "panel_Power";
            panel_Power.Padding = new Padding(5);
            panel_Power.Size = new Size(70, 60);
            panel_Power.TabIndex = 32;
            // 
            // Power
            // 
            Power.Dock = DockStyle.Bottom;
            Power.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Power.FormattingEnabled = true;
            Power.Items.AddRange(new object[] { "0.05", "0.075", "0.1", "0.125", "0.135", "0.150" });
            Power.Location = new Point(5, 29);
            Power.Margin = new Padding(4, 5, 4, 5);
            Power.Name = "Power";
            Power.Size = new Size(60, 26);
            Power.TabIndex = 19;
            Power.Text = "1/8";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Dock = DockStyle.Top;
            label21.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label21.Location = new Point(5, 5);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(58, 20);
            label21.TabIndex = 18;
            label21.Text = "Power";
            // 
            // customPanelDoubleBuffered1
            // 
            customPanelDoubleBuffered1.AutoSize = true;
            customPanelDoubleBuffered1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            customPanelDoubleBuffered1.Controls.Add(Package);
            customPanelDoubleBuffered1.Controls.Add(label20);
            customPanelDoubleBuffered1.Location = new Point(450, 0);
            customPanelDoubleBuffered1.Margin = new Padding(0);
            customPanelDoubleBuffered1.MinimumSize = new Size(80, 60);
            customPanelDoubleBuffered1.Name = "customPanelDoubleBuffered1";
            customPanelDoubleBuffered1.Padding = new Padding(5);
            customPanelDoubleBuffered1.Size = new Size(80, 60);
            customPanelDoubleBuffered1.TabIndex = 33;
            // 
            // Package
            // 
            Package.Dock = DockStyle.Bottom;
            Package.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Package.FormattingEnabled = true;
            Package.Items.AddRange(new object[] { "T1", "T1 3/4", "Square", "Through", "Display", "LCD Module", "0402", "0603", "0805", "1008", "1206", "1210", "1411", "1612", "1806", "1812", "1913", "2010", "2225", "2412", "2416", "2512", "2916", "3119", "3312" });
            Package.Location = new Point(5, 29);
            Package.Margin = new Padding(4, 5, 4, 5);
            Package.Name = "Package";
            Package.Size = new Size(70, 26);
            Package.TabIndex = 20;
            Package.Text = "0402";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Dock = DockStyle.Top;
            label20.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label20.Location = new Point(5, 5);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(44, 20);
            label20.TabIndex = 19;
            label20.Text = "Size";
            // 
            // Leds
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "Leds";
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
            customPanelDoubleBuffered1.ResumeLayout(false);
            customPanelDoubleBuffered1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel;
        private CustomPanelDoubleBuffered panel_Value;
        private TextBox Name_value;
        private Label label_Name_LED;
        private CustomPanelDoubleBuffered panel_Unid;
        private Label label_Color_Leds;
        private ComboBox LedsColor;
        private CustomPanelDoubleBuffered panel_Tolerance;
        private Label label_Vr_LED;
        private ComboBox Vr;
        private CustomPanelDoubleBuffered panel_Size;
        private CustomPanelDoubleBuffered panel_Power;
        private ComboBox If;
        private Label label_If_LED;
        private ComboBox Power;
        private Label label21;
        private CustomPanelDoubleBuffered customPanelDoubleBuffered1;
        private ComboBox Package;
        private Label label20;
    }
}

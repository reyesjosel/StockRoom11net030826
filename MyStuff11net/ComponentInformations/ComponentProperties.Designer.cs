namespace MyStuff11net.Received_Components
{
    partial class ComponentProperties
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
            grouper_ComponentProperties = new CodeVendor.Controls.Grouper();
            flowLayoutPanel_ComBoxComponentsProperties = new System.Windows.Forms.FlowLayoutPanel();
            comboBox_PartNumber = new System.Windows.Forms.ComboBox();
       //     textBox_Received_Quantity = new AMS.TextBox.NumericTextBox();
            dateTimePicker = new System.Windows.Forms.DateTimePicker();
            panel_LabelsComponentsProperties = new System.Windows.Forms.Panel();
            label_PartNumber = new System.Windows.Forms.Label();
            label_Received_Quantity = new System.Windows.Forms.Label();
            label_Received_Date = new System.Windows.Forms.Label();
            grouper_ComponentProperties.SuspendLayout();
            flowLayoutPanel_ComBoxComponentsProperties.SuspendLayout();
            panel_LabelsComponentsProperties.SuspendLayout();
            SuspendLayout();
            // 
            // grouper_ComponentProperties
            // 
            grouper_ComponentProperties.AutoSize = true;
            grouper_ComponentProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            grouper_ComponentProperties.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            grouper_ComponentProperties.BackgroundGradientColor = System.Drawing.Color.LightGray;
            grouper_ComponentProperties.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_ComponentProperties.BorderColor = System.Drawing.Color.Black;
            grouper_ComponentProperties.BorderThickness = 1F;
            grouper_ComponentProperties.Controls.Add(flowLayoutPanel_ComBoxComponentsProperties);
            grouper_ComponentProperties.Controls.Add(panel_LabelsComponentsProperties);
            grouper_ComponentProperties.CustomGroupBoxColor = System.Drawing.Color.White;
            grouper_ComponentProperties.Dock = System.Windows.Forms.DockStyle.Top;
            grouper_ComponentProperties.GroupImage = null;
            grouper_ComponentProperties.GroupTitle = "Component Properties";
            grouper_ComponentProperties.Location = new System.Drawing.Point(0, 0);
            grouper_ComponentProperties.Margin = new System.Windows.Forms.Padding(4);
            grouper_ComponentProperties.Name = "grouper_ComponentProperties";
            grouper_ComponentProperties.Padding = new System.Windows.Forms.Padding(20, 25, 20, 10);
            grouper_ComponentProperties.PaintGroupBox = false;
            grouper_ComponentProperties.RoundCorners = 10;
            grouper_ComponentProperties.ShadowColor = System.Drawing.Color.DarkGray;
            grouper_ComponentProperties.ShadowControl = false;
            grouper_ComponentProperties.ShadowThickness = 3;
            grouper_ComponentProperties.Size = new System.Drawing.Size(650, 90);
            grouper_ComponentProperties.TabIndex = 21;
            // 
            // flowLayoutPanel_ComBoxComponentsProperties
            // 
            flowLayoutPanel_ComBoxComponentsProperties.Controls.Add(comboBox_PartNumber);
       //     flowLayoutPanel_ComBoxComponentsProperties.Controls.Add(textBox_Received_Quantity);
            flowLayoutPanel_ComBoxComponentsProperties.Controls.Add(dateTimePicker);
            flowLayoutPanel_ComBoxComponentsProperties.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel_ComBoxComponentsProperties.Location = new System.Drawing.Point(20, 47);
            flowLayoutPanel_ComBoxComponentsProperties.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel_ComBoxComponentsProperties.Name = "flowLayoutPanel_ComBoxComponentsProperties";
            flowLayoutPanel_ComBoxComponentsProperties.Size = new System.Drawing.Size(610, 33);
            flowLayoutPanel_ComBoxComponentsProperties.TabIndex = 7;
            // 
            // comboBox_PartNumber
            // 
            comboBox_PartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            comboBox_PartNumber.FormattingEnabled = true;
            comboBox_PartNumber.Location = new System.Drawing.Point(3, 3);
            comboBox_PartNumber.Name = "comboBox_PartNumber";
            comboBox_PartNumber.Size = new System.Drawing.Size(150, 26);
            comboBox_PartNumber.TabIndex = 1;
            // 
            // textBox_Received_Quantity
            /*
            textBox_Received_Quantity.AllowNegative = false;
            textBox_Received_Quantity.DigitsInGroup = 0;
            textBox_Received_Quantity.Flags = 65536;
            textBox_Received_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox_Received_Quantity.Location = new System.Drawing.Point(159, 3);
            textBox_Received_Quantity.MaxDecimalPlaces = 0;
            textBox_Received_Quantity.MaxWholeDigits = 9;
            textBox_Received_Quantity.Name = "textBox_Received_Quantity";
            textBox_Received_Quantity.Prefix = "";
            textBox_Received_Quantity.RangeMax = 1.7976931348623157E+308D;
            textBox_Received_Quantity.RangeMin = -1.7976931348623157E+308D;
            textBox_Received_Quantity.Size = new System.Drawing.Size(130, 26);
            textBox_Received_Quantity.TabIndex = 1;
            textBox_Received_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            */ 
            // dateTimePicker
            // 
            dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dateTimePicker.Location = new System.Drawing.Point(295, 3);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new System.Drawing.Size(296, 26);
            dateTimePicker.TabIndex = 4;
            // 
            // panel_LabelsComponentsProperties
            // 
            panel_LabelsComponentsProperties.AutoSize = true;
            panel_LabelsComponentsProperties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel_LabelsComponentsProperties.Controls.Add(label_PartNumber);
            panel_LabelsComponentsProperties.Controls.Add(label_Received_Quantity);
            panel_LabelsComponentsProperties.Controls.Add(label_Received_Date);
            panel_LabelsComponentsProperties.Dock = System.Windows.Forms.DockStyle.Top;
            panel_LabelsComponentsProperties.Location = new System.Drawing.Point(20, 25);
            panel_LabelsComponentsProperties.Margin = new System.Windows.Forms.Padding(0);
            panel_LabelsComponentsProperties.Name = "panel_LabelsComponentsProperties";
            panel_LabelsComponentsProperties.Size = new System.Drawing.Size(610, 22);
            panel_LabelsComponentsProperties.TabIndex = 6;
            // 
            // label_PartNumber
            // 
            label_PartNumber.AutoSize = true;
            label_PartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_PartNumber.Location = new System.Drawing.Point(3, 6);
            label_PartNumber.Margin = new System.Windows.Forms.Padding(3);
            label_PartNumber.Name = "label_PartNumber";
            label_PartNumber.Size = new System.Drawing.Size(77, 13);
            label_PartNumber.TabIndex = 0;
            label_PartNumber.Text = "Part Number";
            // 
            // label_Received_Quantity
            // 
            label_Received_Quantity.AutoSize = true;
            label_Received_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_Received_Quantity.Location = new System.Drawing.Point(158, 6);
            label_Received_Quantity.Margin = new System.Windows.Forms.Padding(3);
            label_Received_Quantity.Name = "label_Received_Quantity";
            label_Received_Quantity.Size = new System.Drawing.Size(113, 13);
            label_Received_Quantity.TabIndex = 2;
            label_Received_Quantity.Text = "Amounts Received";
            // 
            // label_Received_Date
            // 
            label_Received_Date.AutoSize = true;
            label_Received_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_Received_Date.Location = new System.Drawing.Point(372, 6);
            label_Received_Date.Margin = new System.Windows.Forms.Padding(3);
            label_Received_Date.Name = "label_Received_Date";
            label_Received_Date.Size = new System.Drawing.Size(85, 13);
            label_Received_Date.TabIndex = 5;
            label_Received_Date.Text = "Recived Date";
            // 
            // ComponentProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(grouper_ComponentProperties);
            MinimumSize = new System.Drawing.Size(650, 90);
            Name = "ComponentProperties";
            Size = new System.Drawing.Size(650, 90);
            grouper_ComponentProperties.ResumeLayout(false);
            grouper_ComponentProperties.PerformLayout();
            flowLayoutPanel_ComBoxComponentsProperties.ResumeLayout(false);
            flowLayoutPanel_ComBoxComponentsProperties.PerformLayout();
            panel_LabelsComponentsProperties.ResumeLayout(false);
            panel_LabelsComponentsProperties.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private CodeVendor.Controls.Grouper grouper_ComponentProperties;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_ComBoxComponentsProperties;
        private System.Windows.Forms.ComboBox comboBox_PartNumber;
    //    private AMS.TextBox.NumericTextBox textBox_Received_Quantity;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Panel panel_LabelsComponentsProperties;
        private System.Windows.Forms.Label label_PartNumber;
        private System.Windows.Forms.Label label_Received_Quantity;
        private System.Windows.Forms.Label label_Received_Date;
    }
}

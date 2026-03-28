namespace MyStuff11net
{
    partial class PrintingReferences
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
            grouper_PrintingReferences = new CodeVendor.Controls.Grouper();
            checkBox_printLabels = new CheckBox();
            panel_EnablePrints = new Panel();
            panel_Reels = new Panel();
            panel1 = new Panel();
            label_DescriptionToPrint = new Label();
            textBox_DescriptionToPrint = new TextBox();
            grouper_BarCodeRegion = new CodeVendor.Controls.Grouper();
            label_LabelInformation = new Label();
            grouper_LabelBarCode = new CodeVendor.Controls.Grouper();
            label_Description = new Label();
            label_HumanReadableInformation = new Label();
            pictureBox_BarCode_Image = new PictureBox();
            grouper_PrintingReferences.SuspendLayout();
            panel_EnablePrints.SuspendLayout();
            panel_Reels.SuspendLayout();
            panel1.SuspendLayout();
            grouper_BarCodeRegion.SuspendLayout();
            grouper_LabelBarCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_BarCode_Image).BeginInit();
            SuspendLayout();
            // 
            // grouper_PrintingReferences
            // 
            grouper_PrintingReferences.BackgroundColor = Color.WhiteSmoke;
            grouper_PrintingReferences.BackgroundGradientColor = SystemColors.Control;
            grouper_PrintingReferences.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_PrintingReferences.BorderColor = Color.Black;
            grouper_PrintingReferences.BorderThickness = 1F;
            grouper_PrintingReferences.Controls.Add(checkBox_printLabels);
            grouper_PrintingReferences.Controls.Add(panel_EnablePrints);
            grouper_PrintingReferences.CustomGroupBoxColor = Color.White;
            grouper_PrintingReferences.Dock = DockStyle.Fill;
            grouper_PrintingReferences.GroupImage = null;
            grouper_PrintingReferences.GroupTitle = "Printing References";
            grouper_PrintingReferences.Location = new Point(0, 0);
            grouper_PrintingReferences.MinimumSize = new Size(0, 150);
            grouper_PrintingReferences.Name = "grouper_PrintingReferences";
            grouper_PrintingReferences.Padding = new Padding(1, 0, 0, 1);
            grouper_PrintingReferences.PaintGroupBox = false;
            grouper_PrintingReferences.RoundCorners = 10;
            grouper_PrintingReferences.ShadowColor = Color.DarkGray;
            grouper_PrintingReferences.ShadowControl = false;
            grouper_PrintingReferences.ShadowThickness = 3;
            grouper_PrintingReferences.Size = new Size(500, 175);
            grouper_PrintingReferences.TabIndex = 20;
            // 
            // checkBox_printLabels
            // 
            checkBox_printLabels.AutoSize = true;
            checkBox_printLabels.Checked = true;
            checkBox_printLabels.CheckState = CheckState.Checked;
            checkBox_printLabels.Location = new Point(15, 48);
            checkBox_printLabels.Margin = new Padding(4, 5, 4, 5);
            checkBox_printLabels.Name = "checkBox_printLabels";
            checkBox_printLabels.Size = new Size(121, 25);
            checkBox_printLabels.TabIndex = 51;
            checkBox_printLabels.Text = "Print Labels ?";
            checkBox_printLabels.UseVisualStyleBackColor = true;
            // 
            // panel_EnablePrints
            // 
            panel_EnablePrints.Controls.Add(panel_Reels);
            panel_EnablePrints.Controls.Add(grouper_BarCodeRegion);
            panel_EnablePrints.Dock = DockStyle.Fill;
            panel_EnablePrints.Location = new Point(1, 0);
            panel_EnablePrints.Margin = new Padding(0);
            panel_EnablePrints.Name = "panel_EnablePrints";
            panel_EnablePrints.Size = new Size(499, 174);
            panel_EnablePrints.TabIndex = 58;
            // 
            // panel_Reels
            // 
            panel_Reels.Controls.Add(panel1);
            panel_Reels.Dock = DockStyle.Fill;
            panel_Reels.Location = new Point(0, 0);
            panel_Reels.Margin = new Padding(0);
            panel_Reels.Name = "panel_Reels";
            panel_Reels.Padding = new Padding(5);
            panel_Reels.Size = new Size(184, 174);
            panel_Reels.TabIndex = 57;
            // 
            // panel1
            // 
            panel1.Controls.Add(label_DescriptionToPrint);
            panel1.Controls.Add(textBox_DescriptionToPrint);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(5, 97);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(174, 72);
            panel1.TabIndex = 55;
            // 
            // label_DescriptionToPrint
            // 
            label_DescriptionToPrint.AutoSize = true;
            label_DescriptionToPrint.Dock = DockStyle.Top;
            label_DescriptionToPrint.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DescriptionToPrint.Location = new Point(10, 10);
            label_DescriptionToPrint.Margin = new Padding(0);
            label_DescriptionToPrint.Name = "label_DescriptionToPrint";
            label_DescriptionToPrint.Size = new Size(139, 17);
            label_DescriptionToPrint.TabIndex = 53;
            label_DescriptionToPrint.Text = "Description to print...";
            // 
            // textBox_DescriptionToPrint
            // 
            textBox_DescriptionToPrint.Dock = DockStyle.Bottom;
            textBox_DescriptionToPrint.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_DescriptionToPrint.Location = new Point(10, 36);
            textBox_DescriptionToPrint.Margin = new Padding(4, 5, 4, 5);
            textBox_DescriptionToPrint.Name = "textBox_DescriptionToPrint";
            textBox_DescriptionToPrint.Size = new Size(154, 26);
            textBox_DescriptionToPrint.TabIndex = 54;
            // 
            // grouper_BarCodeRegion
            // 
            grouper_BarCodeRegion.BackgroundColor = Color.WhiteSmoke;
            grouper_BarCodeRegion.BackgroundGradientColor = Color.LightGray;
            grouper_BarCodeRegion.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_BarCodeRegion.BorderColor = Color.Black;
            grouper_BarCodeRegion.BorderThickness = 1F;
            grouper_BarCodeRegion.Controls.Add(label_LabelInformation);
            grouper_BarCodeRegion.Controls.Add(grouper_LabelBarCode);
            grouper_BarCodeRegion.CustomGroupBoxColor = Color.White;
            grouper_BarCodeRegion.Dock = DockStyle.Right;
            grouper_BarCodeRegion.GroupImage = null;
            grouper_BarCodeRegion.GroupTitle = "";
            grouper_BarCodeRegion.Location = new Point(184, 0);
            grouper_BarCodeRegion.Margin = new Padding(0);
            grouper_BarCodeRegion.MinimumSize = new Size(250, 125);
            grouper_BarCodeRegion.Name = "grouper_BarCodeRegion";
            grouper_BarCodeRegion.Padding = new Padding(8);
            grouper_BarCodeRegion.PaintGroupBox = false;
            grouper_BarCodeRegion.RoundCorners = 10;
            grouper_BarCodeRegion.ShadowColor = Color.DarkGray;
            grouper_BarCodeRegion.ShadowControl = false;
            grouper_BarCodeRegion.ShadowThickness = 3;
            grouper_BarCodeRegion.Size = new Size(315, 174);
            grouper_BarCodeRegion.TabIndex = 55;
            // 
            // label_LabelInformation
            // 
            label_LabelInformation.AutoSize = true;
            label_LabelInformation.Font = new Font("Microsoft Sans Serif", 7F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label_LabelInformation.Location = new Point(65, 151);
            label_LabelInformation.Margin = new Padding(4, 0, 4, 0);
            label_LabelInformation.Name = "label_LabelInformation";
            label_LabelInformation.Size = new Size(163, 13);
            label_LabelInformation.TabIndex = 21;
            label_LabelInformation.Text = "Label type: Brady, THT-37-483-10";
            // 
            // grouper_LabelBarCode
            // 
            grouper_LabelBarCode.BackgroundColor = Color.White;
            grouper_LabelBarCode.BackgroundGradientColor = Color.White;
            grouper_LabelBarCode.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            grouper_LabelBarCode.BorderColor = Color.Black;
            grouper_LabelBarCode.BorderThickness = 1F;
            grouper_LabelBarCode.Controls.Add(label_Description);
            grouper_LabelBarCode.Controls.Add(label_HumanReadableInformation);
            grouper_LabelBarCode.Controls.Add(pictureBox_BarCode_Image);
            grouper_LabelBarCode.CustomGroupBoxColor = Color.White;
            grouper_LabelBarCode.Dock = DockStyle.Top;
            grouper_LabelBarCode.GroupImage = null;
            grouper_LabelBarCode.GroupTitle = "";
            grouper_LabelBarCode.Location = new Point(8, 8);
            grouper_LabelBarCode.Margin = new Padding(4, 5, 4, 5);
            grouper_LabelBarCode.Name = "grouper_LabelBarCode";
            grouper_LabelBarCode.Padding = new Padding(30, 32, 30, 32);
            grouper_LabelBarCode.PaintGroupBox = false;
            grouper_LabelBarCode.RoundCorners = 10;
            grouper_LabelBarCode.ShadowColor = Color.DarkGray;
            grouper_LabelBarCode.ShadowControl = false;
            grouper_LabelBarCode.ShadowThickness = 3;
            grouper_LabelBarCode.Size = new Size(299, 136);
            grouper_LabelBarCode.TabIndex = 19;
            // 
            // label_Description
            // 
            label_Description.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Description.Location = new Point(4, 97);
            label_Description.Margin = new Padding(0);
            label_Description.Name = "label_Description";
            label_Description.Size = new Size(304, 29);
            label_Description.TabIndex = 21;
            label_Description.Text = "Description field.";
            label_Description.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_HumanReadableInformation
            // 
            label_HumanReadableInformation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_HumanReadableInformation.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_HumanReadableInformation.Location = new Point(21, 69);
            label_HumanReadableInformation.Margin = new Padding(4, 0, 4, 0);
            label_HumanReadableInformation.Name = "label_HumanReadableInformation";
            label_HumanReadableInformation.Size = new Size(243, 24);
            label_HumanReadableInformation.TabIndex = 20;
            label_HumanReadableInformation.Text = "Human Readable Information.";
            label_HumanReadableInformation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox_BarCode_Image
            // 
            pictureBox_BarCode_Image.BackColor = Color.White;
            pictureBox_BarCode_Image.Location = new Point(4, 23);
            pictureBox_BarCode_Image.Margin = new Padding(4, 5, 4, 5);
            pictureBox_BarCode_Image.Name = "pictureBox_BarCode_Image";
            pictureBox_BarCode_Image.Size = new Size(291, 42);
            pictureBox_BarCode_Image.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_BarCode_Image.TabIndex = 14;
            pictureBox_BarCode_Image.TabStop = false;
            // 
            // PrintingReferences
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grouper_PrintingReferences);
            DoubleBuffered = true;
            Margin = new Padding(0);
            MinimumSize = new Size(500, 175);
            Name = "PrintingReferences";
            Size = new Size(500, 175);
            grouper_PrintingReferences.ResumeLayout(false);
            grouper_PrintingReferences.PerformLayout();
            panel_EnablePrints.ResumeLayout(false);
            panel_Reels.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grouper_BarCodeRegion.ResumeLayout(false);
            grouper_BarCodeRegion.PerformLayout();
            grouper_LabelBarCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_BarCode_Image).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private CodeVendor.Controls.Grouper grouper_PrintingReferences;
        private System.Windows.Forms.TextBox textBox_DescriptionToPrint;
        private System.Windows.Forms.Label label_DescriptionToPrint;
        private CodeVendor.Controls.Grouper grouper_LabelBarCode;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Label label_HumanReadableInformation;
        private System.Windows.Forms.PictureBox pictureBox_BarCode_Image;
        private System.Windows.Forms.Label label_LabelInformation;
        private CodeVendor.Controls.Grouper grouper_BarCodeRegion;
        private System.Windows.Forms.Panel panel_Reels;
        private System.Windows.Forms.Panel panel_EnablePrints;
        protected System.Windows.Forms.CheckBox checkBox_printLabels;
        private Panel panel1;
    }
}

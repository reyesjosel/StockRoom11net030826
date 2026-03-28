namespace MyStuff11net
{
    partial class ComboBoxExtended
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
            comboBox = new System.Windows.Forms.ComboBox();
            label = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // comboBox
            // 
            comboBox.Dock = System.Windows.Forms.DockStyle.Top;
            comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            comboBox.FormattingEnabled = true;
            comboBox.Location = new System.Drawing.Point(0, 22);
            comboBox.Name = "comboBox";
            comboBox.Size = new System.Drawing.Size(60, 23);
            comboBox.TabIndex = 0;
            // 
            // label
            // 
            label.Dock = System.Windows.Forms.DockStyle.Top;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.Location = new System.Drawing.Point(0, 0);
            label.Name = "label";
            label.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            label.Size = new System.Drawing.Size(60, 22);
            label.TabIndex = 1;
            label.Text = "label1";
            // 
            // ComboBoxExtended
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(comboBox);
            Controls.Add(label);
            MinimumSize = new System.Drawing.Size(60, 45);
            Name = "ComboBoxExtended";
            Size = new System.Drawing.Size(60, 45);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label;
    }
}

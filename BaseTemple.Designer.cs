using System.Drawing;

namespace StockRoom11net
{
    partial class BaseTemple
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
                components.Dispose();

            if (_cache != null)
                _cache.Dispose();
            if(dataGridViewExtendedBase != null)
                dataGridViewExtendedBase.Dispose();
            if (thumbViewerBasePictures != null)
                thumbViewerBasePictures.Dispose();           
            if (_currentColumnActive != null)
                _currentColumnActive.Dispose();
            if (_tooltip != null)
                _tooltip.Dispose();

            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Bottom;
            richTextBox1.Location = new Point(0, 268);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(775, 154);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // BaseTemple
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 422);
            ControlBox = false;
            Controls.Add(richTextBox1);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BaseTemple";
            Text = "BaseTemple";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
    }
}
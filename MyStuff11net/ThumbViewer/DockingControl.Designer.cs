namespace MyStuff11net
{
    partial class DockingControl
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
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            thumbNail1 = new MyStuff11net.ThumbNail();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(thumbNail1);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(650, 106);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // thumbNail1
            // 
            thumbNail1.BackColor = System.Drawing.SystemColors.Window;
            thumbNail1.Location = new System.Drawing.Point(3, 3);
            thumbNail1.MaximumSize = new System.Drawing.Size(125, 125);
            thumbNail1.MinimumSize = new System.Drawing.Size(100, 100);
            thumbNail1.Name = "thumbNail1";
            thumbNail1.Size = new System.Drawing.Size(100, 100);
            thumbNail1.TabIndex = 0;
            // 
            // DockingControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Name = "DockingControl";
            Size = new System.Drawing.Size(650, 106);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ThumbNail thumbNail1;











    }
}

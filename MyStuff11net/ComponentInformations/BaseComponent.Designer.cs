namespace MyStuff11net
{
    partial class BaseComponent
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
            grouper_BaseComponent = new CodeVendor.Controls.Grouper();
            label_DescriptionLabel = new Label();
            label_DescriptionInformations = new Label();
            grouper_BaseComponent.SuspendLayout();
            SuspendLayout();
            // 
            // grouper_BaseComponent
            // 
            grouper_BaseComponent.AutoSize = true;
            grouper_BaseComponent.BackgroundColor = SystemColors.ButtonHighlight;
            grouper_BaseComponent.BackgroundGradientColor = Color.LightGray;
            grouper_BaseComponent.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.Vertical;
            grouper_BaseComponent.BorderColor = Color.Black;
            grouper_BaseComponent.BorderThickness = 1F;
            grouper_BaseComponent.Controls.Add(label_DescriptionLabel);
            grouper_BaseComponent.Controls.Add(label_DescriptionInformations);
            grouper_BaseComponent.CustomGroupBoxColor = Color.White;
            grouper_BaseComponent.Dock = DockStyle.Fill;
            grouper_BaseComponent.GroupImage = null;
            grouper_BaseComponent.GroupTitle = "Undefined";
            grouper_BaseComponent.Location = new Point(0, 0);
            grouper_BaseComponent.Margin = new Padding(0);
            grouper_BaseComponent.Name = "grouper_BaseComponent";
            grouper_BaseComponent.Padding = new Padding(25, 25, 25, 15);
            grouper_BaseComponent.PaintGroupBox = false;
            grouper_BaseComponent.RoundCorners = 10;
            grouper_BaseComponent.ShadowColor = Color.DarkGray;
            grouper_BaseComponent.ShadowControl = false;
            grouper_BaseComponent.ShadowThickness = 3;
            grouper_BaseComponent.Size = new Size(590, 175);
            grouper_BaseComponent.TabIndex = 0;
            // 
            // label_DescriptionLabel
            // 
            label_DescriptionLabel.Dock = DockStyle.Bottom;
            label_DescriptionLabel.Location = new Point(25, 93);
            label_DescriptionLabel.Margin = new Padding(6);
            label_DescriptionLabel.Name = "label_DescriptionLabel";
            label_DescriptionLabel.Padding = new Padding(0, 10, 0, 0);
            label_DescriptionLabel.Size = new Size(540, 30);
            label_DescriptionLabel.TabIndex = 0;
            label_DescriptionLabel.Text = "GUI for this component has not been defined, see the information in component definition for assistance.";
            // 
            // label_DescriptionInformations
            // 
            label_DescriptionInformations.Dock = DockStyle.Bottom;
            label_DescriptionInformations.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DescriptionInformations.Location = new Point(25, 123);
            label_DescriptionInformations.Margin = new Padding(4, 5, 4, 5);
            label_DescriptionInformations.Name = "label_DescriptionInformations";
            label_DescriptionInformations.Padding = new Padding(0, 5, 0, 0);
            label_DescriptionInformations.Size = new Size(540, 37);
            label_DescriptionInformations.TabIndex = 26;
            label_DescriptionInformations.Text = "012345678910123456789012345678901234567890";
            label_DescriptionInformations.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BaseComponent
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(grouper_BaseComponent);
            Margin = new Padding(0);
            MinimumSize = new Size(590, 175);
            Name = "BaseComponent";
            Size = new Size(590, 175);
            grouper_BaseComponent.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        public CodeVendor.Controls.Grouper grouper_BaseComponent;
        public System.Windows.Forms.Label label_DescriptionLabel;
        public System.Windows.Forms.Label label_DescriptionInformations;

    }
}

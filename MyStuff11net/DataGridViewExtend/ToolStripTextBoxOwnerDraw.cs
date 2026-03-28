using System.ComponentModel;

namespace MyStuff11net.DataGridViewExtended
{
    public partial class ToolStripTextBoxOwnerDraw : ToolStripControlHost
    {
        private TextBoxOwnerDraw InnerTextBox
        {
            get { return Control as TextBoxOwnerDraw; }
        }

        public ToolStripTextBoxOwnerDraw() : base(new TextBoxOwnerDraw()) { }

        public TextBox ToolStripTextBox
        {
            get { return InnerTextBox.TextBox; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CornerRadius
        {
            get { return InnerTextBox.CornerRadius; }
            set
            {
                InnerTextBox.CornerRadius = value;
                InnerTextBox.Invalidate();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return InnerTextBox.BorderColor; }
            set
            {
                InnerTextBox.BorderColor = value;
                InnerTextBox.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderSize
        {
            get { return InnerTextBox.BorderSize; }
            set
            {
                InnerTextBox.BorderSize = value;
                InnerTextBox.Invalidate();
            }
        }

        public override Size GetPreferredSize(Size constrainingSize)
        {
            return InnerTextBox.PrefSize;
        }

        public void Initialize(string text)
        {
            InnerTextBox.Padding = new Padding(1);
            InnerTextBox.BackColor = Color.LightGoldenrodYellow;

            InnerTextBox.TextBox.Text = text;
            InnerTextBox.TextBox.BackColor = Color.LightGoldenrodYellow;
        }
    }
}

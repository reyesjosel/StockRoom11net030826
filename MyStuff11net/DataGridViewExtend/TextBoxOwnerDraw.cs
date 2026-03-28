using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace MyStuff11net
{
    public partial class TextBoxOwnerDraw : Panel
    {
        Button MyButton;
        TextBox MyTextBox;
        int cornerRadius = 1;
        Color borderColor = Color.Black;
        int borderSize = 1;
        Size preferredSize = new Size(120, 25); // Use 25 for height, so it sits in the middle

        /// <summary>
        /// Access the textbox
        /// </summary>
        public TextBox TextBox
        {
            get { return MyTextBox; }
        }

        public Button Button
        {
            get { return MyButton; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                RestyleTextBox();
                Invalidate();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                RestyleTextBox();
                Invalidate();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                RestyleTextBox();
                Invalidate();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Size PrefSize
        {
            get { return preferredSize; }
            set
            {
                preferredSize = value;
                RestyleTextBox();
                Invalidate();
            }
        }

        public TextBoxOwnerDraw()
        {
            Padding = new Padding(1);
            Size = new Size(170, 22);
            BackColor = Color.LightGoldenrodYellow;

            MyButton = new Button()
            {
                Dock = DockStyle.Right,
                Size = new Size(20, 20),
                UseVisualStyleBackColor = true,
                Image = Properties.Resources.FilterClearing
            };

            MyTextBox = new TextBox()
            {
                Dock = DockStyle.Fill,
                Size = new Size(150, 20),
                BorderStyle = BorderStyle.None,
                BackColor = Color.LightGoldenrodYellow
            };

            Controls.Add(MyButton);
            Controls.Add(MyTextBox);
            RestyleTextBox();
        }

        void RestyleTextBox()
        {
            double TopPos = Math.Floor(((double)preferredSize.Height / 2) - ((double)MyTextBox.Height / 2));

            MyTextBox.BackColor = Color.White;
            MyTextBox.BorderStyle = BorderStyle.None;
            MyTextBox.Multiline = false;
            MyTextBox.Top = (int)TopPos;
            MyTextBox.Left = BorderSize;
            MyTextBox.Width = preferredSize.Width - (BorderSize * 2);

            Height = MyTextBox.Height + (BorderSize * 2); // Will be ignored, but if you use elsewhere
            Width = preferredSize.Width;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (cornerRadius > 0 && borderSize > 0)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var cRect = ClientRectangle;
                var safeRect = new Rectangle(cRect.X, cRect.Y, cRect.Width - BorderSize, cRect.Height - BorderSize);

                // Background color
                using (Brush bgBrush = new SolidBrush(MyTextBox.BackColor))
                {
                    DrawRoundRect(g, bgBrush, safeRect, CornerRadius);
                }
                // Border
                using (Pen borderPen = new Pen(BorderColor, BorderSize))
                {
                    DrawRoundRect(g, borderPen, safeRect, CornerRadius);
                }
            }
            base.OnPaint(e);
        }

        GraphicsPath getRoundRect(int x, int y, int width, int height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner (Top Right)
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner (Bottom Right)
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner (Bottom Left)
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner (Top Left)
            gp.CloseFigure();
            return gp;
        }
        void DrawRoundRect(Graphics g, Pen p, Rectangle rect, float radius)
        {
            GraphicsPath gp = getRoundRect(rect.X, rect.Y, rect.Width, rect.Height, radius);
            g.DrawPath(p, gp);
            gp.Dispose();
        }
        void DrawRoundRect(Graphics g, Pen p, int x, int y, int width, int height, float radius)
        {
            GraphicsPath gp = getRoundRect(x, y, width, height, radius);
            g.DrawPath(p, gp);
            gp.Dispose();
        }
        void DrawRoundRect(Graphics g, Brush b, int x, int y, int width, int height, float radius)
        {
            GraphicsPath gp = getRoundRect(x, y, width, height, radius);
            g.FillPath(b, gp);
            gp.Dispose();
        }
        void DrawRoundRect(Graphics g, Brush b, Rectangle rect, float radius)
        {
            GraphicsPath gp = getRoundRect(rect.X, rect.Y, rect.Width, rect.Height, radius);
            g.FillPath(b, gp);
            gp.Dispose();
        }

    }
}

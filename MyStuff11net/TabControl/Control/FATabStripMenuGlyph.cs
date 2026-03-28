using System.Drawing.Drawing2D;

namespace MyStuff11net
{
    internal class FATabStripMenuGlyph
    {
        private Rectangle glyphRect = Rectangle.Empty;
        private bool isMouseOver;
        private readonly ToolStripProfessionalRenderer renderer;

        public bool IsMouseOver
        {
            get { return isMouseOver; }
            set { isMouseOver = value; }
        }

        public Rectangle Bounds
        {
            get { return glyphRect; }
            set { glyphRect = value; }
        }

        internal FATabStripMenuGlyph(ToolStripProfessionalRenderer renderer1)
        {
            renderer = renderer1;
        }

        public void DrawGlyph(Graphics g)
        {
            if (isMouseOver)
            {
                Color fill = renderer.ColorTable.ButtonSelectedHighlight; //Color.FromArgb(35, SystemColors.Highlight);
                g.FillRectangle(new SolidBrush(fill), glyphRect);
                Rectangle borderRect = glyphRect;

                borderRect.Width--;
                borderRect.Height--;

                g.DrawRectangle(SystemPens.Highlight, borderRect);
            }

            SmoothingMode bak = g.SmoothingMode;

            g.SmoothingMode = SmoothingMode.Default;

            using (Pen pen = new Pen(Color.Black))
            {
                pen.Width = 2;
                g.DrawLine(pen, new Point(glyphRect.Left + (glyphRect.Width / 3 - 2), glyphRect.Bottom - 11),
                    new Point(glyphRect.Right - (glyphRect.Width / 3 - 2), glyphRect.Bottom - 11));
            }

            g.FillPolygon(Brushes.Black, new Point[]{
                     new Point(glyphRect.Left + (glyphRect.Width / 3 - 2), glyphRect.Bottom - 9),
                     new Point(glyphRect.Right - (glyphRect.Width / 3 - 2), glyphRect.Bottom - 9),
                     new Point(glyphRect.Left + (glyphRect.Width / 2), glyphRect.Bottom - 3)});

            g.SmoothingMode = bak;
        }
    }
}

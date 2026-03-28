namespace MyStuff11net
{
    internal class FATabStripCloseButton
    {
        private Rectangle crossRect = Rectangle.Empty;
        private bool isMouseOver;
        private readonly ToolStripProfessionalRenderer renderer;

        public bool IsMouseOver
        {
            get { return isMouseOver; }
            set { isMouseOver = value; }
        }

        public Rectangle Bounds
        {
            get { return crossRect; }
            set { crossRect = value; }
        }

        internal FATabStripCloseButton(ToolStripProfessionalRenderer renderer1)
        {
            renderer = renderer1;
        }

        public void DrawCross(Graphics g)
        {
            if (isMouseOver)
            {
                Color fill = renderer.ColorTable.ButtonSelectedHighlight;

                g.FillRectangle(new SolidBrush(fill), crossRect);

                Rectangle borderRect = crossRect;

                borderRect.Width--;
                borderRect.Height--;

                g.DrawRectangle(SystemPens.Highlight, borderRect);
            }

            using (Pen pen = new Pen(Color.Black, 1.6f))
            {
                g.DrawLine(pen, crossRect.Left + 3, crossRect.Top + 3,
                    crossRect.Right - 5, crossRect.Bottom - 4);

                g.DrawLine(pen, crossRect.Right - 5, crossRect.Top + 3,
                    crossRect.Left + 3, crossRect.Bottom - 4);
            }
        }

    }
}

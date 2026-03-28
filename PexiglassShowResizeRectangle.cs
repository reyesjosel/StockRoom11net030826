using System.Runtime.InteropServices;
using System.ComponentModel;

namespace StockRoom11net
{
    class Plexiglass : Form
    {
        Image recImage;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image RectImage
        {
            get
            {
                return recImage;
            }
            set
            {
                if (value == null)
                    return;

                recImage = value;
                RecZoomImage = new Bitmap(recImage.Width, recImage.Height);
                zoomGraphics = Graphics.FromImage(RecZoomImage);

                int new4W = recImage.Width / 4;
                int new4H = recImage.Height / 4;
                int new2W = recImage.Width / 2;
                int new2H = recImage.Height / 2;
                srcRect = new Rectangle(new4W, new4H, new2W, new2H);
            }
        }

        Rectangle srcRect;
        Image RecZoomImage;
        Graphics zoomGraphics;

        public Plexiglass(Form tocover)
        {
            BackColor = Color.DarkGray;
            Opacity = 0.30;      // Tweak as desired
            FormBorderStyle = FormBorderStyle.FixedSingle;
            ControlBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            AutoScaleMode = AutoScaleMode.None;
            Location = tocover.PointToScreen(Point.Empty);
            DoubleBuffered = true;

            ClientSizeChanged += Plexiglass_ClientSizeChanged;

            Show(tocover);
            //  tocover.Focus();
            // Disable Aero transitions, the plexiglass gets too visible
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
        }

        private void Plexiglass_ClientSizeChanged(object sender, EventArgs e)
        {
            if (RecZoomImage == null)
                return;

            Rectangle dstRect = new Rectangle(0, 0, RecZoomImage.Width, RecZoomImage.Height);
            zoomGraphics.DrawImage(RectImage, dstRect, srcRect, GraphicsUnit.Pixel);

            //Invalidate();
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.DrawImageUnscaledAndClipped(RectImage, RectangleToClient(Bounds));
            e.Graphics.DrawImage(RectImage, RectangleToClient(Bounds), 0, 0, RectImage.Width, RectImage.Height, GraphicsUnit.Pixel);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
            {
                int value = 1;
                DwmSetWindowAttribute(Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
            base.OnFormClosing(e);
        }

        protected override void OnActivated(EventArgs e)
        {
            // Always keep the owner activated instead
            BeginInvoke(new Action(() => Owner.Activate()));
        }

        const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
        [DllImport("dwmapi.dll")]
        static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);

        void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Plexiglass
            // 
            ClientSize = new Size(374, 306);
            Name = "Plexiglass";
            ResumeLayout(false);

        }
    }
}

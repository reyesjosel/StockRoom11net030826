using System.ComponentModel;
using System.Windows.Forms.VisualStyles;

namespace MyStuff11net
{
    [ToolboxItem(false)]
    public class BaseStyledPanel : ContainerControl
    {
        private static ToolStripProfessionalRenderer renderer;

        public event EventHandler ThemeChanged;

        static BaseStyledPanel()
        {
            renderer = new ToolStripProfessionalRenderer();
        }

        public BaseStyledPanel()
        {
            // Set painting style for better performance.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
            UpdateRenderer();
            Invalidate();
        }

        protected virtual void OnThemeChanged(EventArgs e)
        {
            if (ThemeChanged != null)
                ThemeChanged(this, e);
        }

        private void UpdateRenderer()
        {
            if (!UseThemes)
            {
                renderer.ColorTable.UseSystemColors = true;
            }
            else
            {
                renderer.ColorTable.UseSystemColors = false;
            }
        }

        [Browsable(false)]
        public ToolStripProfessionalRenderer ToolStripRenderer
        {
            get { return renderer; }
        }

        [DefaultValue(true)]
        [Browsable(false)]
        public bool UseThemes
        {
            get
            {
                return VisualStyleRenderer.IsSupported && VisualStyleInformation.IsSupportedByOS;
            }
        }
    }
}

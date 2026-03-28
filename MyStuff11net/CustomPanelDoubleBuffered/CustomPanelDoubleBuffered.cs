
namespace MyStuff11net
{
    public class CustomPanelDoubleBuffered : Panel
    {
        public CustomPanelDoubleBuffered()
        {
            // Enable double buffering and control over painting
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint,
                          true);
            UpdateStyles();
        }
    }
}

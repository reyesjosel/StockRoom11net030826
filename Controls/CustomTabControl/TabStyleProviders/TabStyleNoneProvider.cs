/*
 * This code is provided under the Code Project Open Licence (CPOL)
 * See http://www.codeproject.com/info/cpol10.aspx for details
 */

namespace System.Windows.Forms
{
    using System.Drawing;
    using System.Drawing.Drawing2D;

    [System.ComponentModel.ToolboxItem(false)]
    public class TabStyleNoneProvider : TabStyleProvider
    {
        public TabStyleNoneProvider(CustomTabControl tabControl) : base(tabControl)
        {
        }

        public override void AddTabBorder(GraphicsPath path, Rectangle tabBounds)
        {
        }
    }
}

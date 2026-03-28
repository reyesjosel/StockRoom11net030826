using System.Runtime.InteropServices;

namespace MyStuff11net.DataGridViewExtend
{
    public sealed class ScreenImage
    {
        #region Unmanaged declarations

        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(nint handlerToDestinationDeviceContext, int x, int y, int nWidth, int nHeight, nint handlerToSourceDeviceContext, int xSrc, int ySrc, int opCode);

        [DllImport("user32.dll")]
        private static extern nint GetWindowDC(nint windowHandle);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(nint windowHandle, nint dc);

        private static int SRCCOPY = 0x00CC0020;  // dest = source

        #endregion

        public static Image GetScreenshot(nint windowHandle, Point location, Size size)
        {
            Image myImage = new Bitmap(size.Width, size.Height);

            using (Graphics g = Graphics.FromImage(myImage))
            {
                nint destDeviceContext = g.GetHdc();
                nint srcDeviceContext = GetWindowDC(windowHandle);

                // TODO: throw exception
                BitBlt(destDeviceContext, 0, 0, size.Width, size.Height, srcDeviceContext, location.X, location.Y, SRCCOPY);

                ReleaseDC(windowHandle, srcDeviceContext);
                g.ReleaseHdc(destDeviceContext);

            } // dispose the Graphics object

            return myImage;
        }
    }
}

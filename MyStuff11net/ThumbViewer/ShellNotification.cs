using System.Runtime.InteropServices;

namespace MyStuff11net
{
    public class ShellNotification
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern Int32 SHParseDisplayName(
            [MarshalAs(UnmanagedType.LPWStr)] string pszName,
            IntPtr pbc,
            out IntPtr ppidl,
            UInt32 sfgaoIn,
            out UInt32 psfgaoOut);
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        internal static extern void SHChangeNotify(
            UInt32 wEventId,
            UInt32 uFlags,
            IntPtr dwItem1,
            IntPtr dwItem2);

        [Flags]
        private enum ShellChangeNotificationEvents : uint
        {
            //...
            SHCNE_UPDATEITEM = 0x00002000,
            //...
        }

        private enum ShellChangeNotificationFlags
        {
            //...
            SHCNF_FLUSH = 0x1000,
            //...
        }

        /// <summary>
        /// In Windows XP forces windows Explorer refreshes the file and shows the correct
        /// thumbnail.
        /// </summary>
        /// <param name="path"></param>
        public static void RefreshThumbnail(string path)
        {
            try
            {
                uint iAttribute;
                IntPtr pidl;
                SHParseDisplayName(path, IntPtr.Zero, out pidl, 0, out iAttribute);
                SHChangeNotify((uint)ShellChangeNotificationEvents.SHCNE_UPDATEITEM,
                               (uint)ShellChangeNotificationFlags.SHCNF_FLUSH,
                                pidl,
                                IntPtr.Zero);
            }
            catch { }
        }
    }
}


using System.Runtime.InteropServices;

namespace StockRoom11net.Controls.ShellBasics
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9CC22886-DC8E-11d2-B1D0-00C04F8EEB3E")]
    public interface IFolderFilter
    {
        // Allows a client to specify which individual items should be enumerated.
        // Note: The host calls this method for each itemEFtableTreeView in the folder. Return S_OK, to have the itemEFtableTreeView enumerated.
        // Return S_FALSE to prevent the itemEFtableTreeView from being enumerated.
        [PreserveSig]
        Int32 ShouldShow(
            [MarshalAs(UnmanagedType.Interface)] Object psf,                // A pointer to the folder's IShellFolder interface.
            IntPtr pidlFolder,      // The folder's PIDL.
            IntPtr pidlItem);       // The itemEFtableTreeView's PIDL.

        // Allows a client to specify which classes of objects in a Shell folder should be enumerated.
        [PreserveSig]
        Int32 GetEnumFlags(
            [MarshalAs(UnmanagedType.Interface)] Object psf,                // A pointer to the folder's IShellFolder interface.
            IntPtr pidlFolder,      // The folder's PIDL.
            IntPtr phwnd,           // A pointer to the host's window handle.
            out UInt32 pgrfFlags);  // One or more SHCONTF values that specify which classes of objects to enumerate.

    };

}
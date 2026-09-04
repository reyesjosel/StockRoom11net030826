using System.Runtime.InteropServices;

namespace StockRoom11net.Controls.ShellBasics
{
    [ComVisible(true)]
    [Guid("3766C955-DA6F-4fbc-AD36-311E342EF180")]
    public class FilterByExtension : IFolderFilter
    {
        // Allows a client to specify which individual items should be enumerated.
        // Note: The host calls this method for each itemEFtableTreeView in the folder. Return S_OK, to have the itemEFtableTreeView enumerated.
        // Return S_FALSE to prevent the itemEFtableTreeView from being enumerated.
        public Int32 ShouldShow(
            Object psf,				// A pointer to the folder's IShellFolder interface.
            IntPtr pidlFolder,		// The folder's PIDL.
            IntPtr pidlItem)		// The itemEFtableTreeView's PIDL.
        {
            // check extension, and if not ok return 1 (S_FALSE)

            // get display name of itemEFtableTreeView
            IShellFolder isf = (IShellFolder)psf;

            ShellApi.STRRET ptrDisplayName;
            isf.GetDisplayNameOf(pidlItem, (uint)ShellApi.SHGNO.SHGDN_NORMAL | (uint)ShellApi.SHGNO.SHGDN_FORPARSING, out ptrDisplayName);

            string sDisplay;
            ShellApi.StrRetToBSTR(ref ptrDisplayName, (IntPtr)0, out sDisplay);

            // check if itemEFtableTreeView is file or folder
            IntPtr[] aPidl = new IntPtr[1];
            aPidl[0] = pidlItem;
            uint Attrib;
            Attrib = (uint)ShellApi.SFGAO.SFGAO_FOLDER;

            int temp;
            temp = isf.GetAttributesOf(1, aPidl, ref Attrib);

            // if itemEFtableTreeView is a folder, accept
            if ((Attrib & (uint)ShellApi.SFGAO.SFGAO_FOLDER) == (uint)ShellApi.SFGAO.SFGAO_FOLDER)
                return 0;

            // if itemEFtableTreeView is file, check if it has a valid extension
            for (int i = 0; i < ValidExtension.Length; i++)
            {
                if (sDisplay.ToUpper().EndsWith("." + ValidExtension[i].ToUpper()))
                    return 0;
            }

            return 1;
        }

        // Allows a client to specify which classes of objects in a Shell folder should be enumerated.
        public Int32 GetEnumFlags(
            Object psf,				// A pointer to the folder's IShellFolder interface.
            IntPtr pidlFolder,		// The folder's PIDL.
            IntPtr phwnd,			// A pointer to the host's window handle.
            out UInt32 pgrfFlags)	// One or more SHCONTF values that specify which classes of objects to enumerate.
        {
            pgrfFlags = (uint)ShellApi.SHCONTF.SHCONTF_FOLDERS | (uint)ShellApi.SHCONTF.SHCONTF_NONFOLDERS;
            return 0;
        }

        public string[] ValidExtension;
    }

}
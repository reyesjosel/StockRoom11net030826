using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace MyStuff11net
{
    public sealed class UsingKernel32
    {
        static int _index;
        static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        public const int MAX_PATH = 260;
        public const int MAX_ALTERNATE = 14;
        public const int FILE_ATTRIBUTE_DIRECTORY = 0x10;

        static ObservableCollection<FileDirectoryModel> dir = new ObservableCollection<FileDirectoryModel>();

        [StructLayout(LayoutKind.Sequential)]
        public struct FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WIN32_FIND_DATA
        {
            public uint dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public uint nFileSizeHigh; //changed all to uint from int, otherwise you run into unexpected overflow
            public uint nFileSizeLow;  //| http://www.pinvoke.net/default.aspx/Structures/WIN32_FIND_DATA.html
            public uint dwReserved0;   //|
            public uint dwReserved1;   //v
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ALTERNATE)]
            public string cAlternate;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll")]
        public static extern bool FindClose(IntPtr hFindFile);


        public static long RecurseDirectory(FileDirectoryModel currentDir, out int files, out int folders)
        {
            long size = 0;
            files = 0;
            folders = 0;
            WIN32_FIND_DATA _fileDirData;

            IntPtr findHandle;

            _index = currentDir.ID;

            // please note that the following line won't work if you try this on a network folder, like \\Machine\C$
            // simply remove the \\?\ part in this case or use \\?\UNC\ prefix
            findHandle = FindFirstFile(@"\\?\" + currentDir.Location + @"\*", out _fileDirData);

            if (findHandle != INVALID_HANDLE_VALUE)
            {
                do
                {
                    #region"Directory or Folder"

                    if ((_fileDirData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) != 0)
                    {
                        if (_fileDirData.cFileName != "." && _fileDirData.cFileName != "..")
                        {
                            folders++;
                            string subdirectory = currentDir.Location + (currentDir.Location.EndsWith(@"\") ? "" : @"\") + _fileDirData.cFileName;

                            #region"Hide Directory or Folder"
                            //if (_fileDirData.cFileName.Contains(".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}"))
                            //{
                            //    HideFolders.Add(_fileDirData.cFileName);
                            //}
                            #endregion"Hide Directory or Folder"

                            #region"Directory or Folder"
                            _index++;

                            FileDirectoryModel newDir = new FileDirectoryModel
                                (
                                _index,                     // Index/ ID.
                                currentDir.ID,              // Parent ID.
                                FileAttributes.Directory,   // Define ther posible type, File or Directory.
                                subdirectory,               // Current levels or parent directory.
                                _fileDirData.cFileName      // Name of childs directory or file.
                            );
                            dir.Add(newDir);
                            #endregion"Directory or Folder"

                            int subfiles, subfolders;
                            size += RecurseDirectory(newDir, out subfiles, out subfolders);
                            folders += subfolders;
                            files += subfiles;
                        }
                    }

                    #endregion"Directory or Folder"

                    #region"File"
                    else
                    {
                        // File
                        files++;

                        _index++;

                        var newFile = new FileDirectoryModel
                        (
                            _index,                 // Index/ ID.
                            currentDir.ID,          // Parent ID.
                            FileAttributes.Normal,         // Define they possible type, File or Directory.
                            currentDir.Location,    // Current levels or parent directory.
                            _fileDirData.cFileName  // Name of file.
                        );
                        //currentDir.Entries.Add(newFile);
                        dir.Add(newFile);

                        size += (long)_fileDirData.nFileSizeLow + (long)_fileDirData.nFileSizeHigh * 4294967296;
                    }
                    #endregion"File"

                } while (FindNextFile(findHandle, out _fileDirData));

                FindClose(findHandle);
            }
            return size;
        }
    }
}

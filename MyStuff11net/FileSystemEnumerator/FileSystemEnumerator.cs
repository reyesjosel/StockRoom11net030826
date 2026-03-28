/*=============================================================================
    FileSystemEnumerator.cs: Lazy enumerator for finding files in subdirectories.

    Copyright (c) 2006 Carl Daniel. Distributed under the Boost
    Software License, Version 1.0. (See accompanying file
    LICENSE.txt or copy at http://www.boost.org/LICENSE_1_0.txt)
=============================================================================*/

// ---------------------------------------------------------------------------
// FileSystemEnumerator implementation
// ---------------------------------------------------------------------------

using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace MyStuff11net
{
    namespace Win32
    {
        /// <summary>
        /// Structure that maps to WIN32_FIND_DATA
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal sealed class FindData
        {
            public int fileAttributes;
            public int creationTime_lowDateTime;
            public int creationTime_highDateTime;
            public int lastAccessTime_lowDateTime;
            public int lastAccessTime_highDateTime;
            public int lastWriteTime_lowDateTime;
            public int lastWriteTime_highDateTime;
            public int nFileSizeHigh;
            public int nFileSizeLow;
            public int dwReserved0;
            public int dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string fileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string alternateFileName;
        }

        /// <summary>
        /// SafeHandle class for holding find handles
        /// </summary>
        internal sealed class SafeFindHandle : Microsoft.Win32.SafeHandles.SafeHandleMinusOneIsInvalid
        {
            /// <summary>
            /// Constructor
            /// </summary>
            public SafeFindHandle() : base(true)
            {
            }

            /// <summary>
            /// Release the find handle
            /// </summary>
            /// <returns>true if the handle was released</returns>
           // [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            protected override bool ReleaseHandle()
            {
                return SafeNativeMethods.FindClose(handle);
            }
        }

        /// <summary>
        /// Wrapper for P/Invoke methods used by FileSystemEnumerator
        /// </summary>
        //[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
        internal static class SafeNativeMethods
        {
            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            public static extern SafeFindHandle FindFirstFile(string fileName, [In, Out] FindData findFileData);

            [DllImport("kernel32", CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FindNextFile(SafeFindHandle hFindFile, [In, Out] FindData lpFindFileData);

            [DllImport("kernel32", CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool FindClose(IntPtr hFindFile);
        }
    }

    /// <summary>
    /// File system enumerator.  This class provides an easy to use, efficient mechanism for searching a list of
    /// directories for files matching a list of file specifications.  The search is done incrementally as matches
    /// are consumed, so the overhead before processing the first match is always kept to a minimum.
    /// </summary>
    public sealed class FileSystemEnumerator : IDisposable
    {
        public int FoundedFile;

        bool _includeMatch = true;
        int _index;
        string _pathToSearch;
        string _defaultProjectsDirectory = Path.Combine(Properties.Settings.Default.DataBaseAddress, "Projects");
        List<FileDirectoryModel> dir = new List<FileDirectoryModel>();

        /// <summary>
        /// Information that's kept in our stack for simulated recursion
        /// </summary>
        struct SearchInfo
        {
            /// <summary>
            /// Find handle returned by FindFirstFile
            /// </summary>
            public Win32.SafeFindHandle Handle;

            /// <summary>
            /// Path that was searched to yield the find handle.
            /// </summary>
            public string Path;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="h">Find handle returned by FindFirstFile.</param>
            /// <param name="p">Path corresponding to find handle.</param>
            public SearchInfo(Win32.SafeFindHandle h, string p)
            {
                Handle = h;
                Path = p;
            }
        }

        /// <summary>
        /// Stack of open scopes.  This is a member (instead of a local variable)
        /// to allow Dispose to close any open find handles if the object is disposed
        /// before the enumeration is completed.
        /// </summary>
        Stack<SearchInfo> m_scopes;

        /// <summary>
        /// Array of paths to be searched.
        /// </summary>
        string[] m_paths;

        /// <summary>
        /// Array of regular expressions that will detect matching files.
        /// </summary>
        List<Regex> m_fileSpecs;

        /// <summary>
        /// If true, sub-directories are searched.
        /// </summary>
        bool m_includeSubDirs;

        #region IDisposable implementation

        /// <summary>
        /// IDisposable.Dispose
        /// </summary>
        public void Dispose()
        {
            while (m_scopes.Count > 0)
            {
                SearchInfo si = m_scopes.Pop();
                si.Handle.Close();
            }
        }

        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pathsToSearch">Semicolon- or comma-delimited list of paths to search.</param>
        /// <param name="fileTypesToMatch">Semicolon- or comma-delimited list of wildcard file specs to match.</param>
        /// <param name="includeMatch">if true, include the match file, if false, exclude the match file.</param>
        /// <param name="includeSubDirs">If true, subdirectories are searched.</param>
        /// <param name="index">Index or ID where the enumerator begin.</param>
        public FileSystemEnumerator(string pathsToSearch, string fileTypesToMatch, bool includeMatch, bool includeSubDirs, int index)
        {
            m_scopes = new Stack<SearchInfo>();

            // check for nulls
            if (null == pathsToSearch)
                throw new ArgumentNullException("pathsToSearch");
            if (null == fileTypesToMatch)
                throw new ArgumentNullException("fileTypesToMatch");

            // make sure spec doesn't contain invalid characters
            if (fileTypesToMatch.IndexOfAny(new char[] { ':', '<', '>', '/', '\\' }) >= 0)
                throw new ArgumentException("invalid characters in wildcard pattern", "fileTypesToMatch");

            // check security - ensure that caller has rights to read this directory
            new FileIOPermission(FileIOPermissionAccess.PathDiscovery, Path.Combine(pathsToSearch, ".")).Demand();

            _index = index;
            FoundedFile = 0;
            _includeMatch = includeMatch;
            _pathToSearch = pathsToSearch;
            m_includeSubDirs = includeSubDirs;
            m_paths = pathsToSearch.Split(new char[] { ';', ',' });

            string[] specs = fileTypesToMatch.Split(new char[] { ';', ',' });
            m_fileSpecs = new List<Regex>(specs.Length);
            foreach (string spec in specs)
            {
                // trim whitespace off file spec and convert Win32 wildcards to regular expressions
                string pattern = spec
                  .Trim()
                  .Replace(".", @"\.")
                  .Replace("*", @".*")
                  .Replace("?", @".?");

                m_fileSpecs.Add(new Regex("^" + pattern + "$", RegexOptions.IgnoreCase));
            }
        }

        public List<FileDirectoryModel> FoundMatchFiles(string fileName)
        {
            var findData = new Win32.FindData();
            var handle = Win32.SafeNativeMethods.FindFirstFile(Path.Combine(_pathToSearch, fileName), findData);

            if (!handle.IsInvalid)
            {
                do
                {
                    // don't match . or ..
                    if (findData.fileName.Equals(@".") || findData.fileName.Equals(@".."))
                        continue;

                    // if it,s a directory continue.
                    if ((findData.fileAttributes & (int)FileAttributes.Directory) != 0)
                        continue;

                    _index++;

                    var newFile = new FileDirectoryModel
                    (
                        _index,                     // Index/ ID.
                        _index,                     // Parent ID.
                        (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                        _pathToSearch,              // Current levels or parent directory.
                        findData.fileName           // Name of file.
                    );

                    dir.Add(newFile);

                } while (Win32.SafeNativeMethods.FindNextFile(handle, findData));

                // close this find handle
                handle.Close();
            }
            return dir;
        }

        /// <summary>
        /// Get an enumerator that returns all of the files that match the wildcards that
        /// are in any of the directories to be searched. String fileNameToMatch parameter
        /// continue the file name to search, use * to restring the search,
        /// "*"             , return all file.
        /// "filename"      , return the exactly file.
        /// "*filename*"    , return any file containing in the file name it.
        /// "*filename"     , return any file containing in the end of file name it.
        /// "filename*"     , return any file containing in the begin of file name it.
        /// </summary>
        /// <param name="fileNameToMatch">todo: describe fileNameToMatch parameter on MatchesFiles</param>
        /// <returns>An IEnumerable that returns all matching files one by one.</returns>
        /// <remarks>The enumerator that is returned finds files using a lazy algorithm that
        /// searches directories incrementally as matches are consumed.</remarks>
        public IEnumerable<FileInfo> MatchesFiles(string fileNameToMatch)
        {
            FoundedFile = 0;

            // we "recourse" into a new directory by jumping to this spot
        top:

            // now that security is checked, go read the directory
            Win32.FindData findData = new Win32.FindData();
            Win32.SafeFindHandle handle = Win32.SafeNativeMethods.FindFirstFile(Path.Combine(_pathToSearch, fileNameToMatch), findData);
            m_scopes.Push(new SearchInfo(handle, _pathToSearch));
            bool restart = false;

            // we "return" from a sub-directory by jumping to this spot
        restart:
            if (!handle.IsInvalid)
            {
                do
                {
                    // if we restarted the loop (unwound a recursion), fetch the next match
                    if (restart)
                    {
                        restart = false;
                        continue;
                    }

                    // don't match . or ..
                    if (findData.fileName.Equals(@".") || findData.fileName.Equals(@".."))
                        continue;

                    //If the file was deleted ...
                    if (findData.fileName.StartsWith(@"~$"))
                        continue;

                    if ((findData.fileAttributes & (int)FileAttributes.Directory) != 0)
                    {
                        if (m_includeSubDirs)
                        {
                            // it's a directory - recourse into it
                            _pathToSearch = Path.Combine(_pathToSearch, findData.fileName);
                            goto top;
                        }
                    }
                    else
                    {
                        // it's a file, see if any of the file specs matches it
                        foreach (Regex fileSpec in m_fileSpecs)
                        {
                            // if this spec matches, return this file's info
                            if (fileSpec.IsMatch(findData.fileName))
                            {
                                FoundedFile++;
                                yield return new FileInfo(Path.Combine(_pathToSearch, findData.fileName));
                            }
                        }
                    }
                } while (Win32.SafeNativeMethods.FindNextFile(handle, findData));

                // close this find handle
                handle.Close();

                // unwind the stack - are we still in a recursion?
                m_scopes.Pop();
                if (m_scopes.Count > 0)
                {
                    SearchInfo si = m_scopes.Peek();
                    handle = si.Handle;
                    _pathToSearch = si.Path;
                    restart = true;
                    goto restart;
                }

                if (FoundedFile == 0)
                {
                    string namefile = findData.fileName;
                    FoundedFile = 0;
                }
            }
        }

        /// <summary>
        /// Get an enumerator that returns all of the files that match the wildcards that
        /// are in any of the directories to be searched.
        /// </summary>
        /// <returns>An IEnumerable that returns all matching files one by one.</returns>
        /// <remarks>The enumerator that is returned finds files using a lazy algorithm that
        /// searches directories incrementally as matches are consumed.</remarks>
        public IEnumerable<FileInfo> MatchesFiles()
        {
            foreach (string rootPath in m_paths)
            {
                string path = rootPath.Trim();

                // we "recourse" into a new directory by jumping to this spot
            top:

                // check security - ensure that caller has rights to read this directory
                new FileIOPermission(FileIOPermissionAccess.PathDiscovery, Path.Combine(path, ".")).Demand();

                // now that security is checked, go read the directory
                Win32.FindData findData = new Win32.FindData();
                Win32.SafeFindHandle handle = Win32.SafeNativeMethods.FindFirstFile(Path.Combine(path, "*"), findData);
                m_scopes.Push(new SearchInfo(handle, path));
                bool restart = false;

                // we "return" from a sub-directory by jumping to this spot
            restart:
                if (!handle.IsInvalid)
                {
                    do
                    {
                        // if we restarted the loop (unwound a recursion), fetch the next match
                        if (restart)
                        {
                            restart = false;
                            continue;
                        }

                        // don't match . or ..
                        if (findData.fileName.Equals(@".") || findData.fileName.Equals(@".."))
                            continue;

                        if ((findData.fileAttributes & (int)FileAttributes.Directory) != 0)
                        {
                            if (m_includeSubDirs)
                            {
                                // it's a directory - recourse into it
                                path = Path.Combine(path, findData.fileName);
                                goto top;
                            }
                        }
                        else
                        {
                            // it's a file, see if any of the file specs matches it
                            foreach (Regex fileSpec in m_fileSpecs)
                            {
                                // if this spec matches, return this file's info
                                if (fileSpec.IsMatch(findData.fileName))
                                    yield return new FileInfo(Path.Combine(path, findData.fileName));
                            }
                        }
                    } while (Win32.SafeNativeMethods.FindNextFile(handle, findData));

                    // close this find handle
                    handle.Close();

                    // unwind the stack - are we still in a recursion?
                    m_scopes.Pop();
                    if (m_scopes.Count > 0)
                    {
                        SearchInfo si = m_scopes.Peek();
                        handle = si.Handle;
                        path = si.Path;
                        restart = true;
                        goto restart;
                    }
                }
            }
        }

        /// <summary>
        /// Get an structured tree schema of the directory to search,
        /// used as root entry the directory name where the search start.
        /// </summary>
        /// <returns></returns>
        public List<FileDirectoryModel> FoundFiles()
        {
            FileDirectoryModel _currentDir = new FileDirectoryModel
              (
                  _index,                             // Index/ ID. Root entry.
                  null,                               // Parent ID. Null has no parent.
                  System.IO.FileAttributes.Directory,           // Define they possible type, File or Directory.
                  _pathToSearch,                      // Current levels or parent directory.
                  _pathToSearch                       // Name of root directory or base.
              );

            dir.Add(_currentDir);

            if (_includeMatch)
                return ScanFilesFoldersInclude(_currentDir);

            return ScanFilesFoldersExclude(_currentDir);
        }

        /// <summary>
        /// Get an structured tree schema of the directory to search,
        /// used as root entry the directory name where the search start,
        /// mark parent if exist Thumbs.db
        /// </summary>
        /// <returns></returns>
        public List<FileDirectoryModel> FoundFilesToTreeView()
        {
            FileDirectoryModel _currentDirList = new FileDirectoryModel
              (
                  _index,                             // Index/ ID. Root entry.
                  null,                               // Parent ID. Null has no parent.
                  System.IO.FileAttributes.Directory,           // Define they possible type, File or Directory.
                  _pathToSearch.Replace(Properties.Settings.Default.DataBaseAddress + "\\", ""), // Current levels or parent directory.
                  _pathToSearch.Replace(Properties.Settings.Default.DataBaseAddress + "\\", "")  // Name of root directory or base.
              );

            dir.Add(_currentDirList);

            FileDirectoryModel _currentDir = new FileDirectoryModel
              (
                  _index,                             // Index/ ID. Root entry.
                  null,                               // Parent ID. Null has no parent.
                  System.IO.FileAttributes.Directory,           // Define they possible type, File or Directory.
                  _pathToSearch,                      // Current levels or parent directory.
                  _pathToSearch                       // Name of root directory or base.
              );

            return ScanFilesFoldersExcludeToTreeView(_currentDir);
        }

        /// <summary>
        /// Creates a directory tree structured schema, if there Thumbs.db,
        /// ignoring the directory where no Thumb.db is
        /// </summary>
        /// <returns></returns>
        public List<FileDirectoryModel> FoundThumbDBFilesToTreeView()
        {
            var _currentDirList = new FileDirectoryModel
              (
                  _index,                             // Index/ ID. Root entry.
                  null,                               // Parent ID. Null has no parent.
                  System.IO.FileAttributes.Directory,           // Define they possible type, File or Directory.
                  _pathToSearch.Replace(Properties.Settings.Default.DataBaseAddress + "\\", ""), // Current levels or parent directory.
                  _pathToSearch.Replace(Properties.Settings.Default.DataBaseAddress + "\\", "")  // Name of root directory or base.
              );

            dir.Add(_currentDirList);

            var _currentDir = new FileDirectoryModel
              (
                  _index,                             // Index/ ID. Root entry.
                  null,                               // Parent ID. Null has no parent.
                  System.IO.FileAttributes.Directory,           // Define they possible type, File or Directory.
                  _pathToSearch,                      // Current levels or parent directory.
                  _pathToSearch                       // Name of root directory or base.
              );

            return ScanThumbDBFiles(_currentDir);
        }


        List<FileDirectoryModel> ScanFilesFoldersInclude(FileDirectoryModel currentDir)
        {
            Win32.FindData findData = new Win32.FindData();
            Win32.SafeFindHandle handle = Win32.SafeNativeMethods.FindFirstFile(Path.Combine(currentDir.Location, "*"), findData);

            if (!handle.IsInvalid)
            {
                do
                {
                    // don't match . or ..
                    if (findData.fileName.Equals(@".") || findData.fileName.Equals(@".."))
                        continue;

                    #region"Directory"
                    if ((findData.fileAttributes & (int)FileAttributes.Directory) != 0)
                    {
                        _index++;
                        string subdirectory = currentDir.Location + (currentDir.Location.EndsWith(@"\") ? "" : @"\") + findData.fileName;

                        FileDirectoryModel newDir = new FileDirectoryModel
                            (
                            _index,                     // Index/ ID.
                            currentDir.ID,              // Parent ID.
                            (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                            subdirectory,               // Current levels or parent directory.
                            findData.fileName           // Name of children directory or file.
                        );
                        dir.Add(newDir);

                        if (m_includeSubDirs)
                        {
                            // it's a directory - recourse into it
                            ScanFilesFoldersInclude(newDir);
                        }
                    }
                    #endregion"Directory"

                    else

                    #region"Files"
                    {
                        // it's a file, see if any of the file specs matches it
                        foreach (Regex fileSpec in m_fileSpecs)
                        {
                            // if this spec matches, return this file's info
                            if (fileSpec.IsMatch(findData.fileName))
                            {
                                _index++;

                                var newFile = new FileDirectoryModel
                                (
                                    _index,                     // Index/ ID.
                                    currentDir.ID,              // Parent ID.
                                    (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                                    currentDir.Location,        // Current levels or parent directory.
                                    findData.fileName           // Name of file.
                                );
                                dir.Add(newFile);
                            }
                        }
                    }
                    #endregion"Files"

                } while (Win32.SafeNativeMethods.FindNextFile(handle, findData));

                // close this find handle
                handle.Close();
            }
            return dir;
        }

        List<FileDirectoryModel> ScanFilesFoldersExclude(FileDirectoryModel currentDir)
        {
            Win32.FindData findData = new Win32.FindData();
            Win32.SafeFindHandle handle = Win32.SafeNativeMethods.FindFirstFile(Path.Combine(currentDir.Location, "*"), findData);

            if (!handle.IsInvalid)
            {
                do
                {
                    // don't match . or ..
                    if (findData.fileName.Equals(@".") || findData.fileName.Equals(@".."))
                        continue;

                    #region"Directory"
                    if ((findData.fileAttributes & (int)FileAttributes.Directory) != 0)
                    {
                        _index++;
                        string subdirectory = currentDir.Location + (currentDir.Location.EndsWith(@"\") ? "" : @"\") + findData.fileName;

                        FileDirectoryModel newDir = new FileDirectoryModel
                            (
                            _index,                     // Index/ ID.
                            currentDir.ID,              // Parent ID.
                            (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                            subdirectory,               // Current levels or parent directory.
                            findData.fileName           // Name of children directory or file.
                        );
                        dir.Add(newDir);

                        if (m_includeSubDirs)
                        {
                            // it's a directory - recourse into it
                            ScanFilesFoldersExclude(newDir);
                        }
                    }
                    #endregion"Directory"

                    else

                    #region"Files"
                    {
                        // it's a file, see if any of the file specs matches it
                        foreach (Regex fileSpec in m_fileSpecs)
                        {
                            // if this spec matches, no return this file's info
                            if (fileSpec.IsMatch(findData.fileName))
                                continue;

                            _index++;

                            var newFile = new FileDirectoryModel
                            (
                                _index,                     // Index/ ID.
                                currentDir.ID,              // Parent ID.
                                (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                                currentDir.Location,        // Current levels or parent directory.
                                findData.fileName           // Name of file.
                            );
                            dir.Add(newFile);

                        }
                    }
                    #endregion"Files"

                } while (Win32.SafeNativeMethods.FindNextFile(handle, findData));

                // close this find handle
                handle.Close();
            }
            return dir;
        }

        List<FileDirectoryModel> ScanFilesFoldersExcludeToTreeView(FileDirectoryModel currentDir)
        {
            Win32.FindData findData = new Win32.FindData();
            Win32.SafeFindHandle handle = Win32.SafeNativeMethods.FindFirstFile(Path.Combine(currentDir.Location, "*"), findData);

            if (!handle.IsInvalid)
            {
                do
                {
                    // don't match . or ..
                    if (findData.fileName.Equals(@".") || findData.fileName.Equals(@".."))
                        continue;

                    #region"Directory"
                    if ((findData.fileAttributes & (int)FileAttributes.Directory) != 0)
                    {
                        _index++;
                        string subdirectory = currentDir.Location + (currentDir.Location.EndsWith(@"\") ? "" : @"\") + findData.fileName;

                        FileDirectoryModel newDir = new FileDirectoryModel
                            (
                            _index,                     // Index/ ID.
                            currentDir.ID,              // Parent ID.
                            (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                            (subdirectory.Replace((_defaultProjectsDirectory + "\\"), "")),  // Current levels or parent directory.
                            findData.fileName           // Name of children directory or file.
                        );
                        dir.Add(newDir);

                        if (m_includeSubDirs)
                        {
                            FileDirectoryModel newDirSearch = new FileDirectoryModel
                            (
                            _index,                       // Index/ ID.
                            currentDir.ID,                // Parent ID.
                            (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                            subdirectory,                 // Current levels or parent directory.
                            findData.fileName             // Name of children directory or file.
                        );

                            // it's a directory - recourse into it
                            ScanFilesFoldersExcludeToTreeView(newDirSearch);
                        }
                    }
                    #endregion"Directory"

                    else

                    #region"Files"
                    {
                        // it's a file, see if any of the file specs matches it
                        foreach (Regex fileSpec in m_fileSpecs)
                        {
                            // if this spec matches, no return this file's info
                            if (fileSpec.IsMatch(findData.fileName))
                            {
                                var result = dir.Find(i => i.ID == currentDir.ID);
                                result.ExistThumbs = true;
                                continue;
                            }

                            _index++;

                            var newFile = new FileDirectoryModel
                            (
                                _index,                     // Index/ ID.
                                currentDir.ID,              // Parent ID.
                                (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                                (currentDir.Location.Replace(_defaultProjectsDirectory + "\\", "")), // Current levels or parent directory.
                                findData.fileName           // Name of file.
                            );
                            dir.Add(newFile);

                        }
                    }
                    #endregion"Files"

                } while (Win32.SafeNativeMethods.FindNextFile(handle, findData));

                // close this find handle
                handle.Close();
            }
            return dir;
        }

        List<FileDirectoryModel> ScanThumbDBFiles(FileDirectoryModel currentDir)
        {
            Win32.FindData findData = new Win32.FindData();
            Win32.SafeFindHandle handle = Win32.SafeNativeMethods.FindFirstFile(Path.Combine(currentDir.Location, "*"), findData);

            if (!handle.IsInvalid)
            {
                do
                {
                    // don't match . or ..
                    if (findData.fileName.Equals(@".") || findData.fileName.Equals(@".."))
                        continue;

                    #region"Directory"
                    string subdirectory = currentDir.Location + (currentDir.Location.EndsWith(@"\") ? "" : @"\") + findData.fileName;
                    if ((findData.fileAttributes & (int)FileAttributes.Directory) != 0)
                    {
                        FileDirectoryModel newDirSearch = new FileDirectoryModel
                        (
                        _index,                       // Index/ ID.
                        currentDir.ID,                // Parent ID.
                        (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                        subdirectory,                 // Current levels or parent directory.
                        findData.fileName             // Name of children directory or file.
                        );

                        // it's a directory - recourse into it
                        ScanThumbDBFiles(newDirSearch);
                    }
                    #endregion"Directory"

                    else

                    #region"Files"
                    {
                        // it's a file, see if any of the file specs matches it
                        foreach (Regex fileSpec in m_fileSpecs)
                        {
                            // if this spec not matches, no return this file's info
                            if (!fileSpec.IsMatch(findData.fileName))
                                continue;

                            /*_index++;
                            string subdirectory = currentDir.Location + (currentDir.Location.EndsWith(@"\") ? "" : @"\") + findData.fileName;

                            FileDirectoryModel newDir = new FileDirectoryModel
                                (
                                _index,                     // Index/ ID.
                                currentDir.ID,              // Parent ID.
                                (FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                                (subdirectory.Replace((_defaultProjectsDirectory + "\\"), "")),  // Current levels or parent directory.
                                findData.fileName           // Name of children directory or file.
                            );
                            dir.Add(newDir);*/

                            _index++;

                            var newFile = new FileDirectoryModel
                            (
                                _index,                     // Index/ ID.
                                currentDir.ID,              // Parent ID.
                                (System.IO.FileAttributes)findData.fileAttributes,    // Define they possible type, File or Directory.
                                (currentDir.Location.Replace(_defaultProjectsDirectory + "\\", "")), // Current levels or parent directory.
                                findData.fileName           // Name of file.
                            );
                            dir.Add(newFile);
                        }
                    }
                    #endregion"Files"

                } while (Win32.SafeNativeMethods.FindNextFile(handle, findData));

                // close this find handle
                handle.Close();
            }
            return dir;
        }

    }

}



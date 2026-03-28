using MyStuff11net.Properties;
using System.Text.RegularExpressions;



namespace MyStuff11net
{
    public class DirectoryFile : IDisposable
    {
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        private MyCode.HTMLFileTemple TempleToBeUse;

        static DirectoryInfo _directoryInfo;
        static FileSystemInfo _fileSystemInfo;
        static FileAttributes _fileAttributes;
        static FileInfo _fileInfo;

        /// <summary>
        /// Keep the full path address of the project.
        /// Settings.Default.DataBaseAddress + ProjectPathWithoutDataBaseAddress
        /// </summary>
        public string ProjectFullPath { get; set; }

        /// <summary>
        /// Get the file name without extension from ProjectPathWithoutDataBaseAddress property.
        /// FileNameWithoutExtension, ProjectName file, example: 1103-03 Desktop_LCD
        /// </summary>
        public string ProjectFileName
        {
            get
            {
                return Path.GetFileNameWithoutExtension(ProjectPathWithoutDataBaseAddress);
            }
        }

        /// <summary>
        /// Keep the full path address of the project, without file name and ext.
        /// Settings.Default.DataBaseAddress + ProjectPathWithoutDataBaseAddress - ProjectFileName.ext.
        /// </summary>
        public string ProjectFullPathOutFileName
        {
            get
            {
                string projectfileNameExt = Path.GetFileName(ProjectPathWithoutDataBaseAddress);

                //   if (TempleToBeUse == MyCode.HTMLFileTemple.SMTproject)
                return Settings.Default.DataBaseAddress + ProjectPathWithoutDataBaseAddress.Replace(projectfileNameExt, "");
            }
        }

        string _projectPathWithoutDataBaseAddress;
        /// <summary>
        /// Keep the information about the project address without the database path.
        /// //H5H//ProjectName folder//ProjectName.xxx
        /// </summary>
        public string ProjectPathWithoutDataBaseAddress
        {
            get
            {
                return _projectPathWithoutDataBaseAddress;
            }
            set
            {
                _projectPathWithoutDataBaseAddress = value;
            }
        }


        /// <summary>
        /// Initialize a new class DirectoryFile, no parameter.
        /// Allows access to the methods available in this class.
        /// </summary>
        /// <param name="projectFullAddress"></param>
        public DirectoryFile()
        {

        }

        /// <summary>
        /// Initialize a new class DirectoryFile, input string contains the full address of file.
        /// C:\Documents and Settings\Jose L. Reyes\My Documents\ProductionManager\H5H Files\1061-05_4BANK NiCAD\FileName.ext
        /// </summary>
        /// <param name="projectFullAddress"></param>
        public DirectoryFile(string projectFullAddress)
        {
            try
            {
                ProjectFullPath = projectFullAddress;

                _directoryInfo = new DirectoryInfo(ProjectFullPathOutFileName);
                _fileSystemInfo = new FileInfo(ProjectFullPath);
                _fileInfo = new FileInfo(ProjectFullPath);

                if (_fileSystemInfo.Exists)
                    _fileAttributes = File.GetAttributes(ProjectFullPath);
            }
            catch (Exception error)
            {
                MessageBox.Show(@"DirectoryFile has found an error. This input projectFullAddress " + projectFullAddress + "\r\n" +
                                          @"generated the follow error, " + error.Message, @"Initialize a new DirectoryFile class.",
                                                                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initialize a new class DirectoryFile, input string contains the full address of file.
        /// C:\Documents and Settings\Jose L. Reyes\My Documents\ProductionManager\H5H Files\1061-05_4BANK NiCAD\FileName.ext
        /// </summary>
        /// <param name="projectFullAddress"></param>
        public DirectoryFile(string projectFullAddress, MyCode.HTMLFileTemple templeToUse)
        {
            try
            {
                TempleToBeUse = templeToUse;

                ProjectFullPath = projectFullAddress;

                _directoryInfo = new DirectoryInfo(ProjectFullPath);
                _fileSystemInfo = new FileInfo(ProjectFullPath);
                _fileInfo = new FileInfo(ProjectFullPath);

                if (_fileSystemInfo.Exists)
                    _fileAttributes = File.GetAttributes(ProjectFullPath);
            }
            catch (Exception error)
            {
                MessageBox.Show(@"DirectoryFile has found an error. This input projectFullAddress " + projectFullAddress + @"\r\n" +
                                     @"and this HTMLtempleToUse " + templeToUse + @", generated the follow error, " + error.Message,
                                             @"Initialize a new DirectoryFile class.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Exposes instance methods for creating, moving, and enumerating through directories and subdirectories.
        /// Use it's for typical operations such as copying, moving, renaming, creating, and deleting directories.
        /// </summary>
        public DirectoryInfo DirectoryInfo
        {
            get
            {
                return _directoryInfo;
            }
            set
            {
                _directoryInfo = value;
            }
        }

        /// <summary>
        /// Provides the base class for both FileInfo and DirectoryInfo objects.
        /// </summary>
        public FileSystemInfo FileSystemInfo
        {
            get
            {
                return _fileSystemInfo;
            }
            set
            {
                _fileSystemInfo = value;
            }
        }


        public FileInfo FileInfo
        {
            get
            {
                return _fileInfo;
            }
        }

        /// <summary>
        /// Provides attributes for files and directories.
        /// This enumeration has a FlagsAttribute attribute that allows a bitwise combination of its member values.
        /// </summary>
        public FileAttributes FileAttributes
        {
            get
            {
                return _fileAttributes;
            }
            set
            {
                _fileAttributes = value;
            }
        }

        /// <summary>
        /// Return any valid path if exist.
        /// </summary>
        public string ValidPath
        {
            get
            {
                var parentExist = _directoryInfo.Parent.Exists;
                var directoryInfoParent = _directoryInfo.Parent;

                while (!parentExist)
                {
                    directoryInfoParent = directoryInfoParent.Parent;
                    parentExist = directoryInfoParent.Exists;
                }

                var validPath = directoryInfoParent.FullName;

                return validPath;
            }
            private set { }
        }

        /// <summary>
        /// Returns pcb side for this project.
        /// </summary>
        /// <param name="projectFileName">todo: describe projectFileName parameter on PWBSide</param>
        public string PWBSide(string projectFileName)
        {
            //Validate input
            if (string.IsNullOrEmpty(projectFileName))
                return "Undefined";

            if (projectFileName.Length < 5)
                return "Undefined";


            //any PartNumber will be at least 4 characters + T or B (1106-AAT_ProjectName.h5h or .h7h)
            int indexOf_ = projectFileName.IndexOf('_');
            if (indexOf_ == -1)
                return "Undefined";

            string _code = projectFileName.Substring(0, 4);
            if (StringFunctions.IsNumeric(_code))
            {
                if (projectFileName.Substring((indexOf_ - 1), 1).Contains("T"))
                    return "Top";

                if (projectFileName.Substring((indexOf_ - 1), 1).Contains("B"))
                    return "Bottom";
            }
            return "Undefined";
        }

        public bool Exists
        {
            get
            {
                return DirectoryInfo.Exists;
            }
            private set { }
        }

        /// <summary>
        /// Copy a picture file to folder Settings.Default.DataBaseAddress + "\\Picture\\",
        /// renameDiskFileName, true to rename with fileName, false keep original fileName,
        /// deleteOriginalFile, true to delete the source file, false keep source file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="renameDistFileName"></param>
        /// <param name="deleteOriginalFile"></param>
        /// <returns></returns>
        public string CopyFileToPicture(string fileName, bool renameDiskFileName, bool deleteOriginalFile)
        {
            using (var openfile = new OpenFileDialogExt
            {
                Title = @"Please select any Image",
                FileName = "",
                Multiselect = false,
                Filter = @"*.jpg|*.jpg|*.png|*.png|*.gif|*.gif",
                DefaultExt = "(*.jpg)|*.jpg",
                InitialDirectory = Settings.Default.DataBaseAddress + "\\CAMERA WIFI PICTURES\\",
            }
                   )
            {
                if (openfile.ShowDialog(new Form() { TopMost = true }) == DialogResult.Cancel)
                    return "";

                try
                {
                    //Using FileInfo class copy the file.
                    var fileInfo = new FileInfo(openfile.FileName);
                    var diskFileName = Settings.Default.DataBaseAddress + "\\Picture\\" +
                                                          openfile.FileName + Path.GetExtension(openfile.FileName);

                    if (renameDiskFileName)
                        diskFileName = Settings.Default.DataBaseAddress + "\\Picture\\" +
                                                          fileName + Path.GetExtension(openfile.FileName);

                    // The user has selected a picture in Picture folder. Do not copy again.
                    if (openfile.FileName.Contains(Settings.Default.DataBaseAddress + "\\Picture\\"))
                    {
                        File.Move(openfile.FileName, diskFileName);
                        return diskFileName;
                    }

                    fileInfo.CopyTo(diskFileName, true);

                    if (deleteOriginalFile)
                        fileInfo.Delete();

                    return Path.GetFileName(diskFileName);
                }
                catch (Exception except)
                {
                    MessageBox.Show(new Form() { TopMost = true }, @"Image Error ; " + except.Message,
                        @"Error in CopyFileToPicture(string fileName), class DirectoryFile.cs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return "";
        }

        /// <summary>
        /// Copy a file image or multifile image to destiny folder, the destiny folder most exist and have write access.
        /// </summary>
        /// <param name="destinyFolder">Settings.Default.DataBaseAddress + "\\Picture\\" + Existent folder</param>
        public string[] CopyMultiFileToFolder()
        {
            using (var openfile = new OpenFileDialogExt
            {
                Title = @"Please select any Image",
                FileName = "",
                Multiselect = true,
                Filter = @"*.jpg|*.jpg|*.png|*.png|*.gif|*.gif",
                DefaultExt = "(*.jpg)|*.jpg",
                InitialDirectory = Settings.Default.DataBaseAddress + "\\CAMERA WIFI PICTURES\\",
            }
                   )
            {
                if (openfile.ShowDialog(new Form() { TopMost = true }) == DialogResult.Cancel)
                    return new string[] { };

                return openfile.FileNames;
            }
        }

        /// <summary>
        /// Copy a file image or multifile image to destiny folder, the destiny folder most exist and have write access.
        /// </summary>
        /// <param name="destinyFolder">Settings.Default.DataBaseAddress + "\\Picture\\" + Existent folder</param>
        public void CopyMultiFileToFolder(string destinyFolder)
        {
            using (var openfile = new OpenFileDialogExt
            {
                Title = @"Please select any Image",
                FileName = "",
                Multiselect = true,
                Filter = @"*.jpg|*.jpg|*.png|*.png|*.gif|*.gif",
                DefaultExt = "(*.jpg)|*.jpg",
                InitialDirectory = Settings.Default.DataBaseAddress + "\\CAMERA WIFI PICTURES\\",
            }
                   )
            {
                if (openfile.ShowDialog(new Form() { TopMost = true }) == DialogResult.Cancel)
                    return;

                try
                {
                    foreach (string strfileName in openfile.FileNames)
                    {
                        //Using FileInfo class copy the file.
                        FileInfo fileInfo = new FileInfo(strfileName);
                        string diskFileName = Path.Combine(destinyFolder, Path.GetFileName(strfileName));

                        fileInfo.CopyTo(diskFileName, false);
                    }
                }
                catch (Exception except)
                {
                    MessageBox.Show(new Form() { TopMost = true }, @"Image Error ; " + except.Message,
                        @"Error in CopyMultiFileToPicture(), class DirectoryFile.cs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Process DataSheet files to folder Settings.Default.DataBaseAddress + "\\DataSheets\\",
        /// renameDiskFileName, true to rename with fileName, false keep original fileName,
        /// deleteOriginalFile, true to delete the source file, false keep source file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="renameDistFileName"></param>
        /// <param name="deleteOriginalFile"></param>
        /// <returns></returns>
        public string[] ProcessDataSheetFiles(string fileName, bool renameDiskFileName, bool deleteOriginalFile)
        {
            using (var openfile = new OpenFileDialogExt(MyStuff11net.OpenFileDialogExt.DialogViewTypes.List)
            {
                Title = @"Please select a pdf file for " + fileName + ".",
                FileName = "",
                Multiselect = true,
                Filter = @"*.pdf|*.pdf",
                DefaultExt = "(*.pdf)|*.pdf",
                InitialDirectory = Settings.Default.DataBaseAddress + "\\DataSheets\\",
            })
            {
                if (openfile.ShowDialog(new Form { TopMost = true }) == DialogResult.Cancel)
                    return new string[] { };

                try
                {
                    foreach (string strFileName in openfile.FileNames)
                    {
                        //Using FileInfo class copy the file.
                        var fileInfo = new FileInfo(openfile.FileName);
                        var diskFileName = Settings.Default.DataBaseAddress + "\\DataSheets\\" + Path.GetFileName(strFileName);

                        if (renameDiskFileName)
                            diskFileName = Settings.Default.DataBaseAddress + "\\DataSheets\\" + fileName + Path.GetExtension(strFileName);

                        if (!File.Exists(diskFileName))
                            fileInfo.CopyTo(diskFileName, true);

                        if (deleteOriginalFile)
                            fileInfo.Delete();
                    }

                    return openfile.FileNames;
                }
                catch (Exception except)
                {
                    MessageBox.Show(new Form { TopMost = true }, @"DataSheets Error ; " + except.Message,
                        @"Error in CopyFileToDataSheet(string fileName), class DirectoryFile.cs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return new string[] { };
        }

        //DirectoryInfo d = new DirectoryInfo("....");
        //FileInfo[] infos = d.GetFiles();
        //foreach(FileInfo f in infos)
        //{
        //    File.Move(f.FullName, f.FullName.ToString().Replace("abc_","");
        //}

        public bool IsValidPath(string path)
        {
            Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
            if (!driveCheck.IsMatch(path.Substring(0, 3))) return false;
            string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
            strTheseAreInvalidFileNameChars += @":/?*" + "\"";
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
            if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
                return false;

            var dir = new DirectoryInfo(Path.GetFullPath(path));
            if (!dir.Exists)
                return false; // dir.Create();

            return true;
        }
    }
}

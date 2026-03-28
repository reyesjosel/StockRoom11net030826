using System.Data;
using System.Runtime.InteropServices.ComTypes;
using WIN32_FIND_DATA = MyStuff11net.UsingKernel32.WIN32_FIND_DATA;

namespace MyStuff11net
{
    public sealed class FileDirectoryModel
    {
        public FileDirectoryModel() { }

        public FileDirectoryModel(int index, int? paret_ID, WIN32_FIND_DATA fileDirData)
        {
            ID = index;
            Parent_ID = paret_ID;
            _fileDirData = fileDirData;

            Text_Name = _fileDirData.cFileName;

            ExistThumbs = false;
        }

        public FileDirectoryModel(int _index, int? _paret_ID, FileAttributes _fileAttributes, string _location, string _name)
        {
            ID = _index;
            Parent_ID = _paret_ID;
            Text_Name = _name;
            FileAttributes = _fileAttributes;
            Location = _location;

            ExistThumbs = false;

            ProjectName = Path.Combine(_location, _name);
        }

        DataRowView _myRow;
        public FileDirectoryModel(DataRowView rowBound)
        {
            _myRow = rowBound;

            ID = MyCode.IntParseFast(rowBound["ID"].ToString());
            Parent_ID = rowBound["Parent_ID"] == DBNull.Value ? (int?)null : Convert.ToInt32(rowBound["Parent_ID"]);
            Text_Name = (rowBound["Text_Name"] ?? "Undefined Name") as string;
            ProjectName = (rowBound["ProjectName"] ?? "Undefined Name") as string;

            Image = (rowBound["Image"] ?? "Undefined Image").ToString();
            Description_Short = (rowBound["Description_Short"] ?? "Undefined Description").ToString();
            Description_Expand = (rowBound["Description_Expand"] ?? "Undefined Description").ToString();

            ExistThumbs = (bool)rowBound["ItemOpen"];
        }

        /*s
                        _index,                     // Index/ ID.
                        currentDir.ID,              // Parent ID.
                        FileAttributes.Directory,   // Define they possible type, File or Directory.
                        currentDir.Location,        // Current levels or parent directory.
                        _fileDirData.cFileName      // Name of file.
        */

        #region Private Members

        private string _location;
        private FileAttributes _fileAttributes;

        private FILETIME _ftCreationTime;
        private FILETIME _ftLastAccessTime;
        private FILETIME _ftLastWriteTime;

        private WIN32_FIND_DATA _fileDirData;
        #endregion

        #region Public Members

        public int ID { get; set; }

        public int? Parent_ID { get; set; }

        /// <summary>
        /// Contains the file name, return the value in Text_Name.
        /// </summary>
        public string Name
        {
            get { return Text_Name; }
        }

        public string Ext
        {
            get
            {
                var _ext = Path.GetExtension(Text_Name);
                return _ext.Replace(".", "");
            }
        }

        /// <summary>
        /// Contains the address and file name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Return the file name.
        /// </summary>
        public string Text_Name { get; set; }

        public string Image { get; set; }

        public string Description_Short { get; set; }

        public string Description_Expand { get; set; }

        /// <summary>
        /// Contains the path address.
        /// </summary>
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
            }
        }

        public bool ExistThumbs { get; set; }

        public bool IsFile
        {
            get
            {
                if ((FileAttributes & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory)
                    return false;

                return true;
            }
        }

        public bool IsDirectory
        {
            get
            {
                if ((FileAttributes & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory)
                    return true;

                return false;
            }
        }

        public FileAttributes FileAttributes
        {
            get { return _fileAttributes; }
            set
            {
                _fileAttributes = value;
            }
        }

        public FILETIME CreationTime
        {
            get { return _ftCreationTime; }
            set
            {
                _ftCreationTime = value;
            }
        }

        public FILETIME LastAccessTime
        {
            get { return _ftLastAccessTime; }
            set
            {
                _ftLastAccessTime = value;
            }
        }

        public FILETIME LastWriteTime
        {
            get { return _ftLastWriteTime; }
            set
            {
                _ftLastWriteTime = value;
            }
        }

        #endregion Public Members
    }
}

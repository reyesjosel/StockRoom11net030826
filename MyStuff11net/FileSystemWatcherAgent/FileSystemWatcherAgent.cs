namespace MyStuff11net
{
    public class FileSystemWatcherAgent
    {
        #region"Events"

        public delegate void FileErrorEventHandler(object sender, ErrorEventArgs e);
        public event FileErrorEventHandler FileError;

        public delegate void FileCreatedEventHandler(object sender, FileSystemEventArgs e);
        public event FileCreatedEventHandler FileCreated;

        public delegate void FileChangingEventHandler(object sender, FileSystemEventArgs e);
        public event FileChangingEventHandler FileChanging;

        public delegate void FileHasChangedEventHandler(object sender, FileSystemEventArgs e);
        public event FileHasChangedEventHandler FileHasChanged;

        public delegate void FileDeletedEventHandler(object sender, FileSystemEventArgs e);
        public event FileDeletedEventHandler FileDeleted;

        public delegate void FileRenamedEventHandler(object sender, RenamedEventArgs e);
        public event FileRenamedEventHandler FileRenamed;

        public delegate void DirectoryRenamedEventHandler(object sender, RenamedEventArgs e);
        public event DirectoryRenamedEventHandler DirectoryRenamed;

        #endregion"Events"

        FileSystemWatcher fileSystemWatcher;

        public string FolderPath { get; private set; }

        public FileSystemWatcherAgent(string folderPath)
        {
            FolderPath = folderPath;

            InitializeFileSystemWatcher();
        }

        void InitializeFileSystemWatcher()
        {
            // If there is no folder selected, to nothing
            if (string.IsNullOrWhiteSpace(FolderPath))
                return;

            fileSystemWatcher = new FileSystemWatcher();

            // Set folder path to watch
            fileSystemWatcher.Path = FolderPath;
            fileSystemWatcher.IncludeSubdirectories = true;

            // Gets or sets the type of changes to watch for.
            // In this case we will watch change of filename, last modified time, size and directory name
            fileSystemWatcher.NotifyFilter = NotifyFilters.Size |
                                             NotifyFilters.FileName |
                                             NotifyFilters.LastWrite |
                                             NotifyFilters.DirectoryName;



            // Event handlers that are watching for specific event
            fileSystemWatcher.Error += FileSystemWatcher_Error;
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;

            // NOTE: If you want to monitor specified files in folder, you can use this filter
            fileSystemWatcher.Filter = "*.*";

            // START watching
            StartFileSystemWatcher();
        }

        void StartFileSystemWatcher()
        {
            // START watching
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        void StopFileSystemWatcher()
        {
            // Stop watching
            fileSystemWatcher.EnableRaisingEvents = false;
        }

        void FileSystemWatcher_Error(object sender, ErrorEventArgs e)
        {
            FileError?.Invoke(this, e);
        }

        void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            FileCreated?.Invoke(this, e);
        }

        void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            FileChanging?.Invoke(this, e);
            FileChanged(e);
        }

        void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            FileDeleted?.Invoke(this, e);
        }

        void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (File.Exists(e.FullPath))
                FileRenamed?.Invoke(this, e);
            else
                DirectoryRenamed?.Invoke(this, e);
        }

        void FileChanged(FileSystemEventArgs e)
        {
            if (!IsFileReady(e.FullPath))
                return; //first notification the file is arriving

            //The file has completed arrived, so lets process it
            FileHasChanged?.Invoke(this, e);
        }

        bool IsFileReady(string path)
        {
            //One exception per file rather than several like in the polling pattern
            try
            {
                if (!File.Exists(path))
                    return false;

                //If we can't open the file, it's still copying
                using (var file = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}

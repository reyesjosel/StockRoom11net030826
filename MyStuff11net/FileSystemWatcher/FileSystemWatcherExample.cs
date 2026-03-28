namespace MyStuff11net
{
    class FileSystemWatcherExample : Form
    {
        public void CreateFileWatcher(string path)
        {
            // Create a new FileSystemWatcher and set its properties.
            System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
            watcher.Path = path;
            /* Watch for changes in LastAccess and LastWrite times, and 
               the renaming of files or directories. */
            watcher.NotifyFilter = System.IO.NotifyFilters.LastAccess | System.IO.NotifyFilters.LastWrite
               | System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        // Define the event handlers.
        private static void OnChanged(object source, System.IO.FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

        private static void OnRenamed(object source, System.IO.RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
        }


        /*You indeed need a thread that would open all files and read a byte from them, my program
         stopped working after I ran it on Windows 7 instead of XP, I used the following code*/
        private void SingleByteReadThread(string pathRootFolder)
        {
            while (true)
            {
                using (FileSystemEnumerator fse = new FileSystemEnumerator(
                                                                            pathRootFolder,
                                                                            "*.*",
                                                                            true,
                                                                            true,
                                                                            0))
                {
                    foreach (FileInfo fi in fse.MatchesFiles())
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(fi.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                            fs.ReadByte();
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
        }
        //DirectoryEnumerator is my own class




        /*I wanted to access network resources, but did not have sufficient share permissions because
        the code ran under the ASP user. I also had a service that copied files every night between file
        shares in two different domains. I wanted a way to access remote resources without opening up
        security holes by changing permissions or running as a privileged user.
            If you require persistent connections, declare an instance of the class and use the
        NetUseWithCredentials() method to connect. Once connected, you can access the remote resource at
        need until disconnected. Do not forget to remove the connection when you are finished using the
        NetUseDelete() method..*/

        void ConnectToUNC_Path(string uncpath, string user, string domain, string password)
        {
            using (UNCAccessWithCredentials unc = new UNCAccessWithCredentials())
            {
                if (unc.NetUseWithCredentials(uncpath, user, domain, password))
                {
                    // Insert your code that requires access to the UNC resource
                }
                else
                {
                    // The connection has failed. Use the LastError to get the system error code
                    MessageBox.Show("Failed to connect to " + uncpath +
                                    "\r\nLastError = " + unc.LastError.ToString(),
                                    "Failed to connect",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                // When it reaches the end of the using block, the class deletes the connection.
            }
        }


        #region"Instantiate FileSystemWatcher class, set handlers, start monitoring, and display the action message."

        TextBox TextBoxFolderPath = new TextBox();
        ListBox ListBoxFileSystemWatcher = new ListBox();

        private void ButtonOpenFolderDialog_Click(object sender, EventArgs e)
        {
            // Browse folder to monitor
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxFolderPath.Text = folderBrowserDialog.SelectedPath;
            }

            // Start file system watcher on selected folder
            StartFileSystemWatcher();
        }

        private void StartFileSystemWatcher()
        {
            string folderPath = TextBoxFolderPath.Text;

            // If there is no folder selected, to nothing
            if (string.IsNullOrWhiteSpace(folderPath))
                return;

            System.IO.FileSystemWatcher fileSystemWatcher = new System.IO.FileSystemWatcher();

            // Set folder path to watch
            fileSystemWatcher.Path = folderPath;

            // Gets or sets the type of changes to watch for.
            // In this case we will watch change of filename, last modified time, size and directory name
            fileSystemWatcher.NotifyFilter = System.IO.NotifyFilters.FileName |
                System.IO.NotifyFilters.LastWrite |
                System.IO.NotifyFilters.Size |
                System.IO.NotifyFilters.DirectoryName;


            // Event handlers that are watching for specific event
            fileSystemWatcher.Created += fileSystemWatcher_Created;
            fileSystemWatcher.Changed += fileSystemWatcher_Changed;
            fileSystemWatcher.Deleted += fileSystemWatcher_Deleted;
            fileSystemWatcher.Renamed += fileSystemWatcher_Renamed;

            // NOTE: If you want to monitor specified files in folder, you can use this filter
            // fileSystemWatcher.Filter

            // START watching
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        // ----------------------------------------------------------------------------------
        // Events that do all the monitoring
        // ----------------------------------------------------------------------------------

        void fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            DisplayFileSystemWatcherInfo(e.ChangeType, e.Name);
        }

        void fileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            DisplayFileSystemWatcherInfo(e.ChangeType, e.Name);
        }

        void fileSystemWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            DisplayFileSystemWatcherInfo(e.ChangeType, e.Name);
        }

        void fileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            DisplayFileSystemWatcherInfo(e.ChangeType, e.Name, e.OldName);
        }

        // ----------------------------------------------------------------------------------

        void DisplayFileSystemWatcherInfo(System.IO.WatcherChangeTypes watcherChangeTypes, string name, string oldName = null)
        {
            if (watcherChangeTypes == System.IO.WatcherChangeTypes.Renamed)
            {
                // When using FileSystemWatcher event's be aware that these events will be called on a separate thread automatically!!!
                // If you call method AddListLine() in a normal way, it will throw following exception: 
                // "The calling thread cannot access this object because a different thread owns it"
                // To fix this, you must call this method using Dispatcher.BeginInvoke(...)!

                Invoke(new EventHandler(delegate (object o, EventArgs e)
                {
                    //Do your work here.
                    AddListLine(string.Format("{0} -> {1} to {2} - {3}",
                                              watcherChangeTypes.ToString(), oldName, name, DateTime.Now));
                }));

            }
            else
            {
                Invoke(new EventHandler(delegate (object o, EventArgs e)
                    {
                        //Do your work here.
                        AddListLine(string.Format("{0} -> {1} - {2}",
                                                  watcherChangeTypes.ToString(), name, DateTime.Now));
                    }));
            }
        }

        public void AddListLine(string text)
        {
            ListBoxFileSystemWatcher.Items.Add(text);
        }

        #endregion"Instantiate FileSystemWatcher class, set handlers, start monitoring, and display the action message."

    }
}

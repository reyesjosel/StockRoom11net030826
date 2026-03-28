using System.ComponentModel;
using System.Text;
using LogFileMessageEventArgs = MyStuff11net.Custom_Events_Args.LogFileMessageEventArgs;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;
using Tags = MyStuff11net.HTML_Tags;

namespace MyStuff11net
{
    public class LogFileProcess
    {
        public enum LogFileStatus
        {
            /// <summary>
            /// The file is ready.
            /// </summary>
            [Description("The file is ready.")]
            Ready,
            /// <summary>
            /// The file is not ready.
            /// </summary>
            [Description("The file is not ready.")]
            No_Ready,
            /// <summary>
            /// The file was create and ready.
            /// </summary>
            [Description("Created a new file.")]
            Created,
            /// <summary>
            /// The directory was not found.
            /// </summary>
            [Description("Not found directory.")]
            NOT_Founded
        }

        LogFileStatus logfilestatus;
        /// <summary>
        /// Status of current log file process.
        /// </summary>
        public LogFileStatus LogStatus
        {
            get
            {
                return logfilestatus;
            }
            set
            {
                logfilestatus = value;
            }
        }

        private MyCode.HTMLFileTemple TempleToBeUse;

        private DirectoryFile FileProperties;
        private DirectoryFile LogFileProperties;

        private string TempleFilePath_Name = "";

        /// <summary>
        /// LogFileHTML lines existent into the file.
        /// </summary>
        public List<string> LogFileHTML = new List<string>();

        /// <summary>
        /// Initializes a log file using logFilePath_Name, if the file does not exist,
        /// initializing a new file using the specified temple.
        /// </summary>
        /// <param name="templeFilePath_Name">Path.Combine(Settings.Default.DataBaseAddress, "\\Resources\\HTML pages\\ProjectLogFile temple modif.html");</param>
        /// <param name="templeToUse">Temple to be used in the initialization of the new file.</param>
        /// <param name="logFilePath_Name"> Path.Combine(Settings.Default.DataBaseAddress + "\\LogFile\\" + CurrentDepartmentLogIn.DeptName,
        /// DateTime.Now.ToString("MM"), CurrentDepartmentLogIn.DeptName + DateTime.Now.ToString("dd") + ".html";);</param>
        public LogFileProcess(string logFilePath_Name, string templeFilePath_Name, MyCode.HTMLFileTemple templeToUse)
        {
            TempleFilePath_Name = templeFilePath_Name;

            FileProperties = new DirectoryFile(logFilePath_Name, templeToUse);

            TempleToBeUse = templeToUse;

            InitializeLogFile();
        }


        private void InitializeLogFile()
        {
            var messageError = "";
            try
            {
                if (FileProperties.ProjectFullPath == "")
                {
                    MessageBox.Show(@"Project name information loss in row[""ProjectName""]", @"DataRow information loss.",
                                                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogStatus = LogFileStatus.No_Ready;
                    return;
                }

                messageError = "Creating a new LogFileProperties.";
                LogFileProperties = new DirectoryFile(FileProperties.ProjectFullPath, TempleToBeUse);

                if (LogFileProperties.FileInfo.Exists)
                {
                    messageError = "LogFileProperties.FileInfo exist.";
                    #region"If log file properties exist."
                    if ((LogFileProperties.FileInfo.Length > 10 * 1024 * 1024)) // 10 MB will be max size. ( 1024 * 1024 = 1MB)
                    {
                        messageError = "File.Length > 10 mb.";
                        LogStatus = LogFileStatus.No_Ready;
                        string dateName = string.Join("-", DateTime.Now.ToShortDateString().Split(Path.GetInvalidFileNameChars()));
                        string backupName = FileProperties.ProjectFullPath.Replace(".html", "(Backup " + dateName + ").html");

                        messageError = "Copy to backup file.";
                        if (Directory.Exists(LogFileProperties.ProjectFullPathOutFileName))
                            LogFileProperties.FileInfo.CopyTo(backupName);

                        // Call again to created the file.
                        messageError = "InitalizeLogFile again.";
                        InitializeLogFile();
                        return;
                    }
                    else
                    {
                        messageError = "File.Length < 10 mb.";
                        LogFileHTML = File.ReadAllLines(FileProperties.ProjectFullPath, Encoding.UTF8).ToList();

                        var indexWhereInsert = LogFileHTML.IndexOf(Tags.TextWhereInsert);

                        if (indexWhereInsert == -1)
                        {
                            LogStatus = LogFileStatus.No_Ready;
                            using (var form1 = new Form { TopMost = true })
                            {
                                MessageBox.Show(@"Project log file contains error information or old formatted file was used, " + Environment.NewLine +
                                                  FileProperties.ProjectFullPath + Environment.NewLine +
                                                  @"(<!-- Insert new information here. -->) this string has been present.",
                                                  @"Error in InitializeLogFile(), LogFileProcess Ln 119.",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            messageError = "FileInfo.Delete();";
                            FileProperties.FileInfo.Delete();
                            // Call again to created the file.
                            messageError = "InitializeLogFile(); after deleted old file.";
                            InitializeLogFile();
                            return;
                        }
                        LogStatus = LogFileStatus.Ready;
                    }
                    #endregion"If log file properties exist."
                }
                else
                {
                    #region"The LogFile no exist, create a new one."
                    LogStatus = LogFileStatus.NOT_Founded;
                    messageError = "The LogFile no exist, create a new one. = " + FileProperties.ProjectFullPath;

                    var templeLogFile = new FileInfo(TempleFilePath_Name);
                    if (!templeLogFile.Exists)
                    {
                        MyCode.On_StatusBarMessage(new StatusBarMessage_EventArgs("The LogFile temple was no founded. Error in System setting"));
                        return;
                    }

                    var directoryProject = Path.GetDirectoryName(FileProperties.ProjectFullPath);
                    if (!Directory.Exists(directoryProject))
                    {
                        Directory.CreateDirectory(directoryProject);
                        //when The User Write The New Folder It Will Create 
                        MyCode.On_StatusBarMessage(new StatusBarMessage_EventArgs("The File will be Create in " + " " + directoryProject));
                    }

                    templeLogFile.CopyTo(FileProperties.ProjectFullPath, true);
                    MyCode.On_StatusBarMessage(new StatusBarMessage_EventArgs("A new LogFile has been created, " + FileProperties.ProjectFullPath));

                    // Call again to initialize the class.
                    InitializeLogFile();
                    return;
                    #endregion"The LogFile no exist, create a new one."
                }
            }
            catch (Exception error)
            {
                LogStatus = LogFileStatus.No_Ready;

                MessageBox.Show(@"InitializeLogFile() has found an error, " + error.Message + @" in LogFileProcess.\r\n" +
                                                @"TempleFilePath = " + TempleFilePath_Name + Environment.NewLine + messageError,
                                                @"Wrong LogInformation address.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Write_LogFile(LogFileMessageEventArgs e)
        {
            if (LogStatus == LogFileStatus.No_Ready)
                return;

            var indexWhereInsert = LogFileHTML.IndexOf(Tags.TextWhereInsert);

            if (indexWhereInsert == -1 || indexWhereInsert >= LogFileHTML.Count)
            {
                LogStatus = LogFileStatus.No_Ready;
                MessageBox.Show("The system look for the string \" " + Tags.TextWhereInsert + " \" " + Environment.NewLine +
                "and was not found, insert new information is not possible",
                "Wrong formatted HTML file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            e.LogFileMessage.Add("");

            LogFileHTML.InsertRange(indexWhereInsert, e.LogFileMessage);

            FileSystemExt.CallExecuteWithFailOver(FileProperties.ProjectFullPath, LogFileHTML);
        }

        private string Read_LogFile()
        {
            if (LogStatus == LogFileStatus.No_Ready)
                return "LogFile not ready yet.";

            var readedFile = "";
            if (File.Exists(FileProperties.ProjectFullPath))
            {
                using (TextReader tr = new StreamReader(FileProperties.ProjectFullPath))
                {
                    readedFile = tr.ReadToEnd();

                    tr.Close();
                }
            }

            if (readedFile.Length == 0)
                readedFile = "No logInformation has been place yet.";

            return readedFile;
        }

    }
}

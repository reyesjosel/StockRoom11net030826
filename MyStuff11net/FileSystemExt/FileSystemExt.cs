using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using static MyStuff11net.Custom_Events_Args;

namespace MyStuff11net
{
    public class FileSystemExt
    {
        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public static event StatusBarMessage_EventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessage_EventHandler(object sender, StatusBarMessage_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public static void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            // Notify Subscribers
            StatusBarMessage?.Invoke(new object(), e);
        }

        #endregion"StatusBarMessage"


        public static void FileCopy()
        {
            //Using File class.
            File.Create("File address and name");

            File.Copy("Old filename", "New filename");

            File.Delete("File address and name");

            // This is the only .net method available to rename a file and the best option to rename files in .net
            File.Move("Old filename", "New filename");

            //Using FileInfo class.
            FileInfo _fileInfo = new FileInfo("FileName");
            _fileInfo.CopyTo("destFileName", true);
            _fileInfo.Delete();

            List<string> LinesHTMLFile = new List<string>();

            #region"Using StreamWriter"

            string filePath = @"C:\Documents and Settings\My Documents\ProductionManager\HTML pages\ProjectLogFile temple modif.html";

            //Read all lines.
            LinesHTMLFile = File.ReadAllLines(filePath, Encoding.UTF8).ToList();

            //Read all lines using a StreamReader, if you need interact with each line.
            using (FileStream _fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(_fs))
            using (StreamReader sr = new StreamReader(bs, Encoding.UTF8))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    LinesHTMLFile.Add(line);
                }
            }

            //Create a new file.
            StreamWriter HTMLnewFile = new StreamWriter("FileName and address", false, Encoding.UTF8);

            foreach (string linetowrite in LinesHTMLFile)
                HTMLnewFile.WriteLine(linetowrite);

            HTMLnewFile.Close();

            #endregion"Using StreamWriter"
        }

        /// <summary>
        /// FileRename will rename the file in filePath string with the new name in newFileName.
        /// filePath most contain a full path and newFileName most contain new name and extension. 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="newFileName"></param>
        public static void FileRename(string filePath, string newFileName)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new ArgumentException("The file is not found.", filePath);

                if (string.IsNullOrWhiteSpace(newFileName))
                    throw new ArgumentNullException("newFileName", "New file name cannot be null or empty.");

                if (!Path.HasExtension(newFileName))
                    throw new ArgumentException("New file name must contain file extension.", newFileName);

                //         if (newFileName.ToCharArray().Any(Path.GetInvalidFileNameChars().Contains))
                //             throw new ArgumentException("New file name contains illegal filename characters.", newFileName);

                newFileName = Path.Combine(new FileInfo(filePath).DirectoryName, newFileName);

                // This is the only .net method available to rename a file
                File.Move(filePath, newFileName);
            }
            catch (Exception error)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                MessageBox.Show(new Form() { TopMost = true }, @"the file is unavailable because it is:" + Environment.NewLine +
                                                               "still being written to" + Environment.NewLine +
                                                               "or being processed by another thread" + Environment.NewLine +
                                                               "or does not exist (has already been processed)" + Environment.NewLine +
                                                               error.Message,
                                                               @"System has generated an error.",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DirectoryRename(string directoryPath, string newName)
        {
            try
            {
                DirectoryInfo _directory = new DirectoryInfo(directoryPath);

                if (!_directory.Exists)
                    throw new ArgumentException("A valid directory path is required.", directoryPath);

                if (newName.ToCharArray().Any(Path.GetInvalidPathChars().Contains))
                    throw new ArgumentException("New name contains illegal path characters.", newName);

                // This is the only .net method available to rename a file/directory.
                _directory.MoveTo(newName);
            }
            catch (Exception error)
            {
                //the file is unavailable because it is: 
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                MessageBox.Show(new Form() { TopMost = true }, @"the file is unavailable because it is:" + Environment.NewLine +
                                                               "still being written to" + Environment.NewLine +
                                                               "or being processed by another thread" + Environment.NewLine +
                                                               "or does not exist (has already been processed)" + Environment.NewLine +
                                                               error.Message,
                                                               @"System has generated an error.",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * In the Windows API, the maximum length for a path is MAX_PATH, which is defined as 260 characters.
         * A path is structured in the following order: drive letter, colon, backslash, components separated
         * by backslashes, and a null-terminating character, for example, the maximum path on the D drive
         * is D:\<256 chars>NUL.
         * The Unicode versions of several functions permit a maximum path length of approximately 32,000 characters
         * composed of components up to 255 characters in length. To specify that kind of path, use the "\\?\" prefix.
         * The maximum path of 32,000 characters is approximate, because the "\\?\" prefix can be expanded to a longer
         * string, and the expansion applies to the total length.
         */

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteFile(string lpFileName);

        /// <summary>
        /// Delete file or folder with long name
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteLongFileName(string fileName)
        {
            string formattedName = @"\\?\" + fileName;
            DeleteFile(formattedName);
        }

        public static FileAttributes AddAttribute(FileAttributes attributes, FileAttributes attributesToAdd)
        {
            return attributes | attributesToAdd;
        }

        public static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }



        /// <summary>
        /// Performs the action and if this fails will try till 5 times,
        /// in each failure sends a StatusBarMessage.
        /// </summary>
        /// <param name="toDo">Action to do, see CallExecuteWithFailOver()</param>
        /// <param name="fileName"></param>
        public static void ExecuteWithFailOver(Action toDo, string fileName)
        {
            var MaxAttempts = 5;

            for (var i = 1; i <= MaxAttempts; i++)
            {
                try
                {
                    toDo?.Invoke();
                    return;
                }
                catch (IOException ex)
                {
                    var messageString = string.Format("File IO operation is failed. (File name: {0}, Reason: {1})", fileName, ex.Message);
                    On_StatusBarMessage(new StatusBarMessage_EventArgs(messageString));
                    messageString = string.Format("Repeat in {0} milliseconds.", i * 500);
                    On_StatusBarMessage(new StatusBarMessage_EventArgs("", messageString));

                    if (i < MaxAttempts)
                        Thread.Sleep(500 * i);
                }
            }

            throw new IOException(string.Format(CultureInfo.InvariantCulture, "Failed to process file. (File name: {0})", fileName));
        }

        /// <summary>
        /// Example how call ExecuteWithFailOver() method.
        /// </summary>
        /// <param name="fileName">todo: describe fileName parameter on CallExecuteWithFailOver</param>
        /// <param name="content">todo: describe content parameter on CallExecuteWithFailOver</param>
        public static void CallExecuteWithFailOver(string fileName, List<string> content)
        {
            Action toDo = () =>
            {
                if (File.Exists(fileName))
                    File.SetAttributes(fileName, FileAttributes.Normal);

                File.WriteAllLines(
                                    fileName,
                                    content,
                                    Encoding.UTF8
                                  );
            };

            ExecuteWithFailOver(toDo, fileName);
        }



        void Button1_Click(object sender, EventArgs e)
        {
            string source, destination;
            var overwrite = false;

            //Mention here your source and destination path 
            //source mean where you want copy file and destination means where you move to that file
            source = "E:\\temp1";
            destination = "E:\\temp2";
            MoveFiles(source, destination, overwrite);
            //Finally delete old folder after copy that files
            if (Directory.Exists(source))
            {
                Directory.Delete(source);
            }
        }

        /// <summary>
        /// Move all files from one directory to other directory, including sub folder files too
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="overwrite"></param>
        public static void MoveFiles(string source, string destination, bool overwrite)
        {
            var inputDir = new DirectoryInfo(source);
            var outputDir = new DirectoryInfo(destination);

            if (!TestIfDirExist(inputDir))
                return;
            if (!TestIfDirExist(outputDir))
                return;

            try
            {
                #region"copy a file"
                foreach (FileInfo eachfile in inputDir.GetFiles())
                {
                    var copyToFile = new FileInfo(Path.Combine(outputDir.FullName, eachfile.Name));
                    if (overwrite == false)
                        if (copyToFile.Exists)
                            continue;

                    eachfile.CopyTo(copyToFile.FullName, overwrite);
                    //File.Delete(file.FullName);
                }
                #endregion"copy a file"

                #region"copy Sub folder"
                foreach (DirectoryInfo subfolderFile in inputDir.GetDirectories())
                {
                    var dirToCopy = new DirectoryInfo(Path.Combine(outputDir.FullName, subfolderFile.Name));
                    if (!dirToCopy.Exists)
                        dirToCopy.Create();

                    if ((subfolderFile.FullName != outputDir.ToString()))
                    {
                        MoveFiles(subfolderFile.FullName, dirToCopy.FullName, overwrite);
                    }
                    //Directory.Delete(dir.FullName);
                }
                #endregion"copy Sub folder"
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message,
                                          @"MoveFiles() has generated an error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static bool TestIfDirExist(DirectoryInfo dirToTest)
        {
            if ((dirToTest.Exists))
                return true;
            else
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"The directory " + dirToTest.FullName + "do not exist.",
                                          @"MoveFiles() has generated an error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }
    }
}

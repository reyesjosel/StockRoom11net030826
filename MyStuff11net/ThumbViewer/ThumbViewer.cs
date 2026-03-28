using MyStuff11net.Properties;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using static MyStuff11net.Custom_Events_Args;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;
using ThumbNailClick_EventArgs = MyStuff11net.Custom_Events_Args.ThumbNailClick_EventArgs;
using ThumbNailMouseEnter_EventArgs = MyStuff11net.Custom_Events_Args.ThumbNailMouseEnter_EventArgs;
using ThumbNailMouseMove_EventArgs = MyStuff11net.Custom_Events_Args.ThumbNailMouseMove_EventArgs;

namespace MyStuff11net
{
    public partial class ThumbViewer : UserControl
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern bool PathIsDirectory([MarshalAs(UnmanagedType.LPWStr), In] string pszPath);

        #region"Events, Custom Controls Events with custom Args.*********************"

        #region"InformationStatus"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ThumbViewer has send an StatusBasMessage")]
        public event InformationStatus_EventHandler InformationStatus;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void InformationStatus_EventHandler(object sender, InformationStatus_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_InformationStatus(InformationStatus_EventArgs e)
        {
            InformationStatus?.Invoke(this, e);
        }

        #endregion"InformationStatus"

        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ThumbViewer has send an StatusBasMessage")]
        public event StatusBarMessageEventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessageEventHandler(object sender, StatusBarMessage_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            if (ReportEvents)
                StatusBarMessage?.Invoke(this, e);
        }

        #endregion"StatusBarMessage"

        #endregion"Events, Custom Controls Events with custom Args.*********************"

        #region"Properties"

        /// <summary>
        /// True if the given address result in a Directory ( A folder),
        /// This partNumber have a name folder, are expect more than 1 picture.
        /// </summary>
        bool TheItem_HaveFolder;
        /// <summary>
        /// Full path of the actual directory...
        /// </summary>
        string DirectoryPath;

        bool IsFromPartNumber;

        ThumbNail SelectedThumb { get; set; }

        string _filePath;
        /// <summary>
        /// Keep a record of the last picture accessed.
        /// </summary>
        string FilePathPictureBoxImage
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
            }
        }

        DialogResult DialogResult = new DialogResult();

        ResourcesCache _cache = new ResourcesCache();

        System.Windows.Forms.Timer PathFromPartNumberTimer;

        bool ReportEvents;
        int lastMouseMove;
        Panel toInsert;
        ThumbNail thumbnailChildAtPosition;
        ThumbNail thumbnailDisplaced;

        /// <summary>
        /// Internal record of number of pictures founded.
        /// </summary>
        int _informationStatus = 0;

        #endregion"Properties"

        #region"CurrentUserBroadcast"

        private string EmployeeName = "Not user login.";
        private string EmployeeLastName = "";
        private MyCode.AccessLevel EmployeeAccessLevel = MyCode.AccessLevel.User;
        private MyCode.EditMode EmployeeEditMode = MyCode.EditMode.View;
        private Employee _currentEmployeesLogIn;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Employee CurrentEmployeesLogIn
        {
            get
            {
                return _currentEmployeesLogIn;
            }
            set
            {
                if (value == null)
                    return;

                EmployeeName = value.Name;
                EmployeeLastName = value.LastName;
                EmployeeEditMode = value.EmployeeEditMode;
                EmployeeAccessLevel = value.EmployeeAccessLevel;
                _currentEmployeesLogIn = value;
            }
        }

        #endregion"CurrentUserBroadcast"

        #region"Properties, Custom Control Properties"

        // thumbNail size 92 x 70. Ratio 92/70 = 1.314
        int _thumbNailWidth = 92;
        int _thumbNailHeight = 70;
        double _ratioImage = 1.314;

        /// <summary>
        /// A flag to warn ThumbNailHeight event is not front the user...
        /// this change because the Panel2 was enabled.
        /// </summary>
        bool splitContainer_ThumbViewer_Panel2Collapsed_Changed = false;

        bool isThumbNailHeightEvent = false;

        [Category("Control Properties"),
        DefaultValue(true),
        Description("Width of ThumbNail, default value is 92.")]
        public int ThumbNailWidth
        {
            set
            {
                if (value >= 10 && value <= (flowLayoutPanel.Width / 2))
                    _thumbNailWidth = value;
            }
            get
            {
                return _thumbNailWidth;
            }
        }

        [Category("Control Properties"),
        DefaultValue(true),
        Description("Height of ThumbNail, default value is 70.")]
        public int ThumbNailHeight
        {
            set
            {
                if (value >= 1 && value <= (flowLayoutPanel.Height + 10))
                {
                    _thumbNailHeight = value;
                    isThumbNailHeightEvent = true;
                    _thumbNailWidth = (int)(_thumbNailHeight * _ratioImage);

                    if (splitContainer_ThumbViewer_Panel2Collapsed_Changed)
                    {
                        splitContainer_ThumbViewer_Panel2Collapsed_Changed = false;
                        return;
                    }



                    PathFromPartNumberProcess();
                }
            }
            get
            {
                return _thumbNailHeight;
            }
        }


        /// <summary>
        /// The splitterContainer.SplitterDistance will be splitContainer_ThumbViewer.Height - _splitterContainerDistance;
        /// </summary>
        int _splitterContainerDistance = 88;

        [Category("Control Properties"),
        DefaultValue(true),
        Description("Height of the Splitter container, default value is 88.")]
        public int SplitterDistance
        {
            set
            {
                try
                {
                    if (splitContainer_ThumbViewer.Height < value)
                    {
                        int _height = splitContainer_ThumbViewer.Height - 88;

                        if (_height > 0)
                            splitContainer_ThumbViewer.SplitterDistance = _height;

                        return;
                    }

                    if (value > 0 && value < (splitContainer_ThumbViewer.Height * 2))
                    {
                        _splitterContainerDistance = value;
                        int distance = splitContainer_ThumbViewer.Height - _splitterContainerDistance;

                        if (distance > 0)
                            splitContainer_ThumbViewer.SplitterDistance = distance;
                        else
                        {
                            _splitterContainerDistance = 88;
                            splitContainer_ThumbViewer.SplitterDistance = splitContainer_ThumbViewer.Height - 88;
                        }
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"ThumbViewer has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            get
            {
                return _splitterContainerDistance;
            }
        }


        string _defaultAddress;

        [Category("Control Properties"),
        DefaultValue(true),
        Description("Address to found a folder or file. new string[] {thumbsPath, nodeImagePath, rowPath};")]
        public string DefaultAddress
        {
            set
            {
                try
                {
                    if (Directory.Exists(value))
                    {
                        _defaultAddress = value;
                    }
                    else
                    {
                        _defaultAddress = "";
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"ThumbViewer has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            get
            {
                return _defaultAddress;
            }
        }

        [Category("Control Properties"),
        DefaultValue(true),
        Description("Address to found a folder or file. new string[] {thumbsPath, nodeImagePath, rowPath};")]
        public string[] PathFromNodeTreeView
        {
            set
            {
                try
                {
                    IsFromPartNumber = false;

                    int directoryPath = 0;
                    int partNumberPath = 2;

                    if (Directory.Exists(value[directoryPath]))
                    {
                        TheItem_HaveFolder = true;
                        DirectoryPath = value[directoryPath];
                        ProcessDirectory(DirectoryPath);
                    }
                    else
                    {
                        #region"The path is a file"

                        TheItem_HaveFolder = false;
                        string strFilePath = value[directoryPath];

                        if (!File.Exists(strFilePath))
                        {
                            // If the file no exist, call partNumber process.
                            // Remember value[] {directoryPath, nodeImagePath, partNumberPath}
                            PathFromPartNumber = value[partNumberPath];
                            return;
                        }

                        if (".txt.TXT".Contains(Path.GetExtension(strFilePath)))
                        {
                            splitContainer_ThumbViewer.Panel2Collapsed = true;
                            splitContainer_ThumbViewer_Panel2Collapsed_Changed = true;
                            pictureBox_Image.Image = ThumbsNail_Ejp.CreateBitmapImage("Test the Image.");
                            return;
                        }

                        GetPictureProcess(strFilePath, true);

                        #endregion"The path is a file"
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"ThumbViewer has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        string _pathFromPartNumber;
        string directoryPathString;
        [Category("Control Properties"),
        DefaultValue(true),
        Description("PathFromPartNumber just gives me the partNumber, if it's a folder or file must be within the folder pictures, we first tested whether it is a folder...")]
        public string PathFromPartNumber
        {
            get
            {
                return _pathFromPartNumber;
            }
            set
            {
                //if (_pathFromPartNumber == value)
                //    return;

                foreach (object imageBox in flowLayoutPanel.Controls)
                {
                    var imageNail = (ThumbNail)imageBox;
                    imageNail.Dispose();
                }

                // If the information is incorrect, show "No_Picture_Found.jpg"
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    directoryPathString = Path.Combine(Settings.Default.DataBaseAddress, "Resources", "No_Picture_Found.jpg");
                    GetPictureProcess(directoryPathString, false);
                    return;
                }

                _pathFromPartNumber = value;
                IsFromPartNumber = true;

                PathFromPartNumberTimer.Start();
            }
        }

        #endregion"Properties, Custom Control Properties"


        public ThumbViewer()
        {
            try
            {
                InitializeComponent();

                ReportEvents = false;

                flowLayoutPanel.AllowDrop = true;
                flowLayoutPanel.HorizontalScroll.Enabled = false;
                flowLayoutPanel.HorizontalScroll.Visible = false;
                flowLayoutPanel.VerticalScroll.SmallChange = 2;
                flowLayoutPanel.VerticalScroll.LargeChange = 80;
                flowLayoutPanel.MouseEnter += new EventHandler(FlowLayoutPanel_MouseEnter);
                flowLayoutPanel.MouseWheel += new MouseEventHandler(FlowLayoutPanel_MouseWheel);
                flowLayoutPanel.DragEnter += new DragEventHandler(FlowLayoutPanel_DragEnter);
                flowLayoutPanel.DragDrop += new DragEventHandler(FlowLayoutPanel_DragDrop);
                flowLayoutPanel.GiveFeedback += new GiveFeedbackEventHandler(FlowLayoutPanel_GiveFeedback);
                flowLayoutPanel.DragOver += new DragEventHandler(FlowLayoutPanel_DragOver);

                splitContainer_ThumbViewer.MouseDown += SplitContainer_ThumbViewer_MouseDown;
                splitContainer_ThumbViewer.MouseUp += SplitContainer_ThumbViewer_MouseUp;

                InitializedFlowLayoutPanel();
                InitializedPictureBox();
                InitializeToDropPanel();

                PathFromPartNumberTimer = new System.Windows.Forms.Timer
                {
                    Interval = 250
                };

                PathFromPartNumberTimer.Tick += PathFromPartNumberTimer_Tick;


            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message,
                    @"ThumbViewer has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        bool _mouseLeftButtonDown;
        void SplitContainer_ThumbViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                _mouseLeftButtonDown = false;
        }

        void SplitContainer_ThumbViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mouseLeftButtonDown = true;
        }

        void PathFromPartNumberTimer_Tick(object sender, EventArgs e)
        {
            PathFromPartNumberTimer.Stop();

            PathFromPartNumberProcess();
        }

        void PathFromPartNumberProcess()
        {
            _informationStatus = 0;
            ClearFlowLayoutPanelThumbNails();

            if (_pathFromPartNumber == null)
                return;

            if (_pathFromPartNumber.Contains(";"))
            {
                string[] strings = _pathFromPartNumber.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in strings)
                {
                    if (splitContainer_ThumbViewer.Panel2Collapsed)
                    {
                        splitContainer_ThumbViewer.Panel2Collapsed = false;

                        if (!isThumbNailHeightEvent)
                            splitContainer_ThumbViewer_Panel2Collapsed_Changed = true;
                    }

                    isThumbNailHeightEvent = false;

                    var strTestDirectoryPath = Path.Combine(DefaultAddress, item.Trim());
                    if (Directory.Exists(strTestDirectoryPath))
                    {
                        #region"The path is a directory"

                        TheItem_HaveFolder = true;
                        DirectoryPath = strTestDirectoryPath;

                        ProcessDirectory(DirectoryPath);

                        #endregion"The path is a directory"
                    }
                    else
                    {
                        #region"The path is a file"

                        TheItem_HaveFolder = false;

                        string searchPattern = item.Trim();

                        if (searchPattern.Contains("."))
                            searchPattern = searchPattern.Remove(searchPattern.IndexOf("."));

                        searchPattern += "*.*";

                        string[] strFiles = Directory.EnumerateFiles(DefaultAddress, searchPattern).ToArray();

                        if (strFiles.Length == 1)
                        {
                            LoadPicturesInDirectory(strFiles);
                            _informationStatus += 1;
                        }

                        #endregion"The path is a file"
                    }
                }
            }
            else
            {
                var strTestDirectoryPath = Path.Combine(DefaultAddress, _pathFromPartNumber);
                if (Directory.Exists(strTestDirectoryPath))
                {
                    #region"The path is a directory"

                    TheItem_HaveFolder = true;

                    if (splitContainer_ThumbViewer.Panel2Collapsed)
                    {
                        splitContainer_ThumbViewer.Panel2Collapsed = false;

                        if (!isThumbNailHeightEvent)
                            splitContainer_ThumbViewer_Panel2Collapsed_Changed = true;
                    }

                    isThumbNailHeightEvent = false;

                    DirectoryPath = strTestDirectoryPath;
                    ProcessDirectory(DirectoryPath);

                    #endregion"The path is a directory"
                }
                else
                {
                    #region"The path is a file"

                    TheItem_HaveFolder = false;

                    if (!splitContainer_ThumbViewer.Panel2Collapsed)
                    {
                        splitContainer_ThumbViewer.Panel2Collapsed = true;

                        if (!isThumbNailHeightEvent)
                            splitContainer_ThumbViewer_Panel2Collapsed_Changed = true;
                    }

                    isThumbNailHeightEvent = false;

                    ProcessFile(_pathFromPartNumber);

                    #endregion"The path is a file"
                }
            }

            On_InformationStatus(new InformationStatus_EventArgs(true, _informationStatus));
        }


        void InitializeToDropPanel()
        {
            toInsert = new Panel
            {
                Width = 10,
                Height = 70,
                BackColor = Color.Beige,
                BorderStyle = BorderStyle.FixedSingle
            };
            toInsert.BringToFront();
        }

        void FlowLayoutPanel_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                Point clientPoint = flowLayoutPanel.PointToClient(new Point(e.X, e.Y));

                if (flowLayoutPanel.GetChildAtPoint(clientPoint) == null)
                    return;

                if (flowLayoutPanel.GetChildAtPoint(clientPoint).GetType() == typeof(Panel))
                    return;

                thumbnailChildAtPosition = (ThumbNail)flowLayoutPanel.GetChildAtPoint(clientPoint);
                if (thumbnailChildAtPosition == null)
                {
                    thumbnailDisplaced = new ThumbNail();
                    return;
                }

                // if the mouse is hovering over the original thumbNail, we do not want to
                // paint anything, so we return.
                if (thumbNailMouseDown.FileName.Contains(thumbnailChildAtPosition.FileName))
                {
                    thumbnailDisplaced = new ThumbNail();
                    flowLayoutPanel.Controls.Remove(toInsert);
                    return;
                }

                int index = flowLayoutPanel.Controls.GetChildIndex(thumbnailChildAtPosition, false);
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Mouse position over thumbnail index " + index + " position at " + thumbnailMousePosition, 1));

                if (!flowLayoutPanel.Controls.Contains(toInsert))
                    flowLayoutPanel.Controls.Add(toInsert);

                if (thumbnailDisplaced != null && thumbnailDisplaced.FileName.Contains(thumbnailChildAtPosition.FileName))
                    return;

                thumbnailDisplaced = thumbnailChildAtPosition;

                // column is being dragged to the left.
                if (lastMouseMove > e.X)
                {
                    lastMouseMove = lastMouseMove - 5;
                    flowLayoutPanel.Controls.SetChildIndex(toInsert, (index - 1));
                }

                // column is being dragged to the right.
                if (lastMouseMove < e.X)
                {
                    lastMouseMove = e.X + 5;
                    flowLayoutPanel.Controls.SetChildIndex(toInsert, index);
                }
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message,
                    @"ThumbViewer has generated an error at flowLayoutPanel_DragOver().", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void FlowLayoutPanel_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            Cursor = dragCursor;
        }

        void FlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            Cursor = Cursors.Default;
            flowLayoutPanel.Controls.Remove(toInsert);

            if (EmployeeAccessLevel < MyCode.AccessLevel.Administrator)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            var source = (Control)e.Data.GetData(dragType);
            var target = flowLayoutPanel.GetChildAtPoint(flowLayoutPanel.PointToClient(new Point(e.X, e.Y)));

            if (target != null)
            {
                int index = flowLayoutPanel.Controls.GetChildIndex(target);
                flowLayoutPanel.Controls.SetChildIndex(source, index);
            }

            UpDateFileNameIndex();
            ProcessPictureInDirectory(DirectoryPath);
        }

        void FlowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.AllowedEffect == DragDropEffects.Move && e.Data.GetDataPresent(dragType))
                e.Effect = DragDropEffects.Move;
        }

        #region"FlowLayoutPanel"

        void InitializedFlowLayoutPanel()
        {
            flowLayoutPanel.DoubleClick += FlowLayoutPanel_DoubleClick;
        }

        void FlowLayoutPanel_DoubleClick(object sender, EventArgs e)
        {
            ReportEvents = !ReportEvents;
        }

        void FlowLayoutPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!flowLayoutPanel.VerticalScroll.Visible)
                return;

            if (e.Delta > 0 && flowLayoutPanel.VerticalScroll.Value > 30)
                flowLayoutPanel.VerticalScroll.Value += 40;

            int pageSize = AccessPrivatePropertiesFiels.GetPrivateProperty<int>(flowLayoutPanel.VerticalScroll, "PageSize");

            if (e.Delta < 0 && flowLayoutPanel.VerticalScroll.Value < (flowLayoutPanel.VerticalScroll.Maximum - pageSize))
                if (flowLayoutPanel.VerticalScroll.Value > 41)
                    flowLayoutPanel.VerticalScroll.Value -= 40;
        }

        void FlowLayoutPanel_MouseEnter(object sender, EventArgs e)
        {
            // flowLayoutPanel.Focus();
        }

        void OpenThumbFile(string strThumbFile)
        {
            ThumbDB db = new ThumbDB(strThumbFile);

            if (db != null)
            {
                flowLayoutPanel.BackgroundImage = null;
                flowLayoutPanel.Controls.Clear();

                var strThumbsFiles = db.GetThumbfiles();
                var strFiles = GetImageFiles(DirectoryPath);

                //test if Thumbs.db is update...
                if (strThumbsFiles.Length != (strFiles.Length + 1))
                {
                    ProcessPictureInDirectory(DirectoryPath);
                    StubbedFile(strThumbFile);
                    ShellNotificationRefresh(strThumbFile);
                    return;
                }

                //if no picture in folder and strThumbsFiles.Length == 0
                if (strThumbsFiles.Length <= 1)
                {
                    GetPictureProcess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_ThumbNail_Found.jpg", false);
                    StubbedFile(strThumbFile);
                    ShellNotificationRefresh(strThumbFile);
                    return;
                }

                // create the thumbnails for the selected files
                foreach (string strFileName in strThumbsFiles)
                {
                    //This task is slow, many files take time, if the user select a different
                    //directory before the loop finished, we need restart.
                    if (!strThumbFile.Contains(DirectoryPath))
                    {
                        flowLayoutPanel.BackgroundImage = null;
                        flowLayoutPanel.Controls.Clear();
                    }

                    if (strFileName.Equals(string.Empty))
                        continue;

                    if (strFileName.Contains("{A42CD7B6-E9B9-4D02-B7A6-288B71AD28BA}"))
                        continue;

                    //Check if the image file exist before generated the thumbnail, it's nasty to
                    //click a thumbnail and do nothing.
                    string fileNameFullPath = Path.Combine(DirectoryPath, strFileName);
                    if (!File.Exists(fileNameFullPath))
                    {
                        ProcessPictureInDirectory(DirectoryPath);
                        break;
                    }

                    ThumbNail thumbnail = null;

                    Image pImage = null;
                    try
                    {
                        pImage = db.GetThumbnailImage(strFileName);
                    }
                    catch (OutOfMemoryException)
                    {
                        pImage = null;
                    }

                    try
                    {
                        thumbnail = new ThumbNail(fileNameFullPath, pImage);
                        thumbnail.ThumbNailDragStarting += Thumbnail_ThumbNailDragStarting;
                        thumbnail.ThumbNailClicked += Thumbnail_ThumbNailClicked;
                        thumbnail.ThumbNailMouseEnter += Thumbnail_ThumbNailMouseEnter;
                        thumbnail.ThumbNailMouseMove += Thumbnail_ThumbNailMouseMove;
                    }
                    catch (OutOfMemoryException)
                    {
                        thumbnail = null;
                        continue;
                    }

                    flowLayoutPanel.Controls.Add(thumbnail);

                    if (flowLayoutPanel.Controls.Count == 1)
                    {
                        splitContainer_ThumbViewer.Panel2Collapsed = false;
                        splitContainer_ThumbViewer_Panel2Collapsed_Changed = true;
                        Thumbnail_ThumbNailClicked(new object(), new ThumbNailClick_EventArgs(thumbnail.FileName,
                                                                                    thumbnail.FilePath, thumbnail));
                    }
                }
            }
        }

        void ProcessFile(string filePath)
        {
            if (filePath.Contains("."))
                filePath = filePath.Remove(filePath.IndexOf("."));

            string searchPattern = filePath + "*.*";

            string[] strFiles = Directory.EnumerateFiles(DefaultAddress, searchPattern).ToArray();

            if (strFiles.Length == 0)
            {
                directoryPathString = Path.Combine(Settings.Default.DataBaseAddress, "Resources", "No_Picture_Found.jpg");
                GetPictureProcess(directoryPathString, false);
                _informationStatus += 0;
                return;
            }

            if (strFiles.Length == 1)
            {
                GetPictureProcess(strFiles[0], true);
                _informationStatus += 1;
            }

            // If two or more file are founded, we have different files names containing _pathFromPartNumber
            // into the root folder (Settings.Default.DataBaseAddress, "Pictures"), we need locate the correct one.
            if (strFiles.Length >= 2)
            {
                foreach (string picture in strFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(picture);
                    if (fileName != filePath)
                        continue;

                    GetPictureProcess(picture, true);
                    break;
                }
                //flowLayoutPanel.Controls.Clear();
                //Task.Factory.StartNew(() => LoadPicturesInDirectory(strFiles, directoryPathString));
            }

        }

        void ProcessDirectory(string pathDirectory)
        {
            // The path is a directory D:\ProductionManagement\Pictures\PartNumber\Thumbs.db
            string thumbsDbPath = Path.Combine(pathDirectory, "Thumbs.db");
            if (File.Exists(thumbsDbPath))
                OpenThumbFile(thumbsDbPath);
            else
                ProcessPictureInDirectory(pathDirectory);
        }

        void ProcessPictureInDirectory(string pathDirectory)
        {
            var strFiles = GetImageFiles(pathDirectory);
            _informationStatus += strFiles.Length;

            if (strFiles.Length == 0)
            {
                GetPictureProcess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Picture_Found.jpg", false);
                return;
            }

            if (strFiles.Length == 1)
            {
                GetPictureProcess(Path.Combine(pathDirectory, strFiles[0]), true);
                _informationStatus += 1;
            }

            if (strFiles.Length > 1)
                LoadPicturesInDirectory(strFiles);
        }

        /// <summary>
        /// Add an auto-generate thumbNail for each image existent in this directory.
        /// </summary>
        /// <param name="strFiles"></param>
        /// <param name="directoryPath"></param>
        void LoadPicturesInDirectory(string[] strFiles)
        {
            foreach (ThumbNail thumb in GetThumbNailImage(strFiles))
            {
                flowLayoutPanel.Controls.Add(thumb);
                thumb.Index = flowLayoutPanel.Controls.Count;

                if (thumb.Index == 1)
                {
                    Thumbnail_ThumbNailClicked(new object(), new ThumbNailClick_EventArgs(thumb.FileName, thumb.FilePath, thumb));
                    //On_StatusBarMessage(new StatusBarMessage_EventArgs("ThumbNail height " + thumb.Height + " , width " + thumb.Width, 1));
                }
            }
        }

        /// <summary>
        /// Generate a thumbNail for each image found in the directory.
        /// </summary>
        /// <param name="strFiles"></param>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        IEnumerable<ThumbNail> GetThumbNailImage(string[] strFiles, string directoryPath)
        {
            // create the thumbnails for the selected files
            foreach (string strFileName in strFiles)
            {
                ThumbNail thumbnail = null;
                const int XSquare = 96; // thumbNail size 96 x 70.
                const int YSquare = 70;

                Image pImage = null;
                try
                {
                    var image = Image.FromFile(strFileName);

                    int cxThumbnail, cyThumbnail;

                    if (image.Width > image.Height)
                    {
                        cxThumbnail = XSquare;
                        cyThumbnail = YSquare * image.Height / image.Width;
                    }
                    else
                    {
                        cyThumbnail = YSquare;
                        cxThumbnail = XSquare * image.Width / image.Height;
                    }
                    pImage = image.GetThumbnailImage(cxThumbnail, cyThumbnail, () => false, IntPtr.Zero);
                    image.Dispose();
                }
                catch (OutOfMemoryException)
                {
                    pImage = null;
                }

                try
                {
                    thumbnail = new ThumbNail(strFileName, pImage);
                    thumbnail.ThumbNailDragStarting += Thumbnail_ThumbNailDragStarting;
                    thumbnail.ThumbNailClicked += Thumbnail_ThumbNailClicked;
                    thumbnail.ThumbNailMouseEnter += Thumbnail_ThumbNailMouseEnter;
                    thumbnail.ThumbNailMouseMove += Thumbnail_ThumbNailMouseMove;
                }
                catch (OutOfMemoryException)
                {
                    thumbnail = null;
                    continue;
                }

                pImage = null;
                thumbnail.FilePath = directoryPath.Substring(0, directoryPath.LastIndexOf("\\") + 1);

                yield return thumbnail;
            }
        }

        /// <summary>
        /// Generate a thumbNail for each image found in the directory.
        /// </summary>
        /// <param name="strFiles"></param>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        IEnumerable<ThumbNail> GetThumbNailImage(string[] strFiles)
        {
            // create the thumbnails for the selected files
            foreach (string strFileName in strFiles)
            {
                ThumbNail thumbnail;
                try
                {
                    thumbnail = new ThumbNail(strFileName, _thumbNailWidth, _thumbNailHeight);
                    thumbnail.ThumbNailDragStarting += Thumbnail_ThumbNailDragStarting;
                    thumbnail.ThumbNailClicked += Thumbnail_ThumbNailClicked;
                    thumbnail.ThumbNailMouseEnter += Thumbnail_ThumbNailMouseEnter;
                    thumbnail.ThumbNailMouseMove += Thumbnail_ThumbNailMouseMove;
                }
                catch (OutOfMemoryException)
                {
                    thumbnail = null;
                    continue;
                }

                yield return thumbnail;
            }
        }

        /// <summary>
        /// Returns an array of strings containing the full path and name of existing images files in this directory.
        /// Will check for { "*.jpg", "*.png", "*.gif", "*.bmp" }.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        string[] GetImageFiles(string directoryPath)
        {
            var filters = new[] { "*.jpg", "*.png", "*.gif", "*.bmp" };
            var strFiles = filters.SelectMany(f => Directory.EnumerateFiles(directoryPath, f)).ToArray();

            return strFiles;
        }


        Type dragType;
        Cursor dragCursor;
        ThumbNail thumbNailMouseDown;
        int thumbnailMousePosition;

        void Thumbnail_ThumbNailDragStarting(object sender, MouseEventArgs e)
        {
            thumbNailMouseDown = sender as ThumbNail;

            using (Bitmap bmp = new Bitmap(thumbNailMouseDown.Width, thumbNailMouseDown.Height))
            {
                thumbNailMouseDown.DrawToBitmap(bmp, new Rectangle(Point.Empty, new Size((thumbNailMouseDown.Size.Width - 10), (thumbNailMouseDown.Size.Height - 20))));
                dragCursor = new Cursor(bmp.GetHicon());
            }

            lastMouseMove = e.X;
            dragType = thumbNailMouseDown.GetType();
            flowLayoutPanel.DoDragDrop(thumbNailMouseDown, DragDropEffects.Move);
            dragCursor.Dispose();
        }

        void Thumbnail_ThumbNailClicked(object sender, ThumbNailClick_EventArgs e)
        {
            //if (!pictureBox_Image.Visible)
            //    return;

            FilePathPictureBoxImage = Path.Combine(e.FilePath, e.FileName);
            if (FilePathPictureBoxImage == pictureBox_Image.ImageLocation)
                return;

            if (SelectedThumb != null)
                SelectedThumb.Selected = false;

            pictureBox_Image.ImageLocation = FilePathPictureBoxImage;

            pictureBox_Image.Image = GetImageFromByteArray(File.ReadAllBytes(FilePathPictureBoxImage));

            SelectedThumb = e.Thumb;
            SelectedThumb.Selected = true;
        }

        void Thumbnail_ThumbNailMouseEnter(object sender, ThumbNailMouseEnter_EventArgs e)
        {
            int index = flowLayoutPanel.Controls.GetChildIndex(thumbnailChildAtPosition, false);
            On_StatusBarMessage(new StatusBarMessage_EventArgs("Mouse position enter at thumbnail index " + index + " position at " + thumbnailMousePosition, 1));
        }

        void Thumbnail_ThumbNailMouseMove(object sender, ThumbNailMouseMove_EventArgs e)
        {
            thumbnailMousePosition = e.MousePosition;
        }

        /// <summary>
        /// Remove all thumbNail present in flowLayoutPanel.
        /// </summary>
        void ClearFlowLayoutPanelThumbNails()
        {
            if (flowLayoutPanel.Controls.Count == 0)
                return;

            foreach (ThumbNail thumbnail in flowLayoutPanel.Controls)
            {
                thumbnail.Dispose();
            }

            //  flowLayoutPanel.BackgroundImage = null;
            flowLayoutPanel.Controls.Clear();
        }

        void ShellNotificationRefresh(string pathFolder)
        {
            try
            {
                ShellNotification.RefreshThumbnail(pathFolder);
            }
            catch (Exception error)
            {
                string Error = error.Message;
            }

        }

        void StubbedFile(string pathFolder)
        {
            try
            {
                ThumbsNail_Ejp.StubbedFile(pathFolder);
            }
            catch (Exception error)
            {
                string Error = error.Message;
            }
        }

        // ImageConverter object used to convert byte arrays containing JPEG or PNG file images into 
        //  Bitmap objects. This is static and only gets instantiated once.
        static readonly ImageConverter _imageConverter = new ImageConverter();

        //Byte array to Image:
        /// <summary>
        /// Method that uses the ImageConverter object in .Net Framework to convert a byte array,
        /// presumably containing a JPEG or PNG file image, into a Bitmap object, which can also be
        /// used as an Image object.
        /// </summary>
        /// <param name="byteArray">byte array containing JPEG or PNG file image or similar</param>
        /// <returns>Bitmap object if it works, else exception is thrown</returns>
        public static Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            var bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                               bm.VerticalResolution != (int)bm.VerticalResolution))
            {
                // Correct a strange glitch that has been observed in the test program when converting
                //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts"
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                 (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
        }

        //Edit: To get the Image from a jpg or png file you should read the file into a byte array using File.ReadAllBytes():
        //Bitmap newBitmap = GetImageFromByteArray(File.ReadAllBytes("fileName"));

        #endregion"FlowLayoutPanel"

        #region"Initialize ToolTip"

        private readonly ToolTip toolTip = new ToolTip();
        private void InitializeToolTip()
        {
            toolTip.IsBalloon = true;
            toolTip.AutomaticDelay = 0;
            toolTip.OwnerDraw = true;
            toolTip.ShowAlways = true;
            toolTip.UseAnimation = false;
            toolTip.UseFading = false;
            toolTip.Draw += ToolTipDraw;
        }

        // if toolTip.IsBalloon = true, toolTip_Draw never is called.
        private void ToolTipDraw(object sender, System.Windows.Forms.DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Chocolate, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));
            e.Graphics.DrawString(toolTip.ToolTipTitle + e.ToolTipText, e.Font, Brushes.Red, e.Bounds);
        }

        /// <summary>
        /// Call from the control handle mouseLeave to hide the tooltip. 
        /// </summary>
        private void ToolTip_MouseLeave(ToolStripMenuItem controlToHideToolTip)
        {
            //   toolTip.Hide(controlToHideToolTip);
        }

        /// <summary>
        /// Call from the control handle mouseEnter to show the tooltip. 
        /// </summary>
        /// <param name="e"></param>
        private void ToolTip_CellMouseEnter(ToolStripMenuItem controlToShowToolTip, string toolTipTitle, string toolTipInfo)
        {
            try
            {
                // To show, workaround.
                //     toolTip.SetToolTip(controlToShowToolTip, "");
                //     toolTip.Hide(controlToShowToolTip);

                Point mousePos = contextMenuStripPictureBox.PointToClient(MousePosition);

                toolTip.ToolTipTitle = toolTipTitle;
                toolTip.ToolTipIcon = ToolTipIcon.Info;

                //     toolTip.SetToolTip(controlToShowToolTip, toolTipInfo);
                //    toolTip.Show(toolTipInfo, controlToShowToolTip, mousePos);
            }
            catch (Exception)
            {
            }
        }

        #endregion"Initialize ToolTip"

        #region"PictureBox Initialized"

        private void InitializedPictureBox()
        {
            pictureBox_Image.DoubleClick += PictureBoxImageDoubleClick;
            pictureBox_Image.LoadProgressChanged += PictureBoxImageLoadProgressChanged;
            pictureBox_Image.LoadCompleted += PictureBoxImageLoadCompleted;

            contextMenuStripPictureBox.Opening += ContextMenuStripPictureBoxOpening;
            contextMenuStripPictureBox.MouseLeave += ContextMenuStripPictureBox_MouseLeave;

            toolStripMenuItem_RemoveThisPicture.Click += ToolStripMenuItemRemoveThisPictureClick;
            toolStripMenuItem_AddANewPicture.Click += ToolStripMenuItemAddANewPictureClick;
            toolStripMenuItemCopyToANewFile.Click += ToolStripMenuItemCopyToANewFile_Click;
            toolStripMenuItemCopyFileToTheClickBoard.Click += ToolStripMenuItemCopyFileToTheClickBoard_Click;
            toolStripMenuItemCopyImageToTheClipBoard.Click += ToolStripMenuItemCopyImageToTheClipBoard_Click;

            toolStripMenuItemCopyToANewFile.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItemCopyToANewFile.MouseLeave += ToolStripMenuItem_MouseLeave;

            toolStripMenuItemCopyFileToTheClickBoard.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItemCopyFileToTheClickBoard.MouseLeave += ToolStripMenuItem_MouseLeave;

            toolStripMenuItemCopyImageToTheClipBoard.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItemCopyImageToTheClipBoard.MouseLeave += ToolStripMenuItem_MouseLeave;

            toolStripMenuItem_AddANewPicture.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItem_AddANewPicture.MouseLeave += ToolStripMenuItem_MouseLeave;

            toolStripMenuItem_RemoveThisPicture.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItem_RemoveThisPicture.MouseLeave += ToolStripMenuItem_MouseLeave;
        }

        void ToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            string title = "";
            string information = "";

            // To show, workaround, eliminate double show.
            toolTip.SetToolTip(contextMenuStripPictureBox, "");
            toolTip.Hide(contextMenuStripPictureBox);

            ToolStripMenuItem senderControl = (ToolStripMenuItem)sender;
            Point mousePos = contextMenuStripPictureBox.PointToClient(new Point((contextMenuStripPictureBox.Bounds.X +
                                                                                senderControl.Bounds.Right), MousePosition.Y));

            switch (senderControl.Text)
            {
                case "Copy to a new file.":
                    {
                        title = "test1";
                        information = "12345 fsafd";
                        break;
                    }
                case "Copy file to the ClipBoard.":
                    {
                        title = "test2";
                        information = "1234 sdfgadsfg";
                        break;
                    }
                case "Copy image to the ClipBoard.":
                    {
                        title = "test3";
                        information = "123 asgsdg";
                        break;
                    }
                default:
                    {
                        title = "";
                        information = "";
                        break;
                    }
            }

            toolTip.ToolTipTitle = title;
            toolTip.ToolTipIcon = ToolTipIcon.Info;

            toolTip.SetToolTip(contextMenuStripPictureBox, information);
            toolTip.Show(information, contextMenuStripPictureBox, mousePos);
        }

        void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(contextMenuStripPictureBox);
        }


        void ContextMenuStripPictureBoxOpening(object sender, CancelEventArgs e)
        {
            contextMenuStripPictureBox.Items.Clear();

            contextMenuStripPictureBox.Items.AddRange(new ToolStripMenuItem[]
                                                                      {
                                                                          toolStripMenuItemCopyToANewFile,
                                                                          toolStripMenuItemCopyFileToTheClickBoard,
                                                                          toolStripMenuItemCopyImageToTheClipBoard
                                                                      });
            #region"IsManager or Administrator"

            if (EmployeeAccessLevel == MyCode.AccessLevel.Manager ||
                EmployeeAccessLevel == MyCode.AccessLevel.Administrator)
            {
                contextMenuStripPictureBox.Items.Add(toolStripMenuItem_AddANewPicture);

                if (FilePathPictureBoxImage.Contains("No_"))
                    return;

                contextMenuStripPictureBox.Items.Add(toolStripMenuItem_RemoveThisPicture);
            }

            #endregion"IsManager or Administrator"
        }

        void ContextMenuStripPictureBox_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStripPictureBox.Close();
        }

        void ToolStripMenuItemAddANewPictureClick(object sender, EventArgs e)
        {
            PictureBoxImageDoubleClick(new object(), new EventArgs());
        }

        void ToolStripMenuItemRemoveThisPictureClick(object sender, EventArgs e)
        {
            if (TheItem_HaveFolder)
            {
                #region"RemovePictureFromFolder"

                if (FilePathPictureBoxImage != null)
                    if (File.Exists(FilePathPictureBoxImage))
                    {
                        try
                        {
                            DialogResult = MessageBox.Show(@"Do you want save this picture?", "Save picture.",
                                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (DialogResult == System.Windows.Forms.DialogResult.Cancel)
                                return;

                            //Using FileInfo class copy the file.
                            FileInfo _fileInfo = new FileInfo(FilePathPictureBoxImage);

                            if (DialogResult == System.Windows.Forms.DialogResult.Yes)
                            {
                                #region"Yes, save the picture"

                                using (var openfile = new OpenFileDialogExt
                                {
                                    Title = @"Please, name filename to save it picture.",
                                    FileName = "",
                                    Filter = @"*.jpg|*.jpg|*.png|*.png|*.gif|*.gif",
                                    DefaultExt = "(*.jpg)|*.jpg",
                                    CheckFileExists = false,
                                    InitialDirectory = Settings.Default.DataBaseAddress + "\\Picture\\",
                                }
                                    )
                                {
                                    if (openfile.ShowDialog(this) == DialogResult.Cancel)
                                        return;

                                    _fileInfo.CopyTo(openfile.FileName, true);
                                }

                                #endregion"Yes, save the picture"
                            }

                            // Delete original file selected to be removed.
                            _fileInfo.Delete();

                            FileInfo[] restFileInFolder = _fileInfo.Directory.GetFiles();
                            // if no more file inside of this folder, delete it.
                            if (restFileInFolder.Length == 0)
                                _fileInfo.Directory.Delete(true);

                            ReloadPicture();
                        }
                        catch (Exception)
                        {

                        }
                    }

                #endregion"RemovePictureFromFolder"
            }
            else
            {
                #region"RemovePictureFile"
                if (FilePathPictureBoxImage != null)
                    if (File.Exists(FilePathPictureBoxImage))
                    {
                        DialogResult = MessageBox.Show(@"Do you want save this picture?", "Save picture.",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        //Using FileInfo class copy the file.
                        FileInfo _fileInfo = new FileInfo(FilePathPictureBoxImage);

                        if (DialogResult == System.Windows.Forms.DialogResult.Cancel)
                            return;

                        if (DialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            #region"Yes, save the picture"

                            using (var openfile = new OpenFileDialogExt
                            {
                                Title = @"Please, name filename to save it picture.",
                                FileName = "",
                                Filter = @"*.jpg|*.jpg|*.png|*.png|*.gif|*.gif",
                                DefaultExt = "(*.jpg)|*.jpg",
                                CheckFileExists = false,
                                InitialDirectory = Settings.Default.DataBaseAddress + "\\Picture\\",
                            }
                                )
                            {
                                if (openfile.ShowDialog(this) == DialogResult.Cancel)
                                    return;

                                _fileInfo.CopyTo(openfile.FileName, true);
                            }

                            #endregion"Yes, save the picture"
                        }

                        // Delete original file
                        _fileInfo.Delete();

                        GetPictureProcess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Picture_Found.jpg", false);
                    }
                #endregion"RemovePictureFile"
            }
        }


        void ToolStripMenuItemCopyToANewFile_Click(object sender, EventArgs e)
        {
            string fileExt = Path.GetExtension(pictureBox_Image.ImageLocation);

            SaveFileDialog copyTo = new SaveFileDialog()
            {
                FileName = "Copy of " + Path.GetFileNameWithoutExtension(pictureBox_Image.ImageLocation),
                Filter = "(*" + fileExt + ")|*" + fileExt,
                FilterIndex = 1,
                DefaultExt = Path.GetExtension(pictureBox_Image.ImageLocation),
                InitialDirectory = pictureBox_Image.ImageLocation
            };

            if (copyTo.ShowDialog() == DialogResult.OK && copyTo.FileName.Length > 0)
            {
                foreach (string strFile in copyTo.FileNames)
                {
                    File.Copy(pictureBox_Image.ImageLocation, copyTo.FileName, false);
                }
            }
        }

        void ToolStripMenuItemCopyFileToTheClickBoard_Click(object sender, EventArgs e)
        {
            StringCollection FileCollection = new StringCollection();
            FileCollection.Add(pictureBox_Image.ImageLocation);
            Clipboard.SetFileDropList(FileCollection);
        }

        void ToolStripMenuItemCopyImageToTheClipBoard_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(pictureBox_Image.Image, true);
        }

        void PictureBoxImageLoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            On_StatusBarMessage(new StatusBarMessage_EventArgs("Loading a picture at " + e.ProgressPercentage + " %.", 1));
        }

        void PictureBoxImageLoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            On_StatusBarMessage(new StatusBarMessage_EventArgs("Load completed..."));
        }

        void PictureBoxImageDoubleClick(object sender, EventArgs e)
        {
            if (EmployeeAccessLevel == MyCode.AccessLevel.User)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsFromPartNumber)
            {
                using (var directoryFile = new DirectoryFile())
                {
                    string[] filesToCopy = directoryFile.CopyMultiFileToFolder();
                    if (filesToCopy.Length == 0)
                        return;

                    int countFiles = 0;
                    string filename = "";
                    string distFileName = "";
                    string fileCounterChar = "#";

                    if (TheItem_HaveFolder)
                    {
                        List<string> di = Directory.EnumerateFiles(DirectoryPath).ToList();

                        if (di.Count > 0)
                        {
                            #region"Directory exist, but have some file...."

                            di.Sort();
                            string lastName = di.Last();
                            int topValue = 50;

                            if (lastName.Contains(fileCounterChar))
                                topValue = int.Parse(lastName.Substring((lastName.IndexOf(fileCounterChar) + 1), 2));

                            countFiles = topValue;

                            #endregion"Directory exist, but have some file...."
                        }

                        #region"Directory"
                        foreach (string strfileName in filesToCopy)
                        {
                            countFiles++;

                            //Using FileInfo class copy the file.
                            FileInfo fileInfo = new FileInfo(strfileName);
                            if (!strfileName.Contains(fileCounterChar))
                            {
                                filename = Path.GetFileNameWithoutExtension(strfileName) + fileCounterChar + countFiles.ToString("00");
                                filename += Path.GetExtension(strfileName);
                            }
                            else
                                filename = Path.GetFileName(strfileName);


                            distFileName = Path.Combine(DirectoryPath, Path.GetFileName(filename));

                            fileInfo.CopyTo(distFileName, true);
                        }
                        ReloadPicture();
                        return;
                        #endregion"Directory"
                    }
                    else
                    {
                        if (FilePathPictureBoxImage.Contains("No_Picture_Found"))
                        {
                            #region"Have no picture"
                            if (filesToCopy.Length == 1)
                            {
                                countFiles++;

                                //Using FileInfo class copy the file.
                                FileInfo fileInfo = new FileInfo(filesToCopy[0]);

                                filename = PathFromPartNumber + fileCounterChar + countFiles.ToString("00");
                                filename += Path.GetExtension(filesToCopy[0]);

                                distFileName = Path.Combine(Settings.Default.DataBaseAddress, "Pictures", filename);

                                fileInfo.CopyTo(distFileName, false);
                                ReloadPicture();
                                return;
                            }

                            if (filesToCopy.Length >= 2)
                            {
                                // The row have more picture, need make a new folder and move the picture in.
                                // Try to create the directory.
                                string directoryPathString = Path.Combine(Settings.Default.DataBaseAddress, "Pictures", PathFromPartNumber);
                                DirectoryInfo di = Directory.CreateDirectory(directoryPathString);

                                foreach (string strfileName in filesToCopy)
                                {
                                    countFiles++;

                                    //Using FileInfo class copy the file.
                                    FileInfo fileInfo = new FileInfo(strfileName);

                                    filename = PathFromPartNumber + fileCounterChar + countFiles.ToString("00");
                                    filename += Path.GetExtension(strfileName);
                                    distFileName = Path.Combine(directoryPathString, filename);

                                    fileInfo.CopyTo(distFileName, false);
                                }
                                ReloadPicture();
                            }
                            #endregion"Have no picture"
                        }
                        else
                        {
                            #region"Have a picture"

                            try
                            {
                                // The row have a picture, need make a new folder and move the picture in.
                                // Try to create the directory.
                                string directoryPathString = Path.Combine(Settings.Default.DataBaseAddress, "Pictures", PathFromPartNumber);
                                DirectoryInfo di = Directory.CreateDirectory(directoryPathString);

                                countFiles++;
                                if (!FilePathPictureBoxImage.Contains("#"))
                                {
                                    filename = PathFromPartNumber + fileCounterChar + countFiles.ToString("00");
                                    filename += Path.GetExtension(FilePathPictureBoxImage);
                                }
                                else
                                    filename = Path.GetFileName(FilePathPictureBoxImage);


                                FileInfo filetoMove = new FileInfo(FilePathPictureBoxImage);
                                filetoMove.MoveTo(Path.Combine(directoryPathString, filename));

                                foreach (string strfileName in filesToCopy)
                                {
                                    countFiles++;

                                    //Using FileInfo class copy the file.
                                    FileInfo fileInfo = new FileInfo(strfileName);
                                    filename = PathFromPartNumber + fileCounterChar + countFiles.ToString("00");
                                    filename += Path.GetExtension(strfileName);
                                    distFileName = Path.Combine(directoryPathString, filename);

                                    fileInfo.CopyTo(distFileName, false);
                                }

                                ReloadPicture();
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                                         @"ThumbViewer has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            #endregion"Have a picture"
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Collapsed the splitContainer, show one imagen in pictureBox
        /// and call On_InformationStatus event.
        /// </summary>
        /// Full address to the file.
        /// <param name="filePathString"></param>
        /// 
        /// <param name="status"></param>
        void GetPictureProcess(string filePathString, bool status)
        {
            if (filePathString == null)
                return;

            if (pictureBox_Image.ImageLocation == filePathString)
                return;

            FilePathPictureBoxImage = filePathString;
            pictureBox_Image.ImageLocation = filePathString;
            pictureBox_Image.Image = _cache.GetBitmap(filePathString);
        }

        void ReloadPicture()
        {
            string partNumberToReload = PathFromPartNumber;
            // Internally change the store information to reload el partNumber.
            _pathFromPartNumber = "Reset";

            PathFromPartNumber = partNumberToReload;
        }

        void PrintImage_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.Print();
        }

        void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox_Image.Image, 0, 0);
        }

        // And save it:
        // by drawing image first on bitmap and then saving this bitmap
        public void ExportToBmp(string path)
        {
            using (var bitmap = new Bitmap(pictureBox_Image.Width, pictureBox_Image.Height))
            {
                pictureBox_Image.DrawToBitmap(bitmap, pictureBox_Image.ClientRectangle);
                bitmap.Save(path, ImageFormat.Bmp);
            }
        }


        #endregion"PictureBox Initialized"

        void SplitContainer_ThumbViewer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (_mouseLeftButtonDown == false)
                return;

            int splitHeight = splitContainer_ThumbViewer.Height - splitContainer_ThumbViewer.SplitterDistance;

            ThumbNailHeight = splitHeight - 8;
            SplitterDistance = splitHeight;

            if (splitHeight < 30)
                while (splitHeight < 30)
                {
                    splitContainer_ThumbViewer.SplitterDistance -= 1;
                    splitHeight = splitContainer_ThumbViewer.Height - splitContainer_ThumbViewer.SplitterDistance;
                }
        }

        void UpDateFileNameIndex()
        {
            foreach (Control thumb in flowLayoutPanel.Controls)
            {
                try
                {
                    var thumbNail = (ThumbNail)thumb;

                    var newFileName = Path.Combine(DirectoryPath, PathFromPartNumber + "#temp" +
                                         flowLayoutPanel.Controls.IndexOf(thumb).ToString("00") + thumbNail.FileExt);

                    FileSystemExt.FileRename(thumbNail.FileFullPath, newFileName);
                }
                catch (Exception error)
                {
                    var err = error.Message;
                }
            }

            var strFiles = GetImageFiles(DirectoryPath);
            foreach (string fileName in strFiles)
            {
                try
                {
                    var newFileName = ReplaceLast(fileName, "temp", "");
                    FileSystemExt.FileRename(fileName, newFileName);
                }
                catch (Exception error)
                {
                    var err = error.Message;
                }
            }
        }

        public static string ReplaceLast(string val, string stringToReplace, string replacement)
        {
            int index = val.LastIndexOf(stringToReplace);
            if (index < 0)
            {
                return val;
            }
            else
            {
                StringBuilder sb = new StringBuilder(val.Length - stringToReplace.Length + replacement.Length);
                sb.Append(val.Substring(0, index));
                sb.Append(replacement);
                sb.Append(val.Substring(index + stringToReplace.Length,
                   val.Length - index - stringToReplace.Length));

                return sb.ToString();
            }
        }
    }
}

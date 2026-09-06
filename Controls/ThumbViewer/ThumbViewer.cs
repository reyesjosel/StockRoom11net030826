using StockRoom11net.Controls.DirectoryFileOperations;
//using StockRoom11net.Controls.EmployeeInformation;
//using StockRoom11net.Controls.ThumbViewer;
using StockRoom11net.Properties;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using static StockRoom11net.Controls.Custom_Events_Args;
using static StockRoom11net.Controls.FileSystemEnumerator.UsingKernel32;

//using static System.Net.Mime.MediaTypeNames;
using StatusBarMessage_EventArgs = StockRoom11net.Controls.Custom_Events_Args.StatusBarMessage_EventArgs;
using ThumbNailClick_EventArgs = StockRoom11net.Controls.Custom_Events_Args.ThumbNailClick_EventArgs;
using ThumbNailMouseEnter_EventArgs = StockRoom11net.Controls.Custom_Events_Args.ThumbNailMouseEnter_EventArgs;
using ThumbNailMouseMove_EventArgs = StockRoom11net.Controls.Custom_Events_Args.ThumbNailMouseMove_EventArgs;

namespace StockRoom11net.Controls.ThumbViewer
{
    public partial class ThumbViewer : UserControl
    {
        private readonly object _cacheLock = new();
        private readonly System.Collections.Concurrent.ConcurrentDictionary<string, Image> _thumbnailCache = new();
        private CancellationTokenSource _loadCts;
        private readonly SemaphoreSlim _concurrency = new(4);
        private bool _isDisposed;

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
        /// This partNumber have a folder, are expect more than 1 picture.
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

        ResourcesCache.ResourcesCache _cache = new ResourcesCache.ResourcesCache();

        bool ReportEvents;
        int lastMouseMove;
        int lastDragDirection; // -1 = left, +1 = right, 0 = unknown/no horizontal movement yet
        Panel? placeToInsert;
        ThumbNail? thumbnailChildAtPosition;
        ThumbNail? thumbnailDisplaced;


        /// <summary>
        /// Internal record of number of pictures founded.
        /// </summary>
        int _informationStatus = 0;

        #endregion"Properties"

        #region"CurrentUserBroadcast"

        private string EmployeeName = "Not user login.";
        private string EmployeeLastName = "";
        private Utilities.AccessLevel EmployeeAccessLevel = Utilities.AccessLevel.User;
        private Utilities.EditMode EmployeeEditMode = Utilities.EditMode.View;
        private EmployeeInformation.EmployeeInformation _currentEmployeesLogIn;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EmployeeInformation.EmployeeInformation CurrentEmployeesLogIn
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
        readonly double _ratioImage = 1.314;

        /// <summary>
        /// Extra vertical space (paddings + slack) added to _thumbNailHeight to get the Panel2 height.
        /// </summary>
        int ThumbNailRowChrome => splitContainer_ThumbViewer.Panel2.Padding.Vertical
                                  + flowLayoutPanel_ThumbNails.Padding.Vertical
                                  + ThumbNailVerticalPadding;

        [Category("Control Properties"),
        DefaultValue(92),
        Description("Width of ThumbNail, default value is 92. Derived from ThumbNailHeight; setting it only takes effect if consistent with the ratio.")]
        public int ThumbNailWidth
        {
            get => _thumbNailWidth;
            set
            {
                if (value >= 10)
                    _thumbNailWidth = value;
            }
        }

        [Category("Control Properties"),
        DefaultValue(70),
        Description("Height of ThumbNail, default value is 70. Drives the initial splitter position.")]
        public int ThumbNailHeight
        {
            get => _thumbNailHeight;
            set
            {
                if (value < 1 || value == _thumbNailHeight)
                    return;

                _thumbNailHeight = value;
                _thumbNailWidth = (int)(_thumbNailHeight * _ratioImage);

                // Re-position the splitter (no-op until the container has a real size,
                // or after the user has dragged the splitter).
                ApplySplitterFromThumbNailHeight();
            }
        }

        /// <summary>
        /// Height of the thumbnail row (Panel2). Kept for designer/host compatibility;
        /// it is derived from ThumbNailHeight and setting it maps back to ThumbNailHeight.
        /// </summary>
        [Category("Control Properties"),
        DefaultValue(88),
        Description("Height of the thumbnail row (Panel2). Derived from ThumbNailHeight.")]
        public int SplitterDistance
        {
            get => _thumbNailHeight + ThumbNailRowChrome;
            set
            {
                int height = value - ThumbNailRowChrome;
                if (height >= 1)
                    ThumbNailHeight = height;
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
                            ClearFlowLayoutPanelThumbNails();
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
                if (_pathFromPartNumber == value)
                    return;

                _pathFromPartNumber = value;
                IsFromPartNumber = true;                

                ClearFlowLayoutPanelThumbNails();

                // If the information is incorrect, show "No_Picture_Found.jpg"
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    directoryPathString = Path.Combine(Settings.Default.DataBaseAddress, "Resources", "No_Picture_Found.jpg");
                    GetPictureProcess(directoryPathString, false);
                    return;
                }
                                
                PathFromPartNumberProcess();
            }
        }

        #endregion"Properties, Custom Control Properties"


        public ThumbViewer()
        {
            try
            {
                InitializeComponent();

                ReportEvents = false;

                flowLayoutPanel_ThumbNails.AllowDrop = true;
                flowLayoutPanel_ThumbNails.HorizontalScroll.Enabled = false;
                flowLayoutPanel_ThumbNails.HorizontalScroll.Visible = false;
                flowLayoutPanel_ThumbNails.VerticalScroll.SmallChange = 2;
                flowLayoutPanel_ThumbNails.VerticalScroll.LargeChange = 80;
                flowLayoutPanel_ThumbNails.MouseEnter += new EventHandler(FlowLayoutPanel_MouseEnter);
                flowLayoutPanel_ThumbNails.MouseWheel += new MouseEventHandler(FlowLayoutPanel_MouseWheel);
                flowLayoutPanel_ThumbNails.DragEnter += new DragEventHandler(FlowLayoutPanel_DragEnter);
                flowLayoutPanel_ThumbNails.DragDrop += new DragEventHandler(FlowLayoutPanel_DragDrop);
                flowLayoutPanel_ThumbNails.GiveFeedback += new GiveFeedbackEventHandler(FlowLayoutPanel_GiveFeedback);
                flowLayoutPanel_ThumbNails.DragOver += new DragEventHandler(FlowLayoutPanel_DragOver);

                splitContainer_ThumbViewer.IsSplitterFixed = true;
                splitContainer_ThumbViewer.MouseDown += SplitContainer_ThumbViewer_MouseDown;
                splitContainer_ThumbViewer.MouseMove += SplitContainer_ThumbViewer_MouseMove;
                splitContainer_ThumbViewer.MouseUp += SplitContainer_ThumbViewer_MouseUp;
                splitContainer_ThumbViewer.MouseLeave += (_, _) => splitContainer_ThumbViewer.Cursor = Cursors.Default;

                // Panel2 keeps its height when the container is resized; only the user's drag changes it.
                splitContainer_ThumbViewer.FixedPanel = FixedPanel.Panel2;
                splitContainer_ThumbViewer.SizeChanged += SplitContainer_ThumbViewer_SizeChanged;

                InitializedFlowLayoutPanel();
                InitializedPictureBox();
                InitializeToDropPanel();

                InitializeTimerPathFromPartNumber();
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



        /// <summary>Once the user drags the splitter, stop forcing Panel2 to _thumbNailHeight.</summary>
        bool _splitterUserOverride;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplySplitterFromThumbNailHeight();
        }

        void SplitContainer_ThumbViewer_SizeChanged(object sender, EventArgs e)
        {
            ApplySplitterFromThumbNailHeight();
        }

        /// <summary>
        /// Positions the splitter so Panel2 is exactly tall enough for one row of
        /// thumbnails of _thumbNailHeight. Re-applied on every resize until the user drags.
        /// </summary>
        void ApplySplitterFromThumbNailHeight()
        {
            if (_splitterUserOverride || _splitterDragging || !IsHorizontalSplit)
                return;

            int panel2Height = _thumbNailHeight + ThumbNailRowChrome;

            int min = splitContainer_ThumbViewer.Panel1MinSize;
            int max = splitContainer_ThumbViewer.Height
                      - splitContainer_ThumbViewer.SplitterWidth
                      - splitContainer_ThumbViewer.Panel2MinSize;

            if (max <= min)
                return;

            int distance = Math.Clamp(
                splitContainer_ThumbViewer.Height - splitContainer_ThumbViewer.SplitterWidth - panel2Height,
                min, max);

            if (distance != splitContainer_ThumbViewer.SplitterDistance)
                splitContainer_ThumbViewer.SplitterDistance = distance;
        }


        System.Windows.Forms.Timer PathFromPartNumberTimer;

        void InitializeTimerPathFromPartNumber()
        {
            PathFromPartNumberTimer = new System.Windows.Forms.Timer
            {
                Interval = 5 //250
            };

            PathFromPartNumberTimer.Tick += PathFromPartNumberTimer_Tick;
        }

        void PathFromPartNumberTimer_Tick(object? sender, EventArgs e)
        {
            PathFromPartNumberTimer.Stop();

            PathFromPartNumberProcess();
        }

        /// <summary>True while the user is dragging the splitter with the left button.</summary>
        bool _splitterDragging;

        /// <summary>Offset between the mouse and the top of the splitter bar at drag start.</summary>
        int _splitterDragOffset;

        /// <summary>
        /// Vertical space reserved so one row of thumbnails fits without a vertical scrollbar.
        /// </summary>
        const int ThumbNailVerticalPadding = 1;

        bool IsHorizontalSplit => splitContainer_ThumbViewer.Orientation == Orientation.Horizontal;

        void SplitContainer_ThumbViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || splitContainer_ThumbViewer.Panel2Collapsed)
                return;

            if (!splitContainer_ThumbViewer.SplitterRectangle.Contains(e.Location))
                return;

            _splitterDragging = true;
            _splitterUserOverride = true;
            _splitterDragOffset = IsHorizontalSplit
                ? e.Y - splitContainer_ThumbViewer.SplitterRectangle.Y
                : e.X - splitContainer_ThumbViewer.SplitterRectangle.X;
        }

        void SplitContainer_ThumbViewer_MouseMove(object sender, MouseEventArgs e)
        {
            // Hover feedback (IsSplitterFixed suppresses the built-in cursor change).
            if (!_splitterDragging)
            {
                bool mouseOverSplitterRectangle = splitContainer_ThumbViewer.SplitterRectangle.Contains(e.Location);
                splitContainer_ThumbViewer.Cursor = mouseOverSplitterRectangle
                    ? (IsHorizontalSplit ? Cursors.HSplit : Cursors.VSplit) : Cursors.Default;
                return;
            }

            int proposed = (IsHorizontalSplit ? e.Y : e.X) - _splitterDragOffset;

            int total = IsHorizontalSplit ? splitContainer_ThumbViewer.Height : splitContainer_ThumbViewer.Width;
            int min = splitContainer_ThumbViewer.Panel1MinSize;
            int max = total - splitContainer_ThumbViewer.SplitterWidth - splitContainer_ThumbViewer.Panel2MinSize;

            if (max <= min)
                return;

            proposed = Math.Clamp(proposed, min, max);

            if (proposed == splitContainer_ThumbViewer.SplitterDistance)
                return;

            splitContainer_ThumbViewer.SplitterDistance = proposed;
            ResizeThumbNails(splitContainer_ThumbViewer.Panel2.ClientSize.Height);
            splitContainer_ThumbViewer.Update();
        }

        void SplitContainer_ThumbViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _splitterDragging = false;
        }

        /// <summary>
        /// Recomputes the thumbnail size for the given Panel2 height and applies it
        /// to every ThumbNail hosted in the flowLayoutPanel.
        /// </summary>
        void ResizeThumbNails(int panel2Height)
        {
            int availableHeight = panel2Height
                                  - splitContainer_ThumbViewer.Panel2.Padding.Vertical
                                  - flowLayoutPanel_ThumbNails.Padding.Vertical
                                  - ThumbNailVerticalPadding;

            if (availableHeight < 1 || availableHeight == _thumbNailHeight)
                return;

            // Update backing fields directly; the ThumbNailHeight setter has side effects.
            _thumbNailHeight = availableHeight;
            _thumbNailWidth = (int)(_thumbNailHeight * _ratioImage);

            placeToInsert?.Height = _thumbNailHeight;

            flowLayoutPanel_ThumbNails.SuspendLayout();
            try
            {
                foreach (Control control in flowLayoutPanel_ThumbNails.Controls)
                {
                    if (control is ThumbNail thumb)
                        thumb.Resize(_thumbNailWidth, _thumbNailHeight);
                }
            }
            finally
            {
                flowLayoutPanel_ThumbNails.ResumeLayout(true);
            }

            // Force an immediate repaint so the change is visible while the mouse is captured.
            flowLayoutPanel_ThumbNails.Update();
        }



        void PathFromPartNumberProcess()
        {
            _informationStatus = 0;

            if (_pathFromPartNumber == null)
                return;

            if (_pathFromPartNumber.Contains(';'))
            {
                string[] strings = _pathFromPartNumber.Split([';'], StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in strings)
                {
                    DirectoryPath = Path.Combine(DefaultAddress, item.Trim());
                    if (Directory.Exists(DirectoryPath))
                    {
                        #region"The path is a directory"

                        TheItem_HaveFolder = true;
                        ProcessDirectory(DirectoryPath);

                        #endregion"The path is a directory"
                    }
                    else
                    {
                        #region"The path is a file"

                        TheItem_HaveFolder = false;
                        string searchPattern = item.Trim();

                        if (searchPattern.Contains('.'))
                            searchPattern = searchPattern[..searchPattern.IndexOf('.')];

                        searchPattern += "*.*";
                        string[] strFiles = [..Directory.EnumerateFiles(DefaultAddress, searchPattern)];

                        if (strFiles.Length == 1)
                        {
                            ProcessFile(strFiles[0]);
                            _informationStatus += 1;
                        }

                        #endregion"The path is a file"
                    }
                }
            }
            else
            {
                DirectoryPath = Path.Combine(DefaultAddress, _pathFromPartNumber);
                if (Directory.Exists(DirectoryPath))
                {
                    #region"The path is a directory"

                    TheItem_HaveFolder = true;

                    ProcessDirectory(DirectoryPath);

                    #endregion"The path is a directory"
                }
                else
                {
                    #region"The path is a file"

                    TheItem_HaveFolder = false;
                    splitContainer_ThumbViewer.Panel2Collapsed = true;                    
                    ProcessFile(_pathFromPartNumber);

                    #endregion"The path is a file"
                }
            }

            On_InformationStatus(new InformationStatus_EventArgs(true, _informationStatus));
        }


        void InitializeToDropPanel()
        {
            placeToInsert = new Panel
            {
                Width = 10,
                Height = 70,
                BackColor = Color.Beige,
                BorderStyle = BorderStyle.FixedSingle
            };
            placeToInsert.BringToFront();
        }

        void Thumbnail_ThumbNailDragStarting(object sender, MouseEventArgs e)
        {
            thumbNailSource = sender as ThumbNail;

            using (Bitmap bmp = new Bitmap(thumbNailSource.Width, thumbNailSource.Height))
            {
                thumbNailSource.DrawToBitmap(bmp, new Rectangle(Point.Empty, new Size((thumbNailSource.Size.Width - 10), (thumbNailSource.Size.Height - 20))));
                dragCursor = new Cursor(bmp.GetHicon());
            }

            lastMouseMove = e.X;
            dragType = thumbNailSource.GetType();

            try
            {
                flowLayoutPanel_ThumbNails.DoDragDrop(thumbNailSource, DragDropEffects.Move);
            }
            finally
            {
                // Guaranteed to run no matter where the drop landed
                // (inside flowLayoutPanel_ThumbNails, on a foreign control, or cancelled).
                Cursor = Cursors.Default;
                flowLayoutPanel_ThumbNails.Controls.Remove(placeToInsert);
                thumbnailDisplaced = null;

                dragCursor?.Dispose();
                dragCursor = null;
            }
        }

        void FlowLayoutPanel_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                Point clientPoint = flowLayoutPanel_ThumbNails.PointToClient(new Point(e.X, e.Y));

                Control? childAtPoint = flowLayoutPanel_ThumbNails.GetChildAtPoint(clientPoint);
                if (childAtPoint == null)
                    return;

                thumbnailChildAtPosition = childAtPoint as ThumbNail;
                if (thumbnailChildAtPosition == null)
                {
                    thumbnailDisplaced = new ThumbNail();
                    return;
                }

                int currentDirection = e.X.CompareTo(lastMouseMove);

                bool sameTarget = thumbnailDisplaced != null && thumbnailDisplaced.FileName == thumbnailChildAtPosition.FileName;
                bool sameDirection = currentDirection == 0 || currentDirection == lastDragDirection;

                if (sameTarget && sameDirection)
                    return;

                thumbnailDisplaced = thumbnailChildAtPosition;

                flowLayoutPanel_ThumbNails.SuspendLayout();
                try
                {
                    // Compute the target's index as if the placeholder weren't in the collection at all,
                    // without actually removing/re-adding it (which was causing the visible shift).
                    int rawIndex = flowLayoutPanel_ThumbNails.Controls.GetChildIndex(thumbnailChildAtPosition, false);
                    bool placeholderPresent = flowLayoutPanel_ThumbNails.Controls.Contains(placeToInsert);
                    int placeholderIndex = placeholderPresent
                        ? flowLayoutPanel_ThumbNails.Controls.GetChildIndex(placeToInsert, false)
                        : -1;

                    int index = (placeholderPresent && placeholderIndex < rawIndex) ? rawIndex - 1 : rawIndex;

                    On_StatusBarMessage(new StatusBarMessage_EventArgs("Mouse position mouseOverSplitterRectangle thumbnail index " + index + " position at " + thumbnailMousePosition, 1));

                    if (!placeholderPresent)
                        flowLayoutPanel_ThumbNails.Controls.Add(placeToInsert);

                    if (currentDirection != 0)
                    {
                        lastDragDirection = currentDirection;
                        lastMouseMove = e.X;
                    }

                    if (placeToInsert != null)
                    {
                        // thumbNail is being dragged to the left.
                        if (lastDragDirection < 0)
                            flowLayoutPanel_ThumbNails.Controls.SetChildIndex(placeToInsert, index);
                        // thumbNail is being dragged to the right.
                        else if (lastDragDirection > 0)
                            flowLayoutPanel_ThumbNails.Controls.SetChildIndex(placeToInsert, index + 1);
                    }
                }
                finally
                {
                    flowLayoutPanel_ThumbNails.ResumeLayout(true);
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
            flowLayoutPanel_ThumbNails.Controls.Remove(placeToInsert);

            if (EmployeeAccessLevel < Utilities.AccessLevel.Administrator)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            ThumbNail? source = (ThumbNail?)e.Data.GetData(dragType)?? null;
            ThumbNail? target = (ThumbNail?)flowLayoutPanel_ThumbNails.GetChildAtPoint(flowLayoutPanel_ThumbNails.PointToClient(new Point(e.X, e.Y)))?? null;

            if (source == null) return;
            if (target == null) return;
            if (target.FileName == source.FileName) return;

            int index = flowLayoutPanel_ThumbNails.Controls.GetChildIndex(target);
            flowLayoutPanel_ThumbNails.Controls.SetChildIndex(source, index);

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
            flowLayoutPanel_ThumbNails.DoubleClick += FlowLayoutPanel_DoubleClick;
        }

        void FlowLayoutPanel_DoubleClick(object? sender, EventArgs e)
        {
            ReportEvents = !ReportEvents;
        }


        void FlowLayoutPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!flowLayoutPanel_ThumbNails.VerticalScroll.Visible)
                return;

            if (e.Delta > 0 && flowLayoutPanel_ThumbNails.VerticalScroll.Value > 30)
                flowLayoutPanel_ThumbNails.VerticalScroll.Value += 40;
                            
            if (e.Delta < 0)
                if (flowLayoutPanel_ThumbNails.VerticalScroll.Value > 41)
                    flowLayoutPanel_ThumbNails.VerticalScroll.Value -= 40;
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
                flowLayoutPanel_ThumbNails.BackgroundImage = null;
                flowLayoutPanel_ThumbNails.Controls.Clear();

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
                        flowLayoutPanel_ThumbNails.BackgroundImage = null;
                        flowLayoutPanel_ThumbNails.Controls.Clear();
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

                    flowLayoutPanel_ThumbNails.Controls.Add(thumbnail);

                    if (flowLayoutPanel_ThumbNails.Controls.Count == 1)
                    {
                        splitContainer_ThumbViewer.Panel2Collapsed = false;
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
                TryDeleteDirectory(pathDirectory);
                GetPictureProcess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Picture_Found.jpg", false);
                splitContainer_ThumbViewer.Panel2Collapsed = true;
                return;
            }

            if (strFiles.Length == 1)
            {
                GetPictureProcess(Path.Combine(pathDirectory, strFiles[0]), true);
                splitContainer_ThumbViewer.Panel2Collapsed = true;
                _informationStatus += 1;
                return;
            }

            if (strFiles.Length > 1)
            {
                splitContainer_ThumbViewer.Panel2Collapsed = false;
                LoadPicturesInDirectory(strFiles);

            }
        }

        /// <summary>
        /// Add an auto-generate thumbNail for each image existent in this directory.
        /// </summary>
        /// <param name="strFiles"></param>
        /// <param name="directoryPath"></param>
        void LoadPicturesInDirectory(string[] strFiles)
        {
            // If the user select a different directory before the loop finished, we need restart.
            flowLayoutPanel_ThumbNails.Controls.Clear();

            foreach (ThumbNail thumb in GetThumbNailImage(strFiles))
            {
                flowLayoutPanel_ThumbNails.Controls.Add(thumb);
                thumb.Index = flowLayoutPanel_ThumbNails.Controls.Count;

                if (thumb.Index == 1)
                {
                    Thumbnail_ThumbNailClicked(new object(), new ThumbNailClick_EventArgs(thumb.FileName, thumb.FilePath, thumb));
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


        private bool TryDeleteDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
                return false;

            try
            {
                // Clear read-only attributes so Delete doesn't fail on protected files
                foreach (var file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
                    File.SetAttributes(file, FileAttributes.Normal);

                Directory.Delete(path, recursive: true);

                On_StatusBarMessage(new StatusBarMessage_EventArgs($"Deleted folder: {path}"));
                return true;
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs($"Could not delete folder: {ex.Message}"));
                return false;
            }
        }

        Type dragType;
        Cursor? dragCursor;
        ThumbNail thumbNailSource;
        int thumbnailMousePosition;
                
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
            int index = flowLayoutPanel_ThumbNails.Controls.GetChildIndex(thumbnailChildAtPosition, false);
            On_StatusBarMessage(new StatusBarMessage_EventArgs("Mouse position enter at thumbnail index " + index + " position at " + thumbnailMousePosition, 1));
        }

        void Thumbnail_ThumbNailMouseMove(object sender, ThumbNailMouseMove_EventArgs e)
        {
            thumbnailMousePosition = e.MousePosition;
        }

        /// <summary>
        /// Remove all thumbNail present in flowLayoutPanel and collapse the splitContainer_ThumbViewer.Panel2.
        /// </summary>
        void ClearFlowLayoutPanelThumbNails()
        {
            if (flowLayoutPanel_ThumbNails.Controls.Count == 0)
                return;

            foreach (ThumbNail thumbnail in flowLayoutPanel_ThumbNails.Controls.OfType<ThumbNail>())
            {
                thumbnail.Dispose();
            }
            
            flowLayoutPanel_ThumbNails.Controls.Clear();
            splitContainer_ThumbViewer.Panel2Collapsed = true;
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

            toolStripMenuItem_AddANewPicture.Click += ToolStripMenuItemAddANewPictureClick;
            toolStripMenuItem_AddANewPicture.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItem_AddANewPicture.MouseLeave += ToolStripMenuItem_MouseLeave;

            toolStripMenuItemCopyToANewFile.Click += ToolStripMenuItemCopyToANewFile_Click;
            toolStripMenuItemCopyToANewFile.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItemCopyToANewFile.MouseLeave += ToolStripMenuItem_MouseLeave;

            toolStripMenuItemCopyFileToTheClickBoard.Click += ToolStripMenuItemCopyFileToTheClickBoard_Click;
            toolStripMenuItemCopyFileToTheClickBoard.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItemCopyFileToTheClickBoard.MouseLeave += ToolStripMenuItem_MouseLeave;

            toolStripMenuItemCopyImageToTheClipBoard.Click += ToolStripMenuItemCopyImageToTheClipBoard_Click;
            toolStripMenuItemCopyImageToTheClipBoard.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItemCopyImageToTheClipBoard.MouseLeave += ToolStripMenuItem_MouseLeave;

            toolStripMenuItemPasteImageFromClipBoard.Click += ToolStripMenuItemPasteImageFromClipBoard_Click;
            toolStripMenuItemPasteImageFromClipBoard.MouseHover += ToolStripMenuItem_MouseHover;
            toolStripMenuItemPasteImageFromClipBoard.MouseLeave += ToolStripMenuItem_MouseLeave;

            toolStripMenuItem_RemoveThisPicture.Click += ToolStripMenuItemRemoveThisPictureClick;
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


        void ContextMenuStripPictureBoxOpening(object? sender, CancelEventArgs e)
        {
            contextMenuStripPictureBox.Items.Clear();

            contextMenuStripPictureBox.Items.AddRange(new ToolStripMenuItem[]
                                                                      {
                                                                          toolStripMenuItemCopyToANewFile,
                                                                          toolStripMenuItemCopyFileToTheClickBoard,
                                                                          toolStripMenuItemCopyImageToTheClipBoard,
                                                                          toolStripMenuItemPasteImageFromClipBoard
                                                                      });
            #region"IsManager or Administrator"

            if (EmployeeAccessLevel == Utilities.AccessLevel.Manager ||
                EmployeeAccessLevel == Utilities.AccessLevel.Administrator)
            {
                contextMenuStripPictureBox.Items.Add(toolStripMenuItem_AddANewPicture);

                // If the picture is a default picture, we do not want to allow the user to remove it.
                if (FilePathPictureBoxImage.Contains("No_"))
                    return;
                else
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

        void ToolStripMenuItemRemoveThisPictureClick(object? sender, EventArgs e)
        {
            if (TheItem_HaveFolder)
            {
                #region"RemovePictureFromFolder"

                if (FilePathPictureBoxImage != null)
                    if (File.Exists(FilePathPictureBoxImage))
                    {
                        try
                        {
                            DialogResult = MessageBox.Show(@"Do you want to save this photo with" + Environment.NewLine +
                                                            "a new name so you can use it later?", "Save picture.",
                                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (DialogResult == System.Windows.Forms.DialogResult.Cancel)
                                return;

                            //Using FileInfo class copy the file.
                            FileInfo _fileInfo = new FileInfo(FilePathPictureBoxImage);

                            if (DialogResult == System.Windows.Forms.DialogResult.Yes)
                            {
                                #region"Yes, save the picture"

                                using (var openfile = new OpenFileDialogExt.OpenFileDialogExt
                                {
                                    Title = @"Please name the picture to be saved.",
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

                            using (var openfile = new OpenFileDialogExt.OpenFileDialogExt
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


        void ToolStripMenuItemCopyToANewFile_Click(object? sender, EventArgs e)
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

        void ToolStripMenuItemCopyFileToTheClickBoard_Click(object? sender, EventArgs e)
        {
            StringCollection FileCollection = new StringCollection();
            FileCollection.Add(pictureBox_Image.ImageLocation);
            Clipboard.SetFileDropList(FileCollection);
        }

        void ToolStripMenuItemCopyImageToTheClipBoard_Click(object? sender, EventArgs e)
        {
            Clipboard.SetDataObject(data: pictureBox_Image.Image, copy: true);
        }

        void ToolStripMenuItemPasteImageFromClipBoard_Click(object? sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                Image? image = Clipboard.GetImage();
                if (image == null)
                {
                    MessageBox.Show("Clipboard does not contain a valid image.", "Paste Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pictureBox_Image.Image = image;

                NameImageSave(image);
            }
        }

        void NameImageSave(Image? image)
        {
            string fileName = $"Pasted_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string fullPath = Path.Combine(DefaultAddress, fileName);

            try
            {
                if (image != null)
                {
                    image.Save(fullPath, ImageFormat.Png);
                    On_StatusBarMessage(new StatusBarMessage_EventArgs($"Image saved: {fullPath}"));
                    ProcessAddANewPicture([fullPath]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save image:{Environment.NewLine}{ex.Message}",
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (EmployeeAccessLevel == Utilities.AccessLevel.User)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsFromPartNumber)
            {
                using (var directoryFile = new DirectoryFile())
                {
                    directoryFile.Title = @"Select one or more picture to be added to this part number.";

                    // Yes, directoryFile.CopyMultiFileToFolder() will return an array of strings containing
                    // the full path and name of each file selected by the user to be copied into the folder.
                    string[] filesToCopy = directoryFile.CopyMultiFileToFolder();

                    // If the user did not select any file, return.
                    if (filesToCopy.Length == 0)
                        return;

                    ProcessAddANewPicture(filesToCopy);                    
                }
            }
        }

        void ProcessAddANewPicture(string[] filesToCopy)
        {
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

        void UpDateFileNameIndex()
        {
            foreach (Control thumb in flowLayoutPanel_ThumbNails.Controls)
            {
                try
                {
                    var thumbNail = (ThumbNail)thumb;

                    var newFileName = Path.Combine(DirectoryPath, PathFromPartNumber + "#temp" +
                                         flowLayoutPanel_ThumbNails.Controls.IndexOf(thumb).ToString("00") + thumbNail.FileExt);

                    FileSystemExt.FileSystemExt.FileRename(thumbNail.FileFullPath, newFileName);
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
                    FileSystemExt.FileSystemExt.FileRename(fileName, newFileName);
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

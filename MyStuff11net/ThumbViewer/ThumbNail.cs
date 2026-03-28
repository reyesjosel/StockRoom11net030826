// *******************************************************************
// File    : ThumbNail.cs 
// Author  : Igor Tolmachev
// Email   : info@itsamples.com
// Web     : www.itsamples.com 
// You are free to use/modify this code but leave this header intact.
// *******************************************************************

using System.ComponentModel;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ThumbNailClick_EventArgs = MyStuff11net.Custom_Events_Args.ThumbNailClick_EventArgs;
using ThumbNailMouseEnter_EventArgs = MyStuff11net.Custom_Events_Args.ThumbNailMouseEnter_EventArgs;
using ThumbNailMouseMove_EventArgs = MyStuff11net.Custom_Events_Args.ThumbNailMouseMove_EventArgs;

namespace MyStuff11net
{
    public class ThumbNail : UserControl
    {
        int _width = 102;
        int _height = 80;

        public PictureBox pictureBox;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        #region "Properties & Fields"

        public bool m_bOpenFile;

        string strFileName;

        /// <summary>
        /// Return the extension of the specified path string;
        /// </summary>
        public string FileExt
        {
            get
            {
                return Path.GetExtension(strFileName);
            }
        }

        /// <summary>
        /// Return the file name and extension of the specified path string
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Return the file name and extension of the specified path string
        /// </summary>
        public string FileName
        {
            get
            {
                return Path.GetFileName(strFileName);
            }

            private set { }
        }

        /// <summary>
        /// Return the absolute path for the specified path string.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Return the absolute path for the specified path string.
        /// </summary>
        public string FilePath
        {
            get
            {
                return Path.GetFullPath(strFileName).Replace(FileName, "");
            }

            set
            {

            }
        }

        /// <summary>
        /// Return the absolute full path for the specified path string.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Return the absolute full path for the specified path string.
        /// </summary>
        public string FileFullPath
        {
            get
            {
                return Path.GetFullPath(strFileName);
            }

            set
            {

            }
        }

        bool isSelected;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Selected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;

                SetBackGroundColor(value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image ThumbNailImage
        {
            get
            {
                return pictureBox.Image;
            }
            set
            {
                if (value != null)
                    pictureBox.Image = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Index { get; internal set; }

        #endregion "Properties & Fields"

        #region"ThumbNailClick"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ThumbNailClickEventHandler(object sender, ThumbNailClick_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ThumbNail control has been clicked.")]
        public event ThumbNailClickEventHandler ThumbNailClicked;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_ThumbNailClick_Event(ThumbNailClick_EventArgs e)
        {
            ThumbNailClicked?.Invoke(this, e);
        }
        #endregion"ThumbNailClickClick"

        #region"ThumbNailMouseMove"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ThumbNailMouseMoveEventHandler(object sender, ThumbNailMouseMove_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ThumbNail control has been clicked.")]
        public event ThumbNailMouseMoveEventHandler ThumbNailMouseMove;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_ThumbNailMouseMove_Event(ThumbNailMouseMove_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (ThumbNailMouseMove != null)
            {
                // Notify Subscribers
                ThumbNailMouseMove(this, e);
            }
        }
        #endregion"ThumbNailMouseMoveClick"

        #region"ThumbNailMouseEnter"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ThumbNailMouseEnterEventHandler(object sender, ThumbNailMouseEnter_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ThumbNail control has been clicked.")]
        public event ThumbNailMouseEnterEventHandler ThumbNailMouseEnter;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_ThumbNailMouseEnter_Event(ThumbNailMouseEnter_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (ThumbNailMouseEnter != null)
            {
                // Notify Subscribers
                ThumbNailMouseEnter(this, e);
            }
        }
        #endregion"ThumbNailMouseEnter"

        #region"ThumbNailDragStarting"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ThumbNailDragStartingEventHandler(object sender, MouseEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ThumbNail control has been dragged.")]
        public event ThumbNailDragStartingEventHandler ThumbNailDragStarting;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_ThumbNailDragStarting_Event(MouseEventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (ThumbNailDragStarting != null)
            {
                // Notify Subscribers
                ThumbNailDragStarting(this, e);
            }
        }
        #endregion"ThumbNailDragStarting"

        public ThumbNail()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            strFileName = @"X:\Test Unit\File Not Defined.JPG";
        }

        public ThumbNail(string imageFilePath, int width, int height)
        {
            _width = width;
            _height = height;

            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            var toolTip = new ToolTip
            {
                // Set up the delays for the ToolTip.
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                BackColor = Color.Peru,
                ForeColor = Color.Black,
                ReshowDelay = 500,
                // Force the ToolTip text to be displayed whether or not the form is active.
                ShowAlways = true
            };

            strFileName = imageFilePath;

            // Set up the ToolTip text for the Button and Check-box.
            toolTip.SetToolTip(pictureBox, "File: " + strFileName + "\n");

            //GetThumbNailImage(imageFilePath);
            Task.Factory.StartNew(() => GetThumbNailImage(imageFilePath, width, height));
        }

        public ThumbNail(string strFile, Image pImage)
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            var toolTip = new ToolTip
            {
                // Set up the delays for the ToolTip.
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                BackColor = Color.Peru,
                ForeColor = Color.Black,
                ReshowDelay = 500,
                // Force the ToolTip text to be displayed whether or not the form is active.
                ShowAlways = true
            };

            if (pImage != null)
                ThumbNailImage = (Image)pImage.Clone();

            strFileName = strFile;
            var strTip = "File: " + strFile + "\n";

            // Set up the ToolTip text for the Button and Check-box.
            toolTip.SetToolTip(pictureBox, strTip);

            pictureBox.MouseMove += PictureBox_MouseMove;
        }


        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            ((ISupportInitialize)(pictureBox)).BeginInit();
            SuspendLayout();
            //
            // pictureBox
            //
            pictureBox.BackColor = Color.WhiteSmoke;
            pictureBox.BackgroundImageLayout = ImageLayout.Center;
            pictureBox.Cursor = Cursors.Hand;
            pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox.ErrorImage = global::MyStuff11net.Properties.Resources.Empty;
            pictureBox.Image = global::MyStuff11net.Properties.Resources.Empty;
            pictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Margin = new Padding(0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(102, 80);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;

            pictureBox.MouseClick += PictureBox_MouseClick;
            pictureBox.MouseEnter += PictureBox_MouseEnter;
            pictureBox.MouseLeave += PictureBox_MouseLeave;
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseMove += PictureBox_MouseMove;
            //
            // ThumbNail
            //
            BackColor = System.Drawing.SystemColors.Control;
            Controls.Add(pictureBox);
            Margin = new Padding(0);
            MaximumSize = new Size(500, 400);
            MinimumSize = new Size(50, 40);
            Name = "ThumbNail";
            Size = new Size(_width, _height);
            ((ISupportInitialize)(pictureBox)).EndInit();
            ResumeLayout(false);
        }

        private bool DraggingFromGrid;
        private Point DraggingStartPoint = new Point();

        void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            isSelected = true;
            On_ThumbNailClick_Event(new ThumbNailClick_EventArgs(strFileName, FilePath, this));
        }

        void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //isSelected = true;
            // On_ThumbNailClick_Event(new ThumbNailClick_EventArgs(strFileName, FilePath, this, ItemPicture));

            if (e.Button == MouseButtons.Left)
            {
                DraggingFromGrid = true;
                DraggingStartPoint = new Point(e.X, e.Y);
            }
        }

        void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (DraggingFromGrid)
            {
                DraggingFromGrid = false;
            }
        }

        void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int Xpos = 0;
            Xpos = e.X - (Width / 2);
            // Send the information out side.
            On_ThumbNailMouseMove_Event(new ThumbNailMouseMove_EventArgs(Xpos, this));

            if (DraggingFromGrid)
            {
                if (Math.Abs(e.X - DraggingStartPoint.X) > SystemInformation.DragSize.Width ||
                    Math.Abs(e.Y - DraggingStartPoint.Y) > SystemInformation.DragSize.Height)
                {
                    // Start Dragging process.
                    DraggingFromGrid = false;
                    On_ThumbNailDragStarting_Event(e);
                }
            }
        }

        void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            SetBackGroundColor(true);
            On_ThumbNailMouseEnter_Event(new ThumbNailMouseEnter_EventArgs(strFileName, FilePath, this));
        }

        void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (Selected)
                return;

            SetBackGroundColor(false);
        }


        /// <summary>
        /// Generate a thumbNail for the image file path.
        /// </summary>
        /// <param name="imageFilePath"></param>
        /// <returns></returns>
        void GetThumbNailImage(string imageFilePath, int width, int height)
        {
            try
            {
                var imagePict = GetImageFromByteArray(File.ReadAllBytes(imageFilePath));

                if (imagePict == null)
                    return;

                int cxThumbnail, cyThumbnail;

                if (imagePict.Width > imagePict.Height)
                {
                    cxThumbnail = width;
                    cyThumbnail = height * imagePict.Height / imagePict.Width;
                }
                else
                {
                    cyThumbnail = height;
                    cxThumbnail = width * imagePict.Width / imagePict.Height;
                }

                ThumbNailImage = imagePict.GetThumbnailImage(cxThumbnail, cyThumbnail, () => false, IntPtr.Zero);
                imagePict = null;
            }
            catch (Exception error)
            {
                var errrr = error.Message;
                ThumbNailImage = null;
            }
        }

        void SetBackGroundColor(bool selectedThumbNails)
        {
            if (selectedThumbNails)
                pictureBox.BackColor = Color.Silver;
            else
                pictureBox.BackColor = Color.WhiteSmoke;
        }

        [DllImport("kernel32.dll", EntryPoint = "CopyMemory")]
        static extern void CopyMemory(IntPtr Destination, IntPtr Source, uint Length);

        public static Bitmap KernelDllCopyBitmap(Bitmap bmp, bool CopyPalette = true)
        {
            var bmpDest = new Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat);

            if (!KernelDllCopyBitmap(bmp, bmpDest, CopyPalette))
                bmpDest = null;

            return bmpDest;
        }

        /// <summary>
        /// Copy bitmap data.
        /// Note: bitmaps must have same size and pixel format.
        /// </summary>
        /// <param name="bmpSrc">Source Bitmap</param>
        /// <param name="bmpDest">Destination Bitmap</param>
        /// <param name="CopyPalette">Must copy Palette</param>
        public static bool KernelDllCopyBitmap(Bitmap bmpSrc, Bitmap bmpDest, bool CopyPalette = false)
        {
            bool copyOk = false;
            copyOk = CheckCompatibility(bmpSrc, bmpDest);
            if (copyOk)
            {
                BitmapData bmpDataSrc;
                BitmapData bmpDataDest;

                //Lock Bitmap to get BitmapData
                bmpDataSrc = bmpSrc.LockBits(new Rectangle(0, 0, bmpSrc.Width, bmpSrc.Height), ImageLockMode.ReadOnly, bmpSrc.PixelFormat);
                bmpDataDest = bmpDest.LockBits(new Rectangle(0, 0, bmpDest.Width, bmpDest.Height), ImageLockMode.WriteOnly, bmpDest.PixelFormat);
                int lenght = bmpDataSrc.Stride * bmpDataSrc.Height;

                CopyMemory(bmpDataDest.Scan0, bmpDataSrc.Scan0, (uint)lenght);

                bmpSrc.UnlockBits(bmpDataSrc);
                bmpDest.UnlockBits(bmpDataDest);

                if (CopyPalette && bmpSrc.Palette.Entries.Length > 0)
                    bmpDest.Palette = bmpSrc.Palette;
            }
            return copyOk;
        }

        public static bool CheckCompatibility(Bitmap bmp1, Bitmap bmp2)
        {
            return ((bmp1.Width == bmp2.Width) && (bmp1.Height == bmp2.Height) && (bmp1.PixelFormat == bmp2.PixelFormat));
        }

        //Here's what I'm currently using. Some of the other techniques I've tried have been non-optimal because they changed
        //the bit depth of the pixels (24-bit vs. 32-bit) or ignored the image's resolution(dpi).

        // ImageConverter object used to convert byte arrays containing JPEG or PNG file images into 
        //  Bitmap objects. This is static and only gets instantiated once.
        static readonly ImageConverter _imageConverter = new ImageConverter();

        //Image to byte array:
        /// <summary>
        /// Method to "convert" an Image object into a byte array, formatted in PNG file format, which
        /// provides lossless compression. This can be used together with the GetImageFromByteArray()
        /// method to provide a kind of serialization / deserialization.
        /// </summary>
        /// <param name="theImage">Image object, must be convertible to PNG format</param>
        /// <returns>byte array image of a PNG file containing the image</returns>
        public static byte[] CopyImageToByteArray(Image theImage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                theImage.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

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
        //This avoids problems related to Bitmap wanting its source stream to be kept open, and some suggested workarounds to
        //that problem that result in the source file being kept locked.

    }
}

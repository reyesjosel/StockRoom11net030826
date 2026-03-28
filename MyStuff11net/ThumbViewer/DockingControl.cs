using System.ComponentModel;

namespace MyStuff11net
{
    public partial class DockingControl : UserControl
    {
        public DockingControl()
        {
            InitializeComponent();

            Dock = DockStyle.Bottom;

            Load += new EventHandler(DockingControl_Load);
            Resize += new EventHandler(DockingControl_Resize);
            //      DockChanged += new EventHandler(DockingControl_DockChanged);
            ParentChanged += new EventHandler(DockingControl_ParentChanged);
        }

        void DockingControl_ParentChanged(object sender, EventArgs e)
        {
            //          dockingHandle.ParentDockingControl = Parent;
        }
        /*
                void DockingControl_DockChanged(object sender, EventArgs e)
                {
                    // Our size before docking position is changed
                    Size size = ClientSize;

                    // Remember the current docking position
                    DockStyle dsOldResize = dockingResize.Dock;

                    // New handle size is dependant on the orientation of the new docking position
                    dockingHandle.SizeToOrientation(Dock);

                    // Modify docking position of child controls based on our new docking position
                    dockingResize.Dock = DockingControl.ResizeStyleFromControlStyle(Dock);
                    dockingHandle.Dock = DockingControl.HandleStyleFromControlStyle(Dock);

                    // Change in orientation occurred?
                    if (dsOldResize != dockingResize.Dock)
                    {
                        // Must update our client size to ensure the correct size is used when
                        // the docking position changes.  We have to transfer the value that determines
                        // the vector of the control to the opposite dimension
                        if ((Dock == DockStyle.Top) || (Dock == DockStyle.Bottom))
                            size.Height = size.Width;
                        else
                            size.Width = size.Height;

                        ClientSize = size;
                    }

                    // Repaint of the our controls 
                    dockingHandle.Invalidate();
                    dockingResize.Invalidate();
                }
        */
        void DockingControl_Resize(object sender, EventArgs e)
        {
            // Repaint of the our controls 
            //         dockingHandle.Invalidate();
            //         dockingResize.Invalidate();
        }

        void DockingControl_Load(object sender, EventArgs e)
        {
            // Repaint of the our controls 
            //         dockingHandle.Invalidate();
            //         dockingResize.Invalidate();
        }

        // Static variables defining colors for drawing
        private static Pen _testPen = new Pen(Color.FromKnownColor(KnownColor.Aquamarine));
        private static Pen _lightPen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight));
        private static Pen _darkPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark));
        private static Brush _plainBrush = Brushes.LightGray;

        // Static properties for read-only access to drawing colors
        public static Pen TestPen { get { return _testPen; } }
        public static Pen LightPen { get { return _lightPen; } }
        public static Pen DarkPen { get { return _darkPen; } }
        public static Brush PlainBrush { get { return _plainBrush; } }

        public static DockStyle ResizeStyleFromControlStyle(DockStyle ds)
        {
            switch (ds)
            {
                case DockStyle.Left:
                    return DockStyle.Right;
                case DockStyle.Top:
                    return DockStyle.Bottom;
                case DockStyle.Right:
                    return DockStyle.Left;
                case DockStyle.Bottom:
                    return DockStyle.Top;
                case DockStyle.None:
                    return DockStyle.Left;
                default:
                    // Should never happen!
                    throw new ApplicationException("Invalid DockStyle argument");
            }
        }

        public static DockStyle HandleStyleFromControlStyle(DockStyle ds)
        {
            switch (ds)
            {
                case DockStyle.Left:
                    return DockStyle.Top;
                case DockStyle.Top:
                    return DockStyle.Left;
                case DockStyle.Right:
                    return DockStyle.Top;
                case DockStyle.Bottom:
                    return DockStyle.Left;
                case DockStyle.None:
                    return DockStyle.Left;
                default:
                    // Should never happen!
                    throw new ApplicationException("Invalid DockStyle argument");
            }
        }
    }

    // A bar used to resize the parent DockingControl
    class DockingResize : UserControl
    {
        // Class constants
        private const int _fixedLength = 4;

        // Instance variables
        private Point _pointStart;
        private Point _pointLast;
        private Size _size;

        public DockingResize()
        {
            Dock = DockingControl.ResizeStyleFromControlStyle(DockStyle.Bottom);
            Size = new Size(_fixedLength, _fixedLength);
            BackColor = Color.Beige;
        }

        public DockingResize(DockStyle ds)
        {
            Dock = DockingControl.ResizeStyleFromControlStyle(ds);
            Size = new Size(_fixedLength, _fixedLength);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Remember the mouse position and client size when capture occured
            _pointStart = _pointLast = PointToScreen(new Point(e.X, e.Y));
            _size = Parent.ClientSize;

            // Ensure delegates are called
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Cursor depends on if we a vertical or horizontal resize
            if ((Dock == DockStyle.Top) || (Dock == DockStyle.Bottom))
                Cursor = Cursors.HSplit;
            else
                Cursor = Cursors.VSplit;

            // Can only resize if we have captured the mouse
            if (Capture)
            {
                // Find the new mouse position
                Point point = PointToScreen(new Point(e.X, e.Y));

                // Have we actually moved the mouse?
                if (point != _pointLast)
                {
                    // Update the last processed mouse position
                    _pointLast = point;

                    // Find delta from original position
                    int xDelta = _pointLast.X - _pointStart.X;
                    int yDelta = _pointLast.Y - _pointStart.Y;

                    // Resizing from bottom or right of form means inverse movements
                    if ((Dock == DockStyle.Top) ||
                        (Dock == DockStyle.Left))
                    {
                        xDelta = -xDelta;
                        yDelta = -yDelta;
                    }

                    // New size is original size plus delta
                    if ((Dock == DockStyle.Top) ||
                        (Dock == DockStyle.Bottom))
                        Parent.ClientSize = new Size(_size.Width, _size.Height + yDelta);
                    else
                        Parent.ClientSize = new Size(_size.Width + xDelta, _size.Height);

                    // Force a repaint of parent so we can see changed appearance
                    Parent.Refresh();
                }
            }

            // Ensure delegates are called
            base.OnMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Create objects used for drawing
            Point[] ptLight = new Point[2];
            Point[] ptDark = new Point[2];
            Rectangle rectMiddle = new Rectangle();
            Control parentControl = Parent;

            // Drawing is relative to client area
            Size sizeClient = parentControl.ClientSize;

            // Painting depends on orientation
            if ((parentControl.Dock == DockStyle.Top) || (parentControl.Dock == DockStyle.Bottom))
            {
                // Draw as a horizontal bar
                ptDark[1].Y = ptDark[0].Y = sizeClient.Height - 1;
                ptLight[1].X = ptDark[1].X = sizeClient.Width;
                rectMiddle.Width = sizeClient.Width;
                rectMiddle.Height = sizeClient.Height - 2;
                rectMiddle.X = 0;
                rectMiddle.Y = 1;
            }
            else
                if ((parentControl.Dock == DockStyle.Left) || (parentControl.Dock == DockStyle.Right))
                {
                    // Draw as a vertical bar
                    ptDark[1].X = ptDark[0].X = sizeClient.Width - 1;
                    ptLight[1].Y = ptDark[1].Y = sizeClient.Height;
                    rectMiddle.Width = sizeClient.Width - 2;
                    rectMiddle.Height = sizeClient.Height;
                    rectMiddle.X = 1;
                    rectMiddle.Y = 0;
                }

            // Use colours defined by docking control that is using us
            pe.Graphics.DrawLine(DockingControl.LightPen, ptLight[0], ptLight[1]);
            //pe.Graphics.DrawLine(DockingControl.TestPen, ptLight[0], ptLight[1]);
            pe.Graphics.DrawLine(DockingControl.DarkPen, ptDark[0], ptDark[1]);
            pe.Graphics.FillRectangle(DockingControl.PlainBrush, rectMiddle);

            // Ensure delegates are called
            base.OnPaint(pe);
        }
    }

    public class DockingHandle : UserControl
    {
        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public static event StatusBarMessage_EventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessage_EventHandler(object sender, Custom_Events_Args.StatusBarMessage_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public static void On_StatusBarMessage(Custom_Events_Args.StatusBarMessage_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (StatusBarMessage != null)
            {
                // Notify Subscribers
                StatusBarMessage(new object(), e);
            }
        }

        #endregion"StatusBarMessage"

        // Class constants
        private const int _fixedLength = 12;
        private const int _hotLength = 50;
        private const int _offset = 3;
        private const int _inset = 3;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control ParentDockingControl
        {
            get
            {
                if (_dockingControl == null)
                    return Parent;
                else
                    return _dockingControl;
            }
            set
            {
                _dockingControl = value;
                if (_dockingControl != null)
                {
                    Dock = DockingControl.HandleStyleFromControlStyle(_dockingControl.Dock);
                    //MinimumSize = new System.Drawing.Size(13, _dockingControl.Height);
                    //MaximumSize = new System.Drawing.Size(13, _dockingControl.Height);
                }
                SizeToOrientation(Dock);
            }
        }

        // Instance variables
        private Control _dockingControl;

        public DockingHandle()
        {
        }

        public DockingHandle(Control dockingControl, DockStyle ds)
        {
            _dockingControl = dockingControl;
            Dock = DockingControl.HandleStyleFromControlStyle(_dockingControl.Dock);
            SizeToOrientation(Dock);
        }

        public void SizeToOrientation(DockStyle ds)
        {
            if ((ds == DockStyle.Top) || (ds == DockStyle.Bottom))
                ClientSize = new Size(_fixedLength, 0);
            else
                ClientSize = new Size(0, _fixedLength);
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();

            // Ensure delegates are called
            base.OnResize(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Can only move the DockingControl is we have captured the
            // mouse otherwise the mouse is not currently pressed
            if (Capture)
            {
                // Must have reference to parent object
                if (null != _dockingControl)
                {
                    Cursor = Cursors.Hand;

                    // Convert from client point of DockingHandle to client of DockingControl
                    Point screenPoint = PointToScreen(new Point(e.X, e.Y));
                    Point parentPoint = _dockingControl.PointToClient(screenPoint);

                    // Find the client rectangle of the form
                    Size parentSize = _dockingControl.ClientSize;

                    // New docking position is defaulted to current style
                    DockStyle ds = _dockingControl.Dock;

                    // Find new docking position
                    if (parentPoint.X < _hotLength)
                    {
                        ds = DockStyle.Left;
                    }
                    else if (parentPoint.Y < _hotLength)
                    {
                        ds = DockStyle.Top;
                    }
                    else if (parentPoint.X >= (parentSize.Width - _hotLength))
                    {
                        ds = DockStyle.Right;
                    }
                    else if (parentPoint.Y >= (parentSize.Height - _hotLength))
                    {
                        ds = DockStyle.Bottom;
                    }

                    // Update docking position of DockingControl we are part of
                    if (_dockingControl.Dock != ds)
                        _dockingControl.Dock = ds;
                }
            }
            else
                Cursor = Cursors.Default;

            // Ensure delegates are called
            base.OnMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Size sizeClient = ClientSize;
            Point[] ptLight = new Point[4];
            Point[] ptDark = new Point[4];

            // Depends on orientation
            if ((ParentDockingControl.Dock == DockStyle.Top) || (ParentDockingControl.Dock == DockStyle.Bottom))
            {
                BackColor = Color.Blue;

                int iBottom = sizeClient.Height - _inset - 1;
                int iRight = _offset + 2;

                ptLight[3].X = ptLight[2].X = ptLight[0].X = _offset;
                ptLight[2].Y = ptLight[1].Y = ptLight[0].Y = _inset;
                ptLight[1].X = _offset + 1;
                ptLight[3].Y = iBottom;

                ptDark[2].X = ptDark[1].X = ptDark[0].X = iRight;
                ptDark[3].Y = ptDark[2].Y = ptDark[1].Y = iBottom;
                ptDark[0].Y = _inset;
                ptDark[3].X = iRight - 1;
            }
            else
            {
                BackColor = Color.Green;

                int iBottom = _offset + 2;
                int iRight = sizeClient.Width - _inset - 1;

                ptLight[3].X = ptLight[2].X = ptLight[0].X = _inset;
                ptLight[1].Y = ptLight[2].Y = ptLight[0].Y = _offset;
                ptLight[1].X = iRight;
                ptLight[3].Y = _offset + 1;

                ptDark[2].X = ptDark[1].X = ptDark[0].X = iRight;
                ptDark[3].Y = ptDark[2].Y = ptDark[1].Y = iBottom;
                ptDark[0].Y = _offset;
                ptDark[3].X = _inset;
            }

            Pen lightPen = DockingControl.LightPen;
            Pen darkPen = DockingControl.DarkPen;
            Pen testPen = DockingControl.TestPen;

            //pe.Graphics.DrawLine(lightPen, ptLight[0], ptLight[1]);
            pe.Graphics.DrawLine(testPen, ptLight[0], ptLight[1]);
            pe.Graphics.DrawLine(lightPen, ptLight[2], ptLight[3]);
            pe.Graphics.DrawLine(darkPen, ptDark[0], ptDark[1]);
            pe.Graphics.DrawLine(darkPen, ptDark[2], ptDark[3]);

            // Shift coordinates to draw section grab bar
            if ((ParentDockingControl.Dock == DockStyle.Top) || (ParentDockingControl.Dock == DockStyle.Bottom))
            {
                for (int i = 0; i < 4; i++)
                {
                    ptLight[i].X += 4;
                    ptDark[i].X += 4;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    ptLight[i].Y += 4;
                    ptDark[i].Y += 4;
                }
            }

            pe.Graphics.DrawLine(lightPen, ptLight[0], ptLight[1]);
            pe.Graphics.DrawLine(lightPen, ptLight[2], ptLight[3]);
            pe.Graphics.DrawLine(darkPen, ptDark[0], ptDark[1]);
            pe.Graphics.DrawLine(darkPen, ptDark[2], ptDark[3]);

            // Ensure delegates are called
            base.OnPaint(pe);
        }
    }

    // Position the provided control inside a border to give a portrait picture effect
    class DockingBorderControl : UserControl
    {
        // Instance variables
        private int _borderWidth = 3;
        private int _borderDoubleWidth = 6;
        private Control _userControl;

        public DockingBorderControl()
        {

        }

        public DockingBorderControl(Control userControl)
        {
            _userControl = userControl;
            Controls.Add(_userControl);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderWidth
        {
            get
            {
                return _borderWidth;
            }

            set
            {
                // Only interested if value has changed
                if (_borderWidth != value)
                {
                    _borderWidth = value;
                    _borderDoubleWidth = _borderWidth + _borderWidth;

                    // Force resize of control to get the embedded control 
                    // repositioned according to new border width
                    Size = Size;
                }
            }
        }

        // Must reposition the embedded control whenever we change size
        protected override void OnResize(EventArgs e)
        {
            // Can be called before instance constructor
            if (null != _userControl)
            {
                Size sizeClient = Size;

                // Move the user control to enforce the border area we want	
                _userControl.Location = new Point(_borderWidth, _borderWidth);

                //      _userControl.Size = new Size(sizeClient.Width - _borderDoubleWidth,
                //                                   sizeClient.Height - _borderDoubleWidth);

                Size sizeHost = new Size(Size.Width, _userControl.Size.Height + _borderDoubleWidth);
            }

            // Ensure delegates are called
            base.OnResize(e);
        }
    }
}

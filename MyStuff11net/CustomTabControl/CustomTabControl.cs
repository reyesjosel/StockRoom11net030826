using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using ResizeGrip_EventArgs = MyStuff11net.Custom_Events_Args.ResizeGrip_EventArgs;

namespace System.Windows.Forms
{
    [DisplayName(nameof(Name))]
    [Description("My Custom Control.")]
    [DesignTimeVisible(true)]
    [ToolboxItem(true)]
    [DesignerCategory(nameof(UserControl))]
    [ToolboxBitmap(typeof(TabControl))]
    [ComVisible(true)]
    [SupportedOSPlatform("windows")]
    public class CustomTabControl : TabControl
    {
        #region	Construction

        public CustomTabControl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw, true);

            _BackBuffer = new Bitmap(Width, Height);
            _BackBufferGraphics = Graphics.FromImage(_BackBuffer);
            _TabBuffer = new Bitmap(Width, Height);
            _TabBufferGraphics = Graphics.FromImage(_TabBuffer);

            DisplayStyle = TabStyle.Default;
            Alignment = TabAlignment.Bottom;

            MouseDown += CustomTabControl_MouseDown;
            MouseUp += CustomTabControl_MouseUp;

            Initialize_TabControlRunningProject();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            OnFontChanged(EventArgs.Empty);

            if (Width > 0 && Height > 0)
                ResizeGripRect = new Rectangle(Location.X, Bottom - 12, Location.X + 12, Bottom);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (RightToLeftLayout)
                    cp.ExStyle = cp.ExStyle | NativeMethods.WS_EX_LAYOUTRTL | NativeMethods.WS_EX_NOINHERITLAYOUT;
                return cp;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _BackImage?.Dispose();
                _BackBufferGraphics?.Dispose();
                _BackBuffer?.Dispose();
                _TabBufferGraphics?.Dispose();
                _TabBuffer?.Dispose();
                _StyleProvider?.Dispose();
            }
        }

        #endregion

        #region Private variables

        private Bitmap? _BackImage;
        private Bitmap _BackBuffer;
        private Graphics _BackBufferGraphics;
        private Bitmap _TabBuffer;
        private Graphics _TabBufferGraphics;

        private int _oldValue;
        private Drawing.Point _dragStartPosition = new Drawing.Point();

        private TabStyle _Style;
        private TabStyleProvider _StyleProvider;

        private List<TabPage> _TabPages;

        #endregion

        #region Public properties

        [Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabStyleProvider DisplayStyleProvider
        {
            get
            {
                if (_StyleProvider == null)
                {
                    DisplayStyle = TabStyle.Default;
                }

                return _StyleProvider;
            }
            set
            {
                _StyleProvider = value;
            }
        }

        [Category("Appearance"), DefaultValue(typeof(TabStyle), "Default"), RefreshProperties(RefreshProperties.All)]
        public TabStyle DisplayStyle
        {
            get
            {
                return _Style;
            }
            set
            {
                if (_Style != value)
                {
                    _Style = value;
                    _StyleProvider = TabStyleProvider.CreateProvider(this);
                    Invalidate();
                }
            }
        }

        [Category("Appearance"), RefreshProperties(RefreshProperties.All)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Multiline
        {
            get
            {
                return base.Multiline;
            }
            set
            {
                base.Multiline = value;
                Invalidate();
            }
        }

        //	Hide the Padding attribute so it can not be changed
        //	We are handling this on the Style Provider
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Point Padding
        {
            get
            {
                return DisplayStyleProvider.Padding;
            }
            set
            {
                DisplayStyleProvider.Padding = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool RightToLeftLayout
        {
            get
            {
                return base.RightToLeftLayout;
            }
            set
            {
                base.RightToLeftLayout = value;
                UpdateStyles();
            }
        }

        //	Hide the HotTrack attribute so it can not be changed
        //	We are handling this on the Style Provider
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool HotTrack
        {
            get
            {
                return DisplayStyleProvider.HotTrack;
            }
            set
            {
                DisplayStyleProvider.HotTrack = value;
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TabAlignment Alignment
        {
            get
            {
                return base.Alignment;
            }
            set
            {
                base.Alignment = value;
                switch (value)
                {
                    case TabAlignment.Top:
                    case TabAlignment.Bottom:
                        Multiline = false;
                        break;
                    case TabAlignment.Left:
                    case TabAlignment.Right:
                        Multiline = true;
                        break;
                }

            }
        }

        //	Hide the Appearance attribute so it can not be changed
        //	We don't want it as we are doing all the painting.
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new TabAppearance Appearance
        {
            get
            {
                return base.Appearance;
            }
            set
            {
                //	Don't permit setting to other appearances as we are doing all the painting
                base.Appearance = TabAppearance.Normal;
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                //	Special processing to hide tabs
                if (_Style == TabStyle.None)
                {
                    return new Rectangle(0, 0, Width, Height);
                }
                else
                {
                    int itemHeight;
                    if (Alignment <= TabAlignment.Bottom)
                    {
                        itemHeight = ItemSize.Height;
                    }
                    else
                    {
                        itemHeight = ItemSize.Width;
                    }

                    int tabStripHeight = 5 + (itemHeight * RowCount);

                    Rectangle rect = new Rectangle(4, tabStripHeight, Width - 8, Height - tabStripHeight - 4);
                    switch (Alignment)
                    {
                        case TabAlignment.Top:
                            rect = new Rectangle(4, tabStripHeight, Width - 8, Height - tabStripHeight - 4);
                            break;
                        case TabAlignment.Bottom:
                            rect = new Rectangle(4, 4, Width - 8, Height - tabStripHeight - 4);
                            break;
                        case TabAlignment.Left:
                            rect = new Rectangle(tabStripHeight, 4, Width - tabStripHeight - 4, Height - 8);
                            break;
                        case TabAlignment.Right:
                            rect = new Rectangle(4, 4, Width - tabStripHeight - 4, Height - 8);
                            break;
                    }
                    return rect;
                }
            }
        }

        [Browsable(false)]
        public int ActiveIndex
        {
            get
            {
                Drawing.Point _point = PointToClient(Control.MousePosition);
                NativeMethods.TCHITTESTINFO hitTestInfo = new NativeMethods.TCHITTESTINFO(new Point(_point.X, _point.Y));
                int index = NativeMethods.SendMessage(Handle, NativeMethods.TCM_HITTEST, IntPtr.Zero, NativeMethods.ToIntPtr(hitTestInfo)).ToInt32();
                if (index == -1)
                {
                    return -1;
                }
                else
                {
                    if (TabPages[index].Enabled)
                    {
                        return index;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        [Browsable(false)]
        public TabPage ActiveTab
        {
            get
            {
                int activeIndex = ActiveIndex;
                if (activeIndex > -1)
                {
                    return TabPages[activeIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region	Extension methods

        public void HideAll()
        {
            foreach (TabPage page in TabPages)
            {
                if (page.Tag == null)
                    continue;

                HideTab(page);
            }
        }

        public void HideTab(object tag)
        {
            foreach (TabPage page in TabPages)
            {
                if (page.Tag.ToString().Contains(tag.ToString()))
                    HideTab(page);
            }
        }

        public void HideTab(TabPage page)
        {
            if (page != null && TabPages.Contains(page))
            {
                BackupTabPages();
                TabPages.Remove(page);
            }
        }

        public void HideTab(int index)
        {
            if (IsValidTabIndex(index))
            {
                HideTab(_TabPages[index]);
            }
        }

        public void HideTab(string key)
        {
            if (TabPages.ContainsKey(key))
            {
                HideTab(TabPages[key]);
            }
        }

        public void ShowAll()
        {
            foreach (TabPage page in _TabPages)
            {
                ShowTab(page);
            }
        }

        public void ShowTab(object tag)
        {
            foreach (TabPage page in _TabPages)
            {
                if (page.Tag.ToString().Contains(tag.ToString()))
                {
                    ShowTab(page);
                    SelectTab(page);
                }
            }
        }

        public void ShowTab(TabPage? page)
        {
            if (page != null)
            {
                if (_TabPages != null)
                {
                    if (!TabPages.Contains(page)
                        && _TabPages.Contains(page))
                    {
                        //	Get insert point from backup of pages
                        int pageIndex = _TabPages.IndexOf(page);
                        if (pageIndex > 0)
                        {
                            int start = pageIndex - 1;

                            //	Check for presence of earlier pages in the visible tabs
                            for (int index = start; index >= 0; index--)
                            {
                                if (TabPages.Contains(_TabPages[index]))
                                {
                                    //	Set insert point to the right of the last present tab
                                    pageIndex = TabPages.IndexOf(_TabPages[index]) + 1;
                                    break;
                                }
                            }
                        }

                        //	Insert the page, or add to the end
                        if ((pageIndex >= 0) && (pageIndex < TabPages.Count))
                        {
                            TabPages.Insert(pageIndex, page);
                        }
                        else
                        {
                            TabPages.Add(page);
                        }
                    }
                }
                else
                {
                    //	If the page is not found at all then just add it
                    if (!TabPages.Contains(page))
                    {
                        TabPages.Add(page);
                    }
                }
            }
        }

        public void ShowTab(int index)
        {
            if (IsValidTabIndex(index))
            {
                ShowTab(_TabPages[index]);
            }
        }

        public void ShowTab(string key)
        {
            if (_TabPages != null)
            {
                TabPage? tab = _TabPages.Find(delegate (TabPage page) { return page.Name.Equals(key, StringComparison.OrdinalIgnoreCase); });
                ShowTab(tab);
            }
        }

        public TabPage SelectTabPage(string tabPageText)
        {
            foreach (TabPage page in TabPages)
            {
                if (page.Text == tabPageText)
                {
                    SelectTab(page);
                    return page;
                }
            }

            return new TabPage();
        }

        private bool IsValidTabIndex(int index)
        {
            BackupTabPages();
            return ((index >= 0) && (index < _TabPages.Count));
        }

        private void BackupTabPages()
        {
            if (_TabPages == null)
            {
                _TabPages = new List<TabPage>();
                foreach (TabPage page in TabPages)
                {
                    _TabPages.Add(page);
                }
            }
        }

        public bool ContainTabPage(string tabPageText)
        {
            foreach (TabPage page in TabPages)
            {
                if (page.Text == tabPageText)
                    return true;
            }

            return false;
        }

        public TabPage GetTabPage(string tabPageText)
        {
            foreach (TabPage page in TabPages)
            {
                if (page.Text == tabPageText)
                    return page;
            }

            return new TabPage();
        }

        public bool DeletedTabPage(string tabPageText)
        {
            TabPage? toDeleted = null;

            foreach (TabPage page in TabPages)
            {
                if (page.Text == tabPageText)
                {
                    toDeleted = page;
                    break;
                }
            }

            if (toDeleted != null)
            {
                TabPages.Remove(toDeleted);
                return true;
            }

            return false;
        }

        #endregion

        #region Drag 'n' Drop
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (AllowDrop)
            {
                _dragStartPosition = new Drawing.Point(e.X, e.Y);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (AllowDrop)
            {
                _dragStartPosition = new Drawing.Point();
            }
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);

            if (drgevent.Data.GetDataPresent(typeof(TabPage)))
            {
                drgevent.Effect = DragDropEffects.Move;
            }
            else
            {
                drgevent.Effect = DragDropEffects.None;
            }
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            if (drgevent.Data.GetDataPresent(typeof(TabPage)))
            {
                drgevent.Effect = DragDropEffects.Move;

                TabPage dragTab = (TabPage)drgevent.Data.GetData(typeof(TabPage));

                if (ActiveTab == dragTab)
                {
                    return;
                }

                //	Capture insert point and adjust for removal of tab
                //	We cannot assess this after removal as differing tab sizes will cause
                //	inaccuracies in the activeTab at insert point.
                int insertPoint = ActiveIndex;
                if (dragTab.Parent.Equals(this) && TabPages.IndexOf(dragTab) < insertPoint)
                {
                    insertPoint--;
                }
                if (insertPoint < 0)
                {
                    insertPoint = 0;
                }

                //	Remove from current position (could be another tabcontrol)
                ((TabControl)dragTab.Parent).TabPages.Remove(dragTab);

                //	Add to current position
                TabPages.Insert(insertPoint, dragTab);
                SelectedTab = dragTab;

                //	deal with hidden tab handling?
            }
        }

        private void StartDragDrop()
        {
            if (!_dragStartPosition.IsEmpty)
            {
                TabPage? dragTab = SelectedTab;
                if (dragTab != null)
                {
                    //	Test for movement greater than the drag activation trigger area
                    Rectangle dragTestRect = new Rectangle(_dragStartPosition, Drawing.Size.Empty);
                    dragTestRect.Inflate(SystemInformation.DragSize);
                    Drawing.Point pt = PointToClient(Control.MousePosition);
                    if (!dragTestRect.Contains(pt))
                    {
                        DoDragDrop(dragTab, DragDropEffects.All);
                        _dragStartPosition = new Drawing.Point();
                    }
                }
            }
        }

        #endregion

        #region Events

        [Category("Action")]
        public event ScrollEventHandler HScroll;

        [Category("Action")]
        public event EventHandler<TabControlEventArgs> TabImageClick;

        [Category("Action")]
        public event EventHandler<TabControlCancelEventArgs> TabClosing;

        #region"MouseDownResizeGripEvent"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void MouseDownResizeGripEventHandler(object sender, MouseEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Mouse down over ResizeGrip")]
        public event MouseDownResizeGripEventHandler MouseDownResizeGripEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_MouseDownResizeGrip_Event(MouseEventArgs e)
        {
            MouseDownResizeGripEvent?.Invoke(this, e);
        }

        #endregion"MouseDownResizeGripEvent"

        #region"MouseUpResizeGripEvent"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void MouseUpResizeGripEventHandler(object sender, MouseEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Mouse down over ResizeGrip")]
        public event MouseDownResizeGripEventHandler MouseUpResizeGripEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_MouseUpResizeGrip_Event(MouseEventArgs e)
        {
            MouseUpResizeGripEvent?.Invoke(this, e);
        }

        #endregion"MouseUpResizeGripEvent"

        #region"ResizeGripEvent"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ResizeGripEventHandler(object sender, ResizeGrip_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellDoubleClick has changed")]
        public event ResizeGripEventHandler ResizeGripEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_ResizeGrip_Event(ResizeGrip_EventArgs e)
        {
            ResizeGripEvent?.Invoke(this, e);
        }

        #endregion"ResizeGripEvent"

        #endregion

        #region	Base class event processing
        protected override void OnFontChanged(EventArgs e)
        {
            IntPtr hFont = Font.ToHfont();
            NativeMethods.SendMessage(Handle, NativeMethods.WM_SETFONT, hFont, (IntPtr)(-1));
            NativeMethods.SendMessage(Handle, NativeMethods.WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
            UpdateStyles();
            if (Visible)
            {
                Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            if (isResize == false)
            {
                mouseX = 0;
                mouseY = 0;
            }

            ResizeGripRect = new Rectangle(Location.X, Bottom - 12, Location.X + 12, Bottom);
            //	Recreate the buffer for manual double buffering
            if (Width > 0 && Height > 0)
            {
                if (_BackImage != null)
                {
                    _BackImage.Dispose();
                    _BackImage = null;
                }
                _BackBufferGraphics?.Dispose();
                _BackBuffer?.Dispose();

                _BackBuffer = new Bitmap(Width, Height);
                _BackBufferGraphics = Graphics.FromImage(_BackBuffer);

                _TabBufferGraphics?.Dispose();
                _TabBuffer?.Dispose();

                _TabBuffer = new Bitmap(Width, Height);
                _TabBufferGraphics = Graphics.FromImage(_TabBuffer);

                if (_BackImage != null)
                {
                    _BackImage.Dispose();
                    _BackImage = null;
                }

            }
            base.OnResize(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            if (_BackImage != null)
            {
                _BackImage.Dispose();
                _BackImage = null;
            }
            base.OnParentBackColorChanged(e);
        }

        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            if (_BackImage != null)
            {
                _BackImage.Dispose();
                _BackImage = null;
            }
            base.OnParentBackgroundImageChanged(e);
        }

        private void OnParentResize(object? sender, EventArgs e)
        {
            if (isResize == false)
            {
                mouseX = 0;
                mouseY = 0;
            }

            ResizeGripRect = new Rectangle(Location.X, Bottom - 12, Location.X + 12, Bottom);

            if (Visible)
            {
                Invalidate();
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent != null)
            {
                Parent.Resize += OnParentResize;
            }
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);

            //	Do not allow selecting of disabled tabs
            if (e.Action == TabControlAction.Selecting && e.TabPage != null && !e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }

        protected override void OnMove(EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                ResizeGripRect = new Rectangle(Location.X, Bottom - 12, Location.X + 12, Bottom);

                if (_BackImage != null)
                {
                    _BackImage.Dispose();
                    _BackImage = null;
                }
            }
            base.OnMove(e);
            Invalidate();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (Visible)
            {
                Invalidate();
            }
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
            if (Visible)
            {
                Invalidate();
            }
        }

        protected override bool ProcessMnemonic(char charCode)
        {
            foreach (TabPage page in TabPages)
            {
                if (IsMnemonic(charCode, page.Text))
                {
                    SelectedTab = page;
                    return true;
                }
            }
            return base.ProcessMnemonic(charCode);
        }

        //protected override void OnSelectedIndexChanged(EventArgs e)
        //{
        //    if (Handle == null)
        //        return;

        //	base.OnSelectedIndexChanged(e);
        //}

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_HSCROLL:

                    //	Raise the scroll event when the scroller is scrolled
                    base.WndProc(ref m);
                    OnHScroll(new ScrollEventArgs(((ScrollEventType)NativeMethods.LoWord(m.WParam)), _oldValue, NativeMethods.HiWord(m.WParam), ScrollOrientation.HorizontalScroll));
                    break;
                //				case NativeMethods.WM_PAINT:
                //					
                //					//	Handle painting ourselves rather than call the base OnPaint.
                //					CustomPaint(ref m);
                //					break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        void CustomTabControl_MouseDown(object? sender, MouseEventArgs e)
        {
            if (ResizeGripRect.Contains(e.Location))
            {
                if (e.Button == MouseButtons.Left)
                    isResize = true;

                mouseX = e.X;
                mouseY = e.Y;
                Capture = true;
                On_MouseDownResizeGrip_Event(e);
            }
        }

        void CustomTabControl_MouseUp(object? sender, MouseEventArgs e)
        {
            if (isResize)
            {
                isResize = false;
                Capture = false;
                Cursor = Cursors.Default;

                On_MouseUpResizeGrip_Event(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // base.OnMouseMove(e);

            if (ResizeGripRect.Contains(e.Location) || isResize)
            {
                Cursor = Cursors.SizeAll;

                if (isResize)
                {
                    int deltaX = e.X - mouseX;
                    int deltaY = e.Y - mouseY;

                    On_ResizeGrip_Event(new ResizeGrip_EventArgs(deltaX, deltaY));

                    mouseX = e.X;
                    mouseY = e.Y;
                }
                return;
            }
            else
                Cursor = Cursors.Default;

            if (_StyleProvider.ShowTabCloser)
            {
                var tabRect = _StyleProvider.GetTabRect(ActiveIndex);
                if (tabRect.Contains(MousePosition))
                {
                    Invalidate();
                }
            }

            //	Initialize Drag Drop
            if (AllowDrop && e.Button == MouseButtons.Left)
            {
                StartDragDrop();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            int index = ActiveIndex;

            //	If we are clicking on an image then raise the ImageClicked event before raising the standard mouse click event
            //	if there if a handler.
            if (index > -1 && TabImageClick != null
                && (TabPages[index].ImageIndex > -1 || !string.IsNullOrEmpty(TabPages[index].ImageKey))
                && GetTabImageRect(index).Contains(MousePosition))
            {
                OnTabImageClick(new TabControlEventArgs(TabPages[index], index, TabControlAction.Selected));

                //	Fire the base event
                base.OnMouseClick(e);

            }
            else
                if (!DesignMode && index > -1 && _StyleProvider.ShowTabCloser && GetTabCloserRect(index).Contains(MousePosition))
                {

                    //	If we are clicking on a closer then remove the tab instead of raising the standard mouse click event
                    //	But raise the tab closing event first
                    TabPage tab = ActiveTab;
                    TabControlCancelEventArgs args = new TabControlCancelEventArgs(tab, index, false, TabControlAction.Deselecting);
                    OnTabClosing(args);

                    if (!args.Cancel)
                    {
                        TabPages.Remove(tab);
                        tab.Dispose();
                    }
                }
                else
                {
                    //	Fire the base event
                    base.OnMouseClick(e);
                }
        }

        protected virtual void OnTabImageClick(TabControlEventArgs e)
        {
            TabImageClick?.Invoke(this, e);
        }

        protected virtual void OnTabClosing(TabControlCancelEventArgs e)
        {
            TabClosing?.Invoke(this, e);
        }

        protected virtual void OnHScroll(ScrollEventArgs e)
        {
            //	repaint the moved tabs
            Invalidate();

            //	Raise the event
            HScroll?.Invoke(this, e);

            if (e.Type == ScrollEventType.EndScroll)
            {
                _oldValue = e.NewValue;
            }
        }

        bool isResize;
        int mouseX;
        int mouseY;
        Rectangle ResizeGripRect;
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        #endregion

        #region	Basic drawing methods

        //		private void CustomPaint(ref Message m)
        //      {
        //			NativeMethods.PAINTSTRUCT paintStruct = new NativeMethods.PAINTSTRUCT();
        //			NativeMethods.BeginPaint(m.HWnd, ref paintStruct);
        //			using (Graphics screenGraphics = CreateGraphics())
        //          {
        //				CustomPaint(screenGraphics);
        //			}
        //			NativeMethods.EndPaint(m.HWnd, ref paintStruct);
        //		}

        protected override void OnPaint(PaintEventArgs e)
        {
            CustomPaint(e.Graphics);
        }// Modified on Thursday, March 31, 2011 1:54 pm. by reyes on Thursday, October 27, 2011 6:05 pm.

        private void CustomPaint(Graphics screenGraphics)
        {
            //	We render into a bitmap that is then drawn in one shot rather than using
            //	double buffering built into the control as the built in buffering
            // 	messes up the background painting.
            //	Equally the .Net 2.0 BufferedGraphics object causes the background painting
            //	to mess up, which is why we use this .Net 1.1 buffering technique.

            //	Buffer code from Gil. Schmidt http://www.codeproject.com/KB/graphics/DoubleBuffering.aspx

            if (Width > 0 && Height > 0)
            {
                if (_BackImage == null)
                {
                    //	Cached Background Image
                    _BackImage = new Bitmap(Width, Height);
                    Graphics backGraphics = Graphics.FromImage(_BackImage);
                    backGraphics.Clear(Color.Transparent);
                    PaintTransparentBackground(backGraphics, ClientRectangle);
                    PaintReSizeGrip(backGraphics, ClientRectangle);
                }

                _BackBufferGraphics.Clear(Color.Transparent);
                _BackBufferGraphics.DrawImageUnscaled(_BackImage, 0, 0);

                _TabBufferGraphics.Clear(Color.Transparent);

                if (TabCount > 0)
                {
                    //	When top or bottom and scrollable we need to clip the sides from painting the tabs.
                    //	Left and right are always multiline.
                    if (Alignment <= TabAlignment.Bottom && !Multiline)
                        _TabBufferGraphics.Clip = new Region(new RectangleF(ClientRectangle.X + 3, ClientRectangle.Y, ClientRectangle.Width - 6, ClientRectangle.Height));

                    //	Draw each tabPage from right to left.We do it this way to handle
                    //	the overlap correctly.
                    if (Multiline)
                        for (int row = 0; row < RowCount; row++)
                        {
                            for (int index = TabCount - 1; index >= 0; index--)
                            {
                                if (index != SelectedIndex && (RowCount == 1 || GetTabRow(index) == row))
                                    DrawTabPage(index, _TabBufferGraphics);
                            }
                        }
                    else
                        for (int index = TabCount - 1; index >= 0; index--)
                        {
                            if (index != SelectedIndex)
                                DrawTabPage(index, _TabBufferGraphics);
                        }
                    //	The selected tab must be drawn last so it appears on top.
                    if (SelectedIndex > -1)
                        DrawTabPage(SelectedIndex, _TabBufferGraphics);
                }

                _TabBufferGraphics.Flush();

                //	Paint the tabs on top of the background

                // Create a new color matrix and set the alpha value to 0.5
                ColorMatrix alphaMatrix = new ColorMatrix();
                alphaMatrix.Matrix00 = alphaMatrix.Matrix11 = alphaMatrix.Matrix22 = alphaMatrix.Matrix44 = 1;
                alphaMatrix.Matrix33 = _StyleProvider.Opacity;

                // Create a new image attribute object and set the color matrix to
                // the one just created
                using (ImageAttributes alphaAttributes = new ImageAttributes())
                {
                    alphaAttributes.SetColorMatrix(alphaMatrix);

                    // Draw the original image with the image attributes specified
                    _BackBufferGraphics.DrawImage(_TabBuffer,
                                                       new Rectangle(0, 0, _TabBuffer.Width, _TabBuffer.Height),
                                                       0, 0, _TabBuffer.Width, _TabBuffer.Height, GraphicsUnit.Pixel,
                                                       alphaAttributes);
                }

                _BackBufferGraphics.Flush();

                //	Now paint this to the screen
                //	We want to paint the whole tabStrip and border every time
                //	so that the hot areas update correctly, along with any overlaps

                //	paint the tabs etc.
                if (RightToLeftLayout)
                    screenGraphics.DrawImageUnscaled(_BackBuffer, -1, 0);
                else
                    screenGraphics.DrawImageUnscaled(_BackBuffer, 0, 0);
            }
        }

        protected void PaintTransparentBackground(Graphics graphics, Rectangle clipRect)
        {
            if (Parent != null)
            {
                //	Set the clipRect to be relative to the parent
                clipRect.Offset(Location);

                //	Save the current state before we do anything.
                GraphicsState state = graphics.Save();

                //	Set the graphicsObject to be relative to the parent
                graphics.TranslateTransform((float)-Location.X, (float)-Location.Y);
                graphics.SmoothingMode = SmoothingMode.HighSpeed;

                //	Paint the parent
                PaintEventArgs e = new PaintEventArgs(graphics, clipRect);
                try
                {
                    InvokePaintBackground(Parent, e);
                    InvokePaint(Parent, e);
                }
                finally
                {
                    //	Restore the graphics state and the clipRect to their original locations
                    graphics.Restore(state);
                    clipRect.Offset(-Location.X, -Location.Y);
                }
            }
        }

        protected void PaintReSizeGrip(Graphics graphics, Rectangle clipRect)
        {
            if ((Parent != null))
            {
                graphics.DrawLine(Pens.Black, clipRect.Left + 3, clipRect.Bottom - 6, clipRect.Left + 6, clipRect.Bottom - 3);
                graphics.DrawLine(Pens.Black, clipRect.Left + 3, clipRect.Bottom - 9, clipRect.Left + 9, clipRect.Bottom - 3);
                graphics.DrawLine(Pens.Black, clipRect.Left + 3, clipRect.Bottom - 12, clipRect.Left + 12, clipRect.Bottom - 3);
            }
        }

        private void DrawTabPage(int index, Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighSpeed;

            //	Get TabPageBorder
            using (GraphicsPath tabPageBorderPath = GetTabPageBorder(index))
            {
                //	Paint the background
                using (Brush fillBrush = _StyleProvider.GetPageBackgroundBrush(index))
                {
                    graphics.FillPath(fillBrush, tabPageBorderPath);
                }

                if (_Style != TabStyle.None)
                {
                    //	Paint the tab
                    _StyleProvider.PaintTab(index, graphics);
                    //	Draw any image
                    DrawTabImage(index, graphics);
                    //	Draw the text
                    DrawTabText(index, graphics);
                }

                //	Paint the border
                DrawTabBorder(tabPageBorderPath, index, graphics);
            }
        }

        private void DrawTabBorder(GraphicsPath path, int index, Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            Color borderColor;

            if (index == SelectedIndex)
                borderColor = _StyleProvider.BorderColorSelected;
            else
                if (_StyleProvider.HotTrack && index == ActiveIndex)
                    borderColor = _StyleProvider.BorderColorHot;
                else
                    borderColor = _StyleProvider.BorderColor;

            using (Pen borderPen = new Pen(borderColor))
            {
                graphics.DrawPath(borderPen, path);
            }
        }

        private void DrawTabText(int index, Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle tabBounds = GetTabTextRect(index);

            if (SelectedIndex == index)
            {
                using (Brush textBrush = new SolidBrush(_StyleProvider.TextColorSelected))
                {
                    graphics.DrawString(TabPages[index].Text, Font, textBrush, tabBounds, GetStringFormat());
                }
            }
            else
            {
                if (TabPages[index].Enabled)
                {
                    using (Brush textBrush = new SolidBrush(_StyleProvider.TextColor))
                    {
                        graphics.DrawString(TabPages[index].Text, Font, textBrush, tabBounds, GetStringFormat());
                    }
                }
                else
                {
                    using (Brush textBrush = new SolidBrush(_StyleProvider.TextColorDisabled))
                    {
                        graphics.DrawString(TabPages[index].Text, Font, textBrush, tabBounds, GetStringFormat());
                    }
                }
            }
        }

        private void DrawTabImage(int index, Graphics graphics)
        {
            Image? tabImage = null;

            if (TabPages[index].ImageIndex > -1 && ImageList != null && ImageList.Images.Count > TabPages[index].ImageIndex)
                tabImage = ImageList.Images[TabPages[index].ImageIndex];
            else
                if ((!string.IsNullOrEmpty(TabPages[index].ImageKey) && !TabPages[index].ImageKey.Equals("(none)", StringComparison.OrdinalIgnoreCase))
                       && ImageList != null && ImageList.Images.ContainsKey(TabPages[index].ImageKey))
                    tabImage = ImageList.Images[TabPages[index].ImageKey];

            if (tabImage == null)
                return;

            if (RightToLeftLayout)
                tabImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Rectangle imageRect = GetTabImageRect(index);

            if (TabPages[index].Enabled)
                graphics.DrawImage(tabImage, imageRect);
            else
                ControlPaint.DrawImageDisabled(graphics, tabImage, imageRect.X, imageRect.Y, Color.Transparent);
        }

        #endregion

        #region String formatting
        private StringFormat GetStringFormat()
        {
            StringFormat format = new();

            //	Rotate Text by 90 degrees for left and right tabs
            switch (Alignment)
            {
                case TabAlignment.Top:
                case TabAlignment.Bottom:
                    break;
                case TabAlignment.Left:
                case TabAlignment.Right:
                    format = new StringFormat(StringFormatFlags.DirectionVertical);
                    break;
            }
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            if (FindForm() != null && FindForm().KeyPreview)
            {
                format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
            }
            else
            {
                format.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide;
            }
            if (RightToLeft == RightToLeft.Yes)
            {
                format.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
            }
            return format;
        }

        #endregion

        #region Tab borders and bounds properties
        private GraphicsPath GetTabPageBorder(int index)
        {
            GraphicsPath path = new GraphicsPath();
            Rectangle pageBounds = GetPageBounds(index);
            Rectangle tabBounds = _StyleProvider.GetTabRect(index);
            _StyleProvider.AddTabBorder(path, tabBounds);
            AddPageBorder(path, pageBounds, tabBounds);

            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Return TabPages[index].Bounds, this is a retangle where the tabpage will be draw.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Rectangle GetPageBounds(int index)
        {
            Rectangle pageBounds = TabPages[index].Bounds;
            pageBounds.Width += 1;
            pageBounds.Height += 1;
            pageBounds.X -= 1;
            pageBounds.Y -= 1;

            if (pageBounds.Bottom > Height - 4)
            {
                pageBounds.Height -= (pageBounds.Bottom - Height + 4);
            }
            return pageBounds;
        }

        private Rectangle GetTabTextRect(int index)
        {
            Rectangle textRect = new Rectangle();
            using (GraphicsPath path = _StyleProvider.GetTabBorder(index))
            {
                RectangleF tabBounds = path.GetBounds();

                textRect = new Rectangle((int)tabBounds.X, (int)tabBounds.Y, (int)tabBounds.Width, (int)tabBounds.Height);

                //	Make it shorter or thinner to fit the height or width because of the padding added to the tab for painting
                switch (Alignment)
                {
                    case TabAlignment.Top:
                        textRect.Y += 4;
                        textRect.Height -= 6;
                        break;
                    case TabAlignment.Bottom:
                        textRect.Y += 2;
                        textRect.Height -= 6;
                        break;
                    case TabAlignment.Left:
                        textRect.X += 4;
                        textRect.Width -= 6;
                        break;
                    case TabAlignment.Right:
                        textRect.X += 2;
                        textRect.Width -= 6;
                        break;
                }

                //	If there is an image allow for it
                if (ImageList != null && (TabPages[index].ImageIndex > -1
                                               || (!string.IsNullOrEmpty(TabPages[index].ImageKey)
                                                   && !TabPages[index].ImageKey.Equals("(none)", StringComparison.OrdinalIgnoreCase))))
                {
                    Rectangle imageRect = GetTabImageRect(index);
                    if ((_StyleProvider.ImageAlign & NativeMethods.AnyLeftAlign) != ((ContentAlignment)0))
                    {
                        if (Alignment <= TabAlignment.Bottom)
                        {
                            textRect.X = imageRect.Right + 4;
                            textRect.Width -= (textRect.Right - (int)tabBounds.Right);
                        }
                        else
                        {
                            textRect.Y = imageRect.Y + 4;
                            textRect.Height -= (textRect.Bottom - (int)tabBounds.Bottom);
                        }
                        //	If there is a closer allow for it
                        if (_StyleProvider.ShowTabCloser)
                        {
                            Rectangle closerRect = GetTabCloserRect(index);
                            if (Alignment <= TabAlignment.Bottom)
                            {
                                if (RightToLeftLayout)
                                {
                                    textRect.Width -= (closerRect.Right + 4 - textRect.X);
                                    textRect.X = closerRect.Right + 4;
                                }
                                else
                                {
                                    textRect.Width -= ((int)tabBounds.Right - closerRect.X + 4);
                                }
                            }
                            else
                            {
                                if (RightToLeftLayout)
                                {
                                    textRect.Height -= (closerRect.Bottom + 4 - textRect.Y);
                                    textRect.Y = closerRect.Bottom + 4;
                                }
                                else
                                {
                                    textRect.Height -= ((int)tabBounds.Bottom - closerRect.Y + 4);
                                }
                            }
                        }
                    }
                    else if ((_StyleProvider.ImageAlign & NativeMethods.AnyCenterAlign) != ((ContentAlignment)0))
                    {
                        //	If there is a closer allow for it
                        if (_StyleProvider.ShowTabCloser)
                        {
                            Rectangle closerRect = GetTabCloserRect(index);
                            if (Alignment <= TabAlignment.Bottom)
                            {
                                if (RightToLeftLayout)
                                {
                                    textRect.Width -= (closerRect.Right + 4 - textRect.X);
                                    textRect.X = closerRect.Right + 4;
                                }
                                else
                                {
                                    textRect.Width -= ((int)tabBounds.Right - closerRect.X + 4);
                                }
                            }
                            else
                            {
                                if (RightToLeftLayout)
                                {
                                    textRect.Height -= (closerRect.Bottom + 4 - textRect.Y);
                                    textRect.Y = closerRect.Bottom + 4;
                                }
                                else
                                {
                                    textRect.Height -= ((int)tabBounds.Bottom - closerRect.Y + 4);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Alignment <= TabAlignment.Bottom)
                        {
                            textRect.Width -= ((int)tabBounds.Right - imageRect.X + 4);
                        }
                        else
                        {
                            textRect.Height -= ((int)tabBounds.Bottom - imageRect.Y + 4);
                        }
                        //	If there is a closer allow for it
                        if (_StyleProvider.ShowTabCloser)
                        {
                            Rectangle closerRect = GetTabCloserRect(index);
                            if (Alignment <= TabAlignment.Bottom)
                            {
                                if (RightToLeftLayout)
                                {
                                    textRect.Width -= (closerRect.Right + 4 - textRect.X);
                                    textRect.X = closerRect.Right + 4;
                                }
                                else
                                {
                                    textRect.Width -= ((int)tabBounds.Right - closerRect.X + 4);
                                }
                            }
                            else
                            {
                                if (RightToLeftLayout)
                                {
                                    textRect.Height -= (closerRect.Bottom + 4 - textRect.Y);
                                    textRect.Y = closerRect.Bottom + 4;
                                }
                                else
                                {
                                    textRect.Height -= ((int)tabBounds.Bottom - closerRect.Y + 4);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //	If there is a closer allow for it
                    if (_StyleProvider.ShowTabCloser)
                    {
                        Rectangle closerRect = GetTabCloserRect(index);
                        if (Alignment <= TabAlignment.Bottom)
                        {
                            if (RightToLeftLayout)
                            {
                                textRect.Width -= (closerRect.Right + 4 - textRect.X);
                                textRect.X = closerRect.Right + 4;
                            }
                            else
                            {
                                textRect.Width -= ((int)tabBounds.Right - closerRect.X + 4);
                            }
                        }
                        else
                        {
                            if (RightToLeftLayout)
                            {
                                textRect.Height -= (closerRect.Bottom + 4 - textRect.Y);
                                textRect.Y = closerRect.Bottom + 4;
                            }
                            else
                            {
                                textRect.Height -= ((int)tabBounds.Bottom - closerRect.Y + 4);
                            }
                        }
                    }
                }


                //	Ensure it fits inside the path at the centre line
                if (Alignment <= TabAlignment.Bottom)
                {
                    while (!path.IsVisible(textRect.Right, textRect.Y) && textRect.Width > 0)
                    {
                        textRect.Width -= 1;
                    }
                    while (!path.IsVisible(textRect.X, textRect.Y) && textRect.Width > 0)
                    {
                        textRect.X += 1;
                        textRect.Width -= 1;
                    }
                }
                else
                {
                    while (!path.IsVisible(textRect.X, textRect.Bottom) && textRect.Height > 0)
                    {
                        textRect.Height -= 1;
                    }
                    while (!path.IsVisible(textRect.X, textRect.Y) && textRect.Height > 0)
                    {
                        textRect.Y += 1;
                        textRect.Height -= 1;
                    }
                }
            }
            return textRect;
        }

        public int GetTabRow(int index)
        {
            //	All calculations will use this rect as the base point
            //	because the itemSize does not return the correct width.
            Rectangle rect = GetTabRect(index);

            int row = -1;

            switch (Alignment)
            {
                case TabAlignment.Top:
                    row = (rect.Y - 2) / rect.Height;
                    break;
                case TabAlignment.Bottom:
                    row = ((Height - rect.Y - 2) / rect.Height) - 1;
                    break;
                case TabAlignment.Left:
                    row = (rect.X - 2) / rect.Width;
                    break;
                case TabAlignment.Right:
                    row = ((Width - rect.X - 2) / rect.Width) - 1;
                    break;
            }
            return row;
        }

        public Point GetTabPosition(int index)
        {
            //	If we are not multiline then the column is the index and the row is 0.
            if (!Multiline)
            {
                return new Point(0, index);
            }

            //	If there is only one row then the column is the index
            if (RowCount == 1)
            {
                return new Point(0, index);
            }

            //	We are in a true multi-row scenario
            int row = GetTabRow(index);
            Rectangle rect = GetTabRect(index);
            int column = -1;

            //	Scan from left to right along rows, skipping to next row if it is not the one we want.
            for (int testIndex = 0; testIndex < TabCount; testIndex++)
            {
                Rectangle testRect = GetTabRect(testIndex);
                if (Alignment <= TabAlignment.Bottom)
                {
                    if (testRect.Y == rect.Y)
                    {
                        column += 1;
                    }
                }
                else
                {
                    if (testRect.X == rect.X)
                    {
                        column += 1;
                    }
                }

                if (testRect.Location.Equals(rect.Location))
                {
                    return new Point(row, column);
                }
            }

            return new Point(0, 0);
        }

        public bool IsFirstTabInRow(int index)
        {
            if (index < 0)
            {
                return false;
            }
            bool firstTabInRow = (index == 0);
            if (!firstTabInRow)
            {
                if (Alignment <= TabAlignment.Bottom)
                {
                    if (GetTabRect(index).X == 2)
                    {
                        firstTabInRow = true;
                    }
                }
                else
                {
                    if (GetTabRect(index).Y == 2)
                    {
                        firstTabInRow = true;
                    }
                }
            }
            return firstTabInRow;
        }

        private void AddPageBorder(GraphicsPath path, Rectangle pageBounds, Rectangle tabBounds)
        {
            switch (Alignment)
            {
                case TabAlignment.Top:
                    path.AddLine(tabBounds.Right, pageBounds.Y, pageBounds.Right, pageBounds.Y);
                    path.AddLine(pageBounds.Right, pageBounds.Y, pageBounds.Right, pageBounds.Bottom);
                    path.AddLine(pageBounds.Right, pageBounds.Bottom, pageBounds.X, pageBounds.Bottom);
                    path.AddLine(pageBounds.X, pageBounds.Bottom, pageBounds.X, pageBounds.Y);
                    path.AddLine(pageBounds.X, pageBounds.Y, tabBounds.X, pageBounds.Y);
                    break;
                case TabAlignment.Bottom:
                    path.AddLine(tabBounds.X, pageBounds.Bottom, pageBounds.X, pageBounds.Bottom);
                    path.AddLine(pageBounds.X, pageBounds.Bottom, pageBounds.X, pageBounds.Y);
                    path.AddLine(pageBounds.X, pageBounds.Y, pageBounds.Right, pageBounds.Y);
                    path.AddLine(pageBounds.Right, pageBounds.Y, pageBounds.Right, pageBounds.Bottom);
                    path.AddLine(pageBounds.Right, pageBounds.Bottom, tabBounds.Right, pageBounds.Bottom);
                    break;
                case TabAlignment.Left:
                    path.AddLine(pageBounds.X, tabBounds.Y, pageBounds.X, pageBounds.Y);
                    path.AddLine(pageBounds.X, pageBounds.Y, pageBounds.Right, pageBounds.Y);
                    path.AddLine(pageBounds.Right, pageBounds.Y, pageBounds.Right, pageBounds.Bottom);
                    path.AddLine(pageBounds.Right, pageBounds.Bottom, pageBounds.X, pageBounds.Bottom);
                    path.AddLine(pageBounds.X, pageBounds.Bottom, pageBounds.X, tabBounds.Bottom);
                    break;
                case TabAlignment.Right:
                    path.AddLine(pageBounds.Right, tabBounds.Bottom, pageBounds.Right, pageBounds.Bottom);
                    path.AddLine(pageBounds.Right, pageBounds.Bottom, pageBounds.X, pageBounds.Bottom);
                    path.AddLine(pageBounds.X, pageBounds.Bottom, pageBounds.X, pageBounds.Y);
                    path.AddLine(pageBounds.X, pageBounds.Y, pageBounds.Right, pageBounds.Y);
                    path.AddLine(pageBounds.Right, pageBounds.Y, pageBounds.Right, tabBounds.Y);
                    break;
            }
        }

        private Rectangle GetTabImageRect(int index)
        {
            using (GraphicsPath tabBorderPath = _StyleProvider.GetTabBorder(index))
            {
                return GetTabImageRect(tabBorderPath);
            }
        }

        private Rectangle GetTabImageRect(GraphicsPath tabBorderPath)
        {
            _ = new Rectangle();
            RectangleF rect = tabBorderPath.GetBounds();

            //	Make it shorter or thinner to fit the height or width because of the padding added to the tab for painting
            switch (Alignment)
            {
                case TabAlignment.Top:
                    rect.Y += 4;
                    rect.Height -= 6;
                    break;
                case TabAlignment.Bottom:
                    rect.Y += 2;
                    rect.Height -= 6;
                    break;
                case TabAlignment.Left:
                    rect.X += 4;
                    rect.Width -= 6;
                    break;
                case TabAlignment.Right:
                    rect.X += 2;
                    rect.Width -= 6;
                    break;
            }

            Rectangle imageRect;
            //	Ensure image is fully visible
            if (Alignment <= TabAlignment.Bottom)
            {
                if ((_StyleProvider.ImageAlign & NativeMethods.AnyLeftAlign) != ((ContentAlignment)0))
                {
                    imageRect = new Rectangle((int)rect.X, (int)rect.Y + (int)Math.Floor((double)((int)rect.Height - 16) / 2), 16, 16);
                    while (!tabBorderPath.IsVisible(imageRect.X, imageRect.Y))
                    {
                        imageRect.X += 1;
                    }
                    imageRect.X += 4;

                }
                else if ((_StyleProvider.ImageAlign & NativeMethods.AnyCenterAlign) != ((ContentAlignment)0))
                {
                    imageRect = new Rectangle((int)rect.X + (int)Math.Floor((double)(((int)rect.Right - (int)rect.X - (int)rect.Height + 2) / 2)), (int)rect.Y + (int)Math.Floor((double)((int)rect.Height - 16) / 2), 16, 16);
                }
                else
                {
                    imageRect = new Rectangle((int)rect.Right, (int)rect.Y + (int)Math.Floor((double)((int)rect.Height - 16) / 2), 16, 16);
                    while (!tabBorderPath.IsVisible(imageRect.Right, imageRect.Y))
                    {
                        imageRect.X -= 1;
                    }
                    imageRect.X -= 4;

                    //	Move it in further to allow for the tab closer
                    if (_StyleProvider.ShowTabCloser && !RightToLeftLayout)
                    {
                        imageRect.X -= 10;
                    }
                }
            }
            else
            {
                if ((_StyleProvider.ImageAlign & NativeMethods.AnyLeftAlign) != ((ContentAlignment)0))
                {
                    imageRect = new Rectangle((int)rect.X + (int)Math.Floor((double)((int)rect.Width - 16) / 2), (int)rect.Y, 16, 16);
                    while (!tabBorderPath.IsVisible(imageRect.X, imageRect.Y))
                    {
                        imageRect.Y += 1;
                    }
                    imageRect.Y += 4;
                }
                else if ((_StyleProvider.ImageAlign & NativeMethods.AnyCenterAlign) != ((ContentAlignment)0))
                {
                    imageRect = new Rectangle((int)rect.X + (int)Math.Floor((double)((int)rect.Width - 16) / 2), (int)rect.Y + (int)Math.Floor((double)(((int)rect.Bottom - (int)rect.Y - (int)rect.Width + 2) / 2)), 16, 16);
                }
                else
                {
                    imageRect = new Rectangle((int)rect.X + (int)Math.Floor((double)((int)rect.Width - 16) / 2), (int)rect.Bottom, 16, 16);
                    while (!tabBorderPath.IsVisible(imageRect.X, imageRect.Bottom))
                    {
                        imageRect.Y -= 1;
                    }
                    imageRect.Y -= 4;

                    //	Move it in further to allow for the tab closer
                    if (_StyleProvider.ShowTabCloser && !RightToLeftLayout)
                    {
                        imageRect.Y -= 10;
                    }
                }
            }
            return imageRect;
        }

        public Rectangle GetTabCloserRect(int index)
        {
            Rectangle closerRect = new Rectangle();
            using (GraphicsPath path = _StyleProvider.GetTabBorder(index))
            {
                RectangleF rect = path.GetBounds();

                //	Make it shorter or thinner to fit the height or width because of the padding added to the tab for painting
                switch (Alignment)
                {
                    case TabAlignment.Top:
                        rect.Y += 4;
                        rect.Height -= 6;
                        break;
                    case TabAlignment.Bottom:
                        rect.Y += 2;
                        rect.Height -= 6;
                        break;
                    case TabAlignment.Left:
                        rect.X += 4;
                        rect.Width -= 6;
                        break;
                    case TabAlignment.Right:
                        rect.X += 2;
                        rect.Width -= 6;
                        break;
                }
                if (Alignment <= TabAlignment.Bottom)
                {
                    if (RightToLeftLayout)
                    {
                        closerRect = new Rectangle((int)rect.Left, (int)rect.Y + (int)Math.Floor((double)((int)rect.Height - 6) / 2), 6, 6);
                        while (!path.IsVisible(closerRect.Left, closerRect.Y) && closerRect.Right < Width)
                        {
                            closerRect.X += 1;
                        }
                        closerRect.X += 4;
                    }
                    else
                    {
                        closerRect = new Rectangle((int)rect.Right, (int)rect.Y + (int)Math.Floor((double)((int)rect.Height - 6) / 2), 6, 6);
                        while (!path.IsVisible(closerRect.Right, closerRect.Y) && closerRect.Right > -6)
                        {
                            closerRect.X -= 1;
                        }
                        closerRect.X -= 4;
                    }
                }
                else
                {
                    if (RightToLeftLayout)
                    {
                        closerRect = new Rectangle((int)rect.X + (int)Math.Floor((double)((int)rect.Width - 6) / 2), (int)rect.Top, 6, 6);
                        while (!path.IsVisible(closerRect.X, closerRect.Top) && closerRect.Bottom < Height)
                        {
                            closerRect.Y += 1;
                        }
                        closerRect.Y += 4;
                    }
                    else
                    {
                        closerRect = new Rectangle((int)rect.X + (int)Math.Floor((double)((int)rect.Width - 6) / 2), (int)rect.Bottom, 6, 6);
                        while (!path.IsVisible(closerRect.X, closerRect.Bottom) && closerRect.Top > -6)
                        {
                            closerRect.Y -= 1;
                        }
                        closerRect.Y -= 4;
                    }
                }
            }
            return closerRect;
        }

        public new Drawing.Point MousePosition
        {
            get
            {
                Drawing.Point loc = PointToClient(Control.MousePosition);
                if (RightToLeftLayout)
                {
                    loc.X = (Width - loc.X);
                }
                return loc;
            }
        }

        #endregion

        #region"ContextMenuStrip"

        private ContextMenuStrip _contextMenuStripTabPage;
        private ToolStripMenuItem toolStripMenuItem_Alignment;
        private ToolStripMenuItem toolStripMenuItem_Top;
        private ToolStripMenuItem toolStripMenuItem_Bottom;
        private ToolStripMenuItem toolStripMenuItem_Left;
        private ToolStripMenuItem toolStripMenuItem_Right;
        private ToolStripMenuItem toolStripMenuItem_TabStyle;

        private void Initialize_TabControlRunningProject()
        {
            _contextMenuStripTabPage = new ContextMenuStrip();
            toolStripMenuItem_Alignment = new ToolStripMenuItem();

            toolStripMenuItem_Top = new ToolStripMenuItem();
            toolStripMenuItem_Bottom = new ToolStripMenuItem();
            toolStripMenuItem_Left = new ToolStripMenuItem();
            toolStripMenuItem_Right = new ToolStripMenuItem();

            toolStripMenuItem_TabStyle = new ToolStripMenuItem();

            _contextMenuStripTabPage.Name = "_contextMenuStrTabPage";
            _contextMenuStripTabPage.Size = new Drawing.Size(121, 48);
            // 
            // toolStripMenuItem_Alignment
            // 
            toolStripMenuItem_Alignment.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            toolStripMenuItem_Alignment.DropDownItems.AddRange(new ToolStripItem[]
                                                                        {
                                                                            toolStripMenuItem_Top,
                                                                            toolStripMenuItem_Bottom,
                                                                            toolStripMenuItem_Left,
                                                                            toolStripMenuItem_Right
                                                                        }
                                                                    );
            toolStripMenuItem_Alignment.Name = "toolStripMenuItem_Alignment";
            toolStripMenuItem_Alignment.Size = new Drawing.Size(120, 22);
            toolStripMenuItem_Alignment.Text = "Alignment";
            // 
            // toolStripMenuItem_Top
            // 
            toolStripMenuItem_Top.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            toolStripMenuItem_Top.Name = "toolStripMenuItem_Top";
            toolStripMenuItem_Top.Size = new Drawing.Size(152, 22);
            toolStripMenuItem_Top.Text = "Top";
            // 
            // toolStripMenuItem_Bottom
            // 
            toolStripMenuItem_Bottom.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            toolStripMenuItem_Bottom.Name = "toolStripMenuItem_Bottom";
            toolStripMenuItem_Bottom.Size = new Drawing.Size(152, 22);
            toolStripMenuItem_Bottom.Text = "Bottom";
            // 
            // toolStripMenuItem_Left
            // 
            toolStripMenuItem_Left.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            toolStripMenuItem_Left.Name = "toolStripMenuItem_Left";
            toolStripMenuItem_Left.Size = new Drawing.Size(152, 22);
            toolStripMenuItem_Left.Text = "Left";
            // 
            // toolStripMenuItem_Right
            // 
            toolStripMenuItem_Right.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            toolStripMenuItem_Right.Name = "toolStripMenuItem_Right";
            toolStripMenuItem_Right.Size = new Drawing.Size(152, 22);
            toolStripMenuItem_Right.Text = "Right";
            // 
            // toolStripMenuItem_TabStyle
            // 
            toolStripMenuItem_TabStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            toolStripMenuItem_TabStyle.DropDownItems.AddRange(new ToolStripItem[]
                                                                        {
                                                                        }
                                                                    );
            toolStripMenuItem_TabStyle.Name = "toolStripMenuItem_Alignment";
            toolStripMenuItem_TabStyle.Size = new Drawing.Size(120, 22);
            toolStripMenuItem_TabStyle.Text = "TabStyle";
            // 
            // _contextMenuStripTabPage
            // 
            _contextMenuStripTabPage.Items.AddRange(new ToolStripItem[]
                                                            {
                                                                toolStripMenuItem_Alignment,
                                                                toolStripMenuItem_TabStyle
                                                            }
                                                         );

            ContextMenuStrip = _contextMenuStripTabPage;

            _contextMenuStripTabPage.Opening += ContextMenuStripTabPage_Opening;
            toolStripMenuItem_Alignment.DropDownItemClicked += ToolStripMenuItem_Alignment_DropDownItemClicked;
        }

        private void ToolStripMenuItem_Alignment_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Top":
                    {
                        Alignment = TabAlignment.Top;
                        break;
                    }
                case "Bottom":
                    {
                        Alignment = TabAlignment.Bottom;
                        break;
                    }
                case "Left":
                    {
                        Alignment = TabAlignment.Left;
                        break;
                    }
                case "Right":
                    {
                        Alignment = TabAlignment.Right;
                        break;
                    }
            }
        }

        private void ContextMenuStripTabPage_Opening(object sender, CancelEventArgs e)
        {
            if (TabPages[0].Bounds.Contains(MousePosition))
            {
                e.Cancel = true;
                return;
            }
        }

        #endregion"ContextMenuStrip"
    }
}

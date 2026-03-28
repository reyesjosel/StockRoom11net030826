using System.ComponentModel;

namespace MyStuff11net
{
    [Designer(typeof(FATabStripItemDesigner))]
    [ToolboxItem(false)]
    [DefaultProperty("Title")]
    [DefaultEvent("Changed")]
    public class FATabStripItem : Panel
    {
        public event EventHandler Changed;

        //private DrawItemState drawState = DrawItemState.None;
        private RectangleF stripRect = Rectangle.Empty;
        private Image image;
        private bool canClose = true;
        private bool selected;
        private bool visible = true;
        private bool isDrawn;
        private string title = string.Empty;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = value; }
        }

        [DefaultValue(true)]
        public new bool Visible
        {
            get { return visible; }
            set
            {
                if (visible == value)
                    return;

                visible = value;
                OnChanged();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal RectangleF StripRect
        {
            get { return stripRect; }
            set { stripRect = value; }
        }

        [Browsable(false)]
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsDrawn
        {
            get { return isDrawn; }
            set
            {
                if (isDrawn == value)
                    return;

                isDrawn = value;
            }
        }

        /// <summary>
        /// Image of <see cref="FATabStripItem"/> which will be displayed
        /// on menu items.
        /// </summary>
        [DefaultValue(null)]
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        [DefaultValue(true)]
        public bool CanClose
        {
            get { return canClose; }
            set { canClose = value; }
        }

        [DefaultValue("Name")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title == value)
                    return;

                title = value;
                OnChanged();
            }
        }

        /// <summary>
        /// Gets and sets a value indicating if the page is selected.
        /// </summary>
        [DefaultValue(false)]
        [Browsable(false)]
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected == value)
                    return;

                selected = value;
            }
        }

        [Browsable(false)]
        public string Caption
        {
            get { return Title; }
        }

        public FATabStripItem() : this(string.Empty, null)
        {
        }

        public FATabStripItem(Control displayControl) : this(string.Empty, displayControl)
        {
        }

        public FATabStripItem(string caption, Control displayControl)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ContainerControl, true);

            selected = false;
            Visible = true;

            UpdateText(caption, displayControl);

            //Add to controls
            if (displayControl != null)
                Controls.Add(displayControl);
        }

        /// <summary>
        /// Handles proper disposition of the tab page control.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (image != null)
                    image.Dispose();
            }
        }

        public bool ShouldSerializeIsDrawn()
        {
            return false;
        }

        public bool ShouldSerializeDock()
        {
            return false;
        }

        public bool ShouldSerializeControls()
        {
            return Controls != null && Controls.Count > 0;
        }

        public bool ShouldSerializeVisible()
        {
            return true;
        }

        private void UpdateText(string caption, Control displayControl)
        {
            if (displayControl != null && displayControl is ICaptionSupport)
            {
                ICaptionSupport capControl = displayControl as ICaptionSupport;
                Title = capControl.Caption;
            }
            else if (caption.Length <= 0 && displayControl != null)
            {
                Title = displayControl.Text;
            }
            else if (caption != null)
            {
                Title = caption;
            }
            else
            {
                Title = string.Empty;
            }
        }

        public void Assign(FATabStripItem item)
        {
            Visible = item.Visible;
            Text = item.Text;
            CanClose = item.CanClose;
            Tag = item.Tag;
        }

        protected internal virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Return a string representation of page.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Caption;
        }

    }
}

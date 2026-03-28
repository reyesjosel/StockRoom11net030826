using System.ComponentModel;

namespace MyStuff11net
{
    public partial class DocumentsAddressItem : UserControl
    {
        string MessagePositionString = "";
        DirectoryFile directoryToTest = new DirectoryFile();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SpliterCharacter
        {
            get
            {
                return "&";
            }
            private set { }
        }

        int index;
        /// <summary>
        /// Value of DocumentsAddressItem, it's store as ("PdfDoc" + "ID" + SpliterCharacter + "AccessLevel" + SpliterCharacter + 
        /// "Description" + SpliterCharacter + "SettingAddressPath"  + SpliterCharacter + "DocumentsExtensionAcepted";)
        /// ID value contains 5 digit (12345), AccessLevel value can be (Public or Private), Description value is any description about this setting,
        /// SettingValue value contains the address or path of this setting.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Value of DocumentsAddressItem, it's store as ("PdfDoc" + "ID" + SpliterCharacter + "AccessLevel" + SpliterCharacter + 
        /// "Description" + SpliterCharacter + "SettingAddressPath"  + SpliterCharacter + "DocumentsExtensionAcepted";)
        /// ID value contains 5 digit (12345), AccessLevel value can be (Public or Private), Description value is any description about this setting,
        /// SettingValue value contains the address or path of this setting.
        /// </summary>
        public string DocumentsAddressSet
        {
            get
            {
                string settingValue = "PdfDoc" + ID + SpliterCharacter + AccessLevel + SpliterCharacter + DocumentsAddressNameDescription +
                                   SpliterCharacter + DocumentsAddressValueDirectory + SpliterCharacter + DocumentsExtensionAcepted;

                return settingValue;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                string[] settingArray = new string[5] { "ID", "AccessLevel", "Description", "SettingAddressPath", "DocumentsExtensionAcepted" };

                try
                {
                    if (value.Contains(SpliterCharacter))
                        settingArray = value.Split(new string[] { SpliterCharacter }, StringSplitOptions.RemoveEmptyEntries);

                    index = 0;
                    if (index < settingArray.Length)
                        ID = MyCode.CastAsInt(settingArray[index].Replace("PdfDoc", ""));
                    index++;
                    if (index < settingArray.Length)
                        AccessLevel = settingArray[index];
                    index++;
                    if (index < settingArray.Length)
                        label_DocumentsAddressItemNameDescription.Text = settingArray[index];
                    index++;
                    if (index < settingArray.Length)
                        label_DocumentsAddressItemValue.Text = settingArray[index];
                    index++;
                    if (index < settingArray.Length)
                        label_DocumentsExtensionAcepted.Text = settingArray[index];

                    labelPublicPrivateID.Text = "ID " + ID + ", AccessLevel -> " + AccessLevel;
                    TestValidPath(label_DocumentsAddressItemValue.Text);
                    Invalidate();
                }
                catch (Exception)
                {
                    switch (index)
                    {
                        #region"Cases"
                        case 0:
                            {
                                ID = 12345;
                                AccessLevel = "Private";
                                label_DocumentsAddressItemNameDescription.Text = @"This setting fault, the system set to default value";
                                label_DocumentsAddressItemValue.Text = @"Default Documents Location";
                                label_DocumentsExtensionAcepted.Text = "Documents extension to be accepted";
                                break;
                            }
                        case 1:
                            {
                                AccessLevel = "Private";
                                label_DocumentsAddressItemNameDescription.Text = @"This setting fault, the system set to default value";
                                label_DocumentsAddressItemValue.Text = @"Default Documents Location";
                                label_DocumentsExtensionAcepted.Text = "Documents extension to be accepted";
                                break;
                            }
                        case 2:
                            {
                                label_DocumentsAddressItemNameDescription.Text = @"This setting fault, the system set to default value";
                                label_DocumentsAddressItemValue.Text = @"Default Documents Location";
                                label_DocumentsExtensionAcepted.Text = "Documents extension to be accepted";
                                break;
                            }
                        case 3:
                            {
                                label_DocumentsAddressItemValue.Text = @"Default Documents Location";
                                label_DocumentsExtensionAcepted.Text = "Documents extension to be accepted";
                                break;
                            }
                        case 4:
                            {
                                label_DocumentsExtensionAcepted.Text = "Documents extension to be accepted";
                                break;
                            }
                            #endregion"Cases"
                    }
                    labelPublicPrivateID.Text = "ID " + ID + ", AccessLevel -> " + AccessLevel;
                    TestValidPath(label_DocumentsAddressItemValue.Text);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// ID value contains 5 digit (12345), it is specific to each DocumentsAddressItem.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// ID value contains 5 digit (12345), it is specific to each DocumentsAddressItem.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Return a string specifying the accessLevel.
        /// The possible value are Public or Private.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Return a string specifying the accessLevel.
        /// The possible value are Public or Private.
        /// </summary>
        public string AccessLevel { get; set; }
        /// <summary>
        /// Return true if AccessLevel is Private.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Return true if AccessLevel is Private.
        /// </summary>
        public bool IsAccessLevelPrivate
        {
            get
            {
                if (AccessLevel.Contains("Private"))
                    return true;

                return false;
            }

            private set { }
        }
        /// <summary>
        /// Return true if AccessLevel is Public.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Return true if AccessLevel is Public.
        /// </summary>
        public bool IsAccessLevelPublic
        {
            get
            {
                if (AccessLevel.Contains("Public"))
                    return true;

                return false;
            }

            private set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DocumentsAddressNameDescription
        {
            get
            {
                return label_DocumentsAddressItemNameDescription.Text;
            }
            set
            {
                label_DocumentsAddressItemNameDescription.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DocumentsAddressValueDirectory
        {
            get
            {
                return label_DocumentsAddressItemValue.Text;
            }
            set
            {
                label_DocumentsAddressItemValue.Text = value;

                if (!directoryToTest.IsValidPath(label_DocumentsAddressItemValue.Text))
                    grouper_DocumentsAddressItem.BackgroundColor = Color.OrangeRed;//Gainsboro
                else
                    grouper_DocumentsAddressItem.BackgroundColor = Color.Gainsboro;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DocumentsExtensionAcepted
        {
            get
            {
                return label_DocumentsExtensionAcepted.Text;
            }
            set
            {
                label_DocumentsExtensionAcepted.Text = value;
            }
        }

        bool _isSelected;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                if (_isSelected)
                {
                    grouper_DocumentsAddressItem.BorderThickness = 2;
                    grouper_DocumentsAddressItem.BorderColor = Color.Black;
                    panel_BackColor.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    grouper_DocumentsAddressItem.BorderThickness = 1;
                    grouper_DocumentsAddressItem.BorderColor = Color.DimGray;
                    panel_BackColor.BackColor = Color.Gainsboro;
                }
            }
        }

        bool _isMouseOver;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMouseOver
        {
            get
            {
                return _isMouseOver;
            }
            set
            {
                _isMouseOver = value;
                if (_isMouseOver)
                {
                    panel_BackColor.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    if (IsSelected)
                        return;

                    if (!directoryToTest.IsValidPath(label_DocumentsAddressItemValue.Text))
                        panel_BackColor.BackColor = Color.OrangeRed;
                    else
                        panel_BackColor.BackColor = Color.Gainsboro;
                }

                Invalidate();
            }
        }

        #region"MouseEnter_Event"

        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void MouseEnter_EventHandler(object sender, MouseEnter_EventArgs e);

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class MouseEnter_EventArgs : EventArgs
        {
            public MouseEnter_EventArgs()
            {

            }
        }

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The mouse has enter the area of the control.")]
        public event MouseEnter_EventHandler MouseEnter_Event;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_MouseEnter_Event(MouseEnter_EventArgs e)
        {
            // Notify Subscribers
            MouseEnter_Event?.Invoke(this, e);
        }

        #endregion"MouseEnter_Event"

        #region"MouseLeave_Event"

        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void MouseLeave_EventHandler(object sender, MouseLeave_EventArgs e);

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class MouseLeave_EventArgs : EventArgs
        {
            public MouseLeave_EventArgs()
            {

            }
        }

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The mouse has enter the area of the control.")]
        public event MouseLeave_EventHandler MouseLeave_Event;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_MouseLeave_Event(MouseLeave_EventArgs e)
        {
            // Notify Subscribers
            MouseLeave_Event?.Invoke(this, e);
        }

        #endregion"MouseLeave_Event"

        #region"MouseClick_Event"

        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void MouseClick_EventHandler(object sender, MouseClick_EventArgs e);

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class MouseClick_EventArgs : EventArgs
        {
            public MouseClick_EventArgs()
            {

            }
        }

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The mouse has click the area of the control.")]
        public event MouseClick_EventHandler MouseClick_Event;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_MouseClick_Event(MouseClick_EventArgs e)
        {
            // Notify Subscribers
            MouseClick_Event?.Invoke(this, e);
        }

        #endregion"MouseClick_Event"

        public DocumentsAddressItem()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, "The constructor has found an error " + error.Message +
                                          " at position " + MessagePositionString,
                                          "EmployeesInformation Class error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public DocumentsAddressItem(string documentsAddressSet)
        {
            try
            {
                InitializeComponent();

                DocumentsAddressSet = documentsAddressSet;
                IsSelected = false;

                InitializeEventHandler();
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"The constructor has found an error " + error.Message +
                                          @" at position " + MessagePositionString,
                                          @"EmployeesInformation Class error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void InitializeEventHandler()
        {
            MouseClick += this_MouseClick;
            MouseEnter += this_MouseEnter;
            MouseLeave += this_MouseLeave;
            VisibleChanged += this_VisibleChanged;

            AddMouseEventsToChildren(this);
        }

        void TestValidPath(string path)
        {
            if (!directoryToTest.IsValidPath(path))
                panel_BackColor.BackColor = Color.OrangeRed;
            else
                panel_BackColor.BackColor = Color.Gainsboro;
        }

        void AddMouseEventsToChildren(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                child.MouseClick += this_MouseClick;
                child.MouseLeave += this_MouseLeave;
                child.MouseEnter += this_MouseEnter;
                AddMouseEventsToChildren(child);
            }
        }

        void AddMouseEventsToParents(Control child)
        {
            if (child.Parent != null)
            {
                // connect both enter and leave to MouseLeave()
                child.Parent.MouseEnter += this_MouseLeave;
                child.Parent.MouseLeave += this_MouseLeave;
                AddMouseEventsToParents(child.Parent);
            }
        }


        void this_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (!directoryToTest.IsValidPath(label_DocumentsAddressItemValue.Text))
                    grouper_DocumentsAddressItem.BackgroundColor = Color.OrangeRed;
                else
                    grouper_DocumentsAddressItem.BackgroundColor = Color.Gainsboro;
            }

        }

        void this_MouseClick(object sender, MouseEventArgs e)
        {
            On_MouseClick_Event(new MouseClick_EventArgs());
        }

        Control _parent;
        void this_MouseEnter(object sender, EventArgs e)
        {
            // since we haven't been added to a control at creation...
            if (_parent == null)
            {
                _parent = Parent;
                //AddMouseEventsToParents(this);
            }

            On_MouseEnter_Event(new MouseEnter_EventArgs());
        }

        void this_MouseLeave(object sender, EventArgs e)
        {
            var pos = PointToClient(Cursor.Position);
            if (!ClientRectangle.Contains(pos))
            {
                On_MouseLeave_Event(new MouseLeave_EventArgs());
            }
        }

        /// <summary>
        /// Value of DocumentsAddressItem, it's store as ("PdfDoc" + "ID" + SpliterCharacter + "AccessLevel" + SpliterCharacter + 
        /// "Description" + SpliterCharacter + "SettingAddressPath"  + SpliterCharacter + "DocumentsExtensionAcepted";)
        /// ID value contains 5 digit (12345), AccessLevel value can be (Public or Private), Description value is any description about this setting,
        /// SettingValue value contains the address or path of this setting.
        /// </summary>
        public override string ToString()
        {
            return DocumentsAddressSet;
        }


    }
}

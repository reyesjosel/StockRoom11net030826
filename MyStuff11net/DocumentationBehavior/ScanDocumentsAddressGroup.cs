using System.ComponentModel;

namespace MyStuff11net
{
    public partial class ScanDocumentsAddressGroup : UserControl
    {
        //documentsAddressItemDefault, it is by default.

        #region "CloseProject"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Description("New Item Event.")]
        [Browsable(true), Category("Controls Events")]
        public event Custom_Events_Args.CloseProject_EventHandler CloseProject;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_CloseProject(Custom_Events_Args.CloseProject_EventArgs e)
        {
            // Notify Subscribers
            CloseProject?.Invoke(this, e);
        }

        #endregion "CloseProject"

        /// <summary>
        /// Middle Prime numbers of 5 digit.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DefaultIDvalue
        {
            get
            {
                return 60013;
            }
            set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SpliterCharacter
        {
            get
            {
                return "&";
            }
            private set { }
        }

        DepartmentInformation Department;
        List<DepartmentInformation> DepartmentList;

        //Needed for design purpose.
        public ScanDocumentsAddressGroup()
        {
            InitializeComponent();

            Department = new DepartmentInformation();
            DepartmentList = new List<DepartmentInformation>();
        }

        public ScanDocumentsAddressGroup(DepartmentInformation department)
        {
            InitializeComponent();

            Department = department;

            ButtonAdd.Enabled = false;
            ButtonDelete.Enabled = false;
            ButtonEdit.Enabled = false;
            ButtonCancel.MouseClick += ButtonCancel_MouseClick;

            InitializeScanDocumentsAddress();
        }

        public ScanDocumentsAddressGroup(DepartmentInformation department, List<DepartmentInformation> departmentList)
        {
            InitializeComponent();

            Department = department;
            DepartmentList = departmentList;

            ButtonAdd.MouseClick += ButtonAdd_MouseClick;
            ButtonDelete.MouseClick += ButtonDelete_MouseClick;
            ButtonEdit.MouseClick += ButtonEdit_MouseClick;
            ButtonCancel.MouseClick += ButtonCancel_MouseClick;

            InitializeScanDocumentsAddress();
        }


        void InitializeScanDocumentsAddress()
        {
            ButtonAdd.Enabled = true;
            ButtonEdit.Enabled = false;
            ButtonDelete.Enabled = false;
            ButtonCancel.Enabled = false;

            panel_ScanDocumentsAddressItems.Controls.Clear();
            MinimumSize = new Size(Width, (panel_ScanFlowLayoutButtons.Height + 15));
            Size = MinimumSize;

            if (Department.DepartmentScanDocumentsAddressItems.Count == 0)
            {
                listID.Add(DefaultIDvalue);
                listID.Sort();
                nextID = listID.Last();

                MinimumSize = new Size(Width, (panel_ScanConvertFilesFrontThisLocationInf.Height + panel_ScanFlowLayoutButtons.Height + 15));
                Size = MinimumSize;
                return;
            }

            grouper_ScanDocumentsAddressGroup.Controls.Remove(panel_ScanConvertFilesFrontThisLocationInf);

            foreach (ScanDocumentsAddressItem scanDocumentAddressItemLoop in Department.DepartmentScanDocumentsAddressItems)
            {
                // UpDate the ID list.
                listID.Add(scanDocumentAddressItemLoop.ID);

                ScanDocumentsAddressItem scanDocumentAddressItem;
                scanDocumentAddressItem = new ScanDocumentsAddressItem(scanDocumentAddressItemLoop.ScanDocumentsAddressSet)
                {
                    Dock = DockStyle.Top,
                    Name = scanDocumentAddressItemLoop.ID.ToString()
                };
                scanDocumentAddressItem.MouseEnter_Event += ScanDocumentsAddressItem_MouseEnter_Event;
                scanDocumentAddressItem.MouseLeave_Event += ScanDocumentsAddressItemDefault_MouseLeave_Event;
                scanDocumentAddressItem.MouseClick_Event += ScanDocumentsAddressItem1_MouseClick_Event;

                MinimumSize = new Size(Width, (Height + scanDocumentAddressItem.Height));
                Size = MinimumSize;
                panel_ScanDocumentsAddressItems.Controls.Add(scanDocumentAddressItem);
            }

            listID.Sort();
            nextID = listID.Last();
        }

        void ScanDocumentsAddressItemDefault_MouseLeave_Event(object sender, ScanDocumentsAddressItem.MouseLeave_EventArgs e)
        {
            if (panel_ScanDocumentsAddressItems.Controls.Count == 0)
                return;

            foreach (ScanDocumentsAddressItem scanDocumentAddressItem in panel_ScanDocumentsAddressItems.Controls)
            {
                scanDocumentAddressItem.IsMouseOver = false;
            }
        }

        void ScanDocumentsAddressItem_MouseEnter_Event(object sender, ScanDocumentsAddressItem.MouseEnter_EventArgs e)
        {
            if (panel_ScanDocumentsAddressItems.Controls.Count == 0)
                return;

            ScanDocumentsAddressItem senderItem = (ScanDocumentsAddressItem)sender;

            foreach (ScanDocumentsAddressItem scanDocumentAddressItem in panel_ScanDocumentsAddressItems.Controls)
            {
                if (scanDocumentAddressItem == senderItem)
                {
                    scanDocumentAddressItem.IsMouseOver = true;
                    continue;
                }

                scanDocumentAddressItem.IsMouseOver = false;
            }
        }

        void ScanDocumentsAddressItem1_MouseClick_Event(object sender, ScanDocumentsAddressItem.MouseClick_EventArgs e)
        {
            var itemClicked = (ScanDocumentsAddressItem)sender;

            foreach (ScanDocumentsAddressItem scanDocumentAddressItem in panel_ScanDocumentsAddressItems.Controls)
            {
                if (scanDocumentAddressItem == itemClicked)
                {
                    scanDocumentAddressItem.IsSelected = true;

                    ButtonAdd.Enabled = false;
                    ButtonEdit.Enabled = true;
                    ButtonDelete.Enabled = true;
                    ButtonCancel.Enabled = true;

                    continue;
                }

                scanDocumentAddressItem.IsSelected = false;
            }
        }

        void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            ScanDocumentsAddressItem itemToDalete = null;

            foreach (ScanDocumentsAddressItem scanDocumentAddressItem in panel_ScanDocumentsAddressItems.Controls)
            {
                if (scanDocumentAddressItem.IsSelected)
                {
                    scanDocumentAddressItem.MouseEnter_Event -= ScanDocumentsAddressItem_MouseEnter_Event;
                    scanDocumentAddressItem.MouseLeave_Event -= ScanDocumentsAddressItemDefault_MouseLeave_Event;
                    scanDocumentAddressItem.MouseClick_Event -= ScanDocumentsAddressItem1_MouseClick_Event;

                    itemToDalete = scanDocumentAddressItem;
                    itemToDalete.IsSelected = false;
                    break;
                }
            }

            if (itemToDalete != null)
            {
                int index = Department.DepartmentScanDocumentsAddressItems.FindIndex(x => x.ID == itemToDalete.ID);
                if (index == -1)
                {
                    using (var form = new Form { TopMost = true })
                    {
                        MessageBox.Show(form, @"Message related to this error is the ScanDocumentsAddressSet was not found.",
                                              @"ScanDocumentAddressGroup, CurrentStatus fail in ---> ButtonDelete_MouseClick() <---",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    InitializeScanDocumentsAddress();
                    return;
                }

                Department.DepartmentScanDocumentsAddressItems.RemoveAt(index);
                Department.SaveSetting();

                InitializeScanDocumentsAddress();
            }
        }

        /// <summary>
        /// Value of ScanDocumentsAddressItem, it's store as ("ID" + SpliterCharacter + "AccessLevel" + SpliterCharacter + "Description" + SpliterCharacter + "SettingValue" +
        /// SpliterCharacter + "DocumentsExtensionAcepted" + SpliterCharacter + "IncludeSubdirectories" + SpliterCharacter + "SkipFile" + SpliterCharacter + "SkipOptions")
        /// ID value contains 5 digit (12345), AccessLevel value can be (Public or Private), Description value is any description about this setting,
        /// SettingValue value contains the address or path of this setting.
        /// </summary>
        void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            var scanDocumentAddressSet = GetID + SpliterCharacter + "Private" + SpliterCharacter + @"Default Documents Description" + SpliterCharacter +
                                     @"Path to documents folder" + SpliterCharacter + @"Documents extension to be accepted" + SpliterCharacter +
                                     "IncludeSubdirectories" + SpliterCharacter + "SkipFile" + SpliterCharacter + "SkipOptions" + SpliterCharacter + "Path to PDF's folder";

            using (var newDocumentsItem = new ScanDocumentsAddressItem(scanDocumentAddressSet))
            {
                ScanDocumentsAddressItemEditor(newDocumentsItem);

                if (editorResult == DialogResult.Cancel)
                    return;

                InitializeScanDocumentsAddress();
            }
        }

        void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ScanDocumentsAddressItem scanDocumentAddressItem in panel_ScanDocumentsAddressItems.Controls)
            {
                if (scanDocumentAddressItem.IsSelected)
                {
                    ScanDocumentsAddressItemEditor(scanDocumentAddressItem);
                }
            }
        }

        void ButtonCancel_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ScanDocumentsAddressItem scanDocumentAddressItem in panel_ScanDocumentsAddressItems.Controls)
            {
                scanDocumentAddressItem.IsSelected = false;
            }

            ButtonAdd.Enabled = true;
            ButtonEdit.Enabled = false;
            ButtonDelete.Enabled = false;
            ButtonCancel.Enabled = false;
        }

        DialogResult editorResult;
        void ScanDocumentsAddressItemEditor(ScanDocumentsAddressItem scanDocumentAddressItem)
        {
            try
            {
                using (var editor = new ScanDocumentsAddressEditor(scanDocumentAddressItem, Department, DepartmentList))
                {
                    editor.TopMost = true;
                    editor.ShowDialog();

                    editorResult = editor.DialogResult;
                }
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                          @", Break code at position ScanDocumentsAddressItemEditor",
                                          @"ScanDocumentsAddressGroup, CurrentStatus fail in ScanDocumentsAddressItemEditorClose",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        List<int> listID = new List<int>();
        int nextID;
        int GetID
        {
            get
            {
                return ++nextID;
            }

            set { }
        }
    }
}

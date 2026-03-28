using System.ComponentModel;

namespace MyStuff11net
{
    public partial class DocumentsAddressGroup : UserControl
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
        /// First Prime numbers of 5 digit.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DefaultIDvalue
        {
            get
            {
                return 10007;
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

        bool AllowedEditing;
        DepartmentInformation Department;
        List<DepartmentInformation> DepartmentList;

        //Needed for design purpose.
        public DocumentsAddressGroup()
        {
            InitializeComponent();

            Department = new DepartmentInformation();
            DepartmentList = new List<DepartmentInformation>();
        }

        public DocumentsAddressGroup(DepartmentInformation department, List<DepartmentInformation> departmentList, bool allowedEditing)
        {
            InitializeComponent();

            AllowedEditing = allowedEditing;
            Department = department;
            DepartmentList = departmentList;

            ButtonAdd.MouseClick += ButtonAdd_MouseClick;
            ButtonDelete.MouseClick += ButtonDelete_MouseClick;
            ButtonEdit.MouseClick += ButtonEdit_MouseClick;

            ButtonAdd.Enabled = allowedEditing;
            ButtonDelete.Enabled = allowedEditing;
            ButtonEdit.Enabled = allowedEditing;
            ButtonCancel.Enabled = true;

            InitializeDocumentsAddress();
        }

        void InitializeDocumentsAddress()
        {
            ButtonCancel.MouseClick -= ButtonCancel_MouseClick;
            ButtonCancel.MouseClick -= ButtonCancel_ViewMode_MouseClick;

            panel_DocumentsAddressItems.Controls.Clear();
            MinimumSize = new Size(Width, (panel_FlowLayoutButtons.Height + 15));
            Size = MinimumSize;

            if (Department.DepartmentDocumentsAddressItems.Count == 0)
            {
                ButtonAdd.Enabled = true;
                ButtonDelete.Enabled = false;
                ButtonEdit.Enabled = false;
                ButtonCancel.Enabled = true;
                ButtonCancel.MouseClick += ButtonCancel_ViewMode_MouseClick;
                MinimumSize = new Size(Width, (panel_DocumentsPDFGroupInf.Height + panel_FlowLayoutButtons.Height + 15));
                Size = MinimumSize;
                return;
            }

            if (AllowedEditing)
            {
                ButtonAdd.Enabled = true;
                ButtonCancel.MouseClick += ButtonCancel_MouseClick;
            }
            else
            {
                ButtonAdd.Enabled = false;
                ButtonCancel.MouseClick += ButtonCancel_ViewMode_MouseClick;
            }

            ButtonCancel.Enabled = true;

            grouper_DocumentsAddressGroup.Controls.Remove(panel_DocumentsPDFGroupInf);


            foreach (DocumentsAddressItem documentAddressItemList in Department.DepartmentDocumentsAddressItems)
            {
                DocumentsAddressItem documentAddressItem;
                documentAddressItem = new DocumentsAddressItem(documentAddressItemList.DocumentsAddressSet)
                {
                    Dock = DockStyle.Top,
                    IsSelected = false,
                    IsMouseOver = false,
                    Name = documentAddressItemList.ID.ToString()
                };
                documentAddressItem.MouseEnter_Event += DocumentsAddressItem_MouseEnter_Event;
                documentAddressItem.MouseLeave_Event += DocumentsAddressItemDefault_MouseLeave_Event;
                if (AllowedEditing)
                    documentAddressItem.MouseClick_Event += DocumentsAddressItem1_MouseClick_Event;

                MinimumSize = new Size(Width, (Height + documentAddressItem.Height));
                Size = MinimumSize;
                panel_DocumentsAddressItems.Controls.Add(documentAddressItem);
            }

            CancelProcedure();
        }

        void DocumentsAddressItemDefault_MouseLeave_Event(object sender, DocumentsAddressItem.MouseLeave_EventArgs e)
        {
            if (panel_DocumentsAddressItems.Controls.Count == 0)
                return;

            foreach (DocumentsAddressItem documentAddressItem in panel_DocumentsAddressItems.Controls)
            {
                documentAddressItem.IsMouseOver = false;
            }
        }

        void DocumentsAddressItem_MouseEnter_Event(object sender, DocumentsAddressItem.MouseEnter_EventArgs e)
        {
            if (panel_DocumentsAddressItems.Controls.Count == 0)
                return;

            DocumentsAddressItem senderItem = (DocumentsAddressItem)sender;

            foreach (DocumentsAddressItem documentAddressItem in panel_DocumentsAddressItems.Controls)
            {
                if (documentAddressItem == senderItem)
                {
                    documentAddressItem.IsMouseOver = true;
                    continue;
                }

                documentAddressItem.IsMouseOver = false;
            }
        }

        void DocumentsAddressItem1_MouseClick_Event(object sender, DocumentsAddressItem.MouseClick_EventArgs e)
        {
            var itemClicked = (DocumentsAddressItem)sender;

            foreach (DocumentsAddressItem documentAddressItem in panel_DocumentsAddressItems.Controls)
            {
                if (documentAddressItem == itemClicked)
                {
                    documentAddressItem.IsSelected = true;

                    ButtonAdd.Enabled = false;
                    ButtonEdit.Enabled = true;
                    ButtonDelete.Enabled = true;
                    ButtonCancel.Enabled = true;

                    continue;
                }

                documentAddressItem.IsSelected = false;
            }
        }


        void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            DocumentsAddressItem itemToDalete = null;

            foreach (DocumentsAddressItem documentAddressItem in panel_DocumentsAddressItems.Controls)
            {
                if (documentAddressItem.IsSelected)
                {
                    documentAddressItem.MouseEnter_Event -= DocumentsAddressItem_MouseEnter_Event;
                    documentAddressItem.MouseLeave_Event -= DocumentsAddressItemDefault_MouseLeave_Event;
                    documentAddressItem.MouseClick_Event -= DocumentsAddressItem1_MouseClick_Event;

                    itemToDalete = documentAddressItem;
                    itemToDalete.IsSelected = false;
                    break;
                }
            }

            if (itemToDalete != null)
            {
                int index = Department.DepartmentDocumentsAddressItems.FindIndex(x => x.ID == itemToDalete.ID);
                if (index == -1)
                {
                    using (var form = new Form { TopMost = true })
                    {
                        MessageBox.Show(form, @"Message related to this error is the DocumentsAddressSet was not found.",
                                              @"DocumentAddressGroup, CurrentStatus fail in ---> ButtonDelete_MouseClick() <---",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    InitializeDocumentsAddress();
                    return;
                }

                Department.DepartmentDocumentsAddressItems.RemoveAt(index);
                Department.SaveSetting();

                InitializeDocumentsAddress();
            }
        }

        /// <summary>
        /// Value of DocumentsAddressItem, it's store as ("ID" + SpliterCharacter + "AccessLevel" + SpliterCharacter + "Description" + SpliterCharacter + "SettingValue")
        /// ID value contains 5 digit (12345), AccessLevel value can be (Public or Private), Description value is any description about this setting,
        /// SettingValue value contains the address or path of this setting.
        /// </summary>
        void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            var documentAddressSet = GetNextID() + SpliterCharacter + "Private" + SpliterCharacter + @"Default Documents Location" +
                                     SpliterCharacter + @"Address to documents location" + SpliterCharacter + @"Documents extension to be accepted";

            using (var newDocumentsItem = new DocumentsAddressItem(documentAddressSet))
            {
                DocumentsAddressItemEditor(newDocumentsItem);

                if (editorResult == DialogResult.Cancel)
                    return;

                InitializeDocumentsAddress();
            }
        }

        void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (DocumentsAddressItem documentAddressItem in panel_DocumentsAddressItems.Controls)
            {
                if (documentAddressItem.IsSelected)
                {
                    DocumentsAddressItemEditor(documentAddressItem);
                }
            }
        }

        void ButtonCancel_ViewMode_MouseClick(object sender, MouseEventArgs e)
        {
            On_CloseProject(new Custom_Events_Args.CloseProject_EventArgs("Documents Address Viewer."));
        }

        void ButtonCancel_MouseClick(object sender, MouseEventArgs e)
        {
            if (AllowedEditing)
                ButtonAdd.Enabled = true;
            else
                ButtonAdd.Enabled = false;

            ButtonAdd.Focus();

            CancelProcedure();
        }

        void CancelProcedure()
        {
            foreach (DocumentsAddressItem documentAddressItem in panel_DocumentsAddressItems.Controls)
            {
                documentAddressItem.IsSelected = false;
            }

            ButtonDelete.Enabled = false;
            ButtonEdit.Enabled = false;
        }

        DialogResult editorResult;
        void DocumentsAddressItemEditor(DocumentsAddressItem documentAddressItem)
        {
            try
            {
                using (var editor = new DocumentsAddressEditor(documentAddressItem, Department, DepartmentList))
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
                                          @", Break code at position DocumentsAddressItemEditor",
                                          @"DocumentsAddressGroup, CurrentStatus fail in DocumentsAddressItemEditorClose",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        int GetNextID()
        {
            var listID = new List<int>();
            foreach (DepartmentInformation department in DepartmentList)
            {
                foreach (DocumentsAddressItem documentaddressItem in department.DepartmentDocumentsAddressItems)
                {
                    listID.Add(documentaddressItem.ID);
                }
            }

            if (listID.Count == 0)
                listID.Add(DefaultIDvalue);

            listID.Sort();
            var nextID = listID.Last();
            nextID++;
            return nextID;
        }

    }
}

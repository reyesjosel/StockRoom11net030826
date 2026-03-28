namespace MyStuff11net
{
    public partial class DocumentsAddressEditor : Form
    {
        Dictionary<string, int> ExtCountDict;
        DepartmentInformation Department;
        DocumentsAddressItem DocumentAddressItem;
        List<DepartmentInformation> DepartmentList = new List<DepartmentInformation>();

        string ExtAcepted { get; set; }
        string AccessLevel { get; set; }

        public DocumentsAddressEditor()
        {
            DialogResult = DialogResult.None;
            InitializeComponent();
        }

        public DocumentsAddressEditor(DocumentsAddressItem documentAddressItem, DepartmentInformation department, List<DepartmentInformation> departmentList)
        {
            try
            {
                InitializeComponent();

                Department = department;
                DepartmentList = departmentList;

                DocumentAddressItem = documentAddressItem;

                if (DocumentAddressItem.IsAccessLevelPrivate)
                {
                    radioButton_Private.Checked = true;
                    radioButton_Public.Checked = false;
                }
                if (DocumentAddressItem.IsAccessLevelPublic)
                {
                    radioButton_Private.Checked = false;
                    radioButton_Public.Checked = true;
                }

                Text = "DocumentsAddressEditor    " + "ID value for this item is " + DocumentAddressItem.ID + ".";

                textBox_DescriptionReference.Text = DocumentAddressItem.DocumentsAddressNameDescription;
                textBox_DirectoryPathFolder.Text = DocumentAddressItem.DocumentsAddressValueDirectory;

                textBox_DescriptionReference.TextChanged += TextBox_DescriptionReference_TextChanged;
                textBox_DirectoryPathFolder.TextChanged += TextBox_DirectoryPathFolder_TextChanged;
                button_BrowserDirectoryPathFolder.MouseClick += Button_BrowserDirectoryPathFolder_MouseClick;
                flowLayoutPanel_AllowedExt.ControlAdded += FlowLayoutPanel_AllowedExt_ControlAdded;
                radioButton_Private.CheckedChanged += RadioButtonCheckedChanged;
                radioButton_Public.CheckedChanged += RadioButtonCheckedChanged;

                AllowedExtCheckBoxFactory(DocumentAddressItem.DocumentsExtensionAcepted);

                button_SaveDocumentsAddress.Enabled = false;
                RadioButtonCheckedChanged(new object(), new EventArgs());
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message + @".",
                                          @"DocumentsAddressEditor, DocumentsAddressEditor fail in constructor.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Private.Checked)
                AccessLevel = "Private";

            if (radioButton_Public.Checked)
                AccessLevel = "Public";
        }

        void FlowLayoutPanel_AllowedExt_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel_AllowedExt.VerticalScroll.Visible)
            {
                Height += 17;
            }
        }

        /// <summary>
        /// Take the string documentsExtensionAcepted formatted as (*.doc,*.docx,*.pdf) and generate the correspond
        /// checkBoxes.
        /// </summary>
        /// <param name="documentsExtensionAcepted"></param>
        void AllowedExtCheckBoxFactory(string documentsExtensionAcepted)
        {
            flowLayoutPanel_AllowedExt.Controls.Clear();

            if (documentsExtensionAcepted.Contains("Documents extension to be accepted"))
            {
                var explainLabel = new Label();
                explainLabel.AutoSize = true;
                explainLabel.Text = "Documents extension to be accepted, select a path and check the ext accepted here...";
                flowLayoutPanel_AllowedExt.Controls.Add(explainLabel);
                return;
            }

            var allowedExt = documentsExtensionAcepted.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string ext in allowedExt)
            {
                AllowedExtCheckBox(ext, ext);
            }
        }

        void AllowedExtCheckBox(string textInf, string ext)
        {
            var checkBox = new CheckBox
            {
                AutoSize = true,
                Text = textInf,
                Tag = ext,
                Checked = false
            };

            checkBox.CheckedChanged += CheckBox_CheckedChanged;

            flowLayoutPanel_AllowedExt.Controls.Add(checkBox);
        }

        void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            button_SaveDocumentsAddress.Enabled = true;
            CheckBox_ExtCheckedChanged();
        }

        bool CheckBox_ExtCheckedChanged()
        {
            var extAcepted = "";
            var builder = new System.Text.StringBuilder();

            foreach (CheckBox checkBox in flowLayoutPanel_AllowedExt.Controls)
            {
                if (checkBox.Checked)
                {
                    var extinf = (string)(checkBox.Tag);
                    builder.Append(extinf.ToLower() + ",");
                }
            }
            extAcepted = builder.ToString();

            ExtAcepted = extAcepted.TrimEnd(new char[] { ',' });

            if (extAcepted.Length == 0)
                return false;

            return true;
        }

        void Button_BrowserDirectoryPathFolder_MouseClick(object sender, MouseEventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog(this) == DialogResult.Cancel)
                    return;

                var filePath = folderBrowser.SelectedPath;
                if (filePath.Contains(@"\\"))
                    filePath.Replace(@"\\", @"\");

                textBox_DirectoryPathFolder.Text = filePath;
            }
        }

        void TextBox_DirectoryPathFolder_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel_AllowedExt.Controls.Clear();

            Task.Factory.StartNew(() => ExtExplorer(textBox_DirectoryPathFolder.Text))
                  .ContinueWith((t1) => UpDateCheckBoxUI(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        void TextBox_DescriptionReference_TextChanged(object sender, EventArgs e)
        {
            if (textBox_DescriptionReference.Text.Contains("&"))
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Sorry, the & character is reserved and can not be used in this name.",
                                          @"Remove the reserved character to continue.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_DescriptionReference.Text = textBox_DescriptionReference.Text.Replace("&", "");
                }
            }
        }

        // ...

        void ExtExplorer(string pathRootFolder)
        {
            var fileNameToMatch = "*";
            var fileExtToMatch = "*";
            ExtCountDict = new Dictionary<string, int>();
            var list_Ext = new List<Dictionary<string, int>>();

            using (FileSystemEnumerator fse = new FileSystemEnumerator(pathRootFolder,
                                                                         fileExtToMatch,
                                                                         true,
                                                                         true,
                                                                         500000))
            {
                foreach (FileInfo document in fse.MatchesFiles(fileNameToMatch))
                {
                    if (ExtCountDict.ContainsKey(document.Extension))
                        ExtCountDict[document.Extension] = ExtCountDict[document.Extension] + 1;
                    else
                        ExtCountDict.Add(document.Extension, 1);
                }
            }
        }

        void UpDateCheckBoxUI()
        {
            if (ExtCountDict == null)
                return;

            foreach (KeyValuePair<string, int> extFound in ExtCountDict.OrderByValueDescending())
            {
                AllowedExtCheckBox(extFound.Value + "-> " + extFound.Key, "*" + extFound.Key);
            }
        }

        bool IsSaveEject;
        void button_SaveDocumentsAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckBox_ExtCheckedChanged())
                    using (var form1 = new Form { TopMost = true })
                    {
                        MessageBox.Show(form1, @"No extension to been selected, you need to specify one or more extensions to search for documents",
                                               @"Documents Address Editor has generated an error.",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                UpDateDocumentAddressItem();

                IsSaveEject = true;
                var departmentAddressExist = Department.DepartmentDocumentsAddressItems.Exists(item => item.ID == DocumentAddressItem.ID);

                if (radioButton_Public.Checked)
                {
                    foreach (DepartmentInformation departInList in DepartmentList)
                    {
                        departmentAddressExist = departInList.DepartmentDocumentsAddressItems.Exists(item => item.ID == DocumentAddressItem.ID);

                        if (departmentAddressExist)
                            departInList.UpDateDocumentAddressItem(DocumentAddressItem);
                        else
                            departInList.AddDocumentAddressItem(DocumentAddressItem);
                    }
                }

                if (radioButton_Private.Checked)
                {
                    if (departmentAddressExist)
                        Department.UpDateDocumentAddressItem(DocumentAddressItem);
                    else
                        Department.AddDocumentAddressItem(DocumentAddressItem);
                }

            }
            catch (Exception)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"An error has been detect in button_SaveDocumentsAddress_Click()...",
                                           @"Documents Address Editor has generated an error.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void button_CancelDocumentsAddress_Click(object sender, EventArgs e)
        {
            if (IsSaveEject)
                DialogResult = DialogResult.OK;
            else
                DialogResult = DialogResult.None;

            Close();
        }

        void UpDateDocumentAddressItem()
        {
            if (DocumentAddressItem == null)
                return;

            DocumentAddressItem.DocumentsAddressNameDescription = textBox_DescriptionReference.Text;
            DocumentAddressItem.DocumentsAddressValueDirectory = textBox_DirectoryPathFolder.Text;
            DocumentAddressItem.DocumentsExtensionAcepted = ExtAcepted;
            DocumentAddressItem.AccessLevel = AccessLevel;

        }
    }
}

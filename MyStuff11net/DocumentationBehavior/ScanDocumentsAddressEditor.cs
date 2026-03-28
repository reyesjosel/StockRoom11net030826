namespace MyStuff11net
{
    public partial class ScanDocumentsAddressEditor : Form
    {
        Dictionary<string, int> ExtCountDict;
        DepartmentInformation Department;
        ScanDocumentsAddressItem ScanDocumentAddressItem;
        List<DepartmentInformation> DepartmentList = new List<DepartmentInformation>();

        string ExtAcepted { get; set; }
        string AccessLevel { get; set; }

        public ScanDocumentsAddressEditor()
        {
            DialogResult = DialogResult.None;
            InitializeComponent();
        }

        public ScanDocumentsAddressEditor(ScanDocumentsAddressItem scanDocumentAddressItem, DepartmentInformation department, List<DepartmentInformation> departmentList)
        {
            try
            {
                InitializeComponent();

                Department = department;
                DepartmentList = departmentList;
                ScanDocumentAddressItem = scanDocumentAddressItem;

                InitializeUIEditor();
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

        void InitializeUIEditor()
        {
            try
            {
                if (ScanDocumentAddressItem == null)
                    throw new NullReferenceException();

                if (ScanDocumentAddressItem.IsAccessLevelPrivate)
                {
                    radioButton_Private.Checked = true;
                    radioButton_Public.Checked = false;
                }
                if (ScanDocumentAddressItem.IsAccessLevelPublic)
                {
                    radioButton_Private.Checked = false;
                    radioButton_Public.Checked = true;
                }

                Text = "DocumentsAddressEditor    " + "ID value for this item is " + ScanDocumentAddressItem.ID + ".";

                textBox_DescriptionReference.Text = ScanDocumentAddressItem.ScanDocumentsAddressNameDescription;
                textBox_DirectoryPathFolder.Text = ScanDocumentAddressItem.ScanDocumentsAddressValueDirectory;

                textBox_DescriptionReference.TextChanged += TextBox_DescriptionReference_TextChanged;
                textBox_DirectoryPathFolder.TextChanged += TextBox_DirectoryPathFolder_TextChanged;
                button_BrowserDirectoryPathFolder.MouseClick += Button_BrowserDirectoryPathFolder_MouseClick;
                flowLayoutPanel_AllowedExt.ControlAdded += FlowLayoutPanel_AllowedExt_ControlAdded;
                radioButton_Private.CheckedChanged += RadioButtonCheckedChanged;
                radioButton_Public.CheckedChanged += RadioButtonCheckedChanged;
                button_SaveConvertedFilesTo.MouseClick += Button_SaveConvertedFilesTo_MouseClick;

                AllowedExtCheckBoxFactory(ScanDocumentAddressItem.ScanDocumentsExtensionAcepted);

                InitializeScanOptions();

                button_SaveDocumentsAddress.Enabled = false;

                RadioButtonCheckedChanged(new object(), new EventArgs());
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message + @".",
                                          @"DocumentsAddressEditor, DocumentsAddressEditor fail in cinitializer.",
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
                Height += 17;
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
                Label explainLabel = new Label();
                explainLabel.AutoSize = true;
                explainLabel.Text = "Documents extension to be accepted, select a path and check the ext accepted here...";
                flowLayoutPanel_AllowedExt.Controls.Add(explainLabel);
                return;
            }

            List<string> allowedExt = documentsExtensionAcepted.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();

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

            checkBox.CheckedChanged += CheckBox_ExtCheckedChanged;

            flowLayoutPanel_AllowedExt.Controls.Add(checkBox);
        }

        void InitializeScanOptions()
        {
            //Wire the event handler..
            checkBox_SkipIfFileExist.CheckedChanged += CheckBox_SkipIfFileExist_CheckedChanged;

            checkBox_IncludeSubdirectoriesInTheSearch.Checked = true;
            if (ScanDocumentAddressItem.IncludeSubdirectories.Contains("false"))
                checkBox_IncludeSubdirectoriesInTheSearch.Checked = false;

            checkBox_SkipIfFileExist.Checked = true;
            if (ScanDocumentAddressItem.SkipFile.Contains("false"))
            {
                checkBox_SkipIfFileExist.Checked = false;
                panel_RadioButtonOptions.Enabled = false;
            }
            else
            {
                //  radioButton_SkipAlwaysChecked = true;
                //   if (ScanDocumentAddressItem.SkipOptions.Contains("SkipAlways"))
                //        radioButton_SkipAlwaysChecked = true;
                if (ScanDocumentAddressItem.SkipOptions.Contains("ToBe"))
                    radioButton_ToBe.Checked = true;
                if (ScanDocumentAddressItem.SkipOptions.Contains("SameDate"))
                    radioButton_BothFileHaveTheSameDate.Checked = true;
            }
        }

        void CheckBox_SkipIfFileExist_CheckedChanged(object sender, EventArgs e)
        {
            panel_RadioButtonOptions.Enabled = checkBox_SkipIfFileExist.Checked;
        }

        void CheckBox_ExtCheckedChanged(object sender, EventArgs e)
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

        void Button_SaveConvertedFilesTo_MouseClick(object sender, MouseEventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog(this) == DialogResult.Cancel)
                    return;

                var filePath = folderBrowser.SelectedPath;
                if (filePath.Contains(@"\\"))
                    filePath.Replace(@"\\", @"\");

                textBox_SaveConvertedFilesTo.Text = filePath;
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
                    }

                UpDateScanDocumentAddressItem();

                IsSaveEject = true;
                var scanDepartmentAddressExist = Department.DepartmentScanDocumentsAddressItems.Exists(item => item.ID == ScanDocumentAddressItem.ID);

                if (radioButton_Public.Checked)
                {
                    foreach (DepartmentInformation departInList in DepartmentList)
                    {
                        scanDepartmentAddressExist = departInList.DepartmentScanDocumentsAddressItems.Exists(item => item.ID == ScanDocumentAddressItem.ID);

                        if (scanDepartmentAddressExist)
                            departInList.UpDateScanDocumentAddressItem(ScanDocumentAddressItem);
                        else
                            departInList.AddScanDocumentAddressItem(ScanDocumentAddressItem);
                    }
                }

                if (radioButton_Private.Checked)
                {
                    if (scanDepartmentAddressExist)
                        Department.UpDateScanDocumentAddressItem(ScanDocumentAddressItem);
                    else
                        Department.AddScanDocumentAddressItem(ScanDocumentAddressItem);
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

        void UpDateScanDocumentAddressItem()
        {
            if (ScanDocumentAddressItem == null)
                return;

            ScanDocumentAddressItem.ScanDocumentsAddressNameDescription = textBox_DescriptionReference.Text;
            ScanDocumentAddressItem.ScanDocumentsAddressValueDirectory = textBox_DirectoryPathFolder.Text;
            ScanDocumentAddressItem.SaveConvertedFilesTo = textBox_SaveConvertedFilesTo.Text;
            ScanDocumentAddressItem.ScanDocumentsExtensionAcepted = ExtAcepted;
            ScanDocumentAddressItem.AccessLevel = AccessLevel;
        }
    }
}

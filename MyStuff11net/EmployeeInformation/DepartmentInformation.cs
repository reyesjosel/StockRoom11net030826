using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Text;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;

namespace MyStuff11net
{
    public class DepartmentInformation
    {
        string MessagePositionString = "";
        public string SpliterCharacter
        {
            get
            {
                return "&";
            }
            private set { }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region"Save_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Save_Requested_EventHandler Save_Requested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Save_Requested(Save_Requested_EventArgs e)
        {
            // If an event has no subscriber registerd, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (Save_Requested != null)
            {
                // Notify Subscribers
                Save_Requested(this, e);
            }
        }
        #endregion

        public DepartmentInformation()
        {
            try
            {
                MessagePositionString = "ID=0";
                ID = 0;
                DeptID = 123456;
                DeptName = "No set to any department yet";

                DeptComments = "";
                DeptTelephone = "";
                HireDate = DateTime.Now;
                Size = "";
                Position = "";
                Department = "Department";

                DeptRights = MyCode.GetDict("AccessLevel:0;EditMode:0;EnableTreeViewSetting:0");

                DeptEditMode = MyCode.EditMode.View;
                DeptAccessLevel = MyCode.AccessLevel.User;

                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                DataGridViewSettingDict = new Dictionary<string, List<ColumnSetting>>();

                MessagePositionString = "defaultDocumentsLocation";
                string defaultDocumentsLocation = Path.Combine(MyStuff11net.Properties.Settings.Default.DataBaseAddress, "DataSheets");
                DocumentsAddressProcess("12345" + SpliterCharacter + "Private" + SpliterCharacter + "Description for Default Documents Location" +
                                                                                                SpliterCharacter + defaultDocumentsLocation);
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

        /// <summary>
        /// Initialize a new DeptInformation with this DataRowView,
        /// if it's null no department is defined.
        /// </summary>
        /// <param name="departmentRow"></param>
        public DepartmentInformation(DataRowView departmentRow)
        {
            if (departmentRow == null)
            {
                new DepartmentInformation();
                return;
            }

            try
            {
                DepartmentRow = departmentRow;

                MessagePositionString = "Column ID.";
                ID = MyCode.CastAsInt(DepartmentRow["ID"]);
                DeptID = MyCode.CastAsInt(DepartmentRow["Last6Digit"]);
                DeptName = DepartmentRow["Name"].ToString();
                DeptComments = DepartmentRow["LastName"].ToString();
                DepartmentDocumentsProcess(DepartmentRow["Address"].ToString());
                DeptTelephone = DepartmentRow["Telephone"].ToString();
                HireDate = MyCode.CastAs(DepartmentRow["HireDate"], DateTime.Now);
                Size = DepartmentRow["Size"].ToString();
                Position = DepartmentRow["Position"].ToString();
                Department = DepartmentRow["Department"].ToString();

                DeptRights = MyCode.GetDict(DepartmentRow["AccessLevel"].ToString(), DeptRights);
                DeptEditMode = (MyCode.EditMode)DeptRights["EditMode"];
                DeptAccessLevel = (MyCode.AccessLevel)DeptRights["AccessLevel"];
                AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DeptRights["AutoSizeColumnsMode"];

                MessagePositionString = "Initialize employees.";
                InitializeDepartment();
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

        readonly bool toTest = true;
        private void InitializeDepartment()
        {
            #region"DataGridViewSetting"

            var dataGridViewSetting = new Dictionary<string, List<ColumnSetting>>();

            var _dataGridViewString = new StringCollection();

            if (DepartmentRow == null)
                return;

            _dataGridViewString.AddRange(DepartmentRow[@"DataGridViewSetting"].ToString().Split('#'));

            foreach (string datagridview in _dataGridViewString)
            {
                if (string.IsNullOrEmpty(datagridview) || string.IsNullOrWhiteSpace(datagridview))
                    continue;

                var ColumnsSetting = new List<ColumnSetting>();

                if (!(datagridview.Contains('|')))
                    continue;

                var name = datagridview.Substring(0, datagridview.IndexOf('|', 0));
                var columns = datagridview.Replace(name + '|', "");

                var columnsCollection = new StringCollection();
                columnsCollection.AddRange(columns.Split(';'));

                foreach (string columnsetting in columnsCollection)
                {
                    if (string.IsNullOrEmpty(columnsetting) || string.IsNullOrWhiteSpace(columnsetting))
                        continue;

                    ColumnsSetting.Add(new ColumnSetting(columnsetting));
                }

                dataGridViewSetting.Add(name, ColumnsSetting);
            }

            DataGridViewSettingDict = dataGridViewSetting;

            #endregion"DataGridViewSetting"

            if (toTest)
                return;
            else
            {
                #region"DeptSettingDict"

                var deptSettingDict = new Dictionary<string, DeptSetting>();

                var _userSettingString = new StringCollection();

                _userSettingString.AddRange(DepartmentRow["UserSetting"].ToString().Split('#'));

                foreach (string deptSetting in _userSettingString)
                {
                    if (string.IsNullOrEmpty(deptSetting) || string.IsNullOrWhiteSpace(deptSetting))
                        continue;

                    var name = deptSetting.Substring(0, deptSetting.IndexOf('|', 0));
                    var settings = deptSetting.Replace(name + '|', "");

                    var DeptSetting = new DeptSetting(settings);

                    deptSettingDict.Add(name, DeptSetting);
                }

                DeptSettingDict = deptSettingDict;

                #endregion"DeptSettingDict"
            }
        }

        /// <summary>
        /// Employee rights and permissions to edit, delete and configure the interface. permits are:
        /// AccessLevel, EditMode, EnableTreeViewSetting, AutoSizeColumnsMode.
        /// </summary>
        SortedDictionary<string, int> DeptRights = new SortedDictionary<string, int>
            {
                {@"AccessLevel", 0},
                {@"EditMode", 0},
                {@"EnableTreeViewSetting", 0},
                {@"AutoSizeColumnsMode", 1}
            };

        private DataRowView DepartmentRow;

        public int Index;
        /// <summary>
        /// Rom id, identified the rom into the table.
        /// </summary>
        public int ID;

        public int DeptID;

        /// <summary>
        /// Department name.
        /// </summary>
        public string DeptName { get; set; }// = "No set to any department yet";

        /// <summary>
        /// Any comment about it depart. We use column "LastName" to store the information into the database.
        /// </summary>
        public string DeptComments = "";

        /// <summary>
        /// Department telephone if exist one.
        /// </summary>
        public string DeptTelephone = "";
        public DateTime Dob = DateTime.Now;
        public DateTime HireDate = DateTime.Now;
        public string DeptSetting = "";
        public string DataGridViewSetting = "";
        public string Position = "";
        public string Department { get; set; }
        public string AccessLevel = "";
        public string Size = "";
        public string Status = "";
        public string Properties { get; set; }

        public SortedDictionary<string, bool> AvailableMenus { get; set; }




        #region"These are packed in the Dictionary, we need to update this to reflect changes."

        public MyCode.AccessLevel DeptAccessLevel
        {
            get
            {
                return (MyCode.AccessLevel)DeptRights["AccessLevel"];
            }

            set
            {
                DeptRights["AccessLevel"] = (int)value;
            }
        }

        public MyCode.EditMode DeptEditMode
        {
            get
            {
                return (MyCode.EditMode)DeptRights["EditMode"];
            }

            set
            {
                DeptRights["EditMode"] = (int)value;
            }
        }

        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
        {
            get
            {
                return (DataGridViewAutoSizeColumnsMode)DeptRights["AutoSizeColumnsMode"];
            }

            set
            {
                DeptRights["AutoSizeColumnsMode"] = (int)value;
            }
        }

        #endregion"These are packed in the Dictionary, we need to update this to reflect changes."

        public string FullName
        {
            get
            {
                return DeptName;
            }

            private set { }
        }

        public bool IsViewMode
        {
            get
            {
                if ((MyCode.EditMode)DeptRights["EditMode"] == MyCode.EditMode.View)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsEditMode
        {
            get
            {
                if ((MyCode.EditMode)DeptRights["EditMode"] == MyCode.EditMode.Edit)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsDeleteMode
        {
            get
            {
                if ((MyCode.EditMode)DeptRights["EditMode"] == MyCode.EditMode.Delete)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsAddMode
        {
            get
            {
                if ((MyCode.EditMode)DeptRights["EditMode"] == MyCode.EditMode.Add)
                    return true;

                return false;
            }

            private set { }
        }



        /// <summary>
        /// If Department field contain Department, return true.
        /// We process department as an employee.
        /// </summary>
        public bool IsDepartment
        {
            get
            {
                if (Department.Contains("Department"))
                    return true;

                return false;
            }

            private set { }
        }

        /// <summary>
        /// The column "Address" in "Table_Employees" is used to store tis information...
        /// </summary>
        /// <param name="departmentDocumentSet"></param>
        void DepartmentDocumentsProcess(string departmentDocumentSet)
        {
            var DepartmentDocumentSet = departmentDocumentSet.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string documentsAddressSet in DepartmentDocumentSet)
            {
                if (documentsAddressSet.Contains("PdfDoc"))
                    DocumentsAddressProcess(documentsAddressSet);

                if (documentsAddressSet.Contains("ScanDoc"))
                    ScanDocumentsAddressProcess(documentsAddressSet);
            }
        }

        #region"Department DocumentAddressItem"

        /// <summary>
        /// List of PathRootFolder of this department.
        /// </summary>
        public List<string> DocumentsPathRootFolder = new List<string>();

        public List<DocumentsAddressItem> DepartmentDocumentsAddressItems = new List<DocumentsAddressItem>();

        /// <summary>
        /// Add a DocumentAddressItem to the Department....
        /// </summary>
        /// <param name="documentsAddressItem"></param>
        public void AddDocumentAddressItem(DocumentsAddressItem documentsAddressItem)
        {
            if (DepartmentDocumentsAddressItems.Contains(documentsAddressItem))
                return;

            DepartmentDocumentsAddressItems.Add(documentsAddressItem);

            SaveSetting();
        }

        /// <summary>
        /// UpDate an existent DocumentAddressItem...
        /// </summary>
        /// <param name="documentsAddressItem"></param>
        public void UpDateDocumentAddressItem(DocumentsAddressItem documentsAddressItem)
        {
            var index = DepartmentDocumentsAddressItems.FindIndex(item => item.ID == documentsAddressItem.ID);

            DepartmentDocumentsAddressItems[index] = documentsAddressItem;

            SaveSetting();
        }

        void DocumentsAddressProcess(string documentsAddressSetting)
        {
            //Set the default value...
            var defaulDocumentsLocation = "12345" + SpliterCharacter + "Private" + SpliterCharacter + "Description for default dataSheets location" + SpliterCharacter +
                                          Path.Combine(MyStuff11net.Properties.Settings.Default.DataBaseAddress, "DataSheets") + SpliterCharacter + "*.doc,*.docx,*.pdf";

            if (string.IsNullOrWhiteSpace(documentsAddressSetting))
                documentsAddressSetting = defaulDocumentsLocation;

            var documentAddressItem = new DocumentsAddressItem(documentsAddressSetting);
            DocumentsPathRootFolder.Add(documentAddressItem.DocumentsAddressValueDirectory);
            DepartmentDocumentsAddressItems.Add(documentAddressItem);
        }

        /// <summary>
        /// Serialize each instance of DocumentsAddressItem in List<DocumentsAddressItem> DocumentsAddress.
        /// </summary>
        /// <returns></returns>
        string DocumentsAddressToString()
        {
            var documentsAddressString = "";
            var builder = new StringBuilder();
            builder.Append(documentsAddressString);

            foreach (DocumentsAddressItem item in DepartmentDocumentsAddressItems)
            {
                builder.Append(item.DocumentsAddressSet + ";");
            }

            documentsAddressString = builder.ToString();

            return documentsAddressString;
        }

        #endregion"Department DocumentAddressItem"

        #region"Department ScanDocumentAddressItem"

        /// <summary>
        /// List of ScanPathRootFolder of this department.
        /// </summary>
        public List<string> ScanDocumentsPathRootFolder = new List<string>();

        public List<ScanDocumentsAddressItem> DepartmentScanDocumentsAddressItems = new List<ScanDocumentsAddressItem>();

        /// <summary>
        /// Add a ScanDocumentAddressItem to the Department....
        /// </summary>
        /// <param name="scandocumentsAddressItem"></param>
        public void AddScanDocumentAddressItem(ScanDocumentsAddressItem scandocumentsAddressItem)
        {
            if (DepartmentScanDocumentsAddressItems.Contains(scandocumentsAddressItem))
                return;

            DepartmentScanDocumentsAddressItems.Add(scandocumentsAddressItem);

            SaveSetting();
        }

        /// <summary>
        /// UpDate an existent ScanDocumentAddressItem...
        /// </summary>
        /// <param name="documentsAddressItem"></param>
        /// <param name="scanDocumentsAddressItem">todo: describe scanDocumentsAddressItem parameter on UpDateScanDocumentAddressItem</param>
        public void UpDateScanDocumentAddressItem(ScanDocumentsAddressItem scanDocumentsAddressItem)
        {
            var index = DepartmentScanDocumentsAddressItems.FindIndex(item => item.ID == scanDocumentsAddressItem.ID);

            DepartmentScanDocumentsAddressItems[index] = scanDocumentsAddressItem;

            SaveSetting();
        }

        void ScanDocumentsAddressProcess(string scanDocumentsAddressSetting)
        {
            //Set the default value...
            var defaulScanDocumentsLocation = "12345" + SpliterCharacter + "Private" + SpliterCharacter + "Description for default dataSheets location" +
                                                        SpliterCharacter + Path.Combine(MyStuff11net.Properties.Settings.Default.DataBaseAddress, "DataSheets") +
                                                        SpliterCharacter + "*.doc,*.docx,*.pdf" + SpliterCharacter + "Default location PDF";

            if (string.IsNullOrWhiteSpace(scanDocumentsAddressSetting))
                scanDocumentsAddressSetting = defaulScanDocumentsLocation;

            var scanDocumentAddressItem = new ScanDocumentsAddressItem(scanDocumentsAddressSetting);
            ScanDocumentsPathRootFolder.Add(scanDocumentAddressItem.ScanDocumentsAddressValueDirectory);
            DepartmentScanDocumentsAddressItems.Add(scanDocumentAddressItem);
        }

        /// <summary>
        /// Serialize each instance of ScanDocumentsAddressItem in List<ScanDocumentsAddressItem> ScanDocumentsAddress.
        /// </summary>
        /// <returns></returns>
        string ScanDocumentsAddressToString()
        {
            var scanDocumentsAddressString = "";
            var builder = new StringBuilder();
            builder.Append(scanDocumentsAddressString);

            foreach (ScanDocumentsAddressItem item in DepartmentScanDocumentsAddressItems)
            {
                builder.Append(item.ScanDocumentsAddressSet + ";");
            }

            scanDocumentsAddressString = builder.ToString();

            return scanDocumentsAddressString;
        }

        #endregion"Department ScanDocumentAddressItem"

        string PathDocumentPathScanDocxToString()
        {
            var pathDocumentPDFPathScanDocx = "";
            var documentAddressString = DocumentsAddressToString();
            var scanDocumentAddressString = ScanDocumentsAddressToString();

            pathDocumentPDFPathScanDocx = documentAddressString + ";" + scanDocumentAddressString;

            return pathDocumentPDFPathScanDocx;
        }

        public DeptSetting DeptSettingList(string DeptSettingName)
        {
            return DeptSettingDict[DeptSettingName + "_DeptSetting"];
        }

        /// <summary>
        /// Test if the current depart have any setting information about EditMode, AutoSizeColumnMode,
        /// </summary>
        /// <param name="DeptSettingName">todo: describe DeptSettingName parameter on ContainsDeptSetting</param>
        /// <returns></returns>
        public bool ContainsDeptSetting(string DeptSettingName)
        {
            if (DeptSettingDict.ContainsKey(DeptSettingName + "_DeptSetting"))
                if (DeptSettingDict[DeptSettingName + "_DeptSetting"] != null)
                    return true;

            return false;
        }

        Dictionary<string, DeptSetting> _deptSettingDict;
        /// <summary>
        /// Because there can be more than one DataGridView in the user-application
        /// a dictionary is used to save the settings for this different DataGridView.
        /// As key the name of the DataGridView is used.
        /// </summary>
        public Dictionary<string, DeptSetting> DeptSettingDict
        {
            get
            {
                return _deptSettingDict;
            }
            set
            {
                _deptSettingDict = value;
            }
        }

        private string DeptSettingDict_to_String()
        {
            if (DeptSettingDict == null)
                return "";

            //Build up each line one by one and them trim the end
            var builder = new StringBuilder();
            foreach (KeyValuePair<string, DeptSetting> pair in DeptSettingDict)
            {
                if (string.IsNullOrEmpty(pair.Value.ToString()) || string.IsNullOrWhiteSpace(pair.Value.ToString()))
                {
                    MessageBox.Show("Error in string information, Dictionary format is as follows 'NameControl:ColumnSetting', " + pair.Key +
                        " : ColumnSetting", "Dictionary information loss in DataGridViewSetting procedure.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                builder.Append(pair.Key).Append("|");

                DeptSetting SettingList = pair.Value;

                builder.Append(SettingList.ToString());

                builder.Append("#");
            }

            string result = builder.ToString();
            //Remove the final delimiter
            result = result.TrimEnd('#');

            return result;
        }

        /// <summary>
        /// Test if this particular DataGridview (e.DataGridViewName) have depart setting information
        /// if is true save the information DeptSetting back to the Dict.
        /// if is false, add new key DeptSettingName + "_DeptSetting" : DeptSetting to Dict.
        /// </summary>
        /// <param name="DeptSettingName">todo: describe DeptSettingName parameter on SaveDeptSetting</param>
        /// <param name="deptSetting">todo: describe deptSetting parameter on SaveDeptSetting</param>
        /// <param name="columns">todo: describe columns parameter on SaveDeptSetting</param>
        /// <param name="autoSizeColumnsMode">todo: describe autoSizeColumnsMode parameter on SaveDeptSetting</param>
        public void SaveDeptSetting(string DeptSettingName, DeptSetting deptSetting, DataGridViewColumnCollection columns,
                                                                            DataGridViewAutoSizeColumnsMode autoSizeColumnsMode)
        {
            DeptRights[@"AutoSizeColumnsMode"] = (int)autoSizeColumnsMode;

            #region"DeptSetting"

            if (DeptSettingDict.ContainsKey(DeptSettingName + "_DeptSetting"))
            {
                DeptSettingDict[DeptSettingName + "_DeptSetting"] = deptSetting;
            }
            else
            {
                DeptSettingDict.Add(DeptSettingName + "_DeptSetting", deptSetting);
            }

            #endregion"DeptSetting"

            #region"ColumnSetting"

            var columnSettingList = new List<ColumnSetting>();

            foreach (DataGridViewColumn column in columns)
            {
                columnSettingList.Add(new ColumnSetting(column));
            }

            if (DataGridViewSettingDict.ContainsKey(DeptSettingName + "_ColumnsSettingList"))
            {
                DataGridViewSettingDict[DeptSettingName + "_ColumnsSettingList"] = columnSettingList;
            }
            else
            {
                DataGridViewSettingDict.Add(DeptSettingName + "_ColumnsSettingList", columnSettingList);
            }

            #endregion"ColumnSetting"

            SaveSetting();
        }

        public void SaveSetting()
        {
            DepartmentRow.BeginEdit();

            DepartmentRow["Index"] = ID;
            DepartmentRow["ID"] = ID;
            DepartmentRow["Last6digit"] = DeptID;
            DepartmentRow["LastName"] = DeptComments;
            DepartmentRow["Name"] = DeptName;
            DepartmentRow["Address"] = PathDocumentPathScanDocxToString();
            DepartmentRow["Telephone"] = DeptTelephone;
            DepartmentRow["Dob"] = Dob;
            DepartmentRow["HireDate"] = HireDate;
            DepartmentRow["UserSetting"] = DeptSettingDict_to_String();
            DepartmentRow["DataGridViewSetting"] = DataGridViewSettingDict_to_String();
            DepartmentRow["Position"] = Position;
            DepartmentRow["Department"] = "Department"; //Department is Department.
            DepartmentRow["AccessLevel"] = MyCode.GetString(DeptRights);
            DepartmentRow["Size"] = Size;
            DepartmentRow["Status"] = Status;

            DepartmentRow.EndEdit();

            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DepartmentInformationChange, DepartmentRow));
        }

        #region"ColumnSetting for this specific DataGridView"

        /// <summary>
        /// Return a List of ColumnSetting for this specific DataGridView.
        /// </summary>
        /// <param name="DataGridViewName"></param>
        /// <returns></returns>
        public List<ColumnSetting> ColumnSettingList(string DataGridViewName)
        {
            return DataGridViewSettingDict[DataGridViewName + "_ColumnsSettingList"];
        }

        /// <summary>
        /// Test if the current user have any setting information about column setting list.
        /// </summary>
        /// <param name="DataGridViewName"></param>
        /// <returns></returns>
        public bool ContainsDataGridViewColumnsSettingList(string DataGridViewName)
        {
            if (DataGridViewSettingDict == null)
                return false;

            if (DataGridViewSettingDict.ContainsKey(DataGridViewName + "_ColumnsSettingList"))
                if (DataGridViewSettingDict[DataGridViewName + "_ColumnsSettingList"] != null)
                    return true;

            return false;
        }

        Dictionary<string, List<ColumnSetting>> _dataGridViewSettingDict;
        /// <summary>
        /// Because there can be more than one DataGridView in the user-application
        /// a dictionary is used to save the settings for this different DataGridView.
        /// As key the name of the DataGridView + "_ColumnsSettingList" is used.
        /// </summary>
        public Dictionary<string, List<ColumnSetting>> DataGridViewSettingDict
        {
            get
            {
                return _dataGridViewSettingDict;
            }
            set
            {
                _dataGridViewSettingDict = value;
            }
        }

        string DataGridViewSettingDict_to_String()
        {
            var builder = new StringBuilder();
            foreach (KeyValuePair<string, List<ColumnSetting>> pair in DataGridViewSettingDict)
            {
                if (string.IsNullOrEmpty(pair.Value.ToString()) || string.IsNullOrWhiteSpace(pair.Value.ToString()))
                {
                    MessageBox.Show("Error in string information, Dictionary format is as follows 'NameControl:ColumnSetting', " + pair.Key +
                        " : ColumnSetting", "Dictionary information loss in DataGridViewSetting procedure.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                builder.Append(pair.Key).Append("|");

                List<ColumnSetting> ColumnList = pair.Value;

                foreach (ColumnSetting columnSetting in ColumnList)
                {
                    builder.Append(columnSetting.ToString()).Append(';');
                }

                builder.Append("#");
            }

            string result = builder.ToString();
            //Remove the final delimiter
            result = result.TrimEnd('#');

            result = result.TrimEnd(';');

            return result;
        }



        #endregion"ColumnSetting for this specific DataGridView"

    }

    [Serializable]
    public sealed class DeptSetting
    {
        public DeptSetting()
        {
            CustomEdit = MyCode.EditMode.View;
            AccessLevel = MyCode.AccessLevel.User;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        public DeptSetting(string settingString)
        {
            var settingCollection = new StringCollection();
            settingCollection.AddRange(settingString.Split(','));

            AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)int.Parse(settingCollection[0]);
            CustomEdit = (MyCode.EditMode)int.Parse(settingCollection[1]);
        }

        public DeptSetting(DataGridViewAutoSizeColumnsMode autoSizeColumnsMode, MyCode.EditMode customEdit)
        {
            AutoSizeColumnsMode = autoSizeColumnsMode;
            CustomEdit = customEdit;
        }

        public override string ToString()
        {
            //Build up each line one by one and them trim the end
            var builder = new StringBuilder();

            builder.Append((int)AutoSizeColumnsMode).Append(",");
            builder.Append((int)CustomEdit).Append(",");

            string result = builder.ToString();
            //Remove the final delimiter
            result = result.TrimEnd(',');

            return result;
        }


        public MyCode.EditMode CustomEdit { get; set; }
        public MyCode.AccessLevel AccessLevel { get; set; }
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get; set; }

    }

}

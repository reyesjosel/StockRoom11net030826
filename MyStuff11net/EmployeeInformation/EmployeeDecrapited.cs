using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Text;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;

namespace MyStuff11net
{
    public class Employee : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            Save_Requested?.Invoke(this, e);
        }
        #endregion

        string MessagePositionString = "";

        public Employee()
        {
            ID = 0;
            Name = "No user LogIn";
            LastName = "";
            Address = "";
            Telephone = "";
            HireDate = DateTime.Now;
            Size = "";
            Position = "";
            Department = "";

            EmployeeRights = MyCode.GetDict("AccessLevel:0;EditMode:0;EnableTreeViewSetting:0");

            EmployeeEditMode = MyCode.EditMode.View;
            EmployeeAccessLevel = MyCode.AccessLevel.User;
            EmployeeEnableTreeViewSetting = MyCode.EnableSetting.False;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            DataGridViewSettingDict = new Dictionary<string, List<ColumnSetting>>();
        }

        /// <summary>
        /// Initialize a new EmployeesInformation with this DataRowView,
        /// if it's null no employee logged in.
        /// </summary>
        /// <param name="employeesRow"></param>
        public Employee(DataRowView employeesRow)
        {
            if (employeesRow == null)
                return;

            try
            {
                EmployeesRow = employeesRow;

                MessagePositionString = "Column ID.";
                ID = MyCode.CastAsInt(EmployeesRow["ID"]);

                MessagePositionString = "Column Last6Digit.";
                Last6Digit = MyCode.CastAsInt(EmployeesRow["Last6Digit"]);

                MessagePositionString = "Column Name.";
                Name = EmployeesRow["Name"].ToString();

                MessagePositionString = "Column LastName.";
                LastName = EmployeesRow["LastName"].ToString();

                MessagePositionString = "Column Address.";
                Address = EmployeesRow["Address"].ToString();

                MessagePositionString = "Column Telephone.";
                Telephone = EmployeesRow["Telephone"].ToString();

                MessagePositionString = "Column HireDate.";
                HireDate = MyCode.CastAs(EmployeesRow["HireDate"], DateTime.Now);

                MessagePositionString = "Column Size.";
                Size = EmployeesRow["Size"].ToString();

                MessagePositionString = "Column Position.";
                Position = EmployeesRow["Position"].ToString();

                MessagePositionString = "Column Department.";
                Department = EmployeesRow["Department"].ToString();

                MessagePositionString = "Column AccessLevel.";
                EmployeeRights = MyCode.GetDict(EmployeesRow["AccessLevel"].ToString(), EmployeeRights);

                MessagePositionString = "Dictionary EditMode.";
                EmployeeEditMode = (MyCode.EditMode)EmployeeRights["EditMode"];

                MessagePositionString = "Dictionary AccessLevel.";
                EmployeeAccessLevel = (MyCode.AccessLevel)EmployeeRights["AccessLevel"];

                MessagePositionString = "Dictionary EnableTreeViewSetting.";
                EmployeeEnableTreeViewSetting = (MyCode.EnableSetting)EmployeeRights["EnableTreeViewSetting"];
                AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)EmployeeRights["AutoSizeColumnsMode"];

                MessagePositionString = "Initialize employees.";
                _userSettingDict = new Dictionary<string, UserSetting>();
                InitializeEmployees();
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, "The constructor has found an error " + error.Message + " at position " +
                                        MessagePositionString, "EmployeesInformation Class error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Employee(string employeesID)
        {
            if (!employeesID.Contains("811266"))
                return;

            try
            {
                ID = 811266;
                Last6Digit = 811266;
                Name = "Jose";
                LastName = "Reyes";
                Address = "";
                Telephone = "";
                HireDate = DateTime.Now;
                Size = "D";
                Position = "Manager";
                Department = "";
                EmployeeRights = MyCode.GetDict("AccessLevel:3;AutoSizeColumnsMode:1;EditMode:3;EnableTreeViewSetting:1", EmployeeRights);
                EmployeeEditMode = MyCode.EditMode.Delete;
                EmployeeAccessLevel = MyCode.AccessLevel.Manager;
                EmployeeEnableTreeViewSetting = MyCode.EnableSetting.False;
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                _userSettingDict = new Dictionary<string, UserSetting>();
                InitializeEmployees();
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, "The constructor has found an error " + error.Message + " at position ",
                                                            "EmployeesInformation Class error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEmployees()
        {
            #region"DataGridViewSetting"

            Dictionary<string, List<ColumnSetting>> dataGridViewSetting = new Dictionary<string, List<ColumnSetting>>();

            StringCollection _dataGridViewString = new StringCollection();

            if (EmployeesRow == null)
                return;

            _dataGridViewString.AddRange(EmployeesRow["DataGridViewSetting"].ToString().Split('#'));

            foreach (string datagridview in _dataGridViewString)
            {
                if (string.IsNullOrEmpty(datagridview) || string.IsNullOrWhiteSpace(datagridview))
                    continue;

                List<ColumnSetting> ColumnsSetting = new List<ColumnSetting>();

                if (!(datagridview.Contains('|')))
                    continue;

                string name = datagridview.Substring(0, datagridview.IndexOf('|', 0));
                string columns = datagridview.Replace(name + '|', "");

                StringCollection columnsCollection = new StringCollection();
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

            #region"UserSettingDict"

            Dictionary<string, UserSetting> userSettingDict = new Dictionary<string, UserSetting>();

            StringCollection _userSettingString = new StringCollection();

            _userSettingString.AddRange(EmployeesRow["UserSetting"].ToString().Split('#'));

            foreach (string userSetting in _userSettingString)
            {
                if (string.IsNullOrEmpty(userSetting) || string.IsNullOrWhiteSpace(userSetting))
                    continue;

                MessagePositionString = "UserSetting";
                UserSetting UserSetting = new UserSetting(userSetting);

                MessagePositionString = "userSettingDict.Add";
                userSettingDict.Add(UserSetting.Name, UserSetting);
            }

            UserSettingDict = userSettingDict;

            #endregion"UserSettingDict"

        }

        /// <summary>
        /// Employee rights and permissions to edit, delete and configure the interface. permits are:
        /// AccessLevel, EditMode, EnableTreeViewSetting, AutoSizeColumnsMode.
        /// </summary>
        private readonly SortedDictionary<string, int> EmployeeRights = new SortedDictionary<string, int>()
            {
                {"AccessLevel", 0},
                {"EditMode", 0},
                {"EnableTreeViewSetting", 0},
                {"AutoSizeColumnsMode", 1}
            };

        private readonly DataRowView EmployeesRow;

        public int Index;
        public int ID;
        public int? ManagerId;
        public int Last6Digit;
        public string LastName = "";
        public string Name = "Not user login.";
        public string Address = "";
        public string Telephone = "";
        public DateTime Dob = DateTime.Now;
        public DateTime HireDate = DateTime.Now;
        public string UserSetting = "";
        public string DataGridViewSetting = "";
        public string Position = "";
        public string Department = "";
        public string Size = "";
        public string Status = "";


        #region"These are packed in the Dictionary, we need to update this to reflect changes."

        public MyCode.AccessLevel EmployeeAccessLevel
        {
            get
            {
                return (MyCode.AccessLevel)EmployeeRights["AccessLevel"];
            }

            set
            {
                EmployeeRights["AccessLevel"] = (int)value;
            }
        }

        public MyCode.EditMode EmployeeEditMode
        {
            get
            {
                return (MyCode.EditMode)EmployeeRights["EditMode"];
            }

            set
            {
                EmployeeRights["EditMode"] = (int)value;
            }
        }

        public MyCode.EnableSetting EmployeeEnableTreeViewSetting
        {
            get
            {
                return (MyCode.EnableSetting)EmployeeRights["EnableTreeViewSetting"];
            }

            set
            {
                EmployeeRights["EnableTreeViewSetting"] = (int)value;
            }
        }

        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
        {
            get
            {
                return (DataGridViewAutoSizeColumnsMode)EmployeeRights["AutoSizeColumnsMode"];
            }

            set
            {
                EmployeeRights["AutoSizeColumnsMode"] = (int)value;
            }
        }

        #endregion"These are packed in the Dictionary, we need to update this to reflect changes."

        public string FullName
        {
            get
            {
                return Name + " " + LastName;
            }

            private set { }
        }

        public bool IsViewMode
        {
            get
            {
                if ((MyCode.EditMode)EmployeeRights["EditMode"] == MyCode.EditMode.View)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsEditMode
        {
            get
            {
                if ((MyCode.EditMode)EmployeeRights["EditMode"] == MyCode.EditMode.Edit)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsDeleteMode
        {
            get
            {
                if ((MyCode.EditMode)EmployeeRights["EditMode"] == MyCode.EditMode.Delete)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsAddMode
        {
            get
            {
                if ((MyCode.EditMode)EmployeeRights["EditMode"] == MyCode.EditMode.Add)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsManager
        {
            get
            {
                if ((MyCode.AccessLevel)EmployeeRights["AccessLevel"] == MyCode.AccessLevel.Manager)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsAdministrator
        {
            get
            {
                if ((MyCode.AccessLevel)EmployeeRights["AccessLevel"] == MyCode.AccessLevel.Administrator)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsEditor
        {
            get
            {
                if ((MyCode.AccessLevel)EmployeeRights["AccessLevel"] == MyCode.AccessLevel.Editor)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsUser
        {
            get
            {
                if ((MyCode.AccessLevel)EmployeeRights["AccessLevel"] == MyCode.AccessLevel.User)
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
        /// Test the Access Level, if is User return true, if warning is true
        /// ShowMessageBox, "The current User, does not have the right to perform this action.", "Warning, access denied."
        /// </summary>
        /// <param name="Warning"></param>
        /// <returns></returns>
        public bool IsUserLevel(bool Warning)
        {
            if (IsUser)
            {
                if (Warning)
                    MessageBox.Show("The current User, does not have the right to perform this action.", "Warning, access denied.",
                                                                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Return a UserSettingList for this specific control. 
        /// </summary>
        /// <param name="DataGridViewName"></param>
        /// <param name="userSettingName">todo: describe userSettingName parameter on UserSettingList</param>
        /// <returns></returns>
        public UserSetting UserSettingList(string userSettingName)
        {
            return UserSettingDict[userSettingName + "_UserSetting"];
        }

        /// <summary>
        /// Test if the current user have any setting information about EditMode, AutoSizeColumnMode,
        /// 
        /// </summary>
        /// <param name="DataGridViewName"></param>
        /// <returns></returns>
        public bool ContainsUserSetting(string userSettingName)
        {
            if (UserSettingDict.ContainsKey(userSettingName + "_UserSetting"))
                if (UserSettingDict[userSettingName + "_UserSetting"] != null)
                    return true;

            return false;
        }

        private Dictionary<string, UserSetting> _userSettingDict;
        /// <summary>
        /// Because there can be more than one DataGridView in the user-application
        /// a dictionary is used to save the settings for this different DataGridView.
        /// As key the name of the DataGridView is used.
        /// </summary>
        public Dictionary<string, UserSetting> UserSettingDict
        {
            get
            {
                return _userSettingDict;
            }
            set
            {
                _userSettingDict = value;
            }
        }

        private string UserSettingDict_to_String()
        {
            //Build up each line one by one and them trim the end
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, UserSetting> pair in UserSettingDict)
            {
                if (string.IsNullOrEmpty(pair.Value.ToString()) || string.IsNullOrWhiteSpace(pair.Value.ToString()))
                {
                    MessageBox.Show("Error in string information, Dictionary format is as follows 'NameControl:ColumnSetting', " + pair.Key +
                        " : ColumnSetting", "Dictionary information loss in DataGridViewSetting procedure.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                builder.Append(pair.Key).Append("|");

                UserSetting SettingList = pair.Value;

                builder.Append(SettingList.ToString());

                builder.Append("#");
            }

            string result = builder.ToString();
            //Remove the final delimiter
            result = result.TrimEnd('#');

            return result;
        }

        /// <summary>
        /// Test if this particular DataGridView (e.DataGridViewName) have user setting information
        /// if is true save the information UserSetting back to the Dict.
        /// if is false, add new key UserSettingName + "_UserSetting" : UserSetting to Dict.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="UserSettingName">todo: describe UserSettingName parameter on SaveUserSetting</param>
        /// <param name="userSetting">todo: describe userSetting parameter on SaveUserSetting</param>
        /// <param name="columns">todo: describe columns parameter on SaveUserSetting</param>
        /// <param name="autoSizeColumnsMode">todo: describe autoSizeColumnsMode parameter on SaveUserSetting</param>
        public void SaveUserSetting(string UserSettingName, UserSetting userSetting, DataGridViewColumnCollection columns,
                                                                            DataGridViewAutoSizeColumnsMode autoSizeColumnsMode)
        {
            EmployeeRights["AutoSizeColumnsMode"] = (int)autoSizeColumnsMode;

            #region"UserSetting"

            if (UserSettingDict == null)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"UserSettingDict not been initialized properly...",
                                                               @"Employees Information has generated an error.",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UserSettingDict.ContainsKey(UserSettingName + "_UserSetting"))
            {
                UserSettingDict[UserSettingName + "_UserSetting"] = userSetting;
            }
            else
            {
                UserSettingDict.Add(UserSettingName + "_UserSetting", userSetting);
            }

            #endregion"UserSetting"

            UpDateColumnsSetting(UserSettingName, columns);

            SaveSetting();
        }

        /// <summary>
        /// UpDate the UserSetting field call On_Save_Requested.
        /// </summary>
        /// <param name="UserSettingName"></param>
        /// <param name="userSetting"></param>
        public void SaveUserSetting(string UserSettingName, UserSetting userSetting)
        {
            if (EmployeesRow == null)
                return;

            #region"UserSetting"

            if (UserSettingDict == null)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"UserSettingDict not been initialized properly...",
                                                               @"Employees Information has generated an error.",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UserSettingDict.ContainsKey(UserSettingName + "_UserSetting"))
            {
                UserSettingDict[UserSettingName + "_UserSetting"] = userSetting;
            }
            else
            {
                UserSettingDict.Add(UserSettingName + "_UserSetting", userSetting);
            }

            #endregion"UserSetting"

            EmployeesRow.BeginEdit();
            EmployeesRow["UserSetting"] = UserSettingDict_to_String();
            EmployeesRow.EndEdit();

            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.EmployeesInformationChange, EmployeesRow));
        }

        public void SaveColumnsSetting(string UserSettingName, DataGridViewColumnCollection columns)
        {
            if (EmployeesRow == null)
                return;

            UpDateColumnsSetting(UserSettingName, columns);

            EmployeesRow.BeginEdit();
            EmployeesRow["DataGridViewSetting"] = DataGridViewSettingDict_to_String();
            EmployeesRow.EndEdit();

            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.EmployeesInformationChange, EmployeesRow));
        }

        public void UpDateColumnsSetting(string UserSettingName, DataGridViewColumnCollection columns)
        {
            if (DataGridViewSettingDict == null)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"DataGridViewSettingDict not been initialized properly...",
                                                               @"Employees Information has generated an error.",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DataGridViewSettingDict.ContainsKey(UserSettingName))
                DataGridViewSettingDict.Remove(UserSettingName);

            List<ColumnSetting> columnSettingList = new List<ColumnSetting>();
            foreach (DataGridViewColumn column in columns)
            {
                columnSettingList.Add(new ColumnSetting(column));
            }

            DataGridViewSettingDict.Add(UserSettingName, columnSettingList);
        }


        /// <summary>
        /// UpDate all fields in EmployeesRow and call On_Save_Requested.
        /// </summary>
        public void SaveSetting()
        {
            if (EmployeesRow == null)
                return;

            EmployeesRow.BeginEdit();

            EmployeesRow["Index"] = ID;
            EmployeesRow["ID"] = ID;
            EmployeesRow["Last6digit"] = Last6Digit;
            EmployeesRow["LastName"] = LastName;
            EmployeesRow["Name"] = Name;
            EmployeesRow["Address"] = Address;
            EmployeesRow["Telephone"] = Telephone;
            EmployeesRow["Dob"] = Dob;
            EmployeesRow["HireDate"] = HireDate;
            EmployeesRow["UserSetting"] = UserSettingDict_to_String();
            EmployeesRow["DataGridViewSetting"] = DataGridViewSettingDict_to_String();
            EmployeesRow["Position"] = Position;
            EmployeesRow["Department"] = Department;
            EmployeesRow["AccessLevel"] = MyCode.GetString(EmployeeRights);
            EmployeesRow["Size"] = Size;
            EmployeesRow["Status"] = Status;

            EmployeesRow.EndEdit();

            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.EmployeesInformationChange, EmployeesRow));
        }

        /// <summary>
        /// Return a List of ColumnSetting for this specific DataGridView. 
        /// </summary>
        /// <param name="DataGridViewName"></param>
        /// <returns></returns>
        public List<ColumnSetting> ColumnSettingList(string DataGridViewName)
        {
            return DataGridViewSettingDict[DataGridViewName];
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

            if (DataGridViewSettingDict.TryGetValue(DataGridViewName, out List<ColumnSetting>? value))
                if (value != null)
                    return true;

            return false;
        }

        Dictionary<string, List<ColumnSetting>> _dataGridViewSettingDict;
        /// <summary>
        /// Because there can be more than one DataGridView in the user-application
        /// a dictionary is used to save the settings for this different DataGridView.
        /// As key the name of the DataGridView is used.
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

        private string DataGridViewSettingDict_to_String()
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, List<ColumnSetting>> pair in DataGridViewSettingDict)
            {
                if (string.IsNullOrEmpty(pair.Value.ToString()) || string.IsNullOrWhiteSpace(pair.Value.ToString()))
                {
                    MessageBox.Show("Error in string information, Dictionary format is as follows 'NameControl:ColumnSetting', " + pair.Key +
                        " : ColumnSetting", "Dictionary information loss in DataGridViewSetting procedure.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                builder.Append(pair.Key).Append('|');

                List<ColumnSetting> ColumnList = pair.Value;

                foreach (ColumnSetting columnSetting in ColumnList)
                {
                    builder.Append(columnSetting.ToString()).Append(';');
                }

                builder.Append('#');
            }

            string result = builder.ToString();
            //Remove the final delimiter
            result = result.TrimEnd('#');

            result = result.TrimEnd(';');

            return result;
        }
    }

    [Serializable]
    public sealed class ColumnSetting
    {
        public ColumnSetting()
        {
            Name = "";
            ColumnIndex = 2;
            DisplayIndex = 2;
            Width = 233;
            VisibleUserSetting = true;
            VisibleUserSetting = true;
            Edit = true;
            Alignment = (DataGridViewContentAlignment)16;
        }

        /// <summary>
        /// Initialize a ColumnSetting properties as Column Name:string and Visible:Boolean.
        /// </summary>
        public ColumnSetting(string columnName, bool visible)
        {
            Name = columnName;
            Visible = visible;

            onlyShow = true;
        }

        /// <summary>
        /// ColumnSetting as Name,Index,DisplayIndex,Width,Visible,Edit,Alignment
        /// Name as string, Index as int, DisplayIndex as int, Width as int,
        /// Visible as Boolean, Edit as Boolean and Alignment as DataGridViewContentAlignment.
        /// </summary>
        /// <param name="columnData"></param>
        public ColumnSetting(string columnData)
        {
            string[] ColumnSettings = columnData.Split(',');

            if (ColumnSettings.Length < 8)
            {
                Name = "NoColumnName";
                ColumnIndex = 2;
                DisplayIndex = 2;
                Width = 233;
                VisibleSystemSetting = true;
                VisibleUserSetting = true;
                Edit = true;
                Alignment = (DataGridViewContentAlignment)6;
                return;
            }

            Name = ColumnSettings[0];

            try
            {
                ColumnIndex = int.Parse(ColumnSettings[1]);
            }
            catch (Exception)
            {
                ColumnIndex++;
            }

            try
            {
                DisplayIndex = int.Parse(ColumnSettings[2]);
            }
            catch (Exception)
            {
                DisplayIndex++;
            }

            try
            {
                Width = int.Parse(ColumnSettings[3]);
            }
            catch (Exception)
            {
                Width = 100;
            }

            try
            {
                VisibleSystemSetting = bool.Parse(ColumnSettings[4]);
            }
            catch (Exception)
            {
                VisibleSystemSetting = true;
            }

            try
            {
                VisibleUserSetting = bool.Parse(ColumnSettings[5]);
            }
            catch (Exception)
            {
                VisibleUserSetting = true;
            }

            try
            {
                Edit = bool.Parse(ColumnSettings[6]);
            }
            catch (Exception)
            {
                Edit = false;
            }

            try
            {
                Alignment = (DataGridViewContentAlignment)int.Parse(ColumnSettings[7]);
            }
            catch (Exception)
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        /// <summary>
        /// Initialize a new ColumnSetting using a DataGridViewColumn properties.
        /// </summary>
        /// <param name="column"></param>
        public ColumnSetting(DataGridViewColumn column)
        {
            Name = column.Name;
            ColumnIndex = column.Index;
            DisplayIndex = column.DisplayIndex;
            Width = column.Width;
            VisibleSystemSetting = true;
            VisibleUserSetting = column.Visible;
            Edit = !column.ReadOnly;
            Alignment = column.DefaultCellStyle.Alignment;
        }

        public override string ToString()
        {
            //Build up each line one by one and them trim the end
            StringBuilder builder = new StringBuilder();

            builder.Append(Name).Append(",");    //[0]
            builder.Append(ColumnIndex).Append(",");    //[1]
            builder.Append(DisplayIndex).Append(",");    //[2]
            builder.Append(Width).Append(",");    //[3]
            builder.Append(VisibleSystemSetting).Append(",");//[4]
            builder.Append(VisibleUserSetting).Append(",");  //[5]           
            builder.Append(Edit).Append(",");    //[6]
            builder.Append((int)Alignment).Append(",");    //[7]

            string result = builder.ToString();
            //Remove the final delimiter
            result = result.TrimEnd(',');

            return result;
        }

        public string Name { get; set; }
        public int ColumnIndex { get; set; }
        public int DisplayIndex { get; set; }
        public int Width { get; set; }
        public bool VisibleUserSetting { get; set; }
        public bool VisibleSystemSetting { get; set; }
        public bool Edit { get; set; }
        public DataGridViewContentAlignment Alignment { get; set; }

        public bool Visible
        {
            get
            {
                if (VisibleSystemSetting)
                    return VisibleUserSetting;
                else
                    return false;
            }

            set
            {
                VisibleUserSetting = value;
            }
        }

        public bool onlyShow;
    }

    [Serializable]
    public sealed class UserSetting
    {
        public UserSetting()
        {
            CustomEdit = MyCode.EditMode.View;
            AccessLevel = MyCode.AccessLevel.User;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        public UserSetting(string settingString)
        {
            try
            {
                int xValue = 500;
                int yValue = 400;
                string[] settings = settingString.Split('|');
                string[] settingCollection = settings[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (settings[0].Contains("StockRoomSetting"))
                {
                    Name = settings[0];
                    _ = int.TryParse(settingCollection[2], out xValue);
                    _ = int.TryParse(settingCollection[3], out yValue);

                    SplitterX = xValue;
                    SplitterY = yValue;

                    return;
                }

                Name = settings[0];
                AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)int.Parse(settingCollection[0]);
                CustomEdit = (MyCode.EditMode)int.Parse(settingCollection[1]);

            }
            catch (Exception)
            {

            }

        }

        public UserSetting(int splitterX, int splitterY)
        {
            SplitterX = splitterX;
            SplitterY = splitterY;
        }

        public UserSetting(DataGridViewAutoSizeColumnsMode autoSizeColumnsMode, MyCode.EditMode customEdit)
        {
            AutoSizeColumnsMode = autoSizeColumnsMode;
            CustomEdit = customEdit;
        }

        public override string ToString()
        {
            //Build up each line one by one and them trim the end
            StringBuilder builder = new StringBuilder();

            builder.Append((int)AutoSizeColumnsMode).Append(',');
            builder.Append((int)CustomEdit).Append(',');
            builder.Append(SplitterX).Append(',');
            builder.Append(SplitterY).Append(',');

            string result = builder.ToString();
            //Remove the final delimiter
            result = result.TrimEnd(',');

            return result;
        }

        public string Name { get; set; } = "Undefined";
        public int SplitterX { get; set; } = 500;
        public int SplitterY { get; set; } = 400;
        public MyCode.EditMode CustomEdit { get; set; } = MyCode.EditMode.View;
        public MyCode.AccessLevel AccessLevel { get; set; } = MyCode.AccessLevel.User;
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get; set; } = DataGridViewAutoSizeColumnsMode.None;

    }

}

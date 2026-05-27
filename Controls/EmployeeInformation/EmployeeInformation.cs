using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace StockRoom11net.Controls.EmployeeInformation
{
    public class EmployeeInformation : INotifyPropertyChanged
    {
        // Injected EF Core services
        private readonly Table_Employee _currentEmployeeEntity;
        private ITableEmployeeService _employeesService;

        public ITableEmployeeService EmployeesService
        {
            get { return _employeesService; }
            set { _employeesService = value; }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        string MessagePositionString = "";

        public EmployeeInformation()
        {           

            EmployeeRights = Utilities.GetDict("AccessLevel:0;EditMode:0;EnableTreeViewSetting:0");

            EmployeeEditMode = Utilities.EditMode.View;
            EmployeeAccessLevel = Utilities.AccessLevel.User;
            EmployeeEnableTreeViewSetting = Utilities.EnableSetting.False;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            DataGridViewSettingDict = new Dictionary<string, List<ColumnSetting>>();
        }

        /// <summary>
        /// Initialize a new EmployeesInformation with this DataRowView,
        /// if it's null no employee logged in.
        /// </summary>
        /// <param name="employeesRow"></param>
        public EmployeeInformation(Table_Employee employeeEntity)
        {
            try
            {
                _currentEmployeeEntity = employeeEntity;

                EmployeeRights = Utilities.GetDict(_currentEmployeeEntity.AccessLevel.ToString());

                MessagePositionString = "Dictionary EditMode.";
                EmployeeEditMode = (Utilities.EditMode)EmployeeRights["EditMode"];

                MessagePositionString = "Dictionary AccessLevel.";
                EmployeeAccessLevel = (Utilities.AccessLevel)EmployeeRights["AccessLevel"];

                MessagePositionString = "Dictionary EnableTreeViewSetting.";
                EmployeeEnableTreeViewSetting = (Utilities.EnableSetting)EmployeeRights["EnableTreeViewSetting"];
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

        public EmployeeInformation(string employeesID)
        {
            if (!employeesID.Contains("811266"))
                return;

            try
            {               
                EmployeeRights = Utilities.GetDict("AccessLevel:3;AutoSizeColumnsMode:1;EditMode:3;EnableTreeViewSetting:1");
                EmployeeEditMode = Utilities.EditMode.Delete;
                EmployeeAccessLevel = Utilities.AccessLevel.Manager;
                EmployeeEnableTreeViewSetting = Utilities.EnableSetting.False;
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                _userSettingDict = new Dictionary<string, UserSetting>();
                InitializeEmployees();
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, "The constructor has found an error " + error.Message + " at position " +
                                        MessagePositionString, "EmployeesInformation Class error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEmployees()
        {
            #region"DataGridViewSetting"

            Dictionary<string, List<ColumnSetting>> dataGridViewSetting = new Dictionary<string, List<ColumnSetting>>();

            StringCollection _dataGridViewString = new StringCollection();
                        
            _dataGridViewString.AddRange(_currentEmployeeEntity.DataGridViewSetting.ToString().Split('#'));

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

            _userSettingString.AddRange(_currentEmployeeEntity.UserSetting.ToString().Split('#'));

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
        /// EmployeeInformation rights and permissions to edit, delete and configure the interface. permits are:
        /// AccessLevel, EditMode, EnableTreeViewSetting, AutoSizeColumnsMode.
        /// </summary>
        private readonly SortedDictionary<string, int> EmployeeRights = new SortedDictionary<string, int>()
            {
                {"AccessLevel", 0},
                {"EditMode", 0},
                {"EnableTreeViewSetting", 0},
                {"AutoSizeColumnsMode", 1}
            };
        
        public int Index { get { return _currentEmployeeEntity?.Index ?? 0; } }
        public int ID { get { return _currentEmployeeEntity?.ID ?? 0; } }
      //  public int? ManagerId { get { return _currentEmployeeEntity?.ManagerId; } }
        public int Last6Digit { get { return _currentEmployeeEntity?.Last6Digit ?? 0; } }
        public string LastName { get { return _currentEmployeeEntity?.LastName ?? ""; } }
        public string Name { get { return _currentEmployeeEntity?.Name ?? "Not user login."; } }
        public string Address { get { return _currentEmployeeEntity?.Address ?? ""; } }
        public string Telephone { get { return _currentEmployeeEntity?.Telephone ?? ""; } }
        public DateTime Dob { get { return _currentEmployeeEntity?.Dob ?? DateTime.Now; } }
        public DateTime HireDate { get { return _currentEmployeeEntity?.HireDate ?? DateTime.Now; } }
        public string UserSetting
        {
            get { return _currentEmployeeEntity?.UserSetting ?? ""; }
            set { _currentEmployeeEntity?.UserSetting = value; }
        }
        public string DataGridViewSetting
        {
            get { return _currentEmployeeEntity?.DataGridViewSetting ?? ""; }
            set { _currentEmployeeEntity?.DataGridViewSetting = value; }
        }
        public string Position { get { return _currentEmployeeEntity?.Position ?? ""; } }
        public string Department { get { return _currentEmployeeEntity?.Department ?? ""; } }
        public string Size { get { return _currentEmployeeEntity?.Size ?? ""; } }
        public string Status { get { return _currentEmployeeEntity?.Status ?? ""; } }
        
        
        #region"These are packed in the Dictionary, we need to update this to reflect changes."

        public Utilities.AccessLevel EmployeeAccessLevel
        {
            get
            {
                return (Utilities.AccessLevel)EmployeeRights["AccessLevel"];
            }

            set
            {
                EmployeeRights["AccessLevel"] = (int)value;
            }
        }

        public Utilities.EditMode EmployeeEditMode
        {
            get
            {
                return (Utilities.EditMode)EmployeeRights["EditMode"];
            }

            set
            {
                EmployeeRights["EditMode"] = (int)value;
            }
        }

        public Utilities.EnableSetting EmployeeEnableTreeViewSetting
        {
            get
            {
                return (Utilities.EnableSetting)EmployeeRights["EnableTreeViewSetting"];
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
                if ((Utilities.EditMode)EmployeeRights["EditMode"] == Utilities.EditMode.View)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsEditMode
        {
            get
            {
                if ((Utilities.EditMode)EmployeeRights["EditMode"] == Utilities.EditMode.Edit)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsDeleteMode
        {
            get
            {
                if ((Utilities.EditMode)EmployeeRights["EditMode"] == Utilities.EditMode.Delete)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsAddMode
        {
            get
            {
                if ((Utilities.EditMode)EmployeeRights["EditMode"] == Utilities.EditMode.Add)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsManager
        {
            get
            {
                if ((Utilities.AccessLevel)EmployeeRights["AccessLevel"] == Utilities.AccessLevel.Manager)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsAdministrator
        {
            get
            {
                if ((Utilities.AccessLevel)EmployeeRights["AccessLevel"] == Utilities.AccessLevel.Administrator)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsEditor
        {
            get
            {
                if ((Utilities.AccessLevel)EmployeeRights["AccessLevel"] == Utilities.AccessLevel.Editor)
                    return true;

                return false;
            }

            private set { }
        }

        public bool IsUser
        {
            get
            {
                if ((Utilities.AccessLevel)EmployeeRights["AccessLevel"] == Utilities.AccessLevel.User)
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
        public async Task SaveUserSettingAsync(string UserSettingName, UserSetting userSetting)
        {
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

            _employeesService.CurrentEmployeeLogIn.UserSetting = UserSettingDict_to_String();
            await SaveSetting();
        }

        public async Task SaveColumnsSetting(string UserSettingName, DataGridViewColumnCollection columns)
        {
            UpDateColumnsSetting(UserSettingName, columns);

            _employeesService.CurrentEmployeeLogIn.DataGridViewSetting = DataGridViewSettingDict_to_String();

            await SaveSetting();
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
        public async Task SaveSetting()
        {
            await _employeesService.UpdateEmployeeAsync(_employeesService.CurrentEmployeeEntity);
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
            CustomEdit = Utilities.EditMode.View;
            AccessLevel = Utilities.AccessLevel.User;
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
                CustomEdit = (Utilities.EditMode)int.Parse(settingCollection[1]);

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

        public UserSetting(DataGridViewAutoSizeColumnsMode autoSizeColumnsMode, Utilities.EditMode customEdit)
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
        public Utilities.EditMode CustomEdit { get; set; } = Utilities.EditMode.View;
        public Utilities.AccessLevel AccessLevel { get; set; } = Utilities.AccessLevel.User;
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get; set; } = DataGridViewAutoSizeColumnsMode.None;

    }
    
}

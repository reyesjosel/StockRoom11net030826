using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using StockRoom11net.Data.Entities;
using StockRoom11net.Data.Services;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using static StockRoom11net.Controls.Utilities;

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

        /// <summary>
        /// Initialize a new EmployeesInformation with default value, no employee logged in,
        /// all the rights are set to 0, and the DataGridViewSettingDict is initialized.
        /// </summary>
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

            string[] dataGridViewStrings = _currentEmployeeEntity.DataGridViewSetting.ToString().Split('#');

            foreach (string datagridview in dataGridViewStrings)
            {
                if (string.IsNullOrWhiteSpace(datagridview))
                    continue;

                int pipeIndex = datagridview.IndexOf('|');
                if (pipeIndex <= 0)
                    continue;

                string name = datagridview.Substring(0, pipeIndex);
                string columns = datagridview.Substring(pipeIndex + 1);

                string[] columnsArray = columns.Split(';', StringSplitOptions.RemoveEmptyEntries);
                List<ColumnSetting> columnsSetting = new List<ColumnSetting>(columnsArray.Length);

                foreach (string columnsetting in columnsArray)
                {
                    if (!string.IsNullOrWhiteSpace(columnsetting))
                    {
                        columnsSetting.Add(new ColumnSetting(columnsetting));
                    }
                }

                dataGridViewSetting.Add(name, columnsSetting);
            }

            DataGridViewSettingDict = dataGridViewSetting;

            #endregion"DataGridViewSetting"

            #region"UserSettingDict"

            Dictionary<string, UserSetting> userSettingDict = new Dictionary<string, UserSetting>();

            string[] userSettingStrings = _currentEmployeeEntity.UserSetting.ToString().Split('#');

            foreach (string userSetting in userSettingStrings)
            {
                if (string.IsNullOrWhiteSpace(userSetting))
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


        /// <summary>
        /// The user setting name, we save userSettingName = Name + "_" + TableName;
        /// It is update at public object DataSource{ set }
        /// We saved the datasource name because in some cases,
        /// the same dataGridView manipulates different dataSources.
        /// </summary>
        public string UserSettingName = "";

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
        /// Check if the current user have any setting information with this UserSettingName, if is true
        /// return the UserSetting information, if is false return a new UserSetting with default value.
        /// </summary>
        /// <param name="DataGridViewName"></param>
        /// <param name="userSettingName">todo: describe userSettingName parameter on UserSettingEntity</param>
        /// <returns></returns>
        public UserSetting UserSettingEntity(string userSettingName)
        {
            return ContainsUserSetting(userSettingName)? UserSettingDict[userSettingName + "_UserSetting"] : new UserSetting();
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
        public async Task Save_UserSetting_ColumnsSetting(string userSettingName, UserSetting userSetting, DataGridViewColumnCollection columns,
                                                                            DataGridViewAutoSizeColumnsMode autoSizeColumnsMode)
        {
            EmployeeRights["AutoSizeColumnsMode"] = (int)autoSizeColumnsMode;

            UserSettingName = userSettingName;

            UpDateUserSetting(UserSettingName, userSetting);

            UpDateColumnsSetting(UserSettingName, columns);

            await SaveUserSettingAsync();
        }


        /// <summary>
        /// UpDate the UserSetting field call SaveSetting();
        /// </summary>
        /// <param name="UserSettingName"></param>
        /// <param name="userSetting"></param>
        async Task SaveUserSettingAsync()
        {
            string serializedColumnsSetting = DataGridViewSettingDict_to_String();
            string serializedUserSetting = UserSettingDict_to_String();

            _employeesService.CurrentEmployeeEntity.UserSetting = serializedUserSetting;
            _employeesService.CurrentEmployeeEntity.DataGridViewSetting = serializedColumnsSetting;            
            
            await _employeesService.UpdateEmployeeAsync(_employeesService.CurrentEmployeeEntity);
        }

        /// <summary>
        /// Test if this UserSettingName + "_UserSetting" have user setting information in the Dict,
        /// if is true save the information UserSetting back to the Dict.
        /// if is false, add new key UserSettingName + "_UserSetting" : UserSetting to Dict.
        /// </summary>
        /// <param name="UserSettingName"></param>
        /// <param name="userSetting"></param>
        void UpDateUserSetting(string UserSettingName, UserSetting userSetting)
        {
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
        }

        /// <summary>
        /// UpDate the DataGridViewSettingDict, if the Dict already contain the key UserSettingName,
        /// remove it and add new key UserSettingName : columnSettingList to Dict,
        /// </summary>
        /// <param name="UserSettingName"></param>
        /// <param name="columns"></param>
        void UpDateColumnsSetting(string UserSettingName, DataGridViewColumnCollection columns)
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
        /// Because there can be more than one DataGridView in the user-application a dictionary is used to save the
        /// settings per user for different DataGridView. As key the name of the DataGridView, as value a List of
        /// ColumnSetting is used to save the setting of each column in the DataGridView.
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

            foreach(KeyValuePair<string, List<ColumnSetting>> pair in DataGridViewSettingDict)
            {
                if (string.IsNullOrWhiteSpace(pair.Key))
                {
                    MessageBox.Show($"Error in string information, Dictionary format is as follows 'NameControl:ColumnSetting', {pair.Key} : ColumnSetting", 
                        "Dictionary information loss in DataGridViewSetting procedure.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                builder.Append(pair.Key).Append("|");
                List<ColumnSetting> columnSettingList = pair.Value;
                foreach (ColumnSetting columnSetting in columnSettingList)
                {
                    builder.Append(columnSetting.ToString()).Append(";");
                }
                
                // Remove trailing semicolon before appending hash delimiter
                if (builder.Length > 0 && builder[builder.Length - 1] == ';')
                {
                    builder.Length--;
                }
                builder.Append("#");
            }

            // Remove final hash delimiter
            if (builder.Length > 0 && builder[builder.Length - 1] == '#')
            {
                builder.Length--;
            }

            return builder.ToString();
        }

        public async Task UpDateSave_DataTreeView_UserSetting(Font font, int columnWidth)
        {
            if (UserSettingDict.ContainsKey(UserSettingName + "_UserSetting"))
            {
                UserSetting userSetting = UserSettingDict[UserSettingName + "_UserSetting"];

                userSetting.DataTreeViewFont = font;
                userSetting.DataTreeViewColumnTextNameWidth = columnWidth;

                await SaveUserSettingAsync();
            }            
        }

        public async Task UpDateSave_Splitter_UserSetting(string userSettingName, int splitterVertical, int splitterHorizontal)
        {
            if (UserSettingDict.ContainsKey(userSettingName + "_UserSetting"))
            {
                UserSetting userSetting = UserSettingDict[userSettingName + "_UserSetting"];

                userSetting.SplitterVertical   = splitterVertical;
                userSetting.SplitterHorizontal = splitterHorizontal;

                await SaveUserSettingAsync();
            }
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
        /// ColumnSetting as
        /// ColumnName, ColumnIndex, DisplayIndex, Width, VisibleSystemSetting, VisibleUserSetting, Edit, Alignment
        /// "PartNumb ,      1     ,      2      ,  30  ,        true         ,         true      , false,    6"
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


        /// <summary>
        /// Serializes the <see cref="ColumnSetting"/> instance into a comma-separated string
        /// where each field occupies a fixed positional index.
        /// </summary>
        /// <returns>
        /// A comma-separated <see cref="string"/> with the following field order:
        /// ColumnName, ColumnIndex, DisplayIndex, Width, VisibleSystemSetting, VisibleUserSetting, Edit, Alignment
        /// "PartNumb ,      1     ,      2      ,  30  ,        true         ,         true      , false,    6"
        /// <list type="table">
        ///   <listheader>
        ///     <term>Index</term>
        ///     <description>Field</description>
        ///   </listheader>
        ///   <itemEFtableTreeView><term>[0]</term><description><see cref="Name"/> —         Column name identifier.</description></itemEFtableTreeView>
        ///   <itemEFtableTreeView><term>[1]</term><description><see cref="ColumnIndex"/> —  Zero-based column index.</description></itemEFtableTreeView>
        ///   <itemEFtableTreeView><term>[2]</term><description><see cref="DisplayIndex"/> — Visual display order index.</description></itemEFtableTreeView>
        ///   <itemEFtableTreeView><term>[3]</term><description><see cref="Width"/> —        Column width in pixels.</description></itemEFtableTreeView>
        ///   <itemEFtableTreeView><term>[4]</term><description><see cref="VisibleSystemSetting"/> — System-level visibility flag.</description></itemEFtableTreeView>
        ///   <itemEFtableTreeView><term>[5]</term><description><see cref="VisibleUserSetting"/> — User-level visibility preference.</description></itemEFtableTreeView>
        ///   <itemEFtableTreeView><term>[6]</term><description><see cref="Edit"/> —          Whether the column is editable.</description></itemEFtableTreeView>
        ///   <itemEFtableTreeView><term>[7]</term><description><see cref="Alignment"/> —     Cell content alignment, stored as its underlying <see cref="int"/> value.</description></itemEFtableTreeView>
        /// </list>
        /// The resulting string is intended to be parsed back by the
        /// <see cref="ColumnSetting(string[])"/> constructor using the same positional indices.
        /// </returns>
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
            builder.Append((int)Alignment);    //[7]

            return builder.ToString();
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

        /// <summary>
        /// Initialize a UserSetting properties as
        ///           16        ,      3     ,     500   ,     400   ,Segoe UI~9~0, Segoe UI~8~2, Segoe UI~12~1 ,   Segoe UI~12~1  ,             200                 ,       18        ,         18
        /// ^AutoSizeColumnsMode, ^CustomEdit, ^SplitterVertical, ^SplitterHorizontal, ^dgvFont   , ^headerFont , ^bindingNaFont, ^dataTreeViewFont, ^DataTreeViewColumnTextNameWidth, ^ImageSize.Width, ^ImageSize.Height
        /// </summary>
        /// <param name="settingString"></param>
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
                    _ = int.TryParse(settingCollection[2], out xValue);
                    _ = int.TryParse(settingCollection[3], out yValue);

                    SplitterVertical = xValue;
                    SplitterHorizontal = yValue;

                    return;
                }
                
                Name = settings[0];
                AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)int.Parse(settingCollection[0]);
                CustomEdit = (EditMode)int.Parse(settingCollection[1]);
                SplitterVertical = int.Parse(settingCollection[2]);
                SplitterHorizontal = int.Parse(settingCollection[3]);
                DgvFont          = (settingCollection.Length > 4 ? FontFromString(settingCollection[4]) : null) ?? DgvFont;
                HeaderFont       = (settingCollection.Length > 5 ? FontFromString(settingCollection[5]) : null) ?? HeaderFont;
                BindingNaFont    = (settingCollection.Length > 6 ? FontFromString(settingCollection[6]) : null) ?? BindingNaFont;
                DataTreeViewFont = (settingCollection.Length > 7 ? FontFromString(settingCollection[7]) : null) ?? DataTreeViewFont;
                DataTreeViewColumnTextNameWidth = settingCollection.Length > 8 ? int.Parse(settingCollection[8]) : 200;
                ImageSize = settingCollection.Length > 10 ? new Size(int.Parse(settingCollection[9]), int.Parse(settingCollection[10])) : new Size(18, 18);
            }
            catch (Exception)
            {

            }

        }

        public UserSetting(int splitterX, int splitterY)
        {
            SplitterVertical = splitterX;
            SplitterHorizontal = splitterY;
        }

        public UserSetting(DataGridViewAutoSizeColumnsMode autoSizeColumnsMode, EditMode customEdit)
        {
            AutoSizeColumnsMode = autoSizeColumnsMode;
            CustomEdit = customEdit;
        }

        public UserSetting(DataGridViewAutoSizeColumnsMode autoSizeColumnsMode, EditMode customEdit,
                                Font? dgvFont, Font? headerFont, Font? bindingNaFont, Size imageSize)
        {
            AutoSizeColumnsMode = autoSizeColumnsMode;
            CustomEdit = customEdit;

            if (dgvFont != null)
                DgvFont = dgvFont;
            
            if (headerFont != null)
                HeaderFont = headerFont;

            if (bindingNaFont != null)
                BindingNaFont = bindingNaFont;

            ImageSize = imageSize;
        }
               
        public string Name { get; set; } = "Undefined";

        /// <summary>
        /// The position of the vertical splitter in the user interface.
        /// </summary>
        public int SplitterVertical { get; set; } = 500;

        /// <summary>
        /// The position of the horizontal splitter in the user interface.
        /// </summary>
        public int SplitterHorizontal { get; set; } = 400;

        public EditMode CustomEdit { get; set; } = EditMode.View;
                
        /// <summary>
        /// The font used for the DataGridView content. This property can be null, in which case a default font will be used.
        /// </summary>
        public Font? DgvFont { get; set; } = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);

        /// <summary>
        /// The font used for the DataGridView columns header. This property can be null, in which case a default font will be used.
        /// </summary>
        public Font? HeaderFont { get; set; } = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);

        /// <summary>
        /// The font used for the BindingNavigator. This property can be null, in which case a default font will be used.
        /// </summary>
        public Font? BindingNaFont { get; set; } = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);

        /// <summary>
        /// The font used for the DataTreeView. This property can be null, in which case a default font will be used.
        /// </summary>
        public Font? DataTreeViewFont { get; set; } = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);

        /// <summary>
        /// The width of the column TextName in the DataTreeView. This property can be customized by the user to fit their preferences.
        /// </summary>
        public int DataTreeViewColumnTextNameWidth { get; set; } = 200;

        /// <summary>
        /// The size of the images used in the DataGridView. Default is 18x18 pixels.
        /// This property can be customized by the user to fit their preferences.
        /// </summary>
        public Size ImageSize { get; set; } = new Size(18, 18);

        public AccessLevel AccessLevel { get; set; } = AccessLevel.User;
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get; set; } = DataGridViewAutoSizeColumnsMode.None;

        // Serialized string (in UserSetting.ToString / save)
        // Before: "16,3,500,400"
        // After:  "16,3,500,400,Segoe UI~9~0,Segoe UI~8~2,Segoe UI~12~1"
        //                       ^dgvFont     ^headerFont   ^dataTreeViewFont
        // Serialize a Font → "Segoe UI~9~Italic"  (null-safe)
        static string FontToString(Font? font) => font == null ? "" : $"{font.FontFamily.Name}~{font.Size}~{(int)font.Style}";

        // Deserialize "Segoe UI~9~2" → Font  (returns null if empty/invalid)
        static Font? FontFromString(string? token)
        {
            if (string.IsNullOrEmpty(token)) return null;
            var p = token.Split('~');
            if (p.Length != 3) return null;
            return new Font(p[0], float.Parse(p[1], CultureInfo.InvariantCulture),
                            (FontStyle)int.Parse(p[2]));
        }

        public override string ToString()
        {
            //Build up each line one by one and them trim the end
            StringBuilder builder = new StringBuilder();

            builder.Append((int)AutoSizeColumnsMode).Append(',');
            builder.Append((int)CustomEdit).Append(',');
            builder.Append(SplitterVertical).Append(',');
            builder.Append(SplitterHorizontal).Append(',');
            builder.Append(FontToString(DgvFont)).Append(',');
            builder.Append(FontToString(HeaderFont)).Append(',');
            builder.Append(FontToString(BindingNaFont)).Append(',');
            builder.Append(FontToString(DataTreeViewFont)).Append(',');
            builder.Append(DataTreeViewColumnTextNameWidth).Append(',');
            builder.Append(ImageSize.Width).Append(',').Append(ImageSize.Height);

            string result = builder.ToString();

            // Final string format:
            //           16        ,      3     ,         500      ,          400       ,Segoe UI~9~0, Segoe UI~8~2, Segoe UI~12~1 ,   Segoe UI~12~1  ,             200                 ,       18        ,         18
            // ^AutoSizeColumnsMode, ^CustomEdit, ^SplitterVertical, ^SplitterHorizontal, ^dgvFont   , ^headerFont , ^bindingNaFont, ^dataTreeViewFont, ^DataTreeViewColumnTextNameWidth, ^ImageSize.Width, ^ImageSize.Height

            return result;
        }


    }

}

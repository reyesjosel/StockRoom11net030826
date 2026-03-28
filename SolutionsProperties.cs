using MyStuff11net;
using MyStuff11net.FirstInstallationSetting;
using MyStuff11net.Properties;
using RawInput_dll;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using WinFormsUI.Docking;
using static MyStuff11net.Custom_Events_Args;
using File = System.IO.File;

namespace StockRoom11net
{
    public partial class SolutionsProperties : DockContent
    {
        ScanDocumentsAddressGroup scanDocumentsAddressGroup_Default = new ScanDocumentsAddressGroup();

        bool IsInstallationMode;

        FileAttributes _fileAttributes = new FileAttributes();

        public List<string> DepartList = new List<string>();
        public List<DepartmentInformation> ListDepartments = new List<DepartmentInformation>();
        // public CustomTabControl tabControlExtendBase = new CustomTabControl();
        public CurrentStatus CurrentStatusReference = new CurrentStatus();

        #region"Custom Controls Events with custom Arguments.*********************"

        #region"Node PDF"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event Custom_Events_Args.Node_PDF_EventHandler Node_PDF;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Node_PDF(ActiveDataSheet_EventArgs e)
        {
            // Notify Subscribers
            Node_PDF?.Invoke(this, e);
        }

        #endregion"Node PDF"

        #region"ActiveDataSheet"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event Custom_Events_Args.ActiveDataSheet_EventHandler ActiveDataSheet;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_ActiveDataSheet(ActiveDataSheet_EventArgs e)
        {
            // Notify Subscribers
            ActiveDataSheet?.Invoke(this, e);
        }

        #endregion"ActiveDataSheet"

        #region"LogFile information"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("LogFile information are append.")]
        public event Custom_Events_Args.LogFileMessageEventHandler LogFileMessage;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_LogFileMessage(LogFileMessageEventArgs e)
        {
            // Notify Subscribers
            LogFileMessage?.Invoke(this, e);
        }

        #endregion"LogFile information"

        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Status bar message and status bar help.")]
        public event Custom_Events_Args.StatusBarMessage_EventHandler StatusBarMessage;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            // Notify Subscribers
            StatusBarMessage?.Invoke(this, e);
        }

        public void OnStatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        #endregion"StatusBarMessage"

        #region"CellDoubleClick"

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellDoubleClick has changed")]
        public event Custom_Events_Args.CellDoubleClick_EventHandler CellDoubleClick_Event;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_CellDoubleClick_Event(CellDoubleClick_EventArgs e)
        {
            // Notify Subscribers
            CellDoubleClick_Event?.Invoke(this, e);
        }

        #endregion"CellDoubleClick_Event"

        #region"Need_SaveData"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Need_SaveData_EventHandler Need_SaveData;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Need_SaveData(Need_SaveData_EventArgs e)
        {
            // Notify Subscribers
            Need_SaveData?.Invoke(this, e);
        }

        #endregion"Need_SaveData"

        #region"NotificationsToSends"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.NotificationsToSends_EventHandler NotificationsToSends;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_NotificationsToSends(Notification e)
        {
            // Notify Subscribers
            NotificationsToSends?.Invoke(this, e);
        }

        #endregion"Need_SaveData"

        #region"SpeechSynthesizerBase"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Status bar message and status bar help.")]
        public event SpeechSynthesizerBase_EventHandler SpeechSynthesizerBase;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_SpeechSynthesizerBase(SpeechSynthesizerBase_EventArgs e)
        {
            // Notify Subscribers
            SpeechSynthesizerBase?.Invoke(this, e);
        }

        #endregion"SpeechSynthesizerBase"

        #region"Save_Setting"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SaveSettingEventHandler(object sender, SaveSettingEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Setting Save action")]
        public event SaveSettingEventHandler SaveSetting;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_SaveSetting(SaveSettingEventArgs e)
        {
            SaveSetting?.Invoke(this, e);
        }
        #endregion"Save_Setting"

        #region"Save_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Save_Requested_EventHandler Save_Requested;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Save_Requested(Save_Requested_EventArgs e)
        {
            // Notify Subscribers
            Save_Requested?.Invoke(this, e);
        }

        #endregion

        #region"Refresh_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Refresh_Requested_EventHandler Refresh_Requested;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Refresh_Requested(Refresh_Requested_EventArgs e)
        {
            // Notify Subscribers
            Refresh_Requested?.Invoke(this, e);
        }

        #endregion"Refresh_Requested"

        #region"SaveTreeView_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.SaveTreeView_Requested_EventHandler SaveTreeView_Requested;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_SaveTreeView_Requested(Save_Requested_EventArgs e)
        {
            // Notify Subscribers
            SaveTreeView_Requested?.Invoke(this, e);
        }

        #endregion

        #region"AddNewItemSaveTreeViewRequested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.SaveTreeView_Requested_EventHandler AddNewItemSaveTreeViewRequested;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_AddNewItemSaveTreeViewRequested(Save_Requested_EventArgs e)
        {
            // Notify Subscribers
            AddNewItemSaveTreeViewRequested?.Invoke(this, e);
        }

        #endregion

        #endregion"Custom Controls Events with custom Arg.*********************"      

        #region"CurrentUserBroadcast"
        /// <summary>
        /// Department active in this machine.
        /// </summary>
        DepartmentInformation _currentDepartmentLogIn;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DepartmentInformation CurrentDepartmentLogIn
        {
            get
            {
                return _currentDepartmentLogIn;
            }
            set
            {
                if (value == null)
                    return;

                _currentDepartmentLogIn = value;

                _currentDepartmentLogIn.Save_Requested -= CurrentDepartmentLogIn_Save_Requested;
                _currentDepartmentLogIn.Save_Requested += CurrentDepartmentLogIn_Save_Requested;
            }
        }

        void CurrentDepartmentLogIn_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            On_Save_Requested(e);
        }

        public Action ProcessCurrentEmployeesLogIn;
        Employee _currentEmployeesLogIn;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Employee CurrentEmployeesLogIn
        {
            get
            {
                if (_currentEmployeesLogIn == null)
                    _currentEmployeesLogIn = new Employee();

                return _currentEmployeesLogIn;
            }
            set
            {
                _currentEmployeesLogIn = value;

                ProcessCurrentEmployeesLogIn?.Invoke();
            }
        }

        public void CurrentUserBroadcast_EventHandler(object sender, CurrentDeptUserBroadcast_EventArgs e)
        {
            if (e == null)
                return;

            CurrentEmployeesLogIn = e.Employee;
            CurrentDepartmentLogIn = e.Deptment;
        }

        #endregion"CurrentUserBroadcast"

        #region"BomAssemblyUpdate"
        public void TreeViewUpdate_EventHandler(object sender, TreeViewUpdateEventArgs e)
        {
            //  _bindingSource_table_StockroomTreeView.DataSource = DuplicateDataSource(_bindingSource_Original_StockroomTreeView);

            //  treeViewBase.DataBinding.DataSource = null;
            //  treeViewBase.DataBinding.DataSource = _bindingSource_table_StockroomTreeView;

            //  treeViewBase.FullRepaint();

            //  treeView.DataBinding.
        }

        #endregion"BomAssemblyUpdate"        


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MessagePositionString { get; set; }

        public ResourcesCache _cache = new ResourcesCache();

        public virtual void ProcessInput(CellDoubleClick_EventArgs cellDoubleClickEventArgs, MyCode.ProcessMode value) { }

        public void ThreadSafeInvoke(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action?.Invoke();
            }
        }


        public SolutionsProperties()
        {
            InitializeComponent();
        }

        public SolutionsProperties(string options)
        {
            InitializeComponent();

            CurrentDepartmentLogIn = new DepartmentInformation();

            if (options.Contains("Installation Mode"))
                IsInstallationMode = true;
        }

        public SolutionsProperties(DepartmentInformation currentDepartment, List<DepartmentInformation> listDepartments)
        {
            InitializeComponent();

            CurrentDepartmentLogIn = currentDepartment;
            ListDepartments = listDepartments;

            Text = "Solutions properties for " + CurrentDepartmentLogIn.DeptName + " department.";
        }


        void SolutionsProperties_Load(object sender, EventArgs e)
        {
            InitializeProperties();

            InitializeRichTextBox();

            InitializeTreeViewApplicationsSetting();

            InitializeApplicationSettingTab();

            InitializeDocumentationBehaviorTab();

            InitializeConvertFilesFrontThisLocationTab();

            InitializePeerToPeerManagementTab();

            //  customTabControlSetting.DisplayStyle = TabStyle.None;

            Init_USB_BarCode();
        }

        void SolutionsProperties_Shown(object sender, EventArgs e)
        {
            CheckBoxEnableSendReceiveNotifycationsCheckedChanged(sender, e);

            grouper_AddNewPrintHelpsButtons_Resize(sender, e);

            if (IsInstallationMode)
            {
                ProcessTaskSystemDeviceInformation();

                Settings.Default.InstallationFirstDate = DateTime.Now;
                Settings.Default.InstallationFirstUser = "";

                using (var installationKey = new InstallationKey())
                {
                    installationKey.TopMost = true;
                    installationKey.ShowDialog();
                }

            }
        }

        void SolutionsProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        void ButtonSaveClick(object sender, EventArgs e)
        {
            SaveTheProperties();
        }

        void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        void ButtonBrowserDataBaseFileClick(object sender, EventArgs e)
        {
            using (var openfile = new OpenFileDialog
            {
                Title = @"Please find the file ProductionInventory.sqlite",
                FileName = "ProductionInventory",
                Filter = @"Sqlite (*.sqlite)|*.sqlite",
                DefaultExt = "(*.sqlite)|*.sqlite"
            })
            {
                if (openfile.ShowDialog(this) == DialogResult.Cancel)
                {
                    MessageBox.Show(@"No Database selected. Must select one to continue.", @"DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                textBox_DataBaseAddress.Text = openfile.FileName;
                Settings.Default.DataBaseConnectionStringSQLite = "data source=" + openfile.FileName + ";";
                Settings.Default.DataBaseAddress = Path.GetDirectoryName(openfile.FileName);
                Settings.Default.DataBaseName = Path.GetFileNameWithoutExtension(openfile.FileName);
                Settings.Default.Save();                
            }
        }

        void CheckBoxEnableSendReceiveNotifycationsCheckedChanged(object sender, EventArgs e)
        {
            grouper_Notifycations.Enabled = checkBox_EnableSendReceiveNotifycations.Checked;
        }

        void buttonApplicationHTMLtemples_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfiledialog = new OpenFileDialog
            {
                Title = @"Please select the address to HTML templepages.",
                FileName = "",
                Filter = @"Webpages temple files (*.HTML)|*.html",
                DefaultExt = "(*.HTML)|*.html"
            })
            {
                if (openfiledialog.ShowDialog(this) == DialogResult.Cancel)
                {
                    //   MessageBox.Show(@"No Database selected. Must select one to continue.", @"DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBoxApplicationHTMLtemples.Text = Path.GetDirectoryName(openfiledialog.FileName);
                Settings.Default.ApplicationDefaultHtmlPages = textBoxApplicationHTMLtemples.Text;
            }
        }

        void GetPicturesProccess(string filePathString)
        {
            if (!PicturesBox_Image.Visible)
                return;

            if (filePathString == null)
                return;

            if (PicturesBox_Image.ImageLocation == filePathString)
                return;

            if (File.Exists(filePathString))
            {
                //  FilePathPicturesBoxImage = filePathString;
                PicturesBox_Image.ImageLocation = filePathString;
                PicturesBox_Image.Image = _cache.GetBitmap(filePathString);
            }
        }

        void InitializeProperties()
        {
            try
            {
                MessagePositionString = "InitializeProperties()";

                checkBox_EnableSendReceiveNotifycations.Checked = Settings.Default.NotifycationsEnableSendReceive;
                checkBox_SendMyOwnNotifications.Checked = Settings.Default.NotificationsSendMyOwn;

                MessagePositionString = @"checkBox_ShowEmailsNotifications";
                checkBox_ShowEmailsNotifications.Checked = Settings.Default.NotificationsShowEmails;
                checkBox_ShowDataBaseUpdateNotifications.Checked = Settings.Default.NotificationsShowDataBaseUpDate;
                checkBox_ShowMyOwnNotifications.Checked = Settings.Default.NotificationsShowMyOwn;
                checkBox_ShowWarningsNotifications.Checked = Settings.Default.NotificationsShowWarnings;
                trackBar_Interval.Value = Settings.Default.IntervalTrackBar_Value;
                TimeUnitName = Settings.Default.IntervalTimeUnitName;

                MessagePositionString = @"checkBoxSaveEachTimeTheInformationIsChanged";
                checkBoxSaveEachTimeTheInformationIsChanged.Checked = Settings.Default.SaveEachTimeTheInformationIsChanged;
                checkBoxSaveTheInformationByTime.Checked = Settings.Default.SaveTheInformationByTime;
                checkBoxSaveTheInformationWhenTheUserSaves.Checked = Settings.Default.SaveTheInformationWhenTheUserSave;
                radioButtonEvery5minutes.Checked = Settings.Default.Every5minutes;
                radioButtonEvery15minutes.Checked = Settings.Default.Every15minutes;
                radioButtonEvery30minutes.Checked = Settings.Default.Every30minutes;
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                          @", Break code at position " + MessagePositionString,
                                          @"SolutionsProperties, it's fail in InitializeProperties()",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void SaveTheProperties()
        {
            Settings.Default.NotifycationsEnableSendReceive = checkBox_EnableSendReceiveNotifycations.Checked;

            Settings.Default.NotificationsSendMyOwn = checkBox_SendMyOwnNotifications.Checked;
            Settings.Default.NotificationsShowMyOwn = checkBox_ShowMyOwnNotifications.Checked;
            Settings.Default.NotificationsShowWarnings = checkBox_ShowWarningsNotifications.Checked;
            Settings.Default.NotificationsShowEmails = checkBox_ShowEmailsNotifications.Checked;
            Settings.Default.NotificationsShowDataBaseUpDate = checkBox_ShowDataBaseUpdateNotifications.Checked;

            Settings.Default.SaveEachTimeTheInformationIsChanged = checkBoxSaveEachTimeTheInformationIsChanged.Checked;
            Settings.Default.SaveTheInformationByTime = checkBoxSaveTheInformationByTime.Checked;
            Settings.Default.SaveTheInformationWhenTheUserSave = checkBoxSaveTheInformationWhenTheUserSaves.Checked;
            Settings.Default.Every5minutes = radioButtonEvery5minutes.Checked;
            Settings.Default.Every15minutes = radioButtonEvery15minutes.Checked;
            Settings.Default.Every30minutes = radioButtonEvery30minutes.Checked;

            Settings.Default.IntervalReadingNotifications = (trackBar_Interval.Value * TimeUnit);
            Settings.Default.IntervalTrackBar_Value = trackBar_Interval.Value;
            Settings.Default.IntervalTimeUnitName = TimeUnitName;

            Settings.Default.DepartmentName = comboBox_ApplicationDepartmentName.Text;
            Settings.Default.ApplicationDefaultHtmlPages = textBoxApplicationHTMLtemples.Text;

            Settings.Default.Save();
        }

        #region"Application Setting Tab"

        string DesktopPathName;
        string StartupPathName;
        //Get the Assembly Name of the application
        string appname = Assembly.GetExecutingAssembly().FullName.Remove(Assembly.GetExecutingAssembly().FullName.IndexOf(","));

        //Used to stop the CheckBoxes CheckedChanged events from calling the CreateShortcut sub when the form is
        //loading and setting the Checkboxes states to true if the shortcuts exist.
        bool Loading = true;

        void InitializeApplicationSettingTab()
        {
            //Adds the applications AssemblyName to the Desktops path and adds the .lnk extension used for shortcuts
            DesktopPathName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), appname + ".lnk");
            //Adds the applications AssemblyName to the Startup folder path and adds the .lnk extension used for shortcuts
            StartupPathName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), appname + ".lnk");
            //Sets the Desktop checkbox checked state to true if the desktop shortcut exists
            CheckBox_ShowDesktopShortcut.Checked = File.Exists(DesktopPathName);
            //Sets the Startup Folder checkbox checked state to true if the Startup folder shortcut exists
            CheckBox_CreateStartupFolderShortcut.Checked = File.Exists(StartupPathName);
            //The checkboxes checked states have been set so set Loading to false to allow the CreateShortcut sub to be called now
            Loading = false;

            comboBox_ApplicationDepartmentName.DataSource = ListDepartments;
            comboBox_ApplicationDepartmentName.DisplayMember = "DeptName";
            comboBox_ApplicationDepartmentName.ValueMember = "DeptName";
            comboBox_ApplicationDepartmentName.SelectedValueChanged += ComboBox_ApplicationDepartmentName_SelectedValueChanged;
            comboBox_ApplicationDepartmentName.SelectedValue = Settings.Default.DepartmentName;

            textBox_DataBaseAddress.Text = Settings.Default.DataBaseAddress + "\\" + Settings.Default.DataBaseName;
            textBoxApplicationHTMLtemples.Text = Settings.Default.ApplicationDefaultHtmlPages;
        }

        void ComboBox_ApplicationDepartmentName_SelectedValueChanged(object sender, EventArgs e)
        {
            CurrentDepartmentLogIn = (DepartmentInformation)comboBox_ApplicationDepartmentName.SelectedItem;

            Settings.Default.InstallationFirstDate = DateTime.Now;

            InitializeDocumentationBehaviorProperties();
        }

        void checkBox_CheckInternetAccess_CheckedChanged(object sender, EventArgs e)
        {
            CheckForShortcut();
        }

        void CheckBox_ShowDesktopShortcut_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            CreateShortcut(DesktopPathName, CheckBox_ShowDesktopShortcut.Checked);
        }

        void CheckBox_CreateStartupFolderShortcut_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            CreateShortcut(StartupPathName, CheckBox_CreateStartupFolderShortcut.Checked);
        }

        /// <summary>Creates or removes a shortcut for this application at the specified pathname.</summary>
        /// <param name="shortcutPathName">The path where the shortcut is to be created or removed from including the (.lnk) extension.</param>
        /// <param name="create">True to create a shortcut or False to remove the shortcut.</param>
        void CreateShortcut(string shortcutPathName, bool create)
        {
            if (create)
            {
                try
                {
                    /*
                    string shortcutTarget = Path.Combine(Application.StartupPath, appname + ".exe");
                    var myShell = new IWshRuntimeLibrary.WshShell();
                    WshShortcut myShortcut = (WshShortcut)myShell.CreateShortcut(shortcutPathName);
                    myShortcut.TargetPath = shortcutTarget; //The exe file this shortcut executes when double clicked
                    myShortcut.IconLocation = shortcutTarget + ",0"; //Sets the icon of the shortcut to the exe`s icon
                    myShortcut.WorkingDirectory = Application.StartupPath; //The working directory for the exe
                    myShortcut.Arguments = ""; //The arguments used when executing the exe
                    myShortcut.Save();                //Creates the shortcut

                    */
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (File.Exists(shortcutPathName))
                        File.Delete(shortcutPathName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// This will create a Application Reference file on the users desktop
        /// if they do not already have one when the program is loaded.
        ///    If not debugging in visual studio check for Application Reference
        ///    #if (!debug)
        ///        CheckForShortcut();
        ///    #endif
        /// </summary
        void CheckForShortcut()
        {/*
            ApplicationDeployment appDep = ApplicationDeployment.CurrentDeployment;

            if (appDep.IsFirstRun)
            {
                Assembly code = Assembly.GetExecutingAssembly();

                string company = string.Empty;
                string description = string.Empty;

                if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
                {
                    AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code,
                        typeof(AssemblyCompanyAttribute));
                    company = ascompany.Company;
                }

                if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
                {
                    AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code,
                        typeof(AssemblyDescriptionAttribute));
                    description = asdescription.Description;
                }

                if (company != string.Empty && description != string.Empty)
                {
                    string desktopPath = string.Empty;
                    desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                        "\\", description, ".appref-ms");

                    string shortcutName = string.Empty;
                    shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                        "\\", company, "\\", description, ".appref-ms");

                    label_CompanyInfo.Text = desktopPath;
                    label_DescriptionInfo.Text = shortcutName;

                    File.Copy(shortcutName, desktopPath, true);
                }

            }
            */
        }

        #endregion"Application Setting"

        #region"USB-BarCode initialization."

        TreeNode Node_USBDeviceUtility;
        TreeNode Node_RecentAttachedDipositive;

        TreeNode Node_RecognizedDevicesSystem;

        TreeNode Node_RecentDetachedDipositive;

        /// <summary>
        /// List all devices recognized by the system in the past.
        /// </summary>
        StringCollection Recognized_Devices_System;
        int count;

        void Init_USB_BarCode()
        {
            Node_USBDeviceUtility = treeViewApplicationsSetting.Nodes["Node_USBDeviceUtility"];
            Node_RecentAttachedDipositive = Node_USBDeviceUtility.Nodes["Node_RecentAttachedDipositive"];
            Node_RecentDetachedDipositive = Node_USBDeviceUtility.Nodes["Node_RecentDetachedDipositive"];
            Node_RecognizedDevicesSystem = Node_USBDeviceUtility.Nodes["Node_RecognizedDevicesSystem"];

            Node_USBDeviceUtility.Nodes.Remove(Node_RecentAttachedDipositive);
            Node_USBDeviceUtility.Nodes.Remove(Node_RecentDetachedDipositive);


            Recognized_Devices_System = Settings.Default.BarCodeDevices;

            if (Recognized_Devices_System == null)
                Recognized_Devices_System = new StringCollection();
            else
            {
                foreach (string recognizedDevice in Recognized_Devices_System)
                {
                    count++;
                    var nodeDevice = new TreeNode("Scanner # " + count + ". " + recognizedDevice)
                    {
                        Name = recognizedDevice
                    };
                    Node_RecognizedDevicesSystem.Nodes.Add(nodeDevice);
                }
            }

            //PicturesBox

            grouper_AddNewPrintHelpsButtons.Resize += grouper_AddNewPrintHelpsButtons_Resize;
            button_PrintHelps.Click += PrintImage_Click;

            InitializeUSBarCodeListener();
        }

        private void Listener_BarcodeScanned(object sender, RawInputEventArg e)
        {
            richTextBox1.Focus();

            if (e != null)
            {
                isBarCodeText = true;
                richTextBox1.AppendText(e.BarcodeData);
            }
        }

        void InitializeUSBarCodeListener()
        {
            try
            {

            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"InitializeUSBarCodeListener found an error " + error.Message,
                                          @"Solutions Properties has generated an error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void grouper_AddNewPrintHelpsButtons_Resize(object sender, EventArgs e)
        {
            var betwen = 4;
            var spaceneed = 4 * betwen;

            int nextWidth = 0;
            nextWidth = (flowLayoutPanel_AddNewPrintHelpsButton.Width - spaceneed) / flowLayoutPanel_AddNewPrintHelpsButton.Controls.Count;

            button_AddNew.Width = button_Adjustment.Width = button_RemoveScanner.Width = button_PrintHelps.Width = nextWidth;
        }

        #region "PicturesBox"

        void PrintImage_Click(object sender, EventArgs e)
        {
            using (var printDocument = new PrintDocument())
            {
                printDocument.PrintPage += printDocument_PrintPage;
                printDocument.Print();
            }
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(PicturesBox_Image.Image, 0, 0);
        }

        // And save it:
        //by drawing image first on bitmap and then saving this bitmap
        public void ExportToBmp(string path)
        {
            using (var bitmap = new Bitmap(PicturesBox_Image.Width, PicturesBox_Image.Height))
            {
                PicturesBox_Image.DrawToBitmap(bitmap, PicturesBox_Image.ClientRectangle);
                bitmap.Save(path, ImageFormat.Bmp);
            }
        }

        #endregion"PicturesBox"

        #endregion"USB-BarCode initialization."

        #region"TreeViewSetting"

        // Node being dragged
        TreeNode dragNode;
        // Temporary drop node for selection
        TreeNode tempDropNode;
        // Timer for scrolling
        System.Windows.Forms.Timer TreeViewSettingScrollingTimer = new System.Windows.Forms.Timer();

        TreeNode InstallationLogNode;

        TreeNode ProcessorNode;
        TreeNode LogicalDiskNode;
        TreeNode VideoControllerNode;
        TreeNode SystemInformationNode;
        TreeNode AppInstalledNode;

        void InitializeTreeViewApplicationsSetting()
        {
            treeViewApplicationsSetting.AllowDrop = true;

            treeViewApplicationsSetting.BeforeCollapse += TreeViewApplicationsSettingBeforeCollapse;
            treeViewApplicationsSetting.ItemDrag += TreeViewApplicationsSetting_ItemDrag;
            treeViewApplicationsSetting.DragDrop += TreeViewApplicationsSetting_DragDrop;
            treeViewApplicationsSetting.DragEnter += TreeViewApplicationsSetting_DragEnter;
            treeViewApplicationsSetting.DragOver += TreeViewApplicationsSetting_DragOver;
            treeViewApplicationsSetting.DragLeave += TreeViewApplicationsSetting_DragLeave;
            treeViewApplicationsSetting.GiveFeedback += TreeViewApplicationsSetting_GiveFeedback;

            treeViewApplicationsSetting.NodeMouseClick += TreeViewApplicationsSettingNodeMouseClick;
            treeViewApplicationsSetting.NodeMouseDoubleClick += TreeViewApplicationsSetting_NodeMouseDoubleClick;

            treeViewApplicationsSetting.ExpandAll();

            TreeViewSettingScrollingTimer.Interval = 200;
            TreeViewSettingScrollingTimer.Tick += TreeViewSettingScrollingTimer_Tick;

            InstallationLogNode = treeViewApplicationsSetting.Nodes["Node_InstallationLog"];
            SystemInformationNode = InstallationLogNode.Nodes["Node_SystemInformation"];
            ProcessorNode = InstallationLogNode.Nodes["Node_Processor"];
            LogicalDiskNode = InstallationLogNode.Nodes["Node_LogicalDisk"];
            VideoControllerNode = InstallationLogNode.Nodes["Node_VideoController"];
            AppInstalledNode = InstallationLogNode.Nodes["Node_AppIntalled"];
        }

        TreeNode toReturn;
        TreeNode GetRootNode(TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                toReturn = e.Node;
                return e.Node;
            }

            GetRootNode(new TreeViewEventArgs(e.Node.Parent));

            return toReturn;
        }

        void TreeViewApplicationsSettingNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string nodeName = e.Node.Name.Replace("Node_", "") + "Tab";
            string tabPageName = "   " + e.Node.Text;

            if (customTabControlSetting.ContainTabPage(tabPageName))
                customTabControlSetting.SelectTabPage(tabPageName);
            else
            {
                if (e.Node.Parent != null)
                    tabPageName = "   " + e.Node.Parent.Text;

                if (customTabControlSetting.ContainTabPage(tabPageName))
                    customTabControlSetting.SelectTabPage(tabPageName);
            }

            //Remember the treeNode most have the same name as the tab page.
            switch (customTabControlSetting.SelectedTab.Text)
            {
                case "   USB Device Utility":
                    {
                        GetPicturesProccess(Settings.Default.DataBaseAddress + "\\Pictures\\" + "Barcode System Help.jpg");
                        break;
                    }
                case "   Installation Log":
                    {
                        break;
                    }
                case "   System Compatibility":
                    {
                        Initialize_SystemCompatibility();
                        break;
                    }
            }
        }

        void TreeViewApplicationsSetting_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null && e.Node.Parent.Text.Contains("Installation Log"))
            {
                #region"Installation Log"
                if (InformationTimer == null)
                {
                    InformationTimer = new System.Windows.Forms.Timer();
                    InformationTimer.Interval = 500;

                    firstProcessTimer = Stopwatch.StartNew();
                }

                InformationTimer.Start();
                firstProcessTimer.Start();

                if (e.Node.Text.Contains("System Information"))
                {
                    InformationTimer.Tick += new EventHandler(InformationSystemTimer_Tick);
                    Task.Factory.StartNew(() => SystemInformation = SystemInformationProcess());
                }

                if (e.Node.Text.Contains("Processor"))
                {
                    InformationTimer.Tick += new EventHandler(InformationProcessorTimer_Tick);
                    Task.Factory.StartNew(() => ProcessorInformation = DeviceInformation("Win32_Processor"));
                }

                if (e.Node.Text.Contains("LogicalDisk"))
                {
                    InformationTimer.Tick += new EventHandler(InformationLogicalTimer_Tick);
                    Task.Factory.StartNew(() => LogicalDiskInformation = DeviceInformation("Win32_LogicalDisk"));
                }

                if (e.Node.Text.Contains("VideoController"))
                {
                    InformationTimer.Tick += new EventHandler(InformationVideoTimer_Tick);
                    Task.Factory.StartNew(() => VideoControllerInformation = DeviceInformation("Win32_VideoController"));
                }

                #endregion"Installation Log"
            }
        }

        void TreeViewApplicationsSettingBeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        void TreeViewApplicationsSetting_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Get drag node and select it
            dragNode = (TreeNode)e.Item;
            treeViewApplicationsSetting.SelectedNode = dragNode;

            // Reset image list used for drag image
            imageListDrag.Images.Clear();
            imageListDrag.ImageSize = new Size(dragNode.Bounds.Size.Width + treeViewApplicationsSetting.Indent, dragNode.Bounds.Height);

            // Create new bitmap
            // This bitmap will contain the tree node image to be dragged
            Bitmap bmp = new Bitmap(dragNode.Bounds.Width + treeViewApplicationsSetting.Indent, dragNode.Bounds.Height);

            // Get graphics from bitmap
            Graphics gfx = Graphics.FromImage(bmp);

            // Draw node icon into the bitmap
            gfx.DrawImage(imageListTreeView.Images[0], 0, 0);

            // Draw node label into bitmap
            gfx.DrawString(dragNode.Text,
                treeViewApplicationsSetting.Font,
                new SolidBrush(treeViewApplicationsSetting.ForeColor),
                (float)treeViewApplicationsSetting.Indent, 1.0f);

            // Add bitmap to imagelist
            imageListDrag.Images.Add(bmp);

            // Get mouse position in client coordinates
            Point p = treeViewApplicationsSetting.PointToClient(Control.MousePosition);

            // Compute delta between mouse position and node bounds
            int dx = p.X + treeViewApplicationsSetting.Indent - dragNode.Bounds.Left;
            int dy = p.Y - dragNode.Bounds.Top;

            // Begin dragging image
            if (DragHelper.ImageList_BeginDrag(imageListDrag.Handle, 0, dx, dy))
            {
                // Begin dragging
                treeViewApplicationsSetting.DoDragDrop(bmp, DragDropEffects.Move);
                // End dragging image
                DragHelper.ImageList_EndDrag();
            }

        }

        void TreeViewApplicationsSetting_DragOver(object sender, DragEventArgs e)
        {
            // Compute drag position and move image
            Point formP = PointToClient(new Point(e.X, e.Y));
            DragHelper.ImageList_DragMove(formP.X - treeViewApplicationsSetting.Left, formP.Y - treeViewApplicationsSetting.Top);

            // Get actual drop node
            TreeNode dropNode = treeViewApplicationsSetting.GetNodeAt(treeViewApplicationsSetting.PointToClient(new Point(e.X, e.Y)));
            if (dropNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = DragDropEffects.Move;

            // if mouse is on a new node select it
            if (tempDropNode != dropNode)
            {
                DragHelper.ImageList_DragShowNolock(false);
                treeViewApplicationsSetting.SelectedNode = dropNode;
                DragHelper.ImageList_DragShowNolock(true);
                tempDropNode = dropNode;
            }

            // Avoid that drop node is child of drag node
            TreeNode tmpNode = dropNode;
            while (tmpNode.Parent != null)
            {
                if (tmpNode.Parent == dragNode) e.Effect = DragDropEffects.None;
                tmpNode = tmpNode.Parent;
            }
        }

        bool toTest = true;
        void TreeViewApplicationsSetting_DragDrop(object sender, DragEventArgs e)
        {
            // Unlock updates
            DragHelper.ImageList_DragLeave(treeViewApplicationsSetting.Handle);
            // Get drop node
            TreeNode dropNode = treeViewApplicationsSetting.GetNodeAt(treeViewApplicationsSetting.PointToClient(new Point(e.X, e.Y)));
            // If drop node is equal to drag node, return.
            if (dragNode == dropNode)
                return;

            bool acceptDrop = true; // (bool)dropNode.Tag;

            if (!acceptDrop)
                return;

            if (dropNode.Name.Contains(nameof(Node_RecognizedDevicesSystem)))
            {
                dropNode.Text = "Recognized Devices in the System";
                dropNode.ImageIndex = 6;
                dropNode.SelectedImageIndex = 6;

                if (Recognized_Devices_System == null)
                    Recognized_Devices_System = new StringCollection();

                //"HID#Vid_05E0&Pid_1200" --> format to be saved.
                string newArrivalDevice = "HID#Vid_";// + DeviceArrival.Device.IdVendor.ToString("X4") +
                                                     //       "&Pid_" + DeviceArrival.Device.IdProduct.ToString("X4");

                if (Recognized_Devices_System.Contains(newArrivalDevice))
                {
                    MessageBox.Show(new Form() { TopMost = true }, @"Sorry, this device is already recognized by the system.",
                                 @"Duplicated device.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    Recognized_Devices_System.Add(newArrivalDevice);

                Settings.Default.BarCodeDevices = Recognized_Devices_System;
                Settings.Default.Save();

                InitializeUSBarCodeListener();

                return;
            }

            if (toTest)
                return;
            else
            {
                // Remove drag node from parent
                if (dragNode.Parent == null)
                {
                    treeViewApplicationsSetting.Nodes.Remove(dragNode);
                }
                else
                {
                    dragNode.Parent.Nodes.Remove(dragNode);
                }

                // Add drag node to drop node
                dropNode.Nodes.Add(dragNode);
                dropNode.ExpandAll();
                // Set drag node to null
                dragNode = null;
                // Disable scroll timer
                TreeViewSettingScrollingTimer.Enabled = false;
            }
        }

        void TreeViewApplicationsSetting_DragEnter(object sender, DragEventArgs e)
        {
            DragHelper.ImageList_DragEnter(treeViewApplicationsSetting.Handle, e.X - treeViewApplicationsSetting.Left,
                e.Y - treeViewApplicationsSetting.Top);

            // Enable timer for scrolling dragged item
            TreeViewSettingScrollingTimer.Enabled = true;
        }

        void TreeViewApplicationsSetting_DragLeave(object sender, EventArgs e)
        {
            DragHelper.ImageList_DragLeave(treeViewApplicationsSetting.Handle);

            // Disable timer for scrolling dragged item
            TreeViewSettingScrollingTimer.Enabled = false;
        }

        void TreeViewApplicationsSetting_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                // Show pointer cursor while dragging
                e.UseDefaultCursors = false;
                treeViewApplicationsSetting.Cursor = Cursors.Default;
            }
            else e.UseDefaultCursors = true;

        }

        void TreeViewSettingScrollingTimer_Tick(object sender, EventArgs e)
        {
            // get node at mouse position
            Point pt = PointToClient(Control.MousePosition);
            TreeNode node = treeViewApplicationsSetting.GetNodeAt(pt);

            if (node == null) return;

            // if mouse is near to the top, scroll up
            if (pt.Y < 30)
            {
                // set actual node to the upper one
                if (node.PrevVisibleNode != null)
                {
                    node = node.PrevVisibleNode;

                    // hide drag image
                    DragHelper.ImageList_DragShowNolock(false);
                    // scroll and refresh
                    node.EnsureVisible();
                    treeViewApplicationsSetting.Refresh();
                    // show drag image
                    DragHelper.ImageList_DragShowNolock(true);

                }
            }
            // if mouse is near to the bottom, scroll down
            else if (pt.Y > treeViewApplicationsSetting.Size.Height - 30)
            {
                if (node.NextVisibleNode != null)
                {
                    node = node.NextVisibleNode;

                    DragHelper.ImageList_DragShowNolock(false);
                    node.EnsureVisible();
                    treeViewApplicationsSetting.Refresh();
                    DragHelper.ImageList_DragShowNolock(true);
                }
            }
        }


        void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _contextMenuStrip.Items.Clear();

            if (treeViewApplicationsSetting.SelectedNode == null)
                return;

            if (CurrentEmployeesLogIn.EmployeeAccessLevel > MyCode.AccessLevel.Administrator)
            {
                if (treeViewApplicationsSetting.SelectedNode.Text.Contains("USB Device Utility"))
                    if (Recognized_Devices_System.Count > 0)
                    {
                        toolStripMenuItem_ClearDevices.Text = "Clear devices: " + Recognized_Devices_System.Count;
                        _contextMenuStrip.Items.AddRange(new ToolStripMenuItem[]
                                                        {
                                                            toolStripMenuItem_ClearDevices,
                                                        });
                    }
            }

            if (treeViewApplicationsSetting.SelectedNode.Parent != null)
                if (treeViewApplicationsSetting.SelectedNode.Parent.Text.Contains("Recognized Devices in the System"))
                {
                    //_contextMenuStrip.Items.Add(toolStripSeparator1);
                    _contextMenuStrip.Items.AddRange(new ToolStripMenuItem[]
                                                     {
                                                         toolStripMenuItem_Deleted_USB,
                                                     });
                }
        }

        void ToolStripMenuItem_ClearDevices_Click(object sender, EventArgs e)
        {
            Recognized_Devices_System.Clear();

            Settings.Default.BarCodeDevices = Recognized_Devices_System;
        }

        void ToolStripMenuItem_Deleted_USB_Click(object sender, EventArgs e)
        {
            if (treeViewApplicationsSetting.SelectedNode == null)
                return;

            Recognized_Devices_System.Remove(treeViewApplicationsSetting.SelectedNode.Text);

            Settings.Default.BarCodeDevices = Recognized_Devices_System;
            //Settings.Default.Save();

            Node_RecognizedDevicesSystem.Nodes.Remove(treeViewApplicationsSetting.SelectedNode);

        }


        void InformationSystemTimer_Tick(object sender, EventArgs e)
        {
            if (_system)
                UpDateNode(SystemInformationNode, "System Information");
            else
                SystemInformationNode.ImageIndex = 3;

            // if one task are not finished, return.
            if (_system)
            {
                InstallationLogNode.ImageIndex = 4;
                return;
            }

            // if all task are finished, stop the timer.
            InstallationLogNode.ImageIndex = 3;
            firstProcessTimer.Stop();
            InformationTimer.Stop();

            InformationTimer = null;

            richTextBox_FirstInstalation.AppendText("The installation manager will check for necessary installed components....." +
                                                                 Environment.NewLine);

            richTextBox_FirstInstalation.AppendText("Getting system information" + Environment.NewLine);
            richTextBox_FirstInstalation.AppendText(SystemInformation);
        }

        void InformationProcessorTimer_Tick(object sender, EventArgs e)
        {
            if (processor)
                UpDateNode(ProcessorNode, "Processor ");
            else
                ProcessorNode.ImageIndex = 3;

            // if one task are not finished, return.
            if (processor)
            {
                InstallationLogNode.ImageIndex = 4;
                return;
            }

            // if all task are finished, stop the timer.
            InstallationLogNode.ImageIndex = 3;
            firstProcessTimer.Stop();
            InformationTimer.Stop();

            InformationTimer = null;

            richTextBox_FirstInstalation.AppendText("The installation manager will check for necessary installed components....." +
                                                                 Environment.NewLine);

            richTextBox_FirstInstalation.AppendText("Getting processor information" + Environment.NewLine);
            richTextBox_FirstInstalation.AppendText(ProcessorInformation);
        }

        void InformationLogicalTimer_Tick(object sender, EventArgs e)
        {
            if (logical)
                UpDateNode(LogicalDiskNode, "LogicalDisk");
            else
                LogicalDiskNode.ImageIndex = 3;

            // if one task are not finished, return.
            if (logical)
            {
                InstallationLogNode.ImageIndex = 4;
                return;
            }

            // if all task are finished, stop the timer.
            InstallationLogNode.ImageIndex = 3;
            firstProcessTimer.Stop();
            InformationTimer.Stop();

            InformationTimer = null;

            richTextBox_FirstInstalation.AppendText("The installation manager will check for necessary installed components....." +
                                                                 Environment.NewLine);

            richTextBox_FirstInstalation.AppendText("Getting logical disk information" + Environment.NewLine);
            richTextBox_FirstInstalation.AppendText(LogicalDiskInformation);
        }

        void InformationVideoTimer_Tick(object sender, EventArgs e)
        {
            if (videoIns)
                UpDateNode(VideoControllerNode, "VideoController");
            else
                VideoControllerNode.ImageIndex = 3;

            // if one task are not finished, return.
            if (videoIns)
            {
                InstallationLogNode.ImageIndex = 4;
                return;
            }

            // if all task are finished, stop the timer.
            InstallationLogNode.ImageIndex = 3;
            firstProcessTimer.Stop();
            InformationTimer.Stop();

            InformationTimer = null;

            richTextBox_FirstInstalation.AppendText("The installation manager will check for necessary installed components....." +
                                                                 Environment.NewLine);

            richTextBox_FirstInstalation.AppendText("Getting video controller information" + Environment.NewLine);
            richTextBox_FirstInstalation.AppendText(VideoControllerInformation);
        }


        #endregion"TreeViewSetting"

        #region"RichTextBox"

        bool isBarCodeText;
        System.Windows.Forms.Timer TextTimert;

        void InitializeRichTextBox()
        {
            richTextBox1.TextChanged += new EventHandler(richTextBox1_TextChanged);

            TextTimert = new System.Windows.Forms.Timer();
            TextTimert.Interval = 500;
            TextTimert.Tick += new EventHandler(TextTimert_Tick);
        }

        void TextTimert_Tick(object sender, EventArgs e)
        {
            TextTimert.Stop();

            if (richTextBox1.Text.Length < 24)
                return;

            string lastText = richTextBox1.Text.Substring(richTextBox1.Text.Length - 24, 24);

            if (lastText.Contains("ABCDEFGHIJKLMNOPQRSTUVYZ"))
            {
                richTextBox1.AppendText(Environment.NewLine + "          Test BarCode Label received," +
                                                        " check the help seccion Add USB device." + Environment.NewLine);
            }
        }

        void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (isBarCodeText)
            {
                isBarCodeText = false;
                return;
            }

            //  TextTimert.Start();
        }

        #endregion"RichTextBox"

        #region"First Installation"

        void FirstInstallation()
        {
            Settings.Default.InstallationFirstDate = DateTime.Now;
            Settings.Default.InstallationFirstUser = "";
        }

        List<string> safd = new List<string>()
        {
            #region"Win32_Class"
            "Win32_1394Controller",
            "Win32_1394ControllerDevice",
            "Win32_AccountSID",
            "Win32_ActionCheck",
            "Win32_ActiveRoute",
            "Win32_AllocatedResource",
            "Win32_ApplicationCommandLine",
            "Win32_ApplicationService",
            "Win32_AssociatedBattery",
            "Win32_AssociatedProcessorMemory",
            "Win32_AutochkSetting",
            "Win32_BaseBoard",
            "Win32_Battery",
            "Win32_Binary",
            "Win32_BindImageAction",
            "Win32_BIOS",
            "Win32_BootConfiguration",
            "Win32_Bus Win32_CacheMemory",
            "Win32_CDROMDrive",
            "Win32_CheckCheck",
            "Win32_CIMLogicalDeviceCIMDataFile",
            "Win32_ClassicCOMApplicationClasses",
            "Win32_ClassicCOMClass",
            "Win32_ClassicCOMClassSetting",
            "Win32_ClassicCOMClassSettings",
            "Win32_ClassInforAction",
            "Win32_ClientApplicationSetting",
            "Win32_CodecFile",
            "Win32_COMApplicationSettings",
            "Win32_COMClassAutoEmulator",
            "Win32_ComClassEmulator",
            "Win32_CommandLineAccess",
            "Win32_ComponentCategory",
            "Win32_ComputerSystem",
            "Win32_ComputerSystemProcessor",
            "Win32_ComputerSystemProduct",
            "Win32_ComputerSystemWindowsProductActivationSetting",
            "Win32_Condition",
            "Win32_ConnectionShare",
            "Win32_ControllerHastHub",
            "Win32_CreateFolderAction",
            "Win32_CurrentProbe",
            "Win32_DCOMApplication",
            "Win32_DCOMApplicationAccessAllowedSetting",
            "Win32_DCOMApplicationLaunchAllowedSetting",
            "Win32_DCOMApplicationSetting",
            "Win32_DependentService",
            "Win32_Desktop",
            "Win32_DesktopMonitor",
            "Win32_DeviceBus",
            "Win32_DeviceMemoryAddress",
            "Win32_Directory",
            "Win32_DirectorySpecification",
            "Win32_DiskDrive",
            "Win32_DiskDrivePhysicalMedia",
            "Win32_DiskDriveToDiskPartition",
            "Win32_DiskPartition",
            "Win32_DiskQuota",
            "Win32_DisplayConfiguration",
            "Win32_DisplayControllerConfiguration",
            "Win32_DMAChanner",
            "Win32_DriverForDevice",
            "Win32_DriverVXD",
            "Win32_DuplicateFileAction",
            "Win32_Environment",
            "Win32_EnvironmentSpecification",
            "Win32_ExtensionInfoAction",
            "Win32_Fan",
            "Win32_FileSpecification",
            "Win32_FloppyController",
            "Win32_FloppyDrive",
            "Win32_FontInfoAction",
            "Win32_Group",
            "Win32_GroupDomain",
            "Win32_GroupUser",
            "Win32_HeatPipe",
            "Win32_IDEController",
            "Win32_IDEControllerDevice",
            "Win32_ImplementedCategory",
            "Win32_InfraredDevice",
            "Win32_IniFileSpecification",
            "Win32_InstalledSoftwareElement",
            "Win32_IP4PersistedRouteTable",
            "Win32_IP4RouteTable",
            "Win32_IRQResource",
            "Win32_Keyboard",
            "Win32_LaunchCondition",
            "Win32_LoadOrderGroup",
            "Win32_LoadOrderGroupServiceDependencies",
            "Win32_LoadOrderGroupServiceMembers",
            "Win32_LocalTime",
            "Win32_LoggedOnUser",
            "Win32_LogicalDisk",
            "Win32_LogicalDiskRootDirectory",
            "Win32_LogicalDiskToPartition",
            "Win32_LogicalFileAccess",
            "Win32_LogicalFileAuditing",
            "Win32_LogicalFileGroup",
            "Win32_LogicalFileOwner",
            "Win32_LogicalFileSecuritySetting",
            "Win32_LogicalMemoryConfiguration",
            "Win32_LogicalProgramGroup",
            "Win32_LogicalProgramGroupDirectory",
            "Win32_LogicalProgramGroupItem",
            "Win32_LogicalProgramGroupItemDataFile",
            "Win32_LogicalShareAccess",
            "Win32_LogicalShareAuditing",
            "Win32_LogicalShareSecuritySetting",
            "Win32_LogonSession",
            "Win32_LogonSessionMappedDisk",
            "Win32_MappedLogicalDisk",
            "Win32_MemoryArray",
            "Win32_MemoryArrayLocation",
            "Win32_MemoryDevice",
            "Win32_MemoryDeviceArray",
            "Win32_MemoryDeviceLocation",
            "Win32_MIMEInfoAction",
            "Win32_MotherboardDevice",
            "Win32_MoveFileAction",
            "Win32_NamedJobObject",
            "Win32_NamedJobObjectActgInfo",
            "Win32_NamedJobObjectLimit",
            "Win32_NamedJobObjectLimitSetting",
            "Win32_NamedJobObjectProcess",
            "Win32_NamedJobObjectSecLimit",
            "Win32_NamedJobObjectSecLimitSetting",
            "Win32_NamedJobObjectStatistics",
            "Win32_NetworkAdapter",
            "Win32_NetworkAdapterConfiguration",
            "Win32_NetworkAdapterSetting",
            "Win32_NetworkClient",
            "Win32_NetworkConnection",
            "Win32_NetworkLoginProfile",
            "Win32_NetworkProtocol",
            "Win32_NTDomain",
            "Win32_NTEventlogFile",
            "Win32_NTLogEvent",
            "Win32_NTLogEventComputer",
            "Win32_NTLogEvnetLog",
            "Win32_NTLogEventUser",
            "Win32_ODBCAttribute",
            "Win32_ODBCDataSourceAttribute",
            "Win32_ODBCDataSourceSpecification",
            "Win32_ODBCDriverAttribute",
            "Win32_ODBCDriverSoftwareElement",
            "Win32_ODBCDriverSpecification",
            "Win32_ODBCSourceAttribute",
            "Win32_ODBCTranslatorSpecification",
            "Win32_OnBoardDevice",
            "Win32_OperatingSystem",
            "Win32_OperatingSystemAutochkSetting",
            "Win32_OperatingSystemQFE",
            "Win32_OSRecoveryConfiguración",
            "Win32_PageFile",
            "Win32_PageFileElementSetting",
            "Win32_PageFileSetting",
            "Win32_PageFileUsage",
            "Win32_ParallelPort",
            "Win32_Patch",
            "Win32_PatchFile",
            "Win32_PatchPackage",
            "Win32_PCMCIAControler",
            "Win32_PerfFormattedData_ASP_ActiveServerPages",
            "Win32_PerfFormattedData_ASPNET_114322_ASPNETAppsv114322",
            "Win32_PerfFormattedData_ASPNET_114322_ASPNETv114322",
            "Win32_PerfFormattedData_ASPNET_2040607_ASPNETAppsv2040607",
            "Win32_PerfFormattedData_ASPNET_2040607_ASPNETv2040607",
            "Win32_PerfFormattedData_ASPNET_ASPNET",
            "Win32_PerfFormattedData_ASPNET_ASPNETApplications",
            "Win32_PerfFormattedData_aspnet_state_ASPNETStateService",
            "Win32_PerfFormattedData_ContentFilter_IndexingServiceFilter",
            "Win32_PerfFormattedData_ContentIndex_IndexingService",
            "Win32_PerfFormattedData_DTSPipeline_SQLServerDTSPipeline",
            "Win32_PerfFormattedData_Fax_FaxServices",
            "Win32_PerfFormattedData_InetInfo_InternetInformationServicesGlobal",
            "Win32_PerfFormattedData_ISAPISearch_HttpIndexingService",
            "Win32_PerfFormattedData_MSDTC_DistributedTransactionCoordinator",
            "Win32_PerfFormattedData_NETCLRData_NETCLRData",
            "Win32_PerfFormattedData_NETCLRNetworking_NETCLRNetworking",
            "Win32_PerfFormattedData_NETDataProviderforOracle_NETCLRData",
            "Win32_PerfFormattedData_NETDataProviderforSqlServer_NETDataProviderforSqlServer",
            "Win32_PerfFormattedData_NETFramework_NETCLRExceptions",
            "Win32_PerfFormattedData_NETFramework_NETCLRInterop",
            "Win32_PerfFormattedData_NETFramework_NETCLRJit",
            "Win32_PerfFormattedData_NETFramework_NETCLRLoading",
            "Win32_PerfFormattedData_NETFramework_NETCLRLocksAndThreads",
            "Win32_PerfFormattedData_NETFramework_NETCLRMemory",
            "Win32_PerfFormattedData_NETFramework_NETCLRRemoting",
            "Win32_PerfFormattedData_NETFramework_NETCLRSecurity",
            "Win32_PerfFormattedData_NTFSDRV_ControladordealmacenamientoNTFSdeSMTP",
            "Win32_PerfFormattedData_Outlook_Outlook",
            "Win32_PerfFormattedData_PerfDisk_LogicalDisk",
            "Win32_PerfFormattedData_PerfDisk_PhysicalDisk",
            "Win32_PerfFormattedData_PerfNet_Browser",
            "Win32_PerfFormattedData_PerfNet_Redirector",
            "Win32_PerfFormattedData_PerfNet_Server",
            "Win32_PerfFormattedData_PerfNet_ServerWorkQueues",
            "Win32_PerfFormattedData_PerfOS_Cache",
            "Win32_PerfFormattedData_PerfOS_Memory",
            "Win32_PerfFormattedData_PerfOS_Objects",
            "Win32_PerfFormattedData_PerfOS_PagingFile",
            "Win32_PerfFormattedData_PerfOS_Processor",
            "Win32_PerfFormattedData_PerfOS_System",
            "Win32_PerfFormattedData_PerfProc_FullImage_Costly",
            "Win32_PerfFormattedData_PerfProc_Image_Costly",
            "Win32_PerfFormattedData_PerfProc_JobObject",
            "Win32_PerfFormattedData_PerfProc_JobObjectDetails",
            "Win32_PerfFormattedData_PerfProc_Process",
            "Win32_PerfFormattedData_PerfProc_ProcessAddressSpace_Costly",
            "Win32_PerfFormattedData_PerfProc_Thread",
            "Win32_PerfFormattedData_PerfProc_ThreadDetails_Costly",
            "Win32_PerfFormattedData_RemoteAccess_RASPort",
            "Win32_PerfFormattedData_RemoteAccess_RASTotal",
            "Win32_PerfFormattedData_RSVP_RSVPInterfaces",
            "Win32_PerfFormattedData_RSVP_RSVPService",
            "Win32_PerfFormattedData_Spooler_PrintQueue",
            "Win32_PerfFormattedData_TapiSrv_Telephony",
            "Win32_PerfFormattedData_Tcpip_ICMP",
            "Win32_PerfFormattedData_Tcpip_IP",
            "Win32_PerfFormattedData_Tcpip_NBTConnection",
            "Win32_PerfFormattedData_Tcpip_NetworkInterface",
            "Win32_PerfFormattedData_Tcpip_TCP",
            "Win32_PerfFormattedData_Tcpip_UDP",
            "Win32_PerfFormattedData_TermService_TerminalServices",
            "Win32_PerfFormattedData_TermService_TerminalServicesSession",
            "Win32_PerfFormattedData_W3SVC_WebService",
            "Win32_PerfRawData_ASP_ActiveServerPages",
            "Win32_PerfRawData_ASPNET_114322_ASPNETAppsv114322",
            "Win32_PerfRawData_ASPNET_114322_ASPNETv114322",
            "Win32_PerfRawData_ASPNET_2040607_ASPNETAppsv2040607",
            "Win32_PerfRawData_ASPNET_2040607_ASPNETv2040607",
            "Win32_PerfRawData_ASPNET_ASPNET",
            "Win32_PerfRawData_ASPNET_ASPNETApplications",
            "Win32_PerfRawData_aspnet_state_ASPNETStateService",
            "Win32_PerfRawData_ContentFilter_IndexingServiceFilter",
            "Win32_PerfRawData_ContentIndex_IndexingService",
            "Win32_PerfRawData_DTSPipeline_SQLServerDTSPipeline",
            "Win32_PerfRawData_Fax_FaxServices",
            "Win32_PerfRawData_InetInfo_InternetInformationServicesGlobal",
            "Win32_PerfRawData_ISAPISearch_HttpIndexingService",
            "Win32_PerfRawData_MSDTC_DistributedTransactionCoordinator",
            "Win32_PerfRawData_NETCLRData_NETCLRData",
            "Win32_PerfRawData_NETCLRNetworking_NETCLRNetworking",
            "Win32_PerfRawData_NETDataProviderforOracle_NETCLRData",
            "Win32_PerfRawData_NETDataProviderforSqlServer_NETDataProviderforSqlServer",
            "Win32_PerfRawData_NETFramework_NETCLRExceptions",
            "Win32_PerfRawData_NETFramework_NETCLRInterop",
            "Win32_PerfRawData_NETFramework_NETCLRJit",
            "Win32_PerfRawData_NETFramework_NETCLRLoading",
            "Win32_PerfRawData_NETFramework_NETCLRLocksAndThreads",
            "Win32_PerfRawData_NETFramework_NETCLRMemory",
            "Win32_PerfRawData_NETFramework_NETCLRRemoting",
            "Win32_PerfRawData_NETFramework_NETCLRSecurity",
            "Win32_PerfRawData_NTFSDRV_ControladordealmacenamientoNTFSdeSMTP",
            "Win32_PerfRawData_Outlook_Outlook",
            "Win32_PerfRawData_PerfDisk_LogicalDisk",
            "Win32_PerfRawData_PerfDisk_PhysicalDisk",
            "Win32_PerfRawData_PerfNet_Browser",
            "Win32_PerfRawData_PerfNet_Redirector",
            "Win32_PerfRawData_PerfNet_Server",
            "Win32_PerfRawData_PerfNet_ServerWorkQueues",
            "Win32_PerfRawData_PerfOS_Cache",
            "Win32_PerfRawData_PerfOS_Memory",
            "Win32_PerfRawData_PerfOS_Objects",
            "Win32_PerfRawData_PerfOS_PagingFile",
            "Win32_PerfRawData_PerfOS_Processor",
            "Win32_PerfRawData_PerfOS_System",
            "Win32_PerfRawData_PerfProc_FullImage_Costly",
            "Win32_PerfRawData_PerfProc_Image_Costly",
            "Win32_PerfRawData_PerfProc_JobObject",
            "Win32_PerfRawData_PerfProc_JobObjectDetails",
            "Win32_PerfRawData_PerfProc_Process",
            "Win32_PerfRawData_PerfProc_ProcessAddressSpace_Costly",
            "Win32_PerfRawData_PerfProc_Thread",
            "Win32_PerfRawData_PerfProc_ThreadDetails_Costly",
            "Win32_PerfRawData_RemoteAccess_RASPort",
            "Win32_PerfRawData_RemoteAccess_RASTotal",
            "Win32_PerfRawData_RSVP_RSVPInterfaces",
            "Win32_PerfRawData_RSVP_RSVPService",
            "Win32_PerfRawData_Spooler_PrintQueue",
            "Win32_PerfRawData_TapiSrv_Telephony",
            "Win32_PerfRawData_Tcpip_ICMP",
            "Win32_PerfRawData_Tcpip_IP",
            "Win32_PerfRawData_Tcpip_NBTConnection",
            "Win32_PerfRawData_Tcpip_NetworkInterface",
            "Win32_PerfRawData_Tcpip_TCP",
            "Win32_PerfRawData_Tcpip_UDP",
            "Win32_PerfRawData_TermService_TerminalServices",
            "Win32_PerfRawData_TermService_TerminalServicesSession",
            "Win32_PerfRawData_W3SVC_WebService",
            "Win32_PhysicalMedia",
            "Win32_PhysicalMemory",
            "Win32_PhysicalMemoryArray",
            "Win32_PhysicalMemoryLocation",
            "Win32_PingStatus",
            "Win32_PNPAllocatedResource",
            "Win32_PnPDevice",
            "Win32_PnPEntity",
            "Win32_PnPSignedDriver",
            "Win32_PnPSignedDriverCIMDataFile",
            "Win32_PointingDevice",
            "Win32_PortableBattery",
            "Win32_PortConnector",
            "Win32_PortResource",
            "Win32_POTSModem",
            "Win32_POTSModemToSerialPort",
            "Win32_Printer",
            "Win32_PrinterConfiguration",
            "Win32_PrinterController",
            "Win32_PrinterDriver",
            "Win32_PrinterDriverDll",
            "Win32_PrinterSetting",
            "Win32_PrinterShare",
            "Win32_PrintJob",
            "Win32_Process",
            "Win32_Processor",
            "Win32_Product",
            "Win32_ProductCheck",
            "Win32_ProductResource",
            "Win32_ProductSoftwareFeatures",
            "Win32_ProgIDSpecification",
            "Win32_ProgramGroup",
            "Win32_ProgramGroupContents",
            "Win32_Property",
            "Win32_ProtocolBinding",
            "Win32_Proxy",
            "Win32_PublishComponentAction",
            "Win32_QuickFixEngineering",
            "Win32_QuotaSetting",
            "Win32_Refrigeration",
            "Win32_Registry",
            "Win32_RegistryAction",
            "Win32_RemoveFileAction",
            "Win32_RemoveIniAction",
            "Win32_ReserveCost",
            "Win32_ScheduledJob",
            "Win32_SCSIController",
            "Win32_SCSIControllerDevice",
            "Win32_SecuritySettingOfLogicalFile",
            "Win32_SecuritySettingOfLogicalShare",
            "Win32_SelfRegModuleAction",
            "Win32_SerialPort",
            "Win32_SerialPortConfiguration",
            "Win32_SerialPortSetting",
            "Win32_ServerConnection",
            "Win32_ServerSession",
            "Win32_Service",
            "Win32_ServiceControl",
            "Win32_ServiceSpecification",
            "Win32_ServiceSpecificationService",
            "Win32_SessionConnection",
            "Win32_SessionProcess",
            "Win32_Share",
            "Win32_ShareToDirectory",
            "Win32_ShortcutAction",
            "Win32_ShortcutFile",
            "Win32_ShortcutSAP",
            "Win32_SID",
            "Win32_SoftwareElement",
            "Win32_SoftwareElementAction",
            "Win32_SoftwareElementCheck",
            "Win32_SoftwareElementCondition",
            "Win32_SoftwareElementResource",
            "Win32_SoftwareFeature",
            "Win32_SoftwareFeatureAction",
            "Win32_SoftwareFeatureCheck",
            "Win32_SoftwareFeatureParent",
            "Win32_SoftwareFeatureSoftwareElements",
            "Win32_SoundDevice",
            "Win32_StartupCommand",
            "Win32_SubDirectory",
            "Win32_SystemAccount",
            "Win32_SystemBIOS",
            "Win32_SystemBootConfiguration",
            "Win32_SystemDesktop",
            "Win32_SystemDevices",
            "Win32_SystemDriver",
            "Win32_SystemDriverPNPEntity",
            "Win32_SystemEnclosure",
            "Win32_SystemLoadOrderGroups",
            "Win32_SystemLogicalMemoryConfiguration",
            "Win32_SystemNetworkConnections",
            "Win32_SystemOperatingSystem",
            "Win32_SystemPartitions",
            "Win32_SystemProcesses",
            "Win32_SystemProgramGroups",
            "Win32_SystemResources",
            "Win32_SystemServices",
            "Win32_SystemSlot",
            "Win32_SystemSystemDriver",
            "Win32_SystemTimeZone",
            "Win32_SystemUsers",
            "Win32_TapeDrive",
            "Win32_TCPIPPrinterPort",
            "Win32_TemperatureProbe",
            "Win32_Terminal",
            "Win32_TerminalService",
            "Win32_TerminalServiceSetting",
            "Win32_TerminalServiceToSetting",
            "Win32_TerminalTerminalSetting",
            "Win32_Thread",
            "Win32_TimeZone",
            "Win32_TSAccount",
            "Win32_TSClientSetting",
            "Win32_TSEnvironmentSetting",
            "Win32_TSGeneralSetting",
            "Win32_TSLogonSetting",
            "Win32_TSNetworkAdapterListSetting",
            "Win32_TSNetworkAdapterSetting",
            "Win32_TSPermissionsSetting",
            "Win32_TSRemoteControlSetting",
            "Win32_TSSessionDirectory",
            "Win32_TSSessionDirectorySetting",
            "Win32_TSSessionSetting",
            "Win32_TypeLibraryAction",
            "Win32_UninterruptiblePowerSupply",
            "Win32_USBController",
            "Win32_USBControllerDevice",
            "Win32_USBHub",
            "Win32_UserAccount",
            "Win32_UserDesktop",
            "Win32_UserInDomain",
            "Win32_UTCTime",
            "Win32_VideoController",
            "Win32_VideoSettings",
            "Win32_VoltageProbe",
            "Win32_VolumeQuotaSetting",
            "Win32_WindowsProductActivation",
            "Win32_WMIElementSetting",
            "Win32_WMISetting",
            #endregion"Win32_Class"
        };

        void ProcessTaskSystemDeviceInformation()
        {
            firstProcessTimer = Stopwatch.StartNew();
            firstProcessTimer.Start();


            InformationTimer = new System.Windows.Forms.Timer();
            InformationTimer.Interval = 500;
            InformationTimer.Tick += new EventHandler(InformationTimer_Tick);
            InformationTimer.Start();

            Task.Factory.StartNew(() => SystemInformation = SystemInformationProcess());
            //    Task.Factory.StartNew(() => AppInstalled = DeviceInformation("Win32_Product"));
            Task.Factory.StartNew(() => ProcessorInformation = DeviceInformation("Win32_Processor"));
            Task.Factory.StartNew(() => LogicalDiskInformation = DeviceInformation("Win32_LogicalDisk"));
            Task.Factory.StartNew(() => VideoControllerInformation = DeviceInformation("Win32_VideoController"));


        }

        void InformationTimer_Tick(object sender, EventArgs e)
        {
            if (processor)
                UpDateNode(ProcessorNode, "Processor ");
            else
                ProcessorNode.ImageIndex = 3;

            if (logical)
                UpDateNode(LogicalDiskNode, "LogicalDisk");
            else
                LogicalDiskNode.ImageIndex = 3;

            if (videoIns)
                UpDateNode(VideoControllerNode, "VideoController");
            else
                VideoControllerNode.ImageIndex = 3;

            if (_system)
                UpDateNode(SystemInformationNode, "System Information");
            else
                SystemInformationNode.ImageIndex = 3;

            if (appIns)
                UpDateNode(AppInstalledNode, "Application Installed");
            else
                AppInstalledNode.ImageIndex = 3;

            // if one task are not finished, return.
            if (processor || logical || videoIns || _system || appIns)
            {
                InstallationLogNode.ImageIndex = 4;
                return;
            }

            // if all task are finished, stop the timer.
            InstallationLogNode.ImageIndex = 3;
            firstProcessTimer.Stop();
            InformationTimer.Stop();

            richTextBox_FirstInstalation.AppendText("The installation manager will check for necessary installed components....." +
                                                                 Environment.NewLine);

            richTextBox_FirstInstalation.AppendText("Getting system information" + Environment.NewLine);
            richTextBox_FirstInstalation.AppendText(SystemInformation);
            richTextBox_FirstInstalation.AppendText("Getting processor information" + Environment.NewLine);
            richTextBox_FirstInstalation.AppendText(ProcessorInformation);
            richTextBox_FirstInstalation.AppendText("Getting logical disk information" + Environment.NewLine);
            richTextBox_FirstInstalation.AppendText(LogicalDiskInformation);
            richTextBox_FirstInstalation.AppendText("Getting video controller information" + Environment.NewLine);
            richTextBox_FirstInstalation.AppendText(VideoControllerInformation);
            //richTextBox_FirstInstalation.AppendText("Getting application installed information" + Environment.NewLine);
            //richTextBox_FirstInstalation.AppendText(AppInstalled);
        }

        void UpDateNode(TreeNode node, string text)
        {
            node.Text = text + "     Process time: " + firstProcessTimer.ElapsedMilliseconds + " milliseg.";
            node.ImageIndex = 4;
            return;
        }

        bool _system = true;
        string _systemInformation = "";
        string SystemInformation
        {
            get
            {
                return _systemInformation;
            }
            set
            {
                _system = false;
                _systemInformation = value;
            }
        }

        bool appIns;
        string _appInstalled = "";
        string AppInstalled
        {
            get
            {
                return _appInstalled;
            }
            set
            {
                appIns = false;
                _appInstalled = value;
            }
        }

        bool processor = true;
        string _processorInformation = "";
        string ProcessorInformation
        {
            get
            {
                return _processorInformation;
            }
            set
            {
                processor = false;
                _processorInformation = value;
            }
        }

        bool logical = true;
        string _logicalDiskInformation = "";
        string LogicalDiskInformation
        {
            get
            {
                return _logicalDiskInformation;
            }
            set
            {
                logical = false;
                _logicalDiskInformation = value;
            }
        }

        bool videoIns = true;
        string _videoControllerInformation = "";
        string VideoControllerInformation
        {
            get
            {
                return _videoControllerInformation;
            }
            set
            {
                videoIns = false;
                _videoControllerInformation = value;
            }
        }


        string SystemInformationProcess()
        {
            StringBuilder StringBuilder1 = new StringBuilder(string.Empty);
            try
            {
                StringBuilder1.AppendFormat(Environment.NewLine);
                StringBuilder1.AppendFormat("Operation System:  {0}\n", Environment.OSVersion);
                if (Environment.Is64BitOperatingSystem)
                    StringBuilder1.AppendFormat("\t\t  64 Bit Operating System\n");
                else
                    StringBuilder1.AppendFormat("\t\t  32 Bit Operating System\n");
                StringBuilder1.AppendFormat("SystemDirectory:  {0}\n", Environment.SystemDirectory);
                StringBuilder1.AppendFormat("ProcessorCount:  {0}\n", Environment.ProcessorCount);
                StringBuilder1.AppendFormat("UserDomainName:  {0}\n", Environment.UserDomainName);
                StringBuilder1.AppendFormat("UserName: {0}\n", Environment.UserName);
                //Drives
                StringBuilder1.AppendFormat("LogicalDrives:\n");
                foreach (DriveInfo DriveInfo1 in System.IO.DriveInfo.GetDrives())
                {
                    try
                    {
                        StringBuilder1.AppendFormat("\t Drive: {0}\n\t\t VolumeLabel: " +
                          "{1}\n\t\t DriveType: {2}\n\t\t DriveFormat: {3}\n\t\t " +
                          "TotalSize: {4}\n\t\t AvailableFreeSpace: {5}\n",
                          DriveInfo1.Name, DriveInfo1.VolumeLabel, DriveInfo1.DriveType,
                          DriveInfo1.DriveFormat, DriveInfo1.TotalSize, DriveInfo1.AvailableFreeSpace);
                    }
                    catch
                    {
                    }
                }
                StringBuilder1.AppendFormat("SystemPageSize:  {0}\n", Environment.SystemPageSize);
                StringBuilder1.AppendFormat("Version:  {0}\n", Environment.Version);
                StringBuilder1.AppendFormat("*********************************** Process time {0}",
                                    firstProcessTimer.ElapsedMilliseconds + " milliseg. ***********************************");
                StringBuilder1.AppendLine("\n");
            }
            catch
            {
            }
            return StringBuilder1.ToString();
        }

        string DeviceInformation(string stringIn)
        {
            StringBuilder StringBuilder1 = new StringBuilder(string.Empty);
            ManagementClass ManagementClass1 = new ManagementClass(stringIn);
            //Create a ManagementObjectCollection to loop through
            ManagementObjectCollection ManagemenobjCol = ManagementClass1.GetInstances();
            //Get the properties in the class
            PropertyDataCollection properties = ManagementClass1.Properties;
            StringBuilder1.AppendFormat(Environment.NewLine);
            foreach (ManagementObject obj in ManagemenobjCol)
            {
                foreach (PropertyData property in properties)
                {
                    try
                    {
                        StringBuilder1.AppendLine(property.Name + ":  " +
                          obj.Properties[property.Name].Value.ToString());
                    }
                    catch
                    {
                        //Add codes to manage more information
                    }
                }
                StringBuilder1.AppendLine();
            }
            StringBuilder1.AppendFormat("*********************************** Process time {0}",
                                firstProcessTimer.ElapsedMilliseconds + " milliseg. ***********************************");
            StringBuilder1.AppendFormat(Environment.NewLine);
            StringBuilder1.AppendFormat(Environment.NewLine);
            return StringBuilder1.ToString();
        }

        System.Windows.Forms.Timer InformationTimer;
        Stopwatch firstProcessTimer;

        #endregion"First Installation"

        #region"Security & Lock System Folder."

        void button_Lock_Click(object sender, EventArgs e)
        {
            // Dim text1 as string = ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}"
            // Shell("cmd /c" & "ren " & TextBox1.Text & " " & TextBox2.Text & Text1)
            // Shell("cmd /c" & "attrib +s +h " & TextBox1.Text & ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}\*.*" & " /S /D")
            // Shell("cmd /c" & "attrib +s +h " & TextBox1.Text & ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}" & " /S /D")

            if (string.IsNullOrWhiteSpace(pathkey))
                return;

            DirectoryInfo d = new DirectoryInfo(pathkey);
            string selectedpath = d.Parent.FullName + "\\" + d.Name;

            if (pathkey.LastIndexOf(".{") == -1)
            {
                string status = ".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";

                FileSystemExt.DirectoryRename(pathkey, d.Parent.FullName + "\\" + d.Name + status);
                pathkey = d.Parent.FullName + "\\" + d.Name + status;

                try
                {
                    File.SetAttributes(pathkey, _fileAttributes);
                }
                catch (Exception error)
                {
                    MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"Security & Lock System Folder has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void button_UnLock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathkey))
                return;

            if (pathkey.LastIndexOf(".{") == -1)
                return;

            DirectoryInfo p = new DirectoryInfo(pathkey);

            FileSystemExt.DirectoryRename(pathkey, p.Parent.FullName + "\\" + "Test");
            pathkey = p.Parent.FullName + "\\" + "Test";

            try
            {
                File.SetAttributes(pathkey, _fileAttributes);
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"Security & Lock System Folder has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void button_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathkey))
                return;

            DirectoryInfo d = new DirectoryInfo(pathkey);

            if (d.Exists)
            {
                d.Delete(true);
                pathkey = "";
            }
        }

        string pathkey
        {
            get
            {
                return comboBox_SecurityLockFolder.Text;
            }
            set
            {
                comboBox_SecurityLockFolder.Text = value;
            }
        }

        void button_Browser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _folderBrower = new FolderBrowserDialog();

            _folderBrower.ShowDialog();

            if (DialogResult == DialogResult.Abort)
                return;

            if (string.IsNullOrEmpty(_folderBrower.SelectedPath))
                return;

            pathkey = _folderBrower.SelectedPath;
            _fileAttributes = File.GetAttributes(pathkey);

            if (_fileAttributes.HasFlag(FileAttributes.Hidden))
                checkBox_Hidden.Checked = true;
            else
                checkBox_Hidden.Checked = false;

            if (_fileAttributes.HasFlag(FileAttributes.System))
                checkBox_System.Checked = true;
            else
                checkBox_System.Checked = false;

            if (_fileAttributes.HasFlag(FileAttributes.ReadOnly))
                checkBox_ReadOnly.Checked = true;
            else
                checkBox_ReadOnly.Checked = false;
        }

        void ProjectsViewer_Load(object sender, EventArgs e)
        {
            comboBox_SecurityLockFolder.Text = "";

            // C:\Users\Owner\Documents

            DirectoryInfo d = new DirectoryInfo(@"C:\Users\Owner\Documents");

            //ExtensionsToSearch.SelectMany(pattern => d.EnumerateFiles("*." + pattern, SearchOption.TopDirectoryOnly).Where(fileInfo => Path.GetExtension(fileInfo.FullName) == "." + pattern ))

            //var collection = (pattern => d.EnumerateFiles("*." + pattern, SearchOption.TopDirectoryOnly).Where(fileInfo => Path.GetExtension(fileInfo.FullName) == "." + pattern));


            //foreach (var item in collection)
            //{
            //    Console.WriteLine(item);
            //}
        }

        public static Dictionary<DirectoryInfo, List<DirectoryInfo>> BuildTree(string path)
        {
            Dictionary<DirectoryInfo, List<DirectoryInfo>> temptree = new Dictionary<DirectoryInfo, List<DirectoryInfo>>();
            //If you need to filter the results edit the search string
            foreach (DirectoryInfo dir in new DirectoryInfo(path).GetDirectories("*", SearchOption.TopDirectoryOnly))
            {
                temptree.Add(dir, dir.GetDirectories("*", SearchOption.TopDirectoryOnly).ToList());
            }

            return temptree;
        }
        public Dictionary<DirectoryInfo, List<DirectoryInfo>> BuildTreeLinq(string path)
        {
            Dictionary<DirectoryInfo, List<DirectoryInfo>> temptree =
                (from dir in new DirectoryInfo(path).EnumerateDirectories("*", SearchOption.TopDirectoryOnly)
                 select dir).ToDictionary(x => x, x => x.GetDirectories("*", SearchOption.TopDirectoryOnly).ToList());

            return temptree;
        }




        void checkBox_Hidden_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pathkey))
                return;

            if (checkBox_Hidden.Checked)
                _fileAttributes = FileSystemExt.AddAttribute(_fileAttributes, FileAttributes.Hidden);
            else
                _fileAttributes = FileSystemExt.RemoveAttribute(_fileAttributes, FileAttributes.Hidden);

            File.SetAttributes(pathkey, _fileAttributes);
        }

        void checkBox_System_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pathkey))
                return;

            if (checkBox_System.Checked)
                _fileAttributes = FileSystemExt.AddAttribute(_fileAttributes, FileAttributes.System);
            else
                _fileAttributes = FileSystemExt.RemoveAttribute(_fileAttributes, FileAttributes.System);

            File.SetAttributes(pathkey, _fileAttributes);
        }

        void checkBox_ReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pathkey))
                return;

            if (checkBox_ReadOnly.Checked)
                _fileAttributes = FileSystemExt.AddAttribute(_fileAttributes, FileAttributes.ReadOnly);
            else
                _fileAttributes = FileSystemExt.RemoveAttribute(_fileAttributes, FileAttributes.ReadOnly);

            File.SetAttributes(pathkey, _fileAttributes);
        }

        #endregion"Security & Lock System Folder."

        string TimeUnitName = "seconds";
        int TimeUnit = 1000;
        void TrackBar_Interval_ValueChanged(object sender, EventArgs e)
        {
            label_IntervalSetTo.Text = "The interval between each reading of notifications is set to " +
                                        trackBar_Interval.Value + " " + TimeUnitName + ".";
        }

        void RadioButton_secund_CheckedChanged(object sender, EventArgs e)
        {
            TimeUnit = 1000;
            TimeUnitName = "seconds";
            label_IntervalSetTo.Text = "The interval between each reading of notifications is set to " +
                                        trackBar_Interval.Value + " " + TimeUnitName + ".";
        }

        void RadioButton_Minutes_CheckedChanged(object sender, EventArgs e)
        {
            TimeUnit = 60000;
            TimeUnitName = "minutes";
            label_IntervalSetTo.Text = "The interval between each reading of notifications is set to " +
                                        trackBar_Interval.Value + " " + TimeUnitName + ".";
        }

        void RadioButton_Hours_CheckedChanged(object sender, EventArgs e)
        {
            TimeUnit = 3600000;
            TimeUnitName = "hours";
            label_IntervalSetTo.Text = "The interval between each reading of notifications is set to " +
                                        trackBar_Interval.Value + " " + TimeUnitName + ".";
        }

        #region"Registering a DLL"

        void button_BrowserDLL_Click(object sender, EventArgs e)
        {
            using (var openfile = new OpenFileDialog
            {
                Title = @"Please found any DLL file to register.",
                FileName = "",
                Filter = @"DLL File (*.dll)|*.dll",
                DefaultExt = "(*.dll)|*.dll"
            }
                 )
            {
                if (openfile.ShowDialog(this) == DialogResult.Cancel)
                    return;

                var fileName = Path.GetFileNameWithoutExtension(openfile.FileName);
                var fileExt = Path.GetExtension(openfile.FileName);
                var filePath = Path.GetDirectoryName(openfile.FileName);

                textBox_BrowsedDLL.Text = openfile.FileName;
            }
        }

        void button_RegisterDLL_Click(object sender, EventArgs e)
        {
            //   using (Registrar registrar = new Registrar(textBox_BrowsedDLL.Text))
            //   {
            //       registrar.RegisterComDLL();
            //return base.Execute();
            //   }
        }





        #endregion"Registering a DLL"

        #region"System Compatibility"

        void Initialize_SystemCompatibility()
        {
            checkBox_SupportDoubleBuffering.Checked = Settings.Default.DataGridViewDrawDoubleBuffering;
        }

        void checkBox_SupportDoubleBuffering_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DataGridViewDrawDoubleBuffering = checkBox_SupportDoubleBuffering.Checked;
        }

        #endregion"System Compatibility"

        #region"DocumentationBehaviorTab"

        /// <summary>
        /// Used to now the checked radioButton.
        /// </summary>
        List<RadioButton> DocumentationBehaviorOptions = new List<RadioButton>();

        void InitializeDocumentationBehaviorTab()
        {
            //Use the Tag property to mark a enum index.
            radioButton_SpecifiedDocument.AutoCheck = false;
            DocumentationBehaviorOptions.Add(radioButton_SpecifiedDocument);
            radioButton_SpecifiedDocument.Tag = 1;// MyCode.DocumentationBehavior.SpecifiedDocument;
            radioButton_SpecifiedDocument.Click += RadioButton_CheckedChanged;

            radioButton_LastRevision.AutoCheck = false;
            DocumentationBehaviorOptions.Add(radioButton_LastRevision);
            radioButton_LastRevision.Tag = 2;// MyCode.DocumentationBehavior.LastRevision;
            radioButton_LastRevision.Click += RadioButton_CheckedChanged;

            radioButton_AllVersionsFound.AutoCheck = false;
            DocumentationBehaviorOptions.Add(radioButton_AllVersionsFound);
            radioButton_AllVersionsFound.Tag = 3;// MyCode.DocumentationBehavior.AllVersionsFound;
            radioButton_AllVersionsFound.Click += RadioButton_CheckedChanged;

            radioButton_Last2Versions.AutoCheck = false;
            DocumentationBehaviorOptions.Add(radioButton_Last2Versions);
            radioButton_Last2Versions.Tag = 4;// MyCode.DocumentationBehavior.Last2Versions;
            radioButton_Last2Versions.Click += RadioButton_CheckedChanged;

            checkBox_PdfViewer.Checked = Settings.Default.PdfViewer;

            radioButton_NoDocumentsToShow.AutoCheck = false;
            DocumentationBehaviorOptions.Add(radioButton_NoDocumentsToShow);
            radioButton_NoDocumentsToShow.Tag = 6; //MyCode.DocumentationBehavior.NoDocumentsExist;
            radioButton_NoDocumentsToShow.Click += RadioButton_CheckedChanged;
        }

        void InitializeDocumentsAddressGroup()
        {
            grouper_DefinedAddressDocumentation.Controls.Remove(documentsAddressGroup_SearchForPDFfileWithin);
            var documentsAddressGroupNew = new DocumentsAddressGroup(CurrentDepartmentLogIn, ListDepartments, true);
            grouper_DefinedAddressDocumentation.Controls.Add(documentsAddressGroupNew);
            documentsAddressGroupNew.Dock = DockStyle.Fill;

            grouper_DefinedAddressDocumentation.Invalidate();
        }

        void InitializeDocumentationBehaviorProperties()
        {
            InitializeDocumentsAddressGroup();

            MessagePositionString = @"DocumentationBehavior switch";
            switch ((MyCode.DocumentationBehavior)Settings.Default.DocumentationBehavior)
            {
                case MyCode.DocumentationBehavior.SpecifiedDocument:
                    {
                        radioButton_SpecifiedDocument.Checked = true;
                        break;
                    }
                case MyCode.DocumentationBehavior.LastRevision:
                    {
                        radioButton_LastRevision.Checked = true;
                        break;
                    }
                case MyCode.DocumentationBehavior.AllVersionsFound:
                    {
                        radioButton_AllVersionsFound.Checked = true;
                        break;
                    }
                case MyCode.DocumentationBehavior.Last2Versions:
                    {
                        radioButton_Last2Versions.Checked = true;
                        break;
                    }
                case MyCode.DocumentationBehavior.NoDocumentsExist:
                    {
                        radioButton_NoDocumentsToShow.Checked = true;
                        break;
                    }
            };

        }

        void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (sender as RadioButton);

            if (!rb.Checked)
            {
                foreach (RadioButton option in DocumentationBehaviorOptions)
                {
                    if (option == rb)
                    {
                        rb.Checked = true;
                        Settings.Default.DocumentationBehavior = (int)rb.Tag;
                        continue;
                    }

                    option.Checked = false;
                }
            }
        }

        void CheckBox_PdfViewer_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.PdfViewer = checkBox_PdfViewer.Checked;
            Settings.Default.Save();
        }

        #endregion"DocumentationBehaviorTab"

        #region"ConvertFilesFrontThisLocationTab"

        void InitializeConvertFilesFrontThisLocationTab()
        {
            grouper_ConvertFilesFrontThisLocation.Controls.Remove(scanDocumentsAddressGroup_Default);
            var scanDocumentsAddressGroupNew = new ScanDocumentsAddressGroup(CurrentDepartmentLogIn, ListDepartments);
            grouper_ConvertFilesFrontThisLocation.Controls.Add(scanDocumentsAddressGroupNew);
            scanDocumentsAddressGroupNew.Dock = DockStyle.Fill;

            grouper_ConvertFilesFrontThisLocation.Invalidate();
        }





        #endregion"ConvertFilesFrontThisLocationTab"

        #region"Peer To Peer Management"

        void InitializePeerToPeerManagementTab()
        {
            checkBox_IsSuperPeer.Checked = Settings.Default.IsSuperPeer;
            textBox_NgrokUtilityPath.Text = Settings.Default.NgrokUtilityPath;
        }

        void checkBox_IsSuperPeer_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.IsSuperPeer = checkBox_IsSuperPeer.Checked;
        }

        void button_BrowserNgrokUtilityPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openfile = new OpenFileDialog
            {
                Title = @"Please found the Ngrok.exe utility file.",
                FileName = "Ngrok.exe",
                Filter = null,
                DefaultExt = "(*.exe)|*.exe"
            })
            {
                if (openfile.ShowDialog(this) == DialogResult.Cancel)
                    return;

                textBox_NgrokUtilityPath.Text = openfile.FileName.Replace(Settings.Default.DataBaseAddress, "");
                Settings.Default.NgrokUtilityPath = textBox_NgrokUtilityPath.Text;
            }
        }

        #endregion"Peer To Peer Management"


    }

    public class DragHelper
    {
        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControls();

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_BeginDrag(IntPtr himlTrack, int
            iTrack, int dxHotspot, int dyHotspot);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragMove(int x, int y);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern void ImageList_EndDrag();

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragEnter(IntPtr hwndLock, int x, int y);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragLeave(IntPtr hwndLock);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragShowNolock(bool fShow);

        static DragHelper()
        {
            InitCommonControls();
        }
    }

}
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using StockRoom11net.Controls.DependencyInjection;
using StockRoom11net.Controls.DocumentationBehavior;
using StockRoom11net.Controls;
using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Controls.ThumbViewer;
using StockRoom11net.Properties;
using StockRoom11net.Data;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Reflection;
using System.Speech.Synthesis;
using WeifenLuo.WinFormsUI.Docking;
using WinFormsUI.Docking;

using ActiveDataSheet_EventArgs = StockRoom11net.Controls.Custom_Events_Args.ActiveDataSheet_EventArgs;
using CellDoubleClick_EventArgs = StockRoom11net.Controls.Custom_Events_Args.CellDoubleClick_EventArgs;
using CurrentDeptUserBroadcast_EventArgs = StockRoom11net.Controls.Custom_Events_Args.CurrentDeptUserBroadcast_EventArgs;
using Custom_Events_Args = StockRoom11net.Controls.Custom_Events_Args;
using Need_SaveData_EventArgs = StockRoom11net.Controls.Custom_Events_Args.Need_SaveData_EventArgs;
using Refresh_Requested_EventArgs = StockRoom11net.Controls.Custom_Events_Args.Refresh_Requested_EventArgs;
using Save_Requested_EventArgs = StockRoom11net.Controls.Custom_Events_Args.Save_Requested_EventArgs;
using StatusBarMessage_EventArgs = StockRoom11net.Controls.Custom_Events_Args.StatusBarMessage_EventArgs;
using Tags = StockRoom11net.Controls.HTML_Tags;
using TreeViewUpdateEventArgs = StockRoom11net.Controls.Custom_Events_Args.TreeViewUpdateEventArgs;
using TreeViewUpdateEventHandler = StockRoom11net.Controls.Custom_Events_Args.TreeViewUpdateEventHandler;
using StockRoom11net.Controls.PdfFileScan;
using StockRoom11net.Controls.FileSystemEnumerator;
using StockRoom11net.Controls.MouseKeyboardActivityMonitor.Controls;
using StockRoom11net.Controls.MouseKeyboardActivityMonitor;
using StockRoom11net.Controls.RawInput;
using StockRoom11net.Data.Services;
using StockRoom11net.Data.Entities;

[assembly: System.Runtime.Versioning.SupportedOSPlatformAttribute("windows")]
namespace StockRoom11net
{
    public partial class Solutions_TempleClass : Form
    {
        // Injected EF Core services
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _serviceProvider;
        private ITableEmployeeService _employeesService;

        // X:\ProductionManagement\AdvanceTec Software\
        // \\advt01s1\atishares\\ProductionManagement\AdvanceTec Software\

        #region"Custom Controls Events with custom Arg.*********************"

        #region"TreeViewUpdate"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("DataSheet file name.")]
        public event TreeViewUpdateEventHandler TreeViewUpdate;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public void On_TreeViewUpdate(TreeViewUpdateEventArgs e)
        {
            // Notify Subscribers
            TreeViewUpdate?.Invoke(this, e);
        }

        #endregion"TreeViewUpdate"

        #region"CellDoubleClick"

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellDoubleClick has changed")]
        public event Custom_Events_Args.CellDoubleClick_EventHandler CellDoubleClick_Event;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_CellDoubleClick_Event(CellDoubleClick_EventArgs e)
        {
            // Notify Subscribers
            CellDoubleClick_Event?.Invoke(this, e);
        }

        #endregion"CellDoubleClick_Event"

        #region"Current_DeptUser_Broadcast"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The current user have be changed.")]
        public event CurrentDeptUserBroadcast_EventHandler CurrentDeptUserBroadcast_Requested;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CurrentDeptUserBroadcast_EventHandler(object sender, CurrentDeptUserBroadcast_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_CurrentDeptUserBroadcast_Requested(CurrentDeptUserBroadcast_EventArgs e)
        {
            // Notify Subscribers
            CurrentDeptUserBroadcast_Requested?.Invoke(this, e);
        }

        #endregion"Current__DeptUser_Broadcast"

        #region"On_ScannedData"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event BarcodeScanned_EventHandler ScannedDataEvent;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void BarcodeScanned_EventHandler(object sender, RawInputEventArg e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_ScannedData(RawInputEventArg e)
        {
            ScannedDataEvent?.Invoke(this, e);
        }
        #endregion

        #region"Refresh_Requested"

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Refresh_Requested_EventHandler Refresh_Requested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Refresh_Requested(Refresh_Requested_EventArgs e)
        {
            // Notify Subscribers
            Refresh_Requested?.Invoke(this, e);
        }

        #endregion"Refresh_Requested"

        #region"Save_Requested"

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Save_Requested_EventHandler Save_Requested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Save_Requested(Save_Requested_EventArgs e)
        {
            // Notify Subscribers
            Save_Requested?.Invoke(this, e);
        }
        #endregion

        #region"SaveTreeView_Requested"

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.SaveTreeView_Requested_EventHandler SaveTreeView_Requested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_SaveTreeView_Requested(Save_Requested_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            // Notify Subscribers
            SaveTreeView_Requested?.Invoke(this, e);
        }
        #endregion

        #region"Active_DataSheet"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("DataSheet file name.")]
        public event Custom_Events_Args.ActiveDataSheet_EventHandler ActiveDataSheet;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public void On_ActiveDataSheet(ActiveDataSheet_EventArgs e)
        {
            // Notify Subscribers
            ActiveDataSheet?.Invoke(this, e);
        }

        #endregion"Active_DataSheet"

        #region"Node PDF"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("DataSheet file name.")]
        public event Custom_Events_Args.Node_PDF_EventHandler Node_PDF;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_Node_PDF(ActiveDataSheet_EventArgs e)
        {
            // Notify Subscribers
            Node_PDF?.Invoke(this, e);
        }

        #endregion"Node PDF"

        #endregion"Custom Controls Events with custom Arg.*********************"

        #region"Properties, Custom Control Properties"

        bool _needSaveData;
        /// <summary>
        /// True if any project need save any data.
        /// NeedSaveDataProject var hold project name need save data.
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint),
        Category("Custom Properties"),
        DefaultValue("False"),
        Description("True if any project need save any data.")]
        public bool NeedSaveData
        {
            get
            {
                foreach (KeyValuePair<string, bool> pair in _needsavedata)
                {
                    if (pair.Value)
                    {
                        NeedSaveDataProject = pair.Key;
                        return true;
                    }
                }

                return false;
            }

            set
            {
                _needSaveData = value;
            }
        }

        public string NeedSaveDataProject = "";
        Dictionary<string, bool> _needsavedata = new Dictionary<string, bool>();
        /// <summary>
        /// Fill the dictionary with projectName:bool
        /// if input string is "" return bool state.
        /// Return true if any project need save any data.
        /// </summary>
        /// <param name="controlName_bool"></param>
        /// <returns></returns>
        public bool NeedSaveDataIni(string controlName_bool)
        {
            if (!string.IsNullOrEmpty(controlName_bool))
            {
                string controlName = controlName_bool.Substring(0, controlName_bool.IndexOf(':'));
                string valueBool = controlName_bool.Substring(controlName_bool.IndexOf(':'));
                bool valuebool = false;

                if (valueBool.Contains(":True"))
                    valuebool = true;

                if (_needsavedata.ContainsKey(controlName))
                {
                    _needsavedata[controlName] = valuebool;
                }
                else
                {
                    _needsavedata.TryAdd(controlName, valuebool);
                }
            }

            foreach (KeyValuePair<string, bool> pair in _needsavedata)
            {
                if (pair.Value)
                {
                    NeedSaveDataProject = pair.Key;
                    return true;
                }
            }

            return false;
        }

        public void Need_SaveData(object sender, Need_SaveData_EventArgs e)
        {
            NeedSaveDataIni(e.ControlName + ":" + e.NeedSaveData);
        }


        bool _hasInternetConnectionAvailable = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasInternetConnectionAvailable
        {
            get
            {
                return _hasInternetConnectionAvailable;
            }
            set
            {
                _hasInternetConnectionAvailable = value;
            }
        }

        #endregion"Properties, Custom Control Properties"

        #region"Properties and fields"        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MessagePositionString { get; set; }

        int _count = 1;
        /// <summary>
        /// Hold the numbers rows saved by any update process.
        /// </summary>
        int RowsSaved;
        /// <summary>
        /// Hold the numbers rows changed by....
        /// </summary>
        int RowsChanged;
        string _rowHasError = "";
        
        bool TestBarCodeReader;

        /// <summary>
        /// Solo para abilitar BindingComplete.
        /// </summary>
        TextBox textbox1 = new TextBox();

        readonly DeserializeDockContent _mDeserializeDockContent;

        private LabelsPrintsSMT _LabelsPrintsSMT;
        public SMT_Reel_Record? _SMT_Reel_Record;
        public Orders_Process _ordersProcess;
        public Pdf_explorer _nodePDF;
        public Pdf_explorer _pdfWindowForm;
        //  public ImportExcel _importExcel;
        //  public ProjectsViewer _projectsViewerForm;
        //  public CalendarViewer _calendarViewerForm;
        public StockRoom_Inventory? _stockRoomForm;
        //  public BOM_Management _bom_ManagementsForm;
        public H7H_Explorer _h7h_ExplorerForm;
        public StockRoomReceive? _stockRoomReceiveForm;
        //   public StockRoomMarshall _marshalExplorerForm;
        public LogFile_Management? _logFile_Management;
        public SolutionsProperties _solutionPropertiesForm;
        public StockRoom_AddNewComp _stockRoomAddNewCompForm;
        public Employees_Management _employees_ManagementsForm;
        public LocationAndLayoutPlanning? _locationAndLayoutDesignForm;
        public TimeLineEditor? _timeLineEditorForm;
               
                      
        private static SqliteConnection? DataBaseSqliteConnection;
        private static string ApplicationDefaultHtmlPages = "";

        /// <summary>
        /// If installation o setting on first day is done go true,
        /// it is initialized in SolutionsBaseLoad();
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static bool IsDoneInstallation { get; set; }
        private static DateTime InstallationFirstDate;
        private static TimeSpan InstallationDaysAfter;

        SpeechSynthesizer SpeechSynthesizerBase;

        #endregion"Properties and fields"

        // To catch missing registrations early, you can also mark the parameterless
        // constructor with[Obsolete] so it shows a compiler warning whenever it's accidentally used:
        [Browsable(false)]
        [Obsolete("Use DI constructor. Missing service registration may be causing this call.")]
        public Solutions_TempleClass()
        {
            InitializeComponent();

            if (DesignMode)
            {
                MessageBox.Show(@"Solutions_TempleClass() parameterless constructor is obsolete. Use DI constructor instead.",
                                @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public Solutions_TempleClass(ITableEmployeeService employeesService, IServiceProvider serviceProvider)
        {
            InitializeComponent();

            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>() ?? throw new ArgumentNullException(nameof(serviceProvider), "IUnitOfWork service is not registered.");
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider), "ServiceProvider cannot be null.");
            _employeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService), "EmployeesService cannot be null.");
            _employeesService.CurrentEmployeeLogInChanged += (s, e) =>
            {
                Solutions_TempleClass_CurrentDeptUserBroadcast_Requested();
            };

            AutoScaleMode = AutoScaleMode.Dpi;
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);

            try
            {
                SuspendLayout();

                showRightToLeft.Checked = true;
                _mDeserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

                dockPanel.Dock = DockStyle.Fill;
                dockPanel.Theme = vS2005Theme;
                dockPanel.ShowDocumentIcon = true;

                InitializeDocumentationBehaviorTimer(1);
                ResumeLayout(false);
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, "Solutions Base, InitializeComponets error. " + error,
                                          "Solutions Base Error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            InitializeStatusBarTimer();
        }

        
        public void SolutionsBaseLoad(object sender, EventArgs e)
        {           
            try
            {
                #region"Check if Installation was done."

                InstallationFirstDate = Settings.Default.InstallationFirstDate;
                InstallationDaysAfter = DateTime.Now.Subtract(Settings.Default.InstallationFirstDate);

                IsDoneInstallation = !(InstallationFirstDate == DateTime.Parse("1/1/2000"));
                                
                if (!TryGetDatabasePath(out var dbPath) || !File.Exists(dbPath))
                {
                    OpenDialogUpdateSetting(); // Ask about dataSource file.
                    Settings.Default.Reload();
                }

                if (!TryGetDatabasePath(out dbPath) || !File.Exists(dbPath))
                {
                    using (var form = new Form() { TopMost = true })
                    {
                        MessageBox.Show(form, @"The database path was not found, call system administrator.",
                                                @"System error, The application will be close.",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Close();
                }

                DataBaseSqliteConnection = new SqliteConnection(Settings.Default.DataBaseConnectionStringSQLite);

                #endregion"Check if Installation was done."

                ApplicationDefaultHtmlPages = Path.Combine(Settings.Default.DataBaseAddress, Settings.Default.ApplicationDefaultHtmlPages);

                //      InitializedLogFile();

                InitializeCurrentUserBroadcastTimer();

                toolStripTextBox_Log_User.Visible = false;

            //    CurrentDeptUserBroadcast_Requested += 123Solutions_TempleClass_CurrentDeptUserBroadcast_Requested;
                ScannedDataEvent += Solutions_TempleClass_ScannedDataEvent;

                var configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

              //  if (File.Exists(configFile))
              //      dockPanel.LoadFromXml(configFile, _mDeserializeDockContent);
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Solutions Base load procedure error, call system administrator. " + error,
                                          @"System error, The application will be close.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Close();
            }
        }

        public void Solutions_Temple_Shown(object sender, EventArgs e)
        {
            InitializeProperties();

            InitSolutionsTemple(@"Solution Temple.");

            Initialize_MouseKeyEventProvider();

            InitializeThreadTimerCheckStatusTable();

            // TODO: Remove this and use the event in Utilities.
            // To use StatusBarMessage event from Utilities.
            //        Utilities.StatusBarMessage += OnStatusBarMessage;
            //        Utilities.LogFileMessage += LogFileMessage;

            // To initialized statusBar itemEFtableTreeView to the right. Alignment property.
            //statusBarPanelHelp.Alignment = ToolStripItemAlignment.Right;
            //toolStripStatusLabel_Spacer3.Alignment = ToolStripItemAlignment.Right;
            toolStripStatusLabel_MousePosition.Alignment = ToolStripItemAlignment.Right;

            InitializeToolStrip();
            DropDownButton_Informations_Initialize();

            InitializeDocumentationBehaviorProcess();

            // Show StockRoom form.
            // Because is the most used form.
            InitStockRoom(@"Inventory Control");
        }

        bool m_bSaveLayout = true;
        public void StockRoom_Solutions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _statusBarTimer.Stop();
                StopThreadTimerCheckStatusTable();

                _stockRoomForm?.Close();

                // Dis-enable mouseKeyEventProvider.
                if (_mouseKeyEventProvider != null)
                    while (_mouseKeyEventProvider.Enabled)
                        _mouseKeyEventProvider.Enabled = false;

                if (dockPanel != null)
                {
                    string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

                 //   if (m_bSaveLayout)
                 //       dockPanel.SaveAsXml(configFile);
                 //   else if (File.Exists(configFile))
                 //       File.Delete(configFile);
                }
            }
            catch (Exception error)
            {
                int ee = error.HResult;
                  MessageBox.Show(new Form() { TopMost = true }, @"StockRoom_Solutions_FormClosing(), error is " + error.Message,
                                   @"Solutions Temple has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Solutions_TempleClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (notifyIconStatusTable != null)
                {
                    notifyIconStatusTable.Visible = false;
                    notifyIconStatusTable.Dispose();
                }

                if (_employeesService.CurrentEmployeeLogIn != null)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(Table_Employee.FullName ),
                        Tags.NewLine("Closing the application at " + DateTime.Now),
                        Tags.StraigthLine,
                        Tags.PageBreak
                    }));
                }

                // Application.Exit();
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Solutions_TempleClass_FormClosed(), error is " + error.Message,
                                          @"Solutions Temple has generated an error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static bool TryGetDatabasePath(out string? dbPath)
        {
            dbPath = null;

            if (string.IsNullOrWhiteSpace(Settings.Default.DataBaseConnectionStringSQLite))
                return false;

            try
            {
                var builder = new SqliteConnectionStringBuilder(Settings.Default.DataBaseConnectionStringSQLite);

                dbPath = builder.DataSource;
                return !string.IsNullOrWhiteSpace(dbPath);
            }
            catch
            {
                return false;
            }
        }

        void OpenDialogUpdateSetting()
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

                Settings.Default.DataBaseConnectionStringSQLite = "data source=" + openfile.FileName + ";";
                Settings.Default.DataBaseAddress = Path.GetDirectoryName(openfile.FileName);
                Settings.Default.DataBaseName = Path.GetFileNameWithoutExtension(openfile.FileName);
                Settings.Default.Save();
            }
        }


        #region"Assembly Program ShortCut Path"

        /// <summary>
        /// Information about assembly Company Attribute.
        /// </summary>
        public string AssemblyCompany;
        /// <summary>
        /// Information about assembly Description Attribute.
        /// </summary>
        public string AssemblyDescription;
        /// <summary>
        /// Information about desktop shortcut path.
        /// </summary>
        public string DesktopShortCutPath;
        /// <summary>
        /// Information about program folder path.
        /// </summary>
        public string ProgramFolderPath;
        /// <summary>
        /// Initialize the field related to program and assembly shortcut path.
        /// Those are used to update the application shortcut and pass parameter.
        /// </summary>
        /// <param name="code"></param>
        public void GetProgramDeskTopShortCutPath(Assembly code)
        {
            AssemblyCompany = string.Empty;
            AssemblyDescription = string.Empty;

            if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
            {
                AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code,
                    typeof(AssemblyCompanyAttribute));
                AssemblyCompany = ascompany.Company;
            }

            if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
            {
                AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code,
                    typeof(AssemblyDescriptionAttribute));
                AssemblyDescription = asdescription.Description;
            }

            if (AssemblyCompany != string.Empty && AssemblyDescription != string.Empty)
            {
                DesktopShortCutPath = string.Empty;
                DesktopShortCutPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "\\", AssemblyDescription, ".appref-ms");

                ProgramFolderPath = string.Empty;
                ProgramFolderPath = Application.ExecutablePath;

                //System.IO.File.Copy(ProgramFolderPath, DesktopShortCutPath, true);
            }
        }

        #endregion"Assembly Program ShortCut Path"

        #region"Solutions Properties."
        /// <summary>
        /// _documentationBehavior is initialize in InitializeProperties().
        /// </summary>
        Utilities.DocumentationBehavior _documentationBehavior = Utilities.DocumentationBehavior.SpecifiedDocument;

        int _speechSynthesizerBaseVolume;
        int _speechSynthesizerBaseRate;

        bool _notificationsSendMyOwn;
        bool _notificationsShowMyOwn;
        bool _notificationsShowWarnings;
        bool _notificationsShowDataBaseUpDate;
        bool _notificationsShowEmails;

        bool _saveTheInformationByTime;
        bool _saveTheInformationWhenTheUserSaves;
        bool _saveEachTimeTheInformationIsChanged;
        bool _every5minutes;
        bool _every15minutes;
        bool _every30minutes;

        void InitializeProperties()
        {
            Settings.Default.Reload();

            InitializeDepartment(Settings.Default.DepartmentName);

            _notificationsShowMyOwn = Settings.Default.NotificationsShowMyOwn;
            _notificationsShowWarnings = Settings.Default.NotificationsShowWarnings;
            _notificationsShowDataBaseUpDate = Settings.Default.NotificationsShowDataBaseUpDate;
            _notificationsShowEmails = Settings.Default.NotificationsShowEmails;

            _saveEachTimeTheInformationIsChanged = Settings.Default.SaveEachTimeTheInformationIsChanged;
            _saveTheInformationByTime = Settings.Default.SaveTheInformationByTime;
            _saveTheInformationWhenTheUserSaves = Settings.Default.SaveTheInformationWhenTheUserSave;

            _every5minutes = Settings.Default.Every5minutes;
            _every15minutes = Settings.Default.Every15minutes;
            _every30minutes = Settings.Default.Every30minutes;

            ApplicationDefaultHtmlPages = Path.Combine(Settings.Default.DataBaseAddress, Settings.Default.ApplicationDefaultHtmlPages);
            IntervalReadingNotifications = Settings.Default.IntervalReadingNotifications;

            _speechSynthesizerBaseVolume = Settings.Default.SpeechSynthesizerBaseVolume;
            _speechSynthesizerBaseRate = Settings.Default.SpeechSynthesizerBaseRate;

            _documentationBehavior = (Utilities.DocumentationBehavior)Settings.Default.DocumentationBehavior;

            InitializeSpeechSynthesizerBase();
            InitializeThreadTimerCheckStatusTable();
            InitializeThreadTimerProcessSaveRequest();

            Init_USB_BarCode();
        }

        /// <summary>
        /// Displays the solutions properties dialog for department selection during installation and validates the
        /// assigned department name.
        /// </summary>
        /// <remarks>The dialog is displayed in installation mode with TopMost set to true. If the user
        /// cancels or selects an invalid department name containing "No set to any department", an error message is
        /// displayed.</remarks>
        void CallSolutionsProperties(bool isInstallationMode)
        {
            using (SolutionsProperties solutionProperties = _serviceProvider.GetRequiredService<SolutionsProperties>())
            {
                solutionProperties.Text = "Select a Department to be assigned at this computer.";
                solutionProperties.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;
                solutionProperties.IsInstallationMode = isInstallationMode;
                solutionProperties.TopMost = true;
                solutionProperties.ShowDialog();
                // When the dialog is closed, the application will return here.

                // No, you don't need to detach it manually here — because SolutionsProperties is inside a using block.
                //•	The using calls Dispose() on solutionProperties when the block exits
                //•	Dispose() will clean up all resources, including event handlers, so you don't have to worry about detaching them manually.
                //•	A WinForms Form.Dispose() automatically clears all event subscriptions on the form's own events.
                solutionProperties.SpeechSynthesizerBase -= SpeechSynthesizerBaseSpeak; // ✅ explicit, clear intent

                if (solutionProperties.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                {
                    MessageBox.Show(@"The department name was incorrectly assigned, the system stores the properties for each department," +
                                          @" we recommend that you name the department for the proper development of the system.",
                                          @"System Installation fail.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SolutionPropertiesFormClosed();
            }

            if (Settings.Default.DepartmentName.Contains("No set to any department"))
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"The department name was incorrectly assigned, the system stores the properties for each department," +
                                          @" we recommend that you name the department for the proper development of the system.",
                                          @"System Installation fail.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// It is called when the SolutionsProperties form is closed, to initialize
        /// the properties and start the application if the installation was done.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SolutionPropertiesFormClosed()
        {
            IsDoneInstallation = true;

            InitializeProperties();
            ProcessWaitingTaskList();
            CloseAllDocumentViewer();
            InitializeDocumentationBehaviorProcess();
        }

        #endregion"Solutions Properties."

        #region"MainMenu"

        public void MainMenuMenuActivate(object sender, EventArgs e)
        {
            MenuItem_PeripheralDevice.DropDownItems[nameof(MenuItem_ScannerDeviceTest)].Text = "Scanner Device Test...";
            MenuItem_ScannerDeviceTest.Click += MenuItem_ScannerDeviceTest_Click;
        }

        #region"File"

        public void MenuItem_New_click(object sender, EventArgs e)
        {

        }

        public void MenuItem_Open_click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog
            {
                InitialDirectory = Application.ExecutablePath,
                Filter = @"rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            switch (openFile.ShowDialog())
            {
                case DialogResult.OK:
                    {
                        string fileName = Path.GetFileName(openFile.FileName);

                        if (FindDocument(fileName) != null)
                        {
                            MessageBox.Show(@"The document: " + fileName + @" has already opened!");
                            return;
                        }

                        /*         var newSmtProject = new Form_SMT_Project { Text = fileName };

                                 if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                                 {
                                     newSmtProject.MdiParent = this;
                                     newSmtProject.Show();
                                 }
                                 else
                                     newSmtProject.Show(dockPanel);
                                 try
                                 {
                                     newSmtProject.File_name = openFile.FileName;
                                 }
                                 catch (Exception exception)
                                 {
                                     newSmtProject.Close();
                                     MessageBox.Show(exception.Message);
                                 }
                         * */
                    }
                    break;
            }
        }

        public void MenuItem_File_popup(object sender, EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                MenuItem_close.Enabled = MenuItem_closeAll.Enabled = (ActiveMdiChild != null);
            }
            else
            {
                MenuItem_close.Enabled = (dockPanel.ActiveDocument != null);
                MenuItem_closeAll.Enabled = (dockPanel.DocumentsCount > 0);
            }
        }

        public void MenuItem_Close_click(object sender, EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                if (ActiveMdiChild != null)
                    ActiveMdiChild.Close();
            }
            else if (dockPanel != null || dockPanel.ActiveDocument != null)
                dockPanel.ActiveDocument.DockHandler.Close();
        }

        public void MenuItem_Close_all_click(object sender, EventArgs e)
        {
            CloseAllDocuments();
        }

        public void MenuItem_CloseAllButThisOne_Click(object sender, EventArgs e)
        {
            CloseAllButThisOne();
        }

        public void CloseAllDocuments()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                for (int index = dockPanel.Contents.Count - 1; index >= 0; index--)
                {
                    if (dockPanel.Contents[index] is IDockContent)
                    {
                        IDockContent content = (IDockContent)dockPanel.Contents[index];
                        content.DockHandler.Close();
                    }
                }
            }
        }

        public void CloseAllButThisOne()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                        form.Close();
                }
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                        document.DockHandler.Close();
                }
            }
        }

        public void MenuItem_Print_Click(object sender, EventArgs e)
        {
            if (_employeesService.CurrentEmployeeLogIn.IsUser)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InitLabelsSMTPrint("Print BarCode Labels");
        }

        public void MenuItem_USBScannerSetup_Click(object sender, EventArgs e)
        {

        }

        public void MenuItem_ScannerDeviceTest_Click(object sender, EventArgs e)
        {

        }

        void ToolStripMenuItem_LabelsPrintersSetup_Click(object sender, EventArgs e)
        {

        }



        void MenuItem_document_style_drop_down_item_clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DocumentStyle oldStyle = dockPanel.DocumentStyle;
            DocumentStyle newStyle;
            if (sender == menuItem_Docking_MDI)
                newStyle = DocumentStyle.DockingMdi;
            else if (sender == menuItem_Docking_SDI)
                newStyle = DocumentStyle.DockingSdi;
            else if (sender == menuItem_Docking_Window)
                newStyle = DocumentStyle.DockingWindow;
            else
                newStyle = DocumentStyle.SystemMdi;

            if (oldStyle == newStyle)
                return;

            if (oldStyle == DocumentStyle.SystemMdi || newStyle == DocumentStyle.SystemMdi)
                CloseAllDocuments();

            dockPanel.DocumentStyle = newStyle;
            menuItem_Docking_MDI.Checked = (newStyle == DocumentStyle.DockingMdi);
            menuItem_Docking_Window.Checked = (newStyle == DocumentStyle.DockingWindow);
            menuItem_Docking_SDI.Checked = (newStyle == DocumentStyle.DockingSdi);
            menuItem_System_Mdi.Checked = (newStyle == DocumentStyle.SystemMdi);
            menuItemLayoutByCode.Enabled = (newStyle != DocumentStyle.SystemMdi);
            menuItemLayoutByXml.Enabled = (newStyle != DocumentStyle.SystemMdi);
            //      toolBarButtonLayoutByCode.Enabled = (newStyle != DocumentStyle.SystemMdi);
            //      toolBarButtonLayoutByXml.Enabled = (newStyle != DocumentStyle.SystemMdi);
        }

        #endregion"File"

        #region"Tools"
        //F2
        void ToolStripMenuItem_SMTReelRecord_Click(object sender, EventArgs e)
        {
            InitSMTReelRecord("SMT Reel Record.");
        }
        //F3
        void ToolStripMenuItem_GPSDataSheet_Click(object sender, EventArgs e)
        {
            InitOrdersProcess("GPS DataSheet Test.");
        }
        //F4

        // F5
        void ToolStripMenuItem_LocationAndLayoutClick(object sender, EventArgs e)
        {
            InitLocationAndLayout(@"Location and Layout Design.");
        }
        // F6
        void ToolStripMenuItemStockRoomReceiveClick(object sender, EventArgs e)
        {
            InitStockRoomReceive(@"StockRoom Receive Control");
        }
        // F7
        void ToolStripMenuItemStockRoomMarshallClick(object sender, EventArgs e)
        {
            InitMarshallExplorer(@"StockRoom Marshall");
        }
        // F8
        void ToolStripMenuItemStockRoomInventoryClick(object sender, EventArgs e)
        {
            InitStockRoom(@"Inventory Control");
        }
        // F9
        void ToolStripMenuItemLogFileManagementClick(object sender, EventArgs e)
        {
            InitLogFileManagement(@"Log File Management.");
        }

        // F10
        void ToolStripMenuItemStockRoomAddNewComponentClick(object sender, EventArgs e)
        {
            if (_employeesService.CurrentEmployeeLogIn.IsAdministrator)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("Initialed StockRoom Projections application at " + DateTime.Now),
                    }));

            InitStockRoomAddNewComponent("Add a new component or BOM.");
        }
        // F11
        void ToolStripMenuItemEmployeesClick1(object sender, EventArgs e)
        {
            InitEmployeesManagement(@"Employees Informations.");
        }
        // F12
        void ToolStripMenuItemBomManagementsClick1(object sender, EventArgs e)
        {
            InitBomManagements(@"BOM Managements.");
        }

        void ToolStripMenuItemSolutionsPropertiesClick(object sender, EventArgs e)
        {
            InitSolutionsProperties(@"Solutions Properties.");
        }

        void MenuItemToolsDropDownOpening(object sender, EventArgs e)
        {
            if (_employeesService.CurrentEmployeeLogIn.IsManager)
            {
                //menuItemTools.DropDownItems.Add(toolStripMenuItem_BarCodeReaderTools);
                return;
            }

            menuItemTools.DropDownItems.RemoveByKey(nameof(DataBaseTools_ToolStripMenuItem));
        }

        void ToolStripMenuItem_LoadBOM_Click(object sender, EventArgs e)
        {/*
            ImportCSVorTXT _loadBOM = new ImportCSVorTXT();

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _loadBOM.MdiParent = this;
                _loadBOM.Show();
            }
            else
                _loadBOM.Show(dockPanel);
            */
        }

        void ToolStripMenuItemLoadExcelDataClick(object sender, EventArgs e)
        {/*
            _importExcel = new ImportExcel(_bindingSource_StockRoom, _bindingSourceStockRoomTreeView,
                                           _bindingSource_Marshall, _bindingSource_Projects,
                                           _bindingSource_Employees, _bindingSource_EmployeesTreeView,
                                           _bindingSourceComponents, _bindingSourcePlacements);

            _importExcel.StatusBarMessage += StatusBarMessage;
            _importExcel.DockStateChanged += ImportExcelDockStateChanged;
            _importExcel.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;
            _importExcel.NotificationsToSends += StockRoomNotificationsToSends;

            this.CurrentDeptUserBroadcast_Requested += _importExcel.CurrentUserBroadcast_EventHandler;

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _importExcel.MdiParent = this;
                _importExcel.Show();
            }
            else
                _importExcel.Show(dockPanel);

            _importExcel.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);
            */
        }

        void FixOnAvailableToolStripMenuItemClick(object sender, EventArgs e)
        {
            fixOnAvailableToolStripMenuItem.Enabled = false;

            //   FixOnAvailable();
        }

        void Reset_OnHoldByToolStripMenuItem_Click(object sender, EventArgs e)
        {}

        void ToolStripMenuItemExploreH7HFile_Click(object sender, EventArgs e)
        {
            if (_employeesService.CurrentEmployeeLogIn.IsManager)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _h7h_ExplorerForm = new H7H_Explorer()
            {
                Text = @"H7H Explorer."
            };

            _h7h_ExplorerForm.StatusBarMessage += OnStatusBarMessage;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("H7H Explorer application at " + DateTime.Now),
                    }));

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _h7h_ExplorerForm.MdiParent = this;
                _h7h_ExplorerForm.Show();
            }
            else
                _h7h_ExplorerForm.Show(dockPanel);
        }

        void ToolStripMenuItem_ScanProjects_Click(object sender, EventArgs e)
        {
            InitializeFileFolderScann();
        }

        void ToolStripMenuItem_ScanThumbsdb_Click(object sender, EventArgs e)
        {
            ThumbNailsManagenment();
        }

        void ToolStripMenuItem_SimulateReading_Click(object sender, EventArgs e)
        {

        }

        void TimeLineEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitTimeLineEditor("TimeLine");
        }

        #region"toolStripMenuItem_ScanPathPdfDoc_Click"

        /// <summary>
        /// For each itemEFtableTreeView in stockroom table will scan the given path and
        /// update status information column with the names of documents found.
        /// </summary>
        void toolStripMenuItem_ScanPathPdfDoc_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_ScanPdfFiles.Enabled = false;
            _ = toolStripMenuItem_ScanPathPdfDoc();
        }

        async Task toolStripMenuItem_ScanPathPdfDoc()
        {
            /* Notice:
                        This process access information into the field "PartNumber" and "Status",
                        test if those columns are available before call it.
            */
      //      if (!Production_InventoryDataSet.Table_StockRoom.Columns.Contains("PartNumber") ||
      //          !Production_InventoryDataSet.Table_StockRoom.Columns.Contains("Status"))
      //          return;

      //      _bindingSource_StockRoom.RemoveSort();
       //     _bindingSource_StockRoom.SuspendBinding();
       //     Production_InventoryDataSet.Table_StockRoom.BeginLoadData();

            var taskA = await Task.Run(() =>
            {
     //           var pdfFileScan = new PdfFileScan(_bindingSource_StockRoom, CurrentDepartmentLogIn);

     //           pdfFileScan.StatusReportEvent += PdfFileScan_StatusReportEvent;
     //           pdfFileScan.RowProcessDoneEvent += PdfFileScan_RowProcessDoneEvent;
     //           pdfFileScan.ScanProcessDoneEvent += PdfFileScan_ScanProcessDoneEvent;

      //          pdfFileScan.StarScanning();

                string Done = "Done";

                return Done;
            });

        }

        void PdfFileScan_StatusReportEvent(object sender, string report)
        {
            InvokeOnUiThreadIfRequired(this, () =>
           {
               StatusBarHelp(report);
           });
        }

        void PdfFileScan_ScanProcessDoneEvent(object sender)
        {
            InvokeOnUiThreadIfRequired(this, () =>
            {
       //         _bindingSource_StockRoom.ResumeBinding();
                toolStripMenuItem_ScanPdfFiles.Enabled = true;
       //         Production_InventoryDataSet.Table_StockRoom.EndLoadData();
                //Production_InventoryDataSet.Table_StockRoom.AcceptChanges();
            });
        }

        void PdfFileScan_RowProcessDoneEvent(string partNumber, List<Tuple<string, string>> listDocInf)
        {
            /*
            InvokeOnUiThreadIfRequired(this, () =>
            {
                _bindingSource_StockRoom.SuspendBinding();

                int indexRow = _bindingSource_StockRoom.Find("PartNumber", partNumber);
                var rowToUpdate = _bindingSource_StockRoom[indexRow] as DataRowView;

                var statusRow = new CurrentStatus(rowToUpdate);
                var headerInfRow = statusRow.HeaderInformationObj;

                headerInfRow.AddListInf(listDocInf);

                statusRow.UpDateStatus();
                rowToUpdate.EndEdit();

                _bindingSource_StockRoom.ResumeBinding();
            });
            */
        }

        #endregion"toolStripMenuItem_ScanPathPdfDoc_Click"

        /// <summary>
        /// Initialize ConvertDocToPdf form and show it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ToolStripMenuItem_ConvertWorkDocToPDF_Click(object sender, EventArgs e)
        {
            //  using (ConvertDocToPdfNameSpace.ConvertDocToPdf _convertDocToPdf = new ConvertDocToPdfNameSpace.ConvertDocToPdf(CurrentDepartmentLogIn))
            //  {
            //      _convertDocToPdf.ShowDialog();
            // }
        }

        /// <summary>
        /// Check Status column for "HeaderInf:pdf|ATxxx;",
        /// Will clear any information where status column contains a different "HeaderInf:Null".
        /// Call save request on Stockroom.
        /// </summary>
        void ToolStripMenuItem_ClearAllDocumentsInformation_Click(object sender, EventArgs e)
        {
         //   ClearHeaderInfStatusColumn(Production_InventoryDataSet.Table_StockRoom);
         //   StockRoomSaveRequest();
        }

        #endregion"Tools"

        #endregion"MainMenu"

        #region"ToolStrip"

        void InitializeToolStrip()
        {
            toolStripButtonSpeechSynthesizer.Click += ToolStripButtonSpeechSynthesizer_Click;
        }

        #region"Button_Informations"
        void DropDownButton_Informations_Initialize()
        {
            toolStripMenuItem_dataBaseAddress.Click += ToolStripMenuItem_dataBaseAddress_Click;
            toolStripMenuItem_departmentName.Click += ToolStripMenuItem_departmentName_Click;
            toolStripMenuItem_lastUserLogIn.Click += ToolStripMenuItem_lastUserLogIn_Click;
            toolStripMenuItem_SearchAFileType.Click += ToolStripMenuItem_SearchAFileType_Click;
            toolStripMenuItem_testBarCodeReader.Click += ToolStripMenuItem_testBarCodeReader_Click;
            toolStripMenuItem_BrowseAppFolder.Click += ToolStripMenuItem_BrowseAppFolder_Click;
            toolStripMenuItem_browseInstallationFolder.Click += ToolStripMenuItem_browseInstallationFolder_Click;
            toolStripMenuItem_AppShortCutPath.Click += ToolStripMenuItem_AppShortCutPath_Click;
            toolStripMenuItem_IntervalReadingNotifications.Click += ToolStripMenuItem_IntervalReadingNotifications_Click;
            toolStripMenuItem_DataBaseDateTime.Click += ToolStripMenuItem_DataBaseDateTime_Click;
            toolStripMenuItem_ShowTheDocumentsAddressSetting.Click += ToolStripMenuItem_ShowTheDocumentsAddressSetting_Click;
        }

        void ToolStripMenuItem_AppShortCutPath_Click(object? sender, EventArgs e)
        {
            if (DesktopShortCutPath == null)
            {
                Text = "AppShortCutPath is not defined, if you are in debug mode it's no available...";
                return;
            }

            Text = DesktopShortCutPath;
        }

        void ToolStripMenuItem_AppProgramFolderPath_Click(object? sender, EventArgs e)
        {
            ProgramFolderPath = Application.ExecutablePath;

            if (ProgramFolderPath == null)
            {
                Text = "ProgramFolderPath is not defined, if you are in debug mode it's no available...";
                return;
            }

            Text = ProgramFolderPath;
        }

        void ToolStripMenuItem_ShowTheDocumentsAddressSetting_Click(object? sender, EventArgs e)
        {
            if (_employeesService.CurrentEmployeeLogIn.EmployeeAccessLevel < Utilities.AccessLevel.Manager)
                using (DocumentsAddressViewer documentsItemsViewer = new DocumentsAddressViewer(_employeesService, false))
                {
                    documentsItemsViewer.ShowDialog();
                }

            if (_employeesService.CurrentEmployeeLogIn.IsManager)
                using (DocumentsAddressViewer documentsItemsViewer = new DocumentsAddressViewer(_employeesService, true))
                {
                    documentsItemsViewer.ShowDialog();
                }
        }

        void ToolStripMenuItem_DataBaseDateTime_Click(object? sender, EventArgs e)
        {
            Text = "The Date & Time in DataBase computer is " + DataBaseTime;
        }

        void ToolStripMenuItem_IntervalReadingNotifications_Click(object? sender, EventArgs e)
        {
            Text = "Interval reading notifications set to " + Settings.Default.IntervalTrackBar_Value +
                                                                   " " + Settings.Default.IntervalTimeUnitName;
        }

        void ToolStripMenuItem_BrowseAppFolder_Click(object? sender, EventArgs e)
        {
            using (var openfile = new OpenFileDialog
            {
                InitialDirectory = Path.GetFullPath(Application.ExecutablePath),
                Title = @"Browse the App Data folder ...",
                FileName = "",
                Filter = @"",
                DefaultExt = ""
            }
                  )
            {
                if (openfile.ShowDialog(this) == DialogResult.Cancel)
                {
                    //MessageBox.Show(@"No Database selected. Must select one to continue.", @"DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Close();
                    return;
                }
            }
        }

        void ToolStripMenuItem_browseInstallationFolder_Click(object? sender, EventArgs e)
        {
            using (var openfile = new OpenFileDialog
            {
                InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath),
                Title = @"Browse the installation folder ...",
                FileName = "",
                Filter = @"",
                DefaultExt = ""
            }
                  )
            {
                if (openfile.ShowDialog(this) == DialogResult.Cancel)
                {
                    //MessageBox.Show(@"No Database selected. Must select one to continue.", @"DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Close();
                    return;
                }
            }
        }

        void ToolStripMenuItem_testBarCodeReader_Click(object? sender, EventArgs e)
        {
            TestBarCodeReader = true;

            Text = "Scan any barcode label and the system will show the information into a MessageBox.";
        }

        void ToolStripMenuItem_SearchAFileType_Click(object? sender, EventArgs e)
        {
            using (var sf = new SearchForm())
            {
                if (sf.ShowDialog().Equals(DialogResult.OK))
                {
                    string strPath = sf.m_strPath;
                    strPath = strPath.TrimStart();
                    strPath = strPath.TrimEnd();
                    if (!strPath.Equals(string.Empty) && File.Exists(strPath))
                        Text = strPath;
                }
            }
        }

        void ToolStripMenuItem_lastUserLogIn_Click(object? sender, EventArgs e)
        {
            Text = _employeesService.CurrentEmployeeLogIn.Name + ", " + _employeesService.CurrentEmployeeLogIn.Position + ".";
        }

        void ToolStripMenuItem_departmentName_Click(object? sender, EventArgs e)
        {
            Text = "This computer has been assigned to " + _employeesService.CurrentDepartmentLogIn.DepartmentName + " department.";
        }

        void ToolStripMenuItem_dataBaseAddress_Click(object? sender, EventArgs e)
        {
            Text = Settings.Default.DataBaseConnectionStringSQLite;
        }

        #endregion"Button_Informations"

        void ToolStripButtonSpeechSynthesizer_Click(object sender, EventArgs e)
        {
            if (SpeechSynthesizerBase.State == SynthesizerState.Ready)
            {
                SpeechSynthesizerBase.Pause();
             //   toolStripButtonSpeechSynthesizer.Image = Resources.speaker_mute;
                StatusBarHelp("SpeechSynthesizer has been paused.");
            }
            else
                if (SpeechSynthesizerBase.State == SynthesizerState.Paused)
            {
                SpeechSynthesizerBase.Resume();
             //   toolStripButtonSpeechSynthesizer.Image = Resources.speaker;
                StatusBarHelp("SpeechSynthesizer has been activated.");
            }
        }

        #endregion"ToolStrip"

        #region"User Log On"
                
        /// <summary>
        /// Maintains a record of login attempts, if a problem winth the database occurrs,
        /// and the system manager tries for 3 times,we give access to certain resources.
        /// </summary>
        int intentLogin = 0;
        string _password = "";
        string _hidepassword = "";
        int last6DigitInt = 0;

        /// <summary>
        /// All initialization are done at EmployeeService constructor.
        /// </summary>
        void InitializeUser()
        {
            //All initialization are done at _employeesService constructor.

            // If no user has been login, we load the parameters front the user index 0, who is any user with no rights.
            // ✅ Push the logged-in employee into the service — event fires automatically
            //_ = _employeesService.InitializeEmployeeAsync(_employeesService.NoUserLogIn);

            //StatusBarHelp("User LogIn done at " + _employeesService.CurrentEmployeeLogIn.Name + ".");
        }

        void ToolStripLabel_Log_User_Click(object sender, EventArgs e)
        {
            toolStripLabel_Log_User.Visible = false;
            toolStripTextBox_Log_User.Visible = true;
            toolStripTextBox_Log_User.Text = "";
            toolStripTextBox_Log_User.Focus();
            toolStripTextBox_Log_User.Tag = "User Leave";

            _password = "";
        }

        void ToolStripTextBox_Log_User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                return;

            _hidepassword += "*";

            toolStripTextBox_Log_User.Clear();
            toolStripTextBox_Log_User.Text = _hidepassword;

            _password += (char)e.KeyValue;

            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        void ToolStripTextBox_Log_User_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            _hidepassword = "";

            toolStripLabel_Log_User.Visible = true;
            toolStripTextBox_Log_User.Visible = false;
            toolStripTextBox_Log_User.Tag = "LogIn On process.";

            toolStripTextBox_Log_User.Text = "";

            LogInProcessAsync(_password);
        }

        void ToolStripButton_Log_out_Click(object sender, EventArgs e)
        {
            LogOutProcessAsync();
        }

        void ToolStripTextBox_Log_User_Leave(object sender, EventArgs e)
        {
            if (toolStripTextBox_Log_User.Tag.ToString().Contains("LogIn On process."))
            {
                toolStripTextBox_Log_User.Tag = "User Leave";
                return;
            }

            LogOutProcessAsync();
        }

        async Task LogInProcessAsync(string last6Digit)
        {
            try
            {
                #region"EmployeesInformation"
                
                last6DigitInt = int.TryParse(last6Digit, out last6DigitInt) ? last6DigitInt : 0;

                //var userLogIn = await _unitOfWork.TableEmployeeRepository.FirstOrDefaultAsync(e => e.Last6Digit == last6DigitInt);

                bool employeeInitialized = await _employeesService.InitializeEmployeeAsync(last6DigitInt);

                if (!employeeInitialized)
                    await _employeesService.InitializeEmployeeAsync(_employeesService.NoUserLogIn);

                #endregion"EmployeesInformation"
                                              
            }
            catch (Exception)
            {
                MessageBox.Show("EmployeeInformation information erroneous", "Missing EmployeeInformation Data.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (last6DigitInt == _employeesService.MasterPassword)
                    await _employeesService.InitializeEmployeeAsync(_employeesService.NoUserLogIn);
            }
        }

        async Task LogOutProcessAsync()
        {
            _password = "";
            _hidepassword = "";

            toolStripLabel_Log_User.Visible = true;
            toolStripTextBox_Log_User.Visible = false;

            toolStripTextBox_Log_User.Text = "";
            toolStripLabel_Log_User.Text = "Type your ID #.";

            toolStripTextBox_Log_User.Tag = "Log On process.";

            await _employeesService.InitializeEmployeeAsync(_employeesService.NoUserLogIn);
        }

        private static readonly char[] separator = new[] { ',' };

        #endregion"User Log On"

        #region"CurrentDeptment LogOn"
 
        void InitializeDepartment(string departmentName)
        {            
            try
            {
                // Department are initialize at EmployeeService constructor.
                ProcessCurrentDepartment();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        /// <summary>
        /// Ones the department is know, process all task
        /// related...
        /// </summary>
        void ProcessCurrentDepartment()
        {
            try
            {
                InitializeFileSystemWatcher(_employeesService);
                InvokeOnUiThreadIfRequired(this, () => Text = _employeesService.CurrentDepartmentLogIn.DepartmentName);
                InvokeOnUiThreadIfRequired(this, () => InitializedLogFile());

          //      if (Production_InventoryDataSet.Table_StockRoom_TreeView.Columns.Contains(" AvalaibleDepartments"))
          //      {
          //          InvokeOnUiThreadIfRequired(this, () => _bindingSourceStockRoomTreeView.Filter = " AvalaibleDepartments LIKE '*" +
           //                                                _employeesService.CurrentDepartmentLogIn.DepartmentName + "*'");
           //     }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        
        /// <summary>
        /// This field is used to execute the Kill command when it is received by SMS,
        /// note its processing inside the SmSController, the 
        /// </summary>
        public static bool IsCommandToKill;

        /// <summary>
        /// Time in sec to delay LogIn process.
        /// </summary>
        int _sec = 2;

        //AppPeriodicTimer_1seg
        System.Threading.Timer AppPeriodicTimer_5seg;
        Stopwatch stopwatchAppRunningTime;
        TimeSpan _delayToLogInCurrentUser;

        bool IsFirstTaskOnMasterTimerDone;
        bool IsInitializeWebApiProcessDone;

        void InitializeCurrentUserBroadcastTimer()
        {
            stopwatchAppRunningTime = Stopwatch.StartNew();

            _delayToLogInCurrentUser = TimeSpan.FromSeconds(_sec);
            
            //CurrentUserBroadcastDelay_Tick = procedure to callback, null = object pass to, First interval = 1000 ms, subsequent intervals = 1000 ms
            AppPeriodicTimer_5seg = new System.Threading.Timer(new TimerCallback(AppPeriodicTimer_5seg_Tick), null, 2000, 2000);
        }


        void AppPeriodicTimer_5seg_Tick(object obj)
        {
            if (IsFirstTaskOnMasterTimerDone == false)
            {
                _sec--;
                StatusBarHelp("  " + _sec + " sec left for user log in.");

                if (stopwatchAppRunningTime.Elapsed > _delayToLogInCurrentUser)
                    FirstTaskOnMasterTimer();
            }

            if (stopwatchAppRunningTime.Elapsed > TimeSpan.FromSeconds(25) && IsDoneInstallation)
            {
                if (HasInternetConnectionAvailable && Settings.Default.IsSuperPeer)
                    if (!IsInitializeWebApiProcessDone)
                        InitializeWebApiProcess();
            }

            if (IsCommandToKill)
                InvokeOnUiThreadIfRequired(this, () => Close());
        }

        void StartThreadTimerCurrentUserBroadcast()
        {
            AppPeriodicTimer_5seg.Change(20000, 1000); //enable
        }

        void StopThreadTimerCurrentUserBroadcast()
        {
            AppPeriodicTimer_5seg.Change(Timeout.Infinite, Timeout.Infinite); //disable
        }


        void Solutions_TempleClass_CurrentDeptUserBroadcast_Requested()
        {
            toolStripLabel_Log_User.Text = _employeesService.CurrentEmployeeLogIn.LastName + ", " +
                                           _employeesService.CurrentEmployeeLogIn.EmployeeAccessLevel +
                                           ", Login at " + DateTime.Now;

            StatusBarHelp("User " + _employeesService.CurrentEmployeeLogIn.LastName + " LogIn at " + DateTime.Now + ".");

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                {
                    Tags.NewLine(""),
                    Tags.NewLineBold(_employeesService.CurrentEmployeeLogIn.FullName),
                    Tags.NewLineRed(_employeesService.CurrentEmployeeLogIn.EmployeeAccessLevel.ToString()),
                    Tags.NewLine("A User LogIn at " + DateTime.Now),
                    Tags.StraigthLine
                }));

            if (_employeesService.CurrentEmployeeLogIn.IsUser)
            {
                #region"User"

                toolStripMenuItem_Employees.Visible = false;
                ToolStripMenuItem_LocationAndLayout.Visible = true;
                toolStripMenuItem_BOM_Managements.Visible = false;
                toolStripMenuItem_StockRoom_Receive.Visible = false;
                toolStripMenuItem_StockRoomMarshall.Visible = false;
                toolStripMenuItem_logFileManagement.Visible = false;
                toolStripMenuItem_stockRoomInventory.Visible = false;
                toolStripMenuItem_SolutionsProperties.Visible = false;
                toolStripMenuItem__stockRoomAddNewComp.Visible = false;

                if (_stockRoomForm == null)
                {
                    toolStripMenuItem_stockRoomInventory.Visible = true;
                }
                else
                {
                    toolStripMenuItem_stockRoomInventory.Visible = false;
                }

                return;

                #endregion"User"
            }

            if (_employeesService.CurrentEmployeeLogIn.IsEditor)
            {
                #region"Editor"

                toolStripMenuItem_Employees.Visible = false;
                ToolStripMenuItem_LocationAndLayout.Visible = true;
                toolStripMenuItem_BOM_Managements.Visible = false;
                toolStripMenuItem_StockRoom_Receive.Visible = true;
                toolStripMenuItem_StockRoomMarshall.Visible = false;
                toolStripMenuItem_logFileManagement.Visible = false;
                toolStripMenuItem_stockRoomInventory.Visible = true;
                toolStripMenuItem_SolutionsProperties.Visible = false;
                toolStripMenuItem__stockRoomAddNewComp.Visible = false;

                if (_stockRoomForm == null)
                {
                    toolStripMenuItem_stockRoomInventory.Enabled = true;
                }
                else
                {
                    toolStripMenuItem_stockRoomInventory.Enabled = false;
                }

                return;

                #endregion"Editor"
            }

            if (_employeesService.CurrentEmployeeLogIn.IsAdministrator)
            {
                #region"Administrator"

                toolStripMenuItem_Employees.Visible = false;
                ToolStripMenuItem_LocationAndLayout.Visible = true;
                toolStripMenuItem_BOM_Managements.Visible = true;
                toolStripMenuItem_StockRoom_Receive.Visible = true;
                toolStripMenuItem_StockRoomMarshall.Visible = false;
                toolStripMenuItem_logFileManagement.Visible = false;
                toolStripMenuItem_stockRoomInventory.Visible = true;
                toolStripMenuItem_SolutionsProperties.Visible = false;
                toolStripMenuItem__stockRoomAddNewComp.Visible = false;

                if (_stockRoomForm == null)
                {
                    toolStripMenuItem_stockRoomInventory.Enabled = true;
                }
                else
                {
                    toolStripMenuItem_stockRoomInventory.Enabled = false;
                }

                #endregion"Administrator"
            }

            if (_employeesService.CurrentEmployeeLogIn.IsManager)
            {
                #region"Manager"

                toolStripMenuItem_Employees.Visible = true;
                ToolStripMenuItem_LocationAndLayout.Visible = true;
                toolStripMenuItem_BOM_Managements.Visible = true;
                toolStripMenuItem_StockRoom_Receive.Visible = true;
                toolStripMenuItem_StockRoomMarshall.Visible = true;
                toolStripMenuItem_logFileManagement.Visible = true;
                toolStripMenuItem_stockRoomInventory.Visible = true;
                toolStripMenuItem_SolutionsProperties.Visible = true;
                toolStripMenuItem__stockRoomAddNewComp.Visible = true;

                if (_stockRoomForm == null)
                {
                    toolStripMenuItem_stockRoomInventory.Enabled = true;
                }
                else
                {
                    toolStripMenuItem_stockRoomInventory.Enabled = false;
                }

                #endregion"Manager"
            }
        }

        #endregion"CurrentDeptment LogOn"

        #region"WaitingTaskProcess"
        /// <summary>
        /// Queue a list of action to be executed when the system is ready.
        /// </summary>
        Queue<Action> WaitingTaskQueue = new Queue<Action>();

        void FirstTaskOnMasterTimer()
        {
            IsFirstTaskOnMasterTimerDone = true;

            if (!IsDoneInstallation)
                InvokeOnUiThreadIfRequired(this, () => CallSolutionsProperties(true));

            InitializeDepartment(Settings.Default.DepartmentName);
            /// We initialize user at the end to make sure that the department has already been initialized
            /// and propagate both information together in the same event.
            InitializeUser();
        }

        void ProcessWaitingTaskList()
        {
            while (WaitingTaskQueue.Count != 0)
            {
                var action = WaitingTaskQueue.Dequeue();
                action();
                //ThreadSafeInvoke(action);
                InvokeOnUiThreadIfRequired(this, action);
            }
        }


        #endregion"WaitingTaskProcess"

        #region"SpeechSynthesizerBase"

        void InitializeSpeechSynthesizerBase()
        {
            SpeechSynthesizerBase = new SpeechSynthesizer
            {
                Volume = _speechSynthesizerBaseVolume,
                Rate = _speechSynthesizerBaseRate
            };
        }

        public void SpeechSynthesizerBaseSpeak(object sender, Custom_Events_Args.SpeechSynthesizerBase_EventArgs e)
        {
            SpeechSynthesizerBase.SpeakAsync(e.Text);
        }

        #endregion"SpeechSynthesizerBase"

        #region"InitializeApplications"

        private static void InitSolutionsTemple(string textTitle)
        {
           
        }

        public void InitLabelsSMTPrint(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                // WaitingTaskQueue.Enqueue(new Action(() => LabelsSMTPrint(textTitle)));
                // return;
            }

            //ZebraPrintsPCBLabels zebraPrints = new ZebraPrintsPCBLabels(_bindingSource_Labels_SMT);
      //      _LabelsPrintsSMT = new LabelsPrintsSMT(_bindingSource_Labels_SMT, LastCurrentDeptUserBroadcast_EventArgs)
       //     {
      //          Text = textTitle
     //       };

            if (_LabelsPrintsSMT.DialogResult == DialogResult.Cancel)
                return; //An error has been found in the initialization.

            _LabelsPrintsSMT.LogFileMessage += Write_LogFile;
            _LabelsPrintsSMT.StatusBarMessageEvent += OnStatusBarMessage;
         //   _LabelsPrintsSMT.Save_Requested += LabelsSMT_ProcessSaveRequest;
            _LabelsPrintsSMT.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

       //     CurrentDeptUserBroadcast_Requested += _LabelsPrintsSMT.CurrentUserBroadcast_EventHandler;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("Initialized LabelsPrintsSMT (_bindingSource_Labels_SMT); ( LabelsSMT ) application at " + DateTime.Now),
                    }));

         //   _LabelsPrintsSMT.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);

            _LabelsPrintsSMT.TopMost = true;
            _LabelsPrintsSMT.Show();
        }

        public void InitSMTReelRecord(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitSMTReelRecord(textTitle)));
                return;
            }

         //   _SMT_Reel_Record = new SMT_Reel_Record(_bindingSource_Employees)
         //   {
         //       Text = textTitle
         //   };

            if (_SMT_Reel_Record.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
            {
                _SMT_Reel_Record = null;
                return;
            }

            _SMT_Reel_Record.FormClosing += SMTReelRecord_FormClosing;
            _SMT_Reel_Record.StatusBarMessageEvent += OnStatusBarMessage;
            _SMT_Reel_Record.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            ScannedDataEvent += _SMT_Reel_Record.OnBarcodeScanned_EventHandler;
      //      CurrentDeptUserBroadcast_Requested += _SMT_Reel_Record.CurrentUserBroadcast_EventHandler;

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _SMT_Reel_Record.MdiParent = this;
                _SMT_Reel_Record.Show();
            }
            else
            {
                _SMT_Reel_Record.Show(dockPanel);
            }

       //     _SMT_Reel_Record.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);
        }
        void SMTReelRecord_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _SMT_Reel_Record = null;
        }

        public void InitOrdersProcess(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitOrdersProcess(textTitle)));
                return;
            }

            _ordersProcess = new Orders_Process()
            {
                Text = textTitle
            };

            if (_ordersProcess.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            _ordersProcess.StatusBarMessageEvent += OnStatusBarMessage;
            _ordersProcess.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            ScannedDataEvent += _ordersProcess.OnBarcodeScanned_EventHandler;
       //     CurrentDeptUserBroadcast_Requested += _ordersProcess.CurrentUserBroadcast_EventHandler;

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _ordersProcess.MdiParent = this;
                _ordersProcess.Show();
            }
            else
            {
                _ordersProcess.Show(dockPanel);
            }

     //       _ordersProcess.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);
        }

        public void InitStockRoom(string textTitle)
        {
          //  if (!IsDoneInstallation)
          //  {
          //      WaitingTaskQueue.Enqueue(new Action(() => InitStockRoom(textTitle)));
          //      return;
          //  }

            /*
            _stockRoomForm = new StockRoom_Inventory(_bindingSourceStockRoomTreeView,
                                                _bindingSource_StockRoom,
                                                _bindingSource_CodeTreeView, DepartmentsList)
            {
                Text = textTitle
            };*/

            _stockRoomForm = _serviceProvider.GetRequiredService<StockRoom_Inventory>();
            {
                Text = textTitle;
            };


            //An error has been found in the initialization.
            if (_stockRoomForm == null || _stockRoomForm.DialogResult == DialogResult.Cancel)
                return;
                        
            _stockRoomForm.DockStateChanged += StockRoomDockStateChanged;
            _stockRoomForm.LogFileMessage += Write_LogFile;
            _stockRoomForm.StatusBarMessageEvent += OnStatusBarMessage;
          //  _stockRoomForm.Save_Requested += StockRoom_ProcessSaveRequest;
            _stockRoomForm.CellDoubleClick_Event += StockRoomCellDoubleClick;
          //  _stockRoomForm.SaveTreeView_Requested += StockRoomSaveTreeViewRequested;
         //   _stockRoomForm.AddNewItemSaveTreeViewRequested += AddNewItemSaveTreeViewRequested;
        //    _stockRoomForm.Refresh_Requested += StockRoomRefreshRequested;

            _stockRoomForm.Node_PDF += StockRoomNodePdf;
            _stockRoomForm.ActiveDataSheet += DocumentationBehaviorProcessor;
            _stockRoomForm.NotificationsToSends += NotificationsToSendsProcessor;
            _stockRoomForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            //_stockRoomForm.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);

       //     CurrentDeptUserBroadcast_Requested += _stockRoomForm.CurrentUserBroadcast_EventHandler;

            ScannedDataEvent += _stockRoomForm.OnBarcodeScanned_EventHandler;

            toolStripMenuItem_stockRoomInventory.Enabled = false;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("Initialized StockRoom ( Inventory Control ) application at " + DateTime.Now),
                    }));

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _stockRoomForm.MdiParent = this;
                _stockRoomForm.Show();
            }
            else
            {
                //_stockRoomForm.Dock = DockStyle.Fill;
                _stockRoomForm.Show(dockPanel);
            }
        }

        public void InitMarshallExplorer(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitMarshallExplorer(textTitle)));
                return;
            }

            if (_employeesService.CurrentEmployeeLogIn.IsManager)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        public void InitLocationAndLayout(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitLocationAndLayout(textTitle)));
                return;
            }

            _locationAndLayoutDesignForm = new LocationAndLayoutPlanning()
            {
                Text = textTitle
            };

            if (_locationAndLayoutDesignForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            _locationAndLayoutDesignForm.DockStateChanged += LocationLayoutDesingDockStateChanged;
            _locationAndLayoutDesignForm.LogFileMessage += Write_LogFile;
            _locationAndLayoutDesignForm.StatusBarMessageEvent += OnStatusBarMessage;
            _locationAndLayoutDesignForm.VisibleChanged += LocationLayoutDesignVisibleChanged;
         //   _locationAndLayoutDesignForm.Save_Requested += LocationAndLayoutDesignSaveRequested;
         //   _locationAndLayoutDesignForm.SaveTreeView_Requested += LocationAndLayoutDesignSaveTreeViewRequested;
            _locationAndLayoutDesignForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

      //      CurrentDeptUserBroadcast_Requested += _locationAndLayoutDesignForm.CurrentUserBroadcast_EventHandler;
            ScannedDataEvent += _locationAndLayoutDesignForm.OnBarcodeScanned;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("InitLocationAndLayoutDesing application at " + DateTime.Now)
                    }));

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _locationAndLayoutDesignForm.MdiParent = this;
                _locationAndLayoutDesignForm.Show();
            }
            else
                _locationAndLayoutDesignForm.Show(dockPanel);
        }

        public void InitStockRoomReceive(string textTitle)
        {
            return;

            if (IsDoneInstallation == false)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitStockRoomReceive(textTitle)));
                return;
            }

            if (_employeesService.CurrentEmployeeLogIn.EmployeeAccessLevel < Utilities.AccessLevel.Administrator)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        //    _stockRoomReceiveForm = new StockRoomReceive(_bindingSourceStockRoomTreeView, _bindingSource_StockRoom)
        //    {
        //        Text = textTitle
        //    };

            if (_stockRoomReceiveForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            _stockRoomReceiveForm.DockStateChanged += StockRoomReceiveDockStateChanged;
         //   _stockRoomReceiveForm.Save_Requested += StockRoom_ProcessSaveRequest;
            _stockRoomReceiveForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            CellDoubleClick_Event += _stockRoomReceiveForm.CellDoubleClick_Event;

            toolStripMenuItem_StockRoom_Receive.Enabled = false;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("Initialized StockRoom Receive application at " + DateTime.Now),
                    }));

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _stockRoomReceiveForm.MdiParent = this;
                _stockRoomReceiveForm.Show();
            }
            else
                _stockRoomReceiveForm.Show(dockPanel);

        }

        public void InitLogFileManagement(string textTitle)
        {
            if (IsDoneInstallation == false)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitLogFileManagement(textTitle)));
                return;
            }

            if (_employeesService.CurrentEmployeeLogIn.EmployeeAccessLevel < Utilities.AccessLevel.Manager)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _logFile_Management = new LogFile_Management(new Uri(@"file:///" + Application.StartupPath + "\\LogUser.html"))
            {
                Text = textTitle
            };

            if (_logFile_Management.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            _logFile_Management.DockStateChanged += LogFileDockStateChanged;

            //this.CurrentUserBroadcast_Requested += _logFile_Management.CurrentUserBroadcast_EventHandler;
            _logFile_Management.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            toolStripMenuItem_logFileManagement.Visible = false;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("Initialized LogFile application at " + DateTime.Now),
                    }));

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _logFile_Management.MdiParent = this;
                _logFile_Management.Show();
            }
            else
                _logFile_Management.Show(dockPanel);
        }

        public void InitEmployeesManagement(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitEmployeesManagement(textTitle)));
                return;
            }

            if (_employeesService.CurrentEmployeeLogIn.EmployeeAccessLevel < Utilities.AccessLevel.Manager)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

      //      DataTable dataTableInventory = ((DataSet)_bindingSource_StockRoom.DataSource).Tables[_bindingSource_StockRoom.DataMember];
            /*
            _employees_ManagementsForm = new Employees_Management(_bindingSource_Employees, _bindingSource_EmployeesTreeView, DepartmentsList)
            {
                Text = textTitle,
                ColumnsCollection_Inventory = dataTableInventory.Columns
            };

            if (_employees_ManagementsForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            _employees_ManagementsForm.DockStateChanged += EmployeesManagementsDockStateChanged;
       //     _employees_ManagementsForm.Refresh_Requested += EmployeesManagementsRefreshRequested;
         //   _employees_ManagementsForm.Save_Requested += EmployeesManagements_ProcessSaveRequest;
         //   _employees_ManagementsForm.SaveTreeView_Requested += EmployeesManagementsSaveTreeViewRequested;
            _employees_ManagementsForm.StatusBarMessageEvent += OnStatusBarMessage;
            _employees_ManagementsForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            CurrentDeptUserBroadcast_Requested += _employees_ManagementsForm.CurrentUserBroadcast_EventHandler;

            toolStripMenuItem_Employees.Enabled = false;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeesService.CurrentEmployeeLogIn.FullName),
                        Tags.NewLine("Employees Information application at " + DateTime.Now),
                    }));

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _employees_ManagementsForm.MdiParent = this;
                _employees_ManagementsForm.Show();
            }
            else
                _employees_ManagementsForm.Show(dockPanel);

            _employees_ManagementsForm.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);
            */
        }

        public void InitBomManagements(string textTitle)
        {
            /*
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitBomManagements(textTitle)));
                return;
            }

            if (_employeesService.CurrentEmployeeLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Administrator)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            toolStripMenuItem_BOM_Managements.Enabled = false;
            menuItemTools.HideDropDown();

            _bom_ManagementsForm = new BOM_Management(_bindingSourceStockRoomTreeView, _bindingSource_StockRoom, _employeesService.CurrentEmployeeLogIn, DepartmentsList)
            {
                Text = textTitle
            };

            if (_bom_ManagementsForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            _bom_ManagementsForm.Refresh_Requested += BomManagementsRefreshRequested;
            _bom_ManagementsForm.DockStateChanged += BomManagementsDockStateChanged;
            _bom_ManagementsForm.Save_Requested += StockRoom_ProcessSaveRequest;
            _bom_ManagementsForm.SaveTreeView_Requested += StockRoomSaveTreeViewRequested;
            _bom_ManagementsForm.StatusBarMessage += StatusBarMessage;
            _bom_ManagementsForm.TreeViewUpdate += TreeViewUpdateMethod;
            _bom_ManagementsForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            CurrentDeptUserBroadcast_Requested += _bom_ManagementsForm.CurrentUserBroadcast_EventHandler;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("BOM Managements application at " + DateTime.Now),
                    }));

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _bom_ManagementsForm.MdiParent = this;
                _bom_ManagementsForm.Show();
            }
            else
                _bom_ManagementsForm.Show(dockPanel);

            _bom_ManagementsForm.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);

            */
        }

        public void InitStockRoomAddNewComponent(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitStockRoomAddNewComponent(textTitle)));
                return;
            }

     //       _stockRoomAddNewCompForm = new StockRoom_AddNewComp(_bindingSource_StockRoom,
     //                                                       _bindingSource_CodeTreeView, DepartmentsList)
     //       {
    //            Text = textTitle
    //        };

            if (_stockRoomAddNewCompForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            //   _stockRoomAddNewComp.Need_SaveData      += StockRoom_NeedSaveData;
            _stockRoomAddNewCompForm.DockStateChanged += StockRoomAddNewCompDockStateChanged;
            //   _stockRoomAddNewComp.LogFileMessage     += Write_LogFile;
            _stockRoomAddNewCompForm.StatusBarMessageEvent += OnStatusBarMessage;
          //  _stockRoomAddNewCompForm.Save_Requested += StockRoom_ProcessSaveRequest;

         //   _stockRoomAddNewCompForm.SaveTreeView_Requested += StockRoomSaveTreeViewRequested;
            //   _stockRoomAddNewComp.AddNewItemSaveTreeViewRequested += AddNewItemSaveTreeViewRequested;
            //   _stockRoomAddNewComp.Refresh_Requested      += StockRoomRefreshRequested;

            //   _stockRoomAddNewComp.NotificationsToSends   += StockRoomNotificationsToSends;
            _stockRoomAddNewCompForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

      //      CurrentDeptUserBroadcast_Requested += _stockRoomAddNewCompForm.CurrentUserBroadcast_EventHandler;
            //   TreeViewUpdate                      += _stockRoomAddNewComp.TreeViewUpdate_EventHandler;
            //   ScannedData                         += _stockRoomAddNewComp.OnBarcodeScanned;

            toolStripMenuItem__stockRoomAddNewComp.Enabled = false;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("Initialized _stockRoomAddNewComp ( Inventory Control ) application at " + DateTime.Now),
                    }));

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _stockRoomAddNewCompForm.MdiParent = this;
                _stockRoomAddNewCompForm.Show();
            }
            else
            {
                _stockRoomAddNewCompForm.Show(dockPanel);
            }

      //      _stockRoomAddNewCompForm.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);
        }

        public void InitSolutionsProperties(string textTitle)
        {
            if (_employeesService.CurrentEmployeeLogIn.EmployeeAccessLevel < Utilities.AccessLevel.Administrator)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           CallSolutionsProperties(false);
        }

        public void InitTimeLineEditor(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitTimeLineEditor(textTitle)));
                MessageBox.Show(@"The system is still initializing, please wait a few seconds and try again.",
                                @"Warning, system not ready.",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

             //? Get TimeLineEditor from DI with all dependencies injected
               _timeLineEditorForm = _serviceProvider.GetRequiredService<TimeLineEditor>();
               {
                   Text = textTitle;
               };

            //_timeLineEditorForm._bindingSourceTimeLineTreeView = _bindingSource_TimeLine_TreeView;

           // _timeLineEditorForm = new TimeLineEditor(_bindingSource_TimeLine, _bindingSource_TimeLine_TreeView)
          //  {
          //      Text = textTitle
          //  };

            if (_timeLineEditorForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;
                        
            _timeLineEditorForm.DockStateChanged += TimeLineDockStateChanged;
            //_timeLineEditorForm.LogFileMessage += Write_LogFile;
            _timeLineEditorForm.StatusBarMessageEvent += OnStatusBarMessage;
            //_timeLineEditorForm.Save_Requested += TimeLine_ProcessSaveRequest;
            // _timeLineEditorForm.CellDoubleClick_Event += StockRoomCellDoubleClick;
           // _timeLineEditorForm.SaveTreeView_Requested += TimeLineSaveTreeViewRequested;
            //_timeLineEditorForm.AddNewItemSaveTreeViewRequested += AddNewItemSaveTreeViewRequested;
            //_timeLineEditorForm.Refresh_Requested += StockRoomRefreshRequested;

            //_timeLineEditorForm.Node_PDF += StockRoomNodePdf;
            //_timeLineEditorForm.ActiveDataSheet += DocumentationBehaviorProcessor;
            //_timeLineEditorForm.NotificationsToSends += StockRoomNotificationsToSends;
            _timeLineEditorForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

           // _timeLineEditorForm.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);

          //  CurrentDeptUserBroadcast_Requested += _timeLineEditorForm.CurrentUserBroadcast_EventHandler;

            ToolStripMenuItem_TimeLineEditor.Enabled = false;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("Initialized TimeLineEditorForm application at " + DateTime.Now),
                    }));

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _timeLineEditorForm.MdiParent = this;
                _timeLineEditorForm.Show();
            }
            else
            {
                //_timeLineEditorForm.Dock = DockStyle.Fill;
                _timeLineEditorForm.Show(dockPanel);
            }
        }

        #endregion"InitializeApplications"

        #region"StockRoom Inventory Control"

        void StockRoomCellDoubleClick(object sender, CellDoubleClick_EventArgs e)
        {
            if (_employeesService.CurrentEmployeeLogIn.EmployeeAccessLevel == Utilities.AccessLevel.User)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_stockRoomReceiveForm == null)
                ToolStripMenuItemStockRoomReceiveClick(new object(), new EventArgs());

            On_CellDoubleClick_Event(e);

            foreach (IDockContent document in dockPanel.DocumentsToArray().Where
                                                    (document => document.DockHandler.TabText.Contains("StockRoom Receive Control")))
            {
                document.DockHandler.Activate();
                return;
            }
        }

        string _lastNodePdf = "";
        public void StockRoomNodePdf(object sender, ActiveDataSheet_EventArgs e)
        {
            if (_nodePDF == null)
                return;

            if (_lastNodePdf.Contains(e.DataSheet))
                return;

            _lastNodePdf = e.DataSheet;
            On_Node_PDF(e);
        }

        #endregion"StockRoom Inventory Control"
        
        #region"WeifenLuo.WinFormsUI.Docking"

        static IDockContent GetContentFromPersistString(string persistString)
        {
            //	if (persistString == typeof(DummySolutionExplorer).ToString())
            //		return m_solutionExplorer;
            //	else if (persistString == typeof(DummyPropertyWindow).ToString())
            //		return m_propertyWindow;
            //	else if (persistString == typeof(DummyToolbox).ToString())
            //		return m_toolbox;
            //	else if (persistString == typeof(DummyOutputWindow).ToString())
            //		return m_outputWindow;
            //	else if (persistString == typeof(DummyTaskList).ToString())
            //		return m_taskList;
            //	else
            //	{
            // DummyDoc overrides GetPersistString to add extra information into persistString.
            // Any DockContent may override this value to add any needed information for deserialization.

            string[] parsedStrings = persistString.Split(separator);
            if (parsedStrings.Length != 3)
                return null;

            //    var test = new Pdf_explorer();

            //      if (parsedStrings[0] != test.GetType().ToString())
            //          return null;

            //     var dummyDoc = new Pdf_explorer();

            //    if (parsedStrings[1] != String.Empty)
            //         dummyDoc.Text = parsedStrings[1];


            //     if (parsedStrings[2] != String.Empty)
            //         dummyDoc.Text = parsedStrings[2];

            //     return dummyDoc;
            return null;

        }

        IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                return (from form in MdiChildren where form.Text == text select form as IDockContent).FirstOrDefault();
            }

            return dockPanel.Documents.FirstOrDefault(content => content.DockHandler.TabText == text);
        }

        #region"DockStateChanged"

        public void StockRoomAddNewCompDockStateChanged(object? sender, EventArgs e)
        {
            if (_stockRoomAddNewCompForm == null)
                return;

            if (_stockRoomAddNewCompForm.DockState == DockState.Unknown)
            {
                if (_employeesService.CurrentEmployeeLogIn.IsUser)
                    toolStripMenuItem__stockRoomAddNewComp.Enabled = false;
                else
                    toolStripMenuItem__stockRoomAddNewComp.Enabled = true;

                _stockRoomAddNewCompForm.DockStateChanged -= StockRoomAddNewCompDockStateChanged;
                _stockRoomAddNewCompForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(Table_Employee.FullName),
                        Tags.NewLine("Closing the Add new Comp at " + DateTime.Now)
                    }));
            }
        }

        public void EmployeesManagementsDockStateChanged(object? sender, EventArgs e)
        {
            if (_employees_ManagementsForm == null)
                return;

            if (_employees_ManagementsForm.DockState == DockState.Unknown)
            {
                if (_employeesService.CurrentEmployeeLogIn.IsUser)
                    toolStripMenuItem_Employees.Enabled = false;
                else
                    toolStripMenuItem_Employees.Enabled = true;

                _employees_ManagementsForm.DockStateChanged -= EmployeesManagementsDockStateChanged;
                _employees_ManagementsForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(Table_Employee.FullName),
                        Tags.NewLine("Closing the Employees Managements at " + DateTime.Now)
                    }));
            }
        }

        public void StockRoomDockStateChanged(object? sender, EventArgs e)
        {
            if (_stockRoomForm == null)
                return;

            if (_stockRoomForm.DockState == DockState.Unknown)
            {
                if (_employeesService.CurrentEmployeeLogIn.IsUser)
                    toolStripMenuItem_stockRoomInventory.Enabled = false;
                else
                    toolStripMenuItem_stockRoomInventory.Enabled = true;

                _stockRoomForm.DockStateChanged -= StockRoomDockStateChanged;
             //   _stockRoomForm.Save_Requested -= StockRoom_ProcessSaveRequest;
                _stockRoomForm.CellDoubleClick_Event -= StockRoomCellDoubleClick;
             //   _stockRoomForm.SaveTreeView_Requested -= StockRoomSaveTreeViewRequested;

              //  _stockRoomForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(Table_Employee.FullName),
                        Tags.NewLine("Closing the StockRoom Managements at " + DateTime.Now)
                    }));
            }

        }

        public void LogFileDockStateChanged(object sender, EventArgs e)
        {
            if (_logFile_Management == null)
                return;

            if (_logFile_Management.DockState == DockState.Unknown)
            {
                if (_employeesService.CurrentEmployeeLogIn.IsManager)
                    toolStripMenuItem_logFileManagement.Visible = true;
                else
                    toolStripMenuItem_logFileManagement.Visible = false;

                _logFile_Management = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(Table_Employee.FullName),
                        Tags.NewLine("Closing the LogFile Managements at " + DateTime.Now)
                    }));
            }
        }

        public void StockRoomReceiveDockStateChanged(object? sender, EventArgs e)
        {
            if (_stockRoomReceiveForm == null)
                return;

            if (_stockRoomReceiveForm.DockState == DockState.Unknown)
            {
                if (_employeesService.CurrentEmployeeLogIn.IsUser)
                    toolStripMenuItem_StockRoom_Receive.Enabled = false;
                else
                    toolStripMenuItem_StockRoom_Receive.Enabled = true;

                _stockRoomReceiveForm.DockStateChanged -= StockRoomReceiveDockStateChanged;
            //    _stockRoomReceiveForm.Save_Requested -= StockRoom_ProcessSaveRequest;

                CellDoubleClick_Event -= _stockRoomReceiveForm.CellDoubleClick_Event;

                //          CurrentUserBroadcast_Requested -= new CurrentUserBroadcast_EventHandler(_stockRoomReceive.CurrentUserBroadcast_EventHandler);

                _stockRoomReceiveForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(Table_Employee.FullName),
                        Tags.NewLine("Closing the Receive Managements at " + DateTime.Now)
                    }));
            }
        }

        public void LocationLayoutDesingDockStateChanged(object sender, EventArgs e)
        {
            if (_locationAndLayoutDesignForm == null)
                return;

            if (_locationAndLayoutDesignForm.DockState == DockState.Unknown)
            {
                if (_employeesService.CurrentEmployeeLogIn.IsUser)
                    ToolStripMenuItem_LocationAndLayout.Enabled = false;
                else
                    ToolStripMenuItem_LocationAndLayout.Enabled = true;

                _locationAndLayoutDesignForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(Table_Employee.FullName),
                        Tags.NewLine("Closing the Location and Layout Desing at " + DateTime.Now)
                    }));
            }
        }

        public void TimeLineDockStateChanged(object? sender, EventArgs e)
        {
            if (_timeLineEditorForm == null)
                return;

            if (_timeLineEditorForm.DockState == DockState.Unknown)
            {
                if (_employeesService.CurrentEmployeeLogIn.IsUser)
                    ToolStripMenuItem_TimeLineEditor.Enabled = false;
                else
                    ToolStripMenuItem_TimeLineEditor.Enabled = true;

                _timeLineEditorForm.DockStateChanged -= TimeLineDockStateChanged;

                _timeLineEditorForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(Table_Employee.FullName),
                        Tags.NewLine("Closing the TimeLineEditor at " + DateTime.Now)
                    }));
            }
        }

        #endregion"DockStateChanged"

        #endregion"WeifenLuo.WinFormsUI.Docking"

        #region"StatusBarMessage"

        int _intervalResetCount;
        int _intervalCount;
        System.Windows.Forms.Timer _statusBarTimer;
        System.Windows.Forms.Timer _statusBarTimerToClear;
        ObservableCollection<StatusBarMessage_EventArgs> _statusBarMessageCollection;

        void InitializeStatusBarTimer()
        {
            toolStripStatusLabel_Spacer1.Text = "  ";
            toolStripStatusLabel_Spacer2.Text = "  ";
            toolStripStatusLabel_Spacer3.Text = "  ";
            toolStripStatusLabel_Progress.Text = "";
            toolStripStatusLabel_Message.Text = "";

            _intervalCount = 100;
            _intervalResetCount = 100;
            _statusBarMessageCollection = new ObservableCollection<StatusBarMessage_EventArgs>();
            _statusBarMessageCollection.CollectionChanged += StatusBarMessage_CollectionChanged;

            _statusBarTimer = new System.Windows.Forms.Timer
            {
                Interval = 400
            };
            _statusBarTimer.Tick += new EventHandler(StatusBarTimer_Tick);

            _statusBarTimerToClear = new System.Windows.Forms.Timer
            {
                Interval = 10
            };
            _statusBarTimerToClear.Tick += new EventHandler(StatusBarTimerToClear_Tick);
        }

        void StatusBarMessage_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
                return;

            if (_statusBarTimer.Enabled)
                return;

            _statusBarTimer.Start();
        }

        void StatusBarTimer_Tick(object? sender, EventArgs e)
        {
            _statusBarTimer.Stop();

            StatusBarMessage_EventArgs message_EventArgs;
            message_EventArgs = _statusBarMessageCollection[0];

            InvokeOnUiThreadIfRequired(this, () =>
            {
                toolStripStatusLabel_Message.Image = message_EventArgs.StatusBarIcon?.ToBitmap();
                toolStripStatusLabel_Message.Text = message_EventArgs.StatusBarMessage;
            });

            _statusBarMessageCollection.RemoveAt(0);

            _statusBarTimerToClear.Start();
        }

        void StatusBarTimerToClear_Tick(object? sender, EventArgs e)
        {
            if (_intervalResetCount > 0)
            {
                if (_mouseInToolStripStatusLabel_Progress)
                    return;

                _intervalResetCount--;

                if (_statusBarMessageCollection.Count == 0)
                    toolStripStatusLabel_Progress.Text = "" + _intervalResetCount;
                else
                    toolStripStatusLabel_Progress.Text = _statusBarMessageCollection.Count + " -> " + _intervalResetCount;

                return;
            }

            _intervalResetCount = _intervalCount;

            _statusBarTimerToClear.Stop();

            InvokeOnUiThreadIfRequired(this, () =>
            {
                toolStripStatusLabel_Progress.Text = "";
                toolStripStatusLabel_Message.Image = null;
                toolStripStatusLabel_Message.Text = string.Empty;
            });

            if (_statusBarMessageCollection.Count > 0)
                _statusBarTimer.Start();
        }

        public void OnStatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            if (e.StatusBarHelp != null)
                StatusBarHelp(e.StatusBarHelp);

            if (!string.IsNullOrEmpty(e.StatusBarMessage) || !string.IsNullOrWhiteSpace(e.StatusBarMessage))
            {
                StatusBarMessage(e);
                InvokeOnUiThreadIfRequired(this, () =>
                {
                    if (e.StatusBarHelp != null)
                        toolStripStatusLabel_Message.Image = e.StatusBarIcon.ToBitmap();
                });
            }
        }

        /// <summary>
        /// Write in the status bar, the message from any control.
        /// </summary>
        /// <param name="statusTex"></param>
        /// <param name="statusText">todo: describe statusText parameter on StatusBarMessage</param>
        public void StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            if (e.Streaming)
            {
                // statusStrip.Items[nameof(statusBarPanelMessage)].Text = e.StatusBarMessage;
                //  return;
            }

            InvokeOnUiThreadIfRequired(this, () =>
            {
                _statusBarMessageCollection.Add(e);
            });
        }

        /// <summary>
        /// Write in the status bar, the help from any control.
        /// </summary>
        /// <param name="statusText"></param>
        public void StatusBarHelp(string statusText)
        {
            InvokeOnUiThreadIfRequired(this, () =>
            {
                toolStripStatusLabel_Help.Text = statusText;
            });
        }

        /// <summary>
        /// Write in the status bar.Panels["statusBarPanelNotificationEvents"], the event message.
        /// </summary>
        /// <param name="statusTex"></param>
        public void StatusBarNotificationEvents(string statusTex)
        {
            InvokeOnUiThreadIfRequired(this, () =>
            {
                toolStripStatusLabel_NotificationEvents.Text = statusTex;
            });
        }

        /// <summary>
        /// Write in the status bar.Panels["statusBarPanelMousePosition"], the mouse position.
        /// </summary>
        /// <param name="statusTex"></param>
        public void StatusBarMousePosition(string statusTex)
        {
            InvokeOnUiThreadIfRequired(this, () =>
            {
                toolStripStatusLabel_MousePosition.Text = statusTex;
            });
        }

        #endregion"StatusBarMessage"

        #region"VisibleChanged"
        public void LocationLayoutDesignVisibleChanged(object sender, EventArgs e)
        {
            //       var _mouseposition = Cursor.Position;

            //       if (_pdfWindow.Visible)
            //       {
            //           Cursor.Position = new Point(_mouseposition.X, (_mouseposition.Y + 75));

            //           MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);
            //           MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);
            //       }
        }

        #endregion"VisibleChanged"
        
        #region"NotifycationsToSend"

        void NotificationsToSendsProcessor(object sender, Notification e)
        {
            try
            {
                NotificationsToSends.TryAdd(NotificationsToSends.Count + 1, e);
            }
            catch (Exception error)
            {
                MessageBox.Show("An error has been found, " + error.Message, "New Status row error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion"NotifycationsToSend"

        #region"TreeViewUpdateMethod"

        void TreeViewUpdateMethod(object sender, TreeViewUpdateEventArgs e)
        {
            On_TreeViewUpdate(e);
        }

        #endregion"TreeViewUpdateMethod"

        #region"DocumentationBehaviorProcessor"

        bool _pdf_explorer_Success = true;
        string _lastDataSheet = "";
        int _indexOpenedPdfDocuments;

        /// <summary>
        /// List of Pdf_explorer form opened by Documentation Behavior Process.
        /// </summary>
   //     List<PDFjs_explorer> openedPDF_Documents = new List<PDFjs_explorer>();

        List<FileDirectoryModel> DocumentScanned = new List<FileDirectoryModel>();

        System.Windows.Forms.Timer _docFactoryTimer;
        void InitializeDocumentationBehaviorTimer(int interval)
        {
            _docFactoryTimer = new System.Windows.Forms.Timer
            {
                Interval = interval
            };
            _docFactoryTimer.Tick += _docFactoryTimer_Tick;
            _docFactoryTimer.Stop();
        }

        void InitializeDocumentationBehaviorProcess()
        {
            if (Settings.Default.InstallationFirstDate == DateTime.Parse("1/1/2000"))
                return;

            _docFactoryTimer.Start();
        }

        void _docFactoryTimer_Tick(object sender, EventArgs e)
        {
            _docFactoryTimer.Stop();

            if (_solutionPropertiesForm != null)
                return;

            InitializeDocumentationBehavior();
        }

        /// <summary>
        /// Initialize the documentation behavior process, test the DocumentationBehavior setting property
        /// and set the container correspond.
        /// </summary>
        public void InitializeDocumentationBehavior()
        {
            ResetDocumentsViewerProcess();

            switch (_documentationBehavior)
            {
                case Utilities.DocumentationBehavior.SpecifiedDocument:
                    {
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        break;
                    }
                case Utilities.DocumentationBehavior.LastRevision:
                    {
                        PdfViewerFactory("LastRevision", null);
                        break;
                    }
                case Utilities.DocumentationBehavior.AllVersionsFound:
                    {
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);
                        if (_pdf_explorer_Success)
                            PdfViewerFactory("", null);

                        break;
                    }
                case Utilities.DocumentationBehavior.Last2Versions:
                    {
                        PdfViewerFactory("", null);
                        PdfViewerFactory("", null);
                        break;
                    }
                case Utilities.DocumentationBehavior.BrowserForAnVersion:
                    {
                        PdfViewerFactory("", null);
                        break;
                    }
                case Utilities.DocumentationBehavior.NoDocumentsExist:
                    {
                        break;
                    }
            }

            LoadComplete();
        }

        void LoadComplete()
        {
            SuspendLayout();

            #region"PdfViewer"
            /*
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (PDFjs_explorer documentViewer in openedPDF_Documents)
                {
                    //documentViewer.MdiParent = this;
                    //documentViewer.Show();
                }
            }
            else
            {
                foreach (PDFjs_explorer documentViewer in openedPDF_Documents)
                {
                    //documentViewer.Show(dockPanel, DockState.Document);
                }
            }
            */
            #endregion"PdfViewer"

            foreach (IDockContent document in dockPanel.DocumentsToArray())
            {
                if (document.DockHandler.TabText.Contains("Inventory Control"))
                {
                    document.DockHandler.Activate();
                }
            }

            ResumeLayout();
        }

        void DocumentationBehaviorProcessor(object sender, ActiveDataSheet_EventArgs e)
        {
            ResetDocumentsViewerProcess();
            _indexOpenedPdfDocuments = -1;

            if (e == null)
                return;

            switch (_documentationBehavior)
            {
                case Utilities.DocumentationBehavior.SpecifiedDocument:
                    {
                        SpecifiedDocumentProcess(e);
                        break;
                    }
                case Utilities.DocumentationBehavior.LastRevision:
                    {
                        LastRevisionProcess(e);
                        break;
                    }
                case Utilities.DocumentationBehavior.AllVersionsFound:
                    {
                        AllVersionsFoundProcess(e);
                        break;
                    }
                case Utilities.DocumentationBehavior.Last2Versions:
                    {
                        Last2VersionsProcess(e);
                        break;
                    }
                case Utilities.DocumentationBehavior.BrowserForAnVersion:
                    {
                        BrowserForAnVersionProcess(e);
                        break;
                    }
                case Utilities.DocumentationBehavior.NoDocumentsExist:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// if DataSheet_File column contains a file name out ext, we add
        /// Settings.Default.DataBaseAddress + DataSheet_File + ext .pdf
        /// </summary>
        void SpecifiedDocumentProcess(ActiveDataSheet_EventArgs e)
        {
            if (e.DataSheet == null)
                return;

            if (e.DataSheet.Length > 3)
            {
                if (!_lastDataSheet.Contains(e.DataSheet))
                {
                    _lastDataSheet = e.DataSheet;
                    ProcessDataSheet(e);
                }
            }
            else
            {
                if (!_lastDataSheet.Contains("No Data Sheet Found"))
                {
                    _lastDataSheet = "No Data Sheet Found";
                    // ProcessDataSheet(new ActiveDataSheet_EventArgs("",e.PartNumber, "No Data Sheet Found.pdf"));
                }
            }
        }

        void LastRevisionProcess(ActiveDataSheet_EventArgs e)
        {
            SpecifiedDocumentProcess(e);
        }

        void Last2VersionsProcess(ActiveDataSheet_EventArgs e)
        {
            SpecifiedDocumentProcess(e);
        }

        void AllVersionsFoundProcess(ActiveDataSheet_EventArgs e)
        {
            ProcessDataSheet(e);

            foreach (DocumentsAddressItem documentsAddressItem in _employeesService.CurrentDepartmentLogIn.DepartmentDocumentsAddressItems)
            {
                if (!Directory.Exists(documentsAddressItem.DocumentsAddressValueDirectory))
                {
                    OnStatusBarMessage(new object(), new StatusBarMessage_EventArgs("Not a valid Directory " +
                                                                                  documentsAddressItem.DocumentsAddressValueDirectory,
                                                                                  Resources.ErrorIcon));
                    continue;
                }

                var taskA = Task.Run(() => DocumentFileScan(documentsAddressItem.DocumentsAddressValueDirectory, "*" +
                                                         e.PartNumber + "*", documentsAddressItem.DocumentsExtensionAcepted));
            }
        }

        void BrowserForAnVersionProcess(ActiveDataSheet_EventArgs e)
        {
            SpecifiedDocumentProcess(e);
        }

        /// <summary>
        /// Created a new PDF document viewer, be possible assign a TabName and dataSheet file.
        /// </summary>
        /// <param name="tabName">Text to be show in Tab text.</param>
        /// <param name="dataSheetFileName">DataSheet file to be opened, null if no file to open.</param>
        void PdfViewerFactory(string tabName, string dataSheetFileName)
        {
            try
            {
                /*
                MessageDebugPosition = "var documentViewer = new Pdf_explorer";
                var documentViewer = new PDFjs_explorer
                {
                   // Text = tabName,
                    Index = openedPDF_Documents.Count,
                    CurrentEmployeesLogIn = CurrentEmployeesLogIn,
                    SetDataSheet = null
                };

                
                if (documentViewer.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                {
                    _pdf_explorer_Success = false;
                    using (var form = new Form { TopMost = true })
                    {
                        MessageBox.Show(form, @"Break code at position " + MessageDebugPosition +
                                              @"Interop.PDFXCviewAxLib.dll file needs to be copied.",
                                              @"Solutions_TempleClass fail in DocumentViewerFactory()",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }*/

                MessagePositionString = "DocumentViewerFactory() -> documentViewer.SpeechSynthesizerBase +=";
                //   documentViewer.CloseButtonVisible = false;

                //   openedPDF_Documents.Add(documentViewer);
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                          @", Break code at position " + MessagePositionString,
                                          @"Solutions_TempleClass, Solutions_TempleClass fail in DocumentViewerFactory()",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Will scan the pathRootFolder parameter directory and found any file match fileToMach parameter.
        /// </summary>
        /// <param name="pathRootFolder"></param>
        /// <param name="fileToMatch"></param>
        void DocumentFileScan(string pathRootFolder, string fileNameToMatch, string fileExtToMatch)
        {
            using (FileSystemEnumerator fse = new FileSystemEnumerator(pathRootFolder,
                                                                        fileExtToMatch,
                                                                        true,
                                                                        true,
                                                                        500000))
            {
                foreach (FileInfo document in fse.MatchesFiles(fileNameToMatch))
                {
                    if (_indexOpenedPdfDocuments == 9)
                        return;

                    _indexOpenedPdfDocuments++;
                    //  openedPDF_Documents[_indexOpenedPdfDocuments].SetDataSheet = new ActiveDataSheet_EventArgs( document.Name, document.FullName, document.FullName);
                }

                if (_indexOpenedPdfDocuments > 0)
                    OnStatusBarMessage(new object(), new StatusBarMessage_EventArgs("Number of files founded " +
                                                      (_indexOpenedPdfDocuments + 1) + ", " + pathRootFolder +
                                                      @"\" + fileNameToMatch + fileExtToMatch.Replace("*", ""),
                                                      Resources.OK));
            }
        }

        void ResetDocumentsViewerProcess()
        {
            DocumentScanned.Clear();
            ClearTabTextSetNoDataSheet();
        }

        void ClearTabTextSetNoDataSheet()
        {
            /*
            if (openedPDF_Documents.Count == 0)
                return;

            while (_indexOpenedPdfDocuments > -1)
            {
                string emptyDataSheetAddress = Settings.Default.DataBaseAddress + "\\DataSheets\\";
                openedPDF_Documents[_indexOpenedPdfDocuments].SetDataSheet = new ActiveDataSheet_EventArgs("", emptyDataSheetAddress, "No Empty Data Sheet.pdf"); ;
                _indexOpenedPdfDocuments--;
            }
            */
        }

        void CloseAllDocumentViewer()
        {
            /*
            foreach (PDFjs_explorer documentViewer in openedPDF_Documents)
            {
                //documentViewer.Close();
            }

            openedPDF_Documents.Clear();

            _pdfWindowForm?.Close();

            */
        }

        void ProcessDataSheet(ActiveDataSheet_EventArgs e)
        {
            FileInfo _defaultDataSheetFile;
            List<string> dataSheetFiles = new List<string>();

            try
            {
                if (e.DataSheet.Contains(";"))
                    dataSheetFiles.AddRange(e.DataSheet.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
                else
                    dataSheetFiles.Add(e.DataSheet);

                foreach (string strFileName in dataSheetFiles)
                {
                    //  _defaultDataSheetFile = new FileInfo(Path.Combine(e.DefaultPath, strFileName.Trim()));

                    if (strFileName.Contains("#pag"))
                    {
                        int indexOf = strFileName.IndexOf("#", StringComparison.Ordinal);
                        if (strFileName.Length > indexOf)
                        {
                            string pageToOpen = strFileName.Substring(indexOf);
                            string fileName = strFileName.Remove(indexOf);
                            //         _defaultDataSheetFile = new FileInfo(Path.Combine(e.DefaultPath, fileName.Trim()));
                        }
                    }
                    /*
                    if (_defaultDataSheetFile.Exists)
                    {
                        _indexOpenedPdfDocuments++;

                        if (_indexOpenedPdfDocuments < openedPDF_Documents.Count)
                        {
                            openedPDF_Documents[_indexOpenedPdfDocuments].SetDataSheet = new ActiveDataSheet_EventArgs(e.PartNumber, e.DefaultPath, strFileName);
                            StatusBarMessage(new object(), new StatusBarMessage_EventArgs("The specified file " + e.DataSheet + " was found...", MyStuff11net.Properties.Resources.OK));
                        }
                        else
                        {                            
                            StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Cannot open more documents, Setting Document Behavior", MyStuff11net.Properties.Resources.OK));
                        }
                    }
                    else
                    {
                        openedPDF_Documents[_indexOpenedPdfDocuments].SetDataSheet = new ActiveDataSheet_EventArgs("", e.DefaultPath, "No Empty Data Sheet.pdf");
                        StatusBarMessage(new object(), new StatusBarMessage_EventArgs("The specified file " + e.DataSheet + " was not found...", MyStuff11net.Properties.Resources.ErrorIcon));
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                OnStatusBarMessage(new object(), new StatusBarMessage_EventArgs("The file name " + e.DataSheet + " has an error " + ex.Message, Resources.ErrorIcon));
            }
        }

        #endregion"DocumentationBehaviorProcessor"

        #region"MouseKeyEventProvider"

        MouseKeyEventProvider _mouseKeyEventProvider;

        void Initialize_MouseKeyEventProvider()
        {
            _mouseKeyEventProvider = new StockRoom11net.Controls.MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider
            {
                Enabled = true,
                HookType = HookType.Global
            };

            _mouseKeyEventProvider.MouseMove += mouseKeyEventProvider_StockRoom_MouseMove;
            _mouseKeyEventProvider.MouseDown += _mouseKeyEventProvider_MouseDown;
            _mouseKeyEventProvider.MouseClickExt += _mouseKeyEventProvider_MouseClickExt;
            _mouseKeyEventProvider.MouseDownExt += _mouseKeyEventProvider_MouseDownExt;
        }

        private void _mouseKeyEventProvider_MouseClickExt(object sender, MouseEventExtArgs e)
        {

        }

        private void _mouseKeyEventProvider_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            if (e.Button == MouseButtons.Left)
                return;

            e.Handled = false;
        }

        private void _mouseKeyEventProvider_MouseDown(object sender, MouseEventArgs e)
        {

        }

        void mouseKeyEventProvider_StockRoom_MouseMove(object sender, MouseEventArgs e)
        {
            StatusBarMousePosition("  " + e.Location);
        }

        #endregion"MouseKeyEventProvider"

        #region"USB-BarCode initialization & BarcodeScanned"

        RawInput _rawinput;
        KeyPressEvent USBDevice;
        System.Windows.Forms.Timer USBDeviceBarCodeInfoChangeTimer;
        const bool CaptureOnlyInForeground = false;

        void Init_USB_BarCode()
        {
            if (USBDevice != null)
                return;

            USBDevice = new KeyPressEvent()
            {
                CustomName = "No BarCode Device",
                CustomDescription = ""
            };

            _rawinput = new RawInput(Handle, CaptureOnlyInForeground);
            _rawinput.BarCodeScannerEvent += OnBarcodeScanned;
            _rawinput.USBDeviceEnabled += Rawinput_USBDeviceEnabled;

            USBDeviceBarCodeInfoChangeTimer = new System.Windows.Forms.Timer
            {
                Interval = 3000
            };
            USBDeviceBarCodeInfoChangeTimer.Tick += USBDeviceBarCodeInfoChangeTimer_Tick;
        }

        void USBDeviceBarCodeInfoChangeTimer_Tick(object sender, EventArgs e)
        {
            USBDeviceBarCodeInfoChangeTimer.Stop();
            toolStripTextBox_BarCodeInfo.Text = USBDevice.CustomName + " device.";
        }

        void Rawinput_USBDeviceEnabled(object sender, RawInputEventArg e)
        {
            USBDevice = e.KeyPressEvent;
            toolStripTextBox_BarCodeInfo.Text = USBDevice.CustomName + ", " + USBDevice.CustomDescription;
        }

        void OnBarcodeScanned(object sender, RawInputEventArg e)
        {
            if (e == null)
                return;

            toolStripTextBox_BarCodeInfo.Text = e.BarcodeData + " (" + e.BarcodeData.Length + ") " + e.ASCIIControlChar;
            USBDeviceBarCodeInfoChangeTimer.Start();

            #region"EmployeeID Scanned"

            if (e.BarcodeData.Length == 6)
            {
                LogInProcessAsync(e.BarcodeData);
            }

            #endregion"EmployeeID Scanned"

            #region"Command_Process"

            if (e.BarcodeData.Contains("Command"))
            {
                if (e.BarcodeData.Contains("CompReelChange"))
                {
                    if (_SMT_Reel_Record == null)
                        InitSMTReelRecord("Initialized from BarCode reader...");

                    if (!_SMT_Reel_Record.IsActivated)
                        _SMT_Reel_Record.Activate();
                }
            }

            #endregion"Command_Process"

            #region"TestBarCodeReader"

            if (TestBarCodeReader)
            {
                TestBarCodeReader = false;
                Text = "BarCode Scanner test executed successfully.";
                string message = "You scanned " + e.BarcodeData + " from device :\r\n";
                message += "\r\n";

                MessageBox.Show(message, "BarCode Scanner test executed.");

                return;
            }

            #endregion"TestBarCodeReader"

            On_ScannedData(e);
        }

        void Solutions_TempleClass_ScannedDataEvent(object sender, RawInputEventArg e)
        {
            var tessss = e.BarcodeData;
        }

        void ToolStripButton_BarCode_Device_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox_BarCodeInfo.Text.Length > 0)
            {
                USBDevice.BarCodeDataRead = toolStripTextBox_BarCodeInfo.Text;
                OnBarcodeScanned(sender, new RawInputEventArg(USBDevice));
            }
        }

        #endregion"USB-BarCode initialization & BarcodeScanned"
       
        #region"InitializeThreadTimer Check status table. Notifications"

        System.Threading.Timer timerCheckStatusTable;
        string messageLocation = "";
        DateTime LastAccessTime;

        /// <summary>
        /// List of notifications pendient to send.
        /// </summary>
        ConcurrentDictionary<int, Notification> NotificationsToSends = new ConcurrentDictionary<int, Notification>();
        ConcurrentDictionary<DateTime, Notification> myConDict = new ConcurrentDictionary<DateTime, Notification>();

        /// <summary>
        /// CheckStatusTable procedure will check the status table, this table inform about new row,
        /// data changes, message and others.
        /// </summary>
        void InitializeThreadTimerCheckStatusTable()
        {
            DeleteOldNotifications();

            // Initialize ThreadTimerEmergencyStatus to infinite.
            InitializeThreadTimerEmergencyStatus();

            //DoSomething = procedure to callback, null = object pass to, First interval = Infinite ms,
            //subsequent intervals = Infinite ms
            if (timerCheckStatusTable == null)
                timerCheckStatusTable = new System.Threading.Timer(CheckStatusTable, null, Timeout.Infinite, Timeout.Infinite);

            if (Settings.Default.NotifycationsEnableSendReceive)
            {
                InitializeNotifyIconStatusTable();
                StartThreadTimerCheckStatusTable();
                statusProcessTime = Stopwatch.StartNew();
            }
            else
            {
                StopThreadTimerCheckStatusTable();
                notifyIconStatusTable.Visible = false;
                notifyIconStatusTable.BalloonTipShown -= new EventHandler(NotifyIconStatusTableBalloonTipShown);
                notifyIconStatusTable.BalloonTipClosed -= new EventHandler(NotifyIconStatusTableBalloonTipClosed);
                notifyIconStatusTable.BalloonTipClicked -= new EventHandler(NotifyIconStatusTableBalloonTipClicked);
            }
        }

        /// <summary>
        /// OldNotificationsSpanTime, time transpired to get old notifications deleted.
        /// unit in minute.
        /// </summary>
        static int OldNotificationsSpanTime = 45;

        /// <summary>
        /// Time to deletion of all notifications older.
        /// Is DateTime.Now.AddMinutes(-OldNotificationsSpanTime).
        /// </summary>
        static DateTime OldNotificationsTime;

        /// <summary>
        /// Interval between each reading of notifications, measured in milliseconds,
        /// 1000 = 1 sec, 5000 = 5 sec, 60000 = 1 min, 150000 = 2.5 min, 300000 = 5 min.
        /// </summary>
        static int IntervalReadingNotifications = 5000;

        /// <summary>
        /// Period in which the connection is established and the status table is updated,
        /// </summary>
        Stopwatch statusProcessTime;

        int _notificationLogCount = (OldNotificationsSpanTime * 60 * 1000) / IntervalReadingNotifications;

        /// <summary>
        /// Server DateTime, we ask in CheckStatusTable process.
        /// </summary>
        DateTime DataBaseTime = DateTime.Now;

        void CheckStatusTable(object obj)
        {
            return;

            statusProcessTime.Start();

            var messageLocation = "";
            try
            {
                messageLocation = "Process notification pendent.";
                if (!NotificationsToSends.IsEmpty)
                    ProcessNotificationPendingToBeSendAndClearTheList();

                ProcessSELECT_FROM_Table_Status_WHERE_DateCreated();

                statusProcessTime.Stop();

                StatusBarNotificationEvents("Process time in notification event is " + statusProcessTime.ElapsedMilliseconds + " milliseconds.");
                statusProcessTime.Reset();
            }
            catch (Exception errors)
            {
                StartThreadTimerEmergencyStatus();

                OnStatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Status at" + messageLocation + " " + errors.Message));
            }

            ProcessTableStatus();
        }

        void ProcessNotificationPendingToBeSendAndClearTheList()
        {
            #region"Process notification pending to be send and clear the List"

            using (SQLiteConnection statusConnectionString = new(Settings.Default.DataBaseConnectionStringSQLite))
            {
                if (_notificationsSendMyOwn)
                {
                    if (statusConnectionString.State == ConnectionState.Closed)
                        statusConnectionString.Open();

                    var query = "INSERT INTO `Table_Status` (`Text_Name`, `Title`, `Description`, `MessageIcon`, `" +
                                 "NotifycationEvents`, `String_Filter`, `DateCreated`, `Created_by`, `Properties`, " +
                                 "`Status`) VALUES (@Text_Name, @Title, @Description, @MessageIcon, @NotifycationEvents, " +
                                 "@String_Filter, Now(), @Created_by, @Properties, @Status)";

                    var cmd = new SQLiteCommand(query, statusConnectionString);

                    foreach (var notificationToSend in NotificationsToSends)
                    {
                        cmd.Parameters.Add("@Text_Name", DbType.String).Value = notificationToSend.Value.Text_Name;
                        cmd.Parameters.Add("@Title", DbType.String).Value = notificationToSend.Value.Title;
                        cmd.Parameters.Add("@Description", DbType.String).Value = notificationToSend.Value.Description;
                        cmd.Parameters.Add("@MessageIcon", DbType.Int32).Value = notificationToSend.Value.MessageIcon;
                        cmd.Parameters.Add("@NotifycationEvents", DbType.Int32).Value = notificationToSend.Value.NotifycationEvents;
                        cmd.Parameters.Add("@String_Filter", DbType.String).Value = notificationToSend.Value.String_Filter;
                        // cmd.Parameters.Add("@DateCreated", DbType.Date).Value = notificationToSend.Value.DateCreated; // Uncomment if needed
                        cmd.Parameters.Add("@Created_by", DbType.String).Value = notificationToSend.Value.Created_by;
                        cmd.Parameters.Add("@Properties", DbType.String).Value = notificationToSend.Value.Properties;
                        cmd.Parameters.Add("@Status", DbType.String).Value = notificationToSend.Value.Status;

                        cmd.ExecuteNonQuery();
                    }
                }

                NotificationsToSends.Clear();
            }

            #endregion"Process notification pending to be send and clear the List"
        }

        void ProcessSELECT_FROM_Table_Status_WHERE_DateCreated()
        {
            using (SQLiteConnection statusConnectionString = new(Settings.Default.DataBaseConnectionStringSQLite))
            {
                //"SELECT * FROM Table_Status WHERE DateCreated >= #" + DataBaseTime.AddMinutes(-5) + "#";
                #region"SELECT * FROM Table_Status WHERE DateCreated >= DataBaseTime.AddMinutes(-5)"

                if (statusConnectionString.State == ConnectionState.Closed)
                    statusConnectionString.Open();

                using (SQLiteCommand command = statusConnectionString.CreateCommand())
                {
                    command.CommandText = "SELECT MAX(DateCreated) FROM Table_Status";
                    object LastRowTime = command.ExecuteScalar();
                    if (LastRowTime.GetType() == typeof(DateTime))
                        DataBaseTime = (DateTime)LastRowTime;
                }

                messageLocation = "Command read.";
                var querySelect = "SELECT * FROM Table_Status WHERE \"DateCreated\" >= '" + DataBaseTime.AddMinutes(-5) + "'";
                using (var cmdSelect = new SQLiteCommand(querySelect, statusConnectionString))
                {
                    using (var reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var rowTime = reader.GetDateTime(6);//DateCreated index 6
                            var values = new object[10];
                            reader.GetValues(values);
                            myConDict.TryAdd(rowTime, new Notification(values));
                        }
                    }
                }

                #endregion"SELECT * FROM Table_Status WHERE DateCreated >= DateTime.Now.AddMinutes(-5)"

                messageLocation = "StatusConnection close.";
                statusConnectionString.Close();
            }
        }

        /// <summary>
        /// Deleted old notifications from table_Status.
        /// </summary>
        void DeleteOldNotifications()
        {
            #region"DELETE FROM Table_Status old notifications"
            try
            {
                OldNotificationsTime = DateTime.Now.AddMinutes(-OldNotificationsSpanTime);

                DataBaseSqliteConnection ??= new SqliteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                if (DataBaseSqliteConnection == null)
                {
                    MessageBox.Show(new Form() { TopMost = true }, "DeleteOldNotifications() process fail, \r\n" +
                                                                    "DataBaseConnectionStringSQLite is null, \r\n" +
                                                                    "This feature will be cancelled.",
                                                                    "DeleteOldNotifications().",
                                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (DataBaseSqliteConnection.State == ConnectionState.Closed)
                    DataBaseSqliteConnection.Open();

                SqliteCommand cmd = (SqliteCommand)SqliteFactory.Instance.CreateCommand();
                cmd.CommandText = "DELETE FROM Table_Status WHERE DateCreated <= '" + OldNotificationsTime + "'";
                cmd.Connection = DataBaseSqliteConnection;

                var numberDeleted = cmd.ExecuteNonQuery();

                StatusBarHelp("Deleted " + numberDeleted + " rows from Table_Status.");

                DataBaseSqliteConnection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, "DeleteOldNotifications() process fail, \r\n" +
                                                                error.Message + "\r\n" + "This feature will be cancelled.",
                                                                "DeleteOldNotifications().",
                                                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                Settings.Default.NotifycationsEnableSendReceive = false;
                Settings.Default.Save();
            }
            #endregion"DELETE FROM Table_Status old notifications"
        }

        void StartThreadTimerCheckStatusTable()
        {
            timerCheckStatusTable.Change(20000, IntervalReadingNotifications); //enable
        }

        void StopThreadTimerCheckStatusTable()
        {
            timerCheckStatusTable?.Change(Timeout.Infinite, Timeout.Infinite); //disable
        }

        bool _notifyIconStatusTableActive;
        void InitializeNotifyIconStatusTable()
        {
            notifyIconStatusTable.Visible = true;
            notifyIconStatusTable.BalloonTipShown += new EventHandler(NotifyIconStatusTableBalloonTipShown);
            notifyIconStatusTable.BalloonTipClosed += new EventHandler(NotifyIconStatusTableBalloonTipClosed);
            notifyIconStatusTable.BalloonTipClicked += new EventHandler(NotifyIconStatusTableBalloonTipClicked);
        }

        void NotifyIconStatusTableBalloonTipClicked(object sender, EventArgs e)
        {
            _notifyIconStatusTableActive = false;
        }

        void NotifyIconStatusTableBalloonTipClosed(object sender, EventArgs e)
        {
            _notifyIconStatusTableActive = false;
        }

        void NotifyIconStatusTableBalloonTipShown(object sender, EventArgs e)
        {
            _notifyIconStatusTableActive = true;
        }

        void NotifyIconStatusTableMethod()
        {
            if (!_notifyIconStatusTableActive)
                notifyIconStatusTable.ShowBalloonTip(100, "Test Warning Message.",
                                        "Will show important information about database status.\r\n" +
                                        "It has be moved to the tray.\r\n" +
                                        "Right click the Icon to exit.",
                                        ToolTipIcon.Info);
        }

        void NotifyIconStatusTableMethod(string title, string text, ToolTipIcon icon)
        {
            // if (!notifyIconStatusTableActive)
            //     notifyIconStatusTable.ShowBalloonTip(1, title, text, icon);

            notifyIconStatusTable.ShowBalloonTip(100, title, text, icon);
        }

        /// <summary>
        /// List of notifications has been processed.
        /// </summary>
        private readonly List<DateTime> notificationDone = new List<DateTime>();
        void ProcessTableStatus()
        {
            messageLocation = "Init Process table status";

            try
            {
                messageLocation = "Using statement";
                foreach (KeyValuePair<DateTime, Notification> notification in myConDict)
                {
                    messageLocation = "NotificationsDone.Contains";
                    if (notificationDone.Contains(notification.Key))
                        continue;

                    if (!_notificationsShowMyOwn)
                        if (notification.Value.DepartmentName.Contains(Settings.Default.DepartmentName))
                            continue;

                    messageLocation = "notifycationsDone.Add";
                    notificationDone.Add(notification.Key);

                    messageLocation = "switch (Utilities.NotifycationEvents)";
                    switch (notification.Value.NotifycationEvents)
                    {
                        case Utilities.NotificationEvents.Warning:
                            {
                                messageLocation = "NotifycationEvents.Warning";
                                if (_notificationsShowWarnings)
                                    NotifyIconStatusTableMethod(notification.Value.Title,
                                                                notification.Value.Description + Environment.NewLine +
                                                                notification.Value.DepartmentName + " " +
                                                                notification.Value.Created_by,
                                                                notification.Value.MessageIcon);
                                break;
                            }
                        case Utilities.NotificationEvents.RowInformationChange:
                            {
                                messageLocation = "NotifycationEvents.RowInformationChange";
                                if (_notificationsShowWarnings)
                                    NotifyIconStatusTableMethod(notification.Value.Title,
                                                                notification.Value.Description + Environment.NewLine +
                                                                notification.Value.DepartmentName + " " +
                                                                notification.Value.Created_by,
                                                                notification.Value.MessageIcon);
                                break;
                            }
                        case Utilities.NotificationEvents.DataBaseUpDated:
                            {
                                messageLocation = "NotifycationEvents.DataBaseUpDated";
                                if (_notificationsShowDataBaseUpDate)
                                    NotifyIconStatusTableMethod(notification.Value.Title,
                                                                notification.Value.Description + Environment.NewLine +
                                                                notification.Value.DepartmentName + " " +
                                                                notification.Value.Created_by,
                                                                notification.Value.MessageIcon);

                                if (!Settings.Default.DepartmentName.Contains(notification.Value.DepartmentName))
                                {
                                    //if (BackgroundWorkerFillByLastAccessTime.IsBusy)
                                    //    return;

                                    LastAccessTime = notification.Value.DateCreated;
                                   // BackgroundWorkerFillByLastAccessTime.RunWorkerAsync();
                                }

                                break;
                            }
                        case Utilities.NotificationEvents.Email:
                            {
                                messageLocation = "NotifycationEvents.Email";
                                if (_notificationsShowEmails)
                                    NotifyIconStatusTableMethod(notification.Value.Title,
                                                                notification.Value.Description + Environment.NewLine +
                                                                notification.Value.DepartmentName + " " +
                                                                notification.Value.Created_by,
                                                                notification.Value.MessageIcon);

                                break;
                            }
                        default:
                            {
                                messageLocation = "default";
                                break;
                            }
                    }
                }
                myConDict.Clear();

                messageLocation = "No error found.";
            }
            catch (Exception error)
            {
                StartThreadTimerEmergencyStatus();

                MessageBox.Show(new Form() { TopMost = true }, "ProcessTableStatus has found an error " + error.Message + " at " + messageLocation,
                                                "ProcessTableStatus method error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SendNotificationWarning(string title, string text, ToolTipIcon icon)
        {
            try
            {
                #region"Start new project row"
                /*
                // We ask per the lastID just before used.
                if (Production_InventoryDataSet.Table_Status.Rows.Count > 0)
                    LastID = (int)Production_InventoryDataSet.Table_Status.Compute("MAX(ID)", "ID is Not null");
                else
                    LastID = 0;

                // Creo new DataRowView front la table.
                var newProject = (DataRowView)_bindingSource_Status.AddNew();

                var ID = LastID;
                newProject["Index"] = LastID; ;
                newProject[nameof(ID)] = ID;
                newProject["Parent_ID"] = 0;

                newProject["Text_Name"] = "Test para Status.";
                newProject[nameof(Node_PDF)] = "";
                newProject["Node_Picture"] = "";
                newProject["Description_Short"] = title;
                newProject["Description_Expand"] = text;
                newProject["Image"] = "";
                newProject["String_Filter"] = "Warning";
                newProject["ItemCount"] = 0;
                newProject["DateCreated"] = DataBaseTime;
                newProject["Created_by"] = CurrentEmployeeLogIn.Name;
                newProject[nameof(Properties)] = "";
                newProject["Message_String"] = "";
                newProject["Status"] = "Open";

                newProject.EndEdit();

                _bindingSource_Status.EndEdit();
                */
                #endregion"Start new project row"
            }
            catch (Exception error)
            {
                MessageBox.Show(@"An error has been found, " + error.Message, @"New Status row error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        System.Threading.Timer _timerEmergencyStatus;
        void InitializeThreadTimerEmergencyStatus()
        {
            //DoSomething = procedure to callback, null = object pass to, First interval = Infinite ms, subsequent intervals = Infinite ms
            _timerEmergencyStatus = new System.Threading.Timer(new TimerCallback(EmergencyCheckStatus), null, Timeout.Infinite, Timeout.Infinite);
        }
        void StartThreadTimerEmergencyStatus()
        {
            StopThreadTimerCheckStatusTable();

            _timerEmergencyStatus.Change(5000, Timeout.Infinite); //enable

            OnStatusBarMessage(new object(), new StatusBarMessage_EventArgs("Process notifications has been stoped."));
        }
        void EmergencyCheckStatus(object obj)
        {
            StartThreadTimerCheckStatusTable();
            OnStatusBarMessage(new object(), new StatusBarMessage_EventArgs("Process notification restarted."));
        }

        #endregion"InitializeThreadTimer Check status table. Notifications"

        #region"InitializeThreadTimer Process Timer Save Request"

        static int DefaultSaveInterval = 1000 * 60 * 5;
        System.Threading.Timer timerSaveEveryInterval;

        void InitializeThreadTimerProcessSaveRequest()
        {
            //DoSomething = procedure to callback, null = object pass to, First interval = Infinite ms, subsequent intervals = Infinite ms
            if (timerSaveEveryInterval == null)
                timerSaveEveryInterval = new System.Threading.Timer(ProcessSaveIntervals, null, Timeout.Infinite, Timeout.Infinite);

            if (Settings.Default.SaveTheInformationByTime)
            {
                StartThreadTimerSaveEveryInterval();
            }
            else
            {
                StopThreadTimerSaveEveryInterval();
           //     OnStatusBarMessage(new object(), new StatusBarMessage_EventArgs("Stopped process Saved by timer..."));
            }
        }

        void ProcessSaveIntervals(object obj)
        {
            try
            {
                if (NeedSaveData)
                {
                    //NeedSaveDataProject hold the project name.
                    NeedSaveData = false;
             //       StockRoom_ProcessSaveRequest(new object(), new Save_Requested_EventArgs(Utilities.NotificationEvents.DataBaseUpDated));
                }
            }
            catch (Exception errors)
            {
                OnStatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Status at" + errors.Message, Resources.ErrorIcon));
            }
        }

        void StartThreadTimerSaveEveryInterval()
        {
            timerSaveEveryInterval.Change(20000, DefaultSaveInterval); //enable
        }

        void StopThreadTimerSaveEveryInterval()
        {
            timerSaveEveryInterval.Change(Timeout.Infinite, Timeout.Infinite); //disable
        }

        #endregion"InitializeThreadTimer Process Timer Save Request"

        #region"Log file, reading and writing information."

        /// <summary>
        /// Reference to LogFile class, initializes, read and write into
        /// log file.
        /// </summary>
        LogFileProcess _processLogFile;

        void InitializedLogFile()
        {
            try
            {
                var logFileNme = _employeesService.CurrentDepartmentLogIn.DepartmentName + " " + DateTime.Now.ToString("dddd, dd-MM-yy") + ".html";
                var deptNameMonth = _employeesService.CurrentDepartmentLogIn.DepartmentName + "\\" + DateTime.Now.ToString("MMMM");
                var logFilePath_Name = Path.Combine(Settings.Default.DataBaseAddress + "\\LogFile\\" + deptNameMonth, logFileNme);
                var templeFilePath_Name = Settings.Default.DataBaseAddress + "\\Resources\\HTML pages\\LogFileTemple.html";

                _processLogFile = new LogFileProcess(logFilePath_Name, templeFilePath_Name, Utilities.HTMLFileTemple.Application);
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(@"Was impossible to initialize LogFile process." + error.Message,
                                    @"Wrong LogInformation address.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void LogFileMessage(object sender, Custom_Events_Args.LogFileMessageEventArgs e)
        {
            Write_LogFile(sender, e);
        }

        public void Write_LogFile(object sender, Custom_Events_Args.LogFileMessageEventArgs e)
        {
            if (_processLogFile == null)
                return;

            _processLogFile.Write_LogFile(e);
        }

        public string Read_LogFile()
        {
            return _processLogFile.LogFileHTML.ToString();
        }

        #endregion"Log file, reading and writing information."
        
        #region"Instantiate FileSystemWatcher class, set handlers, start monitoring, and display the action message."

        List<Controls.FileSystemWatcherAgent.FileSystemWatcherAgent> FileSystemWatcherAgentList =
                                                    new List<Controls.FileSystemWatcherAgent.FileSystemWatcherAgent>();

        void InitializeFileSystemWatcher(ITableEmployeeService departLogin)
        {
            FileSystemWatcherAgentList.Clear();

            foreach (ScanDocumentsAddressItem documentAddressItem in departLogin.CurrentDepartmentLogIn.DepartmentScanDocumentsAddressItems)
            {
                var scanPath = documentAddressItem.ScanDocumentsAddressValueDirectory;

                if (!Directory.Exists(scanPath))
                    continue;

                var watchAgent = new StockRoom11net.Controls.FileSystemWatcherAgent.FileSystemWatcherAgent(scanPath);

                watchAgent.FileCreated += WatchAgent_FileCreated;
                watchAgent.FileDeleted += WatchAgent_FileDeleted;
                watchAgent.FileRenamed += WatchAgent_FileRenamed;
                watchAgent.FileHasChanged += WatchAgent_FileHasChanged;
                watchAgent.DirectoryRenamed += WatchAgent_DirectoryRenamed;

                FileSystemWatcherAgentList.Add(watchAgent);
            }
        }

        private void WatchAgent_FileCreated(object sender, FileSystemEventArgs e)
        {
            InvokeOnUiThreadIfRequired(this, () => Text = "File has been created -> " + e.FullPath);
        }

        private void WatchAgent_DirectoryRenamed(object sender, RenamedEventArgs e)
        {
            InvokeOnUiThreadIfRequired(this, () => Text = "Directory has been renamed -> " + e.FullPath);
        }

        private void WatchAgent_FileDeleted(object sender, FileSystemEventArgs e)
        {
            InvokeOnUiThreadIfRequired(this, () => Text = "File has been deleted -> " + e.FullPath);
        }

        private void WatchAgent_FileRenamed(object sender, RenamedEventArgs e)
        {
            InvokeOnUiThreadIfRequired(this, () => Text = "File has been renamed -> " + e.FullPath);
        }

        void WatchAgent_FileHasChanged(object sender, FileSystemEventArgs e)
        {
            InvokeOnUiThreadIfRequired(this, () => Text = "File content has changed -> " + e.FullPath);
        }


        #endregion"Instantiate FileSystemWatcher class, set handlers, start monitoring, and display the action message."

        #region"Peer-to-peer (P2P) pool tasks. Tasks that are to be executed by the peer."

        #region"Task FileFolderScann"

        /// <summary>
        /// Tools/DataBase Tools/Projects Viewer/DataBase/ClearAllData.
        /// Menu bar, utility to clear all data inside the Projects database file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ToolStripMenuItem_ClearAllDataProjectsViewer_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// LastScan, a List(FileDirectoryModel) filled by the task FileFolderScan().
        /// </summary>
        static List<FileDirectoryModel> LastScan = new List<FileDirectoryModel>();

        /// <summary>
        /// CurrentItems, a List<FileDirectoryModel> filled by the DataTable bines logic.
        /// </summary>
        static List<FileDirectoryModel> CurrentProjects = new List<FileDirectoryModel>();

        static ObservableCollection<string> documentWatcher = new ObservableCollection<string>();

        /// <summary>
        /// Tools/DataBase Tools/Projects Viewer/Scan Projects.
        /// Menu bar, utility to scan the contents of the Project folder.
        /// </summary>
        void InitializeFileFolderScann()
        {
            LastScan.Clear();
            string pathRootFolder = Path.Combine(Settings.Default.DataBaseAddress, "Projects");

            if (string.IsNullOrEmpty(pathRootFolder))
                return;

            FileFolderManagenment(pathRootFolder);
        }

        /// <summary>
        /// Task.Factory of DeleteAllRowsInTableProjectsTreeView(), FileFolderScan(pathRootFolder))
        /// and ProcessFileFolderFounded().
        /// </summary>
        /// <param name="pathRootFolder"></param>
        void FileFolderManagenment(string pathRootFolder)
        {            
            var taskB = Task.Run(() => FileFolderScan(pathRootFolder))
                  .ContinueWith((antecedents) => Task.Run(() => ProcessFileFolderFounded()));
        }

        /// <summary>
        /// Will scan pathRootFolder and fill dir (ObservableCollection<FileDirectoryModel>)
        /// this task access to the network, server, keep small and faster.
        /// </summary>
        /// <param name="pathRootFolder"></param>
        void FileFolderScan(string pathRootFolder)
        {
            using (FileSystemEnumerator fse = new FileSystemEnumerator(
                                                                        pathRootFolder,
                                                                        "Thumbs.db",
                                                                        false,
                                                                        true,
                                                                        100000))
            {
                LastScan = fse.FoundFilesToTreeView();
            }
        }

        /// <summary>
        /// When the FileFolderScan finished, this process will evaluate if the FileSystem
        /// has change since last scan.
        /// </summary>
        void ProcessFileFolderFounded()
        {
            int countThumbs = 0;
            //_bindingSource_ProjectsTreeView.SuspendBinding();

            /*
                        Parallel.ForEach(LastScan, itemEFtableTreeView =>
                        {
                            // Creo new DataRowView front la tabla.
                            DataRowView projectRow = (DataRowView)_bindingSource_ProjectsTreeView.AddNew();

                            projectRow["Index"] = itemEFtableTreeView.ID;
                            projectRow["ID"] = itemEFtableTreeView.ID;

                            if (itemEFtableTreeView.Parent_ID == null)
                                projectRow["Parent_ID"] = DBNull.Value;
                            else
                                projectRow["Parent_ID"] = itemEFtableTreeView.Parent_ID;

                            projectRow["ProjectName"] = itemEFtableTreeView.ProjectName;
                            projectRow["Text_Name"] = itemEFtableTreeView.Text_Name;
                            projectRow["ItemOpen"] = itemEFtableTreeView.ExistThumbs;

                            projectRow["Image"] = itemEFtableTreeView.Image;
                            projectRow["Description_Short"] = itemEFtableTreeView.Description_Short;
                            projectRow["Description_Expand"] = itemEFtableTreeView.Description_Expand;

                            projectRow["ItemCount"] = 0;

                            projectRow.EndEdit();

                        });


            foreach (FileDirectoryModel itemEFtableTreeView in LastScan)
            {
                // Creo new DataRowView front la tabla.
                DataRowView projectRow = (DataRowView)_bindingSource_ProjectsTreeView.AddNew();

                projectRow["Index"] = itemEFtableTreeView.ID;
                projectRow["ID"] = itemEFtableTreeView.ID;

                if (itemEFtableTreeView.Parent_ID == null)
                    projectRow["Parent_ID"] = DBNull.Value;
                else
                    projectRow["Parent_ID"] = itemEFtableTreeView.Parent_ID;

                projectRow["ProjectName"] = itemEFtableTreeView.ProjectName;
                projectRow["Text_Name"] = itemEFtableTreeView.Text_Name;
                projectRow["ItemOpen"] = itemEFtableTreeView.ExistThumbs;

                projectRow["Image"] = itemEFtableTreeView.Image;
                projectRow["Description_Short"] = itemEFtableTreeView.Description_Short;
                projectRow["Description_Expand"] = itemEFtableTreeView.Description_Expand;

                projectRow["ItemCount"] = 0;

                projectRow.EndEdit();

                if (itemEFtableTreeView.ExistThumbs)
                    countThumbs++;

                StatusBarHelp("Rows " + itemEFtableTreeView.ID + " " + countThumbs);
            }

            _bindingSource_ProjectsTreeView.EndEdit();
            _bindingSource_ProjectsTreeView.ResumeBinding();
            */
           // _projectViewer_Save_Requested(new object(), new EventArgs());
        }

        #endregion"Task FileFolderScann"

        #region"Task Thumb.DB refresh"

        /// <summary>
        /// LastScan, a List(FileDirectoryModel) filled by the task FileFolderScan().
        /// </summary>
        static List<FileDirectoryModel> ScanedThumbDBFiles = new List<FileDirectoryModel>();

        /// <summary>
        /// If the DeleteThumbDBFile(string pathfolder) process fail to delete the file,
        /// the full path is stored in this list to reprocess later.
        /// </summary>
        List<string> ThumbsFileToDelete = new List<string>();

        void ThumbNailsManagenment()
        {
            var taskA = Task.Run(() => TaskThumbNailsRefresh())
                  .ContinueWith((antecedents) => Task.Run(() => ProcessThumbDBList()));
        }

        void TaskThumbNailsRefresh()
        {
            ScanedThumbDBFiles.Clear();
            string pathRootFolder = Path.Combine(Settings.Default.DataBaseAddress, "Projects");

            if (string.IsNullOrEmpty(pathRootFolder))
                return;

            ScanThumbDBFiles(pathRootFolder);
        }

        void ProcessThumbDBList()
        {
            foreach (FileDirectoryModel item in ScanedThumbDBFiles)
            {
                if (item.Name.Contains("Projects"))
                    continue;

                string fullPath = Path.Combine(Settings.Default.DataBaseAddress + "Projects", item.ProjectName);

                if (LoadTestThumbFileSuccessfully(fullPath))
                    continue;

                StubbedFile(fullPath);

                //   DeleteThumbDBFile(fullPath);

                ShellNotificationRefresh(fullPath);
            }
        }

        /// <summary>
        /// Will scan pathRootFolder and fill ScanedThumbDBFiles (ObservableCollection<FileDirectoryModel>)
        /// this task access to the network, server, keep small and faster.
        /// </summary>
        /// <param name="pathRootFolder"></param>
        void ScanThumbDBFiles(string pathRootFolder)
        {
            using (FileSystemEnumerator fse = new FileSystemEnumerator(
                                                                        pathRootFolder,
                                                                        "Thumbs.db",
                                                                        true,
                                                                        true,
                                                                        200000))
            {
                ScanedThumbDBFiles = fse.FoundThumbDBFilesToTreeView();
            }
        }

        /// <summary>
        /// LoadThumbFile will load the file and test whether each reference is valid,
        /// if it fails delete the thumb.db file.
        /// </summary>
        /// <param name="strThumbFile"></param>
        bool LoadTestThumbFileSuccessfully(string strThumbFile)
        {
            string pathFolder = strThumbFile.Replace("Thumbs.db", "");
            ThumbDB db = new ThumbDB(strThumbFile);

            if (db != null)
            {
                string[] strFiles = db.GetThumbfiles();

                // create the thumbnails for the selected files
                foreach (string strFileName in strFiles)
                {
                    if (strFileName.Equals(string.Empty))
                        continue;

                    // AutoGenerate thumbnails to show folders contend.
                    if (strFileName.Contains("{A42CD7B6-E9B9-4D02-B7A6-288B71AD28BA}"))
                    {
                        if (strFiles.Length == 1)
                            return true;

                        continue;
                    }

                    if (!File.Exists(Path.Combine(pathFolder, strFileName)))
                        return false;
                }
                return true;
            }
            return false;
        }

        void DeleteThumbDBFile(string pathfolder)
        {
            try
            {
                File.Delete(pathfolder);
            }
            catch (System.IO.IOException ex)
            {
                if (Utilities.IsFileLocked(ex))
                {
                    ThumbsFileToDelete.Add(pathfolder);
                }
            }
        }

        void ShellNotificationRefresh(string pathfolder)
        {
            try
            {
                ShellNotification.RefreshThumbnail(pathfolder);
            }
            catch (Exception error)
            {
                string Error = error.Message;
            }

        }

        void StubbedFile(string pathfolder)
        {
            try
            {
                ThumbsNail_Ejp.StubbedFile(pathfolder);
            }
            catch (Exception error)
            {
                string Error = error.Message;
            }
        }

        #endregion"Task Thumb.DB refresh"


        #endregion"Peer-to-peer (P2P) pool tasks. Tasks that are to be executed by the peer."

        #region"WepApiProcess"

        void InitializeWebApiProcess()
        {
            string utilityNgrokPat = Path.Combine(Settings.Default.DataBaseAddress, Settings.Default.NgrokUtilityPath);

            try
            {
                if (File.Exists(utilityNgrokPat))
                {
                    IsInitializeWebApiProcessDone = true;
                    StartProcessHidden(utilityNgrokPat, WaitForExit: false, Arguments: "http -host-header=rewrite -subdomain=smsprod 61524");
                    FormClosed += (o, e) =>
                    {   //Leave off ".exe", "The process name is a friendly name"
                        foreach (var process in Process.GetProcessesByName("ngrok"))
                        {
                            process.Kill();
                        }
                    };
                    return;
                }
                else
                    using (var form1 = new Form { TopMost = true })
                    {
                        MessageBox.Show(form1, @"The utility file Ngrok.exe was not found. Check the application installations folder or settings.",
                                               @"Initialization of Web api process fault.",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"An error was generated when trying to initialize or eliminate the ngrok process. " +
                                            error.Message,
                                           @"Initialization of Web api process fault.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        static int StartProcessHidden(string FileName, bool WaitForExit, string Arguments = "")
        {
            using (Process myProc = new Process())
            {
                myProc.StartInfo.FileName = FileName;
                myProc.StartInfo.Arguments = Arguments;
                myProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                myProc.StartInfo.CreateNoWindow = true;
                myProc.StartInfo.UseShellExecute = false;
                myProc.Start();

                if (WaitForExit)
                {
                    myProc.WaitForExit(); //Wait for the process if the 'WaitForExit' was sent as true.
                    return myProc.ExitCode; //Return the exit code of the process to the method.
                }

                return 0;
            }
        }

        /// <summary>
        /// Stop or kill a process by name.
        /// Leave off ".exe". From MSDN: "The process name is a friendly name for the
        /// process, such as Outlook, that does not include the .exe extension or the path"
        /// </summary>
        /// <param name="processName"></param>
        static void StopProcessByName(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }

            Process.GetProcesses()
                         .Where(x => x.ProcessName.ToLower()
                                      .StartsWith(processName))
                         .ToList()
                         .ForEach(x => x.Kill());
        }

        #endregion"WepApiProcess"

        public static void InvokeOnUiThreadIfRequired(Control control, Action action)
        {
            //If you are planning on using a similar function in your own code then please be sure to
            //have a quick read over https://stackoverflow.com/questions/1874728/avoid-calling-invoke-when-the-control-is-disposed

            //No action
            if (control.Disposing || control.IsDisposed || !control.IsHandleCreated)
            {
                return;
            }

            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }


        bool _mouseInToolStripStatusLabel_Progress = false;
        void ToolStripStatusLabel_Progress_MouseEnter(object sender, EventArgs e)
        {
            _mouseInToolStripStatusLabel_Progress = true;
        }

        void ToolStripStatusLabel_Progress_MouseLeave(object sender, EventArgs e)
        {
            _mouseInToolStripStatusLabel_Progress = false;
        }
    }

}


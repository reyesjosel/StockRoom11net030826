using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.Devices;
using MyStuff11net;
using MyStuff11net.DependencyInjection;
using MyStuff11net.DocumentationBehavior;
using MyStuff11net.Properties;
using RawInput_dll;
using StockRoom11net.Production_InventoryDataSetTableAdapters;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Diagnostics;
using System.Reflection;
using System.Speech.Synthesis;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFormsUI.Docking;

using ActiveDataSheet_EventArgs = MyStuff11net.Custom_Events_Args.ActiveDataSheet_EventArgs;
using CellDoubleClick_EventArgs = MyStuff11net.Custom_Events_Args.CellDoubleClick_EventArgs;
using CurrentDeptUserBroadcast_EventArgs = MyStuff11net.Custom_Events_Args.CurrentDeptUserBroadcast_EventArgs;
using Custom_Events_Args = MyStuff11net.Custom_Events_Args;
using Need_SaveData_EventArgs = MyStuff11net.Custom_Events_Args.Need_SaveData_EventArgs;
using Refresh_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Refresh_Requested_EventArgs;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;
using Tags = MyStuff11net.HTML_Tags;
using TreeViewUpdateEventArgs = MyStuff11net.Custom_Events_Args.TreeViewUpdateEventArgs;
using TreeViewUpdateEventHandler = MyStuff11net.Custom_Events_Args.TreeViewUpdateEventHandler;

[assembly: System.Runtime.Versioning.SupportedOSPlatformAttribute("windows")]
namespace StockRoom11net
{
    public partial class Solutions_TempleClass : Form
    {
        private readonly IMyService _myService;

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
        /// <summary>
        /// Keep the records changed at the last save call.....
        /// </summary>
        DataTable? changedRecordsTable;

        int _lastID;
        /// <summary>
        /// Top value for ID field, option filter to select a group of row.
        /// table.Compute("MAX(ID)", "filter condition"), itself inc.
        /// </summary>
        int LastID
        {
            get
            {
                ++_lastID;
                return _lastID;
            }
            set
            {
                _lastID = value;

            }
        }

        Employee lastEmployeeLogIn;
        /// <summary>
        /// Keep a information about the last user name log in.
        /// </summary>
        Employee LastEmployeeLOgIN
        {
            get
            {
                return lastEmployeeLogIn;
            }
            set
            {
                if (value.Name.Contains("No User Log On"))
                    return;

                lastEmployeeLogIn = value;
            }
        }

        /// <summary>
        ///
        /// </summary>
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
        public StockRoom_Inventory _stockRoomForm;
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

        static BindingSource _bindingSource_Labels_SMT;
        static BindingSource _bindingSource_Marshall;
        static BindingSource _bindingSource_CodeTreeView;
        static BindingSource _bindingSource_Employees;
        static BindingSource _bindingSource_StockRoom;
        static BindingSource _bindingSourceStockRoomTreeView;
        static BindingSource _bindingSource_Projects;
        static BindingSource _bindingSource_EmployeesTreeView;
        static BindingSource _bindingSource_LocationsTreeView;
        static BindingSource _bindingSource_Locations;
        static BindingSource _bindingSource_ProjectsTreeView;
        static BindingSource _bindingSource_Status;
        static BindingSource _bindingSource_TimeLine;
        static BindingSource _bindingSource_TimeLine_TreeView;

        /// <summary>
        /// It's use in StockRoomRepository to filter data to ProductionsController.
        /// </summary>
        static BindingSource _bindingSource_Products;
        /// <summary>
        /// It's use in StockRoomRepository to filter data to ProductionsController.
        /// Select the filter active by user on mobile-phone.
        /// </summary>
        static BindingSource _bindingSource_SRTreeView;


        static Production_InventoryDataSet Production_InventoryDataSet;
                      
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

        /// <summary>
        /// Initializes a new instance of the Solutions_TempleClass class with the specified service dependency and sets
        /// up data bindings, UI components, and event handlers required for the form's operation.
        /// </summary>
        /// <remarks>This constructor configures data sources, initializes UI elements, and attaches
        /// necessary event handlers for the form to function correctly. It also sets up error handling for unhandled
        /// thread exceptions. The form relies on the provided service for certain operations; ensure that the service
        /// is properly initialized before passing it to the constructor.</remarks>
        /// <param name="myService">The service instance used to provide application-specific functionality to the form. Cannot be null.</param>
        public Solutions_TempleClass(IMyService myService)
        {
            InitializeComponent();

            _myService = myService ?? throw new ArgumentNullException(nameof(myService), "MyService cannot be null.");

            AutoScaleMode = AutoScaleMode.Dpi;
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);

            try
            {
                SuspendLayout();

                #region"Initialize_SMT_InventoryDataSet"

                // SMT_InventoryDataSet
                Production_InventoryDataSet = new Production_InventoryDataSet();
                ((ISupportInitialize)(Production_InventoryDataSet)).BeginInit();
                Production_InventoryDataSet.DataSetName = nameof(Production_InventoryDataSet);
                Production_InventoryDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
                ((ISupportInitialize)(Production_InventoryDataSet)).EndInit();

                #endregion"Initialize_SMT_InventoryDataSet"

                #region"Initialize_bindingSource"

                // _bindingSource_Labels_SMT
                _bindingSource_Labels_SMT = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_Labels_SMT)).BeginInit();
                _bindingSource_Labels_SMT.DataMember = "Table_Labels_SMT";
                _bindingSource_Labels_SMT.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_Labels_SMT)).EndInit();

                // _bindingSource_tableMarshallTreeView
                _bindingSource_CodeTreeView = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_CodeTreeView)).BeginInit();
                _bindingSource_CodeTreeView.DataMember = "Table_Marshall_TreeView";
                _bindingSource_CodeTreeView.DataSource = Production_InventoryDataSet;
                // _bindingSource_tableMarshallTreeView.BindingComplete +=
                ((ISupportInitialize)(_bindingSource_CodeTreeView)).EndInit();

                // _bindingSourceStockRoomTreeView
                _bindingSourceStockRoomTreeView = new BindingSource(components);
                ((ISupportInitialize)(_bindingSourceStockRoomTreeView)).BeginInit();
                _bindingSourceStockRoomTreeView.DataMember = "Table_StockRoom_TreeView";
                _bindingSourceStockRoomTreeView.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSourceStockRoomTreeView)).EndInit();

                // _bindingSource_tableStockRoom
                _bindingSource_StockRoom = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_StockRoom)).BeginInit();
                _bindingSource_StockRoom.DataMember = "Table_StockRoom";
                _bindingSource_StockRoom.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_StockRoom)).EndInit();

                // _bindingSource_Products
                _bindingSource_Products = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_Products)).BeginInit();
                DataView dataViewProducts = new DataView(Production_InventoryDataSet.Tables["Table_StockRoom"], "", "[PartNumber] ASC", DataViewRowState.CurrentRows);
                _bindingSource_Products.DataSource = dataViewProducts;
                ((ISupportInitialize)(_bindingSource_Products)).EndInit();

                // _bindingSource_SRTreeView
                _bindingSource_SRTreeView = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_SRTreeView)).BeginInit();
                DataView dataViewSRTreeView = new DataView(Production_InventoryDataSet.Tables["Table_StockRoom_TreeView"], "", "[ID] ASC", DataViewRowState.CurrentRows);
                _bindingSource_SRTreeView.DataSource = dataViewSRTreeView;
                ((ISupportInitialize)(_bindingSource_SRTreeView)).EndInit();

                // _bindingSource_tableMarshall
                _bindingSource_Marshall = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_Marshall)).BeginInit();
                _bindingSource_Marshall.DataMember = "Table_Marshall";
                _bindingSource_Marshall.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_Marshall)).EndInit();

                // _bindingSource_tableProjects
                _bindingSource_Projects = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_Projects)).BeginInit();
                _bindingSource_Projects.DataMember = "Table_Projects";
                _bindingSource_Projects.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_Projects)).EndInit();

                // _bindingSource_tableProjectsTreeView
                _bindingSource_ProjectsTreeView = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_ProjectsTreeView)).BeginInit();
                _bindingSource_ProjectsTreeView.DataMember = "Table_Projects_TreeView";
                _bindingSource_ProjectsTreeView.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_ProjectsTreeView)).EndInit();

                // _bindingSource_Employees
                _bindingSource_Employees = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_Employees)).BeginInit();
                _bindingSource_Employees.DataMember = "Table_Employees";
                _bindingSource_Employees.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_Employees)).EndInit();

                // _bindingSource_EmployeesTreeView
                _bindingSource_EmployeesTreeView = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_EmployeesTreeView)).BeginInit();
                _bindingSource_EmployeesTreeView.DataMember = "Table_Employees_TreeView";
                _bindingSource_EmployeesTreeView.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_EmployeesTreeView)).EndInit();

                // _bindingSource_Locations
                _bindingSource_Locations = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_Locations)).BeginInit();
                _bindingSource_Locations.DataMember = "Table_Locations";
                _bindingSource_Locations.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_Locations)).EndInit();

                // _bindingSource_LocationsTreeView
                _bindingSource_LocationsTreeView = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_LocationsTreeView)).BeginInit();
                _bindingSource_LocationsTreeView.DataMember = "Table_Location_TreeView";
                _bindingSource_LocationsTreeView.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_LocationsTreeView)).EndInit();

                // _bindingSource_Status
                _bindingSource_Status = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_Status)).BeginInit();
                _bindingSource_Status.DataMember = "Table_Status";
                _bindingSource_Status.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_Status)).EndInit();

                // _bindingSource_TimeLine
                _bindingSource_TimeLine = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_TimeLine)).BeginInit();
                _bindingSource_TimeLine.DataMember = "Table_TimeLine";
                _bindingSource_TimeLine.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_TimeLine)).EndInit();

                // _bindingSource_TimeLine_TreeView
                _bindingSource_TimeLine_TreeView = new BindingSource(components);
                ((ISupportInitialize)(_bindingSource_TimeLine_TreeView)).BeginInit();
                _bindingSource_TimeLine_TreeView.DataMember = "Table_TimeLine_TreeView";
                _bindingSource_TimeLine_TreeView.DataSource = Production_InventoryDataSet;
                ((ISupportInitialize)(_bindingSource_TimeLine_TreeView)).EndInit();

                #endregion"Initialize_bindingSource"
                               
                _currentEmployeesLogIn = new Employee();

                changedRecordsTable = new DataTable("ChangedRecordsTable");

                showRightToLeft.Checked = true;
                _mDeserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);

                _bindingSource_StockRoom.RaiseListChangedEvents = true;
               
                dockPanel.Dock = DockStyle.Fill;
                dockPanel.Theme = vS2005Theme;
                dockPanel.ShowDocumentIcon = true;

                InitializeDocumentationBehaviorTimer(1);

                Application.ThreadException += Application_ThreadException;

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

            //  RegisterDLLOriginal registrar = new RegisterDLLOriginal(
            //  Path.GetDirectoryName(Environment.CurrentDirectory) + "\\Release\\BarcodeSample.UI.WinForms.Interop.dll");
            //  registrar.RegisterComDLL();
            //  finalizer = new Finalizer(registrar);
        }
               
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            return;
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

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Starting the application at " + DateTime.Now),
                        Tags.StraigthLine
                    }));

                toolStripTextBox_Log_User.Visible = false;

                CurrentDeptUserBroadcast_Requested += Solutions_TempleClass_CurrentDeptUserBroadcast_Requested;
                ScannedDataEvent += Solutions_TempleClass_ScannedDataEvent;

                #region"Load all tables."

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Full ConnectionString string = " + Settings.Default.DataBaseConnectionStringSQLite),
                        Tags.NewLine("Starting load all tables at " + DateTime.Now),
                    }));

                BackgroundWorker_Load_Table_Stockroom();
                BackgroundWorker_Load_Table_StockroomTreeView();

                //BackgroundWorker_Load_Table_Marshall();
                //BackgroundWorker_Load_Table_Marshall_TreeView();

                BackgroundWorker_Load_Table_Employees();
                BackgroundWorker_Load_Table_EmployeesTreeView();

                BackgroundWorker_Load_Table_Labels_SMT();

                //BackgroundWorker_Load_Table_Components();
                //BackgroundWorker_Load_Table_Placements();

                //BackgroundWorker_Load_Table_Locations();
                //BackgroundWorker_Load_Table_LocationsTreeView();

                //BackgroundWorker_Load_Table_Projects_TreeView();

                BackgroundWorker_Load_Table_TimeLine();

                BackgroundWorker_Load_Table_TimeLineTreeView();

                #endregion"Load all tables if the binding source no is ready"

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
            if (MyCode.IsInDesignMode())
                return;

            InitializeProperties();

            InitSolutionsTemple(@"Solution Temple.");

            Initialize_MouseKeyEventProvider();

            InitializeThreadTimerCheckStatusTable();
            InitializeBackgroundWorkerFillByLastAccessTime();

            // To use StatusBarMessage event from MyCode.
            MyCode.StatusBarMessage += StatusBarMessage;
            MyCode.LogFileMessage += LogFileMessage;

            // To initialized statusBar item to the right. Alignment property.
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

                    if (m_bSaveLayout)
                        dockPanel.SaveAsXml(configFile);
                    else if (File.Exists(configFile))
                        File.Delete(configFile);
                }
            }
            catch (Exception error)
            {
                int ee = error.HResult;
                //  MessageBox.Show(new Form() { TopMost = true }, @"StockRoom_Solutions_FormClosing(), error is " + error.Message,
                //                   @"Solutions Temple has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (_currentEmployeesLogIn != null)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName ),
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
                var builder = new SqliteConnectionStringBuilder(
                    Settings.Default.DataBaseConnectionStringSQLite);

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
        MyCode.DocumentationBehavior _documentationBehavior = MyCode.DocumentationBehavior.SpecifiedDocument;

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

            _notificationsSendMyOwn = Settings.Default.NotificationsSendMyOwn;
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

            _documentationBehavior = (MyCode.DocumentationBehavior)Settings.Default.DocumentationBehavior;

            InitializeSpeechSynthesizerBase();
            InitializeThreadTimerCheckStatusTable();
            InitializeThreadTimerProcessSaveRequest();

            Init_USB_BarCode();
        }

        void CallSolutionsProperties()
        {
            using (_solutionPropertiesForm = new SolutionsProperties(CurrentDepartmentLogIn, ListDepartments))
            {
                if (_solutionPropertiesForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                    return;

                _solutionPropertiesForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

                _solutionPropertiesForm.TopMost = false;
                _solutionPropertiesForm.Text = "Select a Department to be assigned at this computer.";

                _solutionPropertiesForm.CurrentUserBroadcast_EventHandler(new object(), new CurrentDeptUserBroadcast_EventArgs(null, _currentEmployeesLogIn));
                _solutionPropertiesForm.ShowDialog();
                // The application will return here.
                _solutionPropertiesForm = null;
                SolutionPropertiesFormClosed(new object(), new FormClosedEventArgs(CloseReason.FormOwnerClosing));
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

        static bool CheckIfInstallationWasDone()
        {
            if (Settings.Default.InstallationFirstDate < DateTime.Now)
            {
                InstallationFirstDate = Settings.Default.InstallationFirstDate;
                InstallationDaysAfter = DateTime.Now.Subtract(Settings.Default.InstallationFirstDate);
                return true;
            }

            using (var solutionProperties = new SolutionsProperties("Installation Mode"))
            {
                solutionProperties.TopMost = true;
                solutionProperties.ShowDialog();

                InstallationDaysAfter = TimeSpan.Zero;
                InstallationFirstDate = DateTime.Now;

                return false;
            }
        }

        /// <summary>
        /// Is called when SolutionsProperties windows is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SolutionPropertiesFormClosed(object sender, FormClosedEventArgs e)
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
            if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.User)
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
            if (_currentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Administrator)
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
            if (_currentEmployeesLogIn == null)
                return;

            if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.Manager)
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

            InitEasyProgressBar_FixOnAvailables();
            BeginInvoke(new EventHandler(Start_easyProgressBar_FixOnAvailables));

        }

        void Reset_OnHoldByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitEasyProgressBar_OnHoldBy();
            BeginInvoke(new EventHandler(Start_easyProgressBar_Reset_OnHoldBy));
        }

        void ToolStripMenuItemExploreH7HFile_Click(object sender, EventArgs e)
        {
            if (_currentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Manager)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _h7h_ExplorerForm = new H7H_Explorer()
            {
                Text = @"H7H Explorer."
            };

            _h7h_ExplorerForm.StatusBarMessage += StatusBarMessage;

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
        /// For each item in stockroom table will scan the given path and
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
            if (!Production_InventoryDataSet.Table_StockRoom.Columns.Contains("PartNumber") ||
                !Production_InventoryDataSet.Table_StockRoom.Columns.Contains("Status"))
                return;

            _bindingSource_StockRoom.RemoveSort();
            _bindingSource_StockRoom.SuspendBinding();
            Production_InventoryDataSet.Table_StockRoom.BeginLoadData();

            var taskA = await Task.Run(() =>
            {
                var pdfFileScan = new PdfFileScan(_bindingSource_StockRoom, CurrentDepartmentLogIn);

                pdfFileScan.StatusReportEvent += PdfFileScan_StatusReportEvent;
                pdfFileScan.RowProcessDoneEvent += PdfFileScan_RowProcessDoneEvent;
                pdfFileScan.ScanProcessDoneEvent += PdfFileScan_ScanProcessDoneEvent;

                pdfFileScan.StarScanning();

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
                _bindingSource_StockRoom.ResumeBinding();
                toolStripMenuItem_ScanPdfFiles.Enabled = true;
                Production_InventoryDataSet.Table_StockRoom.EndLoadData();
                //Production_InventoryDataSet.Table_StockRoom.AcceptChanges();
            });
        }

        void PdfFileScan_RowProcessDoneEvent(string partNumber, List<Tuple<string, string>> listDocInf)
        {
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
            ClearHeaderInfStatusColumn(Production_InventoryDataSet.Table_StockRoom);
            StockRoomSaveRequest();
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
            if (CurrentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Manager)
                using (DocumentsAddressViewer documentsItemsViewer = new DocumentsAddressViewer(CurrentDepartmentLogIn, ListDepartments, false))
                {
                    documentsItemsViewer.ShowDialog();
                }

            if (CurrentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.Manager)
                using (DocumentsAddressViewer documentsItemsViewer = new DocumentsAddressViewer(CurrentDepartmentLogIn, ListDepartments, true))
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
            if (LastEmployeeLOgIN == null)
            {
                Text = "No user has been logged.";
                return;
            }

            Text = LastEmployeeLOgIN.Name + ", " + LastEmployeeLOgIN.Position + ".";
        }

        void ToolStripMenuItem_departmentName_Click(object? sender, EventArgs e)
        {
            Text = "This computer has been assigned to " + CurrentDepartmentLogIn.DeptName + " department.";
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
                toolStripButtonSpeechSynthesizer.Image = Properties.Resources.speaker_mute;
                StatusBarHelp("SpeechSynthesizer has been paused.");
            }
            else
                if (SpeechSynthesizerBase.State == SynthesizerState.Paused)
            {
                SpeechSynthesizerBase.Resume();
                toolStripButtonSpeechSynthesizer.Image = Properties.Resources.speaker;
                StatusBarHelp("SpeechSynthesizer has been activated.");
            }
        }

        #endregion"ToolStrip"

        #region"User Log On"

        /// <summary>
        /// When no user has been login, we load the parameters front the user
        /// index 0, who is any user with no rights.
        /// </summary>
        int noUserLogIn = 0;
        /// <summary>
        /// Maintains a record of login attempts, if a problem winth the database occurrs,
        /// and the system manager tries for 3 times,we give access to certain resources.
        /// </summary>
        int intentLogin = 0;
        string _password = "";
        string _hidepassword = "";

        void InitializeUser()
        {
            int employeeIndex = _bindingSource_Employees.Find("Last6Digit", noUserLogIn);
            if (employeeIndex != -1)
                CurrentEmployeesLogIn = new Employee((DataRowView)_bindingSource_Employees[employeeIndex]);
            else
                CurrentEmployeesLogIn = new Employee();

            Invoke((System.Windows.Forms.MethodInvoker)delegate
            {
                On_CurrentDeptUserBroadcast_Requested(new CurrentDeptUserBroadcast_EventArgs(CurrentDepartmentLogIn, CurrentEmployeesLogIn));
            });

            StatusBarHelp("User LogIn done at " + CurrentEmployeesLogIn.Name + ".");
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
            toolStripTextBox_Log_User.Tag = "Log On process.";

            toolStripTextBox_Log_User.Text = "";

            LogInProcess(_password);
        }

        void ToolStripButton_Log_out_Click(object sender, EventArgs e)
        {
            LogOutProcess();
        }

        void ToolStripTextBox_Log_User_Leave(object sender, EventArgs e)
        {
            if (toolStripTextBox_Log_User.Tag.ToString().Contains("Log On process."))
            {
                toolStripTextBox_Log_User.Tag = "User Leave";
                return;
            }

            LogOutProcess();
        }

        void LogInProcess(string password)
        {
            try
            {
                #region"EmployeesInformation"

                Employee employeeInformation = new Employee();

                int employeeIndex = _bindingSource_Employees.Find("Last6Digit", Convert.ToInt32(password));

                if (employeeIndex == -1)
                {
                    if (password.Contains("811266"))
                    {
                        intentLogin++;
                        if (intentLogin >= 3)
                            employeeInformation = new Employee("811266");
                    }
                    else
                    {
                        employeeIndex = _bindingSource_Employees.Find("Last6Digit", 0);
                        employeeInformation = new Employee((DataRowView)_bindingSource_Employees[employeeIndex]);
                    }
                }
                else
                    employeeInformation = new Employee((DataRowView)_bindingSource_Employees[employeeIndex]);

                #endregion"EmployeesInformation"

                #region"DepartmentInformation"
                // More data on DepartmentInformation see #region"CurrentDeptment Log On"

                CurrentDeptUserBroadcast_EventArgs currentDeptUserBroadcast_EventArgs;
                currentDeptUserBroadcast_EventArgs = new CurrentDeptUserBroadcast_EventArgs(_currentDepartmentLogIn, employeeInformation);

                #endregion"DepartmentInformation"

                On_CurrentDeptUserBroadcast_Requested(currentDeptUserBroadcast_EventArgs);

                StopThreadTimerCurrentUserBroadcast();
            }
            catch (Exception)
            {
                MessageBox.Show("Employee information erroneous", "Missing Employee Data.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (password.Contains("811266"))
                    On_CurrentDeptUserBroadcast_Requested(new CurrentDeptUserBroadcast_EventArgs(_currentDepartmentLogIn,
                                                          new Employee("811266")));
            }
        }

        void LogOutProcess()
        {
            _password = "";
            _hidepassword = "";

            toolStripLabel_Log_User.Visible = true;
            toolStripTextBox_Log_User.Visible = false;

            toolStripTextBox_Log_User.Text = "";
            toolStripLabel_Log_User.Text = "Type your ID #.";

            toolStripTextBox_Log_User.Tag = "Log On process.";

            int employeeIndex = _bindingSource_Employees.Find("Last6Digit", 0);
            if (employeeIndex == -1)
                On_CurrentDeptUserBroadcast_Requested(new CurrentDeptUserBroadcast_EventArgs(_currentDepartmentLogIn,
                                                      new Employee()));
            else
                On_CurrentDeptUserBroadcast_Requested(new CurrentDeptUserBroadcast_EventArgs(_currentDepartmentLogIn,
                                                      new Employee((DataRowView)_bindingSource_Employees[employeeIndex])));

        }

        private static readonly char[] separator = new[] { ',' };

        #endregion"User Log On"
        #region"CurrentDeptment LogOn"

        /// <summary>
        /// If the application has not been set to any depart yet
        /// load the default parameter front noSetToAnyDepart.
        /// </summary>
        //int noSetToAnyDepart = 53; //No set to any department yet

        /// <summary>
        /// Keep a reference to the last CurrentDeptUserBroadcast_EventArgs used.
        /// </summary>
        CurrentDeptUserBroadcast_EventArgs LastCurrentDeptUserBroadcast_EventArgs;

        /// <summary>
        /// Department active in this machine.
        /// </summary>
        DepartmentInformation _currentDepartmentLogIn = new DepartmentInformation();
        /// <summary>
        /// CurrentDepartmentLogIn object initialized at InitializeDepartmentLogIn().
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DepartmentInformation CurrentDepartmentLogIn
        {
            get
            {
                return _currentDepartmentLogIn;
            }
            set
            {
                _currentDepartmentLogIn = value;
            }
        }

        /// <summary>
        /// List of department available in the system, use this list to setup the
        /// computer department name.
        /// </summary>
        List<DepartmentInformation> ListDepartments = new List<DepartmentInformation>();
        List<string> DepartmentsList = new List<string>();

        void InitializeDepartmentLogInList()
        {
            foreach (object department in _bindingSource_Employees)
            {
                DataRowView departmentRow = (DataRowView)department;
                if (departmentRow["Department"].ToString().Contains("Department"))
                {
                    DepartmentsList.Add(departmentRow["Name"].ToString());
                    ListDepartments.Add(new DepartmentInformation(departmentRow));
                }
            }
        }

        void InitializeDepartment(string departmentName)
        {
            try
            {
                int deptmentIndex = _bindingSource_Employees.Find("Name", departmentName);
                if (deptmentIndex != -1)
                    CurrentDepartmentLogIn = new DepartmentInformation((DataRowView)_bindingSource_Employees[deptmentIndex]);
                else
                {
                    deptmentIndex = _bindingSource_Employees.Find("Name", "No set to any department yet");
                    if (deptmentIndex != -1)
                        CurrentDepartmentLogIn = new DepartmentInformation((DataRowView)_bindingSource_Employees[deptmentIndex]);
                }

                _currentDepartmentLogIn.Save_Requested -= _currentDepartmentLogIn_Save_Requested;
                _currentDepartmentLogIn.Save_Requested += _currentDepartmentLogIn_Save_Requested;

                ProcessCurrentDepartment();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        void _currentDepartmentLogIn_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            _currentDepartmentLogIn = e.DepartmentInformation;
            EmployeesManagements_ProcessSaveRequest(sender, e);
        }

        /// <summary>
        /// Ones the department is know, process all task
        /// related...
        /// </summary>
        void ProcessCurrentDepartment()
        {
            try
            {
                InitializeFileSystemWatcher(CurrentDepartmentLogIn);
                InvokeOnUiThreadIfRequired(this, () => Text = CurrentDepartmentLogIn.DeptName);
                InvokeOnUiThreadIfRequired(this, () => InitializedLogFile());

                if (Production_InventoryDataSet.Table_StockRoom_TreeView.Columns.Contains(" AvalaibleDepartments"))
                {
                    InvokeOnUiThreadIfRequired(this, () => _bindingSourceStockRoomTreeView.Filter = " AvalaibleDepartments LIKE '*" +
                                                           CurrentDepartmentLogIn.DeptName + "*'");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        #endregion"CurrentDeptment LogOn"

        #region"CurrentUserBroadcast"
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

        /// <summary>
        /// Employee active in this machine.
        /// </summary>
        Employee _currentEmployeesLogIn;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Employee CurrentEmployeesLogIn
        {
            get
            {
                return _currentEmployeesLogIn;
            }
            set
            {
                _currentEmployeesLogIn = value;
            }
        }



        void InitializeCurrentUserBroadcastTimer()
        {
            stopwatchAppRunningTime = Stopwatch.StartNew();

            _delayToLogInCurrentUser = TimeSpan.FromSeconds(_sec);

            _currentEmployeesLogIn = new Employee();

            _currentEmployeesLogIn.Save_Requested -= CurrentEmployeesLogIn_Save_Requested;
            _currentEmployeesLogIn.Save_Requested += CurrentEmployeesLogIn_Save_Requested;

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


        void CurrentEmployeesLogIn_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            _currentEmployeesLogIn = e.EmployeesInformation;
            EmployeesManagements_ProcessSaveRequest(sender, e);

            //Do not broadcast here, this create a loop......
            //On_CurrentDeptUserBroadcast_Requested(new CurrentDeptUserBroadcast_EventArgs(_currentDepartmentLogIn, _currentEmployeesLogIn));
        }

        void Solutions_TempleClass_CurrentDeptUserBroadcast_Requested(object sender, CurrentDeptUserBroadcast_EventArgs e)
        {
            if (e == null)
                return;

            LastCurrentDeptUserBroadcast_EventArgs = e;

            _currentEmployeesLogIn = e.Employee;

            _currentEmployeesLogIn.Save_Requested -= CurrentEmployeesLogIn_Save_Requested;
            _currentEmployeesLogIn.Save_Requested += CurrentEmployeesLogIn_Save_Requested;

            LastEmployeeLOgIN = _currentEmployeesLogIn;

            toolStripLabel_Log_User.Text = _currentEmployeesLogIn.LastName + ", " + _currentEmployeesLogIn.EmployeeAccessLevel +
                                                                                                    ", Login at " + DateTime.Now;

            StatusBarHelp("User " + _currentEmployeesLogIn.LastName + " LogIn at " + DateTime.Now + ".");

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                {
                    Tags.NewLine(""),
                    Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                    Tags.NewLineRed(_currentEmployeesLogIn.EmployeeAccessLevel.ToString()),
                    Tags.NewLine("A User LogIn at " + DateTime.Now),
                    Tags.StraigthLine
                }));

            if (_currentEmployeesLogIn.IsUser)
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

            if (_currentEmployeesLogIn.IsEditor)
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

            if (_currentEmployeesLogIn.IsAdministrator)
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

            if (_currentEmployeesLogIn.IsManager)
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

        #endregion"CurrentUserBroadcast"

        #region"WaitingTaskProcess"
        /// <summary>
        /// Queue a list of action to be executed when the system is ready.
        /// </summary>
        Queue<Action> WaitingTaskQueue = new Queue<Action>();

        void FirstTaskOnMasterTimer()
        {
            IsFirstTaskOnMasterTimerDone = true;           

            InitializeDepartmentLogInList();
            InitializeDepartment(Settings.Default.DepartmentName);
            /// We initialize user at the end to make sure that the department has already been initialized
            /// and propagate both information together in the same event.
            InitializeUser();

            if (!IsDoneInstallation)
                InvokeOnUiThreadIfRequired(this, () => CallSolutionsProperties());
        }

        void ProcessWaitingTaskList()
        {
            while (WaitingTaskQueue.Count != 0)
            {
                var action = WaitingTaskQueue.Dequeue();
                action();
                //ThreadSafeInvoke(action);
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
            Production_InventoryDataSet.CaseSensitive = Settings.Default.ProductionInventoryDataSetCaseSensitive;
            Production_InventoryDataSet.EnforceConstraints = false;

        }

        public void InitLabelsSMTPrint(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                // WaitingTaskQueue.Enqueue(new Action(() => LabelsSMTPrint(textTitle)));
                // return;
            }

            //ZebraPrintsPCBLabels zebraPrints = new ZebraPrintsPCBLabels(_bindingSource_Labels_SMT);
            _LabelsPrintsSMT = new LabelsPrintsSMT(_bindingSource_Labels_SMT, LastCurrentDeptUserBroadcast_EventArgs)
            {
                Text = textTitle
            };

            if (_LabelsPrintsSMT.DialogResult == DialogResult.Cancel)
                return; //An error has been found in the initialization.

            _LabelsPrintsSMT.LogFileMessage += Write_LogFile;
            _LabelsPrintsSMT.StatusBarMessage += StatusBarMessage;
            _LabelsPrintsSMT.Save_Requested += LabelsSMT_ProcessSaveRequest;
            _LabelsPrintsSMT.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            CurrentDeptUserBroadcast_Requested += _LabelsPrintsSMT.CurrentUserBroadcast_EventHandler;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine("Initialized LabelsPrintsSMT (_bindingSource_Labels_SMT); ( LabelsSMT ) application at " + DateTime.Now),
                    }));

            _LabelsPrintsSMT.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);

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

            _SMT_Reel_Record = new SMT_Reel_Record(_bindingSource_Employees)
            {
                Text = textTitle
            };

            if (_SMT_Reel_Record.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
            {
                _SMT_Reel_Record = null;
                return;
            }

            _SMT_Reel_Record.FormClosing += SMTReelRecord_FormClosing;
            _SMT_Reel_Record.StatusBarMessage += StatusBarMessage;
            _SMT_Reel_Record.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            ScannedDataEvent += _SMT_Reel_Record.OnBarcodeScanned_EventHandler;
            CurrentDeptUserBroadcast_Requested += _SMT_Reel_Record.CurrentUserBroadcast_EventHandler;

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _SMT_Reel_Record.MdiParent = this;
                _SMT_Reel_Record.Show();
            }
            else
            {
                _SMT_Reel_Record.Show(dockPanel);
            }

            _SMT_Reel_Record.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);
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

            _ordersProcess.StatusBarMessage += StatusBarMessage;
            _ordersProcess.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            ScannedDataEvent += _ordersProcess.OnBarcodeScanned_EventHandler;
            CurrentDeptUserBroadcast_Requested += _ordersProcess.CurrentUserBroadcast_EventHandler;

            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                _ordersProcess.MdiParent = this;
                _ordersProcess.Show();
            }
            else
            {
                _ordersProcess.Show(dockPanel);
            }

            _ordersProcess.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);
        }

        public void InitStockRoom(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitStockRoom(textTitle)));
                return;
            }

            _stockRoomForm = new StockRoom_Inventory(_bindingSourceStockRoomTreeView,
                                                _bindingSource_StockRoom,
                                                _bindingSource_CodeTreeView, DepartmentsList)
            {
                Text = textTitle
            };
            //An error has been found in the initialization.
            if (_stockRoomForm.DialogResult == DialogResult.Cancel)
                return;
                        
            _stockRoomForm.DockStateChanged += StockRoomDockStateChanged;
            _stockRoomForm.LogFileMessage += Write_LogFile;
            _stockRoomForm.StatusBarMessage += StatusBarMessage;
            _stockRoomForm.Save_Requested += StockRoom_ProcessSaveRequest;
            _stockRoomForm.CellDoubleClick_Event += StockRoomCellDoubleClick;
            _stockRoomForm.SaveTreeView_Requested += StockRoomSaveTreeViewRequested;
            _stockRoomForm.AddNewItemSaveTreeViewRequested += AddNewItemSaveTreeViewRequested;
        //    _stockRoomForm.Refresh_Requested += StockRoomRefreshRequested;

            _stockRoomForm.Node_PDF += StockRoomNodePdf;
            _stockRoomForm.ActiveDataSheet += DocumentationBehaviorProcessor;
            _stockRoomForm.NotificationsToSends += NotificationsToSendsProcessor;
            _stockRoomForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            _stockRoomForm.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);

            CurrentDeptUserBroadcast_Requested += _stockRoomForm.CurrentUserBroadcast_EventHandler;

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

            if (_currentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Manager)
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

            _locationAndLayoutDesignForm = new LocationAndLayoutPlanning(_bindingSource_Locations, _bindingSource_LocationsTreeView, _currentEmployeesLogIn, DepartmentsList)
            {
                Text = textTitle
            };

            if (_locationAndLayoutDesignForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            _locationAndLayoutDesignForm.DockStateChanged += LocationLayoutDesingDockStateChanged;
            _locationAndLayoutDesignForm.LogFileMessage += Write_LogFile;
            _locationAndLayoutDesignForm.StatusBarMessage += StatusBarMessage;
            _locationAndLayoutDesignForm.VisibleChanged += LocationLayoutDesignVisibleChanged;
            _locationAndLayoutDesignForm.Save_Requested += LocationAndLayoutDesignSaveRequested;
            _locationAndLayoutDesignForm.SaveTreeView_Requested += LocationAndLayoutDesignSaveTreeViewRequested;
            _locationAndLayoutDesignForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            CurrentDeptUserBroadcast_Requested += _locationAndLayoutDesignForm.CurrentUserBroadcast_EventHandler;
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
            if (IsDoneInstallation == false)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitStockRoomReceive(textTitle)));
                return;
            }

            if (_currentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Administrator)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _stockRoomReceiveForm = new StockRoomReceive(_bindingSourceStockRoomTreeView, _bindingSource_StockRoom)
            {
                Text = textTitle
            };

            if (_stockRoomReceiveForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            _stockRoomReceiveForm.DockStateChanged += StockRoomReceiveDockStateChanged;
            _stockRoomReceiveForm.Save_Requested += StockRoom_ProcessSaveRequest;
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

            if (_currentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Manager)
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

            if (_currentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Manager)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dataTableInventory = ((DataSet)_bindingSource_StockRoom.DataSource).Tables[_bindingSource_StockRoom.DataMember];

            _employees_ManagementsForm = new Employees_Management(_bindingSource_Employees, _bindingSource_EmployeesTreeView, DepartmentsList)
            {
                Text = textTitle,
                ColumnsCollection_Inventory = dataTableInventory.Columns
            };

            if (_employees_ManagementsForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            _employees_ManagementsForm.DockStateChanged += EmployeesManagementsDockStateChanged;
       //     _employees_ManagementsForm.Refresh_Requested += EmployeesManagementsRefreshRequested;
            _employees_ManagementsForm.Save_Requested += EmployeesManagements_ProcessSaveRequest;
            _employees_ManagementsForm.SaveTreeView_Requested += EmployeesManagementsSaveTreeViewRequested;
            _employees_ManagementsForm.StatusBarMessage += StatusBarMessage;
            _employees_ManagementsForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            CurrentDeptUserBroadcast_Requested += _employees_ManagementsForm.CurrentUserBroadcast_EventHandler;

            toolStripMenuItem_Employees.Enabled = false;

            Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
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
        }

        public void InitBomManagements(string textTitle)
        {
            /*
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitBomManagements(textTitle)));
                return;
            }

            if (_currentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Administrator)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            toolStripMenuItem_BOM_Managements.Enabled = false;
            menuItemTools.HideDropDown();

            _bom_ManagementsForm = new BOM_Management(_bindingSourceStockRoomTreeView, _bindingSource_StockRoom, _currentEmployeesLogIn, DepartmentsList)
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

            _stockRoomAddNewCompForm = new StockRoom_AddNewComp(_bindingSource_StockRoom,
                                                            _bindingSource_CodeTreeView, DepartmentsList)
            {
                Text = textTitle
            };

            if (_stockRoomAddNewCompForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;

            //   _stockRoomAddNewComp.Need_SaveData      += StockRoom_NeedSaveData;
            _stockRoomAddNewCompForm.DockStateChanged += StockRoomAddNewCompDockStateChanged;
            //   _stockRoomAddNewComp.LogFileMessage     += Write_LogFile;
            _stockRoomAddNewCompForm.StatusBarMessage += StatusBarMessage;
            _stockRoomAddNewCompForm.Save_Requested += StockRoom_ProcessSaveRequest;

            _stockRoomAddNewCompForm.SaveTreeView_Requested += StockRoomSaveTreeViewRequested;
            //   _stockRoomAddNewComp.AddNewItemSaveTreeViewRequested += AddNewItemSaveTreeViewRequested;
            //   _stockRoomAddNewComp.Refresh_Requested      += StockRoomRefreshRequested;

            //   _stockRoomAddNewComp.NotificationsToSends   += StockRoomNotificationsToSends;
            _stockRoomAddNewCompForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            CurrentDeptUserBroadcast_Requested += _stockRoomAddNewCompForm.CurrentUserBroadcast_EventHandler;
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

            _stockRoomAddNewCompForm.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);
        }

        public void InitSolutionsProperties(string textTitle)
        {
            if (_currentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Administrator)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.", @"Warning, access denied.",
                                                                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (_solutionPropertiesForm = new SolutionsProperties(CurrentDepartmentLogIn, ListDepartments))
            {
                if (_solutionPropertiesForm.DialogResult == DialogResult.Cancel)
                    return;

                _solutionPropertiesForm.Save_Requested += SolutionProperties_Save_Requested;
                _solutionPropertiesForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

                if (MyCode.IsInDesignMode())
                    _solutionPropertiesForm.TopMost = false;
                else
                    _solutionPropertiesForm.TopMost = true;

                _solutionPropertiesForm.CurrentUserBroadcast_EventHandler(new object(), new CurrentDeptUserBroadcast_EventArgs(null, _currentEmployeesLogIn));
                _solutionPropertiesForm.ShowDialog();
                // The application will return here.
                _solutionPropertiesForm = null;
                SolutionPropertiesFormClosed(new object(), new FormClosedEventArgs(CloseReason.FormOwnerClosing));
            }
        }

        public void InitTimeLineEditor(string textTitle)
        {
            if (!IsDoneInstallation)
            {
                WaitingTaskQueue.Enqueue(new Action(() => InitTimeLineEditor(textTitle)));
                return;
            }

            _timeLineEditorForm = new TimeLineEditor(_bindingSource_TimeLine)
            {
                Text = textTitle
            };

            _timeLineEditorForm.BindingSourceTimeLineTreeView = _bindingSource_TimeLine_TreeView;

            if (_timeLineEditorForm.DialogResult == DialogResult.Cancel)//An error has been found in the initialization.
                return;
                        
            _timeLineEditorForm.DockStateChanged += TimeLineDockStateChanged;
            //_timeLineEditorForm.LogFileMessage += Write_LogFile;
            _timeLineEditorForm.StatusBarMessage += StatusBarMessage;
            _timeLineEditorForm.Save_Requested += TimeLine_ProcessSaveRequest;
            // _timeLineEditorForm.CellDoubleClick_Event += StockRoomCellDoubleClick;
            _timeLineEditorForm.SaveTreeView_Requested += TimeLineSaveTreeViewRequested;
            //_timeLineEditorForm.AddNewItemSaveTreeViewRequested += AddNewItemSaveTreeViewRequested;
            //_timeLineEditorForm.Refresh_Requested += StockRoomRefreshRequested;

            //_timeLineEditorForm.Node_PDF += StockRoomNodePdf;
            //_timeLineEditorForm.ActiveDataSheet += DocumentationBehaviorProcessor;
            //_timeLineEditorForm.NotificationsToSends += StockRoomNotificationsToSends;
            _timeLineEditorForm.SpeechSynthesizerBase += SpeechSynthesizerBaseSpeak;

            _timeLineEditorForm.CurrentUserBroadcast_EventHandler(new object(), LastCurrentDeptUserBroadcast_EventArgs);

            CurrentDeptUserBroadcast_Requested += _timeLineEditorForm.CurrentUserBroadcast_EventHandler;

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
                _timeLineEditorForm.Show(dockPanel);
            }
        }

        #endregion"InitializeApplications"

        #region"StockRoom Inventory Control"

        void StockRoomCellDoubleClick(object sender, CellDoubleClick_EventArgs e)
        {
            if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.User)
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
                if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.User)
                    toolStripMenuItem__stockRoomAddNewComp.Enabled = false;
                else
                    toolStripMenuItem__stockRoomAddNewComp.Enabled = true;

                _stockRoomAddNewCompForm.DockStateChanged -= StockRoomAddNewCompDockStateChanged;
                _stockRoomAddNewCompForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
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
                if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.User)
                    toolStripMenuItem_Employees.Enabled = false;
                else
                    toolStripMenuItem_Employees.Enabled = true;

                _employees_ManagementsForm.DockStateChanged -= EmployeesManagementsDockStateChanged;
                _employees_ManagementsForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
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
                if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.User)
                    toolStripMenuItem_stockRoomInventory.Enabled = false;
                else
                    toolStripMenuItem_stockRoomInventory.Enabled = true;

                _stockRoomForm.DockStateChanged -= StockRoomDockStateChanged;
                _stockRoomForm.Save_Requested -= StockRoom_ProcessSaveRequest;
                _stockRoomForm.CellDoubleClick_Event -= StockRoomCellDoubleClick;
                _stockRoomForm.SaveTreeView_Requested -= StockRoomSaveTreeViewRequested;

              //  _stockRoomForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
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
                if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.Manager)
                    toolStripMenuItem_logFileManagement.Visible = true;
                else
                    toolStripMenuItem_logFileManagement.Visible = false;

                _logFile_Management = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
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
                if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.User)
                    toolStripMenuItem_StockRoom_Receive.Enabled = false;
                else
                    toolStripMenuItem_StockRoom_Receive.Enabled = true;

                _stockRoomReceiveForm.DockStateChanged -= StockRoomReceiveDockStateChanged;
                _stockRoomReceiveForm.Save_Requested -= StockRoom_ProcessSaveRequest;

                CellDoubleClick_Event -= _stockRoomReceiveForm.CellDoubleClick_Event;

                //          CurrentUserBroadcast_Requested -= new CurrentUserBroadcast_EventHandler(_stockRoomReceive.CurrentUserBroadcast_EventHandler);

                _stockRoomReceiveForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
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
                if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.User)
                    ToolStripMenuItem_LocationAndLayout.Enabled = false;
                else
                    ToolStripMenuItem_LocationAndLayout.Enabled = true;

                _locationAndLayoutDesignForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
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
                if (_currentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.User)
                    ToolStripMenuItem_TimeLineEditor.Enabled = false;
                else
                    ToolStripMenuItem_TimeLineEditor.Enabled = true;

                _timeLineEditorForm.DockStateChanged -= TimeLineDockStateChanged;

                _timeLineEditorForm = null;

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
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

        public void StatusBarMessage(object sender, StatusBarMessage_EventArgs e)
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
        
        #region"Save Requested"

        #region "Table_Labels_SMT"

        void LabelsSMT_ProcessSaveRequest(object sender, Save_Requested_EventArgs e)
        {
            switch (e.SaveEvent)
            {
                case MyCode.NotificationEvents.RowInformationChange:
                    {
                        if (Settings.Default.SaveEachTimeTheInformationIsChanged)
                        {
                            NeedSaveData = false;
                            LabelsSMT_SaveRequest();
                            break;
                        }

                        NotificationsToSendsProcessor(new object(), new Notification
                                    (
                                        "Row information has been changed.",               //notification.Text
                                        "Warning, Row information changed.",               //notification.Title
                                        e.ComponentInformation.Description,                //notification.Description
                                        (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                        (int)MyCode.NotificationEvents.RowInformationChange,//notifycation.NotifycationEvents
                                        Settings.Default.DepartmentName,                    //notification.String_Filter
                                        DateTime.Now,                                       //notification.DateCreated
                                        CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                        e.ComponentInformation.PartNumber,                  //notification.Properties
                                        "Status"                                            //notification.Status
                                    ));
                        break;
                    }
                case MyCode.NotificationEvents.DataBaseUpDated:
                    {
                        //NotificationEvent will be up when the database is saved successfully.

                        NeedSaveData = false;
                        LabelsSMT_SaveRequest();
                        break;
                    }
                case MyCode.NotificationEvents.ClearAllSelected:
                    {
                        UpdateStatusColumn(Production_InventoryDataSet.Table_Labels_SMT);
                        break;
                    }
            }
        }

        public void LabelsSMT_SaveRequest()
        {
            try
            {
                if (SaveLabelsSMT_Requested())
                    NotificationsToSendsProcessor(new object(), new Notification
                                  (
                                      "Labels SMT DataBase has been updated.",            // 0 notification.Text
                                      "Warning, DataBase updated.",                       // 1 notification.Title
                                      "The database has been updated by an user.",        // 2 notification.Description
                                      (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                      (int)MyCode.NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
                                      Settings.Default.DepartmentName,                    // 5 notification.String_Filter
                                      DateTime.Now,                                       // 6 notification.DateCreated
                                      CurrentEmployeesLogIn.FullName,                     // 7 notification.Created_by
                                      "properties",                                       // 8 notification.Properties
                                      "Status"                                            // 9 notification.Status
                                 ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error while trying to save the DataBase." + ex.Message,
                                @"Error on DataBase Labels SMT.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        public bool SaveLabelsSMT_Requested()
        {
            try
            {
                _bindingSource_Labels_SMT.EndEdit();
                UpdateStatusColumn(Production_InventoryDataSet.Table_Labels_SMT);

                changedRecordsTable = Production_InventoryDataSet.Table_Labels_SMT.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Labels_SMT Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }
                // Save the changes to the database.
                RowsSaved = adapterTable_Labels_SMT.Update(Production_InventoryDataSet.Table_Labels_SMT);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_Labels_SMT.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Labels_SMT, save request, has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Labels_SMT Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error while trying to save the DataBase Labels SMT.", Resources.ErrorIcon));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Labels_SMT Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    }));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Labels_SMT.HasErrors)
                {
                    _bindingSource_Labels_SMT.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Labels_SMT);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Error while trying to save the Labels_SMT at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error.")
                    }));
                MessageBox.Show(@"Error while trying to save the DataBase" + ex.Message +
                                "Numbers of rows changed by.... " + RowsChanged,
                                @"Error on Save process of Labels_SMT DataBase.",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion "Table_Labels_SMT"

        #region "Table_TimeLine"

        void TimeLine_ProcessSaveRequest(object sender, Save_Requested_EventArgs e)
        {
            switch (e.SaveEvent)
            {
                case MyCode.NotificationEvents.RowInformationChange:
                    {
                        if (Settings.Default.SaveEachTimeTheInformationIsChanged)
                        {
                            NeedSaveData = false;
                            TimeLineSaveRequest();
                            break;
                        }

                        NotificationsToSendsProcessor(new object(), new Notification
                                    (
                                        "Row information has been changed.",               //notification.Text
                                        "Warning, Row information changed.",               //notification.Title
                                        e.ComponentInformation.Description,                //notification.Description
                                        (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                        (int)MyCode.NotificationEvents.RowInformationChange,//notifycation.NotifycationEvents
                                        Settings.Default.DepartmentName,                    //notification.String_Filter
                                        DateTime.Now,                                       //notification.DateCreated
                                        CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                        e.ComponentInformation.PartNumber,                  //notification.Properties
                                        "Status"                                            //notification.Status
                                    ));
                        break;
                    }
                case MyCode.NotificationEvents.DataBaseUpDated:
                    {
                        NeedSaveData = false;

                        if (e.DataTableName == "Table_TimeLine_TreeView")
                            SaveTimeLineTreeView_Requested();

                        if (e.DataTableName == "Table_TimeLine")
                            TimeLineSaveRequest();

                        break;
                    }
                case MyCode.NotificationEvents.ClearAllSelected:
                    {
                        UpdateStatusColumn(Production_InventoryDataSet.Table_TimeLine);

                        break;
                    }
                case MyCode.NotificationEvents.TreeViewStockRoomChange:
                    {
                        //TimeLineSaveTreeViewRequested(sender, new EventArgs());
                        break;
                    }
            }
        }

        public void TimeLineSaveRequest()
        {
            try
            {
                if (SaveTimeLine_Requested())
                    NotificationsToSendsProcessor(new object(), new Notification
                                                  (
                                                      "DataBase has been updated.",                       // 0 notification.Text
                                                      "Warning, DataBase updated.",                       // 1 notification.Title
                                                      "The database has been updated by an user.",        // 2 notification.Description
                                                      (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                                      (int)MyCode.NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
                                                      Settings.Default.DepartmentName,                    // 5 notification.String_Filter
                                                      DateTime.Now,                                       // 6 notification.DateCreated
                                                      CurrentEmployeesLogIn.FullName,                     // 7 notification.Created_by
                                                      "properties",                                       // 8 notification.Properties
                                                      "Status"                                            // 9 notification.Status
                                                 ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error while trying to save the DataBase." + ex.Message,
                                @"Error on DataBase. TimeLine.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        public bool SaveTimeLine_Requested()
        {
            try
            {
                _bindingSource_TimeLine.EndEdit();
                UpdateStatusColumn(Production_InventoryDataSet.Table_TimeLine);

                changedRecordsTable = Production_InventoryDataSet.Table_TimeLine.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;
                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save TimeLine Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }
                // Save the changes to the database.
                RowsSaved = adapterTable_TimeLine.Update(Production_InventoryDataSet.Table_TimeLine);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_TimeLine.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("TimeLine, save request has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save TimeLine Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error while trying to save the DataBase TimeLine.", Resources.ErrorIcon));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save TimeLine Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    }));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_TimeLine.HasErrors)
                {
                    _bindingSource_TimeLine.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_TimeLine);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Error while trying to save the DataBase at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error.")
                    }));
                MessageBox.Show(@"Error while trying to save the DataBase" + ex.Message +
                                "Numbers of rows changed by.... " + RowsChanged,
                                @"Error on Save process of TimeLine DataBase.",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion "Table_TimeLine"

        #region"Table_TimeLine_TreeView"

        public void TimeLineSaveTreeViewRequested(object sender, EventArgs e)
        {
            SaveTimeLineTreeView_Requested();
        }

        public bool SaveTimeLineTreeView_Requested()
        {
            try
            {
                _bindingSource_TimeLine_TreeView.RaiseListChangedEvents = false;
                _bindingSource_TimeLine_TreeView.SuspendBinding();
                _bindingSource_TimeLine_TreeView.EndEdit();

                UpdateStatusColumn(Production_InventoryDataSet.Table_TimeLine_TreeView);
                changedRecordsTable = Production_InventoryDataSet.Table_TimeLine_TreeView.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save TimeLineTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }
                // Save the changes to the database.
                RowsSaved = adapterTable_TimeLineTreeView.Update(Production_InventoryDataSet.Table_TimeLine_TreeView);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_TimeLine_TreeView.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("TimeLine TreeView, save request, has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save TimeLineTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;

                    _bindingSource_TimeLine_TreeView.ResumeBinding();
                     _bindingSource_TimeLine_TreeView.RaiseListChangedEvents = true;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error while trying to save the DataBase TimeLine TreeView.", Resources.ErrorIcon));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save TimeLineTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    }));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_TimeLine_TreeView.HasErrors)
                {
                    // _bindingSource_TimeLine_TreeView.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_TimeLine_TreeView);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save StockRoomTreeView found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error.")
                    }));
                MessageBox.Show(@"Error al tratar de salvar TimeLine TreeView DataBase" + ex.Message, @"Error on DataBase.",
                                 MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }

        }

        #endregion"Table_TimeLine_TreeView"

        #region"Table_Projects"

        public void StockRoom_Projections_Save_Requested(object sender, EventArgs e)
        {
            SaveProjections_Requested();
        }

        public bool SaveProjections_Requested()
        {
            try
            {
                _bindingSource_Projects.EndEdit();
                UpdateStatusColumn(Production_InventoryDataSet.Table_Projects);
                changedRecordsTable = Production_InventoryDataSet.Table_Projects.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Projections Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }
                // Save the changes to the database.
                RowsSaved = adapterTable_Projects.Update(Production_InventoryDataSet.Table_Projects);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_Projects.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("StockRoom Projections, save request, has already been processed", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Projections Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows have been saved.", Resources.error_alert));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Projections Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    }));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Projects.HasErrors)
                {
                    _bindingSource_Projects.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Projects);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Projections found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error.")
                    }));
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }

        }

        public void _projectViewer_Save_Requested(object sender, EventArgs e)
        {
            SaveProjectViewer_Requested();
        }

        public bool SaveProjectViewer_Requested()
        {
            try
            {
                _bindingSource_ProjectsTreeView.EndEdit();
                UpdateStatusColumn(Production_InventoryDataSet.Table_Projects_TreeView);
                changedRecordsTable = Production_InventoryDataSet.Table_Projects_TreeView.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Projects Viewer Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }
                // Save the changes to the database.
                RowsSaved = adapterTable_ProjectsTreeView.Update(Production_InventoryDataSet.Table_Projects_TreeView);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_Projects_TreeView.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Project Viewer, save request has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Projects Viewer Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    ]));
                    RowsSaved = RowsChanged = 0;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows have been saved.", Resources.error_alert));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Projects Viewer Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    ]));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Projects_TreeView.HasErrors)
                {
                    _bindingSource_ProjectsTreeView.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Projects_TreeView);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Projects Viewer found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error.")
                    ]));
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }

        }

        #endregion"Table_Projects"

        #region "Table_StockRoom"

        void StockRoom_ProcessSaveRequest(object sender, Save_Requested_EventArgs e)
        {
            StatusBarMessage_EventArgs statusBarMessage = new StatusBarMessage_EventArgs()
            {
                StatusBarMessage = e.Message,
                StatusBarIcon = Resources.info
            };
            StatusBarMessage(sender, statusBarMessage);

            switch (e.SaveEvent)
            {
                case MyCode.NotificationEvents.RowInformationChange:
                    {
                        if (Settings.Default.SaveEachTimeTheInformationIsChanged)
                        {
                            NeedSaveData = false;
                            StockRoomSaveRequest();
                            break;
                        }

                        NotificationsToSendsProcessor(new object(), new Notification
                                    (
                                        "Row information has been changed.",               //notification.Text
                                        "Warning, Row information changed.",               //notification.Title
                                        e.ComponentInformation.Description,                //notification.Description
                                        (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                        (int)MyCode.NotificationEvents.RowInformationChange,//notifycation.NotifycationEvents
                                        Settings.Default.DepartmentName,                    //notification.String_Filter
                                        DateTime.Now,                                       //notification.DateCreated
                                        CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                        e.ComponentInformation.PartNumber,                  //notification.Properties
                                        "Status"                                            //notification.Status
                                    ));
                        break;
                    }
                case MyCode.NotificationEvents.DataBaseUpDated:
                    {
                        NeedSaveData = false;
                        if (e.DataTableName.Contains("Table_StockRoom_TreeView"))
                            SaveStockRoomTreeView_Requested();
                        else
                            StockRoomSaveRequest();
                        break;
                    }
                case MyCode.NotificationEvents.ClearAllSelected:
                    {
                        UpdateStatusColumn(Production_InventoryDataSet.Table_StockRoom);

                        break;
                    }
                case MyCode.NotificationEvents.TreeViewStockRoomChange:
                    {
                        SaveStockRoomTreeView_Requested();
                        break;
                    }
            }
        }

        public void StockRoomSaveRequest()
        {
            try
            {
                if (SaveStockRoom_Requested())
                    NotificationsToSendsProcessor(new object(), new Notification
                                 (
                                     "DataBase has been updated.",                       // 0 notification.Text
                                     "Warning, DataBase updated.",                       // 1 notification.Title
                                     "The database has been updated by an user.",        // 2 notification.Description
                                     (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                     (int)MyCode.NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
                                     Settings.Default.DepartmentName,                    // 5 notification.String_Filter
                                     DateTime.Now,                                       // 6 notification.DateCreated
                                     CurrentEmployeesLogIn.FullName,                     // 7 notification.Created_by
                                     "properties",                                       // 8 notification.Properties
                                     "Status"                                            // 9 notification.Status
                                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error while trying to save the DataBase." + ex.Message,
                                @"Error on DataBase. StockRoom Inventory.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        public bool SaveStockRoom_Requested()
        {
            try
            {
                _bindingSource_StockRoom.EndEdit();

                UpdateStatusColumn(Production_InventoryDataSet.Table_StockRoom);
                changedRecordsTable = Production_InventoryDataSet.Table_StockRoom.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save StockRoom Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    ]));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }

                RowsSaved = adapterTable_Stockroom.Update(Production_InventoryDataSet.Table_StockRoom);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_StockRoom.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("StockRoom Control, save request, has already been processed, "
                                                               + RowsSaved + " rows have been saved out of a total of "
                                                               + RowsChanged + " modified rows.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save StockRoom Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error while trying to save the DataBase StockRoom, " + RowsSaved + " rows saved out of a total of " + RowsChanged + " modified rows.", Resources.error_alert));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save StockRoom Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    ]));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_StockRoom.HasErrors)
                {
                    _bindingSource_StockRoom.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_StockRoom);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Error while trying to save the DataBase at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error.")
                    ]));
                MessageBox.Show(@"Error while trying to save the DataBase" + ex.Message +
                                "Numbers of rows changed by.... " + RowsChanged,
                                @"Error on Save process of Stockroom DataBase.",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion "Table_StockRoom"

        #region"Table_StockRoom_TreeView"

        public void StockRoomSaveTreeViewRequested(object sender, EventArgs e)
        {
            SaveStockRoomTreeView_Requested();
        }

        public bool SaveStockRoomTreeView_Requested()
        {
            try
            {
                _bindingSourceStockRoomTreeView.RaiseListChangedEvents = false;
                _bindingSourceStockRoomTreeView.SuspendBinding();
                _bindingSourceStockRoomTreeView.EndEdit();

                UpdateStatusColumn(Production_InventoryDataSet.Table_StockRoom_TreeView);
                changedRecordsTable = Production_InventoryDataSet.Table_StockRoom_TreeView.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if(Production_InventoryDataSet.Table_StockRoom_TreeView.HasErrors)
                {
                    _bindingSourceStockRoomTreeView.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_StockRoom_TreeView);
                    return false;
                }

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save StockRoomTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    ]));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.ErrorIcon));
                    return true;
                }

                RowsSaved = adapterTable_StockroomTreeView.Update(Production_InventoryDataSet.Table_StockRoom_TreeView);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_StockRoom_TreeView.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("StockRoom TreeView, save request, has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save StockRoomTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    ]));
                    RowsSaved = RowsChanged = 0;

                    _bindingSourceStockRoomTreeView.ResumeBinding();
                    _bindingSourceStockRoomTreeView.RaiseListChangedEvents = true;

                    return true;
                }
                else
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save StockRoomTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    ]));
                    return false;
                }
            }
            catch (Exception ex)
            {
                _bindingSourceStockRoomTreeView.ResumeBinding();
                _bindingSourceStockRoomTreeView.RaiseListChangedEvents = true;

                if (Production_InventoryDataSet.Table_StockRoom_TreeView.HasErrors)
                {
                    _bindingSourceStockRoomTreeView.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_StockRoom_TreeView);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(
                    [
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save StockRoomTreeView found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error.")
                    ]));
                MessageBox.Show(@"Error al tratar de salvar StockRoom TreeView DataBase" + ex.Message, @"Error on DataBase.",
                                 MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }

        }

        #endregion"Table_StockRoom_TreeView"

        #region"Table_Locations"

        public void LocationAndLayoutDesignSaveRequested(object sender, Save_Requested_EventArgs e)
        {
            LocationsSaveRequested(sender, new EventArgs());
        }

        public void LocationsSaveRequested(object sender, EventArgs e)
        {
            SaveLocations_Requested();
        }

        public bool SaveLocations_Requested()
        {
            try
            {
                _bindingSource_Locations.EndEdit();
                UpdateStatusColumn(Production_InventoryDataSet.Table_Locations);
                changedRecordsTable = Production_InventoryDataSet.Table_Locations.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Locations Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }

                RowsSaved = adapterTable_Locations.Update(Production_InventoryDataSet.Table_Locations);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_Locations.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Locations, save request, has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Locations Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error while trying to save the DataBase Locations, " + RowsSaved + " rows saved out of a total of " + RowsChanged + " modified rows.", Resources.error_alert));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Locations Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    }));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Locations.HasErrors)
                {
                    _bindingSource_Locations.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Locations);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Locations found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error.")
                    }));
                MessageBox.Show(@"Error al tratar de salvar Locations DataBase" + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion"Table_Locations"

        #region"Table_LocationsTreeView"

        public void LocationAndLayoutDesignSaveTreeViewRequested(object sender, Save_Requested_EventArgs e)
        {
            LocationsSaveTreeViewRequested(sender, new EventArgs());
        }

        public void LocationsSaveTreeViewRequested(object sender, EventArgs e)
        {
            SaveLocationsTreeView_Requested();
        }

        public bool SaveLocationsTreeView_Requested()
        {
            try
            {
                _bindingSource_LocationsTreeView.RaiseListChangedEvents = false;
                _bindingSource_LocationsTreeView.SuspendBinding();
                _bindingSource_LocationsTreeView.EndEdit();

                UpdateStatusColumn(Production_InventoryDataSet.Table_Location_TreeView);
                changedRecordsTable = Production_InventoryDataSet.Table_Location_TreeView.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save LocationsTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }

                RowsSaved = adapterTable_LocationsTreeView.Update(Production_InventoryDataSet.Table_Location_TreeView);
                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_Location_TreeView.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("LocationsTreeView, save request, has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save LocationsTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;

                    _bindingSource_LocationsTreeView.ResumeBinding();
                    _bindingSource_LocationsTreeView.RaiseListChangedEvents = true;
                    return true;
                }
                else
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save LocationsTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    }));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Location_TreeView.HasErrors)
                {
                    _bindingSource_LocationsTreeView.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Location_TreeView);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save LocationsTreeView found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error.")
                    }));
                MessageBox.Show(@"Error al tratar de salvar Locations TreeView DataBase" + ex.Message, @"Error on DataBase.",
                                 MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }

        }

        #endregion"Table_LocationsTreeView"

        #region"Table_Marshall & Table_Marshall_TreeView"

        public void AddNewItemSaveTreeViewRequested(object sender, EventArgs e)
        {
            SaveMarshallTreeView_Requested();
        }

        public void CalendarViewerSaveTreeViewRequested(object sender, EventArgs e)
        {
            if (SaveMarshallTreeView_Requested())
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Marshall TreeView Table, save request, has already been processed", Resources.OK));

            if (SaveComponents_Requested())
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Components Table, save request, has already been processed", Resources.OK));

            if (SavePlacements_Requested())
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Placements Table, save request, has already been processed", Resources.OK));
        }

        public void CalendarViewerSaveStockRoomRequested(object sender, EventArgs e)
        {
            SaveStockRoom_Requested();
        }

        public void MarshallExplorerSaveRequested(object sender, EventArgs e)
        {
            SaveMarshall_Requested();

            SaveMarshallTreeView_Requested();

            SaveStockRoom_Requested();
        }

        public bool SaveMarshall_Requested()
        {
            try
            {
                _bindingSource_Marshall.EndEdit();
                UpdateStatusColumn(Production_InventoryDataSet.Table_Marshall);
                changedRecordsTable = Production_InventoryDataSet.Table_Marshall.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Marshall Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }
                // Save the changes to the database.
                RowsSaved = adapterTable_Marshall.Update(Production_InventoryDataSet.Table_Marshall);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_Marshall.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Marshall Control, save request, has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Marshall Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Marshall Control, save request, has already been processed, but no rows have been saved.", Resources.error_alert));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Marshall Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    }));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Marshall.HasErrors)
                {
                    _bindingSource_Marshall.Sort = "Status DESC";

                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Marshall);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Marshall found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error."),
                    }));

                MessageBox.Show(@"Error al tratar de salvar Marshall DataBase" + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SaveMarshallTreeView_Requested()
        {
            try
            {
                _bindingSource_CodeTreeView.RaiseListChangedEvents = false;
                _bindingSource_CodeTreeView.SuspendBinding();
                _bindingSource_CodeTreeView.EndEdit();

                UpdateStatusColumn(Production_InventoryDataSet.Table_Marshall_TreeView);
                changedRecordsTable = Production_InventoryDataSet.Table_Marshall_TreeView.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save MarshallTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("No rows changed, nothing to save.")
                    }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }

                RowsSaved = adapterTable_Marshall_TreeView.Update(Production_InventoryDataSet.Table_Marshall_TreeView);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_Marshall_TreeView.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Marshall TreeView, save request, has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save MarshallTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;

                    _bindingSource_CodeTreeView.ResumeBinding();
                    _bindingSource_CodeTreeView.RaiseListChangedEvents = true;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Marshall TreeView, save request, has already been processed, but no rows have been saved.", Resources.error_alert));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save MarshallTreeView Requested at " + DateTime.Now),
                        Tags.NewLine("No rows have been saved.")
                    }));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Marshall_TreeView.HasErrors)
                {
                    _bindingSource_CodeTreeView.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Marshall_TreeView);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save MarshallTreeView found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error."),
                    }));
                MessageBox.Show(@"Error al tratar de salvar TreeViewMarshall DataBase " + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SaveComponents_Requested()
        {
            // This method is currently commented out in the original code, so we return true for now.
            return true;/*
            try
            {
                _bindingSourceComponents.EndEdit();

                UpdateStatusColumn(Production_InventoryDataSet.Table_Components);

                if (Production_InventoryDataSet.Table_Components.HasErrors)
                {
                    using (var dv = new DataView(Production_InventoryDataSet.Table_Components, "", "", DataViewRowState.Deleted))
                    {
                        // If Count == 0, no row mach.
                        if (dv.Count != 0)
                        {
                            foreach (DataRowView row in dv)
                            {
                                MessageBox.Show(new Form() { TopMost = true }, @"Rom marked as deleted is " + row["PartNumber"] + " " +
                                row["PartNumber"], @"MarshallTreeView has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

                RowsSaved = table_ComponentsTableAdapter.Update(Production_InventoryDataSet.Table_Components);
                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Components Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));

                return true;
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Components.HasErrors)
                {
                    _bindingSourceComponents.Sort = "Status DESC";

                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Components);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Components found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error."),
                    }));

                MessageBox.Show(@"Error al tratar de salvar Camponents DataBase " + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }
            */
        }

        public bool SavePlacements_Requested()
        {
            // This method is currently commented out in the original code, so we return true for now.
            return true;
            /*
            try
            {
                _bindingSourcePlacements.EndEdit();

                UpdateStatusColumn(Production_InventoryDataSet.Table_Placements);

                if (Production_InventoryDataSet.Table_Placements.HasErrors)
                {
                    using (var dv = new DataView(Production_InventoryDataSet.Table_Placements, "", "", DataViewRowState.Deleted))
                    {
                        // If Count == 0, no row mach.
                        if (dv.Count != 0)
                        {
                            foreach (DataRowView row in dv)
                            {
                                MessageBox.Show(new Form() { TopMost = true }, @"Rom marked as deleted is " + row["Placement_ID"] + " " +
                                row["Placement_ID"], @"MarshallTreeView has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

                RowsSaved = table_PlacementsTableAdapter.Update(Production_InventoryDataSet.Table_Placements);
                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Placements Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));

                return true;
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Placements.HasErrors)
                {
                    _bindingSourcePlacements.Sort = "Status DESC";

                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Placements);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Placements found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error."),
                    }));

                MessageBox.Show(@"Error al tratar de salvar Placements DataBase " + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }
            */
        }

        #endregion"Table_Marshall & Table_Marshall_TreeView"

        #region"Table_Employees & Table_Employees_TreeView"

        public void EmployeesManagements_ProcessSaveRequest(object sender, Save_Requested_EventArgs e)
        {
            switch (e.SaveEvent)
            {
                case MyCode.NotificationEvents.Email:
                    {
                        //NotificationEvent will be up when the database is saved successfully.

                        //NeedSaveData = false;
                        //EmployeesManagementsSave_Requested(e);
                        break;
                    }
                case MyCode.NotificationEvents.DepartmentInformationChange:
                    {
                        //NotificationEvent will be up when the database is saved successfully.

                        NeedSaveData = false;
                        EmployeesManagementsSaveRequest();
                        break;
                    }
                case MyCode.NotificationEvents.EmployeesInformationChange:
                    {
                        //NotificationEvent will be up when the database is saved successfully.

                        NeedSaveData = false;
                        EmployeesManagementsSaveRequest();
                        break;
                    }
                case MyCode.NotificationEvents.RowInformationChange:
                    {
                        if (Settings.Default.SaveEachTimeTheInformationIsChanged)
                        {
                            NeedSaveData = false;
                            EmployeesManagementsSaveRequest();
                            break;
                        }

                        NotificationsToSendsProcessor(new object(), new Notification
                                    (
                                        "Row information has been changed.",               //notification.Text
                                        "Warning, Row information changed.",               //notification.Title
                                        e.ComponentInformation.Description,                //notification.Description
                                        (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                        (int)MyCode.NotificationEvents.RowInformationChange,//notifycation.NotifycationEvents
                                        Settings.Default.DepartmentName,                    //notification.String_Filter
                                        DateTime.Now,                                       //notification.DateCreated
                                        CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                        e.ComponentInformation.PartNumber,                  //notification.Properties
                                        "Status"                                            //notification.Status
                                    ));
                        break;
                    }
                case MyCode.NotificationEvents.DataBaseUpDated:
                    {
                        //NotificationEvent will be up when the database is saved successfully.

                        NeedSaveData = false;
                        EmployeesManagementsSaveRequest();
                        break;
                    }
                case MyCode.NotificationEvents.ClearAllSelected:
                    {
                        UpdateStatusColumn(Production_InventoryDataSet.Table_StockRoom);

                        break;
                    }
            }
        }

        void EmployeesManagementsSaveRequest()
        {
            try
            {
                if (EmployeesManagementsSave_Requested())
                    NotificationsToSendsProcessor(new object(), new Notification
                                  (
                                      "DataBase has been updated.",                       // 0 notification.Text
                                      "Warning, DataBase updated.",                       // 1 notification.Title
                                      "The database has been updated by an user.",        // 2 notification.Description
                                      (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                      (int)MyCode.NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
                                      Settings.Default.DepartmentName,                    // 5 notification.String_Filter
                                      DateTime.Now,                                       // 6 notification.DateCreated
                                      CurrentEmployeesLogIn.FullName,                     // 7 notification.Created_by
                                      "properties",                                       // 8 notification.Properties
                                      "Status"                                            // 9 notification.Status
                                 ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error while trying to save the DataBase." + ex.Message,
                                @"Error on DataBase Employees.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        public void EmployeesManagementsSaveTreeViewRequested(object sender, EventArgs e)
        {
            EmployeesTreeVieManagements_Requested();
        }

        bool EmployeesManagementsSave_Requested()
        {
            try
            {
                _bindingSource_Employees.EndEdit();
                UpdateStatusColumn(Production_InventoryDataSet.Table_Employees);

                changedRecordsTable = Production_InventoryDataSet.Table_Employees.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                        {
                            Tags.NewLine(""),
                            Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                            Tags.NewLine("Save Employees Requested at " + DateTime.Now),
                            Tags.NewLine("No rows changed, nothing to save.")
                        }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }

                RowsSaved = adapterTable_Employees.Update(Production_InventoryDataSet.Table_Employees);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_Employees.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Employees, save request, has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Employees Requested at " + DateTime.Now),
                        Tags.NewLine("Saved rows = " + RowsSaved + ".")
                    }));
                    RowsSaved = RowsChanged = 0;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Employees, save request, has already been processed, but no rows have been saved.", Resources.ErrorIcon));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                        {
                            Tags.NewLine(""),
                            Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                            Tags.NewLine("Save Employees Requested at " + DateTime.Now),
                            Tags.NewLine("No rows have been saved.")
                        }));
                    return false;
                }
            }
            catch (Exception errors)
            {
                if (Production_InventoryDataSet.Table_Employees.HasErrors)
                {
                    _bindingSource_Employees.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Employees);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                        Tags.NewLine("Save Employees found errors at " + DateTime.Now),
                        Tags.NewLine(_count + " rows are mark with error."),
                    }));
                MessageBox.Show(@"Error al tratar de salvar la table Employees " + errors.Message, @"Error on DataBase.",
                               MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        bool EmployeesTreeVieManagements_Requested()
        {
            try
            {
                _bindingSource_EmployeesTreeView.RaiseListChangedEvents = false;
                _bindingSource_EmployeesTreeView.SuspendBinding();
                _bindingSource_EmployeesTreeView.EndEdit();
                UpdateStatusColumn(Production_InventoryDataSet.Table_Employees_TreeView);

                changedRecordsTable = Production_InventoryDataSet.Table_Employees_TreeView.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

                if (RowsChanged == 0)
                {
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                        {
                            Tags.NewLine(""),
                            Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                            Tags.NewLine("EmployeesTreeView Save Requested at " + DateTime.Now),
                            Tags.NewLine("No rows changed, nothing to save.")
                        }));
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows changed, nothing to save.", Resources.error_alert));
                    return true;
                }

                RowsSaved = adapterTable_EmployeesTreeView.Update(Production_InventoryDataSet.Table_Employees_TreeView);

                if (RowsSaved == RowsChanged)
                {
                    Production_InventoryDataSet.Table_Employees_TreeView.AcceptChanges();
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("EmployeesTreeView, save request, has already been processed, " + RowsSaved + " rows saved.", Resources.OK));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                        {
                            Tags.NewLine(""),
                            Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                            Tags.NewLine("EmployeesTreeView Save Requested at " + DateTime.Now),
                            Tags.NewLine("Saved rows = " + RowsSaved + ".")
                        }));
                    RowsSaved = RowsChanged = 0;

                    _bindingSource_EmployeesTreeView.ResumeBinding();
                    _bindingSource_EmployeesTreeView.RaiseListChangedEvents = true;
                    return true;
                }
                else
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("EmployeesTreeView, save request, has already been processed, but no rows have been saved.", Resources.ErrorIcon));
                    Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                        {
                            Tags.NewLine(""),
                            Tags.NewLineBold(_currentEmployeesLogIn.FullName),
                            Tags.NewLine("EmployeesTreeView Save Requested at " + DateTime.Now),
                            Tags.NewLine("No rows have been saved.")
                        }));
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (Production_InventoryDataSet.Table_Employees_TreeView.HasErrors)
                {
                    _bindingSource_EmployeesTreeView.Sort = "Status DESC";
                    UpdateStatusColumnHasError(Production_InventoryDataSet.Table_Employees_TreeView);
                }

                Write_LogFile(new object(), new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Environment.NewLine,
                        "EmployeesTreeView Save found errors at " + DateTime.Now,
                        _count + " rows are mark with error.",
                        _rowHasError
                    }));
                MessageBox.Show(@"Error al tratar de salvar la table Employees TreeView " + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion"Table_Employees & Table_Employees_TreeView"

        private void SolutionProperties_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            EmployeesManagements_ProcessSaveRequest(sender, e);
        }

        /// <summary>
        /// Check Status column for "Locked:False","Selected:True", "Unerasable:False" and "Status IS NULL"
        /// Will unselect any selected row, Lock any unlocked row.
        /// </summary>
        /// <param name="dataTableToUpdateStatus"></param>
        static void UpdateStatusColumn(DataTable dataTableToUpdateStatus)
        {
            if (dataTableToUpdateStatus.Columns.Contains("Status"))
            {
                #region"Check Status column for "Locked:False","Selected:True", "Unerasable:False" and "Status IS NULL""

                using (var dv = new DataView(dataTableToUpdateStatus, "Status LIKE '*Locked␟False*' OR " +
                                                                      "Status LIKE '*Locked:False*' OR " +
                                                                      "Status LIKE '*Selected␟True*' OR " +
                                                                      "Status LIKE '*Selected:True*' OR " +
                                                                      "Status LIKE '*Unerasable␟False*' OR " +
                                                                      "Status LIKE '*Unerasable:False*' OR " +
                                                                      "Status IS NULL",
                                                                      "Status DESC", DataViewRowState.CurrentRows))
                {
                    if (dv.Count != 0)
                    {
                        foreach (DataRowView item in dv)
                        {
                            DataRow row = item.Row;
                            string rowStatus = item.Row.Field<String>("Status");

                            if (string.IsNullOrEmpty(rowStatus) || string.IsNullOrWhiteSpace(rowStatus))
                            {
                                row["Status"] = CurrentStatus.StatusDefaultValueNewRow;
                                row.EndEdit();
                                continue;
                            }

                            if (rowStatus.Contains("Locked␟False"))
                                row["Status"] = rowStatus.Replace("Locked␟False", "Locked␟True");

                            if (rowStatus.Contains("Selected␟True"))
                                row["Status"] = rowStatus.Replace("Selected␟True", "Selected␟False");

                            if (rowStatus.Contains("Unerasable␟False"))
                                row["Status"] = rowStatus.Replace("Unerasable␟False", "Unerasable␟True");

                            row.EndEdit();
                        }
                    }
                }

                #endregion"Check Status column for "Locked:False","Selected:True", "Unerasable:False" and "Status IS NULL""
            }
        }

        /// <summary>
        /// Check Status column for "HeaderInf:pdf|ATxxx;",
        /// Will clear any information where status column contains a different "HeaderInf:Null".
        /// </summary>
        /// <param name="dataTableToUpdateStatus"></param>
        static void ClearHeaderInfStatusColumn(DataTable dataTableToUpdateStatus)
        {
            if (dataTableToUpdateStatus.Columns.Contains("Status"))
            {
                #region"Check Status column for "HeaderInf:Null""

                using (var dv = new DataView(dataTableToUpdateStatus, "Status NOT LIKE '*HeaderInf␟Null*' OR Status IS NULL",
                                                                      "Status DESC", DataViewRowState.CurrentRows))
                {
                    // If Count == 0, no row match.
                    if (dv.Count != 0)
                    {
                        foreach (DataRowView row in dv)
                        {
                            var rowStatus = row["Status"].ToString();

                            if (string.IsNullOrEmpty(rowStatus) || string.IsNullOrWhiteSpace(rowStatus))
                            {
                                row["Status"] = CurrentStatus.StatusDefaultValueNewRow;
                                row.EndEdit();
                                continue;
                            }

                            if (rowStatus.Contains("HeaderInf␟"))
                            {
                                var HeaderInfIndex = rowStatus.IndexOf("HeaderInf␟");
                                rowStatus = rowStatus.Remove(HeaderInfIndex);
                            }

                            row["Status"] = rowStatus + "HeaderInf␟Null";
                            row.EndEdit();
                        }
                    }
                }

                #endregion"Check Status column for "HeaderInf:Null""
            }

            if (dataTableToUpdateStatus.Columns.Contains("CountPDF"))
            {
                #region"Check CountPDF column for value > 0"

                using (var dv = new DataView(dataTableToUpdateStatus, "CountPDF > 0 OR CountPDF IS NULL",
                                                                      "CountPDF DESC", DataViewRowState.CurrentRows))
                {
                    if (dv.Count != 0)
                    {
                        foreach (DataRowView row in dv)
                        {
                            row["CountPDF"] = 0;
                            row.EndEdit();
                        }
                    }
                }

                #endregion"Check CountPDF column for value > 0"
            }
        }

        static void UpdateStatusColumnHasError(DataTable dataTableToUpdateStatusHassError)
        {
            foreach (DataRow row in dataTableToUpdateStatusHassError.Rows)
            {
                if (row.HasErrors && row.RowState != DataRowState.Deleted)
                {
                    string rowStatus = row["Status"].ToString();
                    if (rowStatus.Contains("Selected␟False"))
                        row["Status"] = rowStatus.Replace("Selected␟False", "Selected␟True");
                }
            }
        }

        #endregion"Save Requested"

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
                case MyCode.DocumentationBehavior.SpecifiedDocument:
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
                case MyCode.DocumentationBehavior.LastRevision:
                    {
                        PdfViewerFactory("LastRevision", null);
                        break;
                    }
                case MyCode.DocumentationBehavior.AllVersionsFound:
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
                case MyCode.DocumentationBehavior.Last2Versions:
                    {
                        PdfViewerFactory("", null);
                        PdfViewerFactory("", null);
                        break;
                    }
                case MyCode.DocumentationBehavior.BrowserForAnVersion:
                    {
                        PdfViewerFactory("", null);
                        break;
                    }
                case MyCode.DocumentationBehavior.NoDocumentsExist:
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
                case MyCode.DocumentationBehavior.SpecifiedDocument:
                    {
                        SpecifiedDocumentProcess(e);
                        break;
                    }
                case MyCode.DocumentationBehavior.LastRevision:
                    {
                        LastRevisionProcess(e);
                        break;
                    }
                case MyCode.DocumentationBehavior.AllVersionsFound:
                    {
                        AllVersionsFoundProcess(e);
                        break;
                    }
                case MyCode.DocumentationBehavior.Last2Versions:
                    {
                        Last2VersionsProcess(e);
                        break;
                    }
                case MyCode.DocumentationBehavior.BrowserForAnVersion:
                    {
                        BrowserForAnVersionProcess(e);
                        break;
                    }
                case MyCode.DocumentationBehavior.NoDocumentsExist:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// if DataSheet_File column contains a file name out ext, hire we add
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

            foreach (DocumentsAddressItem documentsAddressItem in CurrentDepartmentLogIn.DepartmentDocumentsAddressItems)
            {
                if (!Directory.Exists(documentsAddressItem.DocumentsAddressValueDirectory))
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Not a valid Directory " +
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
                MessagePositionString = "var documentViewer = new Pdf_explorer";
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
                        MessageBox.Show(form, @"Break code at position " + MessagePositionString +
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
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Number of files founded " +
                                                      (_indexOpenedPdfDocuments + 1) + ", " + pathRootFolder +
                                                      @"\" + fileNameToMatch + fileExtToMatch.Replace("*", ""),
                                                      MyStuff11net.Properties.Resources.OK));
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
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("The file name " + e.DataSheet + " has an error " + ex.Message, Resources.ErrorIcon));
            }
        }

        #endregion"DocumentationBehaviorProcessor"

        #region"MouseKeyEventProvider"

        MyStuff11net.MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider _mouseKeyEventProvider;

        void Initialize_MouseKeyEventProvider()
        {
            _mouseKeyEventProvider = new MyStuff11net.MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider
            {
                Enabled = true,
                HookType = MyStuff11net.MouseKeyboardActivityMonitor.Controls.HookType.Global
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
                LogInProcess(e.BarcodeData);
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

        #region"Load Tables"

        /// <summary>
        /// Count the numbers of rows loaded by Fill process.
        /// </summary>
        int _rowLoaded;
        /// <summary>
        /// Mark the location if an error is found.
        /// </summary>
        string messageLocation = "";

        #region"BackgroundWorker_Load_Table_Labels_SMT"

        SQLiteConnection connectionTable_Labels_SMT;
        SQLiteDataAdapter adapterTable_Labels_SMT;

        void BackgroundWorker_Load_Table_Labels_SMT()
        {
            var backgroundWorker_LoadTableLabelsSMT = new BackgroundWorker { };
            backgroundWorker_LoadTableLabelsSMT.DoWork += BackgroundWorker_LoadTableLabels_SMT_DoWork;

            backgroundWorker_LoadTableLabelsSMT.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTableLabels_SMT_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Labels_SMT";
                connectionTable_Labels_SMT = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_Labels_SMT = new SQLiteDataAdapter(query, connectionTable_Labels_SMT);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_Labels_SMT);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_Labels_SMT.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_Labels_SMT.Fill(Production_InventoryDataSet.Table_Labels_SMT);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows loaded from Table_Labels_SMT", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Rows loaded from Table_Labels_SMT = " + _rowLoaded, Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Labels_SMT " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Labels_SMT"

        #region"BackgroundWorker_Load_Table_Stockroom"

        SQLiteConnection connectionTable_Stockroom;
        SQLiteDataAdapter adapterTable_Stockroom;

        void BackgroundWorker_Load_Table_Stockroom()
        {
            var backgroundWorker_LoadTableStockRoom = new BackgroundWorker { };
            backgroundWorker_LoadTableStockRoom.DoWork += BackgroundWorker_LoadTableStockRoom_DoWork;

            backgroundWorker_LoadTableStockRoom.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTableStockRoom_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_StockRoom ORDER BY PartNumber";
                connectionTable_Stockroom = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_Stockroom = new SQLiteDataAdapter(query, connectionTable_Stockroom);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_Stockroom);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_Stockroom.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_Stockroom.Fill(Production_InventoryDataSet.Table_StockRoom);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows loaded from Table_StockRoom", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Rows loaded from Table_StockRoom = " + _rowLoaded, Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_StockRoom " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Stockroom"

        #region"BackgroundWorker_Load_Table_StockroomTreeView"

        SQLiteConnection connectionTable_StockroomTreeView;
        SQLiteDataAdapter adapterTable_StockroomTreeView;

        void BackgroundWorker_Load_Table_StockroomTreeView()
        {
            var backgroundWorker_LoadTableStockroomTreeView = new BackgroundWorker { };
            backgroundWorker_LoadTableStockroomTreeView.DoWork += BackgroundWorker_LoadTableStockroomTreeView_DoWork;

            backgroundWorker_LoadTableStockroomTreeView.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTableStockroomTreeView_DoWork(Object? sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_StockRoom_TreeView ORDER BY \"ID\"";
                connectionTable_StockroomTreeView = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_StockroomTreeView = new SQLiteDataAdapter(query, connectionTable_StockroomTreeView);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_StockroomTreeView);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_StockroomTreeView.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_StockroomTreeView.Fill(Production_InventoryDataSet.Table_StockRoom_TreeView);
                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows loaded from Table_StockRoom_TreeView", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Rows loaded from Table_StockRoom_TreeView = " + _rowLoaded, Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_StockRoom_TreeView " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Stockroom"

        #region"BackgroundWorker_Load_Table_Marshall"

        SQLiteConnection connectionTable_Marshall;
        SQLiteDataAdapter adapterTable_Marshall;

        void BackgroundWorker_Load_Table_Marshall()
        {
            var backgroundWorker_LoadTableMarshall = new BackgroundWorker { };
            backgroundWorker_LoadTableMarshall.DoWork += BackgroundWorker_LoadTableMarshall_DoWork;

            backgroundWorker_LoadTableMarshall.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTableMarshall_DoWork(Object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Marshall";
                connectionTable_Marshall = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_Marshall = new SQLiteDataAdapter(query, connectionTable_Marshall);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_Marshall);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_Marshall.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_Marshall.Fill(Production_InventoryDataSet.Table_Marshall);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows loaded from Table_Marshall", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Rows loaded from Table_Marshall = " + _rowLoaded, Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Marshall " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Marshall"

        #region"BackgroundWorker_Load_Table_Marshall_TreeView"

        SQLiteConnection connectionTable_Marshall_TreeView;
        SQLiteDataAdapter adapterTable_Marshall_TreeView;

        void BackgroundWorker_Load_Table_Marshall_TreeView()
        {
            var backgroundWorker_LoadTableMarshall_TreeView = new BackgroundWorker { };
            backgroundWorker_LoadTableMarshall_TreeView.DoWork += BackgroundWorker_LoadTableMarshall_TreeView_DoWork;

            backgroundWorker_LoadTableMarshall_TreeView.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTableMarshall_TreeView_DoWork(Object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Marshall_TreeView ORDER BY \"Index\"";
                connectionTable_Marshall_TreeView = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_Marshall_TreeView = new SQLiteDataAdapter(query, connectionTable_Marshall_TreeView);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_Marshall_TreeView);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_Marshall_TreeView.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_Marshall_TreeView.Fill(Production_InventoryDataSet.Table_Marshall_TreeView);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows loaded from Table_Marshall_TreeView", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Rows loaded from Table_Marshall_TreeView = " + _rowLoaded, Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Marshall_TreeView " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Marshall_TreeView"

        #region"BackgroundWorker_Load_Table_Projections"

        SQLiteConnection connectionProjections;
        SQLiteDataAdapter adapterTable_Projects;

        void BackgroundWorker_Load_Table_Projections()
        {
            var backgroundWorker_LoadTableProjections = new BackgroundWorker { };
            backgroundWorker_LoadTableProjections.DoWork += Backgroundworker_LoadTableProjections_DoWork;

            backgroundWorker_LoadTableProjections.RunWorkerAsync();
        }

        void Backgroundworker_LoadTableProjections_DoWork(Object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Projects";
                connectionProjections = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_Projects = new SQLiteDataAdapter(query, connectionProjections);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_Projects);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_Projects.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_Projects.Fill(Production_InventoryDataSet.Table_Projects);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows loaded from Table_Projects", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Rows loaded from Table_Projects = " + _rowLoaded, Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Projects " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Projections"

        #region"BackgroundWorker_Load_Table_Employees"

        SQLiteConnection connectionTable_Employees;
        SQLiteDataAdapter adapterTable_Employees;

        void BackgroundWorker_Load_Table_Employees()
        {
            var backgroundWorker_LoadTable_Employees = new BackgroundWorker { };
            backgroundWorker_LoadTable_Employees.DoWork += BackgroundWorker_LoadTable_Employees_DoWork;

            backgroundWorker_LoadTable_Employees.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTable_Employees_DoWork(Object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Employees";
                connectionTable_Employees = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_Employees = new SQLiteDataAdapter(query, connectionTable_Employees);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_Employees);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_Employees.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_Employees.Fill(Production_InventoryDataSet.Table_Employees);
                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No rows loaded from Table_Employees", Resources.ErrorIcon));
                    return;
                }
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Rows loaded from Table_Employees = " + _rowLoaded, Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Employees " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Employees"

        #region"BackgroundWorker_Load_Table_EmployeesTreeView"

        SQLiteConnection connectionTable_EmployeesTreeView;
        SQLiteDataAdapter adapterTable_EmployeesTreeView;

        void BackgroundWorker_Load_Table_EmployeesTreeView()
        {
            var backgroundWorker_LoadTable_Employees_TreeView = new BackgroundWorker { };
            backgroundWorker_LoadTable_Employees_TreeView.DoWork += new DoWorkEventHandler(BackgroundWorker_LoadTable_EmployeesTreeView_DoWork);

            backgroundWorker_LoadTable_Employees_TreeView.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTable_EmployeesTreeView_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Employees_TreeView";
                connectionTable_EmployeesTreeView = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_EmployeesTreeView = new SQLiteDataAdapter(query, connectionTable_EmployeesTreeView);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_EmployeesTreeView);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_EmployeesTreeView.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_EmployeesTreeView.Fill(Production_InventoryDataSet.Table_Employees_TreeView);
                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No data found in Table_Employees_TreeView.", Resources.ErrorIcon));
                    return;
                }
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Table_Employees_TreeView loaded with " + _rowLoaded + " rows.", Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Employees_TreeView " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Employees_TreeView"

        #region"BackgroundWorker_Load_Table_Locations"

        SQLiteConnection connectionTable_Locations;
        SQLiteDataAdapter adapterTable_Locations;

        void BackgroundWorker_Load_TableLocations()
        {
            var backgroundWorker_LoadTableLocations = new BackgroundWorker { };
            backgroundWorker_LoadTableLocations.DoWork += BackGroundWorker_Load_TableLocations_DoWork;

            backgroundWorker_LoadTableLocations.RunWorkerAsync();
        }

        void BackGroundWorker_Load_TableLocations_DoWork(Object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Locations";
                connectionTable_Locations = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_Locations = new SQLiteDataAdapter(query, connectionTable_Locations);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_Locations);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_Locations.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_Locations.Fill(Production_InventoryDataSet.Table_Locations);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No data found in Table_Locations.", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Table_Locations loaded with " + _rowLoaded + " rows.", Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Locations " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Locations"

        #region"BackgroundWorker_Load_Table_LocationsTreeView"

        SQLiteConnection connectionTable_LocationsTreeView;
        SQLiteDataAdapter adapterTable_LocationsTreeView;

        void BackGroundWorker_Load_TableLocationsTreeView()
        {
            var backgroundWorker_LoadTableLocationsTreeView = new BackgroundWorker { };
            backgroundWorker_LoadTableLocationsTreeView.DoWork += BackGroundWorker_Load_TableLocationsTreeView_DoWork;

            backgroundWorker_LoadTableLocationsTreeView.RunWorkerAsync();
        }

        void BackGroundWorker_Load_TableLocationsTreeView_DoWork(Object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Locations_TreeView";
                connectionTable_LocationsTreeView = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_LocationsTreeView = new SQLiteDataAdapter(query, connectionTable_LocationsTreeView);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_LocationsTreeView);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_LocationsTreeView.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_LocationsTreeView.Fill(Production_InventoryDataSet.Table_Location_TreeView);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No data found in Table_Locations_TreeView.", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Table_Locations_TreeView loaded with " + _rowLoaded + " rows.", Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Locations_TreeView " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Locations"

        #region"BackgroundWorker_Load_Table_Components"

        SQLiteConnection connectionTable_Components;
        SQLiteDataAdapter adapterTable_Components;

        public void BackgroundWorker_Load_Table_Components()
        {
            var backgroundWorker_LoadTable_Components = new BackgroundWorker { };
            backgroundWorker_LoadTable_Components.DoWork += BackgroundWorker_LoadTable_Components_DoWork;

            backgroundWorker_LoadTable_Components.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTable_Components_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Components";
                connectionTable_Components = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_Components = new SQLiteDataAdapter(query, connectionTable_Components);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_Components);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_Components.UpdateCommand = scb.GetUpdateCommand();

                //  _rowLoaded = adapterTable_Components.Fill(Production_InventoryDataSet.table_);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No data found in Table_Components.", Resources.error_alert));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Table_Components loaded with " + _rowLoaded + " rows.", Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Components " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Components"

        #region"BackgroundWorker_Load_Table_Placements"

        SQLiteConnection connectionTable_Placements;
        SQLiteDataAdapter adapterTable_Placements;

        public void BackgroundWorker_Load_Table_Placements()
        {
            var backgroundWorker_LoadTable_Placements = new BackgroundWorker { };
            backgroundWorker_LoadTable_Placements.DoWork += BackgroundWorker_LoadTable_Placements_DoWork;

            backgroundWorker_LoadTable_Placements.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTable_Placements_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Placements";
                connectionTable_Placements = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_Placements = new SQLiteDataAdapter(query, connectionTable_Placements);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_Placements);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_Placements.UpdateCommand = scb.GetUpdateCommand();

                //    _rowLoaded = adapterTable_Placements.Fill(Production_InventoryDataSet.Table_);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No data found in Table_Placements.", Resources.ErrorIcon));
                    return;
                }
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Table_Placements loaded with " + _rowLoaded + " rows.", Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Placements " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_Placements"

        #region"BackgroundWorker_Load_Table_Projects_TreeView"

        SQLiteConnection connectionTable_ProjectsTreeView;
        SQLiteDataAdapter adapterTable_ProjectsTreeView;

        public void BackgroundWorker_Load_Table_Projects_TreeView()
        {
            var backgroundWorker_LoadTable_Projects_TreeView = new BackgroundWorker { };

            backgroundWorker_LoadTable_Projects_TreeView.WorkerReportsProgress = false;

            backgroundWorker_LoadTable_Projects_TreeView.DoWork += BackgroundWorker_LoadTable_Projects_TreeView_DoWork;
            backgroundWorker_LoadTable_Projects_TreeView.RunWorkerCompleted += BackgroundWorker_LoadTable_Projects_TreeView_RunWorkerCompleted;

            backgroundWorker_LoadTable_Projects_TreeView.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTable_Projects_TreeView_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_Projects_TreeView";
                connectionTable_ProjectsTreeView = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_ProjectsTreeView = new SQLiteDataAdapter(query, connectionTable_ProjectsTreeView);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_ProjectsTreeView);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_ProjectsTreeView.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_ProjectsTreeView.Fill(Production_InventoryDataSet.Table_Projects_TreeView);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No data found in Table_Projects_TreeView.", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Table_Projects_TreeView loaded with " + _rowLoaded + " rows.", Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Projects_TreeView " + errors.Message, Resources.ErrorIcon));
            }
        }

        void BackgroundWorker_LoadTable_Projects_TreeView_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //InitializeCurrentProjectsList();
        }

        #endregion"BackgroundWorker_Load_Table_Projects_TreeView"

        #region"BackgroundWorker_Load_Table_TimeLine"

        SQLiteConnection connectionTable_TimeLine;
        SQLiteDataAdapter adapterTable_TimeLine;
        public void BackgroundWorker_Load_Table_TimeLine()
        {
            var backgroundWorker_LoadTable_TimeLine = new BackgroundWorker { };
            backgroundWorker_LoadTable_TimeLine.DoWork += BackgroundWorker_LoadTable_TimeLine_DoWork;

            backgroundWorker_LoadTable_TimeLine.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTable_TimeLine_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_TimeLine";
                connectionTable_TimeLine = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_TimeLine = new SQLiteDataAdapter(query, connectionTable_TimeLine);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_TimeLine);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_TimeLine.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_TimeLine.Fill(Production_InventoryDataSet.Table_TimeLine);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No data found in Table_TimeLine.", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Table_TimeLine loaded with " + _rowLoaded + " rows.", Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading TimeLine " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_TimeLine"

        #region"BackgroundWorker_Load_Table_TimeLine_TreeView"

        SQLiteConnection connectionTable_TimeLineTreeView;
        SQLiteDataAdapter adapterTable_TimeLineTreeView;
        public void BackgroundWorker_Load_Table_TimeLineTreeView()
        {
            var backgroundWorker_LoadTable_TimeLineTreeView = new BackgroundWorker { };
            backgroundWorker_LoadTable_TimeLineTreeView.DoWork += BackgroundWorker_LoadTable_TimeLineTreeView_DoWork;

            backgroundWorker_LoadTable_TimeLineTreeView.RunWorkerAsync();
        }

        void BackgroundWorker_LoadTable_TimeLineTreeView_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = "SELECT * FROM Table_TimeLine_TreeView";
                connectionTable_TimeLineTreeView = new SQLiteConnection(Settings.Default.DataBaseConnectionStringSQLite);
                adapterTable_TimeLineTreeView = new SQLiteDataAdapter(query, connectionTable_TimeLineTreeView);
                SQLiteCommandBuilder scb = new SQLiteCommandBuilder(adapterTable_TimeLineTreeView);
                scb.ConflictOption = ConflictOption.OverwriteChanges;
                adapterTable_TimeLineTreeView.UpdateCommand = scb.GetUpdateCommand();

                _rowLoaded = adapterTable_TimeLineTreeView.Fill(Production_InventoryDataSet.Table_TimeLine_TreeView);

                if (_rowLoaded == 0)
                {
                    StatusBarMessage(new object(), new StatusBarMessage_EventArgs("No data found in Table_TimeLine_TreeView.", Resources.ErrorIcon));
                    return;
                }

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Table_TimeLine_TreeView loaded with " + _rowLoaded + " rows.", Resources.OK));
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading TimeLineTreeView " + errors.Message, Resources.ErrorIcon));
            }
        }

        #endregion"BackgroundWorker_Load_Table_TimeLine"

        #endregion"Load Tables"

        #region"BackgroundWorker_FixOnAvailable"

        BackgroundWorker BackgroundWorker_FixOnAvailable;
        void FixOnAvailable()
        {
            BackgroundWorker_FixOnAvailable = new BackgroundWorker { };

            BackgroundWorker_FixOnAvailable.WorkerReportsProgress = true;

            BackgroundWorker_FixOnAvailable.DoWork += BackgroundWorker_FixOnAvailable_DoWork;
            BackgroundWorker_FixOnAvailable.ProgressChanged += BackgroundWorker_FixOnAvailable_ProgressChanged;
            BackgroundWorker_FixOnAvailable.RunWorkerCompleted += BackgroundWorker_FixOnAvailable_RunWorkerCompleted;

            BackgroundWorker_FixOnAvailable.RunWorkerAsync();
        }

        void BackgroundWorker_FixOnAvailable_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _bindingSource_StockRoom.SuspendBinding();

                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate (object o, EventArgs ee)
                    {
                        int count = 0;
                        foreach (DataRow stockroomRow in Production_InventoryDataSet.Table_StockRoom)
                        {
                            stockroomRow.BeginEdit();

                            stockroomRow["OnHoldBy"] = MyCode.Get_String(stockroomRow["OnHoldBy"].ToString());

                            stockroomRow["OnHand"] = MyCode.Get_Value(stockroomRow["OnHand"].ToString());
                            stockroomRow["OnHold"] = MyCode.Get_Value(stockroomRow["OnHold"].ToString());
                            stockroomRow["OnAvailable"] = MyCode.Get_Value(stockroomRow["OnAvailable"].ToString());

                            stockroomRow.AcceptChanges();

                            if ((int)stockroomRow["OnHold"] == 0)
                            {
                                stockroomRow["OnAvailable"] = stockroomRow["OnHand"];
                            }
                            else
                            {
                                int value = ((int)stockroomRow["OnHand"]) - ((int)stockroomRow["OnHold"]);

                                if (value < 0)
                                    value = 0;

                                stockroomRow["OnAvailable"] = value;
                            }

                            count++;
                            stockroomRow.EndEdit();
                            BackgroundWorker_FixOnAvailable.ReportProgress(count, stockroomRow);
                        }

                        _bindingSource_StockRoom.ResumeBinding();

                    }));
                }
                else
                {
                    int count = 0;
                    foreach (DataRow stockroomRow in Production_InventoryDataSet.Table_StockRoom)
                    {
                        stockroomRow.BeginEdit();

                        stockroomRow["OnHoldBy"] = MyCode.Get_String(stockroomRow["OnHoldBy"].ToString());

                        stockroomRow["OnHand"] = MyCode.Get_Value(stockroomRow["OnHand"].ToString());
                        stockroomRow["OnHold"] = MyCode.Get_Value(stockroomRow["OnHold"].ToString());
                        stockroomRow["OnAvailable"] = MyCode.Get_Value(stockroomRow["OnAvailable"].ToString());

                        stockroomRow.AcceptChanges();

                        if ((int)stockroomRow["OnHold"] == 0)
                        {
                            stockroomRow["OnAvailable"] = stockroomRow["OnHand"];
                        }
                        else
                        {
                            int value = ((int)stockroomRow["OnHand"]) - ((int)stockroomRow["OnHold"]);

                            if (value < 0)
                                value = 0;

                            stockroomRow["OnAvailable"] = value;
                        }

                        count++;
                        stockroomRow.EndEdit();
                        BackgroundWorker_FixOnAvailable.ReportProgress(count, stockroomRow);
                    }

                    _bindingSource_StockRoom.ResumeBinding();
                }
            }
            catch (ThreadAbortException)
            {
                // Write log message.
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs(string.Format("Channel Aborted !!!, The {0} is destroyed and stopped at {1:F}",
                                                                                    Thread.CurrentThread.Name, DateTime.Now)));
            }
        }

        void BackgroundWorker_FixOnAvailable_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DataRow _row = (DataRow)e.UserState;
            StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Fixing OnAvailable column, PartNumber " + _row["PartNumber"].ToString() + ", row : " +
                                                         e.ProgressPercentage + " of " + _bindingSource_StockRoom.Count));
        }

        void BackgroundWorker_FixOnAvailable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fixOnAvailableToolStripMenuItem.Enabled = true;
            StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Fixing OnAvailable column, end."));
        }

        #endregion"BackgroundWorker_FixOnAvailable"

        #region"BackgroundWorkerFillByLastAccessTime"
        /// <summary>
        /// Pass DateTime value to backgroundWorker.
        /// </summary>
        DateTime LastAccessTime;
        BackgroundWorker BackgroundWorkerFillByLastAccessTime;

        void InitializeBackgroundWorkerFillByLastAccessTime()
        {
            LastAccessTime = DateTime.Now;
            BackgroundWorkerFillByLastAccessTime = new BackgroundWorker { };

            BackgroundWorkerFillByLastAccessTime.DoWork += BackgroundWorkerFillByLastAccessTime_DoWork;
            BackgroundWorkerFillByLastAccessTime.RunWorkerCompleted += BackgroundWorkerFillByLastAccessTime_RunWorkerCompleted;

            // BackgroundWorkerFillByLastAccessTime.RunWorkerAsync();
        }

        void BackgroundWorkerFillByLastAccessTime_DoWork(Object sender, DoWorkEventArgs e)
        {
            try
            {
                using SQLiteConnection connection = new(Settings.Default.DataBaseConnectionStringSQLite);
                connection.Open();

            //    _rowLoaded = adapterTable_Stockroom.FillByLastAccessTime(
            //        Production_InventoryDataSet.Table_StockRoom, LastAccessTime.AddMinutes(-5d));

                connection.Close();
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_StockRoom by LastAccessTime. " + errors.Message, Resources.ErrorIcon));
            }
        }

        void BackgroundWorkerFillByLastAccessTime_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Finished loading table StockRoom by LastAccessTime... Rows loaded = " + _rowLoaded));
        }

        #endregion"BackgroundWorkerFillByLastAccessTime"

        #region"InitEasyProgressBar_FixOnAvailable"

        /// <summary>
        /// Text message to be show into easyProgressBar.
        /// it self cleen when the time up.
        /// </summary>
        Thread progressThread_FixOnAvailable;
        bool isProgressStarted_FixOnAvailable;
        //   EasyProgressBar.EasyProgressBar easyProgressBar_FixOnAvailable;

        void InitEasyProgressBar_FixOnAvailables()
        {
            /*
            easyProgressBar_FixOnAvailable = new EasyProgressBar.EasyProgressBar();

            easyProgressBar_FixOnAvailable.BackColor = System.Drawing.SystemColors.Window;
            easyProgressBar_FixOnAvailable.BackgroundGradient.ColorStart = System.Drawing.Color.White;
            easyProgressBar_FixOnAvailable.BackgroundGradient.IsBlendedForBackground = true;
            easyProgressBar_FixOnAvailable.BorderColor = System.Drawing.Color.Gray;
            easyProgressBar_FixOnAvailable.DigitBoxGradient.BorderColor = System.Drawing.Color.Silver;
            easyProgressBar_FixOnAvailable.DigitBoxGradient.ColorEnd = System.Drawing.Color.AntiqueWhite;
            easyProgressBar_FixOnAvailable.DigitBoxGradient.ColorStart = System.Drawing.Color.White;
            easyProgressBar_FixOnAvailable.DigitBoxGradient.IsBlendedForBackground = true;
            easyProgressBar_FixOnAvailable.DisplayFormat = "";
            easyProgressBar_FixOnAvailable.Font = new Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            easyProgressBar_FixOnAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            easyProgressBar_FixOnAvailable.IsDigitDrawEnabled = false;
            easyProgressBar_FixOnAvailable.Location = new Point(((ClientSize.Width / 2) - 300), ((ClientSize.Height / 2) + 30));
            easyProgressBar_FixOnAvailable.Name = nameof(easyProgressBar_FixOnAvailable);
            easyProgressBar_FixOnAvailable.ProgressColorizer.Alpha = ((byte)(113));
            easyProgressBar_FixOnAvailable.ProgressColorizer.Blue = ((byte)(140));
            easyProgressBar_FixOnAvailable.ProgressColorizer.Green = ((byte)(200));
            easyProgressBar_FixOnAvailable.ProgressColorizer.Red = ((byte)(230));
            easyProgressBar_FixOnAvailable.ProgressGradient.ColorEnd = System.Drawing.Color.Wheat;
            easyProgressBar_FixOnAvailable.ProgressGradient.ColorStart = System.Drawing.Color.WhiteSmoke;
            easyProgressBar_FixOnAvailable.ProgressGradient.IsBlendedForProgress = true;
            easyProgressBar_FixOnAvailable.Size = new Size(600, 65);
            easyProgressBar_FixOnAvailable.TabIndex = 0;
            easyProgressBar_FixOnAvailable.Text = "40% ";
            easyProgressBar_FixOnAvailable.Value = 40;
            easyProgressBar_FixOnAvailable.DockUndockProgressBar = false;
            easyProgressBar_FixOnAvailable.Visible = false;
            easyProgressBar_FixOnAvailable.EasyProgressBarClosing += easyProgressBar_Reset_OnHoldBy_EasyProgressBarClosing;
            */
        }

        // Starts or stops the current progressThread.
        void Start_easyProgressBar_FixOnAvailables(object? sender, EventArgs e)
        {
            /*
            if (!isProgressStarted_FixOnAvailable)
            {
                easyProgressBar_FixOnAvailable.TextMessage = "Fixing OnAvailable column.";
                easyProgressBar_FixOnAvailable.Visible = true;
                easyProgressBar_FixOnAvailable.Focus();
                easyProgressBar_FixOnAvailable.Value = 0;
                easyProgressBar_FixOnAvailable.Maximum = _bindingSource_StockRoom.Count + 1;

                easyProgressBar_FixOnAvailable.ValueChanged += (thrower, ea) =>
                {
                    if (easyProgressBar_FixOnAvailable.Value == easyProgressBar_FixOnAvailable.Maximum)
                        isProgressStarted_FixOnAvailable = false;
                };

                progressThread_FixOnAvailable = new Thread(new ParameterizedThreadStart(ProgressChannel_FixOnAvailables));
                progressThread_FixOnAvailable.Name = "ProgressBar_FixOnAvailable thread";
                progressThread_FixOnAvailable.IsBackground = true;

                ParameterizedThreadClass pThread = new ParameterizedThreadClass(_bindingSource_StockRoom);
                progressThread_FixOnAvailable.Start(pThread);

                // Set new value.
                isProgressStarted_FixOnAvailable = true;

                // Write log message.
                //      status.Text = String.Format("Channel Started !!!, The {0} is started at {1:F}", progressThread.Name, DateTime.Now);

                // Update button text.
                //      button1.Text = "Stop";
            }
            else
            {
                if (progressThread_FixOnAvailable.IsAlive)
                {
                    easyProgressBar_FixOnAvailable.Visible = false;

                    // Tell the progressThread to abort itself immediately, raises a ThreadAbortException in the progressThread after calling the Thread.Join() method.
                    progressThread_FixOnAvailable.Abort();

                    // Wait for the progressThread to finish.
                    progressThread_FixOnAvailable.Join();

                    isProgressStarted_FixOnAvailable = false;

                    // Update button text.
                    //     button1.Text = "Resume Progress";
                }
            }
            */
        }

        void easyProgressBar_FixOnAvailables_EasyProgressBarClosing(object? sender, out bool cancel)
        {
            if (MessageBox.Show("Do you want to close the control window?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                cancel = true;
            else
                cancel = false;
        }

        void ProgressChannel_FixOnAvailables(object instance)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate (object o, EventArgs ee)
                    {
                        int count = 0;
                        foreach (DataRow stockroomRow in Production_InventoryDataSet.Table_StockRoom)
                        {
                            stockroomRow.BeginEdit();

                            stockroomRow["OnHoldBy"] = MyCode.Get_String(stockroomRow["OnHoldBy"].ToString());

                            stockroomRow["OnHand"] = MyCode.Get_Value(stockroomRow["OnHand"].ToString());
                            stockroomRow["OnHold"] = MyCode.Get_Value(stockroomRow["OnHold"].ToString());
                            stockroomRow["OnAvailable"] = MyCode.Get_Value(stockroomRow["OnAvailable"].ToString());

                            if ((Int32)stockroomRow["OnHold"] == 0)
                            {
                                stockroomRow["OnAvailable"] = stockroomRow["OnHand"];
                            }
                            else
                            {
                                Int32 value = ((Int32)stockroomRow["OnHand"]) - ((Int32)stockroomRow["OnHold"]);

                                if (value < 0)
                                    value = 0;

                                stockroomRow["OnAvailable"] = value;
                            }

                            count++;
                            stockroomRow.EndEdit();
                            UpdateProgressBar_FixOnAvailables(count);
                        }

                        UpdateProgressBar_FixOnAvailables(_bindingSource_StockRoom.Count + 1);
                    }));
                }
                else
                {
                    int count = 0;
                    foreach (DataRow stockroomRow in Production_InventoryDataSet.Table_StockRoom)
                    {
                        stockroomRow.BeginEdit();

                        stockroomRow["OnHoldBy"] = MyCode.Get_String(stockroomRow["OnHoldBy"].ToString());

                        stockroomRow["OnHand"] = MyCode.Get_Value(stockroomRow["OnHand"].ToString());
                        stockroomRow["OnHold"] = MyCode.Get_Value(stockroomRow["OnHold"].ToString());
                        stockroomRow["OnAvailable"] = MyCode.Get_Value(stockroomRow["OnAvailable"].ToString());

                        if ((int)stockroomRow["OnHold"] == 0)
                        {
                            stockroomRow["OnAvailable"] = stockroomRow["OnHand"];
                        }
                        else
                        {
                            int value = ((int)stockroomRow["OnHand"]) - ((int)stockroomRow["OnHold"]);

                            if (value < 0)
                                value = 0;

                            stockroomRow["OnAvailable"] = value;
                        }

                        count++;
                        stockroomRow.EndEdit();
                        UpdateProgressBar_FixOnAvailables(count);
                    }

                    UpdateProgressBar_FixOnAvailables(_bindingSource_StockRoom.Count + 1);
                }
            }
            catch (Exception error)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error" + error.Message));
            }
        }

        void UpdateStatusBar_FixOnAvailables(string statusText)
        {
            //       status.Text = statusText;
        }

        void UpdateProgressBar_FixOnAvailables(int currentValue)
        {
            /*
            if (currentValue == _bindingSource_StockRoom.Count)
                Invoke(new EventHandler(easyProgressBar_FixOnAvailables_Hide));

            if (easyProgressBar_FixOnAvailable.InvokeRequired)
                easyProgressBar_FixOnAvailable.Invoke(new SetProgressValue(UpdateProgressBar_FixOnAvailables), new object[] { currentValue });
            else
            {
                easyProgressBar_FixOnAvailable.Value = currentValue;

            }
            */
        }

        void easyProgressBar_FixOnAvailables_Hide(object sender, EventArgs e)
        {
            //   easyProgressBar_FixOnAvailable.Hide();
            fixOnAvailableToolStripMenuItem.Enabled = true;
        }


        #region"Class ParameterizedThreadClass"

        class ParameterizedThreadClass
        {
            DataTable _tableComp;
            BindingSource _bindingsource;
            int minimum;
            int maximum;
            int progressValue;

            public ParameterizedThreadClass(DataTable tableComp)
            {
                _tableComp = tableComp;
            }

            public ParameterizedThreadClass(BindingSource bindingsource)
            {
                _bindingsource = bindingsource;
            }

            public ParameterizedThreadClass(BindingSource bindingsource, string usethis)
            {
                // No es buena idea, los datos solo se actualizan aqui.
                _tableComp = new DataTable();
                _tableComp.Columns.Add("PartNumber", typeof(string));
                _tableComp.Columns.Add("Component_Name", typeof(string));
                _tableComp.Columns.Add("Comp_for_Production", typeof(int));
                _tableComp.Columns.Add("Comp_On_Hand", typeof(int));
                _tableComp.Columns.Add("Status", typeof(string));

                foreach (object obj in bindingsource)
                {
                    DataRowView row = (DataRowView)obj;
                    DataRow newrow = _tableComp.NewRow();

                    newrow["PartNumber"] = row["PartNumber"];
                    newrow["Component_Name"] = row["Component_Name"];
                    newrow["Comp_for_Production"] = row["Comp_for_Production"];
                    newrow["Comp_On_Hand"] = row["Comp_On_Hand"];
                    newrow["Status"] = row["Status"];

                    _tableComp.Rows.Add(newrow);
                    newrow.AcceptChanges();
                    newrow.SetModified();
                    newrow.EndEdit();
                }

            }

            public ParameterizedThreadClass(int minimum, int maximum, int progressValue)
            {
                this.minimum = minimum;
                this.maximum = maximum;
                this.progressValue = progressValue;
            }

            public int Minimum
            {
                get { return minimum; }
            }

            public int Maximum
            {
                get { return maximum; }
            }

            public int ProgressValue
            {
                get { return progressValue; }
            }

            public DataTable TableComp
            {
                get { return _tableComp; }
            }

            public BindingSource BindingComp
            {
                get { return _bindingsource; }
            }

            public int RowCount
            {
                get
                {
                    if (_tableComp != null)
                        return _tableComp.Rows.Count;

                    return _bindingsource.Count;
                }
            }
        }

        #endregion"Class ParameterizedThreadClass"


        #endregion"InitEasyProgressBar_FixOnAvailable"

        #region"InitEasyProgressBar_Reset_OnHoldBy"

        /// <summary>
        /// Text message to be show into easyProgressBar.
        /// it self cleen when the time up.
        /// </summary>

        Thread progressThread_Reset_OnHoldBy;
        delegate void SetProgressValueReset_OnHoldBy(int value);
        //  EasyProgressBar.EasyProgressBar easyProgressBar_Reset_OnHoldBy;

        void InitEasyProgressBar_OnHoldBy()
        {
            /*
            easyProgressBar_Reset_OnHoldBy = new EasyProgressBar.EasyProgressBar();

            easyProgressBar_Reset_OnHoldBy.BackColor = System.Drawing.SystemColors.Window;
            easyProgressBar_Reset_OnHoldBy.BackgroundGradient.ColorStart = System.Drawing.Color.White;
            easyProgressBar_Reset_OnHoldBy.BackgroundGradient.IsBlendedForBackground = true;
            easyProgressBar_Reset_OnHoldBy.BorderColor = System.Drawing.Color.Gray;
            easyProgressBar_Reset_OnHoldBy.DigitBoxGradient.BorderColor = System.Drawing.Color.Silver;
            easyProgressBar_Reset_OnHoldBy.DigitBoxGradient.ColorEnd = System.Drawing.Color.AntiqueWhite;
            easyProgressBar_Reset_OnHoldBy.DigitBoxGradient.ColorStart = System.Drawing.Color.White;
            easyProgressBar_Reset_OnHoldBy.DigitBoxGradient.IsBlendedForBackground = true;
            easyProgressBar_Reset_OnHoldBy.DisplayFormat = "";
            easyProgressBar_Reset_OnHoldBy.Font = new Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            easyProgressBar_Reset_OnHoldBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            easyProgressBar_Reset_OnHoldBy.IsDigitDrawEnabled = false;
            easyProgressBar_Reset_OnHoldBy.Location = new Point(((ClientSize.Width / 2) - 300), ((ClientSize.Height / 2) + 30));
            easyProgressBar_Reset_OnHoldBy.Name = nameof(easyProgressBar_Reset_OnHoldBy);
            easyProgressBar_Reset_OnHoldBy.ProgressColorizer.Alpha = ((byte)(113));
            easyProgressBar_Reset_OnHoldBy.ProgressColorizer.Blue = ((byte)(140));
            easyProgressBar_Reset_OnHoldBy.ProgressColorizer.Green = ((byte)(200));
            easyProgressBar_Reset_OnHoldBy.ProgressColorizer.Red = ((byte)(230));
            easyProgressBar_Reset_OnHoldBy.ProgressGradient.ColorEnd = System.Drawing.Color.Wheat;
            easyProgressBar_Reset_OnHoldBy.ProgressGradient.ColorStart = System.Drawing.Color.WhiteSmoke;
            easyProgressBar_Reset_OnHoldBy.ProgressGradient.IsBlendedForProgress = true;
            easyProgressBar_Reset_OnHoldBy.Size = new Size(600, 65);
            easyProgressBar_Reset_OnHoldBy.TabIndex = 0;
            easyProgressBar_Reset_OnHoldBy.Text = "40% ";
            easyProgressBar_Reset_OnHoldBy.Value = 40;
            easyProgressBar_Reset_OnHoldBy.DockUndockProgressBar = false;
            easyProgressBar_Reset_OnHoldBy.Visible = false;
            easyProgressBar_Reset_OnHoldBy.EasyProgressBarClosing += easyProgressBar_Reset_OnHoldBy_EasyProgressBarClosing;
            */
        }

        // Starts or stops the current progressThread.
        void Start_easyProgressBar_Reset_OnHoldBy(object sender, EventArgs e)
        {
            /*
            if (progressThread_Reset_OnHoldBy.IsAlive)
            {
                easyProgressBar_Reset_OnHoldBy.Visible = false;

                // Tell the progressThread to abort itself immediately, raises a ThreadAbortException in the progressThread after calling the Thread.Join() method.
                progressThread_Reset_OnHoldBy.Abort();

                // Wait for the progressThread to finish.
                progressThread_FixOnAvailable.Join();

                isProgressStarted_FixOnAvailable = false;

                // Update button text.
                //     button1.Text = "Resume Progress";

                return;
            }

            easyProgressBar_Reset_OnHoldBy.TextMessage = "Fixing OnHoldBy column.";
            easyProgressBar_Reset_OnHoldBy.Visible = true;
            easyProgressBar_Reset_OnHoldBy.Focus();
            easyProgressBar_Reset_OnHoldBy.Value = 0;
            easyProgressBar_Reset_OnHoldBy.Maximum = _bindingSource_StockRoom.Count + 1;

            easyProgressBar_Reset_OnHoldBy.ValueChanged += (thrower, ea) =>
            {
                if (easyProgressBar_Reset_OnHoldBy.Value == easyProgressBar_Reset_OnHoldBy.Maximum)
                    isProgressStarted_FixOnAvailable = false;
            };

            progressThread_Reset_OnHoldBy = new Thread(new ParameterizedThreadStart(ProgressChannel_Reset_OnHoldBy));
            progressThread_Reset_OnHoldBy.Name = "ProgressBar_OnHoldBy thread";
            progressThread_Reset_OnHoldBy.IsBackground = true;

            ParameterizedThreadClass pThread = new ParameterizedThreadClass(_bindingSource_StockRoom);
            progressThread_Reset_OnHoldBy.Start(pThread);

            // Set new value.
            isProgressStarted_FixOnAvailable = true;

            // Write log message.
            //      status.Text = String.Format("Channel Started !!!, The {0} is started at {1:F}", progressThread.Name, DateTime.Now);

            // Update button text.
            //      button1.Text = "Stop";
            */
        }

        void easyProgressBar_Reset_OnHoldBy_EasyProgressBarClosing(object sender, out bool cancel)
        {
            if (MessageBox.Show("Do you want to close the control window?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                cancel = true;
            else
                cancel = false;
        }

        void ProgressChannel_Reset_OnHoldBy(object instance)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate (object o, EventArgs ee)
                    {
                        int count = 0;
                        foreach (DataRow stockroomRow in Production_InventoryDataSet.Table_StockRoom)
                        {
                            stockroomRow.BeginEdit();

                            stockroomRow["OnHoldBy"] = "";  // MyCode.Get_String(stockroomRow["OnHoldBy"].ToString());

                            stockroomRow["OnHand"] = MyCode.Get_Value(stockroomRow["OnHand"].ToString());
                            stockroomRow["OnHold"] = 0;     // MyCode.Get_Value(stockroomRow["OnHold"].ToString());
                            stockroomRow["OnAvailable"] = MyCode.Get_Value(stockroomRow["OnAvailable"].ToString());

                            count++;
                            stockroomRow.EndEdit();
                            UpdateProgressBar_Reset_OnHoldBy(count);
                        }

                        UpdateProgressBar_Reset_OnHoldBy(_bindingSource_StockRoom.Count + 1);
                    }));
                }
                else
                {
                    int count = 0;
                    foreach (DataRow stockroomRow in Production_InventoryDataSet.Table_StockRoom)
                    {
                        stockroomRow.BeginEdit();

                        stockroomRow["OnHoldBy"] = "";  // MyCode.Get_String(stockroomRow["OnHoldBy"].ToString());

                        stockroomRow["OnHand"] = MyCode.Get_Value(stockroomRow["OnHand"].ToString());
                        stockroomRow["OnHold"] = 0;     // MyCode.Get_Value(stockroomRow["OnHold"].ToString());
                        stockroomRow["OnAvailable"] = MyCode.Get_Value(stockroomRow["OnAvailable"].ToString());

                        count++;
                        stockroomRow.EndEdit();
                        UpdateProgressBar_Reset_OnHoldBy(count);
                    }

                    UpdateProgressBar_Reset_OnHoldBy(_bindingSource_StockRoom.Count + 1);
                }
            }
            catch (Exception error)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error" + error.Message));
            }
        }

        void UpdateStatusBar_Reset_OnHoldBy(string statusText)
        {
            //       status.Text = statusText;
        }

        void UpdateProgressBar_Reset_OnHoldBy(int currentValue)
        {
            /*
            if (currentValue == _bindingSource_StockRoom.Count)
                Invoke(new EventHandler(easyProgressBar_Reset_OnHoldBy_Hide));

            if (easyProgressBar_Reset_OnHoldBy.InvokeRequired)
                easyProgressBar_Reset_OnHoldBy.Invoke(new SetProgressValue(UpdateProgressBar_Reset_OnHoldBy), new object[] { currentValue });
            else
            {
                easyProgressBar_Reset_OnHoldBy.Value = currentValue;

            }
            */
        }

        void easyProgressBar_Reset_OnHoldBy_Hide(object sender, EventArgs e)
        {
            //  easyProgressBar_Reset_OnHoldBy.Hide();
            fixOnAvailableToolStripMenuItem.Enabled = true;
        }



        #endregion"InitEasyProgressBar_Reset_OnHoldBy"

        #region"InitializeThreadTimer Check status table. Notifications"

        System.Threading.Timer timerCheckStatusTable;

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

                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Status at" + messageLocation + " " + errors.Message));
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

                    messageLocation = "switch (MyCode.NotifycationEvents)";
                    switch (notification.Value.NotifycationEvents)
                    {
                        case MyCode.NotificationEvents.Warning:
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
                        case MyCode.NotificationEvents.RowInformationChange:
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
                        case MyCode.NotificationEvents.DataBaseUpDated:
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
                                    if (BackgroundWorkerFillByLastAccessTime.IsBusy)
                                        return;

                                    LastAccessTime = notification.Value.DateCreated;
                                    BackgroundWorkerFillByLastAccessTime.RunWorkerAsync();
                                }

                                break;
                            }
                        case MyCode.NotificationEvents.Email:
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
                newProject["Created_by"] = _currentEmployeesLogIn.Name;
                newProject[nameof(Properties)] = "";
                newProject["Message_String"] = "";
                newProject["Status"] = "Open";

                newProject.EndEdit();

                _bindingSource_Status.EndEdit();

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

            StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Process notifications has been stoped."));
        }
        void EmergencyCheckStatus(object obj)
        {
            StartThreadTimerCheckStatusTable();
            StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Process notification restarted."));
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
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Stopped process Saved by timer..."));
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
                    StockRoom_ProcessSaveRequest(new object(), new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
                }
            }
            catch (Exception errors)
            {
                StatusBarMessage(new object(), new StatusBarMessage_EventArgs("Error loading Table_Status at" + errors.Message, Resources.ErrorIcon));
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
                var logFileNme = CurrentDepartmentLogIn.DeptName + " " + DateTime.Now.ToString("dddd, dd-MM-yy") + ".html";
                var deptNameMonth = CurrentDepartmentLogIn.DeptName + "\\" + DateTime.Now.ToString("MMMM");
                var logFilePath_Name = Path.Combine(Settings.Default.DataBaseAddress + "\\LogFile\\" + deptNameMonth, logFileNme);
                var templeFilePath_Name = Settings.Default.DataBaseAddress + "\\Resources\\HTML pages\\LogFileTemple.html";

                _processLogFile = new LogFileProcess(logFilePath_Name, templeFilePath_Name, MyCode.HTMLFileTemple.Application);
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

        List<FileSystemWatcherAgent> FileSystemWatcherAgentList = new List<FileSystemWatcherAgent>();

        void InitializeFileSystemWatcher(DepartmentInformation departLogin)
        {
            FileSystemWatcherAgentList.Clear();

            foreach (ScanDocumentsAddressItem documentAddressItem in departLogin.DepartmentScanDocumentsAddressItems)
            {
                var scanPath = documentAddressItem.ScanDocumentsAddressValueDirectory;

                if (!Directory.Exists(scanPath))
                    continue;

                var watchAgent = new FileSystemWatcherAgent(scanPath);

                watchAgent.FileCreated += WatchAgent_FileCreated;
                watchAgent.FileDeleted += WatchAgent_FileDeleted;
                watchAgent.FileRenamed += WatchAgent_FileRenamed;
                watchAgent.FileHasChanged += WatchAgent_FileHasChanged;
                watchAgent.DirectoryRenamed += WatchAgent_DirectoryRenamed;

                FileSystemWatcherAgentList.Add(watchAgent);
            }
        }

        private void WatchAgent_FileCreated(object sender, System.IO.FileSystemEventArgs e)
        {
            InvokeOnUiThreadIfRequired(this, () => Text = "File has been created -> " + e.FullPath);
        }

        private void WatchAgent_DirectoryRenamed(object sender, System.IO.RenamedEventArgs e)
        {
            InvokeOnUiThreadIfRequired(this, () => Text = "Directory has been renamed -> " + e.FullPath);
        }

        private void WatchAgent_FileDeleted(object sender, System.IO.FileSystemEventArgs e)
        {
            InvokeOnUiThreadIfRequired(this, () => Text = "File has been deleted -> " + e.FullPath);
        }

        private void WatchAgent_FileRenamed(object sender, System.IO.RenamedEventArgs e)
        {
            InvokeOnUiThreadIfRequired(this, () => Text = "File has been renamed -> " + e.FullPath);
        }

        void WatchAgent_FileHasChanged(object sender, System.IO.FileSystemEventArgs e)
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
            _bindingSource_ProjectsTreeView.SuspendBinding();

            /*
                        Parallel.ForEach(LastScan, item =>
                        {
                            // Creo new DataRowView front la tabla.
                            DataRowView projectRow = (DataRowView)_bindingSource_ProjectsTreeView.AddNew();

                            projectRow["Index"] = item.ID;
                            projectRow["ID"] = item.ID;

                            if (item.Parent_ID == null)
                                projectRow["Parent_ID"] = DBNull.Value;
                            else
                                projectRow["Parent_ID"] = item.Parent_ID;

                            projectRow["ProjectName"] = item.ProjectName;
                            projectRow["Text_Name"] = item.Text_Name;
                            projectRow["ItemOpen"] = item.ExistThumbs;

                            projectRow["Image"] = item.Image;
                            projectRow["Description_Short"] = item.Description_Short;
                            projectRow["Description_Expand"] = item.Description_Expand;

                            projectRow["ItemCount"] = 0;

                            projectRow.EndEdit();

                        });*/


            foreach (FileDirectoryModel item in LastScan)
            {
                // Creo new DataRowView front la tabla.
                DataRowView projectRow = (DataRowView)_bindingSource_ProjectsTreeView.AddNew();

                projectRow["Index"] = item.ID;
                projectRow["ID"] = item.ID;

                if (item.Parent_ID == null)
                    projectRow["Parent_ID"] = DBNull.Value;
                else
                    projectRow["Parent_ID"] = item.Parent_ID;

                projectRow["ProjectName"] = item.ProjectName;
                projectRow["Text_Name"] = item.Text_Name;
                projectRow["ItemOpen"] = item.ExistThumbs;

                projectRow["Image"] = item.Image;
                projectRow["Description_Short"] = item.Description_Short;
                projectRow["Description_Expand"] = item.Description_Expand;

                projectRow["ItemCount"] = 0;

                projectRow.EndEdit();

                if (item.ExistThumbs)
                    countThumbs++;

                StatusBarHelp("Rows " + item.ID + " " + countThumbs);
            }

            _bindingSource_ProjectsTreeView.EndEdit();
            _bindingSource_ProjectsTreeView.ResumeBinding();

            _projectViewer_Save_Requested(new object(), new EventArgs());

            BackgroundWorker_Load_Table_Projects_TreeView();
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
                if (MyCode.IsFileLocked(ex))
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


using MyStuff11net;
using MyStuff11net.DataGridViewExtend;
using System.ComponentModel;
using System.Data;
using WinFormsUI.Docking;
using ActiveDataSheet_EventArgs = MyStuff11net.Custom_Events_Args.ActiveDataSheet_EventArgs;
using CellDoubleClick_EventArgs = MyStuff11net.Custom_Events_Args.CellDoubleClick_EventArgs;
using CurrentDeptUserBroadcast_EventArgs = MyStuff11net.Custom_Events_Args.CurrentDeptUserBroadcast_EventArgs;
using CurrentStatus = MyStuff11net.CurrentStatus;
using DepartmentInformation = MyStuff11net.DepartmentInformation;
using Employee = MyStuff11net.Employee;
using LogFileMessageEventArgs = MyStuff11net.Custom_Events_Args.LogFileMessageEventArgs;
using MyCode = MyStuff11net.MyCode;
using Need_SaveData_EventArgs = MyStuff11net.Custom_Events_Args.Need_SaveData_EventArgs;
using Notification = MyStuff11net.Notification;
using Refresh_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Refresh_Requested_EventArgs;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;
using SaveSettingEventArgs = MyStuff11net.Custom_Events_Args.SaveSettingEventArgs;
using SpeechSynthesizerBase_EventArgs = MyStuff11net.Custom_Events_Args.SpeechSynthesizerBase_EventArgs;
using SpeechSynthesizerBase_EventHandler = MyStuff11net.Custom_Events_Args.SpeechSynthesizerBase_EventHandler;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;
using TreeViewUpdateEventArgs = MyStuff11net.Custom_Events_Args.TreeViewUpdateEventArgs;


namespace StockRoom11net
{
    /// <summary>
    /// This is the base class for applications, these develop one aim, one purpose,
    /// example: Stockroom Inventory, Stockroom Received.
    /// </summary>
    public partial class BaseTemple : DockContent
    {
        public BaseTemple()
        {
            try
            {
                MessagePositionString = "constructor method";
                InitializeComponent();

                AutoScaleMode = AutoScaleMode.Dpi;
                DockAreas = DockAreas.Document | DockAreas.Float;

                Controls.Remove(richTextBox1);
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message,
                                          @"BaseTemple has generated an error at " + MessagePositionString,
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string m_fileName = string.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FileName
        {
            get { return m_fileName; }
            set
            {
                if (value != string.Empty)
                {
                    Stream s = new FileStream(value, FileMode.Open);

                    FileInfo efInfo = new FileInfo(value);

                    string fext = efInfo.Extension.ToUpper();

                    if (fext.Equals(".RTF"))
                        richTextBox1.LoadFile(s, RichTextBoxStreamType.RichText);
                    else
                        richTextBox1.LoadFile(s, RichTextBoxStreamType.PlainText);
                    s.Close();
                }

                m_fileName = value;
                this.ToolTipText = value;
            }
        }

        protected override string GetPersistString()
        {
            // Add extra information into the persist string for this document
            // so that it is available when deserialized.
            return GetType().ToString() + "," + FileName + "," + Text;
        }

        #region"Public Properties"

        public List<string> DepartList = new List<string>();
        public List<DepartmentInformation> ListDepartments = new List<DepartmentInformation>();
        public DataGridViewExtended dataGridViewExtendedBase = new DataGridViewExtended();
        public ThumbViewer thumbViewerBasePictures = new ThumbViewer();
        public ThumbViewer thumbViewerBaseLocation = new ThumbViewer();
        public BindingSource BindingSourceTreeViewBase = new BindingSource();
        public CurrentStatus CurrentStatusReference = new CurrentStatus();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get
            {
                return Text;
            }
            set
            {
                Text = $"{Application.ProductName} - {value}";
            }
        }

        #endregion"Public Properties"

        #region"Properties, Custom Control Properties"

        /// <summary>
        /// Specifies the custom string filter, formatted as, ColumnName LIKE ''
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint),
         Category("Custom Properties"),
         DefaultValue(""),
         Description("Receive Process, will open Receive Control in mode 'Receive'.")]
        public CellDoubleClick_EventArgs Received_CellDoubleClickEvent
        {
            set
            {
                if (value == null)
                    return;

                if (value.ComponentInformations.SeletedComponentName == null)
                    return;

                //      _partNumberTag = value.ComponentInformations.PartNumberTag;

                switch (value.ProcessInfor)
                {
                    case MyCode.ProcessMode.AddNew:
                        {
                            ProcessInput(value, MyCode.ProcessMode.AddNew);
                            break;
                        }
                    case MyCode.ProcessMode.Receive:
                        {
                            ProcessInput(value, MyCode.ProcessMode.Receive);
                            break;
                        }

                    case MyCode.ProcessMode.Adjust:
                        {
                            ProcessInput(value, MyCode.ProcessMode.Adjust);
                            break;
                        }
                    default:
                        {

                            break;
                        }
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint),
         Category("Custom Properties"),
         DefaultValue(false),
         Description("Input event front bindingsource.bindingcompleted.")]
        public BindingCompleteEventArgs BindingCompleted
        {
            set
            {
                if (value.BindingCompleteState == BindingCompleteState.Success)
                    if (value.BindingCompleteContext == BindingCompleteContext.ControlUpdate)
                        dataGridViewExtendedBase.BindingCompleted = true;
            }
        }

        public bool _needSaveData;
        [Category("DataView Properties"),
         DefaultValue(true),
         Description("Specifies if the customer need save data.")]
        public bool NeedSaveData
        {
            get
            {
                return _needSaveData;
            }
            set
            {
                _needSaveData = value;
                On_Need_SaveData(new Need_SaveData_EventArgs(this.Name, _needSaveData));
            }
        }

        #endregion"Properties, Custom Control Properties"

        #region"Custom Controls Events with custom Arguments.*********************"

        #region"Node PDF"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event Custom_Events_Args.Node_PDF_EventHandler? Node_PDF;

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
        public event Custom_Events_Args.ActiveDataSheet_EventHandler? ActiveDataSheet;

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
        public event Custom_Events_Args.LogFileMessageEventHandler? LogFileMessage;

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
        public event Custom_Events_Args.StatusBarMessage_EventHandler? StatusBarMessage;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            // Notify Subscribers
            StatusBarMessage?.Invoke(this, e);
        }

        #endregion"StatusBarMessage"

        #region"CellDoubleClick"

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellDoubleClick has changed")]
        public event Custom_Events_Args.CellDoubleClick_EventHandler? CellDoubleClick_Event;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_CellDoubleClick_Event(CellDoubleClick_EventArgs e)
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

        #region"Need_SaveData"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Need_SaveData_EventHandler? Need_Save_Data;

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Need_SaveData(Need_SaveData_EventArgs e)
        {
            // Notify Subscribers
            Need_Save_Data?.Invoke(this, e);
        }

        #endregion"Need_SaveData"

        #region"NotificationsToSends"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.NotificationsToSends_EventHandler? NotificationsToSends;

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
        public event SpeechSynthesizerBase_EventHandler? SpeechSynthesizerBase;

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
        public event SaveSettingEventHandler? SaveSetting;

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
        public event Custom_Events_Args.Save_Requested_EventHandler? Save_Requested;

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
        public event Custom_Events_Args.Refresh_Requested_EventHandler? Refresh_Requested;

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
        public event Custom_Events_Args.SaveTreeView_Requested_EventHandler? SaveTreeView_Requested;

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
        public event Custom_Events_Args.SaveTreeView_Requested_EventHandler? AddNewItemSaveTreeViewRequested;

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
        DepartmentInformation _currentDepartmentLogIn = new DepartmentInformation();
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

        public Action? ProcessCurrentEmployeesLogIn;
        Employee? _currentEmployeesLogIn = new Employee();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Employee CurrentEmployeesLogIn
        {
            get
            {
                _currentEmployeesLogIn ??= new Employee();

                return _currentEmployeesLogIn;
            }
            set
            {
                _currentEmployeesLogIn = value;

                if (dataGridViewExtendedBase != null)
                    dataGridViewExtendedBase.CurrentEmployeesLogIn = _currentEmployeesLogIn;

                if (thumbViewerBasePictures != null)
                    thumbViewerBasePictures.CurrentEmployeesLogIn = _currentEmployeesLogIn;

                if (thumbViewerBaseLocation != null)
                    thumbViewerBaseLocation.CurrentEmployeesLogIn = _currentEmployeesLogIn;

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

        #region"thumbViewerBase"
        public void InitializeThumbViewerPicturesBase(ThumbViewer thumbViewer)
        {
            thumbViewerBasePictures = thumbViewer;
            thumbViewerBasePictures.StatusBarMessage += ThumbViewerBase_StatusBarMessage;
        }

        public void InitializeThumbViewerLocationBase(ThumbViewer thumbViewer)
        {
            thumbViewerBaseLocation = thumbViewer;
            thumbViewerBaseLocation.StatusBarMessage += ThumbViewerBase_StatusBarMessage;
        }

        void ThumbViewerBase_StatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        #endregion"thumbViewerBase"

        #region"Properties"

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MessagePositionString { get; set; } = string.Empty;

        /// <summary>
        /// A flags about the visibility state of the dock control,
        /// most be update in solutions temple.DockStateChanged();
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Showing { get; set; }

        /// <summary>
        /// Keep a record of the last Pictures accessed.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilePathPicturesBoxImage { get; set; } = string.Empty;

        /// <summary>
        /// Keep a record of the last location accessed.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilePathLocationBoxImage { get; set; } = string.Empty;

        public ToolTip _tooltip = new ToolTip();

        /// <summary>
        /// Text message to be show into easyProgressBar.
        /// it self clean when the time up.
        /// </summary>
        public string _textMessage = "";

        /// <summary>
        /// Keep the last DataSheet serviced,
        /// if the next datasheet is same, return.
        /// </summary>
        public string _lastDataSheet = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataColumnCollection? ColumnsCollection { get; set; }

        /// <summary>
        /// Current column active in the dataGridViewExtended_Inventory,
        /// update on CellClick and CellBegingEdit event.
        /// </summary>
        public DataColumn? _currentColumnActive = new DataColumn();
        
        /// <summary>
        /// Current rowView active in the dataGridViewExtended_Inventory,
        /// update on CurrentRowActive and MouseEnterEvent event.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataRowView? CurrentRowViewActive { get; set; }
        
        /// <summary>
        /// Current row status active in the dataGridViewExtended_Inventory,
        /// update on CurrentRowActive and MouseEnterEvent event.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CurrentStatus CurrentRowStatus { get; set; } = new CurrentStatus();
        
        /// <summary>
        /// _currentPartNumber in the dataGridViewExtended_Inventory,
        /// update on CurrentRowActive and MouseEnterEvent event.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrentPartNumber { get; set; } = string.Empty;

        /// <summary>
        /// Current focused node in treeViewBase,
        /// update in FocusedNodeChanged event.
        /// </summary>
        public NodeProperties _currentFocusedNodeproperties = new NodeProperties();

        public ResourcesCache _cache = new ResourcesCache();

        #endregion"Properties"

        #region"DataGridViewBase"
        public void InitializeDataGridViewBase(DataGridViewExtended dataGridView)
        {
            dataGridViewExtendedBase = dataGridView;

            dataGridViewExtendedBase.SaveRequested += DataGridViewExtendedBase_SaveRequested;
            dataGridViewExtendedBase.StatusBarMessage += DataGridViewExtendedBase_StatusBarMessage;
        }

        void DataGridViewExtendedBase_SaveRequested(object sender, Save_Requested_EventArgs e)
        {
            On_Save_Requested(e);
        }

        void DataGridViewExtendedBase_StatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        #endregion"DataGridViewBase"

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
    }
}

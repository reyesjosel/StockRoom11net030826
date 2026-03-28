using System.ComponentModel;
using System.Data;
using System.Text;
using Tags = MyStuff11net.HTML_Tags;
using Timer = System.Windows.Forms.Timer;

namespace MyStuff11net
{
    public class Custom_Events_Args
    {
        #region"InformationStatus"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a SelectNode")]
        public event InformationStatus_EventHandler InformationStatus;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void InformationStatus_EventHandler(object sender, InformationStatus_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        /// <summary>
        /// EventArg to InformationStatus, report if found picture and how qty.
        /// </summary>
        /// True if found a picture or pictures.
        /// <param name="informationStatus"></param>
        /// Qty of pictures founded.
        /// <param name="qty"></param>
        public class InformationStatus_EventArgs(bool informationStatus, int qty) : EventArgs
        {
            public bool InformationStatus = informationStatus;
            public int Qty = qty;
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_InformationStatus(InformationStatus_EventArgs e)
        {
            // Notify Subscribers
            InformationStatus?.Invoke(this, e);
        }

        #endregion"InformationStatus"

        #region"SelectNode"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a SelectNode")]
        public event SelectNode_EventHandler SelectNode;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SelectNode_EventHandler(object sender, SelectNode_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class SelectNode_EventArgs : EventArgs
        {
            public SelectNode_EventArgs(string nodeName)
            {
                NodeName = nodeName;
            }

            public string NodeName;
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_SelectNode(SelectNode_EventArgs e)
        {
            // Notify Subscribers
            SelectNode?.Invoke(this, e);
        }

        #endregion"SelectNode"

        #region"GetTable"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Get the filled table when this is ready.")]
        public event GetTable_EventHandler GetTable;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void GetTable_EventHandler(object sender, GetTable_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class GetTable_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public GetTable_EventArgs(bool isready, DataTable table)
            {
                IsReady = isready;
                Table = table;
            }

            public bool IsReady { get; set; }
            public DataTable Table { get; set; }
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_Get_Table_Change(GetTable_EventArgs e)
        {
            // Notify Subscribers
            GetTable?.Invoke(this, e);
        }

        /*How call this event.
        private DataTable _tableComponents;
        private void Get_Table_ready()
        {
            On_Get_Table_Change(new GetTable_EventArgs(true, _tableComponents));
        }
        */

        #endregion "GetTable"

        #region"Node PDF"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event Node_PDF_EventHandler Node_PDF;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void Node_PDF_EventHandler(object sender, ActiveDataSheet_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_Node_PDF(ActiveDataSheet_EventArgs e)
        {
            // Notify Subscribers
            Node_PDF?.Invoke(this, e);
        }

        #endregion"Node PDF"

        #region "New Items"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Description("New Item Event.")]
        [Browsable(true), Category("Controls Events")]
        public event NewItem_EventHandler NewItem;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void NewItem_EventHandler(object sender, NewItem_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class NewItem_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.

            public RowEventArgs CalendarRowEventArgs { get; set; }
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_NewItem(NewItem_EventArgs e)
        {
            // Notify Subscribers
            NewItem?.Invoke(this, e);
        }

        #endregion "New Items"

        #region "NewProject"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Description("New Item Event.")]
        [Browsable(true), Category("Controls Events")]
        public event NewProjectEventHandler NewProject;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void NewProjectEventHandler(object sender, NewProjectEventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class NewProjectEventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.

            public RowEventArgs CalendarRowEventArgs { get; set; }
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_NewProject(NewProjectEventArgs e)
        {
            // Notify Subscribers
            NewProject?.Invoke(this, e);
        }

        #endregion "NewProject"

        #region "NewRecord"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Description("New record Event.")]
        [Browsable(true), Category("Controls Events")]
        public event NewRecord_EventHandler NewRecord;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void NewRecord_EventHandler(object sender, NewRecord_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class NewRecord_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public NewRecord_EventArgs(RowEventArgs calendarRowEventArgs)
            {
                CalendarRowEventArgs = calendarRowEventArgs;
            }

            public string ProjectName;

            public RowEventArgs CalendarRowEventArgs;
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_NewRecord(NewRecord_EventArgs e)
        {
            if (NewRecord != null)
            {
                // Notify Subscribers
                NewRecord?.Invoke(this, e);
            }
        }

        #endregion "NewRecord"

        #region "HeightChange"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Description("HeightChange Event.")]
        [Browsable(true), Category("Controls Events")]
        public event HeightChange_EventHandler HeightChange;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void HeightChange_EventHandler(object sender, HeightChange_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class HeightChange_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public HeightChange_EventArgs(int heightChange)
            {
                HeightChange = heightChange;
            }

            public int HeightChange;
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_HeightChange(HeightChange_EventArgs e)
        {
            // Notify Subscribers
            HeightChange?.Invoke(this, e);
        }

        #endregion "HeightChange"

        #region "CloseProject"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Description("New Item Event.")]
        [Browsable(true), Category("Controls Events")]
        public event CloseProject_EventHandler CloseProject;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CloseProject_EventHandler(object sender, CloseProject_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class CloseProject_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public CloseProject_EventArgs(string projectname)
            {
                ProjectName = projectname;
            }

            public string ProjectName;
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_CloseProject(CloseProject_EventArgs e)
        {
            // Notify Subscribers
            CloseProject?.Invoke(this, e);
        }

        #endregion "CloseProject"

        #region"Need_SaveData"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Need_SaveData_EventHandler Need_SaveData;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void Need_SaveData_EventHandler(object sender, Need_SaveData_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class Need_SaveData_EventArgs : EventArgs
        {
            public Need_SaveData_EventArgs(string controlName, bool needsavedata)
            {
                ControlName = controlName;
                NeedSaveData = needsavedata;
            }

            public string ControlName;
            public bool NeedSaveData;

        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Need_SaveData(Need_SaveData_EventArgs e)
        {
            // Notify Subscribers
            Need_SaveData?.Invoke(this, e);
        }

        #endregion"Need_SaveData"

        #region"SpeechSynthesizerBase"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public static event SpeechSynthesizerBase_EventHandler SpeechSynthesizerBase;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SpeechSynthesizerBase_EventHandler(object sender, SpeechSynthesizerBase_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class SpeechSynthesizerBase_EventArgs : EventArgs
        {
            public SpeechSynthesizerBase_EventArgs(string statusBarMessage)
            {
                Text = statusBarMessage;
            }

            public string Text { get; set; }

        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_SpeechSynthesizerBase(SpeechSynthesizerBase_EventArgs e)
        {
            // Notify Subscribers
            SpeechSynthesizerBase?.Invoke(this, e);
        }

        #endregion"SpeechSynthesizerBase"

        #region"NotificationsToSends"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a NotificationsToSends action")]
        public event NotificationsToSends_EventHandler NotificationsToSends;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void NotificationsToSends_EventHandler(object sender, Notification e);

        protected virtual void On_NotificationsToSends(Notification e)
        {
            // Notify Subscribers
            NotificationsToSends?.Invoke(this, e);
        }

        #endregion"NotificationsToSends"

        #region"ActiveDataSheet"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event ActiveDataSheet_EventHandler ActiveDataSheet;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ActiveDataSheet_EventHandler(object sender, ActiveDataSheet_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class ActiveDataSheet_EventArgs : EventArgs
        {
            /// <summary>
            /// Constructor accepts two string: partNumber and dataSheet file name.
            /// </summary>
            /// <param name="partNumber">PartNumber of actual row.</param>
            /// <param name="datasheet">If actual row contains a datasheet.</param>
            public ActiveDataSheet_EventArgs(string partNumber, string defaultpath, string datasheet)
            {
                PartNumber = partNumber;
                DefaultPath = defaultpath;
                DataSheet = datasheet;
            }

            public string DefaultPath { get; set; }

            public string PartNumber { get; set; }

            string _dataSheetInfo = "";
            public string DataSheet
            {
                get
                {
                    return _dataSheetInfo;
                }
                set
                {
                    if (string.IsNullOrEmpty(value))
                        _dataSheetInfo = null;

                    _dataSheetInfo = value;
                }
            }
        }

        // # 4 ... Declare the protected virtual methods for
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
        public event LogFileMessageEventHandler LogFileMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void LogFileMessageEventHandler(object sender, LogFileMessageEventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class LogFileMessageEventArgs : EventArgs
        {
            /// <summary>
            /// logFileMessage = new string[] { StatusBarMessage, StatusBarHelp, AnyMessage };
            /// </summary>
            /// <param name="logFileMessage"></param>
            public LogFileMessageEventArgs(List<string> logFileMessage)
            {
                LogFileMessage = new List<string>();
                LogFileMessage.AddRange(logFileMessage);
            }

            public LogFileMessageEventArgs(List<string> logFileMessage, DataGridViewRow logFileGridRow)
            {
                LogFileMessage = new List<string>();
                LogFileMessage.AddRange(logFileMessage);

                string rowString = "";
                var builder = new StringBuilder();
                builder.Append(rowString);

                foreach (DataGridViewCell cell in logFileGridRow.Cells)
                {
                    if (cell.Value == null)
                        cell.Value = "";

                    int index = logFileMessage.Count - 1;
                    if (index < 0)
                        continue;

                    if (logFileMessage[index].Contains(cell.OwningColumn.Name))
                        builder.Append(Tags.TextColor(cell.Value.ToString() + "; ", Color.Red));
                    else
                        builder.Append(cell.Value.ToString() + "; ");
                }
                rowString = builder.ToString();
            }

            public LogFileMessageEventArgs(List<string> logFileMessage, DataRowView logFileRowView)
            {
                LogFileMessage = new List<string>();
                LogFileMessage.AddRange(logFileMessage);

                var rowString = "Row null value.";
                if (logFileRowView != null)
                    rowString = logFileRowView.Row.ItemArray.Aggregate(rowString, (current, item) => current + (item + "; "));

                LogFileMessage = logFileMessage;
                LogFileMessage.Add(Tags.NewLineItalic(rowString));
            }

            public LogFileMessageEventArgs(string eventInformation, DataGridViewRow logFileMessage)
            {
                string rowString = "";
                var builder = new StringBuilder();
                builder.Append(rowString);

                foreach (DataGridViewCell cell in logFileMessage.Cells)
                {
                    builder.Append(cell.Value.ToString() + "; ");
                }
                rowString = builder.ToString();

                LogFileMessage = new List<string>
                {
                    //Tags.newLine,
                    //Tags.NewLine(DateTime.Now.ToString()),
                    //Tags.NewLine(eventInformation),
                    //Tags.NewLineItalic(rowString)
                };
            }

            public LogFileMessageEventArgs(string eventInformation, DataRowView logFileMessage)
            {
                string rowString = "";
                var builder = new StringBuilder();
                builder.Append(rowString);

                foreach (object item in logFileMessage.Row.ItemArray)
                {
                    builder.Append(item.ToString() + "; ");
                }
                rowString = builder.ToString();

                LogFileMessage = new List<string>
                {
                    Tags.newLine,
                    Tags.NewLine(DateTime.Now.ToString()),
                    Tags.NewLine(eventInformation),
                    Tags.NewLineItalic(rowString)
                };
            }

            public List<string> LogFileMessage { get; set; }
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_LogFileMessage(LogFileMessageEventArgs e)
        {
            // Notify Subscribers
            LogFileMessage?.Invoke(this, e);
        }

        #endregion"LogFile information"

        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public static event StatusBarMessage_EventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessage_EventHandler(object sender, StatusBarMessage_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class StatusBarMessage_EventArgs : EventArgs
        {
            public StatusBarMessage_EventArgs()
            {
                Initi = false;
            }

            public StatusBarMessage_EventArgs(string statusBarMessage)
            {
                StatusBarMessage = statusBarMessage;
                Initi = false;
            }

            public StatusBarMessage_EventArgs(string statusBarMessage, Icon iconStatusBar)
            {
                StatusBarMessage = statusBarMessage;
                StatusBarIcon = iconStatusBar;
                Initi = false;
            }

            public StatusBarMessage_EventArgs(string statusBarMessage, string statusBarHelp)
            {
                StatusBarHelp = statusBarHelp;
                StatusBarMessage = statusBarMessage;
                Initi = false;
            }

            public StatusBarMessage_EventArgs(string statusBarMessage, int intervalCount)
            {
                StatusBarMessage = statusBarMessage;
                IntervalCount = intervalCount;
            }

            public StatusBarMessage_EventArgs(string statusBarMessage, int intervalCount, bool streaming)
            {
                StatusBarMessage = statusBarMessage;
                IntervalCount = intervalCount;
                Streaming = streaming;
            }

            public StatusBarMessage_EventArgs(string statusBarMessage, bool showProgressBar, int value, int min, int max)
            {
                StatusBarMessage = statusBarMessage;
                ShowProgressBar = showProgressBar;
                Value = value;
                Min = min;
                Max = max;
                Initi = true;
            }

            public Icon StatusBarIcon { get; set; }
            public string StatusBarHelp { get; set; }
            public string StatusBarMessage { get; set; }
            public bool ShowProgressBar { get; set; }
            public int IntervalCount { get; set; } = 4;
            public int Value { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
            public bool Initi { get; set; }
            public bool Streaming { get; set; } = false;

        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            // Notify Subscribers
            StatusBarMessage?.Invoke(this, e);
        }

        #endregion"StatusBarMessage"

        #region"TreeViewUpdate"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The TreeView data source has been changed")]
        public static event TreeViewUpdateEventHandler TreeViewUpdate;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void TreeViewUpdateEventHandler(object sender, TreeViewUpdateEventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class TreeViewUpdateEventArgs : EventArgs
        {
            public TreeViewUpdateEventArgs(string statusBarMessage)
            {
                Initi = false;
            }

            public string StatusBarHelp { get; set; }
            public bool Initi { get; set; }
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_TreeViewUpdate(TreeViewUpdateEventArgs e)
        {   // Notify Subscribers
            TreeViewUpdate?.Invoke(this, e);
        }

        #endregion"TreeViewUpdate"

        #region"TreeViewSelectedIndexChanged"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The TreeView data source has been changed")]
        public static event TreeViewSelectedIndexChangedEventHandler TreeViewSelectedIndexChanged;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void TreeViewSelectedIndexChangedEventHandler(object sender, TreeViewSelectedIndexChangedEventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class TreeViewSelectedIndexChangedEventArgs : EventArgs
        {
            public TreeViewSelectedIndexChangedEventArgs()
            {

            }

            public NodeProperties SelectedNodeProperties { get; set; }

        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_TreeViewSelectedIndexChanged(TreeViewSelectedIndexChangedEventArgs e)
        {   // Notify Subscribers
            TreeViewSelectedIndexChanged?.Invoke(this, e);
        }

        #endregion"TreeViewSelectedIndexChanged"

        #region"RemovedFilter"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class RemovedFilter_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public RemovedFilter_EventArgs(DataGridViewHeaderCell headerCell)
            {
                HeaderCell = headerCell;
            }

            public int ColumnIndex
            {
                get
                {
                    return HeaderCell.ColumnIndex;
                }
            }
            public DataGridViewHeaderCell HeaderCell { get; private set; }
        }

        #endregion"RemovedFilter"

        #region"CellClick"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class CellClick_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public CellClick_EventArgs(DataGridViewCellEventArgs value, DataGridViewRow currentRowActive)
            {
                ColumnIndex = value.ColumnIndex;
                RowIndex = value.RowIndex;
                CurrentRowActive = currentRowActive;
            }

            public int ColumnIndex { get; set; }
            public int RowIndex { get; set; }
            public DataGridViewRow CurrentRowActive { get; private set; }
        }

        #endregion"CellClick"

        #region"CellDoubleClick"

        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CellDoubleClick_EventHandler(object sender, CellDoubleClick_EventArgs e);

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class CellDoubleClick_EventArgs : EventArgs
        {
            public CellDoubleClick_EventArgs(string information, string partNumberTag, MyCode.ProcessMode processInfor)
            {
                ProcessInfor = processInfor;

                Information = information;

                //ComponentInformations = new ComponentInformation(partNumberTag);
            }

            // Constructor.
            public CellDoubleClick_EventArgs(DataRowView dataRow)
            {
                Information = "Default mode.";

                //ComponentInformations = new ComponentInformation(dataRow);
            }

            // Constructor.
            public CellDoubleClick_EventArgs(DataGridViewRow dataGridViewRow, MyCode.ProcessMode processInfor)
            {
                DataGridViewRow = dataGridViewRow;
                // If Grouping is active.
                if (dataGridViewRow.DataBoundItem.GetType().Name == "GroupRow")
                    return;

                ProcessInfor = processInfor;

                Information = "Default mode.";

                //ComponentInformations = new ComponentInformation(dataGridViewRow.DataBoundItem as DataRowView);
            }

            // Constructor.
            public CellDoubleClick_EventArgs(DataGridViewRow dataGridViewRow, MyCode.ProcessMode processInfor, string columnName)
            {
                DataGridViewRow = dataGridViewRow;
                // If Grouping is active.
                if (dataGridViewRow.DataBoundItem.GetType().Name == "GroupRow")
                    return;

                ColumnName = columnName;

                ProcessInfor = processInfor;

                Information = "Default mode.";

                //ComponentInformations = new ComponentInformation(dataGridViewRow.DataBoundItem as DataRowView);
            }

            /// <summary>
            /// Keep information about the process,
            /// AddNew   -> Process to add new component.
            /// Received -> Process to received components.
            /// Adjusted -> Process to adjust the inventory.
            /// </summary>
            public MyCode.ProcessMode ProcessInfor { get; private set; }
            public string Information { get; private set; }
            public int ColumnIndex { get; private set; }
            public string ColumnName { get; private set; }
            public int RowIndex { get; private set; }
            public string Code
            {
                get
                {
                    return Information;// CurrentRowActive.Cells["PartNumber"].Value.ToString().Remove(4);
                }
                private set { }
            }

            public DataGridViewRow DataGridViewRow;

            public ComponentInformation ComponentInformations { get; private set; }
        }

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellDoubleClick has changed")]
        public event CellDoubleClick_EventHandler CellDoubleClick_Event;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_CellDoubleClick_Event(CellDoubleClick_EventArgs e)
        {
            // Notify Subscribers
            CellDoubleClick_Event?.Invoke(this, e);
        }

        #endregion"CellDoubleClick_Event"

        #region"Refresh_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Refresh_Requested_EventHandler Refresh_Requested;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void Refresh_Requested_EventHandler(object sender, Refresh_Requested_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class Refresh_Requested_EventArgs : EventArgs
        {
            public Refresh_Requested_EventArgs(string _filter)
            {
                if (_filter == null)
                    StringFilter = "";
                else
                    StringFilter = _filter.Replace("*", "%");
            }

            public string StringFilter { get; private set; }
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Refresh_Requested(Refresh_Requested_EventArgs e)
        {
            // Notify Subscribers
            Refresh_Requested?.Invoke(this, e);
        }

        #endregion"Refresh_Requested"

        #region"Save_Setting"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SaveSettingEventHandler(object sender, SaveSettingEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Setting Save action")]
        public event SaveSettingEventHandler SaveSetting;

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class SaveSettingEventArgs : EventArgs
        {
            public SaveSettingEventArgs(string name, UserSetting userSetting)
            {
                Name = name;
                Setting = userSetting;
            }

            public SaveSettingEventArgs(string name, UserSetting userSetting, DataGridViewColumnCollection columns)
            {
                Name = name;
                Setting = userSetting;
                Columns = columns;
            }

            public string Name { get; set; }
            public UserSetting Setting { get; set; }
            public DataGridViewColumnCollection Columns { get; set; }


        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_Save_Setting(SaveSettingEventArgs e)
        {
            SaveSetting?.Invoke(this, e);
        }
        #endregion"Save_Setting"

        #region"Save_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Save_Requested_EventHandler Save_Requested;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void Save_Requested_EventHandler(object sender, Save_Requested_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class Save_Requested_EventArgs : EventArgs
        {
            public Save_Requested_EventArgs() { }

            public Save_Requested_EventArgs(MyCode.NotificationEvents saveEvent)
            {
                SaveEvent = saveEvent;
            }

            public Save_Requested_EventArgs(MyCode.NotificationEvents saveEvent, DataRowView changeRow)
            {
                SaveEvent = saveEvent;
                if (changeRow == null)
                    return;

                switch (saveEvent)
                {
                    case MyCode.NotificationEvents.Email:
                        {
                            break;
                        }
                    case MyCode.NotificationEvents.Warning:
                        {
                            break;
                        }
                    case MyCode.NotificationEvents.RowAdded:
                        {
                            break;
                        }
                    case MyCode.NotificationEvents.RowRemoved:
                        {
                            break;
                        }
                    case MyCode.NotificationEvents.DataBaseUpDated:
                        {
                            break;
                        }
                    case MyCode.NotificationEvents.ClearAllSelected:
                        {
                            break;
                        }
                    case MyCode.NotificationEvents.RowInformationChange:
                        {
                            ComponentInformation = new ComponentInformation(changeRow);
                            break;
                        }
                    case MyCode.NotificationEvents.EmployeesInformationChange:
                        {
                            EmployeesInformation = new Employee(changeRow);
                            break;
                        }
                    case MyCode.NotificationEvents.ComponentInformationChange:
                        {
                            ComponentInformation = new ComponentInformation(changeRow);
                            break;
                        }
                    case MyCode.NotificationEvents.DepartmentInformationChange:
                        {
                            DepartmentInformation = new DepartmentInformation(changeRow);
                            break;
                        }
                }
            }

            public Save_Requested_EventArgs(MyCode.NotificationEvents saveEvent, DepartmentInformation departmentInformation)
            {
                SaveEvent = saveEvent;
                DepartmentInformation = departmentInformation;
            }

            public MyCode.NotificationEvents SaveEvent;

            public ComponentInformation ComponentInformation;
            public DepartmentInformation DepartmentInformation;
            public Employee EmployeesInformation;
            public string DataTableName;
            public MyCode.NotificationEvents NotificationEvent;
            public string Message;

        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Save_Requested(Save_Requested_EventArgs e)
        {
            // Notify Subscribers
            Save_Requested?.Invoke(this, e);
        }
        #endregion

        #region"SaveStockRoom_Requested"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SaveStockRoom_Requested_EventHandler(object sender, Save_Requested_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event SaveStockRoom_Requested_EventHandler SaveStockRoom_Requested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_SaveStockRoom_Requested(Save_Requested_EventArgs e)
        {
            // Notify Subscribers
            SaveStockRoom_Requested?.Invoke(this, e);
        }
        #endregion

        #region"SaveTreeView_Requested"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SaveTreeView_Requested_EventHandler(object sender, Save_Requested_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event SaveTreeView_Requested_EventHandler SaveTreeView_Requested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_SaveTreeView_Requested(Save_Requested_EventArgs e)
        {
            // Notify Subscribers
            SaveTreeView_Requested?.Invoke(this, e);
        }
        #endregion

        #region "StringFilter event."

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Description("StringFilter Event.")]
        [Browsable(true), Category("Controls Events")]
        public event StringFilterControl_EventHandler StringFilter;

        // # 2 ... ***** StringFilter Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StringFilterControl_EventHandler(object sender, StringFilterControl_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class StringFilterControl_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            //    public StringFilterControl_EventArgs(DataColumn columnData, string operation, string condition)
            //    {
            //        ColumnData = columnData;
            //        Operation = operation;
            //        Condition = condition;
            //    }

            public StringFilterControl_EventArgs(string filter)
            {
                StringFilterSql = filter;
            }


            public StringFilterControl_EventArgs(DataColumn columnData, string filter, string controlText)
            {
                ColumnData = columnData;

                StringFilterSql = filter;

                ControlText = controlText;
            }


            public StringFilterControl_EventArgs(DataColumn columnData, string columnName, string operation, string condition, string controlText)
            {
                ColumnData = columnData;

                ColumnName = columnName;
                Operation = operation;
                Condition = condition;
                ControlText = controlText;
            }

            public DataColumn ColumnData;

            /// <summary>
            /// Column name used to be filtered.
            /// Example: PartNumber LIKE '014-02333'; Column name -> PartNumber.
            /// </summary>
            public string ColumnName;
            /// <summary>
            /// Operation in this filter.
            /// Example: PartNumber LIKE '014-02333'; Operation -> LIKE.
            /// </summary>
            public string Operation;
            /// <summary>
            /// Condition to filter the data.
            /// Example: PartNumber LIKE '014-02333'; Condition -> 014-02333.
            /// </summary>
            public string Condition;

            /// <summary>
            /// String filter information SQL formated.
            /// </summary>
            public string StringFilterSql;

            /// <summary>
            /// Whole string filter to be processed.
            /// </summary>
            public string StringFilter
            {
                get
                {
                    if (Operation == "")
                        return "";

                    if (string.IsNullOrWhiteSpace(ColumnName))
                        return "";

                    switch (Condition)
                    {
                        case "Any Informations":
                            {
                                return ColumnName + " LIKE '*'";
                            }
                        case "Null Value":
                            {
                                return ColumnName + " IS NULL";
                            }
                        case "Empty String":
                            {
                                return ColumnName + " LIKE '\"\"'";
                            }
                        default:
                            {
                                break;
                            }
                    }

                    var stringFilter = "";
                    var selectedColumnType = "";

                    if (ColumnData != null)
                        selectedColumnType = ColumnData.DataType.Name;
                    else
                        selectedColumnType = "Int64";

                    switch (selectedColumnType)
                    {
                        case "String":
                            {
                                stringFilter = ColumnName + Match_string(Operation, Condition);
                                break;
                            }
                        case "Int32":
                            {
                                stringFilter = ColumnName + MatchNum(Operation, Condition, Condition);
                                break;
                            }
                        case "Int64": // This selectedColumnType is only for clear the filter.
                            {
                                stringFilter = "";
                                return stringFilter;
                            }
                    }

                    return stringFilter;
                }
            }

            public string ControlText;

            string Match_string(string operation, string condition)
            {
                string mymatch = "";

                if (condition == "")
                {
                    mymatch = " IS NULL";
                    return mymatch;
                }

                switch (operation)
                {
                    case "Equals":
                        {
                            mymatch = " LIKE '" + condition + "'";
                            return mymatch;
                        }
                    case "Does Not Equals":
                        {
                            mymatch = " NOT LIKE '" + condition + "'";
                            return mymatch;
                        }
                    case "Begin With":
                        {
                            mymatch = " LIKE '" + condition + "*'";
                            return mymatch;
                        }
                    case "Does Not Begin With":
                        {
                            mymatch = " NOT LIKE '" + condition + "*'";
                            return mymatch;
                        }
                    case "Contains":
                        {
                            mymatch = " LIKE '*" + condition + "*'";
                            return mymatch;
                        }
                    case "Does Not Contains":
                        {
                            mymatch = " NOT LIKE '*" + condition + "*'";
                            return mymatch;
                        }
                    case "Ends With":
                        {
                            mymatch = " LIKE '*" + condition + "'";
                            return mymatch;
                        }
                    case "Does Not End With":
                        {
                            mymatch = " NOT LIKE '*" + condition + "'";
                            return mymatch;
                        }
                    default:
                        {
                            return mymatch;
                        }
                }
            }

            string MatchNum(string operation, string valueMin, string valueMax)
            {
                string mymatch = "";

                if (valueMin == "")
                {
                    mymatch = " IS NULL";
                    return mymatch;
                }

                switch (operation)
                {
                    case "Equals to":
                        {
                            mymatch = " = " + valueMin;
                            return mymatch;
                        }
                    case "Does Not Equals":
                        {
                            mymatch = " <> " + valueMin;
                            return mymatch;
                        }
                    case "Less Than":
                        {
                            mymatch = " < " + valueMin;
                            return mymatch;
                        }
                    case "Greater Than":
                        {
                            mymatch = " > " + valueMin;
                            return mymatch;
                        }
                    case "Less Than or Equal to":
                        {
                            mymatch = " <= " + valueMin;
                            return mymatch;
                        }
                    case "Greater Than or Equal to":
                        {
                            mymatch = " >= " + valueMin;
                            return mymatch;
                        }
                    case "Between":
                        {
                            mymatch = " >= " + valueMin + " AND " + ColumnName + " <= " + valueMax;
                            return mymatch;
                        }
                    default:
                        {
                            return mymatch;
                        }
                }
            }
        }

        readonly Timer tic = new Timer();
        StringFilterControl_EventArgs _ev;
        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_StringFilter(StringFilterControl_EventArgs e)
        {
            _ev = e;

            if (tic.Enabled)
                return;

            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (StringFilter != null)
            {
                tic.Tick += TicTick;
                tic.Interval = 100;
                tic.Enabled = true;
                tic.Start();
            }
        }

        void TicTick(object sender, EventArgs e)
        {
            tic.Stop();
            tic.Enabled = false;
            tic.Tick -= TicTick;

            // Notify Subscribers
            StringFilter?.Invoke(this, _ev);
        }

        #endregion "StringFilter event."

        #region"Second Condition"

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class SecondCondition_EventArgs : EventArgs
        {
            public SecondCondition_EventArgs(string secondCondition, int index, int x, int y, int width, int higth)
            {
                SecondConditionCombo_Text = secondCondition;

                Index = index;
                IndexNextControl = Index + 1;
                SecondCondition = SecondConditionCombo_Text;

                LocationX = x;
                LocationY = y;
                Width = width;
                Higth = higth;
            }

            public string SecondConditionCombo_Text;

            public int Index;
            public int IndexNextControl;
            public string SecondCondition;
            public int LocationX;
            public int LocationY;
            public int Width;
            public int Higth;
        }

        #endregion"Second Condition"

        #region"Switch_DataTable"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Switch_DataTable_EventHandler Switch_DataTable;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void Switch_DataTable_EventHandler(object sender, Switch_DataTable_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class Switch_DataTable_EventArgs : EventArgs
        {
            public Switch_DataTable_EventArgs() { }


            public string DataTableName;
            public string Message;
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Switch_DataTable(Switch_DataTable_EventArgs e)
        {
            // Notify Subscribers
            Switch_DataTable?.Invoke(this, e);
        }
        #endregion

        #region"ColumnNameSelected"

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class ColumnNameSelected_EventArgs : EventArgs
        {
            public ColumnNameSelected_EventArgs(string columnNameDataBase, int index, int x, int y, string controlText)
            {
                ColumnNameDataBase = columnNameDataBase;

                Index = index;
                IndexNextControl = Index + 1;

                LocationX = x;
                LocationY = y;

                ControlText = controlText;
            }

            public ColumnNameSelected_EventArgs(string columnNameExcel, string columnNameDataBase, int index, int x, int y, string controlText)
            {
                ColumnNameExcel = columnNameExcel;
                ColumnNameDataBase = columnNameDataBase;

                Index = index;
                IndexNextControl = Index + 1;

                LocationX = x;
                LocationY = y;

                ControlText = controlText;
            }

            public string ColumnNameExcel;
            public string ColumnNameDataBase;

            public int Index;
            public int IndexNextControl;
            public int LocationX;
            public int LocationY;
            public string ControlText;
        }

        #endregion"ColumnNameSelected"

        #region"DataGridViewSort"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class DataGridViewSort_EventArgs : EventArgs
        {
            // Constructor accepts some value.
            public DataGridViewSort_EventArgs(BindingSource bindingsource)
            {
                Bindingsource = bindingsource;
            }

            public BindingSource Bindingsource { get; private set; }
        }

        #endregion"DataGridViewSort"

        #region"CurrentRowActive"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class CurrentRowActive_EventArgs : EventArgs
        {
            // Constructor accepts some value.
            public CurrentRowActive_EventArgs(DataGridViewRow currentDataGridViewRow)
            {
                CurrentRow = 0;
                CurrentRowActive = currentDataGridViewRow;
            }

            public CurrentRowActive_EventArgs(int newvalue, DataGridViewRow currentDataGridViewRow)
            {
                CurrentRow = newvalue;
                CurrentRowActive = currentDataGridViewRow;
                CurrentRowViewActive = currentDataGridViewRow.DataBoundItem as DataRowView;
            }

            public int CurrentRow { get; private set; }
            public DataRowView CurrentRowViewActive { get; private set; }
            public DataGridViewRow CurrentRowActive { get; private set; }
        }

        #endregion"CurrentRowActive"

        #region"Current_DeptUser_Broadcast"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The current user have be changed.")]
        public event CurrentDeptUserBroadcast_EventHandler CurrentDeptUserBroadcast_Requested;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CurrentDeptUserBroadcast_EventHandler(object sender, CurrentDeptUserBroadcast_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class CurrentDeptUserBroadcast_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public CurrentDeptUserBroadcast_EventArgs(DepartmentInformation dept, Employee employee)
            {
                Deptment = dept;
                Employee = employee;
            }

            public DepartmentInformation Deptment;

            public Employee Employee;
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_CurrentDeptUserBroadcast_Requested(CurrentDeptUserBroadcast_EventArgs e)
        {
            // Notify Subscribers
            CurrentDeptUserBroadcast_Requested?.Invoke(this, e);
        }

        #endregion"Current__DeptUser_Broadcast"

        #region"DataGridViewMouseEnterEventArgs"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class DataGridViewMouseEnterEventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public DataGridViewMouseEnterEventArgs(DataGridViewRow currentRowActive)
            {
                CurrentRowActive = currentRowActive;
            }

            public DataGridViewRow CurrentRowActive { get; private set; }
        }

        #endregion"DataGridViewMouseEnterEventArgs"

        #region"DataGridViewMouseDownEventArgs"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class DataGridViewMouseDownEventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public DataGridViewMouseDownEventArgs(DataGridViewRow currentRowActive)
            {
                CurrentRowActive = currentRowActive;
            }

            public DataGridViewRow CurrentRowActive { get; private set; }
        }

        #endregion"DataGridViewMouseDownEventArgs"

        #region"RowsMouseEnterEventArgs"

        // # 2 ... Define and provide implementations for RowsMouseEnterEventArgs
        // Declare the constructor and properties of custom Arg.
        public class RowsMouseEnterEventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public RowsMouseEnterEventArgs(DataGridViewRow currentDataGridViewRowMouseEnter,
                                                 DataRowView currentDataRowviewMouseEnter,
                                                 CurrentStatus currentRowMouseEnterStatus)
            {
                CurrentRowActive = currentDataGridViewRowMouseEnter;
                CurrentDataRowviewMouseEnter = currentDataRowviewMouseEnter;
                CurrentRowMouseEnterStatus = currentRowMouseEnterStatus;
            }

            public DataGridViewRow CurrentRowActive { get; private set; }
            public DataRowView CurrentDataRowviewMouseEnter { get; private set; }
            public CurrentStatus CurrentRowMouseEnterStatus { get; private set; }
        }

        #endregion"RowsMouseEnterEventArgs"

        #region"AddNewItemEventArgs"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        // Usado en DataGridView BindingNavegador Add.
        public class AddNewItemEventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public AddNewItemEventArgs(DataRowView addedRow)
            {
                AddedRow = addedRow;
            }

            public DataRowView AddedRow { get; private set; }
        }

        #endregion"AddNewItemEventArgs"

        #region"PrintsLabelsReady"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event PrintsLabelsReady_EventHandler PrintsLabelsReady;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void PrintsLabelsReady_EventHandler(object sender, PrintsLabelsReady_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class PrintsLabelsReady_EventArgs : EventArgs
        {
            public PrintsLabelsReady_EventArgs(bool printsLabelsReady)
            {
                PrintsLabelsReady = printsLabelsReady;
            }

            public bool PrintsLabelsReady;

        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_PrintsLabelsReady(PrintsLabelsReady_EventArgs e)
        {
            PrintsLabelsReady?.Invoke(this, e);
        }

        #endregion"PrintsLabelsReady"

        #region"DoneButton_EventArgs"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public static event DoneButton_EventHandler DoneEvent;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void DoneButton_EventHandler(object sender, DoneButton_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class DoneButton_EventArgs : EventArgs
        {
            public DoneButton_EventArgs(string content, Color color)
            {
                Content = content;
                Color = color;
            }


            public string StatusBarHelp { get; set; }
            public string StatusBarMessage { get; set; }
            public string Content { get; set; }
            public Color Color { get; set; }

        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_DoneEvent(DoneButton_EventArgs e)
        {
            DoneEvent?.Invoke(this, e);
        }

        #endregion"DoneButton_EventArgs"

        #region"ThumbNailClick_EventArgs"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class ThumbNailClick_EventArgs : EventArgs
        {

            public ThumbNailClick_EventArgs(string fileNameAddress)
            {
                FileName = Path.GetFileName(fileNameAddress);
                FilePath = fileNameAddress.Replace(FileName, "");
            }

            // Constructor accepts two integer: the old value and the new value.
            public ThumbNailClick_EventArgs(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public ThumbNailClick_EventArgs(string fileName, string filePath, ThumbNail thumb)
            {
                Thumb = thumb;
                FileName = fileName;
                FilePath = filePath;
            }

            public ThumbNail Thumb { get; set; }
            public string FileName { get; set; }
            public string FilePath { get; set; }
        }

        #endregion"ThumbNailClick_EventArgs"

        #region"ThumbNailMouseMove_EventArgs"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class ThumbNailMouseMove_EventArgs : EventArgs
        {
            public ThumbNailMouseMove_EventArgs(int mousePosition, ThumbNail thumb)
            {
                Thumb = thumb;
                MousePosition = mousePosition;
            }

            public ThumbNail Thumb { get; set; }
            public int MousePosition { get; set; }
        }

        #endregion"ThumbNailMouseMove_EventArgs"

        #region"ThumbNailMouseEnter_EventArgs"

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class ThumbNailMouseEnter_EventArgs : EventArgs
        {

            public ThumbNailMouseEnter_EventArgs(string fileNameAddress)
            {
                FileName = Path.GetFileName(fileNameAddress);
                FilePath = fileNameAddress.Replace(FileName, "");
            }

            // Constructor accepts two integer: the old value and the new value.
            public ThumbNailMouseEnter_EventArgs(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public ThumbNailMouseEnter_EventArgs(string fileName, string filePath, ThumbNail thumb)
            {
                Thumb = thumb;
                FileName = fileName;
                FilePath = filePath;
            }

            public ThumbNail Thumb { get; set; }
            public string FileName { get; set; }
            public string FilePath { get; set; }
        }

        #endregion"ThumbNailMouseEnter_EventArgs"

        #region"ResizeGripEvent"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ResizeGripEventHandler(object sender, ResizeGrip_EventArgs e);

        // # 2 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ResizeGrip is active")]
        public event ResizeGripEventHandler ResizeGripEvent;

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class ResizeGrip_EventArgs : EventArgs
        {
            public ResizeGrip_EventArgs(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }

        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_ResizeGrip_Event(ResizeGrip_EventArgs e)
        {
            ResizeGripEvent?.Invoke(this, e);
        }

        #endregion"ResizeGripEvent"

        #region"ToolStripMenuItemClick"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("A ToolStripMenuItem event Click")]
        public event ToolStripMenuItemClickEventHandler? ToolStripMenuItemClick;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ToolStripMenuItemClickEventHandler(object sender, ToolStripMenuItemClickEventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class ToolStripMenuItemClickEventArgs : EventArgs
        {
            public ToolStripMenuItemClickEventArgs(ToolStripMenuItem item)
            {
                ItemClicked = item;
            }

            public readonly ToolStripMenuItem ItemClicked;
        }

        // # 4 ... Declare the public virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_ToolStripMenuItemClick(ToolStripMenuItemClickEventArgs e)
        {
            // Notify Subscribers
            ToolStripMenuItemClick?.Invoke(this, e);
        }

        #endregion

        public class RowEventArgs : EventArgs
        {
            #region Ctor

            /// <summary>
            /// Creates a new <see cref="WeekPlannerRow"/>
            /// </summary>
            /// <param name="row">Related row</param>


            public RowEventArgs(DateTime seledtedCellDate)
            {
                _seledtedCellDate = seledtedCellDate;
            }




            #endregion

            #region Props

            private readonly DateTime _seledtedCellDate;

            /// <summary>
            /// Project ID.
            /// </summary>
            public int ID
            {
                get
                {
                    return -1;
                }

            }



            /// <summary>
            /// Project Text Name.
            /// </summary>
            public string Text_Name
            {
                get
                {
                    return "no text";
                }
            }

            /// <summary>
            /// Gets the <see cref="WeekPlannerRow"/> related to the event
            /// </summary>


            /// <summary>
            /// Retun true if one item in the collection is open.
            /// </summary>
            public bool AreItemsOpen
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets the DateTime related to the event.
            /// </summary>
            public DateTime SeledtedCellDate
            {
                get { return _seledtedCellDate; }
            }


            #endregion
        }



        public delegate void SetProgressValue(int value);

        public delegate void SetProgressValueBom(int value, int maxValue);






    }
}

using SQLitePCL;
using StockRoom11net.Controls.SMTcontrol;
using StockRoom11net.Controls.UtilsLibrary;
using StockRoom11net.Controls.WinFormsControls;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Text;
using RowsMouseEnterEventArgs = StockRoom11net.Controls.Custom_Events_Args.RowsMouseEnterEventArgs;
using StatusBarMessage_EventArgs = StockRoom11net.Controls.Custom_Events_Args.StatusBarMessage_EventArgs;

namespace StockRoom11net.Controls.DataGridViewExtend
{
    [Description("Extension of the System.Windows.Forms.DataGridView")]
    [ToolboxBitmap(typeof(DataGridView))]
    public class DataGridViewControlExtended : DataGridView
    {
        #region "Index"
        // ── Constructor ────────────────────────────────────────────────────────
        //  DataGridViewControlExtended()
        //
        // ── Overrides ──────────────────────────────────────────────────────────
        //  OnLayout()
        //  Sort()
        //  ProcessCmdKey()
        //
        // ── Initialization ─────────────────────────────────────────────────────
        //  InitializeBrush_Pen_Icon()
        //  InitialDelay_Tick()
        //  InitializeDataGridView()
        //  InitializeGrouper()
        //  InitializeToolTip()
        //  InitializeMouseSingleClickDetectTimer()
        //  InitializeMouseDoubleClickDetectTimer()
        //  AddColumn()
        //
        // ── Row Events ─────────────────────────────────────────────────────────
        //  DataGridViewControlExtended_RowEnterFocus()
        //  DataGridViewControlExtended_RowLeaveFocus()
        //  DataGridViewControlExtended_RowPrePaint()
        //  DataGridViewControlExtended_RowPostPaint()
        //  DataGridViewControlExtended_RowHeaderMouseClick()
        //
        // ── Cell Events ────────────────────────────────────────────────────────
        //  DataGridViewControlExtended_CellMouseDown()
        //  DataGridViewControlExtended_CellMouseUp()
        //  DataGridViewControlExtended_CellMouseEnter()
        //  DataGridViewControlExtended_CellMouseLeave()
        //  DataGridViewControlExtended_CellDoubleClick()
        //  DataGridView_TopLeftHeader_CellPainting()
        //
        // ── Column Events ──────────────────────────────────────────────────────
        //  DataGridViewControlExtended_ColumnHeaderMouseClick()
        //  DataGridViewControlExtended_ColumnWidthChanged()
        //  DataGridViewControlExtended_ColumnDisplayIndexChanged()
        //  DataGridView_ColumnHeader_CellPainting()
        //
        // ── Mouse Events ───────────────────────────────────────────────────────
        //  DataGridViewControlExtended_MouseDown()
        //  DataGridViewControlExtended_MouseUp()
        //  DataGridViewControlExtended_MouseMove()
        //  DataGridViewControlExtended_MouseClick()
        //  DataGridViewControlExtended_MouseLeave()
        //
        // ── Keyboard Events ────────────────────────────────────────────────────
        //  DataGridViewControlExtended_PreviewKeyDown()
        //  DataGridViewControlExtended_KeyDown()
        //  DataGridViewControlExtended_KeyUp()
        //
        // ── Paint / Scroll Events ──────────────────────────────────────────────
        //  DataGridViewControlExtended_Paint()
        //  DataGridViewControlExtended_Scroll()
        //  DataGridViewControlExtended_SizeChanged()
        //  DataGridViewControlExtended_DataError()
        //  PaintBOMRow()
        //
        // ── Column Selection ───────────────────────────────────────────────────
        //  SelectColumnLogicProcess()
        //  SelectColumn()
        //  ReSelectColumn()
        //  UnSelectColumn()
        //  ClearSelectedColumns()
        //
        // ── Mouse Click Detection ──────────────────────────────────────────────
        //  MouseSingleClickDetectTimer_Tick()
        //  MouseSingleClickDetectTimerStop()
        //  MouseTwoClickDetector_Tick()
        //  SortCancel()
        //  TimeDelaySortCancel_Tick()
        //
        // ── Grouper ────────────────────────────────────────────────────────────
        //  SetGroupOn()
        //  ExpandAll()
        //  CollapseAll()
        //  Collapse_expand()
        //  Get_rows()
        //  CheckIfMouseOverCollapseExpandSymbol()
        //  CheckCollapsedFocused()
        //  InvalidateHeaderCell()
        //
        // ── ToolTip ────────────────────────────────────────────────────────────
        //  ToolTipDraw()
        //  ToolTip_MouseLeave()
        //  ToolTip_CellMouseEnter()
        //
        // ── Helper / Navigation ────────────────────────────────────────────────
        //  GetTopLeftHeaderCellBounds()
        //  IsColumnResizeInternalType()
        //  SyncDisplayedColumns()
        //  InvalidateColumnHeaders()
        //  InvalidateColumnArea()
        //  ResetMembersToDefault()
        //  ThreadSafeInvoke()
        //  MoveHorizScrollBar()
        //
        // ── Column Coordinate Helpers ──────────────────────────────────────────
        //  GetLeftmostColumnHeaderXCoordinate()
        //  GetTopmostColumnHeaderYCoordinate()
        //  GetBottommostColumnHeaderYCoordinate()
        //  GetColumnHeight()
        //  GetColumnHeaderHeight()
        //
        // ── Row Search Helpers ─────────────────────────────────────────────────
        //  GetRowIndexInDataGridView()
        //  GetRowInDataGridView()
        //  GetListRowInDataGridView()            // 2 overloads
        //  GetRowListInDataGridView()
        #endregion "Index"

        #region"Properties"

        /// <summary>
        /// The color of the divider displayed between rows while dragging
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("The color of the divider displayed between rows while dragging")]
        public Color DividerColor
        {
            get { return _dividerBrush.Color; }
            set { _dividerBrush = new SolidBrush(value); }
        }

        /// <summary>
        /// Height (in pixels) of the divider to display
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("Height (in pixels) of the divider to display")]
        [DefaultValue(2)]
        public int DividerHeight { get; set; }

        /// <summary>
        /// Width (in pixels) of the border around the selected row
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("Width (in pixels) of the border around the selected row")]
        [DefaultValue(4)]
        public int SelectionBorderWidth { get; set; }
        int HalfSelectionBorderWidth;

        /// <summary>
        /// "The color of the border drawn around the selected row"
        /// </summary>
        Color _currentRowBorderColor;
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("Color of the border drawn around the selected row")]
        public Color CurrentRowBorderColor
        {
            get { return _currentRowBorderColor; }
            set { _currentRowBorderColor = value; }
        }

        /// <summary>
        /// "The Background color of the current row"
        /// </summary>
        Color _currentRowBackgroundColor;
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("Background color of the current row")]
        public Color CurrentRowBackgroundColor
        {
            get { return _currentRowBackgroundColor; }
            set { _currentRowBackgroundColor = value; }
        }


        // Delay timer to initialize lazy handle...
        readonly System.Windows.Forms.Timer initialDelay;

        /// <summary>
        /// DataGridViewColumn used when mouse over row header, is not visible column
        /// row header have no column, use this one.
        /// </summary>
        DataGridViewColumn _rowHeaderColumn;

        public FilteredHeaderCell filteredHeader;
        /// <summary>
        /// Active filter, generated by "Find and Replace" dialog.
        /// or Search By... dialog
        /// </summary>
        string _activefilter = "";
        /// <summary>
        /// Active filter, generated by "Find and Replace" dialog.
        /// or Search By... dialog
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Active filter, generated by "Find and Replace" dialog.
        /// or Search By... dialog
        /// </summary>
        public string ActiveFilter
        {
            get
            {
                if (ActiveFilterCollection.Count == 0)
                    return _activefilter;

                KeyValuePair<int, FilteredHeaderCell> columnFilter;

                _activefilter = "";
                var builder = new StringBuilder();
                builder.Append(_activefilter);

                //Scroll through the contents of the collection to form the filter
                for (int index = 0; index < ActiveFilterCollection.Count; index++)
                {
                    columnFilter = ActiveFilterCollection.ElementAt(index);

                    builder.Append(columnFilter.Value.FilterString);

                    if (index + 1 < ActiveFilterCollection.Count)
                        builder.Append(" AND ");
                }
                _activefilter = builder.ToString();

                if (_activefilter.EndsWith(" AND "))
                    _activefilter = _activefilter.ReplaceLast(" AND ", "");

                return _activefilter;
            }
            set
            {
                if (value == null)
                    return;

                if (ActiveFilterCollection.Count == 0)
                {
                    _activefilter = value;
                    return;
                }

                #region"ColumnHeaderFiltered by user"

                if (ActiveFilterCollection.Count > 0 || value != "")
                {
                    AreInternalFilteredRows = true;

                    KeyValuePair<int, FilteredHeaderCell> columnFilter;

                    _activefilter = "";
                    var builder = new StringBuilder();
                    builder.Append(_activefilter);

                    //Scroll through the contents of the collection to form the filter
                    for (int index = 0; index < ActiveFilterCollection.Count; index++)
                    {
                        columnFilter = ActiveFilterCollection.ElementAt(index);
                        if (columnFilter.Value.FilteredColumnIndex == _currentColumnMouseOverIndex)
                            columnFilter.Value.FilterString = value;

                        builder.Append(columnFilter.Value.FilterString);

                        if (index + 1 < ActiveFilterCollection.Count)
                            builder.Append(" AND ");
                    }
                    _activefilter = builder.ToString();

                    if (_activefilter.EndsWith(" AND "))
                        _activefilter = _activefilter.ReplaceLast(" AND ", "");
                }
                #endregion"ColumnHeaderFiltered by user"               
            }

        }

        /// <summary>
        /// Keep tracking of active Column.
        /// </summary>
        DataGridViewColumn? _currentColumnActive;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewColumn CurrentColumnActive
        {
            get
            {
                return _currentColumnActive;
            }
            set
            {
                _currentColumnActive = value;
            }
        }

        /// <summary>
        /// Return the dataGridView.CurrentRow if it's not null.
        /// </summary>
        public DataGridViewRow CurrentRowActived
        {
            get
            {
                try
                {
                    MessagePositionString = "CurrentRowActived property";
                    if (CurrentRow == null)
                        if (FirstDisplayedScrollingRowIndex != -1)
                        {
                            foreach (DataGridViewCell cell in Rows[FirstDisplayedScrollingRowIndex].Cells)
                                if (cell.Visible)
                                {
                                    MessagePositionString = "CurrentCell set...";
                                    CurrentCell = cell;

                                    if (CurrentRow == null)
                                        return new DataGridViewRow();

                                    MessagePositionString = "return CurrentRow after setting CurrentCell";
                                    return CurrentRow;
                                }
                        }
                        else
                        {
                            return new DataGridViewRow();
                        }

                    return CurrentRow;
                }
                catch (Exception error)
                {
                    using (var form = new Form { TopMost = true })
                    {
                        MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                              @", Break code at position " + MessagePositionString,
                                              @"DataGridViewExtended has generated an error in CurrentRowActived property",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return new DataGridViewRow();
                }
            }
        }

        public int _currentRowMouseOverIndex;
        DataGridViewRow? _currentRowMouseOver;

        /// <summary>
        /// Image to show into header of filtered column a clear option.
        /// </summary>
        //public Image ColumnClearFilterIndicator;

        /// <summary>
        /// Image to show into header of filtered column.
        /// </summary>
        //public Image ColumnFilterIndicator;

        /// <summary>
        /// NeedSaveColumnsSetting is set false, only if the user change column winth, index, visibility or others by mouse
        /// this is true and can by possible save columnsSetting or other setting.
        /// </summary>
        public bool _needSaveSetting;

        /// <summary>
        /// If Active filter, generted by "Find and Remplace" dialog.
        /// or Search By... dialog is a valid filter, this is true.
        /// </summary>
        public bool AreInternalFilteredRows;

        public bool AreSelectedRows;

        public bool _isPainting;

        /// <summary>
        /// Keep tracking of current Column Index were mouse pointer is over.
        /// Update in CellMouseEnter and ColumnHeaderMouseClick.
        /// Yes, that is a known WinForms bug — CellMouseEnter is never fired for TopLeftHeaderCell,
        /// but CellMouseLeave does fire when the mouse exits it
        /// We use MouseMove event to update the current column index when mouse is over TopLeftHeaderCell.
        /// </summary>
        public int _currentColumnMouseOverIndex;
        public int CurrentColumnIndex
        {
            get
            {
                return _currentColumnMouseOverIndex;
            }
        }

        /// <summary>
        /// Keep tracking of current Row Index.
        /// </summary>
        public int CurrentRowIndex
        {
            get
            {
                return CurrentRowActived.Index;
            }
        }

        Rectangle _currentRowHeaderRectMouseHover = new Rectangle();

        DataGridViewCell? _currentCellMouseHover;
        public DataGridViewCell CurrentCellMouseHover
        {
            get
            {
                return _currentCellMouseHover;
            }
        }

        DataGridViewHeaderCell? _currentColumnHeaderCell;
        public DataGridViewHeaderCell CurrentColumnHeaderCell
        {
            get
            {
                return _currentColumnHeaderCell;
            }
        }

        DataGridViewHeaderCell _latestMouseOverColumnHeaderCell;
        public DataGridViewHeaderCell LatestMouseOverColumnHeaderCell
        {
            get
            {
                return _latestMouseOverColumnHeaderCell;
            }
        }

        /// <summary>
        /// Current row ( DataGridViewRow ) where mouse is over, it's update in CellMouseEnter.
        /// The DataGridView have not RowMouseEnter, so we use CellMouseEnter.
        /// Mouse over column header this will be null.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Current row ( DataGridViewRow ) where mouse is over, it's update in CellMouseEnter.
        /// The DataGridView have not RowMouseEnter, so we use CellMouseEnter.
        /// Mouse over column header this will be null.
        /// </summary>
        public DataGridViewRow? CurrentDataGridViewRowMouseEnter { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CurrentStatus CurrentRowMouseEnterStatus { get; set; }

        /// <summary>
        /// Current row ( DataRowView ) where mouse is over, it's update in CellMouseEnter.
        /// The DataGridView have not RowMouseEnter, so we use CellMouseEnter.
        /// Mouse over column header this will be null.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Current row ( DataRowView ) where mouse is over, it's update in CellMouseEnter.
        /// The DataGridView have not RowMouseEnter, so we use CellMouseEnter.
        /// Mouse over column header this will be null.
        /// </summary>
        public DataRowView? CurrentDataRowviewMouseEnter { get; set; }

        /// <summary>
        /// Keep tracking of the last active Column.
        /// </summary>
        public DataGridViewColumn? _lastColumnActive;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewColumn LastColumnActive
        {
            get
            {
                return _lastColumnActive;
            }
            set
            {
                _lastColumnActive = value;
            }
        }

        /// <summary>
        /// Add grouping to any existing ( databound ) DataGridView.
        /// </summary>
        DataGridViewGrouper _grouper;

        /// <summary>
        /// A collection of FilteredColumn.
        /// </summary>
        public SortedDictionary<int, FilteredHeaderCell> ActiveFilterCollection;

        /// <summary>
        /// A collection of selected column, incluide FilteredColumn and SelectedColumn.
        /// In DataGridViewControlExtended_Paint(), we scroll through this collection to paint the background of selected column.
        /// </summary>
        public SortedDictionary<int, SelectedDataGridColumn> SelectedColumnCollection;

        /// <summary>
        /// A collection of selected column header.
        /// </summary>
        public SortedDictionary<int, SelectedDataGridColumn> SelectedColumnHeaderCollection;

        /// <summary>
        /// MyStuff11net.Generic_Sorting, explained in details...
        /// </summary>
        //readonly AggregateBindingListView<ComponentData> _componentDataSource = new AggregateBindingListView<ComponentData>();
               
        DataGridViewCellStyle _dataGridViewCellStyle = new DataGridViewCellStyle();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle DataGridViewCellStyleP
        {
            get
            {
                return _dataGridViewCellStyle;
            }
            set
            {
                _dataGridViewCellStyle = value;
                this.DefaultCellStyle = _dataGridViewCellStyle;
            }
        }

        DataGridViewCellStyle _dataGridViewCellStyleSelectedRow = new DataGridViewCellStyle();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle SelectedRowsDefaultCellStyle
        {
            get
            {
                return _dataGridViewCellStyleSelectedRow;
            }
            set
            {
                _dataGridViewCellStyleSelectedRow = value;
            }
        }

        DataGridViewCellStyle _dataGridViewColumnHeaderCellStyle = new DataGridViewCellStyle();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCellStyle DataGridViewColumnHeaderCellStyle
        {
            get
            {
                return _dataGridViewColumnHeaderCellStyle;
            }
            set
            {
                _dataGridViewColumnHeaderCellStyle = value;
                this.ColumnHeadersDefaultCellStyle = _dataGridViewColumnHeaderCellStyle;
            }
        }

        public Point _mouseLocation;
        public bool IsDragEvent;
        public Rectangle _dragBoxFromMouseDown;
        public int _currentCellClicksCount;
        public bool _isSingleClick;

        /// <summary>
        /// This variable is set to true when the user double click a cell, and is used
        /// to avoid the single click action to be executed after the double click action.
        /// </summary>
        public bool _isDoubleClickEdit;
        public bool ShowColumnWhileDragging = true;
        public bool ShowColumnHeaderWhileDragging = true;

        public bool m_showColumnWhileDragging = true;
        public bool m_showColumnHeaderWhileDragging = true;


        public Rectangle m_mouseOverColumnRect;
        public int m_mouseOverColumnIndex;

        /// <summary>
        /// This fiel is update in DataGridViewControlExtended_CellMouseDown event,
        /// used in MouseTwoClickDetector_Tick event.
        /// </summary>
		int _currentRowIndexMouseClicked;

        /// <summary>
        /// HitTest is a global, it's used in ContextMenuStripDataGridViewOpening
        /// so have to be update always at DataGridViewControlExtended_MouseDown.
        /// Mouse information, such as the row and column indexes, at specific
        /// coordinated pair in DataGridView control.
        /// </summary>
        public HitTestInfo HitTestData;

        //public SelectedDataGridColumn IsSelectedColumn;
        public SelectedDataGridColumn IsDraggedColumn;

        /// <summary>
        /// Message to debug the code. 
        /// </summary>
        public string MessagePositionString;

        #endregion"Fields"         

        #region"Events, Custom Controls Events with custom Args.*********************"

        #region"SettingChanged"

        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SettingChangedEventHandler(object sender, SettingChangedEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("SettingChanged event has changed")]
        public event SettingChangedEventHandler SettingChanged;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_SettingChanged(SettingChangedEventArgs e)
        {
            SettingChanged?.Invoke(this, e);
        }

        public class SettingChangedEventArgs : EventArgs
        {
            // Add properties or fields here as needed
            bool DefaultSetting;

            public SettingChangedEventArgs(bool defaultSetting)
            {
                DefaultSetting = defaultSetting;
            }
        }

        #endregion"SettingChanged"

        #region"PreviewKeyDown"        
        public delegate void PreviewKeyDownEventHandler(object sender, PreviewKeyDownEventArgs e);

        [Category("Controls Events")]
        [Description("PreviewKeyDown event has changed")]
        public event PreviewKeyDownEventHandler PreviewKeyDownEvent;

        protected virtual void OnPreviewKeyDown_Event(PreviewKeyDownEventArgs e)
        {
            PreviewKeyDownEvent?.Invoke(this, e);
        }
        #endregion"PreviewKeyDown"

        #region"CellMouseEnter"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CellMouseEnterEventHandler(object sender, DataGridViewCellEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellMouseEnter has changed")]
        public event CellMouseEnterEventHandler CellsMouseEnter;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnCellsMouseEnter(DataGridViewCellEventArgs e)
        {
            CellsMouseEnter?.Invoke(this, e);
        }

        #endregion"CellMouseEnter"

        #region"RowsMouseEnter"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void RowsMouseEnterEventHandler(object sender, RowsMouseEnterEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("MouseEnter value has changed")]
        public event RowsMouseEnterEventHandler RowsMouseEnter;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnRowsMouseEnter(RowsMouseEnterEventArgs e)
        {
            RowsMouseEnter?.Invoke(this, e);
        }
        #endregion"RowsMouseEnter"

        #region"TopLeftHeaderMouseDown"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void TopLeftHeaderMouseDownEventHandler(object sender, EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("TopLeftHeaderMouseDown event.")]
        public event TopLeftHeaderMouseDownEventHandler TopLeftHeaderMouseDown;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnTopLeftHeaderMouseDown(EventArgs e)
        {
            TopLeftHeaderMouseDown?.Invoke(this, e);
        }
        #endregion"TopLeftHeaderMouseDown"

        #region"TopLeftHeaderMouseUp"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void TopLeftHeaderMouseUpEventHandler(object sender, EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("TopLeftHeaderMouseDown event.")]
        public event TopLeftHeaderMouseUpEventHandler TopLeftHeaderMouseUp;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnTopLeftHeaderMouseUp(EventArgs e)
        {
            TopLeftHeaderMouseUp?.Invoke(this, e);
        }
        #endregion"TopLeftHeaderMouseUp"

        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event StatusBarMessageEventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessageEventHandler(object sender, StatusBarMessage_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            StatusBarMessage?.Invoke(this, e);
        }

        #endregion"StatusBarMessage"

        #endregion"Events, Custom Controls Events with custom Args.*********************"

        /* That's called a Behavioral Flow or Interaction Flow — more formally it's a Sequence Diagram

             Click-and-hold flow:
                MouseDown → timer starts
                    ~250ms → timer tick → SuppressSortOnNextColumnHeaderClick=true → SelectColumn() → SortMode=Programmatic
                MouseUp  (no drag)
            ColumnHeaderMouseClick fires:
                ① DataGridViewControlExtended_ColumnHeaderMouseClick → sees flag=true → BeginInvoke(reset flag + restore SortMode) → returns early
                ② FilteredHeaderCell.DataGridView_ColumnHeaderMouseClick → sees flag=true → returns (no Sort())
            BeginInvoke runs → flag=false, SortMode=Automatic (non-filtered cols)
            ✅ Column selected, no sort

            Quick-click flow:
                MouseDown → timer starts
                MouseUp (fast) → timer stopped before DoubleClickTime/2 → flag stays false → SortMode stays Automatic
            ColumnHeaderMouseClick fires:
                ① DataGridViewControlExtended_ColumnHeaderMouseClick → flag=false → normal filter-clear check
                ② FilteredHeaderCell.DataGridView_ColumnHeaderMouseClick → flag=false → Sort() called ✅
            ✅ Sort happens, no selection


        sequenceDiagram
    actor User
    participant Timer_Single as MouseSingleClickDetectTimer
    participant SelectCol as SelectColumn()
    participant UnSelectCol as UnSelectColumn()
    participant ColHeaderClick as DataGridViewControlExtended#35;ColumnHeaderMouseClick
    participant FilteredCell as FilteredHeaderCell#35;ColumnHeaderMouseClick
    participant BeginInvoke as BeginInvoke (async)

    Note over User,BeginInvoke: ── QUICK CLICK → Sort ──
    User->>Timer_Single: MouseDown → timer starts
    User->>Timer_Single: MouseUp before DoubleClickTime/2 → timer stopped
    Timer_Single-->>ColHeaderClick: ColumnHeaderMouseClick fires, flag=false
    ColHeaderClick-->>FilteredCell: ColumnHeaderMouseClick fires
    FilteredCell->>FilteredCell: flag=false → Sort() ✅

    Note over User,BeginInvoke: ── CLICK-AND-HOLD (1st time) → Select, no sort ──
    User->>Timer_Single: MouseDown + hold
    Timer_Single->>Timer_Single: flag=true, SelectColumn() → SortMode=Programmatic
    User->>ColHeaderClick: MouseUp → ColumnHeaderMouseClick
    ColHeaderClick->>BeginInvoke: flag=true → schedule reset + SortMode=Automatic
    ColHeaderClick-->>FilteredCell: ColumnHeaderMouseClick fires
    FilteredCell->>FilteredCell: flag=true → return, no Sort() ✅
    BeginInvoke->>BeginInvoke: flag=false, SortMode=Automatic ✅

    Note over User,BeginInvoke: ── CLICK-AND-HOLD (2nd time) → Unselect, no sort ──
    User->>Timer_Single: MouseDown + hold same column
    Timer_Single->>Timer_Single: flag=true
    Timer_Single->>UnSelectCol: column in collection → UnSelectColumn()
    UnSelectCol->>UnSelectCol: flag=true → SortMode=Programmatic (force block)
    UnSelectCol->>UnSelectCol: remove from SelectedColumnCollection
    User->>ColHeaderClick: MouseUp → ColumnHeaderMouseClick
    ColHeaderClick->>BeginInvoke: flag=true → schedule reset + SortMode=Automatic
    ColHeaderClick-->>FilteredCell: ColumnHeaderMouseClick fires
    FilteredCell->>FilteredCell: flag=true → return, no Sort() ✅
    BeginInvoke->>BeginInvoke: flag=false, SortMode=Automatic ✅

    Note over User,BeginInvoke: ── DRAG → Reorder, no sort ──
    User->>Timer_Single: MouseDown + move mouse
    Timer_Single->>Timer_Single: MouseMove stops timer, flag stays false
    Timer_Single->>Timer_Single: IsDraggedColumn initialized
    User->>UnSelectCol: MouseUp → IsDraggedColumn!=null → UnSelectColumn()
    UnSelectCol->>UnSelectCol: flag=false → SortMode=Automatic ✅

        */

        public DataGridViewControlExtended() : base()
        {
            try
            {
                AllowUserToAddRows = false;

                Font                                    = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
                _dataGridViewCellStyle.Font             = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 161); 
                _dataGridViewCellStyleSelectedRow.Font  = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 161);
                _dataGridViewColumnHeaderCellStyle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);

                DefaultCellStyle               = _dataGridViewCellStyle;
                RowTemplate.DefaultCellStyle   = _dataGridViewCellStyle;
                ColumnHeadersDefaultCellStyle  = _dataGridViewColumnHeaderCellStyle;

                MessagePositionString = "Initialize initialDelay timer..";
                initialDelay = new System.Windows.Forms.Timer
                {
                    Interval = 100
                };
                initialDelay.Tick += new EventHandler(InitialDelay_Tick);
                initialDelay.Start();

                ActiveFilterCollection = new SortedDictionary<int, FilteredHeaderCell>();
                SelectedColumnHeaderCollection = new SortedDictionary<int, SelectedDataGridColumn>();
                SelectedColumnCollection = new SortedDictionary<int, SelectedDataGridColumn>();

                HitTestData = HitTest(25, 25);
                _mouseLocation = new Point(0, 0);

                InitializeGrouper();
                InitializeToolTip();
                InitializeBrush_Pen_Icon();
                InitializeMouseSingleClickDetectTimer();
                InitializeMouseDoubleClickDetectTimer();

                //Note: The other event handle are initialized in InitialDelay timer.
                RowPrePaint += DataGridViewControlExtended_RowPrePaint;
                RowPostPaint += DataGridViewControlExtended_RowPostPaint;
                SizeChanged += DataGridViewControlExtended_SizeChanged;

            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message,
                                          @"DataGridViewControlExtended, fail in constructor...",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        }


        DataGridViewColumnHeadersHeightSizeMode m_ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        //Set the property in the overridden OnLayout() method:
        //MSDN: Derived classes should override this method to do any custom layout logic.
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            base.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        /// <summary>
        /// Override Sort to block auto-sort during click-and-hold (column select).
        /// This avoids the need to toggle SortMode=Programmatic, which wipes SortGlyphDirection.
        /// </summary>
        public override void Sort(DataGridViewColumn dataGridViewColumn, ListSortDirection direction)
        {
            if (SuppressSortOnNextColumnHeaderClick)
                return;

            base.Sort(dataGridViewColumn, direction);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
        {
            get => m_ColumnHeadersHeightSizeMode;
            set
            {
                m_ColumnHeadersHeightSizeMode = value;
                base.ColumnHeadersHeightSizeMode = m_ColumnHeadersHeightSizeMode;
            }
        }
        
        #region"Brush_Pen_Color"
        /// <summary>
        /// LinearGradientBrush used to paint the background of the odd rows.
        /// </summary>
        LinearGradientBrush _oddRowsGradientBrush;
        /// <summary>
        /// LinearGradientBrush used to paint the background of the even rows.
        /// </summary>
        LinearGradientBrush _evenRowsGradientBrush;
        SolidBrush _dividerBrush;
        SolidBrush _solidBrush;
        SolidBrush blackBrush;
        SolidBrush darkGreyBrush;
        Color unLockedRowColor;
        Color colorToDraw;
        Pen _penRowBorder;
        Pen blackPen;
        Image IconTxT;
        Image IconPDF;
        Image IconDoc;
        Image IconDocx;
        #endregion"Brush_Pen_Color"
        void InitializeBrush_Pen_Icon()
        {
            SelectionBorderWidth = 3;
            unLockedRowColor = Color.LightGray;
            CurrentRowBorderColor = Color.DarkBlue;
            CurrentRowBackgroundColor = Color.DeepSkyBlue;
            HalfSelectionBorderWidth = SelectionBorderWidth / 2;

            IconTxT = Properties.Resources.Document_TXT;
            IconPDF = Properties.Resources.Document_PDF;
            IconDoc = Properties.Resources.Document_Doc;
            IconDocx = Properties.Resources.Document_Doc;

            var rowRect = new Rectangle(0, 0, Width, 35);
            _evenRowsGradientBrush = new LinearGradientBrush(rowRect, Color.LightBlue, Color.White, LinearGradientMode.Horizontal);
            _oddRowsGradientBrush = new LinearGradientBrush(rowRect, Color.White, Color.LightBlue, LinearGradientMode.Horizontal);
            _dividerBrush = new SolidBrush(Color.LightBlue);
            _solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
            _penRowBorder = new Pen(CurrentRowBorderColor, SelectionBorderWidth);

            blackBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
            darkGreyBrush = new SolidBrush(Color.FromArgb(100, 200, 200, 255));
            blackPen = new Pen(blackBrush, 2F);
        }

        void InitialDelay_Tick(object sender, EventArgs e)
        {
            initialDelay.Stop();

            InitializeDataGridView();
        }

        void InitializeDataGridView()
        {
            //We need call this handle to initialized.
            //var X = Handle;
            
            #region"Wire the handles..."

            DataError   += DataGridViewControlExtended_DataError;
            Paint       += DataGridViewControlExtended_Paint;
            Scroll      += DataGridViewControlExtended_Scroll;

            MouseLeave  += DataGridViewControlExtended_MouseLeave;
            MouseUp     += DataGridViewControlExtended_MouseUp;
            MouseDown   += DataGridViewControlExtended_MouseDown;
            MouseMove   += DataGridViewControlExtended_MouseMove;
            MouseClick  += DataGridViewControlExtended_MouseClick;
            MouseWheel  += DataGridViewControlExtended_MouseWheel;

            CellPainting    += DataGridView_TopLeftHeader_CellPainting;
            CellPainting    += DataGridView_ColumnHeader_CellPainting;
            CellMouseUp     += DataGridViewControlExtended_CellMouseUp;
            CellMouseDown   += DataGridViewControlExtended_CellMouseDown;
            CellMouseEnter  += DataGridViewControlExtended_CellMouseEnter;
            CellMouseLeave  += DataGridViewControlExtended_CellMouseLeave;
            CellDoubleClick += DataGridViewControlExtended_CellDoubleClick;

            RowEnter += DataGridViewControlExtended_RowEnterFocus;

            KeyDown         += DataGridViewControlExtended_KeyDown;
            PreviewKeyDown  += DataGridViewControlExtended_PreviewKeyDown;
            KeyUp           += DataGridViewControlExtended_KeyUp;

            ColumnWidthChanged           += DataGridViewControlExtended_ColumnWidthChanged;
            ColumnHeaderMouseClick       += DataGridViewControlExtended_ColumnHeaderMouseClick;
            ColumnDisplayIndexChanged    += DataGridViewControlExtended_ColumnDisplayIndexChanged;

            #endregion"Wire the handles..."

            //DataGridViewColumn used when mouse over row header, is not visible column
            //row header have no column, use this one.
            using (_rowHeaderColumn = new DataGridViewColumn())
            {
                using (var newcell = new DataGridViewTextBoxCell())
                {
                    _rowHeaderColumn.CellTemplate = newcell;
                    _rowHeaderColumn.HeaderText = "";
                    _rowHeaderColumn.ValueType = typeof(string);
                    _rowHeaderColumn.Name = "RowHeaderColumn";
                    _rowHeaderColumn.Visible = false;
                    _rowHeaderColumn.Width = 60;
                    _rowHeaderColumn.SortMode = DataGridViewColumnSortMode.Automatic;

                    Columns.Add(_rowHeaderColumn);
                }
            }

            SyncDisplayedColumns();
        }
                
        void AddColumn(string headerText, string name)
        {
            using (var newColumn = new DataGridViewColumn())
            {
                using (var newcell = new DataGridViewTextBoxCell())
                {
                    newColumn.CellTemplate = newcell;
                    newColumn.HeaderText = headerText;
                    newColumn.ValueType = typeof(int);
                    newColumn.Name = name;
                    newColumn.Visible = true;
                    newColumn.Width = 60;
                    newColumn.SortMode = DataGridViewColumnSortMode.Automatic;

                    Columns.Add(newColumn);
                }
            }
        }

        /// <summary>
        /// Occurs when a row receives input focus but before it becomes the current row.
        /// When event fire, the CurrentRow is the previous row, so we need restore the style of CurrentRow,
        /// remenber that we change the style of CurrentRow in DataGridViewControlExtended_RowPrePaint event to
        /// _dataGridViewCellStyleSelectedRow, so we need restore to _dataGridViewCellStyle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataGridViewControlExtended_RowEnterFocus(object? sender, DataGridViewCellEventArgs e)
        {
            //Occurs when a row receives input focus but before it becomes the current row.
            //But it also fire when the control receives the focus...
            // If CurrentRow == e.RowIndex, it is the selected row, do not change style, Return.
            // When event fire, the CurrentRow is the previous row, so we need restore the style of CurrentRow,
            // remenber that we change the style of CurrentRow in DataGridViewControlExtended_RowPrePaint event to
            // _dataGridViewCellStyleSelectedRow, so we need restore to _dataGridViewCellStyle.
            if (CurrentRow == null || CurrentRow.Index == e.RowIndex)
                return;

            CurrentRow.DefaultCellStyle = _dataGridViewCellStyle;
        }

        int countError = 0;
        void DataGridViewControlExtended_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            if (countError == 0)
            {
                countError++;
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + e.Exception.Message + " " + countError,
                                          @"DataGridViewExtended has generated an error at " + MessagePositionString,
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if(countError >= 1000)
                {
                    countError = 0;
                    return;
                }
                                
                countError++;

                if (countError > 4)
                    return;

                On_StatusBarMessage(new StatusBarMessage_EventArgs("DataGridViewExtended has generated an error, count:" + countError));
            }
        }

        void DataGridViewControlExtended_SizeChanged(object? sender, EventArgs e)
        {
            if (Width == 0)
                return;

            var rowRect = new Rectangle(0, 0, Width, 35);
            _evenRowsGradientBrush = new LinearGradientBrush(rowRect, Color.LightBlue, Color.White, LinearGradientMode.Horizontal);
            _oddRowsGradientBrush = new LinearGradientBrush(rowRect, Color.White, Color.LightBlue, LinearGradientMode.Horizontal);
            ReSelectColumn();
        }

        void DataGridViewControlExtended_ColumnWidthChanged(object? sender, DataGridViewColumnEventArgs e)
        {
            SyncDisplayedColumns();
            ReSelectColumn();
        }

        void DataGridViewControlExtended_ColumnDisplayIndexChanged(object? sender, DataGridViewColumnEventArgs e)
        {
            SyncDisplayedColumns();
            ReSelectColumn();
        }

        #region"KeyDown event & KeyUp event"

        KeyEventArgs _keyEvent = new KeyEventArgs(Keys.Cancel);
        void DataGridViewControlExtended_PreviewKeyDown(object? sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control)
            {
                e.IsInputKey = true;
            }
        }

        /// <summary>
        /// It is only ever called on a key down event, before the control with the focus gets the KeyDown event and
        /// regardless of which client control has the focus.
        /// The method performs no processing on keystrokes that include the ALT or CONTROL modifiers.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Some erratic behavior...
            this.WRTInvokeOnUiThreadIfRequired(() =>
            {
                OnPreviewKeyDown_Event(new PreviewKeyDownEventArgs(keyData));
            });

            if (keyData == Keys.Escape)
            {
                //Close();
                //return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void DataGridViewControlExtended_KeyDown(object? sender, KeyEventArgs e)
        {
            _keyEvent = e;

            #region"Esc  (Escape)"

            if (e.KeyCode == Keys.Escape)
            {
                foreach (DataGridViewRow row in GetListRowInDataGridView("Status", new string[] { "Unerasable:False", "Locked:False" }))
                {
                    if (((DataRowView)row.DataBoundItem).Row.Table.Columns.Contains("Status"))
                    {
                        var status = new CurrentStatus(row)
                        {
                            Unerasable = true,
                            Locked = true
                        };
                        status.UpDateStatus();
                    }
                }

                ResetMembersToDefault();

                Invalidate();
                Update();

                e.Handled = true;
                return;
            }

            #endregion"Esc  (Escape)"

            #region"Control-C  (Copy)"

            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.Clear();

                if (_currentCellMouseHover != null)
                {
                    Clipboard.SetText(_currentCellMouseHover.Value.ToString());
                    e.Handled = true;
                    return;
                }

                if (CurrentDataGridViewRowMouseEnter != null)
                {
                    string rowto;
                    var sb = new StringBuilder();
                    foreach (DataGridViewRow row in SelectedRows)
                    {
                        rowto = "";
                        foreach (DataGridViewColumn column in Columns)
                        {
                            if (!column.Visible)
                                continue;

                            var cellValue = row.Cells[column.Name].Value.ToString();
                            if (string.IsNullOrEmpty(cellValue) || string.IsNullOrWhiteSpace(cellValue))
                                continue;

                            rowto += cellValue + ",   ";
                        }

                        sb.AppendLine(rowto.ReplaceLast(",   ", ""));
                    }

                    Clipboard.SetText(sb.ToString());
                    e.Handled = true;
                    return;
                }
            }

            #endregion"Control-C  (Copy)"
        }

        void DataGridViewControlExtended_KeyUp(object? sender, KeyEventArgs e)
        {
            _keyEvent = e;
        }

        #endregion"KeyDown event & KeyUp event"

        void DataGridViewControlExtended_Paint(object? sender, PaintEventArgs e)
        {
            #region"SelectedColumnHeaderCollection"

            if (SelectedColumnHeaderCollection.Count != 0)
            {
                foreach (KeyValuePair<int, SelectedDataGridColumn> selectedColumnKeyValue in SelectedColumnHeaderCollection)
                {
                    var g = e.Graphics;

                    g.FillRectangle(darkGreyBrush, selectedColumnKeyValue.Value.InitialRegion);
                    //g.DrawRectangle(blackPen, selectedColumn.HeaderCell.ContentBounds);
                }
            }

            #endregion"SelectedColumnHeaderCollection"

            #region"SelectedColumnCollection"

            if (SelectedColumnCollection.Count == 0)
                return;

            foreach (KeyValuePair<int, SelectedDataGridColumn> selectedColumnKeyValue in SelectedColumnCollection)
            {
                var g = e.Graphics;
                SelectedDataGridColumn selectedColumn = selectedColumnKeyValue.Value;

                g.FillRectangle(darkGreyBrush, selectedColumn.InitialRegion);
                g.DrawRectangle(blackPen, selectedColumn.InitialRegion);
            }

            #endregion"SelectedColumnCollection"

            if (IsDraggedColumn != null)
            {
                #region"IsDraggedColumn"

                var g = e.Graphics;
                g.FillRectangle(darkGreyBrush, IsDraggedColumn.InitialRegion);
                g.DrawRectangle(blackPen, IsDraggedColumn.InitialRegion);

                // user feedback indicating which column the dragged column is over
                if (m_mouseOverColumnIndex != -1)
                {
                    using (SolidBrush b = new SolidBrush(Color.FromArgb(100, 100, 100, 100)))
                    {
                        g.FillRectangle(b, m_mouseOverColumnRect);
                    }
                }

                // draw bitmap image
                if (ShowColumnWhileDragging || ShowColumnHeaderWhileDragging)
                {
                    var rect = new Rectangle(IsDraggedColumn.CurrentRegion.X,
                            IsDraggedColumn.CurrentRegion.Y,
                            IsDraggedColumn.ColumnImage.Width,
                            IsDraggedColumn.ColumnImage.Height);

                    g.DrawImage(IsDraggedColumn.ColumnImage,
                        rect,
                        0,
                        0,
                        IsDraggedColumn.ColumnImage.Width,
                        IsDraggedColumn.ColumnImage.Height,
                        GraphicsUnit.Pixel);
                }

                // translucent film
                Pen filmBorder = new Pen(new SolidBrush(Color.FromArgb(255, 200, 200, 230)), 2F);
                var filmFill = new SolidBrush(Color.FromArgb(100, 200, 200, 255));

                g.FillRectangle(filmFill, IsDraggedColumn.InitialRegion);
                g.DrawRectangle(filmBorder, IsDraggedColumn.InitialRegion);

                filmBorder.Dispose();
                filmFill.Dispose();

                #endregion"IsDraggedColumn"
            }
        }

        /// <summary>
        /// Save the event in MouseDown & clear it in MouseUp, because in MouseMove we need to know if it's a drag event or not,
        /// and we also need the information of mouse button, clicks count, etc... so we can use it in other event handlers like
        /// CellMouseDown, ColumnHeaderMouseClick, etc...and in MouseUp we need to reset it to default value for the same reason.
        /// </summary>
        MouseEventArgs _mouseEvent = new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0);
               
        void DataGridViewControlExtended_MouseMove(object? sender, MouseEventArgs e)
        {
            _mouseLocation = e.Location;

            var hit = this.HitTest(e.X, e.Y);
            _currentRowMouseOverIndex = hit.RowIndex;
            _currentColumnMouseOverIndex = hit.ColumnIndex;
                        
            #region "Test if mouse over collapsible sign in row header"

            if (e.Button == MouseButtons.None && _isMouseOverColumnHeaderCell)
            {
                int yCenterOffset = _currentRowHeaderRectMouseHover.Y + _currentRowHeaderRectMouseHover.Height / 2 - CollapseBoxYOffset;
                CollapsibleSignRect = new Rectangle(Header_X_offset - CollapseBoxWidth, yCenterOffset, CollapseBoxWidth, CollapseBoxWidth);

                if (CollapsibleSignRect.Contains(e.Location))
                {
                    IsOverCollapsibleSign = CheckIfMouseOverCollapseExpandSymbol(_currentRowMouseOverIndex);
                }
                else
                {
                    IsOverCollapsibleSign = false;
                    CheckCollapsedFocused(-1, -1);
                }
            }

            #endregion "Test if mouse over collapsible sign in row header"

            #region"Test if it's drag process, if is true go..."

            if (e.Button == MouseButtons.Left)
            {
                if (_dragBoxFromMouseDown != Rectangle.Empty && _dragBoxFromMouseDown.Contains(e.X, e.Y))
                    return;

                IsDragEvent = true;
                if (_isMouseOverColumnHeaderCell && _currentColumnMouseOverIndex >= 0 && _currentColumnMouseOverIndex < Columns.Count)
                    _hitTestColumnDisplayIndex = Columns[_currentColumnMouseOverIndex].DisplayIndex;
            }

            #endregion"Test if it's drag process, if is true go..."

            #region"Mouse over TopLeftHeaderCell"
                        
            if (_currentRowMouseOverIndex == -1 && _currentColumnMouseOverIndex == -1)
            {
                // The mouse is no longer over a column header cell (it's over the
                // top-left header cell instead), so clear the stale flag to avoid
                // indexing Columns[-1] on a subsequent MouseMove.
                _isMouseOverColumnHeaderCell = false;

                IsMouseOverTopLeftHeaderCell = true;

                Rectangle bounds = GetTopLeftHeaderCellBounds();

                var ptRowsHeader = new Point(bounds.Left + 1, bounds.Bottom - 10);
                TopLeftRowsHeaderSelectRect = new Rectangle(ptRowsHeader, new Size(bounds.Width - 2, 9));

                var ptColumnsHeader = new Point(bounds.Right - 10, bounds.Top + 1);
                TopLeftColumnHeaderSelectRect = new Rectangle(ptColumnsHeader, new Size(9, bounds.Height - 2));

                if (TopLeftColumnHeaderSelectRect.Contains(_mouseLocation))
                {
                    IsMouseOverTopLeftColumnHeaderCellGlyph = true;
                }
                else
                    IsMouseOverTopLeftColumnHeaderCellGlyph = false;

                if (TopLeftRowsHeaderSelectRect.Contains(_mouseLocation))
                {
                    IsMouseOverTopLeftRowsHeaderCellGlyph = true;
                }
                else
                    IsMouseOverTopLeftRowsHeaderCellGlyph = false;

                if ((IsMouseOverTopLeftColumnHeaderCellGlyph || IsMouseOverTopLeftRowsHeaderCellGlyph) && !_isPainted)
                {
                    _isPainted = true;
                    this.InvalidateCell(TopLeftHeaderCell);
                }
                else
                {
                    _isPainted = false;
                    this.InvalidateCell(TopLeftHeaderCell);
                }

                if (!_isOverTopLeft)
                {
                    // This flag simulates the enter/leave state of the mouse over the TopLeftHeaderCell,
                    // then the event is fire just the first time.
                    _isOverTopLeft = true;

                    // We fire this event in mouse move event, because that is a known WinForms bug — CellMouseEnter is never fired
                    // for TopLeftHeaderCell, but CellMouseLeave does fire when the mouse exits it. Inconsistent behavior by design.
                    this.OnCellsMouseEnter(new DataGridViewCellEventArgs(-1, -1));
                }
            }
            else if (!IsMouseOverTopLeftHeaderCell && _isOverTopLeft)
            {
                _isOverTopLeft = false;
                // We fire this event in mouse move event, because that is a known WinForms bug — CellMouseEnter is never fired
                // for TopLeftHeaderCell, but CellMouseLeave does fire when the mouse exits it. Inconsistent behavior by design.
                //this.OnCellsMouseLeave(new DataGridViewCellEventArgs(-1, -1));
            }

            #endregion"Mouse over TopLeftHeaderCell"

            #region"Mouse over ColumnHeader"

            if (_currentRowMouseOverIndex == -1 && _currentColumnMouseOverIndex >= 0)
            {
                _isMouseOverColumnHeaderCell = true;

                if (_mouseEvent.Button == MouseButtons.Left)
                {
                    if (IsDraggedColumn != null && e.X >= 0)
                    {
                        #region"Is Dragging a Column"

                        var x = e.X - IsDraggedColumn.CursorLocation.X;

                        // detect the column that the cursor is currently hovering above and
                        // calculate its region.
                        if (_hitTestColumnDisplayIndex >= 0)
                        {
                            if (_hitTestColumnDisplayIndex != m_mouseOverColumnIndex)
                            {
                                // NOTE: moc = mouse over column
                                int mocX = GetLeftmostColumnHeaderXCoordinate(_hitTestColumnDisplayIndex);
                                var mocCol = DisplayedColumns.FirstOrDefault(col => col.DisplayIndex == _hitTestColumnDisplayIndex);
                                if (mocCol != null)
                                {
                                    var mocWidth = mocCol.Width;

                                    // indicate that we want to invalidate the old rectangle area
                                    if (m_mouseOverColumnRect != Rectangle.Empty)
                                        Invalidate(m_mouseOverColumnRect, false);

                                    // if the mouse is hovering over the original column, we do not want to
                                    // paint anything, so we negate the index.
                                    if (_hitTestColumnDisplayIndex == IsDraggedColumn.Index)
                                        m_mouseOverColumnIndex = -1;
                                    else
                                        m_mouseOverColumnIndex = _hitTestColumnDisplayIndex;

                                    m_mouseOverColumnRect = new Rectangle(mocX, IsDraggedColumn.InitialRegion.Y, mocWidth, IsDraggedColumn.InitialRegion.Height);

                                    // invalidate this area so it gets painted when OnPaint is called.
                                    Invalidate(m_mouseOverColumnRect, false);
                                }
                            }

                            var oldX = IsDraggedColumn.CurrentRegion.X;
                            var oldPoint = Point.Empty;

                            // column is being dragged to the right
                            if (oldX < x)
                            {
                                oldPoint = new Point(oldX - 5, IsDraggedColumn.InitialRegion.Y);
                                // to the left
                            }
                            else
                                oldPoint = new Point(x - 5, IsDraggedColumn.InitialRegion.Y);

                            var sizeOfRectangleToInvalidate = new Size(Math.Abs(x - oldX) + IsDraggedColumn.InitialRegion.Width + oldPoint.X * 2, IsDraggedColumn.InitialRegion.Height);
                            Invalidate(new Rectangle(oldPoint, sizeOfRectangleToInvalidate));

                            IsDraggedColumn.CurrentRegion = new Rectangle(x, IsDraggedColumn.InitialRegion.Y, IsDraggedColumn.InitialRegion.Width, IsDraggedColumn.InitialRegion.Height);
                        }
                        else
                        {
                            Invalidate();
                            ResetMembersToDefault();
                            Update();
                        }

                        #endregion"Is Dragging a Column"
                    }
                    else
                    {
                        if (IsDraggedColumn == null)
                        {
                            #region"Starting a drag process"

                            // Stop the timer, was an click....
                            MouseSingleClickDetectTimerStop();
                            ResetMembersToDefault();

                            var xCoordinate = GetLeftmostColumnHeaderXCoordinate(_hitTestColumnDisplayIndex);
                            int yCoordinate = GetTopmostColumnHeaderYCoordinate(e.X, e.Y);
                            var dragCol = DisplayedColumns.FirstOrDefault(col => col.DisplayIndex == _hitTestColumnDisplayIndex);
                            if (dragCol != null)
                            {
                                int columnWidth = dragCol.Width;
                                var columnHeight = GetColumnHeight(yCoordinate);

                                Size columnSize = Size.Empty;

                                var startingLocation = new Point(xCoordinate, yCoordinate);
                                Rectangle columnRegion = new Rectangle(xCoordinate, yCoordinate, columnWidth, columnHeight);
                                var cursorLocation = new Point(e.X - xCoordinate, e.Y - yCoordinate);

                                if (ShowColumnWhileDragging || ShowColumnHeaderWhileDragging)
                                {
                                    if (ShowColumnWhileDragging)
                                    {
                                        columnSize = new Size(columnWidth, columnHeight);
                                    }
                                    else
                                    {
                                        columnSize = new Size(columnWidth, GetColumnHeaderHeight(e.X, yCoordinate));
                                    }

                                    var columnImage = (Bitmap)ScreenImage.GetScreenshot(Handle, startingLocation, columnSize);
                                    IsDraggedColumn = new SelectedDataGridColumn(_hitTestColumnDisplayIndex, columnRegion, cursorLocation, columnImage);
                                }
                                else
                                    IsDraggedColumn = new SelectedDataGridColumn(_hitTestColumnDisplayIndex, columnRegion, cursorLocation, null);

                                IsDraggedColumn.CurrentRegion = columnRegion;
                            }

                            #endregion"Starting a drag process"
                        }
                        // Force the grid to repaint.
                        Update();

                        //_dataGridView.Invalidate(ClientRectangle);
                        //ResetMembersToDefault();
                        //_dataGridView.Update();
                    }
                }
            }
            else
                _isMouseOverColumnHeaderCell = false;

            #endregion"Mouse over ColumnHeader"

            #region"Mouse over RowHeader"

            if (_currentRowMouseOverIndex >= 0 && _currentColumnMouseOverIndex == -1)
            {
                _isMouseOverRowHeaderCell = true;

                // Only start drag when left button is held down
                if (e.Button == MouseButtons.Left && SelectedRows.Count == 1)
                    DoDragDrop(CurrentRow, DragDropEffects.Move);
            }
            else
                _isMouseOverRowHeaderCell = false;
             
            #endregion"Mouse over RowHeader"

            #region"Mouse over Cell"

            if (!_isMouseOverRowHeaderCell && !_isMouseOverColumnHeaderCell)
                _isMouseOverCell = true;
            else
                _isMouseOverCell = false;

            #endregion"Mouse over Cell"

        }

        void DataGridViewControlExtended_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _currentColumnMouseOverIndex == -1)
            {
                if (_grouper.Is_grouped)
                    return;

                if (IsOverCollapsibleSign && CurrentRowMouseEnterStatus != null)
                {
                    bool isExpanded = false;
                    if (Rows.Count > _currentRowIndexMouseClicked + 1)
                        isExpanded = Rows[_currentRowIndexMouseClicked + 1].Visible;

                    Collapse_expand(_currentRowIndexMouseClicked, !isExpanded);
                }
            }

            if (e.Button == MouseButtons.Right && _currentColumnMouseOverIndex == -1)
            {

            }
        }

        void DataGridViewControlExtended_MouseLeave(object? sender, EventArgs e)
        {
            ToolTip_MouseLeave();
        }

        void DataGridViewControlExtended_MouseDown(object? sender, MouseEventArgs e)
        {
            // Note: DataGridViewMouseDown is the first event handler and then is called DataGridViewCellMouseDown event handler,
            // opposite to DataGridViewCellMouseUp/DataGridViewMouseUp event handler.

            // Save the event in MouseDown & clear it in MouseUp, because in MouseDown we need to
            // use it in other event handlers like CellMouseDown, ColumnHeaderMouseClick, etc...
            // and in MouseUp we need to reset it to default value for the same reason.
            _mouseEvent = e;

            // _hitTest is a global, it,s used in ContextMenuStripDataGridViewOpening so have to be update always.
            HitTestData = HitTest(e.X, e.Y);
            if (HitTestData.ColumnIndex > -1)
                _hitTestColumnDisplayIndex = Columns[HitTestData.ColumnIndex].DisplayIndex;

            if (e.Button == MouseButtons.Right)
            {
                if (HitTestData.Type == DataGridViewHitTestType.ColumnHeader && _hitTestColumnDisplayIndex > -1)
                    _latestMouseOverColumnHeaderCell = Columns[HitTestData.ColumnIndex].HeaderCell;
                return;
            }

            if (IsColumnResizeInternalType())
            {
                // Reset _mouseEvent so MouseMove doesn't treat this resize as a column drag,
                // which would cause the resized column to be incorrectly highlighted.
                _mouseEvent = new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0);
                return;
            }

            // In mouse down event, we create System Information.Drag Size rectangle regardless of where the click occurred
            var dragSize = SystemInformation.DragSize;
            _dragBoxFromMouseDown = new Rectangle(new Point(e.X - dragSize.Width / 2, e.Y - dragSize.Height / 2), dragSize);

            #region"MouseDown over TopLeftHeader"

            if (HitTestData.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                MultiSelect = false;

                if (IsMouseOverTopLeftColumnHeaderCellGlyph)
                {
                    if (SelectedColumnHeaderCollection.Count != 0)
                    {
                        SelectAllColumnsHeader(false);
                        return;
                    }
                    else
                    {
                        SelectAllColumnsHeader(true);
                        return;
                    }
                }

                if(IsMouseOverTopLeftRowsHeaderCellGlyph)
                {
                    return;
                }

                ToolStripMenuItem_SortByPDF_Click();
                OnTopLeftHeaderMouseDown(new EventArgs());
                return;
            }

            #endregion"MouseDown over TopLeftHeader"

            #region"MouseDown over ColumnHeader"

            if (HitTestData.Type == DataGridViewHitTestType.ColumnHeader)
            {
                // Start the single click timer.
                MouseSingleClickDetectTimer.Start();
                Cursor = Cursors.Hand;

                return;
            }

            #endregion"MouseDown over ColumnHeader"

            #region"MouseDown over RowHeader"

            if (HitTestData.Type == DataGridViewHitTestType.RowHeader)
            {
                return;
            }

            #endregion"MouseDown over RowHeader"

            #region"MouseDown over Cell"

            if (HitTestData.Type == DataGridViewHitTestType.Cell)
            {
                // Start the double click timer.
                MouseTwoClickDetectorTimer.Change(0, 25); //enable
                Cursor = Cursors.Hand;
                return;
            }

            #endregion"MouseDown over Cell"

        }

        void DataGridViewControlExtended_MouseUp(object? sender, MouseEventArgs e)
        {
            _mouseEvent = new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0);
            MouseSingleClickDetectTimer.Stop();

            #region"MouseUp over TopLeftHeader"

            if (HitTestData.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                OnTopLeftHeaderMouseUp(new EventArgs());
                return;
            }

            #endregion"MouseUp over TopLeftHeader"

            //Set HeaderText only to repaint it again.
         //   if (_currentColumnActive != null)
         //       _currentColumnActive.HeaderText = _currentColumnActive.HeaderText;

         //   Cursor = Cursors.Default;

            if (IsDraggedColumn != null)
            {
                ResetMembersToDefault();
                UnSelectColumn(_hitTestColumnDisplayIndex);

                Invalidate();
                Update();
            }

            // Note: SortMode restoration for click-and-hold is handled by
            // BeginInvoke in DataGridViewControlExtended_ColumnHeaderMouseClick.

        }

        void DataGridViewControlExtended_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                if (IsMouseOverCell)
                {
                    float currentSize = DefaultCellStyle.Font?.Size ?? Font.Size;
                    float newSize = e.Delta > 0 ? currentSize + 0.5f : currentSize - 0.5f;
                    newSize = Math.Clamp(newSize, 10f, 34f);

                    Font newFont = new Font(_dataGridViewCellStyle.Font!.FontFamily, newSize, _dataGridViewCellStyle.Font.Style);

                    Set_DefaultCellStyle_SelectedCellStyle(newFont);
                    On_StatusBarMessage(new StatusBarMessage_EventArgs("DefaultCellStyle font size changed to " + newFont.Size, ""));
                }

                if (IsMouseOverColumnHeaderCell)
                {
                    // ✅ Column headers
                    if (ColumnHeadersDefaultCellStyle.Font != null)
                    {
                        float currentSizeHeader = ColumnHeadersDefaultCellStyle.Font.Size;
                        float newSizeHeader = Math.Clamp(e.Delta > 0 ? currentSizeHeader + 0.5f : currentSizeHeader - 0.5f, 10f, 34f);
                        Font colHeaderFont = new Font(ColumnHeadersDefaultCellStyle.Font.FontFamily, newSizeHeader,
                                                      ColumnHeadersDefaultCellStyle.Font.Style);

                        Set_ColumnHeaderCellStyle(colHeaderFont);
                        On_StatusBarMessage(new StatusBarMessage_EventArgs("ColumnHeaderCellStyle font size changed to " + colHeaderFont.Size, ""));
                    }
                }

                ((HandledMouseEventArgs)e).Handled = true;
                On_SettingChanged(new SettingChangedEventArgs(true));
            }
        }

        public void Set_DefaultCellStyle_SelectedCellStyle(Font newFont)
        {
            if (newFont is null) return;

            Font newFontSelected = new Font(newFont.FontFamily, newFont.Size + 2f, FontStyle.Bold);

            // ✅ Update the two backing style objects directly
            _dataGridViewCellStyle.Font = newFont;
            _dataGridViewCellStyleSelectedRow.Font = newFontSelected;

            // ✅ Sync grid-level styles
            this.Font = newFont;
            this.DefaultCellStyle.Font = newFont;
            base.RowsDefaultCellStyle.Font = newFont;
            RowTemplate.DefaultCellStyle.Font = newFont;

            if (!_doOverDefaultCellStyleScheduled)
            {
                _doOverDefaultCellStyleScheduled = true;

                if (IsHandleCreated)
                {
                    // Using BeginInvoke here batches rapid wheel events into a single style
                    // pass at the end of the current message loop, which also eliminates flicker.
                    BeginInvoke(() =>
                    {
                        DoOverDefaultCellStyle();
                        _doOverDefaultCellStyleScheduled = false;
                    });
                }
                else
                {
                    // Handle not yet created (e.g. called during constructor/DI setup),
                    // apply immediately or defer until the handle is ready.
                    void OnHandleCreated(object? s, EventArgs e)
                    {
                        HandleCreated -= OnHandleCreated;
                        DoOverDefaultCellStyle();
                        _doOverDefaultCellStyleScheduled = false;
                    }
                    HandleCreated += OnHandleCreated;
                }
            }

            Invalidate();
            Update();
        }

        public void Set_ColumnHeaderCellStyle(Font colHeaderFont)
        {
            _dataGridViewColumnHeaderCellStyle.Font = colHeaderFont;
            ColumnHeadersHeight = colHeaderFont.Height + _rowHeightAdd;
            InvalidateColumnHeaders(colHeaderFont);
        }

        /// <summary>
        /// This method forces each row to re-apply the DefaultCellStyle,
        /// which is necessary for the font change to take effect on all cells.
        /// </summary>
        bool _doOverDefaultCellStyleScheduled = false;
        void DoOverDefaultCellStyle()
        {
            _doOverDefaultCellStyleScheduled = true;

            // ✅ Force each row to use the correct backing style with the new font
            //    Row.DefaultCellStyle = Row.DefaultCellStyle is a no-op — we must re-assign
            //    the actual style object so the grid picks up the font change.
            foreach (DataGridViewRow row in Rows)
            {
                row.DefaultCellStyle = _dataGridViewCellStyle;
            }
        }

        //  The flag _isOverTopLeft simulates the enter/leave state of the mouse over the TopLeftHeaderCell,
        //  because the CellMouseEnter event is never fired for TopLeftHeaderCell, but CellMouseLeave does fire
        //  when the mouse exits it. Inconsistent behavior by design.
        bool _isOverTopLeft = false;
        bool IsOverCollapsibleSign;
        bool _isPainted = false;
        Rectangle CollapsibleSignRect;
        public int _hitTestColumnDisplayIndex = -1;

        /// <summary>
        /// This property is set to true when the mouse is over the TopLeftHeaderCell,
        /// and false when the mouse leave it.
        /// </summary>
        bool IsMouseOverTopLeftHeaderCell       = false;
        Rectangle ColumnClearFilterIndicatorRect = new Rectangle(5,5,5,5);

        /// <summary>
        /// These two flags are used to determine if the mouse is over the respective glyph areas in the top-left header cell,
        /// which allows us to provide visual feedback and handle clicks on those areas for selecting all rows or columns.
        /// The rectangles define the areas within the top-left header cell that are considered "glyph" areas for rows and columns.
        /// Ths are updated dynamically in the MouseMove, MouseDown event based on the current mouse position to ensure they are always in the
        /// correct location relative to the top-left header cell.
        /// </summary>
        bool _isMouseOverTopLeftRowsHeaderCellGlyph   = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// This property is set to true when the mouse is over the TopLeftHeaderCell glyph for the rows header,
        /// and false when the mouse leaves it.
        /// </summary>
        public bool IsMouseOverTopLeftRowsHeaderCellGlyph
        {
            get => _isMouseOverTopLeftRowsHeaderCellGlyph;
            set
            {
                if (_isMouseOverTopLeftRowsHeaderCellGlyph != value)
                {
                    _isMouseOverTopLeftRowsHeaderCellGlyph = value;                    
                }
            }
        }

        /// <summary>
        /// The rectangle defines the area within the top-left header cell that is considered the "glyph" area for the rows header.
        /// </summary>
        Rectangle TopLeftRowsHeaderSelectRect = new Rectangle(5,5,5,5);

        /// <summary>
        /// This flag is used to determine if the mouse is over the column header glyph area in the top-left header cell,
        /// which allows us to provide visual feedback and handle clicks on that area for selecting all columns headers.
        /// </summary>
        bool _isMouseOverTopLeftColumnHeaderCellGlyph = false;
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// This property is set to true when the mouse is over the TopLeftHeaderCell glyph for the column header,
        /// and false when the mouse leaves it.
        /// </summary>
        public bool IsMouseOverTopLeftColumnHeaderCellGlyph
        {
            get => _isMouseOverTopLeftColumnHeaderCellGlyph;
            set
            {
                if (_isMouseOverTopLeftColumnHeaderCellGlyph != value)
                {
                    _isMouseOverTopLeftColumnHeaderCellGlyph = value;                    
                }
            }
        }

        /// <summary>
        /// The rectangle defines the area within the top-left header cell that is considered the "glyph" area for the column header.
        /// </summary>
        Rectangle TopLeftColumnHeaderSelectRect = new Rectangle(5,5,5,5);

        Pen PenColumnClearFilterIndicador = new(Color.Black, 1);

        Rectangle GetTopLeftHeaderCellBounds()
        {
            // TopLeftHeaderCell bounds = intersection of RowHeaders width and ColumnHeaders height
            return new Rectangle(
                0,
                0,
                this.RowHeadersWidth,
                this.ColumnHeadersHeight
            );
        }
        
        bool CheckIfMouseOverCollapseExpandSymbol(int rowIndex)
        {
            CheckCollapsedFocused(-1, rowIndex);
            return true;
        }

        void InvalidateHeaderCell()
        {
            if (_capturedCollapseBox.X == -1 || _capturedCollapseBox.Y == -1)
                return;

            InvalidateCell(_capturedCollapseBox.X, _capturedCollapseBox.Y);
        }

        void CheckCollapsedFocused(int col, int row)
        {
            if (_capturedCollapseBox.X == col && _capturedCollapseBox.Y == row)
                return;

            InvalidateHeaderCell();
            _capturedCollapseBox = new Point(col, row);
            InvalidateHeaderCell();
        }

        void Collapse_expand(int index, bool show)
        {
            if (!Columns.Contains("PartNumber"))
                return;

            SuspendLayout();
            //If datagridviewrow is selected, genera error.....
            foreach (var row in Get_rows(index))
            {
                if (row.Selected)
                    continue;

                row.Visible = show;
            }

            ResumeLayout();
        }

        IEnumerable<DataGridViewRow> Get_rows(int index)
        {
            while (++index < Rows.Count && Rows[index].DataBoundItem.GetType() != typeof(BindingSourceGroups.GroupRow) && !Rows[index].Cells["PartNumber"].Value.ToString().Contains("AT60"))
                yield return Rows[index];
        }

        /// <summary>
        /// Manually paint column header cells to ensure sort glyph is always visible, even when EnableHeadersVisualStyles=false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataGridView_ColumnHeader_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            // Only column headers (not top-left, not filtered columns — FilteredHeaderCell handles those)
            if (e.RowIndex != -1 || e.ColumnIndex < 0)
                return;

            // If this column has a FilteredHeaderCell, it handles its own painting — skip.
            if (ActiveFilterCollection.ContainsKey(e.ColumnIndex))
                return;

            e.PaintBackground(e.ClipBounds, true);
            e.PaintContent(e.ClipBounds);

            // Manually draw sort glyph when EnableHeadersVisualStyles=false suppresses it.
            if (SortedColumn != null && SortedColumn.Index == e.ColumnIndex && SortOrder != SortOrder.None)
            {
                bool ascending = SortOrder == SortOrder.Ascending;
                
                // Scale glyph to column header height.
                int glyphHeight = Math.Max(4, e.CellBounds.Height / 3);
                int glyphWidth = glyphHeight * 2;                      // keep equilateral-ish ratio
                int glyphX = e.CellBounds.Right - glyphWidth - 6;      // right-aligned with margin
                int glyphCenterY = e.CellBounds.Top + e.CellBounds.Height / 2;

                Point[] triangle = ascending  // ▲
                    ? new Point[]
                    {
                        new Point(glyphX,              glyphCenterY + glyphHeight / 2),
                        new Point(glyphX + glyphWidth, glyphCenterY + glyphHeight / 2),
                        new Point(glyphX + glyphWidth / 2, glyphCenterY - glyphHeight / 2)
                    }
                    : new Point[]             // ▼
                    {
                        new Point(glyphX,              glyphCenterY - glyphHeight / 2),
                        new Point(glyphX + glyphWidth, glyphCenterY - glyphHeight / 2),
                        new Point(glyphX + glyphWidth / 2, glyphCenterY + glyphHeight / 2)
                    };

                e.Graphics.FillPolygon(Brushes.Black, triangle);
            }

            e.Handled = true;
        }

        /// <summary>
        /// Manually paint the TopLeftHeaderCell to draw custom glyphs when mouse is over them, and also to ensure consistent visual feedback
        /// for mouse hover since CellMouseEnter is never fired for this cell (but CellMouseLeave is fired when the mouse exits it).
        /// Inconsistent behavior by design in WinForms.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataGridView_TopLeftHeader_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            // We are in the top left header cell. DataGridViewHeaderCell type, but not all events are fire for this cell,
            // like CellMouseEnter, but CellMouseLeave is fire when the mouse exit it. Inconsistent behavior by design.
            // Remenber that TopLeftHeaderCell do not fire CellMouseEnter.
            if (e.RowIndex != -1 || e.ColumnIndex != -1)
                return;                        

            e.PaintBackground(e.ClipBounds, true);
            //  e.CellStyle.ForeColor = Color.Crimson;
            e.PaintContent(e.ClipBounds);
                       
            /*
            this.Cursor = Cursors.Default;        // Normal arrow
            this.Cursor = Cursors.Arrow;          // Arrow
            this.Cursor = Cursors.Hand;           // 👆 Pointing hand (links)
            this.Cursor = Cursors.WaitCursor;     // ⏳ Hourglass / spinning wheel
            this.Cursor = Cursors.AppStarting;    // Arrow + hourglass
            this.Cursor = Cursors.Cross;          // ✛ Crosshair
            this.Cursor = Cursors.IBeam;          // | Text cursor
            this.Cursor = Cursors.No;             // 🚫 Not allowed
            this.Cursor = Cursors.SizeAll;        // ✥ Move (4-way arrow)
            this.Cursor = Cursors.SizeNS;         // ↕ Resize vertical
            this.Cursor = Cursors.SizeWE;         // ↔ Resize horizontal
            this.Cursor = Cursors.SizeNESW;       // ↗↙ Resize diagonal
            this.Cursor = Cursors.SizeNWSE;       // ↖↘ Resize diagonal
            this.Cursor = Cursors.HSplit;         // Horizontal splitter
            this.Cursor = Cursors.VSplit;         // Vertical splitter
            this.Cursor = Cursors.Help;           // Arrow + ?
            this.Cursor = Cursors.UpArrow;        // ↑ Up arrow
            this.Cursor = Cursors.PanEast;        // Pan right
            this.Cursor = Cursors.PanWest;        // Pan left
            this.Cursor = Cursors.PanNorth;       // Pan up
            this.Cursor = Cursors.PanSouth;       // Pan down
            */

            if (IsMouseOverTopLeftHeaderCell)
            {
                if (IsMouseOverTopLeftColumnHeaderCellGlyph)
                {
                   // e.Graphics.FillRoundedRectangle(Brushes.LightYellow, TopLeftColumnHeaderSelectRect, new Size(1, 1));
                   // e.Graphics.DrawRoundedRectangle(PenColumnClearFilterIndicador, TopLeftColumnHeaderSelectRect, new Size(1, 1));
                    e.Graphics.FillPolygon(Brushes.Black, new Point[]
                    {
                        new Point(TopLeftColumnHeaderSelectRect.Left , TopLeftColumnHeaderSelectRect.Top),
                        new Point(TopLeftColumnHeaderSelectRect.Right, TopLeftColumnHeaderSelectRect.Height / 2),
                        new Point(TopLeftColumnHeaderSelectRect.Left, TopLeftColumnHeaderSelectRect.Bottom)
                    });
                }

                if (IsMouseOverTopLeftRowsHeaderCellGlyph)
                {
                    //e.Graphics.FillRoundedRectangle(Brushes.LightBlue, TopLeftRowsHeaderSelectRect, new Size(1, 1));
                    //e.Graphics.DrawRoundedRectangle(PenColumnClearFilterIndicador, TopLeftRowsHeaderSelectRect, new Size(1, 1));
                    e.Graphics.FillPolygon(Brushes.Black, new Point[]
                    {
                        new Point(TopLeftRowsHeaderSelectRect.Left , TopLeftRowsHeaderSelectRect.Top),
                        new Point(TopLeftRowsHeaderSelectRect.Right, TopLeftRowsHeaderSelectRect.Top),
                        new Point(TopLeftRowsHeaderSelectRect.Width / 2, TopLeftRowsHeaderSelectRect.Bottom)
                    });
                }

                // Access it:
                TopLeftHeaderCell.Value = "";
                //DataGridViewHeaderCell topLeftHeaderCell = TopLeftHeaderCell;
            }

            e.Handled = true;
        }

        void DataGridViewControlExtended_CellMouseUp(object? sender, DataGridViewCellMouseEventArgs e)
        {
            // Note: DataGridViewCellMouseUp  is the first event handler and then is called DataGridViewMouseUp event handler,
            // opposite to DataGridViewMouseDown/DataGridViewCellMouseDown event handler.

            // Stop the timer, was an click....
            MouseSingleClickDetectTimerStop();
        }

        // Add this field near the other click-tracking fields
        bool _cellWasAlreadyCurrentOnMouseDown = false;

        void DataGridViewControlExtended_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (HitTestData.ColumnIndex == -1 || Columns[HitTestData.ColumnIndex].ReadOnly)
                return;

            // Track whether this click landed on the cell that was ALREADY current.
            // First click on a new cell → just selects it (no edit).
            // Click on the already-current cell → qualifies for edit mode.
            _cellWasAlreadyCurrentOnMouseDown = CurrentCell != null
                && CurrentCell.ColumnIndex == HitTestData.ColumnIndex
                && CurrentCell.RowIndex == HitTestData.RowIndex;

            if (_currentRowIndexMouseClicked == HitTestData.RowIndex)
            {
                _currentCellClicksCount++;
            }
            else
            {
                _currentRowIndexMouseClicked = HitTestData.RowIndex;
                _currentCellClicksCount = 1;
            }
        }

        int rowIndex = 0;
        void DataGridViewControlExtended_CellMouseEnter(object? sender, DataGridViewCellEventArgs e)
        {
            _currentColumnMouseOverIndex = e.ColumnIndex;
            _currentRowMouseOverIndex = e.RowIndex;

            CurrentDataRowviewMouseEnter = null;
            CurrentDataGridViewRowMouseEnter = null;

            _currentRowMouseOver = null;
            _currentColumnHeaderCell = null;
            _currentColumnActive = null;
            _currentCellMouseHover = null;

            // TopLeftHeaderCell event.
            if (_currentRowMouseOverIndex == -1 && _currentColumnMouseOverIndex == -1)
            {
                _currentColumnActive = _rowHeaderColumn;
                return;
            }

            // Column header event.
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                _currentColumnActive = Columns[_currentColumnMouseOverIndex];
                _currentColumnHeaderCell = Columns[_currentColumnMouseOverIndex].HeaderCell;
                return;
            }

            // Row header event.
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
            {
                _currentColumnActive = _rowHeaderColumn;
                _currentCellMouseHover = Rows[e.RowIndex].HeaderCell;
                _currentRowMouseOver = Rows[e.RowIndex];
                _currentRowHeaderRectMouseHover = GetCellDisplayRectangle(_currentColumnMouseOverIndex, e.RowIndex, true);
            }

            // Cells event.
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _currentColumnActive = Columns[_currentColumnMouseOverIndex];
                _currentCellMouseHover = this[_currentColumnMouseOverIndex, e.RowIndex];
                _currentRowMouseOver = Rows[e.RowIndex];

                OnCellsMouseEnter(e);
            }

            try
            {
                //If the mouse move between cells into the same row...return
                if (rowIndex == e.RowIndex)
                    return;
                //Store for next cicle
                rowIndex = e.RowIndex;

                CurrentDataGridViewRowMouseEnter = Rows[e.RowIndex];
                if (CurrentDataGridViewRowMouseEnter == null)
                    return;

                if (CurrentDataGridViewRowMouseEnter.DataBoundItem.GetType() == typeof(DataRowView))
                    CurrentDataRowviewMouseEnter = CurrentDataGridViewRowMouseEnter.DataBoundItem as DataRowView;

                CurrentRowMouseEnterStatus = new CurrentStatus(CurrentDataGridViewRowMouseEnter);

                OnRowsMouseEnter(new RowsMouseEnterEventArgs(CurrentDataGridViewRowMouseEnter, CurrentDataRowviewMouseEnter, CurrentRowMouseEnterStatus));
            }
            catch (Exception error)
            {
                string Error = error.Message;
                return;
            }

            ToolTip_CellMouseEnter(e);
        }

        void DataGridViewControlExtended_CellMouseLeave(object? sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == -1 && e.RowIndex == -1)
            {
                _isOverTopLeft = false;
                IsMouseOverTopLeftHeaderCell = false;
            }

            //If the mouse move between cells into the same row...return
           // if (rowIndex == e.RowIndex)
           //     return;

           // rowIndex = 0;
        }

        void DataGridViewControlExtended_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            // Stop the timer — double-click confirmed.
            MouseTwoClickDetectorTimer.Change(Timeout.Infinite, Timeout.Infinite); // disable
            _currentCellClicksCount = 0;
            millisecondsSecondClick = 0;
            _isSingleClick = false;

            // Flag MUST be set here — DataGridView calls BeginEditInternal internally
            // as part of its own double-click handling, BEFORE CellDoubleClick returns.
            // DataGridViewCellBeginEdit checks this flag and cancels the edit.
            _isDoubleClickEdit = true;

            if (IsCurrentCellInEditMode)
                CancelEdit();

            Cursor = Cursors.Default;

            // Reset the flag after all double-click event handlers have finished
            // so the next single-click can enter edit mode normally.
            BeginInvoke(() => _isDoubleClickEdit = false);
        }

        void DataGridViewControlExtended_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (SuppressSortOnNextColumnHeaderClick)
            {
                // Reset the flag after all ColumnHeaderMouseClick handlers have run.
                BeginInvoke(() =>
                {
                    SuppressSortOnNextColumnHeaderClick = false;
                });
                return;
            }

            if (ActiveFilterCollection.Count > 0 && _currentColumnHeaderCell != null)
                if (ActiveFilterCollection.ContainsKey(_currentColumnHeaderCell.ColumnIndex))
                {
                    filteredHeader = ActiveFilterCollection[_currentColumnHeaderCell.ColumnIndex];

                    if (filteredHeader.IsMouseOverColumnClearFilterIndicator)
                    {
                        ActiveFilterCollection.Remove(_currentColumnHeaderCell.ColumnIndex);
                        ActiveFilter = "";

                        if (ActiveFilterCollection.Count == 0)
                            EnableHeadersVisualStyles = true;
                    }
                }
        }
                

        void DataGridViewControlExtended_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (CurrentRow == null || e.RowIndex == -1)
                    return;
                                
                if (e.RowIndex == CurrentRow?.Index)
                {
                    if (Rows[e.RowIndex].DefaultCellStyle == _dataGridViewCellStyleSelectedRow)
                        return;

                    Rows[e.RowIndex].DefaultCellStyle = _dataGridViewCellStyleSelectedRow;
                }
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                          @", Break code at position " + MessagePositionString,
                                          @"DataGridViewExtended has generated an error in _dataGridView_RowPrePaint().",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
                
        CurrentStatus _currentRowPostPaintStatus;
        Rectangle RowBoundsColumnsDisplayed;
        int numberOfIconToDraw = 0;
        int counterIconDrawn = 0;
        readonly int offsetImageX = 5;
        public int _rowHeightAdd = 4;
        public int _rowHeightSelectedAdd = 10;

        void DataGridViewControlExtended_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.IsFirstDisplayedRow)
                _isPainting = true;

            if (Columns.GetColumnCount(DataGridViewElementStates.Displayed) == 0)
                return;

            try
            {
                if (CurrentRow == null)
                    return;

                // Defer row height changes to avoid conflict with auto-fill column resizing,
                // which throws InvalidOperationException if row height is set during a paint cycle.
                int targetHeight;
                if (e.RowIndex == CurrentRow.Index)
                {
                    targetHeight = _dataGridViewCellStyle.Font.Height + _rowHeightSelectedAdd;
                    if (CurrentRow.Height != targetHeight)
                    {
                        var row = CurrentRow;
                        BeginInvoke(() => { row.Height = targetHeight; });
                    }
                }
                else
                {
                    targetHeight = _dataGridViewCellStyle.Font.Height + _rowHeightAdd;
                    if (Rows[e.RowIndex].Height != targetHeight)
                    {
                        var row = Rows[e.RowIndex];
                        BeginInvoke(() => { row.Height = targetHeight; });
                    }
                }

                RowBoundsColumnsDisplayed = e.RowBounds;
                RowBoundsColumnsDisplayed.Width = Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
                RowBoundsColumnsDisplayed.X = RowHeadersWidth;

                MessagePositionString = "_currentRowPostPaintStatus initialization";
                var _currentRow = Rows[e.RowIndex];
                if (_currentRow == null)
                    return;

                _currentRowPostPaintStatus = new CurrentStatus(_currentRow);

                #region"HeaderInformation"

                if (_currentRowPostPaintStatus.ExistIconInf)
                {
                    MessagePositionString = "HeaderInformation.";
                    var offsetImageY = (e.RowBounds.Height - IconTxT.Height) / 2;
                    var pt = new Point(e.RowBounds.Left + offsetImageX, e.RowBounds.Location.Y + offsetImageY);
                    var DocumentTypeIconRect = new Rectangle(pt, IconTxT.Size);

                    counterIconDrawn = 0;

                    if (RowHeadersWidth <= 25)
                        numberOfIconToDraw = 0;

                    if (RowHeadersWidth >= 25 && RowHeadersWidth < 50)
                        numberOfIconToDraw = 1;

                    if (RowHeadersWidth >= 50 && RowHeadersWidth < 75)
                        numberOfIconToDraw = 2;

                    if (RowHeadersWidth >= 75)
                        numberOfIconToDraw = 10;

                    if (numberOfIconToDraw > 0)
                    {
                        #region"Draw Icon Process"
                        foreach (Tuple<string, string> headerInf in _currentRowPostPaintStatus.HeaderInformationObj.HeaderIconList)
                        {
                            switch (headerInf.Item1)
                            {
                                case "txt":
                                    {
                                        e.Graphics.DrawImage(IconTxT, pt);
                                        pt = new Point(pt.X + IconTxT.Width + offsetImageX, pt.Y);
                                        break;
                                    }
                                case "pdf":
                                    {
                                        e.Graphics.DrawImage(IconPDF, pt.X, pt.Y);
                                        //e.Graphics.DrawImage(IconPDF, pt);
                                        pt = new Point(pt.X + IconTxT.Width + offsetImageX, pt.Y);
                                        break;
                                    }
                                case "doc":
                                    {
                                        e.Graphics.DrawImage(IconDoc, pt);
                                        pt = new Point(pt.X + IconTxT.Width + offsetImageX, pt.Y);
                                        break;
                                    }
                                case "docx":
                                    {
                                        e.Graphics.DrawImage(IconDocx, pt);
                                        pt = new Point(pt.X + IconTxT.Width + offsetImageX, pt.Y);
                                        break;
                                    }
                            }
                            counterIconDrawn++;

                            if (counterIconDrawn == numberOfIconToDraw)
                                break;
                        }
                        #endregion"Draw Icon Process"
                        //e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                        //e.Graphics.DrawString("Your Text Here", font, solidBrush, pt);
                    }

                    e.PaintHeader(DataGridViewPaintParts.Border);
                }

                #endregion"HeaderInformation"

                #region"Alternate row paint."
                MessagePositionString = "Alternate row paint.";

                if (e.RowIndex % 2 == 0) //Even row...
                    e.Graphics.FillRectangle(_evenRowsGradientBrush, RowBoundsColumnsDisplayed);
                else
                    e.Graphics.FillRectangle(_oddRowsGradientBrush, RowBoundsColumnsDisplayed);

                #endregion"Alternate row paint."                

                #region"MouseOverRow Hot mode"
                /* TODO: Implement hot mode for mouse over row, but first need to decide if it's really useful for the user, because we already
                 * have a lot of visual indicators for the current row like selection by status, selected, note, etc... and maybe this hot mode
                 * can be more confusing than helpful. Also, is not working good because when the mouse move between cells into the same row, the
                 * RowPostPaint is called and the hot mode is lost, so need to find a way to keep it until the mouse leave the row.
               if (CurrentDataGridViewRowMouseEnter != null && CurrentDataGridViewRowMouseEnter.Index == e.RowIndex)
               {
                   //_selectionPen.Width = 1;
                   //_selectionPen.Color = Color.Red;
                   //e.Graphics.DrawRectangle(_selectionPen, eRowBounds.X, eRowBounds.Y,
                   //						 eRowBounds.Width, eRowBounds.Height - 2);
                   e.Graphics.FillRectangle(new SolidBrush(_currentRowPostPaintStatus.SelectedColor), RowBoundsColumnsDisplayed);

                   e.PaintCellsContent(RowBoundsColumnsDisplayed);
                   e.PaintCells(RowBoundsColumnsDisplayed, DataGridViewPaintParts.Border);
                   return;
               }
               */
                #endregion"MouseOverRow Hot mode"              

                #region"Select by Status."

                #region"Selected"

                if (_currentRow.Selected || _currentRowPostPaintStatus.Selected)
                {
                    MessagePositionString = "Select by Status.";
                    _solidBrush = new SolidBrush(CurrentRowBackgroundColor);
                    e.Graphics.FillRectangle(_solidBrush, RowBoundsColumnsDisplayed);
                }

                #endregion"Selected"

                #region"Is UnLocked"
                MessagePositionString = "Is UnLocked";

                if (!_currentRowPostPaintStatus.Locked)
                {
                    _solidBrush = new SolidBrush(unLockedRowColor);
                    e.Graphics.FillRectangle(_solidBrush, RowBoundsColumnsDisplayed);
                }
                #endregion"Is UnLocked"

                #region"Note"

                MessagePositionString = "Note";

                if (_currentRowPostPaintStatus.HasNote)
                {
                    _solidBrush = new SolidBrush(_currentRowPostPaintStatus.SelectedNoteColor);
                    e.Graphics.FillRectangle(_solidBrush, RowBoundsColumnsDisplayed);
                }

                #endregion"Note"

                #region"IsAnAssembly"
                MessagePositionString = "IsAnAssembly";

                //    if (_currentRowPostPaintStatus.IsBOM)
                //    {
                //        PaintBOMRow(e);
                //    }
                #endregion"IsAnAssembly"

                #endregion"Select by Status."

                #region"Current row, Selection type."

                if (CurrentRow != null)
                {
                    // if is painting now the current row?
                    if (e.RowIndex == CurrentRow.Index)
                    {
                        MessagePositionString = "CurrentRow != null";
                        colorToDraw = CurrentRowBackgroundColor;

                        if (_currentRowPostPaintStatus.Selected)
                            colorToDraw = _currentRowPostPaintStatus.SelectedColor;

                        if (!_currentRowPostPaintStatus.Locked)
                            colorToDraw = unLockedRowColor;

                        if (_currentRowPostPaintStatus.HasNote)
                            colorToDraw = _currentRowPostPaintStatus.SelectedNoteColor;

                        _solidBrush = new SolidBrush(colorToDraw);
                        e.Graphics.FillRectangle(_solidBrush, RowBoundsColumnsDisplayed);
                        e.Graphics.DrawRectangle(_penRowBorder, e.RowBounds.X + HalfSelectionBorderWidth, e.RowBounds.Y + HalfSelectionBorderWidth,
                                                e.RowBounds.Width - SelectionBorderWidth, e.RowBounds.Height - SelectionBorderWidth - HalfSelectionBorderWidth);
                    }
                }

                #endregion"Current row, Selection type."

                MessagePositionString = "e.PaintCellsContent";
                e.PaintCellsContent(RowBoundsColumnsDisplayed);
                MessagePositionString = "e.PaintCells";
                e.PaintCells(RowBoundsColumnsDisplayed, DataGridViewPaintParts.Border);

                var y = RowBoundsColumnsDisplayed.Bottom + RowBoundsColumnsDisplayed.Height;
                if (y > e.ClipBounds.Bottom)
                    _isPainting = false;

            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is " + error.Message + " " + MessagePositionString,
                                 @"DataGridViewRowPostPaint has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {

            }
        }

        int Header_X_offset
        {
            get
            {
                if (RowHeadersVisible)
                    return RowHeadersWidth - LineOffSet;

                return LineOffSet * 4;
            }
        }
        const int CollapseBoxWidth = 14;
        const int CollapseBoxYOffset = CollapseBoxWidth / 2;
        const int LineOffSet = CollapseBoxWidth / 2;
        readonly Pen _linePen = Pens.SteelBlue;
        Point _capturedCollapseBox = new Point(-1, -1);

        void PaintBOMRow(DataGridViewRowPostPaintEventArgs e)
        {
            #region"collapse/expand symbol"

            Rectangle RowHeaderRec = e.RowBounds;
            RowHeaderRec.Width = RowHeadersWidth;

            int yCenterOffset = RowHeaderRec.Y + RowHeaderRec.Height / 2 - CollapseBoxYOffset;
            Rectangle CollapseBoxRec = new Rectangle(Header_X_offset - CollapseBoxWidth, yCenterOffset, CollapseBoxWidth, CollapseBoxWidth);

            if (_capturedCollapseBox.Y == e.RowIndex)
                e.Graphics.FillEllipse(Brushes.Yellow, CollapseBoxRec);

            // Draw a Ellipse inside the rectangle CollapseBoxRec.
            e.Graphics.DrawEllipse(_linePen, CollapseBoxRec);

            var rowIndex = e.RowIndex + 1 <= Rows.Count ? e.RowIndex + 1 : e.RowIndex;
            bool isExpanded = !Rows[rowIndex].Visible;
            int cx;

            if (RowHeadersVisible && !isExpanded)
            {
                cx = Header_X_offset - LineOffSet;
                e.Graphics.DrawLine(_linePen, cx, CollapseBoxRec.Bottom, cx, RowHeaderRec.Bottom);
            }

            CollapseBoxRec.Inflate(-2, -2);
            var cy = CollapseBoxRec.Y + CollapseBoxRec.Height / 2;
            //Draw the horizontal line inside collapsible sing.
            e.Graphics.DrawLine(_linePen, CollapseBoxRec.X, cy, CollapseBoxRec.Right, cy);

            if (isExpanded)
            {
                cx = CollapseBoxRec.X + CollapseBoxRec.Width / 2;
                e.Graphics.DrawLine(_linePen, cx, CollapseBoxRec.Top, cx, CollapseBoxRec.Bottom);
            }

            #endregion"collapse/expand symbol"
        }


        void DataGridViewControlExtended_Scroll(object? sender, ScrollEventArgs e)
        {
            if (_isPainting)
                return;

            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll && e.NewValue < e.OldValue)
                Invalidate();
        }

        int columnIndexSortMode;
        readonly System.Windows.Forms.Timer timeDelaySortCancel = new System.Windows.Forms.Timer();
        public void SortCancel(int index)
        {
            timeDelaySortCancel.Tick += TimeDelaySortCancel_Tick;
            timeDelaySortCancel.Interval = 1000;
            columnIndexSortMode = index;

            timeDelaySortCancel.Start();
        }

        /// <summary>
        /// Test if the user is resizing a column header left, right, top or bottom border.
        /// </summary>
        /// <returns></returns>
        public bool IsColumnResizeInternalType()
        {
          //  if (HitTestData.ColumnIndex == -1)
          //      return true;

            var _type = DataGridViewHitTestType.ColumnHeader;

            // make sure that the user is hovering above a column header and not a column border.
            var ColumnResizeInternalType = HitTestData.GetPrivateField("_typeInternal");
            if (ColumnResizeInternalType.Contains("ColumnResizeLeft") || ColumnResizeInternalType.Contains("ColumnResizeRight") ||
                ColumnResizeInternalType.Contains("ColumnHeadersResizeTop") || ColumnResizeInternalType.Contains("ColumnHeadersResizeBottom") ||
                ColumnResizeInternalType.Contains("TopLeftHeaderResizeRight") ||
                ColumnResizeInternalType.Contains("TopLeftHeaderResizeLeft") ||
                ColumnResizeInternalType.Contains("TopLeftHeaderResizeTop") ||
                ColumnResizeInternalType.Contains("TopLeftHeaderResizeBottom"))

                return true;

            return false;
        }

        /// <summary>
        /// Collection of columns displayed, orden by DisplayedIndex.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]        
        public IEnumerable<DataGridViewColumn> DisplayedColumns { get; set; }

        bool _isMouseOverColumnHeaderCell = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// This property is set to true when the mouse is over a column header cell,
        /// and false when the mouse leave it.
        /// </summary>
        public bool IsMouseOverColumnHeaderCell
        {
            get
            {
                return _isMouseOverColumnHeaderCell;
            }
            set
            {
                _isMouseOverColumnHeaderCell = value;
            }
        }
        
        bool _isMouseOverRowHeaderCell = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// This property is set to true when the mouse is over a row header cell,
        /// and false when the mouse leave it.
        /// </summary>
        public bool IsMouseOverRowHeaderCell
        {
            get
            {
                return _isMouseOverRowHeaderCell;
            }
            set
            {
                _isMouseOverRowHeaderCell = value;
            }
        }
        
        bool _isMouseOverCell = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// This property is set to true when the mouse is over a cell,
        /// and false when the mouse leave it.
        /// </summary>
        public bool IsMouseOverCell
        {
            get
            {
                return _isMouseOverCell;
            }
            set
            {
                _isMouseOverCell = value;
            }
        }

        /// <summary>
        /// When true, the next ColumnHeaderMouseClick sort is suppressed because
        /// it originated from a click-and-hold (column selection), not a quick click.
        /// Reset asynchronously via BeginInvoke after all ColumnHeaderMouseClick handlers run.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SuppressSortOnNextColumnHeaderClick { get; set; } = false;
        
        /// <summary>
        /// Kept in sync DisplayedColumns collection, is kept in sync with ColumnDisplayIndexChanged event,
        /// ColumnDividerWidthChanged event.
        /// </summary>
        void SyncDisplayedColumns()
        {
            DisplayedColumns = Columns.Cast<DataGridViewColumn>().Where(col => col.Displayed).OrderBy(i => i.DisplayIndex);
        }

        void TimeDelaySortCancel_Tick(object sender, EventArgs e)
        {
            timeDelaySortCancel.Stop();
            timeDelaySortCancel.Tick -= TimeDelaySortCancel_Tick;
            Columns[columnIndexSortMode].SortMode = DataGridViewColumnSortMode.Automatic;
        }


        public void ToolStripMenuItem_SortByPDF_Click()
        {
            if (!Columns.Contains("CountPDF"))
                return;

            switch (SortOrder)
            {
                case SortOrder.None:
                    {
                        Sort(Columns["CountPDF"], ListSortDirection.Ascending);
                        TopLeftHeaderCell.Value = "▲";
                        break;
                    }
                case SortOrder.Ascending:
                    {
                        Sort(Columns["CountPDF"], ListSortDirection.Descending);
                        TopLeftHeaderCell.Value = "▼";
                        break;
                    }
                case SortOrder.Descending:
                    {
                        Sort(Columns["CountPDF"], ListSortDirection.Ascending);
                        TopLeftHeaderCell.Value = "▲";
                        break;
                    }
            }
        }


        #region"Grouper"

        void InitializeGrouper()
        {
            _grouper = new DataGridViewGrouper(this)
            {
                SortOrder = SortOrder.None
            };

            //    _grouperDetailsView = new DataGridViewDatailsView.DataGridViewDatailsView(this)
            //    {
            //        SortOrder = SortOrder.None
            //   };
        }

        public void SetGroupOn()
        {
            _grouper.SetGroupOn(_currentColumnActive);
            //_grouperDetailsView.SetGroupOn(_currentColumnActive);
        }

        public void ExpandAll()
        {
            _grouper.Expand_all();
            //_grouperDetailsView.Expand_all();
        }

        public void CollapseAll()
        {
            _grouper.Collapse_all();
            // _grouperDetailsView.Collapse_all();
        }

        #endregion"Grouper"


        #region"DataGridView ToolTip"

        ToolTip _toolTip;
        void InitializeToolTip()
        {
            ShowCellToolTips = false;

            _toolTip = new ToolTip
            {
                IsBalloon = true,
                AutomaticDelay = 0,
                OwnerDraw = true,
                ShowAlways = true,
                UseAnimation = false,
                UseFading = false
            };
            _toolTip.Draw += ToolTipDraw;
        }

        // if toolTip.IsBalloon = true, toolTip_Draw never is called.
        void ToolTipDraw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Chocolate, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));
            e.Graphics.DrawString(_toolTip.ToolTipTitle + e.ToolTipText, e.Font, Brushes.Red, e.Bounds);
        }

        void ToolTip_MouseLeave()
        {
            _toolTip.Hide(this);
        }

        string messageErrorPosition = "";
        int _cellColumnIndex = -1, _cellRowIndex = -1;
        void ToolTip_CellMouseEnter(DataGridViewCellEventArgs e)
        {
            #region"try"
            try
            {
                messageErrorPosition = "try starting...";
                if (e.RowIndex == -1)
                {
                    _cellColumnIndex = e.ColumnIndex;
                    _cellRowIndex = e.RowIndex;

                    _toolTip.SetToolTip(this, "");
                    _toolTip.Hide(this);
                    return;
                }

                messageErrorPosition = "If Grouping is active...";
                #region"If Grouping is active"
                try
                {
                    if (Rows[e.RowIndex] == null || Rows[e.RowIndex].DataBoundItem.GetType().Name == "GroupRow")
                        return;

                    if (Rows[e.RowIndex].DataBoundItem.GetType() == typeof(ComponentData) ||
                        Rows[e.RowIndex].DataBoundItem.GetType() == typeof(PlacementData))
                    {
                        return;
                    }
                }
                catch (Exception)
                {
                    return;
                }
                #endregion"If Grouping is active"

                //If current cell is in edit mode ... return.
                if (CurrentCell != null && CurrentCell.IsInEditMode)
                {
                    _toolTip.SetToolTip(this, "");
                    _toolTip.Hide(this);
                    return;
                }

                messageErrorPosition = "If mouse is over a different row...";
                //The DataGridView have not RowMouseEnter, so we use CellMouseEnter
                //If mouse is over a different row, we need all variables for this row where mouse is over....
                if (e.ColumnIndex != _cellColumnIndex || e.RowIndex != _cellRowIndex)
                {
                    _toolTip.SetToolTip(this, "");
                    _toolTip.Hide(this);

                    _cellColumnIndex = e.ColumnIndex;
                    _cellRowIndex = e.RowIndex;

                    messageErrorPosition = "If (_cellColumnIndex >= 0 && _cellRowIndex >= 0)...";
                    if (_cellColumnIndex >= 0 && _cellRowIndex >= 0)
                    {
                        var mousePos = PointToClient(MousePosition);
                        string tip;

                        #region"IsNotLocked"

                        if (!CurrentRowMouseEnterStatus.Locked)
                        {
                            tip = "Attention, this line is not locked.\r\n" +
                                  "To lock it press Esc or right-click\r\n" +
                                  "over row header and click \"Lock\"";

                            _toolTip.ToolTipTitle = "Warning, it itemEFtableTreeView is not locked.";
                            _toolTip.ToolTipIcon = ToolTipIcon.Warning;
                            _toolTip.SetToolTip(this, tip);
                            _toolTip.Show(tip, this, mousePos);
                        }

                        #endregion"IsNotLocked"

                        #region"IsMarkWithNote"

                        if (CurrentRowMouseEnterStatus.IsMarkWithNote)
                        {
                            tip = CurrentRowMouseEnterStatus.Note;

                            _toolTip.ToolTipTitle = "Attention, this itemEFtableTreeView is marked with a note.";
                            _toolTip.ToolTipIcon = ToolTipIcon.Info;
                            _toolTip.SetToolTip(this, tip);
                            _toolTip.Show(tip, this, mousePos);
                        }

                        #endregion"IsMarkWithNote"

                        #region"IsMarkToDelete"

                        if (CurrentRowMouseEnterStatus.IsMarkToDelete)
                        {
                            tip = "Attention, this itemEFtableTreeView is marked for deletion.\r\n" +
                                  "To deselect press Esc or right-click over\r\n" +
                                  "row header and click \"Mark as Unerasable\"";

                            _toolTip.ToolTipTitle = "Warning, it itemEFtableTreeView is marked to be delete.";
                            _toolTip.ToolTipIcon = ToolTipIcon.Warning;
                            _toolTip.SetToolTip(this, tip);
                            _toolTip.Show(tip, this, mousePos);
                        }

                        #endregion"IsMarkToDelete"

                        #region"Status_Error"

                        messageErrorPosition = "Status_Error...";
                        if (CurrentDataRowviewMouseEnter != null && CurrentDataRowviewMouseEnter.Row.HasErrors)
                        {
                            tip = CurrentDataRowviewMouseEnter.Row.RowError + "\r\nFix the error and save.";

                            _toolTip.ToolTipTitle = "Warning error: ";
                            _toolTip.ToolTipIcon = ToolTipIcon.Error;
                            _toolTip.SetToolTip(this, tip);
                            _toolTip.Show(tip, this, mousePos);
                        }

                        #endregion"Status_Error"

                        #region"If Column Status is visible..."

                        if (CurrentColumnActive != null && CurrentColumnActive.HeaderText.Contains("Status"))
                        {
                            tip = CurrentRowMouseEnterStatus.HeaderInformationObj.ToToolTipString();

                            _toolTip.ToolTipTitle = CurrentRowMouseEnterStatus.PartNumber + " it's Status information.";
                            _toolTip.ToolTipIcon = ToolTipIcon.Info;
                            _toolTip.SetToolTip(this, tip);
                            _toolTip.Show(tip, this, mousePos);
                        }

                        #endregion"If Column Status is visible..."
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message + messageErrorPosition,
                                 @"DataGridView has generated an error at ToolTip_CellMouseEnter().", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion"try"
        }


        #endregion"DataGridView ToolTip"

        #region"Mouse Two Click Detector"

        int millisecondsSecondClick;
        System.Threading.Timer MouseTwoClickDetectorTimer;

        void InitializeMouseDoubleClickDetectTimer()
        {
            //DoSomething = procedure to callback, null = object pass to, First interval = 0 ms, subsequent intervals = 1000 ms
            MouseTwoClickDetectorTimer = new System.Threading.Timer(new TimerCallback(MouseTwoClickDetector_Tick), null, Timeout.Infinite, Timeout.Infinite);
        }

        void MouseTwoClickDetector_Tick(object? sender)
        {
            millisecondsSecondClick += 25;

            if (millisecondsSecondClick >= SystemInformation.DoubleClickTime)
            {
                MouseTwoClickDetectorTimer.Change(Timeout.Infinite, Timeout.Infinite); // disable

                Invoke(new EventHandler(delegate (object? o, EventArgs e)
                {
                    Cursor = Cursors.Default;

                    // Only enter edit mode if:
                    //   - it was a single click (count == 1), AND
                    //   - the click was on the cell that was ALREADY current/active
                    //     (first click merely selects the cell, second single click edits it).
                    if (_currentCellClicksCount == 1
                        && HitTestData.RowIndex > -1
                        && _cellWasAlreadyCurrentOnMouseDown)
                    {
                        BeginEdit(true);
                        InvalidateCell(HitTestData.ColumnIndex, HitTestData.RowIndex);
                    }

                    _currentCellClicksCount = 0;
                }));

                _isSingleClick = true;
                millisecondsSecondClick = 0;
            }
        }

        #endregion"Mouse Double Click Detect"

        #region"Mouse Single Click Detect"

        int millisecondsSingleClick;
        /// <summary>
        /// This timer star at MouseDown event, if it's over columnHeader, start the timer and if the timer reach
        /// the half of system double click time, we process the single click action, if not, we wait for the second click.
        /// Interval = 25.
        /// </summary>
        System.Windows.Forms.Timer MouseSingleClickDetectTimer;

        void InitializeMouseSingleClickDetectTimer()
        {
            MouseSingleClickDetectTimer = new System.Windows.Forms.Timer
            {
                Interval = 25
            };
            MouseSingleClickDetectTimer.Tick += MouseSingleClickDetectTimer_Tick;
        }

        void MouseSingleClickDetectTimer_Tick(object? sender, EventArgs e)
        {
            millisecondsSingleClick += 25;

            // The timer has not reached the single click time limit. 
            if (millisecondsSingleClick <= SystemInformation.DoubleClickTime / 2)
                return;

            millisecondsSingleClick = 0;
            MouseSingleClickDetectTimer.Stop();

            Cursor = Cursors.Default;
            // Allow the MouseDown event handler to process clicks again.
            _isSingleClick = true;

            // This is a click-and-hold — suppress the sort that ColumnHeaderMouseClick
            // would otherwise trigger (sort should only happen on a quick click).
            SuppressSortOnNextColumnHeaderClick = true;

            SelectColumnLogicProcess();
        }

        void MouseSingleClickDetectTimerStop()
        {
            MouseSingleClickDetectTimer.Stop();
            millisecondsSingleClick = 0;
        }

        #endregion"Mouse Single Click Detect"

        void SelectColumnLogicProcess()
        {
            if (_keyEvent.Control)
            {
                if (SelectedColumnCollection.ContainsKey(_hitTestColumnDisplayIndex))
                    UnSelectColumn(_hitTestColumnDisplayIndex);
                else
                    SelectColumn();
            }
            else
            {
                if (SelectedColumnCollection.ContainsKey(_hitTestColumnDisplayIndex))
                    UnSelectColumn(_hitTestColumnDisplayIndex);
                else
                {
                    SelectedColumnCollection.Clear();
                    SelectColumn();
                }
            }
        }

        public void SelectColumn()
        {
            var xCoordinate = GetLeftmostColumnHeaderXCoordinate(_hitTestColumnDisplayIndex);
            var yCoordinate = GetTopmostColumnHeaderYCoordinate(HitTestData.ColumnX, HitTestData.RowY);
            var columnWidth = DisplayedColumns.First(col => col.DisplayIndex == _hitTestColumnDisplayIndex).Width;
            var columnHeight = GetColumnHeight(yCoordinate);

            var columnRegion = new Rectangle(xCoordinate, yCoordinate, columnWidth, columnHeight);

            SelectedColumnCollection.Add(_hitTestColumnDisplayIndex, new SelectedDataGridColumn(HitTestData, columnRegion, _hitTestColumnDisplayIndex));

            Invalidate();
            Update();
        }

        /// <summary>
        /// Recalculate the column region after a resize event, column width event.
        /// </summary>
        public void ReSelectColumn()
        {
            if (SelectedColumnCollection.Count == 0)
                return;

            foreach (KeyValuePair<int, SelectedDataGridColumn> selectedColumnKeyValue in SelectedColumnCollection)
            {
                SelectedDataGridColumn selectedColumn = selectedColumnKeyValue.Value;
                var xCoordinate = GetLeftmostColumnHeaderXCoordinate(selectedColumn.HitTestColumnDisplayIndex);
                var yCoordinate = GetTopmostColumnHeaderYCoordinate(selectedColumn.HitInfo.ColumnX, selectedColumn.HitInfo.RowY);
                DataGridViewColumn columnSelect = DisplayedColumns.FirstOrDefault(col => col.DisplayIndex == selectedColumn.HitTestColumnDisplayIndex);

                var columnWidth = selectedColumn.InitialRegion.Width;
                if (columnSelect != null)
                    columnWidth = columnSelect.Width;

                var columnHeight = GetColumnHeight(yCoordinate);

                var columnRegion = new Rectangle(xCoordinate, yCoordinate, columnWidth, columnHeight);

                selectedColumn.CurrentRegion = columnRegion;
            }

            Invalidate();
            Update();
        }

        public void UnSelectColumn(int columnDisplayIndex)
        {
            var col = DisplayedColumns.FirstOrDefault(c => c.DisplayIndex == columnDisplayIndex);

            if (col != null && !ActiveFilterCollection.ContainsKey(col.Index))
            {
                // SortMode is NOT changed here — Sort() override blocks unwanted sorts.
                // FilteredHeaderCell manages SortMode for filtered columns itself.
            }

            SelectedColumnCollection.Remove(columnDisplayIndex);
            Invalidate();
            Update();
        }

        /// <summary>
        /// Clear all selected columns.
        /// </summary>
        public void ClearSelectedColumns()
        {
            ResetMembersToDefault();
            SelectedColumnCollection.Clear();

            Invalidate();
            Update();
        }

        /// <summary>
        /// Selects all visible columns, adding them to SelectedColumnHeaderCollection.
        /// Triggered by clicking the column-select arrow in the TopLeftHeaderCell glyph for the column header.
        /// </summary>
        /// <param name="selectcol">If set to true, selects all columns; otherwise, clears the selection.</param>
        public void SelectAllColumnsHeader(bool selectcol)
        {
            if (selectcol)
            {
                SelectedColumnHeaderCollection.Clear();

                foreach (var col in DisplayedColumns)
                {
                    var xCoordinate = GetLeftmostColumnHeaderXCoordinate(col.DisplayIndex);
                    var yCoordinate = GetTopmostColumnHeaderYCoordinate(HitTestData.ColumnX, HitTestData.RowY);
                    var columnWidth = DisplayedColumns.First(c => c.DisplayIndex == col.DisplayIndex).Width;
                    var columnHeight = ColumnHeadersHeight;

                    var columnRegion = new Rectangle(xCoordinate, yCoordinate, columnWidth, columnHeight);

                    SelectedColumnHeaderCollection.Add(col.DisplayIndex, new SelectedDataGridColumn(HitTestData,
                                                                            columnRegion, _hitTestColumnDisplayIndex));
                }
            }
            else
                SelectedColumnHeaderCollection.Clear();

            Invalidate();
            Update();
        }

        #region Helper Methods
        /// <summary>
        /// Resets all of the member fields to their default values.
        /// </summary>
        public void ResetMembersToDefault()
        {
            _currentCellClicksCount = 0;

            // Fields used in drag process, set it's default value.
            IsDragEvent = false;
            _dragBoxFromMouseDown = Rectangle.Empty;
            Cursor = Cursors.Default;

            if (IsDraggedColumn != null)
                IsDraggedColumn.Dispose();

            IsDraggedColumn = null;
            _dragBoxFromMouseDown = Rectangle.Empty;
            m_mouseOverColumnRect = Rectangle.Empty;
            m_mouseOverColumnIndex = -1;
        }

        /// <summary>
        /// When a dragged column is dropped on top of its original location, 
        /// whether it’s because the user has decided that they no longer want 
        /// to drag it, or they’ve just happened to release the column in this 
        /// location, we need to invalidate the area where the current drawings 
        /// reside.
        /// </summary>
        public void InvalidateColumnArea()
        {
            if (IsDraggedColumn != null)
            {
                int startX = (IsDraggedColumn.InitialRegion.X < IsDraggedColumn.CurrentRegion.X ? IsDraggedColumn.InitialRegion.X : IsDraggedColumn.CurrentRegion.X) - 5;
                var width = IsDraggedColumn.InitialRegion.Width + IsDraggedColumn.CurrentRegion.Width + 10;
                var rectangleToInvalidate = new Rectangle(startX, IsDraggedColumn.InitialRegion.Y, width, IsDraggedColumn.InitialRegion.Height);

                Invalidate(rectangleToInvalidate);
                Update();
            }
        }

        /// <summary>
        /// Returns the height of the column. The height is defined as the area 
        /// between the bottom portion of the caption area and either the 
        /// bottom of the client rectangle, or the top of the horizontal scroll 
        /// bar if it’s visible.
        /// </summary>
        public int GetColumnHeight(int topmostYCoordinate)
        {
            var height = ClientSize.Height;

            //   if (  ScrollBars. HorizScrollBar.Visible)
            //       height -= HorizScrollBar.Height;

            return height - topmostYCoordinate;
        }

        /// <summary>
        /// Returns the height of the column header. In order to make this 
        /// calculation, you  need to pass in the topmost y-coordinate of the 
        /// header. This method will then invoke the 
        /// GetBottommostColumnHeaderYCoordinate, which is a recursive method 
        /// that is invoked repeatedly until the DataGrid hit test determines 
        /// that the current coordinates no longer lie within the boundaries 
        /// of a ColumnHeader.
        /// </summary>
        public int GetColumnHeaderHeight(int x, int y)
        {
            return GetBottommostColumnHeaderYCoordinate(x, y) - y;
        }

        /// <summary>
        /// Calculates the leftmost x coordinate for the column corresponding 
        /// to the parameterized column index. By accessing the GridColumnStyle 
        /// style – which is discussed in the article -- we’re able to get the 
        /// current column widths (this changes when you resize columns) for 
        /// the columns that precede the current column. 
        /// </summary>
        public int GetBottommostColumnHeaderYCoordinate(int x, int currentY)
        {
            var hti = HitTest(x, currentY);
            var yCoordinate = currentY;

            if (hti.Type == DataGridViewHitTestType.ColumnHeader)
                yCoordinate = GetBottommostColumnHeaderYCoordinate(x, ++currentY);

            return yCoordinate;
        }

        /// <summary>
        /// Calculates the leftmost x coordinate for the column corresponding 
        /// to the parameterized column index. By accessing the 
        /// GridColumnStyle style, which is discussed in detail in the article,
        /// we’re able to get the current column widths (this changes when you 
        /// resize columns) for the columns that precede the current column. 		
        /// </summary>
        public int GetLeftmostColumnHeaderXCoordinate(int displayedIndex)
        {
            var xCoordinate = RowHeadersVisible ? RowHeadersWidth : 0;

            foreach (var column in DisplayedColumns)
            {
                if (column.DisplayIndex == displayedIndex)
                    break;

                xCoordinate += column.Width;
            }

            return xCoordinate;// - HorizontalScrollingOffset;
        }

        /// <summary>
        /// This is another recursive method that returns the Y-coordinate of 
        /// the topmost portion of the column header. First, a check is 
        /// performed to see if the DataGrid caption is visible. If not, the 
        /// Y-coordinate is set to zero and the method returns. Otherwise, a 
        /// recursion is performed until the DataGrid hit test determines that 
        /// the current Y-coordinate value does not fall within the boundaries 
        /// of a ColumnHeader. 
        /// </summary>
        public int GetTopmostColumnHeaderYCoordinate(int currentX, int currentY)
        {
            var hti = HitTest(currentX, currentY);
            var yCoordinate = currentY;

            if (!ColumnHeadersVisible)
                yCoordinate = 0;
            else
                if (hti.Type == DataGridViewHitTestType.ColumnHeader)
                    yCoordinate = GetTopmostColumnHeaderYCoordinate(currentX, --currentY);
                else
                    yCoordinate++;

            return yCoordinate;
        }

        /// <summary>
        /// Positions the horizontal scroll bar and invalidates the 
        /// </summary>
        /// <param name="amount">todo: describe amount parameter on MoveHorizScrollBar</param>
        public void MoveHorizScrollBar(int amount)
        {
            HorizontalScrollingOffset = amount;
            Update();
        }

        /// <summary>
        /// Returns the row index that meets CellValue in the column specified by columnName.
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="cellValue"></param>
        public int GetRowIndexInDataGridView(string columnName, string cellValue)
        {
            var _rowIndexBindingSource = -1;

            if (!Columns.Contains(columnName))
                return _rowIndexBindingSource;

            //if (Columns[columnName].ValueType == typeof(string))
            _rowIndexBindingSource = Rows.OfType<DataGridViewRow>().Where(x => x.Cells[columnName].Value.ToString().Equals(cellValue,
                                                                                    StringComparison.InvariantCultureIgnoreCase))
                                                                                   .ToArray()[0].Index;
            return _rowIndexBindingSource;
        }

        /// <summary>
        /// Returns the first row that meets the condition in column columnName and cell CellValue
        /// </summary>
        /// <param name="columnName">Column name where checks for...</param>
        /// <param name="cellValue">Cell value to find....</param>
        /// <returns></returns>
        public DataGridViewRow GetRowInDataGridView(string columnName, string cellValue)
        {
            var _rowInDataGridView = Rows.OfType<DataGridViewRow>().Where(x =>
                                                 x.Cells[columnName].Value.ToString().Contains(cellValue))
                                                 .ToArray().FirstOrDefault();
            return _rowInDataGridView;
        }

        public List<DataGridViewRow> GetListRowInDataGridView(string columnName, string cellValue)
        {
            var _rowList = Rows.OfType<DataGridViewRow>().Where(x =>
                                             x.Cells[columnName].Value.ToString().Contains(cellValue))
                                             .ToList();
            return _rowList;
        }

        public List<DataGridViewRow> GetListRowInDataGridView(string columnName, string[] cellValues)
        {
            var _rowList = new List<DataGridViewRow>();

            foreach (string cellValue in cellValues)
            {
                _rowList.AddRange(Rows.OfType<DataGridViewRow>().Where(x =>
                                             x.Cells[columnName].Value.ToString().Contains(cellValue))
                                             .ToList());
            }

            return _rowList;
        }

        /// <summary>
        /// Returns the row index that meets CellValue in the column specified by columnName.
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="cellValue"></param>
        public IEnumerable<DataGridViewRow> GetRowListInDataGridView(string columnName, string cellValue)
        {
            foreach (var row in Rows.OfType<DataGridViewRow>().Where(x =>
                         x.Cells[columnName].Value.ToString().Contains(cellValue)))
            {
                yield return row;
            }
        }

        #endregion

        public class SelectedDataGridColumn : IDisposable
        {
            Point m_cursorLocation;
            Rectangle m_initialRegion;
            Rectangle m_currentRegion;
            int m_index;
            readonly Image m_columnImage;
            bool disposed;
            readonly int _hitTestColumnDisplayIndex;
            readonly HitTestInfo _hitTest;

            #region Properties

            /// <summary>
            /// An integer representing the original column index.
            /// </summary>
            public int Index
            {
                get
                {
                    CheckState();
                    return m_index;
                }
            }

            public int HitTestColumnDisplayIndex
            {
                get
                {
                    CheckState();
                    return _hitTestColumnDisplayIndex;
                }
            }

            public HitTestInfo HitInfo
            {
                get
                {
                    return _hitTest;
                }
            }

            /// <summary>
            /// A Rectangle structure that identifies the region of the column at
            /// the time the drag and drop operation was initiated.
            /// </summary>	
            public Rectangle InitialRegion
            {
                get
                {
                    CheckState();
                    return m_initialRegion;
                }
            }

            /// <summary>
            /// A Rectangle structure that identifies the current region of the 
            /// column that is being dragged. This is the only member that can be 
            /// modified after an instance has been created.
            /// </summary>
            public Rectangle CurrentRegion
            {
                get
                {
                    CheckState();
                    return m_currentRegion;
                }
                set
                {
                    CheckState();
                    m_currentRegion = value;
                    m_initialRegion = value;
                }
            }

            /// <summary>
            /// A Bitmap object containing a bitmap representation of the column at 
            /// the time that the drag and drop operation was initiated.
            /// </summary>
            public Image ColumnImage
            {
                get
                {
                    CheckState();
                    return m_columnImage;
                }
            }

            /// <summary>
            /// A Point structure representing the cursor location relative to the 
            /// origin of m_initialRegion.
            /// </summary>
            public Point CursorLocation
            {
                get
                {
                    CheckState();
                    return m_cursorLocation;
                }
            }

            #endregion

            public SelectedDataGridColumn(HitTestInfo hitTest, Rectangle initialRegion, int hitTestColumnDisplayIndex)
            {
                _hitTest = hitTest;
                m_index = hitTest.ColumnIndex;
                m_initialRegion = initialRegion;
                m_currentRegion = initialRegion;
                _hitTestColumnDisplayIndex = hitTestColumnDisplayIndex;
                m_columnImage = null;
            }

            public SelectedDataGridColumn(int hitTestColumnDisplayIndex, Rectangle columnRegion, Point cursorLocation, Image columnImage)
            {
                _hitTest = null;
                m_index = hitTestColumnDisplayIndex;
                m_initialRegion = columnRegion;
                m_currentRegion = columnRegion;
                m_cursorLocation = cursorLocation;
                _hitTestColumnDisplayIndex = hitTestColumnDisplayIndex;
                m_columnImage = columnImage;
            }

            public void Dispose()
            {
                if (!disposed)
                {
                    m_initialRegion = Rectangle.Empty;
                    m_currentRegion = Rectangle.Empty;

                    m_index = -1;
                    m_cursorLocation = Point.Empty;

                    if (m_columnImage != null)
                    {
                        m_columnImage.Dispose();
                    }

                    disposed = true;
                }
                // Remove this object from the finalization queue so the 
                // finalizes doesn't invoke this method again.
                GC.SuppressFinalize(this);
            }

            // NOTE: We do not implement the destructor because we are not 
            // explicitly dealing with unmanaged resources.

            // ~DraggedDataGridColumn() { }

            /// <summary>
            /// Throw an ObjectDisposedException if this object has already been
            /// disposed.
            /// </summary>
            private void CheckState()
            {
                if (disposed)
                {
                    throw new ObjectDisposedException("DraggedDataGridColumn object has already been disposed.");
                }
            }

        }

        public class DraggedDataGridColumnTest : IDisposable
        {
            #region Private data fields

            // private data fields
            private Rectangle m_initialRegion;
            private Rectangle m_currentRegion;

            private int m_index;
            private readonly Image m_columnImage;
            private Point m_cursorLocation;

            private bool disposed;

            #endregion

            #region Properties

            private readonly DataGridView _dataGridView;

            /// <summary>
            /// An integer representing the original column index.
            /// </summary>
            public int Index
            {
                get
                {
                    CheckState();
                    return m_index;
                }
            }

            /// <summary>
            /// A Rectangle structure that identifies the region of the column at
            /// the time the drag and drop operation was initiated.
            /// </summary>	
            public Rectangle InitialRegion
            {
                get
                {
                    CheckState();
                    return m_initialRegion;
                }
            }

            /// <summary>
            /// A Rectangle structure that identifies the current region of the 
            /// column that is being dragged. This is the only member that can be 
            /// modified after an instance has been created.
            /// </summary>
            public Rectangle CurrentRegion
            {
                get
                {
                    CheckState();
                    return m_currentRegion;
                }
                set
                {
                    CheckState();
                    m_currentRegion = value;
                }
            }

            /// <summary>
            /// A Bitmap object containing a bitmap representation of the column at 
            /// the time that the drag and drop operation was initiated.
            /// </summary>
            public Image ColumnImage
            {
                get
                {
                    CheckState();
                    return m_columnImage;
                }
            }

            /// <summary>
            /// A Point structure representing the cursor location relative to the 
            /// origin of m_initialRegion.
            /// </summary>
            public Point CursorLocation
            {
                get
                {
                    CheckState();
                    return m_cursorLocation;
                }
            }

            #endregion

            #region Constructors

            public DraggedDataGridColumnTest(DataGridViewColumn selectedColumn)
            {
                _dataGridView = selectedColumn.DataGridView;
                var _hitTest = _dataGridView.HitTest(selectedColumn.HeaderCell.ContentBounds.Location.X, selectedColumn.HeaderCell.ContentBounds.Location.Y);

                _dataGridView.Columns[selectedColumn.Index].SortMode = DataGridViewColumnSortMode.Programmatic;

                int xCoordinate = GetLeftmostColumnHeaderXCoordinate(selectedColumn.Index);
                var yCoordinate = GetTopmostColumnHeaderYCoordinate(_hitTest.ColumnX, _hitTest.RowY);
                int columnWidth = _dataGridView.Columns[selectedColumn.Index].Width;
                var columnHeight = GetColumnHeight(yCoordinate);

                Size columnSize = new Size(selectedColumn.Width, GetColumnHeight(yCoordinate));

                var startingLocation = new Point(xCoordinate, yCoordinate);
                Rectangle columnRegion = new Rectangle(xCoordinate, yCoordinate, columnWidth, columnHeight);
                var cursorLocation = new Point(_hitTest.ColumnX - xCoordinate, _hitTest.RowY - yCoordinate);

                Bitmap columnImage = (Bitmap)ScreenImage.GetScreenshot(_dataGridView.Handle, startingLocation, columnSize);

                m_index = selectedColumn.Index;
                m_initialRegion = columnRegion;
                m_currentRegion = columnRegion;
                m_cursorLocation = cursorLocation;
                m_columnImage = columnImage;
            }

            #endregion

            public void Dispose()
            {
                if (!disposed)
                {
                    m_initialRegion = Rectangle.Empty;
                    m_currentRegion = Rectangle.Empty;

                    m_index = -1;
                    m_cursorLocation = Point.Empty;

                    if (m_columnImage != null)
                    {
                        m_columnImage.Dispose();
                    }

                    disposed = true;
                }
                // Remove this object from the finalization queue so the 
                // finalizer doesn't invoke this method again.
                GC.SuppressFinalize(this);
            }

            // NOTE: We do not implement the destructor because we are not 
            // explicitly dealing with unmanaged resources.

            // ~DraggedDataGridColumn() { }

            /// <summary>
            /// Throw an ObjectDisposedException if this object has already been
            /// disposed.
            /// </summary>
            private void CheckState()
            {
                if (disposed)
                {
                    throw new ObjectDisposedException("DraggedDataGridColumn object has already been disposed.");
                }
            }

            /// <summary>
            /// Calculates the leftmost x coordinate for the column corresponding 
            /// to the parameterized column index. By accessing the 
            /// GridColumnStyle style, which is discussed in detail in the article,
            /// we’re able to get the current column widths (this changes when you 
            /// resize columns) for the columns that precede the current column. 		
            /// </summary>
            private int GetLeftmostColumnHeaderXCoordinate(int columnIndex)
            {
                var xCoordinate = _dataGridView.RowHeadersVisible ? _dataGridView.RowHeadersWidth : 0;

                for (int i = 0; i < columnIndex; i++)
                {
                    xCoordinate += _dataGridView.Columns[i].Width;
                }

                return xCoordinate - _dataGridView.HorizontalScrollingOffset;
            }

            /// <summary>
            /// This is another recursive method that returns the Y-coordinate of 
            /// the topmost portion of the column header. First, a check is 
            /// performed to see if the DataGrid caption is visible. If not, the 
            /// Y-coordinate is set to zero and the method returns. Otherwise, a 
            /// recursion is performed until the DataGrid hit test determines that 
            /// the current Y-coordinate value does not fall within the boundaries 
            /// of a ColumnHeader. 
            /// </summary>
            private int GetTopmostColumnHeaderYCoordinate(int currentX, int currentY)
            {
                var hti = _dataGridView.HitTest(currentX, currentY);
                var yCoordinate = currentY;

                if (!_dataGridView.ColumnHeadersVisible)
                    yCoordinate = 0;
                else
                {
                    if (hti.Type == DataGridViewHitTestType.ColumnHeader)
                        yCoordinate = GetTopmostColumnHeaderYCoordinate(currentX, --currentY);
                    else
                        yCoordinate++;
                }

                return yCoordinate;
            }

            /// <summary>
            /// Returns the height of the column. The height is defined as the area 
            /// between the bottom portion of the caption area and either the 
            /// bottom of the client rectangle, or the top of the horizontal scroll 
            /// bar if it’s visible.
            /// </summary>
            private int GetColumnHeight(int topmostYCoordinate)
            {
                var height = _dataGridView.ClientSize.Height;

                //   if (_dataGridView.  ScrollBars. HorizScrollBar.Visible)
                //       height -= _dataGridView.HorizScrollBar.Height;

                return height - topmostYCoordinate;
            }
        }

        void ThreadSafeInvoke(Action action)
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

        internal void InvalidateColumnHeaders(Font newFont)
        {
            // This forces each individual header cell to repaint, which is useful when header cells have
            // custom paint logic responding to state changes (like filter indicators or sort glyphs).
            if (!ColumnHeadersVisible) return;

            // Update the default header cell style font, which is used for painting the header cells.
            // and we reference in MouseWeell event to determine the font size for resizing the header cells.
            ColumnHeadersDefaultCellStyle.Font = newFont;

            foreach (DataGridViewColumn col in Columns)
            {
                col.HeaderCell.Style.Font = newFont;
                InvalidateCell(col.HeaderCell);
            }
        }
    }

}

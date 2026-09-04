using System.ComponentModel;
using HitTestInfo = System.Windows.Forms.DataGridView.HitTestInfo;

namespace StockRoom11net.Controls.DataGridViewExtend
{
    public class FilteredHeaderCell : DataGridViewHeaderCell
    {
        #region"RemovedFilter"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void RemovedFilterEventHandler(object sender, Custom_Events_Args.RemovedFilter_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ClearFilter indicator was clicked.")]
        public event RemovedFilterEventHandler RemovedFilterEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_RemovedFilter_Event(Custom_Events_Args.RemovedFilter_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (RemovedFilterEvent != null)
            {
                // Notify Subscribers
                RemovedFilterEvent(this, e);
            }
        }
        #endregion"ClearFilter"

        readonly DataGridViewControlExtended _dataGridView;

        public FilteredHeaderCell(DataGridViewControlExtended dataGridView, Image columnClearFilterIndicator)
        {
            if (dataGridView != null)
            {
                _dataGridView = dataGridView;
                _headerCell = _dataGridView.LatestMouseOverColumnHeaderCell;
            }

            if (columnClearFilterIndicator != null)
            {
                ColumnClearFilterIndicator = columnClearFilterIndicator;
                ColumnClearFilterIndicatorSize = columnClearFilterIndicator.Size;
            }

            if (_dataGridView != null)
            {
                _dataGridView.EnableHeadersVisualStyles = false;
                _dataGridView.SelectColumn();

                _dataGridView.MouseMove += DataGridView_MouseMove;
                _dataGridView.CellPainting += DataGridView_CellPainting;
                _dataGridView.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;

                _dataGridView.ActiveFilterCollection.Add(FilteredColumnIndex, this);
            }

            MouseLocation = new Point(0, 0);
            
            IsClearFilterIndicatorPainted = false;

            _foreColor = _headerCell.Style.ForeColor;
            _headerCell.Style.ForeColor = Color.Crimson;
            _headerCellValueColumnName = _headerCell.Value.ToString();
            _headerCell.OwningColumn.SortMode = DataGridViewColumnSortMode.Programmatic;

            ColumnClearFilterIndicatorRect = new Rectangle(_headerCell.ContentBounds.X + _headerCell.ContentBounds.Width - 10, _headerCell.ContentBounds.Y + 1, 10, 10);
        }


        Point _mouseLocation;
        public Point MouseLocation
        {
            get
            {
                return _mouseLocation;
            }
            set
            {
                _mouseLocation = value;
            }
        }

        public int HitTestColumnDisplayIndex
        {
            get
            {
                return _dataGridView._hitTestColumnDisplayIndex;
            }
        }
        public int FilteredColumnIndex
        {
            get
            {
                return _headerCell.ColumnIndex;
            }
        }
        int offsetX;
        Color _foreColor;
        string _headerCellValueColumnName;

        string _filterString;
        public string FilterString
        {
            get
            {
                return _filterString;
            }
            set
            {
                _filterString = value;
                _headerCell.Value = value;
            }
        }


        string _filterStringBase;
        public string FilterStringBase
        {
            get { return _filterStringBase; }
            set
            {
                _filterStringBase = value;
            }
        }

        public Pen PenColumnClearFilterIndicador = new(Color.Black, 1);
        HitTestInfo _hitTest;
        public HitTestInfo HitTest
        {
            get
            {
                return _hitTest;
            }
            set
            {
                _hitTest = value;
            }
        }

        DataGridViewHeaderCell _headerCell;

        public Image ColumnClearFilterIndicator;
        bool IsClearFilterIndicatorPainted;
        public Size ColumnClearFilterIndicatorSize;

        Rectangle _columnClearFilterIndicator;
        public Rectangle ColumnClearFilterIndicatorRect
        {
            get
            {
                return _columnClearFilterIndicator;
            }
            set
            {
                _columnClearFilterIndicator = value;
            }
        }

        public bool IsMouseOverColumnClearFilterIndicator
        {
            get
            {
                return ColumnClearFilterIndicatorRect.Contains(MouseLocation);
            }
        }

        public void RemoveFilter()
        {
            if (_dataGridView.ActiveFilterCollection.Count > 1)
                _dataGridView.ActiveFilterCollection.Remove(FilteredColumnIndex);
            else
            {
                _dataGridView.ActiveFilterCollection.Clear();
                _dataGridView.EnableHeadersVisualStyles = false;
                _dataGridView.ActiveFilter = "";
            }

            ClearColumnFilter();
            return;
        }

        void DataGridView_MouseMove(object? sender, MouseEventArgs e)
        {
            HitTest = _dataGridView.HitTest(e.X, e.Y);

            if (_headerCell.ColumnIndex == HitTest.ColumnIndex && HitTest.RowIndex == -1)
            {
                MouseLocation = e.Location;

                if (IsMouseOverColumnClearFilterIndicator)
                    _dataGridView.InvalidateCell(_headerCell.ColumnIndex, _headerCell.RowIndex);

                if (IsClearFilterIndicatorPainted)
                {
                    _dataGridView.InvalidateCell(_headerCell.ColumnIndex, _headerCell.RowIndex);
                    IsClearFilterIndicatorPainted = false;
                }
            }
        }

        void DataGridView_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1)
                return;
            if (e.ColumnIndex != _headerCell.ColumnIndex)
                return;

            e.PaintBackground(e.ClipBounds, true);
            e.PaintContent(e.ClipBounds);

            int iconSize = Math.Max(14, e.CellBounds.Height - 8); // single scale basis for all elements

            #region"Manually draw sort glyph"

            if (_dataGridView.SortedColumn != null &&
                _dataGridView.SortedColumn.Index == e.ColumnIndex &&
                _dataGridView.SortOrder != SortOrder.None)
            {
                bool ascending = _dataGridView.SortOrder == SortOrder.Ascending;

                int glyphHeight = iconSize / 2;        // proportional to iconSize
                int glyphWidth = iconSize;            // same width as icon
                int glyphX = e.CellBounds.Right - glyphWidth - 6;
                int glyphCenterY = e.CellBounds.Top + e.CellBounds.Height / 2;

                Point[] triangle = ascending            // ▲
                    ? new Point[]
                    {
                        new Point(glyphX,             glyphCenterY + glyphHeight / 2),
                        new Point(glyphX + glyphWidth, glyphCenterY + glyphHeight / 2),
                        new Point(glyphX + glyphWidth / 2, glyphCenterY - glyphHeight / 2)
                    }
                    : new Point[]                       // ▼
                    {
                        new Point(glyphX,             glyphCenterY - glyphHeight / 2),
                        new Point(glyphX + glyphWidth, glyphCenterY - glyphHeight / 2),
                        new Point(glyphX + glyphWidth / 2, glyphCenterY + glyphHeight / 2)
                    };

                e.Graphics.FillPolygon(Brushes.Black, triangle);
                offsetX = glyphWidth + 8;    // glyph width + icon width + spacing
            }
            else
            {
                offsetX = iconSize + 4;
            }

            #endregion"Manually draw sort glyph"

            #region"Draw filter clear indicator"

            // Scale filter icon to column header height (same basis as the sort glyph).
            var scaledIcon = new Rectangle(Point.Empty, new Size(iconSize, iconSize));

            var offsetY = (e.CellBounds.Height - iconSize) / 2;
            var pt = new Point(e.CellBounds.Right - offsetX - iconSize, e.CellBounds.Location.Y + offsetY);

            // Update hit-test rect with scaled size.
            ColumnClearFilterIndicatorRect = new Rectangle(pt, new Size(iconSize, iconSize));

            // Draw icon scaled into the computed rect.
            e.Graphics.DrawImage(ColumnClearFilterIndicator, ColumnClearFilterIndicatorRect);

            if (IsMouseOverColumnClearFilterIndicator)
            {
                IsClearFilterIndicatorPainted = true;
                e.Graphics.DrawRoundedRectangle(PenColumnClearFilterIndicador, ColumnClearFilterIndicatorRect, new Size(iconSize / 2, iconSize / 2));
            }

            #endregion"Draw filter clear indicator"

            e.Handled = true;
        }
               
        void DataGridView_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != _headerCell.ColumnIndex)
                return;

            // This was a click-and-hold (column selection), not a sort click — skip sort.
            // The flag is reset asynchronously by DataGridViewControlExtended after all handlers run.
            if (_dataGridView.SuppressSortOnNextColumnHeaderClick)
                return;

            if (IsMouseOverColumnClearFilterIndicator)
            {
                ClearColumnFilter();
                return;
            }

            DataGridViewColumn newColumn = _dataGridView.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = _dataGridView.SortedColumn;
            ListSortDirection direction;

            if (oldColumn != null)
            {
                if (oldColumn == newColumn &&
                    _dataGridView.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            _dataGridView.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending ?
                                                    SortOrder.Ascending : SortOrder.Descending;
        }

        void ClearColumnFilter()
        {
            _headerCell.Value = _headerCellValueColumnName;
            _headerCell.OwningColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            _headerCell.Style.ForeColor = _foreColor;

            _dataGridView.SelectedColumnCollection.Remove(HitTestColumnDisplayIndex);

            _dataGridView.MouseMove -= DataGridView_MouseMove;
            _dataGridView.CellPainting -= DataGridView_CellPainting;
            _dataGridView.ColumnHeaderMouseClick -= DataGridView_ColumnHeaderMouseClick;

            On_RemovedFilter_Event(new Custom_Events_Args.RemovedFilter_EventArgs(_headerCell));

            Dispose(true);
        }

    }
}

using MyStuff11net.DataGridViewExtend;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace MyStuff11net.DataGridViewExtended
{
    /// <summary>
    /// Add this component in runtime or design time and assign a datagridview to it to enable grouping on that grid.
    /// You can also add an 
    /// </summary>
    [DefaultEvent("DisplayGroup")]
    public class DataGridViewGrouper : Component, IGrouper
    {
        private DataGridView _dataGridView;
        [DefaultValue(null)]
        public DataGridView Data_grid_view
        {
            get
            {
                return _dataGridView;
            }
            set
            {
                if (_dataGridView == value)
                    return;

                if (_dataGridView != null)
                {
                    _dataGridView.Sorted -= new EventHandler(Grid_sorted);
                    _dataGridView.RowPrePaint -= new DataGridViewRowPrePaintEventHandler(DataGridView_RowPrePaint);
                    _dataGridView.RowPostPaint -= new DataGridViewRowPostPaintEventHandler(GridRowPostPaint);
                    _dataGridView.CellBeginEdit -= new DataGridViewCellCancelEventHandler(GridCellBeginEdit);
                    _dataGridView.CellDoubleClick -= new DataGridViewCellEventHandler(DataGridView_cell_double_click);
                    _dataGridView.CellClick -= new DataGridViewCellEventHandler(DataGridView_cell_click);
                    _dataGridView.MouseMove -= new MouseEventHandler(DataGridView_MouseMove);
                    _dataGridView.SelectionChanged -= new EventHandler(DataGridView_selection_changed);
                }

                Remove_grouping();
                selectedrows.Clear();


                _dataGridView = value;

                if (_dataGridView == null)
                    return;

                _dataGridView.Sorted += new EventHandler(Grid_sorted);
                _dataGridView.RowPrePaint += new DataGridViewRowPrePaintEventHandler(DataGridView_RowPrePaint);
                _dataGridView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(GridRowPostPaint);
                _dataGridView.CellBeginEdit += new DataGridViewCellCancelEventHandler(GridCellBeginEdit);
                _dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(DataGridView_cell_double_click);
                _dataGridView.CellClick += new DataGridViewCellEventHandler(DataGridView_cell_click);
                _dataGridView.MouseMove += new MouseEventHandler(DataGridView_MouseMove);
                _dataGridView.SelectionChanged += new EventHandler(DataGridView_selection_changed);
                _dataGridView.CellMouseEnter += new DataGridViewCellEventHandler(DataGridView_CellMouseEnter);
            }
        }

        public DataGridViewGrouper()
        {
            bindingSourceGroups.DataSourceChanged += SourceDataSourceChanged;
            bindingSourceGroups.Grouping_changed += Source_grouping_changed;
        }

        public DataGridViewGrouper(DataGridView grid) : this()
        {
            Data_grid_view = grid;
        }

        public DataGridViewGrouper(IContainer container) : this()
        {
            container.Add(this);
        }

        #region"Select/Collapse/Expand"

        void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            GroupHeader = null;

            if (e.ColumnIndex != -1)
                return;

            if (e.RowIndex == -1)
                return;

            if (bindingSourceGroups.IsGroupRow(e.RowIndex))
                GroupHeader = _dataGridView.Rows[e.RowIndex].HeaderCell;
        }

        Point _capturedcollapsebox = new Point(-1, -1);
        DataGridViewRowHeaderCell? GroupHeader;
        void DataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            if (GroupHeader == null)
                return;

            if (e.X < Header_X_offset && e.X >= Header_X_offset - CollapseBoxWidth)
            {
                DataGridView.HitTestInfo ht = _dataGridView.HitTest(e.X, e.Y);

                if (IsGroupRow(ht.RowIndex))
                {
                    var y = e.Y - ht.RowY;
                    if (y >= CollapseBoxYoffset && y <= CollapseBoxYoffset + CollapseBoxWidth)
                    {
                        CheckCollapsedFocused(ht.ColumnIndex, ht.RowIndex);
                        return;
                    }
                }
            }
            CheckCollapsedFocused(-1, -1);
        }

        void InvalidateHeaderCell()
        {
            if (_capturedcollapsebox.Y == -1)
                return;

            _dataGridView.InvalidateCell(_capturedcollapsebox.X, _capturedcollapsebox.Y);
        }

        void CheckCollapsedFocused(int col, int row)
        {
            if (_capturedcollapsebox.X == col && _capturedcollapsebox.Y == row)
                return;

            InvalidateHeaderCell();
            _capturedcollapsebox = new Point(col, row);
            InvalidateHeaderCell();
        }

        void DataGridView_cell_click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.RowIndex != _capturedcollapsebox.Y)
                return;

            Collapse_expand(e.RowIndex, Is_collapsed(e.RowIndex));
            if (Is_collapsed(e.RowIndex) && _dataGridView[1, e.RowIndex + 1].Visible)
                _dataGridView.CurrentCell = _dataGridView[1, e.RowIndex + 1];
        }

        /// <summary>
        /// selected rows are kept separately in order to invalidate the entire row
        /// and not just one cell when the selection is changed
        /// </summary>
        List<int> selectedrows = new List<int>();
        void DataGridView_selection_changed(object sender, EventArgs e)
        {
            Invalidateselected();
            selectedrows.Clear();
            foreach (DataGridViewCell c in _dataGridView.SelectedCells)
                if (IsGroupRow(c.RowIndex))
                    selectedrows.Add(c.RowIndex);
            Invalidateselected();
        }

        void Invalidateselected()
        {
            if (selectedrows.Count == 0 || _dataGridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                return;
            foreach (var i in selectedrows)
            {
                if (_dataGridView.Rows.Count > 1)
                    _dataGridView.InvalidateRow(i);
            }
        }

        bool Is_collapsed(int index)
        {
            if (++index >= _dataGridView.Rows.Count)
                return false;

            return !_dataGridView.Rows[index].Visible;
        }

        void Collapse_expand(int index, bool show)
        {
            _dataGridView.SuspendLayout();

            foreach (var row in Get_rows(index))
                row.Visible = show;

            _dataGridView.ResumeLayout();
        }

        public void Expand_all()
        {
            Collapse_expand_all(true);
        }

        public void Collapse_all()
        {
            Collapse_expand_all(false);
        }

        void Collapse_expand_all(bool show)
        {
            if (_dataGridView == null || !GridUsesGroupingSource)
                return;

            _dataGridView.SuspendLayout();
            bindingSourceGroups.SuspendBinding();
            var cnt = bindingSourceGroups.Count;

            for (var i = 0; i < cnt; i++)
            {
                if (!IsGroupRow(i))
                    _dataGridView.Rows[i].Visible = show;
            }
            _dataGridView.ResumeLayout();
            bindingSourceGroups.ResumeBinding();
        }

        void DataGridView_cell_double_click(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsGroupRow(e.RowIndex))
                return;

            Collapse_expand(e.RowIndex, true);
            _dataGridView.SuspendLayout();
            _dataGridView.CurrentCell = _dataGridView[1, e.RowIndex + 1];
            _dataGridView.Rows[e.RowIndex].Selected = false;
            Select_group(e.RowIndex);
            _dataGridView.ResumeLayout();
        }

        IEnumerable<DataGridViewRow> Get_rows(int index)
        {
            while (!IsGroupRow(++index) && index < bindingSourceGroups.Count)
                yield return _dataGridView.Rows[index];
        }

        void Select_group(int offset)
        {
            foreach (var row in Get_rows(offset))
                row.Selected = true;
        }

        #endregion"Select/Collapse/Expand"

        public bool IsGroupRow(int index)
        {
            return bindingSourceGroups.IsGroupRow(index);
        }

        void SourceDataSourceChanged(object sender, EventArgs e)
        {
            Properties_changed?.Invoke(this, e);
        }

        public event EventHandler Properties_changed;
        public IEnumerable<PropertyDescriptor> Get_properties()
        {
            foreach (PropertyDescriptor pd in bindingSourceGroups.GetItemProperties(null))
                yield return pd;
        }

        void GridCellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (IsGroupRow(e.RowIndex))
                e.Cancel = true;
        }

        protected override void Dispose(bool disposing)
        {
            Data_grid_view = null;
            bindingSourceGroups.Dispose();
            base.Dispose(disposing);
        }

        void Grid_sorted(object sender, EventArgs e)
        {
            _capturedcollapsebox = new Point(-1, -1);
            if (GridUsesGroupingSource)
                try
                {
                    _dataGridView.DataSource = bindingSourceGroups.DataSource;
                    _dataGridView.DataMember = bindingSourceGroups.DataMember;
                    bindingSourceGroups.RemoveGrouping();
                }
                catch (Exception error)
                {
                    string er = error.Message;
                }
        }

        /// <summary>
        /// Class BindingSourceGroups extend BindingSource
        /// it is the main bindingSource.
        /// </summary>
        readonly BindingSourceGroups bindingSourceGroups = new BindingSourceGroups();
        /// <summary>
        /// Property GroupingSource, access to groupingSource field.
        /// </summary>
        public BindingSourceGroups GroupingSource
        {
            get
            {
                return bindingSourceGroups;
            }
        }

        public void Remove_grouping()
        {
            if (GridUsesGroupingSource)
                try
                {
                    _dataGridView.DataSource = bindingSourceGroups.DataSource;
                    _dataGridView.DataMember = bindingSourceGroups.DataMember;
                    bindingSourceGroups.RemoveGrouping();
                }
                catch (Exception error)
                {
                    string er = error.Message;
                }
        }

        public event EventHandler Grouping_changed;
        void Source_grouping_changed(object sender, EventArgs e)
        {
            if (Grouping_changed != null)
                Grouping_changed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Test if the datasource is a groupingSource.
        /// </summary>
        bool GridUsesGroupingSource
        {
            get
            {
                return _dataGridView != null && _dataGridView.DataSource == bindingSourceGroups;
            }
        }

        public void Reset_grouping()
        {
            if (!GridUsesGroupingSource) return;
            bindingSourceGroups.Reset_group();
        }

        [DefaultValue(null)]
        public Grouping_info Group_on
        {
            get
            {
                return bindingSourceGroups.GroupOn;
            }
            set
            {
                if (Group_on == value)
                    return;

                if (value == null)
                    Remove_grouping();
                else
                {
                    Check_source();
                    GroupingSource.GroupOn = value;
                }
            }
        }

        public bool Is_grouped
        {
            get
            {
                return bindingSourceGroups.GroupOn != null;
            }
        }

        [DefaultValue(SortOrder.Ascending)]
        public SortOrder SortOrder
        {
            get
            {
                return bindingSourceGroups.GroupSortDirection;
            }
            set
            {
                GroupingSource.GroupSortDirection = value;
            }
        }

        public void SetGroupOn(string name)
        {
            if (string.IsNullOrEmpty(name))
                Remove_grouping();
            else
            {
                Check_source();
                GroupingSource.SetGroupOn(name);
            }
        }

        public void SetGroupOn(DataGridViewColumn col)
        {
            string dataPropertyName = col == null ? null : col.DataPropertyName;
            SetGroupOn(dataPropertyName);
        }

        public void SetGroupOn(PropertyDescriptor property)
        {
            Check_source();
            GroupingSource.SetGroupOn(property);
        }

        public void SetGroupOn(GroupingDelegate gd)
        {
            Check_source();
            GroupingSource.SetGroupOn(gd);
        }

        public void SetGroupOnStartLetters(Grouping_info g, int letters)
        {
            Check_source();
            GroupingSource.SetGroupOnStartLetters(g, letters);
        }

        public void SetGroupOnStartLetters(string property, int letters)
        {
            Check_source();
            GroupingSource.SetGroupOnStartLetters(property, letters);
        }

        /// <summary>
        /// Check if the dataGridView is no using a groupingSource,
        /// assign a groupingSource ( BindingSource extension )
        /// </summary>
        private void Check_source()
        {
            if (_dataGridView == null)
                throw new Exception("No target DataGridView set");

            if (!GridUsesGroupingSource)
            {
                GroupingSource.DataSource = _dataGridView.DataSource;
                GroupingSource.DataMember = _dataGridView.DataMember;

                _dataGridView.DataSource = GroupingSource;
            }
        }

        #region"Painting"

        void DataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (!IsGroupRow(e.RowIndex))
                return;

            e.Handled = true;
            PaintGroupRow(e);
        }

        int Header_X_offset
        {
            get
            {
                if (_dataGridView.RowHeadersVisible)
                    return _dataGridView.RowHeadersWidth - LineOffSet;

                return LineOffSet * 4;
            }
        }
        const int CollapseBoxWidth = 14;
        const int CollapseBoxYoffset = CollapseBoxWidth / 2;
        const int LineOffSet = CollapseBoxWidth / 2;
        readonly Pen _linepen = Pens.SteelBlue;

        /// <summary>
        /// Draw Grid on expanded node.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GridRowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (!_dataGridView.RowHeadersVisible)
                return;
            if (Group_on == null)
                return;

            //if it's the last row, return.
            if (e.RowIndex >= bindingSourceGroups.Count)
                return;

            var r = _dataGridView.RowHeadersWidth;
            var x = Header_X_offset - LineOffSet;
            var y = e.RowBounds.Top + e.RowBounds.Height / 2;
            // Draw horizontal line on expanded node.
            e.Graphics.DrawLine(_linepen, x, y, r, y);

            var next = e.RowIndex + 1;
            if (IsGroupRow(next))
                return;

            if (next < bindingSourceGroups.Count)
                y = e.RowBounds.Bottom;

            // Draw vertical line on expanded node.
            e.Graphics.DrawLine(_linepen, x, e.RowBounds.Top, x, y);
        }

        private bool _showheader = true;
        [DefaultValue(true)]
        public bool Show_group_name
        {
            get { return _showheader; }
            set
            {
                if (_showheader == value) return;
                _showheader = value;
                if (_dataGridView != null) _dataGridView.Invalidate();
            }
        }

        private bool _showcount = true;
        [DefaultValue(true)]
        public bool Show_count
        {
            get { return _showcount; }
            set
            {
                if (_showcount == value)
                    return;

                _showcount = value;

                if (_dataGridView != null)
                    _dataGridView.Invalidate();
            }
        }

        /// <summary>
        /// This event is fired when the group row has to be painted and the display values are requested
        /// </summary>
        public event EventHandler<Group_display_event_args> DisplayGroup;
        Group_display_event_args Get_display_values(DataGridViewRowPrePaintEventArgs pe)
        {
            var row = bindingSourceGroups[pe.RowIndex] as IGroupRow;
            var e = new Group_display_event_args(row, bindingSourceGroups.GroupOn);
            var selected = selectedrows.Contains(pe.RowIndex);

            e.Selected = selected;
            e.Back_color = selected ? _dataGridView.DefaultCellStyle.SelectionBackColor : _dataGridView.DefaultCellStyle.BackColor;
            e.Fore_color = selected ? _dataGridView.DefaultCellStyle.SelectionForeColor : _dataGridView.DefaultCellStyle.ForeColor;
            e.Font = pe.InheritedRowStyle.Font;

            if (_showcount)
                e.Summary = "(" + row.Count + ")";
            if (_showheader)
                e.Header = bindingSourceGroups.GroupOn.ToString();

            e.GroupingInfo.Set_display_values(e);
            if (e.Cancel)
                return null;

            if (DisplayGroup != null)
            {
                DisplayGroup(this, e);
                if (e.Cancel)
                    return null;
            }

            return e;
        }

        /// <summary>
        /// Draw and fill a rectangle for group row.
        /// Draw the line in the bottom of this rectangle.
        /// Draw the Ellipse for the group row.
        /// Draw string header text.
        /// Draw string cell text.
        /// Draw string summary, (#) of row.
        /// </summary>
        /// <param name="e"></param>
        void PaintGroupRow(DataGridViewRowPrePaintEventArgs e)
        {
            var info = Get_display_values(e);
            if (info == null)
                return; //cancelled

            Rectangle RowBounds = e.RowBounds;
            RowBounds.Width = _dataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed) + _dataGridView.RowHeadersWidth;

            // Draw and fill the rectangle of group row.
            ItemFill(e, RowBounds, Color.White, Color.LightBlue);

            //Draw line under the group row (Row con information of group)
            e.Graphics.DrawLine(new Pen(Color.SteelBlue, 2), RowBounds.Left, RowBounds.Bottom, RowBounds.Right, RowBounds.Bottom);

            #region"collapse/expand symbol"

            Rectangle RowHeaderRec = e.RowBounds;
            //r.X = 1;
            RowHeaderRec.Width = _dataGridView.RowHeadersWidth;
            //RowHeaderRec.Height--;

            //GetCollapseBoxBounds(e.RowBounds.Y);
            int yCenterOffset = RowHeaderRec.Y + RowHeaderRec.Height / 2 - CollapseBoxYoffset;
            Rectangle CollapseBoxRec = new Rectangle(Header_X_offset - CollapseBoxWidth, yCenterOffset,
                                                             CollapseBoxWidth, CollapseBoxWidth);

            if (_capturedcollapsebox.Y == e.RowIndex)
                e.Graphics.FillEllipse(Brushes.Yellow, CollapseBoxRec);

            // Draw a Ellipse inside the rectangle CollapseBoxRec.
            e.Graphics.DrawEllipse(_linepen, CollapseBoxRec);
            bool collapsed = Is_collapsed(e.RowIndex);
            int cx;

            if (_dataGridView.RowHeadersVisible && !collapsed)
            {
                cx = Header_X_offset - LineOffSet;
                e.Graphics.DrawLine(_linepen, cx, CollapseBoxRec.Bottom, cx, RowHeaderRec.Bottom);
            }

            CollapseBoxRec.Inflate(-2, -2);
            var cy = CollapseBoxRec.Y + CollapseBoxRec.Height / 2;
            e.Graphics.DrawLine(_linepen, CollapseBoxRec.X, cy, CollapseBoxRec.Right, cy);

            if (collapsed)
            {
                cx = CollapseBoxRec.X + CollapseBoxRec.Width / 2;
                e.Graphics.DrawLine(_linepen, cx, CollapseBoxRec.Top, cx, CollapseBoxRec.Bottom);
            }

            #endregion"collapse/expand symbol"

            #region"Group value"

            Rectangle RowTitleRec = e.RowBounds;
            RowTitleRec.X = _dataGridView.RowHeadersWidth + 4;
            RowBounds.Width = _dataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);

            using (var fb = new SolidBrush(info.Fore_color))
            {
                var sf = new StringFormat { LineAlignment = StringAlignment.Center };
                // Draw string information of group header.(Header text of Column filtered)
                if (info.Header != null)
                {
                    var size = e.Graphics.MeasureString(info.Header, info.Font);
                    e.Graphics.DrawString(info.Header, info.Font, fb, RowTitleRec, sf);
                    RowTitleRec.Offset((int)size.Width + 5, 0);
                }

                // Draw string information of value. (each Cell text in that Column)
                if (info.Display_value != null)
                {
                    using (var f = new Font(info.Font.FontFamily, info.Font.Size + 2, FontStyle.Bold))
                    {
                        var size = e.Graphics.MeasureString(info.Display_value, f);
                        e.Graphics.DrawString(info.Display_value, f, fb, RowTitleRec, sf);
                        RowTitleRec.Offset((int)size.Width + 10, 0);
                    }
                }
                // Draw string information of Summary. ( Number of Row in the group. (3))
                if (info.Summary != null)
                {
                    e.Graphics.DrawString(info.Summary, info.Font, fb, RowTitleRec, sf);
                }
            }
            #endregion"Group value"
        }

        /// <summary>
        /// Fills the specified rectangle with item border roundness
        /// </summary>
        public void ItemFill(DataGridViewRowPrePaintEventArgs e, Rectangle bounds, Color north, Color south)
        {
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return;

            using (GraphicsPath r = ItemRectangle(e, bounds))
            {
                using (var b = new LinearGradientBrush(bounds, north, south, 90))
                {
                    e.Graphics.FillPath(b, r);
                }
            }
        }

        /// <summary>
        /// Creates a rectangle with item roundess
        /// </summary>
        public GraphicsPath ItemRectangle(DataGridViewRowPrePaintEventArgs evtData, Rectangle bounds)
        {
            int ItemRoundness = 5;

            /*
              if (pointerPadding == ItemRoundness)
              {

               * Trace pointed item
               * 
               *     C--------------------D
               *     |                    |
               * A---B                    |
               * |                        |
               * H---G                    |
               *     |                    |
               *     F--------------------E


              int sq = ItemRoundness * 2;
              var a = new Point(bounds.Left, evtData.Item.Minute_start_top);
              var b = new Point(a.X + pointerPadding, a.Y);
              var c = new Point(b.X, bounds.Top);
              var d = new Point(bounds.Right, c.Y);
              var e = new Point(d.X, bounds.Bottom);
              var f = new Point(b.X, e.Y);
              var g = new Point(b.X, evtData.Item.Minute_end_top);
              var h = new Point(a.X, g.Y);


              var path = new GraphicsPath();

              path.AddLine(a, b);
              path.AddLine(b, c);
              path.AddLine(c, new Point(d.X - sq, d.Y));
              path.AddArc(new Rectangle(d.X - sq, d.Y, sq, sq), -90, 90);
              path.AddLine(new Point(d.X, d.Y + sq), new Point(d.X, e.Y - sq));
              path.AddArc(new Rectangle(e.X - sq, e.Y - sq, sq, sq), 0, 90);
              path.AddLine(new Point(e.X - sq, e.Y), f);
              path.AddLine(f, g);
              path.AddLine(g, h);
              path.AddLine(h, a);

              path.CloseFigure();

              return path;
          }
          else
          {
                * 
                */

            //CalendarRenderer.Corners crns = CalendarRenderer.Corners.None;

            /*
        if (evtData.Is_first)
        {
            crns |= CalendarRenderer.Corners.West;
        }

        if (evtData.Is_last)
        {
            crns |= CalendarRenderer.Corners.East;
        }

             */

            return RoundRectangle(bounds, ItemRoundness);
        }

        /// <summary>
        /// Creates a rectangle with rounded corners
        /// </summary>
        public static GraphicsPath RoundRectangle(Rectangle r, int radius)
        {
            return RoundRectangleCorners(r, radius, 4);
        }

        /// <summary>
        /// Creates a rectangle with the specified corners rounded
        /// </summary>
        public static GraphicsPath RoundRectangleCorners(Rectangle r, int radius, int corners)
        {
            var path = new GraphicsPath();

            if (r.Width <= 0 || r.Height <= 0)
                return path;

            int d = radius * 2;

            int nw = 0;
            int ne = 0;
            int se = 0;
            int sw = 0;

            path.AddLine(r.Left + nw, r.Top, r.Right - ne, r.Top);

            if (ne > 0)
            {
                path.AddArc(Rectangle.FromLTRB(r.Right - ne, r.Top, r.Right, r.Top + ne),
                            -90, 90);
            }

            path.AddLine(r.Right, r.Top + ne, r.Right, r.Bottom - se);

            if (se > 0)
            {
                path.AddArc(Rectangle.FromLTRB(r.Right - se, r.Bottom - se, r.Right, r.Bottom),
                            0, 90);
            }

            path.AddLine(r.Right - se, r.Bottom, r.Left + sw, r.Bottom);

            if (sw > 0)
            {
                path.AddArc(Rectangle.FromLTRB(r.Left, r.Bottom - sw, r.Left + sw, r.Bottom),
                            90, 90);
            }

            path.AddLine(r.Left, r.Bottom - sw, r.Left, r.Top + nw);

            if (nw > 0)
            {
                path.AddArc(Rectangle.FromLTRB(r.Left, r.Top, r.Left + nw, r.Top + nw),
                            180, 90);
            }

            path.CloseFigure();

            return path;
        }

        Rectangle GetCollapseBoxBounds(int yOffset)
        {
            return new Rectangle(Header_X_offset - CollapseBoxWidth, yOffset + CollapseBoxYoffset, CollapseBoxWidth, CollapseBoxWidth);
        }

        #endregion"Painting"

        public bool CurrentRowIsGroupRow
        {
            get
            {
                if (_dataGridView == null || _dataGridView.CurrentCell == null)
                    return false;

                return IsGroupRow(_dataGridView.CurrentCell.RowIndex);
            }
        }
    }

    /*
    * Added the Generic comparer here, for ease of use on blog posting ;)
    */
    /// <summary>
    /// Comparer that tries to find the 'strongest' comparer for a type. 
    /// if the type implements a generic IComparable, that is used.
    /// otherwise if it implements a normal IComparable, that is used.
    /// If neither are implemented, the ToString versions are compared. 
    /// INullable structures are also supported.
    /// This way, the DefaultComparer can compare any object types and can be used for sorting any source.
    /// </summary>
    /// <example>Array.Sort(YourArray,new GenericComparer());</example>
    public class Generic_comparer : IComparer
    {
        public Generic_comparer()
        {
        }

        public Generic_comparer(Type type)
        {
            Type = type;
        }

        Type _type;
        public Type Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value == null) throw new ArgumentNullException();
                _type = value;
                _comp = null;
            }
        }

        Type _targettype;
        /// <summary>
        /// normally the same as the type, but can be set to a different type
        /// </summary>
        public Type Target_type
        {
            get { return _targettype ?? _type; }
            set
            {
                if (Target_type == value)
                    return;

                _targettype = value;
                _comp = null;
            }
        }

        IComparer _comp;

        IComparer GetGenericComparer(Type from, Type to)
        {
            while (to != typeof(object))
            {
                if (typeof(IComparable<>).MakeGenericType(to).IsAssignableFrom(from))
                    return (IComparer)Activator.CreateInstance(typeof(StrongCompare<,>).MakeGenericType(from, to));
                to = to.BaseType;
            }
            return null;
        }

        public IComparer Get_comparer(Type from, Type to)
        {
            var gen = GetGenericComparer(from, to);

            if (gen != null)
                return gen;

            if (typeof(IComparable).IsAssignableFrom(_type))
            {
                return (IComparer)Activator.CreateInstance(typeof(NonGenericCompare<>).MakeGenericType(_type));
            }

            if (_type.IsGenericType && typeof(Nullable<>) == _type.GetGenericTypeDefinition())
            {
                var basetype = _type.GetGenericArguments()[0];
                return (IComparer)Activator.CreateInstance(typeof(NullableComparer<>).MakeGenericType(basetype),
                Get_comparer(basetype, to == from ? basetype : to));
            }

            return new StringComparer();
        }

        class NullableComparer<T> : IComparer where T : struct
        {
            public readonly IComparer BaseComparer;

            public NullableComparer(IComparer baseComparer)
            {
                BaseComparer = baseComparer;
            }

            object getval(object o)
            {
                return ((T?)o).Value;
            }

            public int Compare(object x, object y)
            {
                return BaseComparer.Compare(getval(x), getval(y));
            }
        }

        class StrongCompare<TF, T> : IComparer where TF : IComparable<T>
        {
            public int Compare(object x, object y)
            {
                return ((TF)x).CompareTo((T)y);
            }
        }

        class NonGenericCompare<T> : IComparer where T : IComparable
        {
            public int Compare(object x, object y)
            {
                return ((T)x).CompareTo(y);
            }
        }

        class StringComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return string.Compare(x.ToString(), y.ToString());
            }
        }

        public bool Descending
        {
            get
            {
                return _factor < 0;
            }
            set
            {
                _factor = value ? -1 : 1;
            }
        }

        int _factor = 1;

        int Compare_xy(object x, object y)
        {
            if (x == y) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            if (_type == null)
                Type = x.GetType();

            if (_comp == null)
                _comp = Get_comparer(_type, Target_type);

            return _comp.Compare(x, y);
        }

        public int Compare(object x, object y)
        {
            return _factor * Compare_xy(x, y);
        }
    }
    /*
    public class Generic_comparer<T> : Generic_comparer, IComparer<T>
    {
        public Generic_comparer(): base(typeof(T))
        { }

        public int Compare(T a, T b)
        {
            return base.Compare(a, b);
        }
    }

    public class Property_descriptor_comparer : Generic_comparer
    {
        public readonly PropertyDescriptor Prop;
        public Property_descriptor_comparer(PropertyDescriptor prop): this(prop, true)
        {
        }

        public Property_descriptor_comparer(PropertyDescriptor prop, bool descending): base(prop.PropertyType)
        {
            Prop = prop;
            Descending = descending;
        }
    }
 */
}


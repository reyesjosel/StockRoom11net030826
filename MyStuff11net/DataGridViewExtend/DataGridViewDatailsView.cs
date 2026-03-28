using MyStuff11net.DataGridViewExtended;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;

namespace MyStuff11net.DataGridViewExtend
{
    /// <summary>
    /// Add this component in runtime or design time and assign a datagridview to it to enable grouping on that grid.
    /// You can also add an 
    /// </summary>
    public class DataGridViewDatailsView : Component, IGrouper
    {
        public event EventHandler Properties_changed;

        public event EventHandler Grouping_changed;
        void Source_grouping_changed(object sender, EventArgs e)
        {
            Grouping_changed?.Invoke(this, EventArgs.Empty);
        }

        DataGridView _dataGridView;
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

        /// <summary>
        /// Class BindingSourceGroups extend BindingSource
        /// it is the main bindingSource.
        /// </summary>
        readonly BindingSourceGroups bindingSourceGroups;
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

        /// <summary>
		/// Keep tracking of current Column Index were mouse pointer is over.
		/// </summary>
		public int _currentColumnIndex;
        public int CurrentColumnIndex
        {
            get
            {
                return _currentColumnIndex;
            }
        }

        DataGridViewCell _currentCellMouseHover;
        public DataGridViewCell CurrentCellMouseHover
        {
            get
            {
                return _currentCellMouseHover;
            }
        }

        //   public DataGridViewHeaderCell CurrentColumnHeaderCell { get; }


        public DataGridViewDatailsView()
        {
            bindingSourceGroups = new BindingSourceGroups();
            bindingSourceGroups.DataSourceChanged += SourceDataSourceChanged;
            bindingSourceGroups.Grouping_changed += Source_grouping_changed;
        }

        public DataGridViewDatailsView(DataGridView grid) : this()
        {
            Data_grid_view = grid;
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

            // Cells event.
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _currentColumnIndex = e.ColumnIndex;
                //_currentColumnActive = Columns[_currentColumnIndex];
                _currentCellMouseHover = _dataGridView[_currentColumnIndex, e.RowIndex];
            }

            // Row header event.
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
                _currentRowHeaderRectMouseHover = _dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            try
            {
                CurrentDataGridViewRowMouseEnter = _dataGridView.Rows[e.RowIndex];
                if (CurrentDataGridViewRowMouseEnter == null)
                    return;

                //  if (CurrentDataGridViewRowMouseEnter.DataBoundItem.GetType() == typeof(DataRowView))
                //      CurrentDataRowviewMouseEnter = CurrentDataGridViewRowMouseEnter.DataBoundItem as DataRowView;

                CurrentRowMouseEnterStatus = new CurrentStatus(CurrentDataGridViewRowMouseEnter);
            }
            catch (Exception error)
            {
                string Error = error.Message;
                return;
            }
        }

        Rectangle CollapsibleSignRect;
        Point _capturedcollapsebox = new Point(-1, -1);
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CurrentStatus CurrentRowMouseEnterStatus { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewRow CurrentDataGridViewRowMouseEnter { get; set; }
        Rectangle _currentRowHeaderRectMouseHover = new Rectangle();
        DataGridViewRowHeaderCell GroupHeader;
        void DataGridView_MouseMove(object sender, MouseEventArgs e)
        {
            //if (GroupHeader == null)
            //    return;

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

            if (e.Button == MouseButtons.None && _currentColumnIndex == -1)
            {
                int yCenterOffset = _currentRowHeaderRectMouseHover.Y + _currentRowHeaderRectMouseHover.Height / 2 - CollapseBoxYoffset;
                CollapsibleSignRect = new Rectangle(Header_X_offset - CollapseBoxWidth, yCenterOffset, CollapseBoxWidth, CollapseBoxWidth);

                if (CollapsibleSignRect.Contains(e.Location))
                {
                    CheckIfMouseOvercollapseExpandSymbol();
                }
                else
                {
                    CheckCollapsedFocused(-1, -1);
                }
            }
        }

        void InvalidateHeaderCell()
        {
            if (_capturedcollapsebox.Y == -1)
                return;

            _dataGridView.InvalidateCell(_capturedcollapsebox.X, _capturedcollapsebox.Y);
        }

        void CheckIfMouseOvercollapseExpandSymbol()
        {
            //         if (CurrentRowMouseEnterStatus == null || !CurrentRowMouseEnterStatus.IsBOM)
            //             return;

            CheckCollapsedFocused(_currentCellMouseHover.ColumnIndex, _currentCellMouseHover.RowIndex);
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


        public IEnumerable<IGroupRow> Get_groups()
        {
            return bindingSourceGroups.Get_groups();
        }

        public bool IsGroupRow(int index)
        {
            return bindingSourceGroups.IsGroupRow(index);
        }

        void SourceDataSourceChanged(object sender, EventArgs e)
        {
            Properties_changed?.Invoke(this, e);
        }


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

        public bool Is_grouped
        {
            get
            {
                return bindingSourceGroups.GroupOn != null;
            }
        }

        public bool CurrentRowIsGroupRow
        {
            get
            {
                if (_dataGridView == null || _dataGridView.CurrentCell == null)
                    return false;

                return IsGroupRow(_dataGridView.CurrentCell.RowIndex);
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

            //e.Handled = true;
            //PaintGroupRow(e);            
        }


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

            RowBoundsColumnsDisplayed = e.RowBounds;
            RowBoundsColumnsDisplayed.Width = _dataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
            RowBoundsColumnsDisplayed.X = _dataGridView.RowHeadersWidth;

            PaintBOMRow(e);

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
        // Point _capturedcollapsebox = new Point(-1, -1);
        Rectangle RowBoundsColumnsDisplayed;

        void PaintBOMRow(DataGridViewRowPostPaintEventArgs e)
        {
            var info = Get_display_values(e);
            if (info == null)
                return; //cancelled

            // Draw and fill the rectangle of group row.
            using (var b = new LinearGradientBrush(RowBoundsColumnsDisplayed, Color.White, Color.LightBlue, 90))
            {
                e.Graphics.FillRectangle(b, RowBoundsColumnsDisplayed);
            }

            #region"collapse/expand symbol"

            Rectangle RowHeaderRec = e.RowBounds;
            //r.X = 1;
            RowHeaderRec.Width = _dataGridView.RowHeadersWidth;
            //RowHeaderRec.Height--;

            //GetCollapseBoxBounds(e.RowBounds.Y);
            int yCenterOffset = RowHeaderRec.Y + RowHeaderRec.Height / 2 - CollapseBoxYoffset;
            Rectangle CollapseBoxRec = new Rectangle(Header_X_offset - CollapseBoxWidth, yCenterOffset, CollapseBoxWidth, CollapseBoxWidth);

            if (_capturedcollapsebox.Y == e.RowIndex)
                e.Graphics.FillEllipse(Brushes.Yellow, CollapseBoxRec);

            // Draw a Ellipse inside the rectangle CollapseBoxRec.
            e.Graphics.DrawEllipse(_linepen, CollapseBoxRec);
            bool collapsed = true;// Is_collapsed(e.RowIndex);
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
            RowBoundsColumnsDisplayed.Width = _dataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);

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

        Group_display_event_args Get_display_values(DataGridViewRowPostPaintEventArgs pe)
        {
            //var row = bindingSourceGroups[pe.RowIndex] as IGroupRow;
            var e = new Group_display_event_args(null, null);// bindingSourceGroups.GroupOn);
            var selected = false;// selectedrows.Contains(pe.RowIndex);

            e.Selected = selected;
            e.Back_color = selected ? _dataGridView.DefaultCellStyle.SelectionBackColor : _dataGridView.DefaultCellStyle.BackColor;
            e.Fore_color = selected ? _dataGridView.DefaultCellStyle.SelectionForeColor : _dataGridView.DefaultCellStyle.ForeColor;
            e.Font = pe.InheritedRowStyle.Font;

            if (true)//_showcount)
                e.Summary = "(" + 55 + ")";// row.Count + ")";
                                           // if (true)//_showheader)
                                           //     e.Header = bindingSourceGroups.GroupOn.ToString();

            // e.GroupingInfo.Set_display_values(e);
            if (e.Cancel)
                return null;

            return e;
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
        Group_display_event_args Get_display_values12345(DataGridViewRowPrePaintEventArgs pe)
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
            Group_display_event_args info = new Group_display_event_args();// Get_display_values(e);
            if (info == null)
                return; //cancelled

            Rectangle RowBounds = e.RowBounds;
            RowBounds.Width = _dataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);// + _dataGridView.RowHeadersWidth;

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
            //int pointerPadding = 5;
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

            // CalendarRenderer.Corners crns = CalendarRenderer.Corners.None;

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
            return RoundRectangle(r, radius);
        }

        /// <summary>
        /// Creates a rectangle with the specified corners rounded
        /// </summary>
        public static GraphicsPath RoundRectangle(Rectangle r, int radius, int corners)
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
    }


    public class Group_display_event_args : CancelEventArgs
    {
        public readonly IGroupRow Row;
        public readonly Grouping_info GroupingInfo;
        public Group_display_event_args()
        { }
        public Group_display_event_args(IGroupRow row, Grouping_info info)
        {
            Row = row;
            GroupingInfo = info;
        }

        public object Value { get { return Row.Value; } }
        public string Display_value { get; set; }
        public string Header { get; set; }
        public string Summary { get; set; }
        public Color Back_color { get; set; }
        public Color Fore_color { get; set; }
        public Font Font { get; set; }
        public bool Selected { get; internal set; }
    }


    /// <summary>
    /// Extends the BindingSource class
    /// Act as bindingSource of groups.
    /// </summary>
    [DefaultEvent("BindingSourceGroups")]
    public class BindingSourceGroups : BindingSource
    {
        public event EventHandler Grouping_changed;
        void OnGroupingChanged()
        {
            Grouping_changed?.Invoke(this, EventArgs.Empty);
        }

        Grouping_info _groupon;
        [DefaultValue(null)]
        public Grouping_info GroupOn
        {
            get
            {
                return _groupon;
            }
            set
            {
                if (_groupon == value)
                    return;

                RemoveGrouping(value == null);

                if (value == null)
                    return;

                if (value.Equals(_groupon))
                    return;

                _groupon = value;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                OnGroupingChanged();
            }
        }

        SortOrder _order = SortOrder.Ascending;
        [DefaultValue(SortOrder.Ascending)]
        public SortOrder GroupSortDirection
        {
            get { return _order; }
            set
            {
                if (_order == value)
                    return;

                _order = value;
                Reset_group();
            }
        }


        GroupInfo _info;
        GroupInfo Info
        {
            get
            {
                if (_info == null)
                {
                    _info = new GroupInfo(this);
                    if (_bsource != null)
                        Sync_with_b_source();
                }
                return _info;
            }
        }
        BindingSource _bsource;
        PropertyDescriptorCollection _props;


        public BindingSourceGroups()
        { }

        public BindingSourceGroups(object dataSource) : this()
        {
            DataSource = dataSource;
            _bsource = (BindingSource)dataSource;
        }

        public BindingSourceGroups(object dataSource, string groupOn) : this(dataSource)
        { }


        public List<DataRowView> ToList()
        {
            if (_bsource == null)
                _bsource = DataSource as BindingSource;

            return _bsource.List.OfType<DataRowView>().ToList();
        }

        public void RemoveGrouping()
        {
            RemoveGrouping(true);
        }

        void RemoveGrouping(bool callListChanged)
        {
            if (_groupon == null)
                return;

            _groupon = null;
            Reset_group();

            if (!callListChanged)
                return;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            OnGroupingChanged();
        }

        public void SetGroupOn(string property)
        {
            SetGroupOn(Get_property(property));
        }

        PropertyDescriptor Get_property(string name)
        {
            PropertyDescriptor pd = GetItemProperties(null)[name];
            if (pd == null)
                throw new Exception(name + " is not a valid property");

            return pd;
        }

        public void SetGroupOn(PropertyDescriptor p)
        {
            ArgumentNullException.ThrowIfNull(p);

            if (_groupon == null || !_groupon.Is_property(p))
                GroupOn = new PropertyGrouper(p);
        }

        public void SetGroupOn(GroupingDelegate gd)
        {
            SetGroupOn(gd, null);
        }

        public void SetGroupOn(GroupingDelegate gd, string descr)
        {
            if (gd == null) throw new ArgumentNullException();
            GroupOn = new Delegate_grouper(gd, descr);
        }

        public void SetGroupOnStartLetters(Grouping_info g, int letters)
        {
            GroupOn = new Start_letter_grouper(g, letters);
        }

        public void SetGroupOnStartLetters(string property, int letters)
        {
            SetGroupOnStartLetters(Get_property(property), letters);
        }

        public bool IsGroupRow(int index)
        {
            if (_info == null)
                return false;

            if (index < 0 || index >= Count)
                return false;

            return _info.Rows[index] is GroupRow;
        }

        public IEnumerable<IGroupRow> Get_groups()
        {
            foreach (IGroupRow g in Info.GroupsDict.Values)
                yield return g;
        }

        public void Reset_group()
        {
            _info = null;
        }


        void DisposeBindingSourceEvents()
        {
            if (_bsource == null)
                return;

            _bsource.CurrentChanged -= BindinSourceCurrentChanged;
        }

        protected override void Dispose(bool disposing)
        {
            DisposeBindingSourceEvents();
            base.Dispose(disposing);
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            Reset_group();
            DisposeBindingSourceEvents();
            _bsource = DataSource as BindingSource;
            if (_bsource != null)
            {
                _bsource.CurrentChanged += BindinSourceCurrentChanged;
                if (NeedSync) Sync_with_b_source();
            }
            base.OnDataSourceChanged(e);
        }

        bool _suspendlistchange;
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (_suspendlistchange) return;

            switch (e.ListChangedType)
            {
                case ListChangedType.ItemChanged:
                    if (_groupon != null && _groupon.Is_property(e.PropertyDescriptor))
                        Reset_group();
                    break;
                case ListChangedType.ItemAdded:
                    if (_info != null)
                        _info.Rows.Add(List[e.NewIndex]);
                    break;
                case ListChangedType.ItemDeleted:
                    Reset_group();
                    break;
                case ListChangedType.Reset:
                    Reset_group();
                    break;
                case ListChangedType.PropertyDescriptorAdded:
                case ListChangedType.PropertyDescriptorChanged:
                case ListChangedType.PropertyDescriptorDeleted:
                    _props = null;
                    break;
            }

            base.OnListChanged(e);
        }

        public override object AddNew()
        {
            _suspendlistchange = true;
            try
            {
                var res = base.AddNew();
                if (_info != null)
                    _info.Rows.Add(res);
                return res;
            }
            finally
            {
                _suspendlistchange = false;
            }
        }

        public override void ApplySort(PropertyDescriptor property, ListSortDirection sort)
        {
            if (property is Property_wrapper)
                property = (property as Property_wrapper).Property;

            base.ApplySort(property, sort);
        }

        //public override void ApplySort(ListSortDescriptionCollection sorts)
        //{
        //    base.ApplySort(sorts);
        //}

        public override void RemoveAt(int index)
        {
            if (_info == null || _groupon == null)
                base.RemoveAt(index);
            else
                if (!IsGroupRow(index))
                {
                    var i = List.IndexOf(this[index]);
                    _suspendlistchange = true;
                    try
                    {
                        _info.Rows.RemoveAt(index);
                        List.RemoveAt(i);
                        base.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
                    }
                    finally
                    {
                        _suspendlistchange = false;
                    }
                }
        }

        public override void Remove(object? value)
        {
            if (value is GroupRow)
                return;

            var index = IndexOf(value);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        protected override void OnCurrentChanged(EventArgs e)
        {
            base.OnCurrentChanged(e);
            if (NeedSync && !(Current is GroupRow))
            {
                _bsource.Position = _bsource.IndexOf(Current);
            }
        }

        void BindinSourceCurrentChanged(object sender, EventArgs e)
        {
            if (NeedSync)
                Sync_with_b_source();
        }

        bool NeedSync
        {
            get
            {
                if (_bsource == null || _suspendlistchange)
                    return false;
                if (_bsource.IsBindingSuspended)
                    return false;
                if (GroupOn == null)
                    return false;

                return Current != _bsource.Current;
            }
        }

        void Sync_with_b_source()
        {
            Position = IndexOf(_bsource.Current);
        }

        public override int IndexOf(object? value)
        {
            return Info.Rows.IndexOf(value);
        }

        public override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors == null)
            {
                if (_props == null)
                {
                    /*
                    props = new PropertyDescriptorCollection( 
                    base.GetItemProperties(null).Cast<PropertyDescriptor>()
                    .Select(pd => new PropertyWrapper(pd, this)).ToArray());*/
                    _props = base.GetItemProperties(null);
                    var arr = new PropertyDescriptor[_props.Count];
                    for (int i = 0; i < _props.Count; i++)
                    {
                        arr[i] = new Property_wrapper(_props[i], this);
                    }
                    _props = new PropertyDescriptorCollection(arr);
                }
                return _props;
            }
            return base.GetItemProperties(listAccessors);
        }

        public int Base_count
        {
            get
            {
                return base.Count;
            }
        }
        public object Get_base_row(int index)
        {
            return List[index];
        }
        public override int Count
        {
            get
            {
                return Info.Total_count;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object this[int index]
        {
            get
            {
                return Info.Rows[index];
            }
            set
            {
                Info.Rows[index] = value;
            }
        }


        class GroupInfo
        {
            public readonly BindingSourceGroups OwnerBindingSourceGroups;

            public GroupInfo(BindingSourceGroups owner)
            {
                OwnerBindingSourceGroups = owner;
                Set();
            }

            public int Total_count
            {
                get
                {
                    return Rows.Count;
                }
            }

            public IList Rows;
            //public List<GroupRow> Groups = new List<GroupRow>();
            public IDictionary<object, GroupRow> GroupsDict;

            void Set()
            {
                GroupsDict = null;
                var groupInfo = OwnerBindingSourceGroups._groupon;

                if (groupInfo == null)
                {
                    Rows = OwnerBindingSourceGroups.List;
                    //return;
                }

                if (OwnerBindingSourceGroups.GroupSortDirection == SortOrder.None)
                    GroupsDict = new Dictionary<object, GroupRow>();
                else
                {
                    var comparer = new Generic_comparer
                    {
                        Descending = OwnerBindingSourceGroups.GroupSortDirection == SortOrder.Descending
                    };

                    GroupsDict = new SortedDictionary<object, GroupRow>();
                }

                OwnerBindingSourceGroups.Filter = "PartNumber LIKE 'AT60*'";

                foreach (var row in OwnerBindingSourceGroups)
                {
                    //object key = groupInfo.Get_group_value(row);
                    string key;
                    GroupRow groupRow;
                    DataRowView rowP = (DataRowView)row;

                    groupRow = new GroupRow
                    {
                        Value = key = rowP["PartNumber"].ToString()
                    };
                    groupRow.List.Add(rowP);

                    if (key.Contains("AT60"))
                    {
                        groupRow.List.AddRange(OwnerBindingSourceGroups.ToList().FindAll(f => f["PartNumber"].ToString().Contains("AT87")));
                    }

                    GroupsDict.Add(key, groupRow);
                }

                var i = 0;
                OwnerBindingSourceGroups.Filter = "";
                Rows = new List<object>(GroupsDict.Count + OwnerBindingSourceGroups.Base_count);

                foreach (GroupRow _grouprow in GroupsDict.Values)
                {
                    _grouprow.Finalize(i++);
                    Rows.Add(_grouprow);
                    foreach (var row in _grouprow.Rows)
                        Rows.Add(row);
                }
            }
        }

        public class GroupRow : DataGridViewRow, IGroupRow
        {
            public new int Index { get; private set; }
            public object Value { get; set; }
            public DataRowView[] Rows { get; private set; }

            public int Count
            {
                get { return Rows.Length > 0 ? Rows.Length : 0; }
            }

            public List<DataRowView> List = new List<DataRowView>();
            public void Finalize(int index)
            {
                Index = index;
                Rows = List.ToArray();
                List = null;
            }
        }

        public class Property_wrapper : PropertyDescriptor
        {
            public readonly PropertyDescriptor Property;
            public readonly BindingSourceGroups Owner;
            public Property_wrapper(PropertyDescriptor property, BindingSourceGroups owner) : base(property)
            {
                Property = property;
                Owner = owner;
            }
            public override bool CanResetValue(object component)
            {
                return Property.CanResetValue(component);
            }
            public override Type ComponentType
            {
                get { return Property.ComponentType; }
            }

            public override bool IsReadOnly
            {
                get { return Property.IsReadOnly; }
            }
            public override Type PropertyType
            {
                get { return Property.PropertyType; }
            }
            public override void ResetValue(object component)
            {
                Property.ResetValue(component);
            }
            public override bool ShouldSerializeValue(object component)
            {
                return Property.ShouldSerializeValue(component);
            }

            public override object? GetValue(object? component)
            {
                throw new NotImplementedException();
            }

            public override void SetValue(object? component, object? value)
            {
                throw new NotImplementedException();
            }
        }
    }


    #region Grouping Info objects

    public abstract class Grouping_info
    {
        public abstract object Get_group_value(object row);
        public virtual bool Is_property(PropertyDescriptor p)
        {
            return false;
        }
        public virtual bool Is_property(string name)
        {
            return name == ToString();
        }
        public static implicit operator Grouping_info(PropertyDescriptor p)
        {
            return new PropertyGrouper(p);
        }
        public virtual void Set_display_values(Group_display_event_args e)
        {
            var o = e.Value;
            e.Display_value = o == null ? "<Null>" : o.ToString();
        }
    }
    public class PropertyGrouper : Grouping_info
    {
        public readonly PropertyDescriptor Property;
        public PropertyGrouper(PropertyDescriptor property)
        {
            ArgumentNullException.ThrowIfNull(property);
            Property = property;
        }
        public override object Get_group_value(object row)
        {
            return Property.GetValue(row);
        }
        public override string ToString()
        {
            return Property.Name;
        }
    }
    public delegate object GroupingDelegate(object row);
    public class Delegate_grouper : Grouping_info
    {
        public readonly string Name;
        public readonly GroupingDelegate GroupingDelegate;
        public Delegate_grouper(GroupingDelegate @delegate, string name)
        {
            if (@delegate == null) throw new ArgumentNullException();
            Name = name;
            if (name == null) Name = @delegate.ToString();
            GroupingDelegate = @delegate;
        }
        public override string ToString()
        {
            return Name;
        }
        public override object Get_group_value(object row)
        {
            return GroupingDelegate(row);
        }
    }
    public class Start_letter_grouper : Grouping_info
    {
        public readonly Grouping_info Grouper;
        public readonly int Letters;
        public Start_letter_grouper(Grouping_info grouper) : this(grouper, 1)
        {
        }
        public Start_letter_grouper(Grouping_info grouper, int letters)
        {
            if (grouper == null) throw new ArgumentNullException();
            Grouper = grouper;
            Letters = letters;
        }
        public override string ToString()
        {
            return Grouper.ToString();
        }
        public override bool Is_property(PropertyDescriptor p)
        {
            return Grouper.Is_property(p);
        }
        public override object Get_group_value(object row)
        {
            var val = Grouper.Get_group_value(row);
            if (val == null) return null;
            var s = val.ToString();
            if (s.Length < Letters) return s;
            return s.Substring(0, Letters);
        }
    }

    #endregion

    #region Interfaces

    public interface IGrouper
    {
        void SetGroupOn(string col);
        void SetGroupOn(PropertyDescriptor col);
        void Remove_grouping();
        Grouping_info Group_on { get; set; }
        event EventHandler Properties_changed;
        event EventHandler Grouping_changed;
        IEnumerable<PropertyDescriptor> Get_properties();
    }
    public interface IGroupRow
    {
        int Index { get; }
        object Value { get; }
        int Count { get; }
        DataRowView[] Rows { get; }
    }
    public interface IDataGridViewGrouperOwner
    {
        DataGridViewGrouper Grouper { get; }
    }

    #endregion

}

using System.ComponentModel;
using System.Data;
using ColumnNameSelected_EventArgs = MyStuff11net.Custom_Events_Args.ColumnNameSelected_EventArgs;
using Need_SaveData_EventArgs = MyStuff11net.Custom_Events_Args.Need_SaveData_EventArgs;
using SecondCondition_EventArgs = MyStuff11net.Custom_Events_Args.SecondCondition_EventArgs;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;
using StringFilterControl_EventArgs = MyStuff11net.Custom_Events_Args.StringFilterControl_EventArgs;


namespace MyStuff11net
{
    public partial class QueryBuilder : UserControl
    {
        #region"Custom Controls Events with custom Args.*********************"

        #region"ColumnNameSelected"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User has selected a ColumnName.")]
        public event ColumnNameSelectedEventHandler ColumnNameSelected;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ColumnNameSelectedEventHandler(object sender, ColumnNameSelected_EventArgs e);


        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_ColumnNameSelected(ColumnNameSelected_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (ColumnNameSelected != null)
            {
                // Notify Subscribers
                ColumnNameSelected(this, e);
            }
        }

        #endregion"ColumnNameSelected"

        #region "StringFilter event."

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Description("StringFilter Event.")]
        [Browsable(true), Category("Controls Events")]
        public event StringFilterControlEventHandler StringFilter;

        // # 2 ... ***** StringFilter Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StringFilterControlEventHandler(object sender, StringFilterControl_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_StringFilter(StringFilterControl_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (StringFilter != null)
            {
                StringFilter(this, e);
            }
        }

        #endregion "StringFilter event."

        #region"Second Condition"
        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Second Condition.")]
        public event SecondConditionEventHandler SecondCondition;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SecondConditionEventHandler(object sender, SecondCondition_EventArgs e);


        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_SecondCondition(SecondCondition_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (SecondCondition != null)
            {
                // Notify Subscribers
                SecondCondition(this, e);
            }
        }

        #endregion"Second Condition"

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
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (StatusBarMessage != null)
            {
                // Notify Subscribers
                StatusBarMessage(this, e);
            }
        }

        #endregion"StatusBarMessage"

        #region"Need_SaveData"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event NeedSaveDataEventHandler NeedSaveData;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void NeedSaveDataEventHandler(object sender, Need_SaveData_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Need_SaveData(Need_SaveData_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (NeedSaveData != null)
            {
                // Notify Subscribers
                NeedSaveData(this, e);
            }
        }

        #endregion"Need_SaveData"

        #endregion"Custom Controls Events with custom Args.*********************"

        /// <summary>
        /// Get or Set the value of Condition field on the default FilterCondition object.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Condition
        {
            get
            {
                return filterCondition0.Condition;
            }
            set
            {
                filterCondition0.Condition = value;
            }
        }

        int CounterEvents = 0;

        bool _debugMode = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DebugMode
        {
            get
            {
                return _debugMode;
            }
            set
            {
                _debugMode = value;
                filterCondition0.DebugMode = true;
            }
        }

        DataColumnCollection _columnsCollection;
        /// <summary>
        /// Keep a record of all columns existent in StockRoom datatable.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataColumnCollection ColumnsCollection
        {
            get
            {
                return _columnsCollection;
            }
            set
            {
                if (value == null)
                    return;

                _columnsCollection = value;
            }
        }

        private bool _needSaveData;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool NeedSaveDataPro
        {
            get
            {
                return _needSaveData;
            }
            set
            {
                if (!(Bounds.Contains(PointToClient(MousePosition))))
                    return;

                _needSaveData = value;
            }
        }


        /// <summary>
        /// Keep record about the ColumnName active to format the filter.
        /// </summary>
        Dictionary<string, string> ColumnFilter = new Dictionary<string, string>();


        public QueryBuilder()
        {
            InitializeComponent();

            Load += QueryBuilder_Load;
            Resize += QueryBuilder_Resize;

            QueryBuilder_Resize(new object(), new EventArgs());
        }


        void QueryBuilder_Load(object sender, EventArgs e)
        {
            try
            {
                SendStatusBarMessage("QueryBuilder_Load");

                // Initialize the default filter_Condition.                
                filterCondition0.Text = @"NewControl 0";
                filterCondition0.FilterControlIndex = 0;
                filterCondition0.Tag = 0;
                filterCondition0.ControlText = @"NewControl 0";
                filterCondition0.ColumnsNameFactory(ColumnsCollection);
                ColumnFilter.Add(filterCondition0.ControlText, "");

                filterCondition0.NeedSaveData += NewControl_Need_SaveData;
                filterCondition0.StringFilter += NewControl_StringFilter;
                filterCondition0.StatusBarMessage += FilterCondition0_StatusBarMessage;
                filterCondition0.SecondCondition += FilterConditionSecondConditionHandler;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        void FilterCondition0_StatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        void QueryBuilder_Resize(object sender, EventArgs e)
        {
            labelStringFilter.MaximumSize = new Size(Width - 40, 100);
        }

        void SendStatusBarMessage(string info)
        {
            if (DebugMode == false)
                return;

            CounterEvents++;
            On_StatusBarMessage(new StatusBarMessage_EventArgs(info + " " + CounterEvents));
        }

        #region"Filter, add new filter condition"

        // A new filter has been generated.
        private void NewControl_StringFilter(object sender, StringFilterControl_EventArgs e)
        {
            SendStatusBarMessage("NewControl_StringFilter");

            if (e == null || e.ControlText == null)
                return;

            var filter = panelFilterConditions.Controls.OfType<FilterCondition>().Aggregate
                                                ("", (current, filterControl) => current + filterControl.FilterString);

            var filterSql = panelFilterConditions.Controls.OfType<FilterCondition>().Aggregate
                                                ("", (current, filterControl) => current + filterControl.FilterStringSql);
            if (_showSqlFilter)
                labelStringFilter.Text = filterSql;


            comboBoxStringFilter.Text = filter;

            On_StringFilter(new StringFilterControl_EventArgs(filterSql));
        }

        // A second condition has been requested.
        private void FilterConditionSecondConditionHandler(object sender, SecondCondition_EventArgs e)
        {
            NewControl_SecondCondition(sender, e);
        }

        /// <summary>
        /// Created a new filter conditions and add its to the controls list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private FilterCondition NewControl_SecondCondition(object sender, SecondCondition_EventArgs e)
        {
            switch (e.SecondCondition)
            {
                case "AND":
                    {
                        FilterCondition newControl = AddNew_FilterCondition(e);

                        return newControl;
                    }
                case "OR":
                    {
                        FilterCondition newControl = AddNew_FilterCondition(e);

                        return newControl;
                    }
                case "None":
                    {
                        RemoveUp(e.IndexNextControl);
                        return null;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        private FilterCondition AddNew_FilterCondition(SecondCondition_EventArgs e)
        {
            var newControlFilter = AddNewFilter(ColumnsCollection);
            newControlFilter.Location = new Point(e.LocationX + 15, e.LocationY + e.Higth);
            newControlFilter.MinimumSize = new Size((e.Width - 15), newControlFilter.MinimumSize.Height);
            // Do not dock to top, loss position and order.
            //newControlFilter.Dock = DockStyle.Top;

            panelFilterConditions.Controls.Add(newControlFilter);
            panelFilterConditions.Height += newControlFilter.Height;

            return newControlFilter;
        }

        private FilterCondition AddNewFilter(DataColumnCollection dataColumns)
        {
            var countedFilter = panelFilterConditions.Controls.Count;

            var newControl = new FilterCondition(dataColumns)
            {
                Name = "filterCondition" + countedFilter,
                Tag = countedFilter,
                ControlText = "NewControl " + countedFilter,
                FilterControlIndex = countedFilter,
                Width = filterCondition0.Width
            };

            newControl.NeedSaveData += NewControl_Need_SaveData;
            newControl.StringFilter += NewControl_StringFilter;
            newControl.SecondCondition += FilterConditionSecondConditionHandler;

            return newControl;
        }

        private void NewControl_Need_SaveData(object sender, Need_SaveData_EventArgs e)
        {
            NeedSaveDataPro = true;
        }

        /// <summary>
        /// Deleted all control whit FilterControlIndex >= indexFilterControl.
        /// </summary>
        private void RemoveUp(int indexFilterControl)
        {
            // MyCode.SuspendDrawing(Parent);

            List<FilterCondition> toDeleted = panelFilterConditions.Controls.OfType<FilterCondition>().Where
                                    (filterConditon => filterConditon.FilterControlIndex >= indexFilterControl).ToList();

            foreach (var filterConditiontoDeletes in toDeleted)
            {
                panelFilterConditions.Controls.Remove(filterConditiontoDeletes);
                panelFilterConditions.Height -= filterConditiontoDeletes.Height;
            }

            // MyCode.ResumeDrawing(Parent);
        }

        public void Process_StringFilter(string stringFilter)
        {
            if (panelFilterConditions.Controls.Count > 1)
                RemoveUp(1);

            if (string.IsNullOrEmpty(stringFilter.Trim()))
            {
                comboBoxStringFilter.Text = "";
                filterCondition0.Update_Filter(null);
                return;
            }

            if (stringFilter.Contains(" NOT LIKE "))
                stringFilter = stringFilter.Replace("NOT LIKE", "NOTLIKE");

            if (stringFilter.Contains("'AND"))
                stringFilter = stringFilter.Replace("'AND", "' AND");

            var defaultFilterCondition = panelFilterConditions.Controls["filterCondition0"] as FilterCondition;

            //SuspendLayout();
            MyCode.SuspendDrawing(this);

            string[] filterArray;

            if (stringFilter.Contains(" AND ") || stringFilter.Contains(" OR ") ||
                stringFilter.Contains(" NOT ") || stringFilter.Contains("NOTLIKE"))
            {
                #region"UnGroup the filter collection"

                filterArray = stringFilter.Split(new[] { " AND ", " OR ", " NOT " }, StringSplitOptions.RemoveEmptyEntries);

                var temp = stringFilter;

                for (int s = 0; s < (filterArray.Length - 1); s++)
                {
                    temp = temp.Replace(filterArray[s], "");
                    string condition = temp.Substring(0, 4).Trim();

                    switch (condition)
                    {
                        case "AND":
                            {
                                filterArray[s] += " AND ";
                                temp = temp.Substring(5);
                                break;
                            }
                        case "OR":
                            {
                                filterArray[s] += " OR ";
                                temp = temp.Substring(4);
                                break;
                            }
                        case "NOT":
                            {
                                filterArray[s] += " NOT ";
                                temp = temp.Substring(5);
                                break;
                            }
                    }
                }

                #endregion"UnGroup the filter collection"

                #region"Generated new filter_control, one by filterString in filterArray."

                if (defaultFilterCondition != null)
                    defaultFilterCondition.Update_Filter(filterArray[0]);

                for (int i = 1; i < filterArray.Length; i++)
                {
                    var anteriorfiltercontrol = (FilterCondition)panelFilterConditions.Controls["filterCondition" + (i - 1)];

                    var newControlArgs = new SecondCondition_EventArgs(anteriorfiltercontrol.SecondConditionComboBox.Text,
                                                                                         (int)anteriorfiltercontrol.SecondConditionComboBox.Tag,
                                                                                         anteriorfiltercontrol.LocationX,
                                                                                         anteriorfiltercontrol.LocationY,
                                                                                         anteriorfiltercontrol.Width,
                                                                                         anteriorfiltercontrol.Height);

                    if (newControlArgs.SecondCondition == "None")
                        break;

                    FilterCondition newControlFilter = NewControl_SecondCondition(new object(), newControlArgs);

                    newControlFilter.Update_Filter(filterArray[i]);
                }

                #endregion"Generated new filter_control, one by filterString in filterArray."
            }
            else
                defaultFilterCondition?.Update_Filter(stringFilter);

            comboBoxStringFilter.Text = stringFilter;

            MyCode.ResumeDrawing(this);
            //ResumeLayout(true);
        }

        #endregion"Filter, add new filter condition"

        private bool _showSqlFilter;
        private void LabelStringFilterDoubleClick(object sender, EventArgs e)
        {
            if (_showSqlFilter)
            {
                _showSqlFilter = false;
                labelStringFilter.Text = @"String Filter. The helper will attempt to format it correctly. Almost all, following this syntax,
                                                                                                        ""Column name + Operator + Condition";
                return;
            }

            _showSqlFilter = true;
        }

    }
}

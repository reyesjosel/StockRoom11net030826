using System.ComponentModel;
using System.Data;
using ColumnNameSelected_EventArgs = MyStuff11net.Custom_Events_Args.ColumnNameSelected_EventArgs;
using Need_SaveData_EventArgs = MyStuff11net.Custom_Events_Args.Need_SaveData_EventArgs;
using SecondCondition_EventArgs = MyStuff11net.Custom_Events_Args.SecondCondition_EventArgs;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;
using StringFilterControl_EventArgs = MyStuff11net.Custom_Events_Args.StringFilterControl_EventArgs;
using Timer = System.Windows.Forms.Timer;

namespace MyStuff11net
{
    public sealed partial class FilterCondition : UserControl
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
        public void On_ColumnNameSelected(ColumnNameSelected_EventArgs e)
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


        Timer tic = new Timer();
        StringFilterControl_EventArgs _ev;
        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        void On_StringFilter(StringFilterControl_EventArgs e)
        {
            _ev = e;

            if (tic.Enabled)
            {
                tic.Stop();
                tic.Start();
                return;
            }

            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (StringFilter != null)
            {
                tic.Tick += new EventHandler(TicTick);
                tic.Interval = 800;
                tic.Start();
            }
        }

        void TicTick(object sender, EventArgs e)
        {
            tic.Stop();
            tic.Tick -= TicTick;

            if (comboBoxSecondCondition.Text != @"None")
            {
                FilterString = comboBoxColumnName.Text + " " + comboBoxOperator.Text + " " + comboBoxCondition.Text + " " +
                               comboBoxSecondCondition.Text + " ";
            }
            else
            {
                FilterString = comboBoxColumnName.Text + " " + comboBoxOperator.Text + " " + comboBoxCondition.Text;
            }

            // Notify Subscribers
            StringFilter(this, _ev);
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
        public void On_SecondCondition(SecondCondition_EventArgs e)
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
        void On_StatusBarMessage(StatusBarMessage_EventArgs e)
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
        public void On_Need_SaveData(Need_SaveData_EventArgs e)
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

        int CounterEvents = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DebugMode { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LocationX
        {
            get
            {
                return Location.X;
            }

            set
            {
                Location = new Point(value, Location.Y);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LocationY
        {
            get
            {
                return Location.Y;
            }

            set
            {
                Location = new Point(Location.X, value);
            }
        }

        /// <summary>
        /// Get or Set the value of Condition fiel.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Get or Set the value of Condition fiel.
        /// </summary>
        public string Condition
        {
            get
            {
                return comboBoxCondition.Text;
            }
            set
            {
                comboBoxCondition.Text = value;
            }
        }

        public ComboBox SecondConditionComboBox
        {
            get
            {
                return comboBoxSecondCondition;
            }
        }

        /// <summary>
        /// UpDateProcess mint the information is update from outside, no need StringFilter event.
        /// </summary>
        bool _upDateProcess;

        string _selectedColumnType = "";

        int _filterControlIndex;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FilterControlIndex
        {
            get
            {
                return _filterControlIndex;
            }
            set
            {
                _filterControlIndex = value;
                comboBoxSecondCondition.Tag = value;

                if (_filterControlIndex == 0)
                    ShowLabels = true;
                else
                    ShowLabels = false;
            }
        }

        string _controlText;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ControlText
        {
            get { return _controlText; }
            set { _controlText = value; }
        }

        bool _showLabels;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowLabels
        {
            get { return _showLabels; }
            set
            {
                _showLabels = value;
                if (value)
                    panel_Labels.Visible = true;
                else
                    panel_Labels.Visible = false;
            }
        }

        /// <summary>
        /// Contains the current filter.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilterString { get; set; }

        /// <summary>
        /// Name of the column below to this control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataColumn ColumnNameProperty
        {
            get
            {
                if (ColumnsCollections == null)
                    return new DataColumn("No Column in the collection", typeof(Int32));

                return ColumnsCollections[comboBoxColumnName.Text];
            }
            set
            {
                comboBoxColumnName.Text = value.ColumnName;
            }
        }

        DataColumnCollection _columnsCollections;
        /// <summary>
        /// Keep a record of all columns existent in StockRoom datatable.
        /// </summary>
        DataColumnCollection ColumnsCollections
        {
            get
            {
                return _columnsCollections;
            }
            set
            {
                _columnsCollections = value;

                // This typeof(Int64) is only for clear the filter.
                //if(!(_columnsCollections.Contains(" ")))
                //    _columnsCollections.Add(" ", typeof(Int64));
            }
        }

        public FilterCondition()
        {
            InitializeComponent();

            FilterControlIndex = 0;
            Filter_Condition_Resize(new object(), new EventArgs());
        }

        public FilterCondition(DataColumnCollection columnsCollections)
        {
            InitializeComponent();

            FilterControlIndex = 0;
            ColumnsNameFactory(columnsCollections);

            Filter_Condition_Resize(new object(), new EventArgs());
        }

        public FilterCondition(DataColumnCollection columnsCollections, int filterControlIndex)
        {
            InitializeComponent();

            FilterControlIndex = filterControlIndex;

            ColumnsNameFactory(columnsCollections);

            Filter_Condition_Resize(new object(), new EventArgs());
        }

        void Filter_Condition_Load(object sender, EventArgs e)
        {
            SendStatusBarMessage("Filter_Condition_Load");

            _upDateProcess = true;

            comboBoxColumnName.TabIndex = 1;
            comboBoxOperator.TabIndex = 2;
            comboBoxCondition.TabIndex = 3;
            comboBoxSecondCondition.TabIndex = 4;

            comboBoxColumnName.Text = @" ";

            comboBoxCondition.DataSource = Enum.GetValues(typeof(MyCode.DataFilter))
                            .Cast<MyCode.DataFilter>()
                            .Select(v => new ComboEnumItem(v))
                            .ToList();

            comboBoxCondition.DisplayMember = "Text";
            comboBoxCondition.ValueMember = "Value";
            comboBoxCondition.Text = "";

            Resize += Filter_Condition_Resize;

            Filter_Condition_Resize(sender, e);
        }

        void SendStatusBarMessage(string info)
        {
            if (DebugMode == false)
                return;

            CounterEvents++;
            On_StatusBarMessage(new StatusBarMessage_EventArgs(info + " " + CounterEvents));
        }

        void Filter_Condition_Resize(object sender, EventArgs e)
        {
            SuspendLayout();

            if (ShowLabels)
            {
                var position = 0;
                labelColumnName.Location = new Point(position, 0);
                comboBoxColumnName.Location = new Point(position, 0);
                comboBoxColumnName.Width = (Width * 22) / 100;

                position += comboBoxColumnName.Width + 5;
                labelOperator.Location = new Point(position, 0);
                comboBoxOperator.Location = new Point(position, 0);
                comboBoxOperator.Width = (Width * 17) / 100;

                position += comboBoxOperator.Width + 5;
                labelCondition.Location = new Point(position, 0);
                comboBoxCondition.Location = new Point(position, 0);
                comboBoxCondition.Width = (Width * 44) / 100;

                position += comboBoxCondition.Width + 5;
                labelSecondCondition.Location = new Point(position, 0);
                comboBoxSecondCondition.Location = new Point(position, 0);
                comboBoxSecondCondition.Width = (Width * 13) / 100;
            }
            else
            {
                var position = 0;
                comboBoxColumnName.Location = new Point(position, 0);
                comboBoxColumnName.Width = (Width * 22) / 100;

                position += comboBoxColumnName.Width + 5;
                comboBoxOperator.Location = new Point(position, 0);
                comboBoxOperator.Width = (Width * 17) / 100;

                position += comboBoxOperator.Width + 5;
                comboBoxCondition.Location = new Point(position, 0);
                comboBoxCondition.Width = (Width * 44) / 100;

                position += comboBoxCondition.Width + 5;
                comboBoxSecondCondition.Location = new Point(position, 0);
                comboBoxSecondCondition.Width = (Width * 13) / 100;
            }

            ResumeLayout(true);
        }

        //ToDo: Check if this event is necessary.
        void Filter_Condition_VisibleChanged(object sender, EventArgs e)
        {
            return;

            if (Visible)
                On_StringFilter(new StringFilterControl_EventArgs(ColumnNameProperty, comboBoxColumnName.Text,
                                                                comboBoxOperator.Text, comboBoxCondition.Text, ControlText));
        }

        /// <summary>
        /// Fills items in Column name, and initialized ColumnsCollections property.
        /// </summary>
        /// <param name="columnsCollections"></param>
        public void ColumnsNameFactory(DataColumnCollection columnsCollections)
        {
            if (columnsCollections == null)
                return;

            //Initialize the collection.
            ColumnsCollections = columnsCollections;

            foreach (DataColumn column in columnsCollections)
            {
                comboBoxColumnName.Items.Add(column.ColumnName);
            }
        }

        /// <summary>
        /// Input any stringFilter and attempt to fill Column name, Operator and Condition.
        /// </summary>
        /// <param name="stringFilter"></param>
        public void Update_Filter(string? stringFilter)
        {
            try
            {
                _upDateProcess = true;

                SendStatusBarMessage("Update_Filter");

                if (stringFilter == null)
                {
                    comboBoxColumnName.SelectedItem = null;
                    comboBoxOperator.SelectedItem = null;
                    comboBoxOperator.Enabled = false;
                    comboBoxCondition.Text = "";
                    comboBoxCondition.SelectedItem = null;
                    comboBoxCondition.Enabled = false;
                    comboBoxSecondCondition.Text = "";                                                                         // 0        1        2
                    comboBoxSecondCondition.SelectedItem = comboBoxSecondCondition.Items[2]; // AND - OR - None
                    comboBoxSecondCondition.Enabled = false;
                    return;
                }

                string? operation = "";
                string? condition = "";

                string? temp = stringFilter;// Replace(comboBoxColumnName.Text + " ", "");

                #region"Column Name"

                string _columnName = stringFilter.Substring(0, stringFilter.IndexOf(' ')).Trim();

                comboBoxColumnName.SelectedIndex = -1;

                foreach (DataColumn column in ColumnsCollections)
                {
                    if (column.ColumnName == _columnName)
                    {
                        comboBoxColumnName.SelectedIndex = ColumnsCollections.IndexOf(column);
                        break;
                    }
                }

                if (comboBoxColumnName.SelectedIndex == -1)
                {
                    MessageBox.Show(@"No column name was found in the filter. This is an error. " +
                                      "Every filter must specify the column to which it will be applied.",
                                @"Incorrect filter syntax.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion"Column Name"

                #region"Column type "int"

                if (temp.Contains('<') || temp.Contains('=') || temp.Contains('>') || temp.Contains('!'))
                {
                    FillComboBoxItems(comboBoxOperator, "Int32");

                    #region"Find numeric operation."

                    if (temp.Contains("<="))
                    {
                        if (temp.Contains(">=") && temp.IndexOf("<=") < temp.IndexOf(">="))
                        {
                            operation = "<= XXXX >=";
                            int first = temp.IndexOf("<=");
                            int second = temp.IndexOf(">=");
                            int ending = second - first - 2;
                            condition = temp.Substring(first + 2, ending).Trim();
                            comboBoxOperator.SelectedIndex = comboBoxOperator.FindStringExact("Between");
                        }
                        else
                        {
                            operation = "<=";
                            condition = temp.Substring(temp.IndexOf("<=") + 2).Trim();
                            comboBoxOperator.SelectedIndex = comboBoxOperator.FindStringExact("Less Than or Equal to");
                        }
                    }
                    else
                        if (temp.Contains(">="))
                        {
                            operation = ">=";
                            condition = temp.Substring(temp.IndexOf(">=") + 1).Trim();
                            comboBoxOperator.SelectedIndex = comboBoxOperator.FindStringExact("Greater Than or Equal to");
                        }

                    if (operation == "")
                    {
                        if (temp.Contains("<>"))
                        {
                            operation = "<>";
                            condition = temp.Substring(temp.IndexOf("<>") + 2).Trim();
                            comboBoxOperator.SelectedIndex = comboBoxOperator.FindStringExact("Does Not Equals");
                        }
                        else
                        {
                            if (temp.Contains("<"))
                            {
                                operation = "<";
                                condition = temp.Substring(temp.IndexOf("<") + 1).Trim();
                                comboBoxOperator.SelectedIndex = comboBoxOperator.FindStringExact("Less Than");
                            }
                            else
                                if (temp.Contains(">"))
                                {
                                    operation = ">";
                                    condition = temp.Substring(temp.IndexOf(">") + 1).Trim();
                                    comboBoxOperator.SelectedIndex = comboBoxOperator.FindStringExact("Greater Than");
                                }
                        }
                    }

                    if (operation == "")
                    {
                        if (temp.Contains("!="))
                        {
                            operation = "!=";
                            condition = temp.Substring(temp.IndexOf("!=") + 2).Trim();
                            comboBoxOperator.SelectedIndex = comboBoxOperator.FindStringExact("Does Not Equals");
                        }
                    }

                    if (operation == "")
                    {
                        operation = "=";
                        condition = temp.Substring(temp.IndexOf("=") + 1).Trim();
                        comboBoxOperator.SelectedIndex = comboBoxOperator.FindStringExact("Equals to");
                    }

                    #endregion"Find numeric operation."
                }

                #endregion"Column type "int"

                #region"Column type "string"

                if (temp.Contains('\''))
                {
                    FillComboBoxItems(comboBoxOperator, "String");

                    int first = temp.IndexOf('\'');
                    int second = temp.LastIndexOf('\'');

                    operation = temp.Substring(0, first).Trim();
                    operation = operation.Replace(_columnName, "").Trim();

                    operation = operation.ToUpper();

                    int ending = second - first - 1;
                    condition = temp.Substring(first + 1, ending).Trim();


                    bool start = false;
                    bool end = false;

                    string operationStarEnd = operation + " '";

                    if (condition.StartsWith("*"))
                    {
                        operationStarEnd += "*xxxxx";
                        start = true;
                    }

                    if (condition.EndsWith("*"))
                    {
                        if (start)
                            operationStarEnd += "*'";
                        else
                            operationStarEnd += "xxxxx*'";

                        end = true;
                    }

                    if (!start && !end)
                        operationStarEnd += "xxxxx'";

                    switch (operationStarEnd)
                    {
                        case "LIKE 'xxxxx'":
                            {
                                foreach (string item in comboBoxOperator.Items)
                                {
                                    if (item == "Equals")
                                    {
                                        comboBoxOperator.SelectedItem = item;
                                        break;
                                    }
                                }
                                break;
                            }
                        case "NOTLIKE 'xxxxx'":
                            {
                                foreach (string item in comboBoxOperator.Items)
                                {
                                    if (item == "Does Not Equals")
                                    {
                                        comboBoxOperator.SelectedItem = item;
                                        break;
                                    }
                                }
                                break;
                            }
                        case "LIKE 'xxxxx*'":
                            {
                                foreach (string item in comboBoxOperator.Items)
                                {
                                    if (item == "Begin With")
                                    {
                                        comboBoxOperator.SelectedItem = item;
                                        break;
                                    }
                                }
                                break;
                            }
                        case "NOTLIKE 'xxxxx*'":
                            {
                                foreach (string item in comboBoxOperator.Items)
                                {
                                    if (item == "Does Not Begin With")
                                    {
                                        comboBoxOperator.SelectedItem = item;
                                        break;
                                    }
                                }
                                break;
                            }
                        case "LIKE '*xxxxx*'":
                            {
                                foreach (string item in comboBoxOperator.Items)
                                {
                                    if (item == "Contains")
                                    {
                                        comboBoxOperator.SelectedItem = item;
                                        break;
                                    }
                                }
                                break;
                            }
                        case "NOTLIKE '*xxxxx*'":
                            {
                                foreach (string item in comboBoxOperator.Items)
                                {
                                    if (item == "Does Not Contains")
                                    {
                                        comboBoxOperator.SelectedItem = item;
                                        break;
                                    }
                                }
                                break;
                            }
                        case "LIKE '*xxxxx'":
                            {
                                foreach (string item in comboBoxOperator.Items)
                                {
                                    if (item == "Ends With")
                                    {
                                        comboBoxOperator.SelectedItem = item;
                                        break;
                                    }
                                }
                                break;
                            }
                        case "NOTLIKE '*xxxx'":
                            {
                                foreach (string item in comboBoxOperator.Items)
                                {
                                    if (item == "Does Not End With")
                                    {
                                        comboBoxOperator.SelectedItem = item;
                                        break;
                                    }
                                }
                                break;
                            }
                        case "CONTAINS 'xxxxx'":
                            {
                                foreach (string item in comboBoxOperator.Items)
                                {
                                    if (item == "Contains")
                                    {
                                        comboBoxOperator.SelectedItem = item;
                                        break;
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                }
                #endregion"Column type "string"

                #region"Condition"

                // Fill the condition utilized in this filter. Example: LIKE '*Frutas*'.
                // In this case "Fructis" is the condition.
                if (condition.Contains('*'))
                    comboBoxCondition.Text = condition.Trim(new char[] { '*' });
                else
                    comboBoxCondition.Text = condition.Trim();

                #endregion"Condition"

                #region"Second Condition"

                comboBoxSecondCondition.SelectedItem = "None";

                _upDateProcess = true;

                foreach (string item in comboBoxSecondCondition.Items)
                {
                    if (stringFilter.Contains(" " + item))
                    {
                        comboBoxSecondCondition.SelectedItem = item;
                        break;
                    }
                }

                #endregion"Second Condition"

            }
            catch (Exception error)
            {
                string message = error.Message;
                MessageBox.Show(@"A problem was found in the filter. This is an error. " +
                                 "Every filter must specify the column name + operation + condition .",
                               @"Incorrect filter syntax.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillComboBoxItems(ComboBox comboBoxTo, string columnType)
        {
            if (comboBoxTo == null)
                return;

            comboBoxTo.Items.Clear();

            switch (columnType)
            {
                case "String":
                    {
                        var items = new[]
                        {
                            "Contains",
                            "Equals",
                            "Begin With",
                            "Ends With",
                            "Does Not Contains",
                            "Does Not Equals",
                            "Does Not Begin With",
                            "Does Not End With"
                        };
                        comboBoxTo.Items.AddRange(items);
                        comboBoxTo.Enabled = true;
                        break;
                    }
                case "Int32":
                    {
                        var items = new[]
                        {
                            "Equals to",
                            "Does Not Equals",
                            "Less Than",
                            "Greater Than",
                            "Less Than or Equal to",
                            "Greater Than or Equal to",
                            "Between"
                        };
                        comboBoxTo.Items.AddRange(items);
                        comboBoxTo.Enabled = true;
                        break;
                    }
                case "Bool":
                    {
                        comboBoxTo.Enabled = false;
                        break;
                    }
                case "Int64":
                    {
                        comboBoxTo.Enabled = false;
                        break;
                    }
            }
        }

        public class ComboEnumItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public ComboEnumItem(Enum originalEnum)
            {
                this.Value = originalEnum;
                this.Text = this.ToString();
            }
        }

        void ComboBoxColumnNameSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_upDateProcess)
                return;

            if (string.IsNullOrWhiteSpace(comboBoxColumnName.Text) || comboBoxColumnName.Text == null)
                return;

            var columnSelected = ColumnsCollections[comboBoxColumnName.Text];
            if (columnSelected == null)
                return;

            FillComboBoxItems(comboBoxOperator, columnSelected.DataType.Name);
            comboBoxSecondCondition.Enabled = true;
            comboBoxOperator.Focus();

            On_ColumnNameSelected(new ColumnNameSelected_EventArgs(comboBoxColumnName.Text, 2, LocationX, LocationY, ControlText));
        }

        void ComboBoxColumnNameTextChanged(object sender, EventArgs e)
        {
            SendStatusBarMessage("ComboBoxColumnNameTextChanged");

            if (comboBoxColumnName.Text == @" " || comboBoxColumnName.Text == "")
                return;

            comboBoxOperator.Enabled = true;
            comboBoxOperator.SelectionLength = 0;

            if (_upDateProcess)
                return;

            On_StringFilter(new StringFilterControl_EventArgs(ColumnNameProperty, comboBoxColumnName.Text,
                            comboBoxOperator.Text, comboBoxCondition.Text, ControlText));

            On_Need_SaveData(new Need_SaveData_EventArgs("Filter Condition.", true));
        }

        void ComboBoxColumnName_MouseDown(object sender, MouseEventArgs e)
        {
            _upDateProcess = false;
        }

        void ComboBoxOperatorSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCondition.Focus();
        }

        void ComboBoxOperatorTextChanged(object sender, EventArgs e)
        {
            SendStatusBarMessage("ComboBoxOperatorTextChanged");

            if (comboBoxOperator.Text == "")
                return;

            comboBoxOperator.SelectionLength = 0;
            comboBoxCondition.Enabled = true;

            if (_upDateProcess)
                return;

            On_StringFilter(new StringFilterControl_EventArgs(ColumnNameProperty, comboBoxColumnName.Text,
                                                comboBoxOperator.Text, comboBoxCondition.Text, ControlText));

            On_Need_SaveData(new Need_SaveData_EventArgs("Filter Condition.", true));
        }

        void comboBoxOperator_MouseDown(object sender, MouseEventArgs e)
        {
            _upDateProcess = false;
        }

        void ComboBoxConditionTextChanged(object sender, EventArgs e)
        {
            SendStatusBarMessage("ComboBoxConditionTextChanged");

            if (_upDateProcess)
            {
                comboBoxSecondCondition.Enabled = true;
                return;
            }

            if (_selectedColumnType.Contains("Int32"))
            {
                try
                {
                    if (string.IsNullOrEmpty(comboBoxCondition.Text.Trim()))
                        return;

                    int possibleNum = int.Parse(comboBoxCondition.Text);
                    On_StringFilter(new StringFilterControl_EventArgs(ColumnNameProperty, comboBoxColumnName.Text,
                                                    comboBoxOperator.Text, comboBoxCondition.Text, ControlText));

                }
                catch (Exception error)
                {
                    MessageBox.Show(@"The type of select column " + comboBoxColumnName.Text +
                            @" is Numeric, it only accept Numeric Digit ( 0,1,2,3,4,5,6,7,8,9 )",
                            @"Improper numeric information input.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    return;
                }
            }

            comboBoxSecondCondition.Enabled = true;

            On_StringFilter(new StringFilterControl_EventArgs(ColumnNameProperty, comboBoxColumnName.Text,
                                                comboBoxOperator.Text, comboBoxCondition.Text, ControlText));

            On_Need_SaveData(new Need_SaveData_EventArgs("Filter Condition.", true));
        }

        void comboBoxCondition_MouseDown(object sender, MouseEventArgs e)
        {
            _upDateProcess = false;
        }

        // ToDo: Check the Return linea.
        void ComboBoxSecondConditionTextChanged(object sender, EventArgs e)
        {
            SendStatusBarMessage("ComboBoxSecondConditionTextChanged");

            if (_upDateProcess)
            {
                _upDateProcess = false;

                return;

                On_StringFilter(new StringFilterControl_EventArgs(ColumnNameProperty, comboBoxColumnName.Text,
                                                    comboBoxOperator.Text, comboBoxCondition.Text, ControlText));
                return;
            }

            if (comboBoxSecondCondition.Text.Contains("None"))
            {
                comboBoxSecondCondition.SelectionLength = 0;
                return;
            }

            On_StringFilter(new StringFilterControl_EventArgs(ColumnNameProperty, comboBoxColumnName.Text,
                                                   comboBoxOperator.Text, comboBoxCondition.Text, ControlText));

            On_SecondCondition(new SecondCondition_EventArgs(comboBoxSecondCondition.Text, (int)comboBoxSecondCondition.Tag, LocationX, LocationY, Width, Height));

            On_Need_SaveData(new Need_SaveData_EventArgs("Filter Condition.", true));
        }

        void ComboBoxSecondConditionMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            _upDateProcess = false;
        }

        void ComboBoxDrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox sendBy = (ComboBox)sender;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //On_StatusBarHelp(new StatusBarMessage_EventArgs(sendBy, e, StockRoomColumns));
                On_StatusBarMessage(new StatusBarMessage_EventArgs(sendBy.Text));
            }

            e.DrawBackground();

            string texItems = "";
            if (e.Index != -1)
                texItems = sendBy.Items[e.Index].ToString();

            using (SolidBrush br = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(texItems, e.Font, br, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        public string FilterStringSql
        {
            get
            {
                if (comboBoxOperator.Text == "")
                    return "";

                if (string.IsNullOrWhiteSpace(comboBoxColumnName.Text))
                    return "";

                switch (comboBoxCondition.Text)
                {
                    case "Any Information":
                        {
                            return comboBoxColumnName.Text + " LIKE '*'";
                        }
                    case "Null Value":
                        {
                            return comboBoxColumnName.Text + " IS NULL";
                        }
                    case "Empty String":
                        {
                            return comboBoxColumnName.Text + " LIKE '\"\"'";
                        }
                    default:
                        {
                            break;
                        }
                }

                string? stringFilter = "";
                string? selectedColumnType = "";

                if (comboBoxColumnName.Text != null)
                    selectedColumnType = ColumnsCollections[comboBoxColumnName.Text].DataType.Name;
                else
                    selectedColumnType = "Int64";

                switch (selectedColumnType)
                {
                    case "String":
                        {
                            if (comboBoxSecondCondition.Text != @"None")
                                stringFilter = comboBoxColumnName.Text + MatchString(comboBoxOperator.Text, comboBoxCondition.Text) + " " +
                                                                                                                comboBoxSecondCondition.Text + " ";
                            else
                                stringFilter = comboBoxColumnName.Text + MatchString(comboBoxOperator.Text, comboBoxCondition.Text);
                            break;
                        }
                    case "Int32":
                        {
                            if (comboBoxSecondCondition.Text != @"None")
                                stringFilter = comboBoxColumnName.Text + MatchNum(comboBoxOperator.Text, comboBoxCondition.Text, comboBoxCondition.Text)
                                                                                                           + " " + comboBoxSecondCondition.Text + " ";
                            else
                                stringFilter = comboBoxColumnName.Text + MatchNum(comboBoxOperator.Text, comboBoxCondition.Text, comboBoxCondition.Text);
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

        string MatchString(string operation, string condition)
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
                        mymatch = " >= " + valueMin + " AND " + comboBoxColumnName.Text + " <= " + valueMax;
                        return mymatch;
                    }
                default:
                    {
                        return mymatch;
                    }
            }
        }

    }
}

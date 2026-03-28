using System.ComponentModel;

namespace MyStuff11net
{
    public partial class Find_and_Remplace : Form
    {
        #region"My fields"

        private string _isFilter;


        public bool IsFilter;

        /// <summary>
        /// Define where we will search, can by:
        /// Current Column. --> Name of current Column.
        /// Whole DataBase. --> Search in all DataBase.
        /// </summary>
        private string _lookIn;

        /// <summary>
        /// This field defines a kind of search, can by:
        /// Any Part of Field. --> *Text* ;
        /// Start of Field.    -->  Text* ;
        /// Whole Field.       -->  Text ;
        /// End of Field.      --> *Text ;
        /// </summary>
        private string _match;

        /// <summary>
        /// Contiene the the _match information plus data to filter.
        /// </summary>
        private string _match_filter;

        /// <summary>
        /// Keep tracking of Search data.
        /// </summary>
        private string _search_by;

        /// <summary>
        /// Keep tracking of Replace data.
        /// </summary>
        private string _replace_by;

        /// <summary>
        /// Keep tracking of current Column Index.
        /// </summary>
        private int _currentColumnIndex;

        /// <summary>
        /// Keep tracking of current Row Index.
        /// </summary>
        private int _currentRowIndex;

        /// <summary>
        /// Keep tracking of active Column.
        /// </summary>
        private DataGridViewColumn _currentColumnActive;

        /// <summary>
        /// Keep tracking of active Row.
        /// </summary>
        private DataGridViewRow _currentRowActive;

        private DataGridViewCell _currentCellActive;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ColumnName { get; set; }

        #endregion

        public Find_and_Remplace()
        {
            InitializeComponent();
        }

        /// <summary>
        /// For Filter application, it self determine if Column
        /// is the type String or Num. This constructor changed
        /// the name to Filter and remove Select any color.
        /// </summary>
        /// <param name="currentRowIndex"></param>
        /// <param name="currentRowActive"></param>
        /// <param name="currentColumIndex"></param>
        /// <param name="currentColumnActive"></param>
        /// <param name="currentCellActive"></param>
        /// <param name="filterapplication"></param>
        public Find_and_Remplace(int currentRowIndex, DataGridViewRow currentRowActive, int currentColumIndex,
                                                DataGridViewColumn currentColumnActive, DataGridViewCell currentCellActive, string filterapplication)
        {
            InitializeComponent();

            _currentColumnIndex = currentColumIndex;
            _currentColumnActive = currentColumnActive;
            _currentRowIndex = currentRowIndex;
            _currentRowActive = currentRowActive;
            _currentCellActive = currentCellActive;
            _isFilter = filterapplication;

            ColumnName = currentColumnActive.DataPropertyName;

            #region"String"
            if (_currentColumnActive.ValueType.FullName == "System.String")
            {
                //tabControl.TabPages.Remove(tabPage_double_Find);
               // tabControl.TabPages.Remove(tabPage_double_Replace);
               // tabControl.TabPages.Remove(tabPage_double_Fill);
               // tabControl.TabPages.Remove(tabPage_double_Custom);

                if (_isFilter.Contains("Find"))
                {
                   // tabControl.TabPages.Remove(tabPage_string_Replace);
                   // tabControl.TabPages.Remove(tabPage_string_Fill);

                    Text = "Find in column " + _currentColumnActive.Name + ", string type.";
                }

                if (_isFilter.Contains("Replace"))
                {
                  //  tabControl.TabPages.Remove(tabPage_string_Find);
                  //  tabControl.TabPages.Remove(tabPage_string_Fill);

                    Text = "Replace in column " + _currentColumnActive.Name + ", string type.";
                }

                if (_isFilter.Contains("Fill"))
                {
                  //  tabControl.TabPages.Remove(tabPage_string_Replace);
                  //  tabControl.TabPages.Remove(tabPage_string_Find);

                    Text = "Fill in column " + _currentColumnActive.Name + ", string type.";
                }

             //   tabPage_double_Custom.Text = @"Custom " + _isFilter;


            }
            #endregion"String"

            #region"Int32"
            if (_currentColumnActive.ValueType.FullName == "System.Int32")
            {
              //  tabControl.TabPages.Remove(tabPage_string_Find);
              //  tabControl.TabPages.Remove(tabPage_string_Replace);
              //  tabControl.TabPages.Remove(tabPage_string_Fill);
              //  tabControl.TabPages.Remove(tabPage_string_Custom);

                if (_isFilter.Contains("Find"))
                {
            //        tabControl.TabPages.Remove(tabPage_double_Replace);
            //        tabControl.TabPages.Remove(tabPage_double_Fill);

                    Text = "Find in column " + _currentColumnActive.Name + ", numeric type.";
                }

                if (_isFilter.Contains("Replace"))
                {
             //       tabControl.TabPages.Remove(tabPage_double_Find);
             //       tabControl.TabPages.Remove(tabPage_double_Fill);

                    Text = "Replace in column " + _currentColumnActive.Name + ", numeric type.";
                }

                if (_isFilter.Contains("Fill"))
                {
             //       tabControl.TabPages.Remove(tabPage_double_Find);
             //       tabControl.TabPages.Remove(tabPage_double_Replace);

                    Text = "Fill in column " + _currentColumnActive.Name + ", numeric type.";
                }

            //    tabPage_double_Find.Text = _isFilter;
           //     tabPage_double_Custom.Text = @"Custom " + _isFilter;
            }
            #endregion"Int32"
                        
            if (_currentCellActive == null || _currentCellActive.Value == null)
                return;
            if (_currentRowIndex == -1)
                return;

       //     textBox_Find.Text = textBox_Find_Search_by_Num.Text = textBox_Replace.Text =
       //                         textBox_Replace_Search_by_Num.Text = textBox_Fill.Text =
       //                         textBox_Fill_Num.Text = _currentCellActive.Value.ToString();
        }

        #region"Events, Custom Controls Events with custom Args.*********************"

        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void Find_Remplace_Execute_EventHandler(object sender, Find_Remplace_Execute_EventArgs e);

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class Find_Remplace_Execute_EventArgs : EventArgs
        {
            /// <summary>
            /// When _currentColumnActive.ValueType.FullName == "System.String", call this constructor
            /// Whatever are Find, Replace or Fill.
            /// </summary>
            /// <param name="currentRowIndex"></param>
            /// <param name="currentRowActive"></param>
            /// <param name="currentColumIndex"></param>
            /// <param name="currentColumnActive"></param>
            /// <param name="operationtoDo"></param>
            /// <param name="lookIn"></param>
            /// <param name="color"></param>
            /// <param name="match"></param>
            /// <param name="searchby"></param>
            /// <param name="replaceby"></param>
            public Find_Remplace_Execute_EventArgs(int currentRowIndex, DataGridViewRow currentRowActive, int currentColumIndex,
                DataGridViewColumn currentColumnActive, string operationtoDo, string searchby, Color color, string match, string lookIn, string replaceby)
            {
                CurrentRowIndex = currentRowIndex;
                CurrentRowActive = currentRowActive;
                CurrentColumnIndex = currentColumIndex;
                CurrentColumnActive = currentColumnActive;
                ColumnName = currentColumnActive.DataPropertyName;
                Operationto_do = operationtoDo;
                SelectColor = color;
                Look_in_ = lookIn;

                Searchby = searchby;
                Replaceby = replaceby;

                Match_ = match;
                Filterby = CurrentColumnActive.Name + match;
            }

            /// <summary>
            /// When _currentColumnActive.ValueType.FullName == "System.Double", call this constructor
            /// Whatever are Find, Replace or Fill.
            /// </summary>
            /// <param name="currentRowIndex"></param>
            /// <param name="currentRowActive"></param>
            /// <param name="currentColumIndex"></param>
            /// <param name="currentColumnActive"></param>
            /// <param name="operationtoDo"></param>
            /// <param name="lookIn"></param>
            /// <param name="color"></param>
            /// <param name="match"></param>
            /// <param name="searchby"></param>
            /// <param name="largest"></param>
            /// <param name="replacenum"></param>
            public Find_Remplace_Execute_EventArgs(int currentRowIndex, DataGridViewRow currentRowActive, int currentColumIndex, DataGridViewColumn currentColumnActive,
                string operationtoDo, int searchby, Color color, string match, string match_filter, string lookIn, int largest, int replacenum)
            {
                CurrentRowIndex = currentRowIndex;
                CurrentRowActive = currentRowActive;
                CurrentColumnIndex = currentColumIndex;
                CurrentColumnActive = currentColumnActive;
                ColumnName = currentColumnActive.DataPropertyName;
                Operationto_do = operationtoDo;
                SelectColor = color;
                Look_in_ = lookIn;

                Searchby = searchby.ToString();
                Smallest = searchby;
                Largest = largest;
                ReplaceNum = replacenum;
                Replaceby = replacenum.ToString();

                Match_ = match;
                Filterby = CurrentColumnActive.Name + match_filter;
            }

            public int CurrentRowIndex { get; private set; }
            public DataGridViewRow CurrentRowActive { get; private set; }
            public int CurrentColumnIndex { get; private set; }
            public DataGridViewColumn CurrentColumnActive { get; private set; }



            public Color SelectColor;

            /// <summary>
            /// Operation to Do, can by Find, Replace, Fill and Custom.
            /// </summary>
            public string Operationto_do
            {
                get
                {
                    return _operation;
                }
                set
                {
                    _operation = value;
                    if (value.Contains("Find"))
                        IsFind = true;
                    if (value.Contains("Replace"))
                        IsReplace = true;
                    if (value.Contains("Fill"))
                        IsFill = true;

                }
            }

            /// <summary>
            /// Define where we will search, can by:
            /// Current Column. --> Name of current Column.
            /// Whole DataBase. --> Search in all DataBase.
            /// </summary>
            public string Look_in_
            {
                get
                {
                    return Lookin;
                }
                set
                {
                    Lookin = value;
                    if (value.Contains("Row"))
                        IsRow = true;
                    if (value.Contains("Column"))
                        IsColumn = true;
                    if (value.Contains("DataBase"))
                        IsDataBase = true;

                }
            }

            /// <summary>
            /// This field defines a kind of search, can by:
            /// Any Part of Field. --> *Text* ;
            /// Start of Field.    -->  Text* ;
            /// Whole Field.       -->  Text ;
            /// End of Field.      --> *Text ;
            /// </summary>
            public string Match_
            {
                get
                {
                    return _match;
                }
                set
                {
                    _match = value;
                }
            }

            /// <summary>
            /// Keep tracking of Searched data.
            /// </summary>
            public string Searchby;

            /// <summary>
            /// Keep tracking of Searchby or Smallest Number.
            /// </summary>
            public int Smallest;

            /// <summary>
            /// Keep tracking of Largest Number.
            /// </summary>
            public int Largest;

            /// <summary>
            /// Keep tracking of Replace Number.
            /// </summary>
            public int ReplaceNum;

            /// <summary>
            /// Keep tracking of Replace data.
            /// </summary>
            public string Replaceby;

            /// <summary>
            /// Keep tracking of Filter data.
            /// </summary>
            public string Filterby;

            private string _operation;
            public bool IsFind;
            public bool IsReplace;
            public bool IsFill;

            private string _match;
            private string Lookin;
            public bool IsRow;
            public bool IsColumn;
            public bool IsDataBase;
            public string ColumnName;
        }

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User executed Find & Remplace Dialog.")]
        public event Find_Remplace_Execute_EventHandler Find_Remplace_Execute;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Find_Remplace_Execute(Find_Remplace_Execute_EventArgs e)
        {
            // If an event has no subscriber registerd, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            // Notify Subscribers
            Find_Remplace_Execute?.Invoke(this, e);
        }


        #endregion "Events, Custom Controls Events with custom Args.*********************"


        #region"String Search"

        private void Button_find_execute_click(object sender, EventArgs e)
        {
            _match = Match_string(comboBox_Find_Match, textBox_Find);

            _lookIn = Look_in(comboBox_Find_Look_In);

            _search_by = textBox_Find.Text;

            _replace_by = "";

            On_Find_Remplace_Execute(new Find_Remplace_Execute_EventArgs(_currentRowIndex, _currentRowActive,
                 _currentColumnIndex, _currentColumnActive, "Find", _search_by, grouper_Select_any_Color.BackgroundColor, _match, _lookIn, _replace_by));
            Close_my();
        }

        private void Button_replace_execute_click(object sender, EventArgs e)
        {
            _match = Match_string(comboBox_Replace_Macth, textBox_Replace);

            _lookIn = Look_in(comboBox_Replace_Look_In);

            _search_by = textBox_Replace.Text;

            _replace_by = textBox_Replace_Replace.Text;

            On_Find_Remplace_Execute(new Find_Remplace_Execute_EventArgs(_currentRowIndex, _currentRowActive,
                                    _currentColumnIndex, _currentColumnActive, "Replace", _search_by,
                                    grouper_Select_any_Color.BackgroundColor, _match, _lookIn, _replace_by));

            Close_my();
        }

        private void Button_fill_execute_click(object sender, EventArgs e)
        {
            _match = "";

            _lookIn = Look_in(comboBox_Fill_Look_In);

            _search_by = "";

            _replace_by = textBox_Fill.Text;

            On_Find_Remplace_Execute(new Find_Remplace_Execute_EventArgs(_currentRowIndex, _currentRowActive,
                 _currentColumnIndex, _currentColumnActive, "Fill", _search_by, grouper_Select_any_Color.BackgroundColor, _match, _lookIn, _replace_by));
            Close_my();
        }


        private void Button_find_cancel_click(object sender, EventArgs e)
        {
            Close_my();
        }

        private void Button_replace_cancel_click(object sender, EventArgs e)
        {
            Close_my();
        }

        private void Button_fill_cancel_click(object sender, EventArgs e)
        {
            Close_my();
        }


        public static string Match_string(ComboBox value, TextBox valueTextBox)
        {
            var mymatch = "";
            var checkMatch = value;
            var searchText = MyCode.EscapeLikeValue(valueTextBox.Text);

            if (searchText == "")
            {
                mymatch = " IS NULL";
                return mymatch;
            }

            switch (checkMatch.Text)
            {
                case "Equals...":
                    {
                        mymatch = " LIKE '" + searchText + "'";
                        return mymatch;
                    }
                case "Does Not Equals...":
                    {
                        mymatch = " NOT LIKE '" + searchText + "'";
                        return mymatch;
                    }
                case "Begin With...":
                    {
                        mymatch = " LIKE '" + searchText + "*'";
                        return mymatch;
                    }
                case "Does Not Begin With...":
                    {
                        mymatch = " NOT LIKE '" + searchText + "*'";
                        return mymatch;
                    }
                case "Contains...":
                    {
                        mymatch = " LIKE '*" + searchText + "*'";
                        return mymatch;
                    }
                case "Does Not Contains...":
                    {
                        mymatch = " NOT LIKE '*" + searchText + "*'";
                        return mymatch;
                    }
                case "Ends With...":
                    {
                        mymatch = " LIKE '*" + searchText + "'";
                        return mymatch;
                    }
                case "Does Not End With...":
                    {
                        mymatch = " NOT LIKE '*" + searchText + "'";
                        return mymatch;
                    }
                default:
                    {
                        return mymatch;
                    }
            }
        }

        private void Text_box_replace_replace_text_changed(object sender, EventArgs e)
        {
            _replace_by = textBox_Replace_Replace.Text;
        }

        private void Combo_box_string_find_selection_change_committed(object sender, EventArgs e)
        {
            object lastItem = comboBox_Find_Match.Text;

            comboBox_Find_Match.Items.Add(lastItem);
        }

        private void Combo_box_string_find_text_update(object sender, EventArgs e)
        {
            comboBox_Find_Match.Items.Remove(comboBox_Find_Match.Text);
        }

        private void Grouper_select_any_color_click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog { })
            {
                if (colorDialog.ShowDialog(this) == DialogResult.Cancel)
                    return;

                grouper_Select_any_Color.BackgroundColor = colorDialog.Color;
            }
        }

        #endregion//String Search

        #region"Numeric Search"

        private void Button_find_execute_num_click(object sender, EventArgs e)
        {
      //      _match = Match_value(comboBox_Replace_Match_Num, textBox_Replace_Search_by_Num);
      //      _match_filter = Match_num(comboBox_Find_Match_Num, textBox_Find_Search_by_Num, textBox_Find_Largest_Num);

      //      _lookIn = Look_in(comboBox_Find_Look_In_Num);

            var searchNum = 0;
      //      if (textBox_Find_Search_by_Num.Text != "")
      //          searchNum = Convert.ToInt32(textBox_Find_Search_by_Num.Text);

            var largestNum = 0;
     //       if (textBox_Find_Largest_Num.Enabled & textBox_Find_Largest_Num.Text != "")
     //           largestNum = Convert.ToInt32(textBox_Find_Largest_Num.Text);

            const int replaceNum = 0;

     //       On_Find_Remplace_Execute(new Find_Remplace_Execute_EventArgs(_currentRowIndex, _currentRowActive,
      //              _currentColumnIndex, _currentColumnActive, "Find", searchNum, grouper_select_any_color_num.BackgroundColor,
     //               _match, _match_filter, _lookIn, largestNum, replaceNum));

            Close_my();
        }

        private void Button_replace_execute_num_click(object sender, EventArgs e)
        {
      //      _match = Match_value(comboBox_Replace_Match_Num, textBox_Replace_Search_by_Num);
      //      _match_filter = Match_num(comboBox_Replace_Match_Num, textBox_Replace_Search_by_Num, textBox_Replace_Largest_Num);

     //       _lookIn = Look_in(comboBox_Replace_Look_In_Num);

            var searchNum = 0;
     //       if (textBox_Replace_Search_by_Num.Text != "")
     //           searchNum = Convert.ToInt32(textBox_Replace_Search_by_Num.Text);

            var largestNum = 0;
     //       if (textBox_Replace_Largest_Num.Enabled & textBox_Replace_Largest_Num.Text != "")
     //           largestNum = Convert.ToInt32(textBox_Replace_Largest_Num.Text);

            var replaceNum = 0;
     //       if (textBox_Replace_Replace_by_Num.Text != "")
     //           replaceNum = Convert.ToInt32(textBox_Replace_Replace_by_Num.Text);

      //      On_Find_Remplace_Execute(new Find_Remplace_Execute_EventArgs(_currentRowIndex, _currentRowActive,
     //                            _currentColumnIndex, _currentColumnActive, "Replace", searchNum, grouper_select_any_color_num.BackgroundColor,
      //              _match, _match_filter, _lookIn, largestNum, replaceNum));
            Close_my();
        }

        private void Button_fill_execute_num_click(object sender, EventArgs e)
        {
     //       _match = Match_value(comboBox_Replace_Match_Num, textBox_Replace_Search_by_Num);
            _match_filter = "";

     //       _lookIn = Look_in(comboBox_Fill_Look_In_Num);

            var searchNum = 0;

            var largestNum = 0;

            var fillNum = 0;
      //      if (textBox_Fill_Num.Text != "")
      //          fillNum = Convert.ToInt32(textBox_Fill_Num.Text);

     //       On_Find_Remplace_Execute(new Find_Remplace_Execute_EventArgs(_currentRowIndex, _currentRowActive,
     //                           _currentColumnIndex, _currentColumnActive, "Fill", searchNum, grouper_select_any_color_num.BackgroundColor,
     //                           _match, _match_filter, _lookIn, largestNum, fillNum));
            Close_my();
        }

        private void Button_find_cancel_num_click(object sender, EventArgs e)
        {
            Close_my();
        }

        private void Button_replace_cancel_num_click(object sender, EventArgs e)
        {
            Close_my();
        }

        private void Button_fill_cancel_num_click(object sender, EventArgs e)
        {
            Close_my();
        }

        private string Match_value(ComboBox value, TextBox valueTextBox)
        {
            var mymatch = "";
            var checkMatch = value;
            var searchText = valueTextBox.Text;

            if (searchText == "")
            {
                mymatch = " IS NULL";
                return mymatch;
            }

            switch (checkMatch.Text)
            {
                case "Equals...":
                    {
                        mymatch = " = ";
                        return mymatch;
                    }
                case "Does Not Equals...":
                    {
                        mymatch = " <> ";
                        return mymatch;
                    }
                case "Less Than...":
                    {
                        mymatch = " < ";
                        return mymatch;
                    }
                case "Greater Than...":
                    {
                        mymatch = " > ";
                        return mymatch;
                    }
                case "Between...":
                    {
                        mymatch = " >= AND <= ";
                        return mymatch;
                    }
                default:
                    {
                        return mymatch;
                    }
            }
        }

        public string Match_num(ComboBox value, TextBox valueTextBox, TextBox largest)
        {
            var mymatch = "";
            var checkMatch = value;
            var searchText = valueTextBox.Text;
            var checkLarg = largest;

            if (searchText == "")
            {
                mymatch = " IS NULL";
                return mymatch;
            }

            switch (checkMatch.Text)
            {
                case "Equals...":
                    {
                        mymatch = " = " + searchText;
                        return mymatch;
                    }
                case "Does Not Equals...":
                    {
                        mymatch = " <> " + searchText;
                        return mymatch;
                    }
                case "Less Than...":
                    {
                        mymatch = " < " + searchText;
                        return mymatch;
                    }
                case "Greater Than...":
                    {
                        mymatch = " > " + searchText;
                        return mymatch;
                    }
                case "Between...":
                    {
                        mymatch = " >= " + searchText + " AND " + _currentColumnActive.Name + " <= " + checkLarg.Text;
                        return mymatch;
                    }
                default:
                    {
                        return mymatch;
                    }
            }
        }

        private void Combo_box_find_match_num_selected_index_changed(object sender, EventArgs e)
        {
     //       Match_num_index_changed(comboBox_Find_Match_Num, label_Find_Smallest_Num);
        }

        private void Combo_box_replace_match_num_selected_index_changed(object sender, EventArgs e)
        {
     //       Match_num_index_changed(comboBox_Replace_Match_Num, label_Replace_Smallest);
        }

        private void Match_num_index_changed(ComboBox value, Label valueLabel)
        {
            var checkMatch = value;
            var labelText = valueLabel;

            switch (checkMatch.Text)
            {
                case "Equals...":
                    {
                        labelText.Text = @"Equals to :";

      //                  label_Find_Largest_Num.Enabled = false;
      //                  textBox_Find_Largest_Num.Enabled = false;
                        break;
                    }
                case "Does Not Equals...":
                    {
                        labelText.Text = @"Does Not Equals to:";

      //                  label_Find_Largest_Num.Enabled = false;
      //                  textBox_Find_Largest_Num.Enabled = false;
                        break;
                    }
                case "Less Than...":
                    {
                        labelText.Text = @"Less Than:";

         //               label_Find_Largest_Num.Enabled = false;
         //               textBox_Find_Largest_Num.Enabled = false;
                        break;
                    }
                case "Greater Than...":
                    {
                        labelText.Text = @"Greater Than:";

           //             label_Find_Largest_Num.Enabled = false;
           //             textBox_Find_Largest_Num.Enabled = false;
                        break;
                    }
                case "Between...":
                    {
                        labelText.Text = @"Smallest:";

          //              label_Find_Largest_Num.Enabled = true;
         //               textBox_Find_Largest_Num.Enabled = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void Grouper_select_any_color_num_click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog
            {

            }
                  )
            {
                if (colorDialog.ShowDialog(this) == DialogResult.Cancel)
                    return;

        //        grouper_select_any_color_num.BackgroundColor = colorDialog.Color;
            }
        }

        #endregion//Numeric Search

        void Close_my()
        {
            //  var ff = (PopupControl.Popup)Parent;
            //  ff.Close();
            Close();
        }

        static string Look_in(ComboBox value)
        {
            var myLookIn = "";
            var checkLookIn = value;

            if (checkLookIn.Text.Contains("Current Column."))
                myLookIn = "Column";

            if (checkLookIn.Text.Contains("Whole DataBase."))
                myLookIn = "DataBase";

            return myLookIn;
        }

    }
}
using MyStuff11net.DataGridViewExtend;
using System.Data;
using System.Diagnostics;

namespace MyStuff11net
{
    /// <summary>
    /// This class is used to determine the status of each row in a DataGridView rows collection,
    /// also to alter the status of a selected item.
    /// </summary>
    public class CurrentStatus
    {
        /// <summary>
        /// 30	␞	INFORMATION SEPARATOR, record separator, End of a record or row.
        /// </summary>
        public static readonly char SeparatorRecordEndOfRecord = '␞';

        /// <summary>
        /// 31	␟	INFORMATION SEPARATOR, unit separator, Between fields of a record, or members of a row.
        /// </summary>
        public static readonly char SeparatorBetweenFieldsOfRecord = '␟';

        /// <summary>
        /// Default value in column Status for any row
        /// ( Locked␟True␞Selected␟False␞Unerasable␟True␞Color␟-36865␞Note␟Null␞HeaderInf␟Null␞DisplayStatus␟Ite,Med,4,4␞ )
        /// </summary>
        public static readonly string StatusDefaultValue = "Locked␟True␞Selected␟False␞Unerasable␟True␞Color␟-36865␞Note␟Null␞HeaderInf␟Null␞DisplayStatus␟Ite,Med,4,4␞";

        /// <summary>
        /// Default value in column Status for new rows
        /// ( Locked␟False␞Selected␟False␞Unerasable␟False␞Color␟0␞Note␟Null␞HeaderInf␟Null␞DisplayStatus␟Ite,Med,4,4␞ )
        /// </summary>
        public static readonly string StatusDefaultValueNewRow = "Locked␟False␞Selected␟False␞Unerasable␟False␞Color␟0␞Note␟Null␞HeaderInf␟Null␞DisplayStatus␟Ite,Med,4,4␞";

        /// <summary>
        /// Define status properties to default values, used to set parameters
        /// in new rows and as reference to constant values.
        /// </summary>
        public CurrentStatus()
        {
            BOMInformationObj = new BOMInformation("{BOM}:0;");
            HeaderInformationObj = new HeaderInformation("HeaderInf:Null");
            ErrorSelectedColor = (Color)oConverter.ConvertFromString("-36865");

            SetProperties(StatusDefaultValue);
        }
        public CurrentStatus(DataRowView row)
        {
            try
            {
                _rowDataRow = row.Row;
                InitializeStatus();
            }
            catch (Exception error)
            {
                ColStatusIndex = -1;
                ColPartNumberIndex = -1;
                SetProperties(StatusDefaultValue);
                using (var form = new Form { TopMost = true })
                {
                    System.Windows.Forms.MessageBox.Show(form, @"Message related to this error is " + error.Message,
                    @"CurrentStatus, DataRow CurrentStatus fail.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public CurrentStatus(DataGridViewRow currentDataGridViewRow)
        {
            try
            {
                // It's a Grouping source, have not status column......
                if (currentDataGridViewRow.Index == -1 || currentDataGridViewRow.DataBoundItem.GetType() == typeof(BindingSourceGroups.GroupRow))
                {
                    SetProperties(StatusDefaultValue);
                    return;
                }

                _currentDataGridViewRow = currentDataGridViewRow;
                _currentDataRowView = ((DataRowView)(currentDataGridViewRow.DataBoundItem));

                if (_currentDataRowView == null)
                    return;

                _rowDataRow = _currentDataRowView.Row;
                InitializeStatus();
            }
            catch (Exception)
            {
                ColStatusIndex = -1;
                SetProperties(StatusDefaultValue);
                /*     System.Windows.Forms.MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message +
                                                 @", Break code at position ",
                                                 @"CurrentStatus, CurrentStatus fail in CurrentStatus(DataGridViewRow currentRow) constructor",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                 */
            }
        }

        void InitializeStatus()
        {
            StateInformationObj = new StateInformation("");
            BOMInformationObj = new BOMInformation("");
            HeaderInformationObj = new HeaderInformation("HeaderInf:Null");
            ErrorSelectedColor = (Color)oConverter.ConvertFromString("-36865");

            #region"PartNumberColumn"
            if (_rowDataRow.Table.Columns.Contains(@"PartNumber"))
            {
                ColPartNumberIndex = _rowDataRow.Table.Columns[@"PartNumber"].Ordinal;
                PartNumber = _rowDataRow.ItemArray[ColPartNumberIndex].ToString();

                IsBOM = MyCode.IsPartNumberBOM(PartNumber);
            }
            #endregion"PartNumberColumn"

            #region"PropertyColumn"
            if (_rowDataRow.Table.Columns.Contains("Properties"))
            {
                ColPropertiesIndex = _rowDataRow.Table.Columns["Properties"].Ordinal;
                propertyValue = _rowDataRow.ItemArray[ColPropertiesIndex].ToString();

                // If Property column exist but it's empty....
                if (string.IsNullOrEmpty(propertyValue) || string.IsNullOrWhiteSpace(propertyValue))
                    propertyValue = StateInformation.DefaultStateValue;

                var propertyItems = propertyValue.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string propertyItem in propertyItems)
                {
                    if (propertyItem.Contains("{BOM}:"))
                    {
                        BOMInformationObj = new BOMInformation(propertyItem);
                        continue;
                    }
                    if (propertyItem.Contains("{State}:"))
                    {
                        StateInformationObj = new StateInformation(propertyItem);
                        continue;
                    }
                    if (propertyItem.Contains("Date:"))
                    {
                        // AvalaibleDepartments
                        //Note: If come in, a mistake have ben found
                        //"{BOM}:0;{State}:None|Date:4/4/2017|ColumnModif:Property,Description"
                        //if it's BOM, this failure,
                        //if it's State, this failure also...
                        //The Data is corrupted...
                        //Initialized to default...
                        if (propertyItem.Contains("BOM"))
                        {
                            StateInformationObj.State = MyCode.StateItemsData.None;
                            BOMInformationObj = new BOMInformation(BOMInformationObj.DefaultBOMInformation);
                            UpDateProperties();
                        }
                        if (propertyItem.Contains("State"))
                        {
                            StateInformationObj.State = MyCode.StateItemsData.None;
                            UpDateProperties();
                        }
                        continue;
                    }
                    if (IsBOM)
                    {
                        StateInformationObj.State = MyCode.StateItemsData.UpDate;
                        BOMInformationObj = new BOMInformation(BOMInformationObj.DefaultBOMInformation);

                        UpDateProperties();
                        break;
                    }
                }
            }

            #endregion"PropertyColumn"

            #region"StatusColumn"
            if (_rowDataRow.Table.Columns.Contains("Status"))
            {
                ColStatusIndex = _rowDataRow.Table.Columns["Status"].Ordinal;
                statusValue = _rowDataRow.ItemArray[ColStatusIndex].ToString();

                // If Status column exist but it's empty....
                if (string.IsNullOrEmpty(statusValue) || string.IsNullOrWhiteSpace(statusValue))
                {
                    if (_currentDataRowView != null && _currentDataRowView.IsNew)
                        SetProperties(StatusDefaultValueNewRow);
                    else
                        SetProperties(StatusDefaultValue);

                    UpDateStatus();
                }
                else
                    SetProperties(statusValue);
            }
            else
            {
                ColStatusIndex = -1;
                ColPartNumberIndex = -1;
                SetProperties(StatusDefaultValue);
            }
            #endregion"StatusColumn"

            #region"CountPDFColumn"
            if (_rowDataRow.Table.Columns.Contains("CountPDF"))
            {
                ColCountPDFIndex = _rowDataRow.Table.Columns["CountPDF"].Ordinal;
                HeaderInformationObj.CountPDF = MyCode.CastAsInt(_rowDataRow.ItemArray[ColCountPDFIndex]);
            }
            else
                HeaderInformationObj.CountPDF = 0;
            #endregion"CountPDFColumn"
            #region"CountDocColumn"
            if (_rowDataRow.Table.Columns.Contains("CountDoc"))
            {
                ColCountDocIndex = _rowDataRow.Table.Columns["CountDoc"].Ordinal;
                HeaderInformationObj.CountDoc = MyCode.CastAsInt(_rowDataRow.ItemArray[ColCountDocIndex]);
            }
            else
                HeaderInformationObj.CountDoc = 0;
            #endregion"CountDocColumn"
            #region"CountTxTColumn"
            if (_rowDataRow.Table.Columns.Contains("CountTxT"))
            {
                var ColCountTxTIndex = _rowDataRow.Table.Columns["CountTxT"].Ordinal;
                HeaderInformationObj.CountTxT = MyCode.CastAsInt(_rowDataRow.ItemArray[ColCountTxTIndex]);
            }
            else
                HeaderInformationObj.CountTxT = 0;
            #endregion"CountTxTColumn"
            #region"CountDocxColumn"
            if (_rowDataRow.Table.Columns.Contains("CountDocx"))
            {
                ColCountDocxIndex = _rowDataRow.Table.Columns["CountDocx"].Ordinal;
                HeaderInformationObj.CountDocx = MyCode.CastAsInt(_rowDataRow.ItemArray[ColCountDocxIndex]);
            }
            else
                HeaderInformationObj.CountDocx = 0;
            #endregion"CountDocxColumn"
        }


        string statusValue;
        string propertyValue;
        DataRow _rowDataRow;
        int ColStatusIndex = -1;
        int ColPropertiesIndex = -1;
        int ColPartNumberIndex = -1;

        int ColCountPDFIndex = -1;
        int ColCountDocIndex = -1;
        int ColCountTxTIndex = -1;
        int ColCountDocxIndex = -1;

        DataRowView _currentDataRowView;
        DataGridViewRow _currentDataGridViewRow;
        ColorConverter oConverter = new ColorConverter();

        public string PartNumber { get; set; }
        public bool Locked { get; set; }
        public bool Unerasable { get; set; }
        public bool Selected { get; set; }

        public int BOMItemsCount
        {
            get
            {
                return BOMInformationObj.CountItems;
            }
            set { }
        }
        public bool IsMarkWithNote
        {
            get
            {
                if (Note.Length == 4 && Note.Contains("Null"))
                    return false;

                return true;
            }
            set { }
        }
        public bool IsMarkToDelete
        {
            get
            {
                if (Selected && !Unerasable)
                    return true;

                return false;
            }
            set { }
        }
        public void MarkToDelete(bool markToDelete)
        {
            Selected = markToDelete;
            Unerasable = !markToDelete;
        }

        /// <summary>
        /// If the row have any information to be show in the header row
        /// return true.
        /// </summary>
        public bool ExistIconInf
        {
            get
            {
                return HeaderInformationObj.ExistIconInf;
            }
            set
            {

            }
        }

        public HeaderInformation HeaderInformationObj { get; set; }
        public BOMInformation BOMInformationObj { get; set; }
        public StateInformation StateInformationObj { get; set; }

        public Image ImageHeaderInformation
        {
            get
            {
                return Properties.Resources.Document_PDF;
            }
        }


        public Color ErrorSelectedColor;

        Color selectedColor;
        /// <summary>
        /// By default return Color.FromArgb(Convert.ToInt32(-36865)) if
        /// SelectedNoteColor == Color.Black, if not return SelectedNoteColor;
        /// Only set SelectedColor if HasNote = false ( Note:NULL );
        /// </summary>
        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                selectedColor = value;
            }
        }

        /// <summary>
        /// Color value used to draw the row with Note, but if Note == NULL ( Note:NULL )
        /// and SelectedNoteColor != Color.Black, is used as SelectedColor.
        /// </summary>
        public Color SelectedNoteColor { get; set; } = Color.Black;

        string _note;
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _note = "Null";
                else
                    _note = value;
            }
        }
        public bool HasNote
        {
            get
            {
                if (Note.Contains("Null"))
                    return false;

                return true;
            }

            set { }
        }

        /// <summary>
        /// IsBOM is true if the PartNumber is defined into the list of accepted BOM name.
        /// </summary>
        public bool IsBOM { get; private set; }

        /// <summary>
        /// Set Selected properties to True and updates the status column;
        /// By default set Color.FromArgb(Convert.ToInt32(-36865)), Pink color.
        /// does not save the database, the user is responsible for this action.
        /// </summary>
        public void Select()
        {
            Selected = true;
            UpDateStatus();
        }

        /// <summary>
        /// Set Selected properties to True and updates the status column;
        /// Set SelectColor to it value.
        /// does not save the database, the user is responsible for this action.
        /// </summary>
        /// <param name="selectColor">todo: describe selectColor parameter on Select</param>
        public void Select(Color selectColor)
        {
            Selected = true;
            SelectedColor = selectColor;
            UpDateStatus();
        }

        /// <summary>
        /// Set Selected properties to False and updates the status column;
        /// does not save the database, the user is responsible for this action.
        /// </summary>
        public void UnSelect()
        {
            Selected = false;
            SelectedColor = (Color)oConverter.ConvertFromString("0");
            UpDateStatus();
        }

        /// <summary>
        /// Returns a string containing status information.
        /// </summary>
        /// <returns></returns>
        public string CurrentStatusToString()
        {
            var builder = new System.Text.StringBuilder();
            try
            {
                //       ␟ SeparatorBetweenFieldsOfRecord                 ␞ SeparatorRecordEndOfRecord
                //"Locked␟true␞Selected␟false␞Unerasable␟true␞Color␟-36865␞Note␟Null␞HeaderInf␟Null␞"
                //   0            2               4             6            8           10

                builder.Append("Locked" + SeparatorBetweenFieldsOfRecord);
                builder.Append(Locked.ToString());
                builder.Append(SeparatorRecordEndOfRecord);

                builder.Append("Selected" + SeparatorBetweenFieldsOfRecord);
                builder.Append(Selected.ToString());
                builder.Append(SeparatorRecordEndOfRecord);

                builder.Append("Unerasable" + SeparatorBetweenFieldsOfRecord);
                builder.Append(Unerasable.ToString());
                builder.Append(SeparatorRecordEndOfRecord);

                builder.Append("Color" + SeparatorBetweenFieldsOfRecord);
                builder.Append(SelectedNoteColor.ToArgb());
                builder.Append(SeparatorRecordEndOfRecord);

                builder.Append("Note" + SeparatorBetweenFieldsOfRecord);
                builder.Append(Note);
                builder.Append(SeparatorRecordEndOfRecord);

                builder.Append(HeaderInformationObj.ToString());
                builder.Append(SeparatorRecordEndOfRecord);

                return builder.ToString();
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    System.Windows.Forms.MessageBox.Show(form, @"Message related to this error is " + error.Message,
                    @"CurrentStatus, ToString() fail.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Serialize all the properties and updates the status column;
        /// does not save the database, the user is responsible for this action.
        /// </summary>
        public void UpDateStatus()
        {
            try
            {
                if (ColStatusIndex == -1)
                    return;

                if (ColCountPDFIndex != -1)
                    _rowDataRow.SetField(ColCountPDFIndex, HeaderInformationObj.CountPDF);

                if (ColCountDocIndex != -1)
                    _rowDataRow.SetField(ColCountDocIndex, HeaderInformationObj.CountDoc);

                if (ColCountTxTIndex != -1)
                    _rowDataRow.SetField(ColCountTxTIndex, HeaderInformationObj.CountTxT);

                if (ColCountDocxIndex != -1)
                    _rowDataRow.SetField(ColCountDocxIndex, HeaderInformationObj.CountDocx);

                _rowDataRow.SetField(ColStatusIndex, CurrentStatusToString());

                StateInformationObj.State = MyCode.StateItemsData.UpDate;
                UpDateProperties();
            }
            catch (Exception error)
            {
                // get call stack
                var stackTrace = new StackTrace();

                // get calling method name
                //Console.WriteLine(stackTrace.GetFrame(1).GetMethod().Name);

                using (var form = new Form { TopMost = true })
                {
                    System.Windows.Forms.MessageBox.Show(form, @"Message related to this error is " + error.Message,
                    @"CurrentStatus, UpDateStatus fail at" + PartNumber + "." +
                    " Calling method : " + stackTrace.GetFrame(1).GetMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpDateProperties()
        {
            if (ColPropertiesIndex == -1)
                return;

            string propertiesValue = StateInformationObj.ToString();

            if (IsBOM)
                propertiesValue = BOMInformationObj.ToString() + StateInformationObj.ToString();

            _rowDataRow.SetField(ColPropertiesIndex, propertiesValue);

            _rowDataRow.EndEdit();
        }

        /// <summary>
        /// Removes any note there and set color to white,
        /// call update to propagate changes.
        /// </summary>
        public void RemoveNote()
        {
            Note = "Null";
            SelectedNoteColor = Color.White;
            UpDateStatus();
        }

        void SetProperties(string nameValueProperties)
        {
            var oConverter = new ColorConverter();
            string[] _strings;

            if (nameValueProperties.Contains("" + SeparatorBetweenFieldsOfRecord))
            {
                _strings = nameValueProperties.Split(new char[] { SeparatorBetweenFieldsOfRecord, SeparatorRecordEndOfRecord }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                if (nameValueProperties.Contains("Locked:True;") || nameValueProperties.Contains("Locked:False;"))
                    _strings = nameValueProperties.Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                else
                    _strings = nameValueProperties.Split(new char[] { ':', '|' }, StringSplitOptions.RemoveEmptyEntries);
            }


            //"Locked:true;Selected:false;Unerasable:true;Color:-36865;Note:Null;HeaderInf:Null;DisplayStatus:false,false,0"
            //   0      1     2       3        4       5     6     7     8    9      10     11       12            13
            if (_strings.Length >= 2 && _strings[0].Contains(nameof(Locked)))
                Locked = Convert.ToBoolean(_strings[1]);
            else
                SetPropertiesErrorCatch();

            if (_strings.Length >= 4 && _strings[2].Contains(nameof(Selected)))
                Selected = Convert.ToBoolean(_strings[3]);
            else
                SetPropertiesErrorCatch();

            if (_strings.Length >= 6 && _strings[4].Contains(nameof(Unerasable)))
                Unerasable = Convert.ToBoolean(_strings[5]);
            else
                SetPropertiesErrorCatch();

            if (_strings.Length >= 8 && _strings[6].Contains("Color"))
                SelectedNoteColor = (Color)oConverter.ConvertFromString(_strings[7]);
            else
                SetPropertiesErrorCatch();

            if (_strings.Length >= 10 && _strings[8].Contains(nameof(Note)))
                Note = _strings[9];
            else
                SetPropertiesErrorCatch();

            if (_strings.Length >= 12 && _strings[10].Contains("HeaderInf"))
                HeaderInformationObj = new HeaderInformation(_strings[11]);
            else
                SetPropertiesErrorCatch();
        }

        void SetPropertiesErrorCatch()
        {
            SetProperties(StatusDefaultValue);
            UpDateStatus();
        }
    }

    /// <summary>
    /// HeaderInformation class, process the HeaderInf value as
    /// HeaderInf:pdf|Address of file,doc|Address of file,docx|Address of file,txt|Address of file
    /// </summary>
    public class HeaderInformation
    {
        /// <summary>
        /// HeaderInformation class, process the HeaderInf value as
        /// HeaderInf:pdf|Address of file,doc|Address of file,docx|Address of file,txt|Address of file  
        /// </summary>
        /// <param name="headerInfValue"></param>
        public HeaderInformation(string headerInfValue)
        {
            HeaderInfContent = headerInfValue;
        }

        char Ext_FileName_SplitChar = '>';
        char HeaderInformation_SplitChar = '|';
        public List<Tuple<string, string>> HeaderIconList = new List<Tuple<string, string>>();

        int _countTxT;
        public int CountTxT
        {
            get
            {
                return _countTxT;
            }
            set
            {
                _countTxT = value;
            }
        }
        int _countPDF;
        public int CountPDF
        {
            get
            {
                return _countPDF;
            }
            set
            {
                _countPDF = value;
            }
        }
        int _countDoc;
        public int CountDoc
        {
            get
            {
                return _countDoc;
            }
            set
            {
                _countDoc = value;
            }
        }
        int _countDocx;
        public int CountDocx
        {
            get
            {
                return _countDocx;
            }
            set
            {
                _countDocx = value;
            }
        }

        void ClearAllCounter()
        {
            CountTxT = 0;
            CountPDF = 0;
            CountDoc = 0;
            CountDocx = 0;
        }

        public string HeaderInfContent
        {
            get
            {
                if (HeaderIconList.Count == 0)
                    return "HeaderInf:Null";

                var builder = new System.Text.StringBuilder();
                foreach (Tuple<string, string> iconheader in HeaderIconList)
                {
                    builder.Append(iconheader.Item1 + "      " + iconheader.Item2 + "," + Environment.NewLine);
                }
                return builder.ToString().ReplaceLast(",", "");
            }
            set
            {
                if (value.Contains("Null"))
                    return;

                ClearAllCounter();

                //"pdf>WI-00907 AB 01 - AT8460A, AT8461A, AT8462A, AT8463A, ATT8460A, ATT8461A, ATT8462A -  AdvanceRSM -"
                var extFileNameCollections = value.Split(new char[] { CurrentStatus.SeparatorBetweenFieldsOfRecord }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string iconInf in extFileNameCollections)
                {
                    var extFileName = iconInf.Split(new char[] { Ext_FileName_SplitChar }, StringSplitOptions.RemoveEmptyEntries);
                    AddItemInf(extFileName[0], extFileName[1]);
                    UpDateCountDoc(extFileName[0]);
                }
            }
        }

        public bool ExistIconInf
        {
            get
            {
                if (HeaderIconList.Count == 0)
                    return false;

                return true;
            }
        }

        public void UpDateHeaderInf(List<Tuple<string, string>> headerIconList)
        {
            HeaderIconList = headerIconList;

            ClearAllCounter();
            foreach (Tuple<string, string> itemInf in HeaderIconList)
            {
                UpDateCountDoc(itemInf.Item1);
            }
        }

        public void AddListInf(List<Tuple<string, string>> headerIconList)
        {
            foreach (Tuple<string, string> itemInf in headerIconList)
            {
                AddItemInf(itemInf);
            }
        }

        /// <summary>
        /// Add a Tuple string, string to the collection
        /// Tuple Ext, FullFileName
        /// UpDateCountDoc column value.
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="newItem">todo: describe newItem parameter on Add</param>
        public void AddItemInf(Tuple<string, string> newItem)
        {
            if (HeaderIconList.Contains(newItem))
                return;

            HeaderIconList.Add(newItem);
            UpDateCountDoc(newItem.Item1);
        }

        /// <summary>
        /// Create a new tuple with the information's
        /// File Ext, File full address.
        /// </summary>
        /// <param name="extfile"></param>
        /// <param name="address"></param>
        public void AddItemInf(string extfile, string address)
        {
            var newItem = new Tuple<string, string>(extfile, address);

            if (HeaderIconList.Contains(newItem))
                return;

            HeaderIconList.Add(newItem);
            UpDateCountDoc(extfile);
        }

        public string ToToolTipString()
        {
            return HeaderInfContent;
        }

        public override string ToString()
        {
            //       ␟ SeparatorBetweenFieldsOfRecord                 ␞ SeparatorRecordEndOfRecord

            if (HeaderIconList.Count == 0)
                return "HeaderInf␟Null";

            var builder = new System.Text.StringBuilder();
            builder.Append("HeaderInf");
            builder.Append(CurrentStatus.SeparatorBetweenFieldsOfRecord);

            foreach (Tuple<string, string> iconheader in HeaderIconList)
            {
                builder.Append(iconheader.Item1 + Ext_FileName_SplitChar + iconheader.Item2 + HeaderInformation_SplitChar);
            }
            return builder.ToString().ReplaceLast("" + HeaderInformation_SplitChar, "");
        }

        void UpDateCountDoc(string extFile)
        {
            switch (extFile)
            {
                case "txt":
                    {
                        CountTxT = CountTxT + 1;
                        break;
                    }
                case "pdf":
                    {
                        CountPDF = CountPDF + 1;
                        break;
                    }
                case "doc":
                    {
                        CountDoc = CountDoc + 1;
                        break;
                    }
                case "docx":
                    {
                        CountDocx = CountDocx + 1;
                        break;
                    }
            }
        }

    }

    /// <summary>
    /// BOMInformation class, process the BOMInf value as
    /// Mark:# of Comp|PartNumber:# of Placements|repit # of Comp. and finish with ;
    /// {BOM}:2|014-003:2|045-5467:1;
    /// </summary>
    public class BOMInformation
    {
        char BOMInformation_SplitChar = '|';
        public string DefaultBOMInformation = "{BOM}:0";

        public BOMInformation(string bOMInfValue)
        {
            if (!bOMInfValue.Contains("" + BOMInformation_SplitChar))
                BOMList = BomFactory(DefaultBOMInformation);

            BOMList = BomFactory(bOMInfValue);
        }

        public SortedDictionary<string, int> BOMList = new SortedDictionary<string, int>();

        int _countItems;
        public int CountItems
        {
            get
            {
                return _countItems;
            }
            set
            {
                _countItems = value;
            }
        }

        SortedDictionary<string, int> BomFactory(string bOMInf)
        {
            var initializeBomList = new SortedDictionary<string, int>();

            try
            {
                if (bOMInf.Contains("{BOM}:0;"))
                {
                    CountItems = 0;
                    return initializeBomList;
                }

                // Divide all pairs (remove empty strings)                
                string[] bOMItems = bOMInf.Split(new[] { BOMInformation_SplitChar }, StringSplitOptions.RemoveEmptyEntries);

                // Walk through each item
                foreach (var bOMItem in bOMItems)
                {
                    if (bOMItem == "")
                        continue;

                    int value;
                    var componentQuantity = bOMItem.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    // If the component exist into the sorted dictionary, error....
                    if (initializeBomList.ContainsKey(componentQuantity[0]))
                    {
                        initializeBomList.Add(@"Error Information Duplicated key " + componentQuantity[0], 0);
                        continue;
                    }

                    // Parse the int (this can throw)
                    try
                    {
                        value = int.Parse(componentQuantity[1]);
                    }
                    catch (Exception)
                    {
                        value = 0;
                        initializeBomList.Add(@"Error Information Parse value " + componentQuantity[1], 0);
                    }

                    //If contain {BOM}, it is the mark on properties for BOM row, Example: {BOM}:2;014-003:2;045-5467:1;
                    if (componentQuantity[0].Contains("{BOM}"))
                    {
                        CountItems = value;
                        continue;
                    }

                    initializeBomList.Add(componentQuantity[0].Trim(), value);
                }
            }
            catch (Exception error)
            {
                System.Windows.Forms.MessageBox.Show(@"Error found, " + error.Message,
                                @"IntializeBOM_List(), BOMInformation.cs.",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            return initializeBomList;
        }

        public void AddBOMList(SortedDictionary<string, int> BOMList)
        {
            foreach (KeyValuePair<string, int> BOMInf in BOMList)
            {
                AddBOMInf(BOMInf);
            }
        }

        public void AddBOMInf(KeyValuePair<string, int> newBOMItem)
        {
            AddBOMInf(newBOMItem.Key, newBOMItem.Value);
        }

        public void AddBOMInf(string compInf, int count)
        {
            if (BOMList.ContainsKey(compInf))
            {
                BOMList[compInf] = count;
                return;
            }

            BOMList.Add(compInf, count);
        }

        public override string ToString()
        {
            if (BOMList.Count == 0)
                return "{BOM}:0;";

            var builder = new System.Text.StringBuilder();
            builder.Append("{BOM}:");
            builder.Append(CountItems);
            builder.Append(BOMInformation_SplitChar);

            foreach (KeyValuePair<string, int> compInf in BOMList)
            {
                builder.Append(compInf.Key);
                builder.Append(":");
                builder.Append(compInf.Value);
                builder.Append(BOMInformation_SplitChar);
            }
            return builder.ToString().ReplaceLast("" + BOMInformation_SplitChar, ";");
        }
    }

    /// <summary>
    /// StateInformation class, process the property StateValue as
    /// {State}:Import or UpDate or None|Date:Date.Now()|ColumnModif:columnName,columnName;
    /// </summary>
    public class StateInformation
    {
        char Stateformation_SplitChar = '|';
        public static string DefaultStateValue = "{State}:None|Date:4/4/2017|ColumnModif:Property,Description";

        /// <summary>
        /// {State}:Import-Modif-UpDate-None|Date:Date.Now()|ColumnModif:columnName,columnName;
        /// </summary>
        /// <param name="stateValue"></param>
        public StateInformation(string stateValue)
        {
            _state = MyCode.StateItemsData.None;

            if (!stateValue.Contains("" + Stateformation_SplitChar))
                StateFactory(DefaultStateValue);

            StateFactory(stateValue);
        }

        MyCode.StateItemsData _state;
        public MyCode.StateItemsData State
        {
            get
            {
                return _state;
            }

            set { }
        }

        public string StateDate { get; set; } = DateTime.Now.ToShortDateString();
        public string[] ColumnModif { get; set; }

        void StateFactory(string stateValue)
        {
            try
            {
                // Divide all pairs (remove empty strings)
                var stateItems = new[] { stateValue };
                stateItems = stateValue.Split(new[] { Stateformation_SplitChar }, StringSplitOptions.RemoveEmptyEntries);

                // Walk through each item
                foreach (var stateItem in stateItems)
                {
                    if (stateItem == "")
                        continue;

                    var parValue = stateItem.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    switch (parValue[0])
                    {
                        case "{State}":
                            {
                                Enum.TryParse(parValue[1], true, out _state);
                                break;
                            }
                        case "Date":
                            {
                                StateDate = parValue[1];
                                break;
                            }
                        case "ColumnModif":
                            {
                                ColumnModif = parValue[1].Split(new char[] { ',' });
                                break;
                            }
                    }
                }
            }
            catch (Exception error)
            {
                System.Windows.Forms.MessageBox.Show(@"Error found, " + error.Message,
                                @"StateFactory, StateFactory.cs.",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public override string ToString()
        {
            var builder = new System.Text.StringBuilder();
            builder.Append("{State}:");
            builder.Append(State);
            builder.Append(Stateformation_SplitChar);
            builder.Append("Date:");
            builder.Append(StateDate);
            builder.Append(Stateformation_SplitChar);
            builder.Append("ColumnModif:");
            builder.Append(ColumnModif.ToString(","));
            builder.Append(';');

            return builder.ToString();
        }
    }
}

using System.ComponentModel;
using System.Data;
using System.Text;
using static MyStuff11net.Custom_Events_Args;

namespace MyStuff11net
{
    public class NodeProperties
    {
        string MessagePositionString = "";

        #region"Events, Custom Controls Events with custom Args.*********************"

        #region"Save_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.Save_Requested_EventHandler Save_Requested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnSaveRequested(Save_Requested_EventArgs e)
        {
            // If an event has no subscriber registerd, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (Save_Requested != null)
            {
                // Notify Subscribers
                Save_Requested(this, e);
            }
        }

        #endregion

        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event StatusBarMessage_EventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessage_EventHandler(object sender, StatusBarMessage_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            // If an event has no subscriber registerd, it will
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

        #endregion "Events, Custom Controls Events with custom Args.*********************"

        public NodeProperties()
        {
            try
            {
                _nodeRowView = null;
                Index = 0;
                ID = 0;
                Parent_ID = null;
                Code = "Undefined Code # 1";
                Range = "Undefined Range # 1";
                ProjectName = "Undefined ProjectName # 1";
                Text_Name = "Undefined Name # 1";
                Node_PDF = "Undefined PDF file # 1";
                Node_Picture = "Undefined Picture # 1";
                Description_Short = "Undefined Description # 1";
                Description_Expand = "Undefined Description # 1";
                Image = "Undefined Image # 1";
                StringFilter = "";
                MessagePositionString = "ItemCount # 1";
                ItemCount = 0;
                DateCreated = DateTime.Now;
                Created_by = "Undefined User # 1";
                Properties = "";
                Message_String = "Undefined MessageString # 1";
                Status = "Undefined MessageString # 1";
                ExistThumbs = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Found an error at # 1 " + MessagePositionString + " " + error.Message,
                                @"NodeProperties constructor has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public NodeProperties(string nodeProperties)
        {
            try
            {
                _nodeRowView = null;
                Index = 0;
                ID = 0;
                Parent_ID = null;
                Code = "Undefined Code # 2";
                Range = "Undefined Range # 2";
                ProjectName = "Undefined ProjectName # 2";
                Text_Name = "Undefined Name # 2";
                Node_PDF = "Undefined PDF file # 2";
                Node_Picture = "Undefined Picture # 2";
                Description_Short = "Undefined Description # 2";
                Description_Expand = "Undefined Description # 2";
                Image = "Undefined Image # 2";
                StringFilter = "";
                MessagePositionString = "ItemCount # 2";
                ItemCount = 0;
                DateCreated = DateTime.Now;
                Created_by = "Undefined User # 2";
                Properties = nodeProperties;
                Message_String = "Undefined MessageString # 2";
                Status = "Undefined MessageString # 2";
                ExistThumbs = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Found an error at # 1 " + MessagePositionString + " " + error.Message,
                                @"NodeProperties constructor has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public NodeProperties(DataRow nodeDataRow)
        {
            try
            {
                if (nodeDataRow != null)
                    InitializeNodeProperties(nodeDataRow);
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Found an error at " + MessagePositionString + " " + error.Message,
                                @"NodeProperties constructor has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public NodeProperties(DataRowView nodeRowView)
        {
            try
            {
                MessagePositionString = "Copy row.";
                DataRowViewProperties = nodeRowView;

                if (nodeRowView != null)
                    InitializeNodeProperties(nodeRowView.Row);
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Found an error at " + MessagePositionString + " " + error.Message,
                                @"NodeProperties constructor has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        public NodePropertiesBackup(DataRowView nodeRowView)
        {
            var MessagePositionString = "Starting Try/Catch procedure.";
            try
            {
                MessagePositionString = "Copy row.";
                _nodeRowView = nodeRowView;

                MessagePositionString = "Index";
                Index = MyCode.IntParseFast(_nodeRowView["Index"].ToString());
                MessagePositionString = "ID";
                ID = MyCode.IntParseFast(_nodeRowView["ID"].ToString());

                MessagePositionString = "Parent_ID";
                Parent_ID = _nodeRowView["Parent_ID"] == DBNull.Value ? (int?)null : Convert.ToInt32(_nodeRowView["Parent_ID"]);

                MessagePositionString = "Code";
                Code = (_nodeRowView["Code"] ?? "Undefined Code") as string;
                MessagePositionString = "Range";
                Range = (_nodeRowView["Range"] ?? "Undefined Range") as string;

                MessagePositionString = "ProjectName";
                ProjectName = "Undefined ProjectName";
                if (_nodeRowView.Row.Table.Columns.Contains("ProjectName"))
                    ProjectName = (_nodeRowView["ProjectName"] ?? "Undefined ProjectName").ToString();

                MessagePositionString = "TextName";
                Text_Name = (_nodeRowView["Text_Name"] ?? "Undefined Name") as string;
                MessagePositionString = "Node_PDF";
                Node_PDF = (_nodeRowView["Node_PDF"] ?? "Undefined PDF file").ToString();
                MessagePositionString = "Node_Picture";
                Node_Picture = (_nodeRowView["Node_Picture"] ?? "Undefined Picture").ToString();
                MessagePositionString = "Description_Short";
                Description_Short = (_nodeRowView["Description_Short"] ?? "Undefined Description").ToString();
                MessagePositionString = "Description_Expand";
                Description_Expand = (_nodeRowView["Description_Expand"] ?? "Undefined Description").ToString();
                MessagePositionString = "Image";
                Image = (_nodeRowView["Image"] ?? "Undefined Image").ToString();
                MessagePositionString = "Description_Expand";
                StringFilter = (_nodeRowView["String_Filter"] ?? "").ToString();
                MessagePositionString = "ItemCount";
                ItemCount = MyCode.IntParseFast(_nodeRowView["ItemCount"].ToString());

                MessagePositionString = "CreatedDate";
                string createdDate = (_nodeRowView["DateCreated"] ?? DateTime.Now).ToString();
                DateTime dateCreated;
                bool day = DateTime.TryParse(createdDate, out dateCreated);
                MessagePositionString = "CreatedBy";
                Created_by = (_nodeRowView["Created_by"] ?? "Undefined User").ToString();
                MessagePositionString = "Properties";
                Properties = (_nodeRowView["Properties"] ?? "Undefined User").ToString();

                MessagePositionString = "Message_String";
                Message_String = (_nodeRowView["Message_String"] ?? "Undefined MessageString").ToString();
                MessagePositionString = "Status";
                Status = (_nodeRowView["Status"] ?? "Undefined MessageString").ToString();
                MessagePositionString = "ExistThumbs";
                ExistThumbs = (bool)(_nodeRowView["ItemOpen"] ?? "false");

                DateCreated = dateCreated;
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Found an error at " + MessagePositionString + " " + error.Message,
                                @"NodeProperties constructor has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        void InitializeNodeProperties(DataRow nodeDataRow)
        {
            try
            {
                Index = MyCode.IntParseFast(nodeDataRow["Index"].ToString());       //0
                ID = MyCode.IntParseFast(nodeDataRow["ID"].ToString());             //1
                Parent_ID = nodeDataRow["Parent_ID"] == DBNull.Value ? null : Convert.ToInt32(nodeDataRow["Parent_ID"]); //2
                Code = (nodeDataRow["Code"] ?? "Undefined Code") as string;
                Range = (nodeDataRow["Range"] ?? "Undefined Range") as string;
                ProjectName = "Undefined ProjectName";
                if (nodeDataRow.Table.Columns.Contains("ProjectName"))
                    ProjectName = (nodeDataRow["ProjectName"] ?? "Undefined ProjectName").ToString();

                Text_Name = (nodeDataRow["Text_Name"] ?? "Undefined Name") as string;
                Node_PDF = (nodeDataRow["Node_PDF"] ?? "Undefined PDF file").ToString();    //4
                Node_Picture = (nodeDataRow["Node_Picture"] ?? "Undefined Picture").ToString(); //5
                Description_Short = (nodeDataRow["Description_Short"] ?? "Undefined Description").ToString();
                Description_Expand = (nodeDataRow["Description_Expand"] ?? "Undefined Description").ToString();
                Image = (nodeDataRow["Image"] ?? "Undefined Image").ToString();
                StringFilter = (nodeDataRow["String_Filter"] ?? "").ToString();
                ItemCount = MyCode.IntParseFast(nodeDataRow["ItemCount"].ToString());
                string createdDate = (nodeDataRow["DateCreated"] ?? DateTime.Now).ToString();
                bool day = DateTime.TryParse(createdDate, out DateTime dateCreated);
                Created_by = (nodeDataRow["Created_by"] ?? "Undefined User").ToString();
                AvalaibleDepartments = (nodeDataRow["AvailableDepartments"] ?? "AvailableDepart:ToAll,StockRoom;").ToString();
                Properties = (nodeDataRow["Properties"] ?? "Undefined User").ToString();
                Message_String = (nodeDataRow["Message_String"] ?? "Undefined MessageString").ToString();
                Status = (nodeDataRow["Status"] ?? "Undefined MessageString").ToString();
                ExistThumbs = (nodeDataRow["ItemOpen"] != DBNull.Value);

                DateCreated = dateCreated;
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Found an error at " + MessagePositionString + " " + error.Message,
                                @"NodeProperties constructor has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region Public Members

        public int Index { get; set; }              //0

        public int ID { get; set; }

        public int? Parent_ID { get; set; }

        public string Code { get; set; }

        /// <summary>
        /// Range defined the minimum value and maximum value admissible,
        /// it's formatted as 0000-9999 .
        /// </summary>
        public string Range { get; set; }

        public string Name
        {
            get { return Text_Name; }
        }

        /// <summary>
        /// Project full address and name.
        /// </summary>
        public string ProjectName { get; set; }

        public string Text_Name { get; set; }

        public string Node_PDF { get; set; }        //4

        public string Node_Picture { get; set; }    //5

        public string Image { get; set; }

        public string Description_Short { get; set; }

        public string Description_Expand { get; set; }

        public string StringFilter { get; set; }    //9

        public int ItemCount { get; set; }          //10

        public DateTime DateCreated { get; set; }   //11

        public string Created_by { get; set; }      //12

        /*
                var listDepart = "AvailableDepart:";
                foreach (string depart in AvailableDepartmentList)
                {
                    listDepart += depart + ",";
                }
                listDepart = listDepart.TrimEnd(',');
                return listDepart;
        */

        public string AvalaibleDepartments { get; set; }

        /// <summary>
        /// Gets or sets the properties associated with the object.
        /// DataRow[13] or DataRow["Properties"]
        /// </summary>
        public string Properties { get; set; }      //13

        public string Message_String { get; set; }  //14

        public string Status { get; set; }         //15

        string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
            }
        }

        public bool ExistThumbs { get; set; }

        int _myFatherIs;
        /// <summary>
        /// Project father is.
        /// </summary>
        public int MyFatherIs
        {
            get
            {
                if (_nodeRowView != null)
                {
                    if (_nodeRowView.Row.RowState == DataRowState.Detached)
                        return 0;

                    return MyCode.IntParseFast(_nodeRowView["MyFatherIs"].ToString());
                }

                return _myFatherIs;
            }
            set
            {
                if (_nodeRowView != null)
                    _nodeRowView["MyFatherIs"] = value;
                else
                    _myFatherIs = value;
            }
        }

        int _myGrandFatherIs;
        /// <summary>
        /// Project grandfather is.
        /// </summary>
        public int MyGrandFatherIs
        {
            get
            {
                if (_nodeRowView != null)
                {
                    if (_nodeRowView.Row.RowState == DataRowState.Detached)
                        return 0;

                    return MyCode.IntParseFast(_nodeRowView["MyGrandFatherIs"].ToString());
                }

                return _myGrandFatherIs;
            }
            set
            {
                if (_nodeRowView != null)
                    _nodeRowView["MyGrandFatherIs"] = value;
                else
                    _myGrandFatherIs = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                if (_nodeRowView == null)
                    return DateTime.Now;

                if (_nodeRowView.Row.RowState == DataRowState.Detached)
                    return DateTime.Now;

                DateTime createdDate;

                createdDate = ((DateTime)(_nodeRowView["DateCreated"] ?? DateTime.Now));

                return createdDate;
            }
            set
            {
                if (value != null)
                {
                    _nodeRowView["StartDate"] = value.ToShortDateString();
                }
            }
        }

        public DateTime EndDate
        {
            get
            {
                if (_nodeRowView == null)
                    return DateTime.Now;

                if (_nodeRowView.Row.RowState == DataRowState.Detached)
                    return DateTime.Now;

                DateTime endDate = ((DateTime)(_nodeRowView["EndDate"] ?? DateTime.Now));

                return endDate;
            }
            set
            {
                if (_nodeRowView != null && _nodeRowView.Row.RowState != DataRowState.Detached)
                    _nodeRowView["EndDate"] = value.ToShortDateString();
            }
        }

        public Color BackColor
        {
            get
            {
                try
                {
                    if (_nodeRowView == null)
                        return Color.White;

                    if (_nodeRowView.Row.RowState == DataRowState.Detached)
                        return Color.White;

                    Color colorReturn = Color.FromName(Convert.ToString(_nodeRowView["BackgroundColor"]));

                    if (colorReturn == null)
                        return Color.White;
                    else
                        return colorReturn;
                }
                catch (Exception ex)
                {
                    return Color.White;
                }
            }
            set
            {
                _nodeRowView["BackgroundColor"] = value;
            }
        }

        bool _openItem;
        public bool OpenItem
        {
            get
            {
                if (_nodeRowView != null)
                    return (bool)_nodeRowView["ItemOpen"];

                return _openItem;
            }

            set
            {
                if (_nodeRowView != null)
                    _nodeRowView["ItemOpen"] = value;
                else
                    _openItem = value;
            }
        }

        DataRowView _nodeRowView;
        public DataRowView DataRowViewProperties
        {
            get
            {
                return _nodeRowView;
            }
            set
            {
                //  if (_nodeRowView == null)
                //     _nodeRowView = new DataRowView;

                _nodeRowView = value;
            }
        }

        public string FileNameWithoutExtension
        {
            get
            {
                return Path.GetFileNameWithoutExtension(ProjectName);
            }
            private set { }
        }

        public string CodeString
        {
            get
            {
                if (_nodeRowView["Text_Name"].ToString().Length >= 4)
                    return _nodeRowView["Text_Name"].ToString().Substring(0, 4);
                else
                    return "Text_Name Undefined";
            }
            private set { }
        }

        public string RangeString
        {
            get
            {
                return _nodeRowView["Text_Name"].ToString().Replace(CodeString, "");
            }
            private set { }
        }

        /// <summary>
        /// RangeMax will be the top value defined in Range.
        /// </summary>
        public int RangeMax
        {
            get
            {
                try
                {
                    string rangemax = Range.Substring(5, 4);
                    int rangeMax = int.Parse(rangemax);
                    return rangeMax;
                }
                catch (Exception)
                {
                    return 25;
                }
            }

            set { }
        }

        /// <summary>
        /// It's a pointer to current value scanned into it's range.
        /// </summary>
        public int RangePos { get; set; }

        /// <summary>
        /// RangeMin will be the lowed value defined in Range.
        /// </summary>
        public int RangeMin
        {
            get
            {
                try
                {
                    string rangemin = Range.Substring(0, 4);
                    int rangeMin = int.Parse(rangemin);
                    return rangeMin;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            set { }
        }

        /// <summary>
        /// Gets or sets the list of available departments where this treeView menu is available.AvalaibleDepartments
        /// </summary>
        /// <remarks>When getting the property, the list is derived from the <c>Properties</c> string,
        /// which is expected to contain department information in a specific format. If the format is invalid or
        /// missing, a default list is returned, and the <c>Properties</c> string is updated accordingly.  When setting
        /// the property, the provided list of department names is serialized into the <c>Properties</c> string in the
        /// expected format.</remarks>
        public List<string> AvailableDepartmentList
        {
            get
            {
                List<string> _listDepart = new List<string>();

                if (string.IsNullOrEmpty(AvalaibleDepartments))
                    return _listDepart;

                var _strings = AvalaibleDepartments.Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                //"AvailableDepart:ToAll,StockRoom;Selected:false;Unerasable:true;Color:-36865;Note:Null;HeaderInf:Null;DisplayStatus:false,false,0"
                //      0            2             4                6            8        10             12
                if (_strings[0].Contains("AvailableDepart") && _strings.Length >= 2)
                    _listDepart = _strings[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                else
                {
                    AvalaibleDepartments = "AvailableDepart:ToAll,StockRoom;";
                    _listDepart = "ToAll,StockRoom".Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    SaveProperties();
                }

                return _listDepart;
            }
            set
            {
                string listDepart = "AvailableDepart:";
                foreach (string depart in value)
                {
                    listDepart += depart + ",";
                }
                listDepart = listDepart.TrimEnd(',');

                AvalaibleDepartments = listDepart;
            }
        }

        public string AvailableDepartmentFilter
        {
            get
            {
                var filter = "Properties LIKE '*";
                foreach (string depart in AvailableDepartmentList)
                {
                    filter += depart + "*' OR Properties LIKE '*";
                }
                filter = filter.TrimEnd(" OR Properties LIKE '*", false);

                return filter;
            }
        }

        public void AvailableDepartmentUpDate()
        {
            var listRemove = new List<string>();





            AvailableDepartmentList = listRemove;
        }

        public bool IsEmployee
        {
            get
            {
                if (StringFilter.Contains("Department NOT LIKE '*Department*'"))
                    return true;
                else
                    return false;
            }
        }

        public bool IsDepartment
        {
            get
            {
                if (StringFilter.Contains("Department LIKE '*Department*'"))
                    return true;
                else
                    return false;
            }
        }

        #endregion Public Members

        SortedDictionary<string, int> _BOM_List = new SortedDictionary<string, int>();
        public SortedDictionary<string, int> BOM_List
        {
            get
            {
                return _BOM_List;
            }
            set
            {
                if (value == null)
                    _BOM_List = new SortedDictionary<string, int>();
                else
                    _BOM_List = value;

                _nodeRowView["Properties"] = MyCode.GetString(_BOM_List);
            }
        }

        public string ToHTML()
        {
            string toHTML = "";

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("<P><B>ID            = </B>" + ID + "</P>");
            stringBuilder.AppendLine("<P><B>Parent_ID = </B>" + Parent_ID + "</P>");
            stringBuilder.AppendLine("<P><B>Text         = </B>" + Text_Name + "</P>");
            stringBuilder.AppendLine("<P><B>String_Filter = </B>" + StringFilter + "</P>");

            toHTML = stringBuilder.ToString();

            return toHTML;
        }

        public DataRowView Get_Row
        {
            get
            {
                return _nodeRowView;
            }
        }

        /// <summary>
        /// Saves the current properties of the node to the underlying data source.
        /// </summary>
        /// <remarks>This method updates the underlying data row with the current property values of the
        /// node. It ensures that the data row is in a valid state (not detached or deleted) before performing the
        /// update. After updating the data row, the method raises a save request event to notify listeners of the
        /// change.</remarks>
        public void SaveProperties()
        {
            if (_nodeRowView == null)
                return;

            if (_nodeRowView.Row.RowState == DataRowState.Detached)
                return;
            if (_nodeRowView.Row.RowState == DataRowState.Deleted)
                return;

            _nodeRowView.BeginEdit();

            _nodeRowView["ID"] = ID;
            _nodeRowView["Index"] = Index;

            if (Parent_ID != null)
                _nodeRowView["Parent_ID"] = Parent_ID;
            else
                _nodeRowView["Parent_ID"] = DBNull.Value;

            _nodeRowView["Text_Name"] = Text_Name;
            _nodeRowView["Node_PDF"] = Node_PDF;
            _nodeRowView["Node_Picture"] = Node_Picture;
            _nodeRowView["Description_Short"] = Description_Short;
            _nodeRowView["Description_Expand"] = Description_Expand;
            _nodeRowView["Image"] = Image;
            _nodeRowView["String_Filter"] = StringFilter;
            _nodeRowView["ItemCount"] = ItemCount;
            _nodeRowView["DateCreated"] = DateCreated;
            _nodeRowView["Created_by"] = Created_by;
            _nodeRowView["AvailableDepartments"] = AvalaibleDepartments;
            _nodeRowView["Properties"] = Properties;
            _nodeRowView["Message_String"] = Message_String;
            _nodeRowView["Status"] = Status;

            _nodeRowView.EndEdit();
            //_nodeRowView.Row.AcceptChanges();

            return;

            OnSaveRequested(new Save_Requested_EventArgs()
            {
                NotificationEvent = MyCode.NotificationEvents.DataBaseUpDated,
                Message = "NodeProperties, SaveProperties(): SaveProperties has been called.",
                DataTableName = _nodeRowView.Row.Table.TableName
            });
        }

        public void UpdateParentID(int? parentID)
        {
            if (_nodeRowView == null)
                return;

            if (_nodeRowView.Row.RowState == DataRowState.Detached)
                return;
            if (_nodeRowView.Row.RowState == DataRowState.Deleted)
                return;

            _nodeRowView.BeginEdit();

            if (parentID != null)
                _nodeRowView["Parent_ID"] = parentID;
            else
                _nodeRowView["Parent_ID"] = DBNull.Value;

            _nodeRowView.EndEdit();

            OnSaveRequested(new Save_Requested_EventArgs()
            {
                NotificationEvent = MyCode.NotificationEvents.DataBaseUpDated,
                Message = "NodeProperties, UpdateParentID(): SaveProperties has been called.",
                DataTableName = _nodeRowView.Row.Table.TableName
            });
        }

        /// <summary>
        /// Return true if is the node,
        /// test Text_Name versus caseToEvaluate.
        /// </summary>
        /// <param name="caseToEvaluate"></param>
        /// <returns></returns>
        public bool IsThisNode(string caseToEvaluate)
        {
            if (Text_Name.Contains(caseToEvaluate))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Return true if is not the node,
        /// test Text_Name versus caseToEvaluate.
        /// </summary>
        /// <param name="caseToEvaluate"></param>
        /// <returns></returns>
        public bool IsNotThisNode(string caseToEvaluate)
        {
            if (Text_Name.Contains(caseToEvaluate))
                return false;
            else
                return true;
        }

    }
}

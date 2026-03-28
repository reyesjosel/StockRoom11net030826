using System.ComponentModel;
using System.Data;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;

namespace MyStuff11net
{
    public class ComponentProperties
    {

        #region"Events, Custom Controls Events with custom Args.*********************"

        #region"Save_Requested"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event SaveRequestedEventHandler SaveRequested;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SaveRequestedEventHandler(object sender, Save_Requested_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_Save_Requested(Save_Requested_EventArgs e)
        {
            // If an event has no subscriber registerd, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (SaveRequested != null)
            {
                // Notify Subscribers
                SaveRequested(this, e);
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

        protected DataRowView Row;

        public SortedDictionary<string, int> BomList;


        public ComponentProperties(DataRowView row, bool state)
        {
            Row = row;
        }

        public ComponentProperties(DataRowView row)
        {
            LazyLoad = false;
            Row = row;

            InitializeComponentProperties();
        }

        public ComponentProperties(DataRowView row, int id)
        {
            LazyLoad = false;
            Row = row;

            InitializeComponentProperties();
        }

        public ComponentProperties(DataRowView row, int id, int parent_ID)
        {
            LazyLoad = false;
            Row = row;

            InitializeComponentProperties();
        }



        private void InitializeComponentProperties()
        {
            try
            {
                if (Row == null)
                    return;

                _text = Row["PartNumber"] == DBNull.Value ? "No PartNumber defined" : Row["PartNumber"].ToString();

                NodePdf = Row["DataSheet_File"] == DBNull.Value ? "" : Row["DataSheet_File"].ToString();

                DescriptionShort = Row["Description"] == DBNull.Value ? "" : Row["Description"].ToString();

                if (Row["Properties"] == DBNull.Value)
                    return;

                var properties = Row["Properties"].ToString();

                if (properties == "")
                {
                    return;
                }

                if (properties.Contains("{BOM}"))
                    InitializeProperties(Row["Properties"].ToString());

                //BomList = IntializeBomList(Row["Properties"].ToString());

            }
            catch (Exception error)
            {
                MessageBox.Show(@"Error found, " + error.Message,
                                @"InitializeComponentProperties(), Ln 41, ComponentProperties.cs.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }



        public int ID
        {
            get
            {
                return BomList["ID"];
            }
            set
            {
                BomList["ID"] = value;
            }
        }

        /// <summary>
        /// Index is the same ID, no need storage.
        /// </summary>
        public int Index
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public int? ParentId
        {
            get
            {
                if (BomList["Parent_ID"] == -1)
                    return null;

                return BomList["Parent_ID"];
            }
            set
            {
                BomList["Parent_ID"] = value.GetValueOrDefault(-1); // assigns -1 if v1 has no valueValue;
            }
        }

        public string ClassPa
        {
            get
            {
                // Return the (BOM) sub string.
                string[] allRecords;
                allRecords = Row["Properties"].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                return allRecords[0];
            }
            set
            {
                string test = value;
            }
        }

        public string PartNumber
        {
            get
            {
                return Row["PartNumber"].ToString();
            }
            set
            {
                Row["PartNumber"] = value;
            }
        }

        string _text;
        /// <summary>
        /// Return the value in ["Text_Name"] field.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        string _nodePdf;
        public string NodePdf
        {
            get
            {
                return _nodePdf;
            }
            set
            {
                _nodePdf = value;
                _propertiesValue[0] = value;
            }
        }

        string _nodePicture;
        public string NodePicture
        {
            get
            {
                return _nodePicture;
            }
            set
            {
                _nodePicture = value;
                _propertiesValue[1] = value;
            }
        }

        string _descriptionShort;
        public string DescriptionShort
        {
            get
            {
                return _descriptionShort;
            }
            set
            {
                _descriptionShort = value;
                _propertiesValue[2] = value;
            }
        }

        string _descriptionExpand;
        public string DescriptionExpand
        {
            get
            {
                return _descriptionExpand;
            }
            set
            {
                _descriptionExpand = value;
                _propertiesValue[3] = value;
            }
        }

        string _image;
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                _propertiesValue[4] = value;
            }
        }

        string _stringFilter;
        public string StringFilter
        {
            get
            {
                return _stringFilter;
            }
            set
            {
                _stringFilter = value;
                _propertiesValue[5] = value;
            }
        }

        public int ItemCount { get; set; }

        DateTime _dateCreated = DateTime.Now;
        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }
            set
            {
                _dateCreated = value;
                _propertiesValue[6] = value.ToString();
            }
        }

        string _createdby;
        public string CreatedBy
        {
            get
            {
                return _createdby;
            }
            set
            {
                _createdby = value;
                _propertiesValue[7] = value;
            }
        }

        public bool LazyLoad { get; set; }

        public string Status;


        string _messageString;
        public string MessageString
        {
            get
            {
                return _messageString;
            }
            set
            {
                _messageString = value;
                _propertiesValue[9] = value;
            }
        }

        public override string ToString()
        {
            return "No ready.";
        }



        //Keep all information about row columns value.
        private string[] _propertiesValue = new[] { "", "", "", "", "", "", "", "", "", "" };
        private void InitializeProperties(string rowValues)
        {
            try
            {
                // Divide all pairs (remove empty strings)
                if (rowValues.Contains(","))
                {
                    rowValues = rowValues.Replace("ListProperties,", "");
                    _propertiesValue = rowValues.Split(new[] { ',' }, StringSplitOptions.None);
                }

                if (_propertiesValue.Length == 10)
                {
                    NodePdf = _propertiesValue[0];
                    NodePicture = _propertiesValue[1];
                    DescriptionShort = _propertiesValue[2];
                    DescriptionExpand = _propertiesValue[3];
                    Image = _propertiesValue[4];
                    StringFilter = _propertiesValue[5];
                    //ItemCount
                    DateCreated = MyCode.ParseDate(_propertiesValue[6]);
                    CreatedBy = _propertiesValue[7];
                    //     Node_Properties = new NodeProperties(_propertiesValue[8]);
                    MessageString = _propertiesValue[9];
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(@"Error found, " + error.Message,
                                @"InitializeProperties(), Ln 429, ComponentProperties.cs.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        public void SaveProperties()
        {
            if (Row.Row.RowState == DataRowState.Detached)
                return;

            var listProperties = "ListProperties," + string.Join(",", _propertiesValue);

            Row.BeginEdit();

            Row["PartNumber"] = Text;
            Row["Properties"] = "{BOM}:" + ItemCount + ";" + MyCode.GetString(BomList) + ";" + listProperties + ";";

            Row["Message_String"] = MessageString;
            Row["Status"] = Status;

            Row.EndEdit();

            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
        }

    }
}

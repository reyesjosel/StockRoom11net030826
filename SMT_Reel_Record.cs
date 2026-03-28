using MyStuff11net;
using MyStuff11net.Properties;
using RawInput_dll;
using System.Data;
using System.Data.OleDb;
using static MyStuff11net.Custom_Events_Args;

namespace StockRoom11net
{
    public partial class SMT_Reel_Record : BaseTemple
    {
        static string DataBaseConnectionString = "";
        OleDbConnection ReelRecord_ConnectionString;

        BindingSource _bindingSource_Employees;

        DataRowView _rowReelExist;
        DataRowView _rowFeederExist;

        #region"On_ScannedData"
        string _feederSrNr = "";
        string serialNumber = "";


        public void OnBarcodeScanned_EventHandler(object sender, RawInputEventArg e)
        {
            if (e == null)
                return;

            // If the application is not visible, do not processes the barcode event. 
            if (!Visible)
                return;

            //If command process is active go to it...
            if (Command_ProcessChangeReel_Active)
            {
                Command_CompReelChange(e.BarcodeData);
                return;
            }

            #region"EmployeeID Scanned"

            if (e.BarcodeData.Length == 6)
            {
                EmployeeID_Scaned(e.BarcodeData);
            }

            #endregion"EmployeeID Scanned"

            #region"Scanned a Comammd, goto process it."

            if (e.BarcodeData.StartsWith("Command_"))
            {
                ProcessCommandSMT(e);
            }

            #endregion"Scanned a Comammd, goto process it."            
        }
        #endregion

        public SMT_Reel_Record(BindingSource bindingSource_Employees)
        {
            try
            {
                InitializeComponent();
               

                //Provider=Microsoft.Jet.OLEDB.4.0;Data Source="X:\ProductionManagement\ReelRecord DataSheet.mdb"
                DataBaseConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.Combine(Settings.Default.DataBaseAddress, "ReelRecord.mdb");
                ReelRecord_ConnectionString = new OleDbConnection(DataBaseConnectionString);

                ReelRecord_ConnectionString.Open();
              //  reelRecord_TableAdapter.Connection = ReelRecord_ConnectionString;
              //  _rowLoaded = reelRecord_TableAdapter.Fill(reelRecord_DataSet.ReelRecord_Table);
                ReelRecord_ConnectionString.Close();
             //   reelRecord_DataSet.ReelRecord_Table.AcceptChanges();

                _bindingSource_Employees = bindingSource_Employees;

                On_StatusBarMessage(new StatusBarMessage_EventArgs("Finished loading table ReelRecord ... Rows loaded = " + _rowLoaded));

                splitContainer_CompReelChange.Panel2Collapsed = true;
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is " + error.Message,
                                           @"ReelRecord has generated an error.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void SMT_Reel_Record_Load(object sender, EventArgs e)
        {
            InitializeDataGridViewBase(dataGridViewExtended_ReelRecord);

            dataGridViewExtended_ReelRecord.BindingNavigatorAddNewItemEvent += DataGridViewExtended_ReelRecord_AddNewItemEvent;
            dataGridViewExtended_ReelRecord.SaveRequested += DataGridViewExtended_ReelRecord_SaveRequested;
            dataGridViewExtended_ReelRecord.CellEndEditEvent += DataGridViewExtended_ReelRecord_CellEndEditEvent;
            dataGridViewExtended_ReelRecord.PreviewKeyDownEvent += DataGridViewExtended_ReelRecord_PreviewKeyDownEvent;

            delayEndEdit = new System.Windows.Forms.Timer();
            delayEndEdit.Interval = 25;
            delayEndEdit.Tick += DelayEndEdit_Tick;
            delayEndEdit.Stop();
        }


        #region"DataGridViewExtended_ReelRecord"

        void DataGridViewExtended_ReelRecord_AddNewItemEvent(object sender, EventArgs e)
        {
            DataRowView addedRow = (DataRowView)_bindingSource_ReelRecord.AddNew();
            addedRow.Row.SetField("Reel_SerialNumber", serialNumber);
            addedRow.Row.SetField("DateTime", DateTime.Now);

            SelectCellEditMode(1);
        }

        void DataGridViewExtended_ReelRecord_SaveRequested(object sender, Save_Requested_EventArgs e)
        {
            ReelRecordDataSheetSaveRequest(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
        }

        int cellEditEnd;
        int numberOfRowAdded;
        void DelayEndEdit_Tick(object sender, EventArgs e)
        {
            delayEndEdit.Stop();

            //PreviewKeyDownEnter = true; // To test...

            if (PreviewKeyDownEnter)
            {
                PreviewKeyDownEnter = false;
                int lastdisplayedColumn = dataGridViewExtended_ReelRecord.ColumnsCollection.Count - 4;

                if (cellEditEnd == lastdisplayedColumn)
                {
                    numberOfRowAdded++;
                    dataGridViewExtended_ReelRecord.LockCurrentRow();
                    dataGridViewExtended_ReelRecord.MarkUnerasableCurrentRow();
                    On_StatusBarMessage(new StatusBarMessage_EventArgs("A new item has been received, count = " + numberOfRowAdded));

                    if (numberOfRowAdded == 5)
                    {
                        numberOfRowAdded = 0;
                        ReelRecordDataSheetSaveRequest(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
                        On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("New items have been stored."));
                    }

                    return;
                }

                SelectCellEditMode(cellEditEnd + 1);
            }
        }

        System.Windows.Forms.Timer delayEndEdit;
        void DataGridViewExtended_ReelRecord_CellEndEditEvent(object sender, DataGridViewCellEventArgs e)
        {
            cellEditEnd = e.ColumnIndex;
            delayEndEdit.Start();
        }

        bool PreviewKeyDownEnter;
        void DataGridViewExtended_ReelRecord_PreviewKeyDownEvent(object sender, PreviewKeyDownEventArgs e)
        {
            PreviewKeyDownEnter = (e.KeyCode == Keys.Enter);
        }

        void SelectCellEditMode(int index)
        {
            DataGridViewCell cell = dataGridViewExtended_ReelRecord.CurrentRowActive.Cells[index];
            dataGridViewExtended_ReelRecord._dataGridView.CurrentCell = cell;

            dataGridViewExtended_ReelRecord.UnLockCurrentRow();
            dataGridViewExtended_ReelRecord.MarkErasableCurrentRow();

            dataGridViewExtended_ReelRecord._dataGridView.BeginEdit(false);
        }

        #endregion"DataGridViewExtended_ReelRecord"

        #region "Table_ReelRecordDataSheet"

        /// <summary>
        /// Count the numbers of rows loaded by Fill process.
        /// </summary>
        int _rowLoaded;
        /// <summary>
        /// Hold the numbers rows saved by any update process.
        /// </summary>
        int RowsSaved;
        /// <summary>
        /// Hold the numbers rows changed by....
        /// </summary>
        int RowsChanged;
        /// <summary>
        /// Keep the records changed at the last save call.....
        /// </summary>
        DataTable changedRecordsTable;

        void ReelRecordDataSheet_ProcessSaveRequest(object sender, Save_Requested_EventArgs e)
        {
            switch (e.SaveEvent)
            {
                case MyCode.NotificationEvents.RowInformationChange:
                    {
                        if (Settings.Default.SaveEachTimeTheInformationIsChanged)
                        {
                            NeedSaveData = false;
                            ReelRecordDataSheetSaveRequest(e);
                            break;
                        }

                        break;
                    }
                case MyCode.NotificationEvents.DataBaseUpDated:
                    {
                        //NotificationEvent will be up when the database is saved successfully.

                        NeedSaveData = false;
                        ReelRecordDataSheetSaveRequest(e);
                        break;
                    }
                case MyCode.NotificationEvents.ClearAllSelected:
                    {
         //               UpdateStatusColumn(reelRecord_DataSet.ReelRecord_Table);

                        break;
                    }
            }
        }

        public void ReelRecordDataSheetSaveRequest(Save_Requested_EventArgs e)
        {
            try
            {
                if (!SaveReelRecordDataSheet_Requested())
                {
                    On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Sorry, an error occurred while trying to save the database ReelRecord datasheet."));
                    On_StatusBarMessage(new StatusBarMessage_EventArgs("Sorry, an error occurred while trying to save the database ReelRecord datasheet."));
                    return;
                }

                On_StatusBarMessage(new StatusBarMessage_EventArgs("StockRoom Control, save request, has already been processed, "
                                                                                                + RowsSaved + " has been updated."));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error while trying to save the DataBase." + ex.Message,
                                @"Error on DataBase. StockRoom Inventory.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        public bool SaveReelRecordDataSheet_Requested()
        {
            try
            {
                _bindingSource_ReelRecord.EndEdit();

    //            UpdateStatusColumn(reelRecord_DataSet.ReelRecord_Table);

    //            changedRecordsTable = reelRecord_DataSet.ReelRecord_Table.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

     //           RowsSaved = reelRecord_TableAdapter.Update(reelRecord_DataSet.ReelRecord_Table);

                return true;
            }
            catch (Exception ex)
            {
    //            if (reelRecord_DataSet.ReelRecord_Table.HasErrors)
                {
                    _bindingSource_ReelRecord.Sort = "Status DESC";

   //                 UpdateStatusColumnHasError(reelRecord_DataSet.ReelRecord_Table);
                }

                MessageBox.Show(@"Error while trying to save the DataBase" + ex.Message +
                                "Numbers of rows changed by.... " + RowsChanged,
                                @"Error on Save process of Stockroom DataBase.",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Check Status column for "Locked:False","Selected:True", "Unerasable:False" and "Status IS NULL"
        /// Will unselect any selected row, Lock any unlocked row.
        /// </summary>
        /// <param name="datatableToUpdateStatus"></param>
        void UpdateStatusColumn(DataTable datatableToUpdateStatus)
        {
            if (datatableToUpdateStatus.Columns.Contains("Status"))
            {
                #region"Check Status column for "Locked:False","Selected:True", "Unerasable:False" and "Status IS NULL""

                using (var dv = new DataView(datatableToUpdateStatus, "Status LIKE '*Locked:False*' OR " +
                                                                      "Status LIKE '*Selected:True*' OR " +
                                                                      "Status LIKE '*Unerasable:False*' OR " +
                                                                      "Status IS NULL",
                                                                      "Status DESC", DataViewRowState.CurrentRows))
                {
                    // If Count == 0, no row match.
                    if (dv.Count != 0)
                    {
                        foreach (DataRowView row in dv)
                        {
                            string rowStatus = row["Status"].ToString();

                            if (string.IsNullOrEmpty(rowStatus) || string.IsNullOrWhiteSpace(rowStatus))
                            {
                                row["Status"] = CurrentStatus.StatusDefaultValueNewRow;
                                row.EndEdit();
                                continue;
                            }

                            if (rowStatus.Contains("Locked:False"))
                                row["Status"] = rowStatus.Replace("Locked:False", "Locked:True");

                            if (rowStatus.Contains("Selected:True"))
                                row["Status"] = rowStatus.Replace("Selected:True", "Selected:False");

                            if (rowStatus.Contains("Unerasable:False"))
                                row["Status"] = rowStatus.Replace("Unerasable:False", "Unerasable:True");

                            row.EndEdit();
                        }
                    }
                }

                #endregion"Check Status column for "Locked:False","Selected:True", "Unerasable:False" and "Status IS NULL""
            }
        }

        int _count;
        string _rowHasError = "";


        void UpdateStatusColumnHasError(DataTable datatableToUpdateStatusHassError)
        {
            _count = 0;
            _rowHasError = "";

            foreach (DataRow row in datatableToUpdateStatusHassError.Rows)
            {
                if (row.HasErrors && row.RowState != DataRowState.Deleted)
                {
                    string rowStatus = row["Status"].ToString();
                    if (rowStatus.Contains("Selected:False"))
                        row["Status"] = rowStatus.Replace("Selected:False", "Selected:True");

                    foreach (object rowCell in row.ItemArray)
                    {
                        _rowHasError += rowCell.ToString() + "; ";
                    }

                    _count++;
                }
            }
        }

        #endregion "Table_ReelRecordDataSheet"


        #region"Process Command SMT Reel"

        bool Command_ProcessChangeReel_Active = false;
        string process_compReelChange_Index = "New process";
        void ProcessCommandSMT(RawInputEventArg e)
        {
            try
            {
                string _command = e.BarcodeData.Replace("Command_", "");

                switch (_command)
                {
                    case "AddFeeder":
                        {
                            DataGridViewExtended_ReelRecord_AddNewItemEvent(new object(), new EventArgs());
                            break;
                        }
                    case "RemoveFeeder":
                        {
                            //Command_RemoveFeeder(e.Barcode);
                            break;
                        }
                    case "CompReelChange":
                        {
                            process_compReelChange_Index = "ProcessCompReelChange";
                            Command_CompReelChange(e.BarcodeData);
                            break;
                        }
                }
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is " + error.Message,
                                           @"ProcessCommandSMT has generated an error.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion"Process Command SMT Reel"

        #region"Command Component Reel Change"

        void Command_CompReelChange(string barcodeValue)
        {
            try
            {
                switch (process_compReelChange_Index)
                {
                    case "ProcessCompReelChange":
                        {
                            process_compReelChange_Index = "Employee_ID";
                            Command_ProcessChangeReel_Active = true;
                            groupBox_Employee_ID.BackColor = Color.DimGray;
                            splitContainer_CompReelChange.Panel2Collapsed = false;
                            tabControl_CompReelChange.SelectTab("tabPage_CompReelChangeProcess");
                            On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Scan the Employee ID card"));
                            break;
                        }
                    case "Employee_ID":
                        {
                            if (barcodeValue.Length == 6)
                            {
                                EmployeeID_Scaned(barcodeValue);
                                process_compReelChange_Index = "Feeder_SrNr";
                                groupBox_Employee_ID.BackColor = Color.LightGreen;
                                On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Scan the Feeder serial number"));
                                groupBox_feederSrNr.BackColor = Color.DimGray;
                            }
                            else
                            {
                                On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Sorry, the system is waiting for a Employee ID"));
                            }
                            break;
                        }
                    case "Feeder_SrNr":
                        {
                            if (barcodeValue.StartsWith("Feeder_SrNr_"))
                            {
                                int feederSerialN = int.Parse(barcodeValue.Substring(barcodeValue.Length - 3));
                                if (CheckIf_FeederExist(barcodeValue))
                                {
                                    FeederSrNr_AllreadyExist(barcodeValue);
                                    return;
                                }
                                process_compReelChange_Index = "CompPartNumber";
                                label_FeederSrNr_Value.Text = barcodeValue;
                                groupBox_feederSrNr.BackColor = Color.LightGreen;
                                On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Scan the Component Part Number"));
                                groupBox_CompSrNr.BackColor = Color.DimGray;
                            }
                            else
                            {
                                On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Sorry, the system is waiting for a Feeder serial number"));
                            }


                            break;
                        }
                    case "CompPartNumber":
                        {
                            if (barcodeValue.StartsWith("CompPartNumber"))
                            {
                                int feederSerialN = int.Parse(_feederSrNr.Substring(barcodeValue.Length - 3));
                                if (CheckIf_FeederExist(barcodeValue))
                                {
                                    FeederSrNr_AllreadyExist(barcodeValue);
                                    return;
                                }
                                process_compReelChange_Index = "New process";

                                groupBox_Employee_ID.BackColor = Color.Transparent;
                                groupBox_feederSrNr.BackColor = Color.Transparent;
                                groupBox_feederSrNr.BackColor = Color.Transparent;

                                On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Reel change event archived"));
                            }
                            else
                            {
                                On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Sorry, the system is waiting for a Component Part Number"));
                            }
                            break;
                        }
                }
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is " + error.Message,
                                           @"Component Reel Change process has generated an error.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion"Command Component Reel Change"



        #region"Employee ID fiel"

        Employee _employeeInformation;
        void EmployeeID_Scaned(string password)
        {
            try
            {
                #region"EmployeesInformation"

                int employeeIndex = _bindingSource_Employees.Find("Last6Digit", password);

                if (employeeIndex == -1)
                    return;

                _employeeInformation = new Employee((DataRowView)_bindingSource_Employees[employeeIndex]);

                label_EmployeeID_Value.Text = _employeeInformation.FullName;
                On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Hi " + _employeeInformation.Name));

                #endregion"EmployeesInformation"
            }
            catch (Exception)
            {
                MessageBox.Show("Employee information erroneous", "Missing Employee Data.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion"Employee ID fiel"

        #region"Feeder fiel"

        void FeederSrNr_Scaned(string feederSrNr)
        {
            try
            {
                int feederSerialN = int.Parse(_feederSrNr.Substring(feederSrNr.Length - 3));

                if (CheckIf_FeederExist(feederSrNr))
                {
                    FeederSrNr_AllreadyExist(feederSrNr);
                    return;
                }
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is " + error.Message,
                                           @"ReelRecord DataSheet has generated an error.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        bool CheckIf_FeederExist(string feederSrNr)
        {
            _rowFeederExist = _bindingSource_ReelRecord.List.OfType<DataRowView>().ToList().Find(f => f["Feeder_SerialNumber"].ToString().Equals(feederSrNr, StringComparison.InvariantCultureIgnoreCase));
            if (_rowFeederExist == null)
                return false;

            return true;
        }

        void FeederSrNr_AllreadyExist(string feederSrNr)
        {
            if (_rowFeederExist == null)
                return;

            int pos = _bindingSource_ReelRecord.IndexOf(_rowFeederExist);
            _bindingSource_ReelRecord.Position = pos;

            On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("The feeder serial number " + feederSrNr + "already exists."));
        }

        #endregion"Feeder fiel"

        private void textBox_ProgressBarData_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox_ProgressBarData.Text, out int j))
            {
                if (j <= 100)
                    progressBar_Test.Value = j;
            }
            else
                progressBar_Test.Value = 0;
        }
    }
}

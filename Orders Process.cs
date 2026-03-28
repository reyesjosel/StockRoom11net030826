using MyStuff11net;
using MyStuff11net.Properties;
using RawInput_dll;
using System.Data;
using System.Data.OleDb;
using static MyStuff11net.Custom_Events_Args;

namespace StockRoom11net
{
    public partial class Orders_Process : BaseTemple
    {
        static string DataBaseConnectionString = "";
        OleDbConnection GPS_DataSheetConnectionString;

        #region"On_ScannedData"
        string serialNumber = "";
        public void OnBarcodeScanned_EventHandler(object sender, RawInputEventArg e)
        {
            if (e == null)
                return;

            // If the application is not visible, do not processes the barcode event. 
            if (!Visible)
                return;

            #region"Scanned SerialNumber label"

            if (e.BarcodeData.Length == 8 && e.BarcodeData.StartsWith("GPS"))
            {
                try
                {
                    serialNumber = e.BarcodeData;

                    if (CheckIfExist(serialNumber))
                    {
                        SerialNumberAllreadyExist(serialNumber);
                        return;
                    }

                    AddNewRow(serialNumber);
                }
                catch (Exception error)
                {
                    using (var form1 = new Form { TopMost = true })
                    {
                        MessageBox.Show(form1, @"Message related to this error is " + error.Message,
                                               @"GPS DataSheet Test has generated an error.",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion"Scanned SerialNumber label"
        }
        #endregion

        public Orders_Process()
        {
            try
            {
                InitializeComponent();

            //    table_GPSDataSheetAdapter = new GPS_DataSheetTableAdapter();
                //Provider=Microsoft.Jet.OLEDB.4.0;Data Source="X:\ProductionManagement\GPS DataSheet.mdb"
                DataBaseConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.Combine(Settings.Default.DataBaseAddress, "GPS DataSheet.mdb");
                GPS_DataSheetConnectionString = new OleDbConnection(DataBaseConnectionString);

                GPS_DataSheetConnectionString.Open();
           //     table_GPSDataSheetAdapter.Connection = GPS_DataSheetConnectionString;
          //      _rowLoaded = table_GPSDataSheetAdapter.Fill(_dataSet_GPSDataSheet.GPS_DataSheet);
                GPS_DataSheetConnectionString.Close();
         //       _dataSet_GPSDataSheet.GPS_DataSheet.AcceptChanges();

                On_StatusBarMessage(new StatusBarMessage_EventArgs("Finished loading table StockRoom ... Rows loaded = " + _rowLoaded));
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is " + error.Message,
                                           @"GPS DataSheet has generated an error.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void Orders_Process_Load(object sender, EventArgs e)
        {
            InitializeDataGridViewBase(dataGridViewExtended_GPS);

            dataGridViewExtended_GPS.SaveRequested += DataGridViewExtended_GPS_SaveRequested;
            dataGridViewExtended_GPS.CellEndEditEvent += DataGridViewExtended_GPS_CellEndEditEvent;
            dataGridViewExtended_GPS.PreviewKeyDownEvent += DataGridViewExtended_GPS_PreviewKeyDownEvent;

            delayEndEdit = new System.Windows.Forms.Timer();
            delayEndEdit.Interval = 25;
            delayEndEdit.Tick += DelayEndEdit_Tick;
            delayEndEdit.Stop();
        }

        #region"DataGridViewExtended_GPS"

        void DataGridViewExtended_GPS_SaveRequested(object sender, Save_Requested_EventArgs e)
        {
            GPSDataSheetSaveRequest(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
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
                int lastdisplayedColumn = dataGridViewExtended_GPS.ColumnsCollection.Count - 4;

                if (cellEditEnd == lastdisplayedColumn)
                {
                    numberOfRowAdded++;
                    dataGridViewExtended_GPS.LockCurrentRow();
                    dataGridViewExtended_GPS.MarkUnerasableCurrentRow();
                    On_StatusBarMessage(new StatusBarMessage_EventArgs("A new item has been received, count = " + numberOfRowAdded));

                    if (numberOfRowAdded == 5)
                    {
                        numberOfRowAdded = 0;
                        GPSDataSheetSaveRequest(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
                        On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("New items have been stored."));
                    }

                    return;
                }

                SelectCellEditMode(cellEditEnd + 1);
            }
        }

        System.Windows.Forms.Timer delayEndEdit;
        void DataGridViewExtended_GPS_CellEndEditEvent(object sender, DataGridViewCellEventArgs e)
        {
            cellEditEnd = e.ColumnIndex;
            delayEndEdit.Start();
        }

        bool PreviewKeyDownEnter;
        void DataGridViewExtended_GPS_PreviewKeyDownEvent(object sender, PreviewKeyDownEventArgs e)
        {
            PreviewKeyDownEnter = (e.KeyCode == Keys.Enter);
        }

        bool CheckIfExist(string serialNumber)
        {
            DataRowView rowView = _bindingSource_GPSDataSheet.List.OfType<DataRowView>().ToList().Find(f => f["SerialNumber"].ToString().Equals(serialNumber, StringComparison.InvariantCultureIgnoreCase));
            if (rowView == null)
                return false;

            return true;
        }

        void AddNewRow(string serialNumber)
        {
            DataRowView addedRow = (DataRowView)_bindingSource_GPSDataSheet.AddNew();
            addedRow.Row.SetField("SerialNumber", serialNumber);
            addedRow.Row.SetField("DateTime", DateTime.Now);

            SelectCellEditMode(1);
        }

        void SelectCellEditMode(int index)
        {
            DataGridViewCell cell = dataGridViewExtended_GPS.CurrentRowActive.Cells[index];
            dataGridViewExtended_GPS._dataGridView.CurrentCell = cell;

            dataGridViewExtended_GPS.UnLockCurrentRow();
            dataGridViewExtended_GPS.MarkErasableCurrentRow();

            dataGridViewExtended_GPS._dataGridView.BeginEdit(false);
        }

        void SerialNumberAllreadyExist(string serialNumber)
        {
            DataRowView rowView = _bindingSource_GPSDataSheet.List.OfType<DataRowView>().ToList().Find(
                                  f => f["SerialNumber"].ToString().Equals(serialNumber, StringComparison.InvariantCultureIgnoreCase));

            if (rowView == null)
                return;

            int pos = _bindingSource_GPSDataSheet.IndexOf(rowView);
            _bindingSource_GPSDataSheet.Position = pos;

            On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("The serial number " + serialNumber + "already exists."));
        }

        #endregion"DataGridViewExtended_GPS"

        #region "Table_GPSDataSheet"

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

        void GPSDataSheet_ProcessSaveRequest(object sender, Save_Requested_EventArgs e)
        {
            switch (e.SaveEvent)
            {
                case MyCode.NotificationEvents.RowInformationChange:
                    {
                        if (Settings.Default.SaveEachTimeTheInformationIsChanged)
                        {
                            NeedSaveData = false;
                            GPSDataSheetSaveRequest(e);
                            break;
                        }

                        break;
                    }
                case MyCode.NotificationEvents.DataBaseUpDated:
                    {
                        //NotificationEvent will be up when the database is saved successfully.

                        NeedSaveData = false;
                        GPSDataSheetSaveRequest(e);
                        break;
                    }
                case MyCode.NotificationEvents.ClearAllSelected:
                    {
                   //     UpdateStatusColumn(_dataSet_GPSDataSheet.GPS_DataSheet);

                        break;
                    }
            }
        }

        public void GPSDataSheetSaveRequest(Save_Requested_EventArgs e)
        {
            try
            {
                if (!SaveGPSDataSheet_Requested())
                {
                    On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("Sorry, an error occurred while trying to save the database GPS datasheet."));
                    On_StatusBarMessage(new StatusBarMessage_EventArgs("Sorry, an error occurred while trying to save the database GPS datasheet."));
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

        public bool SaveGPSDataSheet_Requested()
        {
            try
            {
                _bindingSource_GPSDataSheet.EndEdit();

          //      UpdateStatusColumn(_dataSet_GPSDataSheet.GPS_DataSheet);

         //       changedRecordsTable = _dataSet_GPSDataSheet.GPS_DataSheet.GetChanges();
                if (changedRecordsTable != null)
                    RowsChanged = changedRecordsTable.Rows.Count;

      //          RowsSaved = table_GPSDataSheetAdapter.Update(_dataSet_GPSDataSheet.GPS_DataSheet);

                return true;
            }
            catch (Exception ex)
            {
        //        if (_dataSet_GPSDataSheet.GPS_DataSheet.HasErrors)
                {
                    _bindingSource_GPSDataSheet.Sort = "Status DESC";

      //              UpdateStatusColumnHasError(_dataSet_GPSDataSheet.GPS_DataSheet);
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

        #endregion "Table_GPSDataSheet"
    }
}

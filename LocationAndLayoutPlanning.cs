using MyStuff11net;
using MyStuff11net.DataGridViewExtend;
using MyStuff11net.Properties;
using RawInput_dll;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using CellClick_EventArgs = MyStuff11net.Custom_Events_Args.CellClick_EventArgs;
using CellDoubleClick_EventArgs = MyStuff11net.Custom_Events_Args.CellDoubleClick_EventArgs;
using CurrentRowActive_EventArgs = MyStuff11net.Custom_Events_Args.CurrentRowActive_EventArgs;
using DataGridViewMouseEnterEventArgs = MyStuff11net.Custom_Events_Args.DataGridViewMouseEnterEventArgs;
using DataGridViewSort_EventArgs = MyStuff11net.Custom_Events_Args.DataGridViewSort_EventArgs;
using Refresh_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Refresh_Requested_EventArgs;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;


namespace StockRoom11net
{
    public partial class LocationAndLayoutPlanning : BaseTemple
    {
        #region"On_ScannedData"

        public void OnBarcodeScanned(object sender, RawInputEventArg e)
        {
            if (e == null)
                return;

            if (!this.Visible)
                return;

            #region"Set Location field"

            if (CurrentEmployeesLogIn.IsManager && dataGridViewExtended.IsColumnVisible("BarCodeData"))
            {
                if (_currentColumnActive.ColumnName.Contains("BarCodeData"))
                {
                    _currentRowViewActive.Row[_currentColumnActive.ColumnName] = e.BarcodeData;
                    _bindingSourceLocations.Position++;
                    return;
                }
            }
            #endregion"Set Location field"

            #region"Scanned Location label"

            if (e.BarcodeData.Contains("LOCATION-7869"))
            {
                if (dataGridViewExtended.CustomFilter != null &&
                    dataGridViewExtended.CustomFilter.Contains("Location LIKE '" + e.BarcodeData + "'"))
                {
                    //  TabControl_Inventory.SelectTab(returnToTabpage);
                    //    if (_currentFocusedNodeproperties != null)
                    //        dataGridViewExtended.CustomFilter = _currentFocusedNodeproperties.StringFilter;
                    //    else
                    dataGridViewExtended.CustomFilter = "";
                    return;
                }

                dataGridViewExtended.CustomFilter = "Location LIKE '" + e.BarcodeData + "'";

                /*  if (TabControl_Inventory.SelectedTab.Name.Contains("tabPage_Location"))
                  {
                      return;
                  }
                  else
                  {
                      returnToTabpage = TabControl_Inventory.SelectedTab.Name;
                      TabControl_Inventory.SelectTab("tabPage_Location");
                      return;
                  }
                 */
            }

            #endregion"Scanned Location label"

            #region"Scanned PartNumber label"

            if (e.BarcodeData.Length == 15)
            {
                string partNumber = e.BarcodeData.Substring(0, 7);
                partNumber = partNumber.Insert(3, "-");

                if (dataGridViewExtended.CustomFilter != null &&
                    dataGridViewExtended.CustomFilter.Contains("PartNumber LIKE '*" + partNumber + "*'"))
                {
                    // TabControl_Inventory.SelectTab(returnToTabpage);
                    //   if (_currentFocusedNodeproperties != null)
                    //       dataGridViewExtended.CustomFilter = _currentFocusedNodeproperties.StringFilter;
                    //   else
                    dataGridViewExtended.CustomFilter = "";
                    return;
                }

                dataGridViewExtended.CustomFilter = "PartNumber LIKE '*" + partNumber + "*'";
                //  if (TabControl_Inventory.SelectedTab.Name.Contains("tabPage_Picturess"))
                //  {
                //      return;
                //  }
                //  else
                //  {
                //      returnToTabpage = TabControl_Inventory.SelectedTab.Name;
                // TabControl_Inventory.SelectTab("tabPage_Picturess");
                //      return;
                //  }
            }
            #endregion"Scanned PartNumber label"
        }

        #endregion

        #region"Properties"

        /// <summary>
        /// RenameDistFileName, true to rename with new fileName, false keep original fileName.
        /// </summary>
        bool RenameDistFileName;

        /// <summary>
        /// DeleteOriginalFile, true to delete the source file, false keep source file.
        /// </summary>
        bool DeleteOriginalFile;

        /// <summary>
        /// Reference to datatable were is saved all information.
        /// </summary>
        private DataTable table;

        private BindingSource _bindingSourceLocations;
        private BindingSource _bindingSourceLocationsTreeView;

        int _lastID;
        // If we are using a bindingsource, used this in Load procedure.
        //    table = ((DataSet)_bindingSource.DataSource).Tables[_bindingSource.DataMember];
        // We ask per the lastID just before used.
        //            if (table.Rows.Count > 0)
        //                LastID = (int)table.Compute("MAX(ID)", "ID is Not null");
        //            else
        //                LastID = 0;
        /// <summary>
        /// Top value for ID fiel, option filter to select a group of row.
        /// table.Compute("MAX(ID)", "filter condition"), itself inc.
        /// </summary>
        private int LastID
        {
            get
            {
                ++_lastID;
                return _lastID;
            }
            set
            {
                _lastID = value;

            }
        }

        /// <summary>
        /// Current rowView active in the dataGridViewExtended_Inventory,
        /// update on CurrentRowActive and MouseEnterEvent event.
        /// </summary>
        DataRowView _currentRowViewActive;

        #endregion"Properties"

        public LocationAndLayoutPlanning()
        {
            InitializeComponent();
        }

        public LocationAndLayoutPlanning(BindingSource bindingsourceLocations, BindingSource bindingsourceLocationsTreeView,
                                        Employee currentEmployeesLogIn, List<string> departList)
        {
            InitializeComponent();

            DepartList = departList;
            CurrentEmployeesLogIn = currentEmployeesLogIn;
            dataGridViewExtended.CurrentEmployeesLogIn = currentEmployeesLogIn;

            _bindingSourceLocations = bindingsourceLocations;
            _bindingSourceLocationsTreeView = bindingsourceLocationsTreeView;

            MessagePositionString = "tempDataTable";
            Type typeDataSource = bindingsourceLocations.DataSource.GetType();

            if (typeDataSource.BaseType == typeof(DataSet))
                table = ((DataSet)bindingsourceLocations.DataSource).Tables[bindingsourceLocations.DataMember];

            if (typeDataSource.BaseType == typeof(DataTable))
                table = bindingsourceLocations.DataSource as DataTable;

            MessagePositionString = "columnsCollection";
            ColumnsCollection = table.Columns;
        }

        void LocationAndLayoutPlanning_Load(object sender, EventArgs e)
        {
            MessagePositionString = "InitializeProperties()";
            InitializeProperties();

            InitializedPicturesBox();

            Intialize_DataGridView();
        }

        void LocationAndLayoutPlanning_Shown(object sender, EventArgs e)
        {

        }

        void InitializeProperties()
        {
            RenameDistFileName = Settings.Default.RenameDistFileName;

            DeleteOriginalFile = Settings.Default.DeleteOriginalFile;

        }

        #region"PicturesBox Initialized"

        private void InitializedPicturesBox()
        {
            PicturesBox_Image.DoubleClick += PicturesBoxImageDoubleClick;
            PicturesBox_Image.LoadProgressChanged += PicturesBoxImageLoadProgressChanged;
            PicturesBox_Image.LoadCompleted += PicturesBoxImageLoadCompleted;

            contextMenuStripPicturesBox.Opening += ContextMenuStripPicturesBoxOpening;
            toolStripMenuItem_SetToNoPicturesFound.Click += ToolStripMenuItemSetToNoPicturesFoundClick;
            toolStripMenuItem_AddANewPictures.Click += ToolStripMenuItemAddANewPicturesClick;
        }

        private void ToolStripMenuItemAddANewPicturesClick(object sender, EventArgs e)
        {
            PicturesBoxImageDoubleClick(new object(), new EventArgs());
        }

        private void ToolStripMenuItemSetToNoPicturesFoundClick(object sender, EventArgs e)
        {
            if (FilePathPicturesBoxImage != null)
                if (File.Exists(FilePathPicturesBoxImage))
                {
                    DialogResult = MessageBox.Show(@"Do you want save this Pictures?", "Save Pictures.",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    //Using FileInfo class copy the file.
                    FileInfo _fileInfo = new FileInfo(FilePathPicturesBoxImage);

                    if (DialogResult == System.Windows.Forms.DialogResult.Cancel)
                        return;

                    if (DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        #region"Yes, save the Pictures"

                        using (var openfile = new OpenFileDialogExt
                        {
                            Title = @"Please select any filename to save it Pictures.",
                            FileName = "",
                            Filter = @"*.jpg|*.jpg|*.png|*.png|*.gif|*.gif",
                            DefaultExt = "(*.jpg)|*.jpg",
                            CheckFileExists = false,
                            InitialDirectory = Settings.Default.DataBaseAddress + "\\Pictures\\",
                        }
                            )
                        {
                            if (openfile.ShowDialog(this) == DialogResult.Cancel)
                                return;

                            _fileInfo.CopyTo(openfile.FileName, true);
                        }

                        #endregion"Yes, save the Pictures"
                    }

                    _fileInfo.Delete();
                    PicturesBox_Image.ImageLocation = "";

                    string filePathRow = Settings.Default.DataBaseAddress + "\\Pictures\\" +
                                         _currentRowViewActive["ID"].ToString() + ".JPG";
                    if (File.Exists(filePathRow))
                        GetPicturesProccess(filePathRow);
                    else
                        GetPicturesProccess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Pictures_Found.jpg");
                }
        }

        private void ContextMenuStripPicturesBoxOpening(object sender, CancelEventArgs e)
        {
            contextMenuStripPicturesBox.Items.Clear();

            if (CurrentEmployeesLogIn.IsUser || CurrentEmployeesLogIn.IsEditor)
            {
                MessageBox.Show(@"Attention, the current user has not access level to do this operation.", @"Warning, Access Level violation.",
                                                                                                       MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            #region"IsManager or Administrator"

            if (CurrentEmployeesLogIn.IsAdministrator || CurrentEmployeesLogIn.IsManager)
            {
                if (FilePathPicturesBoxImage != null)
                    if (FilePathPicturesBoxImage.Contains("No_Pictures_Found.jpg"))
                    {
                        contextMenuStripPicturesBox.Items.AddRange(new ToolStripMenuItem[]
                                                                      {
                                                                          toolStripMenuItem_AddANewPictures,
                                                                      });
                    }
                    else
                    {
                        contextMenuStripPicturesBox.Items.AddRange(new ToolStripMenuItem[]
                                                                      {
                                                                          toolStripMenuItem_SetToNoPicturesFound,
                                                                      });

                    }
            }

            #endregion"IsManager or Administrator"

            if (CurrentEmployeesLogIn.EmployeeEnableTreeViewSetting == MyCode.EnableSetting.True)
            {

            }
        }

        private void PicturesBoxImageLoadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            On_StatusBarMessage(new StatusBarMessage_EventArgs("Loading a Pictures at " + e.ProgressPercentage + " %."));
        }

        private void PicturesBoxImageLoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            On_StatusBarMessage(new StatusBarMessage_EventArgs(""));
        }

        private void PicturesBoxImageDoubleClick(object sender, EventArgs e)
        {
            if (CurrentEmployeesLogIn.IsUser)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentRowViewActive == null)
                return;

            var directoryFile = new DirectoryFile();

            var fileName = directoryFile.CopyFileToPicture(_currentRowViewActive["ID"].ToString(), RenameDistFileName, DeleteOriginalFile);

            if (fileName != "")
                PicturesBox_Image.Image = _cache.GetBitmap(fileName);

        }

        private void GetPicturesProccess(string filePathString)
        {
            if (!PicturesBox_Image.Visible)
                return;

            if (filePathString == null)
                return;

            if (PicturesBox_Image.ImageLocation == filePathString)
                return;

            FilePathPicturesBoxImage = filePathString;
            PicturesBox_Image.ImageLocation = filePathString;
            PicturesBox_Image.Image = _cache.GetBitmap(filePathString);
        }

        private void GetLocationProccess(string filePathString)
        {
            //  if (PicturesBox_Location.Visible == false)
            //      return;

            if (filePathString == null)
                return;

            if (PicturesBox_Image.ImageLocation == filePathString)
                return;

            FilePathLocationBoxImage = filePathString;
            PicturesBox_Image.ImageLocation = filePathString;
            PicturesBox_Image.Image = _cache.GetBitmap(filePathString);
        }

        private void PrintImage_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += printDocument_PrintPage;
            printDocument.Print();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(PicturesBox_Image.Image, 0, 0);
        }

        // And save it:
        // by drawing image first on bitmap and then saving this bitmap
        public void ExportToBmp(string path)
        {
            using (var bitmap = new Bitmap(PicturesBox_Image.Width, PicturesBox_Image.Height))
            {
                PicturesBox_Image.DrawToBitmap(bitmap, PicturesBox_Image.ClientRectangle);
                bitmap.Save(path, ImageFormat.Bmp);
            }
        }


        #endregion"PicturesBox Initialized"

        #region"DataGridViewExtended"

        private void Intialize_DataGridView()
        {
            dataGridViewExtended.SuspendLayout();

            dataGridViewExtended.Name = this.Name;

            dataGridViewExtended.CellBegingEditEvent += DataGridViewExtendedInventoryCellBegingEditEvent;
            dataGridViewExtended.CellEndEditEvent += DataGridViewExtendedInventoryCellEndEditEvent;
            dataGridViewExtended.CellClickEvent += dataGridViewExtended_StockRoom_CellClick_Event;
            dataGridViewExtended.CellDoubleClickEvent += DataGridViewExtended_StockRoom_CellDoubleClick_Event;
            dataGridViewExtended.CurrentRowActivesEvent += DataGridViewExtendedInventoryCurrentRowActive;
            dataGridViewExtended.FindRemplace += dataGridViewExtended_Inventory_Find_Remplace;
            dataGridViewExtended.SaveRequested += DataGridViewExtendedInventorySaveRequested;
            dataGridViewExtended.RefreshRequested += DataGridViewExtendedInventoryRefreshRequested;
            dataGridViewExtended.UserDeletedRow += DataGridViewExtendedInventoryUserDeletedRow;
            dataGridViewExtended.RowsRemoved += DataGridViewExtendedInventoryRowsRemoved;
            dataGridViewExtended.DataGridViewMouseEnterEvent += DataGridViewExtendedInventoryMouseEnterEvent;
            dataGridViewExtended.DataGridViewSort += DataGridViewExtendedInventoryDataGridViewSort;
            dataGridViewExtended.BindingNavigatorAddNewItemEvent += dataGridViewExtended_Inventory_AddNewItemEvent;

            dataGridViewExtended.StatusBarMessage += DataGridViewExtendedInventoryStatusBarMessage;
            dataGridViewExtended.LogFileMessage += DataGridViewExtendedInventoryLogFileMessage;

            dataGridViewExtended.DataSource = _bindingSourceLocations;

            dataGridViewExtended.ResumeLayout();
        }

        private void dataGridViewExtended_Inventory_AddNewItemEvent(object sender, EventArgs e)
        {
            if (table.Rows.Count > 0)
                LastID = (int)table.Compute("MAX(ID)", "ID is Not null");
            else
                LastID = 0;

            //          e.AddedRow["ID"] = LastID;
            //          e.AddedRow["Index"] = e.AddedRow["ID"];
        }

        private void DataGridViewExtendedInventoryCellEndEditEvent(object sender, DataGridViewCellEventArgs e)
        {
            DataColumn column = _currentRowViewActive.DataView.Table.Columns[e.ColumnIndex];
            string partNumber = _currentRowViewActive["ID"].ToString();
            string description = "The information of " + partNumber + " has been updated.\r\n" +
                                 column.ColumnName + " " + _currentRowViewActive[column.ColumnName].ToString();

            NeedSaveData = true;
            _currentRowViewActive["LastAccessTime"] = DateTime.Now;
            _currentRowViewActive["ModifiedBy"] = CurrentEmployeesLogIn.FullName;

            On_NotificationsToSends(new Notification(
                                                     "Row information has been changed.",               //notification.Text
                                                     "Warning, Row information changed.",               //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)MyCode.NotificationEvents.RowInformationChange,//notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName,        //notification.String_Filter
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                                     partNumber,                                         //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));

            if (column.ColumnName.Contains("OnHand"))
            {
                int OnHold = MyCode.IntParseFast(_currentRowViewActive["OnHold"].ToString());
                if (OnHold < 0)
                    OnHold = 0;

                int OnHand = MyCode.IntParseFast(_currentRowViewActive["OnHand"].ToString());

                int OnAvailable = OnHand - OnHold;

                if (OnAvailable < 0)
                    OnAvailable = 0;

                _currentRowViewActive["OnAvailable"] = OnAvailable;
                _currentRowViewActive.EndEdit();

                ProcessSaveRequest(MyCode.NotificationEvents.RowInformationChange);
            }
        }

        private void DataGridViewExtendedInventoryCellBegingEditEvent(object sender, DataGridViewCellCancelEventArgs e)
        {
            _currentColumnActive = _currentRowViewActive.DataView.Table.Columns[e.ColumnIndex];

            string description = "The information of " + _currentRowViewActive["ID"].ToString() + " is being edited.\r\n" +
                                 _currentColumnActive.ColumnName + " " + _currentRowViewActive[_currentColumnActive.ColumnName].ToString();

            On_NotificationsToSends(new Notification(
                                                     "Row information is being edited.",                //notification.Text
                                                     "Warning, Row information is being edited.",       //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)MyCode.NotificationEvents.Warning,             //notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName,         //notification.DepartmentName
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        private void DataGridViewExtendedInventoryLogFileMessage(object sender, Custom_Events_Args.LogFileMessageEventArgs e)
        {
            On_LogFileMessage(e);
        }

        private void DataGridViewExtendedInventoryDataGridViewSort(object sender, DataGridViewSort_EventArgs e)
        {
            //   if (chart_Components.Visible)
            //       Start_EasyProgressBar_GraphicChart();
        }

        private void DataGridViewExtendedInventoryStatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        private void dataGridViewExtended_StockRoom_CellClick_Event(object sender, CellClick_EventArgs e)
        {
            _currentColumnActive = _currentRowViewActive.DataView.Table.Columns[e.ColumnIndex];
        }

        private void DataGridViewExtended_StockRoom_CellDoubleClick_Event(object sender, CellDoubleClick_EventArgs e)
        {

            if (CurrentEmployeesLogIn.IsUser)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentRowViewActive == null)
                return;

            On_CellDoubleClick_Event(e);
        }

        private void DataGridViewExtendedInventoryCurrentRowActive(object sender, CurrentRowActive_EventArgs e)
        {
            if (e.CurrentRowActive.Index == -1)
            {
                GetPicturesProccess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Pictures_Found.jpg");
                GetLocationProccess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Location_Found.jpg");
                return;
            }

            _currentRowViewActive = (DataRowView)e.CurrentRowActive.DataBoundItem;

            //   if (!dataGridViewExtended_Inventory.Bounds.Contains(dataGridViewExtended_Inventory.PointToClient(MousePosition)))
            //       return;

            var filePathRow = Settings.Default.DataBaseAddress + "\\Pictures\\" + _currentRowViewActive["ID"] + ".JPG";
            if (File.Exists(filePathRow))
                GetPicturesProccess(filePathRow);
            else
                GetPicturesProccess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Pictures_Found.jpg");

            var filePathLocation = Settings.Default.DataBaseAddress + "\\Pictures\\" + _currentRowViewActive["Location"] + ".JPG";
            if (File.Exists(filePathLocation))
                GetLocationProccess(filePathLocation);
            else
                GetLocationProccess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Location_Found.jpg");
        }

        private void dataGridViewExtended_Inventory_Find_Remplace(object sender, DataGridViewExtended.FindRemplaceEventArgs e)
        {

        }

        private void DataGridViewExtendedInventorySaveRequested(object sender, Save_Requested_EventArgs e)
        {
            ProcessSaveRequest(MyCode.NotificationEvents.DataBaseUpDated);
        }

        private void DataGridViewExtendedInventoryRefreshRequested(object sender, Refresh_Requested_EventArgs e)
        {
            if (_currentRowViewActive == null)
                On_Refresh_Requested(new Refresh_Requested_EventArgs("ID Like 'Is Not Null'"));
            else
            {
                //   if (_currentFocusedNodeproperties == null)
                //       On_Refresh_Requested(new Refresh_Requested_EventArgs("ID Like 'Is Not Null'"));
                //   else
                //       On_Refresh_Requested(new Refresh_Requested_EventArgs(_currentFocusedNodeproperties.StringFilter));
            }
        }

        private void DataGridViewExtendedInventoryUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells[0].Value == null)
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Error in row information."));
                return;
            }

            if (!e.Row.Cells[0].Value.ToString().Contains("-"))
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Error in row information."));
                return;
            }

            string filePath = Settings.Default.DataBaseAddress + "\\Pictures\\" + e.Row.Cells[0].Value.ToString() + ".JPG";

            if (!File.Exists(filePath))
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("No Pictures file was found."));
                return;
            }

            string[] source = new string[1];
            source[0] = filePath;

            ShellFileOperation fo = new ShellFileOperation();

            fo.Operation = ShellFileOperation.FileOperations.FO_DELETE;
            fo.OwnerWindow = this.Handle;
            fo.SourceFiles = source;

            if (fo.DoOperation())
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Pictures file was found and deleted."));
            else
                MessageBox.Show("Pictures file was found, but unable to be deleted.");

            //*****************************************************************************************************************

            string description = "The component " + e.Row.Cells[0].Value.ToString() + " has been deleted.";

            On_NotificationsToSends(new Notification(
                                                     "DataBase hass change.",                            //notification.Text
                                                     "Warning, DataBase change.",                        //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)MyCode.NotificationEvents.RowRemoved,          //notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName + ";",   //notification.String_Filter
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        private void DataGridViewExtendedInventoryRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //*****************************************************************************************************************

            string description = "The component " + "" + " has been removed.";

            On_NotificationsToSends(new Notification(
                                                     "DataBase has been change.",                        //notification.Text
                                                     "Warning, DataBase change.",                        //notification.Title
                                                     description,                                        //notification.Description
                                                     (int)ToolTipIcon.Info,                              //notification.MessageIcon
                                                     (int)MyCode.NotificationEvents.RowRemoved,          //notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName + ";",   //notification.String_Filter
                                                     DateTime.Now,                                       //notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     //notification.Created_by
                                                     "Properties",                                       //notification.Properties
                                                     "Status"                                            //notification.Status
                                                    ));
        }

        private void DataGridViewExtendedInventoryMouseEnterEvent(object sender, DataGridViewMouseEnterEventArgs e)
        {
            dataGridViewExtended._dataGridView.Focus();

            if (e.CurrentRowActive == null)
                return;

            if (e.CurrentRowActive.Index == -1)
                return;

            if (e.CurrentRowActive.Cells["ID"].Value == null)
                return;

            _currentRowViewActive = (DataRowView)e.CurrentRowActive.DataBoundItem;

            Update_Description(_currentRowViewActive);

            string filePathRow = Settings.Default.DataBaseAddress + "\\Pictures\\" +
                                                        e.CurrentRowActive.Cells["Picture"].Value.ToString() + ".JPG";
            if (File.Exists(filePathRow))
                GetPicturesProccess(filePathRow);
            else
                GetPicturesProccess(Settings.Default.DataBaseAddress + "\\Resources\\" + "No_Pictures_Found.jpg");
        }

        private void Update_Description(DataRowView currentRowview)
        {
            if (currentRowview == null)
                return;

            if (currentRowview["ID"] == null)
                return;

            if (_bindingSourceLocationsTreeView.Count == 0)
                return;

            #region"Description Short"

            string discription_short;
            discription_short = "<font color='Blue'><b>" + currentRowview["ID"] + "</b></font>    ->";

            if (currentRowview["Description"].ToString() == "")
                discription_short += "  This component has not any Description.";
            else
            {
                string tempDescription = currentRowview["Description"].ToString();
                if (tempDescription.Contains("&"))
                    tempDescription = tempDescription.Replace("&", "&amp;");

                discription_short += "<i>" + tempDescription + "</i>";
            }


            #endregion"Description Short"

            if (currentRowview["OnAvailable"] == DBNull.Value)
                currentRowview["OnAvailable"] = 0;

            string discriptionexpand = MyCode.DescriptionExpand(currentRowview["Who_uses_this"].ToString(), Font, CreateGraphics());
            if (discriptionexpand != null && discriptionexpand.Contains("Error Information"))
            {
                currentRowview["Status"] += "Selected(-36865)";
                currentRowview.Row.RowError = @"Column Who_uses_this have a error information." + discriptionexpand;
                currentRowview.EndEdit();
            }
        }



        #endregion"DataGridViewExtended"

        #region"Process Save Request"

        private void ProcessSaveRequest(MyCode.NotificationEvents saveEvent)
        {
            switch (saveEvent)
            {
                case MyCode.NotificationEvents.RowInformationChange:
                    {
                        if (Settings.Default.SaveEachTimeTheInformationIsChanged)
                        {
                            NeedSaveData = false;
                            SaveRequest();
                        }

                        break;
                    }
                case MyCode.NotificationEvents.DataBaseUpDated:
                    {
                        NeedSaveData = false;
                        SaveRequest();
                        break;
                    }

            }
        }

        private void SaveRequest()
        {
            try
            {
                On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));

                On_NotificationsToSends(new Notification(
                                                     "DataBase has been updated.",                       // 0 notification.Text
                                                     "Warning, DataBase updated.",                       // 1 notification.Title
                                                     "The database has been updated by an user.",        // 2 notification.Description
                                                     (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                                     (int)MyCode.NotificationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
                                                     Settings.Default.DepartmentName,         // 5 notification.String_Filter
                                                     DateTime.Now,                                       // 6 notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     // 7 notification.Created_by
                                                     "properties",                                       // 8 notification.Properties
                                                     "Status"                                            // 9 notification.Status
                                                    ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase. StockRoom Inventory.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        #endregion"Process Save Request"



























        private void UpDateInformation(Object sender, EventArgs e)
        {

        }









    }
}

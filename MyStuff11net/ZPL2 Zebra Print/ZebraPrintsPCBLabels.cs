using GenCode128;
using MyStuff11net.Properties;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static MyStuff11net.Custom_Events_Args;

namespace MyStuff11net.ZPL2ZebraPrint
{
    public partial class ZebraPrintsPCBLabels : Form
    {
        StringBuilder builderCommands;
        BindingSource bindingSource_Labels_SMT;

        IPEndPoint printerIP;
        readonly string IP = "10.1.1.249";

        string[] _labels;

        bool isdate;
        bool isStarting = true;
        bool isEncodeCode = true;
        int Counter;

        string Prefix;
        string Suffix;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BarcodeDatatoPrint { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescriptiontoPrint { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StartingValue { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int QuantitytoPrint { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime DateInfo { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal DarknessValue { get; set; }



        /// <summary>
        /// Limit of labels to be prints. Counter plus Quantity.
        /// </summary>
        int maxtoPrint;


        public ZebraPrintsPCBLabels()
        {
            InitializeComponent();

            _labels = new string[]
            {
                "^XA",
                "~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3~SD15^JUS^LRN^CI0",
                "^XZ",
                "^XA",
                "^MMT",
                "^LL0121",
                "^PW679",
                "^LS0",
                "^BY2,3,41^FT71,55^BCN,,Y,N",
                "^FD>;0140010123021312^FS",
                "^BY2,3,41^FT406,55^BCN,,Y,N",
                "^FD>;0140010123021312^FS",
                "^FT74,100^A0N,25,28^FH\\^FDIridium Desktop.^FS",
                "^FT409,100^A0N,25,28^FH\\^FDIridium Desktop.^FS",
                "^PQ1,0,1,Y",
                "^XZ",
                "^XA",
                "^MMT",
                "^LL0121",
                "^PW679",
                "^LS0",
                "^BY2,3,41^FT71,55^BCN,,Y,N",
                "^FD>;0140010123021312^FS",
                "^BY2,3,41^FT406,55^BCN,,Y,N",
                "^FD>;0140010123021312^FS",
                "^FT74,100^A0N,25,28^FH\\^FDIridium Desktop.^FS",
                "^FT409,100^A0N,25,28^FH\\^FDIridium Desktop.^FS",
                "^PQ1,0,1,Y",
                "^XZ",
                };

            DateInfo = DateTime.Now;
            isdate = true;
            BarcodeDatatoPrint = "";
            DescriptiontoPrint = "";
            QuantitytoPrint = 1;
            Counter = 0;
            maxtoPrint = Counter + QuantitytoPrint;
        }

        /// <summary>
        /// Inicializa new ZebraPrints instancy.
        /// </summary>
        /// <param name="BarcodeData"></param>
        /// <param name="Description"></param>
        /// <param name="Quantity"></param>
        public ZebraPrintsPCBLabels(BindingSource bindingSourceLabelsSMT)
        {
            InitializeComponent();

            bindingSource_Labels_SMT = new BindingSource();
            bindingSource_Labels_SMT = bindingSourceLabelsSMT;

            BarcodeDatatoPrint = "1101061";
            DescriptiontoPrint = "Test Description";
            QuantitytoPrint = 4;
            Counter = 1;
            maxtoPrint = Counter + QuantitytoPrint;

            numericUpDown_StartingValue.Value = Counter;
            numericUpDown_Quantity.Value = QuantitytoPrint;

            DateInfo = DateTime.Now;
            isdate = true;

            builderCommands = new StringBuilder();

            dataGridViewExtendedInitialize();
        }

        public ZebraPrintsPCBLabels(string barcodeDatatoPrint, string descriptiontoPrint, int counterStartValue, int quantitytoPrint)
        {
            InitializeComponent();

            BarcodeDatatoPrint = barcodeDatatoPrint;
            DescriptiontoPrint = descriptiontoPrint;
            QuantitytoPrint = quantitytoPrint;
            Counter = counterStartValue;
            maxtoPrint = Counter + QuantitytoPrint;

            numericUpDown_StartingValue.Value = Counter;
            numericUpDown_Quantity.Value = QuantitytoPrint;

            DateInfo = DateTime.Now;
            isdate = true;

            builderCommands = new StringBuilder();
        }

        public ZebraPrintsPCBLabels(string barcodeDatatoPrint, string descriptiontoPrint, int counterStartValue, int quantitytoPrint, DateTime date)
        {
            InitializeComponent();

            BarcodeDatatoPrint = barcodeDatatoPrint;
            DescriptiontoPrint = descriptiontoPrint;
            QuantitytoPrint = quantitytoPrint;
            Counter = counterStartValue;
            maxtoPrint = Counter + QuantitytoPrint;

            numericUpDown_StartingValue.Value = Counter;
            numericUpDown_Quantity.Value = QuantitytoPrint;

            DateInfo = date;
            isdate = true;

            builderCommands = new StringBuilder();
        }

        private void EPL2_Zebra_Prints_Load(object sender, EventArgs e)
        {
            button_Print.Enabled = false;
            textBox_BarCode_Prefix.Text = Prefix;
            textBox_BarCode_Data.Text = BarcodeDatatoPrint;
            textBox_Suffix.Text = Suffix;
            numericUpDown_StartingValue.Value = Counter;
            numericUpDown_Quantity.Value = QuantitytoPrint;
            textBox_Description.Text = DescriptiontoPrint;
            ShowBarCodeImage(BarcodeDatatoPrint + Counter);

            numericUpDown_DarknessValue.Value = Settings.Default.ZebraPrintsDarknessValue;

            isStarting = false;

            button_Print.Enabled = true;
            richTextBox_ZPL.Text = Contruct_Labels();
        }

        #region"DataGridView"

        void dataGridViewExtendedInitialize()
        {
            _dataGridViewLabelsSMT.SuspendLayout();

            _dataGridViewLabelsSMT.Name = "EmployeesDepartment";

            _dataGridViewLabelsSMT.CellBegingEditEvent += DataGridViewLabelsSMTCellBegingEditEvent;
            //dataGridViewExtended_Employees.CellEndEditEvent     += DataGridViewExtendedInventoryCellEndEditEvent;
            //dataGridViewExtended_Employees.CellClickEvent       += dataGridViewExtended_StockRoom_CellClick_Event;
            //dataGridViewExtended_Employees.CellDoubleClickEvent += DataGridViewExtended_StockRoom_CellDoubleClick_Event;
            _dataGridViewLabelsSMT.CurrentRowActivesEvent += dataGridViewLabelsSMT_CurrentRowActive;
            //dataGridViewExtended_Employees.FindRemplace         += dataGridViewExtended_Inventory_Find_Remplace;
            _dataGridViewLabelsSMT.RefreshRequested += dataGridViewLabelsSMT_Refresh_Requested;
            //dataGridViewExtended_Employees.UserDeletedRow       += DataGridViewExtendedInventoryUserDeletedRow;
            //dataGridViewExtended_Employees.RowsRemoved          += DataGridViewExtendedInventoryRowsRemoved;
            //dataGridViewExtended_Employees.MouseEnterEvent      += DataGridViewExtendedInventoryMouseEnterEvent;
            //dataGridViewExtended_Employees.DataGridViewSort     += DataGridViewExtendedInventoryDataGridViewSort;
            _dataGridViewLabelsSMT.BindingNavigatorAddNewItemEvent += DataGridViewLabelsSMT_AddNewItemEvent;

            //dataGridViewExtended_Employees.LogFileMessage       += dataGridViewExtended_EmployeesLogFileMessage;

            _dataGridViewLabelsSMT.DataSource = bindingSource_Labels_SMT;

            _dataGridViewLabelsSMT.ResumeLayout();

            _dataGridViewLabelsSMT._dataGridView.ReadOnly = false;
            _dataGridViewLabelsSMT.CustomEdit = MyCode.EditMode.Delete;

        }

        void DataGridViewLabelsSMTCellBegingEditEvent(object sender, DataGridViewCellCancelEventArgs e)
        {
            // _currentColumnActive = CurrentDataColumnActive(e.ColumnIndex);
            /*
            if (CurrentEmployeesLogIn.IsUser)
            {
                MessageBox.Show(@"The current User, does not have the right to perform this action.",
                                 @"Warning, access denied.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            if (_currentColumnActive == null)
                return;
            */
        }

        void dataGridViewLabelsSMT_Refresh_Requested(object sender, Refresh_Requested_EventArgs e)
        {
            try
            {
                //  On_Refresh_Requested(new Refresh_Requested_EventArgs(bindingSource_Labels_SMT.Filter));
                //  NeedSaveData = false;
            }
            catch (Exception)
            {

            }
        }

        void dataGridViewLabelsSMT_CurrentRowActive(object sender, CurrentRowActive_EventArgs e)
        {
            if (e.CurrentRowActive == null || e.CurrentRowActive.Index == -1)
                return;

            DataRowView currentRow = (DataRowView)bindingSource_Labels_SMT[e.CurrentRowActive.Index];
            /*
            if (currentRow["Department"].ToString().Contains("Department"))
            {
                DepartmentSelected = new DepartmentInformation(currentRow);
                DepartmentSelected.Save_Requested -= EmployeesDepartmentSelected_SaveRequested;
                DepartmentSelected.Save_Requested += EmployeesDepartmentSelected_SaveRequested;

                InitializeUI_Department(DepartmentSelected);
            }
            else
            {
                EmployeesSelected = new Employee(currentRow);
                EmployeesSelected.Save_Requested -= EmployeesDepartmentSelected_SaveRequested;
                EmployeesSelected.Save_Requested += EmployeesDepartmentSelected_SaveRequested;

                InitializeUI_Employee(EmployeesSelected);
            }
            */
        }

        void EmployeesDepartmentSelected_SaveRequested(object sender, Save_Requested_EventArgs e)
        {
            try
            {
                // On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotifycationEvents.DataBaseUpDated));
                // NeedSaveData = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase. Employees Management.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        void DataGridViewLabelsSMT_AddNewItemEvent(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        void AddNewRecord()
        {
            DataRowView addedRow = (DataRowView)bindingSource_Labels_SMT.AddNew();
            addedRow.Row.SetField("PartNumber", BarcodeDatatoPrint);
            addedRow.Row.SetField("Description", DescriptiontoPrint);
            addedRow.Row.SetField("StartingValue", StartingValue);
            addedRow.Row.SetField("QuantityToPrint", QuantitytoPrint);
            addedRow.Row.SetField("Darkness", numericUpDown_DarknessValue.Value);
        }

        #endregion"DataGridView"

        public bool Prints()
        {
            return PrintLabels(Contruct_Labels());
        }

        private bool PrintLabels(string labelsCommand)
        {
            bool result;
            NetworkStream ns = null;
            Socket socket = null;

            try
            {
                if (printerIP == null)
                    printerIP = new IPEndPoint(IPAddress.Parse(IP), 9100);

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(printerIP);

                ns = new NetworkStream(socket);

                byte[] toSend = Encoding.ASCII.GetBytes(labelsCommand);

                ns.Write(toSend, 0, toSend.Length);

                result = true;

            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                if (ns != null)
                    ns.Close();

                if (socket != null && socket.Connected)
                    socket.Close();
            }

            return result;
        }

        private string Contruct_Labels()
        {
            bool isFirst = true;

            #region"Inicializa the Printers..."

            string darknessValue = "SD" + DarknessValue;

            string[] _inicialitation = new string[]
            {
                "^XA",
                "~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3~" + darknessValue + "^JUS^LRN^CI0",
                "^XZ",
             };

            foreach (string value in _inicialitation)
            {
                builderCommands.Append(value + "\r\n");
            }

            #endregion"Inicializa Prints"

            #region"EncodeCode"
            //Always false, I will not use, but keep the code.
            isEncodeCode = false;
            if (isEncodeCode)
            {
                string Code = "";
                string PartNumber = BarcodeDatatoPrint.Replace("-", "");

                if (PartNumber.Length > 7)
                    PartNumber = (PartNumber.Remove(7)).Remove(0, 3);
                else
                    if (PartNumber.Length > 3)
                        PartNumber = PartNumber.Remove(0, 3);

                if (BarcodeDatatoPrint.Length > 3)
                {
                    if (Enum.IsDefined(typeof(MyCode.EncodeCode), Convert.ToInt32(BarcodeDatatoPrint.Substring(0, 3))))
                        Code = "" + (MyCode.EncodeCode)Convert.ToInt32(BarcodeDatatoPrint.Substring(0, 3));
                    else
                    {
                        Code = BarcodeDatatoPrint.Substring(0, 3);
                        MessageBox.Show("The code " + BarcodeDatatoPrint.Substring(0, 3) + " is not defined", "Code no defined.",
                                                                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                BarcodeDatatoPrint = Code + PartNumber;
            }
            #endregion"EncodeCode"

            else
            {
                BarcodeDatatoPrint = BarcodeDatatoPrint.Replace("-", "");
                if (BarcodeDatatoPrint.Length > 7)
                    BarcodeDatatoPrint = BarcodeDatatoPrint.Remove(7);
            }

            while (Counter < maxtoPrint)
            {
                string[] Label = LabelsData();

                if (isFirst)
                {
                    string humanreadable = Label[6].Replace("^FD>;", "");

                    if (humanreadable.Contains(">6"))
                    {
                        int indexW = humanreadable.IndexOf(">6", 0, humanreadable.Length);
                        string sub = humanreadable.Substring(indexW, 2);
                        humanreadable = humanreadable.Replace(sub, "");
                    }

                    humanreadable = humanreadable.Replace("^FS", "");

                    ShowBarCodeImage(humanreadable);
                    label_HumanReadableInformation.Text = humanreadable;
                    label_HumanReadableInformation_2.Text = humanreadable;

                    Graphics g = grouper_BarCode.CreateGraphics();
                    _ = g.MeasureString(humanreadable, label_HumanReadableInformation.Font);

                    int X_LabelLocation = (int)((grouper_Label.Width - label_HumanReadableInformation.Width) / 2) - 4;

                    label_HumanReadableInformation.Location = new Point(X_LabelLocation, label_HumanReadableInformation.Location.Y);
                    label_HumanReadableInformation_2.Location = new Point(X_LabelLocation, label_HumanReadableInformation_2.Location.Y);

                    isFirst = false;
                }

                foreach (string value in Label)
                {
                    if (value == null)
                        continue;

                    builderCommands.Append(value + "\r\n");
                }

            }
            Counter = 0;
            return builderCommands.ToString();
        }

        private string[] LabelsData()
        {
            int ptos_Caracter = 11;

            #region"Label"

            string[] _label = new string[]
             {
                "^XA",          // #0
                "^MMT",         // #1
                "^LL0121",      // #2
                "^PW679",       // #3
                "^LS0",         // #4
                "^BY2,3,41^FT35,55^BCN,,Y,N",   // #5
                "BarcodeData",                  // #6 ^FD----^FS
                "^BY2,3,41^FT370,55^BCN,,Y,N",  // #7
                "BarcodeData",                  // #8 ^FD----^FS
                "^FT74,98^A0N,25,28^FH\\^FDIridium Desktop.^FS",   // #9
                "^FT409,98^A0N,25,28^FH\\^FDIridium Desktop.^FS",  // #10
                "^PQ1,0,1,Y",                   // #11
                "^XZ",                          // #12
                 };

            #endregion"Label"       

            int posX = (300 - (DescriptiontoPrint.Length * ptos_Caracter)) / 2;

            _label[9] = _label[9].Replace("74", posX.ToString());
            _label[10] = _label[10].Replace("409", (posX + 335).ToString());

            _label[6] = ReplaceBarCodeDataCounter(Counter, BarcodeDatatoPrint);

            #region"Date (Month and Year"

            if (isdate)
            {
                string month;
                if (DateInfo.Month > 9)
                    month = DateInfo.Month.ToString();
                else
                    month = "0" + DateInfo.Month.ToString();

                //   _label[6] += (FileSystemExt.EncodeMonth)Date_Info.Month + month + (FileSystemExt.EncodeYear)Date_Info.Year;
                _label[6] += month + DateInfo.Year.ToString().Remove(0, 2);
            }

            #endregion"Date (Month and Year"
            // ^FD Fiel Data start and ^FS fiel stop.
            // >9 Code 128 Subset A     (Numeric Pairs give Alpha/Numerics)
            string label6_Data = "^FD>;";   // >: Code 128 Subset B     (Normal Alpha/Numeric)
                                            // >; Code 128 Subset C     (All numeric (00 - 99)
            int numNumber = 0;
            for (int position = 0; position < _label[6].Length; position++)
            {
                label6_Data += _label[6].ElementAt(position);

                if (char.IsNumber(_label[6], position))
                {
                    numNumber++;
                    if (numNumber == 14)
                    {                               // >5 Select Subset C.
                        label6_Data += ">6";        // >6 Select Subset B.
                        numNumber = 0;              // >7 Select Subset A.
                    }
                }
                else
                {
                    MessageBox.Show("Wrong information in Barcode data.", "Error in data.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }

            _label[6] = label6_Data + "^FS";

            _label[9] = _label[9].Replace("Iridium Desktop.", DescriptiontoPrint);

            Counter++;

            if (Counter == maxtoPrint)
            {
                _label[7] = null;
                _label[8] = null;
                _label[10] = null;
            }
            else
            {
                _label[8] = ReplaceBarCodeDataCounter(Counter, BarcodeDatatoPrint);

                #region"Date Month and Year"

                if (isdate)
                {
                    string month;
                    if (DateInfo.Month > 9)
                        month = DateInfo.Month.ToString();
                    else
                        month = "0" + DateInfo.Month.ToString();

                    //   _label[9] += (FileSystemExt.EncodeMonth)Date_Info.Month + month + (FileSystemExt.EncodeYear)Date_Info.Year;
                    _label[8] += month + DateInfo.Year.ToString().Remove(0, 2);
                }

                #endregion"Date Month and Year"

                // ^FD Fiel Data start and ^FS fiel stop.
                // >9 Code 128 Subset A     (Numeric Pairs give Alpha/Numerics)
                string label8_Data = "^FD>;";   // >: Code 128 Subset B     (Normal Alpha/Numeric)
                // >; Code 128 Subset C     (All numeric (00 - 99)
                int numNumber8 = 0;
                for (int position = 0; position < _label[8].Length; position++)
                {
                    label8_Data += _label[8].ElementAt(position);

                    if (char.IsNumber(_label[8], position))
                    {
                        numNumber8++;
                        if (numNumber8 == 14)
                        {                               // >5 Select Subset C.
                            label8_Data += ">6";        // >6 Select Subset B.
                            numNumber8 = 0;              // >7 Select Subset A.
                        }

                    }
                    else
                    {
                        MessageBox.Show("Wrong information in Barcode data.", "Error in data.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }

                _label[8] = label8_Data + "^FS";

                _label[10] = _label[10].Replace("Iridium Desktop.", DescriptiontoPrint);
            }

            Counter++;

            return _label;
        }

        static string ReplaceBarCodeDataCounter(int counter, string barCode)
        {
            string barCodeDataInfo = "";

            if (counter < 10)
                barCodeDataInfo = barCode + "000" + counter;
            else
                if (counter < 100)
                    barCodeDataInfo = barCode + "00" + counter;
                else
                    if (counter < 1000)
                        barCodeDataInfo = barCode + "0" + counter;
                    else
                        if (counter > 999)
                            barCodeDataInfo = barCode + counter;

            return barCodeDataInfo;
        }

        private void ShowBarCodeImage(string value)
        {
            try
            {
                pictureBox_BarCode_Image.Image = Code128Rendering.MakeBarcodeImage(value, 1, true);
                pictureBox_BarCode_Image_2.Image = pictureBox_BarCode_Image.Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text);
            }
        }

        private void TextBox_BarCode_Prefix_TextChanged(object sender, EventArgs e)
        {
            Prefix = textBox_BarCode_Prefix.Text;

            Any_TextChanged();
        }

        private void TextBox_BarCode_Data_TextChanged(object sender, EventArgs e)
        {
            BarcodeDatatoPrint = textBox_BarCode_Data.Text;

            Any_TextChanged();
        }

        private void TextBox_Suffix_TextChanged(object sender, EventArgs e)
        {
            Suffix = textBox_Suffix.Text;

            Any_TextChanged();
        }

        private void NumericUpDown_StartingValue_ValueChanged(object sender, EventArgs e)
        {
            StartingValue = (int)numericUpDown_StartingValue.Value;

            Any_TextChanged();
        }

        private void NumericUpDown_Quantity_ValueChanged(object sender, EventArgs e)
        {
            QuantitytoPrint = (int)numericUpDown_Quantity.Value;

            Any_TextChanged();
        }

        private void TextBox_Description_TextChanged(object sender, EventArgs e)
        {
            DescriptiontoPrint = textBox_Description.Text;

            Any_TextChanged();
        }

        private void Any_TextChanged()
        {
            if (isStarting)
                return;

            button_Print.Enabled = false;

            builderCommands.Clear();

            Counter = (int)numericUpDown_StartingValue.Value;

            QuantitytoPrint = (int)numericUpDown_Quantity.Value;

            BarcodeDatatoPrint = textBox_BarCode_Data.Text;

            maxtoPrint = Counter + QuantitytoPrint;

            richTextBox_ZPL.Clear();
            richTextBox_ZPL.Text = Contruct_Labels();

            button_Print.Enabled = true;
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            button_Print.Enabled = false;

            if (PrintLabels(richTextBox_ZPL.Text))
                AddNewRecord();
        }

        private void CheckBox_print_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_print.Checked)
                isdate = true;
            else
                isdate = false;
        }

        private void CheckBox_EncodeCode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_EncodeCode.Checked)
                isEncodeCode = true;
            else
                isEncodeCode = false;
        }

        private void NumericUpDown_DarknessValue_ValueChanged(object sender, EventArgs e)
        {
            DarknessValue = numericUpDown_DarknessValue.Value;

            Settings.Default.ZebraPrintsDarknessValue = numericUpDown_DarknessValue.Value;
            Settings.Default.Save();
        }
    }
}

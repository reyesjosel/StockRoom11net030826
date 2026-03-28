using GenCode128;
using MyStuff11net;
using MyStuff11net.Properties;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static MyStuff11net.Custom_Events_Args;
using System.ComponentModel;

namespace StockRoom11net
{
    public partial class LabelsPrintsSMT : BaseTemple
    {
        #region"Properties"

        StringBuilder builderCommands;

        IPEndPoint printerIP;
        readonly string IP = "10.1.1.249";

        bool isdate;
        bool isStarting = true;
        bool isEncodeCode = true;
        int Counter;

        /// <summary>
        /// Limit of labels to be prints. Counter plus Quantity.
        /// </summary>
        int maxtoPrint;

        #endregion"Properties"

        #region"Public Properties"
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

        #endregion"Public Properties"

        public LabelsPrintsSMT(BindingSource bindingSourceLabelsSMT, CurrentDeptUserBroadcast_EventArgs currentDeptUser)
        {
            InitializeComponent();

            BindingSourceTreeViewBase = bindingSourceLabelsSMT;

            BarcodeDatatoPrint = "BarCodeData";
            DescriptiontoPrint = "";
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

        private void LabelsPrintsSMT_Load(object sender, EventArgs e)
        {
            button_Print.Enabled = false;

            numericUpDown_StartingValue.Value = Counter;
            numericUpDown_Quantity.Value = QuantitytoPrint;
            textBox_Description.Text = DescriptiontoPrint;
            ShowBarCodeImage(BarcodeDatatoPrint + Counter);

            numericUpDown_DarknessValue.Value = Settings.Default.ZebraPrintsDarknessValue;

            isStarting = false;

            button_Print.Enabled = true;

            Description_ListUsedDescriptionEnable(false, Color.Linen);
            ListBox_PreviosUsedDescription.DataSource = BindingSourceTreeViewBase;
            ListBox_PreviosUsedDescription.DisplayMember = "Description";

            BindingSourceTreeViewBase.Filter = null;


        }

        #region"DataGridView"

        void dataGridViewExtendedInitialize()
        {
            _dataGridViewLabelsSMT.SuspendLayout();

            dataGridViewExtendedBase = _dataGridViewLabelsSMT;

            _dataGridViewLabelsSMT.Name = "PrintLabelSMT";

            _dataGridViewLabelsSMT.CurrentRowActivesEvent += dataGridViewLabelsSMT_CurrentRowActive;
            _dataGridViewLabelsSMT.RefreshRequested += dataGridViewLabelsSMT_Refresh_Requested;
            _dataGridViewLabelsSMT.BindingNavigatorAddNewItemEvent += DataGridViewLabelsSMT_AddNewItemEvent;

            _dataGridViewLabelsSMT.DataSource = BindingSourceTreeViewBase;

            _dataGridViewLabelsSMT.ResumeLayout();

            //_dataGridViewLabelsSMT._dataGridView.ReadOnly = false;
            //_dataGridViewLabelsSMT.CustomEdit = MyCode.EditMode.Delete;

        }

        void dataGridViewLabelsSMT_Refresh_Requested(object sender, Refresh_Requested_EventArgs e)
        {
            try
            {
                On_Refresh_Requested(new Refresh_Requested_EventArgs(BindingSourceTreeViewBase.Filter));
                NeedSaveData = false;
            }
            catch (Exception)
            {

            }
        }

        void dataGridViewLabelsSMT_CurrentRowActive(object sender, CurrentRowActive_EventArgs e)
        {
            if (e.CurrentRowActive == null || e.CurrentRowActive.Index == -1)
                return;

            DataRowView currentRow = (DataRowView)BindingSourceTreeViewBase[e.CurrentRowActive.Index];
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

        void DataGridViewLabelsSMT_AddNewItemEvent(object sender, EventArgs e)
        {
            AddNewRecord();
        }

        #endregion"DataGridView"

        void AddNewRecord()
        {
            DataRowView addedRow = (DataRowView)BindingSourceTreeViewBase.AddNew();
            addedRow.Row.SetField("PartNumber", textBox_PartNumber_Data.Text);
            addedRow.Row.SetField("Description", DescriptiontoPrint);
            addedRow.Row.SetField("StartingValue", StartingValue);
            addedRow.Row.SetField("QuantityToPrint", Counter);
            addedRow.Row.SetField("Darkness", numericUpDown_DarknessValue.Value);
            addedRow.Row.SetField("DateCreated", DateTime.Now);
            addedRow.Row.SetField("BackUpField1", CurrentEmployeesLogIn.Name);
            addedRow.Row.EndEdit();
        }

        void LabelsPrintsSMT_SaveRequested(object sender, Save_Requested_EventArgs e)
        {
            try
            {
                On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
                NeedSaveData = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de salvar la DataBase" + ex.Message, @"Error on DataBase. Employees Management.",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        #region"Print's Process"

        void Button_Print_Click(object sender, EventArgs e)
        {
            button_Print.Enabled = false;

            if ((int)numericUpDown_Quantity.Value == 0)
            {
                AddNewRecord();
                LabelsPrintsSMT_SaveRequested(sender, new Save_Requested_EventArgs(MyCode.NotificationEvents.RowAdded));
                Close();
                return;
            }

            if (Prints())
            {
                AddNewRecord();
                LabelsPrintsSMT_SaveRequested(sender, new Save_Requested_EventArgs(MyCode.NotificationEvents.RowAdded));
            }
        }

        public bool Prints()
        {
            return PrintLabels(Contruct_Labels());
        }

        bool PrintLabels(string labelsCommand)
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

        string Contruct_Labels()
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

                    int X_LabelLocation = (int)((grouper_BarCode.Width - label_HumanReadableInformation.Width) / 2) - 4;

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

        string[] LabelsData()
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

            #region"Description"

            label_Description.Text = label_Description_2.Text = DescriptiontoPrint;

            _label[9] = _label[9].Replace("Iridium Desktop.", DescriptiontoPrint);

            int posX = (300 - (DescriptiontoPrint.Length * ptos_Caracter)) / 2;
            _label[9] = _label[9].Replace("74", posX.ToString());
            _label[10] = _label[10].Replace("409", (posX + 335).ToString());

            #endregion"Description"

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

        void ShowBarCodeImage(string value)
        {
            try
            {
                pictureBox_BarCode_Image.Image = Code128Rendering.MakeBarcodeImage(value, 1, true);
                pictureBox_BarCode_Image_2.Image = pictureBox_BarCode_Image.Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, this.Text);
            }
        }

        void TextBox_PartNumber_Data_TextChanged(object sender, EventArgs e)
        {
            if (textBox_PartNumber_Data.Text.Length == 0)
                Description_ListUsedDescriptionEnable(false, Color.Linen);
            else
                Description_ListUsedDescriptionEnable(true, Color.White);

            BindingSourceTreeViewBase.Filter = "PartNumber LIKE '*" + textBox_PartNumber_Data.Text + "*'";

            Any_TextChanged();
        }

        bool descriptionProcessing = false;
        void TextBox_Description_TextChanged(object sender, EventArgs e)
        {
            if (descriptionProcessing)
                return;

            descriptionProcessing = true;

            int _characterLess = 25 - textBox_Description.Text.Length;

            if (textBox_Description.Text.Length > 25)
            {
                label_Text_Description.Text = "Description Information." + "            Maximum description length is 25 characters.";
                textBox_Description.Text = textBox_Description.Text.Remove((textBox_Description.Text.Length - 1));
                descriptionProcessing = false;
                return;
            }
            else
                if (textBox_Description.Text.Length <= 25)//label_Text_Description.Text.Contains("Maximum") & 
            {
                label_Text_Description.Text = "Description Information." + "            Characters available : " + _characterLess;
                descriptionProcessing = false;
            }

            DescriptiontoPrint = textBox_Description.Text;

            Any_TextChanged();
        }

        void NumericUpDown_StartingValue_ValueChanged(object sender, EventArgs e)
        {
            StartingValue = (int)numericUpDown_StartingValue.Value;

            Any_TextChanged();
        }

        void NumericUpDown_Quantity_ValueChanged(object sender, EventArgs e)
        {
            QuantitytoPrint = (int)numericUpDown_Quantity.Value;

            Any_TextChanged();
        }

        void Any_TextChanged()
        {
            if (isStarting)
                return;

            button_Print.Enabled = false;

            builderCommands.Clear();

            Counter = (int)numericUpDown_StartingValue.Value;

            QuantitytoPrint = (int)numericUpDown_Quantity.Value;

            BarcodeDatatoPrint = textBox_PartNumber_Data.Text;

            maxtoPrint = Counter + QuantitytoPrint;

            button_Print.Enabled = true;

            Contruct_Labels();
        }

        void CheckBox_print_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_print.Checked)
                isdate = true;
            else
                isdate = false;
        }

        void NumericUpDown_DarknessValue_ValueChanged(object sender, EventArgs e)
        {
            DarknessValue = numericUpDown_DarknessValue.Value;

            Settings.Default.ZebraPrintsDarknessValue = numericUpDown_DarknessValue.Value;
            Settings.Default.Save();
        }

        void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ListBox_PreviosUsedDescription.Focused)
                return;

            if (ListBox_PreviosUsedDescription.SelectedValue == DBNull.Value)
                return;

            if (ListBox_PreviosUsedDescription.SelectedIndex == -1)
                return;

            for (int i = 0; i < ListBox_PreviosUsedDescription.Items.Count; i++)
            {
                Point mousePosition = ListBox_PreviosUsedDescription.PointToClient(MousePosition);
                if (ListBox_PreviosUsedDescription.GetItemRectangle(i).Contains(mousePosition))
                {
                    textBox_Description.Text = (string)ListBox_PreviosUsedDescription.SelectedValue;
                    break;
                }
            }
        }

        void Description_ListUsedDescriptionEnable(bool enabled, Color backColor)
        {
            textBox_Description.Enabled = enabled;
            textBox_Description.BackColor = backColor;
            ListBox_PreviosUsedDescription.Enabled = enabled;
            ListBox_PreviosUsedDescription.BackColor = backColor;
            grouper_PrintInformation.Enabled = enabled;
            grouper_PrintSettings.Enabled = enabled;
        }

        void ListBox_PreviosUsedDescription_Format(object sender, ListControlConvertEventArgs e)
        {
            // Assuming your class called Scores
            string partNumber = ((DataRowView)e.ListItem)["PartNumber"].ToString();
            string description = ((DataRowView)e.ListItem)["Description"].ToString();
            string quantityToPrint = ((DataRowView)e.ListItem)["QuantityToPrint"].ToString();
            string employeeName = ((DataRowView)e.ListItem)["BackUpField1"].ToString();
            string dateTime = ((DataRowView)e.ListItem)["DateCreated"].ToString();

            e.Value = partNumber + ",  " + description + ",  Qty Printed : " + quantityToPrint + " by " + employeeName + " on " + dateTime;
        }

        #endregion"Print's Process"


    }
}

using GenCode128;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyStuff11net.ZPL2_Zebra_Print
{

    public partial class Zebra_Prints_PCBLabels : Form
    {
        StringBuilder builderCommands;

        IPEndPoint printerIP;

        string IP = "10.1.1.249";

        string[] _labels;

        bool isdate;
        bool isStarting = true;
        bool isEncodeCode = true;

        string BarCodeData;
        string Prefix;
        string Suffix;

        string _description;
        string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;

                Graphics g = grouper_BarCode.CreateGraphics();

                label_Description.Text = _description;
                label_Description_2.Text = _description;

                SizeF descripLength = g.MeasureString(_description, label_Description.Font);

                int X_LabelLocation = (int)((grouper_Label.Width - descripLength.Width) / 2) - 4;

                label_Description.Location = new Point(X_LabelLocation, label_Description.Location.Y);
                label_Description_2.Location = new Point(X_LabelLocation, label_Description_2.Location.Y);

            }
        }

        int Quantity;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BarcodeDatatoPrint { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescriptiontoPrint { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CounterStartValue { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int QuantitytoPrint { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Date_Info { get; set; }

        /// <summary>
        /// Starting number for the counter. This will count the Labels numbers.
        /// </summary>
        int Counter;

        /// <summary>
        /// Limit of labels to be prints. Counter plus Quantity.
        /// </summary>
        int maxtoPrint;


        public Zebra_Prints_PCBLabels()
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

            Date_Info = DateTime.Now;
            isdate = true;
            BarCodeData = "";
            Description = "";
            Quantity = 1;
            Counter = 0;
            maxtoPrint = Counter + Quantity;
        }

        /// <summary>
        /// Inicializa new ZebraPrints instancy.
        /// </summary>
        /// <param name="BarcodeData"></param>
        /// <param name="Description"></param>
        /// <param name="Quantity"></param>
        public Zebra_Prints_PCBLabels(string barcodeDatatoPrint, string descriptiontoPrint, int counterStartValue, int quantitytoPrint)
        {
            InitializeComponent();

            BarCodeData = barcodeDatatoPrint;
            Description = descriptiontoPrint;
            Quantity = quantitytoPrint;
            Counter = counterStartValue;
            maxtoPrint = Counter + Quantity;

            numericUpDown_Counter.Value = Counter;
            numericUpDown_Quantity.Value = Quantity;

            Date_Info = DateTime.Now;
            isdate = true;

            builderCommands = new StringBuilder();
        }

        public Zebra_Prints_PCBLabels(string barcodeDatatoPrint, string descriptiontoPrint, int counterStartValue, int quantitytoPrint, DateTime date)
        {
            InitializeComponent();

            BarCodeData = barcodeDatatoPrint;
            Description = descriptiontoPrint;
            Quantity = quantitytoPrint;
            Counter = counterStartValue;
            maxtoPrint = Counter + Quantity;

            numericUpDown_Counter.Value = Counter;
            numericUpDown_Quantity.Value = Quantity;

            Date_Info = date;
            isdate = true;

            builderCommands = new StringBuilder();
        }

        private void EPL2_Zebra_Prints_Load(object sender, EventArgs e)
        {
            button_Print.Enabled = false;
            textBox_BarCode_Prefix.Text = Prefix;
            textBox_BarCode_Data.Text = BarCodeData;
            textBox_Suffix.Text = Suffix;
            numericUpDown_Counter.Value = Counter;
            numericUpDown_Quantity.Value = Quantity;
            textBox_Description.Text = Description;
            ShowBarCodeImage(BarCodeData + Counter);

            isStarting = false;

            button_Print.Enabled = true;
            richTextBox_ZPL.Text = Contruct_Labels();
        }

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

            #region"Inicializa Prints"

            string[] _inicialitation = new string[]
            {
                "^XA",
                "~TA000~JSN^LT0^MNW^MTT^PON^PMN^LH0,0^JMA^PR3,3~SD15^JUS^LRN^CI0",
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
                string PartNumber = "";

                PartNumber = BarCodeData.Replace("-", "");

                if (PartNumber.Length > 7)
                    PartNumber = (PartNumber.Remove(7)).Remove(0, 3);
                else
                    if (PartNumber.Length > 3)
                        PartNumber = PartNumber.Remove(0, 3);

                if (BarCodeData.Length > 3)
                {
                    if (Enum.IsDefined(typeof(MyCode.EncodeCode), Convert.ToInt32(BarCodeData.Substring(0, 3))))
                        Code = "" + (MyCode.EncodeCode)Convert.ToInt32(BarCodeData.Substring(0, 3));
                    else
                    {
                        Code = BarCodeData.Substring(0, 3);
                        MessageBox.Show("The code " + BarCodeData.Substring(0, 3) + " is not defined", "Code no defined.",
                                                                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                BarCodeData = Code + PartNumber;
            }
            #endregion"EncodeCode"

            else
            {
                BarCodeData = BarCodeData.Replace("-", "");
                if (BarCodeData.Length > 7)
                    BarCodeData = BarCodeData.Remove(7);
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
                "0140010123021312",             // #6 ^FD----^FS
                "^BY2,3,41^FT370,55^BCN,,Y,N",  // #7
                "0140010123021312",             // #8 ^FD----^FS
                "^FT74,98^A0N,25,28^FH\\^FDIridium Desktop.^FS",   // #9
                "^FT409,98^A0N,25,28^FH\\^FDIridium Desktop.^FS",  // #10
                "^PQ1,0,1,Y",                   // #11
                "^XZ",                          // #12
                 };

            #endregion"Label"       


            int posX = (300 - (Description.Length * ptos_Caracter)) / 2;

            _label[9] = _label[9].Replace("74", posX.ToString());
            _label[10] = _label[10].Replace("409", (posX + 335).ToString());

            if (Counter < 10)
                _label[6] = _label[6].Replace("0140010123021312", BarCodeData + "000" + Counter);
            else
                if (Counter < 100)
                    _label[6] = _label[6].Replace("0140010123021312", BarCodeData + "00" + Counter);
                else
                    if (Counter < 1000)
                        _label[6] = _label[6].Replace("0140010123021312", BarCodeData + "0" + Counter);
                    else
                        if (Counter > 999)
                            _label[6] = _label[6].Replace("0140010123021312", BarCodeData + Counter);

            #region"Date (Month and Year"

            if (isdate)
            {
                string month;
                if (Date_Info.Month > 9)
                    month = Date_Info.Month.ToString();
                else
                    month = "0" + Date_Info.Month.ToString();

                //   _label[6] += (FileSystemExt.EncodeMonth)Date_Info.Month + month + (FileSystemExt.EncodeYear)Date_Info.Year;
                _label[6] += month + Date_Info.Year.ToString().Remove(0, 2);
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


            _label[9] = _label[9].Replace("Iridium Desktop.", Description);

            Counter++;

            if (Counter == maxtoPrint)
            {
                _label[7] = null;
                _label[8] = null;
                _label[10] = null;
            }
            else
            {
                if (Counter < 10)
                    _label[8] = _label[8].Replace("0140010123021312", BarCodeData + "000" + Counter);
                else
                    if (Counter < 100)
                        _label[8] = _label[8].Replace("0140010123021312", BarCodeData + "00" + Counter);
                    else
                        if (Counter < 1000)
                            _label[8] = _label[8].Replace("0140010123021312", BarCodeData + "0" + Counter);
                        else
                            if (Counter > 999)
                                _label[8] = _label[8].Replace("0140010123021312", BarCodeData + Counter);

                #region"Date Month and Year"

                if (isdate)
                {
                    string month = "";
                    if (Date_Info.Month > 9)
                        month = Date_Info.Month.ToString();
                    else
                        month = "0" + Date_Info.Month.ToString();

                    //   _label[9] += (FileSystemExt.EncodeMonth)Date_Info.Month + month + (FileSystemExt.EncodeYear)Date_Info.Year;
                    _label[8] += month + Date_Info.Year.ToString().Remove(0, 2);
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


                _label[10] = _label[10].Replace("Iridium Desktop.", Description);
            }

            Counter++;

            return _label;
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

        private void textBox_BarCode_Data_TextChanged(object sender, EventArgs e)
        {
            BarCodeData = textBox_BarCode_Data.Text;

            Any_TextChanged();
        }

        private void textBox_Suffix_TextChanged(object sender, EventArgs e)
        {
            Suffix = textBox_Suffix.Text;

            Any_TextChanged();
        }

        private void numericUpDown_Counter_ValueChanged(object sender, EventArgs e)
        {
            Counter = (int)numericUpDown_Counter.Value;

            Any_TextChanged();
        }

        private void numericUpDown_Quantity_ValueChanged(object sender, EventArgs e)
        {
            Quantity = (int)numericUpDown_Quantity.Value;

            Any_TextChanged();
        }

        private void textBox_Description_TextChanged(object sender, EventArgs e)
        {
            Description = textBox_Description.Text;

            Any_TextChanged();
        }

        private void Any_TextChanged()
        {
            if (isStarting)
                return;

            button_Print.Enabled = false;

            builderCommands.Clear();

            Counter = (int)numericUpDown_Counter.Value;

            Quantity = (int)numericUpDown_Quantity.Value;

            BarCodeData = textBox_BarCode_Data.Text;

            maxtoPrint = Counter + Quantity;

            richTextBox_ZPL.Clear();
            richTextBox_ZPL.Text = Contruct_Labels();

            button_Print.Enabled = true;
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            button_Print.Enabled = false;

            PrintLabels(richTextBox_ZPL.Text);
        }

        private void CheckBox_print_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_print.Checked)
                isdate = true;
            else
                isdate = false;
        }

        private void checkBox_EncodeCode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_EncodeCode.Checked)
                isEncodeCode = true;
            else
                isEncodeCode = false;
        }




    }
}

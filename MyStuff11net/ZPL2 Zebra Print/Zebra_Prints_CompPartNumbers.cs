using GenCode128;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyStuff11net.ZPL2ZebraPrint
{
    public partial class Zebra_Prints_CompPartNumbers : Form
    {
        StringBuilder builderCommands;

        IPEndPoint printerIP;
        readonly string IP = "10.1.1.249";

        string[] _labels;

        bool isdate;
        bool isStarting = true;
        bool isEncodeCode = true;

        string BarCodeData = "1051112";
        string Prefix;
        string Suffix;

        string PartNumber;

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
        public DateTime DateInfo { get; set; }

        /// <summary>
        /// Starting number for the counter. This will count the Labels numbers.
        /// </summary>
        int Counter;

        /// <summary>
        /// Limit of labels to be prints. Counter plus Quantity.
        /// </summary>
        int maxtoPrint;


        public Zebra_Prints_CompPartNumbers()
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
            BarCodeData = "1051112";
            Description = "";
            Quantity = 1;
            Counter = 0;
            maxtoPrint = Counter + Quantity;

            builderCommands = new StringBuilder();
        }

        /// <summary>
        /// Inicializa new ZebraPrints instancy.
        /// </summary>
        /// <param name="BarcodeData"></param>
        /// <param name="Description"></param>
        /// <param name="Quantity"></param>
        public Zebra_Prints_CompPartNumbers(string partNumber, string descriptiontoPrint, int counterStartValue)
        {
            InitializeComponent();

            if (partNumber == null)
                partNumber = "-";

            if (partNumber.Length > 8)
                PartNumber = partNumber.Substring(0, 8);
            else
                PartNumber = partNumber;

            BarCodeData = PartNumber.Replace("-", "");


            if (descriptiontoPrint == null)
                descriptiontoPrint = "";

            if (descriptiontoPrint.Length > 23)
                Description = descriptiontoPrint.Substring(0, 23);
            else
                Description = descriptiontoPrint;

            Quantity = 1;
            Counter = counterStartValue;
            maxtoPrint = Counter + Quantity;

            numericUpDown_Counter.Value = Counter;
            numericUpDown_Quantity.Value = Quantity;

            DateInfo = DateTime.Now;
            isdate = true;

            builderCommands = new StringBuilder();
        }

        void EPL2_Zebra_Prints_Load(object sender, EventArgs e)
        {
            splitContainer_PrintCompPartNumber.Panel2Collapsed = true;
            Height = 320;

            button_Print.Enabled = false;
            textBox_BarCode_Prefix.Text = Prefix;
            textBox_BarCode_Data.Text = BarCodeData;
            textBox_Suffix.Text = Suffix;
            numericUpDown_Counter.Value = Counter;
            numericUpDown_Quantity.Value = Quantity;
            textBox_Description.Text = Description;

            isStarting = false;

            button_Print.Enabled = true;
            richTextBox_ZPL.Text = Contruct_Labels();

            Any_TextChanged();
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
                ns?.Close();

                if (socket != null && socket.Connected)
                    socket.Close();

                socket?.Dispose();
            }

            return result;
        }

        string Contruct_Labels()
        {
            CultureInfo cultures = new CultureInfo("en-US");
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
                PartNumber = BarCodeData.Replace("-", "");

                if (PartNumber.Length > 7)
                    PartNumber = (PartNumber.Remove(7)).Remove(0, 3);
                else
                    if (PartNumber.Length > 3)
                        PartNumber = PartNumber.Remove(0, 3);

                if (BarCodeData.Length > 3)
                {
                    if (Enum.IsDefined(typeof(MyCode.EncodeCode), Convert.ToInt32(BarCodeData.Substring(0, 3), cultures)))
                        Code = "" + (MyCode.EncodeCode)Convert.ToInt32(BarCodeData.Substring(0, 3), cultures);
                    else
                    {
                        Code = BarCodeData.Substring(0, 3);
                        MessageBox.Show("The code " + BarCodeData.Substring(0, 3) + " is not defined", "Code no defined.",
                                                                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                BarCodeData = Code + PartNumber;
            }
            else
            {
                BarCodeData = BarCodeData.Replace("-", "");
                if (BarCodeData.Length > 7)
                    BarCodeData = BarCodeData.Remove(7);
            }

            #endregion"EncodeCode"

            while (Counter < maxtoPrint)
            {
                string[] Label = LabelsData();

                if (isFirst)
                {
                    string humanreadable = Label[6].Replace("^FD>;", "");

                    if (humanreadable.Contains(">6"))
                    {
                        int indexW = humanreadable.IndexOf(">6", 0, humanreadable.Length, StringComparison.OrdinalIgnoreCase);
                        string sub = humanreadable.Substring(indexW, 2);
                        humanreadable = humanreadable.Replace(sub, "");
                    }

                    humanreadable = humanreadable.Replace("^FS", "");



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

        string[] LabelsData()
        {
            int ptos_Caracter = 11;

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

            _label[6] = _label[6].Replace("0140010123021312", BarCodeData + CounterString(Counter));

            int posX = (300 - (Description.Length * ptos_Caracter)) / 2;

            _label[9] = _label[9].Replace("74", posX.ToString());
            _label[10] = _label[10].Replace("409", (posX + 335).ToString());


            #region"Date (Month and Year"

            if (isdate)
                _label[6] += DateString(DateInfo);

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
                _label[8] = _label[8].Replace("0140010123021312", BarCodeData + CounterString(Counter));

                #region"Date Month and Year"

                if (isdate)
                    _label[8] += DateString(DateInfo);

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

        string CounterString(int counter)
        {
            string counterString = "" + counter;

            if (counter < 10)
                counterString = "000" + counter;
            else
                if (counter < 100)
                    counterString = "00" + counter;
                else
                    if (counter < 1000)
                        counterString = "0" + counter;

            return counterString;
        }

        string DateString(DateTime dateInfo)
        {
            string month;
            if (DateInfo.Month > 9)
                month = dateInfo.Month.ToString();
            else
                month = "0" + dateInfo.Month.ToString();

            //   _label[6] += (FileSystemExt.EncodeMonth)Date_Info.Month + month + (FileSystemExt.EncodeYear)Date_Info.Year;
            month += dateInfo.Year.ToString().Remove(0, 2);

            return month;
        }

        void TextBox_BarCode_Prefix_TextChanged(object sender, EventArgs e)
        {
            Prefix = textBox_BarCode_Prefix.Text;

            Any_TextChanged();
        }

        void TextBox_BarCode_Data_TextChanged(object sender, EventArgs e)
        {
            BarCodeData = textBox_BarCode_Data.Text;

            Any_TextChanged();
        }

        void TextBox_Suffix_TextChanged(object sender, EventArgs e)
        {
            Suffix = textBox_Suffix.Text;

            Any_TextChanged();
        }

        void NumericUpDown_Counter_ValueChanged(object sender, EventArgs e)
        {
            Counter = (int)numericUpDown_Counter.Value;

            Any_TextChanged();
        }

        void NumericUpDown_Quantity_ValueChanged(object sender, EventArgs e)
        {
            Quantity = (int)numericUpDown_Quantity.Value;

            if (Quantity == 0)
                numericUpDown_Quantity.Value = 1;

            Any_TextChanged();
        }

        void TextBox_Description_TextChanged(object sender, EventArgs e)
        {
            Description = textBox_Description.Text;

            Any_TextChanged();
        }

        void Any_TextChanged()
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

            label_HumanReadableInformation.Text = BarCodeData + CounterString(Counter) + DateString(DateInfo);
            pictureBox_BarCode_Image.Image = Code128Rendering.MakeBarcodeImage(label_HumanReadableInformation.Text, 1, true);

            if (Quantity == 1)
            {
                pictureBox_BarCode_Image_2.Image = pictureBox_BarCode_Image.Image;
                label_HumanReadableInformation_2.Text = label_HumanReadableInformation.Text;
            }
            else
            {
                label_HumanReadableInformation_2.Text = BarCodeData + CounterString(Counter + 1) + DateString(DateInfo);
                pictureBox_BarCode_Image_2.Image = Code128Rendering.MakeBarcodeImage(label_HumanReadableInformation_2.Text, 1, true);
            }

            button_Print.Enabled = true;
        }



        void CheckBox_print_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_print.Checked)
                isdate = true;
            else
                isdate = false;
        }

        void CheckBox_EncodeCode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_EncodeCode.Checked)
                isEncodeCode = true;
            else
                isEncodeCode = false;
        }



        void Button1_Click(object sender, EventArgs e)
        {
            button_Print.Enabled = false;

            PrintLabels(richTextBox_ZPL.Text);
        }

        void RoundButton_NewProject_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

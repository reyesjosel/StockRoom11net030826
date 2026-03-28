using Be.Windows.Forms;
using MyStuff11net;
using MyStuff11net.Properties;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using WinFormsUI.Docking;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;


namespace StockRoom11net
{
    public partial class H7H_Explorer : DockContent
    {
        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Status bar message and status bar help.")]
        public event Custom_Events_Args.StatusBarMessage_EventHandler StatusBarMessage;

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

        string _openfileName = "";
        string _fileName = "";
        string _ext = "";

        public H7H_Explorer()
        {
            InitializeComponent();
        }

        private void H7H_Explorer_Load(object sender, EventArgs e)
        {
            openAFileToolStripMenuItem_Click(sender, e);
        }

        BinaryReader _binaryreader;
        private int _bufferSize = 16384;
        private void openAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openfile = new OpenFileDialog
            {
                Title = @"Please found any H7H file",
                FileName = "",
                Filter = @"(*.H7H)|*.H7H|All files (*.*)|*.*",
                DefaultExt = "(*.H7H)|*.H7H|All files (*.*)|*.*",
                InitialDirectory = Settings.Default.DataBaseAddress + "\\H7H\\"
            }
                  )
            {
                if (openfile.ShowDialog(this) == DialogResult.Cancel)
                    return;

                _openfileName = openfile.FileName;

                _fileName = Path.GetFileNameWithoutExtension(_openfileName);

                _ext = Path.GetExtension(_openfileName);

                int pointerReader = 0;
                StringBuilder stringBuilder = new StringBuilder();
                FileStream fileStream = new FileStream(_openfileName, FileMode.Open, FileAccess.Read);
                using (StreamReader streamReader = new StreamReader(fileStream))

                using (BufferedStream bs = new BufferedStream(fileStream))
                using (_binaryreader = new BinaryReader(bs, Encoding.Default))
                {
                    char[] fileContents = new char[_bufferSize];
                    int charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                    // Can't do much with 0 bytes
                    if (charsRead == 0)
                        throw new Exception("File is 0 bytes");

                    while (charsRead > 0)
                    {
                        stringBuilder.Append(fileContents);
                        charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                        pointerReader += _bufferSize;
                    }

                    string fullData = stringBuilder.ToString();
                    var enc = new UTF8Encoding();
                    var data = enc.GetBytes(stringBuilder.ToString());
                    DynamicByteProvider dbp = new DynamicByteProvider(data);
                    this.hexBox.ByteProvider = dbp;

                    _binaryreader.BaseStream.Position = 0;
                    richTextBox.Text = "MachineName : " + Encoding.UTF8.GetString(_binaryreader.ReadBytes(33));
                    richTextBox.Text += Environment.NewLine + "Machine 701 : " + Encoding.UTF8.GetString(_binaryreader.ReadBytes(13));
                    richTextBox.Text += Environment.NewLine + "unknow01    : " + Encoding.UTF8.GetString(_binaryreader.ReadBytes(40));

                    int addressForPlacementStar = _binaryreader.ReadInt32();
                    richTextBox.Text += Environment.NewLine + "addressForPlacementStar : " + addressForPlacementStar;
                    richTextBox.Text += Environment.NewLine + "unknow02    : " + Encoding.UTF8.GetString(_binaryreader.ReadBytes(8));
                    int numberOfPlacements = _binaryreader.ReadInt32();
                    richTextBox.Text += Environment.NewLine + "numberOfPlacements      : " + numberOfPlacements;

                    int addressForComponentStar = _binaryreader.ReadInt32();
                    richTextBox.Text += Environment.NewLine + "addressForComponentStar : " + addressForComponentStar;
                    richTextBox.Text += Environment.NewLine + "unknow03    : " + Encoding.UTF8.GetString(_binaryreader.ReadBytes(8));
                    int numberOfComponets = _binaryreader.ReadInt32();
                    richTextBox.Text += Environment.NewLine + "numberOfComponets      : " + numberOfComponets;
                    richTextBox.Text += Environment.NewLine + "addressForComponentEnd : " + _binaryreader.ReadInt32();

                    ProcessComponents(addressForComponentStar, numberOfComponets);

                    ProcessPlacements(addressForPlacementStar, numberOfPlacements);

                    _binaryreader.Close();
                }
            }
        }

        private void ProcessComponents(int addressForComponentStar, int numberOfComponets)
        {
            _binaryreader.BaseStream.Position = addressForComponentStar;

            for (int i = 0; i < numberOfComponets; i++)
            {
                richTextBox.Text += Environment.NewLine;
                richTextBox.Text += Environment.NewLine;
                richTextBox.Text += ReadComponent();
            }

        }

        private string ReadComponent()
        {
            string componentInformations = "";

            componentInformations = Environment.NewLine + "Componen Name 21    : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(20));
            componentInformations += Environment.NewLine + "unknowCompData 13   : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(13));
            componentInformations += Environment.NewLine + "unknowCompDataInt 4 : " + _binaryreader.ReadInt32();
            componentInformations += Environment.NewLine + "unknowCompData 9   : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(10));
            componentInformations += Environment.NewLine + "Component Coment 30 : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(30));

            byte[] nextInform = _binaryreader.ReadBytes(4);
            string nextInformation = BitConverter.ToString(nextInform).Replace("-", string.Empty);
            componentInformations += Environment.NewLine + "unknowCompData 4   : " + int.Parse(nextInformation, NumberStyles.AllowHexSpecifier);

            nextInform = _binaryreader.ReadBytes(4);
            nextInformation = BitConverter.ToString(nextInform).Replace("-", string.Empty);
            componentInformations += Environment.NewLine + "unknowCompData 4   : " + int.Parse(nextInformation, NumberStyles.AllowHexSpecifier);

            nextInform = _binaryreader.ReadBytes(4);
            nextInformation = BitConverter.ToString(nextInform).Replace("-", string.Empty);
            componentInformations += Environment.NewLine + "unknowCompData 4   : " + int.Parse(nextInformation, NumberStyles.AllowHexSpecifier);

            nextInform = _binaryreader.ReadBytes(4);
            nextInformation = BitConverter.ToString(nextInform).Replace("-", string.Empty);
            componentInformations += Environment.NewLine + "unknowCompData 4   : " + int.Parse(nextInformation, NumberStyles.AllowHexSpecifier);

            nextInform = _binaryreader.ReadBytes(4);
            nextInformation = BitConverter.ToString(nextInform).Replace("-", string.Empty);
            componentInformations += Environment.NewLine + "unknowCompData 4   : " + int.Parse(nextInformation, NumberStyles.AllowHexSpecifier);

            byte[] test = _binaryreader.ReadBytes(295);
            componentInformations += Environment.NewLine + "unknowCompData 295   : " + ConvertBytesToStringFiltered(test);

            componentInformations += Environment.NewLine + "unknowCompData 10   : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(10));
            componentInformations += Environment.NewLine + "unknowCompDataInt 4 : " + _binaryreader.ReadInt32();

            componentInformations += Environment.NewLine + "unknowCompData 710   : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(710));

            componentInformations += Environment.NewLine + "OtravezCompName 20   : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(20));

            componentInformations += Environment.NewLine + "unknowCompData 41   : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(41));

            componentInformations += Environment.NewLine + "OtravezCompComment 30   : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(30));

            componentInformations += Environment.NewLine + "unknowCompData 585   : " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(585));

            return componentInformations.Replace("\0", "");
        }

        private void ProcessPlacements(int addressForPlacementStar, int numberOfPlacements)
        {
            _binaryreader.BaseStream.Position = addressForPlacementStar;

            for (int i = 0; i < numberOfPlacements; i++)
            {
                richTextBox.Text += Environment.NewLine;
                richTextBox.Text += Environment.NewLine;
                richTextBox.Text += ReadPlacements();
            }
        }

        private string ReadPlacements()
        {
            string placementsInformations = "";

            placementsInformations = "********** Placement.....  " + ConvertBytesToStringFiltered(_binaryreader.ReadBytes(8));  // 8

            byte[] X_axes = _binaryreader.ReadBytes(4);                                                                      // 8+4=12

            //Array.Reverse(X_axes);  // Deal with Endian issue?
            Single Xmyvalue = BitConverter.ToSingle(X_axes, 0);
            placementsInformations += Environment.NewLine + "Axe X  : " + MyCode.CodeSMTAxes(X_axes).ToString("0.000") + "  --->" + Xmyvalue;
            placementsInformations += Environment.NewLine + "Axe X  : " + MyCode.CodeSMTAxes(BitConverter.ToString(X_axes).Replace("-", string.Empty)).ToString("0.000");
            string axesX = BitConverter.ToString(X_axes).Replace("-", string.Empty);
            placementsInformations += Environment.NewLine + "Axe X  : " + int.Parse(axesX, NumberStyles.AllowHexSpecifier) / 254000;

            byte[] Y_axes = _binaryreader.ReadBytes(4);                                                                      // 12+4=16
            placementsInformations += Environment.NewLine + "Axe Y  : " + MyCode.CodeSMTAxes(Y_axes).ToString("0.000");
            placementsInformations += Environment.NewLine + "Axe Y  : " + MyCode.CodeSMTAxes(BitConverter.ToString(Y_axes).Replace("-", string.Empty)).ToString("0.000");
            string axesY = BitConverter.ToString(Y_axes).Replace("-", string.Empty);
            placementsInformations += Environment.NewLine + "Axe X  : " + int.Parse(axesY, NumberStyles.AllowHexSpecifier) / 254000;

            placementsInformations += Environment.NewLine + "Placement Angle : " + (_binaryreader.ReadInt16() / 80);             // 16+2=18

            placementsInformations += Environment.NewLine + "Interger 2 : " + (_binaryreader.ReadInt16() / 80);                  // 18+2=20

            placementsInformations += Environment.NewLine + "Station #: " + _binaryreader.ReadInt16();                           // 20+2=22

            byte[] nextPlac = _binaryreader.ReadBytes(2);                                                                        // 22+2=24
            string stationIndex = BitConverter.ToString(nextPlac).Replace("-", string.Empty);
            placementsInformations += Environment.NewLine + "Station Placement Index: " + int.Parse(stationIndex, NumberStyles.AllowHexSpecifier);

            placementsInformations += Environment.NewLine + "Boolean 1 : " + _binaryreader.ReadBoolean();  // 24+1=25
            placementsInformations += Environment.NewLine + "Boolean 2 : " + _binaryreader.ReadBoolean();  // 25+1=26
            placementsInformations += Environment.NewLine + "Boolean 3 : " + _binaryreader.ReadBoolean();  // 26+1=27
            placementsInformations += Environment.NewLine + "Skip : " + _binaryreader.ReadBoolean();       // 27+1=28

            nextPlac = _binaryreader.ReadBytes(2);                                                         // 28+2=30
            stationIndex = BitConverter.ToString(nextPlac).Replace("-", string.Empty);
            placementsInformations += Environment.NewLine + "unknow Placement Data 2 : " + int.Parse(stationIndex, NumberStyles.AllowHexSpecifier);

            nextPlac = _binaryreader.ReadBytes(2);                                                         // 30+2=32
            stationIndex = BitConverter.ToString(nextPlac).Replace("-", string.Empty);
            placementsInformations += Environment.NewLine + "unknow Placement Data 3: " + int.Parse(stationIndex, NumberStyles.AllowHexSpecifier);

            nextPlac = _binaryreader.ReadBytes(2);                                                          // 32+2=34
            stationIndex = BitConverter.ToString(nextPlac).Replace("-", string.Empty);
            placementsInformations += Environment.NewLine + "       Component Index : " + int.Parse(stationIndex, NumberStyles.AllowHexSpecifier);

            nextPlac = _binaryreader.ReadBytes(2);                                                           // 34+2=36
            stationIndex = BitConverter.ToString(nextPlac).Replace("-", string.Empty);
            placementsInformations += Environment.NewLine + "unknow PlacementData 4 : " + int.Parse(stationIndex, NumberStyles.AllowHexSpecifier);

            string inknowPlacement220 = ConvertBytesToStringFiltered(_binaryreader.ReadBytes(220));
            placementsInformations += Environment.NewLine + "unknowPlacementData 220: " + inknowPlacement220;  // 36+220=256

            return placementsInformations.Replace("\0", "");
        }


        private void hexBox_HorizontalByteCountChanged(object sender, EventArgs e)
        {
            On_StatusBarMessage(new StatusBarMessage_EventArgs("", this.hexBox.CurrentFindingPosition.ToString()));
        }

        private void hexBox_CurrentLineChanged(object sender, EventArgs e)
        {
            string text = string.Format("Ln {0}    Col {1}    Byte {2}", hexBox.CurrentLine,
                                                                hexBox.CurrentPositionInLine, hexBox.SelectionStart);
            text += string.Format("    Hex {0:X}", hexBox.SelectionStart);
            On_StatusBarMessage(new StatusBarMessage_EventArgs("", text));
        }

        private void hexBox_CurrentPositionInLineChanged(object sender, EventArgs e)
        {
            string text = string.Format("Ln {0}    Col {1}    Byte {2}", hexBox.CurrentLine,
                                                                hexBox.CurrentPositionInLine, hexBox.SelectionStart);
            text += string.Format("    Hex {0:X}", hexBox.SelectionStart);
            On_StatusBarMessage(new StatusBarMessage_EventArgs("", text));
        }


        /// <summary>
        /// Displays the goto byte dialog.
        /// </summary>
        void Goto()
        {
            //  _formGoto.SetMaxByteIndex(hexBox.ByteProvider.Length);
            //  _formGoto.SetDefaultValue(hexBox.SelectionStart);
            //  if (_formGoto.ShowDialog() == DialogResult.OK)
            //  {
            //       hexBox.SelectionStart = _formGoto.GetByteIndex();
            hexBox.SelectionLength = 1;
            hexBox.Focus();
            //  }
        }

        private void contextMenuStripHxH_Opening(object sender, CancelEventArgs e)
        {
            if (hexBox.SelectionLength > 0)
            {
                string hexString = string.Empty;
                byte[] data = new byte[2];
                DynamicByteProvider byteprovider;

                byteprovider = hexBox.ByteProvider as DynamicByteProvider;

                data[0] = byteprovider.Bytes[(int)hexBox.SelectionStart + 0];
                data[1] = byteprovider.Bytes[(int)hexBox.SelectionStart + 1];
                // data[2] = byteprovider.Bytes[(int)hexBox.SelectionStart + 2];
                // data[3] = byteprovider.Bytes[(int)hexBox.SelectionStart + 3];

                data.ToList().ForEach(b => hexString += b.ToString("X2"));

                toolStripTextBoxGotoHex.Text = hexString;
                toolStripTextBoxFindNext.Text = hexString;

                Int64 hexValue = Convert.ToInt64(hexString, 16);

                toolStripTextBoxGoToDec.Text = Convert.ToInt32(hexValue).ToString();
            }
        }

        private void toolStripTextBoxGoto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            int positionvalue;

            if (int.TryParse(toolStripTextBoxGotoHex.Text, NumberStyles.AllowHexSpecifier,
                                                                CultureInfo.InvariantCulture, out positionvalue))
            {
                hexBox.SelectionStart = positionvalue;
                hexBox.SelectionLength = 1;
                hexBox.Focus();

                contextMenuStripHxH.Close();
                toolStripTextBoxGotoHex.Text = "";
            }
            else
            {
                contextMenuStripHxH.Close();
                toolStripTextBoxGotoHex.Text = "";
            }
        }

        private void toolStripTextBoxDec_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            int positionvalue;

            if (int.TryParse(toolStripTextBoxGoToDec.Text, out positionvalue))
            {
                hexBox.SelectionStart = positionvalue;
                hexBox.SelectionLength = 1;
                hexBox.Focus();

                contextMenuStripHxH.Close();
                toolStripTextBoxGotoHex.Text = "";
            }
            else
            {
                contextMenuStripHxH.Close();
                toolStripTextBoxGoToDec.Text = "";
            }
        }

        private void toolStripTextBoxFindNext_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            byte[] toFind = new byte[toolStripTextBoxFindNext.Text.Length / 2];
            for (int index = 0; index < toFind.Length; index++)
            {
                string byteValue = toolStripTextBoxFindNext.Text.Substring(index * 2, 2);
                toFind[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            // start find process
            long res = -1;      // hexBox.Find(toFind, hexBox.SelectionStart + hexBox.SelectionLength);

            if (res == -1) // -1 = no match
            {
                contextMenuStripHxH.Close();
                On_StatusBarMessage(new StatusBarMessage_EventArgs("No mach string found."));
            }
            else if (res == -2) // -2 = find was aborted
            {
                contextMenuStripHxH.Close();
                On_StatusBarMessage(new StatusBarMessage_EventArgs("Find process aborted."));
                return;
            }
            else // something was found
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("String found."));

                if (!hexBox.Focused)
                    hexBox.Focus();
            }
        }

        private static string ConvertBytesToStringFiltered(byte[] toConvert)
        {
            //return Encoding.UTF8.GetString(toConvert.Where(b => b != 0x02).ToArray()).TrimIntraWords();

            return Encoding.UTF8.GetString(toConvert.Except(new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 }).ToArray());
        }























    }
}

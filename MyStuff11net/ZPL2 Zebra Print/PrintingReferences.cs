using GenCode128;
using System.ComponentModel;

namespace MyStuff11net
{
    public partial class PrintingReferences : UserControl
    {
        #region"PrintsLabelsReady"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event Custom_Events_Args.PrintsLabelsReady_EventHandler PrintsLabelsReady;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_PrintsLabelsReady(Custom_Events_Args.PrintsLabelsReady_EventArgs e)
        {
            // If an event has no subscriber registerd, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (PrintsLabelsReady != null)
            {
                // Notify Subscribers
                PrintsLabelsReady(this, e);
            }
        }

        #endregion"PrintsLabelsReady"
        
        /// <summary>
        /// Counter of reel quantity in stockroom.
        /// </summary>
        public int ReelsCounter;

        /// <summary>
        /// Count the number of reels received till now,
        /// Reserved 4 digits for this counter from 0001-9999.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ReelsCounterToString
        {
            get
            {
                if (ReelsCounter < 10)
                    return "000" + ReelsCounter;

                if (ReelsCounter < 100)
                    return "00" + ReelsCounter;

                if (ReelsCounter < 1000)
                    return "0" + ReelsCounter;

                return "" + ReelsCounter;
            }
            private set { }
        }

        /// <summary>
        /// On Received Process, Quantity by Reels after validation.
        /// </summary>
        public int QuantityPerReels;

        public string PartNumber = "014-0000";

        string descriptionToPrint;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescriptionToPrint
        {
            get
            {
                return descriptionToPrint;
            }
            set
            {
                descriptionToPrint = value;
                label_Description.Text = value;
                textBox_DescriptionToPrint.Text = value;

                ShowBarCodeImage(PartNumber.Replace("-", "") + ReelsCounterToString + EncodeMothYear());
                label_HumanReadableInformation.Text = PartNumber.Replace("-", "") + ReelsCounterToString + EncodeMothYear();
            }
        }

        int quantityReceived;
        /// <summary>
        /// On Received Process, Quantity received.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int QuantityReceived
        {
            get
            {
                return quantityReceived;
            }
            set
            {
                quantityReceived = value;


            }
        }

        /// <summary>
        /// On Received Process, Numbers of Reels after validation.
        /// </summary>
        public int NumberOfReels;

        /// <summary>
        /// Enable or disable the print properties menu.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EnablePrintsProperties
        {
            get
            {
                return checkBox_printLabels.Checked;
            }
            set
            {
                checkBox_printLabels.Checked = value;
            }
        }

        public PrintingReferences()
        {
            InitializeComponent();

            Load += new EventHandler(PrintingReferences_Load);
            DockChanged += new EventHandler(PrintingReferences_DockChanged);

            //     comboBox_Quantityper_Reels.KeyUp += comboBox_Quantityper_Reels_KeyUp;
            //     comboBox_Numberof_Reels.KeyUp += comboBox_Numberof_Reels_KeyUp;
            textBox_DescriptionToPrint.KeyUp += textBox_DescriptionToPrint_KeyUp;

            checkBox_printLabels.CheckedChanged += checkBox_printLabels_CheckedChanged;

            ShowBarCodeImage("014-0023");
        }

        public PrintingReferences(string description)
        {
            InitializeComponent();

            Load += new EventHandler(PrintingReferences_Load);
            DockChanged += new EventHandler(PrintingReferences_DockChanged);

            //    comboBox_Quantityper_Reels.KeyUp += comboBox_Quantityper_Reels_KeyUp;
            //    comboBox_Numberof_Reels.KeyUp += comboBox_Numberof_Reels_KeyUp;
            textBox_DescriptionToPrint.KeyUp += textBox_DescriptionToPrint_KeyUp;

            checkBox_printLabels.CheckedChanged += checkBox_printLabels_CheckedChanged;

            DescriptionToPrint = textBox_DescriptionToPrint.Text = description;

            ShowBarCodeImage(DescriptionToPrint);
        }

        void PrintingReferences_Load(object sender, EventArgs e)
        {/*
            comboBox_Quantityper_Reels.Enabled = true;
            comboBox_Quantityper_Reels.Text = "";
            comboBox_Numberof_Reels.Enabled = true;
            comboBox_Numberof_Reels.Text = "";

            comboBox_Quantityper_Reels.Text = "1";
            comboBox_Numberof_Reels.Text = "1";
            */
        }

        void comboBox_Quantityper_Reels_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;

            //   QuantityPerReels = MyCode.IntParseFast(comboBox_Quantityper_Reels.Text);
        }

        void comboBox_Numberof_Reels_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;

            //    NumberOfReels = MyCode.IntParseFast(comboBox_Numberof_Reels.Text);
            //     QuantityPerReels = MyCode.IntParseFast(comboBox_Quantityper_Reels.Text);

            if (QuantityPerReels == 0)
                QuantityPerReels = QuantityReceived;

            On_PrintsLabelsReady(new Custom_Events_Args.PrintsLabelsReady_EventArgs(AuthenticateReceived()));
        }

        void textBox_DescriptionToPrint_KeyUp(object sender, KeyEventArgs e)
        {
            int quedan = 25 - textBox_DescriptionToPrint.Text.Length;

            DescriptionToPrint = textBox_DescriptionToPrint.Text;

            if (quedan < 0)
                return;

            label_DescriptionToPrint.Text = "Up to " + quedan + " characters...";
            label_Description.Text = DescriptionToPrint;

            if (e.KeyData != Keys.Enter)
                return;
        }

        void PrintingReferences_DockChanged(object sender, EventArgs e)
        {

        }

        void checkBox_printLabels_CheckedChanged(object sender, EventArgs e)
        {
            panel_EnablePrints.Enabled = checkBox_printLabels.Checked;
        }

        bool AuthenticateReceived()
        {
            if (QuantityReceived == 0)
            {
                MessageBox.Show("Received Quantity must be greater than 0", "Are you missing some information",
                                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (QuantityPerReels == 0)
            {
                MessageBox.Show("Quantity by Reels must be greater than 0", "Are you missing some information",
                                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        comboBox_Quantityper_Reels.Clear();
                //         comboBox_Quantityper_Reels.Focus();
                return false;
            }

            if (NumberOfReels == 0)
            {
                MessageBox.Show("Number of Reels must be greater than 0", "Are you missing some information",
                                                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                //         comboBox_Numberof_Reels.Clear();
                //         comboBox_Numberof_Reels.Focus();
                return false;
            }

            if (QuantityPerReels > QuantityReceived)
            {
                MessageBox.Show("Received Quantity must be greater than Quantity by Reels", "Are you missing some information",
                                                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int CalculedNumberOfReel = QuantityReceived / QuantityPerReels;

            if (CalculedNumberOfReel != NumberOfReels)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"QuantityReceived / QuantityPerReels hass to be " + CalculedNumberOfReel,
                                 @"QuantityReceived, QuantityPerReels and NumberOfReels has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        void ShowBarCodeImage(string value)
        {
            try
            {
                if (value.Length == 0)
                    value = "Unknown";

                pictureBox_BarCode_Image.Image = Code128Rendering.MakeBarcodeImage(value, 1, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text);
            }
        }

        string EncodeMothYear()
        {
            string month = "";
            DateTime Date_Info = DateTime.Now;

            if (Date_Info.Month > 9)
                month = Date_Info.Month.ToString();
            else
                month = "0" + Date_Info.Month.ToString();

            //   _label[6] += (FileSystemExt.EncodeMonth)Date_Info.Month + month + (FileSystemExt.EncodeYear)Date_Info.Year;
            return month + Date_Info.Year.ToString().Remove(0, 2);
        }

    }
}

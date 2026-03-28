using MyStuff11net;
using MyStuff11net.DataGridViewExtend;
using System.Data;
using CellDoubleClick_EventArgs = MyStuff11net.Custom_Events_Args.CellDoubleClick_EventArgs;
using CurrentRowActive_EventArgs = MyStuff11net.Custom_Events_Args.CurrentRowActive_EventArgs;
using DataGridViewMouseEnterEventArgs = MyStuff11net.Custom_Events_Args.DataGridViewMouseEnterEventArgs;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;


namespace StockRoom11net
{
    public partial class StockRoomReceive : BaseTemple
    {
        BaseComponent _selectedComponet;

        #region"Global variables, controles activos by Tabpage."

        string _partNumber;

        #endregion"Global variables, controles activos by Tabpage."

        /// <summary>
        /// _messageString, used in try...catch block.
        /// </summary>
        string _messageString = ""; // Utilizado para identificar try...catch block.

        /// <summary>
        /// This flag indica FTV finalized the inicialization an is ready to show information.
        /// </summary>
        bool _canUpdate;    // Indica si se puede UpDate la description.

        /// <summary>
        /// If we are inside a received process, this will be true.
        /// </summary>
        bool _isReceivedProcess;

        /// <summary>
        /// On Received Process, Quantity received after validation.
        /// </summary>
        int QuantityReceived;

        /// <summary>
        /// On Received Process, Quantity by Reels after validation.
        /// </summary>
        readonly int Qty_perReels = 0;

        /// <summary>
        /// On Received Process, Numbers of Reels after validation.
        /// </summary>
        readonly int NumberofReels;

        /// <summary>
        /// Counter of reel quantity in stockroom.
        /// </summary>
        int ReelsCounter;

        /// <summary>
        /// Description show in LabelsBarcode;
        /// </summary>
        string Description;


        public StockRoomReceive()
        {
            InitializeComponent();
        }

        public StockRoomReceive(BindingSource treeview, BindingSource stockroom)
        {
            InitializeComponent();

            _bindingSource_table_StockroomTreeView = treeview;
            _bindingSource_tableStockRoom = stockroom;
        }

        #region"StockRoom Received"

        void StockRoom_Receive_Load(object sender, EventArgs e)
        {
            printingReferences.PrintsLabelsReady += PrintingReferences_PrintsLabelsReady;

            _cache = new ResourcesCache();

            FlowLayoutPanel_ComBoxComponentsProperties_Resize(new object(), new EventArgs());
            FlowLayoutPanel_ComBoxManufacturerProperties_Resize(new object(), new EventArgs());
        }

        void StockRoom_Receive_Shown(object sender, EventArgs e)
        {
            this.VisibleChanged += new EventHandler(StockRoom_Receive_VisibleChanged);

            DataGridViewInitialize();
            InitTabControlExtend();
        }

        void FlowLayoutPanel_ComBoxManufacturerProperties_Resize(object sender, EventArgs e)
        {
            int spaceneed = 24 + 75; // 24 space + 75 Button

          
            label_Manufacturer.Location = new Point(comboBox_Manufacturer.Location.X, 6);
            label_Model_Number.Location = new Point(comboBox_Model_Number.Location.X, 6);
            label_Supplier.Location = new Point(comboBox_Supplier.Location.X, 6);
        }

        void FlowLayoutPanel_ComBoxComponentsProperties_Resize(object sender, EventArgs e)
        {
            int spaceneed = 18;
               
            label_PartNumber.Location = new Point(comboBox_PartNumber.Location.X, 6);
    //        label_Received_Quantity.Location = new Point(textBox_Received_Quantity.Location.X, 6);

            int deltaX = (dateTimePicker.Width / 2) - (label_Received_Date.Width / 2);
            label_Received_Date.Location = new Point((dateTimePicker.Location.X + deltaX), 6);
        }

        void StockRoom_Receive_VisibleChanged(object sender, EventArgs e)
        {
            UpDateInformation();
        }

        #endregion"StockRoom Received"


        void UpDateInformation()
        {
            if (!this.Visible)
                return;

            if (_isReceivedProcess)
                return;

            if (_canUpdate)
            {
                if (_bindingSource_table_StockroomTreeView.Current == null)
                    return;

                DataRowView currentRowview = (DataRowView)_bindingSource_table_StockroomTreeView.Current;

                if (currentRowview["ID"] == null)
                    return;

                #region"Select Node"

                string rowTag = currentRowview["ID"].ToString();



                #endregion"Select Node"

            }
                     
            ProcessInput(MyCode.ProcessMode.Adjust);

        }

        void Update_Description(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(Update_Description), new object[] { sender, e });
                return;
            }

            DataRowView currentRowview = (DataRowView)_bindingSource_tableStockRoom.Current;

            if ((currentRowview == null) || (currentRowview["PartNumber"] == null))
                return;

            #region"Description Short"

            string discription_short;
            discription_short = "<font color='Blue'><b>" + currentRowview["PartNumber"].ToString() + "</b></font>    ->";

            if (currentRowview["Description"].ToString() == "")
                discription_short += "  This component has not any Description.";
            else
                discription_short += "<i>" + currentRowview["Description"].ToString() + "</i>";

            #endregion"Description Short"

            #region"Description Expand"

            string information;
            string headtext = "Project Name    Number of Comp used    Enough to produced<br/>";
            string headline = "-----------------------|--------------------------------------|-----------------------------------<br/>";

            if (currentRowview["Who_uses_this"].ToString() == "")
            {
                information = "This component has not been assigned to any other project.<br/>";
                return;
            }

            var dict = MyCode.GetDict(currentRowview["Who_uses_this"].ToString());

            information = headtext + headline;

            string space_fill = "";

            foreach (KeyValuePair<string, int> inf in dict)
            {
                string space_value = "";
                int max_prod;

                #region"Space to Fill"

                if (inf.Key.Length == 3)
                    space_fill = "                                 ";
                if (inf.Key.Length == 4)
                    space_fill = "                               ";
                if (inf.Key.Length == 5)
                    space_fill = "                         ";
                if (inf.Key.Length == 6)
                    space_fill = "                        ";
                if (inf.Key.Length == 7)
                    space_fill = "                        ";
                if (inf.Key.Length == 8)
                    space_fill = "                      ";
                if (inf.Key.Length == 9)
                    space_fill = "                     ";
                if (inf.Key.Length == 10)
                    space_fill = "                    ";

                #endregion"Space to Fill"

                if (inf.Value < 10)
                    space_value = "    ";

                if (inf.Value < 100 & inf.Value > 9)
                    space_value = "  ";

                information += "  " + inf.Key + space_fill + space_value + inf.Value;

                max_prod = int.Parse(currentRowview["OnAvailable"].ToString()) / inf.Value;

                #region"Space max production"

                string space_maxprod = "               ";

                if (max_prod.ToString().Length == 1)
                    space_maxprod = "                                      ";
                if (max_prod.ToString().Length == 2)
                    space_maxprod = "                                    ";
                if (max_prod.ToString().Length == 3)
                    space_maxprod = "                                  ";
                if (max_prod.ToString().Length == 4)
                    space_maxprod = "                                ";
                if (max_prod.ToString().Length == 5)
                    space_maxprod = "                              ";
                if (max_prod.ToString().Length == 6)
                    space_maxprod = "                            ";
                if (max_prod.ToString().Length == 7)
                    space_maxprod = "                          ";
                if (max_prod.ToString().Length == 8)
                    space_maxprod = "                        ";

                #endregion"Space max production"

                information += space_maxprod + max_prod + "<br/>";

            }

            information += "--------------------------------------------------------------------------------------------------<br/>";

            #endregion"Description Expand"
        }

        void Update_Description(DataGridViewRow currentRowview)
        {
            if (currentRowview == null)
                return;

            if (currentRowview.Index == -1)
                return;

            if (currentRowview.Cells["PartNumber"].Value == null)
                return;

            if (_bindingSource_table_StockroomTreeView.Count == 0)
                return;

            #region"Description Short"

            string discription_short;
            discription_short = "<font color='Blue'><b>" + currentRowview.Cells["PartNumber"].Value.ToString() + "</b></font>    ->";

            if (currentRowview.Cells["Description"].Value.ToString() == "")
                discription_short += "  This component has not any Description.";
            else
                discription_short += "<i>" + currentRowview.Cells["Description"].Value.ToString() + "</i>";

            #endregion"Description Short"

            if (currentRowview.Cells["OnAvailable"].Value == DBNull.Value)
                currentRowview.Cells["OnAvailable"].Value = 0;

            int OnAvailable = int.Parse(currentRowview.Cells["OnAvailable"].Value.ToString());
        }

        string DescriptionExpand(string stringToDescription, int OnAvailable)
        {
            string information;

            if (stringToDescription == "")
            {
                information = "This component has not been assigned to any other project.<br/>";
                return information;
            }

            Graphics graphics = this.CreateGraphics();
            float dot_Size = graphics.MeasureString(".", this.Font).Width;
            float space_Size = graphics.MeasureString(". ", this.Font).Width;
            float maxSpace = 0;

            int padRight = 0;
            var dict = MyCode.GetDict(stringToDescription);

            foreach (KeyValuePair<string, int> inf in dict)
            {
                if (maxSpace < graphics.MeasureString(inf.Key.PadRight(inf.Key.Length + 5, '.'), this.Font).Width)
                {
                    maxSpace = graphics.MeasureString(inf.Key.PadRight(inf.Key.Length + 5, '.'), this.Font).Width;
                    string max_string = inf.Key.PadRight(inf.Key.Length + 5, '.');
                    padRight = (Int32)(maxSpace / space_Size);
                }
            }

            string headtext;
            string headline;
            if (maxSpace < 135)
            {
                maxSpace = 135;
                headtext = string.Format("Project Name".PadRight(16)) + string.Format("Number of Comp used".PadRight(24)) + "Enough to produced<br/>";
                headline = string.Format("|".PadLeft(24, '-')) + string.Format("|".PadLeft(40, '-')) + "----------------------------------<br/>";
            }
            else
            {
                headtext = string.Format("Project Name".PadRight(padRight)) + string.Format("Number of Comp used".PadRight(24)) + "Enough to produced<br/>";
                headline = "---------------------------|-------------------------------------------|-----------------------------------<br/>";
            }
            information = headtext + headline;

            //     if (inf.Key.Length + count < padRight)
            //         rowInfo = inf.Key.PadRight(padRight - inf.Key.Length);
            //     else
            //         rowInfo = inf.Key.PadRight(inf.Key.Length + count);                

            foreach (KeyValuePair<string, int> inf in dict)
            {
                string rowInfo = "";
                string temp = "";
                int count = 0;
                int max_prod;
                /*   

                   spacerowinfo = graphics.MeasureString(inf.Key.PadRight(inf.Key.Length + 5, '.'), this.Font).Width;

                   float ddd = maxSpace - spacerowinfo;

                   if (is_short)
                       count = 25;
                   else
                       count = (Int32)Math.Round((ddd / dot_Size), 0);

                 */

                temp = inf.Key;

                rowInfo = temp.PadRight(temp.Length + 5 + count, '.');


                float actual_space = graphics.MeasureString(rowInfo, this.Font).Width;

                while (actual_space < maxSpace - dot_Size)
                {
                    rowInfo = temp.PadRight(inf.Key.Length + count + 6, '.');
                    actual_space = graphics.MeasureString(rowInfo, this.Font).Width;
                    count++;
                }

                rowInfo += inf.Value.ToString();

                count = 1;
                while (actual_space < 250)
                {
                    rowInfo = rowInfo.PadRight(inf.Key.Length + count, '.');
                    actual_space = graphics.MeasureString(rowInfo, this.Font).Width;
                    count++;
                }

                max_prod = OnAvailable / inf.Value;
                information += rowInfo + max_prod + "<br/>";
            }

            information += "--------------------------------------------------------------------------------------------------<br/>";

            return information;
        }

        CellDoubleClick_EventArgs CellDoubleClick_Args;
        public new void CellDoubleClick_Event(object sender, CellDoubleClick_EventArgs e)
        {
            CellDoubleClick_Args = e;
            //     _partNumberTag = e.CurrentRowActive.Cells["PartNumber"].Value.ToString().Remove(4);

            if (CellDoubleClick_Args.ComponentInformations == null)
                return;

            ProcessInput(MyCode.ProcessMode.Receive);
        }

        #region"DataGridViewExtended" 

        void DataGridViewInitialize()
        {
           
        }

        void DataGridViewExtended_CurrentRowActive(object sender, CurrentRowActive_EventArgs e)
        {
            if (!this.Visible)
                return;

            if (e.CurrentRowActive.Index == -1)
                return;

            if (e.CurrentRowActive.Cells["PartNumber"].Value.ToString().Length <= 4)
                return;

            Update_Description(e.CurrentRowActive);

            //Inicializo el sistema para Adjust Inventory by defauld,
            CellDoubleClick_Args = new CellDoubleClick_EventArgs(e.CurrentRowActive, MyCode.ProcessMode.Adjust);

            ProcessInput(MyCode.ProcessMode.Adjust);

        }

        void DataGridViewExtended_Save_Requested(object sender, Save_Requested_EventArgs e)
        {
            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
        }

        public void DataGridViewExtended_CellDoubleClick_Event(object sender, CellDoubleClick_EventArgs e)
        {
            CellDoubleClick_Event(sender, e);

        }

        void DataGridViewExtended_Receive_MouseEnter_Event(object sender, DataGridViewMouseEnterEventArgs e)
        {
            Update_Description(e.CurrentRowActive);
        }

        #endregion"DataGridViewExtended"     

        #region"Methods concerning Received_CellDoubleClickEvent"

        void ProcessInput(MyCode.ProcessMode value)
        {
            tabPage_Received.SuspendLayout();
            _isReceivedProcess = true;

            if (_selectedComponet == null)
                return;

            panel_ComponentControl.Controls.Remove(_selectedComponet);

            if (CellDoubleClick_Args != null && CellDoubleClick_Args.ComponentInformations != null)
                _selectedComponet = CellDoubleClick_Args.ComponentInformations.SeletedComponent;

            if (_selectedComponet == null)
                return;

            _selectedComponet.Dock = DockStyle.Fill;
            panel_ComponentControl.Controls.Add(_selectedComponet);


            switch (value)
            {
                case MyCode.ProcessMode.AddNew:
                    {
                        _selectedComponet.EditMode = MyCode.EditMode.Delete;
                        SelectNode();
                        DescriptionResume();
                        AddNewProcess();

                        break;
                    }
                case MyCode.ProcessMode.Receive:
                    {
                        _selectedComponet.EditMode = MyCode.EditMode.View;
                        SelectNode();
                        DescriptionResume();
                        ReceivedProcess();

                        break;
                    }
                case MyCode.ProcessMode.Adjust:
                    {
                        _selectedComponet.EditMode = MyCode.EditMode.View;
                        SelectNode();
                        DescriptionResume();
                        AdjustedProcess();

                        break;
                    }
                default:
                    {

                        break;
                    }
            }

            tabPage_Received.ResumeLayout();
        }

        void DescriptionResume()
        {
            Description = "";

            if (CellDoubleClick_Args.ComponentInformations == null)
                return;

            if (CellDoubleClick_Args.ComponentInformations.PartNumber.Contains("014-"))
                Description = _selectedComponet.Description.Replace("Ω", "ohm");

            if (CellDoubleClick_Args.ComponentInformations.PartNumber.Contains("018-"))
                Description = _selectedComponet.Description.Replace("" + '\u03BC', "u");

            if (Description.Contains("volts"))
                Description = Description.Replace("volts", "v");

            if (Description.Length > 20)
                Description = Description.Replace(" ", "");

            if (Description.Length > 20)
                Description = Description.Remove(21);
        }

        /// <summary>
        /// Select the correspond node in the treeView.
        /// </summary>
        /// <param name="e"></param>
        void SelectNode()
        {

        }


        //**********************************Process for all components.***************************************

        void AddNewProcess()
        {
            try
            {
        //        textBox_Received_Quantity.KeyUp -= TextBox_Received_Quantity_KeyUp;
      //          textBox_Received_Quantity.KeyUp -= TextBox_Adjusted_Quantity_KeyUp;
                button_Add.Click -= Button_Received_Click;

                comboBox_PartNumber.Enabled = true;
                comboBox_PartNumber.Text = CellDoubleClick_Args.ComponentInformations.PartNumber;

                label_Received_Quantity.Text = "Received Quantity";
         //       textBox_Received_Quantity.Enabled = true;
         //       textBox_Received_Quantity.Text = "";
         //       textBox_Received_Quantity.KeyUp += TextBox_AddNew_Quantity_KeyUp;

                label_Received_Date.Text = "Add New Date";
                dateTimePicker.Enabled = false;

                comboBox_Manufacturer.Enabled = true;
                comboBox_Model_Number.Enabled = true;
                comboBox_Supplier.Enabled = true;
                button_Add_Other.Enabled = false;

                comboBox_Manufacturer.Text = CellDoubleClick_Args.ComponentInformations.Manufacturer;
                comboBox_Model_Number.Text = CellDoubleClick_Args.ComponentInformations.ModelNumber;
                comboBox_Supplier.Text = CellDoubleClick_Args.ComponentInformations.Supplier;

                _messageString = "GroupBox printing references.";
                printingReferences.Enabled = true;
                printingReferences.ReelsCounter = ReelsCounter;
                printingReferences.PartNumber = CellDoubleClick_Args.ComponentInformations.PartNumber;
                printingReferences.DescriptionToPrint = Description;
                printingReferences.EnablePrintsProperties = true;

                #region"Mouse position and click, TabIndex order"

                MyCode.MouseUtility.MousePointerPosition(comboBox_PartNumber);

                MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);

          //      textBox_Received_Quantity.TabIndex = 0;



                printingReferences.TabIndex = 1;



                flowLayoutPanel.TabIndex = 2;
                button_Add.TabIndex = 0;

                #endregion"Mouse position and click, TabIndex order"

                button_Add.Text = "Add New";
                button_Add.Enabled = true;
                button_Add.Click += Button_AddNew_Click;

                button_Adjustment.Enabled = false;
                button_Save.Enabled = false;
                button_Cancel.Enabled = true;
                button_Edit.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(_messageString + " This component has some problem, AddNewProcess Ln 1746, Problem definition Components",
                                                                                     error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ReceivedProcess()
        {
            try
            {
                _messageString = "Remove old handles.";
             //   textBox_Received_Quantity.KeyUp -= TextBox_AddNew_Quantity_KeyUp;
             //   textBox_Received_Quantity.KeyUp -= TextBox_Adjusted_Quantity_KeyUp;

                button_Add.Click -= Button_AddNew_Click;
                button_Add.Click -= Button_Received_Click;

                _messageString = "ComponentInformations.PartNumber";
                comboBox_PartNumber.Enabled = false;
                comboBox_PartNumber.Text = CellDoubleClick_Args.ComponentInformations.PartNumber;

                label_Received_Quantity.Text = "Amounts Received";
              //  textBox_Received_Quantity.Enabled = true;
              //  textBox_Received_Quantity.Text = "";
              //  textBox_Received_Quantity.AllowNegative = false;
             //   textBox_Received_Quantity.KeyUp += TextBox_Received_Quantity_KeyUp;

                label_Received_Date.Text = "Received Date";
                dateTimePicker.Enabled = false;

                _messageString = "Enabled comboBox";
                comboBox_Manufacturer.Enabled = false;
                comboBox_Model_Number.Enabled = false;
                comboBox_Supplier.Enabled = false;
                button_Add_Other.Enabled = false;

                _messageString = "Initialize Manufacturer, Model and Supplier.";
                comboBox_Manufacturer.Text = CellDoubleClick_Args.ComponentInformations.Manufacturer;
                comboBox_Model_Number.Text = CellDoubleClick_Args.ComponentInformations.ModelNumber;
                comboBox_Supplier.Text = CellDoubleClick_Args.ComponentInformations.Supplier;

                _messageString = "GroupBox printing references.";
                printingReferences.Enabled = true;
                printingReferences.ReelsCounter = ReelsCounter;
                printingReferences.PartNumber = CellDoubleClick_Args.ComponentInformations.PartNumber;
                printingReferences.DescriptionToPrint = Description;
                printingReferences.EnablePrintsProperties = true;

                _messageString = "Mouse Positions.";
                #region"Mouse position and click, TabIndex order"

        //        MyCode.MouseUtility.MousePointerPosition(textBox_Received_Quantity);

                MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);

         //       textBox_Received_Quantity.TabIndex = 0;



                printingReferences.TabIndex = 1;

                flowLayoutPanel.TabIndex = 2;
                button_Add.TabIndex = 0;

                #endregion"Mouse position and click, TabIndex order"

                _messageString = "Initialize button Add.";
                button_Add.Text = "Received";
                button_Add.Enabled = false;
                button_Add.Click += Button_Received_Click;

                _messageString = "Initialize buttons Adjustment, Save, Cancel, Edit.";
                button_Adjustment.Enabled = false;
                button_Save.Enabled = false;
                button_Cancel.Enabled = true;
                button_Edit.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(_messageString + " This component has some problem, ReceivedProcess Ln 1818, Problem definition Components",
                                                                                    error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void AdjustedProcess()
        {
            try
            {
                if (CellDoubleClick_Args.ComponentInformations == null)
                    return;

                _messageString = "Unwire KeyUp events";
             //   textBox_Received_Quantity.KeyUp -= TextBox_AddNew_Quantity_KeyUp;
             //   textBox_Received_Quantity.KeyUp -= TextBox_Received_Quantity_KeyUp;

                comboBox_PartNumber.Enabled = false;
                label_Received_Quantity.Text = "Adjust Quantity";
                comboBox_PartNumber.Text = CellDoubleClick_Args.ComponentInformations.PartNumber;

                _messageString = "TextBox Received wire KeyUp events";
                label_Received_Date.Text = "Adjust Date";
              //  textBox_Received_Quantity.Enabled = true;
             //   textBox_Received_Quantity.Text = "";
             //   textBox_Received_Quantity.AllowNegative = true;
             //   textBox_Received_Quantity.KeyUp += TextBox_Adjusted_Quantity_KeyUp;

                label_Received_Date.Text = "Ajusted Date";
                dateTimePicker.Enabled = false;

                comboBox_Manufacturer.Enabled = false;
                comboBox_Model_Number.Enabled = false;
                comboBox_Supplier.Enabled = false;
                button_Add_Other.Enabled = false;

                _messageString = "comboBox_Manufacturer.Text";
                comboBox_Manufacturer.Text = CellDoubleClick_Args.ComponentInformations.Manufacturer;
                comboBox_Model_Number.Text = CellDoubleClick_Args.ComponentInformations.ModelNumber;
                comboBox_Supplier.Text = CellDoubleClick_Args.ComponentInformations.Supplier;

                _messageString = "GroupBox printing references.";
                printingReferences.Enabled = true;
                printingReferences.ReelsCounter = ReelsCounter;
                printingReferences.PartNumber = CellDoubleClick_Args.ComponentInformations.PartNumber;
                printingReferences.DescriptionToPrint = Description;
                printingReferences.EnablePrintsProperties = true;

                _messageString = "Mouse position and click";
                #region"Mouse position and click, TabIndex order"

                //     MyCode.MouseUtility.MousePointerPosition(textBox_Received_Quantity);

                //     MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);

        //        textBox_Received_Quantity.TabIndex = 0;



                printingReferences.TabIndex = 1;

                flowLayoutPanel.TabIndex = 2;
                button_Add.TabIndex = 0;

                #endregion"Mouse position and click, TabIndex order"

                button_Add.Text = "Received";
                button_Add.Enabled = false;

                _messageString = "button_Adjustment.Enabled";
                button_Adjustment.Enabled = true;
                button_Save.Enabled = false;
                button_Cancel.Enabled = true;
                button_Edit.Enabled = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(_messageString + " This component has some problem, AdjustedProcess Ln 1886, Problem definition Components",
                                                                                    error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        bool AuthenticateAdjusted()
        {
          //  QuantityReceived = textBox_Received_Quantity.NumericText != "" ? Convert.ToInt32(textBox_Received_Quantity.NumericText) : 0;

            if (QuantityReceived == 0)
            {
                MessageBox.Show("Adjusted Quantity must not be 0", "Are you mising some information",
                                                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

           //     MyCode.MouseUtility.MousePointerPosition(textBox_Received_Quantity);
                //      MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);

            //    textBox_Received_Quantity.Clear();
            //    textBox_Received_Quantity.Focus();
                return false;
            }

            return true;
        }


        void ComboBox_PartNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;

        //    MyCode.MouseUtility.MousePointerPosition(textBox_Received_Quantity);
            MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);

        //    textBox_Received_Quantity.Focus();
        }


        void TextBox_AddNew_Quantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;

         //   if (textBox_Received_Quantity.Text.Contains("-"))
         //   {
         //       MessageBox.Show("Add New Quantity must be greater than 0, Are you adjust some information?",
         //                                           "AddNew Process.", MessageBoxButtons.OK, MessageBoxIcon.Error);
         //       textBox_Received_Quantity.Clear();
         //       return;
         //   }

            printingReferences.QuantityReceived = QuantityReceived;

            MyCode.MouseUtility.MousePointerPosition(comboBox_Manufacturer);
            MyCode.MouseUtility.DoMouseClick(MouseButtons.Left);

            comboBox_Manufacturer.Focus();
        }

        void TextBox_Received_Quantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;

        //    if (textBox_Received_Quantity.Text.Contains("-"))
        //    {
         //       MessageBox.Show("Received Quantity must be greater than 0, Are you adjust some information?",
         //                                           "Received Process.", MessageBoxButtons.OK, MessageBoxIcon.Error);
         //       textBox_Received_Quantity.Clear();
         //       return;
         //   }

         //   QuantityReceived = MyCode.IntParseFast(textBox_Received_Quantity.Text);

            printingReferences.QuantityReceived = QuantityReceived;
        }

        void TextBox_Adjusted_Quantity_KeyUp(object sender, KeyEventArgs e)
        {
        //    if (textBox_Received_Quantity.Text.Contains("-"))
        //    {
        //        if (textBox_Received_Quantity.Prefix.Contains("+"))
        //        {
        //            textBox_Received_Quantity.Prefix = "";
         //           textBox_Received_Quantity.Text = "";
         //           textBox_Received_Quantity.AppendText("-");
         //       }
         //   }
         //   else
         //       textBox_Received_Quantity.Prefix = "+";

            if (e.KeyData != Keys.Enter)
                return;

            printingReferences.QuantityReceived = QuantityReceived;

            MyCode.MouseUtility.MousePointerPosition(button_Adjustment);

            button_Adjustment.Focus();
        }



        void ComboBox_Manufacturer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            comboBox_Model_Number.Focus();
        }

        void ComboBox_Model_Number_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            comboBox_Supplier.Focus();
        }

        void ComboBox_Supplier_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (CellDoubleClick_Args.ProcessInfor == MyCode.ProcessMode.Adjust)
                button_Adjustment.Focus();
        }


        void PrintingReferences_PrintsLabelsReady(object sender, Custom_Events_Args.PrintsLabelsReady_EventArgs e)
        {
            button_Add.Enabled = true;
        }


        void Button_AddNew_Click(object sender, EventArgs e)
        {
            _bindingSource_tableStockRoom.SuspendBinding();

            _partNumber = comboBox_PartNumber.Text;

            var stockRoomIndex = _bindingSource_tableStockRoom.Find("PartNumber", _partNumber);

            // if Stockroom_Index != -1, this component index was found, all ready existed.
            if (stockRoomIndex != -1)
            {
                MessageBox.Show(" Error: This PartNumber is already in use in the StockRoom Table", "Please choose a different PartNumber.");
                return;
            }

            Button _thisbuttun = (Button)sender;

            _thisbuttun.Enabled = false;

         //   textBox_Received_Quantity.Enabled = false;

          //  textBox_Received_Quantity.KeyUp -= TextBox_AddNew_Quantity_KeyUp;

            int _counter;

            DataRowView _newComponentRow = (DataRowView)_bindingSource_tableStockRoom.AddNew();

            _newComponentRow["PartNumber"] = _partNumber;
            _newComponentRow["Description"] = _selectedComponet.Controls[0].Controls["label_Description_" + CellDoubleClick_Args.ComponentInformations.SeletedComponentName].Text;
            _newComponentRow["Manufacturer"] = comboBox_Manufacturer.Text;
            _newComponentRow["ModelNumber"] = comboBox_Model_Number.Text;
            _newComponentRow["Supplier"] = comboBox_Supplier.Text;
            _newComponentRow["OnHand"] = QuantityReceived;
            _newComponentRow["OnAvailable"] = QuantityReceived;

            var dict = MyCode.GetDict(_newComponentRow["Reel_Number"].ToString());

            dict.Add("Counter", 1);
            _counter = 1;

            for (int i = 0; i < NumberofReels; i++)
            {
                dict.Add(_partNumber.Replace("-", "") + _counter, Qty_perReels);
                _counter++;
            }

            dict["Counter"] = _counter;

            string reel_numbers = MyCode.GetString(dict);

            _newComponentRow["Reel_Number"] = reel_numbers;

            _newComponentRow.EndEdit();
            _bindingSource_tableStockRoom.EndEdit();

            _bindingSource_tableStockRoom.ResumeBinding();

            try
            {
                On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de StockRoom DataBase " + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ProcessInput(MyCode.ProcessMode.Adjust);
        }

        void Button_Received_Click(object sender, EventArgs e)
        {
            var stockRoomIndex = _bindingSource_tableStockRoom.Find("PartNumber", CellDoubleClick_Args.ComponentInformations.PartNumber);

            // if Stockroom_Index == -1, this component index not was found.
            if (stockRoomIndex == -1)
            {
                MessageBox.Show("Error: PartNumber not found in StockRoom table", "Please contact system administrator.");
                return;
            }

            _bindingSource_tableStockRoom.SuspendBinding();

            Button _thisbutton = (Button)sender;

            _thisbutton.Enabled = false;
         //   textBox_Received_Quantity.Enabled = false;
            //    textBox_Received_Quantity.KeyUp -= textBox_Received_Quantity_KeyUp;


            DataRowView _currentRow = (DataRowView)_bindingSource_tableStockRoom[stockRoomIndex];

            _currentRow["OnHand"] = Check_is_no_null(_currentRow["OnHand"]) + QuantityReceived;
            _currentRow["OnAvailable"] = Check_is_no_null(_currentRow["OnAvailable"]) + QuantityReceived;

            var dict = MyCode.GetDict(_currentRow["Reel_Number"].ToString());

            if (dict.ContainsKey("Counter"))
                ReelsCounter = dict["Counter"];
            else
            {
                dict.Add("Counter", 1);
                ReelsCounter = 1;
            }

            //checkBox_printLabels.Checked
            if (true)
            {

                /*
                ZebraPrintsPCBLabels zebraPrints = new ZebraPrintsPCBLabels(
                                                                CellDoubleClick_Args.ComponentInformations.PartNumber,
                                                                printingReferences.DescriptionToPrint,
                                                                ReelsCounter,
                                                                printingReferences.NumberOfReels,
                                                                DateTime.Now
                                                               );
                zebraPrints.Prints();
                */
                printingReferences.Enabled = false;
            }



            for (int i = 0; i < NumberofReels; i++)
            {
                dict.Add(CellDoubleClick_Args.ComponentInformations.PartNumber.Replace("-", "") + ReelsCounter, Qty_perReels);
                ReelsCounter++;
            }

            dict["Counter"] = ReelsCounter;

            string reel_numbers = MyCode.GetString(dict);

            _currentRow["Reel_Number"] = reel_numbers;

            _currentRow.EndEdit();
            _bindingSource_tableStockRoom.EndEdit();

            _bindingSource_tableStockRoom.ResumeBinding();

            try
            {
                On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de StockRoom DataBase " + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Button_Adjusted_Click(object sender, EventArgs e)
        {
            if (!AuthenticateAdjusted())
                return;

            var stockRoomIndex = _bindingSource_tableStockRoom.Find("PartNumber", CellDoubleClick_Args.ComponentInformations.PartNumber);

            // if Stockroom_Index == -1, this component index not was found.
            if (stockRoomIndex == -1)
            {
                MessageBox.Show("PartNumber not found into StockRoom table", "Error, please report to system administrator.");
                return;
            }

            Button _thisbuttun = (Button)sender;

            _thisbuttun.Enabled = false;

          //  textBox_Received_Quantity.Enabled = false;
          //  textBox_Received_Quantity.KeyUp -= TextBox_Adjusted_Quantity_KeyUp;

            _bindingSource_tableStockRoom.SuspendBinding();

            DataRowView _currentRow = (DataRowView)_bindingSource_tableStockRoom[stockRoomIndex];

         //   if (textBox_Received_Quantity.Text.Contains("+"))
         //   {
         //       _currentRow["OnHand"] = Check_is_no_null(_currentRow["OnHand"]) + QuantityReceived;
         //       _currentRow["OnAvailable"] = Check_is_no_null(_currentRow["OnAvailable"]) + QuantityReceived;
         //   }

         //   if (textBox_Received_Quantity.Text.Contains("-"))
         //   {
         //       if (Check_is_no_null(_currentRow["OnAvailable"]) >= -QuantityReceived)
          //      {
         //           _currentRow["OnHand"] = Check_is_no_null(_currentRow["OnHand"]) + QuantityReceived;
         //           _currentRow["OnAvailable"] = Check_is_no_null(_currentRow["OnAvailable"]) + QuantityReceived;
         //       }
          //      else
          //      {
          //          _currentRow["OnHand"] = _currentRow["OnHold"];
          //          _currentRow["OnAvailable"] = 0;
          //      }

          //  }

          //  textBox_Received_Quantity.Clear();

            _currentRow.EndEdit();
            _bindingSource_tableStockRoom.EndEdit();

            _bindingSource_tableStockRoom.ResumeBinding();

            try
            {
                On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error al tratar de StockRoom DataBase " + ex.Message, @"Error on DataBase.",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Button_Save_Click(object sender, EventArgs e)
        {
            DataRowView rowToSave = (DataRowView)_bindingSource_tableStockRoom[_bindingSource_tableStockRoom.Find("PartNumber", CellDoubleClick_Args.ComponentInformations.PartNumber)];

            rowToSave["Description"] = _selectedComponet.Description;

            rowToSave["Manufacturer"] = comboBox_Manufacturer.Text;
            rowToSave["ModelNumber"] = comboBox_Model_Number.Text;
            rowToSave["Supplier"] = comboBox_Supplier.Text;

            rowToSave.EndEdit();
            _bindingSource_tableStockRoom.EndEdit();

            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));

            AdjustedProcess();
        }

        void Button_Cancel_Click(object sender, EventArgs e)
        {
            AdjustedProcess();
        }

        void Button_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox_PartNumber.Enabled = false;
                label_Received_Quantity.Text = "Edit Mode";

            //    textBox_Received_Quantity.Text = "";
            //    textBox_Received_Quantity.Enabled = false;

                label_Received_Date.Text = "Edit Mode";
                dateTimePicker.Enabled = true;

                _selectedComponet.EditMode = MyCode.EditMode.Edit;

                comboBox_Manufacturer.Enabled = true;
                comboBox_Model_Number.Enabled = true;
                comboBox_Supplier.Enabled = true;
                button_Add_Other.Enabled = true;

                grouper_ComponentProperties.TabIndex = 0;
            //    textBox_Received_Quantity.TabIndex = 0;

                flowLayoutPanel.TabIndex = 2;
                button_Save.TabIndex = 0;

                button_Add.Text = "Received";
                button_Add.Enabled = false;

                button_Adjustment.Enabled = false;
                button_Save.Enabled = true;
                button_Cancel.Enabled = true;
                button_Edit.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show(_messageString + " This component has some problem", "ReceivedProcess Ln 3241, Problem definition Components");
            }
        }


        //End Process for all components.

        #endregion"Methods concerning Received_CellDoubleClickEvent"

        /// <summary>
        /// Return an int, value is null, return 0;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int Check_is_no_null(object value)
        {
            return value != DBNull.Value ? Convert.ToInt32(value) : 0;
        }

        void FlowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            var betuin = 6;
            var spaceneed = (flowLayoutPanel.Controls.Count + 1) * betuin;

            int nextWidth = 0;
            if (flowLayoutPanel.Controls.Count > 2)
                nextWidth = (flowLayoutPanel.Width - spaceneed) / flowLayoutPanel.Controls.Count;

            if (nextWidth > 70)
                button_Add.Width = button_Adjustment.Width = button_Save.Width =
                                                    button_Cancel.Width = button_Edit.Width = nextWidth;

        }

        #region"TabControlExtende"

        Plexiglass ShowResizeRectangle;
        void InitTabControlExtend()
        {
            // TabControl_Inventory.HideTab("tabPage_TreeViewSetting");

            customTabControl_Received.MouseDownResizeGripEvent += TabControl_Inventory_MouseDownResizeGripEvent;
            customTabControl_Received.MouseUpResizeGripEvent += TabControl_Inventory_MouseUpResizeGripEvent;
            customTabControl_Received.ResizeGripEvent += TabControl_Inventory_ResizeGripEvent;
            customTabControl_Received.SelectedIndexChanged += TabControl_Inventory_SelectedIndexChanged;

            //  TabControl_Inventory.HideTab(tabPage_NoteEditor);
            //  TabControl_Inventory.HideTab(tabPage_TreeViewSetting);
            //customTabControl_Received.HideTab(tabPage_AddNewItem);
            //customTabControl_Received.ShowTab(tabPage_Pictures);
        }

        void TabControl_Inventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void TabControl_Inventory_MouseUpResizeGripEvent(object sender, MouseEventArgs e)
        {
            ShowResizeRectangle.Close();

            splitContainer_Vertical.SplitterDistance = ShowResizeRectangle.Location.X;
            splitContainer_Horizontal.SplitterDistance = ShowResizeRectangle.Height;

            customTabControl_Received.Visible = true;

            //  StockRoomSetting.SplitterX = splitContainerVertical.SplitterDistance;
            //  StockRoomSetting.SplitterY = splitContainerHorizontal.SplitterDistance;

            //  SaveUserSetting();
        }

        void TabControl_Inventory_MouseDownResizeGripEvent(object sender, MouseEventArgs e)
        {
            Point location = splitContainer_Vertical.SplitterRectangle.Location;
            Size sizeCon = splitContainer_Vertical.Panel2.ClientSize;
            var rectangleImage = (Bitmap)ScreenImage.GetScreenshot(Handle, location, sizeCon);

            ShowResizeRectangle = new Plexiglass(this)
            {
                ClientSize = sizeCon,
                RectImage = rectangleImage,
                Location = PointToScreen(location)
            };

            customTabControl_Received.Visible = false;
        }

        void TabControl_Inventory_ResizeGripEvent(object sender, Custom_Events_Args.ResizeGrip_EventArgs e)
        {
            ShowResizeRectangle.Location = new Point(ShowResizeRectangle.Location.X + e.X, ShowResizeRectangle.Location.Y);
            ShowResizeRectangle.ClientSize = new Size(ShowResizeRectangle.ClientSize.Width - e.X, ShowResizeRectangle.ClientSize.Height + e.Y);
        }

        #endregion"TabControlExtende"

    }
}

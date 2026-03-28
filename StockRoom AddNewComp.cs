using MyStuff11net;
using System.Data;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;
using SpeechSynthesizerBase_EventArgs = MyStuff11net.Custom_Events_Args.SpeechSynthesizerBase_EventArgs;

namespace StockRoom11net
{
    public partial class StockRoom_AddNewComp : BaseTemple
    {
        readonly BindingSource _bindingSource_StockRoomInventory;
        /// <summary>
        /// Reference to table of Code and Range used to defined the database content.
        /// </summary>
        readonly BindingSource _bindingSource_CodeTreeView;

        readonly DataTable codeDataTable = new DataTable("CodeDataTable");



        public StockRoom_AddNewComp(BindingSource bindingSourceStockRoomInventory,
                                    BindingSource bindingSource_CodeTreeView, List<string> departList)
        {
            try
            {
                InitializeComponent();
                DepartList = departList;

                #region"CodeTreeView Table to List"

                if (bindingSource_CodeTreeView == null)
                {
                    MessageBox.Show(@"The input CodeTreeView bindingSource is Null", @"Error on initialization",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _bindingSource_CodeTreeView = bindingSource_CodeTreeView;

                codeDataTable = ((DataSet)_bindingSource_CodeTreeView.DataSource).Tables[_bindingSource_CodeTreeView.DataMember];

                #endregion"CodeTreeView Table to List"

                #region"ColumnsCollection StockRoomInventory"
                MessagePositionString = "stockroom == null";
                if (bindingSourceStockRoomInventory == null)
                {
                    MessageBox.Show(@"The input stockroom bindingSource is Null", @"Error on initialization",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _bindingSource_StockRoomInventory = bindingSourceStockRoomInventory;

                MessagePositionString = "tempDataTable";
                var tempDataTable = ((DataSet)bindingSourceStockRoomInventory.DataSource).Tables[bindingSourceStockRoomInventory.DataMember];

                MessagePositionString = "columnsCollection";
                ColumnsCollection = tempDataTable.Columns;

                #endregion"ColumnsCollection StockRoomInventory"

                Load += StockRoom_AddNewComp_Load;
                Shown += StockRoom_AddNewComp_Shown;

                Initialize_DataGridView_AddNewComp();
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                @"StockRoom AddNewComp has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void StockRoom_AddNewComp_Load(object sender, EventArgs e)
        {
            flowLayoutPanel_ItemsProperties.Resize += FlowLayoutPanel_MultipleWidth_Resize;
            flowLayoutPanel_Buttons.Resize += FlowLayoutPanelResize;

            FlowLayoutPanel_MultipleWidth_Resize(flowLayoutPanel_ItemsProperties, e);
            FlowLayoutPanelResize(flowLayoutPanel_Buttons, e);

            InitializeComboBoxPartNumberDescription();

            InitializeButtons();
            GetListFrontDataTable();
        }

        System.Windows.Forms.Timer timerDelay;
        void StockRoom_AddNewComp_Shown(object sender, EventArgs e)
        {
            timerDelay = new System.Windows.Forms.Timer
            {
                Interval = 50
            };
            timerDelay.Tick += new EventHandler(TimerDelay_Tick);
            timerDelay.Start();


        }

        void TimerDelay_Tick(object sender, EventArgs e)
        {
            timerDelay.Stop();

            //Note: focused node will call CalculateNextAvailablePartNumber(_currentFocusedNodeProperties.CodeString);
        }

        void GetListFrontDataTable()
        {
            // NodeList = GetListFromDataTable(codeDataTable);

        }

        void InitializeComboBoxPartNumberDescription()
        {
            comboBoxExtended_PartNumber.LabelText = "PartNumber";
            comboBoxExtended_PartNumber.Text = "Select a new PartNumber...";
            comboBoxExtended_Description.LabelText = "Description";
            comboBoxExtended_Description.Text = "PartNumber's Description...";
        }

        #region"DataGridView_AddNewComp"

        void Initialize_DataGridView_AddNewComp()
        {
            InitializeDataGridViewBase(dataGridViewExtended_AddNewComp);

            dataGridViewExtended_AddNewComp.DataSource = _bindingSource_StockRoomInventory;

            dataGridViewExtended_AddNewComp.CustomEdit = MyCode.EditMode.View;
        }

        #endregion"DataGridView_AddNewComp"

        #region"Button events"

        int addedCompIndex;
        SortedList<int, DataRowView> addedComp = new SortedList<int, DataRowView>();

        void InitializeButtons()
        {
            button_AddNew.Enabled = false;
            button_Save.Enabled = false;

            button_Delete.Enabled = false;
        }

        void Button_AddNew_Click(object sender, EventArgs e)
        {
            button_AddNew.Enabled = false;
            button_Save.Enabled = true;
            button_Delete.Enabled = true;

            CurrentStatusReference.SelectedColor = ColorTranslator.FromHtml("#FFA456B8");
            CurrentStatusReference.Selected = true;

            object newObject = _bindingSource_StockRoomInventory.AddNew();
            DataRowView newDataRowView = newObject as DataRowView;

            newDataRowView["PartNumber"] = comboBoxExtended_PartNumber.Text;
            newDataRowView["Description"] = comboBoxExtended_Description.Text;
            newDataRowView["Status"] = CurrentStatusReference.ToString();

            addedCompIndex++;
            addedComp.Add(addedCompIndex, newDataRowView);

            InitializeComboBoxPartNumberDescription();

            On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("A new partNumber been added to the database " +
                                                                                    newDataRowView["PartNumber"].ToString()));
        }

        void Button_Save_Click(object sender, EventArgs e)
        {
            button_Save.Enabled = false;

            On_Save_Requested(new Save_Requested_EventArgs(MyCode.NotificationEvents.DataBaseUpDated));
        }

        void Button_Delete_Click(object sender, EventArgs e)
        {
            string partNumberDataGridView = dataGridViewExtended_AddNewComp.CurrentRowActive.Cells["PartNumber"].Value.ToString();

            string partNumberDelete = "";
            DataRowView addedRowToDelete;

            foreach (KeyValuePair<int, DataRowView> ddd in addedComp)
            {
                if (ddd.Value["PartNumber"].ToString().Contains(partNumberDataGridView))
                {
                    partNumberDelete = ddd.Value["PartNumber"].ToString();
                    addedRowToDelete = ddd.Value;

                    dataGridViewExtended_AddNewComp._dataGridView.Rows.Remove(dataGridViewExtended_AddNewComp.CurrentRowActive);

                    if (_bindingSource_StockRoomInventory.Contains(addedRowToDelete))
                    {
                        _bindingSource_StockRoomInventory.Remove(addedRowToDelete);
                        _bindingSource_StockRoomInventory.ResetBindings(false);
                    }

                    addedComp.Remove(ddd.Key);

                    if (addedComp.Count == 0)
                        button_Delete.Enabled = false;

                    button_Save.Enabled = true;

                    On_SpeechSynthesizerBase(new SpeechSynthesizerBase_EventArgs("An partNumber to been removed from the database " + partNumberDelete));

                    return;
                }
            }

            MessageBox.Show(new Form() { TopMost = true }, @"The delete option only applies to components added on this occasion, " +
                                                           @"it is not possible to remove old components using this tool.",
                                                           @"You try to delete a component that has not been generated this time.",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion"Button events"



        void FlowLayoutPanel_MultipleWidth_Resize(object sender, EventArgs e)
        {
            try
            {
                FlowLayoutPanel flowLayoutPanel = sender as FlowLayoutPanel;

                int spaceNeeded = 40;
                int nextWidth = 0;
                nextWidth = flowLayoutPanel.Width - spaceNeeded;

                foreach (Control control in flowLayoutPanel.Controls)
                {
                    ComboBoxExtended comboBox = control as ComboBoxExtended;
                    comboBox.SelectionLength = 0;

                    int pCent = MyCode.CastAsInt(comboBox.Tag);
                    control.Width = (nextWidth * pCent) / 100;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"StockRoom AddNewComponent has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Will resize the panel and it's contend.
        /// The sender most be a FlowLayoutPanel control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FlowLayoutPanelResize(object sender, EventArgs e)
        {
            FlowLayoutPanel flowLayoutPanel = sender as FlowLayoutPanel;

            int between = 4;
            int countCount = flowLayoutPanel.Controls.Count;
            int spaceNeeded = countCount * between;

            int nextWidth = (flowLayoutPanel.Width - spaceNeeded) / countCount;

            foreach (Control control in flowLayoutPanel.Controls)
            {
                control.Width = nextWidth;
            }
        }

    }
}

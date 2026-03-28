using System.ComponentModel;

namespace MyStuff11net
{
    public partial class DataGridViewSetting : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BackgroundColor
        {
            get
            {
                return grouper_DataGridViiewSetting.BackgroundColor;
            }
            set
            {
                grouper_DataGridViiewSetting.BackgroundColor = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return grouper_DataGridViiewSetting.GroupTitle;
            }
            set
            {
                grouper_DataGridViiewSetting.GroupTitle = value;
            }
        }

        KeyValuePair<string, List<ColumnSetting>> _settingName;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KeyValuePair<string, List<ColumnSetting>> SettingName
        {
            get
            {
                if (dataGridView.RowCount == 0)
                    return _settingName;

                foreach (ColumnSetting columnsetting in _settingName.Value)
                {
                    columnsetting.Edit = (bool)dataGridView.Rows[0].Cells[columnsetting.Name].Value;
                    columnsetting.VisibleSystemSetting = (bool)dataGridView.Rows[1].Cells[columnsetting.Name].Value;
                    columnsetting.VisibleUserSetting = (bool)dataGridView.Rows[2].Cells[columnsetting.Name].Value;
                }
                return _settingName;
            }
            set
            {
                _settingName = value;
            }
        }

        public DataGridViewSetting()
        {
            InitializeComponent();

            Load += new EventHandler(DataGridViewSetting_Load);
        }

        public DataGridViewSetting(KeyValuePair<string, List<ColumnSetting>> settingName)
        {
            InitializeComponent();

            SettingName = settingName;

            Load += new EventHandler(DataGridViewSetting_Load);
            grouper_DataGridViiewSetting.Click += new EventHandler(Grouper_DataGridViewSetting_Click);
            dataGridView.Click += new EventHandler(Grouper_DataGridViewSetting_Click);
            dataGridView.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellContentClick);
        }

        void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != 1)
                return;

            if (e.ColumnIndex == 0)
                return;

            if (!((bool)dataGridView.CurrentCell.EditedFormattedValue))
                dataGridView[e.ColumnIndex, 2].Value = false;
        }

        void Grouper_DataGridViewSetting_Click(object sender, EventArgs e)
        {
            OnClick(new EventArgs());
        }

        private void DataGridViewSetting_Load(object sender, EventArgs e)
        {
            grouper_DataGridViiewSetting.GroupTitle = _settingName.Key;

            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToOrderColumns = true;

            DataGridViewCell cellCheckBox = new DataGridViewCheckBoxCell(false);

            DataGridViewCellStyle cellStyleColumnParameter = new DataGridViewCellStyle();
            cellStyleColumnParameter.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyleColumnParameter.BackColor = Color.Cornsilk;
            cellStyleColumnParameter.DataSourceNullValue = false;
            cellStyleColumnParameter.NullValue = false;

            DataGridViewColumn columnParameter = new DataGridViewTextBoxColumn();

            columnParameter.CellTemplate = new DataGridViewTextBoxCell();
            columnParameter.DefaultCellStyle = cellStyleColumnParameter;
            columnParameter.Name = "Parameter";
            columnParameter.HeaderText = "Parameter";
            columnParameter.Frozen = true;
            columnParameter.Width = 150;

            dataGridView.Columns.Add(columnParameter);

            dataGridView.Rows.Add(new object[] { "EditSystemSetting" });
            dataGridView.Rows.Add(new object[] { "VisibleSystemSetting" });
            dataGridView.Rows.Add(new object[] { "VisibleUserSetting" });


            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cellStyle.BackColor = Color.Cornsilk;
            cellStyle.DataSourceNullValue = false;
            cellStyle.NullValue = false;

            foreach (ColumnSetting columnsetting in _settingName.Value)
            {
                DataGridViewColumn newcolumn = new DataGridViewCheckBoxColumn(false);

                newcolumn.CellTemplate = cellCheckBox;
                newcolumn.DefaultCellStyle = cellStyle;
                newcolumn.Name = columnsetting.Name;
                newcolumn.HeaderText = columnsetting.Name;

                dataGridView.Columns.Add(newcolumn);

                dataGridView.Rows[0].Cells[columnsetting.Name].Value = columnsetting.Edit;
                dataGridView.Rows[1].Cells[columnsetting.Name].Value = columnsetting.VisibleSystemSetting;
                dataGridView.Rows[2].Cells[columnsetting.Name].Value = columnsetting.VisibleUserSetting;
            }
        }


    }
}

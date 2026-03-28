using System.ComponentModel;

namespace MyStuff11net
{
    public class DataGridViewBarGraphColumn : DataGridViewColumn
    {
        public int MaxValue;
        public bool NeedcsRecalc = true;

        public DataGridViewBarGraphColumn()
        {
            CellTemplate = new DataGridViewBarGraphCell();
            ReadOnly = true;
        }

        public override object Clone()
        {
            var col = base.Clone() as DataGridViewBarGraphColumn;
            return col;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override sealed DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                base.CellTemplate = value;
            }
        }

        public void CalcMaxValue()
        {
            if (!NeedcsRecalc)
                return;

            for (var rowIndex = 0; rowIndex < DataGridView.Rows.Count; rowIndex++)
            {
                if (DataGridView.Rows[rowIndex].Cells[DisplayIndex].Value != DBNull.Value)
                    MaxValue = Math.Max(MaxValue, Convert.ToInt32(DataGridView.Rows[rowIndex].Cells[DisplayIndex].Value));
            }

            NeedcsRecalc = false;
        }
    }
}

using System.ComponentModel;

namespace MyStuff11net
{
    public class DataGridViewStatusColumn : DataGridViewImageColumn
    {
        public DataGridViewStatusColumn()
        {
            CellTemplate = new DataGridViewStatusCell();
        }
    }

    public class DataGridViewStatusCell : DataGridViewImageCell
    {
        public DataGridViewStatusCell()
        {
            ValueType = typeof(bool);
        }

        protected override object GetFormattedValue(object value,
            int rowIndex,
            ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            bool statusVal = (bool)value;
            return statusVal ? Properties.Resources.Document_cpp : Properties.Resources.Document_csharp;
        }
    }
}
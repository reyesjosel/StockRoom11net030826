using System.ComponentModel;
using System.Data;

namespace MyStuff11net
{
    public static class DataTableExts
    {

        #region"Convert List to DataTable, bindingSource to datatable"

        public static DataTable ToDatatable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add
                    (
                        prop.Name,
                        (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType
                    );

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable MakeDataTable<T>(IEnumerable<T> list, CreateRowDelegate<T> fn)
        {
            DataTable table = new DataTable();

            foreach (T t in list)
            {
                object[] rowData = fn(t);

                if (table.Columns.Count == 0)
                {
                    for (int i = 0; i < rowData.Length; i++)
                        table.Columns.Add();
                }
                table.Rows.Add(rowData);
            }
            return (table);
        }

        public delegate object[] CreateRowDelegate<T>(T t);

        //You'd have to call this with something like
        //   DataTable resulsTable = results.MakeDataTable(row => new object[] {row.customer, row.Order});

        #endregion"Convert List to DataTable, bindingSource to datatable"

    }
}

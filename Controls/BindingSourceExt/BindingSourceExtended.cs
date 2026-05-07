using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace StockRoom11net.Controls.BindingSourceExt
{
    public class BindingSourceExtended : BindingSource
    {
        // Add custom properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TableName { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDirty { get; set; }
        
        // Constructor
        public BindingSourceExtended()
        {
            IsDirty = false;
            ListChanged += OnListChanged;
        }
        
        public BindingSourceExtended(object dataSource, string dataMember) : base(dataSource, dataMember)
        {
            IsDirty = false;
            ListChanged += OnListChanged;
        }
        
        // Track changes
        private void OnListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted)
            {
                IsDirty = true;
            }
        }
        
        // Custom methods
        public void ResetDirtyFlag()
        {
            IsDirty = false;
        }
        
        public T? GetCurrentItem<T>() where T : class
        {
            return Current as T;
        }
        
        public List<T> GetAllItems<T>() where T : class
        {
            return this.Cast<T>().ToList();
        }
    }
        
    public static class BindingListExtensions
    {
        /// <summary>
        /// Converts a BindingList<T> to a DataTable using property reflection.
        /// The resulting DataTable supports BindingSource.Filter via DataView.
        /// </summary>
        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            var table = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                // Handle nullable types
                Type colType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                table.Columns.Add(prop.Name, colType);
            }

            foreach (var item in source)
            {
                var row = table.NewRow();
                foreach (var prop in props)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }

}
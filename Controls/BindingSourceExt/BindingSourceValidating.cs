using StockRoom11net.Data.Entities;
using System.ComponentModel;

namespace StockRoom11net.Controls.BindingSourceExt
{
    public interface IBindingSourceValidating
    {
        string TableName { get; set; }
    }

    public class BindingSourceValidating<T> : BindingSource, IBindingSourceValidating where T : class
    {
        public event EventHandler<ValidationEventArgs>? ValidationFailed;

        /// <summary>
        /// Gets the name of the generic type T
        /// </summary>
        public string TypeName => typeof(T).Name;

        /// <summary>
        /// Gets the full name of the generic type T (including namespace)
        /// </summary>
        public string TypeFullName => typeof(T).FullName ?? typeof(T).Name;

        /// <summary>
        /// Gets the name of the "table" or entity type that this BindingSource is associated with.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TableName { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDirty { get; set; }

        /// <summary>
        /// Note: This method is not actually used for database operations, but it can
        /// be useful for logging or debugging to identify the type of items in the BindingSource.
        /// </summary>
        /// <returns>The name of the generic type T</returns>
        public string GetTableName()
        {
            return TableName;
        }


        public BindingSourceValidating()
        {
            IsDirty = false;
            TableName = TypeName;
            ListChanged += OnListChanged;
        }

        private void OnListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged ||
                e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted)
            {

                IsDirty = true;

                // For ItemDeleted, the item is already removed — accessing e.NewIndex would throw.
                if (e.ListChangedType != ListChangedType.ItemDeleted)
                {
                    var item = this[e.NewIndex] as T;
                    if (item != null && !ValidateItem(item))
                    {
                        ValidationFailed?.Invoke(this, new ValidationEventArgs(item, e.NewIndex));
                    }
                }
            }
        }
        
        protected virtual bool ValidateItem(T item)
        {
            // Override in derived classes
            return true;
        }
        
        public T? GetCurrentTypedItem()
        {
            return Current as T;
        }
        
        public IEnumerable<T> GetTypedItems()
        {
            return this.Cast<T>();
        }
        
        public void RefreshItem(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                ResetItem(index);
            }
        }

        // Custom methods
        public void ResetDirtyFlag()
        {
            IsDirty = false;
        }

        public T? GetCurrentItem()
        {
            return Current as T;
        }

        public List<T> GetAllItems()
        {
            return this.Cast<T>().ToList();
        }

        /// <summary>
        /// Returns all items as a typed list, safely handling both typed-list-backed and
        /// DataView-backed sources.  When the DataSource is a DataView, each DataRowView is
        /// mapped to T by matching column names to writable public properties (case-insensitive)
        /// via reflection — no per-entity boilerplate required at call sites.
        /// </summary>
        public List<T> GetItems()
        {
            var result = new List<T>();

            foreach (var item in this)
            {
                if (item is T typedItem)
                {
                    // Typed-list backed BindingSource — direct use.
                    result.Add(typedItem);
                }
                else if (item is System.Data.DataRowView rowView)
                {
                    // DataView-backed BindingSource — map columns → T properties by name.
                    var entity = Activator.CreateInstance<T>();

                    var props = typeof(T).GetProperties()
                                         .Where(p => p.CanWrite)
                                         .ToDictionary(p => p.Name, StringComparer.OrdinalIgnoreCase);

                    foreach (System.Data.DataColumn col in rowView.Row.Table.Columns)
                    {
                        if (!props.TryGetValue(col.ColumnName, out var prop))
                            continue;

                        var rawValue = rowView[col.ColumnName];
                        if (rawValue == DBNull.Value || rawValue == null)
                        {
                            prop.SetValue(entity, null);
                        }
                        else
                        {
                            var targetType = Nullable.GetUnderlyingType(prop.PropertyType)
                                             ?? prop.PropertyType;
                            prop.SetValue(entity, Convert.ChangeType(rawValue, targetType));
                        }
                    }

                    result.Add(entity);
                }
            }

            return result;
        }

    }
    
    public class ValidationEventArgs : EventArgs
    {
        public object Item { get; }
        public int Index { get; }
        
        public ValidationEventArgs(object item, int index)
        {
            Item = item;
            Index = index;
        }
    }
}
using StockRoom11net.Data.Entities;
using System.ComponentModel;

namespace StockRoom11net.Controls.BindingSourceExt
{
    public class BindingSourceValidating<T> : BindingSource where T : class
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

        // Add custom properties
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
            return TypeName;
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

                var item = this[e.NewIndex] as T;
                if (item != null && !ValidateItem(item))
                {
                    ValidationFailed?.Invoke(this, new ValidationEventArgs(item, e.NewIndex));
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

        public T? GetCurrentItem<T>() where T : class
        {
            return Current as T;
        }

        public List<T> GetAllItems<T>() where T : class
        {
            return this.Cast<T>().ToList();
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
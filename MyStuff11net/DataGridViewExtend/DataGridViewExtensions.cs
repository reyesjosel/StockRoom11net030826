namespace MyStuff11net.DataGridViewExtended
{
    public static class DataGridViewExtensions
    {
        public static bool RemoveSelectedRows(this DataGridView dgv)
        {
            try
            {
                if (dgv.RowCount > 0)
                {
                    if (dgv.SelectedRows.Count == dgv.Rows.Count)
                    {
                        dgv.DataSource = null;
                    }

                    foreach (DataGridViewRow row in dgv.SelectedRows)
                    {
                        dgv.Rows.Remove(row);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

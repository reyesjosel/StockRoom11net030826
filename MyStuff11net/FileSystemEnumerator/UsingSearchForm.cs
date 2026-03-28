namespace MyStuff11net
{
    internal sealed class UsingSearchForm
    {
        private void InitializeSerachForm()
        {
            using (var sf = new SearchForm())
            {
                if (sf.ShowDialog().Equals(DialogResult.OK))
                {
                    string strPath = sf.m_strPath;
                    strPath = strPath.TrimStart();
                    strPath = strPath.TrimEnd();
                    if (!strPath.Equals(string.Empty) && File.Exists(strPath))
                        OpenFile(strPath);
                }
            }

        }

        private void OpenFile(string filePath)
        {

        }
    }
}

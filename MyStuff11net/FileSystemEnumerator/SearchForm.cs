//using Delimon.Win32.IO;
namespace MyStuff11net
{
    public partial class SearchForm : Form
    {
        public string m_strPath = "";
        private bool m_bCancel;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            strPath = Path.GetPathRoot(strPath);

            comboPath.Items.Add(strPath);
            comboPath.SelectedIndex = 0;
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            int nIndex = listboxResult.SelectedIndex;
            if (nIndex == 0 || nIndex == listboxResult.Items.Count - 1)
                nIndex = 0;
            else
            {
                string strPath = listboxResult.SelectedItem.ToString();
                if (strPath.IndexOf("Cancelled by user") == -1)
                    nIndex = 0;
                // buttonSelect.Enabled = true;
            }
        }

        private void OnPathDropDown(object sender, EventArgs e)
        {
            foreach (string strItem in comboPath.Items)
                if (strItem == comboPath.Text)
                    return;

            comboPath.Items.Add(comboPath.Text);
        }

        private void OnButtonBrowse(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                Description = "Browser for Folder where Pictures and database file, created from these Pictures " +
                              "by Explorer (Thumbs.db), can be located:"
            })
            {
                if (DialogResult.OK == fbd.ShowDialog())
                {
                    comboPath.Text = fbd.SelectedPath;
                    comboPath.Items.Add(fbd.SelectedPath);

                    OnButtonStart(sender, e);
                }
            }
        }

        private void OnButtonStart(object sender, EventArgs e)
        {
            m_bCancel = false;
            try
            {
                using (FileSystemEnumerator fse = new FileSystemEnumerator(
                                                                            comboPath.Text,
                                                                            "Thumbs.db",
                                                                            true,
                                                                            checkInclude.Checked,
                                                                            0))
                {
                    IEnumerator<FileInfo> ien = fse.MatchesFiles().GetEnumerator();
                    ien.Dispose();

                    listboxResult.Items.Clear();
                    //  listboxResult.Items.Add("Size             Modified  Full Path");
                    foreach (FileInfo fi in fse.MatchesFiles())
                    {
                        //   string fiResult = string.Format("{0,-14:#,##0}{1,12:d} {2}", fi.Length, fi.LastWriteTime, fi.FullName);
                        //   string fiResult2 = string.Format("{0}{1,-14:#,##0}{2,12:d} ", fi.FullName, fi.Length, fi.LastWriteTime);
                        listboxResult.Items.Add(fi.FullName);

                        if (m_bCancel)
                        {
                            listboxResult.Items.Add("Cancelled by user");
                            break;
                        }
                    }

                    listboxResult.Items.Add(string.Format("Found {0} matches", listboxResult.Items.Count - 1));
                }
            }
            catch (Exception ex)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, string.Format("Exception {0}: {1}", ex.GetType().Name, ex.Message),
                                              "Thumbs Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnButtonStop(object sender, EventArgs e)
        {
            m_bCancel = true;
            //buttonStop.Enabled = false;
        }

        private void OnButtonSelect(object sender, EventArgs e)
        {
            m_strPath = listboxResult.SelectedItem.ToString();
            m_strPath = m_strPath.Substring(26);
        }

        private void listboxResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // This event will be executed after DoubleClick.

        }

        private void listboxResult_DoubleClick(object sender, EventArgs e)
        {
            // This event will be executed before MouseDoubleClick. 
            m_strPath = listboxResult.SelectedItem.ToString();
            m_strPath.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
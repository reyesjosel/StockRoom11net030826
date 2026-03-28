//using Delimon.Win32.IO;
namespace MyStuff11net
{
    internal sealed class UsingFileSystemEnumerator
    {
        /// <summary>
        /// pathsToSearch, Semicolon- or comma-delimited list of paths to search.
        /// </summary>
        ComboBox comboPathsToSearch = new ComboBox();

        ListBox listboxResult = new ListBox();
        /// <summary>
        /// includeSubDirs, If true, subdirectories are searched.
        /// </summary>
        RadioButton includeSubDirs = new RadioButton();
        /// <summary>
        /// fileTypesToMatch, Semicolon- or comma-delimited list of wildcard file specs to match.
        /// </summary>
        string fileTypesToMatch = "Thumbs.db";

        private void OnButtonStart(object sender, EventArgs e)
        {
            bool m_bCancel = false;
            try
            {
                using (FileSystemEnumerator fse = new FileSystemEnumerator(
                                                                            comboPathsToSearch.Text,
                                                                            fileTypesToMatch,
                                                                            true,
                                                                            includeSubDirs.Checked,
                                                                            0))
                {
                    IEnumerator<FileInfo> ien = fse.MatchesFiles().GetEnumerator();
                    ien.Dispose();

                    listboxResult.Items.Clear();
                    listboxResult.Items.Add("Size             Modified  Full Path");
                    foreach (FileInfo fi in fse.MatchesFiles())
                    {
                        listboxResult.Items.Add(string.Format("{0,-14:#,##0}{1,12:d} {2}", fi.Length, fi.LastWriteTime, fi.FullName));

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
                MessageBox.Show(string.Format("Exception {0}: {1}", ex.GetType().Name, ex.Message),
                  "Thumbs Cleaner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

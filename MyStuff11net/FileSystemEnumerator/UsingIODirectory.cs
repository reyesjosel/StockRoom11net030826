using System.Collections.ObjectModel;

namespace MyStuff11net
{
    internal sealed class UsingIODirectory
    {
        static int _index;
        static ObservableCollection<FileDirectoryModel> dir = new ObservableCollection<FileDirectoryModel>();

        static void DirSearch(FileDirectoryModel startDir)
        {
            _index = startDir.ID;
            try
            {
                #region"Directory"
                foreach (string directoryName in Directory.GetDirectories(startDir.Location))
                {
                    _index++;

                    FileDirectoryModel newDir = new FileDirectoryModel
                    (
                        _index,
                        startDir.ID,
                        FileAttributes.Directory,
                        directoryName,
                        Path.GetFileName(directoryName)
                    );
                    dir.Add(newDir);

                    DirSearch(newDir);
                }
                #endregion"Directory"

                #region"Files"
                foreach (string fileName in Directory.GetFiles(startDir.Location))
                {
                    _index++;

                    FileDirectoryModel newFile = new FileDirectoryModel
                    (
                        _index,
                        startDir.ID,
                        FileAttributes.Normal,
                        fileName,
                        Path.GetFileName(fileName)
                    );
                    dir.Add(newFile);
                }
                #endregion"Files"
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        void Usage()
        {
            FileDirectoryModel _rootdir = new FileDirectoryModel
                (
                    1,
                    1,
                    FileAttributes.Directory,
                    "C",
                    @"C:\"
                );

            DirSearch(_rootdir);
        }

    }
}

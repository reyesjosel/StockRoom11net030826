using System.Data;
using System.Diagnostics;

namespace MyStuff11net
{
    public class PdfFileScan
    {
        #region"StatusReport"        
        public delegate void StatusReportEventHandler(object sender, string report);

        public event StatusReportEventHandler StatusReportEvent;
        #endregion"StatusReport"

        #region"RowProcessDone"        
        public delegate void RowProcessDoneEventHandler(string partNumber, List<Tuple<string, string>> listDocInf);

        /// <summary>
        /// This event fire at the end of priocessing the bindingsource.
        /// </summary>
        public event RowProcessDoneEventHandler RowProcessDoneEvent;
        #endregion"RowProcessDone"

        #region"ScanProcessDone"        
        public delegate void ScanProcessDoneEventHandler(object sender);

        /// <summary>
        /// This event fire at the end of priocessing the bindingsource.
        /// </summary>
        public event ScanProcessDoneEventHandler ScanProcessDoneEvent;
        #endregion"ScanProcessDone"

        public class ItemDocInf
        {
            public ItemDocInf(object rowObjt)
            {
                var row = rowObjt as DataRowView;
                PartNumber = row["PartNumber"].ToString();
                listDocInf = new List<Tuple<string, string>>();
            }

            public string PartNumber;
            public List<Tuple<string, string>> listDocInf;

        }

        int totalItems;
        Stopwatch watch;
        BindingSource _bindingSource;
        DepartmentInformation _currentDepartmentLogIn;
        DataView _dv;

        public PdfFileScan(DataView dv, DepartmentInformation currentDepartmentLogIn)
        {
            _dv = dv;
            totalItems = dv.Count;
            _currentDepartmentLogIn = currentDepartmentLogIn;
        }

        public PdfFileScan(BindingSource bindingSource, DepartmentInformation currentDepartmentLogIn)
        {
            _bindingSource = bindingSource;
            totalItems = bindingSource.Count;
            _currentDepartmentLogIn = currentDepartmentLogIn;
        }

        public void StarScanning()
        {
            watch = Stopwatch.StartNew();
            DocumentFileScandProcess();
        }

        /// <summary>
        /// For each item in stockroom table will scan the given path and
        /// update status information column with the names of documents found.
        /// </summary>
        /// <param name="pathRootFolder"></param>
        /// <param name="documentsExtensionAcepted"></param>
        void DocumentFileScandProcess()
        {
            try
            {
                var indexItems = 0;

                foreach (var rowObjt in _bindingSource)
                {
                    ProcessDocumentScan(rowObjt);
                    indexItems++;
                    StatusReportEvent?.Invoke(this, "Scanned " + indexItems + " of " + totalItems);
                }
            }
            catch (Exception error)
            {
                var errrr = error.Message;
            }
        }

        void ProcessDocumentScan(object rowObjt)
        {
            var row = rowObjt as DataRowView;
            var partNumber = row["PartNumber"].ToString();
            var rowInf = new List<Tuple<string, string>>();
            var listDocInf = new List<Tuple<string, string>>();

            foreach (DocumentsAddressItem documentsAddressItem in _currentDepartmentLogIn.DepartmentDocumentsAddressItems)
            {
                if (!Directory.Exists(documentsAddressItem.DocumentsAddressValueDirectory))
                    continue;

                rowInf = DocumentFoundMatchFiles(documentsAddressItem.DocumentsAddressValueDirectory,
                                                         "*" + partNumber + "*", documentsAddressItem.DocumentsExtensionAcepted);

                if (rowInf.Count == 0)
                    continue;

                listDocInf.AddRange(rowInf);
                RowProcessDoneEvent?.Invoke(partNumber, rowInf);
            }

            //if no docments founded, do nothing.
            if (listDocInf.Count == 0)
                return;


        }

        /// <summary>
        /// Will scan the pathRootFolder parameter directory and found any file match fileToMach parameter.
        /// </summary>
        /// <param name="pathRootFolder"></param>
        /// <param name="fileToMatch"></param>        
        List<Tuple<string, string>> DocumentFoundMatchFiles(string pathRootFolder, string fileNameToMatch, string fileExtToMatch)
        {
            var listDocInf = new List<Tuple<string, string>>();

            using (FileSystemEnumerator fse = new FileSystemEnumerator(pathRootFolder,
                                                                        fileExtToMatch,
                                                                        true,
                                                                        true,
                                                                        500000))
            {
                var xxx = fse.FoundMatchFiles(fileNameToMatch);

                foreach (FileDirectoryModel document in xxx)
                {
                    try
                    {
                        var extInf = document.Ext;
                        var nameInf = document.Name.Replace("." + extInf, "");
                        listDocInf.Add(new Tuple<string, string>(extInf, nameInf));
                    }
                    catch (Exception ex)
                    {
                        var errorr = ex.Message;
                    }
                }
            }
            return listDocInf;
        }

        //Destructor
        ~PdfFileScan()
        {
            watch.Stop();

            ScanProcessDoneEvent?.Invoke(this);
            StatusReportEvent?.Invoke(this, "Finished scanning documents " + (watch.ElapsedMilliseconds / 1000) + " seconds.");

            watch = null;
            _bindingSource = null;
            StatusReportEvent = null;
            ScanProcessDoneEvent = null;
            _currentDepartmentLogIn = null;
        }
    }
}

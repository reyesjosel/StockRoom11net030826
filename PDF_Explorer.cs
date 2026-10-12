using Microsoft.Web.WebView2.WinForms;
using PDFXCviewAxLib;
using StockRoom11net.Controls;
using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Controls.ResourcesCache;
using StockRoom11net.Data.Services;
using StockRoom11net.Properties;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics.Colors;
using System.Runtime.InteropServices;
using WinFormsUI.Docking;
using static StockRoom11net.Controls.Custom_Events_Args;
using ActiveDataSheet_EventArgs = StockRoom11net.Controls.Custom_Events_Args.ActiveDataSheet_EventArgs;
using Resources = StockRoom11net.Properties.Resources;


namespace StockRoom11net
{
    public partial class Pdf_explorer : DockContent
    {
        // Injected EF Core services
        private readonly IAppService _iappService;

        string MessageDebugPosition;
        string _lastDataSheet;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Index { get; set; }

        EmployeeInformation _currentEmployeesLogIn;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EmployeeInformation CurrentEmployeesLogIn
        {
            get
            {
                if (_currentEmployeesLogIn == null)
                    _currentEmployeesLogIn = new EmployeeInformation();

                return _currentEmployeesLogIn;
            }
            set
            {
                _currentEmployeesLogIn = value;
            }
        }

        /// <summary>
        /// Default datasheet file, 
        /// </summary>
        FileInfo _defaultDataSheetFile;
        string _dataSheet_File_FullPath;

        /// <summary>
        /// Set the fileName where the control will luck.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DataSheet_File_FullPath
        {
            get { return _dataSheet_File_FullPath; }
            set
            {
                try
                {
                    if (value == null)
                    {
                        ClearPDF_Viewer();
                        _dataSheet_File_FullPath = _defaultDataSheetFile.FullName;
                        return;
                    }

                    _dataSheet_File_FullPath = value;

                    if (InvokeRequired)
                    {
                        Invoke(new EventHandler(delegate (object o, EventArgs e)
                        {
                            //Do your work here.
                            ProcessDataSheet();
                        }));
                    }
                    else
                    {
                        //Do your work here.
                        ProcessDataSheet();
                    }
                }
                catch (Exception error)
                {
                    using (var form = new Form { TopMost = true })
                    {
                        MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                              @", Break code at position " + MessageDebugPosition,
                            @"Pdf_explorer, Pdf_explorer fail in SetDataSheet",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void ProcessDataSheet()
        {
            MessageDebugPosition = "Set_data_sheet();";
            
            if(string.IsNullOrEmpty(_dataSheet_File_FullPath))
            {
                ClearPDF_Viewer();
                return;
            }

            string _ext = Path.GetExtension(_dataSheet_File_FullPath).ToLower();

            switch (_ext)
            {
                case ".pdf":
                    {
                        Icon = Resources.file_pdf;
                        break;
                    }
                case ".doc":
                    {
                        Icon = Resources.file_doc;
                        break;
                    }
                case ".docx":
                    {
                        Icon = Resources.file_docx;
                        break;
                    }
            }

            Text = Path.GetFileName(_dataSheet_File_FullPath);
            ToolTipText = _dataSheet_File_FullPath;
            Set_data_sheet();
        }
               

        public string PdfFile = "";
        WebView2 webView2;

        public Pdf_explorer(IAppService iappService)
        {
            try
            {
                InitializeComponent();

                _iappService = iappService ?? throw new ArgumentNullException(nameof(iappService));

                webView2 = new WebView2
                {
                    Dock = DockStyle.Fill
                };
                Controls.Add(webView2);

                MessageDebugPosition = "ClearPDF_Viewer()";
                ClearPDF_Viewer();
                TabPageContextMenuStrip = contextMenuStripPdfViewer;

                MessageDebugPosition = "_defaultDataSheetFile = new FileInfo";
                _defaultDataSheetFile = new FileInfo(Settings.Default.DataBaseAddress + "\\DataSheets\\" + "No Empty Data Sheet.PDF");
            }
            catch (Exception error)
            {
                string msg = MessageDebugPosition + error.Message;
                DialogResult = DialogResult.Cancel;
                return;
            }
            return;
        }

        void Open_tool_strip_button_click(object sender, EventArgs e)
        {
            using (var openFileDialogStockRoomManager = new OpenFileDialog
            {
                Title = @"Please found any PDF file.",
                FileName = "*.PDF",
                Filter = @"PDF (*.pdf)|*.pdf",
                DefaultExt = "(*.pdf)|*.pdf"
            })
            {
                if (openFileDialogStockRoomManager.ShowDialog(this).Equals(DialogResult.OK))
                {
                    LoadPdf(openFileDialogStockRoomManager.FileName);
                }
            }
        }

        void Pdf_explorer_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeContextMenuStripPdfViewer();

                DockPanel.ShowDocumentIcon = true;
                Icon = Resources.Empy_Icon;
                Text = "";

                _lastDataSheet = _defaultDataSheetFile.FullName;
                DataSheet_File_FullPath = _defaultDataSheetFile.FullName;
            }
            catch (Exception error)
            {
                string msg = error.Message;
                MessageBox.Show(msg);
            }
        }

        void InitializeContextMenuStripPdfViewer()
        {
            #region"Initialize"
            contextMenuStripPdfViewer.BackColor = Color.LightGoldenrodYellow;
            contextMenuStripPdfViewer.ImeMode = ImeMode.On;
            contextMenuStripPdfViewer.Items.AddRange(new ToolStripItem[] {
            toolStripMenuItem_OpenContainingFolder,
            ToolStripMenuItemTheUserHaveNotRight});
            contextMenuStripPdfViewer.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            contextMenuStripPdfViewer.Name = "PreviewDataGridViewContextMenuStrip";
            contextMenuStripPdfViewer.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStripPdfViewer.ShowImageMargin = false;
            contextMenuStripPdfViewer.Size = new Size(301, 48);
            #endregion"Initialize"

            contextMenuStripPdfViewer.Opening += ContextMenuStripPdfViewer_Opening;
            contextMenuStripPdfViewer.MouseLeave += ContextMenuStripPdfViewer_MouseLeave;

            toolStripMenuItem_OpenContainingFolder.Click += ToolStripMenuItem_OpenContainingFolder_Click;
        }
        
        void ContextMenuStripPdfViewer_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_dataSheet_File_FullPath))
                {   //No dataSheets file, no containing folder.
                    e.Cancel = true;
                    return;
                }

                contextMenuStripPdfViewer.Items.Clear();


                if (CurrentEmployeesLogIn.AccessLevel < Utilities.AccessLevel.Manager)
                {
                    contextMenuStripPdfViewer.Items.AddRange(new ToolStripItem[]
                                                             {
                                                                    ToolStripMenuItemTheUserHaveNotRight
                                                             });
                    return;
                }

                if (CurrentEmployeesLogIn.AccessLevel == Utilities.AccessLevel.Manager)
                {
                    contextMenuStripPdfViewer.Items.AddRange(new ToolStripItem[]
                                                             {
                                                                    toolStripMenuItem_OpenContainingFolder
                                                             });
                }
            }
            catch (Exception)
            { }
        }

        void ContextMenuStripPdfViewer_MouseLeave(object sender, EventArgs e)
        {
            contextMenuStripPdfViewer.Close();
        }

        private void ToolStripMenuItem_OpenContainingFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.GetFullPath(ToolTipText);
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
            }
            catch (Exception)
            {
                // If the installation process fail....
                DialogResult = DialogResult.Cancel;
            }
        }

        void Pdf_explorer_shown(object sender, EventArgs e)
        {
            if (Text.Contains("Open Dialog"))
            {
                using (var openFileDialogSchematic = new OpenFileDialog
                {
                    Title = @"Please select any PDF file.",
                    FileName = "*.pdf",
                    Filter = @"Any PDF file (*.pdf)|*.pdf",
                    DefaultExt = "(*.pdf)|*.pdf"
                })
                {
                    if (openFileDialogSchematic.ShowDialog(this).Equals(DialogResult.OK))
                    {
                        try
                        {
                            var dataSheetFile = new FileInfo(openFileDialogSchematic.FileName);
                            
                            if (dataSheetFile.Exists)
                            {
                                _lastDataSheet = dataSheetFile.Name;
                                LoadPdf(dataSheetFile.FullName);
                                Text = dataSheetFile.Name;
                            }
                            else
                            {
                                _lastDataSheet = "";
                                Text = @"No Data Sheet Found";
                                LoadPdf(_defaultDataSheetFile.FullName);

                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show(@"PDF Schematic File not found");
                        }
                    }
                }
            }


        }

        void Set_data_sheet()
        {
            try
            { 
                string pageToOpen = "";
                _defaultDataSheetFile = new FileInfo(_dataSheet_File_FullPath);

                if (_dataSheet_File_FullPath.Contains("#pag"))
                {
                    int indexOf = _dataSheet_File_FullPath.IndexOf("#", StringComparison.Ordinal);
                    if (_dataSheet_File_FullPath.Length > indexOf)
                    {
                        pageToOpen = _dataSheet_File_FullPath.Substring(indexOf);
                        string fileName = _dataSheet_File_FullPath.Remove(indexOf);
                        _defaultDataSheetFile = new FileInfo(fileName);
                    }
                }

                MessageDebugPosition = "Set_data_sheet() -> if (dataSheetFile.Exists)";
                if (_defaultDataSheetFile.Exists)
                {
                    _lastDataSheet = _defaultDataSheetFile.Name;

                    if (pageToOpen.Length == 0)
                    {
                        //_defaultDataSheetFile.FullName "D:\\ProductionManagement\\DataSheets\\1N5819.pdf";
                        LoadPdf(_dataSheet_File_FullPath);
                    }
                    else
                    {
                        pageToOpen = pageToOpen.Replace("#", "/A#");  //"/A#"; ":"

                        //On_StatusBarMessage(new StatusBarMessage_EventArgs("PDF dataSheet loaded " + _defaultDataSheetFile.Name + pageToOpen));
                        LoadPdf(_dataSheet_File_FullPath + pageToOpen);
                    }
                }
                else
                {
                    MessageDebugPosition = @"Set_data_sheet() -> _lastDataSheet = ";
                    ToolTipText = "";
                    _lastDataSheet = "";
                    Icon = Resources.Empy_Icon;
                    Text = @"No Data Sheet Found";
                    _dataSheet_File_FullPath = Settings.Default.DataBaseAddress + "\\DataSheets\\" + "No Empty Data Sheet.PDF";
                    LoadPdf(_dataSheet_File_FullPath);
                }

            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                          @", Break code at position " + MessageDebugPosition,
                        @" Pdf_explorer,  Pdf_explorer fail in Set_data_sheet()",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void LoadPdf(string path)
        {
            await webView2.EnsureCoreWebView2Async();
            webView2.CoreWebView2.Navigate(new Uri(path).AbsoluteUri + "#toolbar=0");
            // Optional: hide the toolbar -> new Uri(path).AbsoluteUri + "#toolbar=0"

            // controls the DockPanel tab caption
            string _tabText = Path.GetFileName(path);
            if (_tabText.Contains("No Empty Data Sheet"))
            {
                TabText = " ";
                Icon = Resources.Empy_Icon;
            }
            else
                TabText = _tabText;
        }

        void Pdf_explorer_form_closing(object sender, FormClosingEventArgs e)
        {
            Dispose(true);
        }

        void ClearPDF_Viewer()
        {
            MessageDebugPosition = "ClearPDF_Viewer()";
            Text = "";
            Icon = Resources.Empy_Icon;
            _lastDataSheet = Settings.Default.DataBaseAddress + "\\DataSheets\\" + "No Empty Data Sheet.PDF";
            _dataSheet_File_FullPath = _lastDataSheet;
        }
    }
}
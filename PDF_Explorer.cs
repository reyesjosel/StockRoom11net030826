using MyStuff11net;
using MyStuff11net.Properties;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WinFormsUI.Docking;
using ActiveDataSheet_EventArgs = MyStuff11net.Custom_Events_Args.ActiveDataSheet_EventArgs;
using Resources = MyStuff11net.Properties.Resources;
using System.ComponentModel;

namespace StockRoom11net
{
    public partial class Pdf_explorer : DockContent
    {
        string MessagePositionString;
        string _lastDataSheet;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Index { get; set; }


        Employee _currentEmployeesLogIn;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Employee CurrentEmployeesLogIn
        {
            get
            {
                if (_currentEmployeesLogIn == null)
                    _currentEmployeesLogIn = new Employee();

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
        ActiveDataSheet_EventArgs _dataSheet;

        /// <summary>
        /// Set the fileName where the control will luck.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ActiveDataSheet_EventArgs SetDataSheet
        {
            get { return _dataSheet; }
            set
            {
                try
                {
                    if (value == null)
                    {
                        ClearPDF_Viewer();
                        return;
                    }

                    _dataSheet = value;

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
                                              @", Break code at position " + MessagePositionString,
                            @"Pdf_explorer, Pdf_explorer fail in SetDataSheet",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void ProcessDataSheet()
        {
            MessagePositionString = "Set_data_sheet();";
            string _ext = Path.GetExtension(_dataSheet?.DataSheet).ToLower();

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

            Text = Path.GetFileName(_dataSheet?.DataSheet);
            ToolTipText = _dataSheet?.DataSheet;
            Set_data_sheet();
        }

        public void ActiveDataSheet_EventHandler(object sender, ActiveDataSheet_EventArgs e)
        {
            SetDataSheet = e;
        }

        public string PdfFile = "";

        const int SwpNomove = 0x0002;
        const int SwpNosize = 0x0001;
        //private IntPtr HWND_TOPMOST = new IntPtr(-1);
        const uint TopmostFlags = SwpNomove | SwpNosize;

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

        // And in the Form Load event, you need to call the SetWindowPos() function like this.
        // SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

        //   AxPDFXCviewAxLib.AxCoPDFXCpreview axCoPDFXCpreview;

        public Pdf_explorer()
        {
            try
            {
                InitializeComponent();
                /*
                MessagePositionString = "xCoPDFXCpreview = new AxPDFXCviewAxLib";
                axCoPDFXCpreview = new AxPDFXCviewAxLib.AxCoPDFXCpreview();
                
                ((System.ComponentModel.ISupportInitialize)(axCoPDFXCpreview)).BeginInit();
                // 
                // axCoPDFXCpreview
                // 
                axCoPDFXCpreview.Dock = DockStyle.Fill;
                axCoPDFXCpreview.Enabled = true;
                axCoPDFXCpreview.Location = new Point(0, 0);
                axCoPDFXCpreview.Name = "axCoPDFXCpreview";
             // axCoPDFXCpreview.OcxState = (AxHost.State)resources.GetObject("axCoPDFXCpreview.OcxState");
                axCoPDFXCpreview.Size = new Size(969, 546);
                axCoPDFXCpreview.TabIndex = 0;
                Controls.Add(this.axCoPDFXCpreview);
                ((System.ComponentModel.ISupportInitialize)(axCoPDFXCpreview)).EndInit();
                */

                /*
                AppDomain.CurrentDomain.AssemblyResolve += (Object sender, ResolveEventArgs args) =>
                {
                    String thisExe = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                    System.Reflection.AssemblyName embeddedAssembly = new System.Reflection.AssemblyName(args.Name);
                    String resourceName = thisExe + "." + embeddedAssembly.Name + ".dll";

                    using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                    {
                        Byte[] assemblyData = new Byte[stream.Length];
                        stream.Read(assemblyData, 0, assemblyData.Length);
                        return System.Reflection.Assembly.Load(assemblyData);
                    }
                };
                */

                MessagePositionString = "ClearPDF_Viewer()";
                ClearPDF_Viewer();
                TabPageContextMenuStrip = contextMenuStripPdfViewer;

                MessagePositionString = "_defaultDataSheetFile = new FileInfo";
                _defaultDataSheetFile = new FileInfo(Settings.Default.DataBaseAddress + "\\DataSheets\\" + "No Data Sheet Found.PDF");
            }
            catch (Exception error)
            {
                string msg = MessagePositionString + error.Message;
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
                    //      axCoPDFXCpreview.Src = openFileDialogStockRoomManager.FileName;
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

                _lastDataSheet = "";
                /*
                if(axCoPDFXCpreview != null)
                    axCoPDFXCpreview.Src = Settings.Default.DataBaseAddress + "\\DataSheets\\" + "No Empty Data Sheet.PDF";
                else
                    axCoPDFXCpreview = new AxPDFXCviewAxLib.AxCoPDFXCpreview();
                */
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
                if (_dataSheet == null)
                {   //No dataSheets file, no containing folder.
                    e.Cancel = true;
                    return;
                }

                contextMenuStripPdfViewer.Items.Clear();


                if (CurrentEmployeesLogIn.EmployeeAccessLevel < MyCode.AccessLevel.Manager)
                {
                    contextMenuStripPdfViewer.Items.AddRange(new ToolStripItem[]
                                                             {
                                                                    ToolStripMenuItemTheUserHaveNotRight
                                                             });
                    return;
                }

                if (CurrentEmployeesLogIn.EmployeeAccessLevel == MyCode.AccessLevel.Manager)
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
                            /*
                            if (dataSheetFile.Exists)
                            {
                                _lastDataSheet = dataSheetFile.Name;
                                axCoPDFXCpreview.Src = dataSheetFile.FullName;
                                Text = dataSheetFile.Name;
                            }
                            else
                            {
                                _lastDataSheet = "";
                                Text = @"No Data Sheet Found";
                                axCoPDFXCpreview.Src = Settings.Default.DataBaseAddress + "\\DataSheets\\" +
                                                       "No Data Sheet Found.PDF";
                               
                            }*/
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
                //    if (axCoPDFXCpreview == null)
                //        return;

                string pageToOpen = "";
                _defaultDataSheetFile = new FileInfo(Path.Combine(_dataSheet.DefaultPath, _dataSheet.DataSheet.Trim()));

                if (_dataSheet.DataSheet.Contains("#pag"))
                {
                    int indexOf = _dataSheet.DataSheet.IndexOf("#", StringComparison.Ordinal);
                    if (_dataSheet.DataSheet.Length > indexOf)
                    {
                        pageToOpen = _dataSheet.DataSheet.Substring(indexOf);
                        string fileName = _dataSheet.DataSheet.Remove(indexOf);
                        _defaultDataSheetFile = new FileInfo(Path.Combine(_dataSheet.DefaultPath, fileName.Trim()));
                    }
                }

                MessagePositionString = "Set_data_sheet() -> if (dataSheetFile.Exists)";
                if (_defaultDataSheetFile.Exists)
                {
                    _lastDataSheet = _defaultDataSheetFile.Name;

                    if (pageToOpen.Length == 0)
                    {
                        //                  _defaultDataSheetFile.FullName "D:\\ProductionManagement\\DataSheets\\1N5819.pdf"
                        //                  On_StatusBarMessage(new StatusBarMessage_EventArgs("PDF dataSheet loaded " + dataSheetName.Trim()));
                        //            axCoPDFXCpreview.Src = _defaultDataSheetFile.FullName.Trim();
                    }
                    else
                    {
                        pageToOpen = pageToOpen.Replace("#", "/A#");  //"/A#"; ":"

                        //                 On_StatusBarMessage(new StatusBarMessage_EventArgs("PDF dataSheet loaded " + _defaultDataSheetFile.Name + pageToOpen));
                        //          axCoPDFXCpreview.Src = _defaultDataSheetFile.FullName + pageToOpen;
                    }
                }
                else
                {
                    MessagePositionString = @"Set_data_sheet() -> _lastDataSheet = ";
                    ToolTipText = "";
                    _lastDataSheet = "";
                    Icon = Resources.Empy_Icon;
                    Text = @"No Data Sheet Found";

                    //              On_StatusBarMessage(new StatusBarMessage_EventArgs("No Data Sheet Found..."));
                    //          axCoPDFXCpreview.Src = Settings.Default.DataBaseAddress + "\\DataSheets\\" + "No Data Sheet Found.PDF";
                }

            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                          @", Break code at position " + MessagePositionString,
                        @" Pdf_explorer,  Pdf_explorer fail in Set_data_sheet()",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void Pdf_explorer_form_closing(object sender, FormClosingEventArgs e)
        {
            //     axCoPDFXCpreview.Dispose();

            Dispose(true);
        }

        void ClearPDF_Viewer()
        {
            Text = "";
            Icon = Resources.Empy_Icon;
            _dataSheet = null;
            _lastDataSheet = Settings.Default.DataBaseAddress + "\\DataSheets\\" + "No Empty Data Sheet.PDF";
            //    if (axCoPDFXCpreview != null)
            //        axCoPDFXCpreview.Src = Settings.Default.DataBaseAddress + "\\DataSheets\\" + "No Empty Data Sheet.PDF";
        }
    }
}
using MyStuff11net.Properties;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using static MyStuff11net.MyCode;
using DoneButton_EventArgs = MyStuff11net.Custom_Events_Args.DoneButton_EventArgs;

namespace MyStuff11net
{
    public partial class TestHTML : Form
    {
        string MessagePositionString = "";

        public static string GetAppLocation()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        #region"DoneEvent"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The Button Done has been hit.")]
        public event DoneEvent_EventHandler DoneEvent;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void DoneEvent_EventHandler(object sender, DoneButton_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public void On_DoneEvent(DoneButton_EventArgs e)
        {
            DoneEvent?.Invoke(new object(), e);
        }

        #endregion"DoneEvent"

        #region"CloseEvent"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The Button Close has been hit.")]
        public event CloseEvent_EventHandler CloseEvent;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CloseEvent_EventHandler(object sender, EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public void On_CloseEvent(EventArgs e)
        {
            CloseEvent?.Invoke(new object(), e);
        }

        #endregion"CloseEvent"

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,      // x-coordinate of upper-left corner
           int nTopRect,       // y-coordinate of upper-left corner
           int nRightRect,     // x-coordinate of lower-right corner
           int nBottomRect,    // y-coordinate of lower-right corner
           int nWidthEllipse,  // height of ellipse
           int nHeightEllipse  // width of ellipse

        );

        public TestHTML(HTMLEditor htmlEditor)
        {
            try
            {
                InitializeComponent();

                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

                Load += TestHTML_Load;
            }
            catch (Exception error)
            {
                string messageError = error.Message;
            }
        }

        void TestHTML_Load(object sender, EventArgs e)
        {
            //string page = new Uri(@"file:///" + @"C:\Users\reyes\Documents\ProductionManagement\Resources\HTML pages\tinymce\examples\full.html").ToString();
            string pageLocation = Path.Combine(Settings.Default.DataBaseAddress, @"\Resources\HTML pages\tinymce\examples\full.html");
            if (!File.Exists(pageLocation))
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"The webpage " + pageLocation + " was not founded.",
                                           @"DataGridView initialization fault.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //  string page = new Uri(@"file:///" + pageLocation).ToString();
            ///   if (webBrowserControl == null)
            //   {
            //Cef.Initialize(new CefSettings());
            //        webBrowserControl = new ChromiumWebBrowser(page);
            // webBrowserControl.RegisterJsObject("windowExternal", new JavaScriptInteractionObj(webBrowserControl, this));

            //       Controls.Add(webBrowserControl);
            //       webBrowserControl.Dock = DockStyle.Fill;
            //   }


            //     if (File.Exists(@"X:\ProductionManagement\Resources\HTML pages\tinymce\examples\full.html"))
            //         webBrowserControl.Load(new Uri(@"file:///" + @"X:\ProductionManagement\Resources\HTML pages\tinymce\examples\full.html").ToString());

            //     if (File.Exists(@"C:\Users\reyes\Documents\ProductionManagement\Resources\HTML pages\tinymce\examples\full.html"))
            //         webBrowserControl.Load(new Uri(@"file:///" + @"C:\Users\reyes\Documents\ProductionManagement\Resources\HTML pages\tinymce\examples\full.html").ToString());
        }


        public void SetContent(string content)
        {
            //    tinyMCE.SetContent(content);
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string HtmlContent
        {
            get
            {
                /*      string content = string.Empty;
                      if (webBrowserControl.doDocument != null)
                      {
                          object html = webBrowserControl.Document.InvokeScript("GetContent");
                          if (html != null)
                              content = html as string;
                      }
                */
                return "";
            }
            set
            {
                /*  if (webBrowserControl.Document != null)
                  {
                      webBrowserControl.Document.InvokeScript("SetContent", new object[] { value });
                  }*/
            }
        }

        public void DoneButton(string content, Color color)
        {
            On_DoneEvent(new DoneButton_EventArgs(content, color));
        }

        public void CloseWindow()
        {
            On_CloseEvent(new EventArgs());
        }


        public void CreateEditor(HTMLEditor htmlEditor)
        {
            if (File.Exists(@"X:\ProductionManagement\Resources\HTML pages\tinymce\jscripts\tiny_mce\tiny_mce.js"))
                MessagePositionString = Settings.Default.DataBaseAddress = @"X:\ProductionManagement";

            if (File.Exists(@"C:\Users\reyes\Documents\ProductionManagement\Resources\HTML pages\tinymce\jscripts\tiny_mce\tiny_mce.js"))
                MessagePositionString = Settings.Default.DataBaseAddress = @"C:\Users\reyes\Documents\ProductionManagement";

            //                C:\Users\reyes\Documents\ProductionManagement\Resources\HTML pages\tinymce\jscripts\tiny_mce\tiny_mce.js
            // Check if the main script file exist. X:\ProductionManagement\Resources\HTML pages\tinymce\jscripts\tiny_mce\tiny_mce.js
            string tinyMceFile = Path.Combine(Settings.Default.DataBaseAddress, @"Resources\HTML pages\tinymce\jscripts\tiny_mce\tiny_mce.js");
            if (File.Exists(tinyMceFile))
            {
                #region"Select the editor format..."
                switch (htmlEditor)
                {
                    case HTMLEditor.FullEditor:
                        {
                            //         webBrowserControl.Load(new Uri(@"file:///" + Path.Combine(Settings.Default.DataBaseAddress, @"Resources\HTML pages\tinymce\examples\full.html")).ToString());
                            break;
                        }
                    case HTMLEditor.SimpleEditor:
                        {
                            //          webBrowserControl.Load(new Uri(@"file:///" + Path.Combine(Settings.Default.DataBaseAddress, @"Resources\HTML pages\tinymce\examples\simple.html")).ToString());
                            break;
                        }
                    case HTMLEditor.O2k7Editor:
                        {
                            //           webBrowserControl.Load(new Uri(@"file:///" + Path.Combine(Settings.Default.DataBaseAddress, @"Resources\HTML pages\tinymce\examples\word.html")).ToString());
                            break;
                        }
                }
                #endregion"Select the editor format..."
            }
            else
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, "Could not find the tinyMCE script directory. Please ensure the directory is in the same location as tinymce.htm",
                                          "Error " + MessagePositionString + ".",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // HtmlDocument requires using System.Windows.Browser.
            //      HtmlDocument doc = webBrowserControl.Document;
            // Hook up the simple JavaScript method HTML button.
            //      var element = doc.GetElementById("done");
            //      if (element != null)
            //          element.AttachEventHandler("click", new EventHandler(SetContent));
        }



        // Call a global JavaScript method defined on the HTML page.
        public void SetContent(object o, EventArgs e)
        {
            string strMS = DateTime.Now.Millisecond.ToString();

            string strTime = "Time came from managed code \n"
                + DateTime.Now.ToLongTimeString()
                + " MS = " + strMS;

            //webBrowserControl.Document.InvokeScript("SetContent", new object[] { strTime });
        }

        /// <summary>
        /// Load the html page at address, this an Uri object....
        /// </summary>
        /// <param name="webPageAddress"></param>
        public void LoadHtmlPage(Uri webPageAddress)
        {
            //  webBrowserControl.Load(webPageAddress.ToString());
        }

        /// <summary>
        /// Load the html page a address, string is full path to the file as
        /// C:\Users\Owner\Documents\ProductionManagement\Resources\tinymce\examples\full.html"
        /// </summary>
        /// <param name="htmlAdressFullPath"></param>
        public void LoadHtmlPage(string htmlAdressFullPath)
        {
            //  webBrowserControl.Load(htmlAdressFullPath);
        }

        private void buttonExecJavaScriptFromWinforms_Click(object sender, EventArgs e)
        {
            //  webBrowserControl.LoadHtml("<html><body>Hello world</body></html>", "http://customrendering/");

            //    var script = "document.body.style.backgroundColor = 'red';";

            //  webBrowserControl.ExecuteScriptAsync(script);
        }

        private void buttonReturnDataFromJavaScript_Click(object sender, EventArgs e)
        {
            //   webBrowserControl.LoadHtml("<html><body>Hello world</body></html>", "http://customrendering/");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction() {");
            sb.AppendLine("     var w = window.innerWidth;");
            sb.AppendLine("     var h = window.innerHeight;");
            sb.AppendLine("");
            sb.AppendLine("     return w*h;");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction();");

            //    var task = webBrowserControl.EvaluateScriptAsync(sb.ToString());

            /*    task.ContinueWith(t =>
                {
                    if (!t.IsFaulted)
                    {
                        var response = t.Result;

                        if (response.Success == true)
                        {
                            MessageBox.Show(response.Result.ToString());
                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            */
        }

        private void buttonReturnDataFromJavaScript2_Click(object sender, EventArgs e)
        {
            // Step 01: create a simple html page (include jquery so we have access to json object
            StringBuilder htmlPage = new StringBuilder();
            htmlPage.AppendLine("<html>");
            htmlPage.AppendLine("<head>");
            htmlPage.AppendLine("<script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js\"> </script>");
            htmlPage.AppendLine("</head>");
            htmlPage.AppendLine("<body>Hello world 2</body>");
            htmlPage.AppendLine("</html>");

            // Step 02: Load the Page
            //    webBrowserControl.LoadHtml(htmlPage.ToString(), "http://customrendering/");

            // Step 03: Execute some ad-hoc JS that returns an object back to C#
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function tempFunction() {");
            sb.AppendLine("     // create a JS object");
            sb.AppendLine("     var person = {firstName:'John', lastName:'Maclaine', age:23, eyeColor:'blue'};");
            sb.AppendLine("");
            sb.AppendLine("     // Important: convert object to string before returning to C#");
            sb.AppendLine("     return JSON.stringify(person);");
            sb.AppendLine("}");
            sb.AppendLine("tempFunction();");

            /*     var task = webBrowserControl.EvaluateScriptAsync(sb.ToString());

                 task.ContinueWith(t =>
                 {
                     if (!t.IsFaulted)
                     {
                         // Step 04: Receive value from JS
                         var response = t.Result;

                         if (response.Success == true)
                         {
                             // Use JSON.net to convert to object;
                             MessageBox.Show(response.Result.ToString());
                         }
                     }
                 }, TaskScheduler.FromCurrentSynchronizationContext());
            */
        }
    }
}

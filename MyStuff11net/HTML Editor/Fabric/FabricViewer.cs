using MyStuff11net.Properties;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Timer = System.Windows.Forms.Timer;

namespace MyStuff11net.HTML_Editor.Fabric
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public partial class FabricViewer : UserControl
    {
        public FabricViewer()
        {
            InitializeComponent();
            FabricBrowser.ObjectForScripting = this;
        }

        Timer tic;
        public void CreateEditor(string InitialPage)
        {
            // Check if the main script file exist being used by the HTML page
            if (File.Exists(Path.Combine(Settings.Default.DataBaseAddress, @"Resources\\tinymce\\jscripts\\tiny_mce\\Fabric.js")))
            {
                switch (InitialPage)
                {
                    case "1000 particles":
                        {
                            FabricBrowser.Url = new Uri(@"file:///" + Path.Combine(Settings.Default.DataBaseAddress, "Resources\\tinymce\\examples\\1000 particles.html"));
                            break;
                        }
                    case "e":
                        {
                            FabricBrowser.Url = new Uri(@"file:///" + Path.Combine(Settings.Default.DataBaseAddress, "Resources\\FabricBrowser\\Per-pixel drag & drop.html"));
                            break;
                        }
                    case "w":
                        {
                            FabricBrowser.Url = new Uri(@"file:///" + Path.Combine(Settings.Default.DataBaseAddress, "Resources\\FabricBrowser\\Stick.html"));
                            break;
                        }
                }


                tic = new Timer()
                {
                    Interval = 25,
                    Enabled = false
                };

                tic.Tick += new EventHandler(tic_Tick);
                tic.Start();
            }
            else
            {
                MessageBox.Show("Could not find the tinyMCE script directory. Please ensure the directory is in the same location as tinymce.htm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void tic_Tick(object sender, EventArgs e)
        {
            tic.Tick -= tic_Tick;
            tic.Enabled = false;
            tic.Stop();

            if (FabricBrowser.Document != null)
            {
                FabricBrowser.Document.InvokeScript("SetContent", new object[] { });
            }
        }
    }
}

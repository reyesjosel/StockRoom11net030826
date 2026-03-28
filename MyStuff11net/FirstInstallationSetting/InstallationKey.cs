namespace MyStuff11net.FirstInstallationSetting
{
    public partial class InstallationKey : Form
    {
        public InstallationKey()
        {
            InitializeComponent();

            Load += new EventHandler(InstallationKey_Load);
            button_Accept.Click += new EventHandler(button_Accept_Click);
            button_Cancel.Click += new EventHandler(button_Cancel_Click);
            button_Browser.Click += new EventHandler(button_Browser_Click);
        }

        void InstallationKey_Load(object sender, EventArgs e)
        {

        }

        void button_Accept_Click(object sender, EventArgs e)
        {

        }

        void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        void button_Browser_Click(object sender, EventArgs e)
        {
            using (var openfile = new OpenFileDialog
            {
                Title = @"Please find the file InstallationKey.key ...",
                FileName = MyStuff11net.Properties.Settings.Default.DataBaseAddress + "\\InstallationKey",
                Filter = @"Installation Key (*.key)|*.key",
                DefaultExt = "(*.key)|*.key"
            }
                  )
            {
                if (openfile.ShowDialog(this) == DialogResult.Cancel)
                {
                    richTextBox1.AppendText("  Attention, you did not select a correct installation key file for this application," +
                                            "the application will be installed in default mode which will allow you to explore and" +
                                            "use tools with certain limitations ..."
                                            );
                    return;
                }


            }
        }






    }
}

using HTMLEditor = MyStuff11net.MyCode.HTMLEditor;


namespace StockRoom11net
{
    public partial class LogFile_Management : BaseTemple
    {
        public LogFile_Management()
        {
            InitializeComponent();
        }

        public LogFile_Management(string logfile)
        {
            InitializeComponent();

            tinyMceEditor.HtmlContent = logfile;

            tinyMceEditor.CreateEditor(HTMLEditor.FullEditor);

            // tinyMceEditor.FullScreen();
        }

        public LogFile_Management(Uri webPageAddress)
        {
            InitializeComponent();

            tinyMceEditor.LoadHtmlPage(webPageAddress);
        }
    }
}

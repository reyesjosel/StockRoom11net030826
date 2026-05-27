using StockRoom11net.Controls.EmployeeInformation;
using StockRoom11net.Data.Services;

namespace StockRoom11net.Controls.DocumentationBehavior
{
    public partial class DocumentsAddressViewer : Form
    {
        private ITableEmployeeService _employeesService;

        public DocumentsAddressViewer()
        {
            InitializeComponent();
        }

        public DocumentsAddressViewer(ITableEmployeeService employeesService, bool allowedEditing)
        {
            InitializeComponent();

            _employeesService = employeesService;

            InitializeDocumentsAddressGroup(allowedEditing);
        }

        void InitializeDocumentsAddressGroup(bool allowedEditing)
        {
            if (allowedEditing)
                Text = "DocumentsAddressViewer Edit mode.";
            else
                Text = "DocumentsAddressViewer View mode.";

            Controls.Remove(documentsAddressGroup);
            var documentsAddressGroupNew = new DocumentsAddressGroup(_employeesService, allowedEditing);
            Controls.Add(documentsAddressGroupNew);
            documentsAddressGroupNew.Dock = DockStyle.Fill;

            documentsAddressGroupNew.CloseProject += DocumentsAddressGroupNew_CloseProject;
        }

        void DocumentsAddressGroupNew_CloseProject(object sender, Custom_Events_Args.CloseProject_EventArgs e)
        {
            Close();
        }
    }
}

namespace MyStuff11net.DocumentationBehavior
{
    public partial class DocumentsAddressViewer : Form
    {
        DepartmentInformation DepartmentLogIn;
        List<DepartmentInformation> DepartmentList;

        public DocumentsAddressViewer()
        {
            InitializeComponent();
        }

        public DocumentsAddressViewer(DepartmentInformation department, List<DepartmentInformation> departmentList, bool allowedEditing)
        {
            InitializeComponent();

            DepartmentLogIn = department;
            DepartmentList = departmentList;

            InitializeDocumentsAddressGroup(allowedEditing);
        }

        void InitializeDocumentsAddressGroup(bool allowedEditing)
        {
            if (allowedEditing)
                Text = "DocumentsAddressViewer Edit mode.";
            else
                Text = "DocumentsAddressViewer View mode.";

            Controls.Remove(documentsAddressGroup);
            var documentsAddressGroupNew = new DocumentsAddressGroup(DepartmentLogIn, DepartmentList, allowedEditing);
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

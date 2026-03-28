using System.ComponentModel;

namespace MyStuff11net
{
    public partial class Engineering_Change_Request : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get
            {
                return htmlwysiwyg_Title.getHTML();
            }
            set
            {
                htmlwysiwyg_Title.setHTML(value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description
        {
            get
            {
                return htmlwysiwyg_Description.getHTML();
            }

            set
            {
                htmlwysiwyg_Description.setHTML(value);
            }
        }

        public Engineering_Change_Request()
        {
            InitializeComponent();
        }

        private void Engineering_Change_Request_Load(object sender, EventArgs e)
        {
            InitializeHTML_Editor(htmlwysiwyg_Title);
            InitializeHTML_Editor(htmlwysiwyg_Description);
        }

        private void InitializeHTML_Editor(Htmlwysiwyg HTML_Editor)
        {
            HTML_Editor.ShowAlignCenterButton = true;
            HTML_Editor.ShowAlignLeftButton = true;
            HTML_Editor.ShowAlignRightButton = true;
            HTML_Editor.ShowBackColorButton = true;
            HTML_Editor.ShowBolButton = true;
            HTML_Editor.ShowBulletButton = true;
            HTML_Editor.ShowCopyButton = true;
            HTML_Editor.ShowCutButton = true;
            HTML_Editor.ShowFontFamilyButton = false;
            HTML_Editor.ShowFontSizeButton = false;
            HTML_Editor.ShowIndentButton = true;
            HTML_Editor.ShowItalicButton = true;
            HTML_Editor.ShowJustifyButton = true;
            HTML_Editor.ShowNewButton = false;
            HTML_Editor.ShowNewEngineeringChange = false;
            HTML_Editor.ShowOrderedListButton = true;
            HTML_Editor.ShowOutdentButton = true;
            HTML_Editor.ShowPasteButton = true;
            HTML_Editor.ShowPrintButton = false;
            HTML_Editor.ShowSaveButton = false;
            HTML_Editor.ShowTxtBGButton = true;
            HTML_Editor.ShowTxtColorButton = true;
            HTML_Editor.ShowUnderlineButton = true;
            HTML_Editor.ShowLinkButton = false;
            HTML_Editor.ShowUnlinkButton = false;
            HTML_Editor.ShowScrollBars = false;

            HTML_Editor.AllowEdit(true);
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }


}

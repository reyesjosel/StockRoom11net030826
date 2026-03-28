using System.ComponentModel;

namespace MyStuff11net
{
    public partial class IntegratedCircuit : BaseComponent
    {
        #region"Properties, Custom Control Properties"

        /// <summary>
        /// Specifies the custom string filter, formated as, ColumnName LIKE ''
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint),
         Category("Custom Properties"),
         DefaultValue(""),
         Description("Get the Description for this component.")]
        public override string Description
        {
            get
            {
                return label_DescriptionInformations.Text;
            }
            set
            {
                label_DescriptionInformations.Text = value;
            }


        }

        [RefreshProperties(RefreshProperties.Repaint),
         Category("Custom Properties"),
         DefaultValue(""),
         Description("Mode edition, None, Edit, Add, Delete, allowed to the user.")]
        public override MyCode.EditMode EditMode
        {
            set
            {
                switch (value)
                {
                    case MyCode.EditMode.View:
                        {
                            Value.Enabled = false;
                            Package.Enabled = false;
                            Comment_about_it.Enabled = false;
                            break;
                        }
                    case MyCode.EditMode.Edit:
                        {
                            Value.Enabled = true;
                            Package.Enabled = true;
                            Comment_about_it.Enabled = true;
                            break;
                        }
                    case MyCode.EditMode.Add:
                        {

                            break;
                        }
                    case MyCode.EditMode.Delete:
                        {

                            break;
                        }

                    default:
                        {

                            break;
                        }

                }

            }
        }

        #endregion"Properties, Custom Control Properties"

        public IntegratedCircuit()
        {
            InitializeComponent();
        }

        public IntegratedCircuit(ComponentInformation componentInformations)
        {
            InitializeComponent();
            PartNumberTag = "015-";

            UpdateInformation(componentInformations);
        }

        private void Any_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            DescriptionString();
        }

        private void Any_Leave(object sender, EventArgs e)
        {
            DescriptionString();
        }

        private void DescriptionString()
        {
            label_DescriptionInformations.Text = "";

            if (Value.Text != "")
                label_DescriptionInformations.Text = Value.Text.Trim();

            if (Package.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Package.Text.Trim());

            if (Comment_about_it.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, "Comm:" + Comment_about_it.Text.Trim());

        }

        public override void UpdateInformation(ComponentInformation componentInformations)
        {
            #region "Name"

            Value.Text = componentInformations.Name ?? "";
            Value.Enabled = componentInformations.Name == null ? true : false;

            #endregion "Name"

            #region "Package"

            Package.Text = componentInformations.Package ?? "";
            Package.Enabled = componentInformations.Package == null ? true : false;

            #endregion "Package"

            #region "Comment_about_it"

            Comment_about_it.Text = componentInformations.Comment_about_it ?? "";
            Comment_about_it.Enabled = componentInformations.Comment_about_it == null ? true : false;

            #endregion "Comment_about_it"

            DescriptionString();
        }
    }
}

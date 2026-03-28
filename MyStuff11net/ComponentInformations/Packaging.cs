using System.ComponentModel;

namespace MyStuff11net
{
    public partial class Packaging : BaseComponent
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
                return label_Description.Text;
            }
            set
            {
                label_Description.Text = value;
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
                            Unid.Enabled = false;
                            Tolerance.Enabled = false;
                            Package.Enabled = false;
                            break;
                        }
                    case MyCode.EditMode.Edit:
                        {
                            Value.Enabled = true;
                            Unid.Enabled = true;
                            Tolerance.Enabled = true;
                            Package.Enabled = true;
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

        public Packaging()
        {
            InitializeComponent();
        }

        public Packaging(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "108-";
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
            label_Description.Text = "";

            if (Value.Text != "")
                if (Unid.Text != "")
                    label_Description.Text = Value.Text.Trim() + " " + Unid.Text.Trim();

            if (Tolerance.Text != "")
                label_Description.Text += String_Add(label_Description.Text, Tolerance.Text.Trim() + " %");

            if (Package.Text != "")
                label_Description.Text += String_Add(label_Description.Text, Package.Text.Trim());
        }

        public override void UpdateInformation(ComponentInformation componentInformations)
        {
            #region "Value"

            Value.Text = componentInformations.Value ?? "";
            Value.Enabled = componentInformations.Value == null ? true : false;

            #endregion "Value"

            #region "Unit"

            Unid.Text = componentInformations.Unit ?? "";
            Unid.Enabled = componentInformations.Unit == null ? true : false;

            #endregion "Unit"

            #region "Tolerance"

            Tolerance.Text = componentInformations.Tolerance ?? "";
            Tolerance.Enabled = componentInformations.Tolerance == null ? true : false;

            #endregion "Tolerance"

            #region "Package"

            Package.Text = componentInformations.Package ?? "";
            Package.Enabled = componentInformations.Package == null ? true : false;

            #endregion "Package"

            DescriptionString();
        }
    }
}

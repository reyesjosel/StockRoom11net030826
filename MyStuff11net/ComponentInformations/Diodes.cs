using System.ComponentModel;

namespace MyStuff11net
{
    public partial class Diodes : BaseComponent
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
                return label_DescriptionLabel.Text;
            }
            set
            {
                label_DescriptionLabel.Text = value;
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
                            Power.Enabled = false;
                            Package.Enabled = false;
                            break;
                        }
                    case MyCode.EditMode.Edit:
                        {
                            Value.Enabled = true;
                            Unid.Enabled = true;
                            Tolerance.Enabled = true;
                            Power.Enabled = true;
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

        public Diodes()
        {
            InitializeComponent();
        }

        public Diodes(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "065-";
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
            label_DescriptionLabel.Text = "";

            if (Value.Text != "")
                label_DescriptionLabel.Text = Value.Text.Trim();

            if (Unid.Text != "")
                label_DescriptionLabel.Text += String_Add(label_DescriptionLabel.Text, Unid.Text.Trim());

            if (Tolerance.Text != "")
                label_DescriptionLabel.Text += String_Add(label_DescriptionLabel.Text, Tolerance.Text.Trim() + " volts");

            if (Power.Text != "")
                label_DescriptionLabel.Text += String_Add(label_DescriptionLabel.Text, Power.Text.Trim() + " amps");

            if (Package.Text != "")
                label_DescriptionLabel.Text += String_Add(label_DescriptionLabel.Text, Package.Text.Trim());
        }

        public override void UpdateInformation(ComponentInformation componentInformations)
        {
            #region "Name"

            Value.Text = componentInformations.Name ?? "";
            Value.Enabled = componentInformations.Name == null ? true : false;

            #endregion "Name"

            #region "Type"

            Unid.Text = componentInformations.Type ?? "";
            Unid.Enabled = componentInformations.Type == null ? true : false;

            #endregion "Type"

            #region "Vrms"

            Tolerance.Text = componentInformations.Vrms ?? "";
            Tolerance.Enabled = componentInformations.Vrms == null ? true : false;

            #endregion "Vrms"

            #region "If"

            Power.Text = componentInformations.If ?? "";
            Power.Enabled = componentInformations.If == null ? true : false;

            #endregion "If"

            #region "Package"

            Package.Text = componentInformations.Package ?? "";
            Package.Enabled = componentInformations.Package == null ? true : false;

            #endregion "Package"

            DescriptionString();
        }
    }
}

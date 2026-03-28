using System.ComponentModel;

namespace MyStuff11net
{
    public partial class Connectors : BaseComponent
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

        public Connectors()
        {
            InitializeComponent();
        }

        public Connectors(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "045-";
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
                if (Unid.Text != "")
                    label_DescriptionInformations.Text = Value.Text.Trim() + " " + Unid.Text.Trim();

            if (Tolerance.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Tolerance.Text.Trim() + " %");

            if (Power.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Power.Text.Trim() + " volts");

            if (Package.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Package.Text.Trim());
        }

        public override void UpdateInformation(ComponentInformation componentInformations)
        {
            #region "Value"

            //     Value.Text = _receivedEvent.Value ?? "";
            //     Value.Enabled = _receivedEvent.Value == null ? true : false;

            #endregion "Value"

            DescriptionString();
        }
                
    }
}

using System.ComponentModel;

namespace MyStuff11net
{
    public partial class Leds : BaseComponent
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
                            Name_value.Enabled = false;
                            LedsColor.Enabled = false;
                            Vr.Enabled = false;
                            If.Enabled = false;
                            Power.Enabled = false;
                            Package.Enabled = false;
                            break;
                        }
                    case MyCode.EditMode.Edit:
                        {
                            Name_value.Enabled = true;
                            LedsColor.Enabled = true;
                            Vr.Enabled = true;
                            If.Enabled = true;
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

        public Leds()
        {
            InitializeComponent();
        }

        public Leds(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "070-";
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

            if (Name_value.Text != "")
                label_DescriptionInformations.Text = Name_value.Text.Trim();

            if (LedsColor.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, LedsColor.Text.Trim());

            if (Vr.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Vr.Text.Trim());

            if (If.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, If.Text.Trim());

            if (Power.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Power.Text.Trim());

            if (Package.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Package.Text.Trim());
        }

        public override void UpdateInformation(ComponentInformation componentInformations)
        {
            #region "Name"

            Name_value.Text = componentInformations.Name ?? "";
            Name_value.Enabled = componentInformations.Name == null ? true : false;

            #endregion "Name"

            #region "LedsColor"

            LedsColor.Text = componentInformations.LedsColor ?? "";
            LedsColor.Enabled = componentInformations.LedsColor == null ? true : false;

            #endregion "LedsColor"

            #region "Vr"

            Vr.Text = componentInformations.Vr ?? "";
            Vr.Enabled = componentInformations.Vr == null ? true : false;

            #endregion "Vr"

            #region "If"

            If.Text = componentInformations.If ?? "";
            If.Enabled = componentInformations.If == null ? true : false;

            #endregion "If"

            #region "Power"

            Power.Text = componentInformations.Power ?? "";
            Power.Enabled = componentInformations.Power == null ? true : false;

            #endregion "Package"

            #region "Package"

            Package.Text = componentInformations.Package ?? "";
            Package.Enabled = componentInformations.Package == null ? true : false;

            #endregion "Package"

            DescriptionString();
        }
    }
}

namespace MyStuff11net
{
    public partial class Transistors : BaseComponent
    {

        public Transistors()
        {
            InitializeComponent();
        }

        public Transistors(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "060-";
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

            if (Type.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Type.Text.Trim());

            if (Vce.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Vce.Text.Trim() + " volts");

            if (Ice.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Ice.Text.Trim() + " amps");

            if (Package.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Package.Text.Trim());
        }

        public override void UpdateInformation(ComponentInformation componentInformations)
        {
            #region "Name"

            Name_value.Text = componentInformations.Name ?? "";
            Name_value.Enabled = componentInformations.Name == null ? true : false;

            #endregion "Name"

            #region "Type"

            Type.Text = componentInformations.Type ?? "";
            Type.Enabled = componentInformations.Type == null ? true : false;

            #endregion "Type"

            #region "Vce"

            Vce.Text = componentInformations.Vce ?? "";
            Vce.Enabled = componentInformations.Vce == null ? true : false;

            #endregion "Vce"

            #region "Ice"

            Ice.Text = componentInformations.Ice ?? "";
            Ice.Enabled = componentInformations.Ice == null ? true : false;

            #endregion "Ice"

            #region "Package"

            Package.Text = componentInformations.Package ?? "";
            Package.Enabled = componentInformations.Package == null ? true : false;

            #endregion "Package"

            DescriptionString();
        }
    }
}

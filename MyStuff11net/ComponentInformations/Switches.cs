namespace MyStuff11net
{
    public partial class Switches : BaseComponent
    {
        public Switches()
        {
            InitializeComponent();
        }

        public Switches(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "075-";
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

            if (Package.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Package.Text.Trim());
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

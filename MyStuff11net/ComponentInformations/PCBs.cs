namespace MyStuff11net
{
    public partial class PCBs : BaseComponent
    {

        public PCBs()
        {
            InitializeComponent();
        }

        public PCBs(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "110-";
            Unid.Text = "pF";
            Unid.Items.Add("pF");
            Unid.Items.Add("nF");
            Unid.Items.Add("" + '\u03BC' + "F");
            Unid.Items.Add("mF");

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

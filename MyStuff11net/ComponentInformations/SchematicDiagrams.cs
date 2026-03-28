namespace MyStuff11net
{
    public partial class SchematicDiagrams : BaseComponent
    {

        public SchematicDiagrams()
        {
            InitializeComponent();
        }

        public SchematicDiagrams(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "109-";
            

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

        }

        public override void UpdateInformation(ComponentInformation componentInformations)
        {
           
        }

    }
}

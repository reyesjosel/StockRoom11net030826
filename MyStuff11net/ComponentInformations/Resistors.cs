using System.ComponentModel;

namespace MyStuff11net
{
    public partial class Resistor : BaseComponent
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

        public ComponentInformation CompInformation;

        public Resistor()
        {
            InitializeComponent();
            PartNumberTag = "014-";
        }

        public Resistor(ComponentInformation componentInformation)
        {
            InitializeComponent();

            PartNumberTag = "014-";
            CompInformation = componentInformation;

            flowLayoutPanel.Resize += new EventHandler(flowLayoutPanel_Resize);

            Unid.Text = "" + '\u03A9';
            Unid.Items.Add('\u03A9');
            Unid.Items.Add("K" + '\u03A9');
            Unid.Items.Add("M" + '\u03A9');

            UpdateInformation(componentInformation);
        }

        void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            int count = 1;
            int betwen = 6;
            int spaceneed = 10;

            if (Power.Visible)
                count = 5;
            else
                count = 4;

            spaceneed = betwen * count;

            int nextWidth = 0;
            nextWidth = (flowLayoutPanel.Width - spaceneed) / count;

            Value.Width = Unid.Width = Tolerance.Width = Package.Width = Power.Width = nextWidth;

            label_Value.Location = new Point(Value.Location.X, 5);
            label_Unid.Location = new Point(Unid.Location.X, 5);
            label_Tolerance.Location = new Point(Tolerance.Location.X, 5);
            label_Size.Location = new Point(Package.Location.X, 5);

            if (Power.Visible)
                label_Power.Location = new Point(Power.Location.X, 5);
        }

        void Any_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            DescriptionString();
        }

        void Any_Leave(object sender, EventArgs e)
        {
            DescriptionString();
        }

        void DescriptionString()
        {
            label_DescriptionInformations.Text = "";

            if (Value.Text != "")
                if (Unid.Text != "")
                    label_DescriptionInformations.Text = Value.Text.Trim() + " " + Unid.Text;
                else
                    label_DescriptionInformations.Text = Value.Text.Trim() + " " + '\u03A9'; // Ohms by default.

            if (Tolerance.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Tolerance.Text + " %");

            if (Package.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Package.Text);

            if (Package.Text == "THole")
            {
                if (Power.Text != "")
                    label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Power.Text.Trim() + " watts");

            }
        }

        public override void UpdateInformation(ComponentInformation componentInformation)
        {
            #region "Value"

            Value.Text = componentInformation.Value ?? "";
            Value.Enabled = componentInformation.Value == null ? true : false;

            #endregion "Value"

            #region "Unit"

            Unid.Text = componentInformation.Unit ?? "";
            Unid.Enabled = componentInformation.Unit == null ? true : false;

            #endregion "Unit"

            #region "Tolerance"

            Tolerance.Text = componentInformation.Tolerance ?? "";
            Tolerance.Enabled = componentInformation.Tolerance == null ? true : false;

            #endregion "Tolerance"

            #region "Package"

            Package.Text = componentInformation.Package ?? "";
            Package.Enabled = componentInformation.Package == null ? true : false;

            #endregion "Package"

            #region "Power"

            if (componentInformation.Package == "THole")
            {
                Power.Text = componentInformation.Power ?? "";
                Power.Enabled = componentInformation.Power == null ? true : false;
            }
            else
            {
                label_Power.Visible = false;
                Power.Visible = false;
            }

            #endregion "Power"
            
            DescriptionString();
        }
    }
}

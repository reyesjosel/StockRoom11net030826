using System.ComponentModel;

namespace MyStuff11net
{
    public partial class Speakers : BaseComponent
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
                            Power.Enabled = false;
                            Comment_about_it.Enabled = false;
                            break;
                        }
                    case MyCode.EditMode.Edit:
                        {
                            Value.Enabled = true;
                            Power.Enabled = true;
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

        public Speakers()
        {
            InitializeComponent();
        }

        public Speakers(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "058-";
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
                label_DescriptionInformations.Text = Value.Text.Trim() + " " + '\u03A9';

            if (Power.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Power.Text.Trim() + " watts");

            if (Comment_about_it.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Comment_about_it.Text.Trim());
        }

        public override void UpdateInformation(ComponentInformation componentInformations)
        {
            #region "Value"

            Value.Text = componentInformations.Value ?? "";
            Value.Enabled = componentInformations.Value == null ? true : false;

            #endregion "Value"

            #region "Power"

            Power.Text = componentInformations.Power ?? "";
            Power.Enabled = componentInformations.Power == null ? true : false;

            #endregion "Power"

            #region "Comment_about_it"

            Comment_about_it.Text = componentInformations.Comment_about_it ?? "";
            Comment_about_it.Enabled = componentInformations.Comment_about_it == null ? true : false;

            #endregion "Comment_about_it"

            DescriptionString();
        }
    }
}

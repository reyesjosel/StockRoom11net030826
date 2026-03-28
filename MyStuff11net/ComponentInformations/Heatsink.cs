using System.ComponentModel;

namespace MyStuff11net
{
    public partial class Heatsink : BaseComponent
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
                            Power_Dissipation.Enabled = false;
                            Package_Cooled.Enabled = false;
                            Attachment_Method.Enabled = false;
                            //         numericLength.Enabled = false;
                            //         numericWidth.Enabled = false;
                            //         numericHeight.Enabled = false;
                            break;
                        }
                    case MyCode.EditMode.Edit:
                        {
                            Power_Dissipation.Enabled = true;
                            Package_Cooled.Enabled = true;
                            Attachment_Method.Enabled = true;
                            //        numericLength.Enabled = true;
                            //        numericWidth.Enabled = true;
                            //       numericHeight.Enabled = true;
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

        public Heatsink()
        {
            InitializeComponent();
        }

        public Heatsink(ComponentInformation componentInformations)
        {
            InitializeComponent();

            PartNumberTag = "040-";
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

            if (Power_Dissipation.Text != "")
                label_Description.Text = Power_Dissipation.Text.Trim();

            if (Package_Cooled.Text != "")
                label_Description.Text += String_Add(label_Description.Text, Package_Cooled.Text.Trim());

            if (Attachment_Method.Text != "")
                label_Description.Text += String_Add(label_Description.Text, Attachment_Method.Text.Trim());

            //      if (numericLength.Text != "")
            //          label_Description.Text += String_Add(label_Description.Text, numericLength.Text.Trim());

            //       if (numericWidth.Text != "")
            //          label_Description.Text += String_Add(label_Description.Text, numericWidth.Text.Trim());

            //     if (numericHeight.Text != "")
            //          label_Description.Text += String_Add(label_Description.Text, numericHeight.Text.Trim());

        }

        public override void UpdateInformation(ComponentInformation componentInformations)
        {
            #region "Power_Dissipation"

            Power_Dissipation.Text = componentInformations.Power_Dissipation ?? "";
            Power_Dissipation.Enabled = componentInformations.Power_Dissipation == null ? true : false;

            #endregion "Power_Dissipation"

            #region "Package_Cooled"

            Package_Cooled.Text = componentInformations.Package_Cooled ?? "";
            Package_Cooled.Enabled = componentInformations.Package_Cooled == null ? true : false;

            #endregion "Package_Cooled"

            #region "Attachment_Method"

            Attachment_Method.Text = componentInformations.Attachment_Method ?? "";
            Attachment_Method.Enabled = componentInformations.Attachment_Method == null ? true : false;

            #endregion "Attachment_Method"

            #region "numericLength"

            //        numericLength.Text = componentInformations.Length ?? "";
            //        numericLength.Enabled = componentInformations.Length == null ? true : false;

            #endregion "numericLength"

            #region "numericWidth"

            //     numericWidth.Text = componentInformations.Width ?? "";
            //      numericWidth.Enabled = componentInformations.Width == null ? true : false;

            #endregion "numericWidth"

            #region "numericHeight"

            //    numericHeight.Text = componentInformations.Height ?? "";
            //   numericHeight.Enabled = componentInformations.Height == null ? true : false;

            #endregion "numericHeight"

            DescriptionString();
        }

    }
}

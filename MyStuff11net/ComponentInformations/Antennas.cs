using System.ComponentModel;

namespace MyStuff11net
{


    // [ProvideToolboxControl("General", false)]
    //[ProvideToolboxControl("General", false)]
    // Set the display name and custom bitmap to use for this item. 
    // The build action for the bitmap must be "Embedded Resource".
    [DisplayName("Antenna")]
    [Description("Antenna control for receiving related materials.")]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(Antennas), "lightbulb.bmp")]
    [DefaultEvent("Description")]
    public partial class Antennas : BaseComponent
    {
        #region"Properties, Custom Control Properties"

        /// <summary>
        /// Specifies the custom string filter, formated as, ColumnName LIKE ''
        /// </summary>
        ///  BrowsableAttribute only determines whether the property shows up in the property grid.
        ///  To prevent the property from being serialized at all, use the DesignerSerializationVisibilityAttribute:
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         //Second, if you want the property to be serialized, but only when the user has actually changed the value, use the DefaultValueAttribute:
         DefaultValue(false),

         RefreshProperties(RefreshProperties.Repaint),
         Category("Custom Properties"),
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
         Browsable(true),
         DefaultValue(""),
         Category("Custom Properties"),
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
                            Package.Enabled = false;
                            break;
                        }
                    case MyCode.EditMode.Edit:
                        {
                            Value.Enabled = true;
                            Unid.Enabled = true;
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

        public Antennas()
        {
            InitializeComponent();
        }

        public Antennas(ComponentInformation componentInformation)
        {
            InitializeComponent();

            PartNumberTag = "098-";
            UpdateInformation(componentInformation);
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

            if (Package.Text != "")
                label_DescriptionInformations.Text += String_Add(label_DescriptionInformations.Text, Package.Text.Trim());
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

            #region "Package"

            Package.Text = componentInformation.Package ?? "";
            Package.Enabled = componentInformation.Package == null ? true : false;

            #endregion "Package"

            DescriptionString();
        }

    }
}

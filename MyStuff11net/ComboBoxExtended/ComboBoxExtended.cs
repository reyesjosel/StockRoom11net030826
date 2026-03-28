using System.ComponentModel;

namespace MyStuff11net
{
    [Serializable,
    DefaultEvent("Name"),
    Description("Displays a comboBox and a label."),
    ToolboxBitmap(typeof(ComboBoxExtended), "AGauge.bmp")]
    public partial class ComboBoxExtended : UserControl
    {
        #region"Properties"

        // When the DesignerSerializationVisibility attribute has
        // a value of "Content" or "Visible" the designer will 
        // serialize the property. This property can also be edited 
        // at design time with a CollectionEditor.
        [Browsable(true),
        Category("CompDesing"),
        RefreshProperties(RefreshProperties.All),
        Description("Text is show in the label."),
        DesignerSerializationVisibility(
        DesignerSerializationVisibility.Content)]
        public string LabelText
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
            }
        }

        [Browsable(true),
        Category("CompDesing"),
        RefreshProperties(RefreshProperties.All),
        Description("The SelectionLength of this component selected text.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectionLength
        {
            get
            {
                return comboBox.SelectionLength;
            }
            set
            {
                comboBox.SelectionLength = value;
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get
            {
                return comboBox.SelectedItem;
            }
            set
            {
                if (value == null)
                    return;

                comboBox.SelectedItem = value;
                comboBox.Text = value.ToString();
            }
        }

        // When the DesignerSerializationVisibility attribute has
        // a value of "Content" or "Visible" the designer will 
        // serialize the property. This property can also be edited 
        // at design time with a CollectionEditor.
        [Browsable(true),
        Category("CompDesing"),
        RefreshProperties(RefreshProperties.All),
        Description("Text is show in the label."),
        DesignerSerializationVisibility(
        DesignerSerializationVisibility.Content)]
        public override string Text
        {
            get
            {
                //required for validation for Text property
                //return base.Text.Replace(waterMarkText, string.Empty);
                return comboBox.Text;
            }
            set
            {
                comboBox.Text = value;
            }
        }

        [Browsable(true),
        Category("CompDesing"),
        RefreshProperties(RefreshProperties.All),
        Description("ComboBox dataSource property.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            get
            {
                return comboBox.DataSource;
            }
            set
            {
                comboBox.DataSource = value;
            }
        }

        #endregion"Properties"

        #region"Custom Controls Events with custom Arg.*********************"

        #region"SelectedValueChanged"

        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SelectedValueChanged_EventHandler(object sender, EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("SelectedValue has been changed")]
        public event SelectedValueChanged_EventHandler SelectedValueChanged;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_SelectedValueChanged(EventArgs e)
        {
            // Notify Subscribers
            SelectedValueChanged?.Invoke(this, e);
        }
        #endregion"SelectedValueChanged"

        #region"TextChanged"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void TextChanged_EventHandler(object sender, EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellDoubleClick has changed")]
        public new event TextChanged_EventHandler TextChanged;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_TextChanged(EventArgs e)
        {
            // If an event has no subscriber registerd, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (TextChanged != null)
            {
                // Notify Subscribers
                TextChanged(this, e);
            }
        }
        #endregion"TextChanged"

        #endregion"Custom Controls Events with custom Arg.*********************"

        public ComboBoxExtended()
        {
            InitializeComponent();

            label.Text = Name.Replace("comboBoxExtended_", "");

            comboBox.TextChanged += new EventHandler(ComboBox_TextChanged);
            comboBox.SelectedValueChanged += new EventHandler(ComboBox_SelectedValueChanged);
        }

        void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            On_SelectedValueChanged(e);
        }

        void ComboBox_TextChanged(object sender, EventArgs e)
        {
            On_TextChanged(e);
        }



    }
}

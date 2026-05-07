using StockRoom11net.Controls.SMTcontrol;
using System.ComponentModel;

using CellDoubleClick_EventArgs = StockRoom11net.Controls.Custom_Events_Args.CellDoubleClick_EventArgs;

namespace StockRoom11net.Controls.ComponentInformations
{
    [Serializable,
    DefaultEvent("BaseComp"),
    Description("Base class to all components."),
    ToolboxBitmap(typeof(ComboBoxExtended.ComboBoxExtended), "AGauge.bmp")]
    public partial class BaseComponent : UserControl
    {
        private string _description = "";

        #region"Properties, Custom Control Properties"

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PartNumberTag { get; set; } = "";

        /// <summary>
        /// Specifies the custom string filter, formated as, ColumnName LIKE ''
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint),
         Category("Custom Properties"),
         DefaultValue(""),
         Description("Get the Description for this component.")]
        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }


        }

        [RefreshProperties(RefreshProperties.Repaint),
         Category("Custom Properties"),
         DefaultValue(""),
         Description("Mode edition, None, Edit, Add, Delete, allowed to the user.")]
        public virtual Utilities.EditMode EditMode
        {
            set
            {
                switch (value)
                {
                    case Utilities.EditMode.View:
                        {
                            //   Value.Enabled = false;
                            //   Unid.Enabled = false;
                            //   Tolerance.Enabled = false;
                            //    Size.Enabled = false;
                            break;
                        }
                    case Utilities.EditMode.Edit:
                        {
                            //   Value.Enabled = true;
                            //   Unid.Enabled = true;
                            //   Tolerance.Enabled = true;
                            //   Size.Enabled = true;
                            break;
                        }
                    case Utilities.EditMode.Add:
                        {

                            break;
                        }
                    case Utilities.EditMode.Delete:
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

        public BaseComponent()
        {
            InitializeComponent();

            Utilities.IsInDesignMode();
        }

        public BaseComponent(CellDoubleClick_EventArgs receivedEvent)
        {
            InitializeComponent();
        }


        public string String_Add(string anterior, string posterior)
        {
            string _string_add = "";

            if (anterior == "")
                _string_add = posterior;
            else
                _string_add = ", " + posterior;

            return _string_add;
        }

        public virtual void UpdateInformation(ComponentInformation componentInformation)
        { }
    }
}

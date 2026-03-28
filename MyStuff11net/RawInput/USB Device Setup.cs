using System.Text;

namespace RawInput_dll
{
    public partial class USB_Device_Setup : Form
    {
        KeyPressEvent _usbDevice;
        public USB_Device_Setup(KeyPressEvent usbDevice)
        {
            InitializeComponent();
            _usbDevice = usbDevice;
        }

        void USB_Device_Setup_Shown(object sender, EventArgs e)
        {
            labelsVID.Text = _usbDevice.VID;
            labelPID.Text = _usbDevice.PID;

            labelSource.Text = _usbDevice.Source;
        }

        void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Button_AddDevice_Click(object sender, EventArgs e)
        {
            StringBuilder infoToSave = new StringBuilder();

            if (textBox_Name.Text != null)
                _usbDevice.CustomName = textBox_Name.Text;
            else
                _usbDevice.CustomName = "NoDef";

            if (textBox_Description.Text != null)
                _usbDevice.CustomDescription = textBox_Description.Text;
            else
                _usbDevice.CustomDescription = "NoDef";

            infoToSave.Append(_usbDevice.CustomName + ",");
            infoToSave.Append(_usbDevice.CustomDescription + ",");
            infoToSave.Append(_usbDevice.VID + ",");
            infoToSave.Append(_usbDevice.PID + ",");
            infoToSave.Append(_usbDevice.DeviceHandle.ToString() + ";");

            MyStuff11net.Properties.Settings.Default.USBDeviceCollection = infoToSave.ToString();
            MyStuff11net.Properties.Settings.Default.Save();

            Close();
        }
    }
}

using System.Diagnostics;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;

namespace RawInput_dll
{
    public class RawInput : NativeWindow
    {
        static bool wasBarCodeInput;
        readonly RawKeyboard _keyboardDriver;
        readonly IntPtr _devNotifyHandle;
        static readonly Guid DeviceInterfaceHid = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");
        PreMessageFilter _filter;
        readonly Timer USBDeviceChangeTimer;
        USB_Device_Setup USB_Device_SetupWindow;

        public event RawKeyboard.DeviceEventHandler BarCodeScannerEvent
        {
            add { _keyboardDriver.BarCodeScannerEvent += value; }
            remove { _keyboardDriver.BarCodeScannerEvent -= value; }
        }

        public event RawKeyboard.DeviceEventHandler USBDeviceEnabled
        {
            add { _keyboardDriver.USBDeviceEnabledEvent += value; }
            remove { _keyboardDriver.USBDeviceEnabledEvent -= value; }
        }

        public int NumberOfKeyboards
        {
            get { return _keyboardDriver.NumberOfKeyboards; }
        }

        public void AddMessageFilter()
        {
            if (null != _filter)
                return;

            _filter = new PreMessageFilter();
            Application.AddMessageFilter(_filter);
        }

        private void RemoveMessageFilter()
        {
            if (null == _filter)
                return;

            Application.RemoveMessageFilter(_filter);
            _filter = null;
        }

        public RawInput(IntPtr parentHandle, bool captureOnlyInForeground)
        {
            AssignHandle(parentHandle);

            _keyboardDriver = new RawKeyboard(parentHandle, captureOnlyInForeground);
            _keyboardDriver.USBDeviceAdd += KeyboardDriver_USBDeviceAdd;
            _keyboardDriver.USBDeviceRemoved += KeyboardDriver_USBDeviceRemoved;

            _devNotifyHandle = RegisterForDeviceNotifications(parentHandle);

            USBDeviceChangeTimer = new Timer
            {
                Interval = 750
            };
            USBDeviceChangeTimer.Tick += USBDeviceChangeTimer_Tick;

            AddMessageFilter();
        }

        private void KeyboardDriver_USBDeviceRemoved(object sender, RawInputEventArg e)
        {

        }

        private void KeyboardDriver_USBDeviceAdd(object sender, RawInputEventArg e)
        {
            if (null == USB_Device_SetupWindow)
            {
                USB_Device_SetupWindow = new USB_Device_Setup(e.KeyPressEvent);
                USB_Device_SetupWindow.ShowDialog(this);
            }
            USB_Device_SetupWindow = null;

            _keyboardDriver.InitUSBDevice();
        }

        static IntPtr RegisterForDeviceNotifications(IntPtr parent)
        {
            var usbNotifyHandle = IntPtr.Zero;
            var bdi = new BroadcastDeviceInterface();
            bdi.DbccSize = Marshal.SizeOf(bdi);
            bdi.BroadcastDeviceType = BroadcastDeviceType.DBT_DEVTYP_DEVICEINTERFACE;
            bdi.DbccClassguid = DeviceInterfaceHid;

            var mem = IntPtr.Zero;
            try
            {
                mem = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(BroadcastDeviceInterface)));
                Marshal.StructureToPtr(bdi, mem, false);
                usbNotifyHandle = Win32.RegisterDeviceNotification(parent, mem, DeviceNotification.DEVICE_NOTIFY_WINDOW_HANDLE);
            }
            catch (Exception e)
            {
                Debug.Print("Registration for device notifications Failed. Error: {0}", Marshal.GetLastWin32Error());
                Debug.Print(e.StackTrace);
            }
            finally
            {
                Marshal.FreeHGlobal(mem);
            }

            if (usbNotifyHandle == IntPtr.Zero)
            {
                Debug.Print("Registration for device notifications Failed. Error: {0}", Marshal.GetLastWin32Error());
            }

            return usbNotifyHandle;
        }

        void USBDeviceChangeTimer_Tick(object sender, EventArgs e)
        {
            USBDeviceChangeTimer.Stop();

            _keyboardDriver.ProcessUSBDeviceChange();
        }

        protected override void WndProc(ref Message message)
        {
            wasBarCodeInput = false;

            switch (message.Msg)
            {
                case Win32.WM_INPUT:
                    {
                        wasBarCodeInput = _keyboardDriver.GetRawInputData(message.LParam);
                    }
                    break;

                case Win32.WM_USB_DEVICECHANGE:
                    {
                        if (USB_Device_SetupWindow != null)
                            return;

                        if (!USBDeviceChangeTimer.Enabled)
                            USBDeviceChangeTimer.Start();
                    }
                    break;
            }

            base.WndProc(ref message);
        }

        class PreMessageFilter : IMessageFilter
        {
            // true  to filter the message and stop it from being dispatched 
            // false to allow the message to continue to the next filter or control.
            public bool PreFilterMessage(ref Message m)
            {
                //return m.Msg == Win32.WM_KEYDOWN;

                if (m.Msg != Win32.WM_KEYDOWN)
                {
                    // Allow any non WM_INPUT message to pass through
                    return false;
                }

                return wasBarCodeInput;
            }
        }

        ~RawInput()
        {
            Win32.UnregisterDeviceNotification(_devNotifyHandle);
            RemoveMessageFilter();
        }
    }
}

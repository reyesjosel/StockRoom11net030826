using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace RawInput_dll
{
    public sealed class RawKeyboard
    {
        public readonly Dictionary<IntPtr, KeyPressEvent> DeviceList = new Dictionary<IntPtr, KeyPressEvent>();

        public delegate void DeviceEventHandler(object sender, RawInputEventArg e);

        public delegate void USBDeviceAddEventHandler(object sender, RawInputEventArg e);
        public event DeviceEventHandler USBDeviceAdd;

        public delegate void USBDeviceRemovedEventHandler(object sender, RawInputEventArg e);
        public event DeviceEventHandler USBDeviceRemoved;

        public delegate void BarCodeScannerEventHandler(object sender, RawInputEventArg e);
        public event DeviceEventHandler BarCodeScannerEvent;

        public delegate void USBDeviceEnabledEventHandler(object sender, RawInputEventArg e);
        public event DeviceEventHandler USBDeviceEnabledEvent;

        string[] _usbDeviceInfo;
        readonly object _padLock = new object();
        string ASCII_control_character_Message = "";
        StringBuilder keystrokeBuffer = new StringBuilder();
        InputData _rawBuffer = new InputData();
        static KeyPressEvent keyPressEvent;
        public static KeyPressEvent USBDevice;
        public int NumberOfKeyboards { get; private set; }

        readonly System.Windows.Forms.Timer InputMessageTimer;
        readonly System.Windows.Forms.Timer USBDeviceEnabledTimer;

        public RawKeyboard(IntPtr hwnd, bool captureOnlyInForeground)
        {
            var rid = new RawInputDevice[1];

            rid[0].UsagePage = HidUsagePage.GENERIC;
            rid[0].Usage = HidUsage.Keyboard;
            rid[0].Flags = (captureOnlyInForeground ? RawInputDeviceFlags.NONE : RawInputDeviceFlags.INPUTSINK) | RawInputDeviceFlags.DEVNOTIFY;
            rid[0].Target = hwnd;

            if (!Win32.RegisterRawInputDevices(rid, (uint)rid.Length, (uint)Marshal.SizeOf(rid[0])))
            {
                throw new ApplicationException("Failed to register raw input device(s).");
            }

            InputMessageTimer = new System.Windows.Forms.Timer
            {
                Interval = 100
            };
            InputMessageTimer.Tick += InputMessageTimer_Tick;

            USBDeviceEnabledTimer = new System.Windows.Forms.Timer
            {
                Interval = 250
            };
            USBDeviceEnabledTimer.Tick += USBDeviceEnabledTimer_Tick;

            InitUSBDevice();
        }

        void USBDeviceEnabledTimer_Tick(object sender, EventArgs e)
        {
            USBDeviceEnabledTimer.Stop();
            USBDeviceEnabledEvent?.Invoke(this, new RawInputEventArg(USBDevice));
        }

        public void InitUSBDevice()
        {
            char[] delimiterChars = { ',', ';' };

            _usbDeviceInfo = MyStuff11net.Properties.Settings.Default.USBDeviceCollection.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            if (_usbDeviceInfo.Length > 2)
                EnumerateDevices(_usbDeviceInfo);
            else
                EnumerateDevices(new string[] { "NoDef", "NoDef", "NoDef", "NoDef" });

            if (USBDevice != null)
                USBDeviceEnabledTimer.Start();
        }

        void InputMessageTimer_Tick(object sender, EventArgs e)
        {
            InputMessageTimer.Stop();

            keyPressEvent.BarCodeDataRead = keystrokeBuffer.ToString();
            keyPressEvent.ASCIIControlChar = ASCII_control_character_Message;

            keystrokeBuffer.Clear();

            BarCodeScannerEvent?.Invoke(this, new RawInputEventArg(keyPressEvent));
        }

        public void EnumerateDevices(string[] usbDeviceInfo)
        {
            string USBDeviceVID = usbDeviceInfo[2];
            string USBDevicePID = usbDeviceInfo[3];
            string USBDeviceName = usbDeviceInfo[0];
            string USBDeviceDesc = usbDeviceInfo[1];

            lock (_padLock)
            {
                DeviceList.Clear();

                var keyboardNumber = 0;
                var globalDevice = new KeyPressEvent
                {
                    DeviceName = "Global Keyboard",
                    DeviceHandle = IntPtr.Zero,
                    DeviceType = Win32.GetDeviceType(DeviceType.RimTypekeyboard),
                    Name = "Fake Keyboard. Some keys (ZOOM, MUTE, VOLUMEUP, VOLUMEDOWN) are sent to rawinput with a handle of zero.",
                    Source = keyboardNumber++.ToString(CultureInfo.InvariantCulture),
                    DeviceKey = IntPtr.Zero
                };
                DeviceList.Add(globalDevice.DeviceHandle, globalDevice);

                var numberOfDevices = 0;
                uint deviceCount = 0;
                var dwSize = Marshal.SizeOf(typeof(Rawinputdevicelist));

                if (Win32.GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, (uint)dwSize) == 0)
                {
                    IntPtr pRawInputDeviceList = Marshal.AllocHGlobal((int)(dwSize * deviceCount));
                    Win32.GetRawInputDeviceList(pRawInputDeviceList, ref deviceCount, (uint)dwSize);

                    for (var i = 0; i < deviceCount; i++)
                    {
                        uint pcbSize = 0;

                        // On Window 8 64bit when compiling against .Net > 3.5 using .ToInt32 you will generate an arithmetic overflow. Leave as it is for 32bit/64bit applications
                        Rawinputdevicelist rid = (Rawinputdevicelist)Marshal.PtrToStructure(new IntPtr(pRawInputDeviceList.ToInt64() + (dwSize * i)), typeof(Rawinputdevicelist));

                        Win32.GetRawInputDeviceInfo(rid.hDevice, RawInputDeviceInfo.RIDI_DEVICENAME, IntPtr.Zero, ref pcbSize);

                        if (pcbSize <= 0)
                            continue;

                        IntPtr pData = Marshal.AllocHGlobal((int)pcbSize);
                        Win32.GetRawInputDeviceInfo(rid.hDevice, RawInputDeviceInfo.RIDI_DEVICENAME, pData, ref pcbSize);
                        string deviceName = Marshal.PtrToStringAnsi(pData);

                        if (rid.dwType == DeviceType.RimTypekeyboard || rid.dwType == DeviceType.RimTypeHid)
                        {
                            var deviceDesc = Win32.GetDeviceDescription(deviceName);
                            GetRawInputData(rid.hDevice);

                            var dInfo = new KeyPressEvent
                            {
                                DeviceName = deviceName,
                                DeviceHandle = rid.hDevice,
                                DeviceType = Win32.GetDeviceType(rid.dwType),
                                Name = deviceDesc,
                                Source = keyboardNumber++.ToString(CultureInfo.InvariantCulture),
                                DeviceKey = _rawBuffer.header.hDevice
                            };

                            dInfo.VID = dInfo.DeviceName.Substring(dInfo.DeviceName.IndexOf("VID_") + 4, 4);
                            dInfo.PID = dInfo.DeviceName.Substring(dInfo.DeviceName.IndexOf("PID_") + 4, 4);

                            if (!DeviceList.ContainsKey(rid.hDevice))
                            {
                                if (dInfo.VID.Contains(USBDeviceVID) && dInfo.DeviceType.Contains("KEYBOARD"))
                                {
                                    USBDevice = dInfo;
                                    USBDevice.CustomName = USBDeviceName;
                                    USBDevice.CustomDescription = USBDeviceDesc;
                                }

                                numberOfDevices++;
                                DeviceList.Add(rid.hDevice, dInfo);
                            }
                        }

                        Marshal.FreeHGlobal(pData);
                    }

                    Marshal.FreeHGlobal(pRawInputDeviceList);

                    NumberOfKeyboards = numberOfDevices;
                    Debug.WriteLine("EnumerateDevices() found {0} Keyboard(s)", NumberOfKeyboards);
                    return;
                }
            }

            throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public void ProcessUSBDeviceChange()
        {
            KeyPressEvent changeValue = new KeyPressEvent();
            Dictionary<IntPtr, KeyPressEvent> _deviceListDef = new Dictionary<IntPtr, KeyPressEvent>();
            Dictionary<IntPtr, KeyPressEvent> _deviceListOld = new Dictionary<IntPtr, KeyPressEvent>(DeviceList);

            if (_usbDeviceInfo.Length > 2)
                EnumerateDevices(_usbDeviceInfo);
            else
                EnumerateDevices(new string[] { "NoDef", "NoDef", "NoDef", "NoDef" });

            foreach (KeyValuePair<IntPtr, KeyPressEvent> item in DeviceList)
            {
                if (_deviceListOld.ContainsKey(item.Key) || _deviceListDef.ContainsKey(item.Key))
                    continue;

                if (item.Value.DeviceType.Contains("KEYBOARD"))
                {
                    changeValue = item.Value;
                    _deviceListDef.Add(item.Key, item.Value);

                    if (_deviceListOld.Count < DeviceList.Count)
                    {
                        USBDeviceAdd?.Invoke(this, new RawInputEventArg(changeValue));
                    }
                    else
                    {
                        USBDeviceRemoved?.Invoke(this, new RawInputEventArg(changeValue));
                    }

                    break;
                }
            }
        }

        public void ProcessRawInput()
        {
            if (DeviceList.Count == 0)
                return;

            int virtualKey = _rawBuffer.data.keyboard.VKey;
            int makeCode = _rawBuffer.data.keyboard.Makecode;
            int flags = _rawBuffer.data.keyboard.Flags;

            if (virtualKey == Win32.KEYBOARD_OVERRUN_MAKE_CODE)
                return;

            bool isE0BitSet = ((flags & Win32.RI_KEY_E0) != 0);

            lock (_padLock)
            {
                keyPressEvent = DeviceList[_rawBuffer.header.hDevice];
            }

            bool isBreakBitSet = ((flags & Win32.RI_KEY_BREAK) != 0);

            keyPressEvent.KeyPressState = isBreakBitSet ? "BREAK" : "MAKE";
            keyPressEvent.Message = _rawBuffer.data.keyboard.Message;
            keyPressEvent.VKeyName = KeyMapper.GetKeyName(VirtualKeyCorrection(virtualKey, isE0BitSet, makeCode, _rawBuffer)).ToUpper();
            keyPressEvent.VKey = virtualKey;

            char ASCII_control_value;

            if (keyPressEvent.KeyPressState.Equals("MAKE"))
            {
                ASCII_control_character_Message = "";
                ASCII_control_value = (char)keyPressEvent.VKey;

                switch (ASCII_control_value)
                {
                    #region"ASCII_control_character"
                    case '\u0000':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "00 NULL char (SP)";
                            break;
                        }
                    case '\u0001':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "01 Start of Heading (SOH)";
                            break;
                        }
                    case '\u0002':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "02 Start of Text (STX)";
                            break;
                        }
                    case '\u0003':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "03 End of Text (ETX)";
                            break;
                        }
                    case '\u0004':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "04 END OF TRANSMISSION (EOT)";
                            break;
                        }
                    case '\u0005':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "05 Enquiry (ENQ)";
                            break;
                        }
                    case '\u0006':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "06 Acknowledgment (ACK)";
                            break;
                        }
                    case '\u0007':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "07 Bell (BEL)";
                            break;
                        }
                    case '\u0008':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "08 Back Space (BS)";
                            break;
                        }
                    case '\u0009':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "09 Horizontal Tab (HT/Tab)";
                            break;
                        }
                    case '\u000A':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "0A Line Feed (LF)";
                            break;
                        }
                    case '\u000B':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "0B Vertical Tab (VT)";
                            break;
                        }
                    case '\u000C':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "0C Form Feed (FF)";
                            break;
                        }
                    case '\u000D':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "0D Carriage Return (CR/Enter)";
                            break;
                        }
                    case '\u000E':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "0E Shift Out / X-On (SO)";
                            break;
                        }
                    case '\u000F':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "0F Shift In / X-Off (SI)";
                            break;
                        }
                    case '\u0010':
                        {
                            ASCII_control_character_Message += "10 Data Line Escape (DLE)";
                            break;
                        }
                    case '\u0011':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "11 Device Control 1 (oft. XON) (DC1)";
                            break;
                        }
                    case '\u0012':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "12 Device Control 2 (DC2)";
                            break;
                        }
                    case '\u0013':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "13 Device Control 3 (oft. XOFF) (DC3)";
                            break;
                        }
                    case '\u0014':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "14 Device Control 4 (DC4)";
                            break;
                        }
                    case '\u0015':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "15 Negative Acknowledgement (NAK)";
                            break;
                        }
                    case '\u0016':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "16 Synchronous Idle (SYN)";
                            break;
                        }
                    case '\u0017':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "17 End of Transmit Block (ETB)";
                            break;
                        }
                    case '\u0018':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "18 Cancel (CAN)";
                            break;
                        }
                    case '\u0019':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "19 End of Medium (EM)";
                            break;
                        }
                    case '\u001A':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "1A Substitute (SUB)";
                            break;
                        }
                    case '\u001B':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "1B Escape (ESC)";
                            break;
                        }
                    case '\u001C':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "1C File Separator (FS)";
                            break;
                        }
                    case '\u001D':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "1D Group Separator (GS)";
                            break;
                        }
                    case '\u001E':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "1E Record Separator (RS)";
                            break;
                        }
                    case '\u001F':
                        {
                            InputMessageTimer.Start();
                            ASCII_control_character_Message += "1F Unit Separator (US)";
                            break;
                        }
                    #endregion"ASCII_control_character"
                    default:
                        {
                            char c = (char)MapVirtualKey(_rawBuffer.data.keyboard.VKey, 2);
                            keystrokeBuffer.Append(c.ToString());

                            break;
                        }
                }
            }
        }

        public bool GetRawInputData(IntPtr hdevice)
        {
            var dwSize = 0;

            Win32.GetRawInputData(hdevice, DataCommand.RID_INPUT, IntPtr.Zero, ref dwSize, Marshal.SizeOf(typeof(Rawinputheader)));

            if (dwSize != Win32.GetRawInputData(hdevice, DataCommand.RID_INPUT, out _rawBuffer, ref dwSize, Marshal.SizeOf(typeof(Rawinputheader))))
            {
                Debug.WriteLine("Error getting the rawinput buffer");
                return false;
            }

            if (USBDevice != null && USBDevice.DeviceHandle == _rawBuffer.header.hDevice)
            {
                ProcessRawInput();
                return true;
            }
            else
                return false;
        }

        private static int VirtualKeyCorrection(int virtualKey, bool isE0BitSet, int makeCode, InputData _rawBuffer)
        {
            var correctedVKey = virtualKey;

            if (_rawBuffer.header.hDevice == IntPtr.Zero)
            {
                // When hDevice is 0 and the vkey is VK_CONTROL indicates the ZOOM key
                if (_rawBuffer.data.keyboard.VKey == Win32.VK_CONTROL)
                {
                    correctedVKey = Win32.VK_ZOOM;
                }
            }
            else
            {
                switch (virtualKey)
                {
                    // Right-hand CTRL and ALT have their e0 bit set 
                    case Win32.VK_CONTROL:
                        correctedVKey = isE0BitSet ? Win32.VK_RCONTROL : Win32.VK_LCONTROL;
                        break;
                    case Win32.VK_MENU:
                        correctedVKey = isE0BitSet ? Win32.VK_RMENU : Win32.VK_LMENU;
                        break;
                    case Win32.VK_SHIFT:
                        correctedVKey = makeCode == Win32.SC_SHIFT_R ? Win32.VK_RSHIFT : Win32.VK_LSHIFT;
                        break;
                    default:
                        correctedVKey = virtualKey;
                        break;
                }
            }

            return correctedVKey;
        }

        [DllImport("user32.dll")]
        public static extern int MapVirtualKey(int uCode, uint uMapType);
    }
}

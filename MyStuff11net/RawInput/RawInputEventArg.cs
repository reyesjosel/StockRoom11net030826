namespace RawInput_dll
{
    public class RawInputEventArg : EventArgs
    {
        public RawInputEventArg(KeyPressEvent arg)
        {
            KeyPressEvent = arg;
        }

        public KeyPressEvent KeyPressEvent { get; private set; }

        public string BarcodeData
        {
            get
            {
                if (KeyPressEvent == null)
                    return "No Data";

                return KeyPressEvent.BarCodeDataRead;
            }
        }

        public string ASCIIControlChar
        {
            get
            {
                if (KeyPressEvent == null)
                    return "No Data";

                return KeyPressEvent.ASCIIControlChar;
            }
        }
    }
}

namespace RawInput_dll
{
    public class PreMessageFilter12345 : IMessageFilter
    {
        // true  to filter the message and stop it from being dispatched 
        // false to allow the message to continue to the next filter or control.
        public bool PreFilterMessage(ref Message m)
        {
            //return m.Msg == Win32.WM_KEYDOWN;

            if (m.Msg != Win32.WM_INPUT)
            {
                // Allow any non WM_INPUT message to pass through
                return false;
            }
            return true;
            //return _keyboardDriver.GetRawInputData(message.LParam);
        }
    }
}

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace StockRoom11net.BlazorWebAssembly.Data
{
    public class AppService
    {
        public event Action<string> MessageReceived;
        public event Action<string> UpDateTimeLineEvent;


        public void UpDateTimeLine(string message)
        {
            UpDateTimeLineEvent?.Invoke(message);
        }

        public void SendMessageToBlazor(string message)
        {
            MessageReceived?.Invoke(message);
        }
    }
}

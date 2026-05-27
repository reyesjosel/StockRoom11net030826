// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace StockRoom11net.BlazorWebAssembly.Data
{
    /// <summary>
    /// Provides event-based communication between WinForms and Blazor components.
    /// </summary>
    /// <remarks>Blazor components should subscribe to events in their OnInitialized lifecycle method to
    /// receive messages from WinForms.</remarks>
    public class AppService
    {
        /// <summary>
        /// Action delegate to send messages from WinForms to Blazor. We need to use Action<string>
        /// because Blazor components can only receive string parameters from JavaScript interop.
        /// The string parameter can be used to pass any message or data needed by the Blazor component.
        /// In Blazor, OnInitialized() we have to subscribe to the MessageReceived event to handle incoming messages.
        /// </summary>
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

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StockRoom11net.BlazorWebAssembly.Components.Pages;
using StockRoom11net.Controls.VisTimeLine;

namespace StockRoom11net.BlazorWebAssembly.Data
{
    /// <summary>
    /// Provides event-based communication between WinForms and Blazor components.
    /// </summary>
    /// <remarks>Blazor components should subscribe to events in their OnInitialized lifecycle method to
    /// receive messages from WinForms.</remarks>
    public class AppService
    {
        #region C# calls to subscribe to the AppService events.
        // C# invokes the event subscribers in AppService;
        // the subscription is established in the `OnAfterRenderAsync(bool firstRender)` event, while
        // maintaining a reference to allow the subscription to be removed in the `Dispose()` event.
               
        public event Action<string> SelectItemEvent;
        public event Action<string> UpDateTimeLineEvent;
        public event Action<TimeLineItem> UpDateItemEvent;

        private event Action<string>? _initializeDataEvent;

        public event Action<string>? InitializeDataEvent
        {
            add
            {
                _initializeDataEvent += value;

                // If data arrived before this component subscribed, deliver it now.
                if (PendingInitData != null)
                {
                    var data = PendingInitData;
                    PendingInitData = null;
                    value?.Invoke(data);   // deliver directly to this new subscriber
                }
            }
            remove => _initializeDataEvent -= value;
        }

        /// <summary>
        /// Fired when the vis-timeline JS component has been fully created and is ready to receive data.
        /// WinForms can subscribe to this event to know when it is safe to call <see cref="InitializeData"/>.
        /// </summary>
        public event Action? TimelineReadyEvent;

        /// <summary>
        /// Data buffered when <see cref="InitializeData"/> is called before the timeline component is ready.
        /// <see cref="TimeLineComp"/> will drain this in <c>OnAfterRenderAsync</c> after <c>timelineInterop.create</c> completes.
        /// </summary>
        public string? PendingInitData { get; private set; }

        public void InitializeData(string message)
        {
            if (_initializeDataEvent == null)
                PendingInitData = message;   // no subscriber yet — buffer
            else
            {
                PendingInitData = null;
                _initializeDataEvent.Invoke(message);
            }
        }

        /// <summary>
        /// Called by <see cref="TimeLineComp"/> once <c>timelineInterop.create</c> has completed successfully.
        /// Drains any pending init data and fires <see cref="TimelineReadyEvent"/> so WinForms is notified.
        /// </summary>
        public void NotifyTimelineReady()
        {
            TimelineReadyEvent?.Invoke();
        }

        public void UpDateTimeLine(string message)
        {
            UpDateTimeLineEvent?.Invoke(message);
        }

        public void SelectItem(string message)
        {
            SelectItemEvent?.Invoke(message);
        }

        public void UpDateItem(TimeLineItem item)
        {
            UpDateItemEvent?.Invoke(item);
        }

        #endregion C# calls to subscribe to the AppService events.

        #region JSInterop calls back to Blazor page, them
        // blazor page call _appService.NotifySelect(id) invoke EventCallback<> and
        // the event fire whatever C# is listening to the event.

        public EventCallback<string> OnSelectEvent;
        public EventCallback<TimeLineItem> OnAddEvent;
        public EventCallback<TimeLineItem> OnUpdateEvent;
        public EventCallback<TimeLineItem> OnMovedEvent;
        public EventCallback<TimeLineItem> OnMovingEvent;
        public EventCallback<TimeLineItem> OnRemoveEvent;
        public EventCallback<TimeLineItem> OnResizeEvent;
        public EventCallback<(DateTime start, DateTime end)> OnRangeChangedEvent;
        public EventCallback<CanvasMouseArgs> MouseDownEvent;
        public EventCallback<CanvasMouseArgs> MouseUpEvent;
        public EventCallback<CanvasMouseArgs> MouseMoveEvent;

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of a selection event.
        /// </summary>
        /// <param name="id">The ID of the selected item.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task NotifySelect(string id) => await OnSelectEvent.InvokeAsync(id);

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of an add event.
        /// This event occurs when a new item is added to the timeline, when the user double-clicks on the timeline.
        /// It allows for validation before the item is added, and can trigger a rollback in the JavaScript UI if the addition is not valid.
        /// </summary>
        /// <param name="item">The item that was added.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task<bool> NotifyAdd(TimeLineItem item)
        {
            // 1. Run your validation logic (e.g., database checks, schedule conflicts)
            await OnAddEvent.InvokeAsync(item);

            bool isValidAdd = true; //await MyValidationService.CheckScheduleAsync(item);

            if (!isValidAdd)
            {
                return false; // Triggers the JS rollback
            }

            // 2. Save changes if valid
            //await MyDatabaseService.SaveItemPositionAsync(item);
            return true; // Triggers the JS UI confirmation
        }

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of an update event.
        /// This event occurs when an existing item is updated, when the user double-clicks on the item.
        /// It allows for validation before the item is updated, and can trigger a rollback in the JavaScript UI if the update is not valid.
        /// </summary>
        /// <param name="item">The item that was updated.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task<bool> NotifyUpdate(TimeLineItem item)
        {
            // 1. Run your validation logic (e.g., database checks, schedule conflicts)
            await OnUpdateEvent.InvokeAsync(item);

            bool isValidUpdate = true; //await MyValidationService.CheckScheduleAsync(item);

            if (!isValidUpdate)
            {
                return false; // Triggers the JS rollback
            }

            // 2. Save changes if valid
            //await MyDatabaseService.SaveItemPositionAsync(item);
            return true; // Triggers the JS UI confirmation
        }

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of a moved event.
        /// This occurs after the item has been moved, allowing for validation and
        /// confirmation of the move.
        /// </summary>
        /// <param name="item">The item that was moved.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task<bool> NotifyMoved(TimeLineItem item)
        {
            // 1. Run your validation logic (e.g., database checks, schedule conflicts)
            await OnMovedEvent.InvokeAsync(item);

            bool isValidMoved = true; //await MyValidationService.CheckScheduleAsync(item);

            if (!isValidMoved)
            {
                return false; // Triggers the JS rollback
            }

            // 2. Save changes if valid
            //await MyDatabaseService.SaveItemPositionAsync(item);
            return true; // Triggers the JS UI confirmation
        }

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of a moving event.
        /// This occurs while the item is being dragged ( moving ), allowing for
        /// validation before the move is finalized.
        /// </summary>
        /// <param name="item">The item that is being moved.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task<bool> NotifyMoving(TimeLineItem item)
        {
            // 1. Run your validation logic (e.g., database checks, schedule conflicts)
            await OnMovingEvent.InvokeAsync(item);

            bool isValidMoving = true; //await MyValidationService.CheckScheduleAsync(item);

            if (!isValidMoving)
            {
                return false; // Triggers the JS rollback
            }

            // 2. Save changes if valid
            //await MyDatabaseService.SaveItemPositionAsync(item);
            return true; // Triggers the JS UI confirmation
        }

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of a remove event.
        /// This occurs when an item red glyph is clicked ( X red bold ),
        /// This method allows for validation before the item is removed, and can
        /// trigger a rollback in the JavaScript UI if the removal is not valid.
        /// </summary>
        /// <param name="item">The item that is being removed.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task<bool> NotifyRemove(TimeLineItem item)
        {
            // 1. Run your validation logic (e.g., database checks, schedule conflicts)
            await OnRemoveEvent.InvokeAsync(item);

            bool isValidRemove = true; //await MyValidationService.CheckScheduleAsync(item);

            if (!isValidRemove)
            {
                return false; // Triggers the JS rollback
            }

            // 2. Save changes if valid
            //await MyDatabaseService.SaveItemPositionAsync(item);
            return true; // Triggers the JS UI confirmation
        }

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of a resize event.
        /// </summary>
        /// <param name="item">The item that was resized.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task<bool> NotifyResize(TimeLineItem item)
        {
            await OnResizeEvent.InvokeAsync(item);

            bool isValidResize = true; //await MyValidationService.CheckScheduleAsync(item);

            if (!isValidResize)
            {
                return false; // Triggers the JS rollback
            }

            // 2. Save changes if valid
            //await MyDatabaseService.SaveItemPositionAsync(item);
            return true; // Triggers the JS UI confirmation
        }

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of a range change event.
        /// This occurs when the visible range of the timeline changes, zooming in or out, or panning left or right.
        /// It allows the Blazor component to respond to changes in the timeline's visible range.
        /// </summary>
        /// <param name="start">The start of the new range.</param>
        /// <param name="end">The end of the new range.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task NotifyRangeChanged(DateTime start, DateTime end)
        {
            await OnRangeChangedEvent.InvokeAsync((start, end));
        }

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of a mouse down event.
        /// </summary>
        /// <param name="args">The arguments for the mouse down event.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task OnMouseDown(CanvasMouseArgs args)
        {
            await MouseDownEvent.InvokeAsync(args);
        }

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of a mouse up event.
        /// </summary>
        /// <param name="args">The arguments for the mouse up event.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task OnMouseUp(CanvasMouseArgs args)
        {
            await MouseUpEvent.InvokeAsync(args);
        }

        /// <summary>
        /// Called by JavaScript to notify the Blazor component of a mouse move event.
        /// </summary>
        /// <param name="args">The arguments for the mouse move event.</param>
        /// <returns></returns>
        [JSInvokable]
        public async Task OnMouseMove(CanvasMouseArgs args)
        {
            // Invoke the MouseMove event callback with the provided arguments
            await MouseMoveEvent.InvokeAsync(args);
        }


        #endregion JSInterop calls back to Blazor page.
    }
}

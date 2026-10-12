// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using StockRoom11net.Controls;
using StockRoom11net.Controls.ResourcesCache;
using System.ComponentModel;
using System.Data;
using static StockRoom11net.Controls.Custom_Events_Args;

namespace StockRoom11net.Data.Services
{
    public interface IAppService
    {
        /// <summary>
        /// A flag to indicate if the DataSheetFactory is busy processing a request
        /// or are loading the PDF_Viewer form, this is intended to prevent multiple
        /// simultaneous operations that could lead to conflicts or performance issues.
        /// Also, prevent StockRoom Inventory docking before the PDF_Viewer is fully
        /// loaded and ready to display the datasheet.
        /// </summary>
        public bool DataSheetFactoryIsBusy { get; set; }

        /// <summary>
        /// A flags about the visibility state of the dock control,
        /// most be update in solutions temple.DockStateChanged();
        /// </summary>
        public bool Showing { get; set; }

        /// <summary>
        /// Keep a record of the last Pictures accessed.
        /// </summary>
        public string FilePathPicturesBoxImage { get; set; }

        /// <summary>
        /// Keep a record of the last location accessed.
        /// </summary>
        public string FilePathLocationBoxImage { get; set; }

        /// <summary>
        /// Keep a reference to the current columns collection of the dataGridViewExtended_Inventory,
        /// </summary>
        public PropertyDescriptorCollection? ColumnsCollection { get; set; }

        /// <summary>
        /// Keep a reference to the current status of the current row view active
        /// in the dataGridViewExtended_Inventory and other relevant information.
        /// </summary>
        public CurrentStatus CurrentStatusReference { get; set; }

        /// <summary>
        /// Keep a reference to the current column active in the dataGridViewExtended_Inventory,
        /// </summary>
        public PropertyDescriptor? CurrentColumnActive { get; set; }

        /// <summary>
        /// Occurs when a status bar message is generated in any modules of the application,
        /// allowing the aplication to update the status bar with relevant information.
        /// </summary>
        public event Action<StatusBarMessage_EventArgs>? StatusBarMessageEvent;
        public void On_StatusBarMessage(StatusBarMessage_EventArgs args);
        
        public event Action<Notification>? NotificationsToSends;
        public void On_NotificationsToSends(Notification e);

        public event Action<object, LogFileMessageEventArgs>? LogFileMessage;
        public void On_LogFileMessage(LogFileMessageEventArgs e);

        public event Action<object, ActiveDataSheet_EventArgs>? ActiveDataSheet;
        public void On_ActiveDataSheet(ActiveDataSheet_EventArgs? e);

        public event Action<SpeechSynthesizerBase_EventArgs>? SpeechSynthesizerBase;
        public void On_SpeechSynthesizerBase(SpeechSynthesizerBase_EventArgs? e);
    }

    public class AppService : IAppService
    {
        #region"Properties"

        /// <summary>
        /// A flag to indicate if the DataSheetFactory is busy processing a request
        /// or are loading the PDF_Viewer form, this is intended to prevent multiple
        /// simultaneous operations that could lead to conflicts or performance issues.
        /// Also, prevent StockRoom Inventory docking before the PDF_Viewer is fully
        /// loaded and ready to display the datasheet.
        /// </summary>
        public bool DataSheetFactoryIsBusy { get; set; } = false;

        /// <summary>
        /// A flags about the visibility state of the dock control,
        /// most be update in solutions temple.DockStateChanged();
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Showing { get; set; }

        /// <summary>
        /// Keep a record of the last Pictures accessed.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilePathPicturesBoxImage { get; set; } = string.Empty;

        /// <summary>
        /// Keep a record of the last location accessed.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilePathLocationBoxImage { get; set; } = string.Empty;

        public ToolTip _tooltip = new ToolTip();

        /// <summary>
        /// Text message to be show into easyProgressBar.
        /// it self clean when the time up.
        /// </summary>
        public string _textMessage = "";

        /// <summary>
        /// Keep the last dataSheet_File serviced,
        /// if the next datasheet is same, return.
        /// </summary>
        public string _lastDataSheet = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PropertyDescriptorCollection? ColumnsCollection { get; set; }

        /// <summary>
        /// Current column active in the dataGridViewExtended_Inventory,
        /// update on CellClick and CellBegingEdit event.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PropertyDescriptor? CurrentColumnActive { get; set; }

        /// <summary>
        /// Current DataRowView active in the dataGridViewExtended_Inventory,
        /// update on CurrentRowActive and MouseEnterEvent event.
        /// </summary>
     //   [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
     //   public DataRowView CurrentRowViewActive { get; set; }
            
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CurrentStatus CurrentStatusReference { get; set; } = new CurrentStatus();
               
        #endregion"Properties"

        public event Action<StatusBarMessage_EventArgs>? StatusBarMessageEvent;

        public void On_StatusBarMessage(StatusBarMessage_EventArgs args)
        {
            StatusBarMessageEvent?.Invoke(args);
        }

        public event Action<Notification>? NotificationsToSends;

        public void On_NotificationsToSends(Notification e)
        {
            // Notify Subscribers
            NotificationsToSends?.Invoke(e);
        }

        public event Action<object, LogFileMessageEventArgs>? LogFileMessage;

        public void On_LogFileMessage(LogFileMessageEventArgs e)
        {
            // Notify Subscribers
            LogFileMessage?.Invoke(this, e);
        }

        public event Action<object, ActiveDataSheet_EventArgs>? ActiveDataSheet;

        public void On_ActiveDataSheet(ActiveDataSheet_EventArgs e)
        {
            // Notify Subscribers
            ActiveDataSheet?.Invoke(this, e);
        }

        public event Action<SpeechSynthesizerBase_EventArgs>? SpeechSynthesizerBase;

        public void On_SpeechSynthesizerBase(SpeechSynthesizerBase_EventArgs? e)
        {
            SpeechSynthesizerBase?.Invoke(e);
        }

    }
}

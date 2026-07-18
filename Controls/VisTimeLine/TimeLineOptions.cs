using StockRoom11net.Controls.TabControl;
using System.Text.Json.Serialization;

namespace StockRoom11net.Controls.VisTimeLine
{
    public class TimeLineOptions
    {
        /// <summary>
        /// Alignment of items with type 'box', 'range', and 'background'. Available values are 'auto' (default),
        /// 'center', 'left', or 'right'. For 'box' items, the 'auto' alignment is 'center'. For 'range' items,
        /// the auto alignment is dynamic: positioned left and shifted such that the contents is always visible on screen.
        /// </summary>
        [JsonPropertyName("aling")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public String Aling { get; set; } = "center";

        /// <summary>
        /// If true, the Timeline will automatically detect when its container is resized, and redraw itself accordingly.
        /// If false, the Timeline can be forced to repaint after its container has been resized using the function redraw().
        /// </summary>
        [JsonPropertyName("autoResize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool AutoResize { get; set; } = true;
        
        /// <summary>
        /// When a Timeline is configured to be clickToUse, it will react to mouse and touch events only when active.
        /// When active, a blue shadow border is displayed around the Timeline. The Timeline is set active by clicking on it,
        /// and is changed to inactive again by clicking outside the Timeline or by pressing the ESC key.
        /// </summary>
        [JsonPropertyName("clickToUse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool ClickToUse { get; set; } = false;

        /// <summary>
        /// An array of fields optionally defined on the timeline items that will be
        /// appended as data- attributes to the DOM element of the items.
        /// </summary>
        [JsonPropertyName("dataAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] DataAttributes { get; set; } = Array.Empty<string>();

        /// <summary>
        /// If true, the items in the timeline can be manipulated. Only applicable when option selectable is true.
        /// See also the callbacks onAdd, onUpdate, onMove, and onRemove. When editable is an object, one can
        /// enable or disable individual manipulation actions. See section Editing Items for a detailed explanation.
        /// </summary>
        /// <remarks>If set to null, the timeline uses the default editability settings. Use this property
        /// to enable or restrict editing features such as moving, resizing, or removing items on the
        /// timeline.</remarks>
        [JsonPropertyName("editable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TimeLineEditableOptions? Editable { get; set; } = new TimeLineEditableOptions();

        /// <summary>
        /// The initial end date for the axis of the timeline. If not provided,
        /// the latest date present in the items set is taken as end date.
        /// </summary>
        [JsonPropertyName("end")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? End { get; set; } = null; // Date | Number | String	none	

        /// <summary>
        /// Order the groups by a field name or custom sort function.
        /// By default, groups are not ordered.
        /// </summary>
        [JsonPropertyName("groupOrder")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? GroupOrder { get; set; } = null; // String | Function	none

        /// <summary>
        /// The height of the timeline in pixels or as a percentage. When height is undefined or null,
        /// the height of the timeline is automatically adjusted to fit the contents. It is possible to
        /// set a maximum height using option maxHeight to prevent the timeline from getting too high
        /// in case of automatically calculated height.
        /// </summary>
        /// <remarks>
        /// Height must be a string, not an int
        /// Valid values: "100px", "100%" , "auto"
        /// If you use "100%", the parent div must have an explicit height
        /// set, otherwise the timeline will not be visible.
        /// <div style = "height: 200px;" >
        ///     < div id= "timelineDiv" ></ div >
        /// </ div >
        /// </remarks>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Height { get; set; } = null; // Number | String	none	

        /// <summary>
        /// Select a locale for the Timeline. See section Localization for more information.
        /// </summary>
        [JsonPropertyName("locale")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Locale { get; set; } = null;

        /// <summary>
        /// A map with i18n locales. See section Localization for more information.
        /// </summary>
        [JsonPropertyName("locales")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object? Locales { get; set; } = null;

        /// <summary>
        /// The minimal margin in pixels between items and the time axis.
        /// </summary>
        [JsonPropertyName("margin.axis")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MarginAxis { get; set; } = 20;

        /// <summary>
        /// The minimal margin in pixels between items in both horizontal and vertical direction.
        /// </summary>
        [JsonPropertyName("margin.item")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MarginItem { get; set; } = 10;

        /// <summary>
        /// The minimal horizontal margin in pixels between items.
        /// </summary>
        [JsonPropertyName("margin.item.horizontal")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MarginItemHorizontal { get; set; } = 10;

        /// <summary>
        /// The minimal vertical margin in pixels between items.
        /// </summary>
        [JsonPropertyName("margin.item.vertical")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MarginItemVertical { get; set; } = 10;

        /// <summary>
        /// Set a maximum Date for the visible range.
        /// It will not be possible to move beyond this maximum.
        /// </summary>
        [JsonPropertyName("max")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Max { get; set; } = null; // Date | Number | String	none	

        /// <summary>
        /// Specifies the maximum height for the Timeline.
        /// Can be a number in pixels or a string like "300px".
        /// </summary>
        [JsonPropertyName("maxHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? MaxHeight { get; set; } = null;  // Number | String	none

        /// <summary>
        ///Set a minimum Date for the visible range.
        ///It will not be possible to move beyond this minimum.
        /// </summary>
        [JsonPropertyName("min")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Min { get; set; } = null;  // Date | Number | String	none	

        /// <summary>
        /// Specifies the minimum height for the Timeline. Can be a number in pixels or a string like "300px".
        /// </summary>
        [JsonPropertyName("minHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? MinHeight { get; set; } = null;  // Number | String	none

        /// <summary>
        /// Specifies whether the Timeline can be moved and zoomed by dragging the window. See also option zoomable.
        /// </summary>
        [JsonPropertyName("moveable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Moveable { get; set; } = true;

        /// <summary>
        /// Callback function triggered when an item is about to be added: when the user double taps
        /// an empty space in the Timeline. See section Editing Items for more information. Only
        /// applicable when both options selectable and editable.add are set true.
        /// </summary>
        [JsonPropertyName("onAdd")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Action<TimeLineAddEventArgs>? OnAdd { get; set; } = null;

        /// <summary>
        /// Callback function triggered when an item is about to be updated, when the user double taps an item in the Timeline. See section Editing Items for more information. Only applicable when both options selectable and editable.updateTime or editable.updateGroup are set true.
        /// </summary>
        [JsonPropertyName("onUpdate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Action<TimeLineUpdateEventArgs>? OnUpdate { get; set; } = null;

        /// <summary>
        /// Callback function triggered when an item has been moved: after the user has dragged the
        /// item to another position. See section Editing Items for more information. Only applicable
        /// when both options selectable and editable.updateTime or editable.updateGroup are set true.
        /// </summary>
        [JsonPropertyName("onMove")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Action<TimeLineUpdateEventArgs>? OnMove { get; set; } = null;

        /// <summary>
        /// Callback function triggered repeatedly when an item is being moved. See section
        /// Editing Items for more information. Only applicable when both options selectable
        /// and editable.updateTime or editable.updateGroup are set true.
        /// </summary>
        [JsonPropertyName("onMoving")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Action<TimeLineUpdateEventArgs>? OnMoving { get; set; } = null;

        /// <summary>
        /// Callback function triggered when an item is about to be removed: when the user tapped the
        /// delete button on the top right of a selected item. See section Editing Items for more information.
        /// Only applicable when both options selectable and editable.remove are set true.
        /// </summary>
        [JsonPropertyName("onRemove")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Action<TimeLineUpdateEventArgs>? OnRemove { get; set; } = null;

        /// <summary>
        /// Orientation of the timeline: 'top' or 'bottom' (default). If orientation is 'bottom',
        /// the time axis is drawn at the bottom, and if 'top', the axis is drawn on top.
        /// </summary>
        [JsonPropertyName("orientation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Orientation { get; set; } = "bottom";

        /// <summary>
        /// The padding of items, needed to correctly calculate the size of item ranges. Must correspond
        /// with the css of items, for example when setting options.padding=10, corresponding css is:
        /// .vis.timeline.item { padding: 10px; }
        /// </summary>
        [JsonPropertyName("padding")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Padding { get; set; } = 5;

        /// <summary>
        /// If true, the items on the timeline can be selected. Multiple items can be selected
        /// by long pressing them, or by using ctrl+click or shift+click. The event select is
        /// fired each time the selection has changed (see section Events).
        /// </summary>
        [JsonPropertyName("selectable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Selectable { get; set; } = true;

        /// <summary>
        /// Show a vertical bar at the current time.
        /// </summary>
        [JsonPropertyName("showCurrentTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool ShowCurrentTime { get; set; } = true;

        /// <summary>
        /// Show a vertical bar displaying a custom time. This line can be dragged by the user.
        /// The custom time can be utilized to show a state in the past or in the future.
        /// When the custom time bar is dragged by the user, the event timechange is fired repeatedly.
        /// After the bar is dragged, the event timechanged is fired once.
        /// </summary>
        [JsonPropertyName("showCustomTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool ShowCustomTime { get; set; } = false;

        /// <summary>
        /// By default, the timeline shows both minor and major date labels on the time axis.
        /// For example the minor labels show minutes and the major labels show hours.
        /// When showMajorLabels is false, no major labels are shown.
        /// </summary>
        [JsonPropertyName("showMajorLabels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool ShowMajorLabels { get; set; } = true;

        /// <summary>
        /// By default, the timeline shows both minor and major date labels on the time axis.
        /// For example the minor labels show minutes and the major labels show hours.
        /// When showMinorLabels is false, no minor labels are shown. When both showMajorLabels
        /// and showMinorLabels are false, no horizontal axis will be visible.
        /// </summary>
        [JsonPropertyName("showMinorLabels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool ShowMinorLabels { get; set; } = true;

        /// <summary>
        /// If true (default), items will be stacked on top of each other such that they do not overlap.
        /// </summary>
        [JsonPropertyName("stack")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Stack { get; set; } = true;

        /// <summary>
        /// The initial start date for the axis of the timeline. If not provided,
        /// the earliest date present in the events is taken as start date.
        /// </summary>
        [JsonPropertyName("start")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Start { get; set; } = null;  // Date | Number | String	none	

        /// <summary>
        /// //A template function used to generate the contents of the items. The function
        /// is called by the Timeline with an items data as argument, and must return HTML
        /// code as result. When the option template is specified, the items do not need to
        /// have a field content. See section Templates for a detailed explanation.
        /// </summary>
        [JsonPropertyName("template")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Action<string> Template { get; set; } = null;

        /// <summary>
        /// Specifies the default type for the timeline items. Choose from 'box', 'point', 'range', and 'background'.
        /// Note that individual items can override this default type. If undefined, the Timeline will auto detect
        /// the type from the items data: if a start and end date is available, a 'range' will be created, and else,
        /// a 'box' is created. Items of type 'background' are not editable.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Type { get; set; } = null;

        /// <summary>
        /// The width of the timeline in pixels or as a percentage.
        /// </summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Width { get; set; } = "100%";

        /// <summary>
        /// Specifies whether the Timeline can be zoomed by pinching or scrolling in the window.
        /// Only applicable when option moveable is set true.
        /// </summary>
        [JsonPropertyName("zoomable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Zoomable { get; set; } = true;

        /// <summary>
        /// Set a maximum zoom interval for the visible range in milliseconds. It will not be possible to
        /// zoom out further than this maximum. Default value equals about 10000 years.
        /// </summary>
        [JsonPropertyName("zoomMax")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long ZoomMax { get; set; } = 315360000000000;

        /// <summary>
        /// Set a minimum zoom interval for the visible range in milliseconds.
        /// It will not be possible to zoom in further than this minimum.
        /// </summary>
        [JsonPropertyName("zoomMin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long ZoomMin { get; set; } = 10;



        [JsonPropertyName("multiselect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Multiselect { get; set; } = null;
        
        /// <summary>
        /// Gets or sets a value indicating whether horizontal scrolling is enabled.
        /// </summary>
        [JsonPropertyName("horizontalScroll")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HorizontalScroll { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether vertical scrolling is enabled.
        /// </summary>
        [JsonPropertyName("verticalScroll")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? VerticalScroll { get; set; } = null;

        /// <summary>
        /// Gets or sets the modifier key used to trigger zoom actions.
        /// </summary>
        /// <remarks>Typical values include "ctrlKey", "altKey", or other supported modifier key names.
        /// The value determines which keyboard modifier must be held to enable zoom functionality in the associated
        /// context.</remarks>
          [JsonPropertyName("zoomKey")]
          public string? ZoomKey { get; set; }

        /// <summary>
        /// Gets or sets the configuration options for the time axis of the timeline chart.
        /// Use this property to customize the appearance and behavior of the time axis, such as
        /// formatting, intervals, and display settings. If not set, default axis options will be applied.
        /// </summary>        
        [JsonPropertyName("timeAxis")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TimeLineAxisOptions? TimeAxis { get; set; }

        /// <summary>
        /// Gets or sets the margin options for the timeline layout.
        /// </summary>
        [JsonPropertyName("margin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TimeLineMargin? Margin { get; set; } = null;

        /// <summary>
        /// Gets or sets the formatting options to apply to the timeline output.
        /// </summary>
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TimeLineFormatOptions? Format { get; set; } = null;

        public class TimeLineUpdateEventArgs
        {
        }

        public class TimeLineAddEventArgs
        {
        }
    }

}

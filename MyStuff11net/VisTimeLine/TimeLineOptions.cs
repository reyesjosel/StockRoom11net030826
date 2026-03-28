using System.Text.Json.Serialization;

namespace MyStuff11net.VisTimeLine
{
    public class TimeLineOptions
    {
        /// <summary>
        /// Gets or sets the start date and time for the event or time range.
        /// </summary>
        [JsonPropertyName("start")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Start { get; set; } = null;

        /// <summary>
        /// Gets or sets the end date and time for the event or time range.
        /// </summary>
        [JsonPropertyName("end")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? End { get; set; } = null;

        /// <summary>
        /// Gets or sets the minimum date and time value allowed or applicable for the associated context.
        /// </summary>
        [JsonPropertyName("min")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Min { get; set; } = null;

        /// <summary>
        /// Gets or sets the maximum date and time value allowed or applicable for the associated context.
        /// </summary>
        [JsonPropertyName("max")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? Max { get; set; } = null;

        /// <summary>
        /// Gets or sets the height value associated with the object.
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
        public string? Height { get; set; } = null;

        /// <summary>
        /// Gets or sets the maximum height constraint for the element, typically specified as a CSS value.
        /// Optional but commonly paired
        /// </summary>
        [JsonPropertyName("maxHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? MaxHeight { get; set; } = "default";

        /// <summary>
        /// Gets or sets the minimum height constraint for the element.
        /// </summary>
        [JsonPropertyName("minHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? MinHeight { get; set; } = "default";

        /// <summary>
        /// Gets or sets a value indicating whether the item can be selected by the user.
        /// </summary>
        [JsonPropertyName("selectable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Selectable { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether the item can be moved.
        /// </summary>
        [JsonPropertyName("moveable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Moveable { get; set; } = null;

        [JsonPropertyName("multiselect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Multiselect { get; set; } = null;

        /// <summary>
        /// Gets or sets the options that determine whether and how the timeline can be edited by the user.
        /// </summary>
        /// <remarks>If set to null, the timeline uses the default editability settings. Use this property
        /// to enable or restrict editing features such as moving, resizing, or removing items on the
        /// timeline.</remarks>
        [JsonPropertyName("editable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TimeLineEditableOptions? Editable { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether the data series are stacked in the chart.
        /// </summary>
        [JsonPropertyName("stack")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Stack { get; set; } = null;

        /// <summary>
        /// Gets or sets the orientation of the timeline display.        /// 
        /// </summary>
        [JsonPropertyName("orientation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TimeLineOrientationOptions? Orientation { get; set; } = null;

        /// <summary>
        /// Gets or sets the minimum allowed zoom level, in milliseconds.
        /// </summary>
        /// <remarks>Set this property to restrict how far users can zoom out. If null, no minimum zoom
        /// constraint is applied.</remarks>
        [JsonPropertyName("zoomMin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ZoomMin { get; set; } = null;

        /// <summary>
        /// Gets or sets the maximum allowed zoom level.
        /// </summary>
        [JsonPropertyName("zoomMax")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ZoomMax { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether the current time should be displayed.
        /// </summary>
        [JsonPropertyName("showCurrentTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowCurrentTime { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether major labels are displayed on the axis.
        /// </summary>
        [JsonPropertyName("showMajorLabels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowMajorLabels { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether minor labels are displayed on the axis.
        /// </summary>
        [JsonPropertyName("showMinorLabels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowMinorLabels { get; set; } = null;

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
        //  [JsonPropertyName("zoomKey")]
        //  public string? ZoomKey { get; set; }

        /// <summary>
        /// Gets or sets the configuration options for the time axis of the timeline chart.
        /// </summary>
        /// <remarks>Use this property to customize the appearance and behavior of the time axis, such as
        /// formatting, intervals, and display settings. If not set, default axis options will be applied.</remarks>
        //  [JsonPropertyName("timeAxis")]
        // public TimeLineAxisOptions? TimeAxis { get; set; }

        /// <summary>
        /// Gets or sets the margin options for the timeline layout.
        /// </summary>
        [JsonPropertyName("margin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TimeLineMarginOptions? Margin { get; set; } = null;

        /// <summary>
        /// Gets or sets the formatting options to apply to the timeline output.
        /// </summary>
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TimeLineFormatOptions? Format { get; set; } = null;
    }

}

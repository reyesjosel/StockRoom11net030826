
using System.Text.Json.Serialization;

namespace MyStuff11net.VisTimeLine
{
    public class TimeLineItem
    {
        /// <summary>
        /// An id for the item. Using an id is not required but highly recommended.
        /// </summary>
        /// <remarks>
        /// An id is needed when dynamically adding, updating, and removing items in a DataSet.
        /// </remarks>
        [JsonPropertyName("id")]
        public int Id { get; set; } = 0;

        /// <summary>
        /// The contents of the item. This can be plain text or html code.
        /// </summary>
        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Content { get; set; } = null;

        /// <summary>
        /// The start date of the item, for example new Date(2010,9,23) 
        /// The start date is required.
        /// </summary>
        [JsonPropertyName("start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// The end date of the item.
        /// </summary>
        /// <remarks>
        /// The end date is optional, and can be left null.
        /// If end date is provided, the item is displayed as a range.
        /// If not, the item is displayed as a box.
        /// </remarks>
        [JsonPropertyName("end")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? End { get; set; } = null;

        /// <summary>
        /// This field is optional. When the group column is provided,
        /// all items with the same group are placed on one line.
        /// </summary>
        [JsonPropertyName("group")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Group { get; set; } = null;

        /// <summary>
        /// The id of a subgroup. Groups all items within a group per subgroup, and positions
        /// them on the same height instead of staking them on top of each other.
        /// </summary>
        /// <remarks>
        /// Can be ordered by specifying the option subgroupOrder of a group.
        /// </remarks>
        [JsonPropertyName("subgroup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? SubGroup { get; set; } = null;

        /// <summary>
        /// A className can be used to give items an individual css style.
        /// </summary>
        /// <remarks>
        /// For example, when an item has className 'red', one can define a css style like:
        /// .vis-item.red { color: white; background-color: red; border-color: darkred; }
        /// </remarks>
        [JsonPropertyName("className")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ClassName { get; set; } = null;

        /// <summary>
        /// Gets or sets the alignment of the content within the element.
        /// </summary>
        /// <remarks>
        /// If set this overrides the global align configuration option for this item.
        /// </remarks>
        [JsonPropertyName("align")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Align { get; set; } = null;

        /// <summary>
        /// Ability to enable/disable selectability for specific items.
        /// </summary>
        /// <remarks>
        /// Defaults to true. Does not override the timeline's selectable configuration option.
        /// </remarks>
        [JsonPropertyName("selectable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Selectable { get; set; } = null;

        /// <summary>
        /// A css text string to apply custom styling for an individual item
        /// for example "color: red; background-color: pink;".
        /// </summary>
        [JsonPropertyName("style")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Style { get; set; } = null;

        /// <summary>
        /// Add a title for the item, displayed when holding the mouse on the item.
        /// The title can be an HTML element or a string containing plain text or HTML.
        /// </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; } = null;

        /// <summary>
        /// The type of the item. Can be 'box' (default), 'point', 'range', or 'background'.
        /// </summary>
        /// <remarks>
        /// Types 'box' and 'point' need a start date, the types 'range' and 'background'
        /// needs both a start and end date.
        /// </remarks>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; } = null;

        /// <summary>
        /// Some browsers cannot handle very large DIVs so by default range DIVs can be
        /// truncated outside the visible area. Setting this to false will cause the
        /// creation of full-size DIVs.
        /// </summary>
        [JsonPropertyName("limitSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LimitSize { get; set; } = null;

        /// <summary>
        /// Ability to enable/disable editability for specific items.Defaults to true.
        /// Does not override the timeline's editable configuration option.
        /// </summary>
        [JsonPropertyName("editable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Editable { get; set; } = null;

    }
}

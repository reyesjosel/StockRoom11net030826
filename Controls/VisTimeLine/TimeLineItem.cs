using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json.Serialization;

namespace StockRoom11net.Controls.VisTimeLine
{
    /// <summary>
    /// For items, the Timeline accepts an Array, a DataSet (offering 2 way data binding),
    /// or a DataView (offering 1 way data binding). Items are regular objects and can contain
    /// the properties start, end (optional), content, group (optional), className (optional), 
    /// editable (optional), and style (optional).
    /// </summary>
    public class TimeLineItem
    {

        // ✅ Explicit parameterless constructor — required when any other
        // constructor is defined, and for object initializer syntax.
        public TimeLineItem() { }

        /// <summary>
        /// This field is optional. A className can be used to give items an individual css style.
        /// For example, when an item has className 'red', one can define a css style like:
        /// .vis-item.red { color: white;
        ///                 background-color: red;
        ///                 border-color: darkred;
        ///               }
        /// More details on how to style items can be found in the section Styles.
        /// </summary>        
        [JsonPropertyName("className")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ClassName { get; set; } = null;

        /// <summary>
        /// This field is optional. If set this overrides the global align configuration option for this item.
        /// </summary>        
        [JsonPropertyName("align")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Align { get; set; } = null;

        /// <summary>
        /// The contents of the item. This can be plain text or html code.
        /// Build the HTML content as a C# string instead:
        /// content = """<div>
        ///                 item1<br>
        ///                 <img src = "/Resources/img/Flag_Red.png"
        ///                 style="width: 24px; height: 24px;">
        ///            </div>"""
        /// </summary>
        [JsonPropertyName("content")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Content { get; set; } = "Content not available";

        /// <summary>
        /// The end date of the item. The end date is optional, and can be left null.
        /// If end date is provided, the item is displayed as a range.
        /// If not, the item is displayed as a box.
        /// </summary>        
        [JsonPropertyName("end")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? End { get; set; } = null;  // Date or number or string or Moment or null

        /// <summary>
        /// This field is optional. When the group column is provided,
        /// all items with the same group are placed on one line.
        /// A vertical axis is displayed showing the groups. Grouping
        /// items can be useful for example when showing availability
        /// of multiple people, rooms, or other resources next to each other.
        /// </summary>
        [JsonPropertyName("group")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Group { get; set; } = null;  // any type or null

        /// <summary>
        /// An id for the item. Using an id is not required but highly recommended.
        /// An id is needed when dynamically adding, updating, and removing items in a DataSet.
        /// </summary>        
        [JsonPropertyName("id")]
        public string Id { get; set; } = "0";  //  String or Number

        /// <summary>
        /// Ability to enable/disable selectability for specific items.
        /// Defaults to true. Does not override the timeline's selectable configuration option.
        /// </summary>        
        [JsonPropertyName("selectable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Selectable { get; set; } = null;

        /// <summary>
        /// The start date of the item, for example new Date(2010,9,23).
        /// The start date is required. Can not be null. If the start
        /// date is after the end date, the item is not displayed.
        /// </summary>
        [JsonPropertyName("start")]
        public DateTime Start { get; set; } = DateTime.Now;  // Date or number or string or Moment

        /// <summary>
        /// A css text string to apply custom styling for an individual itemEFtableTreeView
        /// for example "color: red; background-color: pink;".
        /// </summary>
        [JsonPropertyName("style")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Style { get; set; } = null;

        /// <summary>        
        /// The id of a subgroup. Groups all items within a group per subgroup, and positions
        /// them on the same height instead of staking them on top of each other.
        /// can be ordered by specifying the option subgroupOrder of a group.
        /// </summary>
        /// <remarks>
        /// Can be ordered by specifying the option subgroupOrder of a group.
        /// </remarks>
        [JsonPropertyName("subgroup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SubGroup { get; set; } = null;  //  String or Number or null

        /// <summary>
        /// Add a title for the item, displayed when holding the mouse on the item.
        /// The title can be an HTML element or a string containing plain text or HTML.
        /// title = " Your title here" or title = "<div>Your title here</div>"
        /// title behaves like ToolTips, shows up when the mouse hovers over the item.
        /// </summary>
        [JsonPropertyName("title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; } = null;

        /// <summary>
        /// The type of the item. Can be 'box' (default), 'point', 'range', or 'background'.
        /// Types 'box' and 'point' need a start date,
        /// the types 'range' and 'background' needs both a start and end date.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Type { get; set; } = "box";

        /// <summary>
        /// Some browsers cannot handle very large DIVs so by default range DIVs can be
        /// truncated outside the visible area. Setting this to false will cause the
        /// creation of full-size DIVs.
        /// </summary>
        [JsonPropertyName("limitSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LimitSize { get; set; } = null;

        /// <summary>
        /// Override the editable configuration option for this item.<br/>
        /// Assuming "timeline.editable.overrideItems = false", <br/>
        /// setting editable = true for an item will make it editable.<br/>
        /// By default, items are editable if the timeline is editable.<br/>
        /// If the timeline is not editable, items are not editable.
        /// </summary>
        [JsonPropertyName("editable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimeLineItemEditableOptions? Editable { get; set; } = true;  // Boolean or TimeLineItemEditableOptions
    }


    public enum TimeLineTypeEnum
    {
        box,
        point,
        range,
        background
    }

}

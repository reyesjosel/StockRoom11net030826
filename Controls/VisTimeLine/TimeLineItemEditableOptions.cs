using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json.Serialization;

namespace StockRoom11net.Controls.VisTimeLine
{
    public class TimeLineItemEditableOptions
    {
        /// <summary>
        /// Individual manipulation actions (updateTime, updateGroup and remove) can also be set on individual items.
        /// If any of the item-level actions are specified (and overrideItems is not false) then that takes precedence.
        /// over the settings at the timeline level. Current behavior is that if any of the item-level actions are not
        /// specified, those items get undefined value (rather than inheriting from the timeline level). This may change
        /// in future major releases, and code that specifies all item level values will handle major release changes better.<br/>
        /// That is, instead of using: editable: {updateTime : true},<br/>
        /// Recommend best practice:   editable: {updateTime : true, updateGroup: false, remove: false}.
        /// </summary>
        public TimeLineItemEditableOptions() { }


        /// <summary>
        /// If true, items can be dragged to another moment in time.
        /// See section Editing Items for a detailed explanation.
        /// </summary>
        [JsonPropertyName("updateTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool UpdateTime { get; set; } = true;

        /// <summary>
        /// If true, item can be dragged from one group to another.
        /// Only applicable when the Timeline has groups.
        /// See section Editing Items for a detailed explanation.
        /// </summary>
        [JsonPropertyName("updateGroup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool UpdateGroup { get; set; } = true;

        /// <summary>
        /// If true, item can be deleted by first selecting it,
        /// and then clicking the delete button on the top right of the item.
        /// See section Editing Items for a detailed explanation.
        /// </summary>
        [JsonPropertyName("remove")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool Remove { get; set; } = true;



        /// <summary>
        /// editable accepts either a bool or an options object
        /// You can't express that with two C# properties of the same name
        /// The correct solution is a single property with implicit conversion operators:
        /// </summary>
        private readonly object _value;

        private TimeLineItemEditableOptions(object value) => _value = value;

        // Implicit conversions — caller can assign either type naturally
        public static implicit operator TimeLineItemEditableOptions(bool value) => new(value);

      //  public static implicit operator TimeLineItemEditableOptions(TimeLineItemEditableOptions value) => new(value);

        // vis.js receives whichever type was assigned
        public object Value => _value;
    }
}

using System.Text.Json.Serialization;

namespace StockRoom11net.Controls.VisTimeLine
{
    public class TimeLineEditableOptions
    {
        /// <summary>
        /// If true, new items can be created by double tapping an empty space
        /// in the Timeline. See section Editing Items for a detailed explanation.
        /// </summary>
        [JsonPropertyName("add")]
        public bool Add { get; set; } = false;

        /// <summary>
        /// If true, items can be deleted by first selecting them, and then clicking the delete
        /// button on the top right of the item. See section Editing Items for a detailed explanation.
        /// </summary>
        [JsonPropertyName("remove")]
        public bool Remove { get; set; } = false;

        /// <summary>
        /// If true, items can be dragged from one group to another. Only applicable when the
        /// Timeline has groups. See section Editing Items for a detailed explanation.
        /// </summary>
        [JsonPropertyName("updateGroup")]
        public bool UpdateGroup { get; set; } = false;

        /// <summary>
        /// If true, items can be dragged to another moment in time.
        /// See section Editing Items for a detailed explanation.
        /// </summary>
        [JsonPropertyName("updateTime")]
        public bool UpdateTime { get; set; } = false;

        /// <summary>
        /// If true, item specific editable properties are overridden by timeline settings.
        /// </summary>
        [JsonPropertyName("overrideItems")]
        public bool OverrideItems { get; set; } = false;

    }

}

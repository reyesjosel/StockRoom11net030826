using System.Text.Json.Serialization;

namespace StockRoom11net.Controls.VisTimeLine
{
    public class TimeLineItemEditableOptions
    {
        [JsonPropertyName("updateTime")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? UpdateTime { get; set; } = null;

        [JsonPropertyName("updateGroup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? UpdateGroup { get; set; } = null;

        [JsonPropertyName("remove")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Remove { get; set; } = null;
    }
}

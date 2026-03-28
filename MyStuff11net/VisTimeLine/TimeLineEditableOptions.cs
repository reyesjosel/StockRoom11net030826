using System.Text.Json.Serialization;

namespace MyStuff11net.VisTimeLine
{
    public class TimeLineEditableOptions
    {
        [JsonPropertyName("add")]
        public bool? Add { get; set; }

        [JsonPropertyName("updateTime")]
        public bool? UpdateTime { get; set; }

        [JsonPropertyName("updateGroup")]
        public bool? UpdateGroup { get; set; }

        [JsonPropertyName("remove")]
        public bool? Remove { get; set; }
    }

}

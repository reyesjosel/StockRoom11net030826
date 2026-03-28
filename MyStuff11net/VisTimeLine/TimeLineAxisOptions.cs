using System.Text.Json.Serialization;

namespace MyStuff11net.VisTimeLine
{
    /// <summary>
    /// Represents configuration options for the axis of a timeline, including scale and step settings.
    /// </summary>
    /// <remarks>Use this class to specify how the timeline axis should be divided and displayed, such as the
    /// time unit for intervals and the number of units per step. These options are typically used to control the
    /// granularity and appearance of time-based data visualizations.</remarks>
    public class TimeLineAxisOptions
    {
        /// <summary>
        /// Gets or sets the time scale used for aggregation or grouping operations.
        /// </summary>
        /// <remarks>Valid values include "millisecond", "second", "minute", "hour", "day", "month", and
        /// "year". The chosen scale determines the granularity of time-based calculations or queries. If not set, the
        /// default behavior depends on the consuming API or service.</remarks>
        [JsonPropertyName("scale")]
        public string? Scale { get; set; }

        /// <summary>
        /// Gets or sets the step value used in the operation or calculation.
        /// </summary>
        [JsonPropertyName("step")]
        public int? Step { get; set; }
    }

}

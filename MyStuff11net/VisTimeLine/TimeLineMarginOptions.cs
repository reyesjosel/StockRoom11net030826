using System.Text.Json.Serialization;

namespace MyStuff11net.VisTimeLine
{
    /// <summary>
    /// Represents configuration options for specifying margins in a timeline visualization.
    /// </summary>
    /// <remarks>Use this class to define custom margin values for timeline items and axes. All properties are
    /// optional; if a property is not set, the default margin behavior is applied.</remarks>
    public class TimeLineMarginOptions
    {
        /// <summary>
        /// Gets or sets the item value.
        /// </summary>
        [JsonPropertyName("item")]
        public int? Item { get; set; }

        /// <summary>
        /// Gets or sets the axis along which the operation is performed, if applicable.
        /// </summary>
        [JsonPropertyName("axis")]
        public int? Axis { get; set; }
    }

}

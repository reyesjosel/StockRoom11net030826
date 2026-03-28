using System.Text.Json.Serialization;

namespace MyStuff11net.VisTimeLine
{
    /// <summary>
    /// Represents formatting options for timeline labels, including custom formats for minor and major time intervals.
    /// </summary>
    /// <remarks>Use this class to specify how minor and major labels are displayed on a timeline, such as
    /// customizing date and time formats for different time units. If no custom labels are provided, default formats
    /// will be used.</remarks>
    public class TimeLineFormatOptions
    {
        /// <summary>
        /// Gets or sets the collection of minor labels associated with the object.
        /// minorLabels controls the bottom / smaller labels.
        /// </summary>
        /// <remarks>Each entry in the dictionary represents a minor label, where the key is the label
        /// name and the value is the label's corresponding value. This property may be null if no minor labels are
        /// defined.</remarks>
        [JsonPropertyName("minorLabels")]
        public Dictionary<string, string>? MinorLabels { get; set; }


        [JsonPropertyName("majorLabels")]
        public Dictionary<string, string>? MajorLabels { get; set; }

        // Method to get effective minor labels
        // It returns user-defined labels if provided; otherwise, it falls back to defaults
        private static readonly Dictionary<string, string> TimeLineMinorLabelsOptions = new Dictionary<string, string>
        {
            ["millisecond"] = "SSS",
            ["second"] = "HH:mm:ss",
            ["minute"] = "HH:mm",
            ["hour"] = "HH:mm",
            ["day"] = "HH:mm",
            ["month"] = "DD",
            ["year"] = "MMM"
        };
    }

}

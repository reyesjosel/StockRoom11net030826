using System.Text.Json.Serialization;

namespace StockRoom11net.Controls.VisTimeLine
{
    /// <summary>
    /// Represents configuration options for specifying the axis and itemEFtableTreeView orientation of a timeline element.
    /// </summary>
    /// <remarks>Use this class to define how a timeline element is positioned along its axis and where
    /// individual items appear. The values assigned to the properties determine the visual orientation of the timeline
    /// in supported contexts.</remarks>
    public class TimeLineOrientationOptions
    {
        /// <summary>
        /// Gets or sets the axis position for the element.
        /// </summary>
        /// <remarks>Valid values are "top" and "bottom". The value determines where the element is
        /// rendered along the axis.</remarks>
        [JsonPropertyName("axis")]
        public string? Axis { get; set; }

        /// <summary>
        /// Gets or sets the itemEFtableTreeView position value as a string.
        /// </summary>
        /// <remarks>Valid values are "top" or "bottom". The value determines the itemEFtableTreeView's position in the
        /// context where it is used.</remarks>
        [JsonPropertyName("itemEFtableTreeView")]
        public string? Item { get; set; }
    }

}

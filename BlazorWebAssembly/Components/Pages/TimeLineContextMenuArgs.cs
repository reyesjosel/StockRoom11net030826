namespace StockRoom11net.BlazorWebAssembly.Components.Pages
{
    /// <summary>
    /// Arguments passed from JavaScript when the user right-clicks on the vis-timeline.
    /// </summary>
    public class TimeLineContextMenuArgs
    {
        /// <summary>The id of the item that was right-clicked, or null if the click was on empty space.</summary>
        public string? ItemId { get; set; }

        /// <summary>The id of the group row that was right-clicked, or null if no groups are used.</summary>
        public string? GroupId { get; set; }

        /// <summary>Horizontal position of the click relative to the browser viewport (CSS pixels).</summary>
        public double ClientX { get; set; }

        /// <summary>Vertical position of the click relative to the browser viewport (CSS pixels).</summary>
        public double ClientY { get; set; }

        /// <summary>
        /// Indicates whether the major labels on the timeline axis are currently visible.
        /// This can be used to show a context menu option based on the visibility of the major labels.
        /// </summary>
        public bool ShowMajorLabels { get; set; }

        /// <summary>The date/time on the timeline axis that corresponds to the clicked position.</summary>
        public DateTime? Time { get; set; }
    }
}

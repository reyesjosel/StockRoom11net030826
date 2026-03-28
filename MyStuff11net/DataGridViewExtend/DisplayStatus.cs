
namespace MyStuff11net.DataGridViewExtended
{
    public class DisplayStatus
    {
        private static readonly char[] separator = [','];
        public DisplayStatus(string displayStatus)
        {
            var displaystatusValues = displayStatus.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            // IsAssembly = displaystatusValues[0].Contains("true");
            IsExpanded = displaystatusValues[1].Contains("true");
            ItemsCount = Convert.ToInt32(displaystatusValues[2]);
        }

        public bool IsExpanded { get; set; }
        public int ItemsCount { get; set; }

    }
}

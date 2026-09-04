
namespace StockRoom11net.Docs
{
    internal class ApplicationInsightsTelemetry
    {
        class StockItem
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }

        StockItem item = new StockItem
        {
            Name = "Widget",
            Quantity = 10
        };

        public ApplicationInsightsTelemetry(){ }

        void TrackTelemetry()
        {            
            // Track a custom event
            Program.Telemetry.TrackEvent("StockItemAdded", new Dictionary<string, string>
            {
                { "ItemName", item.Name }
            });
        }

        void TrackException()
        { 
            // Track an exception
            try
            {
             // Some code that may throw an exception
                throw new InvalidOperationException("An error occurred while processing the stock item.");
            }
            catch (Exception ex)
            {
                Program.Telemetry.TrackException(ex);
            }
        }

        void TrackMetric(int totalCount)
        {
            // Track a metric
            Program.Telemetry.TrackMetric("ItemsInStock", totalCount);
        }
    }
}

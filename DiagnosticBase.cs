// Suggested: A shared base class
namespace StockRoom11net
{
    public interface IDiagnosticBase
    {
        /// <summary>
        /// Tracks the last known position in code execution.
        /// Used in catch blocks to identify where an error occurred.
        /// </summary>
        string MessageDebugPosition { get; set; }
    }

    public class DiagnosticBase : IDiagnosticBase
    {
        public string MessageDebugPosition { get; set; } = string.Empty;
    }
}
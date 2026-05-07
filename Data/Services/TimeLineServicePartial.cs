
namespace StockRoom11net.Data.Services;

/// <summary>
/// Service layer for TimeLine business logic using scaffolded entities
/// </summary>
public partial interface ITableTimeLineService
{
    string GetTableName();
}

public partial class TableTimeLineService : ITableTimeLineService
{
    public string GetTableName()
    {
        return "Table_TimeLine";
    }
}
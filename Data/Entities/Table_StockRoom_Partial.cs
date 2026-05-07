using System.ComponentModel.DataAnnotations.Schema;

namespace StockRoom11net.Data.Entities;

public partial class Table_StockRoom
{
    [NotMapped]
    public string TableName
    {
        get{ return GetType().Name; }
        set { }
    }
}

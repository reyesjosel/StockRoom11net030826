using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Table("Table_TimeLine_TreeView")]
[Index("Index", IsUnique = true)]
public partial class Table_TimeLine_TreeView : Table_Base_TreeView
{
    /*public Table_TimeLine_TreeView()
    [Key]
    public int Index { get; set; }

    public int ID { get; set; }

    public int? Parent_ID { get; set; }

    public string? Code { get; set; } = null!;

    public string? Range { get; set; } = null!;

    public string? Text_Name { get; set; } = null!;

    public string? Node_PDF { get; set; } = null!;

    public string? Node_Picture { get; set; } = null!;

    public string? Description_Short { get; set; } = null!;

    public string? Description_Expand { get; set; } = null!;

    public string? Image { get; set; } = null!;

    public string? String_Filter { get; set; } = null!;

    public int ItemCount { get; set; }

    public int ItemOpen { get; set; }

    public string? DateCreated { get; set; } = null!;

    public string? Created_by { get; set; } = null!;

    public string? AvailableDepartments { get; set; } = null!;

    public string? Properties { get; set; } = null!;

    public string? Message_String { get; set; } = null!;

    public string? Status { get; set; } = null!;
    */
}

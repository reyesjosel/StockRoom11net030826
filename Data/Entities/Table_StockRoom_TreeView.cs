using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Table("Table_StockRoom_TreeView")]
[Index("Index", IsUnique = true)]
public partial class Table_StockRoom_TreeView : Table_Base_TreeView
{
    /*public Table_StockRoom_TreeView()
    [Key]
    public int Index { get; set; }

    public int ID { get; set; }

    public int Parent_ID { get; set; }

    public string Code { get; set; } = null!;

    public string Range { get; set; } = null!;

    public string Text_Name { get; set; } = null!;

    [Column(TypeName = "TEXT")]
    public string Node_PDF { get; set; }

    [Column(TypeName = "TEXT")]
    public string Node_Picture { get; set; }

    [Column(TypeName = "TEXT")]
    public string Description_Short { get; set; }

    [Column(TypeName = "TEXT")]
    public string Description_Expand { get; set; }

    [Column(TypeName = "TEXT")]
    public string Image { get; set; }

    [Column(TypeName = "TEXT")]
    public string String_Filter { get; set; }

    public int ItemCount { get; set; }

    [Column(TypeName = "INTEGER")]
    public string ItemOpen { get; set; } = null!;

    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "TEXT")]
    public string Created_by { get; set; } = null!;

    [Column(TypeName = "TEXT")]
    public string AvailableDepartments { get; set; } = null!;

    [Column(TypeName = "TEXT")]
    public string Properties { get; set; } = null!;
    
    [Column(TypeName = "TEXT")]
    public string Message_String { get; set; }

    [Column(TypeName = "TEXT")]
    public string? Status { get; set; }
    */
}

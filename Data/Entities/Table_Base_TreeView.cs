using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockRoom11net.Data.Entities;

public class Table_Base_TreeView
{
    [Key]
    public int Index { get; set; }

    public int ID { get; set; }

    public int Parent_ID { get; set; }

    public string Code { get; set; } = null!;

    public string Range { get; set; } = null!;

    public string Text_Name { get; set; } = null!;

    public string Node_PDF { get; set; } = null!;

    public string Node_Picture { get; set; } = null!;

    public string Description_Short { get; set; } = null!;

    public string Description_Expand { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string String_Filter { get; set; } = null!;

    public int ItemCount { get; set; }

    public int ItemOpen { get; set; }

    public string DateCreated { get; set; } = null!;

    public string Created_by { get; set; } = null!;

    public string AvailableDepartments { get; set; } = null!;

    public string Properties { get; set; } = null!;

    public string Message_String { get; set; } = null!;

    public string Status { get; set; } = null!;

    /// <summary>
    /// Typed accessor for DateCreated.
    /// The value converter in DbContext handles string ↔ DateTime? conversion.
    /// </summary>
    [NotMapped]
    public DateTime DateCreatedAsDateTime
    {
        get => DateTime.TryParse(DateCreated, out var dt) ? dt : DateTime.Now;
        set => DateCreated = value.ToString("yyyy-MM-dd HH:mm:ss");
    }
}

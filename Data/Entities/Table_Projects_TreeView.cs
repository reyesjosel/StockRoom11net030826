using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Table("Table_Projects_TreeView")]
[Index("Code", Name = "IDXTable_Projects_TreeView_Code")]
[Index("ID", Name = "IDXTable_Projects_TreeView_ID", IsUnique = true)]
[Index("Index", Name = "IDXTable_Projects_TreeView_Index", IsUnique = true)]
public partial class Table_Projects_TreeView
{
    [Key]
    [Column(TypeName = "varchar (255)")]
    public string Index { get; set; } = null!;

    [Column(TypeName = "INT")]
    public int ID { get; set; }

    [Column(TypeName = "INT")]
    public int? Parent_ID { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Code { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Range { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? ProjectName { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Text_Name { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Node_PDF { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Node_Picture { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Description_Short { get; set; }

    [Column(TypeName = "longtext")]
    public string? Description_Expand { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Image { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? String_Filter { get; set; }

    [Column(TypeName = "longtext")]
    public string? Engineering_Change { get; set; }

    [Column(TypeName = "INT")]
    public int ItemCount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Created_by { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Message_String { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? PWBSide { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? MachineLine { get; set; }

    [Column(TypeName = "INT")]
    public int? StartPanel { get; set; }

    [Column(TypeName = "INT")]
    public int? FinishPanel { get; set; }

    [Column(TypeName = "INT")]
    public int? TotalPanel { get; set; }

    [Column("Pcs/Panel", TypeName = "INT")]
    public int? Pcs_Panel { get; set; }

    [Column(TypeName = "INT")]
    public int? QtyProduced { get; set; }

    [Column(TypeName = "INT")]
    public int? QtyProjectPlaned { get; set; }

    [Column(TypeName = "INT")]
    public int? QtyProjectProduced { get; set; }

    [Column(TypeName = "INT")]
    public int? QtyProjectRemaining { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? PCBName { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? PCBNumber { get; set; }

    [Column(TypeName = "longtext")]
    public string? PCBComment { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? BackgroundColor { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? ImageAlign { get; set; }

    [Column(TypeName = "boolean")]
    public bool? Locked { get; set; }

    [Column(TypeName = "INT")]
    public int? MinuteStartTop { get; set; }

    [Column(TypeName = "INT")]
    public int? MinuteEndTop { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Pattern { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? PatternColor { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Tag { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? TextItem { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndTime { get; set; }

    [Column(TypeName = "boolean")]
    public bool? ItemOpen { get; set; }

    [Column(TypeName = "INT")]
    public int? MyChildIs { get; set; }

    [Column(TypeName = "INT")]
    public int? MyFatherIs { get; set; }

    [Column(TypeName = "INT")]
    public int? MyGrandFatherIs { get; set; }

    [Column(TypeName = "longtext")]
    public string? Properties { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Status { get; set; }
}

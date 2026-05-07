using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Table("Table_Employees_TreeView")]
[Index("Code", Name = "IDXTable_Employees_TreeView_Code")]
[Index("ID", Name = "IDXTable_Employees_TreeView_ID", IsUnique = true)]
[Index("Index", Name = "IDXTable_Employees_TreeView_Index", IsUnique = true)]
public partial class Table_Employees_TreeView
{
    [Key]
    public int Index { get; set; }

    public int ID { get; set; }

    public string? Code { get; set; }

    public string? Range { get; set; }

    public int? Parent_ID { get; set; }

    public string? ProjectName { get; set; }

    public string? Text_Name { get; set; }

    public string? Node_PDF { get; set; }

    public string? Node_Picture { get; set; }

    public string? Description_Short { get; set; }

    public string? Description_Expand { get; set; }

    public string? Image { get; set; }

    public string? String_Filter { get; set; }

    public string? Engineering_Change { get; set; }

    public int? ItemCount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    public string? Created_by { get; set; }

    public string? Properties { get; set; }

    public string? Message_String { get; set; }

    public string? PWBSide { get; set; }

    public string? MachineLine { get; set; }

    public int? StartPanel { get; set; }

    public int? FinishPanel { get; set; }

    public int? TotalPanel { get; set; }

    [Column("Pcs/Panel")]
    public int? Pcs_Panel { get; set; }

    public int? QtyProduced { get; set; }

    public int? QtyProjectPlaned { get; set; }

    public int? QtyProjectProduced { get; set; }

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

    public int? MinuteStartTop { get; set; }

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

    public int? MyChildIs { get; set; }

    public int? MyFatherIs { get; set; }

    public int? MyGrandFatherIs { get; set; }

    public string? Status { get; set; }
}

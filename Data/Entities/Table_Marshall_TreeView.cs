using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Table("Table_Marshall_TreeView")]
[Index("Code", Name = "IDXTable_Marshall_TreeView_Code")]
[Index("ID", Name = "IDXTable_Marshall_TreeView_ID", IsUnique = true)]
[Index("Index", Name = "IDXTable_Marshall_TreeView_Index", IsUnique = true)]
public partial class Table_Marshall_TreeView
{
    [Key]
    public int Index { get; set; }

    [Column(TypeName = "INT")]
    public int ID { get; set; }

    [Column(TypeName = "INT")]
    public int? Parent_ID { get; set; }

    public string? Code { get; set; }

    public string? Range { get; set; }

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

    [Column(TypeName = "INT")]
    public int ItemCount { get; set; }

    [Column(TypeName = "boolean")]
    public bool? ItemOpen { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Created_by { get; set; }

    [Column(TypeName = "longtext")]
    public string? Properties { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Message_String { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Status { get; set; }
}

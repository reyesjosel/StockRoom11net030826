using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Table("Table_Marshall")]
[Index("ID", Name = "IDXTable_Marshall_ID", IsUnique = true)]
public partial class Table_Marshall
{
    [Key]
    [Column(TypeName = "varchar(255)")]
    public string Index { get; set; } = null!;

    [Column(TypeName = "INT")]
    public int ID { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? PartNumber { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? Description { get; set; }

    [Column(TypeName = "INT")]
    public int? Number_of_Placements { get; set; }

    [Column(TypeName = "longtext")]
    public string? Placements { get; set; }

    [Column(TypeName = "INT")]
    public int? Comp_for_Production { get; set; }

    [Column(TypeName = "INT")]
    public int? Comp_On_Hand { get; set; }

    [Column(TypeName = "INT")]
    public int? Max_Possible_Quantity { get; set; }

    [Column(TypeName = "INT")]
    public int? IndexRecord_Project { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? ProjectName { get; set; }

    [Column(TypeName = "INT")]
    public int? StockRoom_OnHold { get; set; }

    [Column(TypeName = "INT")]
    public int? StockRoom_OnHold_Remain { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? Message_String { get; set; }

    [Column(TypeName = "varchar(255)")]
    public string? Status { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Table("Table_StockRoom")]
public partial class Table_StockRoom
{
    [Key]
    public string PartNumber { get; set; } = null!;

    public string? Labeling { get; set; }

    public string? Description { get; set; }

    public string? Manufacturer { get; set; }

    public string? ModelNumber { get; set; }

    public string? Supplier { get; set; }

    public string? DataSheet_File { get; set; }

    public string? Who_uses_this { get; set; }

    public int? OnHand { get; set; }

    public int? OnHold { get; set; }

    public string? OnHoldBy { get; set; }

    public int? OnAvailable { get; set; }

    public string? Reel_Number { get; set; }

    public int? OnOrder { get; set; }

    [Column(TypeName = "INTEGER")]
    public string? OnDemand { get; set; }

    [Column(TypeName = "boolean")]
    public bool? ToOrder { get; set; }

    public int? MinQty { get; set; }

    public int? MaxQty { get; set; }

    [Column(TypeName = "INT")]
    public int? LTime { get; set; }

    [Column(TypeName = "INT")]
    public int? PrevQty { get; set; }

    [Column(TypeName = "INT")]
    public int? SalePrice { get; set; }

    [Column(TypeName = "decimal (4, 2)")]
    public double? Weight { get; set; }

    public string? Replaced_by { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastAccessTime { get; set; }

    public string? ModifiedBy { get; set; }

    public string? Properties { get; set; }

    public string? Location { get; set; }

    public int? CountTxT { get; set; }

    public int? CountPDF { get; set; }

    public int? CountDoc { get; set; }

    public int? CountDocx { get; set; }

    public string? Message_String { get; set; }

    public string? Status { get; set; }
}

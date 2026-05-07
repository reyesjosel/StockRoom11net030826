using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Table("Table_Labels_SMT")]
public partial class Table_Labels_SMT
{
    [Key]
    public int ID { get; set; }

    public string PartNumber { get; set; } = null!;

    public string? Description { get; set; }

    public int? QuantityToPrint { get; set; }

    public int? StartingValue { get; set; }

    [Column(TypeName = "NUMERIC (3, 1)")]
    public int? Darkness { get; set; }

    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    public string? BackUpField1 { get; set; }

    public int? BackUpField2 { get; set; }
}

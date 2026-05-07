using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Index("ID", Name = "IDXTable_Projects_ID", IsUnique = true)]
[Index("Index", Name = "IDXTable_Projects_Index", IsUnique = true)]
public partial class Table_Project
{
    [Key]
    public int Index { get; set; }

    [Column(TypeName = "INT")]
    public int ID { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Projects { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Description { get; set; }

    [Column(TypeName = "INT")]
    public int? Quantity { get; set; }

    [Column("To Compute?", TypeName = "boolean")]
    public bool To_Compute_ { get; set; }

    [Column(TypeName = "INT")]
    public int? ProjectionGroup { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProjectionDate { get; set; }
}

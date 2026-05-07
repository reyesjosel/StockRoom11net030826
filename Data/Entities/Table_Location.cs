using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Index("ID", Name = "IDXTable_Locations_ID", IsUnique = true)]
public partial class Table_Location
{
    [Key]
    public int Index { get; set; }

    [Column(TypeName = "INT")]
    public int ID { get; set; }

    [Column(TypeName = "INT")]
    public int Location { get; set; }

    [Column(TypeName = "INT")]
    public int Shelf { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Level { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Description { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Picture { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Document { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Capacity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastAccessTime { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? ModifiedBy { get; set; }

    [Column(TypeName = "longtext")]
    public string? Properties { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? BarCodeData { get; set; }

    [Column(TypeName = "varchar (255)")]
    public string? Status { get; set; }
}

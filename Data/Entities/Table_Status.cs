using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Keyless]
[Table("Table_Status")]
public partial class Table_Status
{
    public string? Text_Name { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    [Column(TypeName = "INT")]
    public int? MessageIcon { get; set; }

    [Column(TypeName = "INT")]
    public int? NotifycationEvent { get; set; }

    public string? String_Filter { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    public string? Created_by { get; set; }

    public string? Properties { get; set; }

    public string? Status { get; set; }
}

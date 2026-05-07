using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Table("Table_TimeLine")]
public partial class Table_TimeLine
{
    [Key]
    public int ID { get; set; }

    public string StartDate { get; set; } = null!;

    public string? StartTime { get; set; } = null!;

    public string? EndDate { get; set; } = null!;

    public string? EndTime { get; set; } = null!;

    public string? DisplayDate { get; set; } = null!;

    public string? HeadLine { get; set; } = null!;

    public string? ItemText { get; set; } = null!;

    public string? Media { get; set; } = null!;

    public string? MediaCredit { get; set; } = null!;

    public string? MediaCaption { get; set; } = null!;

    public string? MediaThumbnail { get; set; } = null!;

    public string? AltText { get; set; } = null!;

    public string? Type { get; set; } = null!;

    public string? Group { get; set; } = null!;

    public string? Background { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

[Index("ID", Name = "IDXTable_Employees_ID")]
[Index("Index", Name = "IDXTable_Employees_Index", IsUnique = true)]
public partial class Table_Employee
{
    [Key]
    public int Index { get; set; }

    [Column(TypeName = "INT")]
    public int? ID { get; set; }

    [Column(TypeName = "INT")]
    public int? Last6Digit { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Telephone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Dob { get; set; }

    [Column(TypeName = "datetime")]
    public DateOnly? HireDate { get; set; }

    public string? UserSetting { get; set; }

    public string? DataGridViewSetting { get; set; }

    public string? Position { get; set; }

    public string? Department { get; set; }

    public string? AccessLevel { get; set; }

    public string? Size { get; set; }

    public string? Status { get; set; }
}

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

    [Required]
    [Column(TypeName = "INT")]
    public int ID { get; set; }

    [Column(TypeName = "INT")]
    public int Last6Digit { get; set; }

    public string? LastName { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Telephone { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Dob { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? HireDate { get; set; }

    public string? UserSetting { get; set; }

    public string? DataGridViewSetting { get; set; }

    public string? Position { get; set; }

    /// <summary>
    /// Department or division the employee belongs to, e.g., "Sales", "IT", "HR".
    /// if this string contains "Department", it indicates the item is a department.
    /// Remenber to update the logic in the application to check for "Department" in this field
    /// when determining if an item is a department or an employee. We trated department as a special type of employee,
    /// so we can use the same table to store both employees and departments.
    /// </summary>
    public string? Department { get; set; }

    public string? AccessLevel { get; set; }

    public string? Size { get; set; }

    public string? Status { get; set; }
}

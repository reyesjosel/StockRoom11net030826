using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using StockRoom11net.Data.Repositories;

namespace StockRoom11net.Data.Entities;

[Index("ID", Name = "IDXTable_Employees_ID")]
[Index("Index", Name = "IDXTable_Employees_Index", IsUnique = true)]
public partial class Table_Employee
{
    [Key]
    public int Index { get; set; } = 0; // Default value of 0 for Index, DB auto-assigns the value (autoincrement)

    [Required] // Assign a default value of 0 for ID, which can be overridden when creating instances of this class.
               // The [Required] attribute ensures that a value must be provided for ID, even though it's an int (which cannot be null).
               // This allows for a default value while still enforcing that it cannot be left at the default when creating an instance of the class.
    [Column(TypeName = "INT")]
    public int ID { get; set; } = 0; // Default value of 0 for ID

    [Column(TypeName = "INT")]
    public int Last6Digit { get; set; }

    public string? LastName { get; set; } = "";

    public string? Name { get; set; } = "";

    public string? Address { get; set; } = "";

    public string? Telephone { get; set; } = "";

    /// <summary>
    /// Using string to store DateTime for simplicity. The DbContext will handle conversion to/from DateTime.
    /// By default, it initializes to the current date and time as a string. The format can be standardized in the DbContext converter.
    /// </summary>
    // string? — [Required] removed: see Text_Name comment above. The DbContext value converter already
    // handles null (ValueConverter<string?, DateTime?>), so null round-trips safely.
    public string? Dob { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    /// <summary>
    /// Using string to store DateTime for simplicity. The DbContext will handle conversion to/from DateTime.
    /// By default, it initializes to the current date and time as a string. The format can be standardized in the DbContext converter.
    /// </summary>
    // string? — [Required] removed: see Text_Name comment above. The DbContext value converter already
    // handles null (ValueConverter<string?, DateTime?>), so null round-trips safely.
    public string? HireDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    public string? UserSetting { get; set; } = "";

    public string? DataGridViewSetting { get; set; } = "";

    public string? Position { get; set; } = "";

    /// <summary>
    /// Department or division the employee belongs to, e.g., "Sales", "IT", "HR".
    /// if this string contains "Department", it indicates the itemEFtableTreeView is a department.
    /// Remenber to update the logic in the application to check for "Department" in this field
    /// when determining if an itemEFtableTreeView is a department or an employee. We trated department as a special type of employee,
    /// so we can use the same table to store both employees and departments.
    /// </summary>
    public string? Department { get; set; } = "";

    public string? AccessLevel { get; set; } = "AccessLevel:3;AutoSizeColumnsMode:1;EditMode:3;EnableTreeViewSetting:1";

    public string? Size { get; set; } = "";

    public string? Status { get; set; } = "";
}

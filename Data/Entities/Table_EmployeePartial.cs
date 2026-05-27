using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StockRoom11net.Data.Entities;

public partial class Table_Employee
{
    [NotMapped]
    public static string FullName
    {
        get
        {
            return "Full name";//Name + " " + LastName;
        }        
    }
}

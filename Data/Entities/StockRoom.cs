using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockRoom11net.Data;

/// <summary>
/// StockRoom entity - implements INotifyPropertyChanged for data binding
/// Replaces DataRowView with strongly-typed entity
/// </summary>
[Table("Table_StockRoom")]
public class StockRoom : INotifyPropertyChanged
{
    private int _id;
    private string? _partNumber;
    private string? _description;
    private int _quantity;
    private string? _location;
    private decimal _unitPrice;
    private DateTime? _lastUpdated;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")]
    public int Id
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    [Required]
    [MaxLength(100)]
    [Column("PartNumber")]
    public string? PartNumber
    {
        get => _partNumber;
        set
        {
            if (_partNumber != value)
            {
                _partNumber = value;
                OnPropertyChanged(nameof(PartNumber));
            }
        }
    }

    [MaxLength(500)]
    [Column("Description")]
    public string? Description
    {
        get => _description;
        set
        {
            if (_description != value)
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }

    [Column("Quantity")]
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }

    [MaxLength(100)]
    [Column("Location")]
    public string? Location
    {
        get => _location;
        set
        {
            if (_location != value)
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
    }

    [Column("UnitPrice", TypeName = "decimal(18,2)")]
    public decimal UnitPrice
    {
        get => _unitPrice;
        set
        {
            if (_unitPrice != value)
            {
                _unitPrice = value;
                OnPropertyChanged(nameof(UnitPrice));
            }
        }
    }

    [Column("LastUpdated")]
    public DateTime? LastUpdated
    {
        get => _lastUpdated;
        set
        {
            if (_lastUpdated != value)
            {
                _lastUpdated = value;
                OnPropertyChanged(nameof(LastUpdated));
            }
        }
    }

    // Navigation properties (add as needed based on your relationships)
    // public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockRoom11net.Data;

[Table("Table_Projects")]
public class Project : INotifyPropertyChanged
{
    private int _id;
    private string? _projectName;
    private string? _description;
    private DateTime? _startDate;
    private DateTime? _endDate;
    private string? _status;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get => _id;
        set { if (_id != value) { _id = value; OnPropertyChanged(nameof(Id)); } }
    }

    [Required]
    [MaxLength(200)]
    public string? ProjectName
    {
        get => _projectName;
        set { if (_projectName != value) { _projectName = value; OnPropertyChanged(nameof(ProjectName)); } }
    }

    [MaxLength(1000)]
    public string? Description
    {
        get => _description;
        set { if (_description != value) { _description = value; OnPropertyChanged(nameof(Description)); } }
    }

    public DateTime? StartDate
    {
        get => _startDate;
        set { if (_startDate != value) { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
    }

    public DateTime? EndDate
    {
        get => _endDate;
        set { if (_endDate != value) { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
    }

    [MaxLength(50)]
    public string? Status
    {
        get => _status;
        set { if (_status != value) { _status = value; OnPropertyChanged(nameof(Status)); } }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

[Table("Table_Employees")]
public class Employee : INotifyPropertyChanged
{
    private int _id;
    private string? _employeeName;
    private string? _email;
    private string? _department;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get => _id;
        set { if (_id != value) { _id = value; OnPropertyChanged(nameof(Id)); } }
    }

    [Required]
    [MaxLength(200)]
    public string? EmployeeName
    {
        get => _employeeName;
        set { if (_employeeName != value) { _employeeName = value; OnPropertyChanged(nameof(EmployeeName)); } }
    }

    [MaxLength(200)]
    public string? Email
    {
        get => _email;
        set { if (_email != value) { _email = value; OnPropertyChanged(nameof(Email)); } }
    }

    [MaxLength(100)]
    public string? Department
    {
        get => _department;
        set { if (_department != value) { _department = value; OnPropertyChanged(nameof(Department)); } }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

[Table("Table_Locations")]
public class Location : INotifyPropertyChanged
{
    private int _id;
    private string? _locationName;
    private string? _building;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get => _id;
        set { if (_id != value) { _id = value; OnPropertyChanged(nameof(Id)); } }
    }

    [Required]
    [MaxLength(100)]
    public string? LocationName
    {
        get => _locationName;
        set { if (_locationName != value) { _locationName = value; OnPropertyChanged(nameof(LocationName)); } }
    }

    [MaxLength(100)]
    public string? Building
    {
        get => _building;
        set { if (_building != value) { _building = value; OnPropertyChanged(nameof(Building)); } }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

[Table("Table_Marshall")]
public class Marshall : INotifyPropertyChanged
{
    private int _id;
    private string? _name;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get => _id;
        set { if (_id != value) { _id = value; OnPropertyChanged(nameof(Id)); } }
    }

    [MaxLength(200)]
    public string? Name
    {
        get => _name;
        set { if (_name != value) { _name = value; OnPropertyChanged(nameof(Name)); } }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

[Table("Table_TimeLine")]
public class Timeline : INotifyPropertyChanged
{
    private int _id;
    private DateTime? _eventDate;
    private string? _description;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
        get => _id;
        set { if (_id != value) { _id = value; OnPropertyChanged(nameof(Id)); } }
    }

    public DateTime? EventDate
    {
        get => _eventDate;
        set { if (_eventDate != value) { _eventDate = value; OnPropertyChanged(nameof(EventDate)); } }
    }

    [MaxLength(1000)]
    public string? Description
    {
        get => _description;
        set { if (_description != value) { _description = value; OnPropertyChanged(nameof(Description)); } }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

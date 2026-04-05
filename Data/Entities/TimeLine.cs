using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockRoom11net.Data;

/// <summary>
/// Entity representing a TimeLine item in the database
/// Used for tracking events, milestones, and historical records
/// </summary>
[Table("Table_TimeLine")]
public class TimeLine
{
    /// <summary>
    /// Primary key for the TimeLine record
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    /// <summary>
    /// Index for ordering items in the timeline
    /// </summary>
    [Required]
    public int Index { get; set; }

    /// <summary>
    /// Display name or title of the timeline item
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string Text_Name { get; set; } = string.Empty;

    /// <summary>
    /// Parent ID for hierarchical timeline structure
    /// NULL for root-level items
    /// </summary>
    public int? Parent_ID { get; set; }

    /// <summary>
    /// Path to PDF document associated with this timeline item
    /// Semicolon-separated list if multiple PDFs
    /// </summary>
    [MaxLength(500)]
    public string Node_PDF { get; set; } = string.Empty;

    /// <summary>
    /// Path to picture/image associated with this timeline item
    /// </summary>
    [MaxLength(500)]
    public string Node_Picture { get; set; } = string.Empty;

    /// <summary>
    /// Short description of the timeline event
    /// </summary>
    [MaxLength(500)]
    public string Description_Short { get; set; } = string.Empty;

    /// <summary>
    /// Expanded/detailed description of the timeline event
    /// </summary>
    [MaxLength(2000)]
    public string Description_Expand { get; set; } = string.Empty;

    /// <summary>
    /// Icon or image identifier for the timeline item
    /// </summary>
    [MaxLength(255)]
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Filter string for categorizing or filtering timeline items
    /// Format: "Category1;Category2;Department;etc"
    /// </summary>
    [MaxLength(500)]
    public string String_Filter { get; set; } = string.Empty;

    /// <summary>
    /// Count of child items or related items
    /// </summary>
    public int ItemCount { get; set; } = 0;

    /// <summary>
    /// Indicates whether the timeline item is expanded/open in tree view
    /// </summary>
    public bool ItemOpen { get; set; } = false;

    /// <summary>
    /// Date and time when this timeline item was created
    /// </summary>
    [Required]
    public DateTime DateCreated { get; set; } = DateTime.Now;

    /// <summary>
    /// User who created this timeline item
    /// Format: "FirstName LastName" or employee identifier
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string Created_by { get; set; } = string.Empty;

    /// <summary>
    /// JSON or delimited string containing additional properties
    /// Format: "Property1:Value1;Property2:Value2"
    /// </summary>
    [MaxLength(2000)]
    public string Properties { get; set; } = string.Empty;

    /// <summary>
    /// Message or note associated with this timeline item
    /// </summary>
    [MaxLength(1000)]
    public string Message_String { get; set; } = string.Empty;

    /// <summary>
    /// Current status of the timeline item
    /// Common values: "Active", "Completed", "Pending", "Cancelled"
    /// Format: "Status:Active;Locked:True;Selected:False"
    /// </summary>
    [Required]
    [MaxLength(500)]
    public string Status { get; set; } = "Active";

    #region "Navigation Properties"

    /// <summary>
    /// Parent timeline item (for hierarchical structure)
    /// </summary>
    [ForeignKey(nameof(Parent_ID))]
    public virtual TimeLine? Parent { get; set; }

    /// <summary>
    /// Child timeline items
    /// </summary>
    [InverseProperty(nameof(Parent))]
    public virtual ICollection<TimeLine> Children { get; set; } = new List<TimeLine>();

    #endregion

    #region "Computed Properties"

    /// <summary>
    /// Gets the full name (Text_Name with parent hierarchy)
    /// </summary>
    [NotMapped]
    public string FullName
    {
        get
        {
            if (Parent == null)
                return Text_Name;

            return $"{Parent.FullName} > {Text_Name}";
        }
    }

    /// <summary>
    /// Checks if this timeline item has any PDF documents
    /// </summary>
    [NotMapped]
    public bool HasPDF => !string.IsNullOrWhiteSpace(Node_PDF);

    /// <summary>
    /// Checks if this timeline item has any pictures
    /// </summary>
    [NotMapped]
    public bool HasPicture => !string.IsNullOrWhiteSpace(Node_Picture);

    /// <summary>
    /// Gets the number of days since creation
    /// </summary>
    [NotMapped]
    public int DaysSinceCreation => (DateTime.Now - DateCreated).Days;

    /// <summary>
    /// Gets list of PDF file paths
    /// </summary>
    [NotMapped]
    public List<string> PDFFiles
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Node_PDF))
                return new List<string>();

            return Node_PDF.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(s => s.Trim())
                          .ToList();
        }
    }

    /// <summary>
    /// Gets list of filter categories
    /// </summary>
    [NotMapped]
    public List<string> FilterCategories
    {
        get
        {
            if (string.IsNullOrWhiteSpace(String_Filter))
                return new List<string>();

            return String_Filter.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(s => s.Trim())
                               .ToList();
        }
    }

    /// <summary>
    /// Checks if the item is locked based on Status property
    /// </summary>
    [NotMapped]
    public bool IsLocked
    {
        get => Status?.Contains("Locked:True") ?? false;
        set
        {
            if (string.IsNullOrWhiteSpace(Status))
                Status = "Active";

            if (value)
                Status = Status.Replace("Locked:False", "Locked:True");
            else
                Status = Status.Replace("Locked:True", "Locked:False");
        }
    }

    /// <summary>
    /// Checks if the item is selected based on Status property
    /// </summary>
    [NotMapped]
    public bool IsSelected
    {
        get => Status?.Contains("Selected:True") ?? false;
        set
        {
            if (string.IsNullOrWhiteSpace(Status))
                Status = "Active";

            if (value)
                Status = Status.Replace("Selected:False", "Selected:True");
            else
                Status = Status.Replace("Selected:True", "Selected:False");
        }
    }

    #endregion

    #region "Helper Methods"

    /// <summary>
    /// Adds a PDF file path to the Node_PDF property
    /// </summary>
    public void AddPDFFile(string pdfPath)
    {
        if (string.IsNullOrWhiteSpace(pdfPath))
            return;

        if (string.IsNullOrWhiteSpace(Node_PDF))
            Node_PDF = pdfPath;
        else if (!Node_PDF.Contains(pdfPath))
            Node_PDF += $";{pdfPath}";
    }

    /// <summary>
    /// Removes a PDF file path from the Node_PDF property
    /// </summary>
    public void RemovePDFFile(string pdfPath)
    {
        if (string.IsNullOrWhiteSpace(pdfPath) || string.IsNullOrWhiteSpace(Node_PDF))
            return;

        var files = PDFFiles;
        files.Remove(pdfPath);
        Node_PDF = string.Join(";", files);
    }

    /// <summary>
    /// Adds a filter category to the String_Filter property
    /// </summary>
    public void AddFilterCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
            return;

        if (string.IsNullOrWhiteSpace(String_Filter))
            String_Filter = category;
        else if (!String_Filter.Contains(category))
            String_Filter += $";{category}";
    }

    /// <summary>
    /// Removes a filter category from the String_Filter property
    /// </summary>
    public void RemoveFilterCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(String_Filter))
            return;

        var categories = FilterCategories;
        categories.Remove(category);
        String_Filter = string.Join(";", categories);
    }

    /// <summary>
    /// Checks if this timeline item matches a filter category
    /// </summary>
    public bool MatchesFilter(string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
            return true;

        return FilterCategories.Any(c => 
            c.Equals(filter, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Creates a deep copy of this timeline item
    /// </summary>
    public TimeLine Clone()
    {
        return new TimeLine
        {
            // Don't copy ID - let database generate new one
            Index = this.Index,
            Text_Name = this.Text_Name,
            Parent_ID = this.Parent_ID,
            Node_PDF = this.Node_PDF,
            Node_Picture = this.Node_Picture,
            Description_Short = this.Description_Short,
            Description_Expand = this.Description_Expand,
            Image = this.Image,
            String_Filter = this.String_Filter,
            ItemCount = this.ItemCount,
            ItemOpen = this.ItemOpen,
            DateCreated = DateTime.Now, // New creation date
            Created_by = this.Created_by,
            Properties = this.Properties,
            Message_String = this.Message_String,
            Status = this.Status
        };
    }

    #endregion

    public override string ToString()
    {
        return $"{Text_Name} ({DateCreated:yyyy-MM-dd})";
    }
}
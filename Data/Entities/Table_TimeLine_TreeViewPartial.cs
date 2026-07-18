using System.ComponentModel.DataAnnotations.Schema;

namespace StockRoom11net.Data.Entities;

public partial class Table_TimeLine_TreeView
{
    /// <summary>
    /// Typed accessor for DateCreated.
    /// The value converter in DbContext handles string ↔ DateTime? conversion.
    /// </summary>
    [NotMapped]
    public DateTime DateCreatedAsDateTime
    {
        get => DateTime.TryParse(DateCreated, out var dt) ? dt : DateTime.Now;
        set => DateCreated = value.ToString("yyyy-MM-dd HH:mm:ss");
    }

    /// <summary>
    /// Gets or sets the list of available departments where this treeView menu is available.AvalaibleDepartments
    /// </summary>
    /// <remarks>When getting the property, the list is derived from the <c>Properties</c> string,
    /// which is expected to contain department information in a specific format. If the format is invalid or
    /// missing, a default list is returned, and the <c>Properties</c> string is updated accordingly.  When setting
    /// the property, the provided list of department names is serialized into the <c>Properties</c> string in the
    /// expected format.</remarks>
    [NotMapped]
    public List<string> AvailableDepartmentList
    {
        get
        {
            List<string> _listDepart = new List<string>();

            if (string.IsNullOrEmpty(AvailableDepartments))
                return _listDepart;

            var _strings = AvailableDepartments.Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (_strings.Length == 1)
            {
                _listDepart.Add("No set to any department yet");
                return _listDepart;
            }

            //"AvailableDepart:ToAll,StockRoom;Selected:false;Unerasable:true;Color:-36865;Note:Null;HeaderInf:Null;DisplayStatus:false,false,0"
            //      0            2             4                6            8        10             12
            if (_strings[0].Contains("AvailableDepart") && _strings.Length >= 2)
                _listDepart = _strings[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            else
            {
                AvailableDepartments = "AvailableDepart:ToAll,StockRoom;";
                _listDepart = "ToAll,StockRoom".Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            return _listDepart;
        }
        set
        {
            string listDepart = "AvailableDepart:";
            foreach (string depart in value)
            {
                listDepart += depart + ",";
            }
            listDepart = listDepart.TrimEnd(',');

            AvailableDepartments = listDepart;
        }
    }

    [NotMapped]
    public bool IsEmployee
    {
        get
        {
            if (String_Filter.Contains("Department NOT LIKE '*Department*'"))
                return true;
            else
                return false;
        }
    }

    [NotMapped]
    public bool IsDepartment
    {
        get
        {
            if (String_Filter.Contains("Department LIKE '*Department*'"))
                return true;
            else
                return false;
        }
    }

}
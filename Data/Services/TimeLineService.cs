using StockRoom11net.Data.Entities;
using System.ComponentModel;

namespace StockRoom11net.Data.Services;

/// <summary>
/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
/// Service layer for TimeLine business logic using scaffolded entities
/// </summary>
public partial interface ITableTimeLineService
{
    Task<BindingList<Table_TimeLine>> LoadTimelinesAsync();
    Task<BindingList<Table_TimeLine>> SearchTimeLinesAsync(string searchTerm);
    Task<Table_TimeLine?> GetTimeLineByIdAsync(int id);
    Task<Table_TimeLine> CreateTimeLineAsync(Table_TimeLine timeLine);
    Task UpdateTimeLineAsync(Table_TimeLine timeLine);
    Task DeleteTimeLineAsync(int id);
    Task<BindingList<Table_TimeLine>> GetTimeLinesByFilterAsync(string filter);
}

/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
public partial class TableTimeLineService : ITableTimeLineService
{
    private readonly IUnitOfWork _unitOfWork;

    public TableTimeLineService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BindingList<Table_TimeLine>> LoadTimelinesAsync()
    {
        var items = await _unitOfWork.TableTimeLines.GetAllAsync();
        return new BindingList<Table_TimeLine>(items.ToList());
    }

    public async Task<BindingList<Table_TimeLine>> SearchTimeLinesAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await LoadTimelinesAsync();

        var items = await _unitOfWork.TableTimeLines.FindAsync(t => 
        (t.HeadLine != null && t.HeadLine.Contains(searchTerm)) ||
             (t.ItemText != null && t.ItemText.Contains(searchTerm)) ||
             (t.DisplayDate != null && t.DisplayDate.Contains(searchTerm)));

        //      (t.TextName != null && t.TextName.Contains(searchTerm)) ||
        //      (t.DescriptionShort != null && t.DescriptionShort.Contains(searchTerm)));

        return new BindingList<Table_TimeLine>(items.ToList());
    }

    public async Task<BindingList<Table_TimeLine>> GetTimeLinesByFilterAsync(string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
            return await LoadTimelinesAsync();

        var items = await _unitOfWork.TableTimeLines.FindAsync(t => 
        (t.HeadLine != null && t.HeadLine.Contains(filter)) ||
             (t.ItemText != null && t.ItemText.Contains(filter)) ||
             (t.DisplayDate != null && t.DisplayDate.Contains(filter)));

           // t.StringFilter != null && t.StringFilter.Contains(filter));
        
        return new BindingList<Table_TimeLine>(items.ToList());
    }

    public async Task<Table_TimeLine?> GetTimeLineByIdAsync(int id)
    {
        return await _unitOfWork.TableTimeLines.GetByIdAsync(id);
    }

    public async Task<Table_TimeLine> CreateTimeLineAsync(Table_TimeLine timeLine)
    {
        // Ensure required fields are set
        if (timeLine.StartDate == default)
            timeLine.StartDate = DateTime.Now.ToString();
                
      //  if (string.IsNullOrEmpty(timeLine.Status))
      //      timeLine.Status = "Active";

        var created = await _unitOfWork.TableTimeLines.AddAsync(timeLine);
        await _unitOfWork.SaveChangesAsync();
        return created;
    }

    public async Task UpdateTimeLineAsync(Table_TimeLine timeLine)
    {
        _unitOfWork.TableTimeLines.Update(timeLine);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTimeLineAsync(int id)
    {
        var timeLine = await _unitOfWork.TableTimeLines.GetByIdAsync(id);
        if (timeLine != null)
        {
            _unitOfWork.TableTimeLines.Remove(timeLine);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
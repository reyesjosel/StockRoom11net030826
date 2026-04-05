using StockRoom11net.Data;
using System.ComponentModel;

namespace StockRoom11net.Services;

/// <summary>
/// Service layer for TimeLine business logic
/// Provides async operations for Timeline management
/// </summary>
public interface ITimeLineService
{
    Task<BindingList<TimeLine>> LoadTimelinesAsync();
    Task<BindingList<TimeLine>> GetTimeLinesByFilterAsync(string filter);
    Task<TimeLine?> GetTimeLineByIdAsync(int id);
    Task<TimeLine> CreateTimeLineAsync(TimeLine timeLine);
    Task UpdateTimeLineAsync(TimeLine timeLine);
    Task DeleteTimeLineAsync(int id);
    /// <summary>
    /// Create timeline and update related stock room items in one transaction
    /// </summary>
    Task CreateTimeLineAndUpdateStockAsync(TimeLine timeLine, List<int> stockRoomIds);
    /// <summary>
    /// Move timeline node to different parent with full tree restructuring
    /// </summary>
    Task MoveTimeLineNodeAsync(int nodeId, int? newParentId);
}

public class TimeLineService : ITimeLineService
{
    private readonly IUnitOfWork _unitOfWork;

    public TimeLineService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BindingList<TimeLine>> LoadTimelinesAsync()
    {
        var items = await _unitOfWork.TimeLines.GetAllAsync();
        return new BindingList<TimeLine>(items.ToList());
    }

    public async Task<BindingList<TimeLine>> GetTimeLinesByFilterAsync(string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
            return await LoadTimelinesAsync();

        var items = await _unitOfWork.TimeLines.FindAsync(t => 
            t.Text_Name.Contains(filter) || 
            t.Description_Short.Contains(filter));

        return new BindingList<TimeLine>(items.ToList());
    }

    public async Task<TimeLine?> GetTimeLineByIdAsync(int id)
    {
        return await _unitOfWork.TimeLines.GetByIdAsync(id);
    }

    public async Task<TimeLine> CreateTimeLineAsync(TimeLine timeLine)
    {
        var created = await _unitOfWork.TimeLines.AddAsync(timeLine);
        await _unitOfWork.SaveChangesAsync();
        return created;
    }

    public async Task UpdateTimeLineAsync(TimeLine timeLine)
    {
        _unitOfWork.TimeLines.Update(timeLine);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteTimeLineAsync(int id)
    {
        var timeLine = await _unitOfWork.TimeLines.GetByIdAsync(id);
        if (timeLine != null)
        {
            _unitOfWork.TimeLines.Remove(timeLine);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Create timeline and update related stock room items in one transaction
    /// </summary>
    public async Task CreateTimeLineAndUpdateStockAsync(
        TimeLine timeLine, 
        List<int> stockRoomIds)
    {
        await _unitOfWork.BeginTransactionAsync();
        
        try
        {
            // Create timeline
            var created = await _unitOfWork.TimeLines.AddAsync(timeLine);
            await _unitOfWork.SaveChangesAsync(); // Get the ID
            
            // Update related stock room items
            foreach (var stockId in stockRoomIds)
            {
                var stockRoom = await _unitOfWork.StockRooms.GetByIdAsync(stockId);
                if (stockRoom != null)
                {
                    // Add timeline reference to stock room status
                //    stockRoom.Status += $";TimeLineRef:{created.ID}";
                    _unitOfWork.StockRooms.Update(stockRoom);
                }
            }

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    /// <summary>
    /// Move timeline node to different parent with full tree restructuring
    /// </summary>
    public async Task MoveTimeLineNodeAsync(int nodeId, int? newParentId)
    {
        await _unitOfWork.BeginTransactionAsync();
        
        try
        {
            // 1. Get the node to move
            var nodeToMove = await _unitOfWork.TimeLines.GetByIdAsync(nodeId);
            if (nodeToMove == null)
                throw new InvalidOperationException("Node not found");

            // 2. Get all children (recursive)
            var allChildren = await GetAllChildrenRecursiveAsync(nodeId);

            // 3. Validate new parent is not a descendant (prevent circular reference)
            if (newParentId.HasValue && allChildren.Any(c => c.ID == newParentId.Value))
            {
                throw new InvalidOperationException(
                    "Cannot move node to its own descendant");
            }

            // 4. Update the node's parent
            nodeToMove.Parent_ID = newParentId;
            _unitOfWork.TimeLines.Update(nodeToMove);

            // 5. Update indexes of sibling nodes
            var siblings = await _unitOfWork.TimeLines.FindAsync(
                t => t.Parent_ID == newParentId && t.ID != nodeId);
            
            int index = 0;
            foreach (var sibling in siblings.OrderBy(s => s.Index))
            {
                sibling.Index = index++;
                _unitOfWork.TimeLines.Update(sibling);
            }
            
            nodeToMove.Index = index;

            // 6. Save all changes
            await _unitOfWork.SaveChangesAsync();
            
            // 7. Commit transaction
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    private async Task<List<TimeLine>> GetAllChildrenRecursiveAsync(int parentId)
    {
        var result = new List<TimeLine>();
        var directChildren = await _unitOfWork.TimeLines.FindAsync(
            t => t.Parent_ID == parentId);

        result.AddRange(directChildren);

        foreach (var child in directChildren)
        {
            var grandChildren = await GetAllChildrenRecursiveAsync(child.ID);
            result.AddRange(grandChildren);
        }

        return result;
    }
}
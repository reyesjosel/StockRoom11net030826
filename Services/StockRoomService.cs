using System.ComponentModel;

namespace StockRoom11net.Services;

/// <summary>
/// Service layer for StockRoom business logic
/// Replaces direct TableAdapter calls with modern async patterns
/// Returns BindingList for WinForms DataGridView compatibility
/// </summary>
public interface IStockRoomService
{
    Task<BindingList<StockRoom>> GetAllStockRoomsAsync();
    Task<BindingList<StockRoom>> SearchStockRoomsAsync(string searchTerm);
    Task<StockRoom?> GetStockRoomByIdAsync(int id);
    Task<StockRoom> CreateStockRoomAsync(StockRoom stockRoom);
    Task UpdateStockRoomAsync(StockRoom stockRoom);
    Task DeleteStockRoomAsync(int id);
    Task<BindingList<StockRoom>> GetLowInventoryItemsAsync(int threshold);
}

public class StockRoomService : IStockRoomService
{
    private readonly IUnitOfWork _unitOfWork;

    public StockRoomService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BindingList<StockRoom>> GetAllStockRoomsAsync()
    {
        var items = await _unitOfWork.StockRooms.GetAllAsync();
        return new BindingList<StockRoom>(items.ToList());
    }

    public async Task<BindingList<StockRoom>> SearchStockRoomsAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllStockRoomsAsync();

        var items = await _unitOfWork.StockRooms.SearchByDescriptionAsync(searchTerm);
        return new BindingList<StockRoom>(items.ToList());
    }

    public async Task<StockRoom?> GetStockRoomByIdAsync(int id)
    {
        return await _unitOfWork.StockRooms.GetByIdAsync(id);
    }

    public async Task<StockRoom> CreateStockRoomAsync(StockRoom stockRoom)
    {
        stockRoom.LastUpdated = DateTime.Now;
        await _unitOfWork.StockRooms.AddAsync(stockRoom);
        await _unitOfWork.SaveChangesAsync();
        return stockRoom;
    }

    public async Task UpdateStockRoomAsync(StockRoom stockRoom)
    {
        stockRoom.LastUpdated = DateTime.Now;
        _unitOfWork.StockRooms.Update(stockRoom);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteStockRoomAsync(int id)
    {
        var item = await _unitOfWork.StockRooms.GetByIdAsync(id);
        if (item != null)
        {
            _unitOfWork.StockRooms.Remove(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<BindingList<StockRoom>> GetLowInventoryItemsAsync(int threshold)
    {
        var items = await _unitOfWork.StockRooms.GetLowInventoryAsync(threshold);
        return new BindingList<StockRoom>(items.ToList());
    }
}

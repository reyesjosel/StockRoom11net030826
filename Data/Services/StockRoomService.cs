using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using System.ComponentModel;

namespace StockRoom11net.Data.Services;

/// <summary>
/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
/// Service layer for StockRoom business logic
/// Returns BindingList for WinForms DataGridView compatibility
/// </summary>
public interface IStockRoomService
{
    Task<BindingList<Table_StockRoom>> LoadStockRoomsAsync();
    Task<BindingList<Table_StockRoom>> SearchStockRoomsAsync(string searchTerm);
    Task<Table_StockRoom?> GetStockRoomByIdAsync(int id);
    Task<Table_StockRoom> CreateStockRoomAsync(Table_StockRoom stockRoom);
    Task UpdateStockRoomAsync(Table_StockRoom stockRoom);
    Task DeleteStockRoomAsync(int id);
    Task<BindingList<Table_StockRoom>> GetLowInventoryItemsAsync(int threshold);

    Task<BindingList<Table_StockRoom>> FilterByStringFilterAsync(string stringFilter);
}

/// <summary>
/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
/// Returns BindingList for WinForms DataGridView compatibility
/// </summary>
public class StockRoomService : IStockRoomService
{
    private readonly IUnitOfWork _unitOfWork;

    public StockRoomService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BindingList<Table_StockRoom>> LoadStockRoomsAsync()
    {
        var items = await _unitOfWork.TableStockRoomRepository.GetAllAsync();
        return new BindingList<Table_StockRoom>(items.ToList());
    }

    public async Task<BindingList<Table_StockRoom>> SearchStockRoomsAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await LoadStockRoomsAsync();

        var items = await _unitOfWork.TableStockRoomRepository.SearchByDescriptionAsync(searchTerm);
        return new BindingList<Table_StockRoom>(items.ToList());
    }

    public async Task<Table_StockRoom?> GetStockRoomByIdAsync(int id)
    {
        return await _unitOfWork.TableStockRoomRepository.GetByIdAsync(id);
    }

    public async Task<Table_StockRoom> CreateStockRoomAsync(Table_StockRoom stockRoom)
    {
        stockRoom.LastAccessTime = DateTime.Now;
        await _unitOfWork.TableStockRoomRepository.AddAsync(stockRoom);
        await _unitOfWork.SaveChangesAsync();
        return stockRoom;
    }

    public async Task UpdateStockRoomAsync(Table_StockRoom stockRoom)
    {
        stockRoom.LastAccessTime = DateTime.Now;
        await _unitOfWork.TableStockRoomRepository.UpdateSaveAsync(stockRoom);
    }

    public async Task DeleteStockRoomAsync(int id)
    {
        var item = await _unitOfWork.TableStockRoomRepository.GetByIdAsync(id);
        if (item != null)
        {
            _unitOfWork.TableStockRoomRepository.Remove(item);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<BindingList<Table_StockRoom>> GetLowInventoryItemsAsync(int threshold)
    {
        var items = await _unitOfWork.TableStockRoomRepository.GetLowInventoryAsync(threshold);
        return new BindingList<Table_StockRoom>(items.ToList());
    }

    public async Task<BindingList<Table_StockRoom>> FilterByStringFilterAsync(string stringFilter)
    {
        var results = await _unitOfWork.TableStockRoomRepository.FilterByStringFilterAsync(stringFilter);
        return new BindingList<Table_StockRoom>(results.ToList());
    }

}

using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using System.ComponentModel;

namespace StockRoom11net.Data.Services;

/// <summary>
/// Service interface for Table_TimeLine_TreeView business logic
/// </summary>
public partial interface ITableTimeLineTreeViewService
{
    string GetTableName();

    /// <summary>
    /// Finds a TreeView node by its Text_Name using EF Core.
    /// Replaces: int index = _bindingSourceTreeView.Find("Text_Name", nodeName);
    /// </summary>
    Task<Table_TimeLine_TreeView?> FindNodeByNameAsync(string nodeName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the zero-based index of the node matching Text_Name in the full list.
    /// Returns -1 if not found.
    /// </summary>
    Task<int> FindNodeIndexByNameAsync(string nodeName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a collection of Table_TimeLine_TreeView entities by their code.
    /// </summary>
    Task<IEnumerable<Table_TimeLine_TreeView>> GetByCodeAsync(string code, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a collection of Table_TimeLine_TreeView entities by their status.
    /// </summary>
    Task<IEnumerable<Table_TimeLine_TreeView>> GetByStatusAsync(string status, CancellationToken cancellationToken = default);

    /// <summary>
    /// Searches for Table_TimeLine_TreeView entities matching the specified search term.
    /// </summary>
    Task<IEnumerable<Table_TimeLine_TreeView>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default);
}

/// <summary>
/// Service implementation for Table_TimeLine_TreeView business logic
/// </summary>
public partial class TableTimeLineTreeViewService : ITableTimeLineTreeViewService
{
    public string GetTableName()
    {
        return GetType().Name;
    }

    //  In your file, since the service implements an interface, /// <inheritdoc/> means
    //the documentation is defined on that interface method, and the implementation simply inherits it.

    #region Search and Filter

    /// <inheritdoc/>
    public async Task<Table_TimeLine_TreeView?> FindNodeByNameAsync(string nodeName, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(nodeName))
            return null;

        return await _unitOfWork.TableTimeLineTreeViews
            .FirstOrDefaultAsync(node => node.Text_Name == nodeName);
    }

    /// <inheritdoc/>
    public async Task<int> FindNodeIndexByNameAsync(string nodeName, CancellationToken cancellationToken = default)        
    {
        if (string.IsNullOrEmpty(nodeName))
            return -1;

        IEnumerable<Table_TimeLine_TreeView> allNodes =
            await _unitOfWork.TableTimeLineTreeViews.GetAllAsync(cancellationToken);

        return allNodes.ToList().FindIndex(node => node.Text_Name == nodeName);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(code))
            return Enumerable.Empty<Table_TimeLine_TreeView>();

        return await _unitOfWork.TableTimeLineTreeViews
            .GetAllAsync(cancellationToken)
            .ContinueWith(t => t.Result.Where(node => node.Code == code), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetByStatusAsync(string status, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(status))
            return Enumerable.Empty<Table_TimeLine_TreeView>();

        return await _unitOfWork.TableTimeLineTreeViews
            .GetAllAsync(cancellationToken)
            .ContinueWith(t => t.Result.Where(node => node.Status == status), cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Table_TimeLine_TreeView>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(searchTerm))
            return Enumerable.Empty<Table_TimeLine_TreeView>();

        return await _unitOfWork.TableTimeLineTreeViews
            .GetAllAsync(cancellationToken)
            .ContinueWith(t => t.Result.Where(node => 
                (node.Text_Name != null && node.Text_Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                (node.Code != null && node.Code.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                (node.Description_Short != null && node.Description_Short.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            ), cancellationToken);
    }

    #endregion

}
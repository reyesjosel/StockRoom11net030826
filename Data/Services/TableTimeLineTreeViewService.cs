using StockRoom11net.Data;
using StockRoom11net.Data.Entities;
using System.ComponentModel;

namespace StockRoom11net.Data.Services;

/// <summary>
/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
/// Service interface for Table_TimeLine_TreeView business logic
/// </summary>
public partial interface ITableTimeLineTreeViewService
{
    // Basic operations
    Task<BindingList<Table_TimeLine_TreeView>> LoadTimelinesTreeViewAsync();
    Task<Table_TimeLine_TreeView?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine_TreeView>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Table_TimeLine_TreeView> CreateAsync(Table_TimeLine_TreeView entity, CancellationToken cancellationToken = default);
    Task<Table_TimeLine_TreeView> UpdateAsync(Table_TimeLine_TreeView entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

    // Tree operations
    Task<IEnumerable<Table_TimeLine_TreeView>> GetRootNodesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine_TreeView>> GetChildrenAsync(int parentId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine_TreeView>> GetFullTreeAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Table_TimeLine_TreeView>> GetSubTreeAsync(int rootId, CancellationToken cancellationToken = default);
        
    // Business logic
    Task<int> GetTotalItemCountAsync(int nodeId, CancellationToken cancellationToken = default);
    Task<bool> HasChildrenAsync(int nodeId, CancellationToken cancellationToken = default);
    Task<bool> ValidateParentChildRelationshipAsync(int childId, int parentId, CancellationToken cancellationToken = default);
}

/// <summary>
/// ✅ SERVICE — business logic: : search by name, validate, process,
/// Data access delegated to repository via UnitOfWork.
/// Service implementation for Table_TimeLine_TreeView business logic
/// </summary>
public partial class TableTimeLineTreeViewService : ITableTimeLineTreeViewService
{
    private readonly IUnitOfWork _unitOfWork;

    public TableTimeLineTreeViewService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #region Basic Operations
    
    public async Task<BindingList<Table_TimeLine_TreeView>> LoadTimelinesTreeViewAsync()
    {
        var items = await _unitOfWork.TableTimeLineTreeViewRepository.GetAllAsync();
        return new BindingList<Table_TimeLine_TreeView>(items.ToList());
    }

    public async Task<Table_TimeLine_TreeView?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            throw new ArgumentException("Id must be greater than zero.", nameof(id));

        return await _unitOfWork.TableTimeLineTreeViewRepository.GetByIDAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.TableTimeLineTreeViewRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Table_TimeLine_TreeView> CreateAsync(Table_TimeLine_TreeView entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        // Validate parent relationship if specified
        if (entity.Parent_ID > 0)
        {
            var parent = await _unitOfWork.TableTimeLineTreeViewRepository.GetByIDAsync(entity.Parent_ID ?? 0, cancellationToken);
            if (parent == null)
                throw new InvalidOperationException($"Parent node with Id {entity.Parent_ID} not found.");
        }

        return await _unitOfWork.TableTimeLineTreeViewRepository.AddAsync(entity, cancellationToken);
    }

    public async Task<Table_TimeLine_TreeView> UpdateAsync(Table_TimeLine_TreeView entity, CancellationToken cancellationToken = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var existing = await _unitOfWork.TableTimeLineTreeViewRepository.GetByIDAsync(entity.ID, cancellationToken);
        if (existing == null)
            throw new InvalidOperationException($"Entity with Id {entity.ID} not found.");

        // Validate parent relationship if changed
        if (entity.Parent_ID > 0)
        {
            // Prevent circular reference
            if (entity.ID == entity.Parent_ID)
                throw new InvalidOperationException("A node cannot be its own parent.");

            var parent = await _unitOfWork.TableTimeLineTreeViewRepository.GetByIDAsync(entity.Parent_ID ?? 0, cancellationToken);
            if (parent == null)
                throw new InvalidOperationException($"Parent node with Id {entity.Parent_ID} not found.");
        }

        await _unitOfWork.TableTimeLineTreeViewRepository.UpdateAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
            throw new ArgumentException("Id must be greater than zero.", nameof(id));

        var entity = await _unitOfWork.TableTimeLineTreeViewRepository.GetByIDAsync(id, cancellationToken);
        if (entity == null)
            return false;

        // Check if node has children
        var children = await _unitOfWork.TableTimeLineTreeViewRepository.GetChildrenAsync(id, cancellationToken);
        if (children.Any())
            throw new InvalidOperationException("Cannot delete a node that has children. Delete children first.");

        await _unitOfWork.TableTimeLineTreeViewRepository.DeleteAsync(id, cancellationToken);
        return true;
    }

    #endregion

    #region Tree Operations

    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetRootNodesAsync(CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.TableTimeLineTreeViewRepository.GetRootNodesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetChildrenAsync(int parentId, CancellationToken cancellationToken = default)
    {
        if (parentId <= 0)
            throw new ArgumentException("ParentId must be greater than zero.", nameof(parentId));

        return await _unitOfWork.TableTimeLineTreeViewRepository.GetChildrenAsync(parentId, cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetFullTreeAsync(CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.TableTimeLineTreeViewRepository.GetTreeHierarchyAsync(null, cancellationToken);
    }

    public async Task<IEnumerable<Table_TimeLine_TreeView>> GetSubTreeAsync(int rootId, CancellationToken cancellationToken = default)
    {
        if (rootId <= 0)
            throw new ArgumentException("RootId must be greater than zero.", nameof(rootId));

        return await _unitOfWork.TableTimeLineTreeViewRepository.GetTreeHierarchyAsync(rootId, cancellationToken);
    }

    #endregion
    
    #region Business Logic

    public async Task<int> GetTotalItemCountAsync(int nodeId, CancellationToken cancellationToken = default)
    {
        var node = await _unitOfWork.TableTimeLineTreeViewRepository.GetByIDAsync(nodeId, cancellationToken);
        if (node == null)
            return 0;

        var children = await _unitOfWork.TableTimeLineTreeViewRepository.GetChildrenAsync(nodeId, cancellationToken);
        var childCount = children.Sum(c => c.ItemCount ?? 0);

        return (node.ItemCount ?? 0) + childCount;
    }

    public async Task<bool> HasChildrenAsync(int nodeId, CancellationToken cancellationToken = default)
    {
        var children = await _unitOfWork.TableTimeLineTreeViewRepository.GetChildrenAsync(nodeId, cancellationToken);
        return children.Any();
    }

    public async Task<bool> ValidateParentChildRelationshipAsync(int childId, int parentId, CancellationToken cancellationToken = default)
    {
        if (childId == parentId)
            return false; // A node cannot be its own parent

        var child = await _unitOfWork.TableTimeLineTreeViewRepository.GetByIDAsync(childId, cancellationToken);
        var parent = await _unitOfWork.TableTimeLineTreeViewRepository.GetByIDAsync(parentId, cancellationToken);

        if (child == null || parent == null)
            return false;

        // Check for circular reference by traversing up the tree
        var currentNode = parent;
        while (currentNode?.Parent_ID > 0)
        {
            if (currentNode.Parent_ID == childId)
                return false; // Circular reference detected

            currentNode = await _unitOfWork.TableTimeLineTreeViewRepository.GetByIDAsync(currentNode.Parent_ID ?? 0, cancellationToken);
        }

        return true;
    }

    #endregion
}
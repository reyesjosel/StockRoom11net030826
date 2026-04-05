namespace StockRoom11net.Data;

public static class TransactionHelper
{
    /// <summary>
    /// Execute an action within a transaction with automatic rollback on error
    /// </summary>
    public static async Task ExecuteInTransactionAsync(
        this IUnitOfWork unitOfWork,
        Func<Task> action)
    {
        await unitOfWork.BeginTransactionAsync();

        try
        {
            await action();
            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    /// <summary>
    /// Execute an action within a transaction and return a result
    /// </summary>
    public static async Task<T> ExecuteInTransactionAsync<T>(
        this IUnitOfWork unitOfWork,
        Func<Task<T>> action)
    {
        await unitOfWork.BeginTransactionAsync();

        try
        {
            var result = await action();
            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();
            return result;
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
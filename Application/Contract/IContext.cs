using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Contract;

public interface IContext
{
    IExecutionStrategy CreateExecutionStrategy();
    Task<IDbContextTransaction> BeginTransactionAsync();
    void ClearTracker();

    IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class;
}
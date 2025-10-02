using Application.Contract;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implement;

public class Context : IContext
{
    readonly SqlServerContext _sqlServerContext;
    public Context(SqlServerContext sqlServerContext)
    {
        _sqlServerContext = sqlServerContext;
    }
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _sqlServerContext.Database.BeginTransactionAsync();
    }

    public void ClearTracker()
    {
        _sqlServerContext.ChangeTracker.Clear();
    }

    public IExecutionStrategy CreateExecutionStrategy()
    {
        return _sqlServerContext.Database.CreateExecutionStrategy();
    }

    public IQueryable<TEntity> GetQueryable<TEntity>() where TEntity : class
    {
        return _sqlServerContext.Set<TEntity>().AsQueryable();
    } 
    public DbSet<TEntity> Entity<TEntity>() where TEntity : class
    {
        return _sqlServerContext.Set<TEntity>();
    }

    public async Task SaveChangesAsync()
    {
      await  _sqlServerContext.SaveChangesAsync();
    }
}

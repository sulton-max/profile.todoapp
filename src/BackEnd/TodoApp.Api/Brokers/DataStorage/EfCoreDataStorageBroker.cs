using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Models.Common;
using TodoApp.Api.Models.Entities;

namespace TodoApp.Api.Brokers.DataStorage;

public class EfCoreDataStorageBroker : DbContext, IDataStorageBroker
{
    public DbSet<User> Users => Set<User>();

    public EfCoreDataStorageBroker(DbContextOptions<EfCoreDataStorageBroker> options) : base(options)
    {
    }

    public IQueryable<TEntity> Select<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity
    {
        return Set<TEntity>().Where(expression);
    }

    public ValueTask<TEntity?> SelectByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken = default) where TEntity : class, IEntity
    {
        return Set<TEntity>().FindAsync(new object[] { new[] { id } }, cancellationToken: cancellationToken);
    }

    public async ValueTask<bool> CheckByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken = default) where TEntity : class, IEntity
    {
        return await Set<TEntity>().AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async ValueTask<TEntity?> InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class, IEntity
    {
        var entry = await Set<TEntity>().AddAsync(entity, cancellationToken);
        return entry.Entity;
    }

    public ValueTask<TEntity?> UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntity
    {
        var entry = Set<TEntity>().Update(entity);
        return new ValueTask<TEntity?>(entry.Entity);
    }

    public ValueTask<TEntity?> DeleteAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class, IEntity
    {
        var entry = Set<TEntity>().Remove(entity);
        return new ValueTask<TEntity?>(entry.Entity);
    }

    public async ValueTask<bool> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken) > 0;
    }
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Brokers.DataStorage;
using TodoApp.Api.Brokers.Logger;
using TodoApp.Api.Models.Common;
using TodoApp.Api.Models.Exceptions.Entity;

namespace TodoApp.Api.Services.Foundation.Common;

public partial class EntityFoundationBaseService<TEntity> : IEntityFoundationBaseService<TEntity> where TEntity : class, IEntity
{
    private readonly IDataStorageBroker _dataStorageBroker;
    private readonly ILoggerBroker _loggerBroker;

    public EntityFoundationBaseService(IDataStorageBroker dataStorageBroker, ILoggerBroker loggerBroker)
    {
        _dataStorageBroker = dataStorageBroker;
        _loggerBroker = loggerBroker;
    }

    public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
    {
        return _dataStorageBroker.Select(expression);
    }

    public virtual ValueTask<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        if (expression is null)
            throw new ArgumentException("Query expression cannot be null");

        return new ValueTask<IEnumerable<TEntity>>(_dataStorageBroker.Select(expression).ToList());
    }

    public virtual async ValueTask<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dataStorageBroker.Select<TEntity>(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dataStorageBroker.CheckByIdAsync<TEntity>(id, cancellationToken);
    }

    public virtual async ValueTask<TEntity?> CreateAsync(TEntity entity, bool save = true, CancellationToken cancellationToken = default)
    {
        if (entity is null)
            throw new ArgumentException("Cannot create null entity", nameof(entity));

        entity.Id = default;
        await _dataStorageBroker.InsertAsync(entity, cancellationToken);
        return !save || await _dataStorageBroker.SaveAsync(cancellationToken) ? entity : throw new Exception("Failed to create entity");
    }

    public virtual async ValueTask<TEntity?> UpdateAsync(TEntity entity, bool save = true, CancellationToken cancellationToken = default)
    {
        if (entity is null)
            throw new ArgumentException("Cannot update null entity", nameof(entity));

        if (!await CheckByIdAsync(entity.Id, cancellationToken))
            throw new EntityNotFoundException();
        
        await _dataStorageBroker.UpdateAsync(entity, cancellationToken);
        return !save || await _dataStorageBroker.SaveAsync(cancellationToken) ? entity : throw new Exception("Failed to update entity");
    }

    public virtual async ValueTask<bool> DeleteAsync(Guid id, bool save = true, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken) ?? throw new EntityNotFoundException(typeof(TEntity).Name, id.ToString());
        await _dataStorageBroker.DeleteAsync(entity, cancellationToken);
        return !save || await _dataStorageBroker.SaveAsync(cancellationToken);
    }
}
using System.Linq.Expressions;
using TodoApp.Api.Models.Common;

namespace TodoApp.Api.Services.Foundation.Common;

public interface IEntityFoundationBaseService<TEntity> where TEntity : class, IEntity
{
    /// <summary>
    /// Gets entity set as queryable collection without decryption
    /// </summary>
    /// <param name="expression">Predicate expression</param>
    /// <returns>Queryable collection of entity</returns>
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// Gets entity set after querying
    /// </summary>
    /// <param name="expression">Predicate expression</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Set of queried entities</returns>
    ValueTask<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets entity by Id
    /// </summary>
    /// <param name="id">Id of entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Entity if found, otherwise null</returns>
    ValueTask<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks entity by Id
    /// </summary>
    /// <param name="id">Id of entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Entity if found, otherwise null</returns>
    ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds entity in context scope or saves it to database
    /// </summary>
    /// <param name="entity">Entity being created</param>
    /// <param name="save">Determines whether to commit changes to database</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Created entity</returns>
    ValueTask<TEntity?> CreateAsync(TEntity entity, bool save = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates entity in context scope or saves it to database
    /// </summary>
    /// <param name="entity">Entity being updated</param>
    /// <param name="save">Determines whether to commit changes to database</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Updated entity</returns>
    ValueTask<TEntity?> UpdateAsync(TEntity entity, bool save = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes entity in context scope or saves it to database
    /// </summary>
    /// <param name="id">Entity Id being deleted</param>
    /// <param name="save">Determines whether to commit changes to database</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>True if succeeded, otherwise false</returns>
    ValueTask<bool> DeleteAsync(Guid id, bool save = true, CancellationToken cancellationToken = default);
}
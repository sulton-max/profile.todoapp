using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Models.Common;
using TodoApp.Api.Models.Exceptions.Database;
using TodoApp.Api.Models.Exceptions.Entity;
using TodoApp.Api.Models.Exceptions.Foundation;

namespace TodoApp.Api.Services.Foundation.Common;

public partial class EntityFoundationBaseService<TEntity> where TEntity : class, IEntity
{
    private delegate ValueTask<TEntity> EntityAction();

    private async ValueTask<TEntity> HandleException(EntityAction action)
    {
        try
        {
            return await action();
        }
        catch (EntityNullException entityNullException)
        {
            _loggerBroker.LogError(entityNullException);
            throw new FoundationValidationException(entityNullException);
        }
        catch (InvalidEntityException invalidEntityException)
        {
            _loggerBroker.LogError(invalidEntityException);
            throw new FoundationValidationException(invalidEntityException);
        }
        catch (EntityNotFoundException entityNotFoundException)
        {
            _loggerBroker.LogError(entityNotFoundException);
            throw new FoundationValidationException(entityNotFoundException);
        }
        catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
        {
            _loggerBroker.LogError(dbUpdateConcurrencyException);
            throw new EntityLockedException(dbUpdateConcurrencyException);
        }
        catch (DbUpdateException dbUpdateException)
        {
            _loggerBroker.LogError(dbUpdateException);
            throw new FoundationFailedOperationException(dbUpdateException);
        }
        catch (SqlException sqlException)
        {
            var innerException = sqlException.Number switch
            {
                // Migration or configuration related exceptions
                207 => new DatabaseInvalidColumnNameException() as Exception,
                208 => new DatabaseInvalidObjectNameException(),

                // Validation related exceptions
                547 => new DatabaseForeignKeyViolationException("Foreign key violation error occurred.", sqlException),
                2601 => new DatabaseDuplicateKeyException("Unique constraint violation error occurred.", sqlException),
                2627 => new DatabaseDuplicateKeyException("Unique constraint violation error occurred.", sqlException),

                // Database configuration related exceptions
                4060 => new DatabaseLoginFailedException("Login failed error occurred.", sqlException),
                18456 => new DatabaseLoginFailedException("Login failed error occurred.", sqlException),

                // General exceptions
                _ => new DatabaseException("Database error occurred.", sqlException)
            };

            var exception = innerException switch
            {
                DatabaseInvalidColumnNameException ex => new DependencyValidationException(ex) as Exception,
                DatabaseInvalidObjectNameException ex => new DependencyValidationException(ex),
                DatabaseForeignKeyViolationException ex => new DependencyValidationException(ex),
                DatabaseDuplicateKeyException ex => new DependencyValidationException(ex),
                DatabaseLoginFailedException ex => new DependencyConfigurationException(ex),
                DatabaseException ex => new DependencyException(ex),
                _ => new DependencyException()
            };

            _loggerBroker.LogError(exception);
            throw exception;
        }
        catch (Exception exception)
        {
            _loggerBroker.LogError(exception);
            throw new FoundationFailedOperationException(exception);
        }
    }
}
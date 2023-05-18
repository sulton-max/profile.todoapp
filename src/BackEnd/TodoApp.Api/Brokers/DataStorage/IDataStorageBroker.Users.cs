using TodoApp.Api.Models.Users;

namespace TodoApp.Api.Brokers.DataStorage;

/// <summary>
/// Defines data storage methods for users
/// </summary>
public partial interface IDataStorageBroker
{
    /// <summary>
    /// Selects all users
    /// </summary>
    /// <returns>Queryable source of users</returns>
    IQueryable<User> SelectAllUsers();

    /// <summary>
    /// Selects a user by Id
    /// </summary>
    /// <param name="id">User id</param>
    /// <returns>User</returns>
    ValueTask<User> SelectUserByIdAsync(Guid id);

    /// <summary>
    /// Inserts a user
    /// </summary>
    /// <param name="user">User to insert</param>
    /// <returns>Inserted user</returns>
    ValueTask<User> InsertUserAsync(User user);

    /// <summary>
    /// Updates a user
    /// </summary>
    /// <param name="user">User to update</param>
    /// <returns>Updated user</returns>
    ValueTask<User> UpdateUserAsync(User user);

    /// <summary>
    /// Deletes a user
    /// </summary>
    /// <param name="user">User to delete</param>
    /// <returns>Deleted user</returns>
    ValueTask<User> DeleteUserAsync(User user);
}
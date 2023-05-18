using TodoApp.Api.Models.Users;

namespace TodoApp.Api.Services.Foundation.Users;

public interface IUserService
{
    IQueryable<User> RetrieveAllUsers();

    ValueTask<User> RetrieveUserByIdAsync(User user);

    ValueTask<User> AddUserAsync(User user);

    ValueTask<User> UpdateUserAsync(User user);

    ValueTask<User> DeleteUserAsync(User user);
}
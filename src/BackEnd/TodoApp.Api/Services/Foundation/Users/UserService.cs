using TodoApp.Api.Brokers.DataStorage;
using TodoApp.Api.Brokers.Logger;
using TodoApp.Api.Models.Users;

namespace TodoApp.Api.Services.Foundation.Users;

public partial class UserService : IUserService
{
    public UserService(ILoggerBroker loggerBroker, IDataStorageBroker dataStorageBroker)
    {
    }

    public IQueryable<User> RetrieveAllUsers()
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> RetrieveUserByIdAsync(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> AddUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> ModifyUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<User> RemoveUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}
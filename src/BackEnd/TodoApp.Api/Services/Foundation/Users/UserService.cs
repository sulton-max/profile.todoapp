using TodoApp.Api.Brokers.DataStorage;
using TodoApp.Api.Brokers.Logger;

namespace TodoApp.Api.Services.Foundation.Users;

public class UserService : IUserService
{
    public UserService(ILoggerBroker loggerBroker, IDataStorageBroker dataStorageBroker)
    {
    }
}
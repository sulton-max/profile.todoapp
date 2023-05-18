using System.Linq.Expressions;
using System.Runtime.Serialization;
using Bogus;
using Microsoft.Data.SqlClient;
using Moq;
using TodoApp.Api.Brokers.DataStorage;
using TodoApp.Api.Brokers.DateTime;
using TodoApp.Api.Brokers.Logger;
using TodoApp.Api.Models.Users;
using TodoApp.Api.Services.Foundation.Users;
using Tynamix.ObjectFiller;

namespace TodoApp.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    private readonly UserService _sut;
    private readonly Mock<IDateTimeBroker> _dateTimeBrokerMock;
    private readonly Mock<ILoggerBroker> _loggerBrokerMock;
    private readonly Mock<IDataStorageBroker> _dataStorageBrokerMock;

    private static readonly Faker<User> UserFaker = new Faker<User>()
        // .RuleFor(x => x.Id, Guid.NewGuid())
        .RuleFor(x => x.EmailAddress, x => x.Person.Email)
        .RuleFor(x => x.Password, x => new MnemonicString(1, 8, 20).GetValue())
        .RuleFor(x => x.Username, x => x.Person.UserName)
        .RuleFor(x => x.FirstName, x => x.Person.FirstName)
        .RuleFor(x => x.LastName, x => x.Person.LastName);
    // .RuleFor(x => x.CreatedDate, x => DateTimeOffset.UtcNow)
    // .RuleFor(x => x.UpdatedDate, x => DateTimeOffset.UtcNow);


    public UserServiceTests()
    {
        _dateTimeBrokerMock = new Mock<IDateTimeBroker>();
        _loggerBrokerMock = new Mock<ILoggerBroker>();
        _dataStorageBrokerMock = new Mock<IDataStorageBroker>();
        _sut = new UserService(_loggerBrokerMock.Object, _dataStorageBrokerMock.Object);
    }

    private static DateTimeOffset GetRandomDateTime() => new DateTimeRange(earliestDate: new DateTime()).GetValue();

    private static int GetRandomNumber() => new IntRange(1, 10).GetValue();

    private static int GetNegativeRandomNumber() => new IntRange(-10, -1).GetValue() * -1;

    private static string GetRandomMessage() => new MnemonicString().GetValue();

    private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
    {
        return actualException => actualException.Message == expectedException.Message &&
                                  ((actualException.InnerException == null || expectedException.InnerException == null) ||
                                   actualException.InnerException.Message == expectedException.InnerException.Message);
    }

    private static SqlException GetSqlException() => (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));

    private static IQueryable<User> CreateRandomUsers() => UserFaker.Generate(GetRandomNumber()).AsQueryable();

    private static User CreateRandomUser() => UserFaker.Generate();
}
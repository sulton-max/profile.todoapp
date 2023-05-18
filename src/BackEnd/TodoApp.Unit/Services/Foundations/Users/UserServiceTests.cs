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
        .RuleFor(x => x.LastName, x => x.Person.LastName)
        .RuleFor(x => x.CreatedDate, x => DateTimeOffset.UtcNow)
        .RuleFor(x => x.UpdatedDate, x => DateTimeOffset.UtcNow);

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

    public static TheoryData<(Action<User, dynamic> changeUser, string parameterName, object parameterValue)> InvalidUserCases()
    {
        Action<User> test = x => x.Id = default;

        return new TheoryData<(Action<User, dynamic> changeUser, string parameterName, object parameterValue)>
        {
            // ((x, value) => x.Id = value, nameof(User.Id), default(Guid)),
            ((x, value) => x.EmailAddress = value, nameof(User.EmailAddress), null),
            ((x, value) => x.EmailAddress = value, nameof(User.EmailAddress), string.Empty),
            ((x, value) => x.EmailAddress = value, nameof(User.EmailAddress), " "),
            ((x, value) => x.EmailAddress = value, nameof(User.EmailAddress), new MnemonicString(8).GetValue()),
            ((x, value) => x.Password = value, nameof(User.Password), null),
            ((x, value) => x.Password = value, nameof(User.Password), string.Empty),
            ((x, value) => x.Password = value, nameof(User.Password), new MnemonicString(8).GetValue()),
            ((x, value) => x.Username = value, nameof(User.Username), null),
            ((x, value) => x.Username = value, nameof(User.Username), string.Empty),
            ((x, value) => x.Username = value, nameof(User.Username), new MnemonicString(8).GetValue()),
            ((x, value) => x.FirstName = value, nameof(User.FirstName), null),
            ((x, value) => x.FirstName = value, nameof(User.FirstName), string.Empty),
            ((x, value) => x.FirstName = value, nameof(User.FirstName), new MnemonicString(8).GetValue()),
            ((x, value) => x.LastName = value, nameof(User.LastName), null),
            ((x, value) => x.LastName = value, nameof(User.LastName), string.Empty),
            ((x, value) => x.LastName = value, nameof(User.LastName), new MnemonicString(8).GetValue()),
            ((x, value) => x.CreatedDate = value, nameof(User.CreatedDate), default),
            ((x, value) => x.UpdatedDate = value, nameof(User.UpdatedDate), default),
        };
    }
}
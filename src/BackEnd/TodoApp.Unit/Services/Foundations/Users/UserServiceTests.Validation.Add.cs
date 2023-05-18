using EFxceptions.Models.Exceptions;
using Moq;
using NSubstitute.ExceptionExtensions;
using TodoApp.Api.Models.Users;
using TodoApp.Api.Models.Users.Exceptions;

namespace TodoApp.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task AddUserAsync_WhenGivenNull_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = null as User;
        var exception = new NullUserException();
        var expectedException = new UserValidationException(exception);

        // Act
        var act = _sut.AddUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.InsertUserAsync(It.IsAny<User>()), Times.Never);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddUserAsync_WhenGivenIdIsInvalid_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        inputUser.Id = Guid.NewGuid();
        var exception = new InvalidUserException(nameof(User.Id), inputUser.Id);
        var expectedException = new UserValidationException(exception);

        // Act
        var act = _sut.AddUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.InsertUserAsync(inputUser), Times.Never);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
    }

    [Theory]
    [MemberData(nameof(InvalidUserCases))]
    public async Task AddUserAsync_WhenGivenUserIsInvalid_ShouldThrowValidationExceptionAndLogIt(
        ( Action<User, dynamic> changeUser, string parameterName, object parameterValue ) invalidUserCase
    )
    {
        // Arrange
        var inputUser = CreateRandomUser();
        invalidUserCase.changeUser(inputUser, invalidUserCase.parameterValue);
        var exception = new InvalidUserException(invalidUserCase.parameterName, invalidUserCase.parameterValue);
        var expectedException = new UserValidationException(exception);

        // Act
        var act = _sut.AddUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.InsertUserAsync(inputUser), Times.Never);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddUserAsync_WhenGivenCreatedDateAndUpdatedDateIsNotEqual_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        inputUser.CreatedDate = GetRandomDateTime();
        inputUser.UpdatedDate = GetRandomDateTime();
        var exception = new InvalidUserException(parameterName: nameof(User.UpdatedDate), parameterValue: inputUser.UpdatedDate);
        var expectedException = new UserValidationException(exception);

        // Act
        var act = _sut.AddUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.InsertUserAsync(inputUser), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddUserAsync_WhenGivenUserAlreadyExists_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        inputUser.CreatedDate = GetRandomDateTime();
        inputUser.UpdatedDate = inputUser.CreatedDate;
        var sqlException = new DuplicateKeyException(GetRandomMessage());
        var exception = new AlreadyExistsUserException(sqlException);
        var expectedException = new UserValidationException(exception);

        _dataStorageBrokerMock.Setup(x => x.InsertUserAsync(inputUser).ThrowsAsync(sqlException));

        // Act
        var act = _sut.AddUserAsync(inputUser);

        // Assert   
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.InsertUserAsync(inputUser), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))));

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
    }
}
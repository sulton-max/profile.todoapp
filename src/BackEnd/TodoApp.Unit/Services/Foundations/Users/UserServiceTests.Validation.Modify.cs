using Force.DeepCloner;
using Moq;
using TodoApp.Api.Models.Users;
using TodoApp.Api.Models.Users.Exceptions;

namespace TodoApp.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task ModifyUserAsync_WhenGivenNull_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = null as User;
        var exception = new NullUserException();
        var expectedException = new UserValidationException(exception);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ModifyUserAsync_WhenGivenInvalidId_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        inputUser.Id = default;
        var exception = new InvalidUserException(nameof(User.Id), inputUser.Id);
        var expectedException = new UserValidationException(exception);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ModifyUserAsync_WhenGivenUserDoesNotExist_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        inputUser.Id = Guid.NewGuid();
        var exception = new NotFoundUserException(inputUser.Id);
        var expectedException = new UserValidationException(exception);

        _dataStorageBrokerMock.Setup(x => x.SelectUserByIdAsync(inputUser.Id)).ReturnsAsync(() => null);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.SelectUserByIdAsync(inputUser.Id), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ModifyUserAsync_WhenGivenUpdatedEqualsToPreviousUpdatedDate_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        inputUser.Id = Guid.NewGuid();
        var exception = new InvalidUserException(nameof(User.UpdatedDate), inputUser.UpdatedDate);
        var expectedException = new UserValidationException(exception);
        var beforeUpdateUser = inputUser.DeepClone();

        _dataStorageBrokerMock.Setup(x => x.SelectUserByIdAsync(inputUser.Id)).ReturnsAsync(beforeUpdateUser);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _dataStorageBrokerMock.Verify(x => x.SelectUserByIdAsync(inputUser.Id), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ModifyUserAsync_WhenGivenCreatedDateNotEqualsToPreviousCreatedDate_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        inputUser.Id = Guid.NewGuid();
        var beforeUpdateUser = inputUser.DeepClone();
        beforeUpdateUser.CreatedDate = beforeUpdateUser.CreatedDate.AddMinutes(GetNegativeRandomNumber());
        var exception = new InvalidUserException(nameof(User.CreatedDate), inputUser.CreatedDate);
        var expectedException = new UserValidationException(exception);

        _dataStorageBrokerMock.Setup(x => x.SelectUserByIdAsync(inputUser.Id)).ReturnsAsync(beforeUpdateUser);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _dataStorageBrokerMock.Verify(x => x.SelectUserByIdAsync(inputUser.Id), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ModifyUserAsync_WhenGivenUpdatedDateIsNotRecent_ShouldThrowValidationExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        inputUser.Id = Guid.NewGuid();
        var beforeUpdateUser = inputUser.DeepClone();
        inputUser.UpdatedDate = inputUser.UpdatedDate.AddMinutes(GetNegativeRandomNumber());
        var exception = new InvalidUserException(nameof(User.UpdatedDate), inputUser.UpdatedDate);
        var expectedException = new UserValidationException(exception);

        _dataStorageBrokerMock.Setup(x => x.SelectUserByIdAsync(inputUser.Id)).ReturnsAsync(beforeUpdateUser);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _dataStorageBrokerMock.Verify(x => x.SelectUserByIdAsync(inputUser.Id), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Theory]
    [MemberData(nameof(InvalidUserCases))]
    public async Task ModifyUserAsync_WhenGivenUserIsInvalid_ShouldThrowValidationExceptionAndLogIt(
        (Action<User, dynamic> changeUser, string parameterName, object parameterValue) userInvalidCaseAction
    )
    {
        // Arrange
        var inputUser = CreateRandomUser();
        userInvalidCaseAction.changeUser(inputUser, userInvalidCaseAction.parameterValue);
        var exception = new InvalidUserException(userInvalidCaseAction.parameterName, userInvalidCaseAction.parameterValue);
        var expectedException = new UserValidationException(exception);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }
}
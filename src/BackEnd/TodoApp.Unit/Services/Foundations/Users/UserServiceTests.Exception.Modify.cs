using Microsoft.EntityFrameworkCore;
using Moq;
using TodoApp.Api.Models.Users.Exceptions;

namespace TodoApp.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task ModifyUserAsync_WhenSqlExceptionOccurs_ShouldThrowDependencyExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        var exception = GetSqlException();
        var expectedException = new UserDependencyException(exception);

        _dateTimeBrokerMock.Setup(x => x.GetCurrentDateTime()).Returns(GetRandomDateTime());
        _dataStorageBrokerMock.Setup(x => x.UpdateUserAsync(inputUser)).ThrowsAsync(exception);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserDependencyException>(() => act.AsTask());

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.UpdateUserAsync(inputUser), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ModifyUserAsync_WhenDbUpdateExceptionOccurs_ShouldThrowDependencyExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        var exception = new DbUpdateException();
        var expectedException = new UserDependencyException(exception);

        _dateTimeBrokerMock.Setup(x => x.GetCurrentDateTime()).Returns(GetRandomDateTime());
        _dataStorageBrokerMock.Setup(x => x.UpdateUserAsync(inputUser)).ThrowsAsync(exception);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.UpdateUserAsync(inputUser), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ModifyUserAsync_WhenDbUpdateConcurrencyExceptionOccurs_ShouldThrowDependencyException()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        var dbException = new DbUpdateConcurrencyException();
        var exception = new LockedUserException(dbException);
        var expectedException = new UserDependencyException(exception);

        _dateTimeBrokerMock.Setup(x => x.GetCurrentDateTime()).Returns(GetRandomDateTime());
        _dataStorageBrokerMock.Setup(x => x.UpdateUserAsync(inputUser)).ThrowsAsync(dbException);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserValidationException>(() => act.AsTask());

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.UpdateUserAsync(inputUser), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task ModifyUserAsync_WhenExceptionOccurs_ShouldThrowServiceException()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        var innerException = new Exception();
        var exception = new FailedUserServiceException(innerException);
        var expectedException = new UserServiceException(exception);

        _dateTimeBrokerMock.Setup(x => x.GetCurrentDateTime()).Returns(GetRandomDateTime());
        _dataStorageBrokerMock.Setup(x => x.UpdateUserAsync(inputUser)).ThrowsAsync(innerException);

        // Act
        var act = _sut.ModifyUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserServiceException>(() => act.AsTask());

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.UpdateUserAsync(inputUser), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))));

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }
}
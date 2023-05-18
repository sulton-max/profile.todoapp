using Microsoft.EntityFrameworkCore;
using Moq;
using TodoApp.Api.Models.Users.Exceptions;

namespace TodoApp.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task AddUserAsync_WhenSqlExceptionOccurs_ShouldThrowDependencyExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        var sqlException = GetSqlException();
        var expectedException = new UserDependencyException(sqlException);

        _dateTimeBrokerMock.Setup(x => x.GetCurrentDateTime()).Returns(GetRandomDateTime());
        _dataStorageBrokerMock.Setup(x => x.InsertUserAsync(inputUser)).ThrowsAsync(sqlException);

        // Act
        var act = _sut.AddUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserDependencyException>(() => act.AsTask());

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.InsertUserAsync(inputUser), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddUserAsync_WhenDbExceptionOccurs_ShouldThrowDependencyExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        var dbException = new DbUpdateException();
        var expectedException = new UserDependencyException(dbException);

        _dateTimeBrokerMock.Setup(x => x.GetCurrentDateTime()).Returns(GetRandomDateTime());
        _dataStorageBrokerMock.Setup(x => x.InsertUserAsync(inputUser)).ThrowsAsync(dbException);

        // Act
        var act = _sut.AddUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserDependencyException>(() => act.AsTask());

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.InsertUserAsync(inputUser), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }

    [Fact]
    public async Task AddUserAsync_WhenExceptionOccurs_ShouldThrowFailedServiceExceptionAndLogIt()
    {
        // Arrange
        var inputUser = CreateRandomUser();
        var exception = new Exception();
        var failedServiceException = new FailedUserServiceException(exception);
        var expectedException = new UserServiceException(failedServiceException);

        _dateTimeBrokerMock.Setup(x => x.GetCurrentDateTime()).Returns(GetRandomDateTime());
        _dataStorageBrokerMock.Setup(x => x.InsertUserAsync(inputUser)).ThrowsAsync(exception);

        // Act
        var act = _sut.AddUserAsync(inputUser);

        // Assert
        await Assert.ThrowsAsync<UserServiceException>(() => act.AsTask());

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.InsertUserAsync(inputUser), Times.Once);
        _loggerBrokerMock.Verify(x => x.LogError(It.Is(SameExceptionAs(expectedException))), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }
}
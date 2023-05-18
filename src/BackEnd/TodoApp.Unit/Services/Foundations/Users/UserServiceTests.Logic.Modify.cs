using FluentAssertions;
using Force.DeepCloner;
using Moq;
using TodoApp.Api.Models.Users;

namespace TodoApp.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    [Theory]
    [MemberData(nameof(UserUpdateCases))]
    public async Task ModifyUserAsync_WhenGivenValidUser_ShouldModifyUser(Action<User> userUpdateAction)
    {
        // Arrange
        var dateTime = GetRandomDateTime();
        var beforeUpdateUser = CreateRandomUser();
        var inputUser = beforeUpdateUser.DeepClone();
        inputUser.Id = Guid.NewGuid();
        userUpdateAction(inputUser);
        var expectedUser = inputUser.DeepClone();
        expectedUser.UpdatedDate = dateTime;

        _dateTimeBrokerMock.Setup(x => x.GetCurrentDateTime()).Returns(dateTime);
        _dataStorageBrokerMock.Setup(x => x.SelectUserByIdAsync(inputUser.Id)).ReturnsAsync(beforeUpdateUser);
        _dataStorageBrokerMock.Setup(x => x.UpdateUserAsync(inputUser)).ReturnsAsync(expectedUser);

        // Act
        var actualUser = await _sut.ModifyUserAsync(expectedUser);

        // Assert
        actualUser.Should().BeEquivalentTo(expectedUser);

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.SelectUserByIdAsync(inputUser.Id), Times.Once);
        _dataStorageBrokerMock.Verify(x => x.UpdateUserAsync(inputUser), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }
}
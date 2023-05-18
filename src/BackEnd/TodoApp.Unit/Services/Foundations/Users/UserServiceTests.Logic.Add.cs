using FluentAssertions;
using Force.DeepCloner;
using Moq;

namespace TodoApp.Unit.Services.Foundations.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task Add_WhenAddedSuccessfully_ShouldReturnUser()
    {
        // Arrange
        var dateTime = GetRandomDateTime();
        var inputUser = CreateRandomUser();
        var expectedUser = inputUser.DeepClone();
        expectedUser.Id = Guid.NewGuid();

        _dateTimeBrokerMock.Setup(x => x.GetCurrentDateTime()).Returns(dateTime);
        _dataStorageBrokerMock.Setup(x => x.InsertUserAsync(inputUser)).ReturnsAsync(expectedUser);

        // Act
        var actual = await _sut.AddUserAsync(inputUser);

        // Assert
        actual.Should().BeEquivalentTo(expectedUser);

        _dateTimeBrokerMock.Verify(x => x.GetCurrentDateTime(), Times.Once());
        _dataStorageBrokerMock.Verify(x => x.InsertUserAsync(inputUser), Times.Once);

        _dateTimeBrokerMock.VerifyNoOtherCalls();
        _dataStorageBrokerMock.VerifyNoOtherCalls();
        _loggerBrokerMock.VerifyNoOtherCalls();
    }
}
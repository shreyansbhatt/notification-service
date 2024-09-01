using Moq;
using NotificationService.Application;
using NotificationService.Application.Commands;
using NotificationService.Application.Handlers;
using NotificationService.Application.Interfaces;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Tests.Handlers;

[TestClass]
public class NotificationCommandHandlerTests
{
    private Mock<INotificationService> _mockNotificationService = null!;
    private NotificationCommandHandler _handler = null!;

    [TestInitialize]
    public void Setup()
    {
        _mockNotificationService = new Mock<INotificationService>();
        _handler = new NotificationCommandHandler(_mockNotificationService.Object);
    }

    [TestMethod]
    public async Task Handle_SendNotificationCommand_ReturnsSuccessResult()
    {
        // Arrange
        var command = new SendNotificationCommand(Guid.NewGuid(), Guid.NewGuid(), Channel.Email, "Test Content");

        _mockNotificationService.Setup(service => service.SendNotificationAsync(command))
            .ReturnsAsync(Result<Notification>.SuccessResult(new Notification(Guid.NewGuid(), Guid.NewGuid(), Channel.Email, "Test Content")));

        // Act
        var result = await _handler.Handle(command);

        // Assert
        Assert.IsNotNull(result.Data);
        Assert.AreEqual("Pending", result.Data.Status);
    }
}

using Moq;
using NotificationService.Application.Commands;
using NotificationService.Application.Interfaces;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Tests.Services;

[TestClass]
public class NotificationServiceTests
{
    private Mock<IUnitOfWork> _mockUnitOfWork = null!;
    private Mock<INotificationRepository> _mockNotificationRepository = null!;
    private Mock<INotificationTypeRepository> _mockNotificationTypeRepository = null!;
    private Application.Services.NotificationService _notificationService = null!;

    [TestInitialize]
    public void Setup()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockNotificationRepository = new Mock<INotificationRepository>();
        _mockNotificationTypeRepository = new Mock<INotificationTypeRepository>();

        _mockUnitOfWork.SetupGet(u => u.NotificationRepository).Returns(_mockNotificationRepository.Object);
        _mockUnitOfWork.SetupGet(u => u.NotificationTypeRepository).Returns(_mockNotificationTypeRepository.Object);

        _notificationService = new Application.Services.NotificationService(_mockUnitOfWork.Object);
    }

    [TestMethod]
    public async Task SendNotificationAsync_ValidCommand_ReturnsSuccessResult()
    {
        // Arrange
        var command = new SendNotificationCommand(Guid.NewGuid(), Guid.NewGuid(), Channel.Email, "Test Content");

        _mockNotificationTypeRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new NotificationType("Test Type", "Test Description"));

        // Act
        var result = await _notificationService.SendNotificationAsync(command);

        // Assert
        Assert.IsNotNull(result.Data);
        Assert.AreEqual("Sent", result.Data.Status);
        _mockNotificationRepository.Verify(repo => repo.AddAsync(It.IsAny<Notification>()), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.CompleteAsync(), Times.Once);
    }
}
